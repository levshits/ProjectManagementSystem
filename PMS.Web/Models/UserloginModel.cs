using System.ComponentModel.DataAnnotations;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class UserLoginModel
    {
        [Required]
        [Localised]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Localised]
        public string Password { get; set; }
    }
}