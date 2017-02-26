using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;


using RayTracing.Tracers;
namespace RayTracing.Sampler
{
    public class SamplerBase
    {
        public int NUM_SAMPLES { get; protected set; }
        protected Vector3[] m_samples;

        protected int m_index;


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

        public virtual Vector3 SampleUnitSquare()
        {
            int i= m_index % NUM_SAMPLES;
            m_index++;
            return m_samples[i];
            
        }

        public virtual Vector3 SampleHemisphere()
        {
            int i = m_index % NUM_SAMPLES;
            m_index++;
            return m_samples[i];
        }

        public virtual void MapSamplesToHemisphere(float e=1.0f)
        {
            Console.WriteLine(NUM_SAMPLES);
            int n = m_samples.Length;
            float phi;
            Vector3 sp;
            float cosTheta, sinTheta;
            float powe = 1.0f / (e + 1.0f);
            for(int j=0;j<n;j++)
            {
                sp = m_samples[j];
                phi = TracerConst.TWO_PI * sp.x;
                float cosPhi =(float) Math.Cos(phi);
                float sinPhi = (float)Math.Sin(phi);
                cosTheta =(float) Math.Pow(1.0f - sp.y, powe);
                sinTheta =(float) Math.Sqrt(1.0f - cosTheta * cosTheta);
                float pu = sinTheta * cosPhi;
                float pv = sinTheta * sinPhi;
                float pw = cosTheta;

                m_samples[j] = Vector3.Ctor(pu, pw, pv);
            }

            Bitmap bitmap = new Bitmap(200, 200);
            foreach (var p in m_samples)
            {
                int x = (int)(p.x * 100f) + 100;
                int z = (int)(p.z * 100f) + 100;
                bitmap.SetPixel(x, z, Color.Red);
            }

            bitmap.Save("e:/ee.png", ImageFormat.Png);


        }
    }
}
