namespace DataEdit
{
    using AttributesEdit;
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
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 批量数据裁剪：窗体
    /// </summary>
    public class UserControlClipByXB : UserControlBase1
    {
        private CheckEdit checkEditDelete;
        private CheckEdit checkEditMiniArea;
        private CheckEdit checkEditXB;
        private IContainer components = null;
        private Label label1;
        private Label label11;
        private Label labelInfo;
        private ITable m_CityTable;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureClass m_EditFeatureClass;
        private IFeatureClass m_EditFeatureClass2;
        private IFeatureClass m_EditFeatureClass3;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private IFeatureLayer m_QueryLayer2;
        private IFeatureLayer m_QueryLayer3;
        private ITable m_QueryTable;
        private ITable m_QueryTable2;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private ArrayList mCFList;
        private const string mClassName = "DataEdit.UserControlClipByXB";
        private ArrayList mCList;
        private ArrayList mCList2;
      
        private string mEditKind;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private ArrayList mForList = null;
        private IHookHelper mHookHelper;
        private ArrayList mKindList = null;
        private DataTable mKindTable;
        private ArrayList mLandList = null;
        private ArrayList mLList;
        private ArrayList mLList2;
        private ArrayList mQueryList = null;
        private ArrayList mRangeList = null;
        private ArrayList mRightList = null;
        private ArrayList mRightList2 = null;
        private ArrayList mRightList3 = null;
        private ArrayList mRightList4 = null;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mTreeList = null;
        private ArrayList mVList;
        private ArrayList mVList2;
        private ArrayList mXList;
        private ArrayList mXList2;
        private ArrayList mZLList;
        private Panel panel1;
        private Panel panelQuery;
        private Panel panelSetXB;
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
        internal TreeList tListDist;
        internal TreeListColumn treeListColumn1;
        internal TreeListColumn treeListColumn2;
        private IFeatureLayer xblayer;

        /// <summary>
        /// 批量数据裁剪：窗体：构造器
        /// </summary>
        public UserControlClipByXB()
        {
            this.InitializeComponent();
        }

        private void checkEditXB_CheckedChanged(object sender, EventArgs e)
        {
            this.radioGroup2.Enabled = this.checkEditXB.Checked;
        }

