using System.Collections.Generic;
using System.Windows.Controls;
using IronFoundry.Types;
using MahApps.Metro.Controls;
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

        public List<Tile> Tiles { get; set; }

        private void RefreshTargetTiles()
        {
            var tiles = new List<Tile>();
            var applications = new ApplicationsBridge(new SettingsWrapper()).GetApplications();
            CloudsViewStackPanel.Children.RemoveRange(1, CloudsViewStackPanel.Children.Count - 1);
        }

        private void RefreshButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var targets = (new TargetsBridge(new SettingsWrapper())).GetTargets();
            var applications = (new ApplicationsBridge(new SettingsWrapper())).GetApplications();

            foreach (var target in targets)
            {
                var paas = new PaasTarget(target.Username, target.Password, target.Path);

                foreach (Application cloudApplication in paas.CloudApplications)
                {

                }
            }
        }


    }
}
