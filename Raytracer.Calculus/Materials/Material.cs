using Raytracer.Calculus.Objects;

namespace Raytracer.Calculus.Materials
{
    public abstract class Material
    {
        public abstract double ComputeShade(SceneObject sceneObject, Vect vect, Ray ray);
    }
}