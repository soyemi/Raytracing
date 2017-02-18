using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    public struct Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float length
        {
            get
            {
                
                return (float)System.Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            }

        }
        public float sqrLeng()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }


        public static Vector3 operator *(Vector3 v, float m)
        {
            return new Vector3(v.x * m, v.y * m, v.z * m);
        }


        public static Vector3 operator *(float m, Vector3 v)
        {
            return v * m;
        }

        public Vector3 clamp()
        {
            this.x = Util.Clamp01(x);
            this.y = Util.Clamp01(y);
            this.z = Util.Clamp01(z);
            return this;
        }

        public static Vector3 operator *(Vector3 m, Vector3 n)
        {
            return new Vector3(m.x * n.x, m.y * n.y, m.z * n.z);
        }


        public static Vector3 operator /(Vector3 v, float m)
        {
            return new Vector3(v.x / m, v.y / m, v.z / m);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return a + (-b);
        }

        public Vector3 Nor()
        {
            return this / this.length;
        }

        public float Dot(Vector3 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector3 Cross(Vector3 v)
        {
            return -(new Vector3(this.y * v.z - this.z * v.y, this.z * v.x - this.x * v.z, this.x * v.y - this.y * v.x));
        }

        public byte[] ToColorRGB
        {
            get
            {
                return new byte[] { (byte)System.Math.Floor(x * 255.99f), (byte)System.Math.Floor(y * 255.99f), (byte)System.Math.Floor(z * 255.99f) };
            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", x, y, z);
        }


        public readonly static Vector3 Zero = new Vector3(0, 0, 0);
        public readonly static Vector3 Up = new Vector3(0, 1, 0);
        public readonly static Vector3 Down = new Vector3(0, -1, 0);
        public readonly static Vector3 Left = new Vector3(-1, 0, 0);
        public readonly static Vector3 Right = new Vector3(1, 0, 0);
        public readonly static Vector3 Forward = new Vector3(0, 0, 1);
        public readonly static Vector3 Backward = new Vector3(0, 0, -1);

    }
}
