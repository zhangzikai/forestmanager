namespace td.forest.report
{
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using jn.isos.log;
    using Microsoft.Office.Interop.Excel;
    using Report;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using td.db.mid.forest;
    using td.forest.report.xb;
    using td.logic.forest;
    using Utilities;

    /// <summary>
    /// 统计表选择窗口
    /// </summary>
    public class frmSelectTable : RibbonForm
    {
        private BarEditItem barEditItem1;
        private BarEditItem bCHK_ZYBH_B2_GLSLLMMJXJTJB2;
        private SimpleButton btnAllSelect;
        private SimpleButton btnCancelSelect;
        private SimpleButton btnExportXLS;
        private CheckEdit chk1;
        private CheckEdit chk10;
        private CheckEdit chk11;
        private CheckEdit chk12;
        private CheckEdit chk13;
        private CheckEdit chk14;
        private CheckEdit chk15;
        private CheckEdit chk16;
        private CheckEdit chk17;
        private CheckEdit chk18;
        private CheckEdit chk19;
        private CheckEdit chk2;
        private CheckEdit chk20;
        private CheckEdit chk21;
        private CheckEdit chk22;
        private CheckEdit chk23;
        private CheckEdit chk24;
        private CheckEdit chk25;
        private CheckEdit chk26;
        private CheckEdit chk27;
        private CheckEdit chk28;
        private CheckEdit chk29;
        private CheckEdit chk3;
        private CheckEdit chk30;
        private CheckEdit chk31;
        private CheckEdit chk32;
        private CheckEdit chk33;
        private CheckEdit chk34;
        private CheckEdit chk35;
        private CheckEdit chk36;
        private CheckEdit chk37;
        private CheckEdit chk38;
        private CheckEdit chk39;
        private CheckEdit chk4;
        private CheckEdit chk40;
        private CheckEdit chk5;
        private CheckEdit chk6;
        private CheckEdit chk7;
        private CheckEdit chk8;
        private CheckEdit chk9;
        /// <summary>
        /// 将各表格的表名封装进chks数组
        /// </summary>
        private CheckEdit[] chks;
        private IContainer components;
        private string pConn = "";

        private string pExportXLS_Template = (System.Windows.Forms.Application.StartupPath + @"\二类调查统计表表头.xls");
        private int pLastND;
        private int pNowND;
        private ProgressBarControl progressBarControl1;
        private string[] pSQL;
        private string pTable_Code = "";
        private string pTable_gmlszhb = "";
        private string pTable_hslszhb = "";
        private string pTable_jjlszhb = "";
        private string pTable_qmlszhb = "";
        private string pTable_slszhb = "";
        private string pTable_XB_last = "";
        private string pTable_XB_now = "";
        private string pTable_yclszhb = "";
        private string pXianName;

        private Logger m_log = LoggerManager.CreateLogger("DB", typeof(frmSelectTable));
        private RibbonControl ribbon;
        /// <summary>
        /// 
        /// </summary>
        private FindMidFromLayer<FOR_XIAOBAN_Mid> m_midLayer;
        /// <summary>
        /// 选择表窗体构造器
        /// </summary>
        /// <param name="midLayer"></param>
        public frmSelectTable(FindMidFromLayer<FOR_XIAOBAN_Mid> midLayer)
        {
            this.InitializeComponent();
            m_midLayer = midLayer;
            //将各表单名封装进数组
            this.chks = new CheckEdit[] { 
                this.chk1,this.chk36,this.chk38,this.chk2,this.chk39,this.chk3,this.chk4,this.chk5,this.chk18
                //this.chk1, this.chk2, this.chk3, this.chk4, this.chk5, this.chk6
                //, this.chk7, this.chk8, this.chk9, this.chk10, this.chk11, this.chk12, this.chk13, this.chk14, this.chk15, this.chk16,
                //this.chk17, this.chk18, this.chk19, this.chk20, this.chk21, this.chk22, this.chk23, this.chk24, this.chk25, this.chk26, this.chk27, this.chk28, this.chk29, this.chk30, this.chk31, this.chk32,
                //this.chk33, this.chk34, this.chk35, this.chk36, this.chk37, this.chk38, this.chk39, this.chk40
            };
        }
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chks.Length; i++)
            {
                if (i != 0x24)
                {
                    this.chks[i].Checked = true;
                }
            }
        }
        private void btnCancelSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chks.Length; i++)
            {
                this.chks[i].Checked = false;
            }
        }

        /// <summary>
        /// 找到工作表，并返回工作表名称
        /// </summary>
        /// <param name="pWorkbook"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private Worksheet FindSheet(Workbook pWorkbook, string title)
        {
            for (int i = 1; i < pWorkbook.Sheets.Count + 1; i++)
            {//Worksheet：编辑工作表。Sheets：返回表示指定工作簿中所有工作表的Microsoft.Office.Interop.Excel.Sheets集合。 只读表对象。
                Worksheet sheet = (Worksheet)pWorkbook.Sheets[i];
                if (sheet.Name == title)//尝试或设置对象的名称。 读/写字符串。
                {
                    return sheet;
                }
            }
            return null;
        }

        /// <summary>
        /// “输出EXCEL”的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportXLS_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog;
            //报表保存路径
            string reportSavePath = "";
            dialog = new SaveFileDialog();
            dialog.Title = "小班统计总表";
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel电子表(*.xls)|*.xls";
            dialog.FileName = reportSavePath;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            reportSavePath = dialog.FileName;

            //报表路径：此处加载了报表的表头
            string reportPath = @"二类调查统计表表头.xls";
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("report", "reportpath");
            int startIndex = AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("bin");
            reportPath  = AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + str+reportPath;
            //复制文件:将表头文件（二类调查统计表表头.xls）复制到新的文件（test.xls）中
            try
            {
                File.Copy(reportPath, reportSavePath, true);

            }
            catch (IOException)
            {
                MessageBox.Show("Excel.exe已经被打开。请在任务管理器中关闭该该程序后重新启动！！！");
            }

            //File.Copy(reportPath, reportSavePath, true);
            //Application:代表整个Microsoft Excel应用程序。
            Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
            //Workbook:表示Microsoft Excel工作簿。
            //Workbooks:返回代表所有打开的工作簿的Microsoft.Office.Interop.Excel.Workbook集合。
            //Open:打开工作簿.参数（要打开的工作簿的文件名）
            Workbook pWorkbook = application.Workbooks.Open(reportSavePath);
            //定义链表List，封装将要统计的报表
            IList<XB_Report_Base> rpLst = new List<XB_Report_Base>();

            //一共40个报表
            for (int i = 0; i < chks.Length; i++)
            {
                if (this.chks[i].Checked)
                {
                    string rpName = "td.forest.report.xb.XB_Report_" + chks[i].Tag;
                    Type tp = Type.GetType(rpName);//获取类型
                    // Activator:包含特定的方法，用以在本地或从远程创建对象类型，或获取对现有远程对象的引用。此类不能被继承。
                    //CreateInstance:使用指定类型的默认构造函数来创建该类型的实例。参数（要创建的对象的类型。）
                    XB_Report_Base rp = Activator.CreateInstance(tp) as XB_Report_Base;
                    rpLst.Add(rp);
                }
            } 

            XB_Report_1 xbr = new XB_Report_1();
            List<FOR_XIAOBAN_Mid> xbLst = xbr.InitialReport(this.m_midLayer);
            foreach (XB_Report_Base xbRP in rpLst)
            {
                xbRP.InitialReport(xbLst);
                System.Data.DataTable dt = xbRP.FromMid2Table();
                //Worksheet:表示工作表。
                Worksheet sheet = FindSheet(pWorkbook, xbRP.SheetName);
                Console.WriteLine(xbRP.SheetName);
                if (null != sheet)
                {
                    xbRP.WriteExcel(dt, sheet);//将数据写入Excel表格
                }
            }
            Console.WriteLine(DateTime.Now.ToString());
            pWorkbook.Save();
            pWorkbook.Close();
            MessageBox.Show("您选择的报表已经全部生产成功！！！");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void frmSelectTable_Load(object sender, EventArgs e)
        {
        }
        private void frmSelectTable_Shown(object sender, EventArgs e)
        {

        }
        private void InitializeComponent()
        {
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnCancelSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportXLS = new DevExpress.XtraEditors.SimpleButton();
            this.chk27 = new DevExpress.XtraEditors.CheckEdit();
            this.chk26 = new DevExpress.XtraEditors.CheckEdit();
            this.chk25 = new DevExpress.XtraEditors.CheckEdit();
            this.chk17 = new DevExpress.XtraEditors.CheckEdit();
            this.chk16 = new DevExpress.XtraEditors.CheckEdit();
            this.chk38 = new DevExpress.XtraEditors.CheckEdit();
            this.chk37 = new DevExpress.XtraEditors.CheckEdit();
            this.chk35 = new DevExpress.XtraEditors.CheckEdit();
            this.chk34 = new DevExpress.XtraEditors.CheckEdit();
            this.chk33 = new DevExpress.XtraEditors.CheckEdit();
            this.chk32 = new DevExpress.XtraEditors.CheckEdit();
            this.chk31 = new DevExpress.XtraEditors.CheckEdit();
            this.chk30 = new DevExpress.XtraEditors.CheckEdit();
            this.chk29 = new DevExpress.XtraEditors.CheckEdit();
            this.chk28 = new DevExpress.XtraEditors.CheckEdit();
            this.chk24 = new DevExpress.XtraEditors.CheckEdit();
            this.chk23 = new DevExpress.XtraEditors.CheckEdit();
            this.chk22 = new DevExpress.XtraEditors.CheckEdit();
            this.chk21 = new DevExpress.XtraEditors.CheckEdit();
            this.chk20 = new DevExpress.XtraEditors.CheckEdit();
            this.chk19 = new DevExpress.XtraEditors.CheckEdit();
            this.chk18 = new DevExpress.XtraEditors.CheckEdit();
            this.chk15 = new DevExpress.XtraEditors.CheckEdit();
            this.chk14 = new DevExpress.XtraEditors.CheckEdit();
            this.chk13 = new DevExpress.XtraEditors.CheckEdit();
            this.chk12 = new DevExpress.XtraEditors.CheckEdit();
            this.chk11 = new DevExpress.XtraEditors.CheckEdit();
            this.chk10 = new DevExpress.XtraEditors.CheckEdit();
            this.chk9 = new DevExpress.XtraEditors.CheckEdit();
            this.chk8 = new DevExpress.XtraEditors.CheckEdit();
            this.chk7 = new DevExpress.XtraEditors.CheckEdit();
            this.chk6 = new DevExpress.XtraEditors.CheckEdit();
            this.chk5 = new DevExpress.XtraEditors.CheckEdit();
            this.chk4 = new DevExpress.XtraEditors.CheckEdit();
            this.chk3 = new DevExpress.XtraEditors.CheckEdit();
            this.chk39 = new DevExpress.XtraEditors.CheckEdit();
            this.chk2 = new DevExpress.XtraEditors.CheckEdit();
            this.chk36 = new DevExpress.XtraEditors.CheckEdit();
            this.chk1 = new DevExpress.XtraEditors.CheckEdit();
            this.chk40 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk27.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk26.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk25.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk17.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk16.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk38.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk37.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk35.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk34.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk33.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk32.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk31.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk30.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk29.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk28.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk24.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk23.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk22.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk21.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk20.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk19.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk18.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk15.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk14.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk39.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk36.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk40.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bCHK_ZYBH_B2_GLSLLMMJXJTJB2
            // 
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2.Caption = "表2-1 各类森林林木面积蓄积统计表(2)";
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2.Edit = null;
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2.Id = 146;
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2.Name = "bCHK_ZYBH_B2_GLSLLMMJXJTJB2";
            this.bCHK_ZYBH_B2_GLSLLMMJXJTJB2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "表2-1 各类森林林木面积蓄积统计表(2)";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 146;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(420, 50);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(139, 582);
            this.progressBarControl1.MenuManager = this.ribbon;
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Maximum = 50;
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(420, 18);
            this.progressBarControl1.TabIndex = 110;
            this.progressBarControl1.Visible = false;
            // 
            // btnCancelSelect
            // 
            this.btnCancelSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelSelect.Location = new System.Drawing.Point(165, 331);
            this.btnCancelSelect.Name = "btnCancelSelect";
            this.btnCancelSelect.Size = new System.Drawing.Size(81, 23);
            this.btnCancelSelect.TabIndex = 108;
            this.btnCancelSelect.Text = "取消选择";
            this.btnCancelSelect.Click += new System.EventHandler(this.btnCancelSelect_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllSelect.Location = new System.Drawing.Point(53, 331);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(81, 23);
            this.btnAllSelect.TabIndex = 107;
            this.btnAllSelect.Text = "全部选择";
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnExportXLS
            // 
            this.btnExportXLS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportXLS.Location = new System.Drawing.Point(277, 331);
            this.btnExportXLS.Name = "btnExportXLS";
            this.btnExportXLS.Size = new System.Drawing.Size(81, 23);
            this.btnExportXLS.TabIndex = 114;
            this.btnExportXLS.Text = "输出EXCEL";
            this.btnExportXLS.Click += new System.EventHandler(this.btnExportXLS_Click);
            // 
            // chk27
            // 
            this.chk27.Location = new System.Drawing.Point(398, 316);
            this.chk27.MenuManager = this.ribbon;
            this.chk27.Name = "chk27";
            this.chk27.Properties.Caption = "表27   高保护价值森林统计表";
            this.chk27.Size = new System.Drawing.Size(276, 19);
            this.chk27.TabIndex = 161;
            this.chk27.Tag = "27";
            this.chk27.Visible = false;
            // 
            // chk26
            // 
            this.chk26.Location = new System.Drawing.Point(398, 290);
            this.chk26.MenuManager = this.ribbon;
            this.chk26.Name = "chk26";
            this.chk26.Properties.Caption = "表26   森林经营类型按类型及乔木林龄组统计表";
            this.chk26.Size = new System.Drawing.Size(276, 19);
            this.chk26.TabIndex = 160;
            this.chk26.Tag = "26";
            this.chk26.Visible = false;
            // 
            // chk25
            // 
            this.chk25.Location = new System.Drawing.Point(398, 264);
            this.chk25.MenuManager = this.ribbon;
            this.chk25.Name = "chk25";
            this.chk25.Properties.Caption = "表25   森林经营类型按立地质量统计表";
            this.chk25.Size = new System.Drawing.Size(276, 19);
            this.chk25.TabIndex = 159;
            this.chk25.Tag = "25";
            this.chk25.Visible = false;
            // 
            // chk17
            // 
            this.chk17.Location = new System.Drawing.Point(398, 56);
            this.chk17.MenuManager = this.ribbon;
            this.chk17.Name = "chk17";
            this.chk17.Properties.Caption = "表17   低效经济林面积蓄积统计表";
            this.chk17.Size = new System.Drawing.Size(276, 19);
            this.chk17.TabIndex = 158;
            this.chk17.Tag = "17";
            this.chk17.Visible = false;
            // 
            // chk16
            // 
            this.chk16.Location = new System.Drawing.Point(27, 549);
            this.chk16.MenuManager = this.ribbon;
            this.chk16.Name = "chk16";
            this.chk16.Properties.Caption = "表16   低效公益林面积蓄积统计表";
            this.chk16.Size = new System.Drawing.Size(276, 19);
            this.chk16.TabIndex = 157;
            this.chk16.Tag = "16";
            this.chk16.Visible = false;
            // 
            // chk38
            // 
            this.chk38.EditValue = true;
            this.chk38.Location = new System.Drawing.Point(27, 108);
            this.chk38.MenuManager = this.ribbon;
            this.chk38.Name = "chk38";
            this.chk38.Properties.Caption = "表1-2   各类林地按保护等级面积统计表";
            this.chk38.Size = new System.Drawing.Size(351, 19);
            this.chk38.TabIndex = 156;
            this.chk38.Tag = "1_3";
            this.chk38.CheckedChanged += new System.EventHandler(this.chk38_CheckedChanged);
            // 
            // chk37
            // 
            this.chk37.Enabled = false;
            this.chk37.Location = new System.Drawing.Point(27, 108);
            this.chk37.MenuManager = this.ribbon;
            this.chk37.Name = "chk37";
            this.chk37.Properties.Caption = "表1-2   各类林地按立地类型面积统计表";
            this.chk37.Size = new System.Drawing.Size(351, 19);
            this.chk37.TabIndex = 155;
            this.chk37.Tag = "1_2";
            this.chk37.Visible = false;
            this.chk37.CheckedChanged += new System.EventHandler(this.chk37_CheckedChanged);
            // 
            // chk35
            // 
            this.chk35.Location = new System.Drawing.Point(398, 523);
            this.chk35.MenuManager = this.ribbon;
            this.chk35.Name = "chk35";
            this.chk35.Properties.Caption = "表35   用材林单位面积蓄积变化统计表";
            this.chk35.Size = new System.Drawing.Size(276, 19);
            this.chk35.TabIndex = 154;
            this.chk35.Tag = "35";
            this.chk35.Visible = false;
            // 
            // chk34
            // 
            this.chk34.Location = new System.Drawing.Point(398, 497);
            this.chk34.MenuManager = this.ribbon;
            this.chk34.Name = "chk34";
            this.chk34.Properties.Caption = "表34   乔木林单位面积蓄积变化统计表";
            this.chk34.Size = new System.Drawing.Size(276, 19);
            this.chk34.TabIndex = 153;
            this.chk34.Tag = "34";
            this.chk34.Visible = false;
            // 
            // chk33
            // 
            this.chk33.Location = new System.Drawing.Point(398, 472);
            this.chk33.MenuManager = this.ribbon;
            this.chk33.Name = "chk33";
            this.chk33.Properties.Caption = "表33   用材林面积蓄积变化统计表";
            this.chk33.Size = new System.Drawing.Size(276, 19);
            this.chk33.TabIndex = 152;
            this.chk33.Tag = "33";
            this.chk33.Visible = false;
            // 
            // chk32
            // 
            this.chk32.Location = new System.Drawing.Point(398, 446);
            this.chk32.MenuManager = this.ribbon;
            this.chk32.Name = "chk32";
            this.chk32.Properties.Caption = "表32   乔木林面积蓄积变化统计表";
            this.chk32.Size = new System.Drawing.Size(276, 19);
            this.chk32.TabIndex = 151;
            this.chk32.Tag = "32";
            this.chk32.Visible = false;
            // 
            // chk31
            // 
            this.chk31.Location = new System.Drawing.Point(398, 420);
            this.chk31.MenuManager = this.ribbon;
            this.chk31.Name = "chk31";
            this.chk31.Properties.Caption = "表31   林种面积蓄积变化统计表";
            this.chk31.Size = new System.Drawing.Size(276, 19);
            this.chk31.TabIndex = 150;
            this.chk31.Tag = "31";
            this.chk31.Visible = false;
            // 
            // chk30
            // 
            this.chk30.Location = new System.Drawing.Point(398, 394);
            this.chk30.MenuManager = this.ribbon;
            this.chk30.Name = "chk30";
            this.chk30.Properties.Caption = "表30   林种面积蓄积按类型变化统计表";
            this.chk30.Size = new System.Drawing.Size(276, 19);
            this.chk30.TabIndex = 149;
            this.chk30.Tag = "30";
            this.chk30.Visible = false;
            // 
            // chk29
            // 
            this.chk29.Location = new System.Drawing.Point(398, 368);
            this.chk29.MenuManager = this.ribbon;
            this.chk29.Name = "chk29";
            this.chk29.Properties.Caption = "表29   各类森林、林木面积蓄积变化统计表";
            this.chk29.Size = new System.Drawing.Size(276, 19);
            this.chk29.TabIndex = 148;
            this.chk29.Tag = "29";
            this.chk29.Visible = false;
            // 
            // chk28
            // 
            this.chk28.Location = new System.Drawing.Point(398, 342);
            this.chk28.MenuManager = this.ribbon;
            this.chk28.Name = "chk28";
            this.chk28.Properties.Caption = "表28   土地面积变化统计表";
            this.chk28.Size = new System.Drawing.Size(276, 19);
            this.chk28.TabIndex = 147;
            this.chk28.Tag = "28";
            this.chk28.Visible = false;
            // 
            // chk24
            // 
            this.chk24.Location = new System.Drawing.Point(398, 238);
            this.chk24.MenuManager = this.ribbon;
            this.chk24.Name = "chk24";
            this.chk24.Properties.Caption = "表24   森林健康状况统计表";
            this.chk24.Size = new System.Drawing.Size(276, 19);
            this.chk24.TabIndex = 146;
            this.chk24.Tag = "24";
            this.chk24.Visible = false;
            // 
            // chk23
            // 
            this.chk23.Location = new System.Drawing.Point(398, 212);
            this.chk23.MenuManager = this.ribbon;
            this.chk23.Name = "chk23";
            this.chk23.Properties.Caption = "表23   森林灾害统计表";
            this.chk23.Size = new System.Drawing.Size(276, 19);
            this.chk23.TabIndex = 145;
            this.chk23.Tag = "23";
            this.chk23.Visible = false;
            // 
            // chk22
            // 
            this.chk22.Location = new System.Drawing.Point(398, 186);
            this.chk22.MenuManager = this.ribbon;
            this.chk22.Name = "chk22";
            this.chk22.Properties.Caption = "表22   林地土壤侵蚀类型统计表";
            this.chk22.Size = new System.Drawing.Size(276, 19);
            this.chk22.TabIndex = 144;
            this.chk22.Tag = "22";
            this.chk22.Visible = false;
            // 
            // chk21
            // 
            this.chk21.Location = new System.Drawing.Point(398, 160);
            this.chk21.MenuManager = this.ribbon;
            this.chk21.Name = "chk21";
            this.chk21.Properties.Caption = "表21   湿地统计表";
            this.chk21.Size = new System.Drawing.Size(276, 19);
            this.chk21.TabIndex = 143;
            this.chk21.Tag = "21";
            this.chk21.Visible = false;
            // 
            // chk20
            // 
            this.chk20.Location = new System.Drawing.Point(398, 134);
            this.chk20.MenuManager = this.ribbon;
            this.chk20.Name = "chk20";
            this.chk20.Properties.Caption = "表20   石漠化土地统计表";
            this.chk20.Size = new System.Drawing.Size(276, 19);
            this.chk20.TabIndex = 142;
            this.chk20.Tag = "20";
            this.chk20.Visible = false;
            // 
            // chk19
            // 
            this.chk19.Location = new System.Drawing.Point(398, 108);
            this.chk19.MenuManager = this.ribbon;
            this.chk19.Name = "chk19";
            this.chk19.Properties.Caption = "表19   沙化土地统计表";
            this.chk19.Size = new System.Drawing.Size(276, 19);
            this.chk19.TabIndex = 141;
            this.chk19.Tag = "19";
            this.chk19.Visible = false;
            // 
            // chk18
            // 
            this.chk18.Location = new System.Drawing.Point(27, 264);
            this.chk18.MenuManager = this.ribbon;
            this.chk18.Name = "chk18";
            this.chk18.Properties.Caption = "表6   林业工程面积蓄积统计表";
            this.chk18.Size = new System.Drawing.Size(276, 19);
            this.chk18.TabIndex = 140;
            this.chk18.Tag = "18";
            this.chk18.CheckedChanged += new System.EventHandler(this.chk18_CheckedChanged);
            // 
            // chk15
            // 
            this.chk15.Location = new System.Drawing.Point(27, 523);
            this.chk15.MenuManager = this.ribbon;
            this.chk15.Name = "chk15";
            this.chk15.Properties.Caption = "表15   低效用材林薪炭林面积蓄积统计表";
            this.chk15.Size = new System.Drawing.Size(276, 19);
            this.chk15.TabIndex = 139;
            this.chk15.Tag = "15";
            this.chk15.Visible = false;
            // 
            // chk14
            // 
            this.chk14.Location = new System.Drawing.Point(27, 497);
            this.chk14.MenuManager = this.ribbon;
            this.chk14.Name = "chk14";
            this.chk14.Properties.Caption = "表14   短轮伐期工业原料林面积蓄积统计表";
            this.chk14.Size = new System.Drawing.Size(351, 19);
            this.chk14.TabIndex = 138;
            this.chk14.Tag = "14";
            this.chk14.Visible = false;
            // 
            // chk13
            // 
            this.chk13.Location = new System.Drawing.Point(27, 472);
            this.chk13.MenuManager = this.ribbon;
            this.chk13.Name = "chk13";
            this.chk13.Properties.Caption = "表13   灌木林统计表";
            this.chk13.Size = new System.Drawing.Size(351, 19);
            this.chk13.TabIndex = 137;
            this.chk13.Tag = "13";
            this.chk13.Visible = false;
            // 
            // chk12
            // 
            this.chk12.Location = new System.Drawing.Point(27, 446);
            this.chk12.MenuManager = this.ribbon;
            this.chk12.Name = "chk12";
            this.chk12.Properties.Caption = "表12   竹林统计表";
            this.chk12.Size = new System.Drawing.Size(351, 19);
            this.chk12.TabIndex = 136;
            this.chk12.Tag = "12";
            this.chk12.Visible = false;
            // 
            // chk11
            // 
            this.chk11.Location = new System.Drawing.Point(27, 420);
            this.chk11.MenuManager = this.ribbon;
            this.chk11.Name = "chk11";
            this.chk11.Properties.Caption = "表11   经济林统计表";
            this.chk11.Size = new System.Drawing.Size(351, 19);
            this.chk11.TabIndex = 135;
            this.chk11.Tag = "11";
            this.chk11.Visible = false;
            // 
            // chk10
            // 
            this.chk10.Location = new System.Drawing.Point(27, 394);
            this.chk10.MenuManager = this.ribbon;
            this.chk10.Name = "chk10";
            this.chk10.Properties.Caption = "表10   用材林中幼龄林应抚育间伐面积蓄积统计表";
            this.chk10.Size = new System.Drawing.Size(351, 19);
            this.chk10.TabIndex = 134;
            this.chk10.Tag = "10";
            this.chk10.Visible = false;
            // 
            // chk9
            // 
            this.chk9.Location = new System.Drawing.Point(27, 368);
            this.chk9.MenuManager = this.ribbon;
            this.chk9.Name = "chk9";
            this.chk9.Properties.Caption = "表9   用材林近成过熟林各树种株数、材积按径级组统计表";
            this.chk9.Size = new System.Drawing.Size(351, 19);
            this.chk9.TabIndex = 133;
            this.chk9.Tag = "9";
            this.chk9.Visible = false;
            // 
            // chk8
            // 
            this.chk8.Location = new System.Drawing.Point(27, 342);
            this.chk8.MenuManager = this.ribbon;
            this.chk8.Name = "chk8";
            this.chk8.Properties.Caption = "表8   用材林近成过熟林面积蓄积按可及度出材率等级统计表";
            this.chk8.Size = new System.Drawing.Size(351, 19);
            this.chk8.TabIndex = 132;
            this.chk8.Tag = "8";
            this.chk8.Visible = false;
            // 
            // chk7
            // 
            this.chk7.Location = new System.Drawing.Point(27, 316);
            this.chk7.MenuManager = this.ribbon;
            this.chk7.Name = "chk7";
            this.chk7.Properties.Caption = "表7   用材林面积蓄积按龄级统计表";
            this.chk7.Size = new System.Drawing.Size(351, 19);
            this.chk7.TabIndex = 131;
            this.chk7.Tag = "7";
            this.chk7.Visible = false;
            // 
            // chk6
            // 
            this.chk6.Location = new System.Drawing.Point(27, 290);
            this.chk6.MenuManager = this.ribbon;
            this.chk6.Name = "chk6";
            this.chk6.Properties.Caption = "表6   红树林资源统计表";
            this.chk6.Size = new System.Drawing.Size(351, 19);
            this.chk6.TabIndex = 130;
            this.chk6.Tag = "6";
            this.chk6.Visible = false;
            // 
            // chk5
            // 
            this.chk5.Location = new System.Drawing.Point(27, 238);
            this.chk5.MenuManager = this.ribbon;
            this.chk5.Name = "chk5";
            this.chk5.Properties.Caption = "表5   公益林(地)统计表";
            this.chk5.Size = new System.Drawing.Size(351, 19);
            this.chk5.TabIndex = 129;
            this.chk5.Tag = "5";
            // 
            // chk4
            // 
            this.chk4.Location = new System.Drawing.Point(27, 212);
            this.chk4.MenuManager = this.ribbon;
            this.chk4.Name = "chk4";
            this.chk4.Properties.Caption = "表4   乔木林面积蓄积按龄组统计表";
            this.chk4.Size = new System.Drawing.Size(351, 19);
            this.chk4.TabIndex = 128;
            this.chk4.Tag = "4";
            // 
            // chk3
            // 
            this.chk3.Location = new System.Drawing.Point(27, 186);
            this.chk3.MenuManager = this.ribbon;
            this.chk3.Name = "chk3";
            this.chk3.Properties.Caption = "表3   林种面积蓄积统计表";
            this.chk3.Size = new System.Drawing.Size(351, 19);
            this.chk3.TabIndex = 127;
            this.chk3.Tag = "3";
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // chk39
            // 
            this.chk39.EditValue = true;
            this.chk39.Location = new System.Drawing.Point(27, 160);
            this.chk39.MenuManager = this.ribbon;
            this.chk39.Name = "chk39";
            this.chk39.Properties.Caption = "表2-1   各类森林、林木面积蓄积统计表(2)";
            this.chk39.Size = new System.Drawing.Size(351, 19);
            this.chk39.TabIndex = 126;
            this.chk39.Tag = "2_1";
            this.chk39.CheckedChanged += new System.EventHandler(this.chk39_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.EditValue = true;
            this.chk2.Location = new System.Drawing.Point(27, 134);
            this.chk2.MenuManager = this.ribbon;
            this.chk2.Name = "chk2";
            this.chk2.Properties.Caption = "表2   各类森林、林木面积蓄积统计表";
            this.chk2.Size = new System.Drawing.Size(351, 19);
            this.chk2.TabIndex = 125;
            this.chk2.Tag = "2";
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // chk36
            // 
            this.chk36.EditValue = true;
            this.chk36.Location = new System.Drawing.Point(27, 82);
            this.chk36.MenuManager = this.ribbon;
            this.chk36.Name = "chk36";
            this.chk36.Properties.Caption = "表1-1   各类林按林种面积统计表";
            this.chk36.Size = new System.Drawing.Size(351, 19);
            this.chk36.TabIndex = 124;
            this.chk36.Tag = "1_1";
            // 
            // chk1
            // 
            this.chk1.EditValue = true;
            this.chk1.Location = new System.Drawing.Point(27, 56);
            this.chk1.MenuManager = this.ribbon;
            this.chk1.Name = "chk1";
            this.chk1.Properties.Caption = "表1   各类土地面积统计表";
            this.chk1.Size = new System.Drawing.Size(351, 19);
            this.chk1.TabIndex = 123;
            this.chk1.Tag = "1";
            // 
            // chk40
            // 
            this.chk40.Location = new System.Drawing.Point(398, 549);
            this.chk40.MenuManager = this.ribbon;
            this.chk40.Name = "chk40";
            this.chk40.Properties.Caption = "小班主要调查因子一览表";
            this.chk40.Size = new System.Drawing.Size(276, 19);
            this.chk40.TabIndex = 163;
            this.chk40.Tag = "xbyz";
            this.chk40.Visible = false;
            this.chk40.CheckedChanged += new System.EventHandler(this.chk40_CheckedChanged);
            // 
            // frmSelectTable
            // 
            this.ClientSize = new System.Drawing.Size(420, 368);
            this.Controls.Add(this.chk40);
            this.Controls.Add(this.chk27);
            this.Controls.Add(this.chk26);
            this.Controls.Add(this.chk25);
            this.Controls.Add(this.chk17);
            this.Controls.Add(this.chk16);
            this.Controls.Add(this.chk38);
            this.Controls.Add(this.chk37);
            this.Controls.Add(this.chk35);
            this.Controls.Add(this.chk34);
            this.Controls.Add(this.chk33);
            this.Controls.Add(this.chk32);
            this.Controls.Add(this.chk31);
            this.Controls.Add(this.chk30);
            this.Controls.Add(this.chk29);
            this.Controls.Add(this.chk28);
            this.Controls.Add(this.chk24);
            this.Controls.Add(this.chk23);
            this.Controls.Add(this.chk22);
            this.Controls.Add(this.chk21);
            this.Controls.Add(this.chk20);
            this.Controls.Add(this.chk19);
            this.Controls.Add(this.chk18);
            this.Controls.Add(this.chk15);
            this.Controls.Add(this.chk14);
            this.Controls.Add(this.chk13);
            this.Controls.Add(this.chk12);
            this.Controls.Add(this.chk11);
            this.Controls.Add(this.chk10);
            this.Controls.Add(this.chk9);
            this.Controls.Add(this.chk8);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk39);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk36);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.btnExportXLS);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.btnCancelSelect);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.ribbon);
            this.MaximizeBox = false;
            this.Name = "frmSelectTable";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1";
            this.Text = "统计表选择";
            this.Load += new System.EventHandler(this.frmSelectTable_Load);
            this.Shown += new System.EventHandler(this.frmSelectTable_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk27.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk26.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk25.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk17.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk16.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk38.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk37.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk35.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk34.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk33.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk32.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk31.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk30.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk29.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk28.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk24.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk23.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk22.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk21.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk20.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk19.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk18.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk15.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk14.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk39.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk36.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk40.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void chk40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk37_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk38_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk39_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}

