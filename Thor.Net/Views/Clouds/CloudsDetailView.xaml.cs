using System;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jord;

namespace Thor.Net.Views.Clouds
{
    public partial class CloudsDetailView : UserControl
    {
        private FoundryTarget _tempFoundryTarget;

        public CloudsDetailView()
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

        public CloudsView ParentCloudsView { get { return ((Parent as StackPanel).Parent as CloudsView); } }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                if (!NavigationCloudsHelper.IfUriExists(new Uri(TargetUriTextBox.Text), TargetUriLabel))
                    SaveCloudTarget();
        }

        private void TargetNameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!NavigationCloudsHelper.IfNameExists(TargetNameTextBox.Text, TargetNameLabel))
                SaveCloudTarget();
        }

        private void DeleteCloudTarget(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.LoadDeleteConfirmationView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void PasswordTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            SaveCloudTarget();
        }

        private void UsernameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            SaveCloudTarget();
        }

        private void SaveCloudTarget()
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
                targetRepository.DeleteTarget(_tempFoundryTarget);
                targetRepository.PutTarget(foundryTarget);
                NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
            }
        }

        private void SetTempFoundryTarget()
        {
            _tempFoundryTarget = new FoundryTarget()
                                     {
                                         Created = DateTime.Now,
                                         Name = TargetNameTextBox.Text,
                                         Username = UsernameTextBox.Text,
                                         Password = PasswordTextBox.Password,
                                         Path = new Uri(TargetUriTextBox.Text),
                                         Stamp = DateTime.Now
                                     };
        }

        private void TargetUriTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            SetTempFoundryTarget();
        }

        private void TargetNameTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            SetTempFoundryTarget();
        }

        private void UsernameTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            SetTempFoundryTarget();
        }

        private void PasswordTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            SetTempFoundryTarget();
        }

    }
}
