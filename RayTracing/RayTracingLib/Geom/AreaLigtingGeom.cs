using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;
using RayTracing.Sampler;
namespace RayTracing.Geom
{
    public abstract class AreaLigtingGeom :Geometry
    {
        protected Vector3 m_tempPoint;
        protected float m_area;
        protected float m_pdf;
        protected SamplerBase m_sampler;

        protected Vector3 m_vecx;
        protected Vector3 m_vecy;

        public bool SHADOW_BLOCK { get; set; }

        public AreaLigtingGeom()
        {
            SHADOW_BLOCK = true;
        }

        public virtual void SetSampler(SamplerBase sampler,int samples,int set = 1)
        {
            m_sampler = sampler;
            m_sampler.GenerateSampler(samples, set);
        }


        public virtual Vector3 Sample()
        {
            return Vector3.Zero;
        }
        public virtual float PDF(ShadeRec sr)
        {
            return 1;
        }
        public virtual Vector3 GetNormal(Vector3 p)
        {
            return Vector3.Zero;
        }
    }
}
