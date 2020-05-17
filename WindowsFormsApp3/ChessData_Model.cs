using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    enum ChessName
    {
        NONE,KING,QUEEN,BISHOP,KNIGHT,ROOK,PAWN
    }


    class ChessData_Model
    {
        //white 0 = NONE,  1 = KING,  2 = QUEEN, 3,4 = BISHOP, 5,6 = KNIGHT, 7,8 = ROOK, 9-16 = PAWN
        //black 0 = NONE,  41 = KING,  42 = QUEEN, 43,44 = BISHOP, 45,46 = KNIGHT, 47,48 = ROOK, 49-56 = PAWN
        public int[,] myboard = new int[,] {
            {47,49,0,0,0,0,9,7},
            {45,50,0,0,0,0,10,5},
            {43,51,0,0,0,0,11,3},
            {42,52,0,0,0,0,12,2},
            {41,53,0,0,0,0,13,1},
            {44,54,0,0,0,0,14,4},
            {46,55,0,0,0,0,15,6},
            {48,56,0,0,0,0,16,8} };

        public List<Chess> canMoveBlock = new List<Chess>();

        private int player_x_Win = 2;


        public void ChessMove(Point x,Point y)
        {
            if (myboard[x.X, x.Y] == 1) player_x_Win = 1;
            if (myboard[x.X, x.Y] == 41) player_x_Win = 0;
            myboard[x.X, x.Y] = myboard[y.X, y.Y];
            myboard[y.X, y.Y] = 0;
        }

        public int WinOrNot()
        {
            return player_x_Win;
        }

        // 判斷是否選擇自己的棋  若不是自己的棋則return 0  其餘 return棋子的編號
        public int ThisIsPlayersChess(Point pos,bool player)
        {
                if (player == true) // black
                {
                    if (myboard[pos.X, pos.Y] > 40) return myboard[pos.X, pos.Y];
                }
                else  if(player == false)// white
                {
                    if (myboard[pos.X, pos.Y] <= 16) return myboard[pos.X, pos.Y];
                }
                return 0;
        }

        //取得選擇位置棋子的資訊
        public int PlayersChessIndex(Point pos)
        {
                return myboard[pos.X, pos.Y];
        }

        //開新遊戲
        public void Reset()
        {
            player_x_Win = 2;
            myboard = new int[,] {
            {47,49,0,0,0,0,9,7},
            {45,50,0,0,0,0,10,5},
            {43,51,0,0,0,0,11,3},
            {42,52,0,0,0,0,12,2},
            {41,53,0,0,0,0,13,1},
            {44,54,0,0,0,0,14,4},
            {46,55,0,0,0,0,15,6},
            {48,56,0,0,0,0,16,8} };
        }
    }
}
