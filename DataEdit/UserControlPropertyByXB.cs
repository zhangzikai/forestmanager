namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
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
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlPropertyByXB : UserControlBase1
    {
        private CheckedListBoxControl checkedListBox;
        private IContainer components = null;
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
        private IHookHelper mHookHelper;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mVList;
        private ArrayList mVList2;
        private Panel panel1;
        private Panel panel2;
        private Panel panelQuery;
        private Panel panelsel;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
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

        public UserControlPropertyByXB()
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

        private void InitialFieldList()
        {
            try
            {
                this.mFieldList = new ArrayList();
                this.checkedListBox.Items.Clear();
                IFeature feature = this.xblayer.Search(null, false).NextFeature();
                for (int i = 0; i < feature.Fields.FieldCount; i++)
                {
                    IField field = feature.Fields.get_Field(i);
                    if (((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name)) && this.CheckHasField(field.Name))
                    {
                        this.checkedListBox.Items.Add(field.AliasName + "[" + field.Name + "]");
                        this.mFieldList.Add(field);
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
            this.tListDist = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.simpleButtonClip = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panelsel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButtonSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButtonSelectClear = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).BeginInit();
            this.panelQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox)).BeginInit();
            this.panelsel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tListDist
            // 
            this.tListDist.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Empty.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.EvenRow.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDist.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDist.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tListDist.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListDist.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.tListDist.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDist.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDist.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDist.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.OddRow.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.Options.UseForeColor = true;
            this.tListDist.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.tListDist.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.tListDist.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Preview.Options.UseBackColor = true;
            this.tListDist.Appearance.Preview.Options.UseForeColor = true;
            this.tListDist.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Row.Options.UseBackColor = true;
            this.tListDist.Appearance.Row.Options.UseForeColor = true;
            this.tListDist.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.tListDist.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.tListDist.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tListDist.Appearance.TreeLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListDist.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDist.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.VertLine.Options.UseBackColor = true;
            this.tListDist.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tListDist.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDist.Location = new System.Drawing.Point(0, 28);
            this.tListDist.LookAndFeel.SkinName = "Blue";
            this.tListDist.Name = "tListDist";
            this.tListDist.BeginUnboundLoad();
            this.tListDist.AppendNode(new object[] {
            null,
            null}, -1);
            this.tListDist.AppendNode(new object[] {
            null,
            null}, -1);
            this.tListDist.EndUnboundLoad();
            this.tListDist.OptionsBehavior.Editable = false;
            this.tListDist.OptionsView.ShowColumns = false;
            this.tListDist.OptionsView.ShowHorzLines = false;
            this.tListDist.OptionsView.ShowIndicator = false;
            this.tListDist.OptionsView.ShowVertLines = false;
            this.tListDist.Size = new System.Drawing.Size(160, 258);
            this.tListDist.TabIndex = 78;
            this.tListDist.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDist.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListDist_FocusedNodeChanged);
            this.tListDist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tListDist_MouseDoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "设备号";
            this.treeListColumn1.MinWidth = 100;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 100;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "定位";
            this.treeListColumn2.FieldName = "定位";
            this.treeListColumn2.MinWidth = 16;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 10;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 28);
            this.label1.TabIndex = 80;
            this.label1.Text = "区划范围 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelQuery
            // 
            this.panelQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelQuery.Controls.Add(this.labelInfo);
            this.panelQuery.Controls.Add(this.label11);
            this.panelQuery.Controls.Add(this.simpleButtonClip);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQuery.Location = new System.Drawing.Point(6, 379);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.panelQuery.Size = new System.Drawing.Size(360, 34);
            this.panelQuery.TabIndex = 84;
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInfo.Location = new System.Drawing.Point(6, 6);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(268, 30);
            this.labelInfo.TabIndex = 81;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(274, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(6, 28);
            this.label11.TabIndex = 11;
            // 
            // simpleButtonClip
            // 
            this.simpleButtonClip.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClip.Location = new System.Drawing.Point(280, 6);
            this.simpleButtonClip.Name = "simpleButtonClip";
            this.simpleButtonClip.Size = new System.Drawing.Size(80, 28);
            this.simpleButtonClip.TabIndex = 0;
            this.simpleButtonClip.Text = "获取属性";
            this.simpleButtonClip.ToolTip = "获取所在二类小班属性信息";
            this.simpleButtonClip.Click += new System.EventHandler(this.simpleButtonClip_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(4, 4);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "编辑图层所有班块"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "区划范围内班块"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "编辑图层选中班块")});
            this.radioGroup1.Size = new System.Drawing.Size(160, 75);
            this.radioGroup1.TabIndex = 85;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(6, 6);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.radioGroup1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel2.Controls.Add(this.radioGroup2);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(360, 373);
            this.splitContainerControl1.SplitterPosition = 168;
            this.splitContainerControl1.TabIndex = 87;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tListDist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 286);
            this.panel1.TabIndex = 86;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkedListBox);
            this.panel2.Controls.Add(this.panelsel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 314);
            this.panel2.TabIndex = 87;
            // 
            // checkedListBox
            // 
            this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox.Location = new System.Drawing.Point(0, 28);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(175, 256);
            this.checkedListBox.TabIndex = 82;
            // 
            // panelsel
            // 
            this.panelsel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelsel.Controls.Add(this.label3);
            this.panelsel.Controls.Add(this.simpleButtonSelectAll);
            this.panelsel.Controls.Add(this.label4);
            this.panelsel.Controls.Add(this.simpleButtonSelectClear);
            this.panelsel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelsel.Location = new System.Drawing.Point(0, 284);
            this.panelsel.Name = "panelsel";
            this.panelsel.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.panelsel.Size = new System.Drawing.Size(175, 30);
            this.panelsel.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(25, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(4, 26);
            this.label3.TabIndex = 81;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonSelectAll
            // 
            this.simpleButtonSelectAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelectAll.Location = new System.Drawing.Point(29, 4);
            this.simpleButtonSelectAll.Name = "simpleButtonSelectAll";
            this.simpleButtonSelectAll.Size = new System.Drawing.Size(70, 26);
            this.simpleButtonSelectAll.TabIndex = 0;
            this.simpleButtonSelectAll.Text = "全选";
            this.simpleButtonSelectAll.Click += new System.EventHandler(this.simpleButtonSelectAll_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(99, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(6, 26);
            this.label4.TabIndex = 11;
            // 
            // simpleButtonSelectClear
            // 
            this.simpleButtonSelectClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelectClear.Location = new System.Drawing.Point(105, 4);
            this.simpleButtonSelectClear.Name = "simpleButtonSelectClear";
            this.simpleButtonSelectClear.Size = new System.Drawing.Size(70, 26);
            this.simpleButtonSelectClear.TabIndex = 82;
            this.simpleButtonSelectClear.Text = "清空";
            this.simpleButtonSelectClear.Click += new System.EventHandler(this.simpleButtonSelectClear_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 28);
            this.label2.TabIndex = 81;
            this.label2.Text = "小班属性列表 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup2.Location = new System.Drawing.Point(4, 4);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "自动读取小班属性值"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定读取小班字段")});
            this.radioGroup2.Size = new System.Drawing.Size(175, 47);
            this.radioGroup2.TabIndex = 86;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            // 
            // UserControlPropertyByXB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelQuery);
            this.Name = "UserControlPropertyByXB";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(372, 419);
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).EndInit();
            this.panelQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox)).EndInit();
            this.panelsel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.ResumeLayout(false);

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
                                this.InitialFieldList();
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
            }
            else
            {
                this.panel2.Enabled = true;
                this.panelsel.Enabled = true;
                this.simpleButtonSelectAll.Enabled = true;
                this.simpleButtonSelectClear.Enabled = true;
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
                                    int index;
                                    int num8;
                                    IField field = pFeature.Fields.get_Field(i);
                                    string name = field.Name;
                                    if (this.radioGroup2.SelectedIndex == 1)
                                    {
                                        for (int j = 0; j < this.mFieldList.Count; j++)
                                        {
                                            if (((this.mFieldList[j] as IField).Name == name) && (this.checkedListBox.Items[j].CheckState == CheckState.Checked))
                                            {
                                                if (list2.Contains(name))
                                                {
                                                    index = list2.IndexOf(name);
                                                    name = list[index];
                                                    num8 = xBFeature.Fields.FindField(name);
                                                    if (num8 > -1)
                                                    {
                                                        pFeature.set_Value(i, xBFeature.get_Value(num8));
                                                    }
                                                }
                                                else
                                                {
                                                    num8 = xBFeature.Fields.FindField(field.Name);
                                                    if (num8 > -1)
                                                    {
                                                        pFeature.set_Value(i, xBFeature.get_Value(num8));
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else if ((this.radioGroup2.SelectedIndex == 0) && (pFeature.get_Value(i).ToString().Trim() == ""))
                                    {
                                        if (list2.Contains(name))
                                        {
                                            index = list2.IndexOf(name);
                                            name = list[index];
                                            num8 = xBFeature.Fields.FindField(name);
                                            if (num8 > -1)
                                            {
                                                pFeature.set_Value(i, xBFeature.get_Value(num8));
                                            }
                                        }
                                        else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                        {
                                            num8 = xBFeature.Fields.FindField(field.Name);
                                            if (num8 > -1)
                                            {
                                                pFeature.set_Value(i, xBFeature.get_Value(num8));
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
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                this.checkedListBox.Items[i].CheckState = CheckState.Checked;
            }
        }

        private void simpleButtonSelectClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                this.checkedListBox.Items[i].CheckState = CheckState.Unchecked;
            }
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

