using System;

namespace Raytracer.Calculus
{
    public class Sphere : SceneObject
    {
        public Vect Center { get; private set; }
        public Double Radius { get; private set; }

        public Sphere()
        {
            Center = new Vect(0, 0, 0);
            Radius = 1.0d;
            Color = new Color(0.5d, 0.5d, 0.5d, 0);
        }

        public Sphere(Vect center, double radius, Color color)
        {
            Center = center;
            Radius = radius;
            Color = color;
        }

        public override double FindIntersection(Ray ray)
        {
            //See: http://www.cs.unc.edu/~rademach/xroads-RT/RTarticle.html#glas90

            Vect E = ray.Origin;
            double eX = E.X;
            double eY = E.Y;
            double eZ = E.Z;

            //Vect V = ray.Direction;
            //double vX = V.X;
            //double vY = V.Y;
            //double vZ = V.Z;

            Vect sphereCenter = Center;
            double oX = sphereCenter.X;
            double oY = sphereCenter.Y;
            double oZ = sphereCenter.Z;

            //Compute scalar distance from rayOrigin to circleOrigin using euclidean distance
            //double c = Math.Sqrt((eX-oX) + (eY-oY) + (eZ-oZ));
            var EO = new Vect(oX - eX, oY - eY, oZ - eZ);
            double v = EO.DotProduct(V);
            var disc = (Radius * Radius) - ((EO.DotProduct(EO)) - (v * v));
            if (disc < 0)
            {
                // no intersection
                return -1;
            }
            var d = Math.Sqrt(disc);
            var dist = v - d;
            return dist;

        }

        public double FindIntersection2(Ray ray)
        {
            Vect rayOrigin = ray.Origin;
            double rayOriginX = rayOrigin.X;
            double rayOriginY = rayOrigin.Y;
            double rayOriginZ = rayOrigin.Z;

            Vect rayDirection = ray.Direction;
            double rayDirectionX = rayDirection.X;
            double rayDirectionY = rayDirection.Y;
            double rayDirectionZ = rayDirection.Z;

            Vect sphereCenter = Center;
            double sphereCenterX = sphereCenter.X;
            double sphereCenterY = sphereCenter.Y;
            double sphereCenterZ = sphereCenter.Z;

            double a = 1; //normalized
            double b = (2 * (rayOriginX - sphereCenterX) * rayDirectionX)
                       + (2 * (rayOriginY - sphereCenterY) * rayDirectionY)
                       + (2 * (rayOriginZ - sphereCenterZ) * rayDirectionZ);
            double c = Math.Pow(rayOriginX - sphereCenterX, 2)
                        + Math.Pow(rayOriginY - sphereCenterY, 2)
                        + Math.Pow(rayOriginZ - sphereCenterZ, 2)
                        - (Radius * Radius);

            double discriminant = b * b - 4 * c;

            if (discriminant > 0)
            {
                // The ray intersects the sphere

                //the first root
                double root1 = ((-1d * b - Math.Sqrt(discriminant)) / 2) - 0.000001d;

                if (root1 > 0)
                {
                    // the first root is the samallest positive root
                    return root1;
                }

                // the second root is the smalles positive root
                double root2 = ((Math.Sqrt(discriminant) - b) / 2) - 0.000001d;
                return root2;
            }

            // the ray missed the sphere
            return -1;
        }

        public Vect GetNormalAt(Vect point)
        {
            Vect normalVect = point.Add(Center.Negative()).Normalize();
            return normalVect;
        }
    }
}
