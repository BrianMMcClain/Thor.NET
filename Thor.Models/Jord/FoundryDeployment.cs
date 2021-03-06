using System;
using System.Collections.Generic;

namespace Thor.Models.Jord
{
    public class FoundryDeployment : BaseFoundry
    {
        public List<FoundryApplication> FoundryApplications { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeployedOn { get; set; }
    }
}