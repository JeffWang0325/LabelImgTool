namespace Painter2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_ImageShowForm = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.button_ChangeColor = new System.Windows.Forms.Button();
            this.checkBox_ChangeColor_All = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Cursor = new System.Windows.Forms.ComboBox();
            this.label_widthValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_width = new System.Windows.Forms.TrackBar();
            this.label_width_Max = new System.Windows.Forms.Label();
            this.label_width_Min = new System.Windows.Forms.Label();
            this.button_SetColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Coordinate = new System.Windows.Forms.Label();
            this.label_Coordinate_Cursor = new System.Windows.Forms.Label();
            this.colorDialog_SetColor = new System.Windows.Forms.ColorDialog();
            this.radioButton_OrigImg = new System.Windows.Forms.RadioButton();
            this.radioButton_DrawImg = new System.Windows.Forms.RadioButton();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_Size = new System.Windows.Forms.Label();
            this.label_Memory = new System.Windows.Forms.Label();
            this.txt_GrayValue = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_RGBValue = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageShowForm)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_width)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ImageShowForm
            // 
            this.pictureBox_ImageShowForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_ImageShowForm.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ImageShowForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_ImageShowForm.Name = "pictureBox_ImageShowForm";
            this.pictureBox_ImageShowForm.Size = new System.Drawing.Size(630, 480);
            this.pictureBox_ImageShowForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ImageShowForm.TabIndex = 1;
            this.pictureBox_ImageShowForm.TabStop = false;
            this.pictureBox_ImageShowForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);
            this.pictureBox_ImageShowForm.DoubleClick += new System.EventHandler(this.pictureBox_ImageShowForm_DoubleClick);
            this.pictureBox_ImageShowForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseDown);
            this.pictureBox_ImageShowForm.MouseHover += new System.EventHandler(this.pictureBox_ImageShowForm_MouseHover);
            this.pictureBox_ImageShowForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseMove);
            this.pictureBox_ImageShowForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox_ImageShowForm);
            this.panel1.Location = new System.Drawing.Point(190, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 480);
            this.panel1.TabIndex = 2;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadImg.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Bold);
            this.btnLoadImg.Image = global::Painter2.Properties.Resources.picture32;
            this.btnLoadImg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadImg.Location = new System.Drawing.Point(23, 13);
            this.btnLoadImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(101, 67);
            this.btnLoadImg.TabIndex = 75;
            this.btnLoadImg.Text = "載入影像";
            this.btnLoadImg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // button_ChangeColor
            // 
            this.button_ChangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_ChangeColor.Location = new System.Drawing.Point(28, 379);
            this.button_ChangeColor.Name = "button_ChangeColor";
            this.button_ChangeColor.Size = new System.Drawing.Size(119, 32);
            this.button_ChangeColor.TabIndex = 193;
            this.button_ChangeColor.Text = "標註顏色切換";
            this.button_ChangeColor.UseVisualStyleBackColor = true;
            this.button_ChangeColor.Click += new System.EventHandler(this.button_ChangeColor_Click);
            // 
            // checkBox_ChangeColor_All
            // 
            this.checkBox_ChangeColor_All.AutoSize = true;
            this.checkBox_ChangeColor_All.Location = new System.Drawing.Point(56, 418);
            this.checkBox_ChangeColor_All.Name = "checkBox_ChangeColor_All";
            this.checkBox_ChangeColor_All.Size = new System.Drawing.Size(69, 17);
            this.checkBox_ChangeColor_All.TabIndex = 192;
            this.checkBox_ChangeColor_All.Text = "All Colors";
            this.checkBox_ChangeColor_All.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 191;
            this.label2.Text = "游標類型";
            // 
            // cbx_Cursor
            // 
            this.cbx_Cursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Cursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbx_Cursor.FormattingEnabled = true;
            this.cbx_Cursor.Location = new System.Drawing.Point(12, 138);
            this.cbx_Cursor.Name = "cbx_Cursor";
            this.cbx_Cursor.Size = new System.Drawing.Size(135, 28);
            this.cbx_Cursor.TabIndex = 190;
            this.cbx_Cursor.SelectedIndexChanged += new System.EventHandler(this.cbx_Cursor_SelectedIndexChanged);
            // 
            // label_widthValue
            // 
            this.label_widthValue.AutoSize = true;
            this.label_widthValue.BackColor = System.Drawing.Color.Transparent;
            this.label_widthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_widthValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_widthValue.Location = new System.Drawing.Point(88, 273);
            this.label_widthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_widthValue.Name = "label_widthValue";
            this.label_widthValue.Size = new System.Drawing.Size(18, 20);
            this.label_widthValue.TabIndex = 189;
            this.label_widthValue.Text = "3";
            this.label_widthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 186;
            this.label1.Text = "寬度";
            // 
            // trackBar_width
            // 
            this.trackBar_width.Location = new System.Drawing.Point(68, 195);
            this.trackBar_width.Maximum = 200;
            this.trackBar_width.Minimum = 1;
            this.trackBar_width.Name = "trackBar_width";
            this.trackBar_width.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_width.Size = new System.Drawing.Size(45, 104);
            this.trackBar_width.TabIndex = 185;
            this.trackBar_width.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_width.Value = 3;
            this.trackBar_width.Scroll += new System.EventHandler(this.trackBar_width_Scroll);
            // 
            // label_width_Max
            // 
            this.label_width_Max.AutoSize = true;
            this.label_width_Max.BackColor = System.Drawing.Color.Transparent;
            this.label_width_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_width_Max.ForeColor = System.Drawing.Color.Black;
            this.label_width_Max.Location = new System.Drawing.Point(35, 198);
            this.label_width_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Max.Name = "label_width_Max";
            this.label_width_Max.Size = new System.Drawing.Size(36, 20);
            this.label_width_Max.TabIndex = 188;
            this.label_width_Max.Text = "200";
            this.label_width_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_width_Min
            // 
            this.label_width_Min.AutoSize = true;
            this.label_width_Min.BackColor = System.Drawing.Color.Transparent;
            this.label_width_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_width_Min.ForeColor = System.Drawing.Color.Black;
            this.label_width_Min.Location = new System.Drawing.Point(44, 275);
            this.label_width_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Min.Name = "label_width_Min";
            this.label_width_Min.Size = new System.Drawing.Size(18, 20);
            this.label_width_Min.TabIndex = 187;
            this.label_width_Min.Text = "1";
            this.label_width_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_SetColor
            // 
            this.button_SetColor.BackColor = System.Drawing.Color.Black;
            this.button_SetColor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SetColor.ForeColor = System.Drawing.Color.Transparent;
            this.button_SetColor.Location = new System.Drawing.Point(64, 325);
            this.button_SetColor.Name = "button_SetColor";
            this.button_SetColor.Size = new System.Drawing.Size(49, 48);
            this.button_SetColor.TabIndex = 184;
            this.button_SetColor.UseVisualStyleBackColor = false;
            this.button_SetColor.Click += new System.EventHandler(this.button_SetColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 183;
            this.label4.Text = "Color";
            // 
            // button_ClearAll
            // 
            this.button_ClearAll.Location = new System.Drawing.Point(93, 441);
            this.button_ClearAll.Name = "button_ClearAll";
            this.button_ClearAll.Size = new System.Drawing.Size(75, 23);
            this.button_ClearAll.TabIndex = 182;
            this.button_ClearAll.Text = "Clear All";
            this.button_ClearAll.UseVisualStyleBackColor = true;
            this.button_ClearAll.Click += new System.EventHandler(this.button_ClearAll_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(48, 468);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 194;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Coordinate
            // 
            this.label_Coordinate.AutoSize = true;
            this.label_Coordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Coordinate.Location = new System.Drawing.Point(185, 505);
            this.label_Coordinate.Name = "label_Coordinate";
            this.label_Coordinate.Size = new System.Drawing.Size(73, 20);
            this.label_Coordinate.TabIndex = 195;
            this.label_Coordinate.Text = "像素座標";
            // 
            // label_Coordinate_Cursor
            // 
            this.label_Coordinate_Cursor.AutoSize = true;
            this.label_Coordinate_Cursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Coordinate_Cursor.Location = new System.Drawing.Point(186, 532);
            this.label_Coordinate_Cursor.Name = "label_Coordinate_Cursor";
            this.label_Coordinate_Cursor.Size = new System.Drawing.Size(105, 20);
            this.label_Coordinate_Cursor.TabIndex = 196;
            this.label_Coordinate_Cursor.Text = "滑鼠游標座標";
            this.label_Coordinate_Cursor.Visible = false;
            // 
            // radioButton_OrigImg
            // 
            this.radioButton_OrigImg.AutoSize = true;
            this.radioButton_OrigImg.Checked = true;
            this.radioButton_OrigImg.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_OrigImg.Location = new System.Drawing.Point(14, 88);
            this.radioButton_OrigImg.Name = "radioButton_OrigImg";
            this.radioButton_OrigImg.Size = new System.Drawing.Size(52, 21);
            this.radioButton_OrigImg.TabIndex = 197;
            this.radioButton_OrigImg.TabStop = true;
            this.radioButton_OrigImg.Text = "原圖";
            this.radioButton_OrigImg.UseVisualStyleBackColor = true;
            this.radioButton_OrigImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_DrawImg
            // 
            this.radioButton_DrawImg.AutoSize = true;
            this.radioButton_DrawImg.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_DrawImg.Location = new System.Drawing.Point(84, 88);
            this.radioButton_DrawImg.Name = "radioButton_DrawImg";
            this.radioButton_DrawImg.Size = new System.Drawing.Size(78, 21);
            this.radioButton_DrawImg.TabIndex = 198;
            this.radioButton_DrawImg.TabStop = true;
            this.radioButton_DrawImg.Text = "標註影像";
            this.radioButton_DrawImg.UseVisualStyleBackColor = true;
            this.radioButton_DrawImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(14, 441);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 199;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_Size
            // 
            this.label_Size.AutoSize = true;
            this.label_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Size.Location = new System.Drawing.Point(334, 505);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(73, 20);
            this.label_Size.TabIndex = 200;
            this.label_Size.Text = "影像尺寸";
            this.label_Size.Visible = false;
            // 
            // label_Memory
            // 
            this.label_Memory.AutoSize = true;
            this.label_Memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Memory.Location = new System.Drawing.Point(484, 505);
            this.label_Memory.Name = "label_Memory";
            this.label_Memory.Size = new System.Drawing.Size(73, 20);
            this.label_Memory.TabIndex = 201;
            this.label_Memory.Text = "影像大小";
            this.label_Memory.Visible = false;
            // 
            // txt_GrayValue
            // 
            this.txt_GrayValue.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_GrayValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_GrayValue.Location = new System.Drawing.Point(672, 536);
            this.txt_GrayValue.Name = "txt_GrayValue";
            this.txt_GrayValue.ReadOnly = true;
            this.txt_GrayValue.Size = new System.Drawing.Size(148, 27);
            this.txt_GrayValue.TabIndex = 226;
            this.txt_GrayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(616, 539);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 19);
            this.label20.TabIndex = 225;
            this.label20.Text = "灰階值:";
            // 
            // txt_RGBValue
            // 
            this.txt_RGBValue.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_RGBValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RGBValue.Location = new System.Drawing.Point(672, 503);
            this.txt_RGBValue.Name = "txt_RGBValue";
            this.txt_RGBValue.ReadOnly = true;
            this.txt_RGBValue.Size = new System.Drawing.Size(148, 27);
            this.txt_RGBValue.TabIndex = 224;
            this.txt_RGBValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(607, 506);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 19);
            this.label19.TabIndex = 223;
            this.label19.Text = "[R, G, B]:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 575);
            this.Controls.Add(this.txt_GrayValue);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txt_RGBValue);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label_Memory);
            this.Controls.Add(this.label_Size);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.radioButton_OrigImg);
            this.Controls.Add(this.radioButton_DrawImg);
            this.Controls.Add(this.label_Coordinate_Cursor);
            this.Controls.Add(this.label_Coordinate);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_ChangeColor);
            this.Controls.Add(this.checkBox_ChangeColor_All);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_Cursor);
            this.Controls.Add(this.label_widthValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_width);
            this.Controls.Add(this.label_width_Max);
            this.Controls.Add(this.label_width_Min);
            this.Controls.Add(this.button_SetColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_ClearAll);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "進階小畫家";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageShowForm)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ImageShowForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button button_ChangeColor;
        private System.Windows.Forms.CheckBox checkBox_ChangeColor_All;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_Cursor;
        private System.Windows.Forms.Label label_widthValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_width;
        private System.Windows.Forms.Label label_width_Max;
        private System.Windows.Forms.Label label_width_Min;
        private System.Windows.Forms.Button button_SetColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_ClearAll;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Coordinate;
        private System.Windows.Forms.Label label_Coordinate_Cursor;
        private System.Windows.Forms.ColorDialog colorDialog_SetColor;
        private System.Windows.Forms.RadioButton radioButton_OrigImg;
        private System.Windows.Forms.RadioButton radioButton_DrawImg;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label_Size;
        private System.Windows.Forms.Label label_Memory;
        private System.Windows.Forms.TextBox txt_GrayValue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_RGBValue;
        private System.Windows.Forms.Label label19;
    }
}

