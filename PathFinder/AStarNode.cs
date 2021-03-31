namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Maps;

    public class AStarNode<TData> : MapNode<TData>
    {
        public AStarNode<TData> CameFrom { get; internal set; }
        public double FCost => HCost + GCost;
        public double GCost { get; internal set; }
        public double HCost { get; internal set; }

        public static AStarNode<TData> Create(MapNode<TData> node) =>
            new AStarNode<TData>()
            {
                Cost = node.Cost,
                GCost = double.MaxValue,
                HCost = double.MaxValue,
                Data = node.Data,
                IsWalkable = node.IsWalkable,
                X = node.X,
                Y = node.Y,
                Z = node.Z,
                Map = node.Map,
                CameFrom = null,
            };
    }
}