using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Web.Models
{
    public class SprintListItemModel: ListItemModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        public string ProjectVersion { get; set; }
    }
}