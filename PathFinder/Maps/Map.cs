namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Interfaces;
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;

    public class Map<T> : IMap<T>
    {
        private readonly MapNode<T>[,,] _nodes;

        private Map(int sizeX, int sizeY, int sizeZ)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;

            _nodes = new MapNode<T>[sizeX, sizeY, sizeZ];
            _nodes.Loop((int x, int y, int z) => _nodes[x, y, z] = MapNode<T>.Create(x, y, z, 0, this, default));
        }

        private Map()
        {
        }

        public int SizeX { get; }
        public int SizeY { get; }
        public int SizeZ { get; }

        public static Map<T> Create2Dxy(int sizeX, int sizeY) => new Map<T>(sizeX, sizeY, 1);

        public static Map<T> Create2Dxz(int sizeX, int sizeZ) => new Map<T>(sizeX, 1, sizeZ);

        public static Map<T> Create2Dyz(int sizeY, int sizeZ) => new Map<T>(1, sizeY, sizeZ);

        public static Map<T> Create3D(int sizeX, int sizeY, int sizeZ) => new Map<T>(sizeX, sizeY, sizeZ);

        public MapNode<T> Node(int x, int y, int z) =>
            x < 0 || x > _nodes.GetUpperBound(0) ||
            y < 0 || y > _nodes.GetUpperBound(1) ||
            z < 0 || z > _nodes.GetUpperBound(2)
            ? null
            : _nodes[x, y, z];
    }
}