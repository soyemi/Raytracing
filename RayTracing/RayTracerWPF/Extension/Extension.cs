using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
using System.Windows;

using RayTracing;
namespace RayTracerWPF
{
    public static class WriteableBitmapExtension
    {

        public static void SetPixel(this WriteableBitmap bitmap,int x,int y,Vector3 color)
        {
            Int32Rect rect = new Int32Rect(x, y, 1, 1);

            byte[] dat = new byte[3];
            dat[0] =(byte)(int)(color.x * 255f);
            dat[1] = (byte)(int)(color.y * 255f);
            dat[2] = (byte)(int)(color.z * 255f);

            bitmap.WritePixels(rect,dat, 3, 0);
        }
    }
}
