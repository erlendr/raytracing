namespace Raytracer.Calculus
{
    public class Light
    {
        public Vect Position { get; private set; }
        public Color Color { get; private set; }

        public Light()
        {
            Position = new Vect(0, 0, 0);
            Color = new Color(1, 1, 1, 0);
        }

        public Light(Vect position, Color color)
        {
            Position = position;
            Color = color;
        }
    }
}
