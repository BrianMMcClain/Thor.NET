using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;

namespace Thor.Net.Views.Clouds
{
    /// <summary>
    /// Interaction logic for CloudsDeleteConfirmationView.xaml
    /// </summary>
    public partial class CloudsDeleteConfirmationView : UserControl
    {
        public CloudsDeleteConfirmationView()
        {
            InitializeComponent();

            LoadActiveFoundryTarget();
        }

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
