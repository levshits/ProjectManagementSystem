using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class GetEntityByIdRequest: RequestBase
    {
        public Guid EntityId { get; set; }
    }
}