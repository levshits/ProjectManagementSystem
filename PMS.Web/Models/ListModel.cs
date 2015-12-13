using System.Collections;
using System.Collections.Generic;

namespace PMS.Web.Models
{
    public abstract class ListModel: ListItemModel
    {
        public PagingInfo PagingInfo { get; set; }
    }
    public class ListModel<T>: ListModel where T: ListItemModel
    {
        public List<T> Items { get; set; }

        public ListModel()
        {
            Items=new List<T>();
        }
    }
}