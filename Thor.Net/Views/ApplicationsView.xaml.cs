using System.Windows.Controls;
using Thor.Net.Views.Applications;

namespace Thor.Net.Views
{
    /// <summary>
    /// Interaction logic for ApplicationsView.xaml
    /// </summary>
    public partial class ApplicationsView : UserControl
    {
        public ApplicationsView()
        {
            InitializeComponent();
            NavigationApplicationsHelper.LoadListView(ApplicationsViewInteractiveStackPanel);
        }
    }
}
