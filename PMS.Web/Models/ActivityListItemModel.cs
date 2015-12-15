using System;

namespace PMS.Web.Models
{
    public class ActivityListItemModel: ListItemModel
    {
        public int ActivityType { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public Guid IssueId { get; set; }
        public string IssueName { get; set; }
    }
}