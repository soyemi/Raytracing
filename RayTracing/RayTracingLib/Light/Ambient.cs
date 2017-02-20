using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Light
{
    public class Ambient :LightBase
    {
        public float ls = 1.0f;
        public Vector3 color = ColourF.White;

        public Ambient(float ls,Vector3 color)
        {
            this.ls = ls;
            this.color = color;
        }

        public override Vector3 L(ShadeRec sr)
        {
            return ls * color;
        }
    }
}
