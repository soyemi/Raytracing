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

        BRFDlambertain ambientBRDF;
        BRFDlambertain diffuseBRDF;

        public MatMatte(Vector3 Ca,Vector3 Cd, float Ka = 0.25f, float Kd = 0.75f)
        {
            ambientBRDF = new BRFDlambertain(Ka,Ca);
            diffuseBRDF = new BRFDlambertain(Kd,Cd);
        }

        public override Vector3 Shade(ShadeRec sr)
        {
            Vector3 wo = -sr.ray.dir;
            Vector3 L =Vector3.Zero;// ambientBRDF.rho(sr, wo) * sr.context.ambientLight.L(sr);
            int lightCount = sr.context.lights.Count;
            for(int j=0;j<lightCount;j++)
            {
                Vector3 wi = sr.context.lights[j].GetDirection(sr);
                float nDotWi = sr.normal.Dot(wi);

                L = sr.normal;
                //if (nDotWi > 0)
                //L += diffuseBRDF.F(sr, wo, wi) * sr.context.lights[j].L(sr) * nDotWi;
            }

            return L;
        }
    }
}
