using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_2_Delegate
{
    public static class Extension
    {
        // FirstOrDefault
        public static T FirstOrDefault2<T>(this IEnumerable<T> source )
        {
            foreach (T item in source)
            {
                if (item != null)
                {
                    return item;
                    break;
                }
            }

            return default;
        }

        // SkipWhile
        public static IEnumerable<T> SkipWhile2<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (T item in source)
            {
                if (func(item) == false)
                {
                    yield return item;
                }
            }
        }
    }
}
