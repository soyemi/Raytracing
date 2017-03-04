using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class NRockSampler :SamplerBase
    {
        public override void GenerateSampler(int num,int set = 1)
        {
            NUM_SAMPLES = num;
            m_sampleSets = set;
            m_samples = new Vector3[num * set];
            float invn = 1.0f / num;

            for(int s = 0;s<set;s++)
            {
                int ns = num * s;

                for (int j = 0; j < num; j++)
                {
                    Vector3 p = Vector3.Ctor((j + Util.random) * invn, (j + Util.random) * invn, 0);
                    m_samples[j+ ns] = p;
                }

                //shuffle
                for (int i = 0; i < num; i++)
                {
                    int tar = Util.randomInt % num;
                    float t = m_samples[i+ ns].x;
                    m_samples[i+ ns].x = m_samples[tar+ ns].x;
                    m_samples[tar+ ns].x = t;

                    tar = Util.randomInt % num;
                    t = m_samples[i+ ns].y;
                    m_samples[i+ ns].y = m_samples[tar+ ns].y;
                    m_samples[tar+ ns].y = t;
                }
            }

            
        }
    }
}
