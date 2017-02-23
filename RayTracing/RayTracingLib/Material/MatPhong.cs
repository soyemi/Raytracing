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

        protected BRDFGlossySpecular m_specularBRDF;
        protected BRDFlambertain m_ambientBRDF;
        protected BRDFlambertain m_diffuseBRDF;

        public override Vector3 Shade(ShadeRec sr)
        {
            return Vector3.Zero;
        }
    }
}
