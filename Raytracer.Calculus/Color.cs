using System;

namespace Raytracer.Calculus
{
    public class Color
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public double Special { get; set; }

        const double RgbMax = 255d;

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

        public static Color ComputePixelColor(Color objectColor, double shade)
        {
            double r = Math.Min(objectColor.Red * shade * RgbMax, RgbMax);
            double g = Math.Min(objectColor.Green * shade * RgbMax, RgbMax);
            double b = Math.Min(objectColor.Blue * shade * RgbMax, RgbMax);
            return new Color(r, g, b, 0d);
        }
    }
}
