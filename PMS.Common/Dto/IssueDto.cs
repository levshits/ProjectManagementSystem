using System;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class IssueDto: DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public Guid ProjectId { get; set; }
        public virtual int Status { get; set; }
        public virtual int Priority { get; set; }
        public virtual Guid AssigneeId { get; set; }
        public virtual TimeSpan EstimatedTime { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}