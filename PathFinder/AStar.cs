namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Exceptions;
    using csOdin.PathFinder.Interfaces;
    using csOdin.PathFinder.Maps;
    using System;
    using System.Collections.Generic;

    public class AStar : IPathFinder<int>
    {
        private readonly IMap<int> _map;

        public AStar(IMap<int> map) => _map = map;

        public List<MapNode<int>> Find(MapPoint start, MapPoint end)
        {
            var startNode =
                _map.Node(start.X, start.Y, start.Z)
                ?? throw new NodeOutOfMapException(start.X, start.Y, start.Z);

            var endNode =
                _map.Node(end.X, end.Y, end.Z)
                ?? throw new NodeOutOfMapException(end.X, end.Y, end.Z);

            return Find(startNode, endNode);
        }

        public List<MapNode<int>> Find(MapNode<int> start, MapNode<int> end)
        {
            start = start ?? throw new ArgumentException(null, nameof(start));
            end = end ?? throw new ArgumentException(null, nameof(end));

            var _foundPath = new List<MapNode<int>>();

            return _foundPath;
        }
    }
}