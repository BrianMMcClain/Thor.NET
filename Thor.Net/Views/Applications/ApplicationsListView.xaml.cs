using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Asgard.Mjolner;
using Thor.Models.Jord;
using Thor.Net.Views.Controls;

namespace Thor.Net.Views.Applications
{
    public partial class ApplicationsListView : UserControl
    {
        public ApplicationsListView()
        {
            InitializeComponent();

            RefreshTargetTiles();
        }

        public CloudsView ParentCloudsView
        {
            get { return ((this.Parent as StackPanel).Parent as CloudsView); }
        }

        private void RefreshTargetTiles()
        {
            var applications = new ApplicationsBridge(new SettingsWrapper()).GetApplications();
            FillView(applications);
        }

        private void FillView(IEnumerable<FoundryApplication> applications)
        {
            CloudsViewStackPanel.Children.RemoveRange(1, CloudsViewStackPanel.Children.Count - 1);
            foreach (var application in applications)
            {
                var cloudTile =
                    new ApplicationTile
                        {
                            CloudApplication = { Title = application.Name + " @ " + application.Target.Name },
                            AppsInfo = { Text = GetCollectedInfo(application) }
                        };

                cloudTile.CloudApplication.Click += CloudApplicationOnClick;
                CloudsViewStackPanel.Children.Add(cloudTile);
            }
        }

        private string GetCollectedInfo(FoundryApplication application)
        {
            const string lineBreak = "\n";
            var collectedInfo = Properties.Resources.ApplicationMemory + lineBreak + application.Resources.Memory +
                                lineBreak;

            return collectedInfo;
        }

        private void CloudApplicationOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            // Show details screen.
           // throw new NotImplementedException();
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            var settingsWrapper = new SettingsWrapper();
            var targets = (new TargetsBridge(settingsWrapper)).GetTargets();
            var applicationsBridge = new ApplicationsBridge(settingsWrapper);
            var applications = (applicationsBridge).GetApplications();

            foreach (var target in targets)
            {
                var paas = new PaasTarget(target.Username, target.Password, target.Path);

                foreach (var cloudApplication in paas.CloudApplications)
                {
                    var foundryApplication = Mappers.Map. FoundryApplicationMap(target, cloudApplication);
                    applications.Add(foundryApplication);
                    applicationsBridge.PutApplication(foundryApplication);
                }
            }

            FillView(applications);
        }
    }
}
