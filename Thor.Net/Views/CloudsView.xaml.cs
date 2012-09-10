using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Thor.Models.Jord;
using Thor.Net.Views.Clouds;

namespace Thor.Net.Views
{
    public partial class CloudsView : UserControl
    {
        public CloudsListView CloudsListView { get; set; }
        public CloudsDetailView CloudsDetailView { get; set; }
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
            CloudsDetailView = new CloudsDetailView();
            CloudsAddView = new CloudsAddView();

            CloudsViewInteractiveStackPanel.Children.Add(CloudsListView);
            CloudsViewInteractiveStackPanel.Children.Add(CloudsAddView);
            CloudsViewInteractiveStackPanel.Children.Add(CloudsDetailView);

            CloudsListView.Visibility = Visibility.Hidden;
            CloudsAddView.Visibility = Visibility.Hidden;
            CloudsDetailView.Visibility = Visibility.Hidden;
        }
    }
}