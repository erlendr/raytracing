using System;
using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public class LambertMaterial : Material
    {
        readonly double _ambientCoefficient;
        readonly double _diffuseCoefficient;
        public override SceneObject SceneObject { get; set; }

       public LambertMaterial(double diffuseCoefficient, double ambientCoefficient)
        {
            _diffuseCoefficient = diffuseCoefficient;
            _ambientCoefficient = ambientCoefficient;
        }

       public override Color ComputeColor(Vect intersectionPoint, Ray lightRay, bool isInShadow)
       {
           double shade;

           if (!isInShadow)
           {
               //Object is not in shadow, compute material shading
               shade = ComputeShade(intersectionPoint, lightRay);
           }
           else
           {
               //Object is in shadow, only return ambient coefficient
               shade = _ambientCoefficient;
           }

           //Set pixel color using shade value
           return (Color.ComputePixelColor(SceneObject.Color, shade));
       }

        private double ComputeShade(Vect intersectionPoint, Ray lightRay)
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