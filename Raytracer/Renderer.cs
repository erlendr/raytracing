using Raytracer.Calculus;

//http://www.youtube.com/playlist?list=PLHm_I0tE5kKPPWXkTTtOn8fkcwEGZNETh
namespace Raytracer
{
    public class Renderer
    {
        Vect _x = new Vect(1, 0, 0);
        Vect _y = new Vect(0, 1, 0);
        Vect _z = new Vect(0, 0, 1);

        public Renderer()
        {
            var camera = CreateCamera();
            
            Color whiteLight = new Color(1.0d, 1.0d, 1.0d, 0d);
            Color prettyGreen = new Color(0.5d, 1.0d, 0.5d, 0.3d);
            Color gray = new Color(0.5d, 0.5d, 0.5d, 0d);
            Color black = new Color(0d, 0d, 0d, 0d);

            var lightPosition = new Vect(-7, 10, -10);
            var light = new Light(lightPosition, whiteLight);


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
