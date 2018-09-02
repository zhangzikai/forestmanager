namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlSaveData : UserControlBase1
    {
        public ButtonEdit buttonEditDBName;
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
        internal Label label1;
        internal Label label6;
        internal Label label9;
        internal Label labelCatalog;
        public Label labelLocation;
        private IFeatureWorkspace m_EditWorkspace;
        private IBasicMap mBasicMap;
        private bool mCancelFlag;
        private const string mClassName = "DataEdit.UserControlSaveData";
        private ArrayList mDatasetList;
        private ArrayList mDatasetList2;
        private string mDatasetName = "";
        private string mEditKind = "";
        private string mEditKind2 = "";
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace = null;
        private IGroupLayer mGroupLayer;
        private IHookHelper mHookHelper;
        private ArrayList mLayerList;
        private ArrayList mPathList = null;
        private bool mSaveFlag;
        private bool mSelected = false;
        private ISpatialReference mSpatialReference = null;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTLayerList;
        private ArrayList mWorkspaceList;
        private ArrayList mWorkspaceList2;
        public Panel panel1;
        private Panel panel2;
        private Panel panel6;
        private Panel panel9;
        public Panel panelPath;
        public Panel panelSave;
        private FormSaveData pareForm;
        private SimpleButton simpleButtonRefrash;
        private SimpleButton simpleButtonSave;
        private SimpleButton simpleButtonSelect;
        private string skind = "备份";
        public SplitContainerControl splitContainerControl1;
        private TextEdit textNo;
        private TreeList tListCatalog;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeList treeListno;

        public UserControlSaveData()
        {
            this.InitializeComponent();
        }

        private void buttonEditDBName_EditValueChanged(object sender, EventArgs e)
        {
            if (this.buttonEditDBName.Text == "")
            {
                this.simpleButtonSave.Enabled = false;
            }
            else if (this.tListCatalog.Selection.Count == 0)
            {
                this.simpleButtonSave.Enabled = false;
            }
            else if (this.tListCatalog.Selection[0].Tag is IFeatureWorkspace)
            {
                IFeatureWorkspace tag = this.tListCatalog.Selection[0].Tag as IFeatureWorkspace;
                this.m_EditWorkspace = tag;
                IDataset dataset = tag as IDataset;
                if (dataset != null)
                {
                    if (dataset.Name.Contains(".gdb") || dataset.Name.Contains(".mdb"))
                    {
                        this.buttonEditDBName.Tag = tag;
                        this.simpleButtonSave.Enabled = true;
                    }
                    else
                    {
                        this.buttonEditDBName.Tag = (tag as IWorkspace).PathName;
                        if (this.buttonEditDBName.Text != "")
                        {
                            this.simpleButtonSave.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                string str = this.tListCatalog.Selection[0].Tag.ToString();
                this.buttonEditDBName.Tag = str;
                this.simpleButtonSave.Enabled = true;
            }
        }

        private void buttonPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '8')
            {
            }
        }

        private bool CreateLayer(IFeatureWorkspace pFWorkspace, ArrayList pList)
        {
            try
            {
                if (pFWorkspace == null)
                {
                    return false;
                }
                IWorkspace workspace = pFWorkspace as IWorkspace;
                IFeatureDataset dataset = null;
                this.mTLayerList = new ArrayList();
                try
                {
                    pFWorkspace.OpenFeatureDataset(this.mGroupLayer.Name).Delete();
                }
                catch (Exception)
                {
                }
                dataset = pFWorkspace.CreateFeatureDataset(this.mGroupLayer.Name, this.mSpatialReference);
                if (dataset == null)
                {
                    return false;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                for (int i = 0; i < pList.Count; i++)
                {
                    IFeatureLayer layer = pList[i] as IFeatureLayer;
                    IFeatureClass featureClass = layer.FeatureClass;
                    if (featureClass != null)
                    {
                        Select process = new Select();
                        process.in_features = featureClass;
                        string str = workspace.PathName + @"\" + dataset.Name + @"\" + (featureClass as IDataset).Name;
                        process.out_feature_class = str;
                        process.where_clause = "";
                        object obj2 = geoprocessor.Execute(process, null);
                        IDataset dataset2 = null;
                        IEnumDataset dataset3 = dataset.Subsets;
                        dataset2 = dataset3.Next();
                        while (dataset2 != null)
                        {
                            if (dataset2.Name == (featureClass as IDataset).Name)
                            {
                                break;
                            }
                            dataset2 = dataset3.Next();
                        }
                        if (dataset2 == null)
                        {
                            return false;
                        }
                        string messages = "";
                        object severity = null;
                        messages = geoprocessor.GetMessages(ref severity);
                    }
                }
                IEnumDataset subsets = dataset.Subsets;
                for (IDataset dataset5 = subsets.Next(); dataset5 != null; dataset5 = subsets.Next())
                {
                    IFeatureLayer layer2 = new FeatureLayerClass();
                    layer2.FeatureClass = dataset5 as IFeatureClass;
                    layer2.Name = dataset5.Name;
                    this.mTLayerList.Add(layer2);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "CreateLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool CreateWorkspace(string sPath, string sName)
        {
            try
            {
                IWorkspaceFactory2 factory = null;
                IWorkspaceName name = null;
                this.mFeatureWorkspace = null;
                if (this.tListCatalog.Selection.Count > 0)
                {
                    if (this.tListCatalog.Selection[0].GetDisplayText(0) != this.buttonEditDBName.Text)
                    {
                        IWorkspace workspace;
                        if (sName.Contains(".gdb"))
                        {
                            factory = new FileGDBWorkspaceFactoryClass();
                            workspace = factory.OpenFromFile(sPath + @"\" + sName, 0);
                            name = factory.Create(sPath + @"\", sName, null, 0);
                        }
                        else if (sName.Contains(".mdb"))
                        {
                            factory = new AccessWorkspaceFactoryClass();
                            workspace = factory.OpenFromFile(sPath + @"\" + sName, 0);
                            name = factory.Create(sPath + @"\", sName, null, 0);
                        }
                        else
                        {
                            factory = new FileGDBWorkspaceFactoryClass();
                            name = factory.Create(sPath + @"\", sName + ".gdb", null, 0);
                        }
                        IName name2 = (IName) name;
                        IWorkspace workspace2 = (IWorkspace) name2.Open();
                        this.mFeatureWorkspace = workspace2 as IFeatureWorkspace;
                    }
                    else if (sName.Contains(".gdb") || sName.Contains(".mdb"))
                    {
                        this.mFeatureWorkspace = this.buttonEditDBName.Tag as IFeatureWorkspace;
                    }
                }
                return (this.mFeatureWorkspace != null);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "CreateDataValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    if (dataset != null)
                    {
                        if (dataset.Name.Contains(".gdb") || dataset.Name.Contains(".mdb"))
                        {
                            this.buttonEditDBName.Tag = tag;
                            this.buttonEditDBName.Text = dataset.Name;
                            this.simpleButtonSave.Enabled = true;
                        }
                        else
                        {
                            this.buttonEditDBName.Tag = (tag as IWorkspace).PathName;
                            if (this.buttonEditDBName.Text != "")
                            {
                                this.simpleButtonSave.Enabled = true;
                            }
                        }
                    }
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
                                    else if (class2.ShapeType == esriGeometryType.esriGeometryMultiPatch)
                                    {
                                        node.StateImageIndex = 0x21;
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
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "EnumDirectories", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "InitialCatalogList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControls()
        {
            try
            {
                if (this.mSaveFlag)
                {
                    this.simpleButtonSave.Text = "保存";
                }
                else
                {
                    this.simpleButtonSave.Text = "确定";
                }
                this.InitialCatalogList();
                this.treeListno.Nodes.Clear();
                this.buttonPath.Enabled = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "InitialcListFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSaveData));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlCatalog = new DevExpress.XtraEditors.GroupControl();
            this.tListCatalog = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.labelCatalog = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.groupControlNOList = new DevExpress.XtraEditors.GroupControl();
            this.treeListno = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.labelLocation = new System.Windows.Forms.Label();
            this.panelPath = new System.Windows.Forms.Panel();
            this.textNo = new DevExpress.XtraEditors.TextEdit();
            this.buttonPath = new DevExpress.XtraEditors.ButtonEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonRefrash = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panelSave = new System.Windows.Forms.Panel();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEditDBName = new DevExpress.XtraEditors.ButtonEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).BeginInit();
            this.groupControlCatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).BeginInit();
            this.groupControlNOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).BeginInit();
            this.panelPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).BeginInit();
            this.panelSave.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDBName.Properties)).BeginInit();
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
            this.groupControl.Location = new System.Drawing.Point(7, 79);
            this.groupControl.LookAndFeel.SkinName = "Blue";
            this.groupControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl.Name = "groupControl";
            this.groupControl.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.groupControl.ShowCaption = false;
            this.groupControl.Size = new System.Drawing.Size(747, 299);
            this.groupControl.TabIndex = 4;
            this.groupControl.TabStop = true;
            this.groupControl.Text = "添加数据";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControlCatalog);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlNOList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(747, 298);
            this.splitContainerControl1.SplitterPosition = 311;
            this.splitContainerControl1.TabIndex = 92;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.splitContainerControl1.Resize += new System.EventHandler(this.splitContainerControl1_Resize);
            // 
            // groupControlCatalog
            // 
            this.groupControlCatalog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlCatalog.Controls.Add(this.tListCatalog);
            this.groupControlCatalog.Controls.Add(this.labelCatalog);
            this.groupControlCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlCatalog.Location = new System.Drawing.Point(0, 0);
            this.groupControlCatalog.Name = "groupControlCatalog";
            this.groupControlCatalog.Padding = new System.Windows.Forms.Padding(7, 5, 7, 7);
            this.groupControlCatalog.ShowCaption = false;
            this.groupControlCatalog.Size = new System.Drawing.Size(311, 293);
            this.groupControlCatalog.TabIndex = 88;
            this.groupControlCatalog.TabStop = true;
            this.groupControlCatalog.Text = "数据目录";
            // 
            // tListCatalog
            // 
            this.tListCatalog.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListCatalog.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListCatalog.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListCatalog.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListCatalog.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListCatalog.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListCatalog.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.tListCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListCatalog.Location = new System.Drawing.Point(7, 36);
            this.tListCatalog.Name = "tListCatalog";
            this.tListCatalog.BeginUnboundLoad();
            this.tListCatalog.AppendNode(new object[] {
            "node1",
            null}, -1, 0, 0, 0);
            this.tListCatalog.AppendNode(new object[] {
            null,
            null}, 0, 0, 0, 2);
            this.tListCatalog.AppendNode(new object[] {
            "node11",
            null}, 1, 0, 0, 1);
            this.tListCatalog.AppendNode(new object[] {
            null,
            null}, -1);
            this.tListCatalog.EndUnboundLoad();
            this.tListCatalog.OptionsView.ShowColumns = false;
            this.tListCatalog.OptionsView.ShowHorzLines = false;
            this.tListCatalog.OptionsView.ShowIndicator = false;
            this.tListCatalog.OptionsView.ShowVertLines = false;
            this.tListCatalog.Size = new System.Drawing.Size(297, 250);
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
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn2";
            this.treeListColumn4.FieldName = "treeListColumn2";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Width = 20;
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
            this.labelCatalog.Location = new System.Drawing.Point(7, 5);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(297, 31);
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
            // groupControlNOList
            // 
            this.groupControlNOList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlNOList.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControlNOList.ContentImage")));
            this.groupControlNOList.Controls.Add(this.treeListno);
            this.groupControlNOList.Controls.Add(this.label9);
            this.groupControlNOList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlNOList.Location = new System.Drawing.Point(0, 0);
            this.groupControlNOList.LookAndFeel.SkinName = "Blue";
            this.groupControlNOList.Name = "groupControlNOList";
            this.groupControlNOList.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.groupControlNOList.ShowCaption = false;
            this.groupControlNOList.Size = new System.Drawing.Size(431, 293);
            this.groupControlNOList.TabIndex = 87;
            this.groupControlNOList.Text = "图层列表";
            // 
            // treeListno
            // 
            this.treeListno.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.treeListno.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeListno.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListno.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.treeListno.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeListno.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListno.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn5});
            this.treeListno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListno.Location = new System.Drawing.Point(7, 35);
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
            this.treeListno.Size = new System.Drawing.Size(417, 251);
            this.treeListno.TabIndex = 85;
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
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 10;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(417, 35);
            this.label9.TabIndex = 84;
            this.label9.Text = "     数据内容";
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
            this.labelLocation.Location = new System.Drawing.Point(7, 7);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(747, 30);
            this.labelLocation.TabIndex = 21;
            this.labelLocation.Text = "      保存数据          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPath
            // 
            this.panelPath.BackColor = System.Drawing.Color.Transparent;
            this.panelPath.Controls.Add(this.textNo);
            this.panelPath.Controls.Add(this.buttonPath);
            this.panelPath.Controls.Add(this.panel6);
            this.panelPath.Controls.Add(this.simpleButtonRefrash);
            this.panelPath.Controls.Add(this.label6);
            this.panelPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPath.Location = new System.Drawing.Point(7, 37);
            this.panelPath.Name = "panelPath";
            this.panelPath.Padding = new System.Windows.Forms.Padding(9, 9, 0, 7);
            this.panelPath.Size = new System.Drawing.Size(747, 42);
            this.panelPath.TabIndex = 80;
            // 
            // textNo
            // 
            this.textNo.Enabled = false;
            this.textNo.Location = new System.Drawing.Point(355, 9);
            this.textNo.Name = "textNo";
            this.textNo.Size = new System.Drawing.Size(183, 20);
            this.textNo.TabIndex = 73;
            this.textNo.Visible = false;
            // 
            // buttonPath
            // 
            this.buttonPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPath.Location = new System.Drawing.Point(67, 9);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonPath.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "指定路径", null, null, false)});
            this.buttonPath.Size = new System.Drawing.Size(615, 20);
            this.buttonPath.TabIndex = 76;
            this.buttonPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonPath_KeyPress);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(682, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(7, 26);
            this.panel6.TabIndex = 82;
            // 
            // simpleButtonRefrash
            // 
            this.simpleButtonRefrash.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRefrash.ImageIndex = 69;
            this.simpleButtonRefrash.ImageList = this.imageCollection1;
            this.simpleButtonRefrash.Location = new System.Drawing.Point(689, 9);
            this.simpleButtonRefrash.Name = "simpleButtonRefrash";
            this.simpleButtonRefrash.Size = new System.Drawing.Size(58, 26);
            this.simpleButtonRefrash.TabIndex = 81;
            this.simpleButtonRefrash.Text = "刷新";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 26);
            this.label6.TabIndex = 74;
            this.label6.Text = "    路径";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSave
            // 
            this.panelSave.Controls.Add(this.simpleButtonSave);
            this.panelSave.Controls.Add(this.panel9);
            this.panelSave.Controls.Add(this.simpleButtonSelect);
            this.panelSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSave.Location = new System.Drawing.Point(7, 420);
            this.panelSave.Name = "panelSave";
            this.panelSave.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panelSave.Size = new System.Drawing.Size(747, 40);
            this.panelSave.TabIndex = 81;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSave.Enabled = false;
            this.simpleButtonSave.ImageIndex = 8;
            this.simpleButtonSave.ImageList = this.imageCollection1;
            this.simpleButtonSave.Location = new System.Drawing.Point(563, 7);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(86, 33);
            this.simpleButtonSave.TabIndex = 77;
            this.simpleButtonSave.Text = "保存";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(649, 7);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(12, 33);
            this.panel9.TabIndex = 79;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageIndex = 7;
            this.simpleButtonSelect.ImageList = this.imageCollection1;
            this.simpleButtonSelect.Location = new System.Drawing.Point(661, 7);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(86, 33);
            this.simpleButtonSelect.TabIndex = 78;
            this.simpleButtonSelect.Text = "取消";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonEditDBName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 378);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(9, 9, 0, 7);
            this.panel1.Size = new System.Drawing.Size(747, 42);
            this.panel1.TabIndex = 82;
            // 
            // buttonEditDBName
            // 
            this.buttonEditDBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditDBName.Location = new System.Drawing.Point(85, 9);
            this.buttonEditDBName.Name = "buttonEditDBName";
            this.buttonEditDBName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEditDBName.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "指定路径", null, null, false)});
            this.buttonEditDBName.Size = new System.Drawing.Size(653, 20);
            this.buttonEditDBName.TabIndex = 76;
            this.buttonEditDBName.EditValueChanged += new System.EventHandler(this.buttonEditDBName_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(738, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(9, 26);
            this.panel2.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 74;
            this.label1.Text = "    数据库";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlSaveData
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.panelPath);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSave);
            this.Name = "UserControlSaveData";
            this.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Size = new System.Drawing.Size(761, 467);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).EndInit();
            this.groupControlCatalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).EndInit();
            this.groupControlNOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).EndInit();
            this.panelPath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).EndInit();
            this.panelSave.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDBName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialValue(string datasetname, ArrayList pLayerList, ISpatialReference pSpatialReference, FormSaveData form, bool bSaveFlag)
        {
            try
            {
                this.mDatasetName = datasetname;
                this.mLayerList = pLayerList;
                this.mSpatialReference = pSpatialReference;
                this.pareForm = form;
                this.mSaveFlag = bSaveFlag;
                this.InitialControls();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (this.mSaveFlag)
            {
                if (this.CreateWorkspace(this.buttonEditDBName.Tag.ToString(), this.buttonEditDBName.Text))
                {
                    if (this.CreateLayer(this.mFeatureWorkspace, this.mLayerList))
                    {
                        this.mCancelFlag = false;
                        this.pareForm.LayerList = this.mTLayerList;
                        this.pareForm.Close();
                    }
                    else
                    {
                        this.mCancelFlag = true;
                    }
                }
            }
            else
            {
                this.mCancelFlag = false;
                this.pareForm.Close();
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            this.mCancelFlag = true;
            if (this.pareForm != null)
            {
                this.pareForm.Close();
            }
        }

        private void simpleButtonViewMap3_Click(object sender, EventArgs e)
        {
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
                this.simpleButtonSave.Enabled = false;
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
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "tListCatalog_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void treeListno_MouseUp(object sender, MouseEventArgs e)
        {
            try
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
                                this.simpleButtonSave.Enabled = true;
                            }
                            else
                            {
                                this.simpleButtonSave.Enabled = false;
                            }
                        }
                        else
                        {
                            this.simpleButtonSave.Enabled = true;
                        }
                    }
                    else if (this.treeListno.FocusedNode.Tag is IFeatureDataset)
                    {
                        this.simpleButtonSave.Enabled = true;
                    }
                    else if (this.treeListno.FocusedNode.Tag is ITable)
                    {
                        this.simpleButtonSave.Enabled = false;
                    }
                    else if (this.treeListno.FocusedNode.Tag is IRasterLayer)
                    {
                        this.simpleButtonSave.Enabled = false;
                    }
                    else if (this.treeListno.FocusedNode.Tag is IRelationshipClass)
                    {
                        this.simpleButtonSave.Enabled = false;
                    }
                    else
                    {
                        this.simpleButtonSave.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "treeListno_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public bool CancelFlag
        {
            get
            {
                return this.mCancelFlag;
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
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "CancelVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "CancelVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    MessageBox.Show(exception.Message, "DataEdit.UserControlSaveData", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public ArrayList SaveLayerList
        {
            get
            {
                try
                {
                    return this.mTLayerList;
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "SaveLayerList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    return null;
                }
            }
            set
            {
                try
                {
                    this.mTLayerList = value;
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlSaveData", "SaveLayerList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    MessageBox.Show(exception.Message, "DataEdit.UserControlSaveData", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}

