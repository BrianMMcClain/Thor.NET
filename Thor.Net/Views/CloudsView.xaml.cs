using System.Collections.Generic;
using System.Windows.Controls;
using Thor.Models.Jord;
using Thor.Net.Views.Clouds;

namespace Thor.Net.Views
{
    public partial class CloudsView : UserControl
    {
        public List<FoundryTarget> FoundryTargets { get; set; }

        public CloudsView()
        {
            InitializeComponent();
            NavigationHelper.LoadListView(CloudsViewInteractiveStackPanel);
        }
    }
}