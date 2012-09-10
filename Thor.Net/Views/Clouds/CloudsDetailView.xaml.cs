using System;
using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views.Clouds
{
    /// <summary>
    /// Interaction logic for CloudsDetailView.xaml
    /// </summary>
    public partial class CloudsDetailView : UserControl
    {
        public CloudsDetailView()
        {
            InitializeComponent();
        }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GetCloudsListView(this);
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                NavigationHelper.IfUriExists(new Uri(TargetUriTextBox.Text), TargetUriLabel);
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            NavigationHelper.IfNameExists(TargetNameTextBox.Text, TargetNameLabel);
        }
    }
}
