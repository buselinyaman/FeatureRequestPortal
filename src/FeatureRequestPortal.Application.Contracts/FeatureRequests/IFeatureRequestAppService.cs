using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FeatureRequestPortal.FeatureRequests
{
    public interface IFeatureRequestAppService :

        //ICrudService has a special order(6 generic):must
        //GetOutputDto,
        //TGetListOutputDto,
        //TKey,
        //TGetListInput,
        //TCreateInput,
        //TUpdateInput         

        ICrudAppService<
            FeatureRequestDetailDto,      // GetAsync output
            GetFeatureRequestListDto,     // GetListAsync item output
            Guid,                         // Entity ID type
            FeatureRequestListFilterDto,  // GetListAsync input
            CreateFeatureRequestDto,      // CreateAsync input
            UpdateFeatureRequestDto>      // UpdateAsync input
    {
        Task AddCommentAsync(Guid id, AddCommentDto text);
        Task VoteAsync(Guid id);
        Task<AdminFeatureRequestDto> GetAdminAsync(Guid id);
                
    }


    
}
