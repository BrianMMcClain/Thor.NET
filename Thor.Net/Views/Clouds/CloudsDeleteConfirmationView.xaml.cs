using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jord;

namespace Thor.Net.Views.Clouds
{
    public partial class CloudsDeleteConfirmationView : UserControl
    {
        public CloudsDeleteConfirmationView()
        {
            InitializeComponent();
            LoadActiveFoundryTarget();
        }

        public CloudsView ParentCloudsView { get { return ((Parent as StackPanel).Parent as CloudsView); } }

        public void LoadActiveFoundryTarget()
        {
            var wrapper = new SettingsWrapper();
            var target = wrapper.GetActiveFoundryTarget();
            PasswordTextBox.Password = target.Password;
            TargetNameTextBox.Text = target.Name;
            TargetUriTextBox.Text = target.Path.ToString();
            UsernameTextBox.Text = target.Username;
        }

        private void DeleteCloudButtonClick(object sender, RoutedEventArgs e)
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

            new TargetsBridge(new SettingsWrapper()).DeleteTarget(foundryTarget);
            NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                NavigationCloudsHelper.IfUriExists(TargetUriTextBox.Text, TargetUriLabel);
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.IfNameExists(TargetNameTextBox.Text, TargetNameLabel);
        }
    }
}
