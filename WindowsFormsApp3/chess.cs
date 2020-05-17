using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    abstract class Chess : PictureBox
    {
        public static readonly int ChessSize = 66;

        public Chess(Point pos)
        {
            this.BackColor = Color.Transparent; 
            this.Size = new Size(ChessSize, ChessSize);
            this.Location = new Point(pos.X , pos.Y);
        }

        


        public void MoveTo(Point pos)
        {
            this.Location = new Point(ChessImage_View.X_OFFSET+ChessImage_View.Radius*pos.X,ChessImage_View.Y_OFFSET+ChessImage_View.Radius*pos.Y);
        }

        public abstract void ChangeState();
        public abstract bool GetState();
        public abstract bool CanEatOrNot();
        public abstract void ChangeEatMode();
    }
}
