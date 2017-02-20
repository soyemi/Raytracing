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
            float t = (point - ray.origin).Dot(normal) / (ray.dir.Dot(normal));
            if(t > TracerConst.kEpsilon)
            {
                s.rayT = t;
                s.normal = normal;
                s.localHitPoint = ray.Pos(t);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
