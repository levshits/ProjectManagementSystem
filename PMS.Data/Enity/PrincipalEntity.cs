﻿using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class PrincipalEntity: BaseEntity
    {
        public virtual string Username { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<ProjectEntity> ProjectEntities { get; set; }
        public virtual IList<PrincipalProjectEntity> PrincipalProjectEntities { get; set; }
        public virtual IList<IssueEntity> IssueEntities { get; set; }
        public virtual IList<RoleEntity> RoleEntities { get; set; }
        public virtual IList<PrincipalRoleEntity> PrincipalRoleEntities { get; set; }
        public virtual IList<ActionEntity> ActionEntities { get; set; }

        public PrincipalEntity()
        {
            ProjectEntities = new List<ProjectEntity>();
            IssueEntities = new List<IssueEntity>();
            RoleEntities = new List<RoleEntity>();
            PrincipalProjectEntities = new List<PrincipalProjectEntity>();
            PrincipalRoleEntities = new List<PrincipalRoleEntity>();
            ActionEntities = new List<ActionEntity>();
        }
    }
}