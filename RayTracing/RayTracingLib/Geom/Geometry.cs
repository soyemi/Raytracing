using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;

namespace RayTracing.Geom
{
    public abstract class Geometry
    {

        public string tag = null;

        public abstract bool Hit(Ray ray,ref ShadeRec s);

        public abstract bool ShadowHit(Ray shadowRay, ref float t);

        public MaterialBase material
        { get; protected set; }

        public void SetMaterial(MaterialBase mat)
        {
            material = mat;
        }

    }
}
