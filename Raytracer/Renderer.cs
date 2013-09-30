using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Raytracer.Calculus;
using Raytracer.Calculus.Objects;
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

        private const double RgbMax = 255d;
        private const double AmbientCoefficient = 0.1d;
        private const double DiffuseCoefficient = 1d;
        private const double Accuracy = 0.00000001;

        public Renderer()
        {
            var camera = CreateCamera();

            var whiteLight = new Color(1.0d, 1.0d, 1.0d, 0d);
            var prettyGreen = new Color(0.5d, 1.0d, 0.5d, 0.3d);
            var red = new Color(1d, 0.0d, 0d, 0.3d);
            var gray = new Color(0.5d, 0.5d, 0.5d, 0d);
            var black = new Color(0d, 0d, 0d, 0d);
            var maroon = new Color(0.5d, 0.25d, 0.25d, 0);

            var lightPosition = new Vect(7, 5, -5);
            var light = new Light(lightPosition, whiteLight);

            var sceneSphere = new Sphere(_o.Add(new Vect(1d, -0.5d, -1.5d)), 0.75d, red);
            var sceneSphere2 = new Sphere(_o, 1.0d, prettyGreen);
            var scenePlane = new Plane(_y, -1, maroon);
            var sceneObjects = new List<SceneObject>
                                   {
                                       sceneSphere,
                                       sceneSphere2,
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

                        var camRayOrigin = camera.CameraPosition;
                        var camRayDirection =
                            camera.CameraDirection.Add(
                                camera.CameraRight.Mult(xamnt - 0.5d).Add(camera.CameraDown.Mult(yamnt - 0.5d))).
                                Normalize();

                        var camRay = new Ray(camRayOrigin, camRayDirection);
                        var intersections = new List<double>();

                        for (int i = 0; i < sceneObjects.Count; i++)
                        {
                            intersections.Add(sceneObjects[i].FindIntersection(camRay));
                        }

                        int indexOfWinningObject = WinningObjectIndex(intersections);

                        var pixelColor = black;

                        if (indexOfWinningObject > -1)
                        {
                            if (intersections[indexOfWinningObject] > Accuracy)
                            {
                                var winningObject = sceneObjects[indexOfWinningObject];
                                
                                //compute light ray
                                var intersectionPoint =
                                    camRayOrigin.Add(camRayDirection.Mult(intersections[indexOfWinningObject]));
                                var lightRay = ComputeLightRayFromPoint(intersectionPoint, light);

                                //Compute light ray intersection with all objects except winning object in scene
                                bool isInShadow = LightRayIntersectsObject(sceneObjects, indexOfWinningObject, lightRay);

                                double shade;
                              
                                if (!isInShadow)
                                {
                                    //Object is not in shadow, compute lambert shading
                                    shade = ComputeLambertShading(winningObject, intersectionPoint, lightRay);
                                }
                                else
                                {
                                    //Object is in shadow, only return ambient coefficient
                                    shade = AmbientCoefficient;
                                }

                                //Set pixel color using shade value
                                pixelColor = ComputePixelColor(winningObject.Color, shade);
                            }
                        }

                        //Set bitmap color using pixel color
                        SetBitmapPixel(bitmap, pixelColor, x, y);
                    }
                }

                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap.Save("output.bmp");
            }
        }

        private static void SetBitmapPixel(Bitmap bitmap, Color pixelColor, int pixelPositionX, int pixelPositionY)
        {
            var color = BitmapColor.FromArgb(
                (int) Math.Round(pixelColor.Red),
                (int) Math.Round(pixelColor.Green),
                (int) Math.Round(pixelColor.Blue));
            bitmap.SetPixel(pixelPositionX, pixelPositionY, color);
        }

        private static Color ComputePixelColor(Color objectColor, double shade)
        {
            double r = Math.Min(objectColor.Red * shade * RgbMax, RgbMax);
            double g = Math.Min(objectColor.Green * shade * RgbMax, RgbMax);
            double b = Math.Min(objectColor.Blue * shade * RgbMax, RgbMax);
            return new Color(r, g, b, 0d);
        }

        private static double ComputeLambertShading(SceneObject sceneObject, Vect intersectionPoint, Ray lightRay)
        {
            var winningObjectNormal = sceneObject.GetNormalAt(intersectionPoint);
            var angleBetweenNormalAndLightDirection =
                winningObjectNormal.DotProduct(lightRay.Direction);

            if (angleBetweenNormalAndLightDirection < 0)
            {
                angleBetweenNormalAndLightDirection = 0;
            }

            //Lambert shading
            return AmbientCoefficient +
                   DiffuseCoefficient*angleBetweenNormalAndLightDirection;
        }

        private static bool LightRayIntersectsObject(List<SceneObject> sceneObjects, int indexOfWinningObject, Ray lightRay)
        {
            bool isInShadow = false;
            for (int i = 0; i < sceneObjects.Count; i++)
            {
                if (i == indexOfWinningObject) continue;
                if ((!(sceneObjects[i].FindIntersection(lightRay) > 0))) continue;
                isInShadow = true;
                break;
            }
            return isInShadow;
        }

        private static Ray ComputeLightRayFromPoint(Vect intersectionPoint, Light light)
        {
            var diffBtwIntersectionAndLightPos = new Vect(intersectionPoint.X - light.Position.X,
                                                          intersectionPoint.Y - light.Position.Y,
                                                          intersectionPoint.Z - light.Position.Z);
            var lightDirectionFromIntersectionPoint = diffBtwIntersectionAndLightPos.Negative().Normalize();
            var lightRay = new Ray(intersectionPoint, lightDirectionFromIntersectionPoint);
            return lightRay;
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
            var camPos = new Vect(5d, 2.25d, -1d);
            var lookAt = new Vect(0, 0, 0);
            var diffBtw = new Vect(camPos.X - lookAt.X, camPos.Y - lookAt.Y, camPos.Z - lookAt.Z);
            var camDir = diffBtw.Negative().Normalize();
            var camRight = _y.CrossProduct(camDir).Normalize();
            var camDown = camRight.CrossProduct(camDir);

            return new Camera(camPos, camDir, camRight, camDown);
        }
    }
}
