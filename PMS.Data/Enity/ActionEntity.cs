using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class ActionEntity: BaseEntity
    {
        public virtual Guid ObjectTypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual ObjectTypeEntity ObjectTypeIdObject { get; set; }
        public virtual IList<RoleEntity> RoleEntities { get; set; }

        public ActionEntity()
        {
            RoleEntities = new List<RoleEntity>();
        } 
    }
}