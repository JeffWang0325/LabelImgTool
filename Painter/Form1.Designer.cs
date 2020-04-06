namespace Painter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_SetColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog_SetColor = new System.Windows.Forms.ColorDialog();
            this.label_widthValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_width = new System.Windows.Forms.TrackBar();
            this.label_width_Max = new System.Windows.Forms.Label();
            this.label_width_Min = new System.Windows.Forms.Label();
            this.imageList_cursor = new System.Windows.Forms.ImageList(this.components);
            this.cbx_Cursor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ChangeColor_All = new System.Windows.Forms.CheckBox();
            this.button_ChangeColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_width)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(746, 474);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 0;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_SetColor
            // 
            this.button_SetColor.BackColor = System.Drawing.Color.Black;
            this.button_SetColor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SetColor.ForeColor = System.Drawing.Color.Transparent;
            this.button_SetColor.Location = new System.Drawing.Point(758, 336);
            this.button_SetColor.Name = "button_SetColor";
            this.button_SetColor.Size = new System.Drawing.Size(49, 48);
            this.button_SetColor.TabIndex = 168;
            this.button_SetColor.UseVisualStyleBackColor = false;
            this.button_SetColor.Click += new System.EventHandler(this.button_SetColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(760, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 167;
            this.label4.Text = "Color";
            // 
            // label_widthValue
            // 
            this.label_widthValue.AutoSize = true;
            this.label_widthValue.BackColor = System.Drawing.Color.Transparent;
            this.label_widthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_widthValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_widthValue.Location = new System.Drawing.Point(783, 276);
            this.label_widthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_widthValue.Name = "label_widthValue";
            this.label_widthValue.Size = new System.Drawing.Size(18, 20);
            this.label_widthValue.TabIndex = 176;
            this.label_widthValue.Text = "3";
            this.label_widthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(754, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 173;
            this.label1.Text = "寬度";
            // 
            // trackBar_width
            // 
            this.trackBar_width.Location = new System.Drawing.Point(762, 198);
            this.trackBar_width.Maximum = 200;
            this.trackBar_width.Minimum = 1;
            this.trackBar_width.Name = "trackBar_width";
            this.trackBar_width.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_width.Size = new System.Drawing.Size(45, 104);
            this.trackBar_width.TabIndex = 172;
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
            this.label_width_Max.Location = new System.Drawing.Point(729, 201);
            this.label_width_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Max.Name = "label_width_Max";
            this.label_width_Max.Size = new System.Drawing.Size(36, 20);
            this.label_width_Max.TabIndex = 175;
            this.label_width_Max.Text = "200";
            this.label_width_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_width_Min
            // 
            this.label_width_Min.AutoSize = true;
            this.label_width_Min.BackColor = System.Drawing.Color.Transparent;
            this.label_width_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_width_Min.ForeColor = System.Drawing.Color.Black;
            this.label_width_Min.Location = new System.Drawing.Point(739, 278);
            this.label_width_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Min.Name = "label_width_Min";
            this.label_width_Min.Size = new System.Drawing.Size(18, 20);
            this.label_width_Min.TabIndex = 174;
            this.label_width_Min.Text = "1";
            this.label_width_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList_cursor
            // 
            this.imageList_cursor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_cursor.ImageStream")));
            this.imageList_cursor.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_cursor.Images.SetKeyName(0, "Cursor1.jpg");
            this.imageList_cursor.Images.SetKeyName(1, "Cursor2.jpg");
            this.imageList_cursor.Images.SetKeyName(2, "Cursor3.jpg");
            // 
            // cbx_Cursor
            // 
            this.cbx_Cursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Cursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbx_Cursor.FormattingEnabled = true;
            this.cbx_Cursor.Location = new System.Drawing.Point(706, 141);
            this.cbx_Cursor.Name = "cbx_Cursor";
            this.cbx_Cursor.Size = new System.Drawing.Size(135, 28);
            this.cbx_Cursor.TabIndex = 177;
            this.cbx_Cursor.SelectedIndexChanged += new System.EventHandler(this.cbx_Cursor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(739, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 178;
            this.label2.Text = "游標類型";
            // 
            // checkBox_ChangeColor_All
            // 
            this.checkBox_ChangeColor_All.AutoSize = true;
            this.checkBox_ChangeColor_All.Location = new System.Drawing.Point(750, 428);
            this.checkBox_ChangeColor_All.Name = "checkBox_ChangeColor_All";
            this.checkBox_ChangeColor_All.Size = new System.Drawing.Size(69, 17);
            this.checkBox_ChangeColor_All.TabIndex = 180;
            this.checkBox_ChangeColor_All.Text = "All Colors";
            this.checkBox_ChangeColor_All.UseVisualStyleBackColor = true;
            // 
            // button_ChangeColor
            // 
            this.button_ChangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_ChangeColor.Location = new System.Drawing.Point(722, 390);
            this.button_ChangeColor.Name = "button_ChangeColor";
            this.button_ChangeColor.Size = new System.Drawing.Size(119, 32);
            this.button_ChangeColor.TabIndex = 181;
            this.button_ChangeColor.Text = "標註顏色切換";
            this.button_ChangeColor.UseVisualStyleBackColor = true;
            this.button_ChangeColor.Click += new System.EventHandler(this.button_ChangeColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 754);
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
            this.Controls.Add(this.button_Clear);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Form1";
            this.Text = "小畫板";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_SetColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog_SetColor;
        private System.Windows.Forms.Label label_widthValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_width;
        private System.Windows.Forms.Label label_width_Max;
        private System.Windows.Forms.Label label_width_Min;
        private System.Windows.Forms.ImageList imageList_cursor;
        private System.Windows.Forms.ComboBox cbx_Cursor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_ChangeColor_All;
        private System.Windows.Forms.Button button_ChangeColor;
    }
}

