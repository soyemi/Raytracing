using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RayTracing
{
    public class IntertsectResult
    {
        public Primitive primitive;
        public Vector3 position;
        public Vector3 normal;
        public float distance;

        public IntertsectResult()
        {
            this.primitive = null;
            this.distance = 0;
            this.position = Vector3.Zero;
            this.normal = Vector3.Zero;
        }

        public IntertsectResult(Primitive primitive, Vector3 pos,Vector3 nor,float dist)
        {
            this.primitive = primitive;
            this.position = pos;
            this.normal = nor;
            this.distance = dist;
        }
    }
}
