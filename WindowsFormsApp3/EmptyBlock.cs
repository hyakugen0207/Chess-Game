using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class EmptyBlock : CColor
    {
        public EmptyBlock(Point pos): base(ChessColor.NONE,pos)
        {
            this.BackColor = Color.FromArgb(255, 47, 78, 78);
        }
    }
}
