namespace AttributesEdit
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 编辑--属性列表：窗体
    /// </summary>
    public class UserControlAttriList : UserControl
    {
        private BarButtonItem barButtonItem5;
        private BarButtonItem barButtonItemCalField;
        private BarButtonItem barButtonItemDelete;
        private BarButtonItem barButtonItemSelect;
        private BarButtonItem barButtonItemSetvalue;
        private BarButtonItem barButtonItemUnselect;
        private BarButtonItem barButtonItemZoom;
        private BarDockControl barDockControl1;
        private BarDockControl barDockControl2;
        private BarDockControl barDockControl3;
        private BarDockControl barDockControl4;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private BarManager barManager2;
        private SimpleButton btnLast;
        private SimpleButton btnNext;
        private SimpleButton btnRefresh;
        private CheckedListBoxControl checkedListBoxControl1;
        private ComboBoxEdit comboBoxEdit1;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private Label label1;
        private Label label2;
        private Label labelCurrent;
        private Label labelTotal;
        private bool m_bSelectedFeature;
        private const string m_ClassName = "AttributesEdit.UserControlAttriList";
        private int m_CurrentPage;
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IFeatureClass m_FClass;
        private IList<IFeature> m_Features;
        private IFeatureLayer m_FLayer;
        private HorXtraGrid m_Grid;
        private IHookHelper m_hookHelper;
        private string m_LayerName = "";
        private int m_maxID;
        private int m_minID;
        private int m_PageCount;
        private int m_PerCount = 20;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private string m_UpdateField = "";
        private string m_Where = "";
        private string[] m_YbdFields = AttriEdit.YBDFields;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        internal PopupContainerControl PopupContainer;
        internal PopupContainerEdit PopupContainerEdit1;
        private PopupMenu popupMenu1;
        private PopupMenu popupMenu2;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextBox textBoxPage;

        /// <summary>
        /// 编辑--属性列表：构造器
        /// </summary>
        public UserControlAttriList()
        {
            this.InitializeComponent();
            this.gridControl1.MouseUp += new MouseEventHandler(this.gridControl1_MouseUp);
            this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.barButtonItemDelete.ItemClick += new ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
            this.barButtonItemSelect.ItemClick += new ItemClickEventHandler(this.barButtonItemSelect_ItemClick);
            this.barButtonItemUnselect.ItemClick += new ItemClickEventHandler(this.barButtonItemUnselect_ItemClick);
            this.barButtonItemZoom.ItemClick += new ItemClickEventHandler(this.barButtonItemZoom_ItemClick);
            this.barButtonItemSetvalue.ItemClick += new ItemClickEventHandler(this.barButtonItemSetvalue_ItemClick);
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            this.btnLast.Click += new EventHandler(this.btnLast_Click);
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
        }

        private void AddColumns()
        {
            try
            {
                this.m_Grid.Clear();
                int iWidth = 50;
                bool readOnly = true;
                int visibleIndex = -1;
                IFields fields = this.m_FClass.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField pField = fields.get_Field(i);
                    string name = pField.Name;
                    string aliasName = pField.AliasName;
                    visibleIndex = i;
                    if (Editor.UniqueInstance.IsBeingEdited)
                    {
                        readOnly = !pField.Editable;
                    }
                    else
                    {
                        readOnly = true;
                    }
                    IDomain domain = null;
                    ICodedValueDomain domain2 = null;
                    IList nameList = new ArrayList();
                    IList valueList = new ArrayList();
                    if (pField.Type == esriFieldType.esriFieldTypeOID)
                    {
                        this.m_Grid.AddOIDColumn(name, aliasName, visibleIndex, true, iWidth);
                    }
                    else if (pField.Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, true, 15, iWidth);
                    }
                    else if ((pField == this.m_FClass.LengthField) || (pField == this.m_FClass.AreaField))
                    {
                        this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, true, 15, iWidth);
                    }
                    else
                    {
                        domain = pField.Domain;
                        if (domain != null)
                        {
                            if (domain is ICodedValueDomain)
                            {
                                domain2 = domain as ICodedValueDomain;
                                nameList.Add("<空>");
                                valueList.Add(DBNull.Value);
                                for (int j = 0; j < domain2.CodeCount; j++)
                                {
                                    nameList.Add(domain2.get_Name(j));
                                    valueList.Add(domain2.get_Value(j));
                                }
                                string[] readonlyItems = AttriEdit.GetReadonlyItems(pField);
                                this.m_Grid.AddComboBoxColumn(name, aliasName, nameList, valueList, visibleIndex, readOnly, iWidth, readonlyItems);
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
                                this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, minValue, maxValue, readOnly, true, pField.Scale, iWidth);
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
                                this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, num7, num8, readOnly, false, 0, iWidth);
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                        {
                            if (this.m_YbdFields.Contains<string>(name))
                            {
                                this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, 0.0, 1.0, readOnly, true, pField.Scale, iWidth);
                            }
                            else
                            {
                                this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, 0.0, 0.0, readOnly, true, pField.Scale, iWidth);
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                        {
                            this.m_Grid.AddSpinColumn1(name, aliasName, visibleIndex, 0.0, 0.0, readOnly, false, 0, iWidth);
                        }
                        else if (pField.Type == esriFieldType.esriFieldTypeDate)
                        {
                            this.m_Grid.AddDateColumn(name, aliasName, visibleIndex, readOnly, iWidth);
                        }
                        else
                        {
                            this.m_Grid.AddTextColumn(name, aliasName, visibleIndex, readOnly, pField.Length, iWidth);
                        }
                    }
                }
                if (EditTask.KindCode.Substring(0, 2) == "02")
                {
                    this.m_Grid.AddButtonColumn("MMJC", "每木检尺表", "打开", visibleIndex++, true, 70).ButtonClick += new ButtonPressedEventHandler(this.repEdit_ButtonClick);
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriList", "AddColumns", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemCalField_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCalField field = new FormCalField();
            if (this.comboBoxEdit1.SelectedIndex == 1)
            {
                field.UpdateType = 1;
            }
            else
            {
                field.UpdateType = 0;
            }
            field.UpdateField = this.m_UpdateField;
            field.OnUpdateValue += new FormCalField.UpdateValuehandler(this.formCalField_OnUpdateValue);
            field.ShowDialog();
            field.Dispose();
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_Features == null)
            {
                this.m_Features = this.GetFeatures();
            }
            IList<IFeature> features = this.m_Features;
            if ((features != null) && (features.Count >= 1))
            {
                UserControlAttrEdit edit = new UserControlAttrEdit();
                Editor.UniqueInstance.StartEditOperation();
                try
                {
                    IFeature pFeature = null;
                    for (int i = 0; i < features.Count; i++)
                    {
                        pFeature = features[i];
                        if (pFeature != null)
                        {
                            if (EditTask.KindCode.Substring(0, 2) == "02")
                            {
                                edit.DeleteJC(pFeature);
                            }
                            pFeature.Delete();
                        }
                    }
                    Editor.UniqueInstance.StopEditOperation();
                }
                catch
                {
                    Editor.UniqueInstance.AbortEditOperation();
                }
                this.ShowTable(this.m_CurrentPage, "refresh");
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void barButtonItemSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_Features == null)
            {
                this.m_Features = this.GetFeatures();
            }
            IList<IFeature> features = this.m_Features;
            if ((features != null) && (features.Count >= 1))
            {
                IFeatureSelection fLayer = (IFeatureSelection) this.m_FLayer;
                IFeature feature = null;
                for (int i = 0; i < features.Count; i++)
                {
                    feature = features[i];
                    if (feature != null)
                    {
                        fLayer.Add(feature);
                    }
                }
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void barButtonItemSetvalue_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormSetUniqueValue value2 = new FormSetUniqueValue();
            if (this.comboBoxEdit1.SelectedIndex == 1)
            {
                value2.UpdateType = 1;
            }
            else
            {
                value2.UpdateType = 0;
            }
            value2.UpdateField = this.m_UpdateField;
            value2.OnUpdateValue += new FormSetUniqueValue.UpdateValuehandler(this.formSetValue_OnUpdateValue);
            value2.ShowDialog();
            value2.Dispose();
        }

        private void barButtonItemUnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_Features == null)
            {
                this.m_Features = this.GetFeatures();
            }
            IList<IFeature> features = this.m_Features;
            if ((features != null) && (features.Count >= 1))
            {
                IFeatureSelection fLayer = (IFeatureSelection) this.m_FLayer;
                ISelectionSet selectionSet = fLayer.SelectionSet;
                IFeature feature = null;
                for (int i = 0; i < features.Count; i++)
                {
                    feature = features[i];
                    if (feature != null)
                    {
                        int oID = feature.OID;
                        selectionSet.RemoveList(1, ref oID);
                    }
                }
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void barButtonItemZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = this.gridView1.GetSelectedRows();
            DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
            this.ZoomToSelectedRow(row);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.ShowTable(this.m_CurrentPage - 1, "last");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.ShowTable(this.m_CurrentPage + 1, "next");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.InitShow();
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
            this.gridView1.RefreshData();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitShow();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void formCalField_OnUpdateValue()
        {
            this.ShowTable(this.m_CurrentPage, "refresh");
        }

        private void formSetValue_OnUpdateValue()
        {
            this.ShowTable(this.m_CurrentPage, "refresh");
        }

        /// <summary>
        /// 获取要素数量
        /// </summary>
        /// <returns></returns>
        private int GetFeatureCount()
        {
            string where = this.m_Where;
            IQueryFilter queryFilter = null;
            if (where != "")
            {
                queryFilter = new QueryFilterClass {
                    WhereClause = where
                };
            }
            int num = this.m_FClass.FeatureCount(queryFilter);
            if (queryFilter != null)
            {
                Marshal.ReleaseComObject(queryFilter);
            }
            return num;
        }

        /// <summary>
        /// 获取List中的要素
        /// </summary>
        /// <returns></returns>
        private IList<IFeature> GetFeatures()
        {
            IList<IFeature> list = new List<IFeature>();
            try
            {
                int[] selectedRows = this.gridView1.GetSelectedRows();
                IFeature item = null;
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    DataRowView row = this.gridView1.GetRow(selectedRows[i]) as DataRowView;
                    int iD = int.Parse(row[0].ToString());
                    try
                    {
                        item = this.m_FClass.GetFeature(iD);
                    }
                    catch
                    {
                        item = null;
                    }
                    list.Add(item);
                }
            }
            catch
            {
                list = new List<IFeature>();
            }
            return list;
        }

        private string GetGeometryType(esriGeometryType pGType)
        {
            return pGType.ToString().Substring(12);
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridHitInfo info = this.gridView1.CalcHitInfo(e.X, e.Y);
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    this.barButtonItemDelete.Enabled = true;
                    if (info.InColumnPanel)
                    {
                        this.m_UpdateField = info.Column.FieldName;
                        if (this.m_UpdateField != "")
                        {
                            string updateField = this.m_UpdateField;
                            int index = this.m_FClass.FindField(updateField);
                            IField field = this.m_FClass.Fields.get_Field(index);
                            if (!field.Editable || (field.Type == esriFieldType.esriFieldTypeGeometry))
                            {
                                this.barButtonItemSetvalue.Enabled = false;
                                this.barButtonItemCalField.Enabled = false;
                            }
                            else
                            {
                                this.barButtonItemSetvalue.Enabled = true;
                                this.barButtonItemCalField.Enabled = true;
                            }
                            this.popupMenu2.ShowPopup(Control.MousePosition);
                        }
                        return;
                    }
                }
                else
                {
                    this.barButtonItemDelete.Enabled = false;
                }
                if (info.InRow)
                {
                    this.m_Features = this.GetFeatures();
                    if (this.gridView1.GetSelectedRows().Length == 1)
                    {
                        this.barButtonItemZoom.Enabled = true;
                    }
                    else
                    {
                        this.barButtonItemZoom.Enabled = false;
                    }
                    this.popupMenu1.ShowPopup(Control.MousePosition);
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                DataRowView row = this.gridView1.GetRow(e.RowHandle) as DataRowView;
                if (row != null)
                {
                    object selectedValue = e.Value;
                    if (e.Column.ColumnEdit is RepositoryItemComboBox)
                    {
                        ZLRepositoryItemComboBox columnEdit = (ZLRepositoryItemComboBox) e.Column.ColumnEdit;
                        selectedValue = columnEdit.SelectedValue;
                    }
                    int iD = int.Parse(row[0].ToString());
                    IFeature feature = this.m_FClass.GetFeature(iD);
                    if (feature != null)
                    {
                        int absoluteIndex = e.Column.AbsoluteIndex;
                        Editor.UniqueInstance.StartEditOperation();
                        feature.set_Value(absoluteIndex, selectedValue);
                        feature.Store();
                        Editor.UniqueInstance.StopEditOperation();
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriList", "gridView1_CellValueChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Init(object hook)
        {
            this.m_hookHelper = new HookHelperClass();
            this.m_hookHelper.Hook = hook;
            this.m_PerCount = Convert.ToInt16(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ListPerCount").ToString());
            this.gridView1.RowHeight = 20;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.btnLast.Enabled = false;
            this.btnNext.Enabled = false;
            this.m_FLayer = EditTask.EditLayer;
            if (this.m_FLayer != null)
            {
                this.m_FClass = this.m_FLayer.FeatureClass;
                if (this.m_FClass != null)
                {
                    if (this.m_Grid == null)
                    {
                        this.m_Grid = new HorXtraGrid(this.gridControl1);
                    }
                    if ((this.m_FLayer.Name != this.m_LayerName) || (this.m_Grid.DataSource.Columns.Count < 1))
                    {
                        this.AddColumns();
                    }
                    this.InitFieldList();
                    this.m_LayerName = this.m_FLayer.Name;
                    if (this.m_bSelectedFeature)
                    {
                        this.comboBoxEdit1.SelectedIndex = 1;
                    }
                    else
                    {
                        this.comboBoxEdit1.SelectedIndex = 0;
                    }
                }
            }
        }

        private void InitFieldList()
        {
            this.checkedListBoxControl1.Items.Clear();
            IFields fields = this.m_FClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                this.checkedListBoxControl1.Items.Add(fields.get_Field(i).AliasName, true);
            }
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PopupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel8 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.PopupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemZoom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUnselect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSetvalue = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
            this.barButtonItemCalField = new DevExpress.XtraBars.BarButtonItem();
            this.barManager2 = new DevExpress.XtraBars.BarManager();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).BeginInit();
            this.PopupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridControl1.Location = new System.Drawing.Point(2, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(528, 215);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxEdit1.Location = new System.Drawing.Point(10, 6);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "全部要素",
            "选中要素"});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(80, 20);
            this.comboBoxEdit1.TabIndex = 2;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PopupContainer);
            this.panel1.Controls.Add(this.PopupContainerEdit1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.comboBoxEdit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 6, 20, 2);
            this.panel1.Size = new System.Drawing.Size(528, 29);
            this.panel1.TabIndex = 3;
            // 
            // PopupContainer
            // 
            this.PopupContainer.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PopupContainer.Appearance.Options.UseBackColor = true;
            this.PopupContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PopupContainer.Controls.Add(this.checkedListBoxControl1);
            this.PopupContainer.Controls.Add(this.panel8);
            this.PopupContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PopupContainer.Location = new System.Drawing.Point(205, -110);
            this.PopupContainer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.PopupContainer.Name = "PopupContainer";
            this.PopupContainer.Padding = new System.Windows.Forms.Padding(1);
            this.PopupContainer.Size = new System.Drawing.Size(163, 166);
            this.PopupContainer.TabIndex = 97;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(157, 134);
            this.checkedListBoxControl1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.simpleButton2);
            this.panel8.Controls.Add(this.simpleButton1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 137);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(157, 26);
            this.panel8.TabIndex = 13;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(98, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(50, 20);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "全不选";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(43, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(40, 20);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "全选";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // PopupContainerEdit1
            // 
            this.PopupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PopupContainerEdit1.EditValue = " 显示字段";
            this.PopupContainerEdit1.Location = new System.Drawing.Point(117, 6);
            this.PopupContainerEdit1.Name = "PopupContainerEdit1";
            this.PopupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.PopupContainerEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Black;
            this.PopupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.PopupContainerEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.PopupContainerEdit1.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.PopupContainerEdit1.Properties.PopupControl = this.PopupContainer;
            this.PopupContainerEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.PopupContainerEdit1.Properties.ShowPopupShadow = false;
            this.PopupContainerEdit1.Size = new System.Drawing.Size(61, 20);
            this.PopupContainerEdit1.TabIndex = 92;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(441, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(27, 21);
            this.panel7.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(468, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 21);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(90, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(27, 21);
            this.panel9.TabIndex = 98;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 244);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 6, 10, 5);
            this.panel2.Size = new System.Drawing.Size(528, 36);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelTotal);
            this.panel4.Controls.Add(this.labelCurrent);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 6, 5, 0);
            this.panel4.Size = new System.Drawing.Size(327, 25);
            this.panel4.TabIndex = 9;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTotal.ForeColor = System.Drawing.Color.Red;
            this.labelTotal.Location = new System.Drawing.Point(0, 6);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 12);
            this.labelTotal.TabIndex = 12;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCurrent.Location = new System.Drawing.Point(322, 6);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(0, 12);
            this.labelCurrent.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.textBoxPage);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(332, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(94, 25);
            this.panel5.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "页";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(23, 3);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(50, 21);
            this.textBoxPage.TabIndex = 13;
            this.textBoxPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPage_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "去";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLast);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.btnNext);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(426, 6);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 3);
            this.panel6.Size = new System.Drawing.Size(92, 25);
            this.panel6.TabIndex = 13;
            // 
            // btnLast
            // 
            this.btnLast.Appearance.BackColor = System.Drawing.Color.White;
            this.btnLast.Appearance.Options.UseBackColor = true;
            this.btnLast.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLast.Location = new System.Drawing.Point(2, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(40, 20);
            this.btnLast.TabIndex = 8;
            this.btnLast.Text = "上一页";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(42, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 20);
            this.panel3.TabIndex = 7;
            // 
            // btnNext
            // 
            this.btnNext.Appearance.BackColor = System.Drawing.Color.White;
            this.btnNext.Appearance.Options.UseBackColor = true;
            this.btnNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(52, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 20);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一页";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemZoom,
            this.barButtonItemSelect,
            this.barButtonItemUnselect,
            this.barButtonItemDelete,
            this.barButtonItemSetvalue});
            this.barManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(2, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(528, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(2, 280);
            this.barDockControlBottom.Size = new System.Drawing.Size(528, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(2, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 280);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(530, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 280);
            // 
            // barButtonItemZoom
            // 
            this.barButtonItemZoom.Caption = "缩放到要素";
            this.barButtonItemZoom.Id = 0;
            this.barButtonItemZoom.Name = "barButtonItemZoom";
            // 
            // barButtonItemSelect
            // 
            this.barButtonItemSelect.Caption = "选择要素";
            this.barButtonItemSelect.Id = 1;
            this.barButtonItemSelect.Name = "barButtonItemSelect";
            // 
            // barButtonItemUnselect
            // 
            this.barButtonItemUnselect.Caption = "取消选择";
            this.barButtonItemUnselect.Id = 2;
            this.barButtonItemUnselect.Name = "barButtonItemUnselect";
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.Caption = "删除要素";
            this.barButtonItemDelete.Id = 3;
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            // 
            // barButtonItemSetvalue
            // 
            this.barButtonItemSetvalue.Caption = "批量赋值";
            this.barButtonItemSetvalue.Id = 4;
            this.barButtonItemSetvalue.Name = "barButtonItemSetvalue";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemZoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSelect),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemUnselect),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSetvalue),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCalField)});
            this.popupMenu2.Manager = this.barManager2;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // barButtonItemCalField
            // 
            this.barButtonItemCalField.Caption = "计算字段";
            this.barButtonItemCalField.Id = 5;
            this.barButtonItemCalField.Name = "barButtonItemCalField";
            this.barButtonItemCalField.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCalField_ItemClick);
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem5,
            this.barButtonItemCalField});
            this.barManager2.MaxItemId = 6;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(2, 0);
            this.barDockControl1.Size = new System.Drawing.Size(528, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(2, 280);
            this.barDockControl2.Size = new System.Drawing.Size(528, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(2, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 280);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(530, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 280);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "批量赋值";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // UserControlAttriList
            // 
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "UserControlAttriList";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(532, 280);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).EndInit();
            this.PopupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitShow()
        {
            this.m_Where = "";
            IFeatureLayerDefinition fLayer = (IFeatureLayerDefinition) this.m_FLayer;
            string definitionExpression = fLayer.DefinitionExpression;
            if (definitionExpression != "")
            {
                this.m_Where = definitionExpression;
            }
            if (this.comboBoxEdit1.SelectedIndex == 0)
            {
                this.m_bSelectedFeature = false;
                this.ShowTable(1, "");
            }
            else if (this.comboBoxEdit1.SelectedIndex == 1)
            {
                this.m_bSelectedFeature = true;
                string oIDFieldName = this.m_FClass.OIDFieldName;
                IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                ISelectionSet selectionSet = editLayer.SelectionSet;
                if (selectionSet.Count > 0)
                {
                    IEnumIDs iDs = selectionSet.IDs;
                    iDs.Reset();
                    int num = -1;
                    string str3 = "";
                    while ((num = iDs.Next()) != -1)
                    {
                        object obj2 = str3;
                        str3 = string.Concat(new object[] { obj2, " or ", oIDFieldName, "=", num });
                    }
                    if (str3.Length > 4)
                    {
                        str3 = str3.Substring(4);
                    }
                    if (this.m_Where == "")
                    {
                        this.m_Where = str3;
                    }
                    else
                    {
                        this.m_Where = this.m_Where + " and " + str3;
                    }
                }
                else
                {
                    string str4 = oIDFieldName + "<0";
                    if (this.m_Where == "")
                    {
                        this.m_Where = str4;
                    }
                    else
                    {
                        this.m_Where = this.m_Where + " and " + str4;
                    }
                }
                this.ShowTable(1, "");
            }
        }

        private void repEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int focusedRowHandle = this.gridView1.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                DataRowView row = this.gridView1.GetRow(focusedRowHandle) as DataRowView;
                int iD = int.Parse(row[0].ToString());
                IFeature pFeature = this.m_FClass.GetFeature(iD);
                FormMMJC mmmjc = new FormMMJC();
                mmmjc.Init(this, pFeature, false);
                mmmjc.WindowState = FormWindowState.Maximized;
                mmmjc.ShowDialog(this);
                this.ShowTable(this.m_CurrentPage, "refresh");
            }
        }

        private void ShowTable(int iPage, string sType)
        {
            this.btnLast.Enabled = false;
            this.btnNext.Enabled = false;
            this.textBoxPage.Enabled = false;
            int num = 1;
            try
            {
                DataTable dataSource = this.m_Grid.DataSource;
                dataSource.Rows.Clear();
                string oIDFieldName = this.m_FClass.OIDFieldName;
                IQueryFilter queryFilter = null;
                queryFilter = new QueryFilterClass {
                    SubFields = oIDFieldName
                };
                if (sType == "")
                {
                    this.m_minID = 0;
                    this.m_maxID = 0;
                    int featureCount = this.GetFeatureCount();
                    this.m_PageCount = Convert.ToInt32((double) ((((double) featureCount) / ((double) this.m_PerCount)) + 0.5));
                    if (iPage > this.m_PageCount)
                    {
                        iPage = this.m_PageCount;
                    }
                    this.labelTotal.Text = "共" + featureCount + "个要素";
                    queryFilter.WhereClause = oIDFieldName + ">=0";
                    if (this.m_Where != "")
                    {
                        queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                    }
                    IQueryFilterDefinition definition = (IQueryFilterDefinition) queryFilter;
                    definition.PostfixClause = "order by " + oIDFieldName;
                }
                else if (sType == "refresh")
                {
                    int num3 = this.GetFeatureCount();
                    this.m_PageCount = Convert.ToInt32((double) ((((double) num3) / ((double) this.m_PerCount)) + 0.5));
                    if (iPage > this.m_PageCount)
                    {
                        iPage = this.m_PageCount;
                    }
                    this.labelTotal.Text = "共" + num3 + "个要素";
                    queryFilter.WhereClause = oIDFieldName + ">=" + this.m_minID;
                    if (this.m_Where != "")
                    {
                        queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                    }
                    IQueryFilterDefinition definition2 = (IQueryFilterDefinition) queryFilter;
                    definition2.PostfixClause = "order by " + oIDFieldName;
                }
                else if (sType == "goto")
                {
                    num = iPage - this.m_CurrentPage;
                    if (num > 0)
                    {
                        queryFilter.WhereClause = oIDFieldName + ">" + this.m_maxID;
                        if (this.m_Where != "")
                        {
                            queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                        }
                        IQueryFilterDefinition definition3 = (IQueryFilterDefinition) queryFilter;
                        definition3.PostfixClause = "order by " + oIDFieldName;
                    }
                    else
                    {
                        queryFilter = new QueryFilterClass {
                            WhereClause = oIDFieldName + "<" + this.m_minID
                        };
                        if (this.m_Where != "")
                        {
                            queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                        }
                        IQueryFilterDefinition definition4 = (IQueryFilterDefinition) queryFilter;
                        definition4.PostfixClause = "order by " + oIDFieldName + " desc";
                    }
                }
                else if (sType == "next")
                {
                    queryFilter.WhereClause = oIDFieldName + ">" + this.m_maxID;
                    if (this.m_Where != "")
                    {
                        queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                    }
                    IQueryFilterDefinition definition5 = (IQueryFilterDefinition) queryFilter;
                    definition5.PostfixClause = "order by " + oIDFieldName;
                }
                else if (sType == "last")
                {
                    queryFilter.WhereClause = oIDFieldName + "<" + this.m_minID;
                    if (this.m_Where != "")
                    {
                        queryFilter.WhereClause = queryFilter.WhereClause + " and (" + this.m_Where + ")";
                    }
                    IQueryFilterDefinition definition6 = (IQueryFilterDefinition) queryFilter;
                    definition6.PostfixClause = "order by " + oIDFieldName + " desc";
                }
                else
                {
                    queryFilter = null;
                }
                if (this.m_PageCount == 0)
                {
                    this.m_CurrentPage = 0;
                    this.labelCurrent.Text = string.Concat(new object[] { "第", this.m_CurrentPage, "/", this.m_PageCount, "页" });
                }
                else
                {
                    this.m_CurrentPage = iPage;
                    this.labelCurrent.Text = string.Concat(new object[] { "第", this.m_CurrentPage, "/", this.m_PageCount, "页" });
                    this.btnLast.Enabled = true;
                    this.btnNext.Enabled = true;
                    this.textBoxPage.Enabled = true;
                    if (this.m_CurrentPage == 1)
                    {
                        this.btnLast.Enabled = false;
                    }
                    if (this.m_CurrentPage == this.m_PageCount)
                    {
                        this.btnNext.Enabled = false;
                    }
                    IFeatureCursor o = this.m_FLayer.Search(queryFilter, false);
                    IFeature feature = null;
                    IFeature feature2 = null;
                    int num4 = 0;
                    while ((feature = o.NextFeature()) != null)
                    {
                        num4++;
                        if (num4 > ((Math.Abs(num) - 1) * this.m_PerCount))
                        {
                            if (num4 > (Math.Abs(num) * this.m_PerCount))
                            {
                                break;
                            }
                            feature2 = this.m_FClass.GetFeature(feature.OID);
                            DataRow row = dataSource.NewRow();
                            int num5 = -1;
                            for (int i = 0; i < feature2.Fields.FieldCount; i++)
                            {
                                IField field = feature2.Fields.get_Field(i);
                                object obj2 = feature2.get_Value(i);
                                num5 = i;
                                if (field.Type == esriFieldType.esriFieldTypeGeometry)
                                {
                                    string geometryType = this.GetGeometryType(this.m_FClass.ShapeType);
                                    row[num5] = geometryType;
                                    continue;
                                }
                                if ((field == this.m_FClass.LengthField) || (field == this.m_FClass.AreaField))
                                {
                                    if (obj2 == null)
                                    {
                                        row[num5] = obj2;
                                    }
                                    else
                                    {
                                        row[num5] = double.Parse(obj2.ToString()).ToString("f6");
                                    }
                                    continue;
                                }
                                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                                {
                                    string str3 = "";
                                    ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                                    string str4 = "";
                                    if (obj2 != null)
                                    {
                                        str4 = obj2.ToString();
                                    }
                                    for (int j = 0; j < domain.CodeCount; j++)
                                    {
                                        if (str4 == domain.get_Value(j).ToString())
                                        {
                                            str3 = domain.get_Name(j);
                                            break;
                                        }
                                    }
                                    row[num5] = str3;
                                    continue;
                                }
                                if (((field.Type == esriFieldType.esriFieldTypeSmallInteger) || (field.Type == esriFieldType.esriFieldTypeSingle)) || ((field.Type == esriFieldType.esriFieldTypeDouble) || (field.Type == esriFieldType.esriFieldTypeInteger)))
                                {
                                    if (obj2 == null)
                                    {
                                        row[num5] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[num5] = obj2;
                                    }
                                }
                                else if (field.Type == esriFieldType.esriFieldTypeOID)
                                {
                                    row[num5] = obj2;
                                }
                                else
                                {
                                    row[num5] = obj2;
                                }
                            }
                            dataSource.Rows.Add(row);
                        }
                    }
                    if (o != null)
                    {
                        Marshal.ReleaseComObject(o);
                    }
                    if (queryFilter != null)
                    {
                        Marshal.ReleaseComObject(queryFilter);
                    }
                    DataView defaultView = dataSource.DefaultView;
                    defaultView.Sort = oIDFieldName + " asc";
                    dataSource = defaultView.ToTable();
                    this.m_minID = int.Parse(dataSource.Rows[0][0].ToString());
                    this.m_maxID = int.Parse(dataSource.Rows[dataSource.Rows.Count - 1][0].ToString());
                    this.m_Grid.RefreshDataSource();
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriList", "ShowTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxControl1.Items.Count; i++)
            {
                this.checkedListBoxControl1.Items[i].CheckState = CheckState.Checked;
            }
            for (int j = 0; j < this.gridView1.Columns.Count; j++)
            {
                this.gridView1.Columns[j].VisibleIndex = this.gridView1.Columns[j].AbsoluteIndex;
            }
            this.gridView1.RefreshData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxControl1.Items.Count; i++)
            {
                this.checkedListBoxControl1.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int j = 0; j < this.gridView1.Columns.Count; j++)
            {
                this.gridView1.Columns[j].Visible = false;
            }
            this.gridView1.RefreshData();
        }

        private void textBoxPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = this.textBoxPage.Text;
                text.Replace(" ", "");
                if (text != "")
                {
                    string pattern = "^[0-9]*$";
                    if (Regex.Match(text, pattern).Success)
                    {
                        int iPage = int.Parse(text);
                        if (((iPage >= 1) && (iPage <= this.m_PageCount)) && (iPage != this.m_CurrentPage))
                        {
                            this.ShowTable(iPage, "goto");
                        }
                    }
                }
            }
        }

        private void ZoomToSelectedRow(DataRowView row)
        {
            try
            {
                int iD = int.Parse(row[0].ToString());
                IFeature feature = this.m_FClass.GetFeature(iD);
                if (feature != null)
                {
                    ((IFeatureSelection) this.m_FLayer).Add(feature);
                    IGeometry shapeCopy = feature.ShapeCopy;
                    shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_hookHelper.ActiveView.FocusMap.SpatialReference);
                    IEnvelope envelope = new EnvelopeClass {
                        SpatialReference = this.m_hookHelper.ActiveView.FocusMap.SpatialReference
                    };
                    double num2 = 100.0;
                    envelope.PutCoords(shapeCopy.Envelope.XMin - num2, shapeCopy.Envelope.YMin - num2, shapeCopy.Envelope.XMax + num2, shapeCopy.Envelope.YMax + num2);
                    this.m_hookHelper.ActiveView.Extent = envelope;
                    this.m_hookHelper.ActiveView.Refresh();
                }
            }
            catch
            {
            }
        }
    }
}

