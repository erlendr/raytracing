using System.Diagnostics;

namespace Raytracer.Console
{
    class Raytrace
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting raytracer...");
            var sw = new Stopwatch();
            sw.Start();
            new Scene();
            sw.Stop();
            System.Console.WriteLine("Done in " + sw.Elapsed);
            System.Console.WriteLine("Press any key to exit");
            System.Console.Read();
        }
    }
}
