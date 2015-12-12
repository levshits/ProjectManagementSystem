using Microsoft.Owin.Security.Jwt;

namespace PMS.Web.Security
{
    public class PmsJwtOptions: JwtBearerAuthenticationOptions
    {
        public PmsJwtOptions()
        {
            AllowedAudiences = new[] { SecurityHelper.AUDIENCE };
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(SecurityHelper.ISSUER, SecurityHelper.Key)
            };
        }
    }
}