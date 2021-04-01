namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Exceptions;
    using csOdin.PathFinder.Interfaces;
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AStar<TData, TMapNode> : IPathFinder<TData, AStarNode<TData>>
        where TMapNode : MapNode<TData>
    {
        private readonly AStarNode<TData>[,,] _map;

        public AStar(IMap<TData> map)
        {
            _map = new AStarNode<TData>[map.SizeX, map.SizeY, map.SizeZ];
            _map.Loop((x, y, z) => _map[x, y, z] = AStarNode<TData>.Create(map.Node(x, y, z)));
        }

        public List<AStarNode<TData>> Find(AStarNode<TData> start, AStarNode<TData> end, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null)
        {
            start = start ?? throw new ArgumentException(null, nameof(start));
            end = end ?? throw new ArgumentException(null, nameof(end));

            _map[start.X, start.Y, start.Z].GCost = 0;
            _map[start.X, start.Y, start.Z].HCost = CalculateHScore(start, end, heuristicFunction);

            var openSet = new AStarNode<TData>[] { start };

            while (openSet.Length != 0)
            {
                // implement loop
            }

            return _foundPath;
        }

        public List<AStarNode<TData>> Find(MapPoint start, MapPoint end, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null)
        {
            var startNode =
                _map[start.X, start.Y, start.Z]
                ?? throw new NodeOutOfMapException(start.X, start.Y, start.Z);

            var endNode =
                _map[end.X, end.Y, end.Z]
                ?? throw new NodeOutOfMapException(end.X, end.Y, end.Z);

            return Find(startNode, endNode, heuristicFunction);
        }

        private double CalculateHScore(AStarNode<TData> from, AStarNode<TData> to, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null) =>
            heuristicFunction == null
                ? from.EulerDistanceTo(to)
                : heuristicFunction(from, to);
    }
}