using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class LambertMaterial : Material
    {
        readonly double _ambientCoefficient;
        readonly double _diffuseCoefficient;

        public LambertMaterial(double diffuseCoefficient, double ambientCoefficient)
        {
            _diffuseCoefficient = diffuseCoefficient;
            _ambientCoefficient = ambientCoefficient;
        }

        public override double ComputeShade(SceneObject sceneObject, Vect intersectionPoint, Ray lightRay)
        {
            var angleBetweenNormalAndLightDirection = ComputeCosineAngle(sceneObject, intersectionPoint, lightRay);

            return _ambientCoefficient +
                   _diffuseCoefficient * angleBetweenNormalAndLightDirection;
        }

        private static double ComputeCosineAngle(SceneObject sceneObject, Vect intersectionPoint, Ray lightRay)
        {
            var winningObjectNormal = sceneObject.GetNormalAt(intersectionPoint);
            var angleBetweenNormalAndLightDirection =
                winningObjectNormal.DotProduct(lightRay.Direction);

            if (angleBetweenNormalAndLightDirection < 0)
            {
                angleBetweenNormalAndLightDirection = 0;
            }
            return angleBetweenNormalAndLightDirection;
        }
    }
}