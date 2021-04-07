namespace csOdin.PathFinder.Exceptions
{
    using csOdin.PathFinder.Maps;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException(MapPoint from, MapPoint to)
        {
            From = from;
            To = to;
        }

        protected PathNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private PathNotFoundException()
        {
        }

        private PathNotFoundException(string message) : base(message)
        {
        }

        private PathNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public MapPoint From { get; }
        public MapPoint To { get; }
    }
}