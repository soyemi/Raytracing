﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class MaterialDiffuse : Material
    {
        public MaterialDiffuse(Color color):base(color)
        {
        }


        //Lambertian Shading
        public override Color CaculateColor(IntersectResult intersect)
        {
            Vector3 ldir = -RenderContext.Light.lightDirection;
            float dot = ldir.Dot(intersect.normal);
            Vector3 colv3 = mainColor * Math.Max(0,dot) * RenderContext.Light.lightAtten * RenderContext.Light.lightColor;
            colv3 += RenderContext.AmbientLight;
            return Util.VecToColor(colv3);
        }
    }
}