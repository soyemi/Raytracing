using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracer;

namespace RayTracing.Geom
{
    abstract class Geometry
    {
        public abstract bool Hit(Ray ray,ref float tmin, ShadeRec s);

        public Material material
        { get; protected set; }

        public void SetMaterial(Material mat)
        {
            material = mat;
        }
    }
}
