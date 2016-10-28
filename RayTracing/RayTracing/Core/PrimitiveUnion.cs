using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class PrimitiveUnion
    {
        public List<Primitive> primitives;


        private const float maxDist = 100000000;

        public PrimitiveUnion(List<Primitive> objs)
        {
            primitives = objs;
        }

        public IntertsectResult Intertsect(Ray ray)
        {
            float minDist = maxDist;
            IntertsectResult finalResult = new IntertsectResult();

            for(int i=0;i<primitives.Count;i++)
            {
                IntertsectResult result = primitives[i].Intersect(ray);
                if(result.primitive != null && result.distance< minDist)
                {
                    minDist = result.distance;
                    finalResult = result;
                }
            }
            return finalResult;
        }
    }
}
