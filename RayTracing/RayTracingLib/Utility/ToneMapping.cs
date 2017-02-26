using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Utility
{
    class ToneMapping
    {

        public enum ToneMappingType
        {
            Reinhard = 0,
            CryEngine = 1,
            Uncharted2 =2,
            ACES =3,
        }

        public static ToneMappingType type = ToneMappingType.ACES;

        public static Vector3 Caculate(Vector3 color, float adaptedLum)
        {
            switch(type)
            {
                case ToneMappingType.Reinhard:
                    return ReinhardToneMapping(color, adaptedLum);
                case ToneMappingType.CryEngine:
                    return CEToneMapping(color, adaptedLum);
                case ToneMappingType.Uncharted2:
                    return Uncharted2ToneMapping(color, adaptedLum);
                case ToneMappingType.ACES:
                    return ACESToneMapping(color, adaptedLum);
                default:
                    return color;
            }
        }

        #region ReinhardToneMapping
        public static readonly float MIDDLE_GREY = 1F;
        public static Vector3 ReinhardToneMapping(Vector3 color,float adapetdLum)
        {
            color *= MIDDLE_GREY / adapetdLum;
            return color / (Vector3.One + color);
        }
        #endregion

        #region CEToneMapping
        public static Vector3 CEToneMapping(Vector3 color, float adaptedLum)
        {
            color *= -adaptedLum;
            float r = (float)Math.Exp(color.x);
            float g = (float)Math.Exp(color.y);
            float b = (float)Math.Exp(color.z);
            return new Vector3(1f - r, 1f - g, 1f - b);
        }
        #endregion;

        #region Uncharted2ToneMapping
        //unchart
        static readonly float A = 0.22f;
        static readonly float B = 0.30f;
        static readonly float C = 0.10f;
        static readonly float D = 0.20f;
        static readonly float E = 0.01f;
        static readonly float F = 0.30f;

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
        #endregion

        #region ACESToneMapping
        static readonly float A1 = 2.51f;
        static readonly float B1 = 0.03f;
        static readonly float C1 = 2.43f;
        static readonly float D1 = 0.59f;
        static readonly float E1 = 0.14f;
        public static Vector3 ACESToneMapping(Vector3 color,float adaptedLum)
        {
            color *= adaptedLum;
            return (color * (A1 * color + B1*Vector3.One)) / (color * (C1 * color + D1 * Vector3.One) + E1 * Vector3.One);
        }

        #endregion
    }
}
