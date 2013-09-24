using NUnit.Framework;

namespace Raytracer.Calculus.Tests
{
    [TestFixture]
    public class PlaneTests
    {
        [Test]
        // ReSharper disable InconsistentNaming
        public void FindInterSection_RayIsPerpendicularToPlane_ShouldReturnCorrectValue()
        // ReSharper restore InconsistentNaming
        {
            const double expectedResult = -1d;
            var sut = new Plane();
            var originO = new Vect(0d, 0d, 0d);
            var yDirection = new Vect(0.0d, 1.0d, 0.0d);
            var ray = new Ray(originO, yDirection);
            var response = sut.FindIntersection(ray);
            Assert.AreEqual(expectedResult, response);
        }

        [Test]
        public void FindInterSection_RayIsNotPerpendicularToPlane_ShouldReturnCorrectValue()
        // ReSharper restore InconsistentNaming
        {
            const double expectedResult = 1d;
            var sut = new Plane();
            var originO = new Vect(0d, 0d, 0d);
            var yDirection = new Vect(1.0d, 0.0d, 0.0d);
            var ray = new Ray(originO, yDirection);
            var response = sut.FindIntersection(ray);
            Assert.AreEqual(expectedResult, response);
        }
    }
}
