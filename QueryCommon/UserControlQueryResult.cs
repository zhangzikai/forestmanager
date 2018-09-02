namespace QueryCommon
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
    using FunFactory;
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
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "TaskManage.UserControlXBSet";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IHookHelper mHookHelper;
        private IFeatureLayer mQueryLayer;
        private ArrayList mQueryList;
        private DataTable mQueryTable;
        private bool mSelected;
        private IFeature mSelFeature;
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
                    this.mSelected = true;
                    int rowHandle = this.gridView1.GetSelectedRows()[0];
                    IFeature pFeature = this.gridView1.GetDataRow(rowHandle)[this.objectid] as IFeature;
                    this.mHookHelper.FocusMap.ClearSelection();
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                    this.mHookHelper.FocusMap.SelectFeature(this.mQueryLayer, pFeature);
                    rowHandle = this.mHookHelper.FocusMap.SelectionCount;
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, pFeature, pFeature.Shape.Envelope);
                    this.mSelected = false;
                }
            }
            catch (Exception)
            {
                this.mSelected = false;
            }
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Enumerable.Count<int>(this.gridView1.GetSelectedRows()) != 0)
                {
                    this.mSelected = true;
                    int rowHandle = this.gridView1.GetSelectedRows()[0];
                    IFeature feature = this.gridView1.GetDataRow(rowHandle)[this.objectid] as IFeature;
                    (this.mQueryLayer as IFeatureSelection).Clear();
                    if (this.mSelFeature != null)
                    {
                        IEnvelope envelope = this.mSelFeature.Shape.Envelope;
                        envelope.Expand(1.2, 1.2, true);
                        this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, this.mQueryLayer, envelope);
                    }
                    this.mHookHelper.FocusMap.SelectFeature(this.mQueryLayer, feature);
                    this.mSelFeature = feature;
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, this.mQueryLayer, null);
                    this.mSelected = false;
                }
            }
            catch (Exception)
            {
                this.mSelected = false;
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

        public void InitialQueryInfo(IHookHelper pHookHelper, IFeatureLayer pQueryLayer, ArrayList pQueryList, ITable pTable, string sDesKeyField, IFeature selFeature, string[] visFields)
        {
            try
            {
                IFields fields = null;
                IRow row = null;
                this.mHookHelper = pHookHelper;
                this.mQueryLayer = pQueryLayer;
                this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                this.mActiveViewEvents.SelectionChanged+=(new IActiveViewEvents_SelectionChangedEventHandler(this.mActiveViewEvents_SelectionChanged));
                if ((this.mQueryList == null) || (this.mQueryList != pQueryList))
                {
                    this.mQueryList = pQueryList;
                    IFeatureClass featureClass = pQueryLayer.FeatureClass;
                    this.labeltitle.Text = pQueryLayer.Name + "班块信息列表";
                    this.labeltitle.Width = 200;
                    if (base.Parent != null)
                    {
                        base.Parent.Visible = true;
                    }
                    if (base.Parent.Parent != null)
                    {
                        base.Parent.Parent.Visible = true;
                    }
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
                    int rowHandle = -1;
                    if (this.mQueryList != null)
                    {
                        for (int m = 0; m < pQueryList.Count; m++)
                        {
                            feature = pQueryList[m] as IFeature;
                            if (feature != null)
                            {
                                if (feature == selFeature)
                                {
                                    rowHandle = m;
                                }
                                if (pTable != null)
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
                            }
                            DataRow row2 = this.mQueryTable.NewRow();
                            for (int n = 0; n < this.mQueryTable.Columns.Count; n++)
                            {
                                DataColumn column3 = this.mQueryTable.Columns[n];
                                int num7 = fields.FindField(column3.ColumnName);
                                IField field3 = fields.get_Field(num7);
                                string str = "";
                                if (num7 == -1)
                                {
                                    goto Label_0537;
                                }
                                if ((field3.Domain != null) && (field3.Domain.Type == esriDomainType.esriDTCodedValue))
                                {
                                    str = "";
                                    try
                                    {
                                        long num8;
                                        ICodedValueDomain domain = (ICodedValueDomain) fields.get_Field(num7).Domain;
                                        if ((row != null) && (pTable != null))
                                        {
                                            num8 = Convert.ToInt64(row.get_Value(num7));
                                        }
                                        else if ((row == null) && (pTable != null))
                                        {
                                            num8 = -1L;
                                        }
                                        else
                                        {
                                            num8 = Convert.ToInt64(feature.get_Value(num7));
                                        }
                                        for (int num9 = 0; num9 < domain.CodeCount; num9++)
                                        {
                                            if (num8 == Convert.ToInt64(domain.get_Value(num9)))
                                            {
                                                str = domain.get_Name(num9);
                                                goto Label_052C;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (row != null)
                                        {
                                            str = row.get_Value(num7).ToString();
                                        }
                                        else
                                        {
                                            str = feature.get_Value(num7).ToString();
                                        }
                                    }
                                }
                                else if (row != null)
                                {
                                    str = row.get_Value(num7).ToString();
                                }
                                else
                                {
                                    num7 = feature.Fields.FindField(column3.ColumnName);
                                    if (num7 != -1)
                                    {
                                        str = feature.get_Value(num7).ToString();
                                    }
                                }
                            Label_052C:
                                row2[n] = str;
                            Label_0537:
                                row2[this.objectid] = feature;
                            }
                            this.mQueryTable.Rows.Add(row2);
                        }
                    }
                    else
                    {
                        IFeatureCursor cursor2 = pQueryLayer.FeatureClass.Search(null, false);
                        for (feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                        {
                            DataRow row3 = this.mQueryTable.NewRow();
                            for (int num10 = 0; num10 < this.mQueryTable.Columns.Count; num10++)
                            {
                                DataColumn column4 = this.mQueryTable.Columns[num10];
                                int num11 = fields.FindField(column4.ColumnName);
                                IField field4 = fields.get_Field(num11);
                                string str2 = "";
                                if (num11 == -1)
                                {
                                    goto Label_0710;
                                }
                                if ((field4.Domain != null) && (field4.Domain.Type == esriDomainType.esriDTCodedValue))
                                {
                                    str2 = "";
                                    try
                                    {
                                        long num12;
                                        ICodedValueDomain domain2 = (ICodedValueDomain) fields.get_Field(num11).Domain;
                                        if ((row != null) && (pTable != null))
                                        {
                                            num12 = Convert.ToInt64(row.get_Value(num11));
                                        }
                                        else if ((row == null) && (pTable != null))
                                        {
                                            num12 = -1L;
                                        }
                                        else
                                        {
                                            num12 = Convert.ToInt64(feature.get_Value(num11));
                                        }
                                        for (int num13 = 0; num13 < domain2.CodeCount; num13++)
                                        {
                                            if (num12 == Convert.ToInt64(domain2.get_Value(num13)))
                                            {
                                                str2 = domain2.get_Name(num13);
                                                goto Label_0705;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (row != null)
                                        {
                                            str2 = row.get_Value(num11).ToString();
                                        }
                                        else
                                        {
                                            str2 = feature.get_Value(num11).ToString();
                                        }
                                    }
                                }
                                else if (row != null)
                                {
                                    str2 = row.get_Value(num11).ToString();
                                }
                                else
                                {
                                    num11 = feature.Fields.FindField(column4.ColumnName);
                                    if (num11 != -1)
                                    {
                                        str2 = feature.get_Value(num11).ToString();
                                    }
                                }
                            Label_0705:
                                row3[num10] = str2;
                            Label_0710:
                                row3[this.objectid] = feature;
                            }
                            this.mQueryTable.Rows.Add(row3);
                        }
                    }
                    this.gridControl1.DataSource = null;
                    this.gridView1.OptionsView.ColumnAutoWidth = false;
                    this.gridView1.Columns.Clear();
                    this.gridControl1.DataSource = this.mQueryTable;
                    this.gridView1.RefreshData();
                    this.gridView1.OptionsBehavior.Editable = false;
                    this.gridControl1.Enabled = true;
                    if (rowHandle != -1)
                    {
                        this.gridView1.SelectRow(rowHandle);
                        this.gridView1.TopRowIndex = rowHandle;
                        this.gridView1.SelectRange(rowHandle, rowHandle);
                    }
                    for (int k = 0; k < (this.gridView1.Columns.Count - 1); k++)
                    {
                        if (k < 15)
                        {
                            this.gridView1.Columns[k].Visible = true;
                            this.checkedListBoxControl1.Items[k].CheckState = CheckState.Checked;
                        }
                        else
                        {
                            this.gridView1.Columns[k].Visible = false;
                            this.checkedListBoxControl1.Items[k].CheckState = CheckState.Unchecked;
                        }
                    }
                    this.gridView1.Columns[this.objectid].Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "TaskManage.UserControlXBSet", "InitialQueryInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mActiveViewEvents_SelectionChanged()
        {
            if (!this.mSelected)
            {
                this.mQueryLayer = new FeatureLayerClass();
                IFeatureSelection mQueryLayer = this.mQueryLayer as IFeatureSelection;
                if (mQueryLayer.SelectionSet!=null&&mQueryLayer.SelectionSet.Count > 0)
                {
                    ICursor cursor = null;
                    mQueryLayer.SelectionSet.Search(null, false, out cursor);
                    IRow row = cursor.NextRow();
                    int startRowHandle = -1;
                    for (int i = 0; i < this.mQueryList.Count; i++)
                    {
                        IFeature feature = this.mQueryList[i] as IFeature;
                        if (feature.OID == row.OID)
                        {
                            startRowHandle = i;
                            break;
                        }
                    }
                    if (startRowHandle != -1)
                    {
                        this.gridView1.TopRowIndex = startRowHandle;
                        this.gridView1.SelectRows(startRowHandle, startRowHandle);
                        this.gridView1.SelectRange(startRowHandle, startRowHandle);
                        this.gridControl1.Refresh();
                    }
                }
            }
        }

        private void UserControlQueryResult_Load(object sender, EventArgs e)
        {
        }
    }
}

