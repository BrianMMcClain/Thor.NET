using System;
using System.Collections.Generic;
using IronFoundry.Models;

namespace Thor.Models.Jord
{
    public class FoundryTarget : BaseFoundry
    {
        public Uri Path { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public string Build { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Framework> Frameworks { get; set; }
        public InfoLimits Limits { get; set; }
        public InfoUsage Usage { get; set; }
        public string Version { get; set; }
        public string Support { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}