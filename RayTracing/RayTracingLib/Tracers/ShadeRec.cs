using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Utility;
namespace RayTracing.Tracers
{
    public class ShadeRec
    {
        public Vector3 normal;
        public Vector3 localHitPoint;
        public bool isHitObj = false;
        public MaterialBase hitMaterial;
        public Ray ray;
        public float rayT;

        public RenderContext context;

        public ShadeRec(RenderContext ctx)
        {
            context = ctx;
        }

        
    }
}
