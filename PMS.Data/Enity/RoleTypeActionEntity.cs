using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class RoleTypeActionEntity: BaseEntity
    {
        public Guid RoleTypeId { get; set; }
        public RoleTypeEntity RoleTypeIdObject { get; set; }
        public Guid ActionId { get; set; }
        public ActionEntity ActionIdObject { get; set; }
    }
}