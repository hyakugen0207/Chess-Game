using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class PawnChangeJob : UserControl
    {
        public PawnChangeJob()
        {
            InitializeComponent();
        }

        private void PawnChangeJob_Load(object sender, EventArgs e)
        {
            CHOOSEQUEEN.MouseClick += new MouseEventHandler(ClickQueen);
            CHOOSEKNIGHT.MouseClick += new MouseEventHandler(ClickKnight);
            CHOOSEROOK.MouseClick += new MouseEventHandler(ClickRook);
            CHOOSEBISHOP.MouseClick += new MouseEventHandler(ClickBishop);
            this.Controls.Add(CHOOSEQUEEN);
            this.Controls.Add(CHOOSEKNIGHT);
            this.Controls.Add(CHOOSEROOK);
            this.Controls.Add(CHOOSEBISHOP);
        }

        public delegate void BtnClickDelegate(object sender, EventArgs e,int a); // 自定一個委派
        public event BtnClickDelegate Click_Delegate; //使用此委派宣告event

        private void ClickQueen(object sender, MouseEventArgs e)
        {
            Click_Delegate(sender, e,0);
        }
        private void ClickKnight(object sender, MouseEventArgs e)
        {
            Click_Delegate(sender, e,1);
        }
        private void ClickRook(object sender, MouseEventArgs e)
        {
            Click_Delegate(sender, e,2);
        }
        private void ClickBishop(object sender, MouseEventArgs e)
        {
            Click_Delegate(sender, e,3);
        }

        private static readonly Chess CHOOSEQUEEN = new Queen(ChessColor.BLACK, new Point(10,15));
        private static readonly Chess CHOOSEKNIGHT = new Knight(ChessColor.BLACK, new Point(80, 15));
        private static readonly Chess CHOOSEROOK = new Rook(ChessColor.BLACK, new Point(150, 15));
        private static readonly Chess CHOOSEBISHOP = new Bishop(ChessColor.BLACK, new Point(220, 15));
    }
}
