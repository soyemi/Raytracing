using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;
using RayTracing.BRDFs;

namespace RayTracing.Material
{
    class MatPhong :MaterialBase
    {
        public MatPhong(float ka,float kd,float ks,Vector3 ca,Vector3 cd,Vector3 cs,float exp = 1.0f)
        {
            m_specularBRDF = new BRDFGlossySpecular(ks, cs, exp);
            m_diffuseBRDF = new BRDFlambertain(kd, cd);
            m_ambientBRDF = new BRDFlambertain(ka, ca);
        }

        protected BRDFGlossySpecular m_specularBRDF;
        protected BRDFlambertain m_ambientBRDF;
        protected BRDFlambertain m_diffuseBRDF;

        public override Vector3 Shade(ShadeRec sr)
        {
            Vector3 wo = -sr.ray.dir;
            Vector3 L = m_ambientBRDF.rho(sr, wo) * sr.context.ambientLight.L(sr);

            int lc = sr.context.lights.Count;
            for(int i=0;i<lc;i++)
            {
                var light = sr.context.lights[i];
                Vector3 wi = light.GetDirection(sr);
                float ndotwi = sr.normal.Dot(wi);
                if(ndotwi > 0)
                {
                    bool inshadow = false;
                    if(light.CAST_SHADOW)
                    {
                        Ray shadowRay = new Ray(sr.localHitPoint + sr.normal * TracerConst.kEpsilon, wi);
                        inshadow = light.ShadowCheck(shadowRay, sr);
                    }
                    if(!inshadow)
                        L += (m_diffuseBRDF.F(sr, wo, wi) + m_specularBRDF.F(sr, wo, wi))* light.L(sr) * ndotwi;
                }
            }

            return L;
        }
    }
}
