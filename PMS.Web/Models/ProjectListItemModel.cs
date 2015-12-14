using PMS.Web.Attributes;

namespace PMS.Web.Models
{
    public class ProjectListItemModel: ListItemModel
    {
        [Localised()]
        public string Name { get; set; }
        [Localised()]
        public string ShortName { get; set; }
    }
}