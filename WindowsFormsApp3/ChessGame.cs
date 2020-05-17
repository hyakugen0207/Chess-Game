using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class ChessGame : Form
    {
        public int playerWhiteWinCount = 0;
        public int playerBlackWinCount = 0;
        
        

        public ChessGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chessboard1.ChangePlayerRound += new Chessboard.Delegate2(ChangePlayerRoundToShow); //加入事件委派函式 (玩家交換)
            pawnChangeJob1.Click_Delegate += new PawnChangeJob.BtnClickDelegate(ChoosePawnTo); //加入事件委派函式 (兵的升變2)
            chessboard1.ChangePawnJob += new Chessboard.Delegate(PawnJobDelegate); //加入事件委派函式 (兵的升變1)
            chessboard1.PlayerWin += new Chessboard.UserWinToForm(ShowPlayerWin);


            this.BackColor = Color.FromArgb(255, 119, 86, 74); 
            this.Controls.Remove(pawnChangeJob1); // 關閉升變選單
        }

      

        //------------玩家輪流-------------//

        private bool playerBlackToMove = true;

        private void ChangePlayerRoundToShow()
        {
            //顯示換玩家
            if(playerBlackToMove)
            {
                UserRoundLabel.Text = "輪到玩家[黑]";
            }
            else
            {
                UserRoundLabel.Text = "輪到玩家[白]";
            }
            playerBlackToMove = !playerBlackToMove;
        }


        //--------------------------兵的升變 Delegate -----------------------------//

        private int Job = -1;
        private int Index = -1;
            //----開啟選單 並紀錄目前升變的棋----//
        private void PawnJobDelegate(int index)
        {
            this.Controls.Add(pawnChangeJob1); //開啟升變選單
            this.Controls.Remove(chessboard1); //關閉棋盤
            Index = index;
        }

            //----將升變選單的選擇傳給棋盤----//
        private void ChoosePawnTo(object sender, EventArgs e, int a)
        {
            // 0 = Queen  1 = Knight  2 = Rook  3 = Bishop
            if (a == 0)
            {
                Job = 0;
            }
            else if (a == 1)
            {
                Job = 1;
            }
            else if (a == 2)
            {
                Job = 2;
            }
            else if (a == 3)
            {
                Job = 3;
            }
            this.Controls.Remove(pawnChangeJob1); //關閉升變選單
            this.Controls.Add(chessboard1);  //開啟起盤
            chessboard1.PawnExchangeJobNext(Index, Job); //將升變資訊傳回棋盤
        }

         //------------玩家勝利---------------//

        private void ShowPlayerWin(bool user)
        {
            if(user) //black
            {
                MessageBox.Show("黑棋勝利！");
                ++playerBlackWinCount;
                BlackWinLabel.Text = $"玩家黑：{playerBlackWinCount}勝";
                
            }
            else  //white
            {
                MessageBox.Show("白棋勝利！");
                ++playerWhiteWinCount;
                WhiteWinLabel.Text = $"玩家白：{playerWhiteWinCount}勝";
            }
            if (MessageBox.Show("再來一局?", "Published by Shiro.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                playerBlackToMove = false;
                UserRoundLabel.Text = "輪到玩家[白]";
                chessboard1.SetNewGame();
            }
            else
            {
                MessageBox.Show("掰掰!", "Published by Shiro.");
                Application.Exit();
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chessboard1_Load(object sender, EventArgs e)
        {

        }

        private void chessboard1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pawnChangeJob1_Load(object sender, EventArgs e)
        {

        }
    }
}
