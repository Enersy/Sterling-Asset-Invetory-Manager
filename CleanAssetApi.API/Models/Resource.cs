using Newtonsoft.Json;

namespace CleanAssetApi.API.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}