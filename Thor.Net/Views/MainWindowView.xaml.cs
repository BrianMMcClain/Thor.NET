
using System.Windows;

namespace Thor.Net.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CloudStackPanel.Children.Add(new CloudsView());
            ApplicationStackPanel.Children.Add(new CloudsView());
            ServicesStackPanel.Children.Add(new ServicesView());
        }
    }
}
