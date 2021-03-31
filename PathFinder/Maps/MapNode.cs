namespace csOdin.PathFinder.Maps
{
    using csOdin.PathFinder.Utils;
    using System;
    using System.Collections.Generic;

    public class MapNode<T>
    {
        protected MapNode()
        {
        }

        public double Cost { get; protected set; }
        public T Data { get; set; }
        public bool IsWalkable { get; protected set; }
        public Map<T> Map { get; protected set; }
        public int X { get; protected set; }

        public int Y { get; protected set; }

        public int Z { get; protected set; }

        public double EulerDistanceTo(MapNode<T> node)
        {
            var xDistane = Math.Abs(X - node.X);
            var yDistane = Math.Abs(Y - node.Y);
            var zDistane = Math.Abs(Z - node.Z);

            var distanceXZ = Math.Sqrt(Math.Pow(xDistane, 2) + Math.Pow(zDistane, 2));
            var distance = Math.Sqrt(Math.Pow(distanceXZ, 2) + Math.Pow(yDistane, 2));

            return distance;
        }

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

        public void SetWalkable(double cost)
        {
            SetWalkable();
            Cost = cost;
        }

        public void SetWalkable() => SetWalkable(0);

        internal static MapNode<T> Create(int x, int y, int z, double cost, Map<T> map, T data) => new MapNode<T>()
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