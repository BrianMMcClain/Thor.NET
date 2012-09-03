using ServiceStack.Text;
using Thor.Net.Models;

namespace Thor.Net.Properties
{
    public class SettingsWrapper : ICuzSettingsIsSealedWrapper
    {
        public SettingsWrapper()
        {
            CreateEmptyFoundryField();
        }

        public Foundry Get()
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.Foundry))
                CreateEmptyFoundryField();
            return Settings.Default.Foundry.FromJson<Foundry>();
        }

        public void Save(Foundry foundry)
        {
            Settings.Default.Foundry = foundry.ToJson();
            Settings.Default.Save();
        }

        public void Delete(Foundry foundry)
        {
            CreateEmptyFoundryField();
        }

        public static void CreateEmptyFoundryField()
        {
            Settings.Default.Foundry = (new Foundry()).ToJson();
            Settings.Default.Save();
        }
    }
}