/*
    Date: 2020/04/07
    Title: 小畫板 -- 用 C# 實作
    Link: http://cs0.wikidot.com/painter
    Title: C# - Create cursor from image
    Link: https://www.youtube.com/watch?v=fxjCB84sCxo&fbclid=IwAR24dk1RtHzB7JD0c7-nvi06p0x0CpQyadQ5BLJLFXyL_pknrVaXfXQcfwU
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

using System.Reflection;

namespace Painter
{
    public partial class Form1 : Form
    {
        Graphics g;                 // 繪圖區
        //Pen pen;                  // 畫筆
        bool isMouseDown = false;   // 紀錄滑鼠是否被按下
        List<Point> points = new List<Point>(); // 紀錄滑鼠軌跡的陣列。
        List<Pen> ListPen = new List<Pen>(); // 紀錄不同滑鼠軌跡段落之顏色及大小
        
        public Form1()
        {
            InitializeComponent();

            g = this.CreateGraphics(); // 取得繪圖區物件
            //pen = new Pen(button_SetColor.BackColor, 3); // 設定畫筆為黑色、粗細為 3 點。
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Cursor = CreateCursor((Bitmap)imageList_cursor.Images[1], new Size(50, 50), Color.White);
            //this.Cursor = CreateCursor((Bitmap)imageList_cursor.Images[2], new Size(50, 50));
            //this.Cursor = CreateCursor((Bitmap)imageList_cursor.Images[2], new Size(150, 150), Color.White);

            string[] ArrayCursor = Enum.GetNames(typeof(enu_CursorImage));
            cbx_Cursor.Items.Clear();
            foreach (string s in ArrayCursor)
                cbx_Cursor.Items.Add(s);
            if (cbx_Cursor.Items.Count > 0)
                cbx_Cursor.SelectedIndex = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true; // 滑鼠被按下後設定旗標值。
                points.Add(e.Location); // 將點加入到 points 陣列當中。
                ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));

                float w = ListPen[points.Count - 1].Width;
                g.DrawRectangle(ListPen[points.Count - 1], points[points.Count - 1].X - w / 2, points[points.Count - 1].Y - w / 2, w, w);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
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
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false; // 滑鼠已經沒有被按下了。
                points.Add(new Point(-1, -1)); // 滑鼠放開時，插入一個斷點 (-1,-1)，以代表前後兩點之間有斷開。
                ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Redraw_Label(g);
        }

        private void Redraw_Label(Graphics g_)
        {
            g_.Clear(System.Drawing.SystemColors.Control); // 清除標註

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

        private void button_Clear_Click(object sender, EventArgs e)
        {
            points.Clear();
            ListPen.Clear();
            g.Clear(System.Drawing.SystemColors.Control);
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
                UpdateCursor();
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
                UpdateCursor();
                
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
            UpdateCursor();
        }

        /// <summary>
        /// 更新繪圖區範圍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            g = this.CreateGraphics(); // 取得繪圖區物件
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
        /// 【游標類型】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Cursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursor();
        }

        #endregion
    }
}
