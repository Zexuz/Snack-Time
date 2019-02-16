using Newtonsoft.Json;

namespace Mpv.JsonIpc
{
    public class Request
    {
        [JsonProperty("command")]
        public object[] Command { get; set; }

        [JsonProperty("request_id")]
        public int RequestId { get; set; }
    }
}