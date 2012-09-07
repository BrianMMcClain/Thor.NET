using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models.Jörð;

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
            FoundryTargets = new Targets(new SettingsWrapper()).GetTargets();
            if (FoundryTargets.Count < 1)
                CloudsAddView.Visibility = Visibility.Visible;
            else
                CloudsListView.Visibility = Visibility.Visible;
        }

        private void LoadViews()
        {
            CloudsListView = new CloudsListView();
            CloudsAddView = new CloudsAddView();

            CloudsInteractiveStackPanel.Children.Add(CloudsListView);
            CloudsInteractiveStackPanel.Children.Add(CloudsAddView);

            CloudsListView.Visibility = Visibility.Hidden;
            CloudsAddView.Visibility = Visibility.Hidden;
        }

        public List<Tile> Tiles { get; set; }

        private void GetTargetTiles()
        {
            //var tiles = new List<Tile>();
            //var targets = new Targets(new SettingsWrapper()).GetTargets();
            //foreach (var target in targets)
            //{
            //    var tile = new Tile() { Title = target.Name };
            //    tile.Click += TileOnClick;
            //    tile.Margin = new Thickness(15, 15, 0, 0);

            //    CloudsViewStackPanel.Children.Add(tile);
            //    tiles.Add(tile);
            //}

            //Tiles = tiles;
        }

        private void TileOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var tile = routedEventArgs.Source as Tile;
            MessageBox.Show(routedEventArgs.OriginalSource + "\n" + tile.Title);
        }

    }
}