using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views.Services
{
    public partial class ServicesListView : UserControl
    {
        public ServicesListView()
        {
            InitializeComponent();
        }

        private void AddServicesClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NotAvailableYetJoinThorProject);
        }
    }
}
