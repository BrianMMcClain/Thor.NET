using System;
using System.Configuration;
using Thor.Net.Asgard.Bridges;

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

       
    }
}
