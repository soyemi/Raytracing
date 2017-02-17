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
    }
}
