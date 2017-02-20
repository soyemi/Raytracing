using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Utility
{
    class ToneMapping
    {
        public static Vector3 CEToneMapping(Vector3 color, float adaptedLum)
        {
            color *= -adaptedLum;
            float r = (float)Math.Exp(color.x);
            float g = (float)Math.Exp(color.y);
            float b = (float)Math.Exp(color.z);
            return new Vector3(1f - r, 1f - g, 1f - b);
        }

        //unchart
        const float A = 0.22f;
        const float B = 0.30f;
        const float C = 0.10f;
        const float D = 0.20f;
        const float E = 0.01f;
        const float F = 0.30f;

        private static readonly Vector3 fw = f(Vector3.One * WHITE);
        private static Vector3 f(Vector3 x)
        {
            return ((x * (x* A + Vector3.One* C * B) + Vector3.One * D * E) / (x * (A * x + Vector3.One * B) + Vector3.One * D * F)) - Vector3.One * E / F;
        }
        const float WHITE = 11.2f;
        public static Vector3 Uncharted2ToneMapping(Vector3 color,float adaptedLum)
        {

            return f(1.6f * adaptedLum * color) / fw;
        }

    }
}
