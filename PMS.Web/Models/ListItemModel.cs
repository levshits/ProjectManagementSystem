using System;

namespace PMS.Web.Models
{
    public class ListItemModel
    {
        public Guid Id { get; set; }
        public bool AllowEdit { get; set; } = false;
        public bool AllowDelete { get; set; } = false;
    }
}