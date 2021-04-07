﻿namespace csOdin.PathFinder
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

            var openSet = new List<AStarNode<TData>>() { start };
            // TODO: Mirar de cambiar por Priority Queue

            while (openSet.Any())
            {
                var current = openSet.OrderBy(i => i.FCost).First();
                if (current.IsSameLocationThan(end))
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
                        aStarNeighbour.HCost = CalculateHScore(aStarNeighbour, end, heuristicFunction);
                        if (!openSet.Contains(aStarNeighbour))
                        {
                            openSet.Add(aStarNeighbour);
                        }
                    }
                }
            }

            throw new PathNotFoundException(start.ToMapPoint(), end.ToMapPoint());
        }

        public List<AStarNode<TData>> Find(MapPoint start, MapPoint end, Func<AStarNode<TData>, AStarNode<TData>, double> heuristicFunction = null)
        {
            var startNode = _map[start.X, start.Y, start.Z];
            var endNode = _map[end.X, end.Y, end.Z];

            return Find(startNode, endNode, heuristicFunction);
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