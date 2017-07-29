using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RobloxShirtMaker
{
    class ClothingMaker
    {
        private Clothing clothing;
        private Bitmap finalImage;
        public enum ErrorEnum {
            None,
            MergeImagesError,
            GraphicNullError
        }

        public ClothingMaker(Clothing clothing) {
            this.clothing = clothing;
        }

        //https://stackoverflow.com/a/465195
        private ErrorEnum MergeImages() {
            Bitmap templateImage = clothing.TemplateImage;

            Graphics finalGraphic = Graphics.FromImage(templateImage);

            //clothing.TemplateImage.Save($"before_test.png", ImageFormat.Png);
            //new Bitmap(clothing.TemplateImage.Width, clothing.TemplateImage.Height, finalGraphic).Save("beforeGraphic.png", ImageFormat.Png);

            foreach (BodyPart bp in clothing.BodyPartList) {
                try
                {
                    Bitmap bodyImage = new Bitmap(ImageConversion.ImageWpfToGDI(bp.UiImageBox));
                    //bodyImage.Save($"{bp.SectionID}_test.png", ImageFormat.Png);

                    finalGraphic.DrawImage(bodyImage, bp.TopLeftPoint.xPoint, bp.TopLeftPoint.yPoint);
                }
                catch (ArgumentNullException ane)
                {
                    return ErrorEnum.GraphicNullError;
                }
                catch (Exception e) {
                    return ErrorEnum.MergeImagesError;
                }
            }

            //finalImage = new Bitmap(clothing.TemplateImage.Width, clothing.TemplateImage.Height, finalGraphic);
            finalImage = new Bitmap(templateImage);
            return ErrorEnum.None;
        }

        public string SaveImageToHardDrive() {
            string typeStr = Enum.GetName(typeof(Clothing.ClothingType), clothing.Type);
            string fileName = $"{clothing.Name}_{typeStr}_R{clothing.Version}.png";

            ErrorEnum error = MergeImages();
            string errorMsg;

            switch (error) {
                case ErrorEnum.GraphicNullError:
                    errorMsg = "Error: null reference passed to Graphics object";
                    break;
                case ErrorEnum.MergeImagesError:
                    errorMsg = "Error: An error occured during the merging of images.";
                    break;
                default:
                    errorMsg = "Clothing template image saved in the executable directory with the file name: " +
                        fileName;
                    finalImage.Save(fileName, ImageFormat.Png);
                    break;
            }

            return errorMsg;
        }
    }
}
