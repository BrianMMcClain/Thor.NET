using System;

namespace Thor.Net.Models
{
    public class FoundryTarget : BaseFoundry
    {
        public Uri Path { get; set; }
        public DateTime Created { get; set; }
    }
}