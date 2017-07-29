using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RobloxShirtMaker
{
    class BodyPart
    {
        //private BitmapImage bodyImage;
        private string sectionID;

        private Point topLeftPoint;
        private Point topRightPoint;
        private Point bottomRightPoint;
        private Point bottomLeftPoint;

        private System.Windows.Controls.Image uiImageBox;

        //public BitmapImage BodyImage { get => bodyImage; set => bodyImage = value; }
        public System.Windows.Controls.Image UiImageBox { get => uiImageBox; set => uiImageBox = value; }
        public Point TopLeftPoint { get => topLeftPoint; set => topLeftPoint = value; }
        internal Point TopRightPoint { get => topRightPoint; set => topRightPoint = value; }
        internal Point BottomRightPoint { get => bottomRightPoint; set => bottomRightPoint = value; }
        internal Point BottomLeftPoint { get => bottomLeftPoint; set => bottomLeftPoint = value; }
        public string SectionID { get => sectionID; set => sectionID = value; }

        //public System.Windows.Controls.Image UiImageBox { get => uiImageBox; set => uiImageBox = value; }

        public BodyPart() {
            this.sectionID = "bodypart";
        }

        public BodyPart(string sectionID,  Point topLeftPoint, Point topRightPoint, Point bottomRightPoint, Point bottomLeftPoint)
        {
            this.sectionID = sectionID;

            this.topLeftPoint = topLeftPoint;
            this.topRightPoint = topRightPoint;
            this.bottomRightPoint = bottomRightPoint;
            this.bottomLeftPoint = bottomLeftPoint;
        }

        public BodyPart(string sectionID, System.Windows.Controls.Image uiImageBox, Point topLeftPoint, int bodyPartWidth, int bodyPartHeight)
        {
            this.sectionID = sectionID;
            this.uiImageBox = uiImageBox;
 
            this.topLeftPoint = topLeftPoint;
            topRightPoint = new Point(topLeftPoint.xPoint + bodyPartWidth, topLeftPoint.yPoint);
            bottomRightPoint = new Point(topLeftPoint.xPoint + bodyPartWidth, topLeftPoint.yPoint - bodyPartHeight);
            bottomLeftPoint = new Point(topLeftPoint.xPoint, topLeftPoint.yPoint - bodyPartHeight);
        }
    }
}
