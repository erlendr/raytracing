using System;

namespace Raytracer.Calculus
{
    public class Vect
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vect()
        {
            X = 0;
            Y = 0;
            Z = 0;

        }
        public Vect(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Magnitude()
        {
            return Math.Sqrt((X*X) + (Y*Y) + (Z*Z));
        }

        public Vect Normalize()
        {
            var magnitude = Magnitude();
            return new Vect(X/magnitude, Y/magnitude, Z/magnitude);
        }

        public Vect Negative()
        {
            return new Vect(-X, -Y, -Z);
        }

        public double DotProduct(Vect v)
        {
            return (X*v.X) + (Y*v.Y) + (Z*v.Z);
        }

        public Vect CrossProduct(Vect v)
        {
            return new Vect(
                (Y*v.Z - Z*v.Y),
                (Z*v.X - X*v.Z),
                (X*v.Y - Y*v.X)
                );
        }

        public Vect Add(Vect v)
        {
            return new Vect(X+v.X, Y+v.Y, Z+v.Z);
        }

        public Vect Substract(Vect v)
        {
            return new Vect(X - v.X, Y - v.Y, Z - v.Z);
        }

        public Vect Mult(double scalar)
        {
            return new Vect(X *scalar, Y * scalar, Z * scalar);
        }
    }
}
