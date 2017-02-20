using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Material
{
    class MatColor :MaterialBase
    {
        private Vector3 mColor;
        public MatColor(Vector3 color)
        {
            mColor = color;
        }

        public override Vector3 Shade(ShadeRec sr)
        {
            return mColor;
        }
    }
}
