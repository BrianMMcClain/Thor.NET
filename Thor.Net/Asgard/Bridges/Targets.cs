using System;
using AutoMapper;
using ServiceStack.Text;
using Thor.Net.Models;
using Thor.Net.Models.Jörð;
using Thor.Net.Properties;

namespace Thor.Net.Asgard.Bridges
{
    public class Targets
    {
        //return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["local"]) &&
        //           Convert.ToBoolean(ConfigurationManager.AppSettings["local"]);



        public bool DeleteTarget(FoundryTarget target)
        {
            throw new NotImplementedException();
        }

        public bool PutTarget(FoundryTarget target)
        {
            try
            {
                var foundry = Settings.Default.Foundry.FromJson<Foundry>();

                foundry.Targets.Add(target);

                Settings.Default.Foundry = foundry.ToJson();
                Settings.Default.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log message.

                return false;
            }
        }
    }
}