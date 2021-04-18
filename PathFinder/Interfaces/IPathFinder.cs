namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;
    using System.Collections.Generic;

    public interface IPathFinder<TData>
    {
        List<MapNode<TData>> Find();
    }
}