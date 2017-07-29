using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RobloxShirtMaker
{
    public static class ImageConversion
    {
        //https://stackoverflow.com/questions/94456/load-a-wpf-bitmapimage-from-a-system-drawing-bitmap
        public static ImageSource ConvertBitmapToBitmapImageSource(Bitmap bitmap, int desiredWidth, int desiredHeight)
        {
            IntPtr hBitmapObj = bitmap.GetHbitmap();

            ImageSource finalBitmapImageSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmapObj, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(desiredWidth, desiredHeight));
            DeleteObject(hBitmapObj);

            return finalBitmapImageSource;
        }

        //https://stackoverflow.com/questions/1546091/wpf-createbitmapsourcefromhbitmap-memory-leak
        //WILL THIS DELETE THE IMAGE ON THE HD?
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        //https://stackoverflow.com/a/9405435
        public static System.Drawing.Image ImageWpfToGDI(System.Windows.Controls.Image image)
        {
            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image.Source as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();
            return System.Drawing.Image.FromStream(ms);
        }
    }
}
