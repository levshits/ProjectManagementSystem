using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class TranslateRequest: RequestBase
    {
        public string Key { get; set; }
        public int Language { get; set; }
    }
}