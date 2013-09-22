using System;
using NUnit.Framework;

namespace Raytracer.Calculus.Tests
{
    [TestFixture]
    public class VectTests
    {
        [Test]
        public void Magnitude_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.ditutor.com/vec/vector_magnitude.html

            double expectedResult = Math.Sqrt(38d);
            var sut = new Vect(-3d, 2d, 5d);
            var response = sut.Magnitude();
            Assert.AreEqual(expectedResult, response);
        }

        [Test]
        public void Normalize_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=vector+%7B2%2C+-5%2C+4%7D&lk=3

            var expectedResult = new Vect(
                2d/(3d*Math.Sqrt(5d)),
                -(Math.Sqrt(5d)/3d),
                4d/(3d*Math.Sqrt(5d))
                );
            var sut = new Vect(2d, -5d, 4d);
            var response = sut.Normalize();
            Assert.AreEqual(expectedResult.X, response.X);
            Assert.AreEqual(expectedResult.Y, response.Y);
            Assert.AreEqual(expectedResult.Z, response.Z);
        }

        [Test]
        public void Negative_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=vector+%7B2%2C+-5%2C+4%7D&lk=3

            const double x = 2d;
            const double y = 4d;
            const double z = -5d;
            var expectedResult = new Vect(-x, -y, -z);
            
            var sut = new Vect(x, y, z);
            var response = sut.Negative();
            Assert.AreEqual(expectedResult.X, response.X);
            Assert.AreEqual(expectedResult.Y, response.Y);
            Assert.AreEqual(expectedResult.Z, response.Z);
        }

        [Test]
        public void DotProduct_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=dot+product

            var sut = new Vect(1d, 2d, 3d);
            var sut2 = new Vect(3d, 4d, 5d);
            const double expectedResult = 26d;
            
            var response = sut.DotProduct(sut2);
            Assert.AreEqual(expectedResult, response);
        }

        [Test]
        public void CrossProduct_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=cross%20product%20%281%2C0%2C0%29%20with%20%280%2C0%2C1%29&lk=2
            //http://no.wikipedia.org/wiki/Kryssprodukt

            var sut = new Vect(1d, 2d, 3d);
            var sut2 = new Vect(3d, 4d, 5d);
            var expectedResult = new Vect(-2d, 4d, -2d);

            var response = sut.CrossProduct(sut2);
            Assert.AreEqual(expectedResult.X, response.X);
            Assert.AreEqual(expectedResult.Y, response.Y);
            Assert.AreEqual(expectedResult.Z, response.Z);
        }

        [Test]
        public void Add_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=add+%281%2C2%2C3%29+with+%283%2C4%2C5%29
            var sut = new Vect(1d, 2d, 3d);
            var sut2 = new Vect(3d, 4d, 5d);
            var expectedResult = new Vect(4d, 6d, 8d);

            var response = sut.Add(sut2);
            Assert.AreEqual(expectedResult.X, response.X);
            Assert.AreEqual(expectedResult.Y, response.Y);
            Assert.AreEqual(expectedResult.Z, response.Z);
        }

        [Test]
        public void Mult_ValidInput_ShouldReturnCorrectValue()
        {
            //http://www.wolframalpha.com/input/?i=add+%281%2C2%2C3%29+with+%283%2C4%2C5%29
            var sut = new Vect(1d, 2d, 3d);
            double sut2 = 3d;
            var expectedResult = new Vect(4d, 6d, 8d);

            var response = sut.Mult(3);
            Assert.AreEqual(expectedResult.X, response.X);
            Assert.AreEqual(expectedResult.Y, response.Y);
            Assert.AreEqual(expectedResult.Z, response.Z);
        }
    }
}
