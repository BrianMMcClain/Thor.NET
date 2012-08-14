using System;

namespace Ui.Wpf.Models
{
    public interface IBaseFoundry
    {
        string Name { get; set; }
        string Notes { get; set; }
        DateTime Stamp { get; set; }
    }
}