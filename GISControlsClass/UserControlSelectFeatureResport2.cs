namespace GISControlsClass
{
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
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
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;
    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;

    public class UserControlSelectFeatureResport2 : UserControlBase1
    {
        private ApplicationMenu applicationMenu1;
        private Bar bar2;
        private BarAndDockingController barAndDockingController1;
        private BarButtonItem BarButtonExcel;
        private BarStaticItem BarButtonFilter;
        private BarStaticItem BarButtonFilterName;
        private BarButtonItem barButtonItemRefresh;
        private BarButtonItem BarButtonPrint;
        private BarButtonItem BarButtonTxt;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarEditItem BarEditGoto;
        private BarManager barManager1;
        private BarStaticItem BarStaticCount;
        private Bar BarStatus;
        private BarSubItem BarSubOutput;
        private IContainer components;
        private GridControl DataGridFeatures;
        private DataView dv;
        private GridView gridView1;
        internal ImageList ImageListToolbar;
        internal ImageList ImageListTreeView;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private const string mClassName = "GISControlsClass.UserControlSelectFeatureResport2";
        private IFeatureLayer mCurLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureColn;
        private System.Data.DataTable mFeatureTable;
        private IFeatureWorkspace mfWorkspace;
        private ArrayList mLayerColn;
        private bool mSelecting;
        private string mShowKind = "Selection";
        private string mSubSysName = UtilFactory.GetConfigOpt().GetConfigValue("SystemName");
        private const string myClassName = "要素属性列表";
        internal Panel panTree;
        private PopupMenu popupMenu1;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private RepositoryItemTextEdit repositoryItemTextEdit2;
        private SplitContainerControl splitContainerControl1;
        internal TreeView TreeViewLayers;

        public UserControlSelectFeatureResport2()
        {
            this.InitializeComponent();
        }

        private void barButtonItemRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.TreeViewLayers.SelectedNode != null)
            {
                this.mSelecting = true;
                this.Cursor = Cursors.WaitCursor;
                this.ReadFeatureValue();
                this.mSelecting = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void BarStaticCount_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private ArrayList CheckSelectionLayer(ILayer pLayer, ArrayList pSelLayerCol)
        {
            try
            {
                if (pLayer != null)
                {
                    if (pSelLayerCol == null)
                    {
                        return pSelLayerCol;
                    }
                    if (!pLayer.Valid)
                    {
                        return pSelLayerCol;
                    }
                    if (pLayer is ICompositeLayer)
                    {
                        ICompositeLayer layer = pLayer as ICompositeLayer;
                        for (int i = 0; i < layer.Count; i++)
                        {
                            pSelLayerCol = this.CheckSelectionLayer(layer.get_Layer(i), pSelLayerCol);
                        }
                    }
                    else if (pLayer is IFeatureSelection)
                    {
                        IFeatureSelection selection = pLayer as IFeatureSelection;
                        if (selection.SelectionSet.Count > 0)
                        {
                            pSelLayerCol.Add(pLayer);
                        }
                    }
                }
                return pSelLayerCol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "CheckSelectionLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return pSelLayerCol;
            }
        }

        private System.Data.DataTable CreateFeatureDataTable(IFeature pFeature)
        {
            try
            {
                if (pFeature.Fields.FieldCount <= 0)
                {
                    return null;
                }
                System.Data.DataTable table = null;
                table = new System.Data.DataTable(this.TreeViewLayers.SelectedNode.Text);
                DataGridTableStyle style = null;
                style = new DataGridTableStyle();
                style.MappingName = this.TreeViewLayers.SelectedNode.Text;
                style.GridColumnStyles.Clear();
                IField field = null;
                string columnName = null;
                string aliasName = null;
                DataColumn column = null;
                DataGridColumnStyle style2 = null;
                table.Columns.Add("序号", System.Type.GetType("System.Int32")).Caption = "ID";
                style2 = new DataGridTextBoxColumn();
                style2.Alignment = HorizontalAlignment.Left;
                style2.HeaderText = "ID";
                style2.MappingName = "序号";
                style2.ReadOnly = true;
                style2.Width = 0;
                style.GridColumnStyles.Add(style2);
                int index = 0;
                for (index = 0; index <= (pFeature.Fields.FieldCount - 1); index++)
                {
                    field = pFeature.Fields.get_Field(index);
                    columnName = field.Name;
                    aliasName = field.AliasName;
                    column = table.Columns.Add(columnName, System.Type.GetType("System.String"));
                    if (string.IsNullOrEmpty(aliasName))
                    {
                        aliasName = columnName;
                    }
                    column.Caption = aliasName;
                    style2 = new DataGridTextBoxColumn();
                    style2.Alignment = HorizontalAlignment.Center;
                    style2.HeaderText = aliasName;
                    style2.MappingName = columnName;
                    style2.ReadOnly = true;
                    if ((field.Name == pFeature.Class.OIDFieldName) || (field.Name == (pFeature.Class as IFeatureClass).ShapeFieldName))
                    {
                        style2.Width = 0;
                    }
                    else if (((pFeature.Class as IFeatureClass).LengthField != null) && (field.Name == (pFeature.Class as IFeatureClass).LengthField.Name))
                    {
                        style2.Width = 0;
                    }
                    else if (((pFeature.Class as IFeatureClass).AreaField != null) && (field.Name == (pFeature.Class as IFeatureClass).AreaField.Name))
                    {
                        style2.Width = 0;
                    }
                    else
                    {
                        style2.Width = 0x4b;
                    }
                    style.GridColumnStyles.Add(style2);
                }
                return table;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "CreateFeatureDataTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
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

        private IFeatureSelection GetFeatureSelection()
        {
            try
            {
                if (this.mLayerColn == null)
                {
                    return null;
                }
                TreeNode selectedNode = null;
                selectedNode = this.TreeViewLayers.SelectedNode;
                if (selectedNode == null)
                {
                    return null;
                }
                ILayer layer = null;
                try
                {
                    int num = int.Parse(selectedNode.Tag.ToString().Substring(1));
                    layer = this.mLayerColn[num] as ILayer;
                    this.mCurLayer = layer as IFeatureLayer;
                }
                catch (Exception)
                {
                }
                if (layer == null)
                {
                    return null;
                }
                IFeatureSelection selection = null;
                selection = layer as IFeatureSelection;
                if (selection.SelectionSet.Count <= 0)
                {
                    return null;
                }
                return selection;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "GetFeatureSelection", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private string GetGeometryTypeName(IGeometry pGeometry)
        {
            try
            {
                switch (pGeometry.GeometryType)
                {
                    case esriGeometryType.esriGeometryNull:
                        return "Unknown type of geometry";

                    case esriGeometryType.esriGeometryPoint:
                        return "Point";

                    case esriGeometryType.esriGeometryMultipoint:
                        return "Multipoint";

                    case esriGeometryType.esriGeometryPolyline:
                        return "Polyline";

                    case esriGeometryType.esriGeometryPolygon:
                        return "Polygon";

                    case esriGeometryType.esriGeometryEnvelope:
                        return "Envelope";

                    case esriGeometryType.esriGeometryPath:
                        return "Path";

                    case esriGeometryType.esriGeometryAny:
                        return "Any valid geometry";

                    case esriGeometryType.esriGeometryMultiPatch:
                        return "MultiPatch";

                    case esriGeometryType.esriGeometryRing:
                        return "Ring";

                    case esriGeometryType.esriGeometryLine:
                        return "Line";

                    case esriGeometryType.esriGeometryCircularArc:
                        return "CircularArc";

                    case esriGeometryType.esriGeometryBezier3Curve:
                        return "BezierCurve";

                    case esriGeometryType.esriGeometryEllipticArc:
                        return "EllipticArc";

                    case esriGeometryType.esriGeometryBag:
                        return "GeometryBag";

                    case esriGeometryType.esriGeometryTriangleStrip:
                        return "TriangleStrip";

                    case esriGeometryType.esriGeometryTriangleFan:
                        return "TriangleFan";

                    case esriGeometryType.esriGeometryRay:
                        return "Ray";

                    case esriGeometryType.esriGeometrySphere:
                        return "Sphere";

                    case esriGeometryType.esriGeometryTriangles:
                        return "Triangles";
                }
                return "";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "GetShapeTypeName", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return "";
            }
        }

        private ArrayList GetLayerCol(IEnumLayer pLayers, bool Flag)
        {
            try
            {
                ArrayList pCol = new ArrayList();
                ILayer layer = null;
                IGroupLayer pGLayer = null;
                pLayers.Reset();
                layer = pLayers.Next();
                IFeatureSelection selection = null;
                while (layer != null)
                {
                    if (layer is IGroupLayer)
                    {
                        pGLayer = layer as IGroupLayer;
                        this.GetLayers(pGLayer, pCol, Flag);
                    }
                    else if (layer is IFeatureLayer)
                    {
                        if (Flag)
                        {
                            selection = layer as IFeatureSelection;
                            if (selection.SelectionSet.Count > 0)
                            {
                                pCol.Add(layer);
                            }
                        }
                        else
                        {
                            pCol.Add(layer);
                        }
                    }
                    layer = pLayers.Next();
                }
                return pCol;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private ArrayList GetLayers(IGroupLayer pGLayer, ArrayList pCol, bool flag)
        {
            try
            {
                ICompositeLayer layer = pGLayer as ICompositeLayer;
                ILayer layer2 = null;
                IFeatureSelection selection = null;
                int index = 0;
                for (index = 0; index <= (layer.Count - 1); index++)
                {
                    layer2 = layer.get_Layer(index);
                    if (layer2 is IGroupLayer)
                    {
                        this.GetLayers(layer2 as IGroupLayer, pCol, flag);
                    }
                    else if (layer2 is IFeatureLayer)
                    {
                        if (flag)
                        {
                            selection = layer2 as IFeatureSelection;
                            if (selection.SelectionSet.Count > 0)
                            {
                                pCol.Add(layer2);
                            }
                        }
                        else
                        {
                            pCol.Add(layer2);
                        }
                    }
                }
                return pCol;
            }
            catch (Exception)
            {
                return pCol;
            }
        }

        private ArrayList GetSelectionLayerCollection()
        {
            try
            {
                if (this.m_Map == null)
                {
                    return null;
                }
                ArrayList pSelLayerCol = new ArrayList();
                for (int i = 0; i < this.m_Map.LayerCount; i++)
                {
                    this.CheckSelectionLayer(this.m_Map.get_Layer(i), pSelLayerCol);
                }
                return pSelLayerCol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "GetSelectionLayerCollection", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string s = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.mCurLayer.FeatureClass.OIDFieldName.ToString()).ToString();
                IFeature feature = this.mCurLayer.FeatureClass.GetFeature(int.Parse(s));
                if (!this.mCurLayer.Visible)
                {
                    this.mCurLayer.Visible = true;
                }
                (this.mCurLayer as IFeatureSelection).Clear();
                this.m_HookHelper.FocusMap.SelectFeature(this.mCurLayer, feature);
                GISFunFactory.FeatureFun.ZoomToFeature(this.m_Map, feature);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "gridView1_DoubleClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSelectFeatureResport2));
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panTree = new System.Windows.Forms.Panel();
            this.TreeViewLayers = new System.Windows.Forms.TreeView();
            this.ImageListTreeView = new System.Windows.Forms.ImageList();
            this.DataGridFeatures = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ImageListToolbar = new System.Windows.Forms.ImageList();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BarStatus = new DevExpress.XtraBars.Bar();
            this.BarStaticCount = new DevExpress.XtraBars.BarStaticItem();
            this.BarButtonFilterName = new DevExpress.XtraBars.BarStaticItem();
            this.BarButtonFilter = new DevExpress.XtraBars.BarStaticItem();
            this.BarEditGoto = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BarSubOutput = new DevExpress.XtraBars.BarSubItem();
            this.BarButtonPrint = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonExcel = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonTxt = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFeatures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 20);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panTree);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.DataGridFeatures);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(629, 193);
            this.splitContainerControl1.SplitterPosition = 144;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panTree
            // 
            this.panTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panTree.Controls.Add(this.TreeViewLayers);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTree.Location = new System.Drawing.Point(2, 2);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(140, 185);
            this.panTree.TabIndex = 42;
            // 
            // TreeViewLayers
            // 
            this.TreeViewLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewLayers.HideSelection = false;
            this.TreeViewLayers.ImageIndex = 3;
            this.TreeViewLayers.ImageList = this.ImageListTreeView;
            this.TreeViewLayers.Indent = 19;
            this.TreeViewLayers.ItemHeight = 16;
            this.TreeViewLayers.Location = new System.Drawing.Point(0, 0);
            this.TreeViewLayers.Name = "TreeViewLayers";
            this.TreeViewLayers.SelectedImageIndex = 3;
            this.TreeViewLayers.ShowRootLines = false;
            this.TreeViewLayers.Size = new System.Drawing.Size(140, 185);
            this.TreeViewLayers.TabIndex = 2;
            this.TreeViewLayers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewLayers_AfterSelect);
            this.TreeViewLayers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeViewLayers_MouseUp);
            // 
            // ImageListTreeView
            // 
            this.ImageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListTreeView.ImageStream")));
            this.ImageListTreeView.TransparentColor = System.Drawing.Color.Magenta;
            this.ImageListTreeView.Images.SetKeyName(0, "");
            this.ImageListTreeView.Images.SetKeyName(1, "");
            this.ImageListTreeView.Images.SetKeyName(2, "");
            this.ImageListTreeView.Images.SetKeyName(3, "");
            this.ImageListTreeView.Images.SetKeyName(4, "");
            this.ImageListTreeView.Images.SetKeyName(5, "");
            this.ImageListTreeView.Images.SetKeyName(6, "");
            this.ImageListTreeView.Images.SetKeyName(7, "");
            this.ImageListTreeView.Images.SetKeyName(8, "");
            this.ImageListTreeView.Images.SetKeyName(9, "");
            this.ImageListTreeView.Images.SetKeyName(10, "");
            this.ImageListTreeView.Images.SetKeyName(11, "");
            this.ImageListTreeView.Images.SetKeyName(12, "");
            this.ImageListTreeView.Images.SetKeyName(13, "");
            this.ImageListTreeView.Images.SetKeyName(14, "");
            this.ImageListTreeView.Images.SetKeyName(15, "");
            this.ImageListTreeView.Images.SetKeyName(16, "");
            this.ImageListTreeView.Images.SetKeyName(17, "");
            // 
            // DataGridFeatures
            // 
            this.DataGridFeatures.Cursor = System.Windows.Forms.Cursors.Default;
            this.DataGridFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridFeatures.Location = new System.Drawing.Point(2, 2);
            this.DataGridFeatures.MainView = this.gridView1;
            this.DataGridFeatures.Name = "DataGridFeatures";
            this.DataGridFeatures.Size = new System.Drawing.Size(472, 185);
            this.DataGridFeatures.TabIndex = 0;
            this.DataGridFeatures.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.DataGridFeatures;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // ImageListToolbar
            // 
            this.ImageListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListToolbar.ImageStream")));
            this.ImageListToolbar.TransparentColor = System.Drawing.Color.White;
            this.ImageListToolbar.Images.SetKeyName(0, "");
            this.ImageListToolbar.Images.SetKeyName(1, "");
            this.ImageListToolbar.Images.SetKeyName(2, "");
            this.ImageListToolbar.Images.SetKeyName(3, "");
            this.ImageListToolbar.Images.SetKeyName(4, "(06,15).png");
            this.ImageListToolbar.Images.SetKeyName(5, "GotoLine.ico");
            this.ImageListToolbar.Images.SetKeyName(6, "move.gif");
            this.ImageListToolbar.Images.SetKeyName(7, "(21,08).png");
            this.ImageListToolbar.Images.SetKeyName(8, "(36,30).png");
            this.ImageListToolbar.Images.SetKeyName(9, "(00,02).png");
            this.ImageListToolbar.Images.SetKeyName(10, "(00,17).png");
            this.ImageListToolbar.Images.SetKeyName(11, "(01,49).png");
            this.ImageListToolbar.Images.SetKeyName(12, "(02,11).png");
            this.ImageListToolbar.Images.SetKeyName(13, "(03,11).png");
            this.ImageListToolbar.Images.SetKeyName(14, "(05,37).png");
            this.ImageListToolbar.Images.SetKeyName(15, "(06,05).png");
            this.ImageListToolbar.Images.SetKeyName(16, "(08,34).png");
            this.ImageListToolbar.Images.SetKeyName(17, "(08,41).png");
            this.ImageListToolbar.Images.SetKeyName(18, "(17,18).png");
            this.ImageListToolbar.Images.SetKeyName(19, "(18,33).png");
            this.ImageListToolbar.Images.SetKeyName(20, "(23,44).png");
            this.ImageListToolbar.Images.SetKeyName(21, "(31,05).png");
            this.ImageListToolbar.Images.SetKeyName(22, "(31,41).png");
            this.ImageListToolbar.Images.SetKeyName(23, "(37,12).png");
            this.ImageListToolbar.Images.SetKeyName(24, "(44,25).png");
            this.ImageListToolbar.Images.SetKeyName(25, "(45,25).png");
            this.ImageListToolbar.Images.SetKeyName(26, "(49,42).png");
            this.ImageListToolbar.Images.SetKeyName(27, "request3.bmp");
            this.ImageListToolbar.Images.SetKeyName(28, "17.png");
            this.ImageListToolbar.Images.SetKeyName(29, "18.png");
            this.ImageListToolbar.Images.SetKeyName(30, "arrow_undo.png");
            this.ImageListToolbar.Images.SetKeyName(31, "printer.png");
            this.ImageListToolbar.Images.SetKeyName(32, "Text2.bmp");
            this.ImageListToolbar.Images.SetKeyName(33, "(142).gif");
            this.ImageListToolbar.Images.SetKeyName(34, "(02,14).png");
            this.ImageListToolbar.Images.SetKeyName(35, "(13,12).png");
            this.ImageListToolbar.Images.SetKeyName(36, "(26,13).png");
            this.ImageListToolbar.Images.SetKeyName(37, "(28,34).png");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.BarStatus});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.ImageListToolbar;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarStaticCount,
            this.BarButtonFilterName,
            this.BarButtonFilter,
            this.BarEditGoto,
            this.BarSubOutput,
            this.BarButtonPrint,
            this.BarButtonExcel,
            this.BarButtonTxt,
            this.barButtonItemRefresh});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2});
            this.barManager1.ShowCloseButton = true;
            this.barManager1.ShowFullMenus = true;
            this.barManager1.StatusBar = this.BarStatus;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BarStatus
            // 
            this.BarStatus.BarName = "Status bar";
            this.BarStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.BarStatus.DockCol = 0;
            this.BarStatus.DockRow = 0;
            this.BarStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.BarStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStaticCount),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonFilterName),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarEditGoto),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubOutput)});
            this.BarStatus.OptionsBar.AllowQuickCustomization = false;
            this.BarStatus.OptionsBar.DrawDragBorder = false;
            this.BarStatus.OptionsBar.UseWholeRow = true;
            this.BarStatus.Text = "Status bar";
            // 
            // BarStaticCount
            // 
            this.BarStaticCount.Caption = "记录:          ";
            this.BarStaticCount.Id = 0;
            this.BarStaticCount.ImageIndex = 22;
            this.BarStaticCount.Name = "BarStaticCount";
            this.BarStaticCount.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.BarStaticCount.TextAlignment = System.Drawing.StringAlignment.Near;
            this.BarStaticCount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BarStaticCount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarStaticCount_ItemClick);
            // 
            // BarButtonFilterName
            // 
            this.BarButtonFilterName.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BarButtonFilterName.Caption = "过滤:";
            this.BarButtonFilterName.Id = 1;
            this.BarButtonFilterName.ImageIndex = 4;
            this.BarButtonFilterName.Name = "BarButtonFilterName";
            this.BarButtonFilterName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.BarButtonFilterName.TextAlignment = System.Drawing.StringAlignment.Near;
            this.BarButtonFilterName.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // BarButtonFilter
            // 
            this.BarButtonFilter.Id = 2;
            this.BarButtonFilter.ImageIndex = 5;
            this.BarButtonFilter.Name = "BarButtonFilter";
            this.BarButtonFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.BarButtonFilter.TextAlignment = System.Drawing.StringAlignment.Near;
            this.BarButtonFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // BarEditGoto
            // 
            this.BarEditGoto.Caption = "转到:";
            this.BarEditGoto.Edit = this.repositoryItemTextEdit2;
            this.BarEditGoto.EditValue = "1";
            this.BarEditGoto.Id = 4;
            this.BarEditGoto.ImageIndex = 6;
            this.BarEditGoto.Name = "BarEditGoto";
            this.BarEditGoto.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.BarEditGoto.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // BarSubOutput
            // 
            this.BarSubOutput.Caption = "输出 ";
            this.BarSubOutput.Id = 5;
            this.BarSubOutput.ImageIndex = 27;
            this.BarSubOutput.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonTxt)});
            this.BarSubOutput.Name = "BarSubOutput";
            this.BarSubOutput.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // BarButtonPrint
            // 
            this.BarButtonPrint.Caption = "打印输出";
            this.BarButtonPrint.Id = 6;
            this.BarButtonPrint.ImageIndex = 31;
            this.BarButtonPrint.Name = "BarButtonPrint";
            this.BarButtonPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // BarButtonExcel
            // 
            this.BarButtonExcel.Caption = "输出Excel";
            this.BarButtonExcel.Id = 7;
            this.BarButtonExcel.ImageIndex = 19;
            this.BarButtonExcel.Name = "BarButtonExcel";
            this.BarButtonExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonExcel_ItemClick);
            // 
            // BarButtonTxt
            // 
            this.BarButtonTxt.Caption = "输出文本";
            this.BarButtonTxt.Id = 8;
            this.BarButtonTxt.ImageIndex = 32;
            this.BarButtonTxt.Name = "BarButtonTxt";
            this.BarButtonTxt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(629, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 213);
            this.barDockControlBottom.Size = new System.Drawing.Size(629, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 193);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(629, 20);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 193);
            // 
            // barButtonItemRefresh
            // 
            this.barButtonItemRefresh.Caption = "刷新";
            this.barButtonItemRefresh.Id = 9;
            this.barButtonItemRefresh.ImageIndex = 33;
            this.barButtonItemRefresh.Name = "barButtonItemRefresh";
            this.barButtonItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRefresh_ItemClick);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRefresh)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // UserControlSelectFeatureResport2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UserControlSelectFeatureResport2";
            this.barManager1.SetPopupContextMenu(this, this.applicationMenu1);
            this.Size = new System.Drawing.Size(629, 240);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFeatures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialTreeView()
        {
            try
            {
                this.mLayerColn = null;
                this.mLayerColn = new ArrayList();
                this.TreeViewLayers.ShowLines = false;
                this.TreeViewLayers.Nodes.Clear();
                ArrayList selectionLayerCollection = this.GetSelectionLayerCollection();
                if ((selectionLayerCollection != null) && (selectionLayerCollection.Count > 0))
                {
                    int num = 0;
                    ILayer layer = null;
                    IFeatureLayer layer2 = null;
                    for (num = 0; num < selectionLayerCollection.Count; num++)
                    {
                        layer = selectionLayerCollection[num] as ILayer;
                        TreeNode node = new TreeNode();
                        node = this.TreeViewLayers.Nodes.Add(layer.Name);
                        node.Text = layer.Name;
                        node.Tag = "L" + Convert.ToString(num);
                        layer2 = layer as IFeatureLayer;
                        switch (layer2.FeatureClass.ShapeType)
                        {
                            case esriGeometryType.esriGeometryPoint:
                            case esriGeometryType.esriGeometryMultipoint:
                                node.ImageIndex = 0;
                                break;

                            case esriGeometryType.esriGeometryPolyline:
                            case esriGeometryType.esriGeometryLine:
                                node.ImageIndex = 1;
                                break;

                            case esriGeometryType.esriGeometryPolygon:
                            {
                                esriFeatureType featureType = layer2.FeatureClass.FeatureType;
                                if (featureType != esriFeatureType.esriFTSimple)
                                {
                                    if ((featureType != esriFeatureType.esriFTSimpleJunction) && (featureType == esriFeatureType.esriFTAnnotation))
                                    {
                                        node.ImageIndex = 4;
                                    }
                                }
                                else
                                {
                                    node.ImageIndex = 2;
                                }
                                break;
                            }
                            default:
                                node.ImageIndex = 3;
                                break;
                        }
                        node.SelectedImageIndex = node.ImageIndex;
                        this.mLayerColn.Add(layer);
                    }
                    this.TreeViewLayers.SelectedNode = this.TreeViewLayers.Nodes[0];
                    this.TreeViewLayers.Refresh();
                    this.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "InitialTreeView", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                if (this.mSelecting)
                {
                    return;
                }
                this.mSelecting = true;
                this.Cursor = Cursors.WaitCursor;
                this.bar2.Visible = false;
                this.InitialTreeView();
                this.ReadFeatureValue();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            this.mSelecting = false;
            this.Cursor = Cursors.Default;
        }

        private bool ReadFeatureValue()
        {
            try
            {
                if (this.mFeatureTable != null)
                {
                    this.mFeatureTable.Rows.Clear();
                    this.mFeatureTable.Columns.Clear();
                    this.mFeatureTable = null;
                }
                this.mFeatureColn = null;
                this.mFeatureColn = new ArrayList();
                this.DataGridFeatures.DataSource = null;
                this.BarStaticCount.Caption = "记录: 0";
                IFeatureCursor cursor = null;
                if (this.mShowKind == "AllFeature")
                {
                    if (this.mLayerColn == null)
                    {
                        return false;
                    }
                    TreeNode selectedNode = null;
                    selectedNode = this.TreeViewLayers.SelectedNode;
                    if (selectedNode == null)
                    {
                        return false;
                    }
                    ILayer layer = null;
                    try
                    {
                        int num = int.Parse(selectedNode.Tag.ToString().Substring(1));
                        layer = this.mLayerColn[num] as ILayer;
                    }
                    catch (Exception)
                    {
                    }
                    if (layer == null)
                    {
                        return false;
                    }
                    this.mCurLayer = layer as IFeatureLayer;
                    cursor = this.mCurLayer.FeatureClass.Search(null, false);
                }
                else if (this.mShowKind == "Selection")
                {
                    IFeatureSelection featureSelection = this.GetFeatureSelection();
                    if (featureSelection == null)
                    {
                        return false;
                    }
                    ISelectionSet selectionSet = null;
                    selectionSet = featureSelection.SelectionSet;
                    ICursor cursor2 = null;
                    selectionSet.Search(null, false, out cursor2);
                    cursor = cursor2 as IFeatureCursor;
                }
                IFeature pFeature = null;
                pFeature = cursor.NextFeature();
                if (pFeature == null)
                {
                    return false;
                }
                this.mFeatureTable = this.CreateFeatureDataTable(pFeature);
                if (this.mFeatureTable == null)
                {
                    return false;
                }
                int index = 0;
                int num3 = 0;
                string name = null;
                string geometryTypeName = null;
                IFeatureClass class2 = null;
                DataRow row = null;
                string[] strArray = null;
                string str3 = "";
                while (pFeature != null)
                {
                    num3++;
                    str3 = "";
                    class2 = pFeature.Class as IFeatureClass;
                    this.mFeatureColn.Add(pFeature);
                    row = this.mFeatureTable.NewRow();
                    row["序号"] = num3;
                    for (index = 0; index <= (pFeature.Fields.FieldCount - 1); index++)
                    {
                        name = pFeature.Fields.get_Field(index).Name;
                        if (name.ToUpper() != class2.ShapeFieldName.ToUpper())
                        {
                            if (object.ReferenceEquals(pFeature.get_Value(index), DBNull.Value))
                            {
                                geometryTypeName = "";
                            }
                            else if (pFeature.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeBlob)
                            {
                                geometryTypeName = "<BLOB>";
                            }
                            else if ((pFeature.Fields.get_Field(index).Name == pFeature.Class.OIDFieldName) || (pFeature.Fields.get_Field(index).Name == (pFeature.Class as IFeatureClass).ShapeFieldName))
                            {
                                if (str3 != "")
                                {
                                    str3 = str3 + "," + index;
                                }
                                else
                                {
                                    str3 = index.ToString();
                                }
                                geometryTypeName = pFeature.get_Value(index).ToString();
                            }
                            else if (((pFeature.Class as IFeatureClass).LengthField != null) && (pFeature.Fields.get_Field(index).Name == (pFeature.Class as IFeatureClass).LengthField.Name))
                            {
                                if (str3 != "")
                                {
                                    str3 = str3 + "," + index;
                                }
                                else
                                {
                                    str3 = index.ToString();
                                }
                                geometryTypeName = pFeature.get_Value(index).ToString();
                            }
                            else if (((pFeature.Class as IFeatureClass).AreaField != null) && (pFeature.Fields.get_Field(index).Name == (pFeature.Class as IFeatureClass).AreaField.Name))
                            {
                                if (str3 != "")
                                {
                                    str3 = str3 + "," + index;
                                }
                                else
                                {
                                    str3 = index.ToString();
                                }
                                geometryTypeName = pFeature.get_Value(index).ToString();
                            }
                            else if ((pFeature.Fields.get_Field(index).Domain != null) && (pFeature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                            {
                                try
                                {
                                    ICodedValueDomain domain = (ICodedValueDomain) pFeature.Fields.get_Field(index).Domain;
                                    long num4 = -1L;
                                    if (pFeature.get_Value(index) != null)
                                    {
                                        num4 = Convert.ToInt64(pFeature.get_Value(index));
                                        for (int j = 0; j < domain.CodeCount; j++)
                                        {
                                            if (num4 == Convert.ToInt64(domain.get_Value(j)))
                                            {
                                                geometryTypeName = domain.get_Name(j);
                                                goto Label_050E;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        geometryTypeName = "";
                                    }
                                }
                                catch (Exception)
                                {
                                    geometryTypeName = pFeature.get_Value(index).ToString();
                                }
                            }
                            else
                            {
                                geometryTypeName = Convert.ToString(pFeature.get_Value(index));
                            }
                        }
                        else
                        {
                            geometryTypeName = this.GetGeometryTypeName(pFeature.Shape);
                            if (str3 != "")
                            {
                                str3 = str3 + "," + index;
                            }
                            else
                            {
                                str3 = index.ToString();
                            }
                        }
                    Label_050E:
                        row[name] = geometryTypeName;
                    }
                    this.mFeatureTable.Rows.Add(row);
                    pFeature = cursor.NextFeature();
                }
                this.mFeatureTable.DefaultView.Sort = "序号 ASC";
                this.mFeatureTable.AcceptChanges();
                this.gridView1.Columns.Clear();
                this.DataGridFeatures.DataSource = this.mFeatureTable;
                strArray = str3.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        this.gridView1.Columns[int.Parse(strArray[i]) + 1].Visible = false;
                    }
                }
                this.BarStaticCount.Caption = "记录: " + Convert.ToString(this.mFeatureTable.Rows.Count);
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "ReadFeatureValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void TreeViewLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (this.mSelecting)
                {
                    return;
                }
                this.mSelecting = true;
                this.Cursor = Cursors.WaitCursor;
                this.ReadFeatureValue();
                this.mSelecting = false;
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlSelectFeatureResport2", "TreeViewLayers_AfterSelect", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
            this.mSelecting = false;
            this.Cursor = Cursors.Default;
        }

        private void TreeViewLayers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point p = new System.Drawing.Point();
                p.X = ((e.Location.X + base.Parent.Location.X) + base.Parent.Parent.Parent.Location.X) + base.Parent.Parent.Parent.Parent.Location.X;
                p.Y = ((e.Location.Y + base.Parent.Location.Y) + base.Parent.Parent.Parent.Location.Y) + base.Parent.Parent.Parent.Parent.Location.Y;
                this.popupMenu1.ShowPopup(p);
            }
        }

        public object hook
        {
            get
            {
                try
                {
                    if (this.m_HookHelper != null)
                    {
                        return this.m_HookHelper.Hook;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_HookHelper = new HookHelperClass();
                        this.m_HookHelper.Hook = value;
                        this.m_Map = this.m_HookHelper.FocusMap;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "要素属性列表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private enum contExportOptMode
        {
            contExportOptModeAll,
            contExportOptModeFilter,
            contExportOptModeSelection
        }

        private void BarButtonExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(this.mFeatureTable==null){
                XtraMessageBox.Show("请先选择要输出的图层", "警告");
                    return;
            }
            string path="";
            SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "导出报表";
                dialog.DefaultExt = ".xls";
                dialog.Filter = "Excel电子表(*.xls)|*.xls";
                dialog.FileName =path ;
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                path = dialog.FileName;
                ExportExcel(mFeatureTable, path);

        }
        public static bool ExportExcel(System.Data.DataTable dt, string path)
        {
            bool succeed = false;
            if (dt != null)
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (xlApp != null)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                        object oMissing = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;

                        xlSheet = (Worksheet)xlBook.Worksheets[1];
                        xlSheet.Name = dt.TableName;

                        int rowIndex = 1;
                        int colIndex = 1;
                        int colCount = dt.Columns.Count;
                        int rowCount = dt.Rows.Count;

                        //列名的处理
                        for (int i = 0; i < colCount; i++)
                        {
                            xlSheet.Cells[rowIndex, colIndex] = dt.Columns[i].ColumnName;
                            colIndex++;
                        }
                        //列名加粗显示
                        xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowIndex, colCount]).Font.Bold = true;
                        xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowCount + 1, colCount]).Font.Name = "Arial";
                        xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowCount + 1, colCount]).Font.Size = "10";
                        rowIndex++;

                        for (int i = 0; i < rowCount; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < colCount; j++)
                            {
                                xlSheet.Cells[rowIndex, colIndex] = dt.Rows[i][j].ToString();
                                colIndex++;
                            }
                            rowIndex++;
                        }
                        xlSheet.Cells.EntireColumn.AutoFit();

                        xlApp.DisplayAlerts = false;
                        path = System.IO.Path.GetFullPath(path);
                        xlBook.SaveCopyAs(path);
                        xlBook.Close(false, null, null);
                        xlApp.Workbooks.Close();
                        Marshal.ReleaseComObject(xlSheet);
                        Marshal.ReleaseComObject(xlBook);
                        xlBook = null;
                        succeed = true;
                    }
                    catch (Exception ex)
                    {
                        succeed = false;
                    }
                    finally
                    {
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                        int generation = System.GC.GetGeneration(xlApp);
                        xlApp = null;
                        System.GC.Collect(generation);
                    }
                }
            }
            return succeed;
        }
    }
}

