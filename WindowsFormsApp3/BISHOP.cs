using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class Bishop : CColor
    {
        
        private Image ResizedImage;
        public Bishop(ChessColor x, Point pos) : base(x, pos)
        {
            if (GetColor() == ChessColor.BLACK)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.black_bishop, newSize);
                this.BackgroundImage = ResizedImage;
            }
            else if (GetColor() == ChessColor.WHITE)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.white_bishop, newSize);
                this.BackgroundImage = ResizedImage;
            }
        }
    }
}