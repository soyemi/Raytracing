using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.BRDFs
{
    class BRDFGlossySpecular :BRDF
    {
        private float m_ks;
        private float m_exp;
        private Vector3 m_color;
        public BRDFGlossySpecular(float ks,Vector3 color,float exp = 1.0f)
        {
            m_ks = ks;
            m_color = color;
            m_exp = exp;
        }

        public override Vector3 F(ShadeRec sr, Vector3 wo, Vector3 wi)
        {
            Vector3 L = ColourF.Black;
            float ndotwi = sr.normal.Dot(wi);
            Vector3 r = 2 * ndotwi * sr.normal - wi;
            float rdotwo = r.Dot(wo);

            if (rdotwo > 0.0f)
                L =  m_color *(float) Math.Pow(rdotwo, m_exp) * m_ks;

            return L;
        }
    }
}
