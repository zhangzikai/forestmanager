namespace MyGridControl
{
    using AttributesEdit;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class UserControlTableWrite : UserControl
    {
        private SimpleButton btnAdd;
        private SimpleButton btnCopy;
        private SimpleButton btnDelete;
        private SimpleButton btnExport;
        private SimpleButton btnImport;
        private SimpleButton btnSave;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private string m_ExcelParentPath = @"C:\";
        private IFields m_Fields;
        private HorXtraGrid m_Grid;
        private string[] m_KeyFieldList;
        private string[] m_KeyValueList;
        private string m_TreeCode = "";
        private Panel panel1;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;

        public event SubmitJCTablehandler OnSubmitJCTable;

        public UserControlTableWrite()
        {
            this.InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = this.m_Grid.CreateRow();
                for (int i = 0; i < this.m_KeyFieldList.Length; i++)
                {
                    string name = this.m_KeyFieldList[i];
                    string str2 = this.m_KeyValueList[i];
                    int index = this.m_Fields.FindField(name);
                    if (index >= 0)
                    {
                        IField field = this.m_Fields.get_Field(index);
                        string str3 = str2;
                        if ((field.Domain != null) && (field.Domain is ICodedValueDomain))
                        {
                            ICodedValueDomain domain = field.Domain as ICodedValueDomain;
                            for (int j = 0; j < domain.CodeCount; j++)
                            {
                                if (str2 == domain.get_Value(j).ToString())
                                {
                                    str3 = domain.get_Name(j);
                                    break;
                                }
                            }
                        }
                        row[name] = str3;
                    }
                }
                if (this.m_Fields.FindField("JCLX") > 0)
                {
                    row["JCLX"] = "采伐";
                }
                if (this.m_TreeCode != "")
                {
                    string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "JCSZField");
                    string treeCode = this.m_TreeCode;
                    int num5 = this.m_Fields.FindField(str4);
                    if (num5 > 0)
                    {
                        IField field2 = this.m_Fields.get_Field(num5);
                        string str6 = treeCode;
                        if ((field2.Domain != null) && (field2.Domain is ICodedValueDomain))
                        {
                            ICodedValueDomain domain2 = field2.Domain as ICodedValueDomain;
                            for (int k = 0; k < domain2.CodeCount; k++)
                            {
                                if (treeCode == domain2.get_Value(k).ToString())
                                {
                                    str6 = domain2.get_Name(k);
                                    break;
                                }
                            }
                        }
                        row[str4] = str6;
                    }
                }
                this.m_Grid.RefreshDataSource();
                this.gridView1.MoveLast();
                this.gridView1.FocusedColumn = this.gridView1.Columns[0];
            }
            catch
            {
                MessageBox.Show("添加出错!");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            DataTable dataSource = this.m_Grid.DataSource;
            int count = dataSource.Rows.Count;
            if (count < 2)
            {
                MessageBox.Show("只有两条或超过两条记录，才可复制！", "提示");
            }
            else
            {
                DataRow row = dataSource.Rows[count - 1];
                DataRow row2 = dataSource.Rows[count - 2];
                for (int i = 0; i < dataSource.Columns.Count; i++)
                {
                    row[i] = row2[i];
                }
                this.m_Grid.DataSource = dataSource;
                this.m_Grid.RefreshDataSource();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.m_Grid.DeleteSelectedRows();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Excel文件(*.xlsx,*.xls)|*.xlsx;*.xls",
                FilterIndex = 1,
                Title = "选择Excel文件",
                InitialDirectory = this.m_ExcelParentPath,
                RestoreDirectory = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = dialog.FileName;
                    this.m_ExcelParentPath = fileName.Substring(0, fileName.LastIndexOf(@"\"));
                    OleDbConnection excelConnection = this.GetExcelConnection(fileName);
                    if (excelConnection == null)
                    {
                        MessageBox.Show("格式不支持，请检查Excel文件！", "提示");
                    }
                    else
                    {
                        excelConnection.Open();
                        if (excelConnection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("读取Excel文件出错！", "提示");
                        }
                        else
                        {
                            DataTable oleDbSchemaTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            excelConnection.Close();
                            if (oleDbSchemaTable.Rows.Count < 1)
                            {
                                MessageBox.Show("Excel文件中不包含工作表，请重新选择文件。", "提示");
                            }
                            else
                            {
                                IList<string> source = new List<string>();
                                foreach (DataRow row in oleDbSchemaTable.Rows)
                                {
                                    string item = row["TABLE_NAME"].ToString();
                                    if (item.Contains("$"))
                                    {
                                        source.Add(item);
                                    }
                                }
                                FormExcel excel = new FormExcel {
                                    Sheets = source.ToArray<string>()
                                };
                                if (DialogResult.OK == excel.ShowDialog())
                                {
                                    this.ImportData(fileName, excel.SelectedSheets);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("导入出错：" + exception.Message, "提示");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dataSource = this.m_Grid.DataSource;
            this.OnSubmitJCTable(dataSource);
            this.gridView1.FocusedColumn = this.gridView1.Columns[0];
        }

        public void Clear()
        {
            if (this.m_Grid != null)
            {
                this.m_Grid.ClearData();
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

        private OleDbConnection GetExcelConnection(string sFilePath)
        {
            try
            {
                string str;
                if (sFilePath.EndsWith("xlsx"))
                {
                    str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                else if (sFilePath.EndsWith("xls"))
                {
                    str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                else
                {
                    return null;
                }
                return new OleDbConnection(str);
            }
            catch
            {
                return null;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if ((e.RowHandle < 0) && (e.RowHandle > -1000))
                {
                    e.Info.Appearance.BackColor = Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void ImportData(string sFilePath, string[] pSelecteds)
        {
            if (pSelecteds.Length >= 1)
            {
                try
                {
                    OleDbConnection excelConnection = this.GetExcelConnection(sFilePath);
                    if (excelConnection == null)
                    {
                        MessageBox.Show("格式不支持，请检查Excel文件！", "提示");
                    }
                    else
                    {
                        excelConnection.Open();
                        if (excelConnection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("读取Excel文件出错！", "提示");
                        }
                        else
                        {
                            DataSet dataSet = new DataSet();
                            for (int i = 0; i < pSelecteds.Length; i++)
                            {
                                string srcTable = pSelecteds[i];
                                new OleDbDataAdapter("SELECT * FROM [" + srcTable + "]", excelConnection).Fill(dataSet, srcTable);
                            }
                            excelConnection.Close();
                            for (int j = 0; j < dataSet.Tables.Count; j++)
                            {
                                DataTable table = dataSet.Tables[j];
                                for (int k = 0; k < table.Rows.Count; k++)
                                {
                                    DataRow row = this.m_Grid.CreateRow();
                                    for (int m = 0; m < this.m_KeyFieldList.Length; m++)
                                    {
                                        string name = this.m_KeyFieldList[m];
                                        string str4 = this.m_KeyValueList[m];
                                        IField field = this.m_Fields.get_Field(this.m_Fields.FindField(name));
                                        string str5 = str4;
                                        if ((field.Domain != null) && (field.Domain is ICodedValueDomain))
                                        {
                                            ICodedValueDomain domain = field.Domain as ICodedValueDomain;
                                            for (int num5 = 0; num5 < domain.CodeCount; num5++)
                                            {
                                                if (str4 == domain.get_Value(num5).ToString())
                                                {
                                                    str5 = domain.get_Name(num5);
                                                    break;
                                                }
                                            }
                                        }
                                        row[name] = str5;
                                    }
                                    for (int n = 0; n < table.Columns.Count; n++)
                                    {
                                        row[table.Columns[n].ColumnName] = table.Rows[k][n];
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("导入出错：" + exception.Message, "提示");
                }
            }
        }

        public void Init(string[] pJcFieldList, IFields pFields, IList pRowList, string[] pKeyFieldList, string[] pKeyValueList, string sTreeCode)
        {
            try
            {
                this.m_TreeCode = sTreeCode;
                this.m_Fields = pFields;
                this.m_KeyFieldList = pKeyFieldList;
                this.m_KeyValueList = pKeyValueList;
                if (this.m_Grid == null)
                {
                    this.m_Grid = new HorXtraGrid(this.gridControl1);
                }
                if (this.m_Grid.DataSource.Columns.Count > 0)
                {
                    this.ShowRows(pJcFieldList, pRowList);
                }
                else
                {
                    this.m_Grid.Clear();
                    int visibleIndex = -1;
                    for (int i = 0; i < pJcFieldList.Length; i++)
                    {
                        string name = pJcFieldList[i];
                        int index = pFields.FindField(name);
                        IField pField = pFields.get_Field(index);
                        string aliasName = pField.AliasName;
                        IDomain domain = null;
                        ICodedValueDomain domain2 = null;
                        IList nameList = new ArrayList();
                        IList valueList = new ArrayList();
                        if ((pField.Type != esriFieldType.esriFieldTypeOID) && (pField.Type != esriFieldType.esriFieldTypeBlob))
                        {
                            if (this.m_KeyFieldList.Contains<string>(name))
                            {
                                visibleIndex++;
                                this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, true, 0, 70);
                            }
                            else
                            {
                                visibleIndex++;
                                domain = pField.Domain;
                                if (domain != null)
                                {
                                    if (domain is ICodedValueDomain)
                                    {
                                        domain2 = domain as ICodedValueDomain;
                                        for (int j = 0; j < domain2.CodeCount; j++)
                                        {
                                            nameList.Add(domain2.get_Name(j));
                                            valueList.Add(domain2.get_Value(j));
                                        }
                                        string[] readonlyItems = AttriEdit.GetReadonlyItems(pField);
                                        this.m_Grid.AddComboBoxColumn(name, aliasName, nameList, valueList, visibleIndex, !pField.Editable, 70, readonlyItems);
                                    }
                                    else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                                    {
                                        double minValue = 0.0;
                                        double maxValue = 0.0;
                                        if (domain is IRangeDomain)
                                        {
                                            minValue = (double) (domain as IRangeDomain).MinValue;
                                            maxValue = (double) (domain as IRangeDomain).MaxValue;
                                        }
                                        this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, minValue, maxValue, !pField.Editable, true, pField.Scale, 70);
                                    }
                                    else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                                    {
                                        double num7 = 0.0;
                                        double num8 = 0.0;
                                        if (domain is IRangeDomain)
                                        {
                                            num7 = (double) (domain as IRangeDomain).MinValue;
                                            num8 = (double) (domain as IRangeDomain).MaxValue;
                                        }
                                        this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, num7, num8, !pField.Editable, false, 0, 70);
                                    }
                                    else if (pField.Type == esriFieldType.esriFieldTypeDate)
                                    {
                                        this.m_Grid.AddDateColumn(name, aliasName, visibleIndex, !pField.Editable, 70);
                                    }
                                    else
                                    {
                                        this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, !pField.Editable, pField.Length, 70);
                                    }
                                }
                                else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                                {
                                    double num9 = 5000.0;
                                    this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, 0.0, num9, !pField.Editable, true, pField.Scale, 70);
                                }
                                else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                                {
                                    double num10 = 5000.0;
                                    this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, 0.0, num10, !pField.Editable, false, 0, 70);
                                }
                                else if (pField.Type == esriFieldType.esriFieldTypeDate)
                                {
                                    this.m_Grid.AddDateColumn(name, aliasName, visibleIndex, !pField.Editable, 70);
                                }
                                else
                                {
                                    this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, !pField.Editable, pField.Length, 70);
                                }
                            }
                        }
                    }
                    this.ShowRows(pJcFieldList, pRowList);
                }
            }
            catch
            {
            }
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new PanelControl();
            this.btnDelete = new SimpleButton();
            this.btnAdd = new SimpleButton();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.panelControl3 = new PanelControl();
            this.btnImport = new SimpleButton();
            this.panel1 = new Panel();
            this.btnExport = new SimpleButton();
            this.btnCopy = new SimpleButton();
            this.btnSave = new SimpleButton();
            this.panelControl2 = new PanelControl();
            this.panelControl1.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.panelControl1.Appearance.BackColor = Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new Padding(10, 5, 10, 5);
            this.panelControl1.Size = new Size(0x1d8, 0x166);
            this.panelControl1.TabIndex = 0;
            this.btnDelete.Location = new Point(0x53, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x34, 0x17);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnAdd.Location = new Point(13, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(0x34, 0x17);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x1d8, 0x13e);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.panelControl3.Appearance.BackColor = Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnImport);
            this.panelControl3.Controls.Add(this.panel1);
            this.panelControl3.Controls.Add(this.btnExport);
            this.panelControl3.Controls.Add(this.btnCopy);
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Dock = DockStyle.Bottom;
            this.panelControl3.Location = new Point(0, 0x13e);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new Padding(10, 9, 30, 8);
            this.panelControl3.Size = new Size(0x1d8, 40);
            this.panelControl3.TabIndex = 3;
            this.btnImport.Dock = DockStyle.Right;
            this.btnImport.Location = new Point(0x138, 9);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new Size(0x34, 0x17);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new EventHandler(this.btnImport_Click);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new Point(0x16c, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1a, 0x17);
            this.panel1.TabIndex = 5;
            this.btnExport.Dock = DockStyle.Right;
            this.btnExport.Location = new Point(390, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(0x34, 0x17);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.Visible = false;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            this.btnCopy.Location = new Point(0x99, 9);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new Size(0x34, 0x17);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "复制";
            this.btnCopy.Click += new EventHandler(this.btnCopy_Click);
            this.btnSave.Location = new Point(0xdf, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x34, 0x17);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "提交";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.panelControl2.Appearance.BackColor = Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x1d8, 0x13e);
            this.panelControl2.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl3);
            base.Controls.Add(this.panelControl1);
            base.Name = "UserControlTableWrite";
            base.Size = new Size(0x1d8, 0x166);
            this.panelControl1.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void ShowRows(string[] pJcFieldList, IList pRowList)
        {
            DataTable dataSource = this.m_Grid.DataSource;
            for (int i = 0; i < pRowList.Count; i++)
            {
                IRow row = pRowList[i] as IRow;
                DataRow row2 = dataSource.NewRow();
                int num2 = -1;
                for (int j = 0; j < pJcFieldList.Length; j++)
                {
                    int index = row.Fields.FindField(pJcFieldList[j]);
                    IField field = row.Fields.get_Field(index);
                    object obj2 = row.get_Value(index);
                    if ((field.Type != esriFieldType.esriFieldTypeOID) && (field.Type != esriFieldType.esriFieldTypeBlob))
                    {
                        num2++;
                        if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                        {
                            string str = "";
                            ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                            string str2 = obj2.ToString();
                            for (int k = 0; k < domain.CodeCount; k++)
                            {
                                if (str2 == domain.get_Value(k).ToString())
                                {
                                    str = domain.get_Name(k);
                                    break;
                                }
                            }
                            row2[num2] = str;
                            continue;
                        }
                        if (((field.Type == esriFieldType.esriFieldTypeSmallInteger) || (field.Type == esriFieldType.esriFieldTypeSingle)) || ((field.Type == esriFieldType.esriFieldTypeDouble) || (field.Type == esriFieldType.esriFieldTypeInteger)))
                        {
                            row2[num2] = obj2;
                        }
                        else
                        {
                            row2[num2] = obj2.ToString();
                        }
                    }
                }
                dataSource.Rows.Add(row2);
            }
            this.m_Grid.RefreshDataSource();
        }

        public DataTable Data
        {
            get
            {
                if (this.m_Grid == null)
                {
                    return null;
                }
                return this.m_Grid.DataSource;
            }
        }

        public delegate void SubmitJCTablehandler(DataTable pDataTable);
    }
}

