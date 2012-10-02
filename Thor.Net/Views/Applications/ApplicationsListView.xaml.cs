using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jord;
using Thor.Net.Views.Controls;

namespace Thor.Net.Views.Applications
{
    public partial class ApplicationListView : UserControl
    {
        public ApplicationListView()
        {
            InitializeComponent();
            RefreshTargetTiles();
        }

        public ApplicationsView ParentCloudsView
        {
            get { return ((Parent as StackPanel).Parent as ApplicationsView); }
        }

        public List<Tile> Tiles { get; set; }

        private void ApplicationOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            NavigationApplicationsHelper.LoadDetailView(ParentCloudsView.ApplicationsViewInteractiveStackPanel);
        }

        private void AddCloudClick(object sender, RoutedEventArgs e)
        {
            NavigationApplicationsHelper.LoadAddView(ParentCloudsView.ApplicationsViewInteractiveStackPanel);
        }

        private void RefreshTargetTiles()
        {
            var tiles = new List<Tile>();
            var applications = new ApplicationsBridge(new SettingsWrapper()).GetApplications();

            ApplicationsViewStackPanel.Children.RemoveRange(1, ApplicationsViewStackPanel.Children.Count - 1);

            foreach (var application in applications)
            {
                var cloudTile =
                    new ApplicationTile
                        {
                            CloudApplication = {Title = application.Name + " @ " + application.Target.Name},
                            AppsInfo = {Text = GetCollectedInfo(application)}
                        };

                cloudTile.CloudApplication.Click += ApplicationOnClick;
                ApplicationsViewStackPanel.Children.Add(cloudTile);

                Tiles = tiles;
            }
        }

        public string GetCollectedInfo(FoundryApplication application)
        {
            const string lineBreak = "\n";
            var collectedInfo = Properties.Resources.ApplicationMemory + lineBreak + application.Resources.Memory +
                                lineBreak;

            return collectedInfo;
        }
    }
}