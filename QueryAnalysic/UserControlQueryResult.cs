namespace QueryAnalysic
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class UserControlQueryResult : UserControlBase1
    {
        private CheckedListBoxControl checkedListBoxControl1;
        private ComboBoxEdit comboBoxEditField;
        private ComboBoxEdit comboBoxEditValue;
        private IContainer components;
        private GridColumn gridColumn3;
        public GridControl gridControl1;
        public GridView gridView1;
        private Label label2;
        private Label label3;
        private Label labeltitle;
        private const string mClassName = "QueryAnalysic.UserControlQueryResult";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IHookHelper mHookHelper;
        private IFeatureLayer mQueryLayer;
        private DataTable mQueryTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private int objectid = -1;
        private Panel panel10;
        private Panel panel2;
        private Panel panel3;
        private Panel panel9;
        private PanelControl panelControl4;
        internal PopupContainerControl PopupContainer;
        internal PopupContainerEdit PopupContainerEdit1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private SimpleButton simpleButtonFind;
        private SimpleButton simpleButtonReset;

        public UserControlQueryResult()
        {
            this.InitializeComponent();
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (e.State == CheckState.Checked)
            {
                this.gridView1.Columns[e.Index].Visible = true;
            }
            else
            {
                this.gridView1.Columns[e.Index].Visible = false;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Enumerable.Count<int>(this.gridView1.GetSelectedRows()) != 0)
                {
                    int rowHandle = this.gridView1.GetSelectedRows()[0];
                    IFeature feature = this.gridView1.GetDataRow(rowHandle)[this.objectid] as IFeature;
                    this.mHookHelper.FocusMap.ClearSelection();
                    this.mHookHelper.FocusMap.SelectFeature(this.mQueryLayer, feature);
                    IEnvelope envelope = feature.Shape.Envelope;
                    if (envelope.Width == 0.0)
                    {
                        envelope.XMin -= 100.0;
                        envelope.XMax += 100.0;
                    }
                    if (envelope.Height == 0.0)
                    {
                        envelope.YMin -= 100.0;
                        envelope.YMax += 100.0;
                    }
                    envelope.Expand(1.2, 1.2, true);
                    this.mHookHelper.ActiveView.FullExtent = envelope;
                    this.mHookHelper.ActiveView.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Enumerable.Count<int>(this.gridView1.GetSelectedRows()) != 0)
                {
                    int rowHandle = this.gridView1.GetSelectedRows()[0];
                    IFeature feature = this.gridView1.GetDataRow(rowHandle)[this.objectid] as IFeature;
                    this.mHookHelper.FocusMap.ClearSelection();
                    this.mHookHelper.FocusMap.SelectFeature(this.mQueryLayer, feature);
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, this.mQueryLayer, null);
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, this.mQueryLayer, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxEditValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEditField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.PopupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.PopupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labeltitle = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).BeginInit();
            this.PopupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelControl4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.PopupContainerEdit1);
            this.panel2.Controls.Add(this.labeltitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel2.Size = new System.Drawing.Size(833, 28);
            this.panel2.TabIndex = 95;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.simpleButtonReset);
            this.panelControl4.Controls.Add(this.simpleButtonFind);
            this.panelControl4.Controls.Add(this.panel10);
            this.panelControl4.Controls.Add(this.comboBoxEditValue);
            this.panelControl4.Controls.Add(this.label3);
            this.panelControl4.Controls.Add(this.comboBoxEditField);
            this.panelControl4.Controls.Add(this.label2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(119, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl4.Size = new System.Drawing.Size(463, 24);
            this.panelControl4.TabIndex = 93;
            this.panelControl4.Visible = false;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonReset.ImageIndex = 81;
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonReset.Location = new System.Drawing.Point(423, 4);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(26, 18);
            this.simpleButtonReset.TabIndex = 97;
            this.simpleButtonReset.ToolTip = "重置";
            // 
            // simpleButtonFind
            // 
            this.simpleButtonFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonFind.ImageIndex = 16;
            this.simpleButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonFind.Location = new System.Drawing.Point(397, 4);
            this.simpleButtonFind.Name = "simpleButtonFind";
            this.simpleButtonFind.Size = new System.Drawing.Size(26, 18);
            this.simpleButtonFind.TabIndex = 90;
            this.simpleButtonFind.ToolTip = "查找";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(388, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(9, 18);
            this.panel10.TabIndex = 96;
            // 
            // comboBoxEditValue
            // 
            this.comboBoxEditValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxEditValue.Location = new System.Drawing.Point(248, 4);
            this.comboBoxEditValue.Name = "comboBoxEditValue";
            this.comboBoxEditValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditValue.Size = new System.Drawing.Size(140, 20);
            this.comboBoxEditValue.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(224, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 18);
            this.label3.TabIndex = 92;
            this.label3.Text = "值";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxEditField
            // 
            this.comboBoxEditField.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxEditField.Location = new System.Drawing.Point(84, 4);
            this.comboBoxEditField.Name = "comboBoxEditField";
            this.comboBoxEditField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditField.Size = new System.Drawing.Size(140, 20);
            this.comboBoxEditField.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 89;
            this.label2.Text = "查找:  字段";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(110, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(9, 24);
            this.panel3.TabIndex = 99;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(688, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(28, 24);
            this.panel9.TabIndex = 95;
            // 
            // PopupContainerEdit1
            // 
            this.PopupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Right;
            this.PopupContainerEdit1.EditValue = "显示字段";
            this.PopupContainerEdit1.Location = new System.Drawing.Point(716, 2);
            this.PopupContainerEdit1.Name = "PopupContainerEdit1";
            this.PopupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PopupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.PopupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.PopupContainerEdit1.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.PopupContainerEdit1.Properties.PopupControl = this.PopupContainer;
            this.PopupContainerEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.PopupContainerEdit1.Properties.ShowPopupShadow = false;
            this.PopupContainerEdit1.Size = new System.Drawing.Size(117, 20);
            this.PopupContainerEdit1.TabIndex = 91;
            // 
            // PopupContainer
            // 
            this.PopupContainer.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PopupContainer.Appearance.Options.UseBackColor = true;
            this.PopupContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PopupContainer.Controls.Add(this.checkedListBoxControl1);
            this.PopupContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PopupContainer.Location = new System.Drawing.Point(489, 59);
            this.PopupContainer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.PopupContainer.Name = "PopupContainer";
            this.PopupContainer.Padding = new System.Windows.Forms.Padding(1);
            this.PopupContainer.Size = new System.Drawing.Size(163, 166);
            this.PopupContainer.TabIndex = 96;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(157, 160);
            this.checkedListBoxControl1.TabIndex = 0;
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            // 
            // labeltitle
            // 
            this.labeltitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labeltitle.Location = new System.Drawing.Point(0, 2);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(110, 24);
            this.labeltitle.TabIndex = 94;
            this.labeltitle.Text = "班块信息列表:";
            this.labeltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.gridControl1.Size = new System.Drawing.Size(833, 217);
            this.gridControl1.TabIndex = 97;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "名称";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // UserControlQueryResult
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.PopupContainer);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Name = "UserControlQueryResult";
            this.Size = new System.Drawing.Size(833, 245);
            this.Load += new System.EventHandler(this.UserControlQueryResult_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).EndInit();
            this.PopupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialQueryInfo(IHookHelper pHookHelper, IFeatureLayer pQueryLayer, ArrayList pQueryList, ITable pTable, string sDesKeyField)
        {
            try
            {
                IFields fields = null;
                IRow row = null;
                this.mHookHelper = pHookHelper;
                this.mQueryLayer = pQueryLayer;
                IFeatureClass featureClass = pQueryLayer.FeatureClass;
                if (pTable == null)
                {
                    IObjectClass class3 = featureClass;
                    if (class3 == null)
                    {
                        return;
                    }
                    IEnumRelationshipClass class4 = class3.get_RelationshipClasses(esriRelRole.esriRelRoleOrigin);
                    class4.Reset();
                    IRelationshipClass class5 = class4.Next();
                    if (class5 != null)
                    {
                        pTable = class5.DestinationClass as ITable;
                        IDataset dataset = pTable as IDataset;
                        if (dataset.Name != EditTask.TableName)
                        {
                            class5 = class4.Next();
                            pTable = class5.DestinationClass as ITable;
                            if ((pTable as IDataset).Name != EditTask.TableName)
                            {
                                class5 = null;
                                return;
                            }
                        }
                        sDesKeyField = class5.OriginForeignKey;
                        fields = pTable.Fields;
                    }
                    else
                    {
                        fields = pQueryLayer.FeatureClass.Fields;
                    }
                }
                else
                {
                    if (sDesKeyField == "")
                    {
                        sDesKeyField = "UUID";
                    }
                    fields = pTable.Fields;
                }
                this.mQueryTable = new DataTable();
                this.checkedListBoxControl1.Items.Clear();
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if ((((featureClass.LengthField == null) || (featureClass.LengthField.Name != field.Name)) && ((featureClass.AreaField == null) || (featureClass.AreaField.Name != field.Name))) && (((field.Name != sDesKeyField) && (field.Type != esriFieldType.esriFieldTypeOID)) && (field.Type != esriFieldType.esriFieldTypeGeometry)))
                    {
                        DataColumn column = new DataColumn(fields.get_Field(i).Name, typeof(string));
                        column.Caption = fields.get_Field(i).AliasName;
                        this.mQueryTable.Columns.Add(column);
                        this.checkedListBoxControl1.Items.Add(column.Caption, true);
                    }
                }
                for (int j = 0; j < fields.FieldCount; j++)
                {
                    if (fields.get_Field(j).Type == esriFieldType.esriFieldTypeOID)
                    {
                        DataColumn column2 = new DataColumn(fields.get_Field(j).Name, typeof(object));
                        this.mQueryTable.Columns.Add(column2);
                        this.objectid = this.mQueryTable.Columns.Count - 1;
                        break;
                    }
                }
                IFeature feature = null;
                for (int k = 0; k < pQueryList.Count; k++)
                {
                    feature = pQueryList[k] as IFeature;
                    if ((feature != null) && (pTable != null))
                    {
                        IQueryFilter queryFilter = new QueryFilterClass();
                        int index = feature.Fields.FindField(sDesKeyField);
                        if (index == -1)
                        {
                            index = feature.Fields.FindField((pQueryLayer.FeatureClass as IDataset).Name + "." + sDesKeyField);
                        }
                        queryFilter.WhereClause = sDesKeyField + "='" + feature.get_Value(index).ToString() + "'";
                        row = pTable.Search(queryFilter, false).NextRow();
                    }
                    DataRow row2 = this.mQueryTable.NewRow();
                    for (int n = 0; n < this.mQueryTable.Columns.Count; n++)
                    {
                        DataColumn column3 = this.mQueryTable.Columns[n];
                        int num6 = fields.FindField(column3.ColumnName);
                        IField field3 = fields.get_Field(num6);
                        string str = "";
                        if (num6 == -1)
                        {
                            goto Label_0478;
                        }
                        if ((field3.Domain != null) && (field3.Domain.Type == esriDomainType.esriDTCodedValue))
                        {
                            str = "";
                            try
                            {
                                long num7;
                                ICodedValueDomain domain = (ICodedValueDomain) fields.get_Field(num6).Domain;
                                if ((row != null) && (pTable != null))
                                {
                                    num7 = Convert.ToInt64(row.get_Value(num6));
                                }
                                else if ((row == null) && (pTable != null))
                                {
                                    num7 = -1L;
                                }
                                else
                                {
                                    num7 = Convert.ToInt64(feature.get_Value(num6));
                                }
                                for (int num8 = 0; num8 < domain.CodeCount; num8++)
                                {
                                    if (num7 == Convert.ToInt64(domain.get_Value(num8)))
                                    {
                                        str = domain.get_Name(num8);
                                        goto Label_046D;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                if (row != null)
                                {
                                    str = row.get_Value(num6).ToString();
                                }
                                else
                                {
                                    str = feature.get_Value(num6).ToString();
                                }
                            }
                        }
                        else if (row != null)
                        {
                            str = row.get_Value(num6).ToString();
                        }
                        else
                        {
                            num6 = feature.Fields.FindField(column3.ColumnName);
                            if (num6 != -1)
                            {
                                str = feature.get_Value(num6).ToString();
                            }
                        }
                    Label_046D:
                        row2[n] = str;
                    Label_0478:
                        row2[this.objectid] = feature;
                    }
                    this.mQueryTable.Rows.Add(row2);
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mQueryTable;
                this.gridView1.RefreshData();
                this.gridView1.OptionsBehavior.Editable = false;
                this.gridControl1.Enabled = true;
                for (int m = 0; m < (this.gridView1.Columns.Count - 1); m++)
                {
                    if (m < 15)
                    {
                        this.gridView1.Columns[m].Visible = true;
                        this.checkedListBoxControl1.Items[m].CheckState = CheckState.Checked;
                    }
                    else
                    {
                        this.gridView1.Columns[m].Visible = false;
                        this.checkedListBoxControl1.Items[m].CheckState = CheckState.Unchecked;
                    }
                }
                this.gridView1.Columns[this.objectid].Visible = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryResult", "InitialQueryInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void UserControlQueryResult_Load(object sender, EventArgs e)
        {
        }
    }
}

