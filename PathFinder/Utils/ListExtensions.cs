namespace csOdin.PathFinder.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ListExtensions
    {
        public static void AddIfNotNull<T>(this List<T> me, T item)
        {
            if (item == null)
            {
                return;
            }

            me.Add(item);
        }
    }
}