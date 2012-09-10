using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views.Clouds
{
    /// <summary>
    /// Interaction logic for CloudsListView.xaml
    /// </summary>
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
                var cv = (this.Parent as StackPanel).Parent as CloudsView;
                cv.CloudsAddView.Visibility = Visibility.Visible;
                cv.CloudsListView.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                // Log things.   
                throw;
            }
        }

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
            MessageBox.Show(routedEventArgs.OriginalSource + "\n" + tile.Title);
        }

        private void UserControlIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshTargetTiles();
        }
    }
}
