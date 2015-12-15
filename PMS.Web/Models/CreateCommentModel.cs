using System;

namespace PMS.Web.Models
{
    public class CreateCommentModel
    {
        public string Text { get; set; }
        public Guid IssueId { get; set; }
    }
}