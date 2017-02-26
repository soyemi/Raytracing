using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class BlurSampler :SamplerBase
    {
        private float m_blueSize;
        private float m_halfblueSize;
        public BlurSampler(float blueSize)
        {
            m_blueSize = blueSize;
            m_halfblueSize = m_blueSize * 0.5f;
        }

        protected override void setSamplePoint(int i)
        {
            m_samples[i] = Vector3.Ctor(Util.random * m_blueSize - m_halfblueSize, Util.random * m_blueSize - m_halfblueSize, 0);
        }
    }
}
