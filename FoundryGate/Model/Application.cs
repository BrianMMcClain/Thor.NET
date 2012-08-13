using System;

namespace FoundryGate.Model
{
    public class Application
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deployed { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Stamp { get; set; }
    }
}
