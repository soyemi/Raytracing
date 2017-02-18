using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Camera;
using RayTracing.Geom;
using RayTracing.Tracers;
namespace RayTracing.Utility
{
    public class RenderContext
    {
        public ViewPlane viewPlane { get; set; }
        public Vector3 backGroundColor = ColourF.Black;

        List<Geometry> objects = new List<Geometry>();

        public List<Geometry> RenderObjects { get { return objects; } }

        public CameraBase camera;
        public Tracer tracer;


        private RenderConfig m_config;

        public RenderContext(RenderConfig config)
        {
            m_config = config;

            float aspectRatio = config.width * 1.0f / config.height;
            viewPlane = new ViewPlane(config.width, config.height, 1f,2);
            viewPlane.sampleType = config.sampleType;
            viewPlane.Samples = config.samples;

            camera = new PerspectiveCamera(Vector3.Zero,(new Vector3(1f,0f,5f)).Nor(),Vector3.Up, aspectRatio);

            tracer = new Tracer(this);

            Sphere spr = new Sphere(new Vector3(0,0,1f), 0.4f);
            spr.SetMaterial(new Material(ColourF.Green));

            Sphere spr1 = new Sphere(new Vector3(0.5f, 0, 1f), 0.5f);
            spr1.SetMaterial(new Material(ColourF.Red));

            Sphere spr2 = new Sphere(new Vector3(3f, 0, 5f), 5f);
            spr2.SetMaterial(new Material(new Vector3(0.2f, 0.4f, 0.8f)));

            Plane p = new Plane(new Vector3(0,-0.2f,0), Vector3.Up);
            p.SetMaterial(new Material(ColourF.White));

            objects.Add(p);
            objects.Add(spr);
            objects.Add(spr1);
            objects.Add(spr2);

        }

        public void Render(Action<int,int,Vector3> SetFinalPixel)
        {
            Vector3 L;
            int n = viewPlane.Samples;
            for(int h =0;h<viewPlane.Height; h++)
            {
                for(int w =0;w < viewPlane.Width;w++)
                {
                    L = Vector3.Zero;
                    

                    for(int x= 0;x<n;x++)
                    {
                        for(int y=0;y<n;y++)
                        {
                            float pw = w - (viewPlane.Width - 1) * 0.5f;
                            float ph = h - (viewPlane.Height - 1) * 0.5f;
                            if(viewPlane.sampleType == SampleType.Default)
                            {
                                pw += (x + 0.5f) / n;
                                ph += (y + 0.5f) / n;
                            }
                            else
                            {
                                pw += Util.random;
                                ph += Util.random;
                            }

                            Ray ray = camera.CaculateRay(pw, ph);
                            L += tracer.TraceRay(ray);
                        }
                    }
                    L /= (n * n);
                    
                    SetFinalPixel(w, h, L);

                }
            }
        }

        public ShadeRec HitObjects(Ray ray)
        {
            ShadeRec sr = new ShadeRec();
            Material mat = null;

            float t = TracerConst.kMaxDist;
            
            foreach(var o in objects)
            {
                if(o.Hit(ray, ref sr))
                {
                    if(sr.rayT < t)
                    {
                        t = sr.rayT;
                        sr.isHitObj = true;
                        mat = o.material;
                    }
                }
            }

            if (sr.isHitObj)
            {
                sr.hitMaterial = mat;
            }

            return sr;
        }

    }
}
