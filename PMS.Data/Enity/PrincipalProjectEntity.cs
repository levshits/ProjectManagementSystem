using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class PrincipalProjectEntity: BaseEntity
    {
        public virtual Guid ProjectId { get; set; }
        public virtual ProjectEntity ProjectIdObject { get; set; }
        public virtual Guid PrincipalId{ get; set; }
        public virtual PrincipalEntity PrincipalIdObject{ get; set; }
        public virtual DateTime CreateTime { get; set; }
         
    }
}