using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracing.Tracers;

using RayTracing.Sampler;
namespace RayTracing.Light
{
    class AmbientOccluder :LightBase
    {
        private Vector3 m_minMount;
        private Vector3 m_color;
        private float m_ls;
        private Vector3 m_lcolor;

        private SamplerBase m_sampler;
        public AmbientOccluder(Vector3 minMount,Vector3 color, float ls)
        {
            m_minMount = minMount;
            m_color = color;
            m_ls = ls;

            m_lcolor = m_ls * m_color;
        }

        public void SetSampler(SamplerBase sampler,int aosamples,int sampleSet = 1)
        {
            m_sampler = sampler;
            m_sampler.GenerateSampler(aosamples, sampleSet);
            m_sampler.MapSamplesToHemisphere();
        }

        public override Vector3 L(ShadeRec sr)
        {
            Vector3 dir = GetDirection(sr);
            Ray sray = new Ray(sr.localHitPoint + dir*TracerConst.kEpsilon,dir);


            //return 0.5f*(sray.dir + Vector3.One);

            if (ShadowCheck(sray, sr))
            {
                return m_minMount * m_lcolor;
            }
            else
            {
                return  m_lcolor;
            }
        }

        public override Vector3 GetDirection(ShadeRec sr)
        {
            Vector3 w = sr.normal.Nor();
            Vector3 v = w.Cross(Vector3.UpJitted).Nor(); //use Jitted Up vector avoid w parallels to vec3.up;
            Vector3 u = v.Cross(w).Nor();

            Vector3 sp = m_sampler.SampleHemisphere();
            Vector3 dir = sp.x * u + sp.y * v + sp.z * w;
            return dir.Nor();
        }

        public override float GetDistance(Vector3 pos)
        {
            return float.MaxValue;
        }
    }
}
