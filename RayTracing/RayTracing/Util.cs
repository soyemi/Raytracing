﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace RayTracing
{
    public static class Util
    {
        private static Random m_random = new Random();

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

        public static float Clamp(float v,float min,float max)
        {
            if(v> max) return max;
            if (v < min) return min;
            return v;
        }

        public static float Clamp01(float v)
        {
            return Clamp(v, 0f, 1f);
        }

        public static float random
        {
            get { return (float)m_random.NextDouble(); }
        }

    }
}
