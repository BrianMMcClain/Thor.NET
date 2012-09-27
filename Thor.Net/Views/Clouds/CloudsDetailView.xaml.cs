using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Asgard.Mjolner;
using Thor.Models.Jord;
using Thor.Net.Views.Controls;

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

            // TODO: Make this an asynchronous call
            try
            {
                // temporary pre-error handling & validation.
                var paas = new PaasTarget(target.Username, target.Password, target.Path);
                new SettingsWrapper().SetActiveFoundryTarget(Mappers.Map.PaasTargetToFoundryTarget(paas, target));

                var applications = paas.CloudApplications;
                foreach (var application in applications)
                {
                    var appDetail =
                        new CloudsAppDetails
                            {
                                ApplicationTile =
                                    {
                                        Title = application.Name,
                                        Count = FoundryApplication.GetInstanceCount(application),
                                    },
                                ApplicationInformationTextBlock =
                                    {
                                        Text =
                                            Properties.Resources.ApplicationMemory + application.Resources.Memory + "\n" +
                                            Properties.Resources.ApplicationDisk + application.Resources.Disk + "\n" +
                                            Properties.Resources.ApplicationStack + application.State + "\n" +
                                            Properties.Resources.ApplicationModel + application.Staging.Model + "\n" +
                                            Properties.Resources.ApplicationStack + application.Staging.Stack + "\n" +
                                            Properties.Resources.ApplicationUris + GetUris(application.Uris)
                                    }
                            };


                    CloudTargetApplications.Children.Add(appDetail);
                }
            }
            catch (Exception ex)
            {
                // Logging here.
                // Temporarily ignoring exceptions until I can look at and determine the unique results from Cloud Foundry.
                MessageBox.Show("This cloud was not found: " + ex.Message);
            }
        }

        private string GetUris(IEnumerable<string> uris)
        {
            return uris.Aggregate(string.Empty, (current, uri) => current + " " + uri);
        }

        public CloudsView ParentCloudsView { get { return ((Parent as StackPanel).Parent as CloudsView); } }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.LoadListView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void TargetUriTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TargetUriTextBox.Text))
                if (!NavigationCloudsHelper.IfUriExists(TargetUriTextBox.Text, TargetUriLabel))
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

            var targetRepository = new TargetsBridge(new SettingsWrapper());

            if (!NavigationCloudsHelper.IfNameExists(TargetNameTextBox.Text, TargetNameLabel) &&
                !NavigationCloudsHelper.IfUriExists(TargetUriTextBox.Text, TargetUriLabel))
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
