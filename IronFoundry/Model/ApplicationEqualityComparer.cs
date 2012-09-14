using System.Collections.Generic;

namespace IronFoundry.Model
{
    public class ApplicationEqualityComparer : IEqualityComparer<Application>
    {
        public bool Equals(Application c1, Application c2)
        {
            return c1.Name.Equals(c2.Name);
        }

        public int GetHashCode(Application c)
        {
            return c.Name.GetHashCode();
        }
    }
}