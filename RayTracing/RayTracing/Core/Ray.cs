using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracing
{
    public class Ray
    {
        public Vector3 origin;
        public Vector3 dir;

        public Ray(Vector3 origin,Vector3 dir)
        {
            this.origin = origin;
            this.dir = dir.Nor();
        }

        public Vector3 Pos(float dist)
        {
            return this.origin + dist * dir;
        }
    }
}
