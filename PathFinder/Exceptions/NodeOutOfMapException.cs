namespace csOdin.PathFinder.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class NodeOutOfMapException : Exception
    {
        private int x;
        private int y;
        private int z;

        public NodeOutOfMapException(int x, int y, int z) : base($"Node in ({x}.{y}, {z} is out of map")
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        protected NodeOutOfMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private NodeOutOfMapException()
        {
        }

        private NodeOutOfMapException(string message) : base(message)
        {
        }

        private NodeOutOfMapException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}