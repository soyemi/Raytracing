using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Utility
{
    public class RenderConfig
    {
        public SampleType sampleType = SampleType.Default;
        public int width = 128;
        public int height = 128;
        public int samples = 1;
    }
}
