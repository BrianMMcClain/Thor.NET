
using System.Windows;
using Thor.Asgard;
using Thor.Models;

namespace Thor.Net.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CloudStackPanel.Children.Add(new CloudsView());
            ApplicationStackPanel.Children.Add(new ApplicationsView());
            ServicesStackPanel.Children.Add(new ServicesView());
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NotAvailableYetJoinThorProject);
        }
    }
}
