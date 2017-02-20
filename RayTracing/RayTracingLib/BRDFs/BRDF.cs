using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Tracers;

namespace RayTracing.BRDFs
{
    public abstract class BRDF
    {
        public virtual Vector3 F(ShadeRec sr,Vector3 wo,Vector3 wi)
        {
            return ColourF.Error;
        }

        public virtual Vector3 Sample(ShadeRec sr, Vector3 wo, Vector3 wi)
        {
            return ColourF.Error;
        }
        public virtual Vector3 Sample(ShadeRec sr, Vector3 wo)
        {
            return ColourF.Error;
        }

        /// <summary>
        /// Reflectance 
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="wo"></param>
        /// <returns></returns>
        public virtual Vector3 rho(ShadeRec sr,Vector3 wo)
        {
            return ColourF.Error;
        }
    }
}
