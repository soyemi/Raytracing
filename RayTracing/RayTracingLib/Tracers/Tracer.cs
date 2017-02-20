using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Utility;
namespace RayTracing.Tracers
{
    public class Tracer
    {

        private RenderContext m_context;

        public Tracer(RenderContext context)
        {
            m_context = context;
        }

        public virtual Vector3 TraceRay(Ray ray)
        {
            ShadeRec sr = m_context.HitObjects(ray);

            if(sr.isHitObj)
            {
                return sr.hitMaterial.Shade(sr);
            }
            else
            {
                return ColourF.Black;
            }
        }
    }
}
