using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public abstract class Primitive
    {
        public Material material;
        public void SetMaterial(Material mat)
        {
            material = mat;
        }
        abstract public IntersectResult Intersect(Ray ray);

    }
}
