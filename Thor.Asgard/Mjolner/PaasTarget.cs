using System;
using System.Collections.Generic;
using IronFoundry.Models;
using IronFoundry.VcapClient;


namespace Thor.Asgard.Mjolner
{
    public interface IPaasTarget
    {
        IEnumerable<Application> CloudApplications { get; }
        Info CloudInfo { get; }
    }

    public class PaasTarget : IPaasTarget
    {
        private readonly VcapClient _client;

        public PaasTarget(string username, string password, Uri apiUri)
        {
            _client = new VcapClient(apiUri.ToString());
            _client.Login(username, password);
        }

        public IEnumerable<Application> CloudApplications
        {
            get { return _client.GetApplications(); }
        }

        public Info CloudInfo
        {
            get { return _client.GetInfo(); }
        }
    }
}