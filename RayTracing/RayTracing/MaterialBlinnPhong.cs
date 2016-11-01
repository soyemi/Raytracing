using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class MaterialBlinnPhong : Material
    {
        public double glossy = 10d;
        public MaterialBlinnPhong(Color color,float glossy) :base(color)
        {
            this.glossy = glossy;
        }

        public override Color CaculateColor(IntersectResult intersect)
        {
            Vector3 v = RenderContext.ViewPoint - intersect.position;
            Vector3 l = -RenderContext.Light.lightDirection;
            Vector3 h = (v + l).Nor();
            Vector3 n = intersect.normal;

            Vector3 Kd = mainColor * RenderContext.Light.lightAtten * Math.Max(0, n.Dot(l)) * RenderContext.Light.lightColor;

            float ndh = Math.Max(0, n.Dot(h));
            Vector3 Ks = RenderContext.Light.lightColor *(float) Math.Pow((double)ndh, glossy);

            return Util.VecToColor(RenderContext.AmbientLight+ Kd + Ks);
        }
    }
}
