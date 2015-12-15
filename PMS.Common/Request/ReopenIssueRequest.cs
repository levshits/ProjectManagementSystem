using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class ReopenIssueRequest: RequestBase
    {
        public Guid EntityId { get; set; }
    }
}