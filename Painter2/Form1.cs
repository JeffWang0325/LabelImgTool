/*
    Date: 2020/04/13
    Title: C#控制元件picturebox實現影象拖拽和縮放
    Link: https://www.itread01.com/article/1537588121.html
    Title: 
    Link: 
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection; // picturebox圖像縮放
using System.IO; // For FileInfo

namespace Painter2
{
    public partial class Form1 : Form
    {
        private Point mouseDownPoint; // 記錄拖拽過程中鼠標位置
        private bool isMove = false; // picturebox圖像拖曳
        private Point Initial_pictureBox1Location = new Point(0, 0);
        private int Initial_pictureBox1Width = 1100, Initial_pictureBox1Height = 700;

        Graphics g;                 // 繪圖區
        bool isMouseDown = false;   // 紀錄滑鼠是否被按下
        List<Point> points = new List<Point>(); // 紀錄滑鼠軌跡的陣列。
        List<Pen> ListPen = new List<Pen>(); // 紀錄不同滑鼠軌跡段落之顏色及大小

        public Form1()
        {
            InitializeComponent();

            this.pictureBox_ImageShowForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseWheel);

            g = pictureBox_ImageShowForm.CreateGraphics(); // 取得繪圖區物件
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 取得初始 pictureBox_ImageShowForm 資訊
            Initial_pictureBox1Location = pictureBox_ImageShowForm.Location;
            Initial_pictureBox1Width = pictureBox_ImageShowForm.Width;
            Initial_pictureBox1Height = pictureBox_ImageShowForm.Height;

            string[] ArrayCursor = Enum.GetNames(typeof(enu_CursorImage));
            cbx_Cursor.Items.Clear();
            foreach (string s in ArrayCursor)
                cbx_Cursor.Items.Add(s);
            if (cbx_Cursor.Items.Count > 0)
                cbx_Cursor.SelectedIndex = 0;
        }

        private void pictureBox_ImageShowForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pictureBox_ImageShowForm.Cursor = Cursors.SizeAll; // 改變游標類型
                b_MouseEvent = true;

                //mouseDownPoint.X = e.X; // 滑鼠游標在pictureBox上的座標
                mouseDownPoint.X = Cursor.Position.X; // 記錄鼠標左鍵按下時位置
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                //pictureBox_ImageShowForm.Focus(); // 鼠標滾輪事件(縮放時)需要picturebox有焦點
            }

            if (e.Button == MouseButtons.Left)
            {
                //this.radioButton_DrawImg.CheckedChanged -= new System.EventHandler(this.radioButton_CheckedChanged);
                radioButton_DrawImg.Checked = true;
                //this.radioButton_DrawImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);

                isMouseDown = true; // 滑鼠被按下後設定旗標值。
                points.Add(e.Location); // 將點加入到 points 陣列當中。
                ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));

                float w = ListPen[points.Count - 1].Width;
                g.DrawRectangle(ListPen[points.Count - 1], points[points.Count - 1].X - w / 2, points[points.Count - 1].Y - w / 2, w, w);
            }
        }

        private void pictureBox_ImageShowForm_MouseMove(object sender, MouseEventArgs e)
        {
            //pictureBox_ImageShowForm.Focus(); // 鼠標在picturebox上時才有焦點，此時可以縮放
            if (isMove)
            {
                int x, y; // 新的pictureBox1.Location(x,y)
                int moveX, moveY; // X方向，Y方向移動大小。
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox_ImageShowForm.Location.X + moveX;
                y = pictureBox_ImageShowForm.Location.Y + moveY;
                pictureBox_ImageShowForm.Location = new Point(x, y);
                //pictureBox_ImageShowForm.Location = new Point(Cursor.Position.X, Cursor.Position.Y); // Error!
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }

            if (isMouseDown) // 如果滑鼠被按下
            {
                points.Add(e.Location); // 將點加入到 points 陣列當中。
                ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));

                // 畫出上一點到此點的線段。
                //g.DrawLine(ListPen[points.Count - 1], points[points.Count - 2], points[points.Count - 1]);
                //g.DrawRectangle(ListPen[points.Count - 1], new Rectangle(points[points.Count - 1], new Size(1, 1)));
                //g.DrawRectangle(ListPen[points.Count - 1], points[points.Count - 1].X, points[points.Count - 1].Y, 1, 1);

                float w = ListPen[points.Count - 1].Width;
                g.DrawRectangle(ListPen[points.Count - 1], points[points.Count - 1].X - w / 2, points[points.Count - 1].Y - w / 2, w, w);

                //this.Invalidate();
            }

            // 顯示滑鼠游標座標資訊
            //label_Coordinate.Text = "(" + String.Format("{0:0}", e.X) + ", " + String.Format("{0:0}", e.Y) + ")";
            Point p_Image = CoordinateTrans_Cursor2Image(e.Location, LoadImage_bmp);
            label_Coordinate.Text = "(" + String.Format("{0:0}", p_Image.X) + ", " + String.Format("{0:0}", p_Image.Y) + ")";
            label_Coordinate_Cursor.Text = "(" + String.Format("{0:0}", Cursor.Position.X) + ", " + String.Format("{0:0}", Cursor.Position.Y) + ")";

            // 顯示【[R, G, B]:】及【灰階值:】
            if (LoadImage_bmp != null && p_Image.X >= 0 && p_Image.X < LoadImage_bmp.Width && p_Image.Y >= 0 && p_Image.Y < LoadImage_bmp.Height)
            {
                Color c = LoadImage_bmp.GetPixel(p_Image.X, p_Image.Y);
                System.Drawing.Imaging.PixelFormat Format = LoadImage_bmp.PixelFormat;
                if (Format == System.Drawing.Imaging.PixelFormat.Format8bppIndexed) // 灰階影像
                {
                    txt_GrayValue.Text = c.R.ToString();
                    txt_RGBValue.Text = "";
                }
                else
                {
                    txt_RGBValue.Text = "[" + c.R + ", " + c.G + ", " + c.B + "]";
                    txt_GrayValue.Text = "";
                }
            }
            else
            {
                txt_RGBValue.Text = "";
                txt_GrayValue.Text = "";
            }
        }

        private void pictureBox_ImageShowForm_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            if (isMove)
            {
                isMove = false;
                //pictureBox_ImageShowForm.Cursor = Cursors.Default; // 復原游標類型
                UpdateCursor(pictureBox_ImageShowForm);
            }

            if (isMouseDown)
            {
                isMouseDown = false; // 滑鼠已經沒有被按下了。
                points.Add(new Point(-1, -1)); // 滑鼠放開時，插入一個斷點 (-1,-1)，以代表前後兩點之間有斷開。
                ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));
            }
        }

        private void pictureBox_ImageShowForm_DoubleClick(object sender, EventArgs e)
        {
            pictureBox_ImageShowForm.Location = Initial_pictureBox1Location;
            pictureBox_ImageShowForm.Width = Initial_pictureBox1Width;
            pictureBox_ImageShowForm.Height = Initial_pictureBox1Height;
        }
        
        private void pictureBox_ImageShowForm_MouseWheel(object sender, MouseEventArgs e)
        {
            pictureBox_ImageShowForm.Cursor = Cursors.SizeAll; // 改變游標類型
            b_MouseEvent = true;

            try
            {
                int zoomStep = 300; // 定義滾輪滑動縮放大小
                int x = e.Location.X; // 滑鼠游標在pictureBox上的座標
                int y = e.Location.Y; // 滑鼠游標在pictureBox上的座標
                int ow = pictureBox_ImageShowForm.Width;
                int oh = pictureBox_ImageShowForm.Height;
                int VX, VY; // 因縮放產生的位移矢量(向量)
                if (e.Delta < 0) // 放大
                {
                    // 第①步
                    pictureBox_ImageShowForm.Width += zoomStep;
                    pictureBox_ImageShowForm.Height += zoomStep;
                    // 第②步
                    PropertyInfo pInfo = pictureBox_ImageShowForm.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox_ImageShowForm, null);
                    // 第③步
                    pictureBox_ImageShowForm.Width = rect.Width;
                    pictureBox_ImageShowForm.Height = rect.Height;
                }
                else if (e.Delta > 0) // 缩小
                {
                    // 防止一直縮成負值
                    if (pictureBox_ImageShowForm.Width < zoomStep || pictureBox_ImageShowForm.Height < zoomStep)
                    {
                        //pictureBox_ImageShowForm.Cursor = Cursors.Default; // 復原游標類型
                        return;
                    }

                    pictureBox_ImageShowForm.Width -= zoomStep;
                    pictureBox_ImageShowForm.Height -= zoomStep;
                    PropertyInfo pInfo = pictureBox_ImageShowForm.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox_ImageShowForm, null);
                    pictureBox_ImageShowForm.Width = rect.Width;
                    pictureBox_ImageShowForm.Height = rect.Height;
                }
                // 第④步，求因縮放產生的位移，進行補償，實現錨點縮放的效果
                VX = (int)((double)x * (ow - pictureBox_ImageShowForm.Width) / ow);
                VY = (int)((double)y * (oh - pictureBox_ImageShowForm.Height) / oh);
                pictureBox_ImageShowForm.Location = new Point(pictureBox_ImageShowForm.Location.X + VX, pictureBox_ImageShowForm.Location.Y + VY);
            }
            catch (Exception ex)
            {
                string message = "Error: " + ex.Message;
                MessageBox.Show(message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //pictureBox_ImageShowForm.Cursor = Cursors.Default; // 復原游標類型
        }

        bool b_MouseEvent = false;
        /// <summary>
        /// 發生於滑鼠指標停留在控制項上一段時間時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_ImageShowForm_MouseHover(object sender, EventArgs e)
        {
            //pictureBox_ImageShowForm.Cursor = Cursors.Default; // 復原游標類型
            if (b_MouseEvent)
            {
                b_MouseEvent = false;
                UpdateCursor(pictureBox_ImageShowForm);
            }
        }

        private Point CoordinateTrans_Cursor2Image(Point p_Cursor, Bitmap bmp)
        {
            Point p_Image = new Point(-1, -1);

            if (bmp != null)
            {
                p_Image.X = (int)(((double)p_Cursor.X / pictureBox_ImageShowForm.Width) * bmp.Width + 0.5);
                p_Image.Y = (int)(((double)p_Cursor.Y / pictureBox_ImageShowForm.Height) * bmp.Height + 0.5);
            }

            return p_Image;
        }

        Bitmap LoadImage_bmp = null;
        /// <summary>
        /// 【載入影像】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenImgDilg = new OpenFileDialog();
            if (OpenImgDilg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string path = OpenImgDilg.FileName;
            LoadImage_bmp = new Bitmap(path);
            pictureBox_ImageShowForm.Image = LoadImage_bmp;

            //g = Graphics.FromImage(LoadImage_bmp);
            //g = Graphics.FromImage(pictureBox_ImageShowForm.Image);

            // 影像尺寸
            label_Size.Visible = true;
            label_Size.Text = LoadImage_bmp.Width.ToString() + " × " + LoadImage_bmp.Height.ToString() + "像素";
            // 影像大小
            FileInfo F = new FileInfo(OpenImgDilg.FileName);
            label_Memory.Visible = true;
            double kb = F.Length / Math.Pow(1024, 1);
            if (kb < 1024)
                label_Memory.Text = "大小: " + kb.ToString("#0.0") + "KB";
            else
                label_Memory.Text = "大小: " + (F.Length / Math.Pow(1024, 2)).ToString("#0.0") + "MB";
        }

        private void pictureBox_ImageShowForm_Paint(object sender, PaintEventArgs e)
        {
            if (b_MouseEvent != true)
                g.Clear(System.Drawing.SystemColors.Control);
            //this.pictureBox_ImageShowForm.Paint -= new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);
            //pictureBox_ImageShowForm.Image = LoadImage_bmp;
            //this.pictureBox_ImageShowForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);

            g = e.Graphics;
            if (radioButton_DrawImg.Checked) // 標註影像
                Redraw_Label(g);
            g = pictureBox_ImageShowForm.CreateGraphics(); // 取得繪圖區物件
        }

        private void Redraw_Label(Graphics g_)
        {
            //g_.Clear(System.Drawing.SystemColors.Control); // 清除標註

            /*
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points[i].X >= 0 && points[i + 1].X >= 0)
                    g_.DrawLine(ListPen[i + 1], points[i], points[i + 1]);
            }
            */

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X >= 0)
                {
                    //g_.DrawRectangle(ListPen[i], new Rectangle(points[i], new Size(1, 1)));

                    float w = ListPen[i].Width;
                    g_.DrawRectangle(ListPen[i], points[i].X - w / 2, points[i].Y - w / 2, w, w);
                }
            }
        }

        /// <summary>
        /// 【Clear】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Click(object sender, EventArgs e)
        {
            /* 法1 */
            if (ListPen.Exists(x => x.Color == button_SetColor.BackColor))
            {
                while (true)
                {
                    int index = ListPen.FindIndex(x => x.Color == button_SetColor.BackColor);
                    if (index == -1)
                        break;
                    ListPen.RemoveAt(index);
                    points.RemoveAt(index);
                }
            }
            
            pictureBox_ImageShowForm.Invalidate();
        }

        /// <summary>
        /// 【Clear All】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            points.Clear();
            ListPen.Clear();
            pictureBox_ImageShowForm.Invalidate();
        }

        /// <summary>
        /// 【Save】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //pictureBox_ImageShowForm.Image.Save("SavedImg.bmp");

            Bitmap bmp = new Bitmap(LoadImage_bmp.Width, LoadImage_bmp.Height);
            Graphics g_save = Graphics.FromImage(bmp);
            //g_save.DrawImage(LoadImage_bmp, new Point(0, 0));
            g_save.DrawImage(LoadImage_bmp, 0, 0, LoadImage_bmp.Width, LoadImage_bmp.Height);
            //g_save.DrawImageUnscaled(LoadImage_bmp, new Point(0, 0));
            Redraw_Label(g_save);
            bmp.Save("SavedImg.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// 顏色設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_SetColor.ShowDialog() != DialogResult.Cancel)
            {
                button_SetColor.BackColor = colorDialog_SetColor.Color;

                // 更新滑鼠游標
                UpdateCursor(pictureBox_ImageShowForm);
            }
        }

        /// <summary>
        /// 標註顏色切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ChangeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_SetColor.ShowDialog() != DialogResult.Cancel)
            {
                Color OrigColor = button_SetColor.BackColor;
                button_SetColor.BackColor = colorDialog_SetColor.Color;

                // 更新滑鼠游標
                UpdateCursor(pictureBox_ImageShowForm);

                // 標註顏色切換
                foreach (Pen p in ListPen)
                {
                    if (checkBox_ChangeColor_All.Checked || p.Color == OrigColor)
                        p.Color = button_SetColor.BackColor;
                }
                Redraw_Label(g);
            }
        }

        /// <summary>
        /// 更新滑桿數值顯示標籤及其位置 (滑桿數值改變)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_width_Scroll(object sender, EventArgs e)
        {
            // 更新滑桿數值顯示
            label_widthValue.Text = trackBar_width.Value.ToString();

            // 更新顯示標籤位置
            int Min = label_width_Min.Top, Max = label_width_Max.Top;
            int value = trackBar_width.Value;
            label_widthValue.Top = (int)(Min + (Max - Min) / ((double)(trackBar_width.Maximum - trackBar_width.Minimum)) * (value - trackBar_width.Minimum) + 0.5);

            // 更新滑鼠游標
            UpdateCursor(pictureBox_ImageShowForm);
        }

        #region Cursor

        /// <summary>
        /// 滑鼠游標類型
        /// </summary>
        public enum enu_CursorImage
        {
            #region Windows Forms 內建游標類型

            Cross,
            Arrow,
            Default,
            SizeAll,
            Hand,

            #endregion

            Circle,
            Rectangle,
            Cross2,
            CrossCircle,
            CrossRectangle,
            DiamondCircle,
        };

        public static Bitmap CreateCursorImage(Size ImageSize, enu_CursorImage type, float DrawWidth = 5, Color color = default(Color))
        {
            int w = ImageSize.Width, h = ImageSize.Height;
            Bitmap bmp = new Bitmap(w, h);
            float x = (float)(ImageSize.Width / 2.0), y = (float)(ImageSize.Height / 2.0);
            Graphics g = Graphics.FromImage(bmp); // 將Graphics g畫布 畫在bmp上

            if (object.Equals(color, default(Color)))
                color = Color.Black;
            Brush bb = new SolidBrush(color);

            // 輪廓
            Pen p;
            if (color != Color.Black)
                p = new Pen(Color.Black, 1);
            else
                p = new Pen(Color.White, 1);

            switch (type)
            {
                case enu_CursorImage.Circle:
                    {
                        g.FillEllipse(bb, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth);
                        g.DrawEllipse(p, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth); // 輪廓
                    }
                    break;
                case enu_CursorImage.Rectangle:
                    {
                        g.FillRectangle(bb, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth);
                        g.DrawRectangle(p, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth); // 輪廓
                    }
                    break;
                case enu_CursorImage.Cross2:
                    {
                        // 輪廓
                        p.Width = 2;
                        g.DrawLine(p, x, y - DrawWidth / 2, x, y + DrawWidth / 2 - 1);
                        g.DrawLine(p, x - DrawWidth / 2, y, x + DrawWidth / 2 - 1, y);

                        p = new Pen(color, 1);
                        g.DrawLine(p, x, y - DrawWidth / 2, x, y + DrawWidth / 2 - 1);
                        g.DrawLine(p, x - DrawWidth / 2, y, x + DrawWidth / 2 - 1, y);
                    }
                    break;
                case enu_CursorImage.CrossCircle:
                    {
                        // Circle
                        g.FillEllipse(bb, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth);
                        g.DrawEllipse(p, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth); // 輪廓

                        // Cross
                        float len = (y - DrawWidth / 2) * 3 / 5;
                        g.DrawLine(p, x, 0, x, len);
                        g.DrawLine(p, x, h - 1, x, h - len);
                        g.DrawLine(p, 0, y, len, y);
                        g.DrawLine(p, w - 1, y, w - len, y);
                    }
                    break;
                case enu_CursorImage.CrossRectangle:
                    {
                        // Rectangle
                        g.FillRectangle(bb, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth);
                        g.DrawRectangle(p, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth); // 輪廓

                        // Cross
                        float len = (y - DrawWidth / 2) * 3 / 5;
                        g.DrawLine(p, x, 0, x, len);
                        g.DrawLine(p, x, h - 1, x, h - len);
                        g.DrawLine(p, 0, y, len, y);
                        g.DrawLine(p, w - 1, y, w - len, y);
                    }
                    break;
                case enu_CursorImage.DiamondCircle:
                    {
                        // Circle
                        g.FillEllipse(bb, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth);
                        g.DrawEllipse(p, x - DrawWidth / 2, y - DrawWidth / 2, DrawWidth, DrawWidth); // 輪廓

                        // Diamond
                        g.DrawLine(p, x, 0, w - 1, y);
                        g.DrawLine(p, w - 1, y, x, h - 1);
                        g.DrawLine(p, x, h - 1, 0, y);
                        g.DrawLine(p, 0, y, x, 0);
                    }
                    break;
            }

            return bmp;
        }

        public static Cursor CreateCursor(Bitmap bm, object size = null, object transparentColor = null)
        {
            if (size == null)
            {
                //bm = new Bitmap(bm);
            }
            else
                bm = new Bitmap(bm, (Size)size);

            if (transparentColor == null)
                bm.MakeTransparent();
            else
                bm.MakeTransparent((Color)transparentColor);

            return new Cursor(bm.GetHicon());
        }

        /// <summary>
        /// 更新滑鼠游標
        /// </summary>
        public void UpdateCursor(Control ctrl_Cursor = null)
        {
            if (ctrl_Cursor == null)
                ctrl_Cursor = this;

            // 判斷是否為Windows Forms 內建游標類型
            Type t = typeof(Cursors);
            MemberInfo[] mis = t.GetMembers();
            List<string> ListStr = new List<string>();
            foreach (var m in mis)
                ListStr.Add(m.Name);
            enu_CursorImage type = (enu_CursorImage)cbx_Cursor.SelectedIndex;
            if (ListStr.Contains(type.ToString())) // Windows Forms 內建游標類型
            {
                switch (type)
                {
                    case enu_CursorImage.Cross:
                        ctrl_Cursor.Cursor = Cursors.Cross;
                        break;
                    case enu_CursorImage.Arrow:
                        ctrl_Cursor.Cursor = Cursors.Arrow;
                        break;
                    case enu_CursorImage.Default:
                        ctrl_Cursor.Cursor = Cursors.Default;
                        break;
                    case enu_CursorImage.SizeAll:
                        ctrl_Cursor.Cursor = Cursors.SizeAll;
                        break;
                    case enu_CursorImage.Hand:
                        ctrl_Cursor.Cursor = Cursors.Hand;
                        break;
                }
            }
            else // 自定義游標類型
            {
                float w = 2 * trackBar_width.Value;
                Bitmap bm = CreateCursorImage(new Size((int)(5 * w), (int)(5 * w)), type, w, button_SetColor.BackColor);
                //ctrl_Cursor.Cursor.Dispose();
                ctrl_Cursor.Cursor = CreateCursor(bm);
                //bm.Dispose();
            }
        }

        /// <summary>
        /// 顯示影像切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked == false) return;

            pictureBox_ImageShowForm.Invalidate();
        }
        
        /// <summary>
        /// 【游標類型】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Cursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursor(pictureBox_ImageShowForm);
            //this.Cursor = Cursors.Default;
        }

        #endregion

    }
}
