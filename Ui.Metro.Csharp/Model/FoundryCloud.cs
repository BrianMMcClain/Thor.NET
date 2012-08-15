using System;
using System.Collections.Generic;

namespace Ui.Metro.Csharp.Model
{
    public class FoundryCloud
    {
        public string Name { get; set; }
        public Uri Target { get; set; }
        

        public List<FoundryApplication> Applications { get; set; }
        public List<FoundryService> Serviceses { get; set; }

       
    }
}