namespace Caro
{
    partial class CoCaro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoCaro));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbLoad = new System.Windows.Forms.Label();
            this.lbUndo = new System.Windows.Forms.Label();
            this.lbExit = new System.Windows.Forms.Label();
            this.lbNew = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSave = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChuoiChu = new System.Windows.Forms.Label();
            this.timerChu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(553, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lbLoad
            // 
            this.lbLoad.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoad.ForeColor = System.Drawing.Color.Black;
            this.lbLoad.Image = ((System.Drawing.Image)(resources.GetObject("lbLoad.Image")));
            this.lbLoad.Location = new System.Drawing.Point(662, 405);
            this.lbLoad.Name = "lbLoad";
            this.lbLoad.Size = new System.Drawing.Size(110, 35);
            this.lbLoad.TabIndex = 5;
            this.lbLoad.Text = "Tiếp tục";
            this.lbLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoad.Click += new System.EventHandler(this.lbLoad_Click);
            this.lbLoad.MouseLeave += new System.EventHandler(this.lbLoad_MouseLeave);
            this.lbLoad.MouseHover += new System.EventHandler(this.lbLoad_MouseHover);
            // 
            // lbUndo
            // 
            this.lbUndo.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUndo.ForeColor = System.Drawing.Color.Black;
            this.lbUndo.Image = ((System.Drawing.Image)(resources.GetObject("lbUndo.Image")));
            this.lbUndo.Location = new System.Drawing.Point(553, 363);
            this.lbUndo.Name = "lbUndo";
            this.lbUndo.Size = new System.Drawing.Size(219, 33);
            this.lbUndo.TabIndex = 2;
            this.lbUndo.Text = "Quay lại";
            this.lbUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUndo.Click += new System.EventHandler(this.lbUndo_Click);
            this.lbUndo.MouseLeave += new System.EventHandler(this.lbUndo_MouseLeave);
            this.lbUndo.MouseHover += new System.EventHandler(this.lbUndo_MouseHover);
            // 
            // lbExit
            // 
            this.lbExit.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.Black;
            this.lbExit.Image = ((System.Drawing.Image)(resources.GetObject("lbExit.Image")));
            this.lbExit.Location = new System.Drawing.Point(553, 491);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(219, 33);
            this.lbExit.TabIndex = 1;
            this.lbExit.Text = "Thoát";
            this.lbExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            this.lbExit.MouseLeave += new System.EventHandler(this.lbExit_MouseLeave);
            this.lbExit.MouseHover += new System.EventHandler(this.lbExit_MouseHover);
            // 
            // lbNew
            // 
            this.lbNew.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNew.ForeColor = System.Drawing.Color.Black;
            this.lbNew.Image = ((System.Drawing.Image)(resources.GetObject("lbNew.Image")));
            this.lbNew.Location = new System.Drawing.Point(553, 320);
            this.lbNew.Name = "lbNew";
            this.lbNew.Size = new System.Drawing.Size(219, 34);
            this.lbNew.TabIndex = 0;
            this.lbNew.Text = "Chơi mới";
            this.lbNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNew.Click += new System.EventHandler(this.label1_Click);
            this.lbNew.MouseLeave += new System.EventHandler(this.lbNew_MouseLeave);
            this.lbNew.MouseHover += new System.EventHandler(this.lbNew_MouseHover);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(553, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tác giả";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // lbSave
            // 
            this.lbSave.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSave.ForeColor = System.Drawing.Color.Black;
            this.lbSave.Image = ((System.Drawing.Image)(resources.GetObject("lbSave.Image")));
            this.lbSave.Location = new System.Drawing.Point(553, 405);
            this.lbSave.Name = "lbSave";
            this.lbSave.Size = new System.Drawing.Size(103, 35);
            this.lbSave.TabIndex = 12;
            this.lbSave.Text = "Lưu";
            this.lbSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSave.Click += new System.EventHandler(this.lbSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblChuoiChu);
            this.panel1.Location = new System.Drawing.Point(553, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 100);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblChuoiChu
            // 
            this.lblChuoiChu.AutoSize = true;
            this.lblChuoiChu.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuoiChu.ForeColor = System.Drawing.Color.Red;
            this.lblChuoiChu.Location = new System.Drawing.Point(3, 81);
            this.lblChuoiChu.Name = "lblChuoiChu";
            this.lblChuoiChu.Size = new System.Drawing.Size(0, 15);
            this.lblChuoiChu.TabIndex = 0;
            this.lblChuoiChu.Click += new System.EventHandler(this.lblChuoiChu_Click);
            // 
            // timerChu
            // 
            this.timerChu.Enabled = true;
            this.timerChu.Interval = 50;
            this.timerChu.Tick += new System.EventHandler(this.timerChu_Tick);
            // 
            // CaroChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbLoad);
            this.Controls.Add(this.lbUndo);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.lbNew);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 580);
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "CaroChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME CỜ CARO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNew;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.Label lbUndo;
        private System.Windows.Forms.Label lbLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChuoiChu;
        private System.Windows.Forms.Timer timerChu;
    }
}

