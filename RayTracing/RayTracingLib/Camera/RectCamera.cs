using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Camera
{
    public class RectCamera :CameraBase
    {
        public float PixelPerUnit;
        public RectCamera(float ppu)
        {
            PixelPerUnit = ppu;
        }

        public override Ray CaculateRay(float x,float y)
        {
            Vector3 p = new Vector3(x, y,0);
            p /= PixelPerUnit;
            Ray ray = new Ray(p, Vector3.Forward);
            return ray;
        }
    }
}
