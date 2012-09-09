using System;
using System.Windows;
using Thor.Asgard;

namespace Thor.Net
{
    public partial class App : Application
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnStartup(StartupEventArgs e)
        {
            SettingsWrapper.CreateEmptyFoundryFieldIfEmpty();

            Log.Debug("Application Started, logging tests starting.");

            Log.Debug("Debug logging");
            Log.Info("Info logging");
            Log.Warn("Warn logging");
            Log.Error("Error logging");
            Log.Fatal("Fatal logging");

            try
            {
                throw new System.IO.FileNotFoundException();
            }
            catch (Exception ex)
            {
                Log.Debug("Debug error logging", ex);
                Log.Info("Info error logging", ex);
                Log.Warn("Warn error logging", ex);
                Log.Error("Error error logging", ex);
                Log.Fatal("Fatal error logging", ex);
            }

            Log.Debug("Logging test completed.");

            base.OnStartup(e);
        }
    }
}
