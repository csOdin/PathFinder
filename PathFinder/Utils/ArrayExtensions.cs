namespace csOdin.PathFinder.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ArrayExtensions
    {
        public static void Loop<T1, T2, T3>(this (T1[] index1, T2[] index2, T3[] index3) array, Action<T1, T2, T3> func)
        {
            foreach (var i in array.index1)
            {
                foreach (var j in array.index2)
                {
                    foreach (var k in array.index3)
                    {
                        func(i, j, k);
                    }
                }
            }
        }

        public static void Loop<Titem>(this Titem[,,] me, Action<int, int, int> func)
        {
            for (int x = 0; x <= me.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= me.GetUpperBound(1); y++)
                {
                    for (int z = 0; z <= me.GetUpperBound(2); z++)
                    {
                        func(x, y, z);
                    }
                }
            }
        }
    }
}