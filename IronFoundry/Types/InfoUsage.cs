using Newtonsoft.Json;

namespace IronFoundry.Types
{
    public class InfoUsage : EntityBase
    {
        [JsonProperty(PropertyName = "memory")]
        public uint Memory { get; private set; }

        [JsonProperty(PropertyName = "apps")]
        public uint Apps { get; private set; }

        [JsonProperty(PropertyName = "services")]
        public uint Services { get; private set; }
    }
}