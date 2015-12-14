using System;

namespace PMS.Web.Models
{
    public class SprintListItemModel: ListItemModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ProjectVersion { get; set; }
    }
}