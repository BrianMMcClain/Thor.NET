using System;
using Thor.Models.J�r�;

namespace Thor.Models.Jord
{
    public class FoundryTarget : BaseFoundry
    {
        public Uri Path { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}