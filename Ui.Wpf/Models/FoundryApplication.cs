using System;

namespace Ui.Wpf.Models
{
    public class FoundryApplication : BaseFoundry
    {
        public FoundryTarget Target { get; set; }
        public DateTime DeployedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}