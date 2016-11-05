using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Plane : Primitive
    {
        public Vector3 dir;
        public Vector3 point;

        public Plane(Vector3 dir,Vector3 point)
        {
            this.dir = dir.Nor();
            this.point = point;
            castShadow = false;
        }

        public override IntersectResult Intersect(Ray ray)
        {
            Vector3 pvec = point - ray.origin;
            float d = pvec.Dot(-dir);
            if (d < 0) return new IntersectResult();
            float cosa = ray.dir.Dot(-dir);
            if (cosa < float.Epsilon) return new IntersectResult();
            float dist = d / cosa;

            return new IntersectResult(this, ray.Pos(dist), dir, dist);
        }
    }
}
