using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public class Sphere :Geometry
    {
        public Vector3 Center { get; set; }
        public float Radius { get; set; }

        public Sphere(Vector3 center,float radius)
        {
            this.Center = center;
            this.Radius = radius;

        }


        public override bool Hit(Ray ray,ref ShadeRec sr)
        {
            Vector3 s = ray.origin - Center;
            float a = ray.dir.sqrLeng();
            float b = 2 * s.Dot(ray.dir);
            float c = s.sqrLeng() - Radius * Radius;

            float delta = b * b - 4 * a * c;

            if(delta <= 0)
            {
                return false;
            }
            else
            {
                float e = (float)Math.Sqrt(delta);
                float t1 = -(b + e) / a * 0.5f;

                if(t1 > TracerConst.kEpsilon)
                {
                    sr.rayT = t1;
                    return true;
                }
                t1 = (e - b) / a * 0.5f;
                if(t1 > TracerConst.kEpsilon)
                {
                    sr.rayT = t1;
                    return true;
                }

                return false;
            }
        }
    }
}
