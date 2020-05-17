using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    class ChessImage_View
    {
        public static readonly int Radius = 76;
        public static readonly int X_OFFSET = 41;
        public static readonly int Y_OFFSET = 62;
        public Chess[] mychsee = {UNUSE,
            WhiteKing, WhiteQueen , WhiteBishop1 , WhiteBishop2 , WhiteKnight1 , WhiteKnight2 , WhiteRook1 , WhiteRook2,
             WhitePawn1,WhitePawn2 , WhitePawn3   , WhitePawn4   , WhitePawn5   , WhitePawn6   , WhitePawn7 , WhitePawn8,
             UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,
             UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,
             UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,UNUSE,
             BlackKing, BlackQueen , BlackBishop1 , BlackBishop2 , BlackKnight1 , BlackKnight2 , BlackRook1 , BlackRook2,
             BlackPawn1,BlackPawn2 , BlackPawn3   , BlackPawn4   , BlackPawn5   , BlackPawn6   , BlackPawn7 , BlackPawn8,
             };

        public int[] pawnChangeJob = {-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1
        };
        public EmptyBlock[] emptyBlock =
        {
            EB00 , EB01 , EB02 , EB03 , EB04 , EB05 , EB06 , EB07,
            EB10 , EB11 , EB12 , EB13 , EB14 , EB15 , EB16 , EB17,
            EB20 , EB21 , EB22 , EB23 , EB24 , EB25 , EB26 , EB27,
            EB30 , EB31 , EB32 , EB33 , EB34 , EB35 , EB36 , EB37,
            EB40 , EB41 , EB42 , EB43 , EB44 , EB45 , EB46 , EB47,
            EB50 , EB51 , EB52 , EB53 , EB54 , EB55 , EB56 , EB57,
            EB60 , EB61 , EB62 , EB63 , EB64 , EB65 , EB66 , EB67,
            EB70 , EB71 , EB72 , EB73 , EB74 , EB75 , EB76 , EB77,
        };

        /*
                private string[] chess_name =
                {
                    "",
                     "BlackKing", "BlackQueen" , "BlackBishop1" , "BlackBishop2" , "BlackKnight1" , "BlackKnight2" , "BlackRook1" , "BlackRook2",
                     "BlackPawn1","BlackPawn2" , "BlackPawn3"   , "BlackPawn4"   , "BlackPawn5"   , "BlackPawn6"   , "BlackPawn7" , "BlackPawn8",
                     "WhiteKing", "WhiteQueen" , "WhiteBishop1" , "WhiteBishop2" , "WhiteKnight1" , "WhiteKnight2" , "WhiteRook1" ,"WhiteRook2",
                     "WhitePawn1","WhitePawn2" , "WhitePawn3"   , "WhitePawn4"   , "WhitePawn5"   , "WhitePawn6"   , "WhitePawn7" , "WhitePawn8",

                };
        */
        private static Chess UNUSE = new Rook(ChessColor.WHITE, new Point(-100,-100));

        private static Chess BlackRook1 = new Rook(ChessColor.BLACK, new Point(41 + Radius * 0, 62 + Radius * 0));
        private static Chess BlackKnight1 = new Knight(ChessColor.BLACK, new Point(41 + Radius * 1, 62 + Radius * 0));
        private static Chess BlackBishop1 = new Bishop(ChessColor.BLACK, new Point(41 + Radius * 2, 62 + Radius * 0));
        private static Chess BlackKing = new King(ChessColor.BLACK, new Point(41 + Radius * 4, 62 + Radius * 0));
        private static Chess BlackQueen = new Queen(ChessColor.BLACK, new Point(41 + Radius * 3, 62 + Radius * 0));
        private static Chess BlackBishop2 = new Bishop(ChessColor.BLACK, new Point(41 + Radius * 5, 62 + Radius * 0));
        private static Chess BlackKnight2 = new Knight(ChessColor.BLACK, new Point(41 + Radius * 6, 62 + Radius * 0));
        private static Chess BlackRook2 = new Rook(ChessColor.BLACK, new Point(41 + Radius * 7, 62 + Radius * 0));
        private static Chess BlackPawn1 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 0, 62 + Radius * 1));
        private static Chess BlackPawn2 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 1, 62 + Radius * 1));
        private static Chess BlackPawn3 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 2, 62 + Radius * 1));
        private static Chess BlackPawn4 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 3, 62 + Radius * 1));
        private static Chess BlackPawn5 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 4, 62 + Radius * 1));
        private static Chess BlackPawn6 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 5, 62 + Radius * 1));
        private static Chess BlackPawn7 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 6, 62 + Radius * 1));
        private static Chess BlackPawn8 = new Pawn(ChessColor.BLACK, new Point(41 + Radius * 7, 62 + Radius * 1));

        

        private static Chess WhiteRook1 = new Rook(ChessColor.WHITE, new Point(41 + Radius * 0, 62 + Radius * 7));
        private static Chess WhiteKnight1 = new Knight(ChessColor.WHITE, new Point(41 + Radius * 1, 62 + Radius * 7));
        private static Chess WhiteBishop1 = new Bishop(ChessColor.WHITE, new Point(41 + Radius * 2, 62 + Radius * 7));
        private static Chess WhiteKing = new King(ChessColor.WHITE, new Point(41 + Radius * 4, 62 + Radius * 7));
        private static Chess WhiteQueen = new Queen(ChessColor.WHITE, new Point(41 + Radius * 3, 62 + Radius * 7));
        private static Chess WhiteBishop2 = new Bishop(ChessColor.WHITE, new Point(41 + Radius * 5, 62 + Radius * 7));
        private static Chess WhiteKnight2 = new Knight(ChessColor.WHITE, new Point(41 + Radius * 6, 62 + Radius * 7));
        private static Chess WhiteRook2 = new Rook(ChessColor.WHITE, new Point(41 + Radius * 7, 62 + Radius * 7));
        private static Chess WhitePawn1 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 0, 62 + Radius * 6));
        private static Chess WhitePawn2 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 1, 62 + Radius * 6));
        private static Chess WhitePawn3 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 2, 62 + Radius * 6));
        private static Chess WhitePawn4 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 3, 62 + Radius * 6));
        private static Chess WhitePawn5 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 4, 62 + Radius * 6));
        private static Chess WhitePawn6 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 5, 62 + Radius * 6));
        private static Chess WhitePawn7 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 6, 62 + Radius * 6));
        private static Chess WhitePawn8 = new Pawn(ChessColor.WHITE, new Point(41 + Radius * 7, 62 + Radius * 6));


        private static EmptyBlock EB00 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 0));
        private static EmptyBlock EB01 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 0));
        private static EmptyBlock EB02 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 0));
        private static EmptyBlock EB03 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 0));
        private static EmptyBlock EB04 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 0));
        private static EmptyBlock EB05 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 0));
        private static EmptyBlock EB06 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 0));
        private static EmptyBlock EB07 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 0));
        private static EmptyBlock EB10 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 1));
        private static EmptyBlock EB11 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 1));
        private static EmptyBlock EB12 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 1));
        private static EmptyBlock EB13 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 1));
        private static EmptyBlock EB14 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 1));
        private static EmptyBlock EB15 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 1));
        private static EmptyBlock EB16 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 1));
        private static EmptyBlock EB17 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 1));
        private static EmptyBlock EB20 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 2));
        private static EmptyBlock EB21 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 2));
        private static EmptyBlock EB22 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 2));
        private static EmptyBlock EB23 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 2));
        private static EmptyBlock EB24 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 2));
        private static EmptyBlock EB25 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 2));
        private static EmptyBlock EB26 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 2));
        private static EmptyBlock EB27 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 2));
        private static EmptyBlock EB30 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 3));
        private static EmptyBlock EB31 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 3));
        private static EmptyBlock EB32 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 3));
        private static EmptyBlock EB33 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 3));
        private static EmptyBlock EB34 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 3));
        private static EmptyBlock EB35 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 3));
        private static EmptyBlock EB36 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 3));
        private static EmptyBlock EB37 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 3));
        private static EmptyBlock EB40 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 4));
        private static EmptyBlock EB41 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 4));
        private static EmptyBlock EB42 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 4));
        private static EmptyBlock EB43 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 4));
        private static EmptyBlock EB44 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 4));
        private static EmptyBlock EB45 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 4));
        private static EmptyBlock EB46 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 4));
        private static EmptyBlock EB47 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 4));
        private static EmptyBlock EB50 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 5));
        private static EmptyBlock EB51 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 5));
        private static EmptyBlock EB52 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 5));
        private static EmptyBlock EB53 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 5));
        private static EmptyBlock EB54 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 5));
        private static EmptyBlock EB55 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 5));
        private static EmptyBlock EB56 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 5));
        private static EmptyBlock EB57 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 5));
        private static EmptyBlock EB60 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 6));
        private static EmptyBlock EB61 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 6));
        private static EmptyBlock EB62 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 6));
        private static EmptyBlock EB63 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 6));
        private static EmptyBlock EB64 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 6));
        private static EmptyBlock EB65 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 6));
        private static EmptyBlock EB66 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 6));
        private static EmptyBlock EB67 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 6));
        private static EmptyBlock EB70 = new EmptyBlock(new Point(41 + Radius * 0, 62 + Radius * 7));
        private static EmptyBlock EB71 = new EmptyBlock(new Point(41 + Radius * 1, 62 + Radius * 7));
        private static EmptyBlock EB72 = new EmptyBlock(new Point(41 + Radius * 2, 62 + Radius * 7));
        private static EmptyBlock EB73 = new EmptyBlock(new Point(41 + Radius * 3, 62 + Radius * 7));
        private static EmptyBlock EB74 = new EmptyBlock(new Point(41 + Radius * 4, 62 + Radius * 7));
        private static EmptyBlock EB75 = new EmptyBlock(new Point(41 + Radius * 5, 62 + Radius * 7));
        private static EmptyBlock EB76 = new EmptyBlock(new Point(41 + Radius * 6, 62 + Radius * 7));
        private static EmptyBlock EB77 = new EmptyBlock(new Point(41 + Radius * 7, 62 + Radius * 7));

        public void ChangePawnToSomeJob(int index,int job)
        {
            MessageBox.Show($"job = {job}");
            if(job==0)
            {
                if (index > 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.black_queen, newSize);
                }
                else if (index <= 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.white_queen, newSize);
                    
                }
                pawnChangeJob[index] = 0;
            }
            else if(job == 1)
            {
                if (index > 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.black_knight, newSize);
                }
                else if (index <= 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.white_knight, newSize);
                }
                pawnChangeJob[index] = 1;
            }
            else if(job == 2)
            {
                if (index > 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.black_rook, newSize);
                }
                else if (index <= 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.white_rook, newSize);
                }
                pawnChangeJob[index] = 2;
            }
            else if(job == 3)
            {
                if (index > 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.black_bishop, newSize);
                }
                else if (index <= 16)
                {
                    Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                    mychsee[index].BackgroundImage = new Bitmap(Properties.Resources.white_bishop, newSize);
                }
                pawnChangeJob[index] = 3;
            }
        }

        public Chess GetChessName(int x)
        {
            return mychsee[x];
        }

        public Chess GetBlockName(int x,int y)
        {
            return emptyBlock[8*y + x];
        }

        public void Reset()
        {
            pawnChangeJob = new int[] {1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1
            };

            BlackRook1.MoveTo(new Point(0,0));
            BlackKnight1.MoveTo(new Point(1, 0));
            BlackBishop1.MoveTo(new Point(2, 0));
            BlackKing.MoveTo(new Point(4, 0));
            BlackQueen.MoveTo(new Point(3, 0));
            BlackBishop2.MoveTo(new Point(5, 0));
            BlackKnight2.MoveTo(new Point(6, 0));
            BlackRook2.MoveTo(new Point(7, 0));
            BlackPawn1.MoveTo(new Point(0, 1));
            BlackPawn2.MoveTo(new Point(1, 1));
            BlackPawn3.MoveTo(new Point(2, 1));
            BlackPawn4.MoveTo(new Point(3, 1));
            BlackPawn5.MoveTo(new Point(4, 1));
            BlackPawn6.MoveTo(new Point(5, 1));
            BlackPawn7.MoveTo(new Point(6, 1));
            BlackPawn8.MoveTo(new Point(7, 1));
            WhiteRook1.MoveTo(new Point(0, 7));
            WhiteKnight1.MoveTo(new Point(1, 7));
            WhiteBishop1.MoveTo(new Point(2, 7));
            WhiteKing.MoveTo(new Point(4, 7));
            WhiteQueen.MoveTo(new Point(3, 7));
            WhiteBishop2.MoveTo(new Point(5, 7));
            WhiteKnight2.MoveTo(new Point(6, 7));
            WhiteRook2.MoveTo(new Point(7, 7));
            WhitePawn1.MoveTo(new Point(0, 6));
            WhitePawn2.MoveTo(new Point(1, 6));
            WhitePawn3.MoveTo(new Point(2, 6));
            WhitePawn4.MoveTo(new Point(3, 6));
            WhitePawn5.MoveTo(new Point(4, 6));
            WhitePawn6.MoveTo(new Point(5, 6));
            WhitePawn7.MoveTo(new Point(6, 6));
            WhitePawn8.MoveTo(new Point(7, 6));

            for(int i=9; i<=16; ++i)
            {
                Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                mychsee[i].BackgroundImage = new Bitmap(Properties.Resources.white_pawn, newSize);
            }
            for (int i = 49; i <= 56; ++i)
            {
                Size newSize = new Size(Chess.ChessSize, Chess.ChessSize);
                mychsee[i].BackgroundImage = new Bitmap(Properties.Resources.black_pawn, newSize);
            }
        }
    }
}
