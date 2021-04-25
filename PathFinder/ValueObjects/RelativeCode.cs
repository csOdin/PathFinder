namespace csOdin.PathFinder.ValueObjects
{
    using csOdin.PathFinder.Enums;
    using csOdin.PathFinder.Maps;
    using System;

    public class RelativeCode
    {
        private RelativeCode()
        {
        }

        public int IncX { get; private set; }
        public int IncY { get; private set; }
        public int IncZ { get; private set; }
        public RelativeLocation Value { get; private set; }

        public static RelativeCode Create(RelativeLocation value)
        {
            var code = new RelativeCode
            {
                Value = value
            };

            var relativeLocationCode = (int)value;
            var XBlock = (relativeLocationCode / 1000000);
            var YBlock = ((relativeLocationCode - (XBlock * 1000000)) / 1000);
            var ZBlock = (relativeLocationCode - (XBlock * 1000000) - (YBlock * 1000));

            code.IncX = XBlock - 100;
            code.IncY = YBlock - 100;
            code.IncZ = ZBlock - 100;

            return code;
        }

        public static RelativeCode Create(int incX, int incY, int incZ)
        {
            var code = new RelativeCode
            {
                IncX = incX,
                IncY = incY,
                IncZ = incZ
            };

            var val = (100 + code.IncX) * 1000000 + (100 + code.IncY) * 1000 + (100 + code.IncZ);

            code.Value =
                Enum.IsDefined(typeof(RelativeLocation), val)
                ? (RelativeLocation)val
                : RelativeLocation.None;
            return code;
        }

        public static RelativeCode Create<T>(MapNode<T> fromNode, MapNode<T> toNode) =>
            Create(fromNode.X - toNode.X, fromNode.Y - toNode.Y, fromNode.Z - toNode.Z);
    }
}