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
        public Vector3 debugColor;
        public bool castShadow = false;
        public void SetMaterial(Material mat)
        {
            material = mat;

            debugColor = new Vector3(Util.random, Util.random, Util.random);
        }
        abstract public IntersectResult Intersect(Ray ray);

    }
}
