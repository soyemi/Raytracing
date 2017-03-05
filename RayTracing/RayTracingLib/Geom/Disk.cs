using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public class Disk : AreaLigtingGeom
    {
        public Vector3 CENTER { get; set; }
        public Vector3 NORMAL { get; set; }
        public float RADIUS { get; set; }

        public bool TWO_SIZE { get; set; }

        public Disk(Vector3 center,Vector3 normal,float radius,bool twoside = true)
        {
            CENTER = center;
            NORMAL = normal.Nor();
            RADIUS = radius;
            TWO_SIZE = twoside;

            m_tempPoint = center;
            m_area = radius * radius * TracerConst.PI;
            m_pdf = 1.0f / m_area;

            m_vecx = NORMAL.Cross(Vector3.UpJitted);
            m_vecy = m_vecx.Cross(NORMAL);
        }

        public override bool Hit(Ray ray, ref ShadeRec s)
        {
            float d = ray.dir.Dot(NORMAL);
            float t = (CENTER - ray.origin).Dot(NORMAL) / d;
            if (t < TracerConst.kEpsilon)
                return false;

            Vector3 p = ray.Pos(t);
            if ((CENTER - p).sqrLeng() < RADIUS * RADIUS)
            {
                s.rayT = t;
                s.normal = TWO_SIZE? (d <0? NORMAL:-NORMAL) : NORMAL;
                s.localHitPoint = p;
                return true;
            }
            else
                return false;
        }

        public override bool ShadowHit(Ray ray, ref float t)
        {
            if (!SHADOW_BLOCK) return false;

            float tr = (CENTER - ray.origin).Dot(NORMAL) / ray.dir.Dot(NORMAL);
            if (tr < TracerConst.kEpsilon)
                return false;

            Vector3 p = ray.Pos(tr);
            if ((CENTER - p).sqrLeng() < RADIUS * RADIUS)
            {
                t = tr;
                return true;
            }
            else
                return false;
        }

        #region AreaLighting
        public override Vector3 GetNormal(Vector3 p)
        {
            return NORMAL;
        }

        public override float PDF(ShadeRec sr)
        {
            return m_pdf;
        }

        public override Vector3 Sample()
        {
            Vector3 sp = m_sampler.SampleUnitSquare();
            return sp.x* m_vecx + sp.y*m_vecy + m_tempPoint;
        }
        #endregion;
    }
}
