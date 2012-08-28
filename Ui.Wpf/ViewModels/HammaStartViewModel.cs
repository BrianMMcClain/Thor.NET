using Caliburn.Micro;

namespace Ui.Wpf.ViewModels
{
    public class HammaStartViewModel : Conductor<object>
    {
        public HammaStartViewModel()
        {
            ShowFoundryClouds();
        }

        public void ShowFoundryClouds()
        {
            ActivateItem(new FoundryCloudsViewModel());
        }

        public void ShowFoundryApplications()
        {
            ActivateItem(new FoundryApplicationsViewModel());
        }

        public void ShowFoundryServices()
        {
            ActivateItem(new FoundryServicesViewModel());
        }
    }
}
