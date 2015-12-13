using System.ComponentModel.DataAnnotations;

namespace PMS.Web.Models
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}