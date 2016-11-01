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
            Camera camera = new Camera(Vector3.Zero, Vector3.Up, Vector3.Right, 70);
            contex.SetCamera(camera);

            //directional light
            //DirectionalLight dlight = new DirectionalLight(new Vector3(5f,-5f,-5f),new Vector3(1f,1f,1f), 1.2f);
            //contex.SetLight(dlight);

            //pointLight
            PointLight plight = new PointLight(new Vector3(-1, 1, -1), new Vector3(1f, 1f, 1f), 1f);
            contex.SetLight(plight);

            contex.SetAmbientLight(Color.FromArgb(10,10,10));

            Sphere sphere = new Sphere(new Vector3(0, -0.2f, -5.3f), 1f);
            sphere.SetMaterial(new MaterialDiffuse(Color.FromArgb(200,20,30)));

            Sphere sphere2 = new Sphere(new Vector3(1.2f, 0, -5f), 1.2f);
            sphere2.SetMaterial(new MaterialBlinnPhong(Color.FromArgb(12,25,213),10));

            Plane plane1 = new Plane(new Vector3(0, 0, 1), new Vector3(0, 0, -6f));
            Plane plane2 = new Plane(new Vector3(0, 1, 0), new Vector3(0,-2, 0));
            Plane plane3 = new Plane(new Vector3(0, -1, 0), new Vector3(0, 2, 0));
            Plane plane4 = new Plane(new Vector3(1, 0, 0), new Vector3(-2, 0, 0));
            Plane plane5 = new Plane(new Vector3(-1, 0, 0), new Vector3(2, 0, 0));

            MaterialBlinnPhong matBlinnPhongW = new MaterialBlinnPhong(Color.FromArgb(20, 200, 20), 10f);
            MaterialBlinnPhong matBlinnPhongB = new MaterialBlinnPhong(Color.FromArgb(0, 50, 200), 10f);
            MaterialBlinnPhong matBlinnPhongY = new MaterialBlinnPhong(Color.FromArgb(100,100, 20),1f);
            plane1.SetMaterial(matBlinnPhongY);
            plane2.SetMaterial(matBlinnPhongB);
            plane3.SetMaterial(matBlinnPhongW);
            plane4.SetMaterial(matBlinnPhongB);
            plane5.SetMaterial(matBlinnPhongW);

            contex.AddGeometry(sphere);
            contex.AddGeometry(sphere2);
            contex.AddGeometry(plane1);
            contex.AddGeometry(plane2);
            contex.AddGeometry(plane3);
            contex.AddGeometry(plane4);
            contex.AddGeometry(plane5);

            bitmap = contex.Render();
        }
    }
}
