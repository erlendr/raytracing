namespace Raytracer.Calculus
{
    public class Light
    {
        public double Intensity { get; private set; }
        public Vect Position { get; private set; }
        public Color Color { get; private set; }

        public Light()
        {
            Position = new Vect(0, 0, 0);
            Color = new Color(1, 1, 1, 0);
            Intensity = 1d;
        }

        public Light(Vect position, Color color, double intensity)
        {
            Intensity = intensity;
            Position = position;
            Color = color;
        }
    }
}
