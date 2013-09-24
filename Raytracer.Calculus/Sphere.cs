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
    }
}
