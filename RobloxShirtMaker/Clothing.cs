using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace RobloxShirtMaker
{
    class Clothing
    {
        private string name;
        private int version;
        private ClothingType type;

        public enum ClothingType
        {
            Shirt,
            Pants
        }
        private static Dictionary<ClothingType, Bitmap> clothingTypeDictionary;

        private Bitmap templateImage;
        private ArrayList bodyPartList;

        public Clothing(int version, ClothingType type, string name, ArrayList bodyPartList) {
            this.version = version;
            this.type = type;
            this.name = name;

            clothingTypeDictionary = new Dictionary<ClothingType, Bitmap>();

            clothingTypeDictionary.Add(ClothingType.Shirt, new Bitmap(Properties.Resources.Template_Shirts_R15_04192017));
            clothingTypeDictionary.Add(ClothingType.Pants, new Bitmap(Properties.Resources.Template_Pants_R15_04192017));

            templateImage = clothingTypeDictionary[type];

            this.bodyPartList = bodyPartList;

           // bodyParts = new Dictionary<int, BitmapImage>();
        }

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public Bitmap TemplateImage { get => templateImage; set => templateImage = value; }
        public ArrayList BodyPartList { get => bodyPartList; set => bodyPartList = value; }
        internal ClothingType Type { get => type; set => type = value; }
        public int Version { get => version; set => version = value; }
    }
}
