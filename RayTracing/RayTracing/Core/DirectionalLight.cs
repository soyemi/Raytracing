using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracing
{
    public class DirectionalLight : LightBase
    {
        public Vector3 lightDirection;
        public DirectionalLight(Vector3 dir,Vector3 color,float atten) :base(color,atten)
        {
            this.lightDirection = dir.Nor();
        }

        public override Vector3 GetDir(Vector3 point)
        {
            return lightDirection;
        }
    }
}
