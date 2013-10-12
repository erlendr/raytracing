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

        public static Color Add(Color color1, Color color2)
        {
            return color1 + color2;
        }

        public static Color operator +(Color color1, Color color2)
        {
            return new Color(
                color1.Red + color2.Red,
                color1.Green + color2.Green,
                color1.Blue + color2.Blue,
                color1.Special
                );
        }

        public static Color Multiply(Color color1, Color color2)
        {
            return color1 * color2;
        }

        public static Color operator *(Color color1, Color color2)
        {
            return new Color(
                color1.Red * color2.Red,
                color1.Green * color2.Green,
                color1.Blue * color2.Blue,
                color1.Special
                );
        }

        public Color Average(Color color)
        {
            return new Color(
                (Red + color.Red) / 2,
                (Green + color.Green) / 2,
                (Blue + color.Blue) / 2,
                Special
                );
        }
    }
}
