using System.Collections.Generic;

namespace PMS.Common.Dto
{
    public class ListResultDto<T>
    {
        public IList<T> Items { get; set; }
        public int ItemsCount { get; set; }
        public int Page { get; set; }
    }
}