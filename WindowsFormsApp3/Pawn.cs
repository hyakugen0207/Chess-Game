using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class Pawn : CColor
    {
        private Image ResizedImage;
        public Pawn(ChessColor x, Point pos) : base(x, pos)
        {
            if (GetColor() == ChessColor.BLACK)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.black_pawn, newSize);
                this.BackgroundImage = ResizedImage;
            }
            else if (GetColor() == ChessColor.WHITE)
            {
                Size newSize = new Size(ChessSize, ChessSize);
                ResizedImage = new Bitmap(Properties.Resources.white_pawn, newSize);
                this.BackgroundImage = ResizedImage;
            }
        }
    }
}

