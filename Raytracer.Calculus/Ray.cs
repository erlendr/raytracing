namespace Raytracer.Calculus
{
    public class Ray
    {
        public Vect Origin { get; private set; }
        public Vect Direction { get; private set; }

        public Ray()
        {
            Origin = new Vect(0, 0, 0);
            Direction = new Vect(1, 0, 0);
        }

        public Ray(Vect origin, Vect direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}
