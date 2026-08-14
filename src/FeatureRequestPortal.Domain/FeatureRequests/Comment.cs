using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests
{
    public class Comment : CreationAuditedEntity<Guid>
    {
        //Don't need to add Id property manually bc CreationAuditedEntity<Guid> adds it automatically
        // Foreign Key
        public Guid FeatureRequestId { get; private set; }

        // CreatorId, CreationTime come from ABP automatically
        public string Text { get; private set; }

        protected Comment() 
        {
            //This constructure is just for ORM  

        }
        internal Comment(
            Guid id,
            Guid featureRequestId,
            string text): base(id)
        {
            FeatureRequestId = featureRequestId;

            Text = Check.NotNullOrWhiteSpace(
                text,
                nameof(text),
                maxLength: FeatureRequestConst.MaxCommentLength,
                minLength: FeatureRequestConst.MinCommentLength
            );
        }
    }
}