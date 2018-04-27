using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Caro
{
    public partial class CoCaro : Form
    {
        Graphic graph = new Graphic();
        Graphics gr;
        DanhGiaBanCo danhGia;
        //Danh sách các nước đã đi
        List<Point> listUndo = new List<Point>();

        public int[,] BanCo = new int[20, 20];   //Người= 1, Máy= 2, Chưa đi= 0
        int mayORnguoi = 2;     //Mặc định lúc đầu cho máy đi trước
        int _x, _y;     //Tọa độ nước cờ mà máy đi.

        public static int doSauMax = 15;        //Độ sâu duyệt cây là 15
        public static int nuocDiMax = 3;        //Chọn 3 ô trống có điểm cao nhất để đánh
        public int doSau = 0;

        public bool Win = false;
        public int End = 1;

        //Ưu tiên việc tấn công nên điểm tấn công gấp đôi phòng ngự
        public int[] mangDiemPhongThu = new int[5] { 0, 1, 9, 81, 729 };
        //public int[] mangDiemPhongThu = new int[5] { 0, 3, 27, 99, 729 };

        //public int[] mangDiemTanCong = new int[5] { 0, 1, 9, 81, 729 };
        //public int[] mangDiemTanCong = new int[5] { 0, 3, 24, 243, 2197 };
        public int[] mangDiemTanCong = new int[5] { 0, 2, 18, 162, 1458 };
        //public int[] mangDiemTanCong = new int[5] { 0, 9, 54, 162, 1458 };

        Point[] MayDi = new Point[nuocDiMax + 2];
        Point[] NguoiDi = new Point[nuocDiMax + 2];
        Point[] NuocThang = new Point[doSauMax + 2];
        Point[] NuocThua = new Point[doSauMax + 2];

        public CoCaro()
        {
            InitializeComponent();
            Width = 800;
            Height = 590;
            Paint += new PaintEventHandler(Form1_Paint);

            for (int i = 0; i < graph.Row * graph.Row; i++)
                BanCo[i % graph.Row, i / graph.Row] = 0;
            danhGia = new DanhGiaBanCo(graph);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblChuoiChu.Text = "LUẬT CHƠI\nNgười chơi chiến thắng khi tạo đủ 5\nquân cờ liên tiếp theo chiều dọc\nhoặc chiều ngang hoặc đường chéo.";
            timerChu.Enabled = true;
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            graph.VeBanCo(gr);

        }

        //Hàm xử lí sự kiện click
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= graph.Left && e.X <= graph._Right && e.Y >= graph.Up && e.Y <= graph.Down && End == 0 && mayORnguoi == 1)
            {
                int x = e.X / graph._Size - 1;
                int y = e.Y / graph._Size - 1;
                if (BanCo[x, y] == 0)
                {
                    BanCo[x, y] = 1;
                    //Thêm các nước đã đi vào trong danh sách
                    listUndo.Add(new Point(x, y));
                    gr = this.CreateGraphics();
                    graph.VeQuanCo(x, y, BanCo[x, y], gr);

                    if (kiemTraKetThuc(x, y) == 1)
                    {
                        MessageBox.Show("Bạn đã chiến thắng!");
                        End = 1;
                        return;
                    }
                    //May di
                    AI();
                    if (Win)
                    {
                        _x = NuocThang[0].X;
                        _y = NuocThang[0].Y;
                    }
                    else
                    {
                        danhGiaBanCo(2, ref danhGia);
                        Point temp = new Point();
                        temp = danhGia.MaxPos();
                        _x = temp.X;
                        _y = temp.Y;
                    }
                    BanCo[_x, _y] = 2;
                    listUndo.Add(new Point(_x, _y));
                    graph.VeQuanCo(_x, _y, BanCo[_x, _y], gr);
                    if (kiemTraKetThuc(_x, _y) == 2)
                    {
                        MessageBox.Show("Bạn thua rồi!");
                        End = 2;
                        return;
                    }
                }
            }
        }


        #region TÌM NƯỚC ĐI TỐI ƯU CHO MÁY
        //Ham danh gia
        private void danhGiaBanCo(int player, ref DanhGiaBanCo danhGia)
        {
            int rw, cl, dGMay, dGNguoi;
            danhGia.ResetBanCo();

            //Danh gia theo hang
            for (rw = 0; rw < graph.Row; rw++)
                for (cl = 0; cl < graph.Col - 4; cl++)      //Đánh 4 ô ở các cột gần biên thì không đủ điều kiện thắng
                {
                    dGMay = 0; dGNguoi = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BanCo[rw, cl + i] == 1)
                            dGNguoi++;
                        if (BanCo[rw, cl + i] == 2)
                            dGMay++;
                    }
                    //Heuristic h(u)
                    if (dGNguoi * dGMay == 0 && dGNguoi != dGMay)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BanCo[rw, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (dGNguoi == 0)
                                    if (player == 1)
                                        danhGia.DanhGia[rw, cl + i] += mangDiemPhongThu[dGMay];
                                    else danhGia.DanhGia[rw, cl + i] += mangDiemTanCong[dGMay];
                                if (dGMay == 0)
                                    if (player == 2)
                                        danhGia.DanhGia[rw, cl + i] += mangDiemPhongThu[dGNguoi];
                                    else danhGia.DanhGia[rw, cl + i] += mangDiemTanCong[dGNguoi];
                                if (dGNguoi == 4 || dGMay == 4)
                                    danhGia.DanhGia[rw, cl + i] *= 2;
                            }
                        }
                    }
                }

            //Danh gia theo cot
            for (cl = 0; cl < graph.Col; cl++)
                for (rw = 0; rw < graph.Row - 4; rw++)          //Đánh 4 ô ở các dòng gần biên thì không đủ điều kiện thắng
                {
                    dGMay = 0; dGNguoi = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BanCo[rw + i, cl] == 1)
                            dGNguoi++;
                        if (BanCo[rw + i, cl] == 2)
                            dGMay++;
                    }
                    //Heuristic h(u)
                    if (dGNguoi * dGMay == 0 && dGNguoi != dGMay)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BanCo[rw + i, cl] == 0) // Neu o chua duoc danh
                            {
                                if (dGNguoi == 0)
                                    if (player == 1)
                                        danhGia.DanhGia[rw + i, cl] += mangDiemPhongThu[dGMay];
                                    else danhGia.DanhGia[rw + i, cl] += mangDiemTanCong[dGMay];
                                if (dGMay == 0)
                                    if (player == 2)
                                        danhGia.DanhGia[rw + i, cl] += mangDiemPhongThu[dGNguoi];
                                    else danhGia.DanhGia[rw + i, cl] += mangDiemTanCong[dGNguoi];
                                if (dGNguoi == 4 || dGMay == 4)
                                    danhGia.DanhGia[rw + i, cl] *= 2;
                            }
                        }
                    }
                }

            //Danh gia duong cheo xuong
            for (cl = 0; cl < graph.Col - 4; cl++)                  //Đánh 4 ô đường chéo gần biên thì không đủ diều kiện thắng
                for (rw = 0; rw < graph.Row - 4; rw++)
                {
                    dGMay = 0; dGNguoi = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BanCo[rw + i, cl + i] == 1)
                            dGNguoi++;
                        if (BanCo[rw + i, cl + i] == 2)
                            dGMay++;
                    }
                    //Heuristic h(u)
                    if (dGNguoi * dGMay == 0 && dGNguoi != dGMay)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BanCo[rw + i, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (dGNguoi == 0)
                                    if (player == 1)
                                        danhGia.DanhGia[rw + i, cl + i] += mangDiemPhongThu[dGMay];
                                    else danhGia.DanhGia[rw + i, cl + i] += mangDiemTanCong[dGMay];
                                if (dGMay == 0)
                                    if (player == 2)
                                        danhGia.DanhGia[rw + i, cl + i] += mangDiemPhongThu[dGNguoi];
                                    else danhGia.DanhGia[rw + i, cl + i] += mangDiemTanCong[dGNguoi];
                                if (dGNguoi == 4 || dGMay == 4)
                                    danhGia.DanhGia[rw + i, cl + i] *= 2;
                            }
                        }
                    }
                }

            //Danh gia duong cheo len
            for (rw = 4; rw < graph.Row; rw++)                  //Đánh 4 ô đường chéo lên tính từ dòng thứ 4 xuống dòng cuối cùng
                for (cl = 0; cl < graph.Col - 4; cl++)
                {
                    dGMay = 0; dGNguoi = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BanCo[rw - i, cl + i] == 1)
                            dGNguoi++;
                        if (BanCo[rw - i, cl + i] == 2)
                            dGMay++;
                    }
                    //Heuristic h(u)
                    if (dGNguoi * dGMay == 0 && dGNguoi != dGMay)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BanCo[rw - i, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (dGNguoi == 0)
                                    if (player == 1)
                                        danhGia.DanhGia[rw - i, cl + i] += mangDiemPhongThu[dGMay];
                                    else danhGia.DanhGia[rw - i, cl + i] += mangDiemTanCong[dGMay];
                                if (dGMay == 0)
                                    if (player == 2)
                                        danhGia.DanhGia[rw - i, cl + i] += mangDiemPhongThu[dGNguoi];
                                    else danhGia.DanhGia[rw - i, cl + i] += mangDiemTanCong[dGNguoi];
                                if (dGNguoi == 4 || dGMay == 4)
                                    danhGia.DanhGia[rw - i, cl + i] *= 2;
                            }
                        }
                    }
                }

        }


        //Ham tim nuoc di cho may
        private void mayTimNuocDi()
        {
            if (doSau > doSauMax)
                return;
            doSau++;
            Win = false;
            bool Lose = false;
            Point mayDi = new Point();
            Point nguoiDi = new Point();
            int demNuocDi = 0;

            danhGiaBanCo(2, ref danhGia);

            //Lấy ra nước đi có điểm cao nhất
            Point temp = new Point();
            for (int i = 0; i < nuocDiMax; i++)
            {
                temp = danhGia.MaxPos();
                MayDi[i] = temp;
                danhGia.DanhGia[temp.X, temp.Y] = 0;
            }

            //Lấy nước đi trong mảng MayDi[] ra đánh thử
            demNuocDi = 0;
            while (demNuocDi < nuocDiMax)
            {
                mayDi = MayDi[demNuocDi++];
                BanCo[mayDi.X, mayDi.Y] = 2;
                NuocThang.SetValue(mayDi, doSau - 1);

                //Tìm các nước đi tối ưu của Người
                danhGia.ResetBanCo();
                danhGiaBanCo(1, ref danhGia);
                //Lấy ra nước đi có điểm cao nhất của Người
                for (int i = 0; i < nuocDiMax; i++)
                {
                    temp = danhGia.MaxPos();
                    NguoiDi[i] = temp;
                    danhGia.DanhGia[temp.X, temp.Y] = 0;
                }

                //Đánh thử các nước đi
                for (int i = 0; i < nuocDiMax; i++)
                {
                    nguoiDi = NguoiDi[i];
                    BanCo[nguoiDi.X, nguoiDi.Y] = 1;
                    if (kiemTraKetThuc(nguoiDi.X, nguoiDi.Y) == 2)
                    {
                        Win = true;
                    }
                    if (kiemTraKetThuc(nguoiDi.X, nguoiDi.Y) == 1)
                    {
                        Lose = true;
                    }
                    if (Lose)
                    {
                        BanCo[mayDi.X, mayDi.Y] = 0;
                        BanCo[nguoiDi.X, nguoiDi.Y] = 0;
                        break;
                    }
                    if (Win)
                    {
                        BanCo[mayDi.X, mayDi.Y] = 0;
                        BanCo[nguoiDi.X, nguoiDi.Y] = 0;
                        return;
                    }
                    mayTimNuocDi();
                    BanCo[nguoiDi.X, nguoiDi.Y] = 0;
                }
                BanCo[mayDi.X, mayDi.Y] = 0;

            }

        }


        private void AI()
        {
            for (int i = 0; i < nuocDiMax; i++)
            {
                NuocThang[i] = new Point();
                MayDi[i] = new Point();
                NguoiDi[i] = new Point();
            }
            doSau = 0;
            mayTimNuocDi();
        }
        #endregion

        #region KIỂM TRA KẾT THÚC (THẮNG - THUA)
        private int kiemTraKetThuc(int cl, int rw)
        {
            int r = 0, c = 0;           //Dòng, Cột hiện tại
            int i;
            bool Nguoi, May;

            //Bàn cờ gồm 20 dòng, đánh số 0 -> 19 dòng
            //Kiểm tra chiều ngang
            while (c < graph.Col - 5)        //4 cột ở biên bàn cờ chỉ đánh được tối đa 4 quân cờ => Không đủ 5 quân cờ liên tiếp  
            {
                Nguoi = true; May = true;
                for (i = 0; i < 5; i++)
                {
                    if (BanCo[cl, c + i] != 1)
                        Nguoi = false;
                    if (BanCo[cl, c + i] != 2)
                        May = false;
                }
                if (Nguoi) return 1;
                if (May) return 2;
                c++;
            }

            //Kiểm tra chiều dọc
            while (r < graph.Row - 5)       //4 dòng ở biên bàn cờ chỉ đánh được tối đa 4 quân cờ => Không đủ 5 quân cờ liên tiếp
            {
                Nguoi = true; May = true;
                for (i = 0; i < 5; i++)
                {
                    if (BanCo[r + i, rw] != 1)
                        Nguoi = false;
                    if (BanCo[r + i, rw] != 2)
                        May = false;
                }
                if (Nguoi) return 1;
                if (May) return 2;
                r++;
            }

            //Kiểm tra đường chéo xuống
            r = rw; c = cl;
            while (r > 0 && c > 0)
            {
                r--;
                c--;
            }
            while (r <= graph.Row - 5 && c <= graph.Col - 5)    
            {
                Nguoi = true; May = true;
                for (i = 0; i < 5; i++)
                {
                    if (BanCo[c + i, r + i] != 1)
                        Nguoi = false;
                    if (BanCo[c + i, r + i] != 2)
                        May = false;
                }
                if (Nguoi) return 1;
                if (May) return 2;
                r++;
                c++;
            }

            //Kiểm tra đường chéo lên
            r = rw; c = cl;
            while (r < graph.Row - 1 && c > 0)
            {
                r++;
                c--;
            }
            while (r >= 4 && c <= graph.Col - 5)
            {
                Nguoi = true; May = true;
                for (i = 0; i < 5; i++)
                {
                    if (BanCo[r - i, c + i] != 1)
                        Nguoi = false;
                    if (BanCo[r - i, c + i] != 2)
                        May = false;
                }
                if (Nguoi) return 1;
                if (May) return 2;
                r--;
                c++;
            }
            return 0;
        }
        #endregion

        #region CHỨC NĂNG CÁC BUTTONS

        //CHƠI MỚI
        private void label1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < graph.Row * graph.Row; i++)
                if (BanCo[i % graph.Row, i / graph.Row] != 0)
                {
                    BanCo[i % graph.Row, i / graph.Row] = 0;
                    graph.VeQuanCo(i % graph.Row, i / graph.Row, 0, gr);
                }
            Paint += new PaintEventHandler(Form1_Paint);
            if (End == 1)
                mayORnguoi = 2;
            else mayORnguoi = 1;
            if (mayORnguoi == 2)
            {
                Random r = new Random();
                _x = r.Next(3);
                _y = r.Next(3);
                BanCo[_x + 7, _y + 7] = 2;
                listUndo.Add(new Point(_x + 7, _y + 7));
                gr = this.CreateGraphics();
                graph.VeQuanCo(_x + 7, _y + 7, BanCo[_x + 7, _y + 7], gr);
                mayORnguoi = 1;
            }
            End = 0;
        }


        //QUAY LAI
        private void lbUndo_Click(object sender, EventArgs e)
        {
            if (listUndo.Count > 1)
            {
                Point p = listUndo.Last();
                listUndo.RemoveAt(listUndo.Count() - 1);
                BanCo[p.X, p.Y] = 0;
                graph.VeQuanCo(p.X, p.Y, 0, gr);
                if (listUndo.Count > 0)
                {
                    p = listUndo.Last();
                    listUndo.RemoveAt(listUndo.Count() - 1);
                    BanCo[p.X, p.Y] = 0;
                    graph.VeQuanCo(p.X, p.Y, 0, gr);
                }
                End = 0;
            }
        }


        //LUU
        private void lbSave_Click(object sender, EventArgs e)
        {
            string path = @"Caro.sav";
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            for (int i = 0; i < graph.Row; i++)
            {
                for (int j = 0; j < graph.Col; j++)
                {
                    sw.Write(BanCo[i, j].ToString());
                }
                sw.Write("\n");
            }
            sw.Flush();
            sw.Close();
            f.Close();
            MessageBox.Show("Đã lưu thành công!");
        }


        //TIEP TUC
        private void lbLoad_Click(object sender, EventArgs e)
        {
            string path = @"Caro.sav";
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(f);

            gr = this.CreateGraphics();

            for (int i = 0; i < graph.Row * graph.Row; i++)
                if (BanCo[i % graph.Row, i / graph.Row] != 0)
                {
                    BanCo[i % graph.Row, i / graph.Row] = 0;
                    graph.VeQuanCo(i % graph.Row, i / graph.Row, 0, gr);
                }
            Paint += new PaintEventHandler(Form1_Paint);

            for (int i = 0; i < graph.Row; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < graph.Col; j++)
                {
                    BanCo[i, j] = (int)(s[j] - 48);
                    if (BanCo[i, j] != 0)
                        graph.VeQuanCo(i, j, BanCo[i, j], gr);
                }
            }
            mayORnguoi = 1;
            End = 0;
            sr.Close();
            f.Close();
        }

        //TAC GIA
        private void label2_Click_1(object sender, EventArgs e)
        {
            TacGia a = new TacGia();
            a.Show();
        }

        //THOAT
        private void lbExit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }
        #endregion


        #region IMAGE CÁC BUTTONS
        private void lbNew_MouseHover(object sender, EventArgs e)
        {
            lbNew.Image = Properties.Resources.To2;
        }

        private void lbUndo_MouseHover(object sender, EventArgs e)
        {
            lbUndo.Image = Properties.Resources.To2;
        }

        private void lbSave_MouseHover(object sender, EventArgs e)
        {
            lbSave.Image = Properties.Resources.Nho2;
        }

        private void lbLoad_MouseHover(object sender, EventArgs e)
        {
            lbLoad.Image = Properties.Resources.Nho2;
        }

        private void label2_MouseHover(object sender, EventArgs e)  //Tac Gia
        {
            label2.Image = Properties.Resources.To2;
        }

        private void lbExit_MouseHover(object sender, EventArgs e)
        {
            lbExit.Image = Properties.Resources.To2;
        }

        private void lbNew_MouseLeave(object sender, EventArgs e)
        {
            lbNew.Image = Properties.Resources.KhungTo;
        }

        private void lbUndo_MouseLeave(object sender, EventArgs e)
        {
            lbUndo.Image = Properties.Resources.KhungTo;
        }

        private void lbSave_MouseLeave(object sender, EventArgs e)
        {
            lbSave.Image = Properties.Resources.KhungNho;
        }

        private void lbLoad_MouseLeave(object sender, EventArgs e)
        {
            lbLoad.Image = Properties.Resources.KhungNho;
        }


        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Image = Properties.Resources.KhungTo;
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.Image = Properties.Resources.KhungTo;
        }

        #endregion

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerChu_Tick(object sender, EventArgs e)
        {
            lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, lblChuoiChu.Location.Y - 1);
            if(lblChuoiChu.Location.Y + lblChuoiChu.Height < 0)
            {
                lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, panel1.Height);
            }
        }

        private void lblChuoiChu_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
