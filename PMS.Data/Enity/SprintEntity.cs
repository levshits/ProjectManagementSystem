using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class SprintEntity: BaseEntity
    {
        public virtual Guid ProjectId { get; set; }
        public virtual ProjectEntity ProjectIdObject { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string ProjectVersion { get; set; }
        public virtual IList<IssueEntity> IssueEntities { get; set; }

        public SprintEntity()
        {
            IssueEntities = new List<IssueEntity>();
        } 
    }
}