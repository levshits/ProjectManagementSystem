using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class PrincipalRoleEntity : BaseEntity
    {
        public virtual Guid PrincipalId { get; set; }
        public virtual PrincipalEntity PrincipalIdObject { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual RoleEntity RoleIdObject { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}