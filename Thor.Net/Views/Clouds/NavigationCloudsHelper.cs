using System;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views.Clouds
{
    public class NavigationCloudsHelper
    {
        private static void ShowCloudsView(UserControl showThisCloudView, StackPanel parentPanel)
        {
            parentPanel.Children.Clear();
            parentPanel.Children.Add(showThisCloudView);
        }

        public static void LoadListView(StackPanel parentPanel)
        {
            ShowCloudsView(new CloudsListView(), parentPanel);
        }

        public static void LoadDetailView(StackPanel parentPanel)
        {
            ShowCloudsView(new CloudsDetailView(), parentPanel);
        }

        public static void LoadAddView(StackPanel parentPanel)
        {
            ShowCloudsView(new CloudsAddView(), parentPanel);
        }

        public static void LoadDeleteConfirmationView(StackPanel parentPanel)
        {
            ShowCloudsView(new CloudsDeleteConfirmationView(), parentPanel);
        }

        public static bool IfNameExists(string name, Label label)
        {
            var nameExists = new TargetsBridge(new SettingsWrapper()).ValidateTargetNameExists(name);
            label.Content = nameExists ?
                Properties.Resources.TargetDuplicateName : Properties.Resources.TargetName;
            return nameExists;
        }

        public static bool IfUriExists(string uri, Label label)
        {
            if(string.IsNullOrWhiteSpace(uri))
            {
                label.Content = Properties.Resources.TargetUri;
                return false;
            }

            var uriExists = new TargetsBridge(new SettingsWrapper()).ValidateTargetUriExists(new Uri(uri));
            label.Content = uriExists ?
                Properties.Resources.TargetDuplicateUri : Properties.Resources.TargetUri;
            return uriExists;
        }
    }
}