        /// <summary>
        /// 裁剪小班创建要素
        /// </summary>
        /// <param name="pFCursor"></param>
        /// <param name="pf"></param>
        /// <param name="pFeature"></param>
        /// <returns></returns>
        private bool ClipXBCreateFeature(IFeatureCursor pFCursor, IFeature pf, IFeature pFeature)
        {
            Exception exception;
            try
            {
                bool flag = false;
                while (pf != null)
                {
                    GC.Collect();
                    IGeometry shapeCopy = pf.ShapeCopy;
                    IGeometry other = pFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    try
                    {
                        ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                        if (!geometry3.IsEmpty)
                        {
                            ITopologicalOperator2 operator2 = geometry3 as ITopologicalOperator2;
                            operator2.IsKnownSimple_2 = false;
                            operator2.Simplify();
                            ITopologicalOperator2 operator3 = shapeCopy as ITopologicalOperator2;
                            IGeometry pGeometry = geometry3;
                            if (!this.checkEditMiniArea.Checked || (((IArea) GISFunFactory.UnitFun.ConvertPoject(pGeometry, this.mHookHelper.FocusMap.SpatialReference)).Area > 667.0))
                            {
                                int num2;
                                int num3;
                                pGeometry = geometry3;
                                Editor.UniqueInstance.StartEditOperation();
                                Editor.UniqueInstance.AddAttribute = false;
                                IFeature feature = this.m_EditLayer.FeatureClass.CreateFeature();
                                feature.Shape = pGeometry;
                                if (this.checkEditXB.Checked)
                                {
                                    if (this.radioGroup2.SelectedIndex == 1)
                                    {
                                        AttriEdit.SetAttributes(feature, this.mHookHelper.Hook, this.checkEditXB.Checked);
                                        GC.Collect();
                                    }
                                    else if (this.radioGroup2.SelectedIndex == 0)
                                    {
                                        IFeature xBFeature = this.GetXBFeature(feature);
                                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanFieldName");
                                        if (!configValue.ToUpper().Contains("SHENG"))
                                        {
                                            configValue = "SHENG," + configValue;
                                        }
                                        string[] strArray = configValue.Split(new char[] { ',' });
                                        num2 = 0;
                                        while (num2 < strArray.Length)
                                        {
                                            num3 = xBFeature.Fields.FindField(strArray[num2]);
                                            int index = feature.Fields.FindField(strArray[num2]);
                                            try
                                            {
                                                if ((index > -1) && (num3 > -1))
                                                {
                                                    feature.set_Value(index, xBFeature.get_Value(num3));
                                                }
                                            }
                                            catch (Exception)
                                            {
                                            }
                                            num2++;
                                        }
                                        GC.Collect();
                                    }
                                }
                                for (num2 = 0; num2 < feature.Fields.FieldCount; num2++)
                                {
                                    IField field = feature.Fields.get_Field(num2);
                                    if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                    {
                                        num3 = pFeature.Fields.FindField(field.Name);
                                        try
                                        {
                                            if (((num3 > -1) && (feature.get_Value(num2).ToString().Trim() == "")) && (pFeature.get_Value(num3).ToString().Trim() != ""))
                                            {
                                                feature.set_Value(num2, pFeature.get_Value(num3));
                                            }
                                        }
                                        catch (Exception exception2)
                                        {
                                            exception = exception2;
                                            this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                                        }
                                    }
                                }
                                GC.Collect();
                                if (EditTask.TaskID > 0L)
                                {
                                    int num5 = feature.Fields.FindField("XMBH");
                                    if (num5 > -1)
                                    {
                                        feature.set_Value(num5, EditTask.TaskID);
                                    }
                                    num5 = feature.Fields.FindField("Task_ID");
                                    if (num5 > -1)
                                    {
                                        feature.set_Value(num5, EditTask.TaskID);
                                    }
                                }
                                feature.Store();
                                flag = true;
                                Editor.UniqueInstance.AddAttribute = true;
                                this.SetFeatureArea(feature);
                                Editor.UniqueInstance.StopEditOperation();
                                GC.Collect();
                                IGeometry geometry5 = feature.ShapeCopy;
                                geometry5 = GISFunFactory.UnitFun.ConvertPoject(geometry5, this.mHookHelper.FocusMap.SpatialReference);
                                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, this.m_EditLayer, geometry5.Envelope);
                            }
                        }
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    pf = pFCursor.NextFeature();
                }
                return flag;
            }
            catch (Exception exception4)
            {
                exception = exception4;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void DeleteFeature()
        {
            try
            {
                ISpatialFilter filter = new SpatialFilterClass();
                IFeatureCursor cursor = null;
                IFeature feature = null;
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    GC.Collect();
                    cursor = this.m_EditLayer.FeatureClass.Search(null, false);
                    feature = cursor.NextFeature();
                }
                else
                {
                    IFeature tag = this.tListDist.Selection[0].Tag as IFeature;
                    if (tag == null)
                    {
                        MessageBox.Show("请先选择区划范围", "批量裁切", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    IGeometry shape = tag.Shape;
                    filter.Geometry = shape;
                    filter.GeometryField = this.m_EditLayer.FeatureClass.ShapeFieldName;
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    GC.Collect();
                    cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                }
                while (feature != null)
                {
                    Editor.UniqueInstance.StartEditOperation();
                    feature.Delete();
                    Editor.UniqueInstance.StopEditOperation();
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "DeleteFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private IFeature GetXBFeature(IFeature pFeature)
        {
            Exception exception;
            try
            {
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
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlClipByXB));
            this.panelQuery = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.simpleButtonClip = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSetXB = new System.Windows.Forms.Panel();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.checkEditMiniArea = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditDelete = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditXB = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListDist = new DevExpress.XtraTreeList.TreeList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelQuery.SuspendLayout();
            this.panelSetXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMiniArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuery
            // 
            this.panelQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelQuery.Controls.Add(this.labelInfo);
            this.panelQuery.Controls.Add(this.label11);
            this.panelQuery.Controls.Add(this.simpleButtonClip);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQuery.Location = new System.Drawing.Point(6, 383);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.panelQuery.Size = new System.Drawing.Size(344, 38);
            this.panelQuery.TabIndex = 79;
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInfo.Location = new System.Drawing.Point(6, 6);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(255, 26);
            this.labelInfo.TabIndex = 81;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(261, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(5, 26);
            this.label11.TabIndex = 11;
            // 
            // simpleButtonClip
            // 
            this.simpleButtonClip.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClip.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonClip.Image")));
            this.simpleButtonClip.Location = new System.Drawing.Point(266, 6);
            this.simpleButtonClip.Name = "simpleButtonClip";
            this.simpleButtonClip.Size = new System.Drawing.Size(78, 26);
            this.simpleButtonClip.TabIndex = 0;
            this.simpleButtonClip.Text = "裁切";
            this.simpleButtonClip.Click += new System.EventHandler(this.simpleButtonClip_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "区划范围 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSetXB
            // 
            this.panelSetXB.Controls.Add(this.radioGroup2);
            this.panelSetXB.Controls.Add(this.checkEditMiniArea);
            this.panelSetXB.Controls.Add(this.checkEditDelete);
            this.panelSetXB.Controls.Add(this.checkEditXB);
            this.panelSetXB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSetXB.Location = new System.Drawing.Point(6, 309);
            this.panelSetXB.Name = "panelSetXB";
            this.panelSetXB.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panelSetXB.Size = new System.Drawing.Size(344, 74);
            this.panelSetXB.TabIndex = 81;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Location = new System.Drawing.Point(160, 11);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "仅读取区划属性"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "读取小班相关属性信息")});
            this.radioGroup2.Size = new System.Drawing.Size(154, 52);
            this.radioGroup2.TabIndex = 36;
            // 
            // checkEditMiniArea
            // 
            this.checkEditMiniArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditMiniArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkEditMiniArea.Location = new System.Drawing.Point(0, 27);
            this.checkEditMiniArea.Name = "checkEditMiniArea";
            this.checkEditMiniArea.Properties.Caption = "小于1亩的忽略";
            this.checkEditMiniArea.Size = new System.Drawing.Size(344, 19);
            this.checkEditMiniArea.TabIndex = 35;
            // 
            // checkEditDelete
            // 
            this.checkEditDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkEditDelete.Location = new System.Drawing.Point(0, 47);
            this.checkEditDelete.Name = "checkEditDelete";
            this.checkEditDelete.Properties.Caption = "删除原有班块";
            this.checkEditDelete.Size = new System.Drawing.Size(344, 19);
            this.checkEditDelete.TabIndex = 34;
            // 
            // checkEditXB
            // 
            this.checkEditXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkEditXB.EditValue = true;
            this.checkEditXB.Location = new System.Drawing.Point(0, 8);
            this.checkEditXB.Name = "checkEditXB";
            this.checkEditXB.Properties.Caption = "自动读取二类小班信息";
            this.checkEditXB.Size = new System.Drawing.Size(344, 19);
            this.checkEditXB.TabIndex = 33;
            this.checkEditXB.CheckedChanged += new System.EventHandler(this.checkEditXB_CheckedChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(6, 6);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "编辑图层所有班块"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "区划范围内班块")});
            this.radioGroup1.Size = new System.Drawing.Size(344, 30);
            this.radioGroup1.TabIndex = 82;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
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
            this.tListDist.Location = new System.Drawing.Point(0, 30);
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
            this.tListDist.Size = new System.Drawing.Size(344, 239);
            this.tListDist.TabIndex = 78;
            this.tListDist.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDist.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListDist_FocusedNodeChanged);
            this.tListDist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tListDist_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tListDist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 36);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel1.Size = new System.Drawing.Size(344, 273);
            this.panel1.TabIndex = 83;
            // 
            // UserControlClipByXB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSetXB);
            this.Controls.Add(this.panelQuery);
            this.Controls.Add(this.radioGroup1);
            this.Name = "UserControlClipByXB";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(356, 427);
            this.panelQuery.ResumeLayout(false);
            this.panelSetXB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMiniArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).EndInit();
            this.panel1.ResumeLayout(false);
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

                                ///在源代码中radioGroup1.SelectedIndex = 0：意味着作者本意不愿让panel1显示
                                this.radioGroup1.SelectedIndex = 1;
                                if (this.radioGroup1.SelectedIndex == 0)
                                {
                                    this.panel1.Enabled = false;
                                }
                                else
                                {
                                    this.panel1.Enabled = true;
                                }
                                this.radioGroup2.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.panel1.Enabled = false;
            }
            else
            {
                this.panel1.Enabled = true;
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
                            name = "Sub";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
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
            try
            {
                if ((this.radioGroup1.SelectedIndex != 1) || (this.tListDist.Selection.Count != 0))
                {
                    IWorkspaceEdit mFeatureWorkspace = this.mFeatureWorkspace as IWorkspaceEdit;
                    this.Cursor = Cursors.WaitCursor;
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    IFeatureCursor cursor = null;
                    IFeature pFeature = null;
                    int num = 0;
                    if (this.radioGroup1.SelectedIndex == 0)
                    {
                        num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                        cursor = this.m_EditLayer.FeatureClass.Search(null, false);
                        pFeature = cursor.NextFeature();
                    }
                    else
                    {
                        IFeature tag = this.tListDist.Selection[0].Tag as IFeature;
                        if (tag == null)
                        {
                            MessageBox.Show("请先选择区划范围", "批量裁切", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        IGeometry shapeCopy = tag.ShapeCopy;
                        queryFilter.Geometry = shapeCopy;
                        queryFilter.GeometryField = this.m_EditLayer.FeatureClass.ShapeFieldName;
                        queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        GC.Collect();
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        GC.Collect();
                        cursor = this.m_EditLayer.FeatureClass.Search(queryFilter, false);
                        pFeature = cursor.NextFeature();
                    }
                    if (pFeature == null)
                    {
                        this.labelInfo.Text = "无指定范围内" + this.mEditKind + "班块";
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.labelInfo.Text = string.Concat(new object[] { "指定范围内", this.mEditKind, "班块共计", num, "个" });
                        int num2 = 0;
                        int num3 = 0;
                        bool flag = false;
                        Editor.UniqueInstance.StopEdit2();
                        Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                        while (pFeature != null)
                        {
                            num2++;
                            num3++;
                            GC.Collect();
                            Application.DoEvents();
                            this.labelInfo.Text = string.Concat(new object[] { "裁切第", num2, "个", this.mEditKind, "班块,共计", num, "个" });
                            IGeometry geometry2 = pFeature.ShapeCopy;
                            if (geometry2.SpatialReference != (this.xblayer.FeatureClass as IGeoDataset).SpatialReference)
                            {
                                geometry2.Project((this.xblayer.FeatureClass as IGeoDataset).SpatialReference);
                            }
                            ISpatialFilter filter = new SpatialFilterClass();
                            filter.Geometry = geometry2;
                            filter.GeometryField = this.xblayer.FeatureClass.ShapeFieldName;
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                            GC.Collect();
                            IFeatureCursor pFCursor = null;
                            pFCursor = this.xblayer.FeatureClass.Search(filter, false);
                            IFeature pf = pFCursor.NextFeature();
                            flag = this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                            GC.Collect();
                            pFCursor = this.xblayer.FeatureClass.Search(filter, false);
                            pf = pFCursor.NextFeature();
                            bool flag2 = this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            if (!flag)
                            {
                                flag = flag2;
                            }
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            GC.Collect();
                            pFCursor = this.xblayer.FeatureClass.Search(filter, false);
                            pf = pFCursor.NextFeature();
                            flag2 = this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            if (!flag)
                            {
                                flag = flag2;
                            }
                            if (this.checkEditDelete.Checked && flag)
                            {
                                Editor.UniqueInstance.StartEditOperation();
                                pFeature.Delete();
                                Editor.UniqueInstance.StopEditOperation();
                            }
                            if (num3 >= 20)
                            {
                                if (Editor.UniqueInstance.IsBeingEdited)
                                {
                                    num3 = 0;
                                    Editor.UniqueInstance.StopEdit2();
                                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                                }
                                try
                                {
                                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                                    {
                                        Process process = new Process();
                                        ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                        process.StartInfo = info;
                                        process.StartInfo.UseShellExecute = false;
                                        process.Start();
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                            pFeature = cursor.NextFeature();
                        }
                        Editor.UniqueInstance.StopEdit();
                        Editor.UniqueInstance.StartEdit(this.mFeatureWorkspace as IWorkspace, this.mHookHelper.FocusMap);
                        this.labelInfo.Text = "裁切完成";
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlClipByXB", "simpleButtonClip_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                this.Cursor = Cursors.Default;
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

