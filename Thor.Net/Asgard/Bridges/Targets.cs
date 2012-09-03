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

        private Settings _settings { get; set; }

        public Targets(Settings settings)
        {
            _settings = settings;
        }

        private void Save(Settings settings)
        {
            _settings.Save();
        }

        public bool DeleteTarget(FoundryTarget target)
        {
            throw new NotImplementedException();
        }

        public bool PutTarget(FoundryTarget target)
        {
            try
            {
                //var foundry = Settings.Default.Foundry;

                //foundry.Targets.Add(target);

                //Settings.Default.Foundry = foundry.ToJson();
                //Settings.Default.Save();

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