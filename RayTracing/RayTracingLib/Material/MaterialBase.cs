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
        public virtual Vector3 ShadeAreaLight(ShadeRec sr)
        {
            return Shade(sr);
        }

        public virtual Vector3 GetColorMain()
        {
            return ColourF.Error;
        }
    }
}
