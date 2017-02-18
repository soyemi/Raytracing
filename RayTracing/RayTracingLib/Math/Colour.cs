using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    public struct Colour
    {
        public byte R;
        public byte G;
        public byte B;

        public Colour(byte r,byte g,byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Colour(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        public static readonly Colour White = new Colour(255, 255, 255);
        public static readonly Colour Black = new Colour(0, 0, 0);

        public static readonly Colour Red = new Colour(255, 0, 0);
        public static readonly Colour Green = new Colour(0, 255, 0);
        public static readonly Colour Blue = new Colour(0, 0, 255);
    }
}
