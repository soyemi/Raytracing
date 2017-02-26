using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public sealed class AxisAlignedBox : Geometry
    {
        public Vector3 CENTER { get; set; }
        public Vector3 SIZE { get; set; }

        public AxisAlignedBox(Vector3 center,Vector3 size)
        {
            CENTER = center;
            SIZE = size;
        }

        public override bool Hit(Ray ray, ref ShadeRec s)
        {
            Vector3 PL = CENTER - SIZE * 0.5f;
            Vector3 PH = CENTER + SIZE;

            float tx = 1.0f / ray.dir.x;
            float ty = 1.0f / ray.dir.y;
            float tz = 1.0f / ray.dir.z;

            float txmax, txmin;
            float tymax, tymin;
            float tzmax, tzmin;

            if (tx >= 0)
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

            int faceIn = 0;
            int faceOut = 0;
            float t0, t1;
            t0 = txmin < tymin ? tymin : txmin;
            t0 = t0 < tzmin ? tzmin : t0;

            t1 = txmax < tymax ? txmax : tymax;
            t1 = t1 < tzmax ? t1 : tzmax;

            if(txmin < tymin)
            {
                t0 = tymin;
                faceIn = ty >= 0 ? 1 : 4;
            }
            else
            {
                t0 = txmin;
                faceIn = tx >= 0 ? 0 : 3;
            }

            if(t0 < tzmin)
            {
                t0 = tzmin;
                faceIn = tz >= 0 ? 2 : 5;
            }

            if(txmax<tymax)
            {
                t1 = txmax;
                faceOut = tx >= 0 ? 3 : 0;
            }
            else
            {
                t1 = tymax;
                faceOut = ty >= 0 ? 4 : 1;
            }
            if(t1 > tzmax)
            {
                t1 = tzmax;
                faceOut = tz >= 0 ? 5 : 2;
            }


            if(t0 < t1 && t1 > TracerConst.kEpsilon)
            {
                s.ray = ray;
                
                if(t0 > TracerConst.kEpsilon)
                {
                    s.rayT = t0;
                    s.normal = GetNormal(faceIn);
                }
                else
                {
                    s.rayT = t1;
                    s.normal = GetNormal(faceOut);
                }
                s.localHitPoint = ray.Pos(s.rayT);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool ShadowHit(Ray ray, ref float t)
        {
            Vector3 PL = CENTER - SIZE * 0.5f;
            Vector3 PH = CENTER + SIZE;

            float tx = 1.0f / ray.dir.x;
            float ty = 1.0f / ray.dir.y;
            float tz = 1.0f / ray.dir.z;

            float txmax, txmin;
            float tymax, tymin;
            float tzmax, tzmin;

            if (tx >= 0)
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

            if (t0 < t1 && t1 > TracerConst.kEpsilon)
            {
                t = t0;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Vector3 GetNormal(int face)
        {
            switch(face)
            {
                case 0: return Vector3.Ctor(-1f, 0, 0);
                case 1: return Vector3.Ctor(0, -1f, 0);
                case 2: return Vector3.Ctor(0, 0, -1f);
                case 3: return Vector3.Ctor(1f, 0, 0);
                case 4: return Vector3.Ctor(0f, 1f, 0);
                case 5: return Vector3.Ctor(0f, 0, 1f);
            }
            return Vector3.Zero;
        }
    }
}
