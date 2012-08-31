using System;
using System.Collections.Generic;
using System.Configuration;
using Thor.Net.Models;

namespace Thor.Net.Asgard
{
    public class Jörð
    {
        public bool LocalAccessOnly
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["local"]) && 
                    Convert.ToBoolean(ConfigurationManager.AppSettings["local"]);
            }
        }

        public Jörð()
        {
        
        }

        public List<FoundryTarget> GetFoundryTargets()
        {
            throw new NotImplementedException();
        }

        public FoundryTarget GetFoundryTarget(Uri apiTarget)
        {
            throw new NotImplementedException();
        }

        public FoundryTarget PutFoundryTarget(FoundryTarget target)
        {
            throw new NotImplementedException();
        }

        public List< FoundryApplication > GetFoundryApplications(Uri apiTarget)
        {
            throw new NotImplementedException();
        }

        public FoundryApplication GetFoundryApplication()
        {
            throw new NotImplementedException();
        }

        public List<FoundryDeployment> GetFoundryDeployment(FoundryApplication foundryApplication)
        {
            throw new NotImplementedException();
        }
    }
}
