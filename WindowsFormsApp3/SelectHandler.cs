using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    class SelectHandler
    {
        private bool selected;
        private Chess selectedName;
        private int pos_x;
        private int pos_y;

        // constructor 
        public SelectHandler()
        {
            selected = false;
        }
        
        // function
        public bool GetSelectState()
        {
            return selected;
        }

        public Chess GetSelectName()
        {
            return selectedName;
        }

        public void SetSelectedName(Chess name)
        {
            selectedName = name;
        }

        public void ChangeSelectedMode()
        {
            selected = !selected;
        }

        public void SetSelectedPos(int x, int y)
        {
            pos_x = x;
            pos_y = y;
        }

        public Point GetPosition()
        {
            return new Point(pos_x, pos_y);
        }

        public void Reset()
        {
            selected = false;
            pos_x = 0;
            pos_y = 0;
    }
    }
}
