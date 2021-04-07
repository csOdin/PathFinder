namespace csOdin.PathFinder.Extensions
{
    using csOdin.PathFinder.Maps;

    public static class MapNodeExtensions
    {
        public static MapPoint ToMapPoint<T>(this MapNode<T> me) =>
            new MapPoint { X = me.X, Y = me.Y, Z = me.Z };
    }
}