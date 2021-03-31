namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;

    public interface IMap<T>
    {
        int SizeX { get; }

        int SizeY { get; }

        int SizeZ { get; }

        MapNode<T> Node(int x, int y, int z);
    }
}