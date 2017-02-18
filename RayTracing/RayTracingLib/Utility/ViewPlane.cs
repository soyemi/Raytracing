using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Utility
{
    public class ViewPlane
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public float Scale { get; private set; }
        public int Samples { get; private set; }
        public float Gamma { get; private set; }
        public float GammaInv { get; private set; }
        public ViewPlane(int w, int h, float scale = 1.0f,int sample = 1,float gamma = 1.0f)
        {
            Height = h;
            Width = w;
            Scale = scale;
            Samples = sample;
            Gamma = gamma;
            GammaInv = 1.0f / Gamma;
        }

    }
}
