using System;
using System.Collections.Generic;
using System.Linq;

namespace Thor.Models.Jord
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

        private List<string> GetBaseFoundryNames(IBaseFoundry baseFoundry, IEnumerable<IBaseFoundry> baseFoundries )
        {
            return baseFoundries.Select(foundryApplication => baseFoundry.Name).ToList();
        }
    }
}