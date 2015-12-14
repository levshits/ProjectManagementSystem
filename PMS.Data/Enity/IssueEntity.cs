using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class IssueEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Type { get; set; }
        public virtual Guid ProjectId { get; set; }
        public virtual ProjectEntity ProjectIdObject { get; set; }
        public virtual Guid SprintId { get; set; }
        public virtual ProjectEntity SprintIdObject { get; set; }
        public virtual int Status { get; set; }
        public virtual int Priority { get; set; }
        public virtual Guid AssigneeId { get; set; }
        public virtual PrincipalEntity AssigneeIdObject { get; set; }
        public virtual TimeSpan EstimatedTime { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual IList<CommentEntity> CommentEntities { get; protected set; }
        public virtual IList<MediaContentEntity> MediaContentEntities { get; protected set; }

        public IssueEntity()
        {
            CommentEntities = new List<CommentEntity>();
            MediaContentEntities = new List<MediaContentEntity>();
        }
    }
}