using Raytracer.Calculus;

/**
 * http://www.youtube.com/playlist?list=PLHm_I0tE5kKPPWXkTTtOn8fkcwEGZNETh
*/
namespace Raytracer
{
    public class Renderer
    {
        readonly Vect _o = new Vect(0, 0, 0);
        readonly Vect _x = new Vect(1, 0, 0);
        readonly Vect _y = new Vect(0, 1, 0);
        readonly Vect _z = new Vect(0, 0, 1);
        
        public Renderer()
        {
            var camera = CreateCamera();
            
            var whiteLight = new Color(1.0d, 1.0d, 1.0d, 0d);
            var prettyGreen = new Color(0.5d, 1.0d, 0.5d, 0.3d);
            var gray = new Color(0.5d, 0.5d, 0.5d, 0d);
            var black = new Color(0d, 0d, 0d, 0d);
            var maroon = new Color(0.5d, 0.25d, 0.25d, 0);

            var lightPosition = new Vect(-7, 10, -10);
            var light = new Light(lightPosition, whiteLight);

            var sceneSphere = new Sphere(_o, 1.0d, prettyGreen);
            var scenePlane = new Plane(_y, -1, maroon);

        }

        private Camera CreateCamera()
        {
            var camPos = new Vect(3, 1.5, 4);
            var lookAt = new Vect(0, 0, 0);
            var diffBtw = new Vect(camPos.X - lookAt.X, camPos.Y - lookAt.Y, camPos.Z - lookAt.Z);
            var camDir = diffBtw.Negative().Normalize();
            var camRight = _y.CrossProduct(camDir).Normalize();
            var camDown = camRight.CrossProduct(camDir);

            return new Camera(camPos, camDir, camRight, camDown);
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }
    }
}
