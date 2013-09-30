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
           double shade = !isInShadow ? 1 : _ambientCoefficient;

           //Set pixel color using shade value
           return (Color.ComputePixelColor(SceneObject.Color, shade));
       }
    }
}