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

            m_bbox = new BoundingBox(center - Vector3.One*radius,center+ Vector3.One*radius);
        }


        public override bool Hit(Ray ray,ref ShadeRec sr)
        {
            if (!m_bbox.Hit(ray)) return false;

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
                    sr.localHitPoint = ray.Pos(t1);
                    sr.normal = (sr.localHitPoint - Center).Nor();

                    return true;
                }
                t1 = (e - b) / a * 0.5f;
                if(t1 > TracerConst.kEpsilon)
                {
                    sr.rayT = t1;
                    sr.localHitPoint = ray.Pos(t1);
                    sr.normal = (sr.localHitPoint - Center).Nor();

                    return true;
                }

                return false;
            }
        }

        public override bool ShadowHit(Ray shadowRay, ref float t)
        {
            if (!m_bbox.Hit(shadowRay)) return false;

            Vector3 s = shadowRay.origin - Center;
            float a = shadowRay.dir.sqrLeng();
            float b = 2 * s.Dot(shadowRay.dir);
            float c = s.sqrLeng() - Radius * Radius;

            float delta = b * b - 4 * a * c;

            if (delta <= 0)
            {
                return false;
            }
            else
            {
                float e = (float)Math.Sqrt(delta);
                float t1 = -(b + e) / a * 0.5f;

                if (t1 > TracerConst.kEpsilon)
                {
                    t = t1;
                    return true;
                }
                t1 = (e - b) / a * 0.5f;
                if (t1 > TracerConst.kEpsilon)
                {
                    t = t1;
                    return true;
                }

                return false;
            }
        }
    }
}
