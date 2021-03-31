namespace PathFinder.Tests
{
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;
    using FluentAssertions;
    using System.Linq;
    using Xunit;

    public class MapTests
    {
        [Fact]
        public void MapBuilderShouldBuildMap()
        {
            var sizeX = 10;
            var sizeY = 20;
            var sizeZ = 30;

            var map = new MapBuilder().WithSizeX(sizeX).WithSizeY(sizeY).WithSizeZ(sizeZ).Build<int>();

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