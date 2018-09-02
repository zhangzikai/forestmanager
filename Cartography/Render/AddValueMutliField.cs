namespace Cartography.Render
{
    using DevExpress.Data;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class AddValueMutliField : FormBase3
    {
        private Dictionary<string, string> _codeValues = new Dictionary<string, string>();
        private IField[] _field;
        private IUniqueValueRenderer _render;
        private ITable _table;
        private SimpleButton btAdd;
        private SimpleButton btCancel;
        private IContainer components;
        private GridControl gcValue;
        private GridView gridView1;
        private const string mClassName = "Cartography.Element.AddValueMutliField";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public AddValueMutliField(IField[] pField, ITable pTable, IUniqueValueRenderer pRender)
        {
            this.InitializeComponent();
            this._field = pField;
            this._table = pTable;
            this._render = pRender;
            this.Init();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._codeValues.Clear();
            int[] selectedRows = this.gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                CVRecord row = this.gridView1.GetRow(selectedRows[i]) as CVRecord;
                this._codeValues.Add(row.Code, row.Value);
            }
        }

        private void Init()
        {
            try
            {
                IFieldEdit edit = this._field[0] as IFieldEdit;
                IFieldEdit edit1 = this._field[1] as IFieldEdit;
                IFieldEdit edit2 = this._field[2] as IFieldEdit;
                ICodedValueDomain domain = edit.Domain as ICodedValueDomain;
                ArrayList list = new ArrayList();
                List<string> list2 = new List<string>();
                for (int i = 0; i < this._render.ValueCount; i++)
                {
                    list2.Add(this._render.get_Value(i));
                }
                GridColumn column = new GridColumn();
                column.Name = "gcCode";
                column.Caption = "代码";
                column.FieldName = "Code";
                column.UnboundType = UnboundColumnType.String;
                column.OptionsColumn.AllowEdit = false;
                column.VisibleIndex = 0;
                this.gridView1.Columns.Add(column);
                column = new GridColumn();
                column.Name = "gcValue";
                column.Caption = "值";
                column.FieldName = "Value";
                column.UnboundType = UnboundColumnType.String;
                column.OptionsColumn.AllowEdit = false;
                column.VisibleIndex = 1;
                this.gridView1.Columns.Add(column);

                int firstCodeCount = 1;
                int secondCodeCount = 1;
                int thirdCodeCount = 1;
                int count = 0;
                int count1 = 0;
                string pLabel = "";
                foreach (IField t in _field)
                {
                    if (t == null)
                    {
                        count++;
                        continue;
                    }
                    pLabel += t.AliasName;
                    this._render.set_Field(count1, t.Name);
                    if (count == 0)
                        firstCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    if (count == 1)
                        secondCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    if (count == 2)
                        thirdCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    count++;
                    count1++;
                }
                string pLable3;
                string pvalue3;
                for (int i = 0; i < firstCodeCount; i++)
                {
                    string pLabel1 = "";
                    string pvalue1 = "";
                    if (_field[0] != null)
                    {
                        pLabel1 += (_field[0].Domain as ICodedValueDomain).get_Name(i);
                        pvalue1 += (_field[0].Domain as ICodedValueDomain).get_Value(i).ToString();
                        if (_field[1] != null || _field[2] != null)
                        {
                            pLabel1 += ",";
                            pvalue1 += this._render.FieldDelimiter;
                        }
                    }
                    for (int m = 0; m < secondCodeCount; m++)
                    {
                        string pLable2 = "";
                        string pvalue2 = "";
                        if (_field[1] != null)
                        {
                            pLable2 = pLabel1 + (_field[1].Domain as ICodedValueDomain).get_Name(m);
                            pvalue2 = pvalue1 + (_field[1].Domain as ICodedValueDomain).get_Value(m).ToString();
                            if (_field[2] != null)
                            {
                                pLable2 += ",";
                                pvalue2 += this._render.FieldDelimiter;
                            }

                        }
                        else
                        {
                            pLable2 = pLabel1;
                            pvalue2 = pvalue1;
                        }
                        for (int n = 0; n < thirdCodeCount; n++)
                        {
                            pLable3 = "";
                            pvalue3 = "";
                            if (_field[2] != null)
                            {
                                pLable3 = pLable2 + (_field[2].Domain as ICodedValueDomain).get_Name(n);
                                pvalue3 = pvalue2 + (_field[2].Domain as ICodedValueDomain).get_Value(n).ToString();

                            }
                            else
                            {
                                pLable3 = pLable2;
                                pvalue3 = pvalue2;
                            }
                            if (!list2.Contains(pvalue3))
                            {
                                list.Add(new CVRecord(pvalue3, pLable3));
                            }
                        }
                    }

                }
                this.gcValue.BeginInit();
                this.gcValue.DataSource = list;
                this.gcValue.EndInit();
                if (list.Count == 0)
                {
                    this.btAdd.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.AddValueMutliField", "Init", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.btAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gcValue = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(97, 311);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(87, 27);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "添加";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(192, 311);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // gcValue
            // 
            this.gcValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcValue.Location = new System.Drawing.Point(0, 0);
            this.gcValue.MainView = this.gridView1;
            this.gcValue.Name = "gcValue";
            this.gcValue.Size = new System.Drawing.Size(377, 304);
            this.gcValue.TabIndex = 3;
            this.gcValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcValue;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // AddValueMutliField
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(377, 352);
            this.Controls.Add(this.gcValue);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddValueMutliField";
            this.Text = "添加值";
            ((System.ComponentModel.ISupportInitialize)(this.gcValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        public Dictionary<string, string> CodeValues
        {
            get
            {
                return this._codeValues;
            }
        }
    }
}

