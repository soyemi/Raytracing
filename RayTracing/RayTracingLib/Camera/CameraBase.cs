using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Utility;
namespace RayTracing.Camera
{
    public abstract class CameraBase
    {
        public Vector3 Position;
        public Vector3 Up = Vector3.Up;
        public Vector3 Forward = Vector3.Forward;
        public Vector3 Right;

        public float AspectRatio;
        public CameraBase(Vector3 pos,Vector3 forward,Vector3 up,ViewPlane plane)
        {
            Position = pos;
            Forward = forward;
            Right = Forward.Cross(up);
            Up = Forward.Cross(Right);

            AspectRatio = plane.Width*1.0f / plane.Height;

            Forward = Forward.Nor();
            Right = Right.Nor();
            Up = Up.Nor();
        }

        public CameraBase()
        {
            Right = Forward.Cross(Up);
        }

        public abstract Ray CaculateRay(float x,float y,ViewPlane plane = null);
    }
}
