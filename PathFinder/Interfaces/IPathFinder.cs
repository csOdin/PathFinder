namespace csOdin.PathFinder.Interfaces
{
    using csOdin.PathFinder.Maps;
    using System;
    using System.Collections.Generic;

    public interface IPathFinder<TData, TMapNode>
        where TMapNode : MapNode<TData>
    {
        List<TMapNode> Find(TMapNode start, TMapNode end, Func<TMapNode, TMapNode, double> heuristicFunction = null);

        List<TMapNode> Find(MapPoint start, MapPoint end, Func<TMapNode, TMapNode, double> heuristicFunction = null);
    }
}