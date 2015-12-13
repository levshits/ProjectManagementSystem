using System.ComponentModel.DataAnnotations;
using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [Localised]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [Localised]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        [Localised]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; } 
    }
}