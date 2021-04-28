using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Security
{
    public interface IB2CSecurityTasks
    {

        Task OnMessageReceived(MessageReceivedContext jwt);

        Task OnTokenValidated(TokenValidatedContext jwt);

        Task OnChallenge(JwtBearerChallengeContext jwt);

        Task AuthenticationFailed(AuthenticationFailedContext arg);
    }
}
