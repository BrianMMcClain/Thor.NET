using System;

namespace Thor.Net.Models.Jörð
{
    public class FoundryApplication : BaseFoundry
    {
        public FoundryTarget Target { get; set; }
        public DateTime DeployedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}