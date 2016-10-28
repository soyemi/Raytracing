using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracing
{
    public class Camera
    {

        public Vector3 pos;
        public Vector3 up;
        public Vector3 right;
        public int FOV;
        public float FOVscale;

        private Vector3 forwardCenter;
        private Vector3 realRight;

        public Camera(Vector3 pos,Vector3 up,Vector3 right,int fov)
        {
            this.pos = pos;
            this.up = up;
            this.right = right;
            this.FOV = fov;

            forwardCenter = up.Cross(right);
            realRight = forwardCenter.Cross(up);

            this.FOVscale = (float)Math.Tan(fov * Math.PI * 0.5 / 180) * 2;
        }

        public Ray GenerateRay(float x,float y)
        {
            Vector3 r = realRight * ((float)(x - 0.5) * FOVscale);
            Vector3 u = up * ((float)(y - 0.5) * FOVscale);
            return new Ray(pos, (forwardCenter + r + u).Nor());
        }
    }
}
