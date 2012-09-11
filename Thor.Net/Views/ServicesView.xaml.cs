using System.Windows.Controls;
using Thor.Net.Views.Services;

namespace Thor.Net.Views
{
    public partial class ServicesView : UserControl
    {
        public ServicesView()
        {
            InitializeComponent();
            NavigationServicesHelper.LoadListView(ServicesViewInteractiveStackPanel);
        }
    }
}
