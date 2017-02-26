using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;
namespace RayTracing.Geom
{
    public class BoundingBox
    {
        Vector3 PL { get; set; }
        Vector3 PH { get; set; }

        public BoundingBox(Vector3 pl,Vector3 ph)
        {
            this.PL = pl;
            this.PH = ph;
        }

        public bool Hit(Ray ray)
        {
            float tx = 1.0f / ray.dir.x;
            float ty = 1.0f / ray.dir.y;
            float tz = 1.0f / ray.dir.z;

            float txmax, txmin;
            float tymax, tymin;
            float tzmax, tzmin;

            if(tx>=0)
            {
                txmin = (PL.x - ray.origin.x) * tx;
                txmax = (PH.x - ray.origin.x) * tx;
            }
            else
            {
                txmax = (PL.x - ray.origin.x) * tx;
                txmin = (PH.x - ray.origin.x) * tx;
            }
            if (ty >= 0)
            {
                tymin = (PL.y - ray.origin.y) * ty;
                tymax = (PH.y - ray.origin.y) * ty;
            }
            else
            {
                tymax = (PL.y - ray.origin.y) * ty;
                tymin = (PH.y - ray.origin.y) * ty;
            }
            if (tz >= 0)
            {
                tzmin = (PL.z - ray.origin.z) * tz;
                tzmax = (PH.z - ray.origin.z) * tz;
            }
            else
            {
                tzmax = (PL.z - ray.origin.z) * tz;
                tzmin = (PH.z - ray.origin.z) * tz;
            }
            float t0, t1;
            t0 = txmin < tymin ? tymin : txmin;
            t0 = t0 < tzmin ? tzmin : t0;

            t1 = txmax < tymax ? txmax : tymax;
            t1 = t1 < tzmax ? t1 : tzmax;

            return (t0 < t1 && t1 > TracerConst.kEpsilon);
        }
    }
}
