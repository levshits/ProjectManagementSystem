using System;
using System.Collections.Generic;
using Levshits.Web.Common.Models;

namespace PMS.Web.Models
{
    public class UserDetailsModel: ModelBase
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}