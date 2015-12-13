using Levshits.Data.Common;
using Levshits.Data.Item;

namespace PMS.Common.Request
{
    public class ListRequest<T>: RequestBase where T: BaseItem
    {
        public int Page { get; set; }
        public string SearchString { get; set; }
         
    }
}