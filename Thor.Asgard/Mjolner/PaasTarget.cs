using System;
using System.Collections.Generic;
using IronFoundry.Types;
using IronFoundry.Vcap;

namespace Thor.Asgard.Mjolner
{
    public interface IPaasTarget
    {
        IEnumerable<Application> CloudApplications { get; set; }
        Info CloudInfo { get; set; }
    }

    public class PaasTarget : IPaasTarget
    {
        public PaasTarget(string username, string password, Uri apiUri)
        {
            var client = new VcapClient(apiUri.ToString());
            client.Login(username, password);

            CloudInfo = client.GetInfo();
            CloudApplications = client.GetApplications();
        }

        public IEnumerable<Application> CloudApplications { get; set; }
        public Info CloudInfo { get; set; }
    }
}