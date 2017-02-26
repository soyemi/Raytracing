using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RayTracing.Camera;
using RayTracing.Geom;
using RayTracing.Tracers;
using RayTracing.Material;
using RayTracing.Light;
using RayTracing.Sampler;
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
        public LightBase ambientLight;
        public List<LightBase> lights;

        private RenderConfig m_config;

        public RenderContext(RenderConfig config)
        {
            m_config = config;

            float aspectRatio = config.width * 1.0f / config.height;
            viewPlane = new ViewPlane(config.width, config.height, 1f,2);
            viewPlane.SAMPLES = config.samples;
            viewPlane.SetSampler(new NRockSampler());

            ToneMapping.type = ToneMapping.ToneMappingType.ACES;

            camera = new PerspectiveCamera(new Vector3(0,0,-5f),Vector3.Forward,Vector3.Up,viewPlane,60f);

            tracer = new Tracer(this);

            MatMatte matSp1 = new MatMatte(ColourF.White, ColourF.White);


            Plane p1 = new Plane(new Vector3(0, 0, 4), Vector3.Backward);
            p1.SetMaterial(matSp1);

            Plane pup = new Plane(new Vector3(0, -1f, 0f), new Vector3(0,1f,0f));
            pup.SetMaterial(matSp1);


            Sphere spr1 = new Sphere(new Vector3(2, 1.3f, 0f), 1.3f);
            spr1.SetMaterial(matSp1);

            MatPhong matphong = new MatPhong(0.25f,0.7f,0.3f,ColourF.White,ColourF.Red,ColourF.White,100F);

            Sphere spr2 = new Sphere(new Vector3(1f, -1f, -0.5f), 0.75f);
            spr2.SetMaterial(matphong);

            Sphere spr3 = new Sphere(new Vector3(-1f, 0.3f, 0f), 1.0f);
            spr3.SetMaterial(matphong);

            AxisAlignedBox box1 = new AxisAlignedBox(Vector3.Ctor(-2.5f, -2f, -1f), Vector3.Ctor(1f, 3f, 2f));
            MatPhong matbox1 = new MatPhong(0.25f, 1.0f, 0.5f, ColourF.White, Vector3.Ctor(0.2f, 0.3f, 1.0f), ColourF.White, 20f);
            box1.SetMaterial(matbox1);

            Disk disk1 = new Disk(Vector3.Ctor(0f, 1f, -0.53f), Vector3.Ctor(-0.2f,0.5f,1f), 0.3f);
            disk1.SetMaterial(matSp1);
            objects.Add(disk1);

            objects.Add(p1);
            objects.Add(pup);

            objects.Add(spr1);
            objects.Add(spr2);
            objects.Add(spr3);
            objects.Add(box1);

            ambientLight = new Ambient(1.0f, ColourF.White);
            lights = new List<LightBase>();

            PointLight pl = new PointLight(Vector3.Ctor(-1f, 2.5f, 2.3f), ColourF.White, 10f,5f);
            pl.CAST_SHADOW = true;

            DirectionalLight dl = new DirectionalLight(Vector3.Ctor(0f,-1f,0.2f), ColourF.White, 2.0f);
            dl.CAST_SHADOW = true;
            lights.Add(dl);
            lights.Add(pl);
        }

        public void Render(Action<int,int,Vector3> SetFinalPixel)
        {
            Vector3 L;
            int n = viewPlane.SAMPLER.NUM_SAMPLES;
            for(int h =0;h<viewPlane.Height; h++)
            {
                for(int w =0;w < viewPlane.Width;w++)
                {
                    L = Vector3.Zero;
                    float pw = w - (viewPlane.Width - 1) * 0.5f;
                    float ph = h - (viewPlane.Height - 1) * 0.5f;

                    for (int j=0;j<n;j++)
                    {
                        Vector3 sp = viewPlane.SAMPLER.SampleUnitSquare(j);
                        sp.x += pw;
                        sp.y += ph;

                        Ray ray = camera.CaculateRay(sp.x, sp.y, viewPlane);
                        L += tracer.TraceRay(ray);
                    }

                    L /= (1.0f*n);
                    L = ToneMapping.Caculate(L, 1.0F);
                    SetFinalPixel(w, h, L);
                }
            }
        }

        public ShadeRec HitObjects(Ray ray)
        {
            ShadeRec sr = new ShadeRec(this);
            sr.ray = ray;

            MaterialBase mat = null;
            Vector3 normal = Vector3.Zero;
            Vector3 localhit = Vector3.Zero;

            float t = TracerConst.kMaxDist;
            
            foreach(var o in objects)
            {
                if(o.Hit(ray, ref sr))
                {
                    if(sr.rayT < t)
                    {
                        t = sr.rayT;
                        sr.isHitObj = true;
                        normal = sr.normal;
                        mat = o.material;
                        localhit = sr.localHitPoint;
                    }
                }
            }

            if (sr.isHitObj)
            {
                sr.hitMaterial = mat;
                sr.normal = normal;
                sr.localHitPoint = localhit;
            }

            return sr;
        }

    }
}
