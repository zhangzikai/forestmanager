namespace gylandzzytj
{
    using DevExpress.Utils;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using DevExpress.XtraGrid.Views.Base;

    /// <summary>
    /// 统计--月统计报表：窗体
    /// </summary>
    public class FormLDZZYMonthReport : Form
    {
        private string _TableName = "";
        private AdvBandedGridView advBandedGridView1;
        private BandedGridColumn bandedGridColumn1;
        private BandedGridColumn bandedGridColumn2;
        private BandedGridColumn bandedGridColumn3;
        private BandedGridColumn bandedGridColumn4;
        private BandedGridColumn bandedGridColumn5;
        private BandedGridColumn bandedGridColumn6;
        private BandedGridColumn bandedGridColumn7;
        private BandedGridColumn bandedGridColumn8;
        private IContainer components;
        private DateTimePicker dateTimePicker1;
        private GridControl gridControl1;
        private CommonFunctions pcomonclass = new CommonFunctions();
        private System.Data.DataTable pTJTABLE;
        private System.Windows.Forms.TextBox textBox1;
        private ToolStripButton tlb_btn_OK;
        private ToolStripButton tlb_btnExportXLS;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private string xiancode = "";

        /// <summary>
        /// 统计--月统计报表：窗体：构造器
        /// </summary>
        /// <param name="tname"></param>
        public FormLDZZYMonthReport(string tname)
        {
            this.InitializeComponent();
            ToolStripControlHost host = new ToolStripControlHost(this.dateTimePicker1);
            this.toolStrip1.Items.Insert(1, host);
            this._TableName = tname;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormZZYMonthReport_Load(object sender, EventArgs e)
        {
            this.InitTable();
            this.pTJTABLE = this.TJZZYMonthReport(this._TableName, DateTime.Now.ToString("yyyy-MM"));
            this.gridControl1.DataSource = this.pTJTABLE;
            for (int i = 0; i < this.pTJTABLE.Columns.Count; i++)
            {
                this.advBandedGridView1.Columns[i].FieldName = this.pTJTABLE.Columns[i].ColumnName;
            }
            this.advBandedGridView1.OptionsBehavior.Editable = false;
        }

        private System.Data.DataTable GetDataTabeBySelRows(System.Data.DataTable dt, string sel)
        {
            System.Data.DataTable table = dt.Clone();
            DataRow[] rowArray = dt.Select(sel);
            if (rowArray.Length < 0)
            {
                return null;
            }
            foreach (DataRow row in rowArray)
            {
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormLDZZYMonthReport));
            this.toolStrip1 = new ToolStrip();
            this.toolStripLabel1 = new ToolStripLabel();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.tlb_btn_OK = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.tlb_btnExportXLS = new ToolStripButton();
            this.gridControl1 = new GridControl();
            this.advBandedGridView1 = new AdvBandedGridView();
            this.bandedGridColumn1 = new BandedGridColumn();
            this.bandedGridColumn2 = new BandedGridColumn();
            this.bandedGridColumn3 = new BandedGridColumn();
            this.bandedGridColumn4 = new BandedGridColumn();
            this.bandedGridColumn5 = new BandedGridColumn();
            this.bandedGridColumn6 = new BandedGridColumn();
            this.bandedGridColumn7 = new BandedGridColumn();
            this.bandedGridColumn8 = new BandedGridColumn();
            this.dateTimePicker1 = new DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.gridControl1.BeginInit();
            this.advBandedGridView1.BeginInit();
            base.SuspendLayout();
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripLabel1, this.toolStripSeparator2, this.tlb_btn_OK, this.toolStripSeparator1, this.tlb_btnExportXLS });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(0x28d, 0x19);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new Size(0x48, 0x16);
            this.toolStripLabel1.Text = "统计年月";
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 0x19);
            this.tlb_btn_OK.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.tlb_btn_OK.Image = (Image) resources.GetObject("tlb_btn_OK.Image");
            this.tlb_btn_OK.ImageTransparentColor = Color.Magenta;
            this.tlb_btn_OK.Name = "tlb_btn_OK";
            this.tlb_btn_OK.Size = new Size(0x2c, 0x16);
            this.tlb_btn_OK.Text = "统计";
            this.tlb_btn_OK.Click += new EventHandler(this.tlb_btn_OK_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 0x19);
            this.tlb_btnExportXLS.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tlb_btnExportXLS.Image = (Image) resources.GetObject("tlb_btnExportXLS.Image");
            this.tlb_btnExportXLS.ImageTransparentColor = Color.Magenta;
            this.tlb_btnExportXLS.Name = "tlb_btnExportXLS";
            this.tlb_btnExportXLS.Size = new Size(0x17, 0x16);
            this.tlb_btnExportXLS.Text = "导出电子表";
            this.tlb_btnExportXLS.Click += new EventHandler(this.tlb_btnExportXLS_Click);
            this.gridControl1.Location = new System.Drawing.Point(2, 0x19);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x288, 0xfb);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.advBandedGridView1 });
            this.advBandedGridView1.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn3, this.bandedGridColumn4, this.bandedGridColumn5, this.bandedGridColumn6, this.bandedGridColumn7, this.bandedGridColumn8 });
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridColumn1.Caption = "bandedGridColumn1";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn2.Caption = "bandedGridColumn2";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn3.Caption = "bandedGridColumn3";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn4.Caption = "bandedGridColumn4";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn5.Caption = "bandedGridColumn5";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn6.Caption = "bandedGridColumn6";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn7.Caption = "bandedGridColumn7";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn8.Caption = "bandedGridColumn8";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            this.dateTimePicker1.CustomFormat = "yyyy年MM月";
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(0x209, 0);
            this.dateTimePicker1.MinDate = new DateTime(0x7d9, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new Size(0x6a, 0x17);
            this.dateTimePicker1.TabIndex = 2;
            this.textBox1.Location = new System.Drawing.Point(2, 0x11a);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x288, 0x90);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "注：1.一类项目：公路、铁路、机场、水利水电、电力通信、油气管道等项目。\r\n    \r\n    2.二类项目：勘查采矿项目。\r\n\r\n    3.三类项目：商业、旅游、娱乐等项目。\r\n\r\n    4.四类项目：其他项目。\r\n\r\n    5.上述项目不包含林业局审核审批的项目。\r\n\r\n";
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28d, 0x1ab);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.dateTimePicker1);
            base.Controls.Add(this.gridControl1);
            base.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
         
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormLDZZYMonthReport";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "征占用林地项目审核情况月报表";
            base.Load += new EventHandler(this.FormZZYMonthReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gridControl1.EndInit();
            this.advBandedGridView1.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void InitTable()
        {
            BandedGridView view = this.advBandedGridView1;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand(DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月征占用林地项目统计汇总表");
            GridBand band2 = band.Children.AddBand("单位：公顷、万元");
            GridBand band3 = band2.Children.AddBand("项目类型");
            this.bandedGridColumn1.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("征占用林地情况");
            GridBand band5 = band4.Children.AddBand("项目数");
            this.bandedGridColumn2.OwnerBand = band5;
            GridBand band6 = band4.Children.AddBand("使用林地面积");
            GridBand band7 = band6.Children.AddBand("合计");
            this.bandedGridColumn3.OwnerBand = band7;
            GridBand band8 = band6.Children.AddBand("长期用地");
            this.bandedGridColumn4.OwnerBand = band8;
            GridBand band9 = band6.Children.AddBand("临时用地");
            this.bandedGridColumn5.OwnerBand = band9;
            GridBand band10 = band4.Children.AddBand("森林植被恢复费");
            GridBand band11 = band10.Children.AddBand("合计");
            this.bandedGridColumn6.OwnerBand = band11;
            GridBand band12 = band10.Children.AddBand("长期用地");
            this.bandedGridColumn7.OwnerBand = band12;
            GridBand band13 = band10.Children.AddBand("临时用地");
            this.bandedGridColumn8.OwnerBand = band13;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new System.Drawing.Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        /// <summary>
        /// 元数据报表
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable METATABLE()
        {
            System.Data.DataTable table = new System.Data.DataTable("xmmeta");
            table.Columns.Add("xmmc");
            table.Columns.Add("xmdm");
            DataRow row = table.NewRow();
            row[0] = "一类项目";
            row[1] = "1";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "二类项目";
            row[1] = "2";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "三类项目";
            row[1] = "3";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "四类项目";
            row[1] = "4";
            table.Rows.Add(row);
            return table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 统计报表
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable TJTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("YBB");
            table.Columns.Add("XMLX", typeof(string));
            table.Columns.Add("XMCount", typeof(int));
            table.Columns.Add("SYLDMJHJ", typeof(double));
            table.Columns.Add("CQYDMJ", typeof(double));
            table.Columns.Add("LSYDMJ", typeof(double));
            table.Columns.Add("ZBHFFHJ", typeof(double));
            table.Columns.Add("CQYDZBF", typeof(double));
            table.Columns.Add("LSYDZBF", typeof(double));
            return table;
        }

        /// <summary>
        /// 按月份统计征占用报表
        /// </summary>
        /// <param name="TABLE_XBTableName"></param>
        /// <param name="shsj"></param>
        /// <returns></returns>
        private System.Data.DataTable TJZZYMonthReport(string TABLE_XBTableName, string shsj)
        {
            System.Data.DataTable table = this.TJTable();
            System.Data.DataTable table2 = this.METATABLE();
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable("mytjdt");
                string cmdtxt = ("SELECT  LTRIM(RTRIM(XIAN)) AS XIAN ,LTRIM(RTRIM(XMMC)) AS XMMC,LTRIM(RTRIM(LDYT)) AS LDYT,LTRIM(RTRIM(YDZL)) AS YDZL,MIAN_JI,ZBHFF FROM " + TABLE_XBTableName) + " WHERE (LTRIM(RTRIM(SPJB))>'1') AND LEN(LTRIM(RTRIM(XMMC)))>0 AND LEN(LTRIM(RTRIM(LDYT)))>0 AND SUBSTRING(LTRIM(RTRIM(SHSJ)),1,7)='" + shsj + "'";
                dt = this.pcomonclass.GetTableInDB(cmdtxt, TABLE_XBTableName);
                if (dt == null)
                {
                    MessageBox.Show(" 读取数据库出错！", "征占用月报统计", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                int count = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    this.xiancode = dt.Rows[0]["XIAN"].ToString();
                }
                dt.Columns.Add("PTYPE", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    string str2 = row["LDYT"].ToString().Trim();
                    if ((str2.Length == 2) && (str2.IndexOf("1") > -1))
                    {
                        row["PTYPE"] = "1";
                    }
                    else if ((str2.Length == 2) && (str2 == "40"))
                    {
                        row["PTYPE"] = "2";
                    }
                    else if ((str2.Length == 2) && (str2.IndexOf("5") > -1))
                    {
                        row["PTYPE"] = "3";
                    }
                    else
                    {
                        row["PTYPE"] = "4";
                    }
                }
                int num = 0;
                double num2 = 0.0;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                string expression = "SUM(MIAN_JI)";
                string str4 = "SUM(ZBHFF)";
                string filterExpression = "YDZL='2'";
                string str6 = "YDZL='1'";
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    DataRow row2 = table.NewRow();
                    for (int m = 1; m < table.Columns.Count; m++)
                    {
                        row2[m] = 0;
                    }
                    string str7 = table2.Rows[i][0].ToString();
                    string str8 = table2.Rows[i][1].ToString();
                    row2[0] = str7;
                    System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "PTYPE='" + str8.ToString() + "'");
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        System.Data.DataTable table5 = dataTabeBySelRows.DefaultView.ToTable(true, new string[] { "xmmc" });
                        if (dataTabeBySelRows.Select(filterExpression).Length > 0)
                        {
                            num3 = Convert.ToDouble(dataTabeBySelRows.Compute(expression, filterExpression));
                            num6 = Convert.ToDouble(dataTabeBySelRows.Compute(str4, filterExpression)) / 10000.0;
                        }
                        if (dataTabeBySelRows.Select(str6).Length > 0)
                        {
                            num4 = Convert.ToDouble(dataTabeBySelRows.Compute(expression, str6));
                            num7 = Convert.ToDouble(dataTabeBySelRows.Compute(str4, str6)) / 10000.0;
                        }
                        num = table5.Rows.Count;
                        num2 = num3 + num4;
                        num5 = num6 + num7;
                        row2[1] = num;
                        row2[2] = num2;
                        row2[3] = num3;
                        row2[4] = num4;
                        row2[5] = num5;
                        row2[6] = num6;
                        row2[7] = num7;
                    }
                    table.Rows.Add(row2);
                }
                DataRow row3 = table.NewRow();
                row3[0] = "总计";
                for (int j = 1; j < table.Columns.Count; j++)
                {
                    row3[j] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[j] + ")", null).ToString());
                }
                table.Rows.InsertAt(row3, 0);
                for (int k = 1; k < table.Columns.Count; k++)
                {
                    foreach (DataRow row4 in table.Rows)
                    {
                        object obj3 = row4[k];
                        if (Convert.ToDouble(obj3) == 0.0)
                        {
                            row4[k] = DBNull.Value;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("征占用月报表统计出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table;
        }

        private void tlb_btn_OK_Click(object sender, EventArgs e)
        {
            this.advBandedGridView1.Bands[0].Caption = this.dateTimePicker1.Value.Year.ToString() + "年" + this.dateTimePicker1.Value.Month.ToString() + "月征占用林地项目统计汇总表";
            this.gridControl1.DataSource = null;
            string shsj = this.dateTimePicker1.Value.ToString("yyyy-MM");
            this.pTJTABLE = this.TJZZYMonthReport(this._TableName, shsj);
            System.Data.DataTable tableInDB = this.pcomonclass.GetTableInDB("SELECT CNAME FROM T_SYS_META_CODE WHERE CCODE='" + this.xiancode + "' AND CINDEX='103'", "xian");
            if ((tableInDB != null) && (tableInDB.Rows.Count != 0))
            {
                this.xiancode = tableInDB.Rows[0][0].ToString() + "林业局";
            }
            this.gridControl1.DataSource = this.pTJTABLE;
            for (int i = 0; i < this.pTJTABLE.Columns.Count; i++)
            {
                this.advBandedGridView1.Columns[i].FieldName = this.pTJTABLE.Columns[i].ColumnName;
            }
            this.advBandedGridView1.OptionsBehavior.Editable = false;
            MessageBox.Show("统计完成，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void tlb_btnExportXLS_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel文件|*.xls";
            dialog.FileName = "占用林地月报表" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(System.Windows.Forms.Application.StartupPath + @"\占用林地月报表.xls", dialog.FileName, true);
                    int count = this.pTJTABLE.Rows.Count;
                    int num2 = this.pTJTABLE.Columns.Count;
                    object[,] objArray = new object[count, num2];
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < num2; j++)
                        {
                            objArray[i, j] = this.pTJTABLE.Rows[i][j];
                        }
                    }
                    Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                    object updateLinks = Missing.Value;
                    Workbook workbook = application.Workbooks.Open(dialog.FileName, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                    Worksheet worksheet = workbook.Sheets[1] as Worksheet;
                    int num1 = worksheet.UsedRange.Rows.Count;
                    worksheet.get_Range("A1", "A1").Value2 = this.advBandedGridView1.Bands[0].Caption;
                    if (this.xiancode.Length > 0)
                    {
                        worksheet.get_Range("A3", "A3").Value2 = "填报单位：" + this.xiancode;
                    }
                    worksheet.get_Range("F3", "F3").Value2 = DateTime.Now.ToString("yyyy年MM月dd日");
                    worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[11, 9]).ClearContents();
                    worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[11, 8]).Value2 = objArray;
                    workbook.Save();
                    application.Visible = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("导出Excel出错，错误：" + exception.Message, "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    new Process();
                    Process[] processesByName = Process.GetProcessesByName("Excel");
                    try
                    {
                        foreach (Process process in processesByName)
                        {
                            IntPtr mainWindowHandle = process.MainWindowHandle;
                            if (string.IsNullOrEmpty(process.MainWindowTitle))
                            {
                                process.Kill();
                            }
                        }
                    }
                    catch
                    {
                    }
                    GC.Collect();
                }
            }
        }
    }
}

