namespace AttributesEdit
{
    using AxDSOFramer;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DSOFramer;
    using ESRI.ArcGIS.Geodatabase;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class FormHarTable : Form
    {
        private AxFramerControl axFramerControl1;
        private Bar bar1;
        private Bar bar2;
        private BarButtonItem barButtonItemPrint;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private BarStaticItem barStaticItem1;
        private IContainer components;
        private System.Windows.Forms.Label labelLoading;
        private bool m_bLoad;
        private IFeature m_Feature;
        private Panel panel1;
        private PanelControl panelLoading;

        public FormHarTable()
        {
            this.InitializeComponent();
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.axFramerControl1.ShowDialog(dsoShowDialogType.dsoDialogPrint);
                MessageBox.Show("操作完成！");
            }
            catch
            {
                MessageBox.Show("打印出错！");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormHarTable_Activated(object sender, EventArgs e)
        {
            if (!this.m_bLoad)
            {
                this.m_bLoad = true;
                this.panelLoading.Visible = true;
                this.labelLoading.Refresh();
                this.Refresh();
                this.LoadWordDocument();
                this.panelLoading.Visible = false;
                this.panel1.Visible = true;
                this.Refresh();
            }
        }

        private void FormHarTable_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private Range GetRange(Worksheet pSheet, Range usedRange, string sName)
        {
            for (int i = 1; i <= usedRange.Rows.Count; i++)
            {
                for (int j = 1; j <= usedRange.Columns.Count; j++)
                {
                    Range range = pSheet.Cells[i, j] as Range;
                    object obj2 = range.Value2;
                    if ((obj2 != null) && (obj2.ToString() == sName))
                    {
                        return range;
                    }
                }
            }
            return null;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHarTable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.panelLoading = new DevExpress.XtraEditors.PanelControl();
            this.labelLoading = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLoading)).BeginInit();
            this.panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.axFramerControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 531);
            this.panel1.TabIndex = 1;
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(874, 531);
            this.axFramerControl1.TabIndex = 0;
            // 
            // panelLoading
            // 
            this.panelLoading.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(0, 31);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(874, 531);
            this.panelLoading.TabIndex = 18;
            // 
            // labelLoading
            // 
            this.labelLoading.BackColor = System.Drawing.Color.Transparent;
            this.labelLoading.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoading.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.ForeColor = System.Drawing.Color.Black;
            this.labelLoading.Location = new System.Drawing.Point(0, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLoading.Size = new System.Drawing.Size(874, 531);
            this.labelLoading.TabIndex = 15;
            this.labelLoading.Text = "正在加载，请稍候……";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemPrint,
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.Caption = "打印";
            this.barButtonItemPrint.Id = 0;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(874, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(874, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 531);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(874, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 531);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // FormHarTable
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 562);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormHarTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易伐区调查设计表";
            this.Activated += new System.EventHandler(this.FormHarTable_Activated);
            this.Load += new System.EventHandler(this.FormHarTable_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLoading)).EndInit();
            this.panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        private void LoadExcelDocument()
        {
            try
            {
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string path = configOpt.RootPath + @"\" + configOpt.GetConfigValue2("Harvest", "AttrTable") + ".xls";
                if (!File.Exists(path))
                {
                    MessageBox.Show("模板文件不存在，无法打印！");
                }
                else
                {
                    this.axFramerControl1.Open(path);
                    if (this.m_Feature != null)
                    {
                        object activeDocument = this.axFramerControl1.ActiveDocument;
                        Workbook workbook = (Workbook) this.axFramerControl1.ActiveDocument;
                        ApplicationClass application = workbook.Application as ApplicationClass;
                        Workbook workbook2 = application.Workbooks[1];
                        Worksheet worksheet = workbook2.Worksheets[1] as Worksheet;
                        if (worksheet.UsedRange.Rows.Count < 1)
                        {
                            return;
                        }
                    }
                    this.axFramerControl1.ProtectDoc(1, 2, "pwd");
                }
            }
            catch
            {
                MessageBox.Show("打开简易伐区调查设计表出错！");
            }
        }

        private void LoadWordDocument()
        {
            try
            {
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string path = configOpt.RootPath + @"\" + configOpt.GetConfigValue2("Harvest", "AttrTable") + ".doc";
                if (!File.Exists(path))
                {
                    MessageBox.Show("模板文件不存在，无法打印！");
                }
                else
                {
                    this.axFramerControl1.Open(path, true, "word.document", "", "");
                    if (this.m_Feature != null)
                    {
                        IFields fields = this.m_Feature.Fields;
                        for (int i = 0; i < fields.FieldCount; i++)
                        {
                            IField field = fields.get_Field(i);
                            string name = field.Name;
                            string strValue = "";
                            object obj2 = this.m_Feature.get_Value(i);
                            if (obj2 != null)
                            {
                                strValue = obj2.ToString();
                            }
                            IDomain domain = field.Domain;
                            if ((domain != null) && (domain is ICodedValueDomain))
                            {
                                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                                for (int j = 0; j < domain2.CodeCount; j++)
                                {
                                    if (strValue == domain2.get_Value(j).ToString())
                                    {
                                        strValue = domain2.get_Name(j);
                                    }
                                }
                            }
                            this.axFramerControl1.SetFieldValue(name, strValue, "");
                        }
                    }
                    this.axFramerControl1.ProtectDoc(1, 2, "pwd");
                }
            }
            catch
            {
                MessageBox.Show("打开简易伐区调查设计表出错！");
            }
        }

        public IFeature ShowFeature
        {
            set
            {
                this.m_Feature = value;
            }
        }
    }
}

