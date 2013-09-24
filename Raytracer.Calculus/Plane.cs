using System;

namespace Raytracer.Calculus
{
    public class Plane : SceneObject
    {
        public Vect Normal { get; private set; }
        public Double Distance { get; private set; }

        public Plane()
        {
            Normal = new Vect(1, 0, 0); //n
            Distance = 1.0d; //p0
            Color = new Color(0.5d, 0.5d, 0.5d, 0);
        }

        public Plane(Vect normal, double distance, Color color)
        {
            Normal = normal;
            Distance = distance;
            Color = color;
        }

        public Vect GetNormalAt(Ray point)
        {
            return Normal;
        }

        public new double FindIntersection(Ray ray)
        {
            //http://www.scratchapixel.com/lessons/3d-basic-lessons/lesson-7-intersecting-simple-shapes/ray-plane-and-ray-disk-intersection/

            double a = ray.Direction.DotProduct(Normal); // l dot n

            if(a.Equals(0.0d))
            {
                //Ray is parallel to the plane (perpendicular) because angle between them is zero
                return -1d;
            }

            double b = Normal.DotProduct(ray.Origin.Substract(Normal.Mult(Distance))); // (l0 - n*p0) dot n
            return -1*b/a; //Distance from ray origin to point of intersection (d)
        }
    }
}
