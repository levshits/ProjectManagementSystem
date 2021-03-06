﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.Dto;
using PMS.Common.ListItem;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class UserDetailsModel: ModelBase
    {
        [Required]
        [Localised()]
        public string FirstName { get; set; }
        [Required]
        [Localised()]
        public string LastName { get; set; }
        [Required]
        [Localised()]
        public string Email { get; set; }

        public IList<RoleDto> RoleEntities { get; set; }
        public IList<ProjectDto> ProjectEntities { get; set; }
        public List<LookupItem> AvailableRoles { get; set; }
        public List<LookupItem> SelectedRoles { get; set; }
        public Guid[] SelectedRolesIds { get; set; }

        public List<LookupItem> AvailableProjects { get; set; }
        public List<LookupItem> SelectedProjects { get; set; }
        public Guid[] SelectedProjectsIds { get; set; }

        public UserDetailsModel()
        {
            AvailableRoles = new List<LookupItem>();
            SelectedRoles = new List<LookupItem>();
            SelectedRolesIds = new Guid[0];
            AvailableProjects = new List<LookupItem>();
            SelectedProjects = new List<LookupItem>();
            SelectedProjectsIds = new Guid[0];
            RoleEntities = new List<RoleDto>();
            ProjectEntities = new List<ProjectDto>();

        }
    }
}