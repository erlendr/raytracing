using System;
using Raytracer;

namespace RaytracerApp
{
    class Raytrace
    {
        static void Main(string[] args)
        {
            //var render = new Renderer();
            //render.Render();
            Console.WriteLine("Starting raytracer...");
            var imageHandler = new ImageHandler();
            imageHandler.CreateImage(320, 240);
            Console.WriteLine("Done");
        }
    }
}
