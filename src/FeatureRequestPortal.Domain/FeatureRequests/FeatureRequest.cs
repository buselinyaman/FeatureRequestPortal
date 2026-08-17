using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests
{
    // FeatureRequest is a Aggregate Root
    public class FeatureRequest:AuditedAggregateRoot<Guid>, ISoftDelete
    {
        
        //Don't need to add Id property manually bc AuditedAggregateRoot<Guid> adds it automatically
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public FeatureRequestStatus Status { get; private set; }
        public int VoteCount { get; private set; }
        public bool IsDeleted { get; private set; }

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


        //it is for generating new Feature request
        internal FeatureRequest(
           Guid id,
           string title,
           string? description)
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

        private void SetDescription(string? description)
        {
            Description = Check.Length(
                description,
                nameof(description),
                maxLength: FeatureRequestConst.MaxDescriptionLength
            );
        }

        public void AddVote(Guid voteId, Guid userId)
        {
            bool alreadyVoted = _votes.Any(vote => vote.CreatorId == userId);

            if (alreadyVoted)
            {
                throw new BusinessException("Already Voted");
            }

            _votes.Add(new Vote(voteId, Id));

            VoteCount++;
        }

        public void AddComment(Guid commentId, string text) 
        {
            _comments.Add(new Comment(commentId, Id, text));
        }

        // It is used for changing the status of the Feature Request
        public void ChangeStatus(FeatureRequestStatus status)
        {
            Status = status;
        }

    }

}
