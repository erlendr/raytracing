namespace Raytracer.Calculus
{
    public class Camera
    {
        public Vect CameraPosition { get; private set; }
        public Vect CameraDirection { get; private set; }
        public Vect CameraRight { get; private set; }
        public Vect CameraDown { get; private set; }

        public Camera()
        {
            CameraPosition = new Vect(0, 0, 0);
            CameraDirection = new Vect(0, 0, 1);
            CameraRight = new Vect(0, 0, 0);
            CameraDown = new Vect(0, 0, 0);
        }

        public Camera(Vect cameraPosition, Vect cameraDirection, Vect cameraRight, Vect cameraDown)
        {
            CameraPosition = cameraPosition;
            CameraDirection = cameraDirection;
            CameraRight = cameraRight;
            CameraDown = cameraDown;
        }
    }
}
