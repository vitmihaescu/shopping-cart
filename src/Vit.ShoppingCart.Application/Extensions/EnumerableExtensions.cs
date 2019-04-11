using System;
using System.Collections.Generic;

namespace Vit.ShoppingCart.Application.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var entry in source)
            {
                action(entry);
            }
        }
    }
}
