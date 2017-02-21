using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;
using RayTracing.Utility;
namespace RayTracing.Camera
{
    class PerspectiveCamera :CameraBase
    {
        private float fov;
        private float fovR;
        public PerspectiveCamera(Vector3 pos, Vector3 forward,Vector3 up,ViewPlane plane,float fov = 60f):base(pos,forward,up,plane)
        {
            
            this.fov = fov;
            fovR =(float) Math.Tan(fov / 360f * TracerConst.PI) *2f;

            Console.WriteLine(forward);
        }


        public override Ray CaculateRay(float x, float y,ViewPlane plane)
        {
            Vector3 dir =(AspectRatio * Right * x / plane.Width + Up * y / plane.Height) + Forward;
            Ray ray = new Ray(Position, dir);
            return ray;
        }
    }
}
