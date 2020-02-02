using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Test_без_БД
{
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> rootNodes, Func<T, IEnumerable<T>> childrenFunction)
        {
            return rootNodes.SelectMany(child => new[] { child }.Concat(childrenFunction(child).Flatten(childrenFunction)));
        }
    }
}
