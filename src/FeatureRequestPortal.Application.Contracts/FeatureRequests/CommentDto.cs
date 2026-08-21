using System;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests
{
    //output dto
    //this dto was created for transfering comments to FeatureRequestDto(for UI)
    public class CommentDto : CreationAuditedEntityDto<Guid>
    {
        public string Text { get; set; } = null!;

    }
}
