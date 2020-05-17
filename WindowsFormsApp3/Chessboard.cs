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
    public partial class Chessboard : UserControl
    {
        private ChessImage_View ChessImage;  // 建立棋子 View
        ChessData_Model ChessData;  // 建立棋子 Model
        SelectHandler SelectHelper;   // 建立選擇棋子時的 Controler  (連接 View . Model)
        private bool player; // false = white   true = black  




        public delegate void Delegate2(); // 自定一個委派 (玩家交換)
        public event Delegate2 ChangePlayerRound; //使用此委派宣告event (玩家交換)




        //-----------------------------------初始化棋盤------------------------------------//
        public Chessboard()
        {
            InitializeComponent();
        }

        private void chessboard_Load(object sender, EventArgs e)
        {
            ChessImage = new ChessImage_View();
            ChessData = new ChessData_Model();
            SelectHelper = new SelectHandler();
            player = false;
            for (int i = 1; i < ChessImage.mychsee.Length; ++i)
            {
                //將棋子加入棋盤
                this.Controls.Add(ChessImage.mychsee[i]);
                //建立Click事件
                ChessImage.mychsee[i].MouseClick += new MouseEventHandler(ChessClick);
            }
            //建立空白格
            for (int i = 1; i < ChessImage.emptyBlock.Length; ++i)
            {
                //建立Click事件
                ChessImage.emptyBlock[i].MouseClick += new MouseEventHandler(EmptyClick);
            }
        }

//-----------------------------------Click事件內容------------------------------------//

        // 選到可移動空格  (缺移除其他變色格)
        private void EmptyClick(object sender, MouseEventArgs e)
        {
            //取消王車易位功能
            int forKingRook = ChessData.PlayersChessIndex(SelectHelper.GetPosition());
            if (forKingRook == 1 || forKingRook == 41 || forKingRook == 47 || forKingRook == 48 || forKingRook == 7 || forKingRook == 8) { ChessImage.pawnChangeJob[forKingRook] = -2; }
            //獲取View座標
            int x = (int)((Chess)sender).Location.X;
            int y = (int)((Chess)sender).Location.Y;
            //轉成Data座標
            Point pos = GetDataPoint(x, y);
            Chess SelectedChess = SelectHelper.GetSelectName(); // 取得之前選的Chess內容
            SelectedChess.MoveTo(pos); // 換位置 View
            SelectedChess.ChangeState(); //變色
            ChessData.ChessMove(pos, SelectHelper.GetPosition()); // 換位置+刪除 DATA
            SelectHelper.ChangeSelectedMode(); //換回沒有東西被選的狀態
            player = !player;//換玩家
            ReleaseCanMoveBlock();
            ChangePlayerRound(); //將user資料傳回Form
            ConditionOfPawnExchangeJob(pos);//兵的升變
        }


        //選到自己的棋子 or 敵人棋子 (缺可移動位置判斷) / (缺移除其他變色格)
        private void ChessClick(object sender, MouseEventArgs e)
        {
            //獲取View座標
            int x = (int)((Chess)sender).Location.X;
            int y = (int)((Chess)sender).Location.Y;
            //轉成Data座標
            Point pos = GetDataPoint(x, y);
            //判斷該座標是否為自己的棋子
            int index = ChessData.ThisIsPlayersChess(pos, player);  // <-判斷式
            if (index != 0)  //  <- 通過判斷 選的是自己的棋
            {
                Chess name = ChessImage.GetChessName(index); // 取得 Chess的 ref.
                if (SelectHelper.GetSelectState()) // 在此之前已經選了自己的棋子(換棋or取消現在選取)
                {
                    Chess recolor = SelectHelper.GetSelectName(); // 取得之前選的Chess內容
                    recolor.ChangeState(); // 將之前選的棋改為未選取(View)
                    SelectHelper.ChangeSelectedMode(); //改為未選取模式
                    if (name.CanEatOrNot())
                    {
                        MessageBox.Show("王車易位");
                        SpecialKingRookMove(recolor, name, index);
                        //取消王車易位功能
                        int forKingRook = ChessData.PlayersChessIndex(SelectHelper.GetPosition());
                        if (forKingRook == 1 || forKingRook == 41) { ChessImage.pawnChangeJob[forKingRook] = -2; }
                        return;
                    }
                    ReleaseCanMoveBlock(); // 將ChessData的 CanMoveTo清掉
                    if (name == recolor) return; // 取消現在選取
                }
                if (index == 1 || index == 41) KingRookSpecialRule(player); // 王車易位
                WhereCanMove(index, pos); //判斷哪裡可走
                SelectHelper.ChangeSelectedMode();  // 將模式轉為已選取
                SelectHelper.SetSelectedName(name); //紀錄選到的物件名稱
                name.ChangeState(); //變色
                SelectHelper.SetSelectedPos(pos.X, pos.Y);  // 紀錄選到的棋子的Data座標
            }
            else if (SelectHelper.GetSelectState())   // 選的是敵人的棋 (吃子) 
            {
                int kuwareru = ChessData.PlayersChessIndex(pos);//獲取被吃的子的資訊
                Chess kuwareruName = ChessImage.GetChessName(kuwareru);
                if (kuwareruName.CanEatOrNot()) // 看那個棋子是否可被吃
                {
                    this.Controls.Remove(kuwareruName); //刪除 UI
                    Chess name = SelectHelper.GetSelectName(); // 取得選擇物的名字
                    int forKingRook = ChessData.PlayersChessIndex(SelectHelper.GetPosition()); //取消王車易位功能
                    if(forKingRook == 1 || forKingRook == 41 || forKingRook == 47 || forKingRook == 48 || forKingRook == 7 || forKingRook == 8) { ChessImage.pawnChangeJob[forKingRook] = -2; }
                    name.MoveTo(pos); // 換位置 UI
                    ChessData.ChessMove(pos, SelectHelper.GetPosition()); // 換位置+刪除 DATA
                    name.ChangeState(); // 變色
                    SelectHelper.ChangeSelectedMode(); //換回沒有東西被選的狀態
                    player = !player;//換玩家
                    ReleaseCanMoveBlock();
                    ChangePlayerRound(); //將user資料傳回Form
                    ConditionOfPawnExchangeJob(pos);//兵的升變
                    WhoWin(ChessData.WinOrNot());
                }
            }
        }

//--------------------------------------取得Data座標----------------------------------//
        public Point GetDataPoint(int x,int y)
        {
            //找array座標
            int pos_x = x - ChessImage_View.X_OFFSET;
            int pos_y = y - ChessImage_View.Y_OFFSET;
            int index_x = pos_x / ChessImage_View.Radius;
            int index_y = pos_y / ChessImage_View.Radius;
            return new Point(index_x, index_y);
        }

//--------------------------------------消除目前的狀況----------------------------------//
        public void ReleaseCanMoveBlock()
        {
            for (int i = 0;i < ChessData.canMoveBlock.Count; ++i)
            {
                if (ChessData.canMoveBlock[i].BackColor == Color.FromArgb(255, 47, 78, 78)) 
                {
                    this.Controls.Remove(ChessData.canMoveBlock[i]);
                }
                else
                {
                    ChessData.canMoveBlock[i].ChangeState();
                    ChessData.canMoveBlock[i].ChangeEatMode();
                }
            }
            ChessData.canMoveBlock.Clear();
        }

//--------------------------判斷被選的棋子哪裡可以移動------------------------------------------------//

        public void WhereCanMove(int i, Point pos)
        {
            switch (i)
            {
                // KING WALK
                case 1:
                case 41:
                    for (int x = -1; x < 2; ++x)
                    {
                        for (int y = -1; y < 2; ++y)
                        {
                            if(pos.X + x >= 0 && pos.X + x <= 7 && pos.Y + y >=0 && pos.Y + y <= 7)
                            {
                                CompareWhereCanGo(pos, x, y);
                            }
                        }
                    }
                    break;
                // Queen Walk
                case 2:
                case 42:
                    Cross(pos); // 上下左右                
                    Slash(pos); //斜角
                    break;
                //Knight Walk
                case 5:
                case 6:
                case 45:
                case 46:
                    if(pos.X + 2 <= 7)
                    {
                        if (pos.Y + 1 <= 7) CompareWhereCanGo(pos, 2, 1);
                        if (pos.Y - 1 >= 0) CompareWhereCanGo(pos, 2, -1);
                    }
                    if (pos.X - 2 >= 0)
                    {
                        if (pos.Y + 1 <= 7) CompareWhereCanGo(pos, -2, 1);
                        if (pos.Y - 1 >= 0) CompareWhereCanGo(pos, -2, -1);
                    }
                    if (pos.Y + 2 <= 7)
                    {
                        if (pos.X + 1 <= 7) CompareWhereCanGo(pos, 1, 2);
                        if (pos.X - 1 >= 0) CompareWhereCanGo(pos, -1, 2);
                    }
                    if (pos.Y - 2 >= 0)
                    {
                        if (pos.X + 1 <= 7) CompareWhereCanGo(pos, 1, -2);
                        if (pos.X - 1 >= 0) CompareWhereCanGo(pos, -1, -2);
                    }
                    break;
                //Bishop Walk
                case 3:
                case 4:
                case 43:
                case 44:
                    Slash(pos);
                    break;
                //Rook Walk
                case 7:
                case 8:
                case 47:
                case 48:
                    Cross(pos);
                    break;
                //White Pawn
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    if (pawnJobCheck(i,pos)) break;  //判斷兵是否已升變
                    if(CompareWhereCanGoForPawn(pos, -1))
                    {
                        if (pos.Y == 6)
                        {
                            CompareWhereCanGoForPawn(pos, -2);
                        }
                    }
                    break;
                //Black Pawn
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                    if (pawnJobCheck(i, pos)) break;  //判斷兵是否已升變
                    if (CompareWhereCanGoForPawn(pos, 1))
                    {
                        if (pos.Y == 1)
                        {
                            CompareWhereCanGoForPawn(pos, 2);
                        }
                    }
                    break;
            }

        }
        //上下左右
        private void Cross(Point pos)
        {
            for (int x = -1; x >= -7; --x)
            {
                if (pos.X + x < 0 || !CompareWhereCanGo(pos, x, 0)) break;
            }
            for (int x = 1; x <= 7; ++x)
            {
                if (pos.X + x > 7 || !CompareWhereCanGo(pos, x, 0)) break;
            }
            for (int y = 1; y <= 7; ++y)
            {
                if (pos.Y + y > 7 || !CompareWhereCanGo(pos, 0, y)) break;
            }
            for (int y = -1; y >= -7; --y)
            {
                if (pos.Y + y < 0 || !CompareWhereCanGo(pos, 0, y)) break;
            }
            return;
        }
        //斜角
        private void Slash(Point pos)
        {
            for (int x = 1; x <= 7; ++x)
            {
                if (pos.X + x > 7 || pos.Y + x > 7 || !CompareWhereCanGo(pos, x, x)) break;
            }
            for (int x = -1; x >= -7; --x)
            {
                if (pos.X + x < 0 || pos.Y + x < 0 || !CompareWhereCanGo(pos, x, x)) break;
            }
            for (int x = 1; x <= 7; ++x)
            {
                if (pos.X + x > 7 || pos.Y - x < 0 || !CompareWhereCanGo(pos, x, -x)) break;
            }
            for (int x = -1; x >= -7; --x)
            {
                if (pos.X + x < 0 || pos.Y - x > 7 || !CompareWhereCanGo(pos, x, -x)) break;
            }
            return;
        }

        private bool CompareWhereCanGo(Point pos,int x,int y)
        {
            
            if (ChessData.myboard[pos.X + x, pos.Y + y] == 0)
            {
                //emptyblock
                Chess irokaeruName = ChessImage.GetBlockName(pos.X + x, pos.Y + y);
                this.Controls.Add(irokaeruName);
                ChessData.canMoveBlock.Add(irokaeruName);
                return true;
            }
            else if (Math.Abs(ChessData.myboard[pos.X + x, pos.Y + y] - ChessData.myboard[pos.X, pos.Y]) > 20)
            {
                int index = ChessData.PlayersChessIndex(new Point(pos.X+x,pos.Y+y));
                Chess irokaeruName = ChessImage.GetChessName(index);
                //有棋子
                //獲取被吃的子的資訊
                if (!irokaeruName.CanEatOrNot())
                {
                    irokaeruName.ChangeState();
                    irokaeruName.ChangeEatMode();
                }
                ChessData.canMoveBlock.Add(irokaeruName);
                return false;
            }
            else
                return false;
        }

        private bool CompareWhereCanGoForPawn(Point pos,int y)
        {
            if (y == 1 || y == -1)
            {
                //有棋子
                //獲取被吃的子的資訊
                if (pos.X + 1 <= 7 && ChessData.myboard[pos.X + 1, pos.Y + y] != 0 && Math.Abs(ChessData.myboard[pos.X + 1, pos.Y + y] - ChessData.myboard[pos.X, pos.Y]) > 20)
                {
                    Chess irokaeruName = ChessImage.GetChessName(ChessData.myboard[pos.X + 1, pos.Y + y]);
                    if (!irokaeruName.CanEatOrNot())
                    {
                        irokaeruName.ChangeState();
                        irokaeruName.ChangeEatMode();
                    }
                    ChessData.canMoveBlock.Add(irokaeruName);
                }

                if (pos.X - 1 >= 0 && ChessData.myboard[pos.X - 1, pos.Y + y] != 0 && Math.Abs(ChessData.myboard[pos.X - 1, pos.Y + y] - ChessData.myboard[pos.X, pos.Y]) > 20)
                {
                    Chess irokaeruName = ChessImage.GetChessName(ChessData.myboard[pos.X - 1, pos.Y + y]);
                    if (!irokaeruName.CanEatOrNot())
                    {
                        irokaeruName.ChangeState();
                        irokaeruName.ChangeEatMode();
                    }
                    ChessData.canMoveBlock.Add(irokaeruName);
                }
            }

            if (ChessData.myboard[pos.X, pos.Y + y] == 0)
            {
                //emptyblock
                Chess irokaeruName = ChessImage.GetBlockName(pos.X, pos.Y + y);
                this.Controls.Add(irokaeruName);
                ChessData.canMoveBlock.Add(irokaeruName);
                return true;
            }
            else
            {
                return false;
            }
            
                
        }
        //-------------------------------------------特殊規則-----------------------------------------//

        //-------------------王車易位-------------------// (借用pawnJob的轉職array判斷)
        
        private void KingRookSpecialRule(bool player)
        {
            if(player && ChessImage.pawnChangeJob[41] == -1) // black
            {
                if (ChessImage.pawnChangeJob[47] == -1) KingRookSpecialRuleBetween(new Point(4,0), new Point(0, 0));
                
                if (ChessImage.pawnChangeJob[48] == -1) KingRookSpecialRuleBetween(new Point(4, 0), new Point(7, 0));
            }
            else if(ChessImage.pawnChangeJob[1] == -1) // white
            {
                if (ChessImage.pawnChangeJob[7] == -1) KingRookSpecialRuleBetween(new Point(4, 7), new Point(0, 7));

                if (ChessImage.pawnChangeJob[8] == -1) KingRookSpecialRuleBetween(new Point(4, 7), new Point(7, 7));
            }
        }

        
        private void KingRookSpecialRuleBetween(Point king, Point rook)
        {
            if(king.X>rook.X) // 長易位
            {
                for(int i=rook.X+1; i< king.X; ++i) // 判斷是否中間有其他棋子 
                {
                    if (ChessData.myboard[i, rook.Y] != 0) return;  // 中間有東西 失敗
                }
                for(int i = king.X; i > king.X-3; --i) // 判斷王的位子與路上是否受到攻擊
                {
                    if (CheckBeAttack(i,king.Y)) return;
                }
            }
            else // 短易位
            {
                for (int i = king.X + 1; i < rook.X; ++i)
                {
                    if (ChessData.myboard[i, rook.Y] != 0) return; // 中間有東西 失敗
                }
                for (int i = king.X; i < king.X + 3; ++i) // 判斷王的位子與路上是否受到攻擊
                {
                    if (CheckBeAttack(i, king.Y)) return;
                }
            }

            // 通過判斷
            int index = ChessData.PlayersChessIndex(rook);
            Chess irokaeruName = ChessImage.GetChessName(index);
            if (!irokaeruName.CanEatOrNot())
            {
                irokaeruName.ChangeState();
                irokaeruName.ChangeEatMode();
            }
            ChessData.canMoveBlock.Add(irokaeruName);
        }

        //BUG  缺判斷升變後的棋子
        private bool CheckBeAttack(int x, int y)
        {
            if(y==0) // black
            {
                //King
                if (ChessData.myboard[x + 1, y] == 1) return true;
                if (ChessData.myboard[x - 1, y] == 1) return true;
                for(int i=x-1; i<=x+1; ++i) if (ChessData.myboard[i, y+1] == 1) return true;
                //Queen & Rook
                for (int i = 0; i <= 7; ++i)
                {
                    if (ChessData.myboard[i, y] == 2 || ChessData.myboard[i, y] == 7 || ChessData.myboard[i, y] == 8) return true;
                    if (ChessData.myboard[i, y]!=0 && i!=x && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20 )) break;
                }
                for (int i = 0; i <= 7; ++i)
                {
                    if (ChessData.myboard[x, i] == 2 || ChessData.myboard[x, i] == 7 || ChessData.myboard[x, i] == 8) return true;
                    if (ChessData.myboard[i, y] != 0 && i != x && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                //Queen & Bishop
                for (int i =1 ; x + i <= 7 && y + i <= 7; ++i)
                {
                    if (ChessData.myboard[x + i, y + i] == 2 || ChessData.myboard[x + i, y + i] == 3 || ChessData.myboard[x + i, y + i] == 4) return true;
                    if (ChessData.myboard[x + i, y + i] != 0 && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                    
                for (int i = 1; x - i >= 0 && y + i <= 7; ++i)
                {
                    if (ChessData.myboard[x - i, y + i] == 2 || ChessData.myboard[x - i, y + i] == 3 || ChessData.myboard[x - i, y + i] == 4) return true;
                    if (ChessData.myboard[x - i, y + i] != 0 && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                    
                //Knight
                if (ChessData.myboard[x + 1, y + 2] == 5 || ChessData.myboard[x + 1, y + 2] == 6) return true;
                if (ChessData.myboard[x - 1, y + 2] == 5 || ChessData.myboard[x - 1, y + 2] == 6) return true;
                if (x + 2 <= 7 && (ChessData.myboard[x + 2, y + 1] == 5 || ChessData.myboard[x + 2, y + 1] == 6)) return true;
                if (x - 2 >= 0 && (ChessData.myboard[x - 2, y + 1] == 5 || ChessData.myboard[x - 2, y + 1] == 6)) return true;
                //Pawn
                if (ChessData.myboard[x + 1, y + 1] >= 9 && ChessData.myboard[x + 1, y + 1] <= 16) return true;
                if (ChessData.myboard[x - 1, y + 1] >= 9 && ChessData.myboard[x - 1, y + 1] <= 16) return true;
            }
            else // white
            {
                //King
                if (ChessData.myboard[x + 1, y] == 41) return true;
                if (ChessData.myboard[x - 1, y] == 41) return true;
                for (int i = x - 1; i <= x + 1; ++i) if (ChessData.myboard[i, y - 1] == 41) return true;
                //Queen & Rook
                for (int i = 0; i <= 7; ++i)
                {
                    if (ChessData.myboard[i, y] == 42 || ChessData.myboard[i, y] == 47 || ChessData.myboard[i, y] == 48) return true;
                    if (ChessData.myboard[i, y] != 0 && i != x && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                    
                for (int i = 0; i <= 7; ++i)
                {
                    if (ChessData.myboard[x, i] == 42 || ChessData.myboard[x, i] == 47 || ChessData.myboard[x, i] == 48) return true;
                    if (ChessData.myboard[i, y] != 0 && i != x && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                } 
                //Queen & Bishop
                for (int i = 1; x + i <= 7 && y - i >= 0; ++i)
                {
                    if (ChessData.myboard[x + i, y - i] == 42 || ChessData.myboard[x + i, y - i] == 43 || ChessData.myboard[x + i, y - i] == 44) return true;
                    if (ChessData.myboard[x + i, y - i] != 0 && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                   
                for (int i = 1; x - i >= 0 && y - i >= 0; ++i)
                {
                    if (ChessData.myboard[x - i, y - i] == 42 || ChessData.myboard[x - i, y - i] == 43 || ChessData.myboard[x - i, y - i] == 44) return true;
                    if (ChessData.myboard[x - i, y - i] != 0 && (Math.Abs(ChessData.myboard[x, y] - ChessData.myboard[i, y]) < 20)) break;
                }
                    
                //Knight
                if (ChessData.myboard[x + 1, y - 2] == 45 || ChessData.myboard[x + 1, y - 2] == 46) return true;
                if (ChessData.myboard[x - 1, y - 2] == 45 || ChessData.myboard[x - 1, y - 2] == 46) return true;
                if (x + 2 <= 7 && (ChessData.myboard[x + 2, y - 1] == 45 || ChessData.myboard[x + 2, y - 1] == 46)) return true;
                if (x - 2 >= 0 && (ChessData.myboard[x - 2, y - 1] == 45 || ChessData.myboard[x - 2, y - 1] == 46)) return true;
                //Pawn
                if (ChessData.myboard[x + 1, y - 1] >= 49 && ChessData.myboard[x + 1, y - 1] <= 56) return true;
                if (ChessData.myboard[x - 1, y - 1] >= 49 && ChessData.myboard[x - 1, y - 1] <= 56) return true;
            }
            return false;
        }

        private void SpecialKingRookMove(Chess king,Chess rook,int index)
        {
            switch (index)
            {
                case 7:
                    king.MoveTo(new Point(2 , 7)); // 換位置 UI
                    rook.MoveTo(new Point(3 , 7)); // 換位置 UI
                    ChessData.ChessMove(new Point(2, 7), new Point(4, 7)); // King換位
                    ChessData.ChessMove(new Point(3, 7), new Point(0, 7)); // Rook換位
                    player = !player;//換玩家
                    ReleaseCanMoveBlock();
                    ChangePlayerRound(); //將user資料傳回Form
                    break;
                case 8:
                    king.MoveTo(new Point(6, 7)); // 換位置 UI
                    rook.MoveTo(new Point(5, 7)); // 換位置 UI
                    ChessData.ChessMove(new Point(6, 7), new Point(4, 7)); // King換位
                    ChessData.ChessMove(new Point(5, 7), new Point(7, 7)); // Rook換位
                    player = !player;//換玩家
                    ReleaseCanMoveBlock();
                    ChangePlayerRound(); //將user資料傳回Form
                    break;
                case 47:
                    king.MoveTo(new Point(2, 0)); // 換位置 UI
                    rook.MoveTo(new Point(3, 0)); // 換位置 UI
                    ChessData.ChessMove(new Point(2, 0), new Point(4, 0)); // King換位
                    ChessData.ChessMove(new Point(3, 0), new Point(0, 0)); // Rook換位
                    player = !player;//換玩家
                    ReleaseCanMoveBlock();
                    ChangePlayerRound(); //將user資料傳回Form
                    break;
                case 48:
                    king.MoveTo(new Point(6, 0)); // 換位置 UI
                    rook.MoveTo(new Point(5, 0)); // 換位置 UI
                    ChessData.ChessMove(new Point(6, 0), new Point(4, 0)); // King換位
                    ChessData.ChessMove(new Point(5, 0), new Point(7, 0)); // Rook換位
                    player = !player;//換玩家
                    ReleaseCanMoveBlock();
                    ChangePlayerRound(); //將user資料傳回Form
                    break;
            }
        }

        //-------------------兵的升變-------------------// 
        public delegate void Delegate(int index); // 自定一個委派 (兵的升變)
        public event Delegate ChangePawnJob; //使用此委派宣告event (兵的升變)

        private void ConditionOfPawnExchangeJob(Point pos)
        {
            
            int index = ChessData.myboard[pos.X,pos.Y];
            if (ChessImage.pawnChangeJob[index] != -1) return; //判斷是否已升變
            if ((index >= 9 && index <= 16) || (index >= 49 && index <= 56)) //判斷兵
            {
                if(pos.Y == 0 || pos.Y == 7) //判斷位置
                {
                    ChangePawnJob(index); //傳至Form開啟選單
                }
            }
        }
        
            //-----改變圖示-----//
        public void PawnExchangeJobNext(int index,int job)
        {
            ChessImage.ChangePawnToSomeJob(index, job);
        }

            //-----升變後的移動方式判斷區-----//
        private bool pawnJobCheck(int i,Point pos)
        {
            if (ChessImage.pawnChangeJob[i] != -1)
            {
                int j = ChessImage.pawnChangeJob[i];
                switch (j)
                {
                    case 0:
                        Cross(pos);
                        Slash(pos);
                        break;
                    case 1:
                        if (pos.X + 2 <= 7)
                        {
                            if (pos.Y + 1 <= 7) CompareWhereCanGo(pos, 2, 1);
                            if (pos.Y - 1 >= 0) CompareWhereCanGo(pos, 2, -1);
                        }
                        if (pos.X - 2 >= 0)
                        {
                            if (pos.Y + 1 <= 7) CompareWhereCanGo(pos, -2, 1);
                            if (pos.Y - 1 >= 0) CompareWhereCanGo(pos, -2, -1);
                        }
                        if (pos.Y + 2 <= 7)
                        {
                            if (pos.X + 1 <= 7) CompareWhereCanGo(pos, 1, 2);
                            if (pos.X - 1 >= 0) CompareWhereCanGo(pos, -1, 2);
                        }
                        if (pos.Y - 2 >= 0)
                        {
                            if (pos.X + 1 <= 7) CompareWhereCanGo(pos, 1, -2);
                            if (pos.X - 1 >= 0) CompareWhereCanGo(pos, -1, -2);
                        }
                        break;
                    case 2:
                        Cross(pos);
                        break;
                    case 3:
                        Slash(pos);
                        break;
                }
                return true;
            }
            return false;
        }
        //-------------------路過吃兵-------------------//



        //-------------------------------------------勝利/認輸/和局----------------------------------//

        //勝利
        public delegate void UserWinToForm(bool player);
        public event UserWinToForm PlayerWin;

        private void WhoWin(int user)
        {
            if(user==0)
                PlayerWin(false);
            else if(user==1)
                PlayerWin(true);
        }

        //建立新遊戲

        public void SetNewGame()
        {
            player = false;
            for (int i = 1; i < ChessImage.mychsee.Length; ++i)
            {
                this.Controls.Remove(ChessImage.mychsee[i]);
            }
            ReleaseCanMoveBlock();
            ChessImage.Reset();
            ChessData.Reset();
            SelectHelper.Reset();
            for (int i = 1; i < ChessImage.mychsee.Length; ++i)
            {
                this.Controls.Add(ChessImage.mychsee[i]);
            }
        }

    }
}

/*    //將事件傳回Form   Delegate~~
      http://www.blueshop.com.tw/board/FUM20050124192253INM/BRD20091223153018APP.html 
 */
