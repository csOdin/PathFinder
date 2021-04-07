namespace csOdin.PathFinder.Maps
{
    public class MapPoint
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }

    public class MapPoint2Dxy : MapPoint
    {
        public MapPoint2Dxy(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal new int Z => 0;
    }

    public class MapPoint2Dxz : MapPoint
    {
        public MapPoint2Dxz(int x, int z)
        {
            X = x;
            Z = z;
        }

        internal new int Y => 0;
    }

    public class MapPoint2Dyz : MapPoint
    {
        public MapPoint2Dyz(int y, int z)
        {
            Y = y;
            Z = z;
        }

        internal new int X => 0;
    }
}