using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class NRockSampler :SamplerBase
    {
        public override void GenerateSampler(int num)
        {
            NUM_SAMPLES = num;

            m_samples = new Vector3[num];
            float invn = 1.0f / num;
            for(int j=0;j<num;j++)
            {
                Vector3 p = Vector3.Ctor((j+Util.random)* invn,(j+Util.random)* invn,0);
                m_samples[j] = p;
            }

            //shuffle
            for(int i=0;i<num;i++)
            {
                int tar = Util.randomInt % num;
                float t = m_samples[i].x;
                m_samples[i].x = m_samples[tar].x;
                m_samples[tar].x = t;

                tar = Util.randomInt % num;
                t = m_samples[i].y;
                m_samples[i].y = m_samples[tar].y;
                m_samples[tar].y = t;
            }
        }
    }
}
