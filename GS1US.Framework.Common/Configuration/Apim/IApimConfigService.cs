namespace GS1US.Framework.Common.Configuration.Apim
{
    public interface IApimConfigService
    {
        void AddApimSettings(ApimConnection apimConnection);
        string GetApimRoot(string ConnectionName);
        string GetApimSubscriptionKey(string ConnectionName);
    }
}
