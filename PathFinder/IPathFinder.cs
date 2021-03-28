namespace csOdin.PathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPathFinder<T>
    {
        List<MapNode<T>> Find(MapNode<T> start, MapNode<T> end);
    }
}