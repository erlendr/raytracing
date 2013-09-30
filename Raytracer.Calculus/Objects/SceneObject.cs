using System;

namespace Raytracer.Calculus.Objects
{
    public abstract class SceneObject
    {
        public virtual Color Color { get; protected set; }

        public virtual double FindIntersection(Ray ray)
        {
            Console.WriteLine("Wrong find intersection");
            return 0d;
        }

        public virtual Vect GetNormalAt(Vect point)
        {
            return new Vect(0d, 0d, 0d);
        }
    }
}
