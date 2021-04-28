using GS1US.Framework.Common.Logging;
using System;
using System.Text.Json;

namespace GS1US.Framework.Common.DataSerializer
{
    public class DataSerializer : IDataSerializer
    {
        private IGS1USAppInsightsLogger Logger { get; }
        public DataSerializer(IGS1USAppInsightsLogger logger) 
        {
            this.Logger = logger;
        }

        public string ConvertToJsonString(object value)
        {
            return JsonSerializer.Serialize(value);
        }

        public T ConvertToJsonObject<T>(string jsonString)
        {
            try
            {
                jsonString = jsonString.Replace("\\\"", "\"");
                jsonString = jsonString[1..^1];
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception e)
            {
                var msg = $"Failed to convert Json string: {e.Message}";
                Logger.Error(e, msg);
                throw new Exception($"{msg}: {jsonString}");
            }
        }
    }
}

