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
    public partial class Form2 : Form
    {
        CoCaro Caro;
        public Form2(CoCaro c)
        {
            InitializeComponent();
            Caro = c;
        }

       
        private void button2_Click(object sender, EventArgs e)          //Không
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)          //Có
        {
            this.Close();
            Caro.Close();
        }
    }
}
