using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Thor.Models.Jörð;

namespace Thor.Net.Views
{
    /// <summary>
    /// Interaction logic for CloudsAddView.xaml
    /// </summary>
    public partial class CloudsAddView : UserControl
    {
        public CloudsAddView()
        {
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var window = this.Parent as CloudsView;
            window.CloudsListView.Visibility = Visibility.Visible;
        }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {
            var foundryTarget = new FoundryTarget()
            {
                Created = DateTime.Now,
                Name = TargetNameTextBox.Text,
                Username = UsernameTextBox.Text,
                Path = new Uri(TargetUriTextBox.Text),
                Stamp = DateTime.Now
            };
        }
    }
}
