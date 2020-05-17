using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class SelectBoard : PictureBox
    {
        public static readonly int ChessSize = 66;

        public SelectBoard(Point pos)
        {
            this.BackColor = Color.Chocolate;
            this.Size = new Size(ChessSize, ChessSize);
            this.Location = new Point(pos.X, pos.Y);
        }
    }
}
