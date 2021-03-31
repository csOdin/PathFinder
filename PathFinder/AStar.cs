namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Exceptions;
    using csOdin.PathFinder.Interfaces;
    using csOdin.PathFinder.Maps;
    using System;
    using System.Collections.Generic;

    public class AStar<T> : IPathFinder<T>
    {
        private readonly IMap<T> _map;

        public AStar(IMap<T> map) => _map = map;

        public List<MapNode<T>> Find(MapPoint start, MapPoint end) => Find(start, end, null);

        public List<MapNode<T>> Find(MapNode<T> start, MapNode<T> end) => Find(start, end, null);

        public List<MapNode<T>> Find(MapNode<T> start, MapNode<T> end, Func<MapNode<T>, MapNode<T>, double> heuristicFunction)
        {
            start = start ?? throw new ArgumentException(null, nameof(start));
            end = end ?? throw new ArgumentException(null, nameof(end));

            var _foundPath = new List<MapNode<T>>();

            return _foundPath;
        }

        public List<MapNode<T>> Find(MapPoint start, MapPoint end, Func<MapNode<T>, MapNode<T>, double> heuristicFunction)
        {
            var startNode =
                _map.Node(start.X, start.Y, start.Z)
                ?? throw new NodeOutOfMapException(start.X, start.Y, start.Z);

            var endNode =
                _map.Node(end.X, end.Y, end.Z)
                ?? throw new NodeOutOfMapException(end.X, end.Y, end.Z);

            return Find(startNode, endNode, heuristicFunction);
        }
    }
}