using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jord;

namespace Thor.Net.Views.Clouds
{
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

            if (!NavigationHelper.IfNameExists(foundryTarget.Name, TargetNameLabel) &&
                !NavigationHelper.IfUriExists(foundryTarget.Path, TargetUriLabel))
            {
                targetRepository.PutTarget(foundryTarget);
                ClearCloudsAddViewForm();
                NavigationHelper.GetCloudsListView(this);
            }
        }

        private void ClearCloudsAddViewForm()
        {
            TargetNameTextBox.Text = string.Empty;
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Password = string.Empty;
            TargetUriTextBox.Text = string.Empty;
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
