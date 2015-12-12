using System;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;

namespace PMS.Web.Security
{
    public class PmsJwtFormat: ISecureDataFormat<AuthenticationTicket>
    {
        public string SignatureAlgorithm => "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";

        public string DigestAlgorithm => "http://www.w3.org/2001/04/xmlenc#sha256";

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var signingCredentials = new SigningCredentials(
                new InMemorySymmetricSecurityKey(SecurityHelper.Key),
                SignatureAlgorithm,
                DigestAlgorithm);
            var token = new JwtSecurityToken(SecurityHelper.ISSUER, SecurityHelper.AUDIENCE, data.Identity.Claims,
                DateTime.Now, SecurityHelper.Expires, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new System.NotImplementedException();
        }
    }
}