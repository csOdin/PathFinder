namespace PathFinderTests.ValueObjectsTests
{
    using csOdin.PathFinder.Enums;
    using csOdin.PathFinder.ValueObjects;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class RelativeCodeTests
    {
        [TestMethod]
        [DataRow(RelativeLocation.Self, 0, 0, 0)]
        [DataRow(RelativeLocation.Left, -1, 0, 0)]
        [DataRow(RelativeLocation.FrontLeft, -1, 0, 1)]
        [DataRow(RelativeLocation.Front, 0, 0, 1)]
        [DataRow(RelativeLocation.FrontRight, 1, 0, 1)]
        [DataRow(RelativeLocation.Right, 1, 0, 0)]
        [DataRow(RelativeLocation.BackRight, 1, 0, -1)]
        [DataRow(RelativeLocation.Back, 0, 0, -1)]
        [DataRow(RelativeLocation.BackLeft, -1, 0, -1)]
        [DataRow(RelativeLocation.Top, 0, 1, 0)]
        [DataRow(RelativeLocation.TopLeft, -1, 1, 0)]
        [DataRow(RelativeLocation.TopFrontLeft, -1, 1, 1)]
        [DataRow(RelativeLocation.TopFront, 0, 1, 1)]
        [DataRow(RelativeLocation.TopFrontRight, 1, 1, 1)]
        [DataRow(RelativeLocation.TopRight, 1, 1, 0)]
        [DataRow(RelativeLocation.TopBackRight, 1, 1, -1)]
        [DataRow(RelativeLocation.TopBack, 0, 1, -1)]
        [DataRow(RelativeLocation.TopBackLeft, -1, 1, -1)]
        [DataRow(RelativeLocation.Bottom, 0, -1, 0)]
        [DataRow(RelativeLocation.BottomLeft, -1, -1, 0)]
        [DataRow(RelativeLocation.BottomFrontLeft, -1, -1, 1)]
        [DataRow(RelativeLocation.BottomFront, 0, -1, 1)]
        [DataRow(RelativeLocation.BottomFrontRight, 1, -1, 1)]
        [DataRow(RelativeLocation.BottomRight, 1, -1, 0)]
        [DataRow(RelativeLocation.BottomBackRight, 1, -1, -1)]
        [DataRow(RelativeLocation.BottomBack, 0, -1, -1)]
        [DataRow(RelativeLocation.BottomBackLeft, -1, -1, -1)]
        [DataRow(RelativeLocation.None, 10, 10, 10)]
        public void IncrementsShouldReturnCorrectLocation(RelativeLocation relativeLocation, int incX, int incY, int incZ)
        {
            var relativeCode = RelativeCode.Create(incX, incY, incZ);
            relativeCode.Value.Should().Be(relativeLocation);
        }

        [TestMethod]
        [DataRow(RelativeLocation.Self, 0, 0, 0)]
        [DataRow(RelativeLocation.Left, -1, 0, 0)]
        [DataRow(RelativeLocation.FrontLeft, -1, 0, 1)]
        [DataRow(RelativeLocation.Front, 0, 0, 1)]
        [DataRow(RelativeLocation.FrontRight, 1, 0, 1)]
        [DataRow(RelativeLocation.Right, 1, 0, 0)]
        [DataRow(RelativeLocation.BackRight, 1, 0, -1)]
        [DataRow(RelativeLocation.Back, 0, 0, -1)]
        [DataRow(RelativeLocation.BackLeft, -1, 0, -1)]
        [DataRow(RelativeLocation.Top, 0, 1, 0)]
        [DataRow(RelativeLocation.TopLeft, -1, 1, 0)]
        [DataRow(RelativeLocation.TopFrontLeft, -1, 1, 1)]
        [DataRow(RelativeLocation.TopFront, 0, 1, 1)]
        [DataRow(RelativeLocation.TopFrontRight, 1, 1, 1)]
        [DataRow(RelativeLocation.TopRight, 1, 1, 0)]
        [DataRow(RelativeLocation.TopBackRight, 1, 1, -1)]
        [DataRow(RelativeLocation.TopBack, 0, 1, -1)]
        [DataRow(RelativeLocation.TopBackLeft, -1, 1, -1)]
        [DataRow(RelativeLocation.Bottom, 0, -1, 0)]
        [DataRow(RelativeLocation.BottomLeft, -1, -1, 0)]
        [DataRow(RelativeLocation.BottomFrontLeft, -1, -1, 1)]
        [DataRow(RelativeLocation.BottomFront, 0, -1, 1)]
        [DataRow(RelativeLocation.BottomFrontRight, 1, -1, 1)]
        [DataRow(RelativeLocation.BottomRight, 1, -1, 0)]
        [DataRow(RelativeLocation.BottomBackRight, 1, -1, -1)]
        [DataRow(RelativeLocation.BottomBack, 0, -1, -1)]
        [DataRow(RelativeLocation.BottomBackLeft, -1, -1, -1)]
        public void RelativeLocationShouldReturnCorrectIncrements(RelativeLocation relativeLocation, int incX, int incY, int incZ)
        {
            var relativeCode = RelativeCode.Create(relativeLocation);

            relativeCode.IncX.Should().Be(incX);
            relativeCode.IncY.Should().Be(incY);
            relativeCode.IncZ.Should().Be(incZ);
        }
    }
}