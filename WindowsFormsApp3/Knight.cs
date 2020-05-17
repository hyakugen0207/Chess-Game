using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class Knight : CColor
    {
        private Image ResizedImage;
        public Knight(ChessColor x, Point pos) : base(x, pos)
        {
            if (GetColor() == ChessColor.BLACK)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.black_knight, newSize);
                this.BackgroundImage = ResizedImage;
            }
            else if (GetColor() == ChessColor.WHITE)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.white_knight, newSize);
                this.BackgroundImage = ResizedImage;
            }
        }


    }
}
