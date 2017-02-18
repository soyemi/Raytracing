using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Utility
{

    public enum SampleType
    {
        Default = 0,
        Random = 1,
    }

    public class ViewPlane
    {
        public SampleType sampleType { get; set; }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public float Scale { get; private set; }
        public int Samples { get; set; }
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
