using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class RoleActionEntity: BaseEntity
    {
        public virtual Guid RoleId { get; set; }
        public virtual RoleEntity RoleIdObject { get; set; }
        public virtual Guid ActionId { get; set; }
        public virtual ActionEntity ActionIdObject { get; set; }
    }
}