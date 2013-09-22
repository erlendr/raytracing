namespace Raytracer.Calculus
{
    public class Color
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public double Special { get; set; }

        public Color()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Special = 0;
        }
        public Color(double red, double green, double blue, double special)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Special = special;
        }
    }
}
