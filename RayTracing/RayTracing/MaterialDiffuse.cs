using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class MaterialDiffuse : Material
    {
        public Vector3 color;
        public MaterialDiffuse(Color color)
        {
            this.color = new Vector3(color.R * 1.0f / 256f, color.B * 1.0f / 256f, color.G * 1.0f / 256f);
        }

        public override Color CaculateColor(IntertsectResult intersect)
        {
            Vector3 ldir = -RenderContext.Light.lightDirection;
            float dot = ldir.Dot(intersect.normal);
            Vector3 colv3 = color * dot * RenderContext.Light.lightAtten * RenderContext.Light.lightColor;
            colv3 += RenderContext.AmbientLight;
            return Util.VecToColor(colv3);
        }
    }
}
