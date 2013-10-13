using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class LambertMaterial : Material
    {
        readonly double _ambientCoefficient;
        readonly double _diffuseCoefficient;
        public override SceneObject SceneObject { get; set; }
        public override sealed bool IsRefractive { get; set; }
        public override sealed double ReflectionCoefficient { get; set; }
        public override sealed bool IsReflective { get; set; }

       public LambertMaterial(double diffuseCoefficient, double ambientCoefficient, double reflectionCoefficient, bool isReflective, bool isRefractive)
        {
           ReflectionCoefficient = reflectionCoefficient;
           IsReflective = isReflective;
           IsRefractive = isRefractive;
           _diffuseCoefficient = diffuseCoefficient;
            _ambientCoefficient = ambientCoefficient;
        }

        public override Color ComputeColor(Vect intersectionPoint, Ray lightRay, bool isInShadow)
       {
           double shadeCoefficient;

           if (!isInShadow)
           {
               //Object is not in shadow, compute material shading
               shadeCoefficient = ComputeShade(intersectionPoint, lightRay);
           }
           else
           {
               //Object is in shadow, only return ambient coefficient
               shadeCoefficient = _ambientCoefficient;
           }

           //Set pixel color using shade value
           return (SceneObject.Color.Scalar(shadeCoefficient));
       }

        protected double ComputeShade(Vect intersectionPoint, Ray lightRay)
        {
            var angleBetweenNormalAndLightDirection = ComputeCosineAngle(SceneObject, intersectionPoint, lightRay);

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