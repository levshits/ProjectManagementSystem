using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;
using PMS.Common.ListItem;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class CreateIssueModel: ModelBase
    {
        [Required]
        [Localised]
        public string Name { get; set; }
        [Required]
        [Localised]
        public string Description { get; set; }
        [Required]
        [Localised]
        public IssueTypeEnumModel Type { get; set; }
        [Required]
        [Localised]
        public Guid ProjectId { get; set; }
        public IList<LookupItem> ProjectLookupItems { get; set; }
        [Localised]
        public Guid SprintId { get; set; }
        public IList<LookupItem> SprintLookupItems { get; set; }

        public IssueStatusEnumModel Status { get; set; }
        [Required]
        [Localised]
        public IssuePriorityEnumModel Priority { get; set; }
        [Required]
        [Localised]
        public Guid AssigneeId { get; set; }
        public IList<LookupItem> PrincipalLookupItems { get; set; }
        [Required]
        [Localised]
        [DataType(DataType.Time)]
        public TimeSpan EstimatedTime { get; set; }

        public CreateIssueModel()
        {
            SprintLookupItems = new List<LookupItem>();
            PrincipalLookupItems = new List<LookupItem>();
            ProjectLookupItems = new List<LookupItem>();
        }
    }
}