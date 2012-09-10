using System;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Net.Views.Clouds;

namespace Thor.Net.Views.Services
{
    public class NavigationServicesHelper
    {
        private static void ShowCloudsView(UserControl showThisCloudView, StackPanel parentPanel)
        {
            parentPanel.Children.Clear();
            parentPanel.Children.Add(showThisCloudView);
        }

        public static void LoadListView(StackPanel parentPanel)
        {
            ShowCloudsView(new ServicesListView(), parentPanel);
        }

        public static bool IfNameExists(string name, Label label)
        {
            var nameExists = new Targets(new SettingsWrapper()).ValidateTargetNameExists(name);
            label.Content = nameExists ?
                Properties.Resources.TargetDuplicateName : Properties.Resources.TargetName;
            return nameExists;
        }

        public static bool IfUriExists(Uri uri, Label label)
        {
            var uriExists = new Targets(new SettingsWrapper()).ValidateTargetUriExists(uri);
            label.Content = uriExists ?
                Properties.Resources.TargetDuplicateUri : Properties.Resources.TargetUri;
            return uriExists;
        }
    }
}
