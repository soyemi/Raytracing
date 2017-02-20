using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing;
using RayTracing.Utility;
namespace RayTracing.Tracers
{
    public class TracerNormal :Tracer
    {
        public TracerNormal(RenderContext context):base(context)
        {

        }

        public override Vector3 TraceRay(Ray ray)
        {
            ShadeRec sr = m_context.HitObjects(ray);

            if (sr.isHitObj)
            {
                Vector3 normal = sr.normal.Nor();
                return 0.5f * (normal + Vector3.One);
            }
            else
            {
                return ColourF.Black;
            }
        }
    }
}
