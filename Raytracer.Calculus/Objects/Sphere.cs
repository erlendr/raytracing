using System;
using Raytracer.Calculus.Materials;

namespace Raytracer.Calculus.Objects
{
    public sealed class Sphere : SceneObject
    {
        public Vect Center { get; private set; }
        public Double Radius { get; private set; }

        public Sphere()
        {
            Center = new Vect(0, 0, 0);
            Radius = 1.0d;
            Color = new Color(0.5d, 0.5d, 0.5d, 0);
        }

        public Sphere(Vect center, double radius, Color color, Material material)
        {
            Center = center;
            Radius = radius;
            Color = color;
            Material = material;
        }

        public override double FindIntersection(Ray ray)
        {
            //See: http://www.cs.unc.edu/~rademach/xroads-RT/RTarticle.html#glas90

            //Compute scalar distance from rayOrigin to circleOrigin using euclidean distance
            //double c = Math.Sqrt((eX-oX) + (eY-oY) + (eZ-oZ));
            var EO = new Vect(Center.X - ray.Origin.X, Center.Y - ray.Origin.Y, Center.Z - ray.Origin.Z);
            double v = EO.DotProduct(ray.Direction);
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

        public override Vect GetNormalAt(Vect point)
        {
            Vect normalVect = point.Add(Center.Negative()).Normalize();
            return normalVect;
        }
    }
}
