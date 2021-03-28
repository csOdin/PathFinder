using csOdin.PathFinder.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csOdin.PathFinder
{
    public class MapNode<T>
    {
        private MapNode()
        {
        }

        public decimal Cost { get; private set; }
        public T Data { get; set; }
        public bool IsWalkable { get; private set; }
        public Map<T> Map { get; private set; }
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Z { get; private set; }

        public List<MapNode<T>> GetNeighbours()
        {
            var returnList = new List<MapNode<T>>();
            var delta = new[] { -1, 0, 1 };
            (delta, delta, delta).Loop((int x, int y, int z) =>
            {
                if (x == 0 && y == 0 && z == 0)
                {
                    return;
                }

                returnList.AddIfNotNull(Map.Node(X + x, Y + y, Z + z));
            });

            return returnList;
        }

        public void SetNotWalkable()
        {
            IsWalkable = false;
            Cost = int.MaxValue;
        }

        public void SetWalkable(decimal cost)
        {
            SetWalkable();
            Cost = cost;
        }

        public void SetWalkable() => SetWalkable(0);

        internal static MapNode<T> Create(int x, int y, int z, decimal cost, Map<T> map, T data) => new()
        {
            X = x,
            Y = y,
            Z = z,
            IsWalkable = true,
            Cost = cost,
            Map = map,
            Data = data
        };

        internal bool IsSameLocationThan(MapNode<T> node) =>
            X == node.X && Y == node.Y && Z == node.Z;
    }
}