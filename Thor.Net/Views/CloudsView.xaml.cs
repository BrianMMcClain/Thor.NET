using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;

namespace Thor.Net.Views
{
    public partial class CloudsView : UserControl
    {
        public CloudsView()
        {
            InitializeComponent();

            GetTargetTiles();
        }

        public List<Tile> Tiles { get; set; }

        private void GetTargetTiles()
        {
            var tiles = new List<Tile>();
            var targets = new Targets(new SettingsWrapper()).GetTargets();
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

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

        }

    }
}