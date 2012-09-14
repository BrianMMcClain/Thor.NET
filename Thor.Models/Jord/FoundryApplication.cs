using System;
using IronFoundry.Model;

namespace Thor.Models.Jord
{
    public class FoundryApplication : BaseFoundry
    {
        public FoundryTarget Target { get; set; }
        public Uri Path { get; set; }
        public int InstanceCount { get; set; }
        public DateTime DeployedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public AppResources Resources { get; set; }

        public static string GetInstanceCount(Application application)
        {
            var instanceCount = "0";
            if (application.RunningInstances != null)
            {
                instanceCount = application.RunningInstances.ToString();
            }
            return instanceCount;
        }
    }
}