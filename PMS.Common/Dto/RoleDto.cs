using System;
using System.Collections.Generic;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class RoleDto: DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public virtual Guid RoleTypeId { get; set; }
        public virtual RoleTypeDto RoleTypeIdObject { get; set; }
        public DateTime CreateTime { get; set; }
        public IList<ActionDto> ActionEntities { get; set; }
    }
}