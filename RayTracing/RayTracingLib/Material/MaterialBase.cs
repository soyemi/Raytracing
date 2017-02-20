using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;

namespace RayTracing
{
    public abstract class MaterialBase
    {

        public abstract Vector3 Shade(ShadeRec sr);
    }
}
