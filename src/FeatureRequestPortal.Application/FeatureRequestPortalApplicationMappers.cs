using FeatureRequestPortal.FeatureRequests;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace FeatureRequestPortal;

/*
 * You can add your own mappings here.
 * [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
 * public partial class FeatureRequestPortalApplicationMappers : MapperBase<BookDto, CreateUpdateBookDto>
 * {
 *    public override partial CreateUpdateBookDto Map(BookDto source);
 *
 *    public override partial void Map(BookDto source, CreateUpdateBookDto destination);
 * }
 */

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FeatureRequestToAdminFeatureRequestDtoMapper : MapperBase<FeatureRequest, AdminFeatureRequestDto>
{
    public override partial AdminFeatureRequestDto Map(FeatureRequest source);

    public override partial void Map(FeatureRequest source, AdminFeatureRequestDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FeatureRequestToGetFeatureRequestListDtoMapper : MapperBase<FeatureRequest, GetFeatureRequestListDto>
{
    public override partial GetFeatureRequestListDto Map(FeatureRequest source);

    public override partial void Map(FeatureRequest source, GetFeatureRequestListDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CommentToCommentDtoMapper : MapperBase<Comment, CommentDto>
{
    public override partial CommentDto Map(Comment source);
    public override partial void Map(Comment source, CommentDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FeatureRequestToFeatureRequestDetailDtoMapper : MapperBase<FeatureRequest, FeatureRequestDetailDto>
{
    public override partial FeatureRequestDetailDto Map(FeatureRequest source);
    public override partial void Map(FeatureRequest source, FeatureRequestDetailDto destination);
}


