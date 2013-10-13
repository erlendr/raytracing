using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class FlatMaterial : Material
    {
        readonly double _ambientCoefficient;
        public override SceneObject SceneObject { get; set; }
        public override bool IsReflective { get; set; }
        public override bool IsRefractive { get; set; }
        public override double ReflectionCoefficient { get; set; }

        public FlatMaterial(double ambientCoefficient)
        {
            _ambientCoefficient = ambientCoefficient;
        }

        public override Color ComputeColor(Vect intersectionPoint, Ray lightRay, bool isInShadow)
       {
           double shadeCoefficient = !isInShadow ? 1 : _ambientCoefficient;

           //Set pixel color using shade value
           return (SceneObject.Color.Scalar(shadeCoefficient));
       }
    }
}