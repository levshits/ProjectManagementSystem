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
        public IList<RoleDto> Roles { get; set; }
        public IList<ActionDto> Actions { get; set; }
    }
}