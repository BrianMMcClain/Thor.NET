using Caliburn.Micro;

namespace Ui.Wpf.ViewModels
{
    public class HammaViewModel : Conductor<object>
    {
        public HammaViewModel()
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
