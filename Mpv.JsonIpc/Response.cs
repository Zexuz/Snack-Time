using Newtonsoft.Json;

namespace Mpv.JsonIpc
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("request_id")]
        public int RequestId { get; set; }

        [JsonIgnore]
        public bool Success => Error == "success";
    }
}