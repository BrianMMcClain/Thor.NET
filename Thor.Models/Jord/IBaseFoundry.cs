using System;

namespace Thor.Models.Jord
{
    public interface IBaseFoundry
    {
        string Name { get; set; }
        string Notes { get; set; }
        DateTime Stamp { get; set; }
    }
}