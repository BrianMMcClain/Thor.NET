using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views.Clouds
{
    public partial class CloudsListView : UserControl
    {
        public CloudsListView()
        {
            InitializeComponent();
        }

        private void AddCloudClick(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationCloudsHelper.LoadAddView(ParentCloudsView.CloudsViewInteractiveStackPanel);
            }
            catch (Exception)
            {
                // Log things.   
                throw;
            }
        }

        public CloudsView ParentCloudsView { get { return ((this.Parent as StackPanel).Parent as CloudsView); } }

        public List<Tile> Tiles { get; set; }

        private void RefreshTargetTiles()
        {
            var tiles = new List<Tile>();
            var targets = new Targets(new SettingsWrapper()).GetTargets();

            CloudsViewStackPanel.Children.RemoveRange(1, CloudsViewStackPanel.Children.Count - 1);
            foreach (var target in targets)
            {
                var tile = new Tile() { Title = target.Name };
                tile.Click += TileOnClick;
                tile.Margin = new Thickness(15, 15, 0, 0);
                CloudsViewStackPanel.Children.Add(tile);
                tiles.Add(tile);
            }

            Tiles = tiles;
        }

        private void TileOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var tile = routedEventArgs.Source as Tile;
            var target = new Targets(new SettingsWrapper()).GetTarget(tile.Title);
            new SettingsWrapper().SetActiveFoundryTarget(target);
            NavigationCloudsHelper.LoadDetailView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void UserControlIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshTargetTiles();
        }

        
    }
}
