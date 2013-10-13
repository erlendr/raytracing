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

        public static Color ComputePixelColor(Color objectColor)
        {
            double r = objectColor.Red*RgbMax;
            double g = objectColor.Green*RgbMax;
            double b = objectColor.Blue*RgbMax;
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

        public Color Scalar(double scalar)
        {
            return new Color(Red * scalar, Green * scalar, Blue * scalar, Special);
        }

        public Color Clip()
        {
            double sumOfLight = Red + Green + Blue;
            double excessLight = sumOfLight - 3;

            if (excessLight > 0)
            {
                Red = Red + excessLight * (Red / sumOfLight);
                Green = Green + excessLight * (Green / sumOfLight);
                Blue = Blue + excessLight * (Blue / sumOfLight);
            }

            Red = Math.Max(Math.Min(Red, 1), 0);
            Green = Math.Max(Math.Min(Green, 1), 0);
            Blue = Math.Max(Math.Min(Blue, 1), 0);

            return new Color(Red, Green, Blue, Special);
        }
    }
}
