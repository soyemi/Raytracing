using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Material
{
    public class MatAmbientOccluder : MaterialBase
    {
        public override Vector3 Shade(ShadeRec sr)
        {
            return sr.context.ambientLight.L(sr);
        }
    }
}
