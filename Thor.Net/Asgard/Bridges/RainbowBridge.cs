using System;
using System.Configuration;

namespace Thor.Net.Asgard.Bridges
{
    public class RainbowBridge
    {
        public static bool LocalOnly
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["local"]) &&
               Convert.ToBoolean(ConfigurationManager.AppSettings["local"]);
            }
        }
    }
}
