using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public abstract class Geometry
    {
        public abstract bool Hit(Ray ray,ref ShadeRec s);

        public Material material
        { get; protected set; }

        public void SetMaterial(Material mat)
        {
            material = mat;
        }
    }
}
