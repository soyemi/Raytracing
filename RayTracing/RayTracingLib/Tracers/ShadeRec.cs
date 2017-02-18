using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing.Tracers
{
    public class ShadeRec
    {
        public Vector3 normal;
        public Vector3 localHitPoint;
        public bool isHitObj = false;
        public Material hitMaterial;

        public float rayT;

        
    }
}
