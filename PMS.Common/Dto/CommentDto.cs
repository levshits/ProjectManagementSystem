using System;

namespace PMS.Common.Dto
{
    public class CommentDto
    {
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CreatorId { get; set; }
        public PrincipalDto CreatorIdObject { get; set; }
        public Guid IssueId { get; set; }
    }
}