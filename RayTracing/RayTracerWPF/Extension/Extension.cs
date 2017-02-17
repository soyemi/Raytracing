using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
using System.Windows;

namespace RayTracerWPF
{
    public static class WriteableBitmapExtension
    {
        public static void SetPixel(this WriteableBitmap bitmap,int x,int y)
        {
            Int32Rect rect = new Int32Rect(x, y, 1, 1);
            bitmap.WritePixels(rect, new byte[] { 255, 0, 0 }, 3, 0);
        }
    }
}
