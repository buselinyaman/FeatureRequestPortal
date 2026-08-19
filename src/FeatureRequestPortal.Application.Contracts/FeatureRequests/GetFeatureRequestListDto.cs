using System;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests
{
    //output dto
    public class GetFeatureRequestListDto : EntityDto<Guid>
    {
        public string Title { get; set; } = null!;
        public int VoteCount { get; set; }
        public FeatureRequestStatus Status { get; set; }
    }
}
