using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls;

using RayTracing.Utility;
using RayTracing.Camera;
using RayTracing.Geom;
using RayTracing.Tracers;
using RayTracing;

namespace RayTracerWPF
{
    public class RenderTask
    {

        public bool IsFinish { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private WriteableBitmap m_targetBitmap;

        private System.Windows.Controls.Image img;
        private Image image;

        private RenderContext m_context;

        private byte[] m_rawData;

        public RenderTask(int width,int height,System.Windows.Controls.Image targetImage)
        {
            IsFinish = false;

            this.Width = width;
            this.Height = height;

            image = targetImage;

            targetImage.Width = width;
            targetImage.Height = height;

            img = targetImage;

            m_targetBitmap = new WriteableBitmap(Width,height , 0, 0, PixelFormats.Rgb24, null);
            img.Source = m_targetBitmap;
            InitRenderContext();
        }

        private void InitRenderContext()
        {
            m_context = new RenderContext(Width,Height);
            m_rawData = new byte[Width * Height * 3];


        }

        public void Start()
        {
            Thread thread = new Thread(DoRender);
            thread.Start();

        }

        private void DoRender()
        {
            m_context.Render(SetPixel);

            IsFinish = true;
            Refresh();

            Console.WriteLine("render done!");
        }

        private int pixelCount = 0;

        private void SetPixel(int x,int y,Vector3 color)
        {
            int off = (x + y * Width)*3;
            m_rawData[off] = (byte)(int)(color.x * 255f);
            m_rawData[off+1] = (byte)(int)(color.y * 255f);
            m_rawData[off+2] = (byte)(int)(color.z * 255f);

            pixelCount++;
            if (pixelCount % 512 == 0)
                Refresh();
        }

        private void Refresh()
        {
            m_targetBitmap.Dispatcher.Invoke(() =>
            {
                m_targetBitmap.WritePixels(new System.Windows.Int32Rect(0, 0, Width, Height), m_rawData, Width * 3, 0);
            });
        }
    }
}
