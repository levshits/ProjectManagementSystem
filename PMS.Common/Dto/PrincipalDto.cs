using System;
using System.Collections.Generic;
using Levshits.Data.Dto;

namespace PMS.Common.Dto
{
    public class PrincipalDto: DtoBase
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateTime { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public IList<RoleDto> RoleEntities { get; set; }
        public IList<ProjectDto> ProjectEntities { get; set; }
        public IList<ActionDto> Actions { get; set; }
    }
}