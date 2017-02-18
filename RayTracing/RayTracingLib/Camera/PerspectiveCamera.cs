using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Camera
{
    class PerspectiveCamera :CameraBase
    {

        private float m_fov = 60f;
        private float d;

        private float aspect;

        public PerspectiveCamera(Vector3 pos, Vector3 forward,Vector3 up,float aspectRatio):base(pos,forward,up)
        {
            aspect = aspectRatio;
            
        }


        public override Ray CaculateRay(float x, float y)
        {
            Vector3 dir = Right * x /100f + Up * y /100f + Forward;
            dir = dir.Nor();
            Ray ray = new Ray(Position, dir);
            return ray;
        }
    }
}
