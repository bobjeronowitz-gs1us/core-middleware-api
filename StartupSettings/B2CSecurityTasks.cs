using GS1US.Framework.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Threading.Tasks;

namespace GS1US.Framework.API.StartupSettings
{
    public class B2CSecurityTasks : IB2CSecurityTasks
    {
        public Task OnMessageReceived(MessageReceivedContext jwt)
        {
            return Task.FromResult(0);
        }

        public Task OnTokenValidated(TokenValidatedContext jwt)
        {
            return Task.FromResult(0);
        }

        public Task OnChallenge(JwtBearerChallengeContext jwt)
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Task should only be implemented for debuggging!
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Task AuthenticationFailed(AuthenticationFailedContext arg)
        {   
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            var encodedData = Encoding.UTF8.GetBytes(s);
            arg.Response.ContentLength = encodedData.Length;
            _FailureTask(arg, encodedData);
            return Task.FromResult(0);
        }

        private async void _FailureTask(AuthenticationFailedContext arg, byte[] encodedData) 
        {
            await arg.Response.Body.WriteAsync(encodedData, 0, encodedData.Length);
        }
    }
}
