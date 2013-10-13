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
            double alllight = Red + Green + Blue;
            double excesslight = alllight - 3;
            if (excesslight > 0)
            {
                Red = Red + excesslight * (Red / alllight);
                Green = Green + excesslight * (Green / alllight);
                Blue = Blue + excesslight * (Blue / alllight);
            }
            if (Red > 1) { Red = 1; }
            if (Green > 1) { Green = 1; }
            if (Blue > 1) { Blue = 1; }
            if (Red < 0) { Red = 0; }
            if (Green < 0) { Green = 0; }
            if (Blue < 0) { Blue = 0; }

            return new Color(Red, Green, Blue, Special);
        }
    }
}
