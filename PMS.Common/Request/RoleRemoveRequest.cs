using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class RoleRemoveRequest: RequestBase
    {
        public Guid RoleId { get; set; }
    }
}