using GS1US.Framework.Common.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Authentication
{
    public class ClaimsPrincipalService : IClaimsPrincipalService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsPrincipalService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetSamAccountName()
        {
            var userName = GetClaimByType("Name");
            return !string.IsNullOrWhiteSpace(userName) || userName == "unknown" ? userName : GetUserDisplayName();
        }

        public string GetIdentityName()
        {
            return GetClaimByType("AccessControlUserId");
        }

        private string GetClaimByType(string claimType) 
        {
            return _httpContextAccessor?.HttpContext?.User?.Claims.Where(c => c.Type == claimType).Select(c => c.Value).SingleOrDefault();
        }


        /// <summary>
        /// Hack if username is not set
        /// </summary>
        /// <returns></returns>
        private string GetUserDisplayName() 
        {
            var given = GetClaimByType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            var surname = GetClaimByType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");

            given = string.IsNullOrEmpty(given) ? string.Empty : given;
            surname = string.IsNullOrEmpty(surname) ? string.Empty : surname;

            return $"{given} {surname}".Trim();
        }

    }
}
