namespace GS1US.Framework.Common.DataSerializer
{
    public interface IDataSerializer
    {
        string ConvertToJsonString(object obj);
        T ConvertToJsonObject<T>(string jsonString);
    }
}
