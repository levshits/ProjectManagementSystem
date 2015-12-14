using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.ListItem;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class CreateSprintModel : ModelBase
    {
        [Required]
        [Localised()]
        public Guid ProjectId { get; set; }
        public IList<LookupItem> ProjectLookupItems { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [Required]
        public string ProjectVersion { get; set; }
    }
}