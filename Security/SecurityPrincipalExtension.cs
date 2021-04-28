using System.Security.Claims;

namespace GS1US.Framework.API.Security
{
    public static class SecurityPrincipalExtension
    {
        public static GS1Principal GS1Principal(this ClaimsPrincipal claimsPrincipal)
        {
            return new GS1Principal(claimsPrincipal);
        }

    }
}
