using System;
using Thor.Models.Jord;

namespace Thor.Models.Jörð
{
    public class FoundryApplication : BaseFoundry
    {
        public FoundryTarget Target { get; set; }
        public DateTime DeployedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}