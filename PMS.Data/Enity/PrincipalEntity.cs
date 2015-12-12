using System;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class PrincipalEntity: BaseEntity
    {
        public string Username { get; set; }
        public DateTime CreateTime { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}