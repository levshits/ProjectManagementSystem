using Levshits.Data.Common;

namespace PMS.Common.Request
{
    public class LoginRequest: RequestBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}