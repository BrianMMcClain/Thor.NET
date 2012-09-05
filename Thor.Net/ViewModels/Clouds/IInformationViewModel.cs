using System.Collections.Generic;
using Thor.Net.Models.Jörð;

namespace Thor.Net.ViewModels.Clouds
{
    public interface IInformationViewModel
    {
        List<FoundryTarget> Targets { get; set; }
    }
}