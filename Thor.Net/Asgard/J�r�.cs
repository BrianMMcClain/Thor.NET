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

    }
}
