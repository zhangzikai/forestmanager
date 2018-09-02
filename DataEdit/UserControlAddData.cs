namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlAddData : UserControlBase1
    {
        private ButtonEdit buttonPath;
        private IContainer components = null;
        public GroupControl groupControl;
        private GroupControl groupControlCatalog;
        private GroupControl groupControlNOList;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private ImageList imageList1;
        private ImageList imageList2;
        private ImageList imageList3;
        private int kind = 0;
        internal Label label6;
        internal Label label9;
        internal Label labelCatalog;
        public Label labelLocation;
        private IFeatureWorkspace m_EditWorkspace;
        private bool mAddFlag;
        private RibbonPageGroup mapViewTools;
        private IBasicMap mBasicMap;
        private const string mClassName = "DataEdit.UserControlAddData";
        private ArrayList mDatasetList;
        private ArrayList mDatasetList2;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IGroupLayer mGroupLayer;
        private IHookHelper mHookHelper;
        private ArrayList mPathList = null;
        private bool mSelected = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mWorkspaceList;
        private ArrayList mWorkspaceList2;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private FormAddData pareForm;
        private SimpleButton simpleButtonRefrash;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonViewMap3;
        private string skind = "备份";
        public SplitContainerControl splitContainerControl1;
        private TextEdit textNo;
        private TreeList tListCatalog;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeList treeListno;

        public UserControlAddData()
        {
            this.InitializeComponent();
        }

        private void AddLayer(TreeList treeList)
        {
            try
            {
                if (treeList.Selection.Count != 0)
                {
                    IMap mBasicMap = this.mBasicMap as IMap;
                    ArrayList list = new ArrayList();
                    for (int i = 0; i < treeList.Selection.Count; i++)
                    {
                        IFeatureClass tag;
                        IFeatureLayer layer;
                        TreeListNode node = treeList.Selection[i];
                        if (node.Tag is IFeatureDataset)
                        {
                            for (int j = 0; j < node.Nodes.Count; j++)
                            {
                                tag = node.Nodes[j].Tag as IFeatureClass;
                                layer = new FeatureLayerClass();
                                layer.Name = tag.AliasName;
                                layer.FeatureClass = tag;
                                list.Add(layer);
                                if (this.mAddFlag)
                                {
                                    this.DoAdd(layer);
                                }
                            }
                        }
                        else if (node.Tag is IFeatureClass)
                        {
                            tag = node.Tag as IFeatureClass;
                            layer = new FeatureLayerClass();
                            layer.Name = tag.AliasName;
                            layer.FeatureClass = tag;
                            list.Add(layer);
                            if (this.mAddFlag)
                            {
                                this.DoAdd(layer);
                            }
                        }
                        else if (!(node.Tag is ITable) && (node.Tag is IRasterDataset))
                        {
                            IRasterDataset rasterDataset = node.Tag as IRasterDataset;
                            IRaster2 raster = (IRaster2) rasterDataset.CreateDefaultRaster();
                            IRasterLayer layer2 = new RasterLayerClass();
                            layer2.Name = rasterDataset.CompleteName;
                            layer2.CreateFromDataset(rasterDataset);
                            list.Add(layer2);
                            if (this.mAddFlag)
                            {
                                this.DoAdd(layer2);
                            }
                        }
                    }
                    this.pareForm.LayerList = list;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "AddLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void DoAdd(ILayer pLayer)
        {
            try
            {
                IMapLayers mBasicMap = this.mBasicMap as IMapLayers;
                if (this.mGroupLayer != null)
                {
                    this.mGroupLayer.Add(pLayer);
                }
                else
                {
                    this.mBasicMap.AddLayer(pLayer);
                }
                if (this.mGroupLayer == null)
                {
                    mBasicMap.MoveLayer(pLayer, 0);
                }
                else if (this.mBasicMap is IMap)
                {
                    mBasicMap.MoveLayerEx(this.mGroupLayer, this.mGroupLayer, pLayer, 0);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "DoAdd", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void EnumDirectories(TreeListNode ParentNode)
        {
            TreeListNode node = null;
            TreeListNode parentNode = null;
            TreeListNode node3 = null;
            this.treeListno.Columns[0].Width = this.treeListno.Width - 10;
            this.treeListno.OptionsView.ShowRoot = true;
            this.treeListno.SelectImageList = null;
            this.treeListno.StateImageList = this.imageList1;
            this.treeListno.OptionsView.ShowButtons = true;
            this.treeListno.TreeLineStyle = LineStyle.None;
            this.treeListno.RowHeight = 20;
            this.treeListno.OptionsBehavior.AutoPopulateColumns = true;
            this.treeListno.OptionsView.AutoWidth = true;
            this.treeListno.OptionsBehavior.Editable = false;
            this.treeListno.Nodes.Clear();
            this.treeListno.Tag = ParentNode.Tag;
            this.mWorkspaceList = new ArrayList();
            this.mDatasetList = new ArrayList();
            try
            {
                IFeatureWorkspace tag;
                ParentNode.Selected = true;
                string path = "";
                if (ParentNode.Tag is IFeatureWorkspace)
                {
                    tag = ParentNode.Tag as IFeatureWorkspace;
                    this.m_EditWorkspace = tag;
                    IDataset dataset = tag as IDataset;
                    IEnumDataset subsets = dataset.Subsets;
                    for (IDataset dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
                    {
                        IFeatureClass class2;
                        if (dataset3 is IFeatureClass)
                        {
                            class2 = dataset3 as IFeatureClass;
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = class2;
                            if (class2.ShapeType == esriGeometryType.esriGeometryPoint)
                            {
                                parentNode.StateImageIndex = 30;
                            }
                            else if (class2.ShapeType == esriGeometryType.esriGeometryPolyline)
                            {
                                parentNode.StateImageIndex = 0x1f;
                            }
                            else if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
                            {
                                parentNode.StateImageIndex = 0x20;
                            }
                            this.mDatasetList.Add(class2);
                        }
                        else if (dataset3 is IFeatureDataset)
                        {
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = dataset3;
                            parentNode.StateImageIndex = 0x1d;
                            this.mDatasetList.Add(dataset3 as IFeatureDataset);
                            IEnumDataset dataset4 = dataset3.Subsets;
                            for (IDataset dataset5 = dataset4.Next(); dataset5 != null; dataset5 = dataset4.Next())
                            {
                                if (dataset5 is IFeatureClass)
                                {
                                    class2 = dataset5 as IFeatureClass;
                                    node = this.treeListno.AppendNode(dataset3.Name, parentNode);
                                    node.SetValue(0, dataset5.Name);
                                    node.Tag = class2;
                                    if (class2.ShapeType == esriGeometryType.esriGeometryPoint)
                                    {
                                        node.StateImageIndex = 30;
                                    }
                                    else if (class2.ShapeType == esriGeometryType.esriGeometryPolyline)
                                    {
                                        node.StateImageIndex = 0x1f;
                                    }
                                    else if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
                                    {
                                        node.StateImageIndex = 0x20;
                                    }
                                    this.mDatasetList.Add(class2);
                                }
                            }
                        }
                        else if (dataset3 is ITable)
                        {
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = dataset3 as ITable;
                            parentNode.StateImageIndex = 0x22;
                            this.mDatasetList.Add(dataset3 as ITable);
                        }
                        else if (dataset3 is IRasterDataset)
                        {
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = dataset3 as IRasterDataset;
                            parentNode.StateImageIndex = 7;
                            this.mDatasetList.Add(dataset3 as IRasterDataset);
                        }
                        else if (dataset3 is IRasterCatalog)
                        {
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = dataset3 as IRasterCatalog;
                            parentNode.StateImageIndex = 7;
                            this.mDatasetList.Add(dataset3 as IRasterCatalog);
                        }
                        else
                        {
                            parentNode = this.treeListno.AppendNode(dataset3.Name, node3);
                            parentNode.SetValue(0, dataset3.Name);
                            parentNode.Tag = dataset3;
                            parentNode.StateImageIndex = 0x21;
                        }
                    }
                }
                else
                {
                    IFeatureClass class3;
                    string str3;
                    if (!(ParentNode.Tag is IRasterWorkspace))
                    {
                        if (ParentNode.Tag is IFeatureClass)
                        {
                            class3 = ParentNode.Tag as IFeatureClass;
                            int num = 0;
                            if (class3.ShapeType == esriGeometryType.esriGeometryPoint)
                            {
                                num = 30;
                            }
                            else if (class3.ShapeType == esriGeometryType.esriGeometryPolyline)
                            {
                                num = 0x1f;
                            }
                            else if (class3.ShapeType == esriGeometryType.esriGeometryPolygon)
                            {
                                num = 0x20;
                            }
                            parentNode = this.treeListno.AppendNode(class3.AliasName, node3);
                            parentNode.SetValue(0, class3.AliasName);
                            parentNode.Tag = class3;
                            parentNode.StateImageIndex = num;
                            this.mDatasetList.Add(class3);
                            return;
                        }
                        if (ParentNode.Tag is string)
                        {
                            path = ParentNode.Tag.ToString();
                            if (path.Substring(path.Length - 1, 1) != @"\")
                            {
                                path = path + @"\";
                            }
                            if (path.Substring(path.Length - 1) != "")
                            {
                                path = path ?? "";
                            }
                            ParentNode.Nodes.Clear();
                            foreach (string str2 in Directory.GetDirectories(path))
                            {
                                str3 = str2.Substring(ParentNode.GetValue(0).ToString().Length + 1, str2.ToString().Length - (ParentNode.GetValue(0).ToString().Length + 1));
                                str3 = str2.Substring(path.Length, str2.ToString().Length - path.Length);
                                parentNode = this.tListCatalog.AppendNode(str3, ParentNode);
                                parentNode.SetValue(0, str3);
                                parentNode.Tag = str2;
                                if ((str3.Length > 4) && (str3.Substring(str3.Length - 4, 4).ToLower() == ".gdb"))
                                {
                                    tag = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(str2, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                                    if (tag == null)
                                    {
                                        parentNode.StateImageIndex = 1;
                                    }
                                    else
                                    {
                                        parentNode.StateImageIndex = 3;
                                        parentNode.Tag = tag;
                                    }
                                }
                                else
                                {
                                    parentNode.StateImageIndex = 1;
                                }
                            }
                        }
                    }
                    this.mWorkspaceList = new ArrayList();
                    this.mDatasetList = new ArrayList();
                    foreach (string str4 in Directory.GetFiles(path))
                    {
                        str3 = str4.Substring(ParentNode.GetValue(0).ToString().Length + 1, str4.ToString().Length - (ParentNode.GetValue(0).ToString().Length + 1));
                        str3 = str4.Substring(path.Length, str4.ToString().Length - path.Length);
                        if ((str3.Length > 4) && (str3.Substring(str3.Length - 4, 4).ToLower() == ".mdb"))
                        {
                            tag = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(str4, WorkspaceSource.esriWSAccessWorkspaceFactory);
                            if (tag != null)
                            {
                                parentNode = this.tListCatalog.AppendNode(str3, ParentNode);
                                parentNode.SetValue(0, str3);
                                parentNode.StateImageIndex = 3;
                                parentNode.Tag = tag;
                            }
                        }
                        else
                        {
                            string[] strArray;
                            if ((str3.Length > 4) && (str3.Substring(str3.Length - 4, 4).ToLower() == ".shp"))
                            {
                                strArray = str3.Split(new char[] { '.' });
                                tag = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(ParentNode.Tag.ToString(), WorkspaceSource.esriWSShapefileWorkspaceFactory);
                                if (tag != null)
                                {
                                    try
                                    {
                                        class3 = tag.OpenFeatureClass(strArray[0]);
                                        parentNode = this.tListCatalog.AppendNode(str3, ParentNode);
                                        parentNode.SetValue(0, str3);
                                        parentNode.StateImageIndex = 3;
                                        parentNode.Tag = class3;
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                IWorkspaceFactory factory = new RasterWorkspaceFactoryClass();
                                IRasterWorkspace workspace2 = null;
                                IWorkspace workspace3 = null;
                                IRasterDataset dataset6 = null;
                                strArray = str3.Split(new char[] { '.' });
                                if ((strArray[1].ToLower() == "tif") || (strArray[1].ToLower() == "tiff"))
                                {
                                    try
                                    {
                                        workspace2 = (IRasterWorkspace) factory.OpenFromFile(path, 0);
                                        dataset6 = workspace2.OpenRasterDataset(strArray[0] + ".tif");
                                        if (workspace2 != null)
                                        {
                                            parentNode = this.tListCatalog.AppendNode(str3, ParentNode);
                                            parentNode.SetValue(0, str3);
                                            parentNode.StateImageIndex = 3;
                                            parentNode.Tag = workspace2;
                                        }
                                        else
                                        {
                                            this.tListCatalog.AppendNode(str3, ParentNode).StateImageIndex = 4;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        workspace2 = (IRasterWorkspace) factory.OpenFromFile(path + strArray[0], 0);
                                        workspace3 = workspace2 as IWorkspace;
                                        if ((workspace2 != null) && workspace2.IsWorkspace(path + strArray[0]))
                                        {
                                            parentNode = this.tListCatalog.AppendNode(str3, ParentNode);
                                            parentNode.SetValue(0, str3);
                                            parentNode.StateImageIndex = 3;
                                            parentNode.Tag = workspace2;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                    }
                    this.mSelected = true;
                    ParentNode.ExpandAll();
                    this.mSelected = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitialCatalogList()
        {
            try
            {
                TreeListNode node2 = null;
                TreeListNode parentNode = null;
                this.tListCatalog.ClearNodes();
                this.tListCatalog.Columns[0].Width = this.tListCatalog.Width;
                this.tListCatalog.Columns[1].Width = 0;
                this.tListCatalog.OptionsView.ShowRoot = true;
                this.tListCatalog.SelectImageList = null;
                this.tListCatalog.StateImageList = this.imageCollection1;
                this.tListCatalog.OptionsView.ShowButtons = true;
                this.tListCatalog.TreeLineStyle = LineStyle.None;
                this.tListCatalog.RowHeight = 20;
                this.tListCatalog.OptionsBehavior.AutoPopulateColumns = true;
                this.tListCatalog.OptionsView.AutoWidth = true;
                this.tListCatalog.Columns[0].Width = this.tListCatalog.Width - 20;
                this.tListCatalog.Columns[1].Width = 0;
                this.tListCatalog.OptionsBehavior.Editable = false;
                foreach (string str in Directory.GetLogicalDrives())
                {
                    node2 = this.tListCatalog.AppendNode(str.Substring(0, str.Length - 1), parentNode);
                    node2.SetValue(0, str.Substring(0, str.Length - 1));
                    node2.Tag = str;
                    node2.StateImageIndex = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "InitialCatalogList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControls()
        {
            try
            {
                this.InitialCatalogList();
                this.treeListno.Nodes.Clear();
                this.buttonPath.Enabled = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "InitialcListFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlAddData));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlCatalog = new DevExpress.XtraEditors.GroupControl();
            this.tListCatalog = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.labelCatalog = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonPath = new DevExpress.XtraEditors.ButtonEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonRefrash = new DevExpress.XtraEditors.SimpleButton();
            this.textNo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControlNOList = new DevExpress.XtraEditors.GroupControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.treeListno = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.simpleButtonViewMap3 = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).BeginInit();
            this.groupControlCatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).BeginInit();
            this.groupControlNOList.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl.AppearanceCaption.Image")));
            this.groupControl.AppearanceCaption.Options.UseImage = true;
            this.groupControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.groupControl.Controls.Add(this.splitContainerControl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl.Location = new System.Drawing.Point(0, 30);
            this.groupControl.LookAndFeel.SkinName = "Blue";
            this.groupControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl.Name = "groupControl";
            this.groupControl.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.groupControl.ShowCaption = false;
            this.groupControl.Size = new System.Drawing.Size(427, 717);
            this.groupControl.TabIndex = 4;
            this.groupControl.TabStop = true;
            this.groupControl.Text = "添加数据";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControlCatalog);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlNOList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(427, 716);
            this.splitContainerControl1.SplitterPosition = 294;
            this.splitContainerControl1.TabIndex = 92;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.splitContainerControl1.Resize += new System.EventHandler(this.splitContainerControl1_Resize);
            // 
            // groupControlCatalog
            // 
            this.groupControlCatalog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlCatalog.Controls.Add(this.tListCatalog);
            this.groupControlCatalog.Controls.Add(this.labelCatalog);
            this.groupControlCatalog.Controls.Add(this.panel5);
            this.groupControlCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlCatalog.Location = new System.Drawing.Point(0, 0);
            this.groupControlCatalog.Name = "groupControlCatalog";
            this.groupControlCatalog.Padding = new System.Windows.Forms.Padding(6, 4, 6, 0);
            this.groupControlCatalog.ShowCaption = false;
            this.groupControlCatalog.Size = new System.Drawing.Size(427, 294);
            this.groupControlCatalog.TabIndex = 88;
            this.groupControlCatalog.TabStop = true;
            this.groupControlCatalog.Text = "数据目录";
            // 
            // tListCatalog
            // 
            this.tListCatalog.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.tListCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListCatalog.Location = new System.Drawing.Point(6, 32);
            this.tListCatalog.Name = "tListCatalog";
            this.tListCatalog.BeginUnboundLoad();
            this.tListCatalog.AppendNode(new object[] {
            "node",
            null}, -1, 0, 0, 0);
            this.tListCatalog.AppendNode(new object[] {
            "node1",
            null}, 0, 0, 0, 2);
            this.tListCatalog.AppendNode(new object[] {
            "node11",
            null}, 1, 0, 0, 1);
            this.tListCatalog.AppendNode(new object[] {
            null,
            null}, -1);
            this.tListCatalog.EndUnboundLoad();
            this.tListCatalog.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tListCatalog.OptionsView.ShowColumns = false;
            this.tListCatalog.OptionsView.ShowHorzLines = false;
            this.tListCatalog.OptionsView.ShowIndicator = false;
            this.tListCatalog.OptionsView.ShowVertLines = false;
            this.tListCatalog.Size = new System.Drawing.Size(415, 226);
            this.tListCatalog.StateImageList = this.imageCollection1;
            this.tListCatalog.TabIndex = 0;
            this.tListCatalog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tListCatalog_MouseUp);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn1";
            this.treeListColumn3.FieldName = "treeListColumn1";
            this.treeListColumn3.MinWidth = 87;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 87;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn2";
            this.treeListColumn4.FieldName = "treeListColumn2";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // labelCatalog
            // 
            this.labelCatalog.BackColor = System.Drawing.Color.Transparent;
            this.labelCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCatalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCatalog.ImageIndex = 6;
            this.labelCatalog.ImageList = this.imageList1;
            this.labelCatalog.Location = new System.Drawing.Point(6, 4);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(415, 28);
            this.labelCatalog.TabIndex = 83;
            this.labelCatalog.Text = "     数据目录";
            this.labelCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blank16.ico");
            this.imageList1.Images.SetKeyName(1, "tick16.ico");
            this.imageList1.Images.SetKeyName(2, "PART16.ICO");
            this.imageList1.Images.SetKeyName(3, "application_view_detail.png");
            this.imageList1.Images.SetKeyName(4, "application_view_gallery.png");
            this.imageList1.Images.SetKeyName(5, "application_view_icons.png");
            this.imageList1.Images.SetKeyName(6, "application_view_tile.png");
            this.imageList1.Images.SetKeyName(7, "image.png");
            this.imageList1.Images.SetKeyName(8, "image_edit.png");
            this.imageList1.Images.SetKeyName(9, "layers.png");
            this.imageList1.Images.SetKeyName(10, "layout_content.png");
            this.imageList1.Images.SetKeyName(11, "map.png");
            this.imageList1.Images.SetKeyName(12, "map_add.png");
            this.imageList1.Images.SetKeyName(13, "map_delete.png");
            this.imageList1.Images.SetKeyName(14, "map_edit.png");
            this.imageList1.Images.SetKeyName(15, "map_go.png");
            this.imageList1.Images.SetKeyName(16, "map_magnify.png");
            this.imageList1.Images.SetKeyName(17, "overlays.png");
            this.imageList1.Images.SetKeyName(18, "page.png");
            this.imageList1.Images.SetKeyName(19, "page_add.png");
            this.imageList1.Images.SetKeyName(20, "page_copy.png");
            this.imageList1.Images.SetKeyName(21, "page_delete.png");
            this.imageList1.Images.SetKeyName(22, "page_edit.png");
            this.imageList1.Images.SetKeyName(23, "page_paste.png");
            this.imageList1.Images.SetKeyName(24, "page_red.png");
            this.imageList1.Images.SetKeyName(25, "page_white.png");
            this.imageList1.Images.SetKeyName(26, "page_white_world.png");
            this.imageList1.Images.SetKeyName(27, "page_world.png");
            this.imageList1.Images.SetKeyName(28, "(181).gif");
            this.imageList1.Images.SetKeyName(29, "objects (3).png");
            this.imageList1.Images.SetKeyName(30, "Marker.bmp");
            this.imageList1.Images.SetKeyName(31, "Line.bmp");
            this.imageList1.Images.SetKeyName(32, "Polygon.bmp");
            this.imageList1.Images.SetKeyName(33, "(414).gif");
            this.imageList1.Images.SetKeyName(34, "application_view_columns.png");
            this.imageList1.Images.SetKeyName(35, "(321).gif");
            this.imageList1.Images.SetKeyName(36, "(322).gif");
            this.imageList1.Images.SetKeyName(37, "(323).gif");
            this.imageList1.Images.SetKeyName(38, "setting.ico");
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.buttonPath);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.simpleButtonRefrash);
            this.panel5.Controls.Add(this.textNo);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(6, 258);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.panel5.Size = new System.Drawing.Size(415, 36);
            this.panel5.TabIndex = 79;
            // 
            // buttonPath
            // 
            this.buttonPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPath.Enabled = false;
            this.buttonPath.Location = new System.Drawing.Point(64, 6);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonPath.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "指定路径", null, null, false)});
            this.buttonPath.Size = new System.Drawing.Size(302, 20);
            this.buttonPath.TabIndex = 76;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(366, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(7, 24);
            this.panel6.TabIndex = 82;
            // 
            // simpleButtonRefrash
            // 
            this.simpleButtonRefrash.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRefrash.Location = new System.Drawing.Point(373, 6);
            this.simpleButtonRefrash.Name = "simpleButtonRefrash";
            this.simpleButtonRefrash.Size = new System.Drawing.Size(42, 24);
            this.simpleButtonRefrash.TabIndex = 81;
            this.simpleButtonRefrash.Text = "刷新";
            // 
            // textNo
            // 
            this.textNo.Enabled = false;
            this.textNo.Location = new System.Drawing.Point(710, 8);
            this.textNo.Name = "textNo";
            this.textNo.Size = new System.Drawing.Size(183, 20);
            this.textNo.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 74;
            this.label6.Text = "    路径";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlNOList
            // 
            this.groupControlNOList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlNOList.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControlNOList.ContentImage")));
            this.groupControlNOList.Controls.Add(this.panel7);
            this.groupControlNOList.Controls.Add(this.label9);
            this.groupControlNOList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlNOList.Location = new System.Drawing.Point(0, 0);
            this.groupControlNOList.LookAndFeel.SkinName = "Blue";
            this.groupControlNOList.Name = "groupControlNOList";
            this.groupControlNOList.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.groupControlNOList.ShowCaption = false;
            this.groupControlNOList.Size = new System.Drawing.Size(427, 417);
            this.groupControlNOList.TabIndex = 87;
            this.groupControlNOList.Text = "图层列表";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.treeListno);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(6, 28);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel7.Size = new System.Drawing.Size(415, 389);
            this.panel7.TabIndex = 79;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // treeListno
            // 
            this.treeListno.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn5});
            this.treeListno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListno.Location = new System.Drawing.Point(0, 0);
            this.treeListno.Name = "treeListno";
            this.treeListno.BeginUnboundLoad();
            this.treeListno.AppendNode(new object[] {
            null}, -1);
            this.treeListno.AppendNode(new object[] {
            null}, 0);
            this.treeListno.AppendNode(new object[] {
            null}, 0);
            this.treeListno.AppendNode(new object[] {
            null}, -1);
            this.treeListno.EndUnboundLoad();
            this.treeListno.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListno.OptionsSelection.MultiSelect = true;
            this.treeListno.OptionsView.ShowColumns = false;
            this.treeListno.OptionsView.ShowHorzLines = false;
            this.treeListno.OptionsView.ShowIndicator = false;
            this.treeListno.OptionsView.ShowRoot = false;
            this.treeListno.OptionsView.ShowVertLines = false;
            this.treeListno.Size = new System.Drawing.Size(415, 344);
            this.treeListno.TabIndex = 0;
            this.treeListno.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListno_MouseUp);
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "treeListColumn5";
            this.treeListColumn5.FieldName = "treeListColumn5";
            this.treeListColumn5.MinWidth = 34;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 0;
            this.treeListColumn5.Width = 93;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.simpleButtonViewMap3);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.simpleButtonSelect);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 344);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel8.Size = new System.Drawing.Size(415, 40);
            this.panel8.TabIndex = 79;
            // 
            // simpleButtonViewMap3
            // 
            this.simpleButtonViewMap3.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonViewMap3.Enabled = false;
            this.simpleButtonViewMap3.ImageIndex = 6;
            this.simpleButtonViewMap3.ImageList = this.imageCollection1;
            this.simpleButtonViewMap3.Location = new System.Drawing.Point(217, 6);
            this.simpleButtonViewMap3.Name = "simpleButtonViewMap3";
            this.simpleButtonViewMap3.Size = new System.Drawing.Size(93, 34);
            this.simpleButtonViewMap3.TabIndex = 77;
            this.simpleButtonViewMap3.Text = "添加";
            this.simpleButtonViewMap3.Click += new System.EventHandler(this.simpleButtonViewMap3_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(310, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(12, 34);
            this.panel9.TabIndex = 79;
            this.panel9.Visible = false;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageIndex = 7;
            this.simpleButtonSelect.ImageList = this.imageCollection1;
            this.simpleButtonSelect.Location = new System.Drawing.Point(322, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(93, 34);
            this.simpleButtonSelect.TabIndex = 78;
            this.simpleButtonSelect.Text = "取消";
            this.simpleButtonSelect.Visible = false;
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 10;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(415, 28);
            this.label9.TabIndex = 84;
            this.label9.Text = "     图层列表";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Application.png");
            this.imageList2.Images.SetKeyName(1, "Blue pin.png");
            this.imageList2.Images.SetKeyName(2, "Comment.png");
            this.imageList2.Images.SetKeyName(3, "Earth.png");
            this.imageList2.Images.SetKeyName(4, "Green pin.png");
            this.imageList2.Images.SetKeyName(5, "Home.png");
            this.imageList2.Images.SetKeyName(6, "Modify (3).png");
            this.imageList2.Images.SetKeyName(7, "Notes.png");
            this.imageList2.Images.SetKeyName(8, "Pinion.png");
            this.imageList2.Images.SetKeyName(9, "Red pin.png");
            this.imageList2.Images.SetKeyName(10, "Sync.png");
            this.imageList2.Images.SetKeyName(11, "Table.png");
            this.imageList2.Images.SetKeyName(12, "world (2).png");
            this.imageList2.Images.SetKeyName(13, "Wrench (2).png");
            this.imageList2.Images.SetKeyName(14, "Yellow pin.png");
            this.imageList2.Images.SetKeyName(15, "14.png");
            this.imageList2.Images.SetKeyName(16, "22.png");
            this.imageList2.Images.SetKeyName(17, "59 (3).png");
            this.imageList2.Images.SetKeyName(18, "apacheconf.png");
            this.imageList2.Images.SetKeyName(19, "drawing_pen (6).png");
            this.imageList2.Images.SetKeyName(20, "home (4).png");
            this.imageList2.Images.SetKeyName(21, "objects (6).png");
            this.imageList2.Images.SetKeyName(22, "Picture.png");
            this.imageList2.Images.SetKeyName(23, "resort (6).png");
            this.imageList2.Images.SetKeyName(24, "Applications.png");
            this.imageList2.Images.SetKeyName(25, "Char.png");
            this.imageList2.Images.SetKeyName(26, "Documents.png");
            this.imageList2.Images.SetKeyName(27, "31.ico");
            this.imageList2.Images.SetKeyName(28, "My Computer.ICO");
            this.imageList2.Images.SetKeyName(29, "My Documents.ICO");
            this.imageList2.Images.SetKeyName(30, "001_38.gif");
            this.imageList2.Images.SetKeyName(31, "001_45.gif");
            this.imageList2.Images.SetKeyName(32, "applications.png");
            this.imageList2.Images.SetKeyName(33, "book_24.png");
            this.imageList2.Images.SetKeyName(34, "color_mixer_24.png");
            this.imageList2.Images.SetKeyName(35, "config-xfree_24x24_2.png");
            this.imageList2.Images.SetKeyName(36, "gnome-fs-web_24x24.png");
            this.imageList2.Images.SetKeyName(37, "layers2-24.png");
            this.imageList2.Images.SetKeyName(38, "pathing2.png");
            this.imageList2.Images.SetKeyName(39, "web_24.ico");
            this.imageList2.Images.SetKeyName(40, "world_24.png");
            this.imageList2.Images.SetKeyName(41, "24Record.ico");
            this.imageList2.Images.SetKeyName(42, "24Refresh.ico");
            this.imageList2.Images.SetKeyName(43, "ContentsButton.ico");
            this.imageList2.Images.SetKeyName(44, "CustomButton.ico");
            this.imageList2.Images.SetKeyName(45, "IMBigToolbarShare.ico");
            this.imageList2.Images.SetKeyName(46, "Checkbox%20Empty.png");
            this.imageList2.Images.SetKeyName(47, "Checkbox%20Full.png");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "Application.png");
            this.imageList3.Images.SetKeyName(1, "Blue pin.png");
            this.imageList3.Images.SetKeyName(2, "Comment.png");
            this.imageList3.Images.SetKeyName(3, "Earth.png");
            this.imageList3.Images.SetKeyName(4, "Green pin.png");
            this.imageList3.Images.SetKeyName(5, "Home.png");
            this.imageList3.Images.SetKeyName(6, "Modify (3).png");
            this.imageList3.Images.SetKeyName(7, "Notes.png");
            this.imageList3.Images.SetKeyName(8, "Pinion.png");
            this.imageList3.Images.SetKeyName(9, "Red pin.png");
            this.imageList3.Images.SetKeyName(10, "Sync.png");
            this.imageList3.Images.SetKeyName(11, "Table.png");
            this.imageList3.Images.SetKeyName(12, "world (2).png");
            this.imageList3.Images.SetKeyName(13, "Wrench (2).png");
            this.imageList3.Images.SetKeyName(14, "Yellow pin.png");
            this.imageList3.Images.SetKeyName(15, "14.png");
            this.imageList3.Images.SetKeyName(16, "22.png");
            this.imageList3.Images.SetKeyName(17, "59 (3).png");
            this.imageList3.Images.SetKeyName(18, "apacheconf.png");
            this.imageList3.Images.SetKeyName(19, "drawing_pen (6).png");
            this.imageList3.Images.SetKeyName(20, "home (4).png");
            this.imageList3.Images.SetKeyName(21, "objects (6).png");
            this.imageList3.Images.SetKeyName(22, "Picture.png");
            this.imageList3.Images.SetKeyName(23, "resort (6).png");
            this.imageList3.Images.SetKeyName(24, "Applications.png");
            this.imageList3.Images.SetKeyName(25, "Char.png");
            this.imageList3.Images.SetKeyName(26, "Documents.png");
            this.imageList3.Images.SetKeyName(27, "31.ico");
            this.imageList3.Images.SetKeyName(28, "My Computer.ICO");
            this.imageList3.Images.SetKeyName(29, "My Documents.ICO");
            this.imageList3.Images.SetKeyName(30, "001_38.gif");
            this.imageList3.Images.SetKeyName(31, "001_45.gif");
            this.imageList3.Images.SetKeyName(32, "applications.png");
            this.imageList3.Images.SetKeyName(33, "book_24.png");
            this.imageList3.Images.SetKeyName(34, "color_mixer_24.png");
            this.imageList3.Images.SetKeyName(35, "config-xfree_24x24_2.png");
            this.imageList3.Images.SetKeyName(36, "gnome-fs-web_24x24.png");
            this.imageList3.Images.SetKeyName(37, "layers2-24.png");
            this.imageList3.Images.SetKeyName(38, "pathing2.png");
            this.imageList3.Images.SetKeyName(39, "web_24.ico");
            this.imageList3.Images.SetKeyName(40, "world_24.png");
            this.imageList3.Images.SetKeyName(41, "blank16.ico");
            this.imageList3.Images.SetKeyName(42, "PART16.ICO");
            this.imageList3.Images.SetKeyName(43, "tick16.ico");
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(0, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(427, 30);
            this.labelLocation.TabIndex = 21;
            this.labelLocation.Text = "      地图查找          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlAddData
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlAddData";
            this.Size = new System.Drawing.Size(427, 747);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).EndInit();
            this.groupControlCatalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).EndInit();
            this.groupControlNOList.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(IBasicMap map, IGroupLayer glayer, FormAddData form, bool bAddFlag, IFeatureLayer player)
        {
            try
            {
                this.mBasicMap = map;
                this.mGroupLayer = glayer;
                this.pareForm = form;
                this.mAddFlag = bAddFlag;
                this.mEditLayer = player;
                this.InitialControls();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            if (this.pareForm != null)
            {
                this.pareForm.Close();
            }
        }

        private void simpleButtonViewMap3_Click(object sender, EventArgs e)
        {
            this.AddLayer(this.treeListno);
            if (this.simpleButtonSelect.Visible && (this.pareForm != null))
            {
                this.pareForm.Hide();
            }
        }

        private void splitContainerControl1_Resize(object sender, EventArgs e)
        {
            if (this.splitContainerControl1.Horizontal)
            {
                this.splitContainerControl1.SplitterPosition = this.splitContainerControl1.Width / 2;
            }
            else
            {
                this.splitContainerControl1.SplitterPosition = this.splitContainerControl1.Height / 2;
            }
        }

        private void tListCatalog_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
                if (this.tListCatalog.FocusedNode != null)
                {
                    if (!this.tListCatalog.FocusedNode.HasChildren)
                    {
                        this.EnumDirectories(this.tListCatalog.FocusedNode);
                        if (this.tListCatalog.FocusedNode.HasChildren)
                        {
                            if (this.tListCatalog.FocusedNode.ParentNode != null)
                            {
                                this.tListCatalog.FocusedNode.StateImageIndex = 2;
                            }
                            this.tListCatalog.FocusedNode.Expanded = true;
                        }
                    }
                    else if (this.tListCatalog.FocusedNode.StateImageIndex == 1)
                    {
                        this.tListCatalog.FocusedNode.StateImageIndex = 2;
                        this.tListCatalog.FocusedNode.Expanded = true;
                    }
                    else if (this.tListCatalog.FocusedNode.StateImageIndex == 2)
                    {
                        this.tListCatalog.FocusedNode.StateImageIndex = 1;
                        this.tListCatalog.FocusedNode.Expanded = false;
                    }
                    string currentDirectory = Directory.GetCurrentDirectory();
                    try
                    {
                        Directory.SetCurrentDirectory(this.tListCatalog.FocusedNode.Tag.ToString());
                        currentDirectory = Directory.GetCurrentDirectory();
                    }
                    catch (Exception)
                    {
                        Directory.SetCurrentDirectory(this.tListCatalog.FocusedNode.ParentNode.Tag.ToString());
                        currentDirectory = Directory.GetCurrentDirectory() + @"\" + this.tListCatalog.FocusedNode.GetValue(0);
                    }
                    this.buttonPath.Text = currentDirectory;
                }
                this.simpleButtonViewMap3.Enabled = false;
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlAddData", "tListCatalog_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void treeListno_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.treeListno.FocusedNode.Selected)
            {
                if (this.treeListno.FocusedNode.Tag is IFeatureClass)
                {
                    if (this.mEditLayer != null)
                    {
                        IFeatureClass tag = this.treeListno.FocusedNode.Tag as IFeatureClass;
                        if (tag.ShapeType == this.mEditLayer.FeatureClass.ShapeType)
                        {
                            this.simpleButtonViewMap3.Enabled = true;
                        }
                        else
                        {
                            this.simpleButtonViewMap3.Enabled = false;
                        }
                    }
                    else
                    {
                        this.simpleButtonViewMap3.Enabled = true;
                    }
                }
                else if (this.treeListno.FocusedNode.Tag is IFeatureDataset)
                {
                    this.simpleButtonViewMap3.Enabled = true;
                }
                else if (this.treeListno.FocusedNode.Tag is ITable)
                {
                    this.simpleButtonViewMap3.Enabled = false;
                }
                else if (this.treeListno.FocusedNode.Tag is IRasterLayer)
                {
                    this.simpleButtonViewMap3.Enabled = false;
                }
                else if (this.treeListno.FocusedNode.Tag is IRelationshipClass)
                {
                    this.simpleButtonViewMap3.Enabled = false;
                }
                else
                {
                    this.simpleButtonViewMap3.Enabled = true;
                }
            }
        }

        public bool CancelVisible
        {
            get
            {
                try
                {
                    return this.simpleButtonSelect.Visible;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            set
            {
                try
                {
                    this.simpleButtonSelect.Visible = value;
                    this.panel9.Visible = value;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "DataEdit.UserControlAddData", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public bool Horizontal
        {
            get
            {
                try
                {
                    return this.splitContainerControl1.Horizontal;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            set
            {
                try
                {
                    this.splitContainerControl1.Horizontal = value;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "DataEdit.UserControlAddData", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public bool TitleVisible
        {
            get
            {
                try
                {
                    return this.labelLocation.Visible;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            set
            {
                try
                {
                    this.labelLocation.Visible = value;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "DataEdit.UserControlAddData", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}

