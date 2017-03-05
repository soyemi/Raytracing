using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;
using RayTracing.Utility;
namespace RayTracing.Material
{
    public class MaterialEmissive : MaterialBase
    {
        private float m_ls;
        private Vector3 m_ce;

        private Vector3 m_fcolor;

        public MaterialEmissive(Vector3 Ce, float Ls = 1.0f)
        {
            m_ls = Ls;
            m_ce = Ce;

            m_fcolor = m_ls * m_ce;
        }


        public override Vector3 Shade(ShadeRec sr)
        {
            return m_fcolor;
        }

        public override Vector3 ShadeAreaLight(ShadeRec sr)
        {
            return m_ce* m_ls;
            //if (sr.normal.Nor().Dot(sr.ray.dir.Nor()) < 0f)
            //    return m_fcolor;
            //else
            //    return ColourF.Black;
        }

        public override Vector3 GetColorMain()
        {
            return m_ce;
        }

    }
}
