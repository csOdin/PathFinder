namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;
    using System.Collections.Generic;

    public interface IPathFinder<TData, TMapNode>
        where TMapNode : MapNode<TData>
    {
        List<TMapNode> Find();
    }
}