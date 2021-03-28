namespace csOdin.PathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AStar : IPathFinder<int>
    {
        private readonly IMap _map;

        public AStar(IMap map) => _map = map;

        public List<MapNode<int>> Find(MapNode<int> start, MapNode<int> end)
        {
            if (start == null)
            {
                throw new ArgumentException(null, nameof(start));
            }

            if (end == null)
            {
                throw new ArgumentException(null, nameof(end));
            }

            var _foundPath = new List<MapNode<int>>();

            _foundPath = ProcessNode(start, end, _foundPath);

            return _foundPath;
        }

        private List<MapNode<int>> ProcessNode(MapNode<int> node, MapNode<int> goal, List<MapNode<int>> path)
        {
            path.Add(node);
            if (node.IsSameLocationThan(goal))
            {
                return path;
            }

            foreach (var neighbour in node.GetNeighbours())
            {
                if (!neighbour.IsWalkable)
                {
                    continue;
                }

                if (path.Contains(neighbour))
                {
                    continue;
                }

                return ProcessNode(neighbour, goal, path);
            }

            return path;
        }
    }
}