using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class SamplerBase
    {
        public int NUM_SAMPLES { get; protected set; }
        protected Vector3[] m_samples;

        public SamplerBase()
        {
        }

        public virtual void GenerateSampler(int num)
        {
            NUM_SAMPLES = num;
            m_samples = new Vector3[NUM_SAMPLES];
            for(int i=0;i<NUM_SAMPLES;i++)
            {
                setSamplePoint(i);
            }
        }

        protected virtual void setSamplePoint(int i)
        {
            m_samples[i] = Vector3.Zero;
        }

        public virtual Vector3 SampleUnitSquare(int index)
        {
            return m_samples[index % NUM_SAMPLES];
        }
    }
}
