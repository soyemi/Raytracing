using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing;
using RayTracing.Tracers;
namespace RayTracing.Light
{
    public class LightBase
    {

        public virtual Vector3 GetDirection(ShadeRec sr)
        {
            return Vector3.Zero;
        }

        public virtual Vector3 L(ShadeRec sr)
        {
            return ColourF.Black;
        }
    }
}
