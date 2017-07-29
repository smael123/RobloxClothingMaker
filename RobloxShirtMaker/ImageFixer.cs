using System;
using System.Drawing;

namespace RobloxShirtMaker
{
    class ImageFixer
    {
        private Bitmap bitmap;
        private int desiredWidth;
        private int desiredHeight;
        public enum ErrorEnum {
            None,
            NotResizable,
        }

        public ImageFixer(Bitmap image, int desiredWidth, int desiredHeight) {
            this.bitmap = image;
            this.desiredWidth = desiredWidth;
            this.desiredHeight = desiredHeight;
        }

        public Bitmap FixImage() {
            if (!IsCorrectSize()) {
                Resize();   
            }

            return bitmap;
        }

        private int ConvertTo8Bit() {
            throw new NotImplementedException();
        }

        private void Resize() {
            //image.Size = new Size(desiredWidth, desiredHeight);
            Bitmap resizedBitmap = new Bitmap(bitmap, desiredWidth, desiredHeight);
        }

        private bool IsCorrectSize() {
            if (bitmap.Width == desiredWidth && bitmap.Height == desiredHeight)
            {
                return true;
            }
            else { return false; }
        } 
    }
}
