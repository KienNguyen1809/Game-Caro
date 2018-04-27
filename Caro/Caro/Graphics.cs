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
    class Graphic : Form
    {
        const int row = 20, col = 20, left = 200, up = 50, size = 22, right = col * size + left, down = up + row * size;
        Color bgColor = Color.Khaki;
        public Graphic() {}

        public void DrawBanCo(Graphics graph)
        {
            //Brush b = new SolidBrush(bgColor);
            //graph.FillRectangle(b, left, up, row * size, col * size);
            MessageBox.Show("hello");
            Pen pen = new Pen(Color.Tomato);
            for (int i = 0; i < 21; i++)
            {
                graph.DrawLine(pen, 20, 20 * (i + 1), 420, 20 * (i + 1));
                graph.DrawLine(pen, 20 * (i + 1), 20, 20 * (i + 1), 420);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Tomato);
            for (int i = 0; i < 21; i++)
            {
                graphics.DrawLine(pen, 20, 20 * (i + 1), 420, 20 * (i + 1));
                graphics.DrawLine(pen, 20 * (i + 1), 20, 20 * (i + 1), 420);
            }
            //nếu start == 1 thì gọi hàm DrawChessPiece() để bắt đầu vẽ quân cờ
            //if (start == 1) DrawChessPiece();
        }
    }
}
