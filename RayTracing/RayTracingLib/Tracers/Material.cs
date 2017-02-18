using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Tracers
{
    public class Material
    {
        public Vector3 color = new Vector3(1.0f, 0, 0);

        public Material()
        {

        }
        public Material(Vector3 color)
        {
            this.color = color;
        }

        public Vector3 Shade(ShadeRec fragment)
        {
            return color;
        }
    }
}
