﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Net.Views.Controls;

namespace Thor.Net.Views.Clouds
{
    public partial class CloudsListView : UserControl
    {
        public CloudsListView()
        {
            InitializeComponent();
            RefreshTargetTiles();
        }
        
        public CloudsView ParentCloudsView { get { return ((Parent as StackPanel).Parent as CloudsView); } }

        public List<Tile> Tiles { get; set; }

        private void AddCloudClick(object sender, RoutedEventArgs e)
        {
            NavigationCloudsHelper.LoadAddView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }

        private void RefreshTargetTiles()
        {
            var tiles = new List<Tile>();
            var targets = new TargetsBridge(new SettingsWrapper()).GetTargets();

            CloudsViewStackPanel.Children.RemoveRange(1, CloudsViewStackPanel.Children.Count - 1);
            foreach (var target in targets)
            {
                var cloudTile = new CloudTile {CloudTarget = {Title = target.Name}};
                
                if(target.Applications != null)
                {
                    var apps = target.Applications as List<object>;
                    if (apps != null && apps.Count > 0)
                    {
                        cloudTile.Applications.Text = apps.Count.ToString(CultureInfo.InvariantCulture);
                        cloudTile.Apps.Text = "Apps";
                    }
                }

                cloudTile.CloudTarget.Click += TileOnClick;
                CloudsViewStackPanel.Children.Add(cloudTile);
                tiles.Add(cloudTile.CloudTarget);
            }

            Tiles = tiles;
        }

        private void TileOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var tile = routedEventArgs.Source as Tile;
            var target = new TargetsBridge(new SettingsWrapper()).GetTarget(tile.Title);
            new SettingsWrapper().SetActiveFoundryTarget(target);
            NavigationCloudsHelper.LoadDetailView(ParentCloudsView.CloudsViewInteractiveStackPanel);
        }
    }
}