namespace csOdin.PathFinder.Maps
{
    public class MapBuilder
    {
        private int sizeX = 0;
        private int sizeY = 0;
        private int sizeZ = 0;

        public Map<T> Build<T>() => new(sizeX, sizeY, sizeZ);

        public MapBuilder WithSizeX(int size)
        {
            sizeX = size;
            return this;
        }

        public MapBuilder WithSizeY(int size)
        {
            sizeY = size;
            return this;
        }

        public MapBuilder WithSizeZ(int size)
        {
            sizeZ = size;
            return this;
        }
    }
}