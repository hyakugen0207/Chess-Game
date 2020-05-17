using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    enum ChessColor
    {
        NONE, BLACK, WHITE
    }

    abstract class CColor : Chess
    {
        private bool Selected;
        private ChessColor player;
        private bool CanBeEat = false; 

        public CColor(ChessColor x, Point pos) : base(pos)
        {
            player = x;
            Selected = false;
        }

        public ChessColor GetColor()
        {
            return player;
        }

        
        public override void ChangeState()
        {
            if (Selected == false)
            {
                //變為選取
                this.BackColor = Color.DarkSlateGray;
            }
            else
            {
                //變為未選取
                this.BackColor = Color.Transparent;
            }
            Selected = !Selected;
        }

        public override bool GetState()
        {
            return Selected;
        }



        public override bool CanEatOrNot()
        {
            return CanBeEat;
        }

        public override void ChangeEatMode()
        {
            CanBeEat = !CanBeEat;
        }


    }
}


/*
 *  負片效果
 * 
public Bitmap ConvertToInvert(Image img)
{
    // 讀入欲轉換的圖片並轉成為 Bitmap
    Bitmap bitmap = new Bitmap(img);
    for (int y = 0; y < bitmap.Height; y++)
    {
        for (int x = 0; x < bitmap.Width; x++)
        {
            // 取得每一個 pixel
            var pixel = bitmap.GetPixel(x, y);

            // 負片效果 將其反轉
            Color newColor = Color.FromArgb(pixel.A, 255 - pixel.R, 255 - pixel.G, 255 - pixel.B);

            bitmap.SetPixel(x, y, newColor);

        }
    }
    // 結果
    return bitmap;
}
*/