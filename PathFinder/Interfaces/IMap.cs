namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;

    public interface IMap<T>
    {
        public MapNode<T> Node(int x, int y, int z);
    }
}