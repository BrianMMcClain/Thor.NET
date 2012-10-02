using ServiceStack.Text;
using Thor.Asgard.Properties;
using Thor.Models;
using Thor.Models.Jord;

namespace Thor.Asgard
{
    public class SettingsWrapper : ICuzSettingsIsSealedWrapper
    {
        public SettingsWrapper()
        {
            CreateEmptyFoundryFieldIfEmpty();
        }

        public Foundry Get()
        {
            CreateEmptyFoundryFieldIfEmpty();
            return Settings.Default.Foundry.FromJson<Foundry>();
        }

        public void Save(Foundry foundry)
        {
            Settings.Default.Foundry = foundry.ToJson();
            Settings.Default.Save();
        }

        public void Delete(Foundry foundry)
        {
            CreateEmptyFoundryFieldIfEmpty();
        }

        public static void CreateEmptyFoundryFieldIfEmpty()
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.Foundry))
            {
                Settings.Default.Foundry = (new Foundry()).ToJson();
                Settings.Default.Save();
            }
        }

        public void SetActiveFoundryTarget(FoundryTarget foundryTarget)
        {
            Settings.Default.FoundryActiveTarget = foundryTarget;
            Settings.Default.Save();
        }

        public FoundryTarget GetActiveFoundryTarget()
        {
           return Settings.Default.FoundryActiveTarget;
        }
    }
}