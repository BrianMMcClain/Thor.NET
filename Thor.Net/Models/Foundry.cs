using System.Collections.Generic;

namespace Thor.Net.Models
{
    public class Foundry
    {
        public List<FoundryTarget> Targets { get; set; }
        public List<FoundryApplication> Applications { get; set; }
        public List<FoundryDeployment> Deployments { get; set; }
        public List<FoundryService> Services { get; set; }
    } 
}