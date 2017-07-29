using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShirtMaker
{
    public static class FileGrabber
    {
        //https://stackoverflow.com/a/8527915
        public static string GetImageFilter()
        {
            string filter = "";
            ImageCodecInfo [] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = String.Empty;

            foreach (ImageCodecInfo c in codecs) {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                filter = String.Format("{0}{1}{2} ({3})|{3}", filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            filter = String.Format("{0}{1}{2} ({3})|{3}", filter, sep, "All Files", "*.*");

            return filter;
        }
    }
}
