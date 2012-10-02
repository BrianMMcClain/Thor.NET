using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views.Controls
{
    public partial class CloudsAppDetails : UserControl
    {
        public CloudsAppDetails()
        {
            InitializeComponent();
        }

        private void ApplicationTileClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NotAvailableYetJoinThorProject);
        }
    }
}
