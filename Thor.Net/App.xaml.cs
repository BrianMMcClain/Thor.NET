using System;
using System.Windows;
using Thor.Net.Properties;

namespace Thor.Net
{
    public partial class App : Application
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnStartup(StartupEventArgs e)
        {
            SettingsWrapper.CreateEmptyFoundryField();

            log.Debug("Application Started, logging tests starting.");

            log.Debug("Debug logging");
            log.Info("Info logging");
            log.Warn("Warn logging");
            log.Error("Error logging");
            log.Fatal("Fatal logging");

            try
            {
                throw new System.IO.FileNotFoundException();
            }
            catch (Exception ex)
            {
                log.Debug("Debug error logging", ex);
                log.Info("Info error logging", ex);
                log.Warn("Warn error logging", ex);
                log.Error("Error error logging", ex);
                log.Fatal("Fatal error logging", ex);
            }

            log.Debug("Logging test completed.");

            base.OnStartup(e);
        }
    }
}
