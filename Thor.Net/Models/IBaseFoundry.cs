using System;

namespace Thor.Net.Models
{
    public interface IBaseFoundry
    {
        string Name { get; set; }
        string Notes { get; set; }
        DateTime Stamp { get; set; }
    }
}