using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace GS1US.Framework.API.Security
{
    public class B2CScopeAttribute : ActionFilterAttribute
    {
        public const string SCOPE_READ = "sample.read";
        public const string SCOPE_WRITE = "sample.write";
        public string ScopeName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(ScopeName))
                throw new InvalidOperationException("Scope Name can not be empty.");

            var scopes = context.HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            var result = scopes != null && scopes.Split(' ').Any(s => s.Equals(ScopeName));

            if (!result)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
