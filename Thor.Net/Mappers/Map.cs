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
    }
}
