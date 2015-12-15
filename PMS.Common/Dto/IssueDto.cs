using System;
using System.Collections.Generic;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    [Serializable]
    public class IssueDto: DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public Guid ProjectId { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public Guid AssigneeId { get; set; }
        public Guid SprintId { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual IList<CommentDto> CommentEntities { get; protected set; }
    }
}