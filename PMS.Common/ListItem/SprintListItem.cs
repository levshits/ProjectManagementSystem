using System;
using Levshits.Data.Item;
using PMS.Common.Dto;

namespace PMS.Common.ListItem
{
    public class SprintListItem: BaseItem
    {
        public Guid ProjectId { get; set; }
        public ProjectDto ProjectIdObject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProjectVersion { get; set; }
    }
}