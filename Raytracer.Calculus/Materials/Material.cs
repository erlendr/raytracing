using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public abstract class Material
    {
        public abstract SceneObject SceneObject { get; set; }
        public abstract bool IsReflective { get; set; }
        public abstract bool IsRefractive { get; set; }
        public abstract Color ComputeColor(Vect intersectionPoint, Ray lightRay, bool isInShadow);
    }
}