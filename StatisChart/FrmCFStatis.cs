using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FormBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using TaskManage;
using Utilities;

namespace StatisChart
{
    public class FrmCFStatis : FormBase2
    {
        private const string mClassName = "StatisChart.FrmCFStatis";

        private IContainer components;

        private Panel panel1;

        private Label lbl_content;

        private Label lbl_classify;

        private Label lbl_village;

        private Label lbl_town;

        private Label lbl_chartType;

        private Splitter splitter1;

        private Splitter splitter2;

        private Panel panel_chart;

        private ChartControl chartControl1;

        private GridControl gridControl1;

        private GridView gridView1;

        private SimpleButton btn_query;

        private ImageList imageList1;

        private SimpleButton btn_exportTable;

        private SimpleButton btn_exportChart;

        private RadioGroup radio_content;

        private RadioGroup radio_chartType;

        private RadioGroup radio_classify;

        private Panel panel2;

        private System.Windows.Forms.ComboBox cb_village;

        private System.Windows.Forms.ComboBox cb_town;

        private Label label2;

        private Label label1;

        private ZLDateEdit dateEditEnd;

        private ZLDateEdit dateEditStart;

        private Panel panelContent;

        private Panel panelClassify;

        private Panel panel3;

        private Panel panelChartType;

        private Panel panelMonth;

        private Panel panelCFType;

        private System.Windows.Forms.ComboBox comboBoxCFType;

        private Label label3;

        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();

        private string m_content = string.Empty;

        private string m_classify = string.Empty;

        private string m_pcode = "";

        private string m_pname = "";

        private string m_title = string.Empty;

        private string m_xTitle = "";

        private string m_yTitle = string.Empty;

        private bool m_needSum;

        private ChartControl m_control;

        private ViewType m_chartType;

        private SqlConnection m_conn;

        private SqlCommand m_cmd;

        private SqlDataReader m_reader;

        private SqlDataAdapter m_adapter;

        private string m_EditKind = "";

        private string m_EditKind2 = "";

        private string sFieldTime = "";

        private string mTableName = "";

        private string m_EditKind0 = "";

        private string m_EditKind20 = "";

        private string mTableName0 = "";

        private string m_DistCode = "";

        private string m_NDCFWhere0 = "";

        private string m_NDCFWhere = "";

        private string[] mContentArray;

        private string[] mClassifyArray;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCFStatis));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.dateEditEnd = new StatisChart.ZLDateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEditStart = new StatisChart.ZLDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChartType = new System.Windows.Forms.Panel();
            this.radio_chartType = new DevExpress.XtraEditors.RadioGroup();
            this.lbl_chartType = new System.Windows.Forms.Label();
            this.panelClassify = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_town = new System.Windows.Forms.Label();
            this.cb_town = new System.Windows.Forms.ComboBox();
            this.lbl_village = new System.Windows.Forms.Label();
            this.cb_village = new System.Windows.Forms.ComboBox();
            this.radio_classify = new DevExpress.XtraEditors.RadioGroup();
            this.lbl_classify = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.radio_content = new DevExpress.XtraEditors.RadioGroup();
            this.lbl_content = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_query = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.btn_exportTable = new DevExpress.XtraEditors.SimpleButton();
            this.btn_exportChart = new DevExpress.XtraEditors.SimpleButton();
            this.panelCFType = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCFType = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel_chart = new System.Windows.Forms.Panel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            this.panelMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            this.panelChartType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio_chartType.Properties)).BeginInit();
            this.panelClassify.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio_classify.Properties)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio_content.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelCFType.SuspendLayout();
            this.panel_chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMonth);
            this.panel1.Controls.Add(this.panelChartType);
            this.panel1.Controls.Add(this.panelClassify);
            this.panel1.Controls.Add(this.panelContent);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 142);
            this.panel1.TabIndex = 0;
            // 
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.dateEditEnd);
            this.panelMonth.Controls.Add(this.label2);
            this.panelMonth.Controls.Add(this.dateEditStart);
            this.panelMonth.Controls.Add(this.label1);
            this.panelMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMonth.Location = new System.Drawing.Point(0, 105);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Padding = new System.Windows.Forms.Padding(10, 7, 0, 7);
            this.panelMonth.Size = new System.Drawing.Size(907, 35);
            this.panelMonth.TabIndex = 32;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.DateMode = StatisChart.ZLDateEdit.DateResultModeEnum.LastDayOfMonth;
            this.dateEditEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(208, 7);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEnd.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dateEditEnd.Properties.DisplayFormat.FormatString = "yyyy年MM月";
            this.dateEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEnd.Properties.Mask.EditMask = "yyyy年MM月";
            this.dateEditEnd.Properties.ShowToday = false;
            this.dateEditEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditEnd.Size = new System.Drawing.Size(105, 20);
            this.dateEditEnd.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(182, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 26;
            this.label2.Text = "----";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateEditStart
            // 
            this.dateEditStart.DateMode = StatisChart.ZLDateEdit.DateResultModeEnum.FirstDayOfMonth;
            this.dateEditStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(77, 7);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStart.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dateEditStart.Properties.DisplayFormat.FormatString = "yyyy年MM月";
            this.dateEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.Mask.EditMask = "yyyy年MM月";
            this.dateEditStart.Properties.ShowToday = false;
            this.dateEditStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditStart.Size = new System.Drawing.Size(105, 20);
            this.dateEditStart.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "统计时间：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChartType
            // 
            this.panelChartType.Controls.Add(this.radio_chartType);
            this.panelChartType.Controls.Add(this.lbl_chartType);
            this.panelChartType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChartType.Location = new System.Drawing.Point(0, 70);
            this.panelChartType.Name = "panelChartType";
            this.panelChartType.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelChartType.Size = new System.Drawing.Size(907, 35);
            this.panelChartType.TabIndex = 31;
            // 
            // radio_chartType
            // 
            this.radio_chartType.Dock = System.Windows.Forms.DockStyle.Left;
            this.radio_chartType.Location = new System.Drawing.Point(77, 0);
            this.radio_chartType.Name = "radio_chartType";
            this.radio_chartType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radio_chartType.Properties.Appearance.Options.UseBackColor = true;
            this.radio_chartType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radio_chartType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "折线图"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "柱状图"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "3D折线图"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "3D柱状图")});
            this.radio_chartType.Size = new System.Drawing.Size(415, 35);
            this.radio_chartType.TabIndex = 16;
            this.radio_chartType.SelectedIndexChanged += new System.EventHandler(this.radio_chartType_SelectedIndexChanged);
            // 
            // lbl_chartType
            // 
            this.lbl_chartType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_chartType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_chartType.Location = new System.Drawing.Point(10, 0);
            this.lbl_chartType.Name = "lbl_chartType";
            this.lbl_chartType.Size = new System.Drawing.Size(67, 35);
            this.lbl_chartType.TabIndex = 8;
            this.lbl_chartType.Text = "图类类型：";
            this.lbl_chartType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelClassify
            // 
            this.panelClassify.Controls.Add(this.panel3);
            this.panelClassify.Controls.Add(this.radio_classify);
            this.panelClassify.Controls.Add(this.lbl_classify);
            this.panelClassify.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClassify.Location = new System.Drawing.Point(0, 35);
            this.panelClassify.Name = "panelClassify";
            this.panelClassify.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelClassify.Size = new System.Drawing.Size(907, 35);
            this.panelClassify.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_town);
            this.panel3.Controls.Add(this.cb_town);
            this.panel3.Controls.Add(this.lbl_village);
            this.panel3.Controls.Add(this.cb_village);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(389, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 35);
            this.panel3.TabIndex = 19;
            // 
            // lbl_town
            // 
            this.lbl_town.AutoSize = true;
            this.lbl_town.Location = new System.Drawing.Point(6, 10);
            this.lbl_town.Name = "lbl_town";
            this.lbl_town.Size = new System.Drawing.Size(31, 14);
            this.lbl_town.TabIndex = 4;
            this.lbl_town.Text = "乡：";
            this.lbl_town.Visible = false;
            // 
            // cb_town
            // 
            this.cb_town.FormattingEnabled = true;
            this.cb_town.Location = new System.Drawing.Point(43, 7);
            this.cb_town.Name = "cb_town";
            this.cb_town.Size = new System.Drawing.Size(121, 22);
            this.cb_town.TabIndex = 22;
            this.cb_town.SelectionChangeCommitted += new System.EventHandler(this.cb_town_SelectionChangeCommitted);
            this.cb_town.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_town_KeyPress);
            // 
            // lbl_village
            // 
            this.lbl_village.AutoSize = true;
            this.lbl_village.Location = new System.Drawing.Point(171, 10);
            this.lbl_village.Name = "lbl_village";
            this.lbl_village.Size = new System.Drawing.Size(31, 14);
            this.lbl_village.TabIndex = 6;
            this.lbl_village.Text = "村：";
            this.lbl_village.Visible = false;
            // 
            // cb_village
            // 
            this.cb_village.FormattingEnabled = true;
            this.cb_village.Location = new System.Drawing.Point(208, 7);
            this.cb_village.Name = "cb_village";
            this.cb_village.Size = new System.Drawing.Size(121, 22);
            this.cb_village.TabIndex = 23;
            this.cb_village.SelectionChangeCommitted += new System.EventHandler(this.cb_village_SelectionChangeCommitted);
            this.cb_village.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_village_KeyPress);
            // 
            // radio_classify
            // 
            this.radio_classify.Dock = System.Windows.Forms.DockStyle.Left;
            this.radio_classify.Location = new System.Drawing.Point(77, 0);
            this.radio_classify.Name = "radio_classify";
            this.radio_classify.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radio_classify.Properties.Appearance.Options.UseBackColor = true;
            this.radio_classify.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radio_classify.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐树种"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "土地权属"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "行政区划")});
            this.radio_classify.Size = new System.Drawing.Size(312, 35);
            this.radio_classify.TabIndex = 18;
            this.radio_classify.SelectedIndexChanged += new System.EventHandler(this.radio_classify_SelectedIndexChanged);
            // 
            // lbl_classify
            // 
            this.lbl_classify.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_classify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_classify.Location = new System.Drawing.Point(10, 0);
            this.lbl_classify.Name = "lbl_classify";
            this.lbl_classify.Size = new System.Drawing.Size(67, 35);
            this.lbl_classify.TabIndex = 2;
            this.lbl_classify.Text = "查询分类：";
            this.lbl_classify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.radio_content);
            this.panelContent.Controls.Add(this.lbl_content);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelContent.Size = new System.Drawing.Size(907, 35);
            this.panelContent.TabIndex = 29;
            // 
            // radio_content
            // 
            this.radio_content.Dock = System.Windows.Forms.DockStyle.Left;
            this.radio_content.Location = new System.Drawing.Point(77, 0);
            this.radio_content.Name = "radio_content";
            this.radio_content.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radio_content.Properties.Appearance.Options.UseBackColor = true;
            this.radio_content.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radio_content.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐蓄积量"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐出材量"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐面积")});
            this.radio_content.Size = new System.Drawing.Size(312, 35);
            this.radio_content.TabIndex = 17;
            this.radio_content.SelectedIndexChanged += new System.EventHandler(this.radio_content_SelectedIndexChanged);
            // 
            // lbl_content
            // 
            this.lbl_content.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_content.Location = new System.Drawing.Point(10, 0);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(67, 35);
            this.lbl_content.TabIndex = 0;
            this.lbl_content.Text = "查询内容：";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.btn_exportTable);
            this.panel2.Controls.Add(this.btn_exportChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(907, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 142);
            this.panel2.TabIndex = 19;
            // 
            // btn_query
            // 
            this.btn_query.ImageIndex = 82;
            this.btn_query.ImageList = this.imageList1;
            this.btn_query.Location = new System.Drawing.Point(12, 10);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 13;
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "color_swatch - 副本.png");
            this.imageList1.Images.SetKeyName(1, "color_wheel.png");
            this.imageList1.Images.SetKeyName(2, "blue-document-search-result.png");
            this.imageList1.Images.SetKeyName(3, "blue-folder-open-document-text.png");
            this.imageList1.Images.SetKeyName(4, "disk.png");
            this.imageList1.Images.SetKeyName(5, "doc.png");
            this.imageList1.Images.SetKeyName(6, "doc-download.png");
            this.imageList1.Images.SetKeyName(7, "doc-edit.png");
            this.imageList1.Images.SetKeyName(8, "doc-info.png");
            this.imageList1.Images.SetKeyName(9, "doc-next.png");
            this.imageList1.Images.SetKeyName(10, "doc-ok.png");
            this.imageList1.Images.SetKeyName(11, "doc-previous.png");
            this.imageList1.Images.SetKeyName(12, "folder_open_document_text.png");
            this.imageList1.Images.SetKeyName(13, "hammer_screwdriver.png");
            this.imageList1.Images.SetKeyName(14, "image.png");
            this.imageList1.Images.SetKeyName(15, "image-edit.png");
            this.imageList1.Images.SetKeyName(16, "image-info.png");
            this.imageList1.Images.SetKeyName(17, "image-ok.png");
            this.imageList1.Images.SetKeyName(18, "image-send.png");
            this.imageList1.Images.SetKeyName(19, "info.png");
            this.imageList1.Images.SetKeyName(20, "layer--arrow.png");
            this.imageList1.Images.SetKeyName(21, "layer--pencil.png");
            this.imageList1.Images.SetKeyName(22, "layers__pencil.png");
            this.imageList1.Images.SetKeyName(23, "layers__plus.png");
            this.imageList1.Images.SetKeyName(24, "layers_arrange.png");
            this.imageList1.Images.SetKeyName(25, "layers00.png");
            this.imageList1.Images.SetKeyName(26, "linechart.png");
            this.imageList1.Images.SetKeyName(27, "line-chart.png");
            this.imageList1.Images.SetKeyName(28, "news.png");
            this.imageList1.Images.SetKeyName(29, "news-edit.png");
            this.imageList1.Images.SetKeyName(30, "news-info.png");
            this.imageList1.Images.SetKeyName(31, "news-ok.png");
            this.imageList1.Images.SetKeyName(32, "news-send.png");
            this.imageList1.Images.SetKeyName(33, "note.png");
            this.imageList1.Images.SetKeyName(34, "printer.png");
            this.imageList1.Images.SetKeyName(35, "search0.png");
            this.imageList1.Images.SetKeyName(36, "searchCA4F6CNX.png");
            this.imageList1.Images.SetKeyName(37, "searchCAAWLE08.png");
            this.imageList1.Images.SetKeyName(38, "size.png");
            this.imageList1.Images.SetKeyName(39, "tree2.png");
            this.imageList1.Images.SetKeyName(40, "web-download.png");
            this.imageList1.Images.SetKeyName(41, "web-search.png");
            this.imageList1.Images.SetKeyName(42, "29_.jpg");
            this.imageList1.Images.SetKeyName(43, "bookmark2.bmp");
            this.imageList1.Images.SetKeyName(44, "BtnSave.bmp");
            this.imageList1.Images.SetKeyName(45, "EditorsUnboundMode3.bmp");
            this.imageList1.Images.SetKeyName(46, "err.bmp");
            this.imageList1.Images.SetKeyName(47, "excel.bmp");
            this.imageList1.Images.SetKeyName(48, "excel2.bmp");
            this.imageList1.Images.SetKeyName(49, "feature_point_move.bmp");
            this.imageList1.Images.SetKeyName(50, "go.bmp");
            this.imageList1.Images.SetKeyName(51, "GotoLine.ico");
            this.imageList1.Images.SetKeyName(52, "msgerror.gif");
            this.imageList1.Images.SetKeyName(53, "msginfo.gif");
            this.imageList1.Images.SetKeyName(54, "msgwarning.gif");
            this.imageList1.Images.SetKeyName(55, "mspridls.gif");
            this.imageList1.Images.SetKeyName(56, "mspubTemplate.gif");
            this.imageList1.Images.SetKeyName(57, "mspubTemplates.gif");
            this.imageList1.Images.SetKeyName(58, "mssetqrate.gif");
            this.imageList1.Images.SetKeyName(59, "printicon.gif");
            this.imageList1.Images.SetKeyName(60, "request3.bmp");
            this.imageList1.Images.SetKeyName(61, "monitor_16.png");
            this.imageList1.Images.SetKeyName(62, "folder_16.png");
            this.imageList1.Images.SetKeyName(63, "plus_16.png");
            this.imageList1.Images.SetKeyName(64, "print_16.png");
            this.imageList1.Images.SetKeyName(65, "document_16.png");
            this.imageList1.Images.SetKeyName(66, "statistics_16.png");
            this.imageList1.Images.SetKeyName(67, "up_16.png");
            this.imageList1.Images.SetKeyName(68, "home_16.png");
            this.imageList1.Images.SetKeyName(69, "down_16.png");
            this.imageList1.Images.SetKeyName(70, "bookmark_16.png");
            this.imageList1.Images.SetKeyName(71, "bubble_16.png");
            this.imageList1.Images.SetKeyName(72, "left_16.png");
            this.imageList1.Images.SetKeyName(73, "warning_16.png");
            this.imageList1.Images.SetKeyName(74, "right_16.png");
            this.imageList1.Images.SetKeyName(75, "tick_16.png");
            this.imageList1.Images.SetKeyName(76, "pencil_16.png");
            this.imageList1.Images.SetKeyName(77, "label_16.png");
            this.imageList1.Images.SetKeyName(78, "delete_16.png");
            this.imageList1.Images.SetKeyName(79, "flag_16.png");
            this.imageList1.Images.SetKeyName(80, "info_16.png");
            this.imageList1.Images.SetKeyName(81, "clock_16.png");
            this.imageList1.Images.SetKeyName(82, "search_16.png");
            this.imageList1.Images.SetKeyName(83, "globe_16.png");
            // 
            // btn_exportTable
            // 
            this.btn_exportTable.ImageIndex = 32;
            this.btn_exportTable.ImageList = this.imageList1;
            this.btn_exportTable.Location = new System.Drawing.Point(12, 47);
            this.btn_exportTable.Name = "btn_exportTable";
            this.btn_exportTable.Size = new System.Drawing.Size(75, 23);
            this.btn_exportTable.TabIndex = 14;
            this.btn_exportTable.Text = "导出表";
            this.btn_exportTable.Click += new System.EventHandler(this.btn_exportTable_Click);
            // 
            // btn_exportChart
            // 
            this.btn_exportChart.ImageIndex = 18;
            this.btn_exportChart.ImageList = this.imageList1;
            this.btn_exportChart.Location = new System.Drawing.Point(12, 82);
            this.btn_exportChart.Name = "btn_exportChart";
            this.btn_exportChart.Size = new System.Drawing.Size(75, 23);
            this.btn_exportChart.TabIndex = 15;
            this.btn_exportChart.Text = "导出图";
            this.btn_exportChart.Click += new System.EventHandler(this.btn_exportChart_Click);
            // 
            // panelCFType
            // 
            this.panelCFType.Controls.Add(this.label3);
            this.panelCFType.Controls.Add(this.comboBoxCFType);
            this.panelCFType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCFType.Location = new System.Drawing.Point(0, 0);
            this.panelCFType.Name = "panelCFType";
            this.panelCFType.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.panelCFType.Size = new System.Drawing.Size(1008, 35);
            this.panelCFType.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(10, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 32);
            this.label3.TabIndex = 24;
            this.label3.Text = "统计数据来源：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCFType
            // 
            this.comboBoxCFType.FormattingEnabled = true;
            this.comboBoxCFType.Items.AddRange(new object[] {
            "采伐专题图层",
            "年度小班图层"});
            this.comboBoxCFType.Location = new System.Drawing.Point(107, 8);
            this.comboBoxCFType.Name = "comboBoxCFType";
            this.comboBoxCFType.Size = new System.Drawing.Size(121, 22);
            this.comboBoxCFType.TabIndex = 23;
            this.comboBoxCFType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCFType_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 380);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1008, 6);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 177);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1008, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel_chart
            // 
            this.panel_chart.Controls.Add(this.chartControl1);
            this.panel_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_chart.Location = new System.Drawing.Point(0, 386);
            this.panel_chart.Name = "panel_chart";
            this.panel_chart.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel_chart.Size = new System.Drawing.Size(1008, 344);
            this.panel_chart.TabIndex = 4;
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 2);
            this.chartControl1.Name = "chartControl1";
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.Name = "Series 1";
            sideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Label = sideBySideBarSeriesLabel2;
            series2.Name = "Series 2";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            sideBySideBarSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel3;
            this.chartControl1.Size = new System.Drawing.Size(1008, 342);
            this.chartControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 180);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1008, 200);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FrmCFStatis
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel_chart);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCFType);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FrmCFStatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采伐统计图表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCFStatis_Load);
            this.Controls.SetChildIndex(this.panelCFType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitter2, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.panel_chart, 0);
            this.panel1.ResumeLayout(false);
            this.panelMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            this.panelChartType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radio_chartType.Properties)).EndInit();
            this.panelClassify.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio_classify.Properties)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radio_content.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelCFType.ResumeLayout(false);
            this.panel_chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        public FrmCFStatis()
        {
            this.InitializeComponent();
        }

        public void InitialValue(string sEditKind, string sEditKind2, string sDistCode, string sTableName)
        {
            try
            {
                if (EditTask.KindCode.Substring(0, 2) != "02" && sEditKind == "采伐")
                {
                    this.panelCFType.Visible = true;
                    this.comboBoxCFType.SelectedIndex = 0;
                    this.m_NDCFWhere0 = "(BHYY like '2%' or BAK2=12)";
                }
                else
                {
                    this.panelCFType.Visible = false;
                }
                this.m_NDCFWhere = "";
                this.m_DistCode = sDistCode;
                this.m_pcode = sDistCode;
                this.m_EditKind0 = sEditKind;
                this.m_EditKind = sEditKind;
                this.m_EditKind20 = sEditKind2;
                this.m_EditKind2 = sEditKind2;
                this.mTableName0 = sTableName;
                this.mTableName = sTableName;
                this.Text = this.m_EditKind + "统计图表";
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string name = "Earth";
                ClassUtils.TABLE_CODE = configOpt.GetConfigValue2(name, "TABLE_CODE");
                ClassUtils.TABLE_ADMIN = configOpt.GetConfigValue2(name, "TABLE_CODE");
                if (sEditKind != "火灾")
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.m_EditKind2 + "Content");
                    this.mContentArray = configValue.Split(new char[]
					{
						','
					});
                }
                else
                {
                    this.m_content = "";
                    this.m_yTitle = "次";
                }
                this.mClassifyArray = UtilFactory.GetConfigOpt().GetConfigValue(this.m_EditKind2 + "Classify").Split(new char[]
				{
					','
				});
                this.sFieldTime = UtilFactory.GetConfigOpt().GetConfigValue(this.m_EditKind2 + "FieldTime");
                this.OpenConnection();
                this.m_pname = this.GetNameByMetaCode("县", this.m_pcode);
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "StatisChart.FrmCFStatis", "InitialValue", ex.GetHashCode().ToString(), ex.Source, ex.Message, "", "", "");
            }
        }

        private void comboBoxCFType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCFType.SelectedIndex == 0)
            {
                this.m_EditKind = this.m_EditKind0;
                this.m_EditKind2 = this.m_EditKind20;
                this.mTableName = this.mTableName0;
                this.radio_content.Properties.Items.Clear();
                this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
				{
					new RadioGroupItem(null, this.m_EditKind + "蓄积量")
				});
                this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
				{
					new RadioGroupItem(null, this.m_EditKind + "出材量")
				});
                this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
				{
					new RadioGroupItem(null, this.m_EditKind + "面积")
				});
                this.m_NDCFWhere = "";
            }
            else
            {
                this.m_EditKind = "年度" + this.m_EditKind0;
                this.m_EditKind2 = "ND" + this.m_EditKind20;
                this.mTableName = UtilFactory.GetConfigOpt().GetConfigValue2("Earth", "TABLE_XB") + "_" + UtilFactory.GetConfigOpt().GetConfigValue("EditYear");
                this.radio_content.Properties.Items.Clear();
                this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
				{
					new RadioGroupItem(null, this.m_EditKind + "面积")
				});
                this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
				{
					new RadioGroupItem(null, this.m_EditKind + "小班个数")
				});
                this.m_NDCFWhere = this.m_NDCFWhere0;
            }
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.m_EditKind2 + "Content");
            this.mContentArray = configValue.Split(new char[]
			{
				','
			});
            this.mClassifyArray = UtilFactory.GetConfigOpt().GetConfigValue(this.m_EditKind2 + "Classify").Split(new char[]
			{
				','
			});
            this.radio_content.SelectedIndex = 0;
            this.radio_content_SelectedIndexChanged(null, null);
            this.cb_town.DataSource = null;
            this.cb_village.DataSource = null;
            this.radio_classify_SelectedIndexChanged(null, null);
        }

        private void FrmCFStatis_Load(object sender, EventArgs e)
        {
            this.cb_town.Visible = false;
            this.cb_village.Visible = false;
            this.m_control = new ChartControl();
            this.panel_chart.Controls.Add(this.m_control);
            this.m_control.Dock = DockStyle.Fill;
            if (this.m_EditKind == "火灾")
            {
                this.panelContent.Visible = false;
            }
            else
            {
                this.panelContent.Visible = true;
            }
            DateTime dateTime = DateTime.Now;
            dateTime = DateTime.Parse(dateTime.AddDays((double)(1 - dateTime.Day)).ToShortDateString() + " 00:00:00");
            this.dateEditStart.DateTime = dateTime.AddMonths(-dateTime.Month + 1);
            this.dateEditEnd.DateTime = DateTime.Parse(dateTime.AddMonths(1).AddDays(-1.0).ToShortDateString() + " 23:59:59");
            this.InitialRadioGroup();
            this.radio_content.SelectedIndexChanged += new EventHandler(this.radio_content_SelectedIndexChanged);
            this.radio_classify.SelectedIndexChanged += new EventHandler(this.radio_classify_SelectedIndexChanged);
        }

        private void InitialRadioGroup()
        {
            try
            {
                if (this.m_EditKind == "造林")
                {
                    this.radio_content.Properties.Items.Clear();
                    this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, this.m_EditKind + "面积")
					});
                    this.radio_content.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, this.m_EditKind + "株数")
					});
                    this.radio_classify.Properties.Items.Clear();
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, this.m_EditKind + "树种")
					});
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, this.m_EditKind + "类别")
					});
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, "土地权属")
					});
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, "行政区划")
					});
                }
                else if (this.m_EditKind == "火灾")
                {
                    this.radio_classify.Properties.Items.Clear();
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, "24小时")
					});
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, "月")
					});
                    this.radio_classify.Properties.Items.AddRange(new RadioGroupItem[]
					{
						new RadioGroupItem(null, "火灾原因")
					});
                }
                this.radio_content.SelectedIndex = -1;
                this.radio_content.SelectedIndex = 0;
                this.radio_classify.SelectedIndex = -1;
                this.radio_classify.SelectedIndex = 0;
                this.radio_chartType.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "StatisChart.FrmCFStatis", "InitialRadioGroup", ex.GetHashCode().ToString(), ex.Source, ex.Message, "", "", "");
            }
        }

        private void radio_content_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radio_content.SelectedIndex < 0)
            {
                return;
            }
            if (this.panelContent.Visible)
            {
                this.m_content = this.mContentArray[this.radio_content.SelectedIndex];
                if (this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description.Contains("蓄积"))
                {
                    this.m_yTitle = "立方米";
                    return;
                }
                if (this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description.Contains("出材量"))
                {
                    this.m_yTitle = "立方米";
                    return;
                }
                if (this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description.Contains("面积"))
                {
                    this.m_yTitle = "公顷";
                    return;
                }
                if (this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description.Contains("株数"))
                {
                    this.m_yTitle = "株";
                    return;
                }
                if (this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description.Contains("个数"))
                {
                    this.m_yTitle = "个";
                }
            }
        }

        private void radio_classify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radio_classify.SelectedIndex < 0)
            {
                return;
            }
            this.m_classify = this.mClassifyArray[this.radio_classify.SelectedIndex];
            if (this.radio_classify.Properties.Items[this.radio_classify.SelectedIndex].Description.Contains("区划"))
            {
                this.SetAdminControlVisible(true);
                this.cb_town.DataSource = this.GetAdminComboDataSource();
                this.cb_town.DisplayMember = "CNAME";
                this.cb_town.ValueMember = "CCODE";
                this.cb_town.SelectedIndex = -1;
                this.m_needSum = true;
                this.m_pcode = this.m_DistCode;
                this.m_pname = "";
                return;
            }
            this.SetAdminControlVisible(false);
            this.m_pname = this.GetNameByMetaCode("县", this.m_pcode);
        }

        private void cb_town_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_town.SelectedIndex < 0)
            {
                return;
            }
            this.m_pcode = this.cb_town.SelectedValue.ToString();
            this.m_pname = ((DataRowView)this.cb_town.SelectedItem).Row["CNAME"].ToString();
            this.m_classify = "CUN";
            this.cb_village.DataSource = this.GetAdminComboDataSource();
            this.cb_village.DisplayMember = "CNAME";
            this.cb_village.ValueMember = "CCODE";
            this.cb_village.SelectedIndex = -1;
            this.m_needSum = true;
        }

        private void cb_village_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_village.SelectedIndex < 0)
            {
                return;
            }
            this.m_pcode = this.cb_village.SelectedValue.ToString();
            this.m_pname = this.cb_village.Text.Trim();
            this.m_classify = "CUN";
            this.m_needSum = false;
        }

        private void radio_chartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radio_chartType.SelectedIndex == 0)
            {
                this.m_chartType = ViewType.Line;
                return;
            }
            if (this.radio_chartType.SelectedIndex == 1)
            {
                this.m_chartType = ViewType.Bar;
                return;
            }
            if (this.radio_chartType.SelectedIndex == 2)
            {
                this.m_chartType = ViewType.Line3D;
                return;
            }
            if (this.radio_chartType.SelectedIndex == 3)
            {
                this.m_chartType = ViewType.Bar3D;
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dateEditStart.DateTime;
            DateTime dateTime2 = this.dateEditEnd.DateTime;
            if (dateTime > dateTime2)
            {
                MessageBox.Show("录入开始时间比结束时间晚，请修改！", "提示");
                return;
            }
            this.gridControl1.DataSource = null;
            this.m_control.Series.Clear();
            this.m_control.Titles.Clear();
            dateTime = dateTime.AddDays((double)(1 - dateTime.Day));
            DateTime dateTime3 = dateTime2.AddMonths(1);
            dateTime2 = dateTime3.AddDays((double)(1 - dateTime3.Day - 1));
            DataTable dataTable;
            if (this.m_classify.Equals("XIANG") || this.m_classify.Equals("CUN"))
            {
                dataTable = this.DoQueryByAdmin(dateTime, dateTime2);
            }
            else
            {
                dataTable = this.DoQueryUpToNow(dateTime, dateTime2);
            }
            if (dataTable == null || dataTable.Rows.Count < 1)
            {
                MessageBox.Show("查询结果为空！", "提示");
                return;
            }
            DataTable dataTable2 = this.ConvertStatisTable(dataTable);
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = dataTable2;
            this.gridView1.RefreshData();
            this.GenerateChartControl(dataTable2);
        }

        private void btn_exportTable_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xls)|*.xls";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = false;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "保存为Excel文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.gridControl1.ExportToXls(saveFileDialog.FileName);
            }
        }

        private void btn_exportChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image files(*.jpeg)|*.jpeg";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = false;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "保存为image文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_control.ExportToImage(saveFileDialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void SetAdminControlVisible(bool visible)
        {
            this.lbl_town.Visible = visible;
            this.cb_town.Visible = visible;
            this.lbl_village.Visible = visible;
            this.cb_village.Visible = visible;
        }

        private DataTable DoQueryUpToNow(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                if (string.IsNullOrEmpty(this.m_classify))
                {
                    result = null;
                }
                else
                {
                    string description = this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description;
                    string description2 = this.radio_classify.Properties.Items[this.radio_classify.SelectedIndex].Description;
                    List<string> queryColumns = this.GetQueryColumns(this.m_classify, description2);
                    if (queryColumns == null)
                    {
                        result = null;
                    }
                    else
                    {
                        this.m_xTitle = description2;
                        this.OpenConnection();
                        if (this.m_EditKind == "火灾")
                        {
                            if (description2.Contains("火灾原因"))
                            {
                                this.m_title = string.Concat(new object[]
								{
									pStartDate.Year,
									"年",
									pStartDate.Month,
									"月--",
									pEndDate.Year,
									"年",
									pEndDate.Month,
									"月",
									this.m_pname,
									description2,
									"构成图"
								});
                            }
                            else
                            {
                                this.m_title = string.Concat(new object[]
								{
									pStartDate.Year,
									"年",
									pStartDate.Month,
									"月--",
									pEndDate.Year,
									"年",
									pEndDate.Month,
									"月",
									this.m_pname,
									description2,
									this.m_EditKind,
									"分布图"
								});
                            }
                            string configValue = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "TimeField");
                            for (int i = 0; i < queryColumns.Count; i++)
                            {
                                DataTable dataTable2 = new DataTable();
                                StringBuilder stringBuilder = new StringBuilder();
                                string text = queryColumns[i];
                                if (description2.Contains("月"))
                                {
                                    stringBuilder.Append("select ").Append(text).Append(" as 月").Append(",count(1) as 次数");
                                    stringBuilder.Append(" from ").Append(this.mTableName);
                                    stringBuilder.Append(" where DateName(month,").Append(this.m_classify).Append(")='").Append(text.PadLeft(2, '0')).Append("'");
                                }
                                else if (description2.Contains("小时"))
                                {
                                    stringBuilder.Append("select ").Append(text).Append(" as 小时").Append(",count(1) as 次数");
                                    stringBuilder.Append(" from ").Append(this.mTableName);
                                    stringBuilder.Append(" where DateName(hour,").Append(this.m_classify).Append(")='").Append(text).Append("'");
                                }
                                else if (description2.Contains("火灾原因"))
                                {
                                    string[] array = text.Split(new char[]
									{
										','
									});
                                    string value = array[1];
                                    string value2 = array[0];
                                    stringBuilder.Append("select '").Append(value).Append("' as 火灾原因").Append(",count(1) as 次数");
                                    stringBuilder.Append(" from ").Append(this.mTableName);
                                    stringBuilder.Append(" where ").Append(this.m_classify).Append("='").Append(value2).Append("'");
                                }
                                stringBuilder.Append(" and ").Append(string.Concat(new string[]
								{
									configValue,
									">=cast('",
									pStartDate.ToString(),
									"' as datetime) and ",
									configValue,
									"<cast('",
									pEndDate.ToString(),
									"' as datetime)"
								}));
                                this.m_cmd = new SqlCommand(stringBuilder.ToString(), this.m_conn);
                                this.m_adapter = new SqlDataAdapter();
                                this.m_adapter.SelectCommand = this.m_cmd;
                                this.m_adapter.Fill(dataTable2);
                                dataTable.Merge(dataTable2);
                            }
                            result = this.FilterDataTable(dataTable);
                        }
                        else
                        {
                            this.m_title = string.Concat(new object[]
							{
								pStartDate.Year,
								"年",
								pStartDate.Month,
								"月--",
								pEndDate.Year,
								"年",
								pEndDate.Month,
								"月",
								description,
								"统计图(按",
								description2,
								")"
							});
                            DateTime t = pStartDate;
                            while (t < pEndDate)
                            {
                                DataTable dataTable3 = new DataTable();
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append("select ").Append(t.Month).Append(" as 月份");
                                for (int j = 0; j < queryColumns.Count; j++)
                                {
                                    string text2;
                                    if (description2.Contains("树种"))
                                    {
                                        text2 = this.GetNameByMetaCode("树种", queryColumns[j]);
                                    }
                                    else
                                    {
                                        text2 = this.GetNameByMetaCode(description2, queryColumns[j]);
                                    }
                                    if (text2 == "")
                                    {
                                        text2 = queryColumns[j];
                                        if (text2.Trim() == "")
                                        {
                                            text2 = "无";
                                        }
                                    }
                                    stringBuilder.Append(",sum(case when ").Append(this.m_classify).Append("='").Append(queryColumns[j]).Append("' then ").Append(this.m_content).Append(" else 0 end) as ").Append("\"" + text2 + "\"");
                                }
                                stringBuilder.Append(" from ").Append(this.mTableName).Append(" where substring(" + this.sFieldTime + ",1,6)=");
                                stringBuilder.Append("'" + t.ToString("yyyyMM") + "'");
                                if (this.m_NDCFWhere != "")
                                {
                                    stringBuilder.Append(" and " + this.m_NDCFWhere);
                                }
                                this.m_cmd = new SqlCommand(stringBuilder.ToString(), this.m_conn);
                                this.m_adapter = new SqlDataAdapter();
                                this.m_adapter.SelectCommand = this.m_cmd;
                                this.m_adapter.Fill(dataTable3);
                                dataTable.Merge(dataTable3);
                                t = t.AddMonths(1);
                            }
                            result = this.FilterDataTable(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法DoQueryUpToNow查询出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        private List<string> GetQueryColumns(string key, string sAlias)
        {
            List<string> result;
            try
            {
                List<string> list = new List<string>();
                this.OpenConnection();
                if (this.m_EditKind == "火灾")
                {
                    if (sAlias.Contains("月"))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            list.Add(i.ToString());
                        }
                    }
                    else if (sAlias.Contains("小时"))
                    {
                        for (int j = 1; j <= 24; j++)
                        {
                            if (j == 24)
                            {
                                list.Add("0");
                            }
                            else
                            {
                                list.Add(j.ToString());
                            }
                        }
                    }
                    else if (sAlias.Contains("原因"))
                    {
                        string cmdText = string.Concat(new string[]
						{
							"select ccode,cname from ",
							ClassUtils.TABLE_CODE,
							" where cdomain='",
							key,
							"' order by ccode"
						});
                        this.m_cmd = new SqlCommand(cmdText, this.m_conn);
                        this.m_reader = this.m_cmd.ExecuteReader();
                        while (this.m_reader.Read())
                        {
                            if (this.m_reader.GetValue(0) != DBNull.Value)
                            {
                                list.Add(Convert.ToString(this.m_reader.GetValue(0)) + "," + Convert.ToString(this.m_reader.GetValue(1)));
                            }
                        }
                        this.m_reader.Close();
                    }
                }
                else
                {
                    string cmdText;
                    if (this.m_NDCFWhere != "")
                    {
                        cmdText = string.Concat(new string[]
						{
							"select distinct ",
							key,
							" from ",
							this.mTableName,
							" where ",
							this.m_NDCFWhere,
							" order by ",
							key
						});
                    }
                    else
                    {
                        cmdText = string.Concat(new string[]
						{
							"select distinct ",
							key,
							" from ",
							this.mTableName,
							" order by ",
							key
						});
                    }
                    this.m_cmd = new SqlCommand(cmdText, this.m_conn);
                    this.m_reader = this.m_cmd.ExecuteReader();
                    while (this.m_reader.Read())
                    {
                        if (this.m_reader.GetValue(0) != DBNull.Value)
                        {
                            list.Add(Convert.ToString(this.m_reader.GetValue(0)));
                        }
                    }
                    this.m_reader.Close();
                }
                result = list;
            }
            catch
            {
                result = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        private string GetNameByMetaCode(string ctype, string ccode)
        {
            SqlDataReader sqlDataReader = null;
            string result;
            try
            {
                this.OpenConnection();
                string cmdText = string.Concat(new string[]
				{
					"select CNAME from ",
					ClassUtils.TABLE_CODE,
					" where CTYPE='",
					ctype,
					"' and CCODE='",
					ccode,
					"'"
				});
                SqlCommand sqlCommand = new SqlCommand(cmdText, this.m_conn);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.GetValue(0) != DBNull.Value)
                    {
                        result = Convert.ToString(sqlDataReader.GetValue(0));
                        return result;
                    }
                }
                result = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法GetNameByMetaCode查询元数据名出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (this.m_reader != null && !this.m_reader.IsClosed)
                {
                    this.m_reader.Close();
                }
                result = string.Empty;
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
            }
            return result;
        }

        private DataTable FilterDataTable(DataTable dt)
        {
            if (dt == null)
            {
                return dt;
            }
            if (dt.Rows.Count < 1)
            {
                return dt;
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(dt.Columns[0].Caption, typeof(string));
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dataTable.Columns.Add(dt.Columns[i].Caption, typeof(decimal));
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                object[] array = new object[dt.Columns.Count];
                string text = dt.Rows[j][0].ToString();
                if (this.m_xTitle.Contains("小时"))
                {
                    array[0] = this.ConvertHour(text);
                }
                else
                {
                    array[0] = this.ConvertMonth(text);
                }
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    array[k] = dt.Rows[j][k];
                }
                dataTable.Rows.Add(array);
            }
            return dataTable;
        }

        private string ConvertMonth(string month)
        {
            string key;
            switch (key = month)
            {
                case "1":
                    month = "一月";
                    break;
                case "2":
                    month = "二月";
                    break;
                case "3":
                    month = "三月";
                    break;
                case "4":
                    month = "四月";
                    break;
                case "5":
                    month = "五月";
                    break;
                case "6":
                    month = "六月";
                    break;
                case "7":
                    month = "七月";
                    break;
                case "8":
                    month = "八月";
                    break;
                case "9":
                    month = "九月";
                    break;
                case "10":
                    month = "十月";
                    break;
                case "11":
                    month = "十一月";
                    break;
                case "12":
                    month = "十二月";
                    break;
            }
            return month;
        }

        private string ConvertHour(string hour)
        {
            return hour + "时";
        }

        private void GenerateChartControl(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            if (this.m_control.Series.Count > 0)
            {
                this.m_control.Series.Clear();
            }
            if (this.m_control.Titles.Count > 0)
            {
                this.m_control.Titles.Clear();
            }
            ChartService.SetChartTitle(this.m_control, true, this.m_title, true, 2, StringAlignment.Center, ChartTitleDockStyle.Top, true, new Font("宋体", 12f, FontStyle.Bold), Color.Red, 10);
            double num = -1.0;
            double num2 = -1.0;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                double num3 = -1.0;
                double num4 = -1.0;
                ChartService.DrawChart(this.m_control, dt.Columns[i].Caption, this.m_chartType, dt, 0, i, ref num3, ref num4);
                if (num < 0.0)
                {
                    num = num3;
                }
                if (num3 < num)
                {
                    num = num3;
                }
                if (num2 < 0.0)
                {
                    num2 = num4;
                }
                if (num4 > num2)
                {
                    num2 = num4;
                }
            }
            if (num > 0.0)
            {
                num = Math.Floor(num * 0.8);
            }
            if (num2 > 0.0)
            {
                num2 = Math.Ceiling(num2 * 1.1 + 0.5);
            }
            if (this.m_classify.Contains("HZYY"))
            {
                ChartService.SetAxisX(this.m_control, true, this.m_chartType, StringAlignment.Far, this.m_xTitle, Color.Red, true, new Font("宋体", 12f, FontStyle.Bold), true);
            }
            else
            {
                ChartService.SetAxisX(this.m_control, true, this.m_chartType, StringAlignment.Far, this.m_xTitle, Color.Red, true, new Font("宋体", 12f, FontStyle.Bold), false);
            }
            ChartService.SetAxisY(this.m_control, true, StringAlignment.Far, this.m_yTitle, Color.Red, true, new Font("宋体", 12f, FontStyle.Bold), num, num2);
            this.chartControl1.Visible = false;
        }

        private void OpenConnection()
        {
            try
            {
                if (this.m_conn == null)
                {
                    string sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");
                 //   string connString = UtilFactory.GetDBAccess(sDBKey).ConnectionString;
                    this.m_conn = new SqlConnection("");
                }
                if (this.m_conn.State != ConnectionState.Open)
                {
                    this.m_conn.Open();
                }
            }
            catch
            {
            }
        }

        private void CloseConnection()
        {
            try
            {
                if (this.m_reader != null && !this.m_reader.IsClosed)
                {
                    this.m_reader.Close();
                }
                if (this.m_conn != null && this.m_conn.State != ConnectionState.Closed)
                {
                    this.m_conn.Close();
                }
            }
            catch
            {
            }
        }

        private DataTable DoQueryByAdmin(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                if (string.IsNullOrEmpty(this.m_classify))
                {
                    result = null;
                }
                else
                {
                    List<string> adminCodes = this.GetAdminCodes(this.m_pcode);
                    this.OpenConnection();
                    string description = this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description;
                    if (this.m_EditKind == "火灾")
                    {
                        this.m_title = string.Concat(new object[]
						{
							pStartDate.Year,
							"年",
							pStartDate.Month,
							"月--",
							pEndDate.Year,
							"年",
							pEndDate.Month,
							"月",
							this.m_pname,
							description,
							this.m_EditKind,
							"分布图"
						});
                    }
                    else
                    {
                        this.m_title = string.Concat(new object[]
						{
							pStartDate.Year,
							"年",
							pStartDate.Month,
							"月--",
							pEndDate.Year,
							"年",
							pEndDate.Month,
							"月",
							this.m_pname,
							description,
							"统计图"
						});
                    }
                    DateTime t = pStartDate;
                    while (t < pEndDate)
                    {
                        DataTable dataTable2 = new DataTable();
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("select ").Append(t.Month).Append(" as 月份");
                        for (int i = 0; i < adminCodes.Count; i++)
                        {
                            stringBuilder.Append(",sum(case when ").Append(this.m_classify).Append("='").Append(adminCodes[i]).Append("' then ").Append(this.m_content).Append(" else 0 end) as ").Append("\"" + this.GetAdminNameByCode(adminCodes[i]) + "\"");
                        }
                        stringBuilder.Append(" from ").Append(this.mTableName).Append(" where substring(GXSJ,1,6)=");
                        stringBuilder.Append(t.ToString("yyyyMM"));
                        if (this.m_NDCFWhere != "")
                        {
                            stringBuilder.Append(" and " + this.m_NDCFWhere);
                        }
                        this.m_cmd = new SqlCommand(stringBuilder.ToString(), this.m_conn);
                        this.m_adapter = new SqlDataAdapter();
                        this.m_adapter.SelectCommand = this.m_cmd;
                        this.m_adapter.Fill(dataTable2);
                        dataTable.Merge(dataTable2);
                        t = t.AddMonths(1);
                    }
                    if (this.m_needSum)
                    {
                        result = this.SumResultDataTable(this.FilterDataTable(dataTable));
                    }
                    else
                    {
                        result = this.FilterDataTable(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法DoQueryByAdmin查询出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        private List<string> GetAdminCodes(string pcode)
        {
            List<string> result;
            try
            {
                List<string> list = new List<string>();
                this.OpenConnection();
                string cmdText = string.Empty;
                int length = pcode.Length;
                if (length != 6)
                {
                    if (length != 9)
                    {
                        if (length == 12)
                        {
                            if (this.m_NDCFWhere != "")
                            {
                                cmdText = string.Concat(new string[]
								{
									"select distinct CUN from ",
									this.mTableName,
									" where CUN='",
									pcode,
									"' and ",
									this.m_NDCFWhere,
									" order by CUN"
								});
                            }
                            else
                            {
                                cmdText = string.Concat(new string[]
								{
									"select distinct CUN from ",
									this.mTableName,
									" where CUN='",
									pcode,
									"' order by CUN"
								});
                            }
                        }
                    }
                    else if (this.m_NDCFWhere != "")
                    {
                        cmdText = string.Concat(new string[]
						{
							"select distinct CUN from ",
							this.mTableName,
							" where XIANG='",
							pcode,
							"' and ",
							this.m_NDCFWhere,
							" order by CUN"
						});
                    }
                    else
                    {
                        cmdText = string.Concat(new string[]
						{
							"select distinct CUN from ",
							this.mTableName,
							" where XIANG='",
							pcode,
							"' order by CUN"
						});
                    }
                }
                else if (this.m_NDCFWhere != "")
                {
                    cmdText = string.Concat(new string[]
					{
						"select distinct XIANG from ",
						this.mTableName,
						" where ",
						this.m_NDCFWhere,
						" order by XIANG"
					});
                }
                else
                {
                    cmdText = "select distinct XIANG from " + this.mTableName + " order by XIANG";
                }
                this.m_cmd = new SqlCommand(cmdText, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        list.Add(Convert.ToString(this.m_reader.GetValue(0)));
                    }
                }
                this.m_reader.Close();
                result = list;
            }
            catch
            {
                result = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        private DataTable GetAdminComboDataSource()
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                List<string> adminCodes = this.GetAdminCodes(this.m_pcode);
                if (adminCodes.Count == 0)
                {
                    result = dataTable;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("(");
                    for (int i = 0; i < adminCodes.Count; i++)
                    {
                        stringBuilder.Append("'").Append(adminCodes[i]).Append("',");
                    }
                    stringBuilder.Replace(",", "", stringBuilder.Length - 1, 1);
                    stringBuilder.Append(")");
                    this.OpenConnection();
                    string cmdText = "select CNAME,CCODE from " + ClassUtils.TABLE_ADMIN + " where CCODE in " + stringBuilder.ToString();
                    this.m_cmd = new SqlCommand(cmdText, this.m_conn);
                    this.m_adapter = new SqlDataAdapter();
                    this.m_adapter.SelectCommand = this.m_cmd;
                    this.m_adapter.Fill(dataTable);
                    result = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法GetAdminComboDataSource查询出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        private string GetAdminNameByCode(string code)
        {
            SqlDataReader sqlDataReader = null;
            string result;
            try
            {
                this.OpenConnection();
                string cmdText = string.Concat(new string[]
				{
					"select CNAME from ",
					ClassUtils.TABLE_ADMIN,
					" where CCODE='",
					code,
					"'"
				});
                SqlCommand sqlCommand = new SqlCommand(cmdText, this.m_conn);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.GetValue(0) != DBNull.Value)
                    {
                        result = Convert.ToString(sqlDataReader.GetValue(0));
                        return result;
                    }
                }
                result = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法GetAdminNameByCode查询乡村名出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (this.m_reader != null && !this.m_reader.IsClosed)
                {
                    this.m_reader.Close();
                }
                result = string.Empty;
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
            }
            return result;
        }

        private DataTable SumResultDataTable(DataTable dt)
        {
            DataTable result;
            try
            {
                double num = 0.0;
                dt.Columns.Add(this.m_pname, typeof(decimal));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 1; j < dt.Columns.Count - 1; j++)
                    {
                        num += this.ConvertToDouble(dt.Rows[i][j].ToString());
                    }
                    dt.Rows[i][dt.Columns.Count - 1] = num;
                    num = 0.0;
                }
                result = dt;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        private double ConvertToDouble(string sValue)
        {
            double result;
            try
            {
                result = Convert.ToDouble(sValue);
            }
            catch
            {
                result = 0.0;
            }
            return result;
        }

        private void cb_town_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cb_village_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private DataTable ConvertStatisTable(DataTable dt)
        {
            DataTable result;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    string description = this.radio_content.Properties.Items[this.radio_content.SelectedIndex].Description;
                    DataTable dataTable = dt.Clone();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Rows[i][j] is DBNull)
                            {
                                dataRow[j] = dt.Rows[i][j];
                            }
                            else if (dt.Columns[j].DataType == typeof(decimal))
                            {
                                if (description.Contains("面积"))
                                {
                                    dataRow[j] = Math.Round(Convert.ToDouble(dt.Rows[i][j]), 1);
                                }
                                else
                                {
                                    dataRow[j] = Math.Round(Convert.ToDouble(dt.Rows[i][j]), 0);
                                }
                            }
                            else
                            {
                                dataRow[j] = dt.Rows[i][j];
                            }
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    result = dataTable;
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法ConvertForestStatisTable出错，可能的原因：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
            }
            return result;
        }
    }
}
