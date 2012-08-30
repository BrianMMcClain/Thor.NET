using System;
using System.Windows;
using MahApps.Metro.Controls;
using ServiceStack.Text;
using Thor.Net.Models;
using Thor.Net.Properties;

namespace Thor.Net.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //testing a tile.
            var asdf = new Tile {Content = "est" + "\nblasdgh", Title = "Test1", Count = "53"};
            CloudStackPanel.Children.Add(asdf);

            if (string.IsNullOrWhiteSpace(Settings.Default.FoundryTargets))
                Settings.Default.FoundryTargets = "blagh";
            Settings.Default.Save();

            var target = new FoundryTarget
                             {
                                 Name = "name",
                                 Created = DateTime.Now,
                                 Stamp = DateTime.Now,
                                 Path = new Uri("http://api.someplace.com")
                             };

            var serializeToString = TypeSerializer.SerializeToString(target);

            var blagh = serializeToString.SerializeAndFormat();

            var targetDeserialized = TypeSerializer.DeserializeFromString<FoundryTarget>(blagh);

            MessageBox.Show("Settings was saved " + Settings.Default.FoundryTargets + "\n" +
                "\n\n...and serilized:\n" + blagh + "\n\n\nTarget Name: " + targetDeserialized.Name + "\nType:" + targetDeserialized.GetType());
        }
    }
}
