using System;
using Levshits.Data.Item;
using PMS.Common.Dto;

namespace PMS.Common.ListItem
{
    public class IssueListItem: BaseItem
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public Guid AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}