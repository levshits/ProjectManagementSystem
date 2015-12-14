using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class ActionsLookupListRequest: RequestBase
    {
        public Guid RoleTypeId { get; set; }
    }
}