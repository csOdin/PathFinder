namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;
    using System.Collections.Generic;

    public interface IPathFinder<T>
    {
        List<MapNode<T>> Find(MapNode<T> start, MapNode<T> end);

        List<MapNode<T>> Find(MapPoint start, MapPoint end);
    }
}