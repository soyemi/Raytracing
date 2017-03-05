using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Utility;

namespace RayTracing.Tracers
{
    public class TracerAreaLigting : Tracer
    {
        public TracerAreaLigting(RenderContext context) : base(context)
        {

        }
        public override Vector3 TraceRay(Ray ray)
        {
            ShadeRec sr = m_context.HitObjects(ray);
            if(sr.isHitObj)
            {
                return sr.hitMaterial.ShadeAreaLight(sr);
            }
            else
            {
                return ColourF.Black;
            }
        }
    }
}
