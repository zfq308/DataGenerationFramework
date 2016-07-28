using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace DataGenerationFramework.Core
{

    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> items, T defaultValue = default(T))
        {
            if (items == null)
                return defaultValue;

            var list = items.ToList();
            int count = list.Count();
            if (count == 0)
                return defaultValue;

            return list.ElementAt(RandomHelper.Instance.Next(count));
        }
    }

}