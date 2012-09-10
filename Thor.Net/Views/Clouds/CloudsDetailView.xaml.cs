using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

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


        private bool IfNameExists(string name)
        {
            var nameExists = new Targets(new SettingsWrapper()).ValidateTargetNameExists(name);
            TargetNameLabel.Content = nameExists ?
                Properties.Resources.TargetDuplicateName : Properties.Resources.TargetName;
            return nameExists;
        }

        private bool IfUriExists(Uri uri)
        {
            var uriExists = new Targets(new SettingsWrapper()).ValidateTargetUriExists(uri);
            TargetUriLabel.Content = uriExists ?
                Properties.Resources.TargetDuplicateUri : Properties.Resources.TargetUri;
            return uriExists;
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                IfUriExists(new Uri(TargetUriTextBox.Text));
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            IfNameExists(TargetNameTextBox.Text);
        }
    }
}
