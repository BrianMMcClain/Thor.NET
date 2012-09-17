using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views.Controls
{
    public partial class CloudTile : UserControl
    {
        public CloudTile()
        {
            InitializeComponent();
        }

        private void CloudTargetClick(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NotAvailableYetJoinThorProject);
        }
    }
}
