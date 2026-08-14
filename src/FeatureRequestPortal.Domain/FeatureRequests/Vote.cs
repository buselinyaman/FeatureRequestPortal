using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests
{
    public class Vote : CreationAuditedEntity<Guid>
    {
        //Don't need to add Id property manually bc CreationAuditedEntity<Guid> adds it automatically
        // Foreign Key
        public Guid FeatureRequestId {  get; private set; }

        // CreatorId, CreationTime come from ABP automatically
        protected Vote() 
        {
            //This constructure is just for ORM 
        }

        internal Vote
            (
            Guid id,
            Guid featureRequestId            
            ):base(id)
        {
            FeatureRequestId = featureRequestId;
        }
    }
}
