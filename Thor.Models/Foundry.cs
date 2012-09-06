using System.Collections.Generic;
using Thor.Models.Jörð;

namespace Thor.Models
{
    public class Foundry
    {
        public Foundry()
        {
            if(Targets == null)
                Targets = new List<FoundryTarget>();
            if(Applications == null)
                Applications = new List<FoundryApplication>();
            if (Deployments == null)
                Deployments = new List<FoundryDeployment>();
            if(Services == null)
                Services = new List<FoundryService>();
        }

        public List<FoundryTarget> Targets { get; set; }
        public List<FoundryApplication> Applications { get; set; }
        public List<FoundryDeployment> Deployments { get; set; }
        public List<FoundryService> Services { get; set; }
    } 
}