using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Raytracer.Calculus;
using BitmapColor = System.Drawing.Color;
using Color = Raytracer.Calculus.Color;

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
        double accuracy = 0.00000001;

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

            var sceneSphere = new Sphere(new Vect(0d, -4.0d, 0), 1.5d, prettyGreen);
            var scenePlane = new Plane(_y, 1, maroon);
            var sceneObjects = new List<SceneObject>
                                   {
                                       sceneSphere,
                                       scenePlane
                                   };

            const int width = 500;
            const int height = 500;
            double aspectRatio = (double) width / (double) height;
            double xamnt, yamnt;

            using (var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    for (var y = 0; y < bitmap.Height; y++)
                    {
                        if(bitmap.Width > bitmap.Height)
                        {
                            xamnt = ((x + 0.5d) / width) * aspectRatio - (((width - height) / (double) height) / 2d);
                            yamnt = ((height - y) + 0.5d) / height;
                        }
                        else if(bitmap.Height > bitmap.Width)
                        {
                            xamnt = (x + 0.5d)/width;
                            yamnt = (((height - y) + 0.5d) / height) / aspectRatio - (((height - width)/(double) width)/2d);
                        }
                        else
                        {
                            xamnt = (x + 0.5d)/width;
                            yamnt = ((height - y) + 0.5d) / height;
                        }

                        Vect camRayOrigin = camera.CameraPosition;
                        Vect camRayDirection =
                            camera.CameraDirection.Add(
                                camera.CameraRight.Mult(xamnt - 0.5d).Add(camera.CameraDown.Mult(yamnt - 0.5))).
                                Normalize();

                        Ray camRay = new Ray(camRayOrigin, camRayDirection);
                        var intersections = new List<double>();

                        for (int i = 0; i < sceneObjects.Count; i++)
                        {
                            intersections.Add(sceneObjects[i].FindIntersection(camRay));
                        }

                        int indexOfWinningObject = WinningObjectIndex(intersections);

                        var r = 0;
                        var g = 0;
                        var b = 0;
                        if (indexOfWinningObject > -1)
                        {
                            //if (intersections[indexOfWinningObject] > accuracy)
                            //{
                                var winningObject = sceneObjects[indexOfWinningObject];
                       
                                r = (int) Math.Round(winningObject.Color.Red*255);
                                g = (int) Math.Round(winningObject.Color.Blue*255);
                                b = (int) Math.Round(winningObject.Color.Green*255);
                            //}
                        }
                        
                        var color = BitmapColor.FromArgb(r, g, b);
                        bitmap.SetPixel(x, y, color);
                    }
                }

                bitmap.Save("output.bmp");
            }
        }

        private static int WinningObjectIndex(IReadOnlyList<double> intersections)
        {
            // Return the index of the winning intersection
            int indexOfMinimumValue  = 0;
            
            //prevent uneccessary calculations
            if(intersections.Count == 0)
            {
                // if there are no intersections
                return -1;
            }

            if(intersections.Count == 1)
            {
                // if only intersection is greater than zero than its the winning index
                if (intersections[0] > 0) return 0;
                
                //otherwise the only intersection value is negative;
                return -1;
            }

            //There is more than one intersection
            // First find the maximum value in list of intersections
            double max = 0;

            for (var i = 0; i < intersections.Count; i++)
            {
                if (intersections[i] > max) max = intersections[i];
            }

            // then starting from the maximum value find the minimum positive value
            if(max > 0)
            {
                // We only want positive intersections
                for (var i = 0; i < intersections.Count; i++)
                {
                    if (intersections[i] > 0 && intersections[i] <= max)
                    {
                        max = intersections[i];
                        indexOfMinimumValue = i;
                    }
                }

                return indexOfMinimumValue;
            }

            return -1;
        }

        private Camera CreateCamera()
        {
            var camPos = new Vect(15, -0.25, -4);
            var lookAt = new Vect(0, 0, 0);
            var diffBtw = new Vect(camPos.X - lookAt.X, camPos.Y - lookAt.Y, camPos.Z - lookAt.Z);
            var camDir = diffBtw.Negative().Normalize();
            var camRight = _y.CrossProduct(camDir).Normalize();
            var camDown = camRight.CrossProduct(camDir);

            return new Camera(camPos, camDir, camRight, camDown);
        }
    }
}
