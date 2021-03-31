namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;

    public interface IMap<T>
    {
        MapNode<T> Node(int x, int y, int z);
    }
}