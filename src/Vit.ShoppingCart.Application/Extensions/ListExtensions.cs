using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Vit.ShoppingCart.Application.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random Rng = new Random();

        public static IList<T> Shuffle<T>([NotNull] this IList<T> list)
        {
            //https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            var n = list.Count;
            while (n-- > 1)
            {
                var k = Rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}