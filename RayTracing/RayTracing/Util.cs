using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace RayTracing
{
    public static class Util
    {
        public static Vector3 ColorToVec(Color color)
        {
            return new Vector3(color.R * 1.0f / 256f, color.B * 1.0f / 256f, color.G * 1.0f / 256f);
        }

        public static Color VecToColor(Vector3 vec)
        {
            int r = ClampInt(vec.x * 256f, 0, 255);
            int g = ClampInt(vec.y * 256f, 0, 255);
            int b = ClampInt(vec.z * 256f, 0, 255);
            return  Color.FromArgb(r, g, b);
        }


        public static int ClampInt(float v,int min,int max)
        {
            int vi = (int)v;
            if (vi > max) return max;
            if (vi < min) return min;
            return vi;

        }

    }
}
