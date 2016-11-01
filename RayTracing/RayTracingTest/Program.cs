using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using RayTracing;

namespace RayTracingTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public static Bitmap bitmap;
        public static void Render()
        {
            RenderContext contex = new RenderContext(500, 500);
            Camera camera = new Camera(Vector3.Zero, Vector3.Up, Vector3.Right, 60);
            contex.SetCamera(camera);

            //directional light
            //DirectionalLight dlight = new DirectionalLight(new Vector3(5f,-5f,-5f),new Vector3(1f,1f,1f), 1.2f);
            //contex.SetLight(dlight);

            //pointLight
            PointLight plight = new PointLight(new Vector3(-5f, 5f, 3f), new Vector3(1f, 1f, 1f), 1f);
            contex.SetLight(plight);

            contex.SetAmbientLight(Color.FromArgb(50,50,50));

            Sphere sphere = new Sphere(new Vector3(0, -0.2f, -5.3f), 1f);
            sphere.SetMaterial(new MaterialDiffuse(Color.FromArgb(200,20,30)));

            Sphere sphere2 = new Sphere(new Vector3(1.2f, 0, -5f), 1.2f);
            sphere2.SetMaterial(new MaterialBlinnPhong(Color.FromArgb(12,25,213),10));

            contex.AddGeometry(sphere);
            contex.AddGeometry(sphere2);

            bitmap = contex.Render();
        }
    }
}
