using System;
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
    }
}