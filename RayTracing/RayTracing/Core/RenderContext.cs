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
        private Camera m_camera;

        private Bitmap bitmap;

        public RenderContext(int width,int height)
        {
            m_width = width;
            m_height = height;
            m_geoms = new List<Primitive>();
            bitmap = new Bitmap(width, height);
        }

        public void AddGeometry(Primitive geom)
        {
            m_geoms.Add(geom);
        }

        public void SetCamera(Camera camera)
        {
            m_camera = camera;
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
                    IntertsectResult intersect = union.Intertsect(ray);
                    if(intersect.primitive != null)
                    {
                        bitmap.SetPixel(k, i, intersect.primitive.material.CaculateColor());
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
