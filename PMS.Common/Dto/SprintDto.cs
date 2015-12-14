using System;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class SprintDto: DtoBase
    {
        public Guid ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProjectVersion { get; set; }
    }
}