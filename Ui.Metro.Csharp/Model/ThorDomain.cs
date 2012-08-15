using System;
using System.Collections.Generic;

namespace Ui.Metro.Csharp.Model
{
    public class ThorDomain
    {
        public string ThorDomainName { get; set; }
        public List<FoundryCloud> Clouds { get; set; }
        public List<FoundryDeployment> Deployments { get; set; }
        public DateTime Stamp { get; set; }
    }
}