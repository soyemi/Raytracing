using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public class Plane : Geometry
    {
        public Vector3 normal { get; private set; }
        public Vector3 point { get; private set; }

        public Plane(Vector3 p, Vector3 n)
        {
            point = p;
            normal = n.Nor();
        }

        public override bool Hit(Ray ray,ref ShadeRec s)
        {
            float ddotn = ray.dir.Dot(normal);
            if (Math.Abs(ddotn) < TracerConst.kEpsilon) return false;
            float p = (point - ray.origin).Dot(normal);
            float t = p / ddotn;
            if(t> 0)
            {
                s.normal = normal;
                s.rayT = t;
                s.localHitPoint = ray.Pos(t);
                return true;
            }
            return false;
        }

        public override bool ShadowHit(Ray shadowRay, ref float t)
        {
            float ddotn = shadowRay.dir.Dot(normal);
            if (Math.Abs(ddotn) < TracerConst.kEpsilon) return false;
            float p = (point - shadowRay.origin).Dot(normal);
            float t1 = p / ddotn;
            if (t1 > TracerConst.kEpsilon)
            {
                t = t1;
                return true;
            }
            return false;
        }
    }
}
