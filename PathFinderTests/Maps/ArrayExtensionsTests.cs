namespace csOdin.PathFinder.Maps.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using csOdin.PathFinder.Maps;
    using csOdin.PathFinder.Utils;
    using System.Linq;
    using FluentAssertions;

    [TestClass()]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void ThreeArrayLoopShouldLoopProperly()
        {
            var sizeX = 5;
            var sizeY = 18;
            var sizeZ = 67;

            var expectedResult = sizeX * sizeY * sizeZ;

            var arrayX = Enumerable.Range(0, sizeX).ToArray();
            var arrayY = Enumerable.Range(0, sizeY).ToArray();
            var arrayZ = Enumerable.Range(0, sizeZ).ToArray();

            var result = 0;

            (arrayX, arrayY, arrayZ).Loop((int x, int y, int z) =>
            {
                result++;
            });

            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ThreeDimensionArrayLoopShouldLoopProperly()
        {
            var sizeX = 5;
            var sizeY = 18;
            var sizeZ = 67;

            var expectedResult = sizeX * sizeY * sizeZ;

            var array = new int[sizeX, sizeY, sizeZ];

            var result = 0;

            array.Loop((int x, int y, int z) =>
            {
                result++;
            });

            result.Should().Be(expectedResult);
        }
    }
}