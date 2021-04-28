using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("AccessControlCors")]
    public class SignInController : ControllerBase
    {
        private IGS1USAppInsightsLogger AILogger { get; }
        private const string AI_KEY = "DATA_HUB_UI";
        public SignInController(IGS1USAppInsightsLogger logger)
        {
            this.AILogger = logger;
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            var redirectUri = "https://dh.dev.gs1us.org/ui/#/signout";
            try
            {
                
                if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
                {
                    string scheme = (HttpContext.User.FindFirst("http://schemas.microsoft.com/claims/authnclassreference"))?.Value;
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync(scheme.ToLower(), new AuthenticationProperties { RedirectUri = redirectUri });
                }

                foreach (var header in Request.Headers)
                    this.AILogger.Trace(($"{AI_KEY} - LOGOUT GET: {header.Key}: {header.Value}"));

                this.AILogger.Trace($"DH UI Logout Uri: {redirectUri}");
            }
            catch { }

            RedirectToAction(redirectUri);
            return Ok("Logout");

        }

       
    }
}
