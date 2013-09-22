using Raytracer.Calculus;

namespace Raytracer
{
    public class Render
    {
        Vect _x = new Vect(1, 0, 0);
        Vect _y = new Vect(0, 1, 0);
        Vect _z = new Vect(0, 0, 1);

        public Render()
        {
            var camera = CreateCamera();

        }

        private Camera CreateCamera()
        {
            var camPos = new Vect(2, 3, 1);
            var lookAt = new Vect(0, 0, 0);
            var diffBtw = new Vect(camPos.X - lookAt.X, camPos.Y - lookAt.Y, camPos.Z - lookAt.Z);
            var camDir = diffBtw.Negative().Normalize();
            var camRight = _y.CrossProduct(camDir).Normalize();
            var camDown = camRight.CrossProduct(camDir);

            return new Camera(camPos, camDir, camRight, camDown);
        }
    }
}
