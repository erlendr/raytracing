using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class ChessMaterial : LambertMaterial
    {
        readonly double _ambientCoefficient;
        public override SceneObject SceneObject { get; set; }

        public ChessMaterial(double diffuseCoefficient, double ambientCoefficient)
            : base(diffuseCoefficient, ambientCoefficient)
        {
            _ambientCoefficient = ambientCoefficient;
        }

        public override Color ComputeColor(Vect intersectionPoint, Ray lightRay, bool isInShadow)
        {
            double shadeCoefficient = !isInShadow ? ComputeShade(intersectionPoint, lightRay) : _ambientCoefficient;

            //Set pixel color using shade value

            var zValue = Math.Max(intersectionPoint.Z, -intersectionPoint.Z);
            var zValue2 = Math.Floor(zValue) % 2;

            var xValue = Math.Max(intersectionPoint.X, -intersectionPoint.X);
            var xValue2 = Math.Floor(xValue) % 2;
            
            var objectColor = new Color(0, 0, 0, 0);
            if (Equals(zValue2, 1d) || Equals(xValue2, 1d))
            {
                objectColor = new Color(255, 255, 255, 0);
            }
            else if (Equals(zValue2, 1d) && Equals(xValue2, 1d))
            {
                objectColor = new Color(255, 255, 255, 0);
            }
            return (objectColor.Scalar(shadeCoefficient));
        }
    }
}