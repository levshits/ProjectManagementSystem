using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class ProjectEntity: BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid CreatorId { get; set; }
        public virtual PrincipalEntity CreatorIdObject { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual IList<IssueEntity> IssueEntities { get; protected set; }

        public ProjectEntity()
        {
            IssueEntities = new List<IssueEntity>();
        }
    }
}