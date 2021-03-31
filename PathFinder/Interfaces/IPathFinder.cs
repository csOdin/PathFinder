namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;
    using System.Collections.Generic;

    public interface IPathFinder<T>
    {
        List<MapNode<T>> Find(MapNode<T> start, MapNode<T> end);

        public List<MapNode<int>> Find(MapPoint start, MapPoint end);
    }
}