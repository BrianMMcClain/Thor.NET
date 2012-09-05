using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Thor.Net.Views.Clouds
{
    /// <summary>
    /// Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView : UserControl
    {
        public InformationView()
        {
            InitializeComponent();

            ////testing a tile.
            var asdf = new Tile { Content = "est" + "\nblasdgh", Title = "Test1", Count = "53" };
            CloudStackPanel.Children.Add(asdf);
        }
    }
}
