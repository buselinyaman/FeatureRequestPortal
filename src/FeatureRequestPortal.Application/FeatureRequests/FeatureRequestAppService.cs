using FeatureRequestPortal.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FeatureRequestPortal.FeatureRequests
{
    public class FeatureRequestAppService :
        CrudAppService<
            FeatureRequest,                  // Entity
            FeatureRequestDetailDto,         // GetAsync output
            GetFeatureRequestListDto,        // GetListAsync output
            Guid,                            // Primary key
            FeatureRequestListFilterDto,     // Paging / sorting / filtering
            CreateFeatureRequestDto,         // Create input
            UpdateFeatureRequestDto>,        // Update input
        IFeatureRequestAppService
    {
        public FeatureRequestAppService(
            IRepository<FeatureRequest, Guid> repository)
            : base(repository)
        {
            DeletePolicyName = FeatureRequestPortalPermissions.Delete;
        }

        [Authorize]
        public override async Task<FeatureRequestDetailDto> CreateAsync(CreateFeatureRequestDto input)

        {
            var featureRequest = new FeatureRequest
                (
                GuidGenerator.Create(),
                input.Title,
                input.Description
                );

            await Repository.InsertAsync( featureRequest );

            var featureRequestDto = ObjectMapper.Map<FeatureRequest, FeatureRequestDetailDto>(featureRequest);
            
            return featureRequestDto;
        }

        public override async Task<FeatureRequestDetailDto> GetAsync(Guid id)
        {
            var featureRequest = await Repository.GetAsync(id, includeDetails: true);

            if (!CurrentUser.IsAuthenticated &&
                featureRequest.Status != FeatureRequestStatus.Approved)
            {
                throw new Volo.Abp.Authorization.AbpAuthorizationException();
            }

            var featureRequestDto = ObjectMapper.Map<FeatureRequest, FeatureRequestDetailDto>(featureRequest);
           
            return featureRequestDto;
        }

        [Authorize(FeatureRequestPortalPermissions.Manage)]
        public async Task<AdminFeatureRequestDto> GetAdminAsync(Guid id)
        {
            var featureRequest = await Repository.GetAsync(id, includeDetails: true);

            var featureRequestDto = ObjectMapper.Map<FeatureRequest, AdminFeatureRequestDto>(featureRequest);
            
            return featureRequestDto;

        }

        [Authorize]
        public async Task AddCommentAsync(Guid id, AddCommentDto input) 
        {
            var featureRequest = await Repository.GetAsync(id);

            featureRequest.AddComment(
                GuidGenerator.Create(),
                input.Text);

            await Repository.UpdateAsync(featureRequest);
        }
         
        [Authorize]
        public async Task VoteAsync(Guid id)
        {
            var featureRequest = await Repository.GetAsync(id, includeDetails: true);

            var userId = CurrentUser.Id!.Value;

            featureRequest.AddVote(
                GuidGenerator.Create(),
                userId
                );

            await Repository.UpdateAsync(featureRequest);

        }

        public override async Task<PagedResultDto<GetFeatureRequestListDto>> GetListAsync(FeatureRequestListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();

            //anonymous users can only see 'Approved' feature requests

            if (!CurrentUser.IsAuthenticated)
            {
                query = query.Where(x => x.Status == FeatureRequestStatus.Approved);

            }

            //authenticated users can filter by status
            else if (input.Status.HasValue)
            {
                query = query.Where(x => x.Status == input.Status.Value);
            }

            //get total count before paging
            var totalCount = await AsyncExecuter.CountAsync(query);

            //sorting
                query = query
                    .OrderBy(input.Sorting.IsNullOrWhiteSpace()
                        ? $"{nameof(FeatureRequest.CreationTime)} DESC"
                        : input.Sorting
                    )
                    .Skip(input.SkipCount)
                    .Take(15);

            //execute query
            var featureRequests = await AsyncExecuter.ToListAsync(query);

            //map entities to list Dto
            var featureRequestDtos =
                ObjectMapper.Map<
                    List<FeatureRequest>,
                    List<GetFeatureRequestListDto>
                >(featureRequests);

            

            return new PagedResultDto<GetFeatureRequestListDto>(
                totalCount,
                featureRequestDtos
            );

        }

        [Authorize(FeatureRequestPortalPermissions.Update)]
        public override async Task<FeatureRequestDetailDto> UpdateAsync(Guid id, UpdateFeatureRequestDto input)
        {
            var featureRequest = await Repository.GetAsync(id);

            featureRequest.ChangeTitle(input.Title);
            featureRequest.ChangeDescription(input.Description);
            featureRequest.ChangeStatus(input.Status);

            await Repository.UpdateAsync(featureRequest);

            var featureRequestDto = ObjectMapper.Map<FeatureRequest, FeatureRequestDetailDto>(featureRequest);

            return featureRequestDto;

        }

        
    }
}