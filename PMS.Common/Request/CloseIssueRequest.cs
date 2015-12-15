using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class CloseIssueRequest: RequestBase
    {
        public Guid EntityId { get; set; }
    }
}