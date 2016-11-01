using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class PointLight : LightBase
    {
        public Vector3 pos;
        public PointLight(Vector3 pos,Vector3 color,float atten):base(color,atten)
        {
            this.pos = pos;
        }

        public override Vector3 GetDir(Vector3 point)
        {
            return (point - pos).Nor();
        }
    }
}
