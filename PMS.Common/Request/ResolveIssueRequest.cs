using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class ResolveIssueRequest:RequestBase
    {
        public Guid EntityId { get; set; }
    }
}