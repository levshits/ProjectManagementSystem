using System.Collections.Generic;

namespace PMS.Web.Models
{
    public class ListModel<T> where T: ListItemModel
    {
        public List<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public ListModel()
        {
            Items=new List<T>();
        }
    }
}