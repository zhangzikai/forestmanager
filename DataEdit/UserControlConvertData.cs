namespace DataEdit
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlConvertData : UserControlBase1
    {
        private ButtonEdit buttonEditCADPath;
        private ButtonEdit buttonEditGDBPath;
        private CheckEdit checkSpatialReference;
        private CheckedListBoxControl cListKind;
        private ComboBoxEdit comboBoxB1;
        private ComboBoxEdit comboBoxB2;
        private ComboBoxEdit comboBoxB3;
        private ComboBoxEdit comboBoxB4;
        private ComboBoxEdit comboBoxB5;
        private ComboBoxEdit comboBoxB6;
        private ComboBoxEdit comboBoxL;
        private IContainer components = null;
        internal ImageList ImageList1;
        private Label label1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label2;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListBoxControl listBoxFieldList;
        private ListBoxControl listBoxValueList;
        private ArrayList mAnnFList = null;
        private IFeatureLayer mAnnoLayer;
        private ArrayList mAnnVList = null;
        private IFeatureWorkspace mCADFeatureWorkspace;
        private const string mClassName = "DataEdit.UserControlConvertData";
     
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private IFeatureWorkspace mGDBFeatureWorkspace;
        private IGroupLayer mGroupLayer;
        private HookHelper mHookHelper = null;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
        private ArrayList mLayerList = null;
        private ArrayList mLayerList2 = null;
        private ArrayList mLineFList = null;
        private ArrayList mLineVList = null;
        private ArrayList mMultiFList = null;
        private IFeatureLayer mMultiPatchLayer;
        private ArrayList mMultiVList = null;
        private ArrayList mPointFList = null;
        private IFeatureLayer mPointLayer;
        private DataTable mPointTable;
        private DataTable mPointTable2;
        private ArrayList mPointVList = null;
        private ArrayList mPolyFList = null;
        private IFeatureLayer mPolygonLayer;
        private IFeatureLayer mPolylineLayer;
        private DataTable mPolyTable;
        private ArrayList mPolyVList = null;
        private ArrayList mRangeList = null;
        private string mSaveName = "";
        private string mSavePath = "";
        private bool mSelected = false;
        private DataTable mSelPointTable;
        private ISpatialReference mSpatialReference = null;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTLayerList = null;
        private ArrayList mWhereList = null;
        private const string myClassName = "数据转换";
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel25;
        private Panel panel26;
        private Panel panel4;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private PanelControl panelControl1;
        private Panel panelConvert;
        private Panel panelKind;
        private Panel panelPath2;
        private Panel panelRange;
        private Panel panelResource;
        private Panel panelSetRange;
        internal PopupContainerControl PopupContainer;
        internal PopupContainerControl PopupContainer2;
        internal PopupContainerEdit PopupContainerEdit1;
        internal PopupContainerEdit PopupContainerEdit2;
        private RadioGroup radioGroup2;
        public RichTextBox richTextBox;
        private SimpleButton simpleButtonAdd;
        private SimpleButton simpleButtonClear;
        private SimpleButton simpleButtonInput;
        private SimpleButton simpleButtonPoject;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonView;
        private SpinEdit spinEditL2;
        private SpinEdit spinEditL22;
        private SpinEdit spinEditL3;
        private SpinEdit spinEditL33;
        private SpinEdit spinEditL4;
        private SpinEdit spinEditL44;
        private string SubID = "";
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPage5;

        public UserControlConvertData()
        {
            this.InitializeComponent();
        }

        private void buttonEditCADPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "CAD文件 (*.DWG)|*.DWG";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dialog.FileName;
                    this.buttonEditCADPath.Text = fileName;
                    dialog = null;
                    string directoryName = System.IO.Path.GetDirectoryName(this.buttonEditCADPath.Text);
                    string cadFileName = System.IO.Path.GetFileName(this.buttonEditCADPath.Text);
                    this.buttonEditCADPath.Tag = cadFileName;
                    this.ReadCADValue(directoryName, cadFileName);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "buttonEditCADPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void buttonEditGDBPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                IGroupLayer layer = null;
                string sLayerName = "";
                sLayerName = (this.mCADFeatureWorkspace as IDataset).Subsets.Next().Name.Replace(".dwg", "").Replace(".", "_");
                if (this.mEditKind == "通用")
                {
                    layer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                }
                if (layer == null)
                {
                    layer = new GroupLayerClass();
                    layer.Name = sLayerName;
                }
                FormSaveData data = new FormSaveData(this.buttonEditCADPath.Tag.ToString(), this.mLayerList, this.mSpatialReference, false);
                data.ShowDialog();
                this.panelConvert.Enabled = true;
                if (!data.userControlSaveData1.CancelFlag)
                {
                    this.mGDBFeatureWorkspace = null;
                    this.mSaveName = data.userControlSaveData1.buttonEditDBName.Text;
                    if (data.userControlSaveData1.buttonEditDBName.Tag is IFeatureWorkspace)
                    {
                        this.mGDBFeatureWorkspace = data.userControlSaveData1.buttonEditDBName.Tag as IFeatureWorkspace;
                        this.buttonEditGDBPath.Text = (this.mGDBFeatureWorkspace as IWorkspace).PathName;
                    }
                    else
                    {
                        if (!(this.mSaveName.Contains(".gdb") || this.mSaveName.Contains(".mdb")))
                        {
                            this.mSaveName = this.mSaveName + ".gdb";
                        }
                        this.mSavePath = data.userControlSaveData1.buttonEditDBName.Tag.ToString();
                        this.buttonEditGDBPath.Text = this.mSavePath + @"\" + this.mSaveName;
                    }
                    this.simpleButtonInput.Enabled = true;
                }
                else
                {
                    this.simpleButtonInput.Enabled = false;
                }
                data = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "buttonEditGDBPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void cListKind_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (this.cListKind.Enabled)
            {
                bool flag = false;
                for (int i = 0; i < this.cListKind.Items.Count; i++)
                {
                    if (this.cListKind.Items[i].CheckState == CheckState.Checked)
                    {
                        if (!flag)
                        {
                            flag = true;
                        }
                        this.xtraTabControl1.TabPages[i].PageVisible = true;
                    }
                    else
                    {
                        this.xtraTabControl1.TabPages[i].PageVisible = false;
                    }
                }
                if (flag)
                {
                    this.panelRange.Enabled = true;
                    this.panelPath2.Enabled = true;
                }
                else
                {
                    this.panelRange.Enabled = false;
                    this.panelPath2.Enabled = false;
                }
            }
        }

        private void cListKind_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                string name = this.buttonEditCADPath.Tag.ToString().Replace(".", "_").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("（", "").Replace("）", "").Replace(" ", "");
                try
                {
                    pFWorkspace.OpenFeatureDataset(name).Delete();
                }
                catch (Exception)
                {
                }
                dataset = pFWorkspace.CreateFeatureDataset(name, this.mSpatialReference);
                if (dataset == null)
                {
                    return false;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                for (int i = 0; i < pList.Count; i++)
                {
                    if (!this.xtraTabControl1.TabPages[i].PageVisible)
                    {
                        continue;
                    }
                    IFeatureLayer layer = pList[i] as IFeatureLayer;
                    IFeatureClass featureClass = layer.FeatureClass;
                    if (featureClass != null)
                    {
                        ESRI.ArcGIS.AnalysisTools.Select process = new ESRI.ArcGIS.AnalysisTools.Select();
                        process.in_features = featureClass;
                        string str2 = workspace.PathName + @"\" + dataset.Name + @"\" + (featureClass as IDataset).Name;
                        process.out_feature_class = str2;
                        if (this.mWhereList == null)
                        {
                            this.SetWhereString();
                        }
                        process.where_clause = this.mWhereList[i].ToString();
                        try
                        {
                            object obj2 = geoprocessor.Execute(process, null);
                        }
                        catch (Exception)
                        {
                            string messages = "";
                            object severity = null;
                            messages = geoprocessor.GetMessages(ref severity);
                        }
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
                    }
                }
                if (this.checkSpatialReference.Checked)
                {
                    this.MoveXY(pFWorkspace, this.mSpatialReference, 0.0, 0.0);
                }
                IEnumDataset subsets = dataset.Subsets;
                for (IDataset dataset5 = subsets.Next(); dataset5 != null; dataset5 = subsets.Next())
                {
                    IFeatureLayer layer2 = new FeatureLayerClass();
                    layer2.FeatureClass = dataset5 as IFeatureClass;
                    layer2.Name = dataset5.Name;
                    this.mTLayerList.Add(layer2);
                }
                geoprocessor = null;
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "CreateLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool CreateWorkspace(string sPath, string sName)
        {
            try
            {
                IWorkspaceFactory2 factory = null;
                IWorkspaceName name = null;
                this.mGDBFeatureWorkspace = null;
                if (sName.Contains(".gdb"))
                {
                    factory = new FileGDBWorkspaceFactoryClass();
                    name = factory.Create(sPath + @"\", sName, null, 0);
                }
                else if (sName.Contains(".mdb"))
                {
                    factory = new AccessWorkspaceFactoryClass();
                    name = factory.Create(sPath + @"\", sName, null, 0);
                }
                else
                {
                    factory = new FileGDBWorkspaceFactoryClass();
                    name = factory.Create(sPath + @"\", sName + ".gdb", null, 0);
                }
                IName name2 = (IName) name;
                IWorkspace workspace = (IWorkspace) name2.Open();
                this.mGDBFeatureWorkspace = workspace as IFeatureWorkspace;
                return (this.mGDBFeatureWorkspace != null);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "CreateWorkspace", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private ICadDrawingDataset GetCadDataset(string cadWorkspacePath, string cadFileName)
        {
            try
            {
                IWorkspaceName name = new WorkspaceNameClass();
                name.WorkspaceFactoryProgID = "esriDataSourcesFile.CadWorkspaceFactory";
                name.PathName = cadWorkspacePath;
                IDatasetName name2 = new CadDrawingNameClass();
                name2.Name = cadFileName;
                name2.WorkspaceName = name;
                IName name3 = (IName) name2;
                return (ICadDrawingDataset) name3.Open();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Hook(object hook, string sEditKind)
        {
            try
            {
                if (hook != null)
                {
                    this.mEditKind = sEditKind;
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    this.InitialValue();
                    this.InitialControl();
                }
                this.mEditKind = sEditKind;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControl()
        {
            try
            {
                this.buttonEditCADPath.Enabled = true;
                this.buttonEditGDBPath.Enabled = true;
                this.panelKind.Enabled = false;
                this.panelRange.Enabled = false;
                this.panelPath2.Enabled = false;
                this.panelConvert.Enabled = false;
                this.xtraTabPage1.PageVisible = false;
                this.xtraTabPage2.PageVisible = false;
                this.xtraTabPage3.PageVisible = false;
                this.xtraTabPage4.PageVisible = false;
                this.xtraTabPage5.PageVisible = false;
                this.panelRange.Height = 0x34;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldList(ArrayList pList, IFeatureClass pfClass)
        {
            try
            {
                pList.Clear();
                for (int i = 0; i < pfClass.Fields.FieldCount; i++)
                {
                    IField field = pfClass.Fields.get_Field(i);
                    if ((field.Type != esriFieldType.esriFieldTypeGeometry) && (field.Type != esriFieldType.esriFieldTypeOID))
                    {
                        pList.Add(field.Name);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "InitialFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldList2(ListBoxControl listbox, ArrayList pList)
        {
            try
            {
                listbox.Items.Clear();
                for (int i = 0; i < pList.Count; i++)
                {
                    listbox.Items.Add(pList[i].ToString());
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "InitialFieldList2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlConvertData));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelResource = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.simpleButtonPoject = new DevExpress.XtraEditors.SimpleButton();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.panel11 = new System.Windows.Forms.Panel();
            this.simpleButtonView = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditCADPath = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panelKind = new System.Windows.Forms.Panel();
            this.cListKind = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPath2 = new System.Windows.Forms.Panel();
            this.buttonEditGDBPath = new DevExpress.XtraEditors.ButtonEdit();
            this.checkSpatialReference = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRange = new System.Windows.Forms.Panel();
            this.panelSetRange = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.simpleButtonClear = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PopupContainerEdit2 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.PopupContainer2 = new DevExpress.XtraEditors.PopupContainerControl();
            this.listBoxValueList = new DevExpress.XtraEditors.ListBoxControl();
            this.PopupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.PopupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this.listBoxFieldList = new DevExpress.XtraEditors.ListBoxControl();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel24 = new System.Windows.Forms.Panel();
            this.comboBoxB6 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label23 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.comboBoxB5 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.comboBoxB4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.comboBoxB3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.comboBoxB2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label24 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.comboBoxB1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.panel26 = new System.Windows.Forms.Panel();
            this.spinEditL44 = new DevExpress.XtraEditors.SpinEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.spinEditL4 = new DevExpress.XtraEditors.SpinEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.spinEditL33 = new DevExpress.XtraEditors.SpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.spinEditL3 = new DevExpress.XtraEditors.SpinEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.spinEditL22 = new DevExpress.XtraEditors.SpinEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.spinEditL2 = new DevExpress.XtraEditors.SpinEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.comboBoxL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.label3 = new System.Windows.Forms.Label();
            this.panelConvert = new System.Windows.Forms.Panel();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.simpleButtonInput = new DevExpress.XtraEditors.SimpleButton();
            this.panelResource.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCADPath.Properties)).BeginInit();
            this.panelKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cListKind)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelPath2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditGDBPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSpatialReference.Properties)).BeginInit();
            this.panelRange.SuspendLayout();
            this.panelSetRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer2)).BeginInit();
            this.PopupContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxValueList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).BeginInit();
            this.PopupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).BeginInit();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).BeginInit();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL44.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL4.Properties)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL22.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL2.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.panelConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelResource
            // 
            this.panelResource.BackColor = System.Drawing.Color.Transparent;
            this.panelResource.Controls.Add(this.panel4);
            this.panelResource.Controls.Add(this.buttonEditCADPath);
            this.panelResource.Controls.Add(this.label2);
            this.panelResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResource.Location = new System.Drawing.Point(2, 2);
            this.panelResource.Name = "panelResource";
            this.panelResource.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelResource.Size = new System.Drawing.Size(316, 93);
            this.panelResource.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.simpleButtonPoject);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.simpleButtonView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(4, 58);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.panel4.Size = new System.Drawing.Size(308, 33);
            this.panel4.TabIndex = 20;
            // 
            // simpleButtonPoject
            // 
            this.simpleButtonPoject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonPoject.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonPoject.ImageIndex = 97;
            this.simpleButtonPoject.ImageList = this.ImageList1;
            this.simpleButtonPoject.Location = new System.Drawing.Point(155, 0);
            this.simpleButtonPoject.Name = "simpleButtonPoject";
            this.simpleButtonPoject.Size = new System.Drawing.Size(80, 27);
            this.simpleButtonPoject.TabIndex = 100;
            this.simpleButtonPoject.Text = "空间参考";
            this.simpleButtonPoject.ToolTip = "设置空间参考";
            this.simpleButtonPoject.Click += new System.EventHandler(this.simpleButtonPoject_Click);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "");
            this.ImageList1.Images.SetKeyName(16, "(30,24).png");
            this.ImageList1.Images.SetKeyName(17, "(00,02).png");
            this.ImageList1.Images.SetKeyName(18, "(00,17).png");
            this.ImageList1.Images.SetKeyName(19, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(21, "(01,25).png");
            this.ImageList1.Images.SetKeyName(22, "(05,32).png");
            this.ImageList1.Images.SetKeyName(23, "(06,32).png");
            this.ImageList1.Images.SetKeyName(24, "(07,32).png");
            this.ImageList1.Images.SetKeyName(25, "(08,32).png");
            this.ImageList1.Images.SetKeyName(26, "(08,36).png");
            this.ImageList1.Images.SetKeyName(27, "(09,36).png");
            this.ImageList1.Images.SetKeyName(28, "(10,26).png");
            this.ImageList1.Images.SetKeyName(29, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(31, "(12,29).png");
            this.ImageList1.Images.SetKeyName(32, "(11,32).png");
            this.ImageList1.Images.SetKeyName(33, "(11,36).png");
            this.ImageList1.Images.SetKeyName(34, "(13,32).png");
            this.ImageList1.Images.SetKeyName(35, "(19,31).png");
            this.ImageList1.Images.SetKeyName(36, "(22,18).png");
            this.ImageList1.Images.SetKeyName(37, "(25,27).png");
            this.ImageList1.Images.SetKeyName(38, "(29,43).png");
            this.ImageList1.Images.SetKeyName(39, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(41, "10.png");
            this.ImageList1.Images.SetKeyName(42, "11.png");
            this.ImageList1.Images.SetKeyName(43, "16.png");
            this.ImageList1.Images.SetKeyName(44, "17.png");
            this.ImageList1.Images.SetKeyName(45, "18.png");
            this.ImageList1.Images.SetKeyName(46, "19.png");
            this.ImageList1.Images.SetKeyName(47, "20.png");
            this.ImageList1.Images.SetKeyName(48, "21.png");
            this.ImageList1.Images.SetKeyName(49, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(51, "31.png");
            this.ImageList1.Images.SetKeyName(52, "41.png");
            this.ImageList1.Images.SetKeyName(53, "add.png");
            this.ImageList1.Images.SetKeyName(54, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(55, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(56, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(57, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(58, "cross.png");
            this.ImageList1.Images.SetKeyName(59, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(61, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(62, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(63, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(64, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(65, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(66, "flag blue.png");
            this.ImageList1.Images.SetKeyName(67, "flag red.png");
            this.ImageList1.Images.SetKeyName(68, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(69, "31.png");
            this.ImageList1.Images.SetKeyName(70, "42.png");
            this.ImageList1.Images.SetKeyName(71, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(72, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(73, "cursor.png");
            this.ImageList1.Images.SetKeyName(74, "cursor_small.png");
            this.ImageList1.Images.SetKeyName(75, "cut.png");
            this.ImageList1.Images.SetKeyName(76, "cut_red.png");
            this.ImageList1.Images.SetKeyName(77, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(78, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(79, "Feedicons_v2_024.png");
            this.ImageList1.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.ImageList1.Images.SetKeyName(81, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(82, "key.png");
            this.ImageList1.Images.SetKeyName(83, "page_add.png");
            this.ImageList1.Images.SetKeyName(84, "page_delete.png");
            this.ImageList1.Images.SetKeyName(85, "page_white_world.png");
            this.ImageList1.Images.SetKeyName(86, "page_world.png");
            this.ImageList1.Images.SetKeyName(87, "reload.png");
            this.ImageList1.Images.SetKeyName(88, "world_add.png");
            this.ImageList1.Images.SetKeyName(89, "world_delete.png");
            this.ImageList1.Images.SetKeyName(90, "zoom_in.png");
            this.ImageList1.Images.SetKeyName(91, "zoom_out.png");
            this.ImageList1.Images.SetKeyName(92, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(93, "Tipicon.ico");
            this.ImageList1.Images.SetKeyName(94, "Exit.png");
            this.ImageList1.Images.SetKeyName(95, "langicon.gif");
            this.ImageList1.Images.SetKeyName(96, "web.gif");
            this.ImageList1.Images.SetKeyName(97, "profile.gif");
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(235, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel11.Size = new System.Drawing.Size(7, 27);
            this.panel11.TabIndex = 101;
            // 
            // simpleButtonView
            // 
            this.simpleButtonView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonView.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonView.ImageIndex = 16;
            this.simpleButtonView.ImageList = this.ImageList1;
            this.simpleButtonView.Location = new System.Drawing.Point(242, 0);
            this.simpleButtonView.Name = "simpleButtonView";
            this.simpleButtonView.Size = new System.Drawing.Size(66, 27);
            this.simpleButtonView.TabIndex = 20;
            this.simpleButtonView.Text = "预览";
            this.simpleButtonView.ToolTip = "预览CAD图形";
            this.simpleButtonView.Click += new System.EventHandler(this.simpleButtonView_Click);
            // 
            // buttonEditCADPath
            // 
            this.buttonEditCADPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditCADPath.Enabled = false;
            this.buttonEditCADPath.Location = new System.Drawing.Point(4, 30);
            this.buttonEditCADPath.Name = "buttonEditCADPath";
            this.buttonEditCADPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditCADPath.Size = new System.Drawing.Size(308, 20);
            this.buttonEditCADPath.TabIndex = 19;
            this.buttonEditCADPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditCADPath_ButtonClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 28);
            this.label2.TabIndex = 18;
            this.label2.Text = "CAD数据路径:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelKind
            // 
            this.panelKind.BackColor = System.Drawing.Color.Transparent;
            this.panelKind.Controls.Add(this.cListKind);
            this.panelKind.Controls.Add(this.panel2);
            this.panelKind.Controls.Add(this.label6);
            this.panelKind.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKind.Location = new System.Drawing.Point(2, 95);
            this.panelKind.Name = "panelKind";
            this.panelKind.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelKind.Size = new System.Drawing.Size(316, 117);
            this.panelKind.TabIndex = 31;
            // 
            // cListKind
            // 
            this.cListKind.CheckOnClick = true;
            this.cListKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListKind.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("注记"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("点"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("线"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("面"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("多面体")});
            this.cListKind.Location = new System.Drawing.Point(4, 30);
            this.cListKind.MultiColumn = true;
            this.cListKind.Name = "cListKind";
            this.cListKind.Size = new System.Drawing.Size(308, 53);
            this.cListKind.TabIndex = 16;
            this.cListKind.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.cListKind_ItemCheck);
            this.cListKind.SelectedIndexChanged += new System.EventHandler(this.cListKind_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 83);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel2.Size = new System.Drawing.Size(308, 32);
            this.panel2.TabIndex = 18;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageIndex = 28;
            this.simpleButtonSelect.ImageList = this.ImageList1;
            this.simpleButtonSelect.Location = new System.Drawing.Point(242, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonSelect.TabIndex = 20;
            this.simpleButtonSelect.Text = "全选";
            this.simpleButtonSelect.ToolTip = "全选/清空";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(4, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 28);
            this.label6.TabIndex = 17;
            this.label6.Text = "导入数据类型:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPath2
            // 
            this.panelPath2.Controls.Add(this.buttonEditGDBPath);
            this.panelPath2.Controls.Add(this.checkSpatialReference);
            this.panelPath2.Controls.Add(this.label1);
            this.panelPath2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPath2.Location = new System.Drawing.Point(2, 597);
            this.panelPath2.Name = "panelPath2";
            this.panelPath2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.panelPath2.Size = new System.Drawing.Size(316, 78);
            this.panelPath2.TabIndex = 32;
            // 
            // buttonEditGDBPath
            // 
            this.buttonEditGDBPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditGDBPath.Enabled = false;
            this.buttonEditGDBPath.Location = new System.Drawing.Point(4, 30);
            this.buttonEditGDBPath.Name = "buttonEditGDBPath";
            this.buttonEditGDBPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditGDBPath.Size = new System.Drawing.Size(308, 20);
            this.buttonEditGDBPath.TabIndex = 20;
            this.buttonEditGDBPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditGDBPath_ButtonClick);
            // 
            // checkSpatialReference
            // 
            this.checkSpatialReference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkSpatialReference.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkSpatialReference.Location = new System.Drawing.Point(4, 55);
            this.checkSpatialReference.Name = "checkSpatialReference";
            this.checkSpatialReference.Properties.Caption = "根据当前视图设置空间参考";
            this.checkSpatialReference.Size = new System.Drawing.Size(308, 19);
            this.checkSpatialReference.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 28);
            this.label1.TabIndex = 21;
            this.label1.Text = "保存路径:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelRange
            // 
            this.panelRange.Controls.Add(this.panelSetRange);
            this.panelRange.Controls.Add(this.xtraTabControl1);
            this.panelRange.Controls.Add(this.radioGroup2);
            this.panelRange.Controls.Add(this.label3);
            this.panelRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRange.Location = new System.Drawing.Point(2, 212);
            this.panelRange.Name = "panelRange";
            this.panelRange.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelRange.Size = new System.Drawing.Size(316, 385);
            this.panelRange.TabIndex = 33;
            // 
            // panelSetRange
            // 
            this.panelSetRange.Controls.Add(this.panelControl1);
            this.panelSetRange.Controls.Add(this.panel6);
            this.panelSetRange.Controls.Add(this.panel7);
            this.panelSetRange.Location = new System.Drawing.Point(9, 91);
            this.panelSetRange.Name = "panelSetRange";
            this.panelSetRange.Padding = new System.Windows.Forms.Padding(4);
            this.panelSetRange.Size = new System.Drawing.Size(293, 279);
            this.panelSetRange.TabIndex = 100;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(4, 102);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(285, 173);
            this.panelControl1.TabIndex = 100;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(281, 169);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.simpleButtonAdd);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.simpleButtonClear);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 64);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.panel6.Size = new System.Drawing.Size(285, 38);
            this.panel6.TabIndex = 101;
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonAdd.ImageIndex = 71;
            this.simpleButtonAdd.ImageList = this.ImageList1;
            this.simpleButtonAdd.Location = new System.Drawing.Point(146, 6);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonAdd.TabIndex = 21;
            this.simpleButtonAdd.Text = "添加";
            this.simpleButtonAdd.ToolTip = "添加条件";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(212, 6);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel9.Size = new System.Drawing.Size(7, 26);
            this.panel9.TabIndex = 99;
            // 
            // simpleButtonClear
            // 
            this.simpleButtonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClear.ImageIndex = 92;
            this.simpleButtonClear.ImageList = this.ImageList1;
            this.simpleButtonClear.Location = new System.Drawing.Point(219, 6);
            this.simpleButtonClear.Name = "simpleButtonClear";
            this.simpleButtonClear.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonClear.TabIndex = 22;
            this.simpleButtonClear.Text = "重置";
            this.simpleButtonClear.ToolTip = "清空条件,重新设置";
            this.simpleButtonClear.Click += new System.EventHandler(this.simpleButtonClear_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PopupContainerEdit2);
            this.panel7.Controls.Add(this.PopupContainerEdit1);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel7.Size = new System.Drawing.Size(285, 60);
            this.panel7.TabIndex = 102;
            // 
            // PopupContainerEdit2
            // 
            this.PopupContainerEdit2.Dock = System.Windows.Forms.DockStyle.Right;
            this.PopupContainerEdit2.EditValue = "";
            this.PopupContainerEdit2.Location = new System.Drawing.Point(145, 32);
            this.PopupContainerEdit2.Name = "PopupContainerEdit2";
            this.PopupContainerEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.PopupContainerEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.PopupContainerEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("PopupContainerEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.PopupContainerEdit2.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.PopupContainerEdit2.Properties.PopupControl = this.PopupContainer2;
            this.PopupContainerEdit2.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.PopupContainerEdit2.Properties.ShowPopupShadow = false;
            this.PopupContainerEdit2.Size = new System.Drawing.Size(140, 22);
            this.PopupContainerEdit2.TabIndex = 98;
            this.PopupContainerEdit2.EditValueChanged += new System.EventHandler(this.popupContainerEdit2_EditValueChanged);
            // 
            // PopupContainer2
            // 
            this.PopupContainer2.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PopupContainer2.Appearance.Options.UseBackColor = true;
            this.PopupContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PopupContainer2.Controls.Add(this.listBoxValueList);
            this.PopupContainer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PopupContainer2.Location = new System.Drawing.Point(90, 469);
            this.PopupContainer2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.PopupContainer2.Name = "PopupContainer2";
            this.PopupContainer2.Padding = new System.Windows.Forms.Padding(1);
            this.PopupContainer2.Size = new System.Drawing.Size(163, 166);
            this.PopupContainer2.TabIndex = 99;
            // 
            // listBoxValueList
            // 
            this.listBoxValueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxValueList.Location = new System.Drawing.Point(3, 3);
            this.listBoxValueList.Name = "listBoxValueList";
            this.listBoxValueList.Size = new System.Drawing.Size(157, 160);
            this.listBoxValueList.TabIndex = 18;
            this.listBoxValueList.SelectedIndexChanged += new System.EventHandler(this.listBoxValueList_SelectedIndexChanged);
            // 
            // PopupContainerEdit1
            // 
            this.PopupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PopupContainerEdit1.EditValue = "";
            this.PopupContainerEdit1.Location = new System.Drawing.Point(0, 32);
            this.PopupContainerEdit1.Name = "PopupContainerEdit1";
            this.PopupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.PopupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.PopupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("PopupContainerEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.PopupContainerEdit1.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.PopupContainerEdit1.Properties.PopupControl = this.PopupContainer;
            this.PopupContainerEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.PopupContainerEdit1.Properties.ShowPopupShadow = false;
            this.PopupContainerEdit1.Size = new System.Drawing.Size(128, 22);
            this.PopupContainerEdit1.TabIndex = 97;
            this.PopupContainerEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.PopupContainerEdit1_ButtonClick);
            // 
            // PopupContainer
            // 
            this.PopupContainer.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PopupContainer.Appearance.Options.UseBackColor = true;
            this.PopupContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PopupContainer.Controls.Add(this.listBoxFieldList);
            this.PopupContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PopupContainer.Location = new System.Drawing.Point(28, 432);
            this.PopupContainer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.PopupContainer.Name = "PopupContainer";
            this.PopupContainer.Padding = new System.Windows.Forms.Padding(1);
            this.PopupContainer.Size = new System.Drawing.Size(163, 166);
            this.PopupContainer.TabIndex = 98;
            // 
            // listBoxFieldList
            // 
            this.listBoxFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFieldList.Location = new System.Drawing.Point(3, 3);
            this.listBoxFieldList.Name = "listBoxFieldList";
            this.listBoxFieldList.Size = new System.Drawing.Size(157, 160);
            this.listBoxFieldList.TabIndex = 18;
            this.listBoxFieldList.SelectedIndexChanged += new System.EventHandler(this.listBoxFieldList_SelectedIndexChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 2);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel8.Size = new System.Drawing.Size(285, 30);
            this.panel8.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(136, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "值:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "字段:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 61);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(308, 322);
            this.xtraTabControl1.TabIndex = 20;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabControl1.Resize += new System.EventHandler(this.xtraTabControl1_Resize);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.xtraTabPage1.Size = new System.Drawing.Size(302, 293);
            this.xtraTabPage1.Text = "注记";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel24);
            this.xtraTabPage2.Controls.Add(this.panel23);
            this.xtraTabPage2.Controls.Add(this.panel22);
            this.xtraTabPage2.Controls.Add(this.panel19);
            this.xtraTabPage2.Controls.Add(this.panel25);
            this.xtraTabPage2.Controls.Add(this.panel18);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(302, 293);
            this.xtraTabPage2.Text = "点";
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.comboBoxB6);
            this.panel24.Controls.Add(this.label23);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 175);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel24.Size = new System.Drawing.Size(302, 35);
            this.panel24.TabIndex = 21;
            // 
            // comboBoxB6
            // 
            this.comboBoxB6.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB6.EditValue = "--";
            this.comboBoxB6.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB6.Name = "comboBoxB6";
            this.comboBoxB6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB6.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB6.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB6.TabIndex = 23;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Location = new System.Drawing.Point(0, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 26);
            this.label23.TabIndex = 8;
            this.label23.Text = "林地所有权:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.comboBoxB5);
            this.panel23.Controls.Add(this.label22);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 140);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel23.Size = new System.Drawing.Size(302, 35);
            this.panel23.TabIndex = 22;
            // 
            // comboBoxB5
            // 
            this.comboBoxB5.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB5.EditValue = "--";
            this.comboBoxB5.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB5.Name = "comboBoxB5";
            this.comboBoxB5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB5.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB5.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB5.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Location = new System.Drawing.Point(0, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 26);
            this.label22.TabIndex = 8;
            this.label22.Text = "林地使用权:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.comboBoxB4);
            this.panel22.Controls.Add(this.label21);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 105);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel22.Size = new System.Drawing.Size(302, 35);
            this.panel22.TabIndex = 23;
            // 
            // comboBoxB4
            // 
            this.comboBoxB4.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB4.EditValue = "--";
            this.comboBoxB4.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB4.Name = "comboBoxB4";
            this.comboBoxB4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB4.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB4.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB4.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(0, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 26);
            this.label21.TabIndex = 8;
            this.label21.Text = "林木所有权:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.comboBoxB3);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 70);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel19.Size = new System.Drawing.Size(302, 35);
            this.panel19.TabIndex = 16;
            // 
            // comboBoxB3
            // 
            this.comboBoxB3.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB3.EditValue = "--";
            this.comboBoxB3.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB3.Name = "comboBoxB3";
            this.comboBoxB3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB3.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB3.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB3.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(0, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 26);
            this.label15.TabIndex = 8;
            this.label15.Text = "亚林种 :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.comboBoxB2);
            this.panel25.Controls.Add(this.label24);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(0, 35);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel25.Size = new System.Drawing.Size(302, 35);
            this.panel25.TabIndex = 25;
            // 
            // comboBoxB2
            // 
            this.comboBoxB2.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB2.EditValue = "--";
            this.comboBoxB2.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB2.Name = "comboBoxB2";
            this.comboBoxB2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB2.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB2.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB2.TabIndex = 22;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Location = new System.Drawing.Point(0, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 26);
            this.label24.TabIndex = 8;
            this.label24.Text = "起源 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.comboBoxB1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel18.Size = new System.Drawing.Size(302, 35);
            this.panel18.TabIndex = 15;
            // 
            // comboBoxB1
            // 
            this.comboBoxB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB1.EditValue = "--";
            this.comboBoxB1.Location = new System.Drawing.Point(89, 9);
            this.comboBoxB1.Name = "comboBoxB1";
            this.comboBoxB1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB1.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB1.Size = new System.Drawing.Size(213, 20);
            this.comboBoxB1.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(0, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 26);
            this.label14.TabIndex = 8;
            this.label14.Text = "地类 :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.panel26);
            this.xtraTabPage3.Controls.Add(this.panel10);
            this.xtraTabPage3.Controls.Add(this.panel21);
            this.xtraTabPage3.Controls.Add(this.panel20);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(302, 293);
            this.xtraTabPage3.Text = "线";
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.spinEditL44);
            this.panel26.Controls.Add(this.label25);
            this.panel26.Controls.Add(this.spinEditL4);
            this.panel26.Controls.Add(this.label26);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 105);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel26.Size = new System.Drawing.Size(302, 35);
            this.panel26.TabIndex = 26;
            // 
            // spinEditL44
            // 
            this.spinEditL44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL44.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL44.Location = new System.Drawing.Point(221, 9);
            this.spinEditL44.Name = "spinEditL44";
            this.spinEditL44.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL44.Properties.Mask.EditMask = "d";
            this.spinEditL44.Size = new System.Drawing.Size(81, 20);
            this.spinEditL44.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(167, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 26);
            this.label25.TabIndex = 10;
            this.label25.Text = "~";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL4
            // 
            this.spinEditL4.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL4.Location = new System.Drawing.Point(89, 9);
            this.spinEditL4.Name = "spinEditL4";
            this.spinEditL4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL4.Properties.Mask.EditMask = "d";
            this.spinEditL4.Size = new System.Drawing.Size(78, 20);
            this.spinEditL4.TabIndex = 9;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Location = new System.Drawing.Point(0, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 26);
            this.label26.TabIndex = 8;
            this.label26.Text = "郁闭度:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.spinEditL33);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.spinEditL3);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 70);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel10.Size = new System.Drawing.Size(302, 35);
            this.panel10.TabIndex = 20;
            // 
            // spinEditL33
            // 
            this.spinEditL33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL33.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL33.Location = new System.Drawing.Point(221, 9);
            this.spinEditL33.Name = "spinEditL33";
            this.spinEditL33.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL33.Properties.Mask.EditMask = "d";
            this.spinEditL33.Size = new System.Drawing.Size(81, 20);
            this.spinEditL33.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(167, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "~";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL3
            // 
            this.spinEditL3.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL3.Location = new System.Drawing.Point(89, 9);
            this.spinEditL3.Name = "spinEditL3";
            this.spinEditL3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL3.Properties.Mask.EditMask = "d";
            this.spinEditL3.Size = new System.Drawing.Size(78, 20);
            this.spinEditL3.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "补偿面积:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.spinEditL22);
            this.panel21.Controls.Add(this.label18);
            this.panel21.Controls.Add(this.spinEditL2);
            this.panel21.Controls.Add(this.label17);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 35);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel21.Size = new System.Drawing.Size(302, 35);
            this.panel21.TabIndex = 18;
            // 
            // spinEditL22
            // 
            this.spinEditL22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL22.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL22.Location = new System.Drawing.Point(221, 9);
            this.spinEditL22.Name = "spinEditL22";
            this.spinEditL22.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL22.Properties.Mask.EditMask = "d";
            this.spinEditL22.Size = new System.Drawing.Size(81, 20);
            this.spinEditL22.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(167, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 26);
            this.label18.TabIndex = 10;
            this.label18.Text = "~";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL2
            // 
            this.spinEditL2.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL2.Location = new System.Drawing.Point(89, 9);
            this.spinEditL2.Name = "spinEditL2";
            this.spinEditL2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL2.Properties.Mask.EditMask = "d";
            this.spinEditL2.Size = new System.Drawing.Size(78, 20);
            this.spinEditL2.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(0, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 26);
            this.label17.TabIndex = 8;
            this.label17.Text = "小班面积:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.comboBoxL);
            this.panel20.Controls.Add(this.label16);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel20.Size = new System.Drawing.Size(302, 35);
            this.panel20.TabIndex = 17;
            // 
            // comboBoxL
            // 
            this.comboBoxL.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxL.EditValue = "--";
            this.comboBoxL.Location = new System.Drawing.Point(89, 9);
            this.comboBoxL.Name = "comboBoxL";
            this.comboBoxL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxL.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxL.Size = new System.Drawing.Size(213, 20);
            this.comboBoxL.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(0, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 26);
            this.label16.TabIndex = 8;
            this.label16.Text = "优势树种 :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(302, 293);
            this.xtraTabPage4.Text = "面";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(302, 293);
            this.xtraTabPage5.Text = "多面体";
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup2.Location = new System.Drawing.Point(4, 30);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部图形"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定条件")});
            this.radioGroup2.Size = new System.Drawing.Size(308, 31);
            this.radioGroup2.TabIndex = 16;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(4, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 28);
            this.label3.TabIndex = 17;
            this.label3.Text = "导入数据范围:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelConvert
            // 
            this.panelConvert.Controls.Add(this.simpleButtonReset);
            this.panelConvert.Controls.Add(this.panel12);
            this.panelConvert.Controls.Add(this.simpleButtonInput);
            this.panelConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConvert.Location = new System.Drawing.Point(2, 675);
            this.panelConvert.Name = "panelConvert";
            this.panelConvert.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panelConvert.Size = new System.Drawing.Size(316, 38);
            this.panelConvert.TabIndex = 34;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.ImageIndex = 5;
            this.simpleButtonReset.ImageList = this.ImageList1;
            this.simpleButtonReset.Location = new System.Drawing.Point(173, 6);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonReset.TabIndex = 100;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.ToolTip = "清空条件,重新设置";
            this.simpleButtonReset.Visible = false;
            this.simpleButtonReset.Click += new System.EventHandler(this.simpleButtonReset_Click);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(239, 6);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel12.Size = new System.Drawing.Size(7, 26);
            this.panel12.TabIndex = 101;
            // 
            // simpleButtonInput
            // 
            this.simpleButtonInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInput.ImageIndex = 52;
            this.simpleButtonInput.ImageList = this.ImageList1;
            this.simpleButtonInput.Location = new System.Drawing.Point(246, 6);
            this.simpleButtonInput.Name = "simpleButtonInput";
            this.simpleButtonInput.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonInput.TabIndex = 21;
            this.simpleButtonInput.Text = "转换";
            this.simpleButtonInput.ToolTip = "转换CAD图形数据到指定位置";
            this.simpleButtonInput.Click += new System.EventHandler(this.simpleButtonInput_Click);
            // 
            // UserControlConvertData
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.PopupContainer2);
            this.Controls.Add(this.PopupContainer);
            this.Controls.Add(this.panelConvert);
            this.Controls.Add(this.panelPath2);
            this.Controls.Add(this.panelRange);
            this.Controls.Add(this.panelKind);
            this.Controls.Add(this.panelResource);
            this.Name = "UserControlConvertData";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(320, 700);
            this.Load += new System.EventHandler(this.UserControlInputData3_Load);
            this.panelResource.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCADPath.Properties)).EndInit();
            this.panelKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cListKind)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelPath2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditGDBPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSpatialReference.Properties)).EndInit();
            this.panelRange.ResumeLayout(false);
            this.panelSetRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer2)).EndInit();
            this.PopupContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxValueList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).EndInit();
            this.PopupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).EndInit();
            this.panel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).EndInit();
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).EndInit();
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL44.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL4.Properties)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).EndInit();
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL22.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL2.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.panelConvert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue()
        {
            try
            {
                this.mSpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                this.mAnnoLayer = null;
                this.mPointLayer = null;
                this.mPolylineLayer = null;
                this.mPolygonLayer = null;
                this.mMultiPatchLayer = null;
                this.mAnnFList = null;
                this.mAnnVList = null;
                this.mPointFList = null;
                this.mPointVList = null;
                this.mLineFList = null;
                this.mLineVList = null;
                this.mPolyFList = null;
                this.mPolyVList = null;
                this.mMultiFList = null;
                this.mMultiVList = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialValueList(string sFName, IFeatureClass pfclass)
        {
            try
            {
                if (pfclass != null)
                {
                    this.listBoxValueList.Items.Clear();
                    int num = pfclass.Fields.FindField(sFName);
                    IQueryFilter filter = new QueryFilterClass();
                    filter.SubFields = sFName;
                    IFeatureCursor cursor = pfclass.Search(filter, true);
                    IDataStatistics statistics = new DataStatisticsClass();
                    statistics.Field = sFName;
                    statistics.Cursor = cursor as ICursor;
                    IEnumerator uniqueValues = statistics.UniqueValues;
                    uniqueValues.Reset();
                    while (uniqueValues.MoveNext())
                    {
                        object current = uniqueValues.Current;
                        this.listBoxValueList.Items.Add(current.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "InitialValueList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void listBoxFieldList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxFieldList.SelectedIndex != -1)
            {
                this.PopupContainerEdit1.Text = this.listBoxFieldList.Items[this.listBoxFieldList.SelectedIndex].ToString();
                this.InitialValueList(this.PopupContainerEdit1.Text, this.listBoxFieldList.Tag as IFeatureClass);
                this.PopupContainer.Hide();
                this.PopupContainerEdit2.Focus();
                this.richTextBox.Refresh();
                this.richTextBox.Parent.Refresh();
            }
        }

        private void listBoxValueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxValueList.SelectedIndex != -1)
            {
                this.PopupContainerEdit2.Text = this.listBoxValueList.Items[this.listBoxValueList.SelectedIndex].ToString();
                this.PopupContainer2.Hide();
                this.PopupContainer2.Refresh();
                this.simpleButtonSelect.Focus();
                this.richTextBox.Refresh();
                this.richTextBox.Parent.Refresh();
            }
        }

        private bool MoveXY(IFeatureWorkspace pFeatureWorkspace, ISpatialReference pSrf, double x, double y)
        {
            try
            {
                Application.DoEvents();
                IWorkspace workspace = pFeatureWorkspace as IWorkspace;
                IDataset dataset = workspace as IDataset;
                IEnumDataset subsets = dataset.Subsets;
                IDataset dataset3 = subsets.Next();
                IFeatureClass class2 = null;
                IFeatureCursor cursor = null;
                IFeature feature = null;
                while (dataset3 != null)
                {
                    double num;
                    double num2;
                    double num3;
                    double num4;
                    class2 = dataset3 as IFeatureClass;
                    cursor = class2.Search(null, false);
                    feature = cursor.NextFeature();
                    IGeoDataset dataset4 = class2 as IGeoDataset;
                    ISpatialReference spatialReference = dataset4.SpatialReference;
                    IProjectedCoordinateSystem system = spatialReference as IProjectedCoordinateSystem;
                    IGeographicCoordinateSystem system2 = spatialReference as IGeographicCoordinateSystem;
                    IGeoDatasetSchemaEdit edit = (IGeoDatasetSchemaEdit) dataset4;
                    spatialReference.GetDomain(out num, out num2, out num3, out num4);
                    if (num >= (num + x))
                    {
                        num += x;
                    }
                    if (num3 >= (num3 + y))
                    {
                        num3 += y;
                    }
                    if (num2 <= (num2 + x))
                    {
                        num2 += x;
                    }
                    if (num4 <= (num4 + y))
                    {
                        num4 += y;
                    }
                    spatialReference.SetDomain(num, num2, num3, num4);
                    try
                    {
                        if (edit.CanAlterSpatialReference)
                        {
                            edit.AlterSpatialReference(spatialReference);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    IWorkspaceEdit edit2 = pFeatureWorkspace as IWorkspaceEdit;
                    if (edit2 == null)
                    {
                        return false;
                    }
                    edit2.StartEditing(false);
                    edit2.StartEditOperation();
                    while (feature != null)
                    {
                        Application.DoEvents();
                        ITransform2D shape = feature.Shape as ITransform2D;
                        shape.Move(x, y);
                        IGeometry geometry = shape as IGeometry;
                        feature.Shape = geometry;
                        feature.Store();
                        feature = cursor.NextFeature();
                    }
                    try
                    {
                        edit2.StopEditOperation();
                    }
                    catch (Exception)
                    {
                        edit2.StopEditOperation();
                    }
                    edit2.StopEditing(true);
                    dataset3 = subsets.Next();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "MoveXY", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void PopupContainerEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void popupContainerEdit2_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    this.panelRange.Height = 0x34;
                }
                else if (this.radioGroup2.SelectedIndex == 1)
                {
                    this.panelRange.Height = ((base.Height - this.panelRange.Top) - this.panelPath2.Height) - this.panelConvert.Height;
                    for (int i = 0; i < this.cListKind.Items.Count; i++)
                    {
                        if (this.cListKind.Items[i].CheckState == CheckState.Checked)
                        {
                            this.xtraTabControl1.TabPages[i].PageVisible = true;
                        }
                        else
                        {
                            this.xtraTabControl1.TabPages[i].PageVisible = false;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "radioGroup2_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ReadCADValue(string cadWorkspacePath, string cadFileName)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mSelected = true;
                this.mAnnoLayer = null;
                this.mPointLayer = null;
                this.mPolylineLayer = null;
                this.mPolygonLayer = null;
                this.mMultiPatchLayer = null;
                this.mLayerList = null;
                this.cListKind.Items.Clear();
                this.xtraTabControl1.TabPages.Clear();
                this.mLayerList = new ArrayList();
                this.mAnnFList = new ArrayList();
                this.mAnnVList = new ArrayList();
                this.mLineFList = new ArrayList();
                this.mLineVList = new ArrayList();
                this.mPolyFList = new ArrayList();
                this.mPolyVList = new ArrayList();
                this.mMultiFList = new ArrayList();
                this.mMultiVList = new ArrayList();
                IWorkspaceFactory2 factory = new CadWorkspaceFactoryClass();
                IWorkspace workspace = factory.OpenFromFile(cadWorkspacePath, 0);
                this.mCADFeatureWorkspace = workspace as IFeatureWorkspace;
                IFeatureClassContainer container = this.mCADFeatureWorkspace.OpenFeatureDataset(cadFileName) as IFeatureClassContainer;
                for (int i = 0; i < container.ClassCount; i++)
                {
                    IFeatureClass class2 = container.get_Class(i);
                    IFeatureLayer layer = new FeatureLayerClass();
                    if (class2.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                    {
                        layer.Name = (class2 as IDataset).Name;
                        layer.FeatureClass = class2;
                        layer.SpatialReference = this.mSpatialReference;
                        this.mAnnoLayer = layer;
                        this.cListKind.Items.Add("注记", true);
                        this.mLayerList.Add(this.mAnnoLayer);
                        this.xtraTabControl1.TabPages.Add("注记");
                        this.xtraTabControl1.TabPages[this.xtraTabControl1.TabPages.Count - 1].PageVisible = true;
                        this.panelRange.Enabled = true;
                    }
                    else if (class2.FeatureType == esriFeatureType.esriFTSimple)
                    {
                        int num2;
                        layer.Name = (class2 as IDataset).Name;
                        layer.FeatureClass = class2;
                        layer.SpatialReference = this.mSpatialReference;
                        if (class2.ShapeType == esriGeometryType.esriGeometryPoint)
                        {
                            this.mPointLayer = layer;
                            num2 = this.cListKind.Items.Add("点", true);
                            this.mLayerList.Add(this.mPointLayer);
                            this.xtraTabControl1.TabPages.Add("点");
                            this.xtraTabControl1.TabPages[this.xtraTabControl1.TabPages.Count - 1].PageVisible = true;
                            this.panelRange.Enabled = true;
                        }
                        else if (class2.ShapeType == esriGeometryType.esriGeometryPolyline)
                        {
                            this.mPolylineLayer = layer;
                            num2 = this.cListKind.Items.Add("线", true);
                            this.mLayerList.Add(this.mPolylineLayer);
                            this.xtraTabControl1.TabPages.Add("线");
                            this.xtraTabControl1.TabPages[this.xtraTabControl1.TabPages.Count - 1].PageVisible = true;
                            this.panelRange.Enabled = true;
                        }
                        else if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
                        {
                            this.mPolygonLayer = layer;
                            num2 = this.cListKind.Items.Add("面", true);
                            this.mLayerList.Add(this.mPolygonLayer);
                            this.xtraTabControl1.TabPages.Add("面");
                            this.xtraTabControl1.TabPages[this.xtraTabControl1.TabPages.Count - 1].PageVisible = true;
                            this.panelRange.Enabled = true;
                        }
                        else if (class2.ShapeType == esriGeometryType.esriGeometryMultiPatch)
                        {
                            this.mMultiPatchLayer = layer;
                            this.cListKind.Items.Add("多面体");
                            this.mLayerList.Add(this.mMultiPatchLayer);
                            this.xtraTabControl1.TabPages.Add("多面体");
                            this.xtraTabControl1.TabPages[this.xtraTabControl1.TabPages.Count - 1].PageVisible = false;
                        }
                    }
                }
                if (this.mAnnoLayer != null)
                {
                    if (this.mAnnFList.Count == 0)
                    {
                        this.InitialFieldList(this.mAnnFList, this.mAnnoLayer.FeatureClass);
                    }
                    this.InitialFieldList2(this.listBoxFieldList, this.mAnnFList);
                    this.listBoxFieldList.Tag = this.mAnnoLayer.FeatureClass;
                }
                else
                {
                    this.xtraTabPage1.PageVisible = false;
                    if (this.mPointLayer != null)
                    {
                        if (this.mPointFList.Count == 0)
                        {
                            this.InitialFieldList(this.mPointFList, this.mPointLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mPointFList);
                        this.listBoxFieldList.Tag = this.mPointLayer.FeatureClass;
                    }
                    else
                    {
                        this.xtraTabPage2.PageVisible = false;
                        if (this.mPolylineLayer != null)
                        {
                            if (this.mLineFList.Count == 0)
                            {
                                this.InitialFieldList(this.mLineFList, this.mPolylineLayer.FeatureClass);
                            }
                            this.InitialFieldList2(this.listBoxFieldList, this.mLineFList);
                            this.listBoxFieldList.Tag = this.mPolylineLayer.FeatureClass;
                        }
                        else
                        {
                            this.xtraTabPage3.PageVisible = false;
                            if (this.mPolygonLayer != null)
                            {
                                if (this.mPolyFList.Count == 0)
                                {
                                    this.InitialFieldList(this.mPolyFList, this.mPolygonLayer.FeatureClass);
                                }
                                this.InitialFieldList2(this.listBoxFieldList, this.mPolyFList);
                                this.listBoxFieldList.Tag = this.mPolygonLayer.FeatureClass;
                            }
                            else
                            {
                                this.xtraTabPage4.PageVisible = false;
                                if (this.mMultiPatchLayer != null)
                                {
                                    if (this.mMultiFList.Count == 0)
                                    {
                                        this.InitialFieldList(this.mMultiFList, this.mMultiPatchLayer.FeatureClass);
                                    }
                                    this.InitialFieldList2(this.listBoxFieldList, this.mMultiFList);
                                    this.listBoxFieldList.Tag = this.mMultiPatchLayer.FeatureClass;
                                }
                                else
                                {
                                    this.xtraTabPage5.PageVisible = false;
                                }
                            }
                        }
                    }
                }
                if (this.mLayerList.Count > 0)
                {
                    this.panelKind.Enabled = true;
                }
                this.Cursor = Cursors.Default;
                this.mSelected = false;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mSelected = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "ReadCADValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetWhereString()
        {
            try
            {
                int num;
                if (this.mWhereList == null)
                {
                    this.mWhereList = new ArrayList();
                    for (num = 0; num < this.mLayerList.Count; num++)
                    {
                        this.mWhereList.Add("");
                    }
                }
                IFeatureLayer layer = this.mLayerList[this.xtraTabControl1.SelectedTabPageIndex] as IFeatureLayer;
                IFeatureClass featureClass = layer.FeatureClass;
                string[] strArray = this.richTextBox.Text.Trim().Replace(" and ", ",").Split(new char[] { ',' });
                for (num = 0; num < strArray.Length; num++)
                {
                    string[] strArray2 = strArray[num].Split(new char[] { '=' });
                    int index = featureClass.Fields.FindField(strArray2[0].Trim());
                    if (featureClass.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                    {
                        strArray2[1] = strArray2[1].Trim().Replace("'", "");
                        strArray2[1] = strArray2[1].Trim().Replace("'", "");
                        strArray2[1] = "'" + strArray2[1].Trim() + "'";
                        strArray[num] = strArray2[0].Trim() + " = " + strArray2[1];
                    }
                }
                string str = strArray[0];
                for (num = 1; num < strArray.Length; num++)
                {
                    str = str + " and " + strArray[num];
                }
                this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex] = str;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "CreateDataValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            if (this.richTextBox.Text.Trim() == "")
            {
                this.richTextBox.Text = this.PopupContainerEdit1.Text + " = " + this.PopupContainerEdit2.Text;
            }
            else
            {
                this.richTextBox.Text = this.richTextBox.Text + " and " + this.PopupContainerEdit1.Text + " = " + this.PopupContainerEdit2.Text;
            }
            this.SetWhereString();
            this.panelPath2.Enabled = true;
        }

        private void simpleButtonClear_Click(object sender, EventArgs e)
        {
            this.richTextBox.Text = "";
        }

        private void simpleButtonInput_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                ILayer layer;
                if (this.mGDBFeatureWorkspace == null)
                {
                    if (this.CreateWorkspace(this.mSavePath, this.mSaveName))
                    {
                        if (this.CreateLayer(this.mGDBFeatureWorkspace, this.mLayerList))
                        {
                            if (((this.mTLayerList != null) && (this.mTLayerList.Count > 0)) && (MessageBox.Show("是否将已转换数据添加到当前视图", "数据转换", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                            {
                                if (this.mGroupLayer == null)
                                {
                                    this.mGroupLayer = new GroupLayerClass();
                                }
                                this.mGroupLayer.Clear();
                                for (num = 0; num < this.mTLayerList.Count; num++)
                                {
                                    layer = this.mTLayerList[num] as ILayer;
                                    this.mGroupLayer.Name = (layer as IFeatureLayer).FeatureClass.FeatureDataset.Name;
                                    this.mGroupLayer.Add(layer);
                                }
                                this.mHookHelper.FocusMap.AddLayer(this.mGroupLayer);
                            }
                        }
                        else
                        {
                            MessageBox.Show("数据转换错误", "CAD数据转换", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                else if (this.CreateLayer(this.mGDBFeatureWorkspace, this.mLayerList))
                {
                    if (((this.mTLayerList != null) && (this.mTLayerList.Count > 0)) && (MessageBox.Show("是否将已转换数据添加到当前视图", "数据转换", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                    {
                        if (this.mGroupLayer == null)
                        {
                            this.mGroupLayer = new GroupLayerClass();
                        }
                        this.mGroupLayer.Clear();
                        for (num = 0; num < this.mTLayerList.Count; num++)
                        {
                            layer = this.mTLayerList[num] as ILayer;
                            this.mGroupLayer.Name = (layer as IFeatureLayer).FeatureClass.FeatureDataset.Name;
                            this.mGroupLayer.Add(layer);
                        }
                        this.mHookHelper.FocusMap.AddLayer(this.mGroupLayer);
                    }
                }
                else
                {
                    MessageBox.Show("数据转换错误", "CAD数据转换", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "simpleButtonInput_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonPoject_Click(object sender, EventArgs e)
        {
            FormSetSpatialreference spatialreference = new FormSetSpatialreference();
            this.mSpatialReference = this.mHookHelper.FocusMap.SpatialReference;
            spatialreference.InitialValue(this.mSpatialReference);
            spatialreference.ShowDialog();
            this.mSpatialReference = spatialreference.SpatialReference;
        }

        private void simpleButtonReset_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "simpleButtonReset_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                if (this.simpleButtonSelect.Text == "全选")
                {
                    for (num = 0; num < this.cListKind.Items.Count; num++)
                    {
                        this.cListKind.Items[num].CheckState = CheckState.Checked;
                    }
                    this.simpleButtonSelect.Text = "反选";
                    this.panelRange.Enabled = true;
                    this.panelPath2.Enabled = true;
                }
                else
                {
                    for (num = 0; num < this.cListKind.Items.Count; num++)
                    {
                        this.cListKind.Items[num].CheckState = CheckState.Unchecked;
                    }
                    this.simpleButtonSelect.Text = "全选";
                    this.panelRange.Enabled = false;
                    this.panelPath2.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "simpleButtonSelect_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonView_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(this.buttonEditCADPath.Text.Trim()))
                {
                    string directoryName = System.IO.Path.GetDirectoryName(this.buttonEditCADPath.Text.Trim());
                    string fileName = System.IO.Path.GetFileName(this.buttonEditCADPath.Text.Trim());
                    ICadDrawingDataset cadDataset = this.GetCadDataset(directoryName, fileName);
                    if (cadDataset != null)
                    {
                        ICadLayer layer = new CadLayerClass();
                        layer.CadDrawingDataset = cadDataset;
                        layer.Name = fileName;
                        ILayer layer2 = null;
                        layer2 = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, fileName, true);
                        if (layer2 != null)
                        {
                            this.mHookHelper.FocusMap.DeleteLayer(layer2);
                        }
                        layer2 = layer;
                        if (this.mSpatialReference != null)
                        {
                            layer2.SpatialReference = this.mSpatialReference;
                        }
                        if (this.mSpatialReference != null)
                        {
                            layer.SpatialReference = this.mSpatialReference;
                        }
                        this.mHookHelper.FocusMap.AddLayer(layer2);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "simpleButtonView_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void UserControlConverData_Resize(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "UserControlConverData_Resize", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void UserControlInputData3_Load(object sender, EventArgs e)
        {
        }

        private void xtraTabControl1_Resize(object sender, EventArgs e)
        {
            this.panelSetRange.Top = this.xtraTabControl1.Top + 0x18;
            this.panelSetRange.Width = this.xtraTabControl1.Width - 8;
            this.panelSetRange.Height = this.xtraTabControl1.Height - 0x1c;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (!this.mSelected)
                {
                    if (this.xtraTabControl1.SelectedTabPage.Text == "注记")
                    {
                        if (this.mAnnFList == null)
                        {
                            this.mAnnFList = new ArrayList();
                            this.InitialFieldList(this.mAnnFList, this.mAnnoLayer.FeatureClass);
                        }
                        else if (this.mAnnFList.Count == 0)
                        {
                            this.InitialFieldList(this.mAnnFList, this.mAnnoLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mAnnFList);
                        this.listBoxFieldList.Tag = this.mAnnoLayer.FeatureClass;
                        this.richTextBox.Text = this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex].ToString();
                    }
                    else if (this.xtraTabControl1.SelectedTabPage.Text == "点")
                    {
                        if (this.mPointFList == null)
                        {
                            this.mPointFList = new ArrayList();
                            this.InitialFieldList(this.mPointFList, this.mPointLayer.FeatureClass);
                        }
                        else if (this.mPointFList.Count == 0)
                        {
                            this.InitialFieldList(this.mPointFList, this.mPointLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mPointFList);
                        this.listBoxFieldList.Tag = this.mPointLayer.FeatureClass;
                        this.richTextBox.Text = this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex].ToString();
                    }
                    else if (this.xtraTabControl1.SelectedTabPage.Text == "线")
                    {
                        if (this.mLineFList == null)
                        {
                            this.mLineFList = new ArrayList();
                            this.InitialFieldList(this.mLineFList, this.mPolylineLayer.FeatureClass);
                        }
                        else if (this.mLineFList.Count == 0)
                        {
                            this.InitialFieldList(this.mLineFList, this.mPolylineLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mLineFList);
                        this.listBoxFieldList.Tag = this.mPolylineLayer.FeatureClass;
                        this.richTextBox.Text = this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex].ToString();
                    }
                    else if (this.xtraTabControl1.SelectedTabPage.Text == "面")
                    {
                        if (this.mPolyFList == null)
                        {
                            this.mPolyFList = new ArrayList();
                            this.InitialFieldList(this.mPolyFList, this.mPolygonLayer.FeatureClass);
                        }
                        else if (this.mPolyFList.Count == 0)
                        {
                            this.InitialFieldList(this.mPolyFList, this.mPolygonLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mPolyFList);
                        this.listBoxFieldList.Tag = this.mPolylineLayer.FeatureClass;
                        this.richTextBox.Text = this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex].ToString();
                    }
                    else if (this.xtraTabControl1.SelectedTabPage.Text == "多面体")
                    {
                        if (this.mMultiFList == null)
                        {
                            this.mMultiFList = new ArrayList();
                            this.InitialFieldList(this.mMultiFList, this.mMultiPatchLayer.FeatureClass);
                        }
                        else if (this.mMultiFList.Count == 0)
                        {
                            this.InitialFieldList(this.mMultiFList, this.mMultiPatchLayer.FeatureClass);
                        }
                        this.InitialFieldList2(this.listBoxFieldList, this.mMultiFList);
                        this.listBoxFieldList.Tag = this.mMultiPatchLayer.FeatureClass;
                        this.richTextBox.Text = this.mWhereList[this.xtraTabControl1.SelectedTabPageIndex].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlConvertData", "xtraTabControl1_SelectedPageChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

