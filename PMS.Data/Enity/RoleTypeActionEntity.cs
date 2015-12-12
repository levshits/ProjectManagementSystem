using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class RoleTypeActionEntity: BaseEntity
    {
        public virtual Guid RoleTypeId { get; set; }
        public virtual RoleTypeEntity RoleTypeIdObject { get; set; }
        public virtual Guid ActionId { get; set; }
        public virtual ActionEntity ActionIdObject { get; set; }
    }
}