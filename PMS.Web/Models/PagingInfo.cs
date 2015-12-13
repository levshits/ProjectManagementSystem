using System;

namespace PMS.Web.Models
{
    public class PagingInfo
    {
        private static int _itemsPerPageDefault = 10;
        public int TotalItems { get; set; }

        public static int ItemsPerPageDefault
        {
            get { return _itemsPerPageDefault; }
            set
            {
                if (value > 0)
                {
                    _itemsPerPageDefault = value;
                }
            }
        }

        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((decimal) (TotalItems)/ItemsPerPageDefault);

        public static int GetPageOffset(int pageNumber)
        {
            return (pageNumber - 1)*ItemsPerPageDefault;
        }
    }
}