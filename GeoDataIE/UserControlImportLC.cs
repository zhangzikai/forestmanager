namespace GeoDataIE
{
    using AttributesEdit;
    using DataEdit;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
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
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    using TopologyCheck.Base;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;
    using TaskManage;

    public class UserControlImportLC : UserControlBase1
    {
        private ButtonEdit buttonEditPath;
        private CheckBox checkBoxClear;
        private IContainer components;
        private GridControl gridControl1;
        private GridControl gridControl2;
        private GridView gridView1;
        private GridView gridViewResult;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        internal Label LabelLoadInfo;
        internal Label LabelProgressBack;
        internal Label LabelProgressBar;
        internal Label labelQueryLoading;
        private LabelControl labelTop;
        private ListBoxControl listBoxControl1;
        private IFeatureClass m_FClass;
        private IHookHelper m_hookHelper;
        private int m_ImportType = 1;
        private IList<string> m_MultiFeature;
        private IFeatureClass m_NdFClass;
        private DataTable m_Table;
        private const string mClassName = "GeoDataIE.UserControlImportLC";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private PanelControl panelBar;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PanelControl panelControl6;
        private PanelControl panelQueryResult;
        private PanelControl panelTab1;
        private PanelControl panelTab2;
        private RadioGroup radioGroup1;
        private SimpleButton simpleButtonImport;
        private SimpleButton simpleButtonQuery;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlImportLC()
        {
            this.InitializeComponent();
        }

        private void buttonEditPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                this.buttonEditPath.Tag = null;
                IFeatureLayer editLayer = EditTask.EditLayer;
                FormAddData2 data = new FormAddData2(this.m_hookHelper.FocusMap as IBasicMap, null, false, editLayer);
                data.ShowDialog(this);
                ArrayList layerList = data.LayerList;
                if (layerList != null)
                {
                    if (layerList.Count != 1)
                    {
                        MessageBox.Show("请选择一层数据！", "提示");
                    }
                    else
                    {
                        IFeatureLayer layer2 = layerList[0] as IFeatureLayer;
                        IFeatureClass featureClass = layer2.FeatureClass;
                        if (featureClass == null)
                        {
                            MessageBox.Show("数据不存在，请重新选择！", "提示");
                        }
                        else
                        {
                            data.Close();
                            data = null;
                            this.buttonEditPath.Tag = featureClass;
                            IDataset dataset = featureClass as IDataset;
                            this.buttonEditPath.Text = dataset.Workspace.PathName + @"\" + dataset.Name;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "buttonEditPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void buttonEditPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                this.panelBar.Visible = false;
                this.panelControl1.Enabled = true;
                this.panelControl2.Enabled = true;
                if ((this.m_MultiFeature != null) && (this.m_MultiFeature.Count > 0))
                {
                    this.listBoxControl1.Items.Clear();
                    for (int i = 0; i < this.m_MultiFeature.Count; i++)
                    {
                        this.listBoxControl1.Items.Add(this.m_MultiFeature[i]);
                    }
                    this.groupControl1.Text = "多部件数据要素列表（" + this.m_MultiFeature.Count + "个）";
                    this.groupControl1.Visible = true;
                    this.gridControl1.Visible = false;
                    this.listBoxControl1.Visible = true;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private void CopyAttributes(IFeature pSrcFeature, IFeature pNewFeature, bool bBHYY)
        {
            DataFuncs.CopyGeoObject(pSrcFeature, pNewFeature);
            int index = pNewFeature.Fields.FindField("DI_LEI");
            if (pNewFeature.get_Value(index).ToString() == "603")
            {
                pNewFeature.set_Value(index, "6031");
            }
            index = pNewFeature.Fields.FindField("Q_DI_LEI");
            if (pNewFeature.get_Value(index).ToString() == "603")
            {
                pNewFeature.set_Value(index, "6031");
            }
            if (bBHYY)
            {
                index = pNewFeature.Fields.FindField("BHYY");
                pNewFeature.set_Value(index, "93");
            }
        }

        private void CreateFeature(IFeature pSubFeature, IFeatureCursor pFCursor, IFeatureClass pNewFClass)
        {
            if (pFCursor != null)
            {
                IFeature item = pFCursor.NextFeature();
                if (item != null)
                {
                    try
                    {
                        IList<IFeature> list = new List<IFeature>();
                        while (item != null)
                        {
                            IGeometry shapeCopy = pSubFeature.ShapeCopy;
                            IGeometry other = item.ShapeCopy;
                            ITopologicalOperator2 @operator = (ITopologicalOperator2) shapeCopy;
                            @operator.Simplify();
                            if (@operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension).IsEmpty)
                            {
                                item = pFCursor.NextFeature();
                            }
                            else
                            {
                                list.Add(item);
                                item = pFCursor.NextFeature();
                            }
                        }
                        double area = ((IArea) pSubFeature.ShapeCopy).Area;
                        if ((list.Count == 1) && (((IArea) list[0].ShapeCopy).Area == area))
                        {
                            if (!this.IsAttrSample(list[0], pSubFeature))
                            {
                                IFeature pNewFeature = pNewFClass.CreateFeature();
                                pNewFeature.Shape = list[0].ShapeCopy;
                                this.CopyAttributes(list[0], pNewFeature, false);
                                this.SetOtherAttributes(pNewFeature);
                                pNewFeature.Store();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                IFeature feature3 = list[i];
                                IGeometry geometry5 = ((ITopologicalOperator2) pSubFeature.ShapeCopy).Intersect(feature3.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                                if (!geometry5.IsEmpty)
                                {
                                    bool flag2 = this.IsAttrSample(feature3, pSubFeature);
                                    IFeature feature4 = pNewFClass.CreateFeature();
                                    if (flag2)
                                    {
                                        feature4.Shape = geometry5;
                                        this.CopyAttributes(feature3, feature4, true);
                                        this.SetOtherAttributes(feature4);
                                        feature4.Store();
                                    }
                                    else
                                    {
                                        feature4.Shape = geometry5;
                                        this.CopyAttributes(feature3, feature4, false);
                                        this.SetOtherAttributes(feature4);
                                        feature4.Store();
                                    }
                                    this.ReleaseObject(feature3);
                                    this.ReleaseObject(feature4);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "CreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                }
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

        private void GetData1()
        {
            IFeatureLayer editLayer = EditTask.EditLayer;
            if (editLayer == null)
            {
                MessageBox.Show("当前编辑图层不存在，请检查！", "提示");
            }
            else
            {
                IFeatureClass featureClass = editLayer.FeatureClass;
                if (featureClass == null)
                {
                    MessageBox.Show("要素类的数据源已丢失，请检查！", "提示");
                }
                else
                {
                    IDataset dataset = (IDataset) featureClass;
                    string sql = "select objectid as OID from " + dataset.Name + " where BHYY='93'";
                 //   IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //    if (dBAccess != null)
                    {
                  //      this.m_Table = dBAccess.GetDataTable(dBAccess, sql);
                        this.ShowResult();
                    }
                }
            }
        }

        private void GetData2()
        {
            IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
            if (featureClass == null)
            {
                MessageBox.Show("要素类的数据源已丢失，请检查！", "提示");
            }
            else
            {
                IDataset dataset = (IDataset) featureClass;
                string str = "rtrim(ltrim(BHYY))='' or BHYY is null";
                string sql = "select objectid as OID from " + dataset.Name + " where " + str;
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess != null)
                //{
                //    this.m_Table = dBAccess.GetDataTable(dBAccess, sql);
                //    this.ShowResult();
                //}
            }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            DataRow focusedDataRow = this.gridView1.GetFocusedDataRow();
            if (focusedDataRow != null)
            {
                string sOID = focusedDataRow[0].ToString();
                this.ZoomToFeature(sOID);
            }
        }

        private void ImportData()
        {
            this.SetLoadInfo("正在获取数据……", 1);
            IFeatureClass fClass = this.m_FClass;
            if (fClass.FeatureCount(null) < 1)
            {
                MessageBox.Show("选择的数据中无要素，请重新选择！", "提示");
            }
            else
            {
                IFeatureLayer underLayer = null;
                if (this.m_ImportType == 1)
                {
                    underLayer = EditTask.UnderLayer;
                }
                else
                {
                    underLayer = EditTask.EditLayer;
                }
                IFeatureClass featureClass = underLayer.FeatureClass;
                this.SetLoadInfo("正在检查数据……", 5);
                DataTable pTable = DataFuncs.CheckField(fClass, featureClass);
                if (pTable == null)
                {
                    MessageBox.Show("数据检查时出错，请检查数据是否有问题。", "提示");
                }
                else if (pTable.Rows.Count > 0)
                {
                    this.ShowError(pTable);
                    this.panelBar.Visible = false;
                }
                else
                {
                    this.groupControl1.Visible = false;
                    this.Cursor = Cursors.WaitCursor;
                    this.SetLoadInfo("开始导入……", 8);
                    this.panelControl1.Enabled = false;
                    this.panelControl2.Enabled = false;
                    this.ImportThread();
                }
            }
        }

        private void ImportELBH()
        {
            try
            {
                IFeatureClass fClass = this.m_FClass;
                IFeatureClass featureClass = EditTask.UnderLayer.FeatureClass;
                IFeatureClass pNewFClass = EditTask.EditLayer.FeatureClass;
                IWorkspace workspace = pNewFClass.FeatureDataset.Workspace;
                if (this.checkBoxClear.Checked)
                {
                    this.SetLoadInfo("正在清空数据……", 8);
                    string sqlStmt = "delete from " + ((IDataset) pNewFClass).Name;
                    workspace.ExecuteSQL(sqlStmt);
                }
                GC.Collect();
                this.SetLoadInfo("正在查找涉及到的班块……", 12);
                string sFile = (UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath")) + @"\dissolve.shp";
                IGeometry geometry = SpatialAnalysis.DissolveGeo(fClass, sFile);
                ISpatialFilter filter = new SpatialFilterClass();
                filter.GeometryField = featureClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                filter.Geometry = geometry;
                IFeatureCursor cursor = featureClass.Search(filter, false);
                if (cursor != null)
                {
                    IFeature pSubFeature = cursor.NextFeature();
                    if (pSubFeature == null)
                    {
                        MessageBox.Show("当前无涉及到的资源数据，请检查是否为此区县内数据！", "提示");
                    }
                    else
                    {
                        int num = fClass.FeatureCount(filter);
                        IWorkspaceEdit edit = (IWorkspaceEdit) workspace;
                        edit.StartEditing(false);
                        int num2 = 0;
                        while (pSubFeature != null)
                        {
                            num2++;
                            this.SetLoadInfo("正在处理第" + num2 + "个班块", 15 + Convert.ToInt16((int) ((80 * num2) / num)));
                            Application.DoEvents();
                            IGeometry shapeCopy = pSubFeature.ShapeCopy;
                            if (!shapeCopy.IsEmpty)
                            {
                                ISpatialFilter filter2 = new SpatialFilterClass();
                                filter2.GeometryField = fClass.ShapeFieldName;
                                filter2.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                                filter2.Geometry = shapeCopy;
                                IFeatureCursor pFCursor = fClass.Search(filter2, false);
                                edit.StartEditOperation();
                                try
                                {
                                    this.CreateFeature(pSubFeature, pFCursor, pNewFClass);
                                    this.ReleaseObject(pSubFeature);
                                    this.ReleaseObject(pFCursor);
                                    edit.StopEditOperation();
                                }
                                catch
                                {
                                    edit.AbortEditOperation();
                                }
                                pSubFeature = cursor.NextFeature();
                            }
                        }
                        this.ReleaseObject(cursor);
                        edit.StopEditing(true);
                        this.SetLoadInfo("正在保存", 0x62);
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                        Editor.UniqueInstance.StopEdit2();
                        GC.Collect();
                        this.SetLoadInfo("导入完成", 100);
                        MessageBox.Show("导入完成。请进行逻辑校验，修改没有变化原因的班块！！", "提示");
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ImportData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("导入失败！", "提示");
            }
        }

        private void ImportThread()
        {
            this.m_MultiFeature = null;
            if (this.m_ImportType == 1)
            {
                this.ReplaceND();
            }
            else if (this.m_ImportType == 2)
            {
                this.ImportELBH();
            }
            GC.Collect();
            this.CallBack();
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxClear = new System.Windows.Forms.CheckBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.buttonEditPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelTop = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelTab1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBar = new DevExpress.XtraEditors.PanelControl();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonImport = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelTab2 = new DevExpress.XtraEditors.PanelControl();
            this.panelQueryResult = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelQueryLoading = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTab1)).BeginInit();
            this.panelTab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).BeginInit();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTab2)).BeginInit();
            this.panelTab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQueryResult)).BeginInit();
            this.panelQueryResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(264, 65);
            this.panelControl1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 27);
            this.panel1.TabIndex = 13;
            // 
            // checkBoxClear
            // 
            this.checkBoxClear.AutoSize = true;
            this.checkBoxClear.Location = new System.Drawing.Point(23, 8);
            this.checkBoxClear.Name = "checkBoxClear";
            this.checkBoxClear.Size = new System.Drawing.Size(122, 18);
            this.checkBoxClear.TabIndex = 0;
            this.checkBoxClear.Text = "清空图层原有数据";
            this.checkBoxClear.UseVisualStyleBackColor = true;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.buttonEditPath);
            this.panelControl3.Controls.Add(this.labelTop);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 30);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(12, 7, 15, 7);
            this.panelControl3.Size = new System.Drawing.Size(264, 35);
            this.panelControl3.TabIndex = 12;
            // 
            // buttonEditPath
            // 
            this.buttonEditPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditPath.Location = new System.Drawing.Point(72, 7);
            this.buttonEditPath.Name = "buttonEditPath";
            this.buttonEditPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditPath.Size = new System.Drawing.Size(177, 20);
            this.buttonEditPath.TabIndex = 0;
            this.buttonEditPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditPath_ButtonClick);
            // 
            // labelTop
            // 
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTop.Location = new System.Drawing.Point(12, 7);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(60, 14);
            this.labelTop.TabIndex = 10;
            this.labelTop.Text = "林场数据：";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(274, 375);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelTab1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(268, 346);
            this.xtraTabPage1.Text = "数据导入";
            // 
            // panelTab1
            // 
            this.panelTab1.Controls.Add(this.panelControl6);
            this.panelTab1.Controls.Add(this.panelBar);
            this.panelTab1.Controls.Add(this.panelControl2);
            this.panelTab1.Controls.Add(this.panelControl1);
            this.panelTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTab1.Location = new System.Drawing.Point(0, 0);
            this.panelTab1.Name = "panelTab1";
            this.panelTab1.Size = new System.Drawing.Size(268, 346);
            this.panelTab1.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.groupControl1);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(2, 156);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(264, 188);
            this.panelControl6.TabIndex = 14;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.listBoxControl1);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(264, 188);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "错误列表";
            this.groupControl1.Visible = false;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControl1.Location = new System.Drawing.Point(2, 22);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(260, 164);
            this.listBoxControl1.TabIndex = 4;
            this.listBoxControl1.Visible = false;
            this.listBoxControl1.DoubleClick += new System.EventHandler(this.listBoxControl1_DoubleClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gridViewResult;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(260, 164);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResult});
            // 
            // gridViewResult
            // 
            this.gridViewResult.GridControl = this.gridControl1;
            this.gridViewResult.Name = "gridViewResult";
            this.gridViewResult.OptionsBehavior.Editable = false;
            this.gridViewResult.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewResult.OptionsCustomization.AllowFilter = false;
            this.gridViewResult.OptionsCustomization.AllowGroup = false;
            this.gridViewResult.OptionsCustomization.AllowSort = false;
            this.gridViewResult.OptionsMenu.EnableColumnMenu = false;
            this.gridViewResult.OptionsMenu.EnableFooterMenu = false;
            this.gridViewResult.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewResult.OptionsView.ColumnAutoWidth = false;
            this.gridViewResult.OptionsView.ShowGroupPanel = false;
            this.gridViewResult.OptionsView.ShowIndicator = false;
            // 
            // panelBar
            // 
            this.panelBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBar.Controls.Add(this.LabelProgressBack);
            this.panelBar.Controls.Add(this.LabelProgressBar);
            this.panelBar.Controls.Add(this.LabelLoadInfo);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(2, 105);
            this.panelBar.Name = "panelBar";
            this.panelBar.Padding = new System.Windows.Forms.Padding(20, 10, 20, 17);
            this.panelBar.Size = new System.Drawing.Size(264, 51);
            this.panelBar.TabIndex = 16;
            this.panelBar.Visible = false;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(20, 29);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(224, 4);
            this.LabelProgressBack.TabIndex = 15;
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Orange;
            this.LabelProgressBar.ForeColor = System.Drawing.Color.Black;
            this.LabelProgressBar.Location = new System.Drawing.Point(20, 29);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(55, 4);
            this.LabelProgressBar.TabIndex = 14;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.LabelLoadInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Location = new System.Drawing.Point(20, 10);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(224, 19);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "      正在进行，请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButtonImport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 67);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 7, 16, 7);
            this.panelControl2.Size = new System.Drawing.Size(264, 38);
            this.panelControl2.TabIndex = 15;
            // 
            // simpleButtonImport
            // 
            this.simpleButtonImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonImport.Location = new System.Drawing.Point(193, 7);
            this.simpleButtonImport.Name = "simpleButtonImport";
            this.simpleButtonImport.Size = new System.Drawing.Size(55, 24);
            this.simpleButtonImport.TabIndex = 0;
            this.simpleButtonImport.Text = "导入";
            this.simpleButtonImport.Click += new System.EventHandler(this.simpleButtonImport_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panelTab2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(268, 346);
            this.xtraTabPage2.Text = "导入结果";
            // 
            // panelTab2
            // 
            this.panelTab2.Controls.Add(this.panelQueryResult);
            this.panelTab2.Controls.Add(this.panelControl5);
            this.panelTab2.Controls.Add(this.panelControl4);
            this.panelTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTab2.Location = new System.Drawing.Point(0, 0);
            this.panelTab2.Name = "panelTab2";
            this.panelTab2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelTab2.Size = new System.Drawing.Size(268, 346);
            this.panelTab2.TabIndex = 0;
            // 
            // panelQueryResult
            // 
            this.panelQueryResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelQueryResult.Controls.Add(this.groupControl2);
            this.panelQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQueryResult.Location = new System.Drawing.Point(2, 96);
            this.panelQueryResult.Name = "panelQueryResult";
            this.panelQueryResult.Size = new System.Drawing.Size(264, 238);
            this.panelQueryResult.TabIndex = 17;
            this.panelQueryResult.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(264, 238);
            this.groupControl2.TabIndex = 10;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 22);
            this.gridControl2.MainView = this.gridView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(260, 214);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl2.DoubleClick += new System.EventHandler(this.gridControl2_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.labelQueryLoading);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(2, 76);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.panelControl5.Size = new System.Drawing.Size(264, 20);
            this.panelControl5.TabIndex = 17;
            // 
            // labelQueryLoading
            // 
            this.labelQueryLoading.BackColor = System.Drawing.Color.Transparent;
            this.labelQueryLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQueryLoading.ForeColor = System.Drawing.Color.Black;
            this.labelQueryLoading.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelQueryLoading.Location = new System.Drawing.Point(20, 0);
            this.labelQueryLoading.Name = "labelQueryLoading";
            this.labelQueryLoading.Size = new System.Drawing.Size(234, 19);
            this.labelQueryLoading.TabIndex = 13;
            this.labelQueryLoading.Text = "      正在查询，请稍候...";
            this.labelQueryLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.panel2);
            this.panelControl4.Controls.Add(this.radioGroup1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(5, 15, 10, 5);
            this.panelControl4.Size = new System.Drawing.Size(264, 74);
            this.panelControl4.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonQuery);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(200, 15);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.panel2.Size = new System.Drawing.Size(54, 54);
            this.panel2.TabIndex = 5;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButtonQuery.Location = new System.Drawing.Point(0, 28);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(54, 20);
            this.simpleButtonQuery.TabIndex = 4;
            this.simpleButtonQuery.Text = "查询";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioGroup1.Location = new System.Drawing.Point(5, 15);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "其他调查因素"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "无变化原因")});
            this.radioGroup1.Size = new System.Drawing.Size(145, 54);
            this.radioGroup1.TabIndex = 3;
            // 
            // UserControlImportLC
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UserControlImportLC";
            this.Size = new System.Drawing.Size(274, 375);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTab1)).EndInit();
            this.panelTab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).EndInit();
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTab2)).EndInit();
            this.panelTab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelQueryResult)).EndInit();
            this.panelQueryResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private bool IsAttrSample(IFeature pNewFeature, IFeature pFeature)
        {
            string[] strArray = new string[] { "LIN_ZHONG", "G_CHENG_LB", "SHI_QUAN_D", "SEN_LIN_LB", "DI_LEI", "LD_QS", "BH_DJ" };
            for (int i = 0; i < strArray.Length; i++)
            {
                int index = pNewFeature.Fields.FindField(strArray[i]);
                string str = pNewFeature.get_Value(index).ToString();
                int num3 = pFeature.Fields.FindField(strArray[i]);
                string str2 = pFeature.get_Value(num3).ToString();
                if (str != str2)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsMultiGeometry(IGeometry pGeo)
        {
            IList<IGeometry> list = new List<IGeometry>();
            try
            {
                IPolygon4 polygon = pGeo as IPolygon4;
                if (polygon.ExteriorRingCount < 2)
                {
                    list.Add(pGeo);
                    return false;
                }
                IEnumGeometry exteriorRingBag = polygon.ExteriorRingBag as IEnumGeometry;
                exteriorRingBag.Reset();
                for (IRing ring = exteriorRingBag.Next() as IRing; ring != null; ring = exteriorRingBag.Next() as IRing)
                {
                    IGeometryBag bag2 = polygon.get_InteriorRingBag(ring);
                    object missing = System.Type.Missing;
                    IGeometryCollection geometrys = null;
                    geometrys = new PolygonClass();
                    geometrys.AddGeometry(ring, ref missing, ref missing);
                    IPolygon item = geometrys as IPolygon;
                    item.SpatialReference = pGeo.SpatialReference;
                    ITopologicalOperator2 @operator = (ITopologicalOperator2) item;
                    @operator.IsKnownSimple_2 = false;
                    @operator.Simplify();
                    if (!bag2.IsEmpty)
                    {
                        IGeometryCollection geometrys2 = new PolygonClass();
                        IEnumGeometry geometry2 = bag2 as IEnumGeometry;
                        geometry2.Reset();
                        for (IRing ring2 = geometry2.Next() as IRing; ring2 != null; ring2 = geometry2.Next() as IRing)
                        {
                            geometrys2.AddGeometry(ring2, ref missing, ref missing);
                        }
                        IPolygon other = geometrys2 as IPolygon;
                        other.SpatialReference = pGeo.SpatialReference;
                        ITopologicalOperator2 operator2 = (ITopologicalOperator2) other;
                        operator2.IsKnownSimple_2 = false;
                        operator2.Simplify();
                        IGeometry geometry3 = @operator.Difference(other);
                        list.Add(geometry3);
                        if (list.Count > 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        list.Add(item);
                        if (list.Count > 1)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return (list.Count > 1);
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBoxControl1.SelectedIndex >= 0)
            {
                string sOID = this.listBoxControl1.SelectedItem.ToString();
                this.ZoomToFeature(sOID);
            }
        }

        private void Query()
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.GetData1();
            }
            else if (this.radioGroup1.SelectedIndex == 1)
            {
                this.GetData2();
            }
        }

        private void ReleaseObject(object obj)
        {
            if (obj != null)
            {
                while (Marshal.ReleaseComObject(obj) > 0)
                {
                }
                obj = null;
            }
        }

        private void ReplaceND()
        {
            try
            {
                this.m_MultiFeature = new List<string>();
                IFeatureClass fClass = this.m_FClass;
                IFeatureClass ndFClass = this.m_NdFClass;
                IWorkspaceEdit workspace = (IWorkspaceEdit) ndFClass.FeatureDataset.Workspace;
                workspace.StartEditing(false);
                IGeometry other = null;
                other = SpatialAnalysis.DissolveGeo(fClass, (UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath")) + @"\dissolve.shp");
                try
                {
                    this.SetLoadInfo("正在删除完全覆盖数据……", 10);
                    workspace.StartEditOperation();
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.GeometryField = ndFClass.ShapeFieldName;
                    filter.Geometry = other;
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    IFeatureCursor cursor = ndFClass.Update(filter, false);
                    for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                    {
                        cursor.DeleteFeature();
                        this.ReleaseObject(feature);
                    }
                    this.ReleaseObject(cursor);
                    workspace.StopEditOperation();
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ImportData1", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    workspace.AbortEditOperation();
                    MessageBox.Show("处理覆盖数据出错！", "提示");
                    workspace.StopEditing(false);
                    return;
                }
                try
                {
                    this.SetLoadInfo("正在处理重叠数据……", 20);
                    workspace.StartEditOperation();
                    ISpatialFilter filter2 = new SpatialFilterClass();
                    filter2.GeometryField = ndFClass.ShapeFieldName;
                    filter2.Geometry = other;
                    filter2.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                    IFeatureCursor cursor2 = ndFClass.Update(filter2, false);
                    IFeature pObject = cursor2.NextFeature();
                    int index = ndFClass.Fields.FindField("XIANG");
                    int num2 = fClass.FindField("XIANG");
                    int num3 = 0;
                    while (pObject != null)
                    {
                        num3++;
                        this.SetLoadInfo("正在处理重叠数据 第" + num3.ToString() + "个", 20);
                        Application.DoEvents();
                        IGeometry shapeCopy = pObject.ShapeCopy;
                        shapeCopy.SpatialReference = other.SpatialReference;
                        ITopologicalOperator2 @operator = (ITopologicalOperator2) shapeCopy;
                        @operator.Simplify();
                        IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                        if (geometry3.IsEmpty)
                        {
                            cursor2.DeleteFeature();
                            pObject = cursor2.NextFeature();
                        }
                        else
                        {
                            ISpatialFilter filter3 = new SpatialFilterClass();
                            filter3.GeometryField = fClass.ShapeFieldName;
                            filter3.Geometry = geometry3;
                            filter3.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                            IFeatureCursor cursor3 = fClass.Search(filter3, false);
                            IFeature feature3 = cursor3.NextFeature();
                            if (feature3 == null)
                            {
                                filter3.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                                cursor3 = fClass.Search(filter3, false);
                                feature3 = cursor3.NextFeature();
                                if (feature3 == null)
                                {
                                    this.ReleaseObject(cursor3);
                                    pObject = cursor2.NextFeature();
                                    continue;
                                }
                            }
                            this.ReleaseObject(cursor3);
                            string str2 = feature3.get_Value(num2).ToString();
                            string str3 = pObject.get_Value(index).ToString();
                            if (str2 == str3)
                            {
                                cursor2.DeleteFeature();
                            }
                            else
                            {
                                int num4 = pObject.Fields.FindField("MIAN_JI");
                                double num5 = Convert.ToDouble(pObject.get_Value(num4).ToString());
                                IGeometry pGeo = @operator.Difference(other);
                                if (!pGeo.IsEmpty)
                                {
                                    if (this.IsMultiGeometry(pGeo))
                                    {
                                        this.m_MultiFeature.Add(pObject.OID.ToString());
                                    }
                                    double pFieldValue = Math.Round(Math.Abs((double) (DataFuncs.GetArea(this.m_hookHelper.FocusMap.SpatialReference, pGeo) / 10000.0)), 2);
                                    DataFuncs.UpdateField(pObject, "MIAN_JI", pFieldValue);
                                    int num7 = pObject.Fields.FindField("YSSZXJ");
                                    double num8 = 0.0;
                                    object obj2 = pObject.get_Value(num7);
                                    if ((obj2 != DBNull.Value) && (obj2 != null))
                                    {
                                        double num9 = Convert.ToInt32(obj2.ToString());
                                        num8 = (pFieldValue / num5) * num9;
                                    }
                                    pObject.set_Value(num7, num8);
                                    num7 = pObject.Fields.FindField("BSSZXJ");
                                    double num10 = 0.0;
                                    object obj3 = pObject.get_Value(num7);
                                    if ((obj3 != DBNull.Value) && (obj3 != null))
                                    {
                                        double num11 = Convert.ToInt32(obj3.ToString());
                                        num10 = (pFieldValue / num5) * num11;
                                    }
                                    pObject.set_Value(num7, num10);
                                    num7 = pObject.Fields.FindField("SSXJ");
                                    double num12 = 0.0;
                                    object obj4 = pObject.get_Value(num7);
                                    if ((obj4 != DBNull.Value) && (obj4 != null))
                                    {
                                        double num13 = Convert.ToInt32(obj4.ToString());
                                        num12 = (pFieldValue / num5) * num13;
                                    }
                                    pObject.set_Value(num7, num12);
                                    num7 = pObject.Fields.FindField("SLXJ");
                                    double num14 = num8 + num10;
                                    pObject.set_Value(num7, num14);
                                    num7 = pObject.Fields.FindField("ZXJ");
                                    double num15 = num14 + num12;
                                    pObject.set_Value(num7, num15);
                                    pObject.Shape = pGeo;
                                    cursor2.UpdateFeature(pObject);
                                }
                            }
                            if (shapeCopy != null)
                            {
                                this.ReleaseObject(shapeCopy);
                            }
                            this.ReleaseObject(pObject);
                            this.ReleaseObject(feature3);
                            pObject = cursor2.NextFeature();
                        }
                    }
                    this.ReleaseObject(cursor2);
                    workspace.StopEditOperation();
                }
                catch (Exception exception2)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ImportData2", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                    workspace.AbortEditOperation();
                    MessageBox.Show("处理重叠数据出错！", "提示");
                    workspace.StopEditing(false);
                    return;
                }
                this.SetLoadInfo("正在导入数据……", 15);
                workspace.StartEditOperation();
                try
                {
                    int num16 = 0;
                    int num17 = ndFClass.Fields.FindField("DI_LEI");
                    int num18 = ndFClass.Fields.FindField("Q_DI_LEI");
                    int num19 = ndFClass.Fields.FindField("DT_SRC");
                    int num20 = ndFClass.Fields.FindField("BHYY");
                    int num21 = ndFClass.Fields.FindField("XIAO_BAN");
                    IFeature pSrcObj = null;
                    IFeatureCursor cursor4 = fClass.Search(null, false);
                    int num22 = fClass.FeatureCount(null);
                    while ((pSrcObj = cursor4.NextFeature()) != null)
                    {
                        num16++;
                        this.SetLoadInfo(string.Concat(new object[] { "正在导入", num16, "/", num22 }), 40 + Convert.ToInt16((int) ((0x37 * num16) / num22)));
                        Application.DoEvents();
                        IFeature pTargObj = ndFClass.CreateFeature();
                        pTargObj.Shape = pSrcObj.ShapeCopy;
                        DataFuncs.CopyGeoObject(pSrcObj, pTargObj);
                        if ((num17 >= 0) && (pTargObj.get_Value(num17).ToString() == "603"))
                        {
                            pTargObj.set_Value(num17, "6031");
                        }
                        if ((num18 >= 0) && (pTargObj.get_Value(num18).ToString() == "603"))
                        {
                            pTargObj.set_Value(num18, "6031");
                        }
                        if (num19 >= 0)
                        {
                            pTargObj.set_Value(num19, "77");
                        }
                        if (num20 >= 0)
                        {
                            pTargObj.set_Value(num20, "93");
                        }
                        if (num21 >= 0)
                        {
                            object obj5 = pTargObj.get_Value(num21);
                            if (obj5 != null)
                            {
                                string str4 = ((int) Convert.ToInt16(Convert.ToDouble(obj5.ToString()))).ToString().PadLeft(4, '0');
                                pTargObj.set_Value(num21, str4);
                            }
                        }
                        pTargObj.Store();
                        this.ReleaseObject(pSrcObj);
                        this.ReleaseObject(pTargObj);
                    }
                    this.ReleaseObject(cursor4);
                    this.SetLoadInfo("正在保存……", 0x62);
                    workspace.StartEditOperation();
                }
                catch (Exception exception3)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ImportData", exception3.GetHashCode().ToString(), exception3.Source, exception3.Message, "", "", "");
                    workspace.AbortEditOperation();
                    MessageBox.Show("增加数据出错！", "提示");
                    workspace.StopEditing(false);
                    return;
                }
                workspace.StopEditing(true);
                this.SetLoadInfo("导入完成", 100);
                MessageBox.Show("导入完成。请选择拓扑校验里的缝隙检查，检查是否有缝隙产生并进行修改！！", "提示");
            }
            catch (Exception exception4)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ImportData", exception4.GetHashCode().ToString(), exception4.Source, exception4.Message, "", "", "");
                MessageBox.Show("导入失败！", "提示");
            }
        }

        private void SetLoadInfo(string sInfo, int iValue)
        {
            if (!base.InvokeRequired)
            {
                this.LabelLoadInfo.Text = "      " + sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            else
            {
                base.Invoke(new DeleSetLoadInfo(this.SetLoadInfo), new object[] { sInfo, iValue });
            }
        }

        private void SetOtherAttributes(IFeature pFeature)
        {
            int index = pFeature.Fields.FindField("DT_SRC");
            if (index >= 0)
            {
                pFeature.set_Value(index, "77");
            }
            double pFieldValue = Math.Round(Math.Abs((double) (DataFuncs.GetArea(this.m_hookHelper.FocusMap.SpatialReference, pFeature.ShapeCopy) / 10000.0)), 2);
            DataFuncs.UpdateField(pFeature, "MIAN_JI", pFieldValue);
            int num3 = pFeature.Fields.FindField("XIAO_BAN");
            if (num3 >= 0)
            {
                object obj2 = pFeature.get_Value(num3);
                if (obj2 != null)
                {
                    string str = ((int) Convert.ToInt16(Convert.ToDouble(obj2.ToString()))).ToString().PadLeft(4, '0');
                    pFeature.set_Value(num3, str);
                }
            }
        }

        private void SetTabVisible()
        {
            if (this.m_ImportType == 1)
            {
                this.xtraTabPage1.PageVisible = true;
                this.xtraTabPage2.PageVisible = false;
                this.checkBoxClear.Visible = false;
            }
            else if (this.m_ImportType == 2)
            {
                this.xtraTabPage1.PageVisible = true;
                this.xtraTabPage2.PageVisible = false;
                this.labelQueryLoading.Visible = false;
                this.checkBoxClear.Visible = true;
            }
            else if (this.m_ImportType == 3)
            {
                this.xtraTabPage1.PageVisible = false;
                this.xtraTabPage2.PageVisible = true;
                this.labelQueryLoading.Visible = false;
                this.checkBoxClear.Visible = true;
            }
        }

        private void ShowError(DataTable pTable)
        {
            this.groupControl1.Text = "数据错误列表";
            this.groupControl1.Visible = true;
            this.gridControl1.Visible = true;
            this.listBoxControl1.Visible = false;
            this.gridControl1.DataSource = pTable;
            this.gridViewResult.Columns[0].Width = this.gridControl1.Width - 10;
        }

        private void ShowResult()
        {
            if (!base.InvokeRequired)
            {
                this.labelQueryLoading.Visible = false;
                if (this.m_Table == null)
                {
                    this.gridControl2.DataSource = null;
                    this.groupControl2.Text = "无结果";
                }
                this.groupControl2.Text = "共有" + this.m_Table.Rows.Count + "个要素";
                this.gridControl2.DataSource = this.m_Table;
                this.gridView1.Columns[0].Width = this.gridControl2.Width - 50;
                this.gridView1.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                this.panelQueryResult.Visible = true;
            }
            else
            {
                base.Invoke(new ThreadStart(this.ShowResult));
            }
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            if ((this.buttonEditPath.Text == "") || (this.buttonEditPath.Tag == null))
            {
                MessageBox.Show("请先选择数据！", "提示");
            }
            else
            {
                this.m_FClass = this.buttonEditPath.Tag as IFeatureClass;
                IFeatureLayer editLayer = EditTask.EditLayer;
                this.m_NdFClass = editLayer.FeatureClass;
                this.panelBar.Visible = true;
                this.ImportData();
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            this.labelQueryLoading.Visible = true;
            this.m_Table = null;
            Thread thread = new Thread(new ThreadStart(this.Query));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ZoomToFeature(string sOID)
        {
            try
            {
                IFeatureLayer editLayer = EditTask.EditLayer;
                IFeature feature = null;
                UtilFactory.GetConfigOpt();
                IFeatureClass featureClass = editLayer.FeatureClass;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = featureClass.OIDFieldName + "=" + sOID;
                feature = featureClass.Search(filter, false).NextFeature();
                if (feature != null)
                {
                    IActiveView activeView = this.m_hookHelper.ActiveView;
                    if (activeView != null)
                    {
                        IGeometry shapeCopy = feature.ShapeCopy;
                        if (shapeCopy.IsEmpty)
                        {
                            XtraMessageBox.Show(this, "要素图形为空，无法定位！", "逻辑校验");
                        }
                        else
                        {
                            shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_hookHelper.ActiveView.FocusMap.SpatialReference);
                            IEnvelope envelope = new EnvelopeClass();
                            envelope = shapeCopy.Envelope;
                            if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                            {
                                IEnvelope envelope2 = new EnvelopeClass();
                                envelope2.SpatialReference = activeView.FocusMap.SpatialReference;
                                double num = 100.0;
                                envelope2.PutCoords(envelope.XMin - num, envelope.YMin - num, envelope.XMax + num, envelope.YMax + num);
                                envelope = envelope2;
                            }
                            else
                            {
                                envelope.Expand(1.5, 1.5, true);
                            }
                            IFeatureSelection selection = editLayer as IFeatureSelection;
                            selection.Clear();
                            selection.Add(feature);
                            activeView.FullExtent = envelope;
                            activeView.Refresh();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.UserControlImportLC", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public object Hook
        {
            set
            {
                if (value != null)
                {
                    if (this.m_hookHelper == null)
                    {
                        this.m_hookHelper = new HookHelperClass();
                    }
                    this.m_hookHelper.Hook = value;
                }
            }
        }

        public int ImportType
        {
            set
            {
                this.m_ImportType = value;
                this.SetTabVisible();
            }
        }

        private delegate void DeleSetLoadInfo(string sInfo, int iValue);
    }
}

