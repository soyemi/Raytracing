using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class MaterialColor:Material
    {
        public MaterialColor(Color c):base(c)
        {
        }

        public override Vector3 CaculateColor(IntersectResult intersect)
        {
            return mainColor;
        }

    }
}
