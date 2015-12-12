using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class SprintEntity: BaseEntity
    {
        public virtual Guid ProjectId { get; set; }
        public ProjectEntity ProjectIdObject { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string ProjectVersion { get; set; }
    }
}