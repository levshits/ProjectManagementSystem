using System;
using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class GetEntityDtoByIdRequest: RequestBase
    {
        public Guid EntityId { get; set; }
         
    }
}