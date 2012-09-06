using System;

namespace Thor.Models.Jörð
{
    public class FoundryTarget : BaseFoundry
    {
        public Uri Path { get; set; }
        public DateTime Created { get; set; }
    }
}