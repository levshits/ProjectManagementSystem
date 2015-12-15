using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class SaveCommentRequest: RequestBase
    {
        public string Text { get; set; }
        public Guid IssueId { get; set; }
    }
}