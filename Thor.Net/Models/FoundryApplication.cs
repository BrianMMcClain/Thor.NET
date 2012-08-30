using System;

namespace Thor.Net.Models
{
    public class FoundryApplicationasdf : BaseFoundry
    {
        public FoundryTarget Target { get; set; }
        public DateTime DeployedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}