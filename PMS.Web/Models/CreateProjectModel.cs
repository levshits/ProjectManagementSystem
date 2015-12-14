using System.ComponentModel.DataAnnotations;
using Levshits.Web.Common.Models;

namespace PMS.Web.Models
{
    public class CreateProjectModel: ModelBase
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        public string ShortName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}