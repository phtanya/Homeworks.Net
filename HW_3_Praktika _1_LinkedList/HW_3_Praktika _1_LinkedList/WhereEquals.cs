using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Praktika__1_LinkedList
{
    public static class WhereEquals
    {
        public static IEnumerable<T> WhereEquals2<T>(this IEnumerable<T> target, T value)
        {
            foreach (T item in target)
            {
                if (item.Equals(value))
                {
                    yield return item;
                }
            }
        }
    }
}
