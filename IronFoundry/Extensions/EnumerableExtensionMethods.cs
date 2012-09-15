using System.Collections.Generic;
using System.Linq;

namespace IronFoundry.Extensions
{
    internal static class EnumerableExtensionMethods
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> argThis)
        {
            return null == argThis || false == argThis.Any();
        }

        public static IList<T> ToListOrNull<T>(this IEnumerable<T> argThis)
        {
            return null == argThis ? null : argThis.ToList();
        }

        public static T[] ToArrayOrNull<T>(this IEnumerable<T> argThis)
        {
            return null == argThis ? null : argThis.ToArray();
        }
    }
}