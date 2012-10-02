using System.Windows;
using System.Windows.Controls;

namespace Thor.Net.Views.Applications
{
    /// <summary>
    /// Interaction logic for ApplicationsAddView.xaml
    /// </summary>
    public partial class ApplicationsAddView : UserControl
    {
        public ApplicationsAddView()
        {
            InitializeComponent();
        }

        public ApplicationsView ParentCloudsView
        {
            get { return ((Parent as StackPanel).Parent as ApplicationsView); }
        }

        private void AddCloudButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationApplicationsHelper.LoadListView(ParentCloudsView.ApplicationsViewInteractiveStackPanel);
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
