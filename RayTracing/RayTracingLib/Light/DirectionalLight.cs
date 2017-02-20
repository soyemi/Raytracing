using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

namespace RayTracing.Light
{
    class DirectionalLight :LightBase
    {
        public float ls = 1.0f;
        public Vector3 color = ColourF.White;
        public Vector3 dir;

        public DirectionalLight(Vector3 dir, Vector3 color, float attune =1.0f)
        {
            this.dir = dir.Nor();
            this.ls = attune;
            this.color = color;
        }

        public override Vector3 GetDirection(ShadeRec sr)
        {
            return dir;
        }
        public override Vector3 L(ShadeRec sr)
        {
            return ls * color;
        }
    }
}
