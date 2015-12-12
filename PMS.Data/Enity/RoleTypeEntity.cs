using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class RoleTypeEntity: BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<ActionEntity> ActionEntities { get; set; }

        public RoleTypeEntity()
        {
            ActionEntities = new List<ActionEntity>();
        }
    }
}