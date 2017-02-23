using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;
namespace RayTracing.Light
{
    public class PointLight : LightBase
    {
        private Vector3 m_pos;
        private Vector3 m_color;
        private float m_atten;
        private float m_range;
        public Vector3 POS
        {
            get { return m_pos; }
        }
        public PointLight(Vector3 pos,Vector3 color,float atten,float range = 1.0f)
        {
            m_pos = pos;
            m_color = color;
            m_atten = atten;
            m_range = range;
        }

        public override Vector3 GetDirection(ShadeRec sr)
        {
            return (m_pos - sr.localHitPoint).Nor();
        }

        public override Vector3 L(ShadeRec sr)
        {
            //falloff
            float falloff = (m_pos - sr.localHitPoint).length;
            falloff = falloff > m_range ? m_range : falloff;
            falloff = falloff / m_range;

            float t = 1f - falloff * falloff;

            return m_atten * m_color;
        }
    }
}
