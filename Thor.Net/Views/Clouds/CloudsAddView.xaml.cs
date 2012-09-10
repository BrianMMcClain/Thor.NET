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

            if (!NavigationHelper.IfNameExists(foundryTarget.Name, TargetNameLabel) && 
                !NavigationHelper.IfUriExists(foundryTarget.Path, TargetUriLabel))
            {
                targetRepository.PutTarget(foundryTarget);
                NavigationHelper.GetCloudsListView(this);
            }
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                NavigationHelper.IfUriExists(new Uri(TargetUriTextBox.Text));
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            NavigationHelper.IfNameExists(TargetNameTextBox.Text);
        }
    }
}
