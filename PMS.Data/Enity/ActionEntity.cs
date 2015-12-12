using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class ActionEntity: BaseEntity
    {
        public virtual Guid ObjectTypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual ObjectTypeEntity ObjectTypeIdObject { get; set; }
    }
}