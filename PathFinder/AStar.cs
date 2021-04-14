namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Exceptions;
    using csOdin.PathFinder.Extensions;
    using csOdin.PathFinder.Interfaces;
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AStar<TData> : IPathFinder<TData, AStarNode<TData>>
    {
        private AStarNode<TData> _end;
        private Func<AStarNode<TData>, AStarNode<TData>, double> _heuristicFunction = null;
        private AStarNode<TData>[,,] _map;
        private AStarNode<TData> _start;

        public AStar(IMap<TData> map, MapPoint start, MapPoint end, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null)
        {
            _map = new AStarNode<TData>[map.SizeX, map.SizeY, map.SizeZ];
            _map.Loop((x, y, z) => _map[x, y, z] = AStarNode<TData>.Create(map.Node(x, y, z)));

            var startNode = _map[start.X, start.Y, start.Z];
            var endNode = _map[end.X, end.Y, end.Z];

            _start = startNode ?? throw new ArgumentException(null, nameof(start));
            _end = endNode ?? throw new ArgumentException(null, nameof(end));
        }

        public List<AStarNode<TData>> Find()
        {
            _map[_start.X, _start.Y, _start.Z].GCost = 0;
            _map[_start.X, _start.Y, _start.Z].HCost = CalculateHScore(_start, _end, _heuristicFunction);

            var openSet = new List<AStarNode<TData>>() { _start };
            // TODO: Mirar de cambiar por Priority Queue

            while (openSet.Any())
            {
                var current = openSet.OrderBy(i => i.FCost).First();
                if (current.IsSameLocationThan(_end))
                {
                    return ReconstructPath(current);
                }

                openSet.Remove(current);
                foreach (var neighbour in current.GetNeighbours())
                {
                    var aStarNeighbour = _map[neighbour.X, neighbour.Y, neighbour.Z];
                    var tentative_gCost = current.GCost + aStarNeighbour.Cost;
                    if (tentative_gCost < aStarNeighbour.GCost)
                    {
                        aStarNeighbour.CameFrom = current;
                        aStarNeighbour.GCost = tentative_gCost;
                        aStarNeighbour.HCost = CalculateHScore(aStarNeighbour, _end, _heuristicFunction);
                        if (!openSet.Contains(aStarNeighbour))
                        {
                            openSet.Add(aStarNeighbour);
                        }
                    }
                }
            }

            throw new PathNotFoundException(_start.ToMapPoint(), _end.ToMapPoint());
        }

        private double CalculateHScore(AStarNode<TData> from, AStarNode<TData> to, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null) =>
            heuristicFunction == null
                ? from.EulerDistanceTo(to)
                : heuristicFunction(from, to);

        private List<AStarNode<TData>> ReconstructPath(AStarNode<TData> node)
        {
            var path = new List<AStarNode<TData>>() { node };

            while (node.CameFrom != null)
            {
                path.Insert(0, node.CameFrom);
                node = node.CameFrom;
            }

            return path;
        }
    }
}