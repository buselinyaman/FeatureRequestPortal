using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests
{
    //output dto
    public class AdminFeatureRequestDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public FeatureRequestStatus Status { get; set; }
        public int VoteCount { get; set; }
        public bool IsDeleted { get; set; }
        public List<CommentDto> Comments { get; set; } = new();

        // Id, CreatorId, CreationTime ,LastModifierId ,LastModificationTime coming from AuditedEntityDto<Guid>


    }
}
