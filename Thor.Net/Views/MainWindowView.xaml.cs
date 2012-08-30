using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using Thor.Net.Asgard;
using Thor.Net.Models;

namespace Thor.Net.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            //testing a tile.

            Tile asdf = new Tile();
            asdf.Content = "est" + "\nblasdgh";
            asdf.Title = "Test1";
            asdf.Count = "53";
            this.CloudStackPanel.Children.Add(asdf);

            var db = new JörðEntities();
            //var targets = db.FoundryTargets.Where(x => x.);

            var targets = db.FoundryTargets.Where(x => x.Name != string.Empty).ToList();

            MessageBox.Show(targets[0].Name);
        }

       
    }
}
