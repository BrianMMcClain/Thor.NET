using System;
using Thor.Models.Jord;

namespace Thor.Models.J�r�
{
    public class BaseFoundry : IBaseFoundry
    {
        public BaseFoundry()
        {
            Id = Guid.NewGuid();
            Stamp = DateTime.Now;
        }

        public BaseFoundry(Guid id)
        {
            Id = id;
            Stamp = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Stamp { get; set; }
    }
}