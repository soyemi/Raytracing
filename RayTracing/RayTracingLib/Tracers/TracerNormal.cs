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
            return base.TraceRay(ray);
        }
    }
}
