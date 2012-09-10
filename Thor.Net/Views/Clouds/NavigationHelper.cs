using System.Windows;
using System.Windows.Controls;

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
    }
}
