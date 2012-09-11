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

        private void AddCloud_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Almost available, help us out on the Thor Project on Github at https://github.com/IronFoundry/Thor.NET.");
        }
    }
}
