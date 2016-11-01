using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public abstract class LightBase
    {
        public LightBase(Vector3 color,float atten)
        {
            this.atten = atten;
            this.color = color;
        }
        public float atten;
        public Vector3 color;

        public abstract Vector3 GetDir(Vector3 point);
    }
}
