using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Net.Models.Jörð;

namespace Thor.Net.Views
{
    /// <summary>
    /// Interaction logic for CloudsView.xaml
    /// </summary>
    public partial class CloudsView : UserControl
    {
        public CloudsView()
        {
            InitializeComponent();


            var foundryTarget = new Targets(new SettingsWrapper());

            foundryTarget.PutTarget(new FoundryTarget()
            {
                Name = "My Test"
            });
            foundryTarget.PutTarget(new FoundryTarget()
            {
                Name = "My Test"
            });

            foreach (var target in foundryTarget.GetTargets())
            {
                CloudsViewStackPanel.Children.Add(
                    new Tile()
                        {
                            Title = target.Name
                        });
            }
        }
    }
}