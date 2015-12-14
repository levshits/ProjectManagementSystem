using System;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class ProjectDto: DtoBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
        public PrincipalDto CreatorIdObject { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}