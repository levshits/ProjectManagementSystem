using System;
using Levshits.Data.Common;
using Levshits.Data.Dto;

namespace PMS.Common.Request
{
    public class GetEntityDtoByIdRequest<T>: RequestBase where T: DtoBase
    {
        public Guid EntityId { get; set; }
         
    }
}