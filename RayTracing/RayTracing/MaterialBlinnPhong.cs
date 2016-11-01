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
            Vector3 l = -RenderContext.Light.GetDir(intersect.position);
            Vector3 h = (v + l).Nor();
            Vector3 n = intersect.normal;

            Vector3 Kd = mainColor * RenderContext.Light.atten * Math.Max(0, n.Dot(l)) * RenderContext.Light.color;

            float ndh = Math.Max(0, n.Dot(h));
            Vector3 Ks = RenderContext.Light.color * (float) Math.Pow((double)ndh, glossy);

            return Util.VecToColor(RenderContext.AmbientLight+ Kd + Ks);
        }
    }
}
