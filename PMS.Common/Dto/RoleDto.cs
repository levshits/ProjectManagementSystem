using System;
using System.Collections.Generic;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class RoleDto: DtoBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid CreatorId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual IList<ActionsDto> ActionEntities { get; protected set; }
    }
}