using System.Windows;
using Thor.Net.Properties;

namespace Thor.Net
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SettingsWrapper.CreateEmptyFoundryField();
            base.OnStartup(e);
        }
    }
}
