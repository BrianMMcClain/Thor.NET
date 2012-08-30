using System;

namespace Thor.Net.Models
{
    public class BaseFoundry : IBaseFoundry
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Stamp { get; set; }
    }
}