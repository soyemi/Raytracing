﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Sampler
{
    public class JitteredSampler :SamplerBase
    {

        public override void GenerateSampler(int num,int set = 1)
        {
            int sc = 0;
            int n = (int)Math.Sqrt(num);
            NUM_SAMPLES = n * n;
            m_sampleSets = set;
            m_samples =new Vector3[NUM_SAMPLES * set];
            float invn = 1.0f / n;
            for(int s =0;s<set;s++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Vector3 sp = Vector3.Ctor((k + Util.random) * invn, (j + Util.random) * invn, 0);
                        m_samples[sc] = sp;
                        sc++;
                    }
                }
            }
            
        }
    }
}
