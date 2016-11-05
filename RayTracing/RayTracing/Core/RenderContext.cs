using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;


namespace RayTracing
{
    public class RenderContext
    {
        private List<Primitive> m_geoms;
        private int m_width;
        private int m_height;
        private static Camera m_camera;

        private Bitmap bitmap;


        public static LightBase Light;
        public static Vector3 AmbientLight;

        public static Vector3 ViewPoint
        {
            get
            {
                return m_camera.pos;
            }
        }

        public const float bias = 0.0001f;



        public RenderContext(int width,int height)
        {
            m_width = width;
            m_height = height;
            m_geoms = new List<Primitive>();
            bitmap = new Bitmap(width, height);
        }

        public void SetLight(LightBase dl)
        {
            Light = dl;
        }


        public void AddGeometry(Primitive geom)
        {
            m_geoms.Add(geom);
        }

        public void SetCamera(Camera camera)
        {
            m_camera = camera;
        }

        public void SetAmbientLight(Color color)
        {
            AmbientLight = Util.ColorToVec(color);
        }

        public Bitmap Render()
        {

            PrimitiveUnion union = new PrimitiveUnion(m_geoms);

            for(int i = 0;i < m_height;i++)
            {
                float dy = 1 - i / (float)m_height;
                for(int k =0;k<m_width;k++)
                {
                    float dx = k / (float)m_width;
                    Ray ray = m_camera.GenerateRay(dx, dy);
                    IntersectResult intersect = union.Intersect(ray);
                    if(intersect.primitive != null)
                    {
                        //base color
                        Vector3 baseColor = intersect.primitive.material.CaculateColor(intersect);
                        //add shadow

                        Vector3 shadowPosition = intersect.position + bias * intersect.normal.Nor();
                        Ray shadowRay = new Ray(shadowPosition, -Light.GetDir(shadowPosition));
                        IntersectResult shadowResult = union.Intersect(shadowRay, intersect.primitive,true);
                        if(shadowResult.primitive != null)
                        {
                            //baseColor = shadowResult.primitive.debugColor;
                            baseColor *= 0.5f;
                        }

                        bitmap.SetPixel(k, i, Util.VecToColor(baseColor));
                    }
                    else
                    {
                        bitmap.SetPixel(k, i, Color.Black);
                    }
                }
            }

            return bitmap;
        }


    }
}
