using System;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views.Applications
{
    public class NavigationApplicationsHelper
    {
        private static void ShowCloudsView(UserControl showThisCloudView, StackPanel parentPanel)
        {
            parentPanel.Children.Clear();
            parentPanel.Children.Add(showThisCloudView);
        }

        public static void LoadListView(StackPanel parentPanel)
        {
            ShowCloudsView(new ApplicationListView(), parentPanel);
        }

        public static void LoadDetailView(StackPanel parentPanel)
        {
            ShowCloudsView(new ApplicationsDetailView(), parentPanel);
        }

        public static void LoadAddView(StackPanel parentPanel)
        {
            ShowCloudsView(new ApplicationsAddView(), parentPanel);
        }

        public static bool IfNameExists(string name, Label label)
        {
            var nameExists = new TargetsBridge(new SettingsWrapper()).ValidateTargetNameExists(name);
            label.Content = nameExists ?
                Properties.Resources.TargetDuplicateName : Properties.Resources.TargetName;
            return nameExists;
        }

        public static bool IfUriExists(Uri uri, Label label)
        {
            var uriExists = new TargetsBridge(new SettingsWrapper()).ValidateTargetUriExists(uri);
            label.Content = uriExists ?
                Properties.Resources.TargetDuplicateUri : Properties.Resources.TargetUri;
            return uriExists;
        }
    }
}
