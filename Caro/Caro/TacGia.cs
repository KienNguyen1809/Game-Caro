using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Caro
{
    partial class TacGia : Form
    {
        public TacGia()
        {
            InitializeComponent();
            
        }

        private void okButton_Click(object sender, EventArgs e)        //Click OK đóng cửa sổ Tác Giả lại
        {
            this.Close();
        }

        private void labelCompanyName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void labelCopyright_Click(object sender, EventArgs e)
        {

        }
    }
}
