using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jord;
using Thor.Models.Jörð;
using Thor.Net.Views.Clouds;

namespace Thor.Net.Views
{
    public partial class CloudsView : UserControl
    {
        public CloudsListView CloudsListView { get; set; }
        public CloudsAddView CloudsAddView { get; set; }
        public List<FoundryTarget> FoundryTargets { get; set; }

        public CloudsView()
        {
            InitializeComponent();
            LoadViews();
            LoadTargetsAndView();
        }

        private void LoadTargetsAndView()
        {
            CloudsListView.Visibility = Visibility.Visible;
        }

        private void LoadViews()
        {
            CloudsListView = new CloudsListView();
            CloudsAddView = new CloudsAddView();

            CloudsViewInteractiveStackPanel.Children.Add(CloudsListView);
            CloudsViewInteractiveStackPanel.Children.Add(CloudsAddView);

            CloudsListView.Visibility = Visibility.Hidden;
            CloudsAddView.Visibility = Visibility.Hidden;
        }
    }
}