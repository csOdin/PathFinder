namespace csOdin.PathFinder.Tests
{
    using csOdin.PathFinder.Maps;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass()]
    public class AStarTests
    {
        [TestMethod]
        public void Find2DxyFromCornerToCornershouldreturnDiagonalPath()
        {
            var mapSize = 100;
            var map = Map<int>.Create2Dxy(mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint2Dxy(0, 0);
            var end = new MapPoint2Dxy(mapSize - 1, mapSize - 1);
            var path = pathFinder.Find(start, end);

            path.Count.Should().Be(mapSize);

            for (int i = 0; i < mapSize; i++)
            {
                path.ElementAt(i).X.Should().Be(i);
                path.ElementAt(i).Y.Should().Be(i);
            }
        }

        [TestMethod]
        public void Find2DxzFromCornerToCornershouldreturnDiagonalPath()
        {
            var mapSize = 100;
            var map = Map<int>.Create2Dxz(mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint2Dxz(0, 0);
            var end = new MapPoint2Dxz(mapSize - 1, mapSize - 1);
            var path = pathFinder.Find(start, end);

            path.Count.Should().Be(mapSize);

            for (int i = 0; i < mapSize; i++)
            {
                path.ElementAt(i).X.Should().Be(i);
                path.ElementAt(i).Z.Should().Be(i);
            }
        }

        [TestMethod]
        public void Find2DyzFromCornerToCornershouldreturnDiagonalPath()
        {
            var mapSize = 100;
            var map = Map<int>.Create2Dyz(mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint2Dyz(0, 0);
            var end = new MapPoint2Dyz(mapSize - 1, mapSize - 1);
            var path = pathFinder.Find(start, end);

            path.Count.Should().Be(mapSize);

            for (int i = 0; i < mapSize; i++)
            {
                path.ElementAt(i).Y.Should().Be(i);
                path.ElementAt(i).Z.Should().Be(i);
            }
        }

        [TestMethod]
        public void FindFromCornerToCornershouldreturnDiagonalPath()
        {
            var mapSize = 100;
            var map = Map<int>.Create3D(mapSize, mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint() { X = 0, Y = 0, Z = 0 };
            var end = new MapPoint() { X = mapSize - 1, Y = mapSize - 1, Z = mapSize - 1 };
            var path = pathFinder.Find(start, end);

            path.Count.Should().Be(mapSize);

            for (int i = 0; i < mapSize; i++)
            {
                path.ElementAt(i).X.Should().Be(i);
                path.ElementAt(i).Y.Should().Be(i);
                path.ElementAt(i).Z.Should().Be(i);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        [DataRow(-1, 0, 0, 2, 2, 2)]
        [DataRow(0, -1, 0, 2, 2, 2)]
        [DataRow(0, 0, -1, 2, 2, 2)]
        [DataRow(0, 0, 0, -1, 2, 2)]
        [DataRow(0, 0, 0, 2, -1, 2)]
        [DataRow(0, 0, 0, 2, 2, -1)]
        public void FindFromNonExistingMapNodesShuoldThrowException(int startX, int startY, int StartZ, int endX, int endY, int endZ)
        {
            var mapSize = 3;
            var map = Map<int>.Create3D(mapSize, mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint() { X = startX, Y = startY, Z = StartZ };
            var end = new MapPoint() { X = endX, Y = endY, Z = endZ };
            pathFinder.Find(start, end);
        }

        [TestMethod]
        public void FindWhenStartAndEndAreTheSameshouldReturnOneNodePath()
        {
            var mapSize = 3;
            var map = Map<int>.Create3D(mapSize, mapSize, mapSize);
            var pathFinder = new AStar<int>(map);

            var start = new MapPoint() { X = 0, Y = 0, Z = 0 };
            var end = new MapPoint() { X = 0, Y = 0, Z = 0 };
            var path = pathFinder.Find(start, end);

            path.Count.Should().Be(1);
            path.First().X.Should().Be(0);
            path.First().Y.Should().Be(0);
            path.First().Z.Should().Be(0);
        }
    }
}