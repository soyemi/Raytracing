using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing;
using RayTracing.Tracers;
namespace RayTracing.Light
{
    public abstract class LightBase
    {

        public bool m_castShadow = false;
        public bool CAST_SHADOW { get { return m_castShadow; } set { m_castShadow = value; } }

        public virtual Vector3 GetDirection(ShadeRec sr)
        {
            return Vector3.Zero;
        }

        public virtual Vector3 L(ShadeRec sr)
        {
            return ColourF.Black;
        }

        public virtual float GetDistance(Vector3 pos)
        {
            return float.MaxValue;
        }

        public virtual bool ShadowCheck(Ray shadowRay, ShadeRec sr)
        {
            float t = float.MaxValue;
            float dist = GetDistance(sr.localHitPoint);
            int objcount = sr.context.RenderObjects.Count();
            for(int i=0;i<objcount;i++)
            {
                if(sr.context.RenderObjects[i].ShadowHit(shadowRay,ref t))
                {
                    if (t < dist)
                        return true;
                }
            }
            return false;
        }

        public virtual float G(ShadeRec sr)
        {
            return 1f;
        }

        /// <summary>
        /// probability density function
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public virtual float PDF(ShadeRec sr)
        {
            return 1f;
        }
    }
}
