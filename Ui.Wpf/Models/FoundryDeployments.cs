using System;
using System.Collections.Generic;

namespace Ui.Wpf.Models
{
    public class FoundryDeployments : BaseFoundry
    {
        public List<FoundryApplication> FoundryApplications { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeployedOn { get; set; }
    }
}