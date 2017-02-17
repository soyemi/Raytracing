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

        public RenderTask(int width,int height,System.Windows.Controls.Image targetImage)
        {
            IsFinish = false;

            this.Width = width;
            this.Height = height;

            image = targetImage;

            targetImage.Width = width;
            targetImage.Height = height;

            img = targetImage;

            m_targetBitmap = new WriteableBitmap(Height, Width, 0, 0, PixelFormats.Rgb24, null);
            image.Source = m_targetBitmap;

        }

        public void Start()
        {
            Thread thread = new Thread(DoRender);
            thread.Start();

        }

        private void DoRender()
        {
            for (int y = 0;y< Height;y++)
            {
                for(int x= 0;x<Width;x++)
                {
                    m_targetBitmap.Dispatcher.Invoke(() =>
                    {
                        m_targetBitmap.SetPixel(x, y);
                    });
                }
            }

            IsFinish = true;
        }
    }
}
