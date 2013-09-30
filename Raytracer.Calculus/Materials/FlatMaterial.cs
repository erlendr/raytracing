using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class FlatMaterial : Material
    {
        readonly double _ambientCoefficient;
        public override SceneObject SceneObject { get; set; }

        public FlatMaterial(double ambientCoefficient)
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