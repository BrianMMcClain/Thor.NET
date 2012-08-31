using System;

namespace Thor.Net.Models
{
    public class BaseFoundry : IBaseFoundry
    {
        public BaseFoundry()
        {
            Id = Guid.NewGuid();
        }

        public BaseFoundry(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Stamp { get; set; }
    }
}