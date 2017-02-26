using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class RandomSampler : SamplerBase
    {
        public RandomSampler()
        {

        }

        protected override void setSamplePoint(int i)
        {
            m_samples[i] = Vector3.Ctor(Util.random, Util.random, 0);
        }
    }
}
