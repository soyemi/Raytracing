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
        public Color color;
        public MaterialColor(Color c)
        {
            color = c;
        }

        public override Color CaculateColor()
        {
            return color;
        }

    }
}
