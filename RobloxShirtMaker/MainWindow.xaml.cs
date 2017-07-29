using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Interop;
using System.IO;

namespace RobloxShirtMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Clothing clothing;
        private int clothingVersion;
        private Clothing.ClothingType clothingType;
        private string clothingName;

        //private ObservableCollection<BodyPart> bodyPartObservableCollection;
        private ArrayList bodyPartList;

        public MainWindow()
        {
            InitializeComponent();

            clothingType = Clothing.ClothingType.Shirt;
            clothingVersion = 15;

            //initialize body parts
            bodyPartList = new ArrayList();

            bodyPartList.Add(new BodyPart("TorsoR0", (System.Windows.Controls.Image)TorsoR0ImageBox.Content, new Point(165, 74), 64, 96));
            bodyPartList.Add(new BodyPart("TorsoR1", (System.Windows.Controls.Image)TorsoR1ImageBox.Content, new Point(165, 171), 64, 31));
            bodyPartList.Add(new BodyPart("TorsoUp", (System.Windows.Controls.Image)TorsoUpImageBox.Content, new Point(231, 8), 128, 64));
            bodyPartList.Add(new BodyPart("TorsoFront0", (System.Windows.Controls.Image)TorsoFront0ImageBox.Content, new Point(231, 74), 128, 96));
            bodyPartList.Add(new BodyPart("TorsoFront1", (System.Windows.Controls.Image)TorsoFront1ImageBox.Content, new Point(231, 171), 128, 31));
            bodyPartList.Add(new BodyPart("TorsoDown", (System.Windows.Controls.Image)TorsoDownImageBox.Content, new Point(231, 204), 128, 64));
            bodyPartList.Add(new BodyPart("TorsoL0", (System.Windows.Controls.Image)TorsoL0ImageBox.Content, new Point(361, 74), 64, 96));
            bodyPartList.Add(new BodyPart("TorsoL1", (System.Windows.Controls.Image)TorsoL1ImageBox.Content, new Point(361, 171), 64, 31));
            bodyPartList.Add(new BodyPart("TorsoBack0", (System.Windows.Controls.Image)TorsoBack0ImageBox.Content, new Point(427, 74), 128, 96));
            bodyPartList.Add(new BodyPart("TorsoBack1", (System.Windows.Controls.Image)TorsoBack1ImageBox.Content, new Point(427, 171), 128, 31));

            bodyPartList.Add(new BodyPart("RightLimbL0", (System.Windows.Controls.Image)RightLimbL0ImageBox.Content, new Point(19, 355), 64, 52));
            bodyPartList.Add(new BodyPart("RightLimbL1", (System.Windows.Controls.Image)RightLimbL1ImageBox.Content, new Point(19, 408), 64, 38));
            bodyPartList.Add(new BodyPart("RightLimbL2", (System.Windows.Controls.Image)RightLimbL2ImageBox.Content, new Point(19, 447), 64, 36));
            bodyPartList.Add(new BodyPart("RightLimbB0", (System.Windows.Controls.Image)RightLimbB0ImageBox.Content, new Point(85, 355), 64, 52));
            bodyPartList.Add(new BodyPart("RightLimbB1", (System.Windows.Controls.Image)RightLimbB1ImageBox.Content, new Point(85, 408), 64, 38));
            bodyPartList.Add(new BodyPart("RightLimbB2", (System.Windows.Controls.Image)RightLimbB2ImageBox.Content, new Point(85, 447), 64, 36));
            bodyPartList.Add(new BodyPart("RightLimbR0", (System.Windows.Controls.Image)RightLimbR0ImageBox.Content, new Point(151, 355), 64, 52));
            bodyPartList.Add(new BodyPart("RightLimbR1", (System.Windows.Controls.Image)RightLimbR1ImageBox.Content, new Point(151, 408), 64, 38));
            bodyPartList.Add(new BodyPart("RightLimbR2", (System.Windows.Controls.Image)RightLimbR2ImageBox.Content, new Point(151, 447), 64, 36));
            bodyPartList.Add(new BodyPart("RightLimbU", (System.Windows.Controls.Image)RightLimbUImageBox.Content, new Point(217, 289), 64, 64));
            bodyPartList.Add(new BodyPart("RightLimbF0", (System.Windows.Controls.Image)RightLimbF0ImageBox.Content, new Point(217, 355), 64, 52));
            bodyPartList.Add(new BodyPart("RightLimbF1", (System.Windows.Controls.Image)RightLimbF1ImageBox.Content, new Point(217, 408), 64, 38));
            bodyPartList.Add(new BodyPart("RightLimbF2", (System.Windows.Controls.Image)RightLimbF2ImageBox.Content, new Point(217, 447), 64, 36));
            bodyPartList.Add(new BodyPart("RightLimbD", (System.Windows.Controls.Image)RightLimbDImageBox.Content, new Point(217, 485), 64, 64));

            bodyPartList.Add(new BodyPart("LeftLimbU", (System.Windows.Controls.Image)LeftLimbUImageBox.Content, new Point(308, 289), 64, 64));
            bodyPartList.Add(new BodyPart("LeftLimbF0", (System.Windows.Controls.Image)LeftLimbF0ImageBox.Content, new Point(308, 355), 64, 52));
            bodyPartList.Add(new BodyPart("LeftLimbF1", (System.Windows.Controls.Image)LeftLimbF1ImageBox.Content, new Point(308, 408), 64, 38));
            bodyPartList.Add(new BodyPart("LeftLimbF2", (System.Windows.Controls.Image)LeftLimbF2ImageBox.Content, new Point(308, 447), 64, 36));
            bodyPartList.Add(new BodyPart("LeftLimbD", (System.Windows.Controls.Image)LeftLimbDImageBox.Content, new Point(308, 485), 64, 64));
            bodyPartList.Add(new BodyPart("LeftLimbL0", (System.Windows.Controls.Image)LeftLimbL0ImageBox.Content, new Point(374, 355), 64, 52));
            bodyPartList.Add(new BodyPart("LeftLimbL1", (System.Windows.Controls.Image)LeftLimbL1ImageBox.Content, new Point(374, 408), 64, 38));
            bodyPartList.Add(new BodyPart("LeftLimbL2", (System.Windows.Controls.Image)LeftLimbL2ImageBox.Content, new Point(374, 447), 64, 36));
            bodyPartList.Add(new BodyPart("LeftLimbB0", (System.Windows.Controls.Image)LeftLimbB0ImageBox.Content, new Point(440, 355), 64, 52));
            bodyPartList.Add(new BodyPart("LeftLimbB1", (System.Windows.Controls.Image)LeftLimbB1ImageBox.Content, new Point(440, 408), 64, 38));
            bodyPartList.Add(new BodyPart("LeftLimbB2", (System.Windows.Controls.Image)LeftLimbB2ImageBox.Content, new Point(440, 447), 64, 36));
            bodyPartList.Add(new BodyPart("LeftLimbR0", (System.Windows.Controls.Image)LeftLimbR0ImageBox.Content, new Point(506, 355), 64, 52));
            bodyPartList.Add(new BodyPart("LeftLimbR1", (System.Windows.Controls.Image)LeftLimbR1ImageBox.Content, new Point(506, 408), 64, 38));
            bodyPartList.Add(new BodyPart("LeftLimbR2", (System.Windows.Controls.Image)LeftLimbR2ImageBox.Content, new Point(506, 447), 64, 36));
        }

        private void R6Button_Click(object sender, RoutedEventArgs e)
        {
            R15Button.IsChecked = false;

            clothingVersion = 6;
        }

        private void R15Button_Click(object sender, RoutedEventArgs e)
        {
            R6Button.IsChecked = false;

            clothingVersion = 15;
        }

        private void ShirtButton_Click(object sender, RoutedEventArgs e)
        {
            PantsButton.IsChecked = false;

            clothingType = Clothing.ClothingType.Shirt;
        }

        private void PantsButton_Click(object sender, RoutedEventArgs e)
        {
            ShirtButton.IsChecked = false;

            clothingType = Clothing.ClothingType.Pants;
        }

        private void SetImageInImageBox(object sender, RoutedEventArgs e)
        {
            Button imageBox = (Button)e.Source;
            System.Windows.Controls.Image content = (System.Windows.Controls.Image)imageBox.Content;

            //content.Source = new BitmapImage(new Uri("Resources/torso_r1.png", UriKind.Relative));

            //initialize openfiledialog
            OpenFileDialog dlg;

            dlg = new OpenFileDialog();
            dlg.Filter = FileGrabber.GetImageFilter();

            if (dlg.ShowDialog() == true)
            {
                ImageVerifier imgVerifier = new ImageVerifier(dlg.FileName);
                string errorMsg = imgVerifier.IsValid();
                if (errorMsg != null) {
                    MessageBox.Show(errorMsg);
                }
                else {
                    ImageFixer imagefixer = new ImageFixer(new Bitmap(dlg.FileName), (int)content.MinWidth, (int)content.MinHeight);
                    Bitmap fixedImage = imagefixer.FixImage();
                    content.Source = ImageConversion.ConvertBitmapToBitmapImageSource(fixedImage, (int)content.MinWidth, (int)content.MinHeight);
                }
            }

            //call FileGrabber
            //var obj = FileGrabber();

            //send obj to ImageVerifier
            //int code = ImageVerifier(obj)

            //if image (0) send to ImageFixer


            //if image and not 8-bit (1)

            //if not image (-1)
            //raise exception
        }

        private void CreateShirtButton_Click(object sender, RoutedEventArgs e)
        {
            //initialize clothing object
            clothingName = ClothingNameTextBox.Text;

            clothing = new Clothing(clothingVersion, clothingType, clothingName, bodyPartList);

            ClothingMaker clothingMaker = new ClothingMaker(clothing);
            
            //displays the either the error message or the success message
            MessageBox.Show(clothingMaker.SaveImageToHardDrive());
        }
    }
}
