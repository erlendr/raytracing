using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public abstract class Material
    {
        public abstract double ComputeShade(Vect vect, Ray ray);
        public abstract SceneObject SceneObject { get; set; }
    }
}