using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

using RayTracing.Geom;
using RayTracing.Material;
namespace RayTracing.Light
{
    public class AreaLight :LightBase
    {
        private AreaLigtingGeom m_geom;
        private MaterialBase m_material;
        private Vector3 m_lightNormal;
        private Vector3 m_wi;
        private Vector3 m_samplePoint;

        public AreaLigtingGeom GEOMETRY
        {
            get
            {
                return m_geom;
            }
            set
            {
                m_geom = value;
                m_geom.SHADOW_BLOCK = false;
            }
        }
        public MaterialBase MATERIAL
        {
            get { return m_material; }
            set { m_material = value; }
        }

        public AreaLight()
        {

        }


        public override Vector3 GetDirection(ShadeRec sr)
        {
            m_samplePoint = m_geom.Sample();
            m_lightNormal = m_geom.GetNormal(m_samplePoint).Nor();
            m_wi = m_samplePoint - sr.localHitPoint;
            m_wi.Nor();
            return m_wi;
        }
        public override bool ShadowCheck(Ray shadowRay, ShadeRec sr)
        {
            return base.ShadowCheck(shadowRay, sr);
        }

        public override Vector3 L(ShadeRec sr)
        {
            float nDotD = (-m_lightNormal).Dot(m_wi);
            if (nDotD > 0f)
                return m_material.Shade(sr);
            else
                return ColourF.Black;
        }

        public override float G(ShadeRec sr)
        {
            float nDotD = (-m_lightNormal).Dot(m_wi);
            float d2 = (m_samplePoint - sr.localHitPoint).sqrLeng();
            return nDotD / d2;
        }

        public override float PDF(ShadeRec sr)
        {
            return m_geom.PDF(sr);
        }
    }
}
