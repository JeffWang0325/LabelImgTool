using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Media; // For SystemSounds

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2.SaveSetting
{
    public partial class SaveSetting_Form : Form
    {
        private Dictionary<string, Label> Dictionary_Label { get; set; } = new Dictionary<string, Label>();

        /// <summary>
        /// ON 時，控制項啟用
        /// </summary>
        private Dictionary<string, List<Control>> Dict_ON_Enabled { get; set; } = new Dictionary<string, List<Control>>();
        /// <summary>
        /// OFF 時，控制項啟用
        /// </summary>
        private Dictionary<string, List<Control>> Dict_OFF_Enabled { get; set; } = new Dictionary<string, List<Control>>();

        private cls_SaveSetting saveSetting { get; set; } = new cls_SaveSetting();
        
        public SaveSetting_Form()
        {
            InitializeComponent();

            this.Dictionary_Label.Add("save_label", lbl_save_label);
            this.Dictionary_Label.Add("save_OrigImage", lbl_save_OrigImage);
            this.Dictionary_Label.Add("save_Image1", lbl_save_Image1);
            this.Dictionary_Label.Add("save_Image2", lbl_save_Image2);
            this.Dictionary_Label.Add("save_Image3", lbl_save_Image3);
            this.Dictionary_Label.Add("Load_AllImageFormat", lbl_Load_AllImageFormat);
            this.Dictionary_Label.Add("Save_SameImageFormat", lbl_Save_SameImageFormat);
            this.Dictionary_Label.Add("B_ColorList", lbl_B_ColorList);

            this.Dict_ON_Enabled.Add("save_label", new List<Control>() { this.label_FileName_label , this.textBox_FileName_label });
            this.Dict_ON_Enabled.Add("save_OrigImage", new List<Control>() { this.label_FileName_OrigImage, this.textBox_FileName_OrigImage });
            this.Dict_ON_Enabled.Add("save_Image1", new List<Control>() { this.label_FileName_Image1, this.textBox_FileName_Image1 });
            this.Dict_ON_Enabled.Add("save_Image2", new List<Control>() { this.label_FileName_Image2, this.textBox_FileName_Image2 });
            this.Dict_ON_Enabled.Add("save_Image3", new List<Control>() { this.label_FileName_Image3, this.textBox_FileName_Image3 });
            this.Dict_ON_Enabled.Add("B_ColorList", new List<Control>() { this.panel_ColorList });

            this.Dict_OFF_Enabled.Add("Load_AllImageFormat", new List<Control>() { this.label_ImageFormat_Load, this.cbx_ImageFormat_Load });
            this.Dict_OFF_Enabled.Add("Save_SameImageFormat", new List<Control>() { this.label_ImageFormat_Save, this.cbx_ImageFormat_Save });

            clsLanguage.clsLanguage.SetLanguateToControls(this, true, "false");
        }

        public void Set_saveSetting(cls_SaveSetting saveSetting_)
        {
            this.saveSetting = saveSetting_;
        }

        private void SaveSetting_Form_Load(object sender, EventArgs e)
        {
            #region ComboBox 新增項目

            // 新增 cbx_ImageFormat_Load & cbx_ImageFormat_Save 項目
            this.cbx_ImageFormat_Load.Items.Clear();
            this.cbx_ImageFormat_Save.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(enu_ImageFormat)))
            {
                this.cbx_ImageFormat_Load.Items.Add(item);
                this.cbx_ImageFormat_Save.Items.Add(item);
            }

            // 新增 cbx_Module 項目
            this.cbx_Module.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(enu_Module)))
                this.cbx_Module.Items.Add(item);

            #endregion

            #region 更新GUI參數

            this.ui_parameters(false);

            #endregion
        }

        /// <summary>
        /// 將 GUI參數 與 saveSetting參數 互傳
        /// </summary>
        /// <param name="ui_2_parameters_">True: UI傳至saveSetting, False: saveSetting傳至UI</param>
        /// <param name="saveSetting_"></param>
        /// <returns></returns>
        public bool ui_parameters(bool ui_2_parameters_, cls_SaveSetting saveSetting_ = null)
        {
            bool b_status_ = false;
            if (saveSetting_ == null)
                saveSetting_ = this.saveSetting;

            try
            {
                if (ui_2_parameters_)
                {
                    #region 將UI內容回傳至saveSetting_

                    saveSetting_.Folder_Save = this.txb_SavePath.Text;

                    saveSetting_.B_save_label = this.cbx_save_label.Checked;
                    saveSetting_.FileName_label = this.textBox_FileName_label.Text;

                    saveSetting_.B_save_OrigImage = this.cbx_save_OrigImage.Checked;
                    saveSetting_.FileName_OrigImage = this.textBox_FileName_OrigImage.Text;

                    saveSetting_.B_save_label_Image1 = this.cbx_save_Image1.Checked;
                    saveSetting_.FileName_label_Image1 = this.textBox_FileName_Image1.Text;

                    saveSetting_.B_save_label_Image2 = this.cbx_save_Image2.Checked;
                    saveSetting_.FileName_label_Image2 = this.textBox_FileName_Image2.Text;

                    saveSetting_.B_save_label_Image3 = this.cbx_save_Image3.Checked;
                    saveSetting_.FileName_label_Image3 = this.textBox_FileName_Image3.Text;

                    saveSetting_.B_Load_AllImageFormat = this.cbx_Load_AllImageFormat.Checked;
                    saveSetting_.ImageFormat_Load = (enu_ImageFormat)(this.cbx_ImageFormat_Load.SelectedIndex);

                    saveSetting_.B_Save_SameImageFormat = this.cbx_Save_SameImageFormat.Checked;
                    saveSetting_.ImageFormat_Save = (enu_ImageFormat)(this.cbx_ImageFormat_Save.SelectedIndex);

                    saveSetting_.B_ColorList = this.cbx_B_ColorList.Checked;
                    saveSetting_.ColorList.Clear();
                    foreach (RadioButton rbt in this.List_rbt_ColorList)
                        saveSetting_.ColorList.Add(rbt.BackColor);

                    saveSetting_.Index_Module = this.cbx_Module.SelectedIndex;

                    #endregion
                }
                else
                {
                    #region 將saveSetting_內容傳至UI

                    this.txb_SavePath.Text = saveSetting_.Folder_Save;

                    this.cbx_save_label.Checked = saveSetting_.B_save_label;
                    this.textBox_FileName_label.Text = saveSetting_.FileName_label;

                    this.cbx_save_OrigImage.Checked = saveSetting_.B_save_OrigImage;
                    this.textBox_FileName_OrigImage.Text = saveSetting_.FileName_OrigImage;

                    this.cbx_save_Image1.Checked = saveSetting_.B_save_label_Image1;
                    this.textBox_FileName_Image1.Text = saveSetting_.FileName_label_Image1;

                    this.cbx_save_Image2.Checked = saveSetting_.B_save_label_Image2;
                    this.textBox_FileName_Image2.Text = saveSetting_.FileName_label_Image2;

                    this.cbx_save_Image3.Checked = saveSetting_.B_save_label_Image3;
                    this.textBox_FileName_Image3.Text = saveSetting_.FileName_label_Image3;

                    this.cbx_Load_AllImageFormat.Checked = saveSetting_.B_Load_AllImageFormat;
                    this.cbx_ImageFormat_Load.SelectedIndex = (int)(saveSetting_.ImageFormat_Load);

                    this.cbx_Save_SameImageFormat.Checked = saveSetting_.B_Save_SameImageFormat;
                    this.cbx_ImageFormat_Save.SelectedIndex = (int)(saveSetting_.ImageFormat_Save);

                    this.cbx_B_ColorList.Checked = saveSetting_.B_ColorList;
                    this.nud_Count_ColorList.Value = saveSetting_.ColorList.Count;
                    // 法1
                    //var Rbt_C_Pairs = this.List_rbt_ColorList.Zip(saveSetting_.ColorList, (rbt, c) => new { Rbt = rbt, C = c });
                    //foreach (var Rbt_C in Rbt_C_Pairs)
                    //    Rbt_C.Rbt.BackColor = Rbt_C.C;
                    // 法2
                    foreach (var Rbt_C in this.List_rbt_ColorList.Zip(saveSetting_.ColorList, Tuple.Create))
                        Rbt_C.Item1.BackColor = Rbt_C.Item2;

                    this.cbx_Module.SelectedIndex = saveSetting_.Index_Module;

                    #endregion
                }

                b_status_ = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return b_status_;
        }

        /// <summary>
        /// 【儲存路徑】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_SavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Dilg = new FolderBrowserDialog();
            Dilg.SelectedPath = this.txb_SavePath.Text; // 初始路徑
            if (Dilg.ShowDialog() != DialogResult.OK)
                return;

            this.txb_SavePath.Text = Dilg.SelectedPath;
            if (string.IsNullOrEmpty(this.txb_SavePath.Text))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("路徑無效!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txb_SavePath.Text = Application.StartupPath;
                return;
            }
        }

        /// <summary>
        /// 改變ON/OFF狀態
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = sender as CheckBox;
            string Tag = cbx.Tag.ToString();
            if (cbx.Checked) // ON
            {
                cbx.BackgroundImage = Properties.Resources.ON;
                if (this.Dictionary_Label.ContainsKey(Tag))
                {
                    this.Dictionary_Label[Tag].Text = "ON";
                    this.Dictionary_Label[Tag].ForeColor = Color.DeepSkyBlue;
                }
            }
            else // OFF
            {
                cbx.BackgroundImage = Properties.Resources.OFF_edited;
                if (this.Dictionary_Label.ContainsKey(Tag))
                {
                    this.Dictionary_Label[Tag].Text = "OFF";
                    this.Dictionary_Label[Tag].ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                }
            }

            // Enabled狀態切換
            if (this.Dict_ON_Enabled.ContainsKey(Tag))
            {
                foreach (Control c in this.Dict_ON_Enabled[Tag])
                    c.Enabled = cbx.Checked;
            }
            else if (this.Dict_OFF_Enabled.ContainsKey(Tag))
            {
                foreach (Control c in this.Dict_OFF_Enabled[Tag])
                    c.Enabled = !(cbx.Checked);
            }
        }

        #region 【顏色快捷列表】

        private List<RadioButton> List_rbt_ColorList { get; set; } = new List<RadioButton>();
        
        /// <summary>
        /// 顏色快捷數量更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Count_ColorList_ValueChanged(object sender, EventArgs e)
        {
            int count_ColorList = int.Parse(this.nud_Count_ColorList.Value.ToString());
            if (count_ColorList <= 0)
            {
                foreach (RadioButton rbt in this.List_rbt_ColorList)
                    this.panel_ColorList.Controls.Remove(rbt);
                this.List_rbt_ColorList.Clear();
                return;
            }

            if (count_ColorList >= this.List_rbt_ColorList.Count)
            {
                while (count_ColorList != this.List_rbt_ColorList.Count)
                {
                    Point loc_1st = new Point(180, 5);
                    int dx = 40, dy = 40;
                    int row = 2, col = 10;
                    int index = this.List_rbt_ColorList.Count;
                    int x = 0, y = 0;
                    y = index / col;
                    x = index - y * col;

                    // RadioButton 宣告及屬性設定
                    RadioButton rbt = new RadioButton();
                    rbt.Appearance = System.Windows.Forms.Appearance.Button;
                    rbt.AutoSize = true;
                    rbt.BackColor = System.Drawing.Color.Black;
                    rbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    rbt.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
                    rbt.Location = new System.Drawing.Point(loc_1st.X + dx * x, loc_1st.Y + dy * y);
                    rbt.Name = "Dynamic_radioButton_" + index.ToString();
                    rbt.Size = new System.Drawing.Size(35, 34);
                    rbt.Text = "   ";
                    rbt.UseVisualStyleBackColor = false;
                    rbt.Click += (sender1, ex) => this.Dynamic_radioButton_Click(sender1, ex);

                    this.panel_ColorList.Controls.Add(rbt);
                    this.List_rbt_ColorList.Add(rbt);
                }
            }
            else
            {
                while (count_ColorList != this.List_rbt_ColorList.Count)
                {
                    int index = this.List_rbt_ColorList.Count - 1;
                    this.panel_ColorList.Controls.Remove(this.List_rbt_ColorList[index]);
                    this.List_rbt_ColorList.RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// 【顏色快捷列表】 Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dynamic_radioButton_Click(object sender, EventArgs e)
        {
            RadioButton rbt = sender as RadioButton;
            ColorDialog colorDialog_SetColor = new ColorDialog();
            colorDialog_SetColor.Color = rbt.BackColor;
            if (colorDialog_SetColor.ShowDialog() != DialogResult.Cancel)
                rbt.BackColor = colorDialog_SetColor.Color;
        }

        #endregion

        /// <summary>
        /// 【載入預設值】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadDefaultValues_Click(object sender, EventArgs e)
        {
            cls_SaveSetting saveSetting_ = new cls_SaveSetting();
            this.ui_parameters(false, saveSetting_);
        }

        /// <summary>
        /// 【關閉】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            //this.Close();
            DialogResult = DialogResult.Cancel; // 會自動關閉表單
        }

        /// <summary>
        /// 【儲存】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("確認是否【儲存】?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            if (!(this.ui_parameters(true)))
            {
                MessageBox.Show("【儲存】失敗!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool b_status_ = this.saveSetting.Save();
            
            if (b_status_)
            {
                MessageBox.Show("【儲存】成功", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Yes; // 會自動關閉表單
            }
            else
                MessageBox.Show("【儲存】失敗!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region 讓使用者可移動視窗

        int curr_x, curr_y;
        bool isWndMove;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.curr_x = e.X;
                this.curr_y = e.Y;
                this.isWndMove = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isWndMove)
            {
                //this.Location = new Point(this.Left + e.X - this.curr_x, this.Top + e.Y - this.curr_y);
                this.Location = new Point(Control.MousePosition.X - e.X + (e.X - this.curr_x), Control.MousePosition.Y - e.Y + (e.Y - this.curr_y));
            }
        }
        
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isWndMove = false;
        }

        #endregion
    }
}
