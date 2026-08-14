using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests
{
    // FeatureRequest is a Aggregate Root
    public class FeatureRequest:AuditedAggregateRoot<Guid>
    {
        
        //Don't need to add Id property manually bc AuditedAggregateRoot<Guid> adds it automatically
        public string Title { get; private set; }
        public string Description { get; private set; }
        public FeatureRequestStatus Status { get; private set; }
        public int VoteCount { get; private set; }

        //
        private readonly List<Vote> _votes = new(); //Child Entity
        private readonly List<Comment> _comments = new(); //Child Entity
        public IReadOnlyList<Vote> Votes => _votes;
        public IReadOnlyList<Comment> Comments => _comments;

        // CreatorId, CreationTime, LastModifierId, LastModificationTime come from ABP automatically
        private FeatureRequest()  
        {
            //This constructure is just for ORM         
        }

        internal FeatureRequest(
           Guid id,
           string title,
           string description)
           : base(id)
        {
            SetTitle(title);
            SetDescription(description);

            Status = FeatureRequestStatus.Pending;
            VoteCount = 0;
        }

        private void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(
                title,
                nameof(title),
                maxLength: FeatureRequestConst.MaxTitleLength,
                minLength: FeatureRequestConst.MinTitleLength
            );
        }

        internal void IncreaseVoteCount()
        {
            VoteCount++; //don’t want VoteCount to be incremented externally bc of that, it is internal.
        }
        private void SetDescription(string description)
        {
            Description = Check.Length(
                description,
                nameof(description),
                maxLength: FeatureRequestConst.MaxDescriptionLength
            );
        }

       

    }

}
