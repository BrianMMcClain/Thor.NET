using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views
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
            StackPanel parentWhta = this.Parent as StackPanel;
            CloudsView cv = parentWhta.Parent as CloudsView;
            
            cv.CloudsAddView.Visibility = Visibility.Visible;
            cv.CloudsListView.Visibility = Visibility.Hidden;

        }
    }
}
