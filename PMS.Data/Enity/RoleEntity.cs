using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class RoleEntity: BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid RoleTypeId { get; set; }
        public virtual RoleTypeEntity RoleTypeIdObject { get; set; }
        public virtual Guid CreatorId { get; set; }
        public virtual PrincipalEntity CreatorIdObject { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual IList<ActionEntity> ActionEntities { get; protected set; }
        public virtual IList<RoleActionEntity> RoleActionEntities { get; protected set; }

        public RoleEntity()
        {
            ActionEntities = new List<ActionEntity>();
            RoleActionEntities = new List<RoleActionEntity>();
        }
    }
}