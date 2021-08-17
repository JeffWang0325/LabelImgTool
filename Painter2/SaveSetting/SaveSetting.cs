using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO; // For FileInfo
using System.Diagnostics; // For Trace
using System.Xml.Serialization;
using System.Drawing;
using System.ComponentModel;

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2.SaveSetting
{
    /// <summary>
    /// 操作模式
    /// </summary>
    public enum enu_Module
    {
        Single_Dir,
        Double_Dir
    }

    [Serializable]
    public class cls_SaveSetting
    {
        #region 參數

        #region 外部程式打開

        /// <summary>
        /// 是否從外部程式打開
        /// </summary>
        public bool B_External_Open { get; set; } = false;

        /// <summary>
        /// 儲存標註原始影像 絕對路徑
        /// </summary>
        public string Extra_dirX { get; set; } = "D:\\X";

        /// <summary>
        /// 儲存標註影像1 絕對路徑
        /// </summary>
        public string Extra_dirY { get; set; } = "D:\\Y";

        #endregion

        /// <summary>
        /// 儲存設定 XML檔案位置
        /// </summary>
        static private string Path_SaveSetting_XML { get; set; } = Application.StartupPath + "\\SaveSetting.xml";

        /// <summary>
        /// 儲存路徑
        /// </summary>
        public string Folder_Save { get; set; } = Application.StartupPath;

        /// <summary>
        /// 是否儲存標註檔 (.xml)
        /// </summary>
        public bool B_save_label { get; set; } = true;

        /// <summary>
        /// 標註檔資料夾名稱
        /// </summary>
        public string FileName_label { get; set; } = "label";

        /// <summary>
        /// 是否儲存標註原始影像
        /// </summary>
        public bool B_save_OrigImage { get; set; } = true;

        /// <summary>
        /// 標註原始影像資料夾名稱
        /// </summary>
        public string FileName_OrigImage { get; set; } = "Original Image";
        
        /// <summary>
        /// 是否儲存標註影像1
        /// </summary>
        public bool B_save_label_Image1 { get; set; } = true;

        /// <summary>
        /// 標註影像1資料夾名稱
        /// </summary>
        public string FileName_label_Image1 { get; set; } = "label_Image1";

        /// <summary>
        /// 是否儲存標註影像2
        /// </summary>
        public bool B_save_label_Image2 { get; set; } = true;

        /// <summary>
        /// 標註影像2資料夾名稱
        /// </summary>
        public string FileName_label_Image2 { get; set; } = "label_Image2";

        /// <summary>
        /// 是否儲存標註影像3
        /// </summary>
        public bool B_save_label_Image3 { get; set; } = true;

        /// <summary>
        /// 標註影像3資料夾名稱
        /// </summary>
        public string FileName_label_Image3 { get; set; } = "label_Image3";

        /// <summary>
        /// 是否載入所有類型影像檔案格式
        /// </summary>
        public bool B_Load_AllImageFormat { get; set; } = false;

        /// <summary>
        /// 載入影像檔案格式
        /// </summary>
        public enu_ImageFormat ImageFormat_Load { get; set; } = enu_ImageFormat.bmp;

        /// <summary>
        /// 儲存影像檔案格式是否和原始影像相同
        /// </summary>
        public bool B_Save_SameImageFormat { get; set; } = false;

        /// <summary>
        /// 儲存影像檔案格式
        /// </summary>
        public enu_ImageFormat ImageFormat_Save { get; set; } = enu_ImageFormat.bmp;

        #region 顏色快捷列表

        /// <summary>
        /// 是否啟用 顏色快捷列表
        /// </summary>
        public bool B_ColorList { get; set; } = true;

        /// <summary>
        /// 顏色快捷列表
        /// </summary>
        [XmlIgnore] // 帶有XmlIgnore，表示序列化時不序列化此屬性 Note: Color 類別無法做序列化及反序列化
        public List<Color> ColorList { get; set; } = new List<Color>();
        
        /// <summary>
        /// 用於序列化 (ColorList)
        /// Note: 不可用 List<string>，因為載入XML時不會執行 set{}
        /// </summary>
        public string[] halconColorArray
        {
            get // 序列化
            {
                List<string> ListStr = new List<string>();
                foreach (Color c in this.ColorList)
                    ListStr.Add(clsStaticTool.GetHalconColor(c));
                return ListStr.ToArray();
            }

            set // 反序列化
            {
                this.ColorList = new List<Color>();
                foreach (string s in value)
                    this.ColorList.Add(clsStaticTool.GetSystemColor_withName(s));
            }
        }

        #endregion

        /// <summary>
        /// 操作模式 Index
        /// </summary>
        public int Index_Module { get; set; } = 0;

        /// <summary>
        /// 批次載入2 路徑資料夾
        /// </summary>
        public string Folder_LoadBatch2 { get; set; } = "D:";
        
        #endregion

        public cls_SaveSetting() { }

        #region 方法

        /// <summary>
        /// 載入工單
        /// </summary>
        /// <param name="Recipe"></param>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public static bool Load(out cls_SaveSetting Recipe, string PathFile = null)
        {
            bool b_status_ = false;
            if (PathFile == null)
                PathFile = cls_SaveSetting.Path_SaveSetting_XML;

            b_status_ = clsStaticTool.LoadXML(PathFile, out Recipe);
            if (b_status_ == false)
                Recipe = new cls_SaveSetting();
            
            return b_status_;
        }

        /// <summary>
        /// 儲存工單
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public bool Save(string PathFile = null)
        {
            bool b_status_ = false;
            if (PathFile == null)
                PathFile = cls_SaveSetting.Path_SaveSetting_XML;

            try
            {
                b_status_ = clsStaticTool.SaveXML(this, PathFile);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return b_status_;
        }

        #endregion
    }
}
