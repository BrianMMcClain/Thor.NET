using System.Collections.Generic;
using Thor.Net.Models.Jörð;

namespace Thor.Net.ViewModels.Clouds
{
    public class InformationViewModel : ViewModelBase, IInformationViewModel
    {
        private List<FoundryTarget> _targets = new List<FoundryTarget>();

        public List<FoundryTarget> Targets
        {
            get
            {
                return _targets;
            }
            set
            {
                _targets = value;
                RaisePropertyChanged(() => Targets);
            }
        }
    }
}
