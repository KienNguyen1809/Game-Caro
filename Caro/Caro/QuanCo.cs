using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Caro
{
    class QuanCo
    {
        private int x, y, val;
        public QuanCo()
        {
            X = -1;
            Y = -1;
            Val = -1; // 1-Nguoi, 2-May, 0 
        }
        public QuanCo(int x, int y, int val)
        {
            X = x;
            Y = y;
            Val = val;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

         public int Val
        {
            get { return val; }
            set { val = value; }
        }
    }
}
