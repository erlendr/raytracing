namespace Raytracer.Console
{
    class Raytrace
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting raytracer...");
            //var render = new Renderer();
            //render.Render();
            var imageHandler = new ImageHandler();
            imageHandler.CreateImage(320, 240);
            System.Console.WriteLine("Done");
        }
    }
}
