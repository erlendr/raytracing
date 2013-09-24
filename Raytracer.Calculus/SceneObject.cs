namespace Raytracer.Calculus
{
    public class SceneObject
    {
        private Color _color;
        public Color Color
        {
            get
            {
                return new Color(0, 0, 0, 0);
            }
            protected set
            {
                _color = value;
            }
        }

        public double FindIntersection(Ray ray)
        {
            return 0d;
        }
    }
}
