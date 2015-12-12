using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class CommentEntity: BaseEntity
    {
        public virtual string Text { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual Guid CreatorId { get; set; }
        public virtual PrincipalEntity CreatorIdObject { get; set; }
        public virtual Guid IssueId { get; set; }
        public virtual IssueEntity IssueIdObject { get; set; }
    }
}