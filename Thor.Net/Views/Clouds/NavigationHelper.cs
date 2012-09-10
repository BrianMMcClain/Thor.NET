using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views.Clouds
{
    public class NavigationHelper
    {
        public static void GetCloudsListView(UserControl cloudActionView)
        {
            cloudActionView.Visibility = Visibility.Hidden;
            var window = cloudActionView.Parent as StackPanel;
            var parentWindow = window.Parent as CloudsView;
            parentWindow.CloudsListView.Visibility = Visibility.Visible;
        }

        public static  bool IfNameExists(string name, Label label)
        {
            var nameExists = new Targets(new SettingsWrapper()).ValidateTargetNameExists(name);
            label.Content = nameExists ?
                Properties.Resources.TargetDuplicateName : Properties.Resources.TargetName;
            return nameExists;
        }

        public static  bool IfUriExists(Uri uri, Label label)
        {
            var uriExists = new Targets(new SettingsWrapper()).ValidateTargetUriExists(uri);
            label.Content = uriExists ?
                Properties.Resources.TargetDuplicateUri : Properties.Resources.TargetUri;
            return uriExists;
        }
    }
}
