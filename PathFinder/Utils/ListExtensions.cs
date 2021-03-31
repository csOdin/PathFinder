namespace csOdin.PathFinder.Utils
{
    using System.Collections.Generic;

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