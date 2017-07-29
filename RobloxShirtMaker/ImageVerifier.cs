using System.Drawing;

namespace RobloxShirtMaker
{
    class ImageVerifier
    {
        //File file
        private Bitmap bitmap;
        private string filePath;
        public enum ErrorEnum {
            None,
            Non8BitImage,
            NonImage,
        };

        public ImageVerifier(string filePath) {
            //accepts file object and trys to parse as image

            this.filePath = filePath;
            
        }

        public string IsValid() {
            if (!IsImage()) { return "Error: Not a valid image."; }
            if (!Is8Bit()) { return "Error: Not an 8-bit alpha image."; }

            return null;
        }

        private bool IsImage() {
            try { bitmap = new Bitmap(filePath); }
            catch { return false; }

            return true;
        }

        //https://stackoverflow.com/a/3780236
        private bool Is8Bit() {
            /*int width = bitmap.Width;
            int height = bitmap.Height;

            bitmap.get

            for (int i = 0; i < width; i++) {
                for (int j = 0; i < height; j++) {
                    var pixel = bitmap.GetPixel(i, j);

                    if (pixel.A != 255) {
                        return true;
                    }
                }
            }

            return false;*/

            //throw new NotImplementedException();

            return true;
        }
    }
}
