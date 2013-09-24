using System;

namespace Raytracer.Calculus
{
    public class Plane : SceneObject
    {
        public Vect Normal { get; private set; }
        public Double Distance { get; private set; }

        public Plane()
        {
            Normal = new Vect(1, 0, 0);
            Distance = 1.0d;
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
            Vect rayDirection = ray.Direction;
            double a = rayDirection.DotProduct(Normal);
            if(a.Equals(0.0d))
            {
                //Ray is parallell to the plane (perpendicular) because angle between them
                return -1d;
            }

            double b = Normal.DotProduct(ray.Origin.Add(Normal.Mult(Distance).Negative()));
            return -1*b/a;
        }
    }
}
