using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;


using RayTracing.BRDFs;
using RayTracing;
namespace RayTracing.Material
{
    class MatMatte :MaterialBase
    {

        BRDFlambertain ambientBRDF;
        BRDFlambertain diffuseBRDF;

        public MatMatte(Vector3 Ca,Vector3 Cd, float Ka = 0.25f, float Kd = 0.75f)
        {
            ambientBRDF = new BRDFlambertain(Ka,Ca);
            diffuseBRDF = new BRDFlambertain(Kd,Cd);
        }

        public override Vector3 Shade(ShadeRec sr)
        {
            Vector3 wo = -sr.ray.dir;
            Vector3 L = ambientBRDF.rho(sr, wo) * sr.context.ambientLight.L(sr);
            int lightCount = sr.context.lights.Count;
            for (int j = 0; j < lightCount; j++)
            {
                var light = sr.context.lights[j];
                Vector3 wi = light.GetDirection(sr);
                float nDotWi = sr.normal.Nor().Dot(wi.Nor());
                if (nDotWi > 0)
                {
                    bool inshadow = false;
                    if(light.CAST_SHADOW)
                    {
                        Ray shadowRay = new Ray(sr.localHitPoint + sr.normal * TracerConst.kEpsilon, wi);
                        inshadow = light.ShadowCheck(shadowRay, sr);
                    }
                    if(!inshadow)
                        L += light.L(sr) * nDotWi * diffuseBRDF.F(sr, wo, wi);
                }
            }

            return L;
        }
    }
}
