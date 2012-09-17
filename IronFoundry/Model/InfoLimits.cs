using Newtonsoft.Json;

namespace IronFoundry.Model
{
    public class InfoLimits : EntityBase
    {
        [JsonProperty(PropertyName = "memory")]
        public uint Memory { get; private set; }

        [JsonProperty(PropertyName = "app_uris")]
        public uint AppURIs { get; private set; }

        [JsonProperty(PropertyName = "services")]
        public uint Services { get; private set; }

        [JsonProperty(PropertyName = "apps")]
        public uint Apps { get; private set; }
    }
}