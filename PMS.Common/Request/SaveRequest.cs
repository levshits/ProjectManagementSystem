using Levshits.Data.Common;
using Levshits.Data.Dto;

namespace PMS.Common.Request
{
    public class SaveRequest<T>: RequestBase where T: DtoBase
    {
        public T Dto { get; set; }
    }
}