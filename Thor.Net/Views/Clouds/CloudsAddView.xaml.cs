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

        public CloudsView ParentCloudsView { get { return ((this.Parent as StackPanel).Parent as CloudsView); } }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
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

            if (!NavigationCloudsHelper.IfNameExists(foundryTarget.Name, TargetNameLabel) &&
                !NavigationCloudsHelper.IfUriExists(foundryTarget.Path, TargetUriLabel))
            {
                targetRepository.PutTarget(foundryTarget);
                ClearCloudsAddViewForm();

                NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
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
                NavigationCloudsHelper.IfUriExists(new Uri(TargetUriTextBox.Text), TargetUriLabel);
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.IfNameExists(TargetNameTextBox.Text, TargetNameLabel);
        }
    }
}
