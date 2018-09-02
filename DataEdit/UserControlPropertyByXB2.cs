namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    /// <summary>
    /// 获取属性的用户窗体
    /// </summary>
    public class UserControlPropertyByXB2 : UserControlBase1
    {
        private int ComboxSelectIndex = -1;
        private IContainer components = null;
        private int CurrentRow = -1;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridControl gridControl1;
        private GridView gridView1;
        private Label label1;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelInfo;
        private IFeatureLayer m_CountyLayer;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_TownLayer;
        private IFeatureLayer m_VillageLayer;
        private const string mClassName = "DataEdit.UserControlPropertyByXB";
        private ArrayList mCList;
        private ArrayList mCList2;
        private string mEditKind;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private ArrayList mFieldList;
        private DataTable mFieldTable;
        private IHookHelper mHookHelper;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mVList;
        private ArrayList mVList2;
        private Panel panel1;
        private Panel panel2;
        private Panel panelGridControl;
        private Panel panelQuery;
        private Panel panelsel;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private string sDistFieldCode;
        private string sDistFieldCode2;
        private string sDistFieldCode3;
        private string sDistFieldName;
        private string sDistFieldName2;
        private string sDistFieldName3;
        private string sDistLayerName;
        private string sDistLayerName2;
        private string sDistLayerName3;
        private SimpleButton simpleButtonClip;
        private SimpleButton simpleButtonSelectAll;
        private SimpleButton simpleButtonSelectClear;
        private SplitContainerControl splitContainerControl1;
        internal TreeList tListDist;
        internal TreeListColumn treeListColumn1;
        internal TreeListColumn treeListColumn2;
        private IFeatureLayer xblayer;

        /// <summary>
        /// 获取属性的用户窗体
        /// </summary>
        public UserControlPropertyByXB2()
        {
            this.InitializeComponent();
        }

        private bool CheckHasField(string sfname)
        {
            try
            {
                IFields fields = this.m_EditLayer.FeatureClass.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    if (fields.get_Field(i).Name == sfname)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "CheckHasField", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
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

        private ArrayList GetDistValues(IFeatureLayer pFLayer, string FieldName, string WhereString, out ArrayList list, out ArrayList list2)
        {
            list = new ArrayList();
            list2 = new ArrayList();
            try
            {
                int num = pFLayer.FeatureClass.FeatureCount(null);
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = WhereString;
                IFeatureCursor cursor = pFLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                string name = FieldName;
                int index = feature.Fields.FindField(name);
                string str2 = "";
                while (feature != null)
                {
                    if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        str2 = "";
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                            long num3 = Convert.ToInt64(feature.get_Value(index));
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (num3 == Convert.ToInt64(domain.get_Value(i)))
                                {
                                    str2 = domain.get_Name(i);
                                    goto Label_0143;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            str2 = feature.get_Value(index).ToString();
                        }
                    }
                    else
                    {
                        str2 = feature.get_Value(index).ToString();
                    }
                Label_0143:
                    list.Add(str2);
                    list2.Add(feature);
                    feature = cursor.NextFeature();
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        private IFeature GetXBFeature(IFeature pFeature, out string err)
        {
            Exception exception;
            try
            {
                err = "";
                if (this.xblayer == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    this.xblayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                }
                if (this.xblayer == null)
                {
                    return null;
                }
                if (this.xblayer.FeatureClass == null)
                {
                    return null;
                }
                GC.Collect();
                IFeature feature = null;
                IFeature feature2 = null;
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pFeature.Shape;
                filter.GeometryField = this.xblayer.FeatureClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                IFeatureCursor cursor = this.xblayer.FeatureClass.Search(filter, false);
                feature = cursor.NextFeature();
                double area = 0.0;
                if (feature == null)
                {
                    GC.Collect();
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                    cursor = this.xblayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                    if (feature == null)
                    {
                        GC.Collect();
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        cursor = this.xblayer.FeatureClass.Search(filter, false);
                        feature = cursor.NextFeature();
                        if (feature == null)
                        {
                            GC.Collect();
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            cursor = this.xblayer.FeatureClass.Search(filter, false);
                            feature = cursor.NextFeature();
                            if (feature == null)
                            {
                            }
                        }
                    }
                }
                GC.Collect();
                while (feature != null)
                {
                    GC.Collect();
                    IGeometry shapeCopy = feature.ShapeCopy;
                    IGeometry other = pFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                    @operator.IsKnownSimple_2 = false;
                    IGeometry geometry3 = null;
                    try
                    {
                        @operator.Simplify();
                        geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        err = "错误来源:" + exception.Source + ",错误描述:" + exception.Message;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    if ((geometry3 != null) && !geometry3.IsEmpty)
                    {
                        if (area == 0.0)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                        else if (area < ((IArea) geometry3).Area)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                    }
                    feature = cursor.NextFeature();
                }
                GC.Collect();
                return feature2;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                err = "错误来源:" + exception.Source + ",错误描述:" + exception.Message;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "源数据字段")
            {
                e.RepositoryItem = this.repositoryItemComboBox1;
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            this.CurrentRow = e.RowHandle;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void InitialDistList()
        {
            try
            {
                TreeListNode node2 = null;
                TreeListNode parentNode = null;
                TreeListNode node4 = null;
                TreeListNode node5 = null;
                this.tListDist.ClearNodes();
                this.tListDist.Columns[0].Width = this.tListDist.Width - 10;
                this.tListDist.Columns[1].Width = 0;
                this.tListDist.OptionsView.ShowRoot = true;
                this.tListDist.SelectImageList = null;
                this.tListDist.OptionsView.ShowButtons = true;
                this.tListDist.TreeLineStyle = LineStyle.None;
                this.tListDist.RowHeight = 20;
                this.tListDist.OptionsBehavior.AutoPopulateColumns = true;
                this.tListDist.OptionsView.AutoWidth = true;
                if (this.tListDist.Columns.Count == 2)
                {
                    this.tListDist.Columns[1].Visible = false;
                }
                if (this.m_CountyLayer != null)
                {
                    this.mCList = this.GetDistValues(this.m_CountyLayer, this.sDistFieldName, "", out this.mCList, out this.mCList2);
                    if (this.mCList.Count != 0)
                    {
                        for (int i = 0; i < this.mCList.Count; i++)
                        {
                            parentNode = this.tListDist.AppendNode(this.mCList[i].ToString(), node5);
                            parentNode.SetValue(0, this.mCList[i].ToString());
                            IFeature feature = this.mCList2[i] as IFeature;
                            parentNode.Tag = feature;
                            parentNode.Expanded = true;
                            int index = feature.Fields.FindField(this.sDistFieldCode);
                            string str = feature.get_Value(index).ToString();
                            this.mTList = this.GetDistValues(this.m_TownLayer, this.sDistFieldName2, this.sDistFieldName + "='" + str + "'", out this.mTList, out this.mTList2);
                            for (int j = 0; j < this.mTList.Count; j++)
                            {
                                node4 = this.tListDist.AppendNode(this.mTList[j].ToString(), parentNode);
                                node4.SetValue(0, this.mTList[j].ToString());
                                IFeature feature2 = this.mTList2[j] as IFeature;
                                node4.Tag = feature2;
                                index = feature2.Fields.FindField(this.sDistFieldCode2);
                                this.mVList = this.GetDistValues(this.m_VillageLayer, this.sDistFieldName3, this.sDistFieldName2 + "='" + feature2.get_Value(index).ToString() + "'", out this.mVList, out this.mVList2);
                                for (int k = 0; k < this.mVList.Count; k++)
                                {
                                    node2 = this.tListDist.AppendNode(this.mVList[k].ToString(), node4);
                                    node2.SetValue(0, this.mVList[k].ToString());
                                    node2.Tag = this.mVList2[k] as IFeature;
                                    node2.Expanded = false;
                                }
                            }
                        }
                    }
                    this.tListDist.Selection.Clear();
                    this.tListDist.FocusedNode = null;
                    this.tListDist.Refresh();
                    this.tListDist.OptionsSelection.Reset();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldGrid()
        {
            try
            {
                this.mFieldTable = new DataTable();
                this.mFieldTable.Clear();
                DataColumn column = new DataColumn("目标数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("目标数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                IFields fields = this.m_EditLayer.FeatureClass.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    DataRow row = this.mFieldTable.NewRow();
                    if ((((fields.get_Field(i).Name != this.m_EditLayer.FeatureClass.OIDFieldName) && (fields.get_Field(i).Name != this.m_EditLayer.FeatureClass.ShapeFieldName)) && (fields.get_Field(i) != this.m_EditLayer.FeatureClass.LengthField)) && (fields.get_Field(i) != this.m_EditLayer.FeatureClass.AreaField))
                    {
                        string str = fields.get_Field(i).Type.ToString().Replace("esriFieldType", "");
                        row[0] = fields.get_Field(i).AliasName + "[" + str + "]";
                        row[1] = fields.get_Field(i).Name;
                        row[2] = "";
                        row[3] = "";
                        this.mFieldTable.Rows.Add(row);
                    }
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mFieldTable;
                this.gridView1.RefreshData();
                this.gridView1.Columns[1].Visible = false;
                this.gridView1.Columns[3].Visible = false;
                this.gridView1.Columns[0].OptionsColumn.AllowEdit = false;
                this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
                this.gridView1.Columns[2].OptionsColumn.AllowEdit = true;
                this.gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "InitialFieldGrid", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldList(IFeatureClass pFeatureClass)
        {
            try
            {
                this.mFieldList = new ArrayList();
                this.repositoryItemComboBox1.Items.Clear();
                this.repositoryItemComboBox1.Items.Add("");
                this.mFieldList.Add("");
                for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
                {
                    if ((pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.OIDFieldName) && (pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.ShapeFieldName))
                    {
                        string str = pFeatureClass.Fields.get_Field(i).Type.ToString().Replace("esriFieldType", "");
                        this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).AliasName + "[" + str + "]");
                        this.mFieldList.Add(pFeatureClass.Fields.get_Field(i).Name);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "InitialFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlPropertyByXB2));
            this.tListDist = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.label1 = new Label();
            this.panelQuery = new Panel();
            this.labelInfo = new Label();
            this.label11 = new Label();
            this.simpleButtonClip = new SimpleButton();
            this.radioGroup1 = new RadioGroup();
            this.splitContainerControl1 = new SplitContainerControl();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panelsel = new Panel();
            this.label3 = new Label();
            this.simpleButtonSelectAll = new SimpleButton();
            this.label4 = new Label();
            this.simpleButtonSelectClear = new SimpleButton();
            this.label2 = new Label();
            this.radioGroup2 = new RadioGroup();
            this.panelGridControl = new Panel();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.tListDist.BeginInit();
            this.panelQuery.SuspendLayout();
            this.radioGroup1.Properties.BeginInit();
            this.splitContainerControl1.BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelsel.SuspendLayout();
            this.radioGroup2.Properties.BeginInit();
            this.panelGridControl.SuspendLayout();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemComboBox1.BeginInit();
            base.SuspendLayout();
            this.tListDist.Appearance.Empty.BackColor = Color.White;
            this.tListDist.Appearance.Empty.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.Empty.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.BackColor = Color.FromArgb(0xe7, 0xf2, 0xfe);
            this.tListDist.Appearance.EvenRow.BackColor2 = Color.White;
            this.tListDist.Appearance.EvenRow.ForeColor = Color.Black;
            this.tListDist.Appearance.EvenRow.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedCell.BackColor = Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedCell.BackColor2 = Color.LightCyan;
            this.tListDist.Appearance.FocusedCell.ForeColor = Color.Black;
            this.tListDist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedRow.BackColor = Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedRow.BackColor2 = Color.LightCyan;
            this.tListDist.Appearance.FocusedRow.ForeColor = Color.White;
            this.tListDist.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FooterPanel.BackColor = Color.FromArgb(0xdd, 0xec, 0xfe);
            this.tListDist.Appearance.FooterPanel.BackColor2 = Color.FromArgb(0x84, 0xab, 0xe4);
            this.tListDist.Appearance.FooterPanel.BorderColor = Color.FromArgb(0xdd, 0xec, 0xfe);
            this.tListDist.Appearance.FooterPanel.ForeColor = Color.Black;
            this.tListDist.Appearance.FooterPanel.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupButton.BackColor = Color.FromArgb(0xc1, 0xd8, 0xf7);
            this.tListDist.Appearance.GroupButton.BorderColor = Color.FromArgb(0xc1, 0xd8, 0xf7);
            this.tListDist.Appearance.GroupButton.ForeColor = Color.Black;
            this.tListDist.Appearance.GroupButton.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupFooter.BackColor = Color.FromArgb(0xc1, 0xd8, 0xf7);
            this.tListDist.Appearance.GroupFooter.BorderColor = Color.FromArgb(0xc1, 0xd8, 0xf7);
            this.tListDist.Appearance.GroupFooter.ForeColor = Color.Black;
            this.tListDist.Appearance.GroupFooter.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListDist.Appearance.HeaderPanel.BackColor = Color.FromArgb(0xdd, 0xec, 0xfe);
            this.tListDist.Appearance.HeaderPanel.BackColor2 = Color.FromArgb(0x84, 0xab, 0xe4);
            this.tListDist.Appearance.HeaderPanel.BorderColor = Color.FromArgb(0xdd, 0xec, 0xfe);
            this.tListDist.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.tListDist.Appearance.HeaderPanel.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.HideSelectionRow.BackColor = Color.FromArgb(0x6a, 0x99, 0xe4);
            this.tListDist.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(0xd0, 0xe0, 0xfb);
            this.tListDist.Appearance.HideSelectionRow.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDist.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDist.Appearance.HorzLine.BackColor = Color.FromArgb(0x63, 0x7f, 0xc4);
            this.tListDist.Appearance.HorzLine.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.BackColor = Color.White;
            this.tListDist.Appearance.OddRow.ForeColor = Color.Black;
            this.tListDist.Appearance.OddRow.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.OddRow.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.Options.UseForeColor = true;
            this.tListDist.Appearance.Preview.BackColor = Color.FromArgb(0xf9, 0xfc, 0xff);
            this.tListDist.Appearance.Preview.ForeColor = Color.FromArgb(0x58, 0x81, 0xb9);
            this.tListDist.Appearance.Preview.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.Preview.Options.UseBackColor = true;
            this.tListDist.Appearance.Preview.Options.UseForeColor = true;
            this.tListDist.Appearance.Row.BackColor = Color.White;
            this.tListDist.Appearance.Row.ForeColor = Color.Black;
            this.tListDist.Appearance.Row.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.Row.Options.UseBackColor = true;
            this.tListDist.Appearance.Row.Options.UseForeColor = true;
            this.tListDist.Appearance.SelectedRow.BackColor = Color.FromArgb(0x45, 0x7e, 0xd9);
            this.tListDist.Appearance.SelectedRow.BackColor2 = Color.White;
            this.tListDist.Appearance.SelectedRow.ForeColor = Color.White;
            this.tListDist.Appearance.SelectedRow.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.TreeLine.BackColor = Color.FromArgb(0x3b, 0x61, 0x9c);
            this.tListDist.Appearance.TreeLine.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListDist.Appearance.VertLine.BackColor = Color.FromArgb(0x63, 0x7f, 0xc4);
            this.tListDist.Appearance.VertLine.GradientMode = LinearGradientMode.Vertical;
            this.tListDist.Appearance.VertLine.Options.UseBackColor = true;
            this.tListDist.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2 });
            this.tListDist.CustomizationFormBounds = new Rectangle(0x10d, 370, 0xd0, 0xa3);
            this.tListDist.Dock = DockStyle.Fill;
            this.tListDist.Location = new System.Drawing.Point(0, 0x1c);
            this.tListDist.LookAndFeel.SkinName = "Blue";
            this.tListDist.Name = "tListDist";
            this.tListDist.BeginUnboundLoad();
            object[] nodeData = new object[2];
            this.tListDist.AppendNode(nodeData, -1);
            object[] nodeData2 = new object[2];
            this.tListDist.AppendNode(nodeData2, -1);
            this.tListDist.EndUnboundLoad();
            this.tListDist.OptionsBehavior.Editable = false;
            this.tListDist.OptionsView.ShowColumns = false;
            this.tListDist.OptionsView.ShowHorzLines = false;
            this.tListDist.OptionsView.ShowIndicator = false;
            this.tListDist.OptionsView.ShowVertLines = false;
            this.tListDist.Size = new Size(160, 0x102);
            this.tListDist.TabIndex = 0x4e;
            this.tListDist.TreeLineStyle = LineStyle.None;
            this.tListDist.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tListDist_FocusedNodeChanged);
            this.tListDist.MouseDoubleClick += new MouseEventHandler(this.tListDist_MouseDoubleClick);
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "设备号";
            this.treeListColumn1.MinWidth = 100;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 100;
            this.treeListColumn2.Caption = "定位";
            this.treeListColumn2.FieldName = "定位";
            this.treeListColumn2.MinWidth = 10;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 10;
            this.label1.Dock = DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(160, 0x1c);
            this.label1.TabIndex = 80;
            this.label1.Text = "区划范围 :";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.panelQuery.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.panelQuery.Controls.Add(this.labelInfo);
            this.panelQuery.Controls.Add(this.label11);
            this.panelQuery.Controls.Add(this.simpleButtonClip);
            this.panelQuery.Dock = DockStyle.Bottom;
            this.panelQuery.Location = new System.Drawing.Point(6, 0x17b);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Padding = new Padding(6, 6, 0, 0);
            this.panelQuery.Size = new Size(360, 0x22);
            this.panelQuery.TabIndex = 0x54;
            this.labelInfo.Dock = DockStyle.Top;
            this.labelInfo.Location = new System.Drawing.Point(6, 6);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(0x10c, 30);
            this.labelInfo.TabIndex = 0x51;
            this.labelInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.label11.BackColor = Color.Transparent;
            this.label11.Dock = DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(0x112, 6);
            this.label11.Name = "label11";
            this.label11.Size = new Size(6, 0x1c);
            this.label11.TabIndex = 11;
            this.simpleButtonClip.Dock = DockStyle.Right;
            this.simpleButtonClip.Image = (Image) resources.GetObject("simpleButtonClip.Image");
            this.simpleButtonClip.Location = new System.Drawing.Point(280, 6);
            this.simpleButtonClip.Name = "simpleButtonClip";
            this.simpleButtonClip.Size = new Size(80, 0x1c);
            this.simpleButtonClip.TabIndex = 0;
            this.simpleButtonClip.Text = "获取属性";
            this.simpleButtonClip.ToolTip = "获取所在二类小班属性信息";
            this.simpleButtonClip.Click += new EventHandler(this.simpleButtonClip_Click);
            this.radioGroup1.Dock = DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(4, 4);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "编辑图层所有班块"), new RadioGroupItem(null, "区划范围内班块"), new RadioGroupItem(null, "编辑图层选中班块") });
            this.radioGroup1.Size = new Size(160, 0x4b);
            this.radioGroup1.TabIndex = 0x55;
            this.radioGroup1.SelectedIndexChanged += new EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.splitContainerControl1.BorderStyle = BorderStyles.Default;
            this.splitContainerControl1.Dock = DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(6, 6);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.radioGroup1);
            this.splitContainerControl1.Panel1.Padding = new Padding(4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel2.Controls.Add(this.radioGroup2);
            this.splitContainerControl1.Panel2.Padding = new Padding(4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new Size(360, 0x175);
            this.splitContainerControl1.SplitterPosition = 0xa8;
            this.splitContainerControl1.TabIndex = 0x57;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.panel1.Controls.Add(this.tListDist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 0x4f);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(160, 0x11e);
            this.panel1.TabIndex = 0x56;
            this.panel2.Controls.Add(this.panelGridControl);
            this.panel2.Controls.Add(this.panelsel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 0x33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0xae, 0x13a);
            this.panel2.TabIndex = 0x57;
            this.panelsel.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.panelsel.Controls.Add(this.label3);
            this.panelsel.Controls.Add(this.simpleButtonSelectAll);
            this.panelsel.Controls.Add(this.label4);
            this.panelsel.Controls.Add(this.simpleButtonSelectClear);
            this.panelsel.Dock = DockStyle.Bottom;
            this.panelsel.Location = new System.Drawing.Point(0, 0x11c);
            this.panelsel.Name = "panelsel";
            this.panelsel.Padding = new Padding(4, 4, 0, 0);
            this.panelsel.Size = new Size(0xae, 30);
            this.panelsel.TabIndex = 0x55;
            this.label3.Dock = DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(0x18, 4);
            this.label3.Name = "label3";
            this.label3.Size = new Size(4, 0x1a);
            this.label3.TabIndex = 0x51;
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.simpleButtonSelectAll.Dock = DockStyle.Right;
            this.simpleButtonSelectAll.Location = new System.Drawing.Point(0x1c, 4);
            this.simpleButtonSelectAll.Name = "simpleButtonSelectAll";
            this.simpleButtonSelectAll.Size = new Size(70, 0x1a);
            this.simpleButtonSelectAll.TabIndex = 0;
            this.simpleButtonSelectAll.Text = "自动匹配";
            this.simpleButtonSelectAll.Click += new EventHandler(this.simpleButtonSelectAll_Click);
            this.label4.BackColor = Color.Transparent;
            this.label4.Dock = DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(0x62, 4);
            this.label4.Name = "label4";
            this.label4.Size = new Size(6, 0x1a);
            this.label4.TabIndex = 11;
            this.simpleButtonSelectClear.Dock = DockStyle.Right;
            this.simpleButtonSelectClear.Location = new System.Drawing.Point(0x68, 4);
            this.simpleButtonSelectClear.Name = "simpleButtonSelectClear";
            this.simpleButtonSelectClear.Size = new Size(70, 0x1a);
            this.simpleButtonSelectClear.TabIndex = 0x52;
            this.simpleButtonSelectClear.Text = "清空";
            this.simpleButtonSelectClear.Click += new EventHandler(this.simpleButtonSelectClear_Click);
            this.label2.Dock = DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xae, 0x1c);
            this.label2.TabIndex = 0x51;
            this.label2.Text = "属性字段列表 :";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.radioGroup2.Dock = DockStyle.Top;
            this.radioGroup2.Location = new System.Drawing.Point(4, 4);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = Color.Transparent;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "自动读取小班属性值"), new RadioGroupItem(null, "指定读取小班字段") });
            this.radioGroup2.Size = new Size(0xae, 0x2f);
            this.radioGroup2.TabIndex = 0x56;
            this.radioGroup2.SelectedIndexChanged += new EventHandler(this.radioGroup2_SelectedIndexChanged);
            this.panelGridControl.BackColor = Color.Transparent;
            this.panelGridControl.Controls.Add(this.gridControl1);
            this.panelGridControl.Dock = DockStyle.Fill;
            this.panelGridControl.Location = new System.Drawing.Point(0, 0x1c);
            this.panelGridControl.Name = "panelGridControl";
            this.panelGridControl.Padding = new Padding(0, 2, 0, 6);
            this.panelGridControl.Size = new Size(0xae, 0x100);
            this.panelGridControl.TabIndex = 0x56;
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox1 });
            this.gridControl1.Size = new Size(0xae, 0xf8);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn1, this.gridColumn2 });
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomRowCellEdit += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.KeyPress += new KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridColumn1.Caption = "目标属性字段";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn2.Caption = "匹配源属性字段";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.SelectedIndexChanged += new EventHandler(this.repositoryItemComboBox1_SelectedIndexChanged);
            this.repositoryItemComboBox1.MouseUp += new MouseEventHandler(this.repositoryItemComboBox1_MouseUp);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.splitContainerControl1);
            base.Controls.Add(this.panelQuery);
            base.Name = "UserControlPropertyByXB2";
            base.Padding = new Padding(6);
            base.Size = new Size(0x174, 0x1a3);
            this.tListDist.EndInit();
            this.panelQuery.ResumeLayout(false);
            this.radioGroup1.Properties.EndInit();
            this.splitContainerControl1.EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelsel.ResumeLayout(false);
            this.radioGroup2.Properties.EndInit();
            this.panelGridControl.ResumeLayout(false);
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemComboBox1.EndInit();
            base.ResumeLayout(false);
        }

        public void InitialValue(IHookHelper hookhelper, string sEditKind)
        {
            try
            {
                this.mHookHelper = hookhelper;
                this.m_EditLayer = EditTask.EditLayer;
                IMap focusMap = this.mHookHelper.FocusMap;
                this.mFeatureWorkspace = EditTask.EditWorkspace;
                if (this.mFeatureWorkspace != null)
                {
                    this.mEditKind = sEditKind;
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    this.xblayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                    this.sDistLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.sDistLayerName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                    this.sDistLayerName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                    this.sDistFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldName");
                    this.sDistFieldCode = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                    this.sDistFieldName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                    this.sDistFieldCode2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                    this.sDistFieldName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldName");
                    this.sDistFieldCode3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                    this.m_CountyLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, this.sDistLayerName, true);
                    if (this.m_CountyLayer != null)
                    {
                        this.m_TownLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, this.sDistLayerName2, true);
                        if (this.m_TownLayer != null)
                        {
                            this.m_VillageLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, this.sDistLayerName3, true);
                            if (this.m_VillageLayer != null)
                            {
                                this.InitialDistList();
                                this.InitialFieldGrid();
                                IFeatureClass featureClass = this.xblayer.FeatureClass;
                                this.SetFieldMatch(featureClass);
                                this.InitialFieldList(featureClass);
                                this.radioGroup1.SelectedIndex = 0;
                                this.radioGroup2.SelectedIndex = 0;
                                if (this.radioGroup1.SelectedIndex == 0)
                                {
                                    this.panelsel.Enabled = false;
                                }
                                else
                                {
                                    this.panelsel.Enabled = true;
                                }
                                if (this.radioGroup2.SelectedIndex == 0)
                                {
                                    this.panel2.Enabled = false;
                                }
                                else
                                {
                                    this.panel2.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 1)
            {
                this.panel1.Enabled = true;
            }
            else
            {
                this.panel1.Enabled = false;
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup2.SelectedIndex == 0)
            {
                this.panel2.Enabled = false;
                this.panelsel.Enabled = false;
                this.simpleButtonSelectAll.Enabled = false;
                this.simpleButtonSelectClear.Enabled = false;
                this.panelGridControl.Enabled = false;
            }
            else
            {
                this.panel2.Enabled = true;
                this.panelsel.Enabled = true;
                this.simpleButtonSelectAll.Enabled = true;
                this.simpleButtonSelectClear.Enabled = true;
                this.panelGridControl.Enabled = true;
            }
        }

        private void repositoryItemComboBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboxSelectIndex = (sender as ComboBoxEdit).SelectedIndex;
            if ((this.CurrentRow > -1) && (this.ComboxSelectIndex > -1))
            {
                this.mFieldTable.Rows[this.CurrentRow]["源数据字段"] = this.repositoryItemComboBox1.Items[this.ComboxSelectIndex].ToString();
                this.mFieldTable.Rows[this.CurrentRow]["源数据字段2"] = this.mFieldList[this.ComboxSelectIndex].ToString();
            }
        }

        private void SetFeatureArea(IFeature pFeature)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        double area = ((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area;
                        string str = EditTask.KindCode.Substring(0, 2);
                        string name = "";
                        string str3 = "";
                        string str4 = "";
                        if (str == "01")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Afforest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "02")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Harvest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "06")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Disaster";
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "07")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "ForestCase";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "04")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 4);
                            name = "Expropriation";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "05")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Fire";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        }
                        int index = pFeature.Fields.FindField(str3);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        index = pFeature.Fields.FindField(str4);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        pFeature.Store();
                    }
                }
                catch
                {
                }
            }
        }

        private void SetFieldMatch(IFeatureClass pSFeatureClass)
        {
            try
            {
                IFeatureClass featureClass = this.m_EditLayer.FeatureClass;
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                {
                    IField field = featureClass.Fields.get_Field(i);
                    int index = pSFeatureClass.Fields.FindField(field.Name);
                    if ((index == -1) && (field.Name.Length > 10))
                    {
                        index = pSFeatureClass.Fields.FindField(field.Name.Substring(0, 10));
                    }
                    if (index != -1)
                    {
                        IField field2 = pSFeatureClass.Fields.get_Field(index);
                        if (field2.Type == field.Type)
                        {
                            DataRow[] rowArray = this.mFieldTable.Select("目标数据字段2='" + field.Name + "'");
                            if (rowArray.Length > 0)
                            {
                                string str = field2.Type.ToString().Replace("esriFieldType", "");
                                rowArray[0]["源数据字段"] = field2.AliasName + "[" + str + "]";
                                rowArray[0]["源数据字段2"] = field2.Name;
                            }
                        }
                    }
                }
                this.gridView1.RefreshData();
                this.simpleButtonSelectClear.Enabled = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "SetFieldMatch", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 获取属性的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonClip_Click(object sender, EventArgs e)
        {
            Exception exception;
            try
            {
                if ((this.radioGroup1.SelectedIndex != 1) || (this.tListDist.Selection.Count != 0))
                {
                    IWorkspaceEdit mFeatureWorkspace = this.mFeatureWorkspace as IWorkspaceEdit;
                    this.Cursor = Cursors.WaitCursor;
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    IFeatureCursor cursor = null;
                    IFeature pFeature = null;
                    int count = 0;
                    if (this.radioGroup1.SelectedIndex == 0)
                    {
                        count = this.m_EditLayer.FeatureClass.FeatureCount(null);
                        cursor = this.m_EditLayer.FeatureClass.Search(null, false);
                        pFeature = cursor.NextFeature();
                    }
                    else if (this.radioGroup1.SelectedIndex == 1)
                    {
                        IFeature tag = this.tListDist.Selection[0].Tag as IFeature;
                        if (tag == null)
                        {
                            MessageBox.Show("请先选择区划范围", "获取小班属性", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        IGeometry shapeCopy = tag.ShapeCopy;
                        queryFilter.Geometry = shapeCopy;
                        queryFilter.GeometryField = this.m_EditLayer.FeatureClass.ShapeFieldName;
                        queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        GC.Collect();
                        count = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        GC.Collect();
                        cursor = this.m_EditLayer.FeatureClass.Search(queryFilter, false);
                        pFeature = cursor.NextFeature();
                    }
                    else if (this.radioGroup1.SelectedIndex == 2)
                    {
                        IFeatureSelection editLayer = this.m_EditLayer as IFeatureSelection;
                        if (editLayer == null)
                        {
                            MessageBox.Show("获取选择集失败", "属性获取", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        ISelectionSet selectionSet = editLayer.SelectionSet;
                        ITable target = selectionSet.Target;
                        ICursor cursor2 = null;
                        selectionSet.Search(null, false, out cursor2);
                        cursor = cursor2 as IFeatureCursor;
                        count = selectionSet.Count;
                        pFeature = cursor.NextFeature();
                    }
                    if (pFeature == null)
                    {
                        this.labelInfo.Text = "无指定范围内" + this.mEditKind + "班块";
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.labelInfo.Text = string.Concat(new object[] { "指定范围内", this.mEditKind, "班块共计", count, "个" });
                        int num2 = 0;
                        int num3 = 0;
                        List<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                        List<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                        Editor.UniqueInstance.StopEdit2();
                        Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                        int num4 = 0;
                        bool flag2 = true;
                        string err = "";
                        while (pFeature != null)
                        {
                            Process process;
                            ProcessStartInfo info;
                            num2++;
                            num3++;
                            GC.Collect();
                            Application.DoEvents();
                            this.labelInfo.Text = string.Concat(new object[] { "获取第", num2, "个", this.mEditKind, "班块,共计", count, "个" });
                            IFeature xBFeature = this.GetXBFeature(pFeature, out err);
                            GC.Collect();
                            if (xBFeature != null)
                            {
                                Editor.UniqueInstance.StartEditOperation();
                                for (int i = 0; i < pFeature.Fields.FieldCount; i++)
                                {
                                    IField field = pFeature.Fields.get_Field(i);
                                    string name = field.Name;
                                    if (this.radioGroup2.SelectedIndex == 1)
                                    {
                                        for (int j = 0; j < this.mFieldTable.Rows.Count; j++)
                                        {
                                            int index = pFeature.Fields.FindField(this.mFieldTable.Rows[j]["目标数据字段2"].ToString());
                                            int num8 = xBFeature.Fields.FindField(this.mFieldTable.Rows[j]["源数据字段2"].ToString());
                                            if ((index != -1) && (num8 != -1))
                                            {
                                                pFeature.set_Value(index, xBFeature.get_Value(num8));
                                            }
                                        }
                                    }
                                    else if ((this.radioGroup2.SelectedIndex == 0) && (pFeature.get_Value(i).ToString().Trim() == ""))
                                    {
                                        int num10;
                                        if (list2.Contains(name))
                                        {
                                            int num9 = list2.IndexOf(name);
                                            name = list[num9];
                                            num10 = xBFeature.Fields.FindField(name);
                                            if (num10 > -1)
                                            {
                                                pFeature.set_Value(i, xBFeature.get_Value(num10));
                                            }
                                        }
                                        else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                        {
                                            num10 = xBFeature.Fields.FindField(field.Name);
                                            if (num10 > -1)
                                            {
                                                pFeature.set_Value(i, xBFeature.get_Value(num10));
                                            }
                                        }
                                    }
                                }
                                GC.Collect();
                                try
                                {
                                    Editor.UniqueInstance.AddAttribute = false;
                                    pFeature.Store();
                                    Editor.UniqueInstance.AddAttribute = true;
                                    try
                                    {
                                        Editor.UniqueInstance.StopEditOperation();
                                    }
                                    catch (Exception exception1)
                                    {
                                        exception = exception1;
                                        Editor.UniqueInstance.StopEditOperation();
                                    }
                                    num4++;
                                    if (num4 >= 50)
                                    {
                                        flag2 = Editor.UniqueInstance.StopEdit2();
                                        try
                                        {
                                            if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                                            {
                                                process = new Process();
                                                info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                                process.StartInfo = info;
                                                process.StartInfo.UseShellExecute = false;
                                                process.Start();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        num4 = 0;
                                        Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                                        GC.Collect();
                                    }
                                    Application.DoEvents();
                                }
                                catch (Exception exception3)
                                {
                                    exception = exception3;
                                    this.labelInfo.Text = this.labelInfo.Text + "\n[失败:错误来源" + exception.Source + "错误描述" + exception.Message + "]";
                                    Editor.UniqueInstance.AddAttribute = false;
                                    pFeature.Store();
                                    Editor.UniqueInstance.AddAttribute = true;
                                }
                            }
                            else if ((xBFeature == null) && (err != ""))
                            {
                                MessageBox.Show("计算所在二类小班信息失败", err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Editor.UniqueInstance.StopEdit();
                                Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                                this.labelInfo.Text = "获取二类小班属性信息操作中断";
                                this.Cursor = Cursors.Default;
                                return;
                            }
                            try
                            {
                                if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                                {
                                    process = new Process();
                                    info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                    process.StartInfo = info;
                                    process.StartInfo.UseShellExecute = false;
                                    process.Start();
                                }
                            }
                            catch (Exception)
                            {
                            }
                            pFeature = cursor.NextFeature();
                        }
                        Editor.UniqueInstance.StopEdit();
                        Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                        this.labelInfo.Text = "获取二类小班属性信息完成";
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception exception5)
            {
                exception = exception5;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlPropertyByXB", "simpleButtonClip_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButtonSelectAll_Click(object sender, EventArgs e)
        {
            this.InitialFieldGrid();
            this.SetFieldMatch(this.xblayer.FeatureClass);
        }

        private void simpleButtonSelectClear_Click(object sender, EventArgs e)
        {
            this.InitialFieldGrid();
        }

        private void tListDist_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        private void tListDist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.tListDist.Selection.Count == 1)
                {
                    IFeature tag = this.tListDist.Selection[0].Tag as IFeature;
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, tag);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

