using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.Dto;
using PMS.Common.ListItem;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class CreateRoleFirstStepModel: ModelBase
    {
        [Required]
        [Localised]
        public string Name { get; set; }
        [Required]
        [Localised()]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Localised("Role type")]
        public Guid RoleTypeId { get; set; }
        public IList<LookupItem> RoleTypeLookupItems { get; set; }
    }
}