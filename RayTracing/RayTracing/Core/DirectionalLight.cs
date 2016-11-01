using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracing
{
    public class DirectionalLight
    {
        public Vector3 lightColor;
        public Vector3 lightDirection;
        public float lightAtten = 1f;
        public DirectionalLight(Vector3 dir,Color color,float atten)
        {
            this.lightColor = Util.ColorToVec(color);
            this.lightDirection = dir.Nor();
            this.lightAtten = atten;
        }
    }
}
