using System;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests
{
    //output dto
    public class CommentDto : CreationAuditedEntityDto<Guid>
    {
        public string Text { get; set; } = null!;

    }
}
