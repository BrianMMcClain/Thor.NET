using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jörð;

namespace Thor.Net.Views.Clouds
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
            NavigationHelper.GetCloudsListView(this);
        }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {
            var foundryTarget = new FoundryTarget()
            {
                Created = DateTime.Now,
                Name = TargetNameTextBox.Text,
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Password,
                Path = new Uri(TargetUriTextBox.Text),
                Stamp = DateTime.Now
            };

            var targetRepository = new Targets(new SettingsWrapper());

            if (!IfNameExists(foundryTarget.Name) && !IfUriExists(foundryTarget.Path))
            {
                targetRepository.PutTarget(foundryTarget);
                NavigationHelper.GetCloudsListView(this);
            }
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
