using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    public struct ColourF
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }

        public ColourF(float x, float y, float z)
        {
            this.r = x;
            this.g = y;
            this.b = z;
        }

        public static readonly Vector3 Black = new Vector3(0, 0, 0);
        public static readonly Vector3 White = new Vector3(1, 1, 1);

        public static readonly Vector3 Red = new Vector3(1, 0, 0);
        public static readonly Vector3 Green = new Vector3(0,1, 0);
        public static readonly Vector3 Blue = new Vector3(0, 0,1);

        public static readonly Vector3 Error = new Vector3(1,0,1);
    }
}
