using System;
using IronFoundry.Model;
using Thor.Asgard.Mjolner;
using Thor.Models.Jord;

namespace Thor.Net.Mappers
{
    public class Map
    {
        public static FoundryTarget PaasTargetToFoundryTarget(PaasTarget paas, FoundryTarget target)
        {
            target.Applications = paas.CloudApplications;
            target.Build = paas.CloudInfo.Build;
            target.Description = paas.CloudInfo.Description;
            target.Frameworks = paas.CloudInfo.Frameworks;
            target.Limits = paas.CloudInfo.Limits;
            target.Usage = paas.CloudInfo.Usage;
            target.Version = paas.CloudInfo.Version;
            target.Support = paas.CloudInfo.Support;
            return target;
        }

        public static FoundryApplication FoundryApplicationMap(FoundryTarget target,
                                                              Application cloudApplication)
        {
            var foundryApplication =
                new FoundryApplication { Name = cloudApplication.Name, Target = target };

            var rootUri = cloudApplication.Uris[0];
            if (!string.IsNullOrWhiteSpace(rootUri))
            {
                if (!rootUri.StartsWith("http://"))
                {
                    rootUri = "http://" + rootUri;
                    foundryApplication.Path = new Uri(rootUri);
                }
            }

            foundryApplication.Resources = cloudApplication.Resources;

            return foundryApplication;
        }
    }
}
