using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests
{
    //input dto
    public class FeatureRequestListFilterDto : PagedAndSortedResultRequestDto
    {
        public FeatureRequestStatus? Status { get; set; }
        //SkipCount, MaxResultCount, Sorting coming from PagedAndSortedResultRequestDto
    }
}
