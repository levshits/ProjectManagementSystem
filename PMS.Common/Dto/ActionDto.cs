using System;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class ActionDto: DtoBase
    {
        public virtual Guid ObjectTypeId { get; set; }
        public virtual string Name { get; set; }
    }
}