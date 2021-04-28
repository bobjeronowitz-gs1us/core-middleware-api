namespace GS1US.Framework.Common.Authentication
{
    public interface IClaimsPrincipalService
    {
        string GetSamAccountName();

        string GetIdentityName();
    }
}
