using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog_Test
{
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> rootNodes, Func<T, IEnumerable<T>> childrenFunction)
        {
            return rootNodes.SelectMany(child => new[] { child }.Concat(childrenFunction(child).Flatten(childrenFunction)));
        }
    }
}
