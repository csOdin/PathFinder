namespace csOdin.PathFinder
{
    using csOdin.PathFinder.Utils;
    using System;
    using System.Collections.Generic;

    public class Map<T> : IMap
    {
        private readonly MapNode<T>[,,] _nodes;

        internal Map(int sizeX, int sizeY, int sizeZ)
        {
            _nodes = new MapNode<T>[sizeX, sizeY, sizeZ];
            _nodes.Loop((int x, int y, int z) => _nodes[x, y, z] = MapNode<T>.Create(x, y, z, 0, this, default));
        }

        private Map()
        {
        }

        public MapNode<T> Node(int x, int y, int z) =>
            x < 0 || x > _nodes.GetUpperBound(0) ||
            y < 0 || y > _nodes.GetUpperBound(1) ||
            z < 0 || z > _nodes.GetUpperBound(2)
            ? null
            : _nodes[x, y, z];
    }
}