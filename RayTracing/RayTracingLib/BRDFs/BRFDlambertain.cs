using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.BRDFs
{
    public class BRFDlambertain :BRDF
    {
        /// <summary>
        /// Radiance Coefficient
        /// </summary>
        public float Kd;
        /// <summary>
        /// Diffuse Color
        /// </summary>
        public Vector3 Cd;

        public BRFDlambertain(float Kd,Vector3 Cd)
        {
            this.Kd = Kd;
            this.Cd = Cd;

        }

        public override Vector3 F(ShadeRec sr, Vector3 wo, Vector3 wi)
        {
            return Kd * Cd * TracerConst.INV_PI;
        }

        public override Vector3 rho(ShadeRec sr, Vector3 wo)
        {
            return Kd * Cd;
        }

    }
}
