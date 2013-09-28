using System;

namespace Raytracer.Calculus
{
    public class SceneObject
    {
        private Color _color;
        public virtual Color Color
        {
            get
            {
                return _color;
            }
            protected set
            {
                _color = value;
            }
        }

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
