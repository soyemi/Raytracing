using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracing
{
    public abstract class Material
    {
        public Vector3 mainColor;
        public Material(Color color)
        {
            mainColor = Util.ColorToVec(color);
        }
        public abstract Color CaculateColor(IntersectResult intersect);
    }
}
