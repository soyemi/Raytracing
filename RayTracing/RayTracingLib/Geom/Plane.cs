using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracer;

namespace RayTracing.Geom
{
    class Plane : Geometry
    {
        public Vector3 normal { get; private set; }
        public Vector3 point { get; private set; }

        public Plane(Vector3 p, Vector3 n)
        {
            point = p;
            normal = n;
        }

        public override bool Hit(Ray ray,ref float tmin, ShadeRec s)
        {
            float t = (point - ray.origin).Dot(normal) / (ray.dir.Dot(normal));
            if(t > TracerConst.kEpsilon)
            {
            }
            return false;
        }
    }
}
