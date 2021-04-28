using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GS1US.Framework.API.Controllers.BaseControllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseJwtScopedController : BaseNoAuthController
    {
        public BaseJwtScopedController(IGS1USAppInsightsLogger logger): base(logger) 
        { }
    }
}
