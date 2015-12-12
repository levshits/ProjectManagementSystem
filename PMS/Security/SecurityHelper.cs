using System;
using System.Linq;
using System.Security.Cryptography;

namespace PMS.Web.Security
{
    public class SecurityHelper
    {
        public const string ISSUER = "ProjectManagementSystem";
        public const string AUDIENCE = "all";

        public static byte[] Key = Convert.FromBase64String("UHJvamVjdE1hbmFnZW1lbnRTeXN0ZW0=");
        public static DateTime Expires => DateTime.Now.AddHours(24);
    }
}