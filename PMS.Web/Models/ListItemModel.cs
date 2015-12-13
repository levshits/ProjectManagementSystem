using System;

namespace PMS.Web.Models
{
    public class ListItemModel
    {
        public Guid Id { get; set; }
        public bool AllowEdit { get { return false; } } 
        public bool AllowDelete { get { return false; } } 
        public bool AllowView { get { return false; } } 
    }
}