namespace csOdin.PathFinder.Maps.Tests
{
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass()]
    public class MapBuilderTests
    {
        [TestMethod]
        public void MapBuilderShouldBuildMap()
        {
            var sizeX = 10;
            var sizeY = 20;
            var sizeZ = 30;

            var map = Map<int>.Create3D(sizeX, sizeY, sizeZ);

            var arrayX = Enumerable.Range(0, sizeX).ToArray();
            var arrayY = Enumerable.Range(0, sizeY).ToArray();
            var arrayZ = Enumerable.Range(0, sizeZ).ToArray();

            (arrayX, arrayY, arrayZ).Loop((int x, int y, int z) =>
            {
                var node = map.Node(x, y, z);
                node.Should().NotBeNull();
                node.Should().BeOfType(typeof(MapNode<int>));
                node.X.Should().Be(x);
                node.Y.Should().Be(y);
                node.Z.Should().Be(z);
                node.Cost.Should().Be(0);
                node.IsWalkable.Should().BeTrue();
                node.Data.Should().Be(default);
            });
        }
    }
}