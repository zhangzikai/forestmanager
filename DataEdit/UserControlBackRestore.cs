namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlBackRestore : UserControlBase1
    {
        private ButtonEdit buttonEdit1;
        private ButtonEdit buttonEdit2;
        private ButtonEdit buttonPath;
        private CheckedListBoxControl cListFiles;
        private IContainer components = null;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private GroupControl groupControlCatalog;
        private GroupControl groupControlNOList;
        private ImageListBoxControl iListFile;
        private ImageListBoxControl iListFile2;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private ImageList imageList1;
        private ImageList imageList2;
        private ImageList imageList3;
        private ImageList imageList4;
        private int kind = 0;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        internal Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        internal Label label5;
        internal Label label6;
        internal Label label7;
        private Label label8;
        internal Label label9;
        internal Label labelCatalog;
        private IFeatureWorkspace m_EditWorkspace;
        private RibbonPageGroup mapViewTools;
        private const string mClassName = "DataEdit.UserControlBackRestore";
        private ArrayList mDatasetList;
        private ArrayList mDatasetList2;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private GridControl mgridControl;
        private GridView mgridView;
        private IHookHelper mHookHelper;
        private Panel mpanMap;
        private ArrayList mPathList = null;
        private UserControlProgress mProgress = null;
        private bool mSelected = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mWorkspaceList;
        private ArrayList mWorkspaceList2;
        public NavBarControl navBarControl1;
        private NavBarGroup navBarGroup1;
        private NavBarGroup navBarGroup2;
        private NavBarGroup navBarGroup3;
        private NavBarGroup navBarGroup4;
        private NavBarGroup navBarGroup5;
        private NavBarGroup navBarGroup6;
        private NavBarGroup navBarGroup7;
        private NavBarGroup navBarGroup8;
        private NavBarItem navBarItem1;
        private NavBarItem navBarItem10;
        private NavBarItem navBarItem11;
        private NavBarItem navBarItem12;
        private NavBarItem navBarItem13;
        private NavBarItem navBarItem14;
        private NavBarItem navBarItem15;
        private NavBarItem navBarItem16;
        private NavBarItem navBarItem17;
        private NavBarItem navBarItem18;
        private NavBarItem navBarItem2;
        private NavBarItem navBarItem3;
        private NavBarItem navBarItem4;
        private NavBarItem navBarItem5;
        private NavBarItem navBarItem6;
        private NavBarItem navBarItem7;
        private NavBarItem navBarItem8;
        private NavBarItem navBarItem9;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelAuto;
        private Panel panelResList;
        private Panel panelResult2;
        private Panel panelSet;
        private RadioGroup radioGroup;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton4;
        private SimpleButton simpleButton5;
        private SimpleButton simpleButtonBackup;
        private SimpleButton simpleButtonBackup2;
        private SimpleButton simpleButtonRefrash;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonRestore;
        private SimpleButton simpleButtonRestore2;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonViewList;
        private SimpleButton simpleButtonViewMap;
        private SimpleButton simpleButtonViewMap2;
        private SimpleButton simpleButtonViewMap3;
        private string skind = "备份";
        private SplitContainerControl splitContainerControl1;
        private SplitterControl splitterControl1;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textNo;
        private TreeList tListCatalog;
        private TreeList tListLayers;
        private TreeList tListLayers2;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeList treeListno;

        public UserControlBackRestore()
        {
            this.InitializeComponent();
        }

        private void AddLayer(TreeList treeList)
        {
            try
            {
                if (treeList.Selection.Count != 0)
                {
                    this.mapViewTools.Visible = true;
                    IMap focusMap = this.mHookHelper.FocusMap;
                    focusMap.ClearLayers();
                    for (int i = 0; i < treeList.Selection.Count; i++)
                    {
                        int num2;
                        IFeatureClass tag;
                        IFeatureLayer layer;
                        string str;
                        string str2;
                        string configValue;
                        TreeListNode node = treeList.Selection[i];
                        if (node.Tag is IFeatureDataset)
                        {
                            num2 = 0;
                            while (num2 < node.Nodes.Count)
                            {
                                if (node.Nodes[num2].Tag is IFeatureClass)
                                {
                                    tag = node.Nodes[num2].Tag as IFeatureClass;
                                    layer = new FeatureLayerClass();
                                    str = "";
                                    str2 = "";
                                    configValue = "";
                                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayer");
                                    if ((tag as IDataset).Name.Contains(configValue))
                                    {
                                        str = "造林";
                                        str2 = "ZaoLin";
                                    }
                                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayer");
                                    if ((tag as IDataset).Name.Contains(configValue))
                                    {
                                        str = "采伐";
                                        str2 = "CaiFa";
                                    }
                                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiLayer");
                                    if ((tag as IDataset).Name.Contains(configValue))
                                    {
                                        str = "林权宗地";
                                        str2 = "LinGai";
                                    }
                                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("GYLLayer");
                                    if ((tag as IDataset).Name.Contains(configValue))
                                    {
                                        str = "公益林";
                                        str2 = "GYL";
                                    }
                                    layer.Name = str + "数据";
                                    layer.FeatureClass = tag;
                                    focusMap.AddLayer(layer);
                                    this.RendererLayer(layer, str2);
                                }
                                num2++;
                            }
                            this.mpanMap.Visible = true;
                            this.mpanMap.BringToFront();
                            this.mgridControl.Visible = false;
                        }
                        else if (node.Tag is IFeatureClass)
                        {
                            tag = node.Tag as IFeatureClass;
                            str = "";
                            str2 = "";
                            configValue = "";
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayer");
                            if ((tag as IDataset).Name.Contains(configValue))
                            {
                                str = "造林";
                                str2 = "ZaoLin";
                            }
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayer");
                            if ((tag as IDataset).Name.Contains(configValue))
                            {
                                str = "采伐";
                                str2 = "CaiFa";
                            }
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiLayer");
                            if ((tag as IDataset).Name.Contains(configValue))
                            {
                                str = "林权宗地";
                                str2 = "LinGai";
                            }
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("GYLLayer");
                            if ((tag as IDataset).Name.Contains(configValue))
                            {
                                str = "公益林";
                                str2 = "GYL";
                            }
                            layer = new FeatureLayerClass();
                            layer.Name = str + "数据";
                            layer.FeatureClass = tag;
                            focusMap.AddLayer(layer);
                            this.RendererLayer(layer, str2);
                            this.mHookHelper.ActiveView.Refresh();
                            this.mpanMap.Visible = true;
                            this.mpanMap.BringToFront();
                            this.mgridControl.Visible = false;
                        }
                        else if (node.Tag is ITable)
                        {
                            ITable table = node.Tag as ITable;
                            DataTable table2 = new DataTable();
                            table2.Clear();
                            DataColumn column = null;
                            num2 = 0;
                            while (num2 < table.Fields.FieldCount)
                            {
                                IField field = table.Fields.get_Field(num2);
                                if (field.Type == esriFieldType.esriFieldTypeString)
                                {
                                    column = new DataColumn(field.Name, typeof(string));
                                }
                                else if (field.Type == esriFieldType.esriFieldTypeInteger)
                                {
                                    column = new DataColumn(field.Name, typeof(int));
                                }
                                else if (field.Type == esriFieldType.esriFieldTypeDouble)
                                {
                                    column = new DataColumn(field.Name, typeof(double));
                                }
                                else if (field.Type == esriFieldType.esriFieldTypeOID)
                                {
                                    column = new DataColumn(field.Name, typeof(string));
                                }
                                else
                                {
                                    column = new DataColumn(field.Name, typeof(string));
                                }
                                table2.Columns.Add(column);
                                num2++;
                            }
                            int num3 = table.RowCount(null);
                            ICursor cursor = table.Search(null, true);
                            for (num2 = 0; num2 < num3; num2++)
                            {
                                IRow row = cursor.NextRow();
                                DataRow row2 = table2.NewRow();
                                for (int j = 0; j < table.Fields.FieldCount; j++)
                                {
                                    if ((table.Fields.get_Field(j).Domain != null) && (table.Fields.get_Field(j).Domain.Type == esriDomainType.esriDTCodedValue))
                                    {
                                        ICodedValueDomain domain = (ICodedValueDomain) table.Fields.get_Field(j).Domain;
                                        string str4 = row.get_Value(j).ToString();
                                        for (int k = 0; k < domain.CodeCount; k++)
                                        {
                                            if (str4 == domain.get_Value(k).ToString())
                                            {
                                                row2[j] = domain.get_Name(k);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        row2[j] = row.get_Value(j);
                                    }
                                }
                                table2.Rows.Add(row2);
                            }
                            this.mgridControl.DataSource = null;
                            this.mgridView.Columns.Clear();
                            this.mgridControl.DataSource = table2;
                            this.mgridView.RefreshData();
                            this.mgridView.OptionsView.ColumnAutoWidth = false;
                            this.mpanMap.Visible = true;
                            this.mpanMap.BringToFront();
                            this.mgridControl.Visible = true;
                            this.mgridControl.BringToFront();
                        }
                        else if (node.Tag is IRasterDataset)
                        {
                            IRasterDataset rasterDataset = node.Tag as IRasterDataset;
                            IRaster2 raster = (IRaster2) rasterDataset.CreateDefaultRaster();
                            IRasterLayer layer2 = new RasterLayerClass();
                            layer2.Name = rasterDataset.CompleteName;
                            layer2.CreateFromDataset(rasterDataset);
                            focusMap.AddLayer(layer2);
                            this.mHookHelper.ActiveView.Refresh();
                            this.mpanMap.Visible = true;
                            this.mpanMap.BringToFront();
                            this.mgridControl.Visible = false;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "AddLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool BackupAllData()
        {
            try
            {
                this.mProgress.labelTitle.Text = this.skind + "进度：全部图形数据备份";
                this.BackupMapData();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupAllData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupEditData()
        {
            try
            {
                int num2;
                int num3;
                Application.DoEvents();
                this.mProgress.labelInfo.Text = "备份编辑数据";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                IWorkspace editWorkspace = this.m_EditWorkspace as IWorkspace;
                IWorkspaceDomains domains = editWorkspace as IWorkspaceDomains;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Dataset");
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Table");
                string str3 = "";
                string str4 = "";
                if (str2.Contains(","))
                {
                    str3 = str2.Split(new char[] { ',' })[1];
                    str2 = str2.Split(new char[] { ',' })[0];
                }
                if (this.mEditKind == "采伐")
                {
                    str4 = "T_HAR_RELATE";
                }
                IDataset dataset = editWorkspace as IDataset;
                IEnumDataset subsets = dataset.Subsets;
                IDataset dataset3 = subsets.Next();
                while (dataset3 != null)
                {
                    if (!((!dataset3.Name.Contains(configValue) || (dataset3.Name == (configValue + "_Templ"))) || dataset3.Name.Contains("HIS_")))
                    {
                        break;
                    }
                    dataset3 = subsets.Next();
                }
                if (dataset3 == null)
                {
                    return false;
                }
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string str6 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                this.mProgress.labelInfo.Text = "创建备份数据库";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建备份数据库";
                this.mProgress.progressBarControl1.Text = "10";
                IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                IWorkspaceName name = factory.Create(path + @"\", this.mEditKind2 + str6, null, 0);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                IWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(name.PathName, WorkspaceSource.esriWSFileGDBWorkspaceFactory) as IWorkspace;
                IWorkspaceDomains domains2 = featureWorkspace as IWorkspaceDomains;
                IEnumDomain domain = domains.Domains;
                IDomain domain2 = domain.Next();
                int num = 0;
                while (domain2 != null)
                {
                    if (domain2 is ICodedValueDomain)
                    {
                        ICodedValueDomain domain3 = new CodedValueDomainClass();
                        ICodedValueDomain domain4 = domain2 as ICodedValueDomain;
                        num2 = 0;
                        while (num2 < domain4.CodeCount)
                        {
                            domain3.AddCode(domain4.get_Value(num2), domain4.get_Name(num2));
                            num2++;
                        }
                        IDomain domain5 = domain3 as IDomain;
                        domain5.Name = domain2.Name;
                        domain5.Description = domain2.Description;
                        domain5.DomainID = num;
                        domain5.FieldType = domain2.FieldType;
                        num3 = domains2.AddDomain(domain3 as IDomain);
                        num++;
                    }
                    domain2 = domain.Next();
                }
                IFeatureWorkspace workspace3 = featureWorkspace as IFeatureWorkspace;
                this.mProgress.labelInfo.Text = "创建编辑数据集";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑数据集";
                IFeatureDataset dataset4 = workspace3.CreateFeatureDataset(dataset3.Name, (dataset3 as IGeoDataset).SpatialReference);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "30";
                IDataset dataset5 = dataset3.Subsets.Next();
                while (dataset5 != null)
                {
                    IFeatureClass class2 = dataset5 as IFeatureClass;
                    IGeoDataset dataset6 = class2 as IGeoDataset;
                    string[] strArray = dataset5.Name.Split(new char[] { '_' });
                    string str7 = strArray[strArray.Length - 1];
                    if (str7.Length != 4)
                    {
                        str7 = "";
                    }
                    ITable table = null;
                    if (str2 != "")
                    {
                        if (str7 != "")
                        {
                            table = this.m_EditWorkspace.OpenTable(str2 + "_" + str7);
                        }
                        else
                        {
                            table = this.m_EditWorkspace.OpenTable(str2);
                        }
                    }
                    ITable table2 = null;
                    ITable table3 = null;
                    if (str3 != "")
                    {
                        try
                        {
                            if (str7 != "")
                            {
                                table2 = this.m_EditWorkspace.OpenTable(str3 + "_" + str7);
                            }
                            else
                            {
                                table2 = this.m_EditWorkspace.OpenTable(str3);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (str4 != "")
                    {
                        try
                        {
                            if (str7 != "")
                            {
                                table3 = this.m_EditWorkspace.OpenTable(str4 + "_" + str7);
                            }
                            else
                            {
                                table3 = this.m_EditWorkspace.OpenTable(str4);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    ITable table4 = null;
                    ITable table5 = null;
                    ITable table6 = null;
                    IFeatureClassDescription description = new FeatureClassDescriptionClass();
                    IObjectClassDescription description2 = (IObjectClassDescription) description;
                    ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                    geoprocessor.OverwriteOutput = true;
                    this.mProgress.labelInfo.Text = "创建编辑图层";
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑图层";
                    this.mProgress.progressBarControl1.Text = "40";
                    ESRI.ArcGIS.AnalysisTools.Select process = new ESRI.ArcGIS.AnalysisTools.Select();
                    process.in_features = class2;
                    string str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + dataset4.Name + @"\" + dataset5.Name;
                    process.out_feature_class = str8;
                    process.where_clause = "";
                    object obj2 = geoprocessor.Execute(process, null);
                    IFeatureClass class3 = dataset4.Subsets.Next() as IFeatureClass;
                    if (class3 != null)
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                    }
                    else
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                    }
                    string messages = "";
                    object severity = null;
                    messages = geoprocessor.GetMessages(ref severity);
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                    this.mProgress.progressBarControl1.Text = "60";
                    this.mProgress.labelInfo.Text = "创建属性表";
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建属性表";
                    if ((str2 != "") && (table != null))
                    {
                        workspace3.CreateTable(str2 + "_" + str7, table.Fields, null, null, "");
                    }
                    if ((str3 != "") && (table2 != null))
                    {
                        workspace3.CreateTable(str3 + "_" + str7, table2.Fields, null, null, "");
                    }
                    if ((str4 != "") && (table3 != null))
                    {
                        workspace3.CreateTable(str4 + "_" + str7, table3.Fields, null, null, "");
                    }
                    TableSelect select2 = new TableSelect();
                    select2.in_table = table;
                    if (str7 != "")
                    {
                        str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str2 + "_" + str7;
                    }
                    else
                    {
                        str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str2;
                    }
                    select2.out_table = str8;
                    obj2 = geoprocessor.Execute(select2, null);
                    if (table2 != null)
                    {
                        select2 = new TableSelect();
                        select2.in_table = table2;
                        if (str7 != "")
                        {
                            str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str3 + "_" + str7;
                        }
                        else
                        {
                            str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str3;
                        }
                        select2.out_table = str8;
                        obj2 = geoprocessor.Execute(select2, null);
                    }
                    if (table3 != null)
                    {
                        select2 = new TableSelect();
                        select2.in_table = table3;
                        if (str7 != "")
                        {
                            str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str4 + "_" + str7;
                        }
                        else
                        {
                            str8 = path + @"\" + this.mEditKind2 + str6 + @".gdb\" + str4;
                        }
                        select2.out_table = str8;
                        obj2 = geoprocessor.Execute(select2, null);
                    }
                    if (table != null)
                    {
                        table4 = workspace3.OpenTable(str2 + "_" + str7);
                    }
                    if (table2 != null)
                    {
                        table5 = workspace3.OpenTable(str3 + "_" + str7);
                    }
                    if (table3 != null)
                    {
                        table6 = workspace3.OpenTable(str4 + "_" + str7);
                    }
                    if (table4 != null)
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                    }
                    else
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                    }
                    messages = "";
                    severity = null;
                    messages = geoprocessor.GetMessages(ref severity);
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                    this.mProgress.progressBarControl1.Text = "80";
                    if ((this.mEditKind == "造林") || (this.mEditKind == "采伐"))
                    {
                        this.mProgress.labelInfo.Text = "创建关联";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建关联";
                        UID uid = new UIDClass();
                        uid.Value = "esriGeoDatabase.Object";
                        IRelationshipClassContainer container = (IRelationshipClassContainer) dataset4;
                        IObjectClass originClass = class3 as IObjectClass;
                        IObjectClass destinationClass = table4 as IObjectClass;
                        IObjectClass class6 = null;
                        IObjectClass class7 = null;
                        if (table5 != null)
                        {
                            class6 = table5 as IObjectClass;
                        }
                        if (table6 != null)
                        {
                            class7 = table6 as IObjectClass;
                        }
                        string relClassName = (table4 as IDataset).Name.Replace("T_", "");
                        if (str7 != "")
                        {
                            relClassName = relClassName.Replace("_" + str7, "") + "_Relation_" + str7;
                        }
                        else
                        {
                            relClassName = relClassName + "_Relation";
                        }
                        IRelationshipClass class8 = container.CreateRelationshipClass(relClassName, originClass, destinationClass, (table4 as IDataset).Name, (class3 as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "UUID", "", "UUID", "");
                        IRelationshipClass class9 = null;
                        IRelationshipClass class10 = null;
                        if (class6 != null)
                        {
                            relClassName = (table5 as IDataset).Name.Replace("T_", "").Replace("_" + str7, "") + "_Relation_" + str7;
                            class9 = container.CreateRelationshipClass(relClassName, originClass, class6, (table5 as IDataset).Name, (class3 as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "UUID", "", "UUID", "");
                        }
                        if (class7 != null)
                        {
                            relClassName = (table6 as IDataset).Name.Replace("T_", "").Replace("_" + str7, "") + "_Relation_" + str7;
                            class10 = workspace3.CreateRelationshipClass(relClassName, destinationClass, class7, (table6 as IDataset).Name, (table4 as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "Tree_ID", "", "Tree_ID", "");
                        }
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        this.mProgress.progressBarControl1.Text = "90";
                        this.mProgress.labelInfo.Text = "创建作业设计表";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建作业设计表";
                        DataTable dataTable = null;// TaskManageClass.GetDataTable(UtilFactory.GetDBAccess("Access"), "SELECT * FROM T_EditTask where (taskyear='" + str7 + "' and layername='" + dataset5.Name + "')");
                        if (dataTable.Rows.Count > 0)
                        {
                            IFields fields = new FieldsClass();
                            IFieldsEdit edit = (IFieldsEdit) fields;
                            IField field = new FieldClass();
                            IFieldEdit edit2 = (IFieldEdit) field;
                            edit2.Name_2 = "ObjectID";
                            edit2.AliasName_2 = "FID";
                            edit2.Type_2 = esriFieldType.esriFieldTypeOID;
                            edit.AddField(field);
                            IField field2 = null;
                            num2 = 0;
                            while (num2 < dataTable.Columns.Count)
                            {
                                field2 = new FieldClass();
                                IFieldEdit edit3 = (IFieldEdit) field2;
                                edit3.Length_2 = 100;
                                edit3.Name_2 = dataTable.Columns[num2].ColumnName;
                                edit3.Type_2 = esriFieldType.esriFieldTypeString;
                                edit.AddField(field2);
                                num2++;
                            }
                            ITable table8 = workspace3.CreateTable("T_EditTask", fields, null, null, "");
                            IWorkspaceEdit edit4 = workspace3 as IWorkspaceEdit;
                            if (edit4 == null)
                            {
                                return false;
                            }
                            edit4.StartEditing(false);
                            edit4.StartEditOperation();
                            for (num3 = 0; num3 < dataTable.Rows.Count; num3++)
                            {
                                IRow row = table8.CreateRow();
                                for (num2 = 0; num2 < dataTable.Columns.Count; num2++)
                                {
                                    row.set_Value(num2 + 1, dataTable.Rows[num3][num2].ToString());
                                }
                                try
                                {
                                    row.Store();
                                }
                                catch (Exception)
                                {
                                }
                            }
                            try
                            {
                                edit4.StopEditOperation();
                            }
                            catch (Exception)
                            {
                                edit4.StopEditOperation();
                            }
                            edit4.StopEditing(true);
                        }
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                    }
                    this.mProgress.progressBarControl1.Text = "100";
                    break;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupEditData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupFeatureClass(IFeatureClass pfClass)
        {
            try
            {
                this.mProgress.labelInfo.Text = "备份" + pfClass.AliasName + "数据";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string str2 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                this.mProgress.labelInfo.Text = "创建备份数据库";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建备份数据库";
                this.mProgress.progressBarControl1.Text = "10";
                IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                IWorkspaceName name = factory.Create(path + @"\", pfClass.AliasName + str2, null, 0);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                IName name2 = (IName) name;
                IWorkspace workspace = (IWorkspace) name2.Open();
                IFeatureWorkspace workspace2 = workspace as IFeatureWorkspace;
                string aliasName = pfClass.AliasName;
                IFeatureClass class2 = pfClass;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                this.mProgress.labelInfo.Text = "创建" + aliasName + "图层";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + aliasName + "创建图层";
                this.mProgress.progressBarControl1.Text = (int.Parse(this.mProgress.progressBarControl1.Text) + 10).ToString();
                ESRI.ArcGIS.AnalysisTools.Select process = new ESRI.ArcGIS.AnalysisTools.Select();
                process.in_features = class2;
                string str4 = path + @"\" + aliasName + str2 + @".gdb\" + aliasName;
                process.out_feature_class = str4;
                process.where_clause = "";
                object obj2 = geoprocessor.Execute(process, null);
                if (workspace2.OpenFeatureClass(aliasName) != null)
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                }
                else
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                }
                string messages = "";
                object severity = null;
                messages = geoprocessor.GetMessages(ref severity);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                this.mProgress.progressBarControl1.Text = (int.Parse(this.mProgress.progressBarControl1.Text) + 10).ToString();
                this.mProgress.progressBarControl1.Text = "100";
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupFeatureClass", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupFeatureDataset(IFeatureDataset pfDataset)
        {
            try
            {
                this.mProgress.labelInfo.Text = "备份" + pfDataset.Name + "数据";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string str2 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                this.mProgress.labelInfo.Text = "创建备份数据库";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建备份数据库";
                this.mProgress.progressBarControl1.Text = "10";
                IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                IWorkspaceName name = factory.Create(path + @"\", pfDataset.Name + str2, null, 0);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                IName name2 = (IName) name;
                IWorkspace workspace = (IWorkspace) name2.Open();
                IFeatureWorkspace workspace2 = workspace as IFeatureWorkspace;
                string str3 = pfDataset.Name;
                this.mProgress.labelInfo.Text = "创建编辑数据集";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑数据集";
                IFeatureDataset dataset = workspace2.CreateFeatureDataset(pfDataset.Name, (pfDataset as IGeoDataset).SpatialReference);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "30";
                IEnumDataset subsets = pfDataset.Subsets;
                for (IDataset dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
                {
                    if (dataset3 is IFeatureClass)
                    {
                        IFeatureClass class2 = dataset3 as IFeatureClass;
                        ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                        geoprocessor.OverwriteOutput = true;
                        this.mProgress.labelInfo.Text = "创建" + dataset3.Name + "图层";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + dataset3.Name + "创建图层";
                        int num = int.Parse(this.mProgress.progressBarControl1.Text) + 10;
                        this.mProgress.progressBarControl1.Text = num.ToString();
                        ESRI.ArcGIS.AnalysisTools.Select process = new ESRI.ArcGIS.AnalysisTools.Select();
                        process.in_features = class2;
                        string str4 = path + @"\" + pfDataset.Name + str2 + @".gdb\" + dataset.Name + @"\" + dataset3.Name;
                        process.out_feature_class = str4;
                        process.where_clause = "";
                        object obj2 = geoprocessor.Execute(process, null);
                        IFeatureClass class3 = dataset.Subsets.Next() as IFeatureClass;
                        if (class3 != null)
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        }
                        else
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                        }
                        string messages = "";
                        object severity = null;
                        messages = geoprocessor.GetMessages(ref severity);
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                        this.mProgress.progressBarControl1.Text = (int.Parse(this.mProgress.progressBarControl1.Text) + 10).ToString();
                    }
                    else if (dataset3 is IRelationship)
                    {
                        IRelationship relationship = dataset3 as IRelationship;
                        IObjectClass originObject = relationship.OriginObject as IObjectClass;
                        IObjectClass destinationObject = relationship.DestinationObject as IObjectClass;
                        IFeatureClass class6 = originObject as IFeatureClass;
                        ITable table = destinationObject as ITable;
                    }
                }
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "100";
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupFeatureDataset", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupMapData()
        {
            try
            {
                this.mProgress.labelTitle.Text = this.skind + "进度：备份图形数据";
                this.mProgress.labelInfo.Text = "开始";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                IWorkspace editWorkspace = this.m_EditWorkspace as IWorkspace;
                IWorkspaceName workspaceName = new WorkspaceNameClass();
                workspaceName.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";
                workspaceName.PathName = editWorkspace.PathName;
                string[] strArray = editWorkspace.PathName.Split(new char[] { '\\' });
                string[] strArray2 = strArray[strArray.Length - 1].Split(new char[] { '.' });
                string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                string str2 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建图形数据库";
                this.mProgress.progressBarControl1.Text = "20";
                IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                IWorkspaceName workspaceNameCopy = null;
                factory.Copy(workspaceName, str + @"\", out workspaceNameCopy);
                if (workspaceNameCopy == null)
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                    return false;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                Rename rename = new Rename();
                rename.in_data = workspaceNameCopy.PathName;
                rename.out_data = str + @"\" + strArray2[0] + str2 + "." + strArray2[1];
                IGPProcess process = rename;
                if (geoprocessor.Execute(process, null) != null)
                {
                    workspaceNameCopy.PathName = str + @"\" + strArray2[0] + str2 + "." + strArray2[1];
                }
                IName name3 = (IName) workspaceNameCopy;
                IWorkspace workspace2 = (IWorkspace) name3.Open();
                IFeatureWorkspace workspace3 = workspace2 as IFeatureWorkspace;
                if (workspace3 != null)
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                }
                else
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                }
                this.mProgress.progressBarControl1.Text = "100";
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupMapData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupSystemData()
        {
            try
            {
                this.mProgress.labelTitle.Text = this.skind + "进度：备份系统数据";
                this.mProgress.labelInfo.Text = "开始";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = false;
                this.mProgress.Refresh();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath");
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath").ToString().Split(new char[] { '\\' });
                string[] strArray2 = strArray[strArray.Length - 1].Split(new char[] { '.' });
                string str2 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                string destFileName = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath") + @"\" + strArray2[0] + str2 + "." + strArray2[1];
                if (File.Exists(path))
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n复制系统数据库";
                    File.Copy(path, destFileName);
                    if (File.Exists(destFileName))
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        return true;
                    }
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                    return false;
                }
                this.mProgress.richTextBox.Text = "系统数据库不存在";
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "BackupSystemData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool BackupTable(ITable pTable)
        {
            try
            {
                IDataset dataset = pTable as IDataset;
                this.mProgress.labelInfo.Text = "备份" + dataset.Name + "数据";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string str2 = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_');
                this.mProgress.labelInfo.Text = "创建备份数据库";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建备份数据库";
                this.mProgress.progressBarControl1.Text = "10";
                IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                IWorkspaceName name = factory.Create(path + @"\", this.mEditKind2 + str2, null, 0);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                IName name2 = (IName) name;
                IWorkspace workspace = (IWorkspace) name2.Open();
                IFeatureWorkspace workspace2 = workspace as IFeatureWorkspace;
                string str3 = dataset.Name;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                this.mProgress.labelInfo.Text = "创建" + str3 + "属性表";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + str3 + "属性表";
                this.mProgress.progressBarControl1.Text = (int.Parse(this.mProgress.progressBarControl1.Text) + 10).ToString();
                workspace2.CreateTable(str3, pTable.Fields, null, null, "");
                TableSelect process = new TableSelect();
                process.in_table = pTable;
                string str4 = path + @"\" + this.mEditKind2 + str2 + @".gdb\" + str3;
                process.out_table = str4;
                object obj2 = geoprocessor.Execute(process, null);
                if (workspace2.OpenTable(str3) != null)
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                }
                else
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                }
                string messages = "";
                object severity = null;
                messages = geoprocessor.GetMessages(ref severity);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                this.mProgress.progressBarControl1.Text = "80";
                this.mProgress.progressBarControl1.Text = "100";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void cListFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            this.Cursor = Cursors.WaitCursor;
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
                    if (this.kind == 3)
                    {
                        this.m_EditWorkspace = tag;
                        this.simpleButtonBackup2.Enabled = true;
                    }
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
                    this.Cursor = Cursors.Default;
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
                            this.simpleButtonRestore.Enabled = true;
                            this.treeListno.FocusedNode = parentNode;
                            this.simpleButtonViewMap3.Enabled = true;
                            this.simpleButtonBackup2.Enabled = true;
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        if (ParentNode.Tag is string)
                        {
                            path = ParentNode.Tag.ToString();
                            if (this.kind == 3)
                            {
                                this.m_EditWorkspace = null;
                            }
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
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "EnumDirectories", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void iListFile_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.mSelected)
            {
                if (this.iListFile.SelectedIndex != -1)
                {
                    if (this.simpleButtonRestore.Visible)
                    {
                        this.simpleButtonRestore.Enabled = true;
                    }
                    this.simpleButtonViewList.Enabled = true;
                    this.InitialLayerlist2();
                    if (this.tListLayers.Nodes.Count > 0)
                    {
                        this.simpleButtonViewMap.Enabled = true;
                    }
                }
                else
                {
                    if (this.simpleButtonRestore.Visible)
                    {
                        this.simpleButtonRestore.Enabled = false;
                    }
                    this.simpleButtonViewList.Enabled = true;
                }
                if (this.radioGroup.SelectedIndex == 1)
                {
                    this.simpleButtonViewList.Enabled = false;
                }
            }
        }

        private void iListFile2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.mSelected)
            {
                this.InitialLayerlist();
            }
        }

        private void iListno_SelectedValueChanged(object sender, EventArgs e)
        {
            this.simpleButtonBackup2.Enabled = true;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "InitialCatalogList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControls(int ikind)
        {
            try
            {
                this.kind = ikind;
                this.splitContainerControl1.Horizontal = false;
                if (this.kind < 2)
                {
                    if (this.kind == 0)
                    {
                        this.skind = "备份";
                        this.simpleButtonBackup.Visible = true;
                        this.simpleButtonRestore.Visible = false;
                        this.simpleButtonBackup.Enabled = true;
                        this.panel3.Visible = true;
                    }
                    else if (this.kind == 1)
                    {
                        this.skind = "恢复";
                        this.simpleButtonBackup.Visible = false;
                        this.simpleButtonRestore.Visible = true;
                        this.panel3.Visible = false;
                    }
                    this.panelAuto.Visible = true;
                    this.groupControl1.Text = "自动" + this.skind;
                    this.panelAuto.Dock = DockStyle.Fill;
                    this.radioGroup.Properties.Items.Clear();
                    RadioGroupItem item = new RadioGroupItem();
                    item.Description = "编辑数据" + this.skind;
                    this.radioGroup.Properties.Items.Add(item);
                    item = new RadioGroupItem();
                    item.Description = "系统数据" + this.skind;
                    this.radioGroup.Properties.Items.Add(item);
                    item = new RadioGroupItem();
                    item.Description = "全部数据" + this.skind;
                    this.radioGroup.Properties.Items.Add(item);
                    this.panelSet.Visible = false;
                    this.InitialListFile();
                }
                else
                {
                    if (this.kind == 2)
                    {
                        this.skind = "备份";
                        this.simpleButtonBackup2.Visible = true;
                        this.simpleButtonRestore2.Visible = false;
                        this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                        this.panelResult2.Visible = true;
                    }
                    else if (this.kind == 3)
                    {
                        this.skind = "恢复";
                        this.simpleButtonBackup2.Visible = false;
                        this.simpleButtonRestore2.Visible = true;
                        this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                        this.panelResult2.Visible = true;
                        this.splitContainerControl1.Horizontal = true;
                        this.splitContainerControl1.Panel1.Width = (this.splitContainerControl1.Width / 2) - 10;
                    }
                    this.panelAuto.Visible = false;
                    this.panelSet.Visible = true;
                    this.panelSet.Dock = DockStyle.Fill;
                    this.groupControl2.Text = "指定" + this.skind;
                    this.InitialCatalogList();
                    this.treeListno.Nodes.Clear();
                    this.InitialListFile();
                    this.InitialLayerlist();
                }
                this.mpanMap.Visible = false;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.labelInfo.Text = "";
                this.mProgress.labelTitle.Text = this.skind + "进度";
                this.mProgress.richTextBox.Text = "";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "InitialcListFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBackRestore));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelAuto = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tListLayers = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel14 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.simpleButtonViewMap = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButtonRestore = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.simpleButtonViewList = new DevExpress.XtraEditors.SimpleButton();
            this.panelResList = new System.Windows.Forms.Panel();
            this.iListFile = new DevExpress.XtraEditors.ImageListBoxControl();
            this.cListFiles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButtonBackup = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.label12 = new System.Windows.Forms.Label();
            this.panelSet = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelResult2 = new System.Windows.Forms.Panel();
            this.tListLayers2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel16 = new System.Windows.Forms.Panel();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.panel17 = new System.Windows.Forms.Panel();
            this.simpleButtonViewMap2 = new DevExpress.XtraEditors.SimpleButton();
            this.label10 = new System.Windows.Forms.Label();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panel18 = new System.Windows.Forms.Panel();
            this.iListFile2 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.label11 = new System.Windows.Forms.Label();
            this.groupControlNOList = new DevExpress.XtraEditors.GroupControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.treeListno = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.simpleButtonViewMap3 = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupControlCatalog = new DevExpress.XtraEditors.GroupControl();
            this.tListCatalog = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.labelCatalog = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonPath = new DevExpress.XtraEditors.ButtonEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonRefrash = new DevExpress.XtraEditors.SimpleButton();
            this.textNo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.panel10 = new System.Windows.Forms.Panel();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.buttonEdit2 = new DevExpress.XtraEditors.ButtonEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.simpleButtonRestore2 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButtonBackup2 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup6 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup7 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup8 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem17 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem18 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.imageList4 = new System.Windows.Forms.ImageList();
            this.panelAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListLayers)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelResList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iListFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListFiles)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.panelSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panelResult2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListLayers2)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iListFile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).BeginInit();
            this.groupControlNOList.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).BeginInit();
            this.groupControlCatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAuto
            // 
            this.panelAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelAuto.Controls.Add(this.groupControl1);
            this.panelAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuto.Location = new System.Drawing.Point(9, 0);
            this.panelAuto.Name = "panelAuto";
            this.panelAuto.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelAuto.Size = new System.Drawing.Size(402, 684);
            this.panelAuto.TabIndex = 19;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.AppearanceCaption.Image")));
            this.groupControl1.AppearanceCaption.Options.UseImage = true;
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.panelResList);
            this.groupControl1.Controls.Add(this.panel3);
            this.groupControl1.Controls.Add(this.radioGroup);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 9);
            this.groupControl1.LookAndFeel.SkinName = "Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupControl1.Size = new System.Drawing.Size(402, 675);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.TabStop = true;
            this.groupControl1.Text = "自动备份";
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControl3.ContentImage")));
            this.groupControl3.Controls.Add(this.panel13);
            this.groupControl3.Controls.Add(this.label13);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(9, 438);
            this.groupControl3.LookAndFeel.SkinName = "Blue";
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(9, 9, 0, 0);
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(384, 228);
            this.groupControl3.TabIndex = 88;
            this.groupControl3.Text = "图层列表";
            this.groupControl3.Visible = false;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tListLayers);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(9, 35);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel13.Size = new System.Drawing.Size(375, 193);
            this.panel13.TabIndex = 79;
            // 
            // tListLayers
            // 
            this.tListLayers.Appearance.FocusedCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.tListLayers.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListLayers.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListLayers.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.tListLayers.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListLayers.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListLayers.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tListLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListLayers.Location = new System.Drawing.Point(0, 0);
            this.tListLayers.Name = "tListLayers";
            this.tListLayers.BeginUnboundLoad();
            this.tListLayers.AppendNode(new object[] {
            "ttt"}, -1, 0, 0, 29);
            this.tListLayers.AppendNode(new object[] {
            "t3"}, 0, 0, 0, 32);
            this.tListLayers.AppendNode(new object[] {
            "t2"}, 0, 0, 0, 31);
            this.tListLayers.AppendNode(new object[] {
            "t1"}, 0, 0, 0, 30);
            this.tListLayers.AppendNode(new object[] {
            "table1"}, -1, 0, 0, 34);
            this.tListLayers.EndUnboundLoad();
            this.tListLayers.OptionsView.ShowColumns = false;
            this.tListLayers.OptionsView.ShowHorzLines = false;
            this.tListLayers.OptionsView.ShowIndicator = false;
            this.tListLayers.OptionsView.ShowRoot = false;
            this.tListLayers.OptionsView.ShowVertLines = false;
            this.tListLayers.Size = new System.Drawing.Size(375, 148);
            this.tListLayers.StateImageList = this.imageList1;
            this.tListLayers.TabIndex = 0;
            this.tListLayers.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListLayers_FocusedNodeChanged);
            this.tListLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListLayers_MouseClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 51;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 93;
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
            // panel14
            // 
            this.panel14.Controls.Add(this.simpleButton1);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.simpleButtonViewMap);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 148);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel14.Size = new System.Drawing.Size(375, 40);
            this.panel14.TabIndex = 79;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.Location = new System.Drawing.Point(196, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 30);
            this.simpleButton1.TabIndex = 78;
            this.simpleButton1.Text = "全选";
            this.simpleButton1.Visible = false;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(282, 5);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(7, 30);
            this.panel15.TabIndex = 79;
            // 
            // simpleButtonViewMap
            // 
            this.simpleButtonViewMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonViewMap.Enabled = false;
            this.simpleButtonViewMap.ImageIndex = 10;
            this.simpleButtonViewMap.ImageList = this.imageCollection1;
            this.simpleButtonViewMap.Location = new System.Drawing.Point(289, 5);
            this.simpleButtonViewMap.Name = "simpleButtonViewMap";
            this.simpleButtonViewMap.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonViewMap.TabIndex = 77;
            this.simpleButtonViewMap.Text = "查看";
            this.simpleButtonViewMap.ToolTip = "地图查看";
            this.simpleButtonViewMap.Click += new System.EventHandler(this.simpleButtonViewMap_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.ImageIndex = 10;
            this.label13.ImageList = this.imageList1;
            this.label13.Location = new System.Drawing.Point(9, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(375, 26);
            this.label13.TabIndex = 84;
            this.label13.Text = "     详细信息列表";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.simpleButtonReset);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.simpleButtonRestore);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.simpleButtonViewList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(9, 398);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel2.Size = new System.Drawing.Size(384, 40);
            this.panel2.TabIndex = 80;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonReset.Image")));
            this.simpleButtonReset.Location = new System.Drawing.Point(112, 5);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonReset.TabIndex = 19;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.ToolTip = "重新选择";
            this.simpleButtonReset.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(198, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(7, 30);
            this.label1.TabIndex = 15;
            // 
            // simpleButtonRestore
            // 
            this.simpleButtonRestore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRestore.Enabled = false;
            this.simpleButtonRestore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRestore.Image")));
            this.simpleButtonRestore.Location = new System.Drawing.Point(205, 5);
            this.simpleButtonRestore.Name = "simpleButtonRestore";
            this.simpleButtonRestore.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonRestore.TabIndex = 21;
            this.simpleButtonRestore.Text = "恢复";
            this.simpleButtonRestore.ToolTip = "数据恢复";
            this.simpleButtonRestore.Visible = false;
            this.simpleButtonRestore.Click += new System.EventHandler(this.simpleButtonRestore_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(291, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(7, 30);
            this.label8.TabIndex = 20;
            // 
            // simpleButtonViewList
            // 
            this.simpleButtonViewList.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonViewList.Enabled = false;
            this.simpleButtonViewList.ImageIndex = 6;
            this.simpleButtonViewList.ImageList = this.imageList1;
            this.simpleButtonViewList.Location = new System.Drawing.Point(298, 5);
            this.simpleButtonViewList.Name = "simpleButtonViewList";
            this.simpleButtonViewList.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonViewList.TabIndex = 22;
            this.simpleButtonViewList.Text = "查看";
            this.simpleButtonViewList.ToolTip = "图层查看";
            this.simpleButtonViewList.Click += new System.EventHandler(this.simpleButtonViewList_Click);
            // 
            // panelResList
            // 
            this.panelResList.Controls.Add(this.iListFile);
            this.panelResList.Controls.Add(this.cListFiles);
            this.panelResList.Controls.Add(this.label4);
            this.panelResList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResList.Location = new System.Drawing.Point(9, 188);
            this.panelResList.Name = "panelResList";
            this.panelResList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panelResList.Size = new System.Drawing.Size(384, 210);
            this.panelResList.TabIndex = 85;
            // 
            // iListFile
            // 
            this.iListFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iListFile.ImageList = this.imageList1;
            this.iListFile.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 14),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 28),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 27)});
            this.iListFile.Location = new System.Drawing.Point(0, 31);
            this.iListFile.Name = "iListFile";
            this.iListFile.Size = new System.Drawing.Size(384, 174);
            this.iListFile.TabIndex = 2;
            this.iListFile.SelectedValueChanged += new System.EventHandler(this.iListFile_SelectedValueChanged);
            // 
            // cListFiles
            // 
            this.cListFiles.CheckOnClick = true;
            this.cListFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListFiles.Location = new System.Drawing.Point(0, 31);
            this.cListFiles.Name = "cListFiles";
            this.cListFiles.Size = new System.Drawing.Size(384, 174);
            this.cListFiles.TabIndex = 1;
            this.cListFiles.SelectedIndexChanged += new System.EventHandler(this.cListFiles_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(384, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "已备份文件列表";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simpleButtonBackup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(9, 148);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel3.Size = new System.Drawing.Size(384, 40);
            this.panel3.TabIndex = 86;
            // 
            // simpleButtonBackup
            // 
            this.simpleButtonBackup.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBackup.Enabled = false;
            this.simpleButtonBackup.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBackup.Image")));
            this.simpleButtonBackup.Location = new System.Drawing.Point(298, 5);
            this.simpleButtonBackup.Name = "simpleButtonBackup";
            this.simpleButtonBackup.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonBackup.TabIndex = 1;
            this.simpleButtonBackup.Text = "备份";
            this.simpleButtonBackup.ToolTip = "备份数据";
            this.simpleButtonBackup.Click += new System.EventHandler(this.simpleButtonBackup_Click);
            // 
            // radioGroup
            // 
            this.radioGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup.Location = new System.Drawing.Point(9, 55);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "编辑数据备份"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "系统数据备份"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部数据备份")});
            this.radioGroup.Size = new System.Drawing.Size(384, 93);
            this.radioGroup.TabIndex = 84;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(9, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(384, 26);
            this.label12.TabIndex = 87;
            this.label12.Text = "备份方式";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSet
            // 
            this.panelSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelSet.Controls.Add(this.groupControl2);
            this.panelSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSet.Location = new System.Drawing.Point(9, 684);
            this.panelSet.Name = "panelSet";
            this.panelSet.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelSet.Size = new System.Drawing.Size(402, 1244);
            this.panelSet.TabIndex = 20;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.AppearanceCaption.Image")));
            this.groupControl2.AppearanceCaption.Options.UseImage = true;
            this.groupControl2.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.groupControl2.Controls.Add(this.splitContainerControl1);
            this.groupControl2.Controls.Add(this.panel1);
            this.groupControl2.Controls.Add(this.panel11);
            this.groupControl2.Controls.Add(this.panel4);
            this.groupControl2.Controls.Add(this.navBarControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 9);
            this.groupControl2.LookAndFeel.SkinName = "Blue";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupControl2.Size = new System.Drawing.Size(402, 1235);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.TabStop = true;
            this.groupControl2.Text = "指定备份";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(9, 144);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelResult2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlNOList);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlCatalog);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(384, 958);
            this.splitContainerControl1.SplitterPosition = 336;
            this.splitContainerControl1.TabIndex = 92;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelResult2
            // 
            this.panelResult2.Controls.Add(this.tListLayers2);
            this.panelResult2.Controls.Add(this.panel16);
            this.panelResult2.Controls.Add(this.label10);
            this.panelResult2.Controls.Add(this.splitterControl1);
            this.panelResult2.Controls.Add(this.panel18);
            this.panelResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult2.Location = new System.Drawing.Point(0, 0);
            this.panelResult2.Name = "panelResult2";
            this.panelResult2.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.panelResult2.Size = new System.Drawing.Size(384, 336);
            this.panelResult2.TabIndex = 91;
            this.panelResult2.Visible = false;
            // 
            // tListLayers2
            // 
            this.tListLayers2.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListLayers2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListLayers2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListLayers2.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListLayers2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tListLayers2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListLayers2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2});
            this.tListLayers2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListLayers2.Location = new System.Drawing.Point(9, 207);
            this.tListLayers2.Name = "tListLayers2";
            this.tListLayers2.BeginUnboundLoad();
            this.tListLayers2.AppendNode(new object[] {
            "ttt"}, -1, 0, 0, 29);
            this.tListLayers2.AppendNode(new object[] {
            "t3"}, 0, 0, 0, 32);
            this.tListLayers2.AppendNode(new object[] {
            "t2"}, 0, 0, 0, 31);
            this.tListLayers2.AppendNode(new object[] {
            "t1"}, 0, 0, 0, 30);
            this.tListLayers2.AppendNode(new object[] {
            "table1"}, -1, 0, 0, 34);
            this.tListLayers2.EndUnboundLoad();
            this.tListLayers2.OptionsView.ShowColumns = false;
            this.tListLayers2.OptionsView.ShowHorzLines = false;
            this.tListLayers2.OptionsView.ShowIndicator = false;
            this.tListLayers2.OptionsView.ShowRoot = false;
            this.tListLayers2.OptionsView.ShowVertLines = false;
            this.tListLayers2.Size = new System.Drawing.Size(366, 84);
            this.tListLayers2.StateImageList = this.imageList1;
            this.tListLayers2.TabIndex = 86;
            this.tListLayers2.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListLayers2_FocusedNodeChanged);
            this.tListLayers2.SelectionChanged += new System.EventHandler(this.tListLayers2_SelectionChanged);
            this.tListLayers2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListLayers2_MouseClick);
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn1";
            this.treeListColumn2.FieldName = "treeListColumn1";
            this.treeListColumn2.MinWidth = 51;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            this.treeListColumn2.Width = 93;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.simpleButton5);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.simpleButtonViewMap2);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(9, 291);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel16.Size = new System.Drawing.Size(366, 40);
            this.panel16.TabIndex = 85;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton5.Location = new System.Drawing.Point(187, 5);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(86, 30);
            this.simpleButton5.TabIndex = 78;
            this.simpleButton5.Text = "全选";
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(273, 5);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(7, 30);
            this.panel17.TabIndex = 79;
            // 
            // simpleButtonViewMap2
            // 
            this.simpleButtonViewMap2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonViewMap2.Enabled = false;
            this.simpleButtonViewMap2.ImageIndex = 10;
            this.simpleButtonViewMap2.ImageList = this.imageCollection1;
            this.simpleButtonViewMap2.Location = new System.Drawing.Point(280, 5);
            this.simpleButtonViewMap2.Name = "simpleButtonViewMap2";
            this.simpleButtonViewMap2.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonViewMap2.TabIndex = 77;
            this.simpleButtonViewMap2.Text = "查看";
            this.simpleButtonViewMap2.Click += new System.EventHandler(this.simpleButtonViewMap2_Click);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(9, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(366, 34);
            this.label10.TabIndex = 3;
            this.label10.Text = "详细信息列表";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(9, 168);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(366, 5);
            this.splitterControl1.TabIndex = 87;
            this.splitterControl1.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.iListFile2);
            this.panel18.Controls.Add(this.label11);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(9, 5);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.panel18.Size = new System.Drawing.Size(366, 163);
            this.panel18.TabIndex = 90;
            // 
            // iListFile2
            // 
            this.iListFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iListFile2.ImageList = this.imageList1;
            this.iListFile2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 14),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 28),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, 27)});
            this.iListFile2.Location = new System.Drawing.Point(0, 26);
            this.iListFile2.Name = "iListFile2";
            this.iListFile2.Size = new System.Drawing.Size(366, 130);
            this.iListFile2.TabIndex = 2;
            this.iListFile2.SelectedIndexChanged += new System.EventHandler(this.iListFile2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(366, 26);
            this.label11.TabIndex = 89;
            this.label11.Text = "备份文件列表";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlNOList
            // 
            this.groupControlNOList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlNOList.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControlNOList.ContentImage")));
            this.groupControlNOList.Controls.Add(this.panel7);
            this.groupControlNOList.Controls.Add(this.label9);
            this.groupControlNOList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlNOList.Location = new System.Drawing.Point(0, 257);
            this.groupControlNOList.LookAndFeel.SkinName = "Blue";
            this.groupControlNOList.Name = "groupControlNOList";
            this.groupControlNOList.Padding = new System.Windows.Forms.Padding(9, 9, 9, 0);
            this.groupControlNOList.ShowCaption = false;
            this.groupControlNOList.Size = new System.Drawing.Size(384, 360);
            this.groupControlNOList.TabIndex = 87;
            this.groupControlNOList.Text = "图层列表";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.treeListno);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(9, 35);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel7.Size = new System.Drawing.Size(366, 325);
            this.panel7.TabIndex = 79;
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
            this.treeListno.OptionsView.ShowColumns = false;
            this.treeListno.OptionsView.ShowHorzLines = false;
            this.treeListno.OptionsView.ShowIndicator = false;
            this.treeListno.OptionsView.ShowRoot = false;
            this.treeListno.OptionsView.ShowVertLines = false;
            this.treeListno.Size = new System.Drawing.Size(366, 280);
            this.treeListno.TabIndex = 0;
            this.treeListno.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListno_MouseClick);
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
            this.panel8.Controls.Add(this.simpleButtonSelect);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.simpleButtonViewMap3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 280);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel8.Size = new System.Drawing.Size(366, 40);
            this.panel8.TabIndex = 79;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.Location = new System.Drawing.Point(187, 5);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonSelect.TabIndex = 78;
            this.simpleButtonSelect.Text = "全选";
            this.simpleButtonSelect.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(273, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(7, 30);
            this.panel9.TabIndex = 79;
            // 
            // simpleButtonViewMap3
            // 
            this.simpleButtonViewMap3.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonViewMap3.Enabled = false;
            this.simpleButtonViewMap3.ImageIndex = 10;
            this.simpleButtonViewMap3.ImageList = this.imageCollection1;
            this.simpleButtonViewMap3.Location = new System.Drawing.Point(280, 5);
            this.simpleButtonViewMap3.Name = "simpleButtonViewMap3";
            this.simpleButtonViewMap3.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonViewMap3.TabIndex = 77;
            this.simpleButtonViewMap3.Text = "查看";
            this.simpleButtonViewMap3.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 10;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(366, 26);
            this.label9.TabIndex = 84;
            this.label9.Text = "     详细信息列表";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlCatalog
            // 
            this.groupControlCatalog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlCatalog.Controls.Add(this.tListCatalog);
            this.groupControlCatalog.Controls.Add(this.labelCatalog);
            this.groupControlCatalog.Controls.Add(this.panel5);
            this.groupControlCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlCatalog.Location = new System.Drawing.Point(0, 0);
            this.groupControlCatalog.Name = "groupControlCatalog";
            this.groupControlCatalog.Padding = new System.Windows.Forms.Padding(9, 5, 9, 0);
            this.groupControlCatalog.ShowCaption = false;
            this.groupControlCatalog.Size = new System.Drawing.Size(384, 257);
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
            this.tListCatalog.Location = new System.Drawing.Point(9, 36);
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
            this.tListCatalog.Size = new System.Drawing.Size(366, 179);
            this.tListCatalog.StateImageList = this.imageCollection1;
            this.tListCatalog.TabIndex = 0;
            this.tListCatalog.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.tListCatalog_AfterExpand);
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
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 1;
            // 
            // labelCatalog
            // 
            this.labelCatalog.BackColor = System.Drawing.Color.Transparent;
            this.labelCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCatalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCatalog.ImageIndex = 6;
            this.labelCatalog.ImageList = this.imageList1;
            this.labelCatalog.Location = new System.Drawing.Point(9, 5);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(366, 31);
            this.labelCatalog.TabIndex = 83;
            this.labelCatalog.Text = "     数据目录";
            this.labelCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panel5.Location = new System.Drawing.Point(9, 215);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(7, 9, 0, 7);
            this.panel5.Size = new System.Drawing.Size(366, 42);
            this.panel5.TabIndex = 79;
            // 
            // buttonPath
            // 
            this.buttonPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPath.Enabled = false;
            this.buttonPath.Location = new System.Drawing.Point(64, 9);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonPath.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "指定路径", null, null, false)});
            this.buttonPath.Size = new System.Drawing.Size(253, 20);
            this.buttonPath.TabIndex = 76;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(317, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(7, 26);
            this.panel6.TabIndex = 82;
            this.panel6.Visible = false;
            // 
            // simpleButtonRefrash
            // 
            this.simpleButtonRefrash.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRefrash.Location = new System.Drawing.Point(324, 9);
            this.simpleButtonRefrash.Name = "simpleButtonRefrash";
            this.simpleButtonRefrash.Size = new System.Drawing.Size(42, 26);
            this.simpleButtonRefrash.TabIndex = 81;
            this.simpleButtonRefrash.Text = "刷新";
            this.simpleButtonRefrash.Visible = false;
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
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 74;
            this.label6.Text = "    路径";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonEdit1);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Controls.Add(this.textEdit1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(9, 1102);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7, 9, 7, 7);
            this.panel1.Size = new System.Drawing.Size(384, 42);
            this.panel1.TabIndex = 89;
            this.panel1.Visible = false;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit1.Enabled = false;
            this.buttonEdit1.Location = new System.Drawing.Point(93, 9);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "指定路径", null, null, false)});
            this.buttonEdit1.Size = new System.Drawing.Size(235, 20);
            this.buttonEdit1.TabIndex = 76;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(328, 9);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(7, 26);
            this.panel10.TabIndex = 82;
            this.panel10.Visible = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton3.Location = new System.Drawing.Point(335, 9);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(42, 26);
            this.simpleButton3.TabIndex = 81;
            this.simpleButton3.Text = "刷新";
            this.simpleButton3.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(710, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(183, 20);
            this.textEdit1.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 26);
            this.label5.TabIndex = 74;
            this.label5.Text = "    备份路径";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.buttonEdit2);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.simpleButton4);
            this.panel11.Controls.Add(this.textEdit2);
            this.panel11.Controls.Add(this.label7);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Enabled = false;
            this.panel11.Location = new System.Drawing.Point(9, 1144);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(7, 9, 7, 7);
            this.panel11.Size = new System.Drawing.Size(384, 42);
            this.panel11.TabIndex = 90;
            this.panel11.Visible = false;
            // 
            // buttonEdit2
            // 
            this.buttonEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit2.Enabled = false;
            this.buttonEdit2.Location = new System.Drawing.Point(93, 9);
            this.buttonEdit2.Name = "buttonEdit2";
            this.buttonEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "指定路径", null, null, false)});
            this.buttonEdit2.Size = new System.Drawing.Size(235, 20);
            this.buttonEdit2.TabIndex = 76;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(328, 9);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(7, 26);
            this.panel12.TabIndex = 82;
            this.panel12.Visible = false;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton4.Location = new System.Drawing.Point(335, 9);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(42, 26);
            this.simpleButton4.TabIndex = 81;
            this.simpleButton4.Text = "刷新";
            this.simpleButton4.Visible = false;
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(710, 8);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(183, 20);
            this.textEdit2.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.ImageIndex = 26;
            this.label7.ImageList = this.imageList1;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 26);
            this.label7.TabIndex = 74;
            this.label7.Text = "    文件名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel4.Controls.Add(this.simpleButtonRestore2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.simpleButtonBackup2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.simpleButton2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(9, 1186);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel4.Size = new System.Drawing.Size(384, 40);
            this.panel4.TabIndex = 80;
            // 
            // simpleButtonRestore2
            // 
            this.simpleButtonRestore2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRestore2.Enabled = false;
            this.simpleButtonRestore2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRestore2.Image")));
            this.simpleButtonRestore2.Location = new System.Drawing.Point(112, 5);
            this.simpleButtonRestore2.Name = "simpleButtonRestore2";
            this.simpleButtonRestore2.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonRestore2.TabIndex = 22;
            this.simpleButtonRestore2.Text = "恢复";
            this.simpleButtonRestore2.ToolTip = "数据恢复";
            this.simpleButtonRestore2.Visible = false;
            this.simpleButtonRestore2.Click += new System.EventHandler(this.simpleButtonRestore2_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(198, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(7, 30);
            this.label2.TabIndex = 15;
            // 
            // simpleButtonBackup2
            // 
            this.simpleButtonBackup2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBackup2.Enabled = false;
            this.simpleButtonBackup2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBackup2.Image")));
            this.simpleButtonBackup2.Location = new System.Drawing.Point(205, 5);
            this.simpleButtonBackup2.Name = "simpleButtonBackup2";
            this.simpleButtonBackup2.Size = new System.Drawing.Size(86, 30);
            this.simpleButtonBackup2.TabIndex = 1;
            this.simpleButtonBackup2.Text = "备份";
            this.simpleButtonBackup2.ToolTip = "备份数据";
            this.simpleButtonBackup2.Click += new System.EventHandler(this.simpleButtonBackup2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(291, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(7, 30);
            this.label3.TabIndex = 20;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(298, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(86, 30);
            this.simpleButton2.TabIndex = 19;
            this.simpleButton2.Text = "重置";
            this.simpleButton2.ToolTip = "重新选择";
            this.simpleButton2.Visible = false;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup2;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4,
            this.navBarGroup5,
            this.navBarGroup6,
            this.navBarGroup7,
            this.navBarGroup8});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7,
            this.navBarItem8,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12,
            this.navBarItem13,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem16,
            this.navBarItem17,
            this.navBarItem18});
            this.navBarControl1.LargeImages = this.imageList2;
            this.navBarControl1.Location = new System.Drawing.Point(9, 29);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.NavigationPaneMaxVisibleGroups = 0;
            this.navBarControl1.NavigationPaneOverflowPanelUseSmallImages = false;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 384;
            this.navBarControl1.Size = new System.Drawing.Size(384, 115);
            this.navBarControl1.SmallImages = this.imageList1;
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 81;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.Visible = false;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "基础地理数据";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem7)});
            this.navBarGroup2.LargeImageIndex = 12;
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImageIndex = 12;
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "地名";
            this.navBarItem4.LargeImageIndex = 46;
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.SmallImageIndex = 41;
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "行政区划";
            this.navBarItem5.LargeImageIndex = 47;
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.SmallImageIndex = 41;
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "道路";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.SmallImageIndex = 41;
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "水系";
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.SmallImageIndex = 41;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "作业设计数据";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)});
            this.navBarGroup1.LargeImageIndex = 32;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImageIndex = 32;
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "2011年造林作业设计";
            this.navBarItem1.LargeImageIndex = 19;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImageIndex = 1;
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "2009年造林作业设计";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImageIndex = 0;
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_LinkClicked);
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "作业设计模板";
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.SmallImageIndex = 0;
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "二类资源数据";
            this.navBarGroup3.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem9),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem8)});
            this.navBarGroup3.LargeImageIndex = 29;
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarGroup3.SmallImageIndex = 29;
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "小班";
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.SmallImageIndex = 0;
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "林班";
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.SmallImageIndex = 0;
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "地形图数据";
            this.navBarGroup4.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10)});
            this.navBarGroup4.LargeImageIndex = 27;
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarGroup4.SmallImageIndex = 27;
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "1:5万扫描图";
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.SmallImageIndex = 41;
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "影像数据";
            this.navBarGroup5.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup5.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup5.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem11)});
            this.navBarGroup5.LargeImageIndex = 38;
            this.navBarGroup5.Name = "navBarGroup5";
            this.navBarGroup5.SmallImageIndex = 38;
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "航片";
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.SmallImageIndex = 41;
            // 
            // navBarGroup6
            // 
            this.navBarGroup6.Caption = "数字高程";
            this.navBarGroup6.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup6.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup6.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem13)});
            this.navBarGroup6.LargeImageIndex = 39;
            this.navBarGroup6.Name = "navBarGroup6";
            this.navBarGroup6.SmallImageIndex = 39;
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "25万数字高程";
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.SmallImageIndex = 0;
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "山地阴影";
            this.navBarItem13.Name = "navBarItem13";
            this.navBarItem13.SmallImageIndex = 0;
            // 
            // navBarGroup7
            // 
            this.navBarGroup7.Caption = "字典表";
            this.navBarGroup7.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup7.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem14)});
            this.navBarGroup7.LargeImageIndex = 43;
            this.navBarGroup7.Name = "navBarGroup7";
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "代码表";
            this.navBarItem14.Name = "navBarItem14";
            this.navBarItem14.SmallImageIndex = 1;
            // 
            // navBarGroup8
            // 
            this.navBarGroup8.Caption = "系统数据";
            this.navBarGroup8.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem17),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem16),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem18),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem15)});
            this.navBarGroup8.LargeImageIndex = 0;
            this.navBarGroup8.Name = "navBarGroup8";
            // 
            // navBarItem17
            // 
            this.navBarItem17.Caption = "系统字典表";
            this.navBarItem17.Name = "navBarItem17";
            this.navBarItem17.SmallImageIndex = 1;
            // 
            // navBarItem16
            // 
            this.navBarItem16.Caption = "系统用户表";
            this.navBarItem16.Name = "navBarItem16";
            this.navBarItem16.SmallImageIndex = 0;
            // 
            // navBarItem18
            // 
            this.navBarItem18.Caption = "系统日志表";
            this.navBarItem18.Name = "navBarItem18";
            this.navBarItem18.SmallImageIndex = 0;
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "作业设计记录";
            this.navBarItem15.Name = "navBarItem15";
            this.navBarItem15.SmallImageIndex = 0;
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
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "start_checkbox_normal.png");
            this.imageList4.Images.SetKeyName(1, "start_checkbox_checked.png");
            // 
            // UserControlBackRestore
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelSet);
            this.Controls.Add(this.panelAuto);
            this.Name = "UserControlBackRestore";
            this.Padding = new System.Windows.Forms.Padding(9, 0, 9, 9);
            this.Size = new System.Drawing.Size(420, 1937);
            this.panelAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListLayers)).EndInit();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelResList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iListFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListFiles)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.panelSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panelResult2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListLayers2)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iListFile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNOList)).EndInit();
            this.groupControlNOList.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListno)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCatalog)).EndInit();
            this.groupControlCatalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNo.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialLayerlist()
        {
            try
            {
                if (this.iListFile2.SelectedIndex == -1)
                {
                    this.simpleButtonRestore2.Enabled = false;
                }
                else
                {
                    this.mDatasetList = new ArrayList();
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    this.tListLayers2.Nodes.Clear();
                    this.tListLayers2.Columns[0].Width = this.tListLayers.Width - 10;
                    this.tListLayers2.OptionsView.ShowRoot = true;
                    this.tListLayers2.SelectImageList = null;
                    this.tListLayers2.StateImageList = this.imageList1;
                    this.tListLayers2.OptionsView.ShowButtons = true;
                    this.tListLayers2.TreeLineStyle = LineStyle.None;
                    this.tListLayers2.RowHeight = 20;
                    this.tListLayers2.OptionsBehavior.AutoPopulateColumns = true;
                    this.tListLayers2.OptionsView.AutoWidth = true;
                    this.tListLayers2.OptionsBehavior.Editable = false;
                    if (this.mWorkspaceList2[this.iListFile2.SelectedIndex] is IFeatureWorkspace)
                    {
                        IFeatureWorkspace workspace = this.mWorkspaceList2[this.iListFile2.SelectedIndex] as IFeatureWorkspace;
                        IDataset dataset = workspace as IDataset;
                        IEnumDataset subsets = dataset.Subsets;
                        IDataset dataset3 = subsets.Next();
                        if (dataset3 == null)
                        {
                        }
                        while (dataset3 != null)
                        {
                            IFeatureClass class2;
                            if (dataset3 is IFeatureClass)
                            {
                                class2 = dataset3 as IFeatureClass;
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
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
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
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
                                        node = this.tListLayers2.AppendNode(dataset3.Name, parentNode);
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
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as ITable;
                                parentNode.StateImageIndex = 0x22;
                                this.mDatasetList.Add(dataset3 as ITable);
                            }
                            else if (dataset3 is IRasterDataset)
                            {
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as IRasterDataset;
                                parentNode.StateImageIndex = 7;
                                this.mDatasetList.Add(dataset3 as IRasterDataset);
                            }
                            else if (dataset3 is IRasterCatalog)
                            {
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as IRasterCatalog;
                                parentNode.StateImageIndex = 7;
                                this.mDatasetList.Add(dataset3 as IRasterCatalog);
                            }
                            else
                            {
                                parentNode = this.tListLayers2.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3;
                                parentNode.StateImageIndex = 0x21;
                            }
                            dataset3 = subsets.Next();
                        }
                        this.simpleButtonRestore2.Enabled = true;
                        this.simpleButtonViewMap2.Enabled = true;
                    }
                    else if (!(this.mWorkspaceList[this.iListFile2.SelectedIndex] is IRasterWorkspace) && (this.mWorkspaceList[this.iListFile2.SelectedIndex] is IFeatureClass))
                    {
                        IFeatureClass class3 = this.mWorkspaceList[this.iListFile.SelectedIndex] as IFeatureClass;
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
                        parentNode = this.tListLayers2.AppendNode(class3.AliasName, node3);
                        parentNode.SetValue(0, class3.AliasName);
                        parentNode.Tag = class3;
                        parentNode.StateImageIndex = num;
                        this.mDatasetList.Add(class3);
                        this.simpleButtonRestore2.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitialLayerlist2()
        {
            try
            {
                if (this.iListFile.SelectedIndex == -1)
                {
                    this.simpleButtonRestore.Enabled = false;
                }
                else
                {
                    this.mDatasetList = new ArrayList();
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    this.tListLayers.Nodes.Clear();
                    this.tListLayers.Columns[0].Width = this.tListLayers.Width - 10;
                    this.tListLayers.OptionsView.ShowRoot = true;
                    this.tListLayers.SelectImageList = null;
                    this.tListLayers.StateImageList = this.imageList1;
                    this.tListLayers.OptionsView.ShowButtons = true;
                    this.tListLayers.TreeLineStyle = LineStyle.None;
                    this.tListLayers.RowHeight = 20;
                    this.tListLayers.OptionsBehavior.AutoPopulateColumns = true;
                    this.tListLayers.OptionsView.AutoWidth = true;
                    this.tListLayers.OptionsBehavior.Editable = false;
                    if (this.mWorkspaceList[this.iListFile.SelectedIndex] is IFeatureWorkspace)
                    {
                        IFeatureWorkspace workspace = this.mWorkspaceList[this.iListFile.SelectedIndex] as IFeatureWorkspace;
                        IDataset dataset = workspace as IDataset;
                        IEnumDataset subsets = dataset.Subsets;
                        IDataset dataset3 = subsets.Next();
                        if (dataset3 == null)
                        {
                        }
                        while (dataset3 != null)
                        {
                            IFeatureClass class2;
                            if (dataset3 is IFeatureClass)
                            {
                                class2 = dataset3 as IFeatureClass;
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
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
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
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
                                        node = this.tListLayers.AppendNode(dataset3.Name, parentNode);
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
                                    else if (dataset5 is IRelationshipClass)
                                    {
                                        node = this.tListLayers.AppendNode(dataset5.Name, parentNode);
                                        node.SetValue(0, dataset5.Name);
                                        node.Tag = dataset5 as IRelationshipClass;
                                        node.StateImageIndex = 0x21;
                                        this.mDatasetList.Add(dataset5 as IRelationshipClass);
                                    }
                                }
                            }
                            else if (dataset3 is ITable)
                            {
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as ITable;
                                parentNode.StateImageIndex = 0x22;
                                this.mDatasetList.Add(dataset3 as ITable);
                            }
                            else if (dataset3 is IRasterDataset)
                            {
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as IRasterDataset;
                                parentNode.StateImageIndex = 7;
                                this.mDatasetList.Add(dataset3 as IRasterDataset);
                            }
                            else if (dataset3 is IRasterCatalog)
                            {
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as IRasterCatalog;
                                parentNode.StateImageIndex = 7;
                                this.mDatasetList.Add(dataset3 as IRasterCatalog);
                            }
                            else if (dataset3 is IRelationshipClass)
                            {
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3 as IRelationshipClass;
                                parentNode.StateImageIndex = 0x21;
                                this.mDatasetList.Add(dataset3 as IRelationshipClass);
                            }
                            else
                            {
                                parentNode = this.tListLayers.AppendNode(dataset3.Name, node3);
                                parentNode.SetValue(0, dataset3.Name);
                                parentNode.Tag = dataset3;
                                parentNode.StateImageIndex = 0x21;
                            }
                            dataset3 = subsets.Next();
                        }
                        this.simpleButtonRestore.Enabled = true;
                    }
                    else if (!(this.mWorkspaceList[this.iListFile.SelectedIndex] is IRasterWorkspace) && (this.mWorkspaceList[this.iListFile.SelectedIndex] is IFeatureClass))
                    {
                        IFeatureClass class3 = this.mWorkspaceList[this.iListFile.SelectedIndex] as IFeatureClass;
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
                        parentNode = this.tListLayers.AppendNode(class3.AliasName, node3);
                        parentNode.SetValue(0, class3.AliasName);
                        parentNode.Tag = class3;
                        parentNode.StateImageIndex = num;
                        this.mDatasetList.Add(class3);
                        this.simpleButtonRestore.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitialListFile()
        {
            try
            {
                string[] directories;
                int num;
                IFeatureWorkspace featureWorkspace;
                DateTime creationTime;
                string browseName;
                string[] strArray2;
                this.mSelected = true;
                this.cListFiles.Items.Clear();
                this.iListFile.Items.Clear();
                this.iListFile2.Items.Clear();
                this.simpleButtonViewList.Enabled = false;
                this.groupControl3.Visible = false;
                this.simpleButtonViewList.Text = "查看";
                this.mpanMap.Visible = false;
                this.mapViewTools.Visible = false;
                this.tListLayers.Nodes.Clear();
                this.simpleButtonViewMap.Enabled = false;
                this.mWorkspaceList = new ArrayList();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("BackupPath");
                this.mPathList = new ArrayList();
                if ((this.kind < 2) && (this.radioGroup.SelectedIndex == 0))
                {
                    this.mWorkspaceList = new ArrayList();
                    directories = Directory.GetDirectories(path);
                    for (num = 0; num < directories.Length; num++)
                    {
                        if (!directories[num].Contains(".gdb") || !directories[num].Contains(this.mEditKind2))
                        {
                            continue;
                        }
                        featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                        if (featureWorkspace != null)
                        {
                            this.mWorkspaceList.Add(featureWorkspace);
                            creationTime = Directory.GetCreationTime(directories[num]);
                            string introduced19 = creationTime.ToLongDateString();
                            browseName = introduced19 + creationTime.ToLongTimeString();
                            if ((this.mEditKind == "采伐") || (this.mEditKind == "造林"))
                            {
                                string str3 = "";
                                IDataset dataset = featureWorkspace as IDataset;
                                IEnumDataset subsets = dataset.Subsets;
                                for (IDataset dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
                                {
                                    if (dataset3 is IFeatureDataset)
                                    {
                                        strArray2 = dataset3.Name.Split(new char[] { '_' });
                                        str3 = strArray2[strArray2.Length - 1];
                                        break;
                                    }
                                }
                                this.cListFiles.Items.Add(browseName);
                                if (str3 != "")
                                {
                                    this.iListFile.Items.Add(browseName + "【" + str3 + "】年度作业设计", 14);
                                }
                                else
                                {
                                    this.iListFile.Items.Add(browseName, 14);
                                }
                            }
                            else
                            {
                                this.cListFiles.Items.Add(browseName);
                                this.iListFile.Items.Add(browseName, 14);
                            }
                            this.mPathList.Add(directories[num]);
                        }
                    }
                }
                else
                {
                    string str4;
                    string[] strArray3;
                    if ((this.kind < 2) && (this.radioGroup.SelectedIndex == 1))
                    {
                        this.mWorkspaceList = new ArrayList();
                        str4 = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath");
                        directories = UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath").ToString().Split(new char[] { '\\' });
                        strArray3 = directories[directories.Length - 1].Split(new char[] { '.' });
                        directories = Directory.GetFiles(path);
                        for (num = 0; num < directories.Length; num++)
                        {
                            if (directories[num].Contains(".mdb") && directories[num].Contains(strArray3[0]))
                            {
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSAccessWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    this.mWorkspaceList.Add(featureWorkspace);
                                    creationTime = File.GetCreationTime(directories[num]);
                                    string introduced20 = creationTime.ToLongDateString();
                                    browseName = introduced20 + creationTime.ToLongTimeString();
                                    this.cListFiles.Items.Add(browseName);
                                    this.iListFile.Items.Add(browseName, 0x1c);
                                    this.mPathList.Add(directories[num]);
                                }
                            }
                        }
                    }
                    else if ((this.kind < 2) && (this.radioGroup.SelectedIndex == 2))
                    {
                        this.mWorkspaceList = new ArrayList();
                        str4 = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                        directories = UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath").ToString().Split(new char[] { '\\' });
                        strArray3 = directories[directories.Length - 1].Split(new char[] { '.' });
                        directories = Directory.GetDirectories(path);
                        for (num = 0; num < directories.Length; num++)
                        {
                            if (directories[num].Contains(".gdb") && directories[num].Contains(strArray3[0]))
                            {
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    this.mWorkspaceList.Add(featureWorkspace);
                                    creationTime = Directory.GetCreationTime(directories[num]);
                                    string introduced21 = creationTime.ToLongDateString();
                                    browseName = introduced21 + creationTime.ToLongTimeString();
                                    this.cListFiles.Items.Add(browseName);
                                    this.iListFile.Items.Add(browseName, 0x1b);
                                    this.mPathList.Add(directories[num]);
                                }
                            }
                        }
                        directories = Directory.GetFiles(path);
                        for (num = 0; num < directories.Length; num++)
                        {
                            if (directories[num].Contains(".mdb") && directories[num].Contains(strArray3[0]))
                            {
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSAccessWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    this.mWorkspaceList.Add(featureWorkspace);
                                    creationTime = File.GetLastWriteTime(directories[num]);
                                    string introduced22 = creationTime.ToLongDateString();
                                    browseName = introduced22 + creationTime.ToLongTimeString();
                                    this.cListFiles.Items.Add(browseName);
                                    this.iListFile.Items.Add(browseName, 0x1b);
                                    this.mPathList.Add(directories[num]);
                                }
                            }
                        }
                    }
                    else if ((this.kind != 2) && (this.kind == 3))
                    {
                        this.mWorkspaceList2 = new ArrayList();
                        directories = Directory.GetDirectories(path);
                        for (num = 0; num < directories.Length; num++)
                        {
                            if (directories[num].Contains(".gdb"))
                            {
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    this.mWorkspaceList2.Add(featureWorkspace);
                                    creationTime = Directory.GetCreationTime(directories[num]);
                                    string introduced23 = creationTime.ToLongDateString();
                                    browseName = introduced23 + creationTime.ToLongTimeString();
                                    browseName = (featureWorkspace as IDataset).BrowseName;
                                    this.iListFile2.Items.Add(browseName, 11);
                                    this.mPathList.Add(directories[num]);
                                }
                            }
                        }
                        directories = Directory.GetFiles(path);
                        for (num = 0; num < directories.Length; num++)
                        {
                            if (directories[num].Contains(".mdb"))
                            {
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(directories[num], WorkspaceSource.esriWSAccessWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    this.mWorkspaceList2.Add(featureWorkspace);
                                    creationTime = File.GetCreationTime(directories[num]);
                                    string introduced24 = creationTime.ToLongDateString();
                                    browseName = introduced24 + creationTime.ToLongTimeString();
                                    browseName = (featureWorkspace as IDataset).BrowseName;
                                    this.iListFile2.Items.Add(browseName, 0x1c);
                                    this.mPathList.Add(directories[num]);
                                }
                            }
                            else if (directories[num].Contains(".shp"))
                            {
                                strArray2 = directories[num].Split(new char[] { '\\' });
                                string[] strArray4 = strArray2[strArray2.Length - 1].Split(new char[] { '.' });
                                featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(path, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                                if (featureWorkspace != null)
                                {
                                    try
                                    {
                                        IFeatureClass class2 = featureWorkspace.OpenFeatureClass(strArray4[0]);
                                        this.mWorkspaceList2.Add(class2);
                                        browseName = (class2 as IDataset).BrowseName;
                                        this.iListFile2.Items.Add(browseName, 0x1a);
                                        this.mPathList.Add(directories[num]);
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                if (this.iListFile.Visible)
                {
                    if (this.iListFile.ItemCount > 0)
                    {
                        this.iListFile.SelectedIndex = 0;
                        if (this.simpleButtonRestore.Visible)
                        {
                            this.simpleButtonRestore.Enabled = true;
                        }
                        this.simpleButtonViewList.Enabled = true;
                        this.InitialLayerlist2();
                        if (this.tListLayers.FocusedNode != null)
                        {
                            if (this.tListLayers.FocusedNode.Tag is IFeatureClass)
                            {
                                this.simpleButtonViewMap.Enabled = true;
                            }
                            else if (this.tListLayers.FocusedNode.Tag is ITable)
                            {
                                this.simpleButtonViewMap.Enabled = true;
                            }
                            else
                            {
                                this.simpleButtonViewMap.Enabled = false;
                            }
                        }
                        else
                        {
                            this.simpleButtonViewMap.Enabled = false;
                        }
                    }
                    else
                    {
                        this.simpleButtonRestore.Enabled = false;
                    }
                }
                else if (this.iListFile2.Visible)
                {
                }
                this.mSelected = false;
            }
            catch (Exception exception)
            {
                this.mSelected = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "InitialListFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue(int kind, string editkind, UserControlProgress pProgress, Panel panMap, object hook, GridControl gridControl, GridView gridView, RibbonPageGroup mapView)
        {
            try
            {
                this.mEditKind = editkind;
                this.mProgress = pProgress;
                this.mpanMap = panMap;
                this.mgridControl = gridControl;
                this.mgridView = gridView;
                this.mapViewTools = mapView;
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                }
                else if (this.mEditKind == "林改")
                {
                    this.mEditKind2 = "LinGai";
                }
                else if (this.mEditKind == "公益林")
                {
                    this.mEditKind2 = "GYL";
                }
                else if (this.mEditKind == "通用")
                {
                    this.mEditKind2 = "TY";
                }
                this.InitialControls(kind);
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                if (sSourceFile.Contains(".gdb") || sSourceFile.Contains(".GDB"))
                {
                    this.m_EditWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                }
                else if (sSourceFile.Contains(".mdb") || sSourceFile.Contains(".MDB"))
                {
                    this.m_EditWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSAccessWorkspaceFactory);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void navBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (e.Link.Item.SmallImageIndex == 0x29)
            {
                e.Link.Item.SmallImageIndex = 0x2b;
            }
            else
            {
                e.Link.Item.SmallImageIndex = 0x29;
            }
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.panelResList.Visible)
            {
                this.InitialListFile();
            }
            if (this.iListFile.ItemCount > 0)
            {
                this.simpleButtonViewList.Enabled = true;
                if (this.iListFile.SelectedIndex != -1)
                {
                    if (this.simpleButtonRestore.Visible)
                    {
                        this.simpleButtonRestore.Enabled = true;
                    }
                    this.simpleButtonViewList.Enabled = true;
                    this.InitialLayerlist2();
                    if (this.tListLayers.Nodes.Count > 0)
                    {
                        this.simpleButtonViewMap.Enabled = true;
                    }
                }
                else
                {
                    if (this.simpleButtonRestore.Visible)
                    {
                        this.simpleButtonRestore.Enabled = false;
                    }
                    this.simpleButtonViewList.Enabled = false;
                }
            }
            if (this.radioGroup.SelectedIndex == 1)
            {
                this.simpleButtonViewList.Enabled = false;
                this.mProgress.progressBarControl1.Visible = false;
            }
            else
            {
                this.mProgress.progressBarControl1.Visible = true;
            }
        }

        private void RendererLayer(IFeatureLayer featureLayer, string sKind)
        {
            try
            {
                IGeoFeatureLayer layer = (IGeoFeatureLayer) featureLayer;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(sKind + "FieldName");
                if (sKind == "GYL")
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue(sKind + "FieldName2");
                }
                string[] strArray = configValue.Split(new char[] { ',' });
                if (strArray.Length > 1)
                {
                    layer.DisplayField = strArray[strArray.Length - 1];
                }
                else
                {
                    layer.DisplayField = configValue;
                }
                ISimpleRenderer renderer = (ISimpleRenderer) layer.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = 0;
                color2.Blue = 0;
                color2.Green = 0xff;
                symbol3.Color = color2;
                symbol3.Width = 1.2;
                symbol2.Outline = symbol3;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Symbol = symbol;
                layer.Renderer = renderer2 as IFeatureRenderer;
                IAnnotateLayerPropertiesCollection annotationProperties = layer.AnnotationProperties;
                annotationProperties.Clear();
                ILineLabelPosition position = new LineLabelPositionClass();
                position.Parallel = false;
                position.Perpendicular = true;
                ILineLabelPlacementPriorities priorities = new LineLabelPlacementPrioritiesClass();
                IBasicOverposterLayerProperties properties2 = new BasicOverposterLayerPropertiesClass();
                properties2.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                properties2.LineLabelPlacementPriorities = priorities;
                properties2.LineLabelPosition = position;
                properties2.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
                ILabelEngineLayerProperties properties3 = new LabelEngineLayerPropertiesClass();
                properties3.BasicOverposterLayerProperties = properties2;
                properties3.Expression = "[" + featureLayer.DisplayField + "]";
                IAnnotateLayerProperties properties4 = properties3 as IAnnotateLayerProperties;
                properties4.AnnotationMinimumScale = 35000.0;
                ITextSymbol symbol4 = new TextSymbolClass();
                symbol4.Size = 12.0;
                IColor color3 = symbol4.Color;
                stdole.IFontDisp font = symbol4.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                IRgbColor color4 = new RgbColorClass();
                color4.Red = 0;
                color4.Blue = 0;
                color4.Green = 0xff;
                color3 = color4;
                symbol4.Color = color3;
                properties3.Symbol = symbol4;
                IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                annotationProperties.Add(item);
                layer.Renderer = renderer2 as IFeatureRenderer;
                IFeatureRenderer renderer3 = layer.Renderer;
                layer.DisplayAnnotation = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "RendererLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool RestoreAllData()
        {
            try
            {
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "RestoreAllData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool RestoreEditData()
        {
            try
            {
                Application.DoEvents();
                this.mProgress.labelTitle.Text = this.skind + "进度：恢复" + this.mEditKind + "编辑数据";
                this.mProgress.labelInfo.Text = "开始";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                this.groupControl3.Visible = false;
                this.simpleButtonViewList.Text = "查看";
                this.mpanMap.Visible = false;
                this.mapViewTools.Visible = false;
                IFeatureWorkspace workspace = this.mWorkspaceList[this.iListFile.SelectedIndex] as IFeatureWorkspace;
                IDataset dataset = workspace as IDataset;
                IEnumDataset subsets = dataset.Subsets;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Dataset");
                string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Table");
                string str4 = "";
                string str5 = "";
                if (str3.Contains(","))
                {
                    str4 = str3.Split(new char[] { ',' })[1];
                    str3 = str3.Split(new char[] { ',' })[0];
                }
                if (this.mEditKind == "采伐")
                {
                    str5 = "T_HAR_RELATE";
                }
                string str6 = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                IDataset dataset3 = subsets.Next();
                configValue = dataset3.Name;
                string[] strArray = configValue.Split(new char[] { '_' });
                string str7 = strArray[strArray.Length - 1];
                if (str7.Length != 4)
                {
                    str7 = "";
                }
                IDataset dataset4 = null;
                IFeatureClass class2 = null;
                this.mProgress.labelInfo.Text = "检查原有编辑数据";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n检查原有编辑数据";
                this.mProgress.progressBarControl1.Text = "5";
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "DatasetName2");
                if (str8 != "")
                {
                    try
                    {
                        IDataset dataset5 = this.m_EditWorkspace.OpenFeatureDataset(str8);
                        if (dataset5 != null)
                        {
                            IEnumDataset dataset6 = dataset5.Subsets;
                            for (IDataset dataset7 = dataset6.Next(); dataset7 != null; dataset7 = dataset6.Next())
                            {
                                if (dataset7.Name == (name + "_" + str7))
                                {
                                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n可恢复编辑数据已存在历史数据中，备份数据不可恢复！";
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                this.mProgress.labelInfo.Text = "删除原有编辑数据";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n删除编辑数据";
                this.mProgress.progressBarControl1.Text = "10";
                try
                {
                    dataset4 = this.m_EditWorkspace.OpenFeatureDataset(configValue);
                    if (dataset4 != null)
                    {
                        dataset4.Delete();
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (str7 != "")
                    {
                        class2 = this.m_EditWorkspace.OpenFeatureClass(name + "_" + str7);
                    }
                    else
                    {
                        class2 = this.m_EditWorkspace.OpenFeatureClass(name);
                    }
                    if (class2 != null)
                    {
                        (class2 as IDataset).Delete();
                    }
                }
                catch (Exception)
                {
                }
                ITable table = null;
                ITable table2 = null;
                ITable table3 = null;
                IRelationshipClass class3 = null;
                try
                {
                    if (str3 != "")
                    {
                        table = this.m_EditWorkspace.OpenTable(str3 + "_" + str7);
                    }
                    if (table != null)
                    {
                        (table as IDataset).Delete();
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (str4 != "")
                    {
                        table2 = this.m_EditWorkspace.OpenTable(str4 + "_" + str7);
                    }
                    if (table2 != null)
                    {
                        (table2 as IDataset).Delete();
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (str5 != "")
                    {
                        table3 = this.m_EditWorkspace.OpenTable(str5 + "_" + str7);
                        class3 = this.m_EditWorkspace.OpenRelationshipClass(str5.Replace("T_", "") + "_Relate_" + str7);
                    }
                    if (table3 != null)
                    {
                        (table3 as IDataset).Delete();
                    }
                }
                catch (Exception)
                {
                }
                if (class3 != null)
                {
                    (class3 as IDataset).Delete();
                }
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                this.mProgress.labelInfo.Text = "创建编辑数据集";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑数据集";
                IFeatureDataset dataset8 = this.m_EditWorkspace.CreateFeatureDataset(dataset3.Name, (dataset3 as IGeoDataset).SpatialReference);
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "30";
                IEnumDataset dataset9 = dataset3.Subsets;
                for (IDataset dataset10 = dataset9.Next(); dataset10 != null; dataset10 = dataset9.Next())
                {
                    if (dataset10 is IFeatureClass)
                    {
                        IFeatureClass class4 = dataset10 as IFeatureClass;
                        IGeoDataset dataset11 = class4 as IGeoDataset;
                        ITable table4 = null;
                        if (str3 != "")
                        {
                            if (str7 != "")
                            {
                                table4 = workspace.OpenTable(str3 + "_" + str7);
                            }
                            else
                            {
                                table4 = workspace.OpenTable(str3);
                            }
                        }
                        ITable table5 = null;
                        ITable table6 = null;
                        try
                        {
                            if (str4 != "")
                            {
                                if (str7 != "")
                                {
                                    table5 = workspace.OpenTable(str4 + "_" + str7);
                                }
                                else
                                {
                                    table5 = workspace.OpenTable(str4);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            if (str5 != "")
                            {
                                if (str7 != "")
                                {
                                    table6 = workspace.OpenTable(str5 + "_" + str7);
                                }
                                else
                                {
                                    table6 = workspace.OpenTable(str5);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        IFeatureClassDescription description = new FeatureClassDescriptionClass();
                        IObjectClassDescription description2 = (IObjectClassDescription) description;
                        ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                        geoprocessor.OverwriteOutput = true;
                        this.mProgress.labelInfo.Text = "创建编辑图层";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑图层";
                        this.mProgress.progressBarControl1.Text = "40";
                        string str9 = str6 + @"\" + dataset8.Name + @"\" + dataset10.Name;
                        object obj2 = null;
                        try
                        {
                            ESRI.ArcGIS.AnalysisTools.Select process = new ESRI.ArcGIS.AnalysisTools.Select();
                            process.in_features = class4;
                            process.out_feature_class = str9;
                            process.where_clause = "";
                            obj2 = geoprocessor.Execute(process, null);
                        }
                        catch (Exception)
                        {
                        }
                        IFeatureClass class5 = dataset8.Subsets.Next() as IFeatureClass;
                        if (class5 != null)
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        }
                        else
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                        }
                        string messages = "";
                        object severity = null;
                        messages = geoprocessor.GetMessages(ref severity);
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                        this.mProgress.progressBarControl1.Text = "60";
                        if (table4 != null)
                        {
                            this.mProgress.labelInfo.Text = "创建属性表";
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建属性表";
                            TableSelect select2 = new TableSelect();
                            select2.in_table = table4;
                            str9 = str6 + @"\" + str3 + "_" + str7;
                            select2.out_table = str9;
                            obj2 = geoprocessor.Execute(select2, null);
                            if (table5 != null)
                            {
                                select2 = new TableSelect();
                                select2.in_table = table5;
                                str9 = str6 + @"\" + str4 + "_" + str7;
                                select2.out_table = str9;
                                obj2 = geoprocessor.Execute(select2, null);
                            }
                            if (table6 != null)
                            {
                                select2 = new TableSelect();
                                select2.in_table = table6;
                                str9 = str6 + @"\" + str5 + "_" + str7;
                                select2.out_table = str9;
                                obj2 = geoprocessor.Execute(select2, null);
                            }
                            table = this.m_EditWorkspace.OpenTable(str3 + "_" + str7);
                            if (table5 != null)
                            {
                                table2 = this.m_EditWorkspace.OpenTable(str4 + "_" + str7);
                            }
                            if (table6 != null)
                            {
                                table3 = this.m_EditWorkspace.OpenTable(str5 + "_" + str7);
                            }
                            if (table != null)
                            {
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                            }
                            else
                            {
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                            }
                            messages = "";
                            severity = null;
                            messages = geoprocessor.GetMessages(ref severity);
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                        }
                        this.mProgress.progressBarControl1.Text = "80";
                        if ((this.mEditKind == "造林") || (this.mEditKind == "采伐"))
                        {
                            if (table != null)
                            {
                                this.mProgress.labelInfo.Text = "创建关联";
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建关联";
                                UID uid = new UIDClass();
                                uid.Value = "esriGeoDatabase.Object";
                                IRelationshipClassContainer container = (IRelationshipClassContainer) dataset8;
                                IObjectClass originClass = class5 as IObjectClass;
                                IObjectClass destinationClass = table as IObjectClass;
                                IObjectClass class8 = null;
                                IObjectClass class9 = null;
                                if (table2 != null)
                                {
                                    class8 = table2 as IObjectClass;
                                }
                                if (table3 != null)
                                {
                                    class9 = table3 as IObjectClass;
                                }
                                string relClassName = (table as IDataset).Name.Replace("T_", "").Replace("_" + str7, "") + "_Relation_" + str7;
                                IRelationshipClass class10 = container.CreateRelationshipClass(relClassName, originClass, destinationClass, (table as IDataset).Name, (class5 as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "UUID", "", "UUID", "");
                                IRelationshipClass class11 = null;
                                IRelationshipClass class12 = null;
                                if (class8 != null)
                                {
                                    relClassName = (table2 as IDataset).Name.Replace("T_", "").Replace("_" + str7, "") + "_Relation_" + str7;
                                    class11 = container.CreateRelationshipClass(relClassName, originClass, class8, (table2 as IDataset).Name, (class5 as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "UUID", "", "UUID", "");
                                }
                                if (class9 != null)
                                {
                                    relClassName = (table3 as IDataset).Name.Replace("T_", "").Replace("_" + str7, "") + "_Relation_" + str7;
                                    class12 = this.m_EditWorkspace.CreateRelationshipClass(relClassName, destinationClass, class9, (table3 as IDataset).Name, (table as IDataset).Name, esriRelCardinality.esriRelCardinalityOneToMany, esriRelNotification.esriRelNotificationNone, false, false, null, "Tree_ID", "", "Tree_ID", "");
                                }
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                                this.mProgress.progressBarControl1.Text = "90";
                            }
                            this.mProgress.labelInfo.Text = "恢复作业设计记录";
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n恢复作业设计记录";
                            ITable table7 = workspace.OpenTable("T_EditTask");
                        //    IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                            DataTable dataTable = null;// TaskManageClass.GetDataTable(dBAccess, "SELECT * FROM T_EditTask where taskyear='" + str7 + "'");
                            int num = table7.RowCount(null);
                            ICursor cursor = table7.Search(null, false);
                            int index = table7.Fields.FindField("ID");
                            for (int i = 0; i < num; i++)
                            {
                                string str12;
                                int num4;
                                string str13;
                                IRow row = cursor.NextRow();
                                if (dataTable.Select("ID=" + row.get_Value(index).ToString()).Length == 0)
                                {
                                    str12 = "INSERT INTO " + str3 + "(id,taskname,taskkind,distcode,taskstate,taskyear,createtime,edittime,datasetname,layername,tablename)";
                                    num4 = -1;
                                    num4 = row.Fields.FindField("ID");
                                    str13 = row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("taskname");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("taskkind");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("distcode");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("taskstate");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("taskyear");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("createtime");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("edittime");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("datasetname");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    num4 = row.Fields.FindField("tablename");
                                    str13 = str13 + "," + row.get_Value(num4).ToString();
                                    str12 = str12 + " VALUES(" + str13 + ")";
                                  //  dBAccess.ExecuteScalar(str12);
                                }
                                else
                                {
                                    num4 = -1;
                                    str13 = "";
                                    num4 = row.Fields.FindField("taskname");
                                    str13 = "taskname='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("taskkind");
                                    str13 = str13 + " , taskkind='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("distcode");
                                    str13 = str13 + " , distcode='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("taskstate");
                                    str13 = str13 + " , taskstate='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("taskyear");
                                    str13 = str13 + " , taskyear='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("createtime");
                                    str13 = str13 + " , createtime='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("edittime");
                                    str13 = str13 + " , edittime='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("datasetname");
                                    str13 = str13 + " , datasetname='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("tablename");
                                    str13 = str13 + " , tablename='" + row.get_Value(num4).ToString() + "'";
                                    num4 = row.Fields.FindField("ID");
                                    str12 = "update T_EditTask set " + str13 + " where ID= " + row.get_Value(num4).ToString();
                                 //   dBAccess.ExecuteScalar(str12);
                                }
                            }
                        }
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        this.mProgress.progressBarControl1.Text = "100";
                        break;
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "RestoreEditData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool RestoreMapData()
        {
            try
            {
                IDataset dataset3;
                this.mProgress.labelTitle.Text = this.skind + "进度：恢复数据";
                this.mProgress.labelInfo.Text = "开始";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = true;
                this.mProgress.progressBarControl1.Text = "0";
                this.mProgress.Refresh();
                IFeatureWorkspace workspace = this.mWorkspaceList2[this.iListFile2.SelectedIndex] as IFeatureWorkspace;
                IDataset dataset = workspace as IDataset;
                IEnumDataset subsets = dataset.Subsets;
                this.mProgress.labelInfo.Text = "删除原有数据";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n删除原有数据";
                this.mProgress.progressBarControl1.Text = "10";
                for (dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
                {
                    if (dataset3 is IFeatureDataset)
                    {
                        try
                        {
                            IFeatureDataset dataset4 = this.m_EditWorkspace.OpenFeatureDataset(dataset3.Name);
                            if (dataset4 != null)
                            {
                                dataset4.Delete();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else if (dataset3 is IFeatureClass)
                    {
                        try
                        {
                            IWorkspace editWorkspace = this.m_EditWorkspace as IWorkspace;
                            IFeatureClass class2 = this.m_EditWorkspace.OpenFeatureClass(dataset3.Name);
                            if (class2 != null)
                            {
                                (class2 as IDataset).Delete();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else if (dataset3 is ITable)
                    {
                        try
                        {
                            ITable table = this.m_EditWorkspace.OpenTable(dataset3.Name);
                            if (table != null)
                            {
                                (table as IDataset).Delete();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                this.mProgress.progressBarControl1.Text = "20";
                subsets.Reset();
                dataset3 = subsets.Next();
                this.mProgress.labelInfo.Text = "创建数据";
                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建数据";
                string pathName = "";
                if (this.m_EditWorkspace == null)
                {
                    pathName = this.tListCatalog.Selection[0].Tag.ToString();
                    IWorkspaceFactory2 factory = new FileGDBWorkspaceFactoryClass();
                    IWorkspaceName name = factory.Create(pathName + @"\", dataset.BrowseName + "_bak.gdb", null, 0);
                    this.m_EditWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(name.PathName, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                }
                else
                {
                    pathName = (this.m_EditWorkspace as IWorkspace).PathName;
                }
                int num = 10;
                while (dataset3 != null)
                {
                    IFeatureClass class3;
                    IGeoDataset dataset8;
                    IFeatureClassDescription description;
                    IObjectClassDescription description2;
                    ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor;
                    ESRI.ArcGIS.AnalysisTools.Select select;
                    string str2;
                    object obj2;
                    string messages;
                    object obj3;
                    if (dataset3 is IFeatureDataset)
                    {
                        this.mProgress.labelInfo.Text = "创建编辑数据集";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建编辑数据集";
                        IFeatureDataset dataset5 = this.m_EditWorkspace.CreateFeatureDataset(dataset3.Name, (dataset3 as IGeoDataset).SpatialReference);
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        this.mProgress.progressBarControl1.Text = "30";
                        IEnumDataset dataset6 = dataset3.Subsets;
                        for (IDataset dataset7 = dataset6.Next(); dataset7 != null; dataset7 = dataset6.Next())
                        {
                            if (dataset7 is IFeatureClass)
                            {
                                class3 = dataset7 as IFeatureClass;
                                dataset8 = class3 as IGeoDataset;
                                description = new FeatureClassDescriptionClass();
                                description2 = (IObjectClassDescription) description;
                                geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                                geoprocessor.OverwriteOutput = true;
                                this.mProgress.labelInfo.Text = "创建" + class3.AliasName + "图层";
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建" + class3.AliasName + "图层";
                                this.mProgress.progressBarControl1.Text = "40";
                                select = new ESRI.ArcGIS.AnalysisTools.Select();
                                select.in_features = class3;
                                str2 = pathName + @"\" + dataset5.Name + @"\" + dataset7.Name;
                                select.out_feature_class = str2;
                                select.where_clause = "";
                                obj2 = geoprocessor.Execute(select, null);
                                IFeatureClass class4 = dataset5.Subsets.Next() as IFeatureClass;
                                if (class4 != null)
                                {
                                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                                }
                                else
                                {
                                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                                }
                                messages = "";
                                obj3 = null;
                                messages = geoprocessor.GetMessages(ref obj3);
                                this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                                int num2 = int.Parse(this.mProgress.progressBarControl1.Text) + num;
                                this.mProgress.progressBarControl1.Text = num2.ToString();
                            }
                        }
                    }
                    else if (dataset3 is IFeatureClass)
                    {
                        class3 = dataset3 as IFeatureClass;
                        dataset8 = class3 as IGeoDataset;
                        description = new FeatureClassDescriptionClass();
                        description2 = (IObjectClassDescription) description;
                        geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                        geoprocessor.OverwriteOutput = true;
                        this.mProgress.labelInfo.Text = "创建" + class3.AliasName + "图层";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n创建" + class3.AliasName + "图层";
                        this.mProgress.progressBarControl1.Text = "40";
                        select = new ESRI.ArcGIS.AnalysisTools.Select();
                        select.in_features = class3;
                        str2 = pathName + @"\" + dataset3.Name;
                        select.out_feature_class = str2;
                        select.where_clause = "";
                        obj2 = geoprocessor.Execute(select, null);
                        if (this.m_EditWorkspace.OpenFeatureClass(class3.AliasName) != null)
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        }
                        else
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                        }
                        messages = "";
                        obj3 = null;
                        messages = geoprocessor.GetMessages(ref obj3);
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                        this.mProgress.progressBarControl1.Text = "60";
                    }
                    else if (dataset3 is ITable)
                    {
                        geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                        geoprocessor.OverwriteOutput = true;
                        this.mProgress.labelInfo.Text = "创建" + dataset3.Name + "属性表";
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + dataset3.Name + "属性表";
                        this.mProgress.progressBarControl1.Text = (int.Parse(this.mProgress.progressBarControl1.Text) + 10).ToString();
                        ITable table2 = dataset3 as ITable;
                        TableSelect process = new TableSelect();
                        process.in_table = table2;
                        str2 = pathName + @"\" + dataset3.Name;
                        process.out_table = str2;
                        obj2 = geoprocessor.Execute(process, null);
                        if (this.m_EditWorkspace.OpenTable(dataset3.Name) != null)
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        }
                        else
                        {
                            this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                        }
                        messages = "";
                        obj3 = null;
                        messages = geoprocessor.GetMessages(ref obj3);
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n" + messages;
                        this.mProgress.progressBarControl1.Text = "80";
                    }
                    dataset3 = subsets.Next();
                }
                this.mProgress.progressBarControl1.Text = "100";
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "RestoreMapData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool RestoreSystemData()
        {
            try
            {
                this.mProgress.labelTitle.Text = this.skind + "进度：恢复系统数据";
                this.mProgress.labelInfo.Text = "开始";
                this.mProgress.richTextBox.Text = "";
                this.mProgress.progressBarControl1.Visible = false;
                this.mProgress.Refresh();
                string path = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath");
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("DBLocalPath").ToString().Split(new char[] { '\\' });
                string[] strArray2 = strArray[strArray.Length - 1].Split(new char[] { '.' });
                string sourceFileName = this.mPathList[this.iListFile.SelectedIndex].ToString();
                if (File.Exists(path))
                {
                    this.mProgress.richTextBox.Text = "删除原系统数据库";
                    IDbConnection connection = null;// UtilFactory.GetDBAccess("Access").Connection;
                    if ((connection != null) && ((connection.State != ConnectionState.Closed) | (connection.State != ConnectionState.Broken)))
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception)
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n失败";
                        return false;
                    }
                    if (File.Exists(path))
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n失败";
                        return false;
                    }
                }
                if (!File.Exists(path))
                {
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "\n复制系统数据库";
                    File.Copy(sourceFileName, path);
                    if (File.Exists(path))
                    {
                        this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——成功";
                        return true;
                    }
                    this.mProgress.richTextBox.Text = this.mProgress.richTextBox.Text + "  ——失败";
                    return false;
                }
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "RestoreSystemData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            this.mpanMap.Visible = true;
            this.mpanMap.BringToFront();
            this.AddLayer(this.treeListno);
        }

        private void simpleButtonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                this.mProgress.Visible = true;
                this.mProgress.BringToFront();
                bool flag = false;
                if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("编辑数据"))
                {
                    this.mProgress.labelTitle.Text = this.skind + "进度：" + this.mEditKind + "编辑数据备份";
                    flag = this.BackupEditData();
                }
                else if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("系统数据"))
                {
                    this.mProgress.labelTitle.Text = this.skind + "进度：" + this.mEditKind + "系统数据备份";
                    flag = this.BackupSystemData();
                }
                else if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("全部数据"))
                {
                    this.mProgress.labelTitle.Text = this.skind + "进度：" + this.mEditKind + "全部数据备份";
                    flag = this.BackupAllData();
                }
                if (flag)
                {
                    if (this.panelResList.Visible)
                    {
                        this.InitialListFile();
                    }
                    if (this.iListFile.ItemCount > 0)
                    {
                        this.simpleButtonViewList.Enabled = true;
                        if (this.iListFile.SelectedIndex != -1)
                        {
                            if (this.simpleButtonRestore.Visible)
                            {
                                this.simpleButtonRestore.Enabled = true;
                            }
                            this.simpleButtonViewList.Enabled = true;
                            this.InitialLayerlist2();
                            if (this.tListLayers.Nodes.Count > 0)
                            {
                                this.simpleButtonViewMap.Enabled = true;
                            }
                        }
                        else
                        {
                            if (this.simpleButtonRestore.Visible)
                            {
                                this.simpleButtonRestore.Enabled = false;
                            }
                            this.simpleButtonViewList.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "simpleButtonBackup_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonBackup2_Click(object sender, EventArgs e)
        {
            if ((this.treeListno.Nodes.Count > 0) && (this.treeListno.Selection.Count > 0))
            {
                this.mpanMap.Visible = false;
                this.mapViewTools.Visible = false;
                IDataset tag = this.treeListno.Selection[0].Tag as IDataset;
                if (tag is IFeatureDataset)
                {
                    this.BackupFeatureDataset(tag as IFeatureDataset);
                }
                else if (tag is IFeatureClass)
                {
                    this.BackupFeatureClass(tag as IFeatureClass);
                }
                else if (tag is ITable)
                {
                    this.BackupTable(tag as ITable);
                }
            }
        }

        private void simpleButtonRestore_Click(object sender, EventArgs e)
        {
            if (this.mpanMap.Visible)
            {
                this.mpanMap.Visible = false;
            }
            if (this.mapViewTools.Visible)
            {
                this.mapViewTools.Visible = false;
            }
            if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("编辑数据"))
            {
                this.RestoreEditData();
            }
            else if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("系统数据"))
            {
                this.RestoreSystemData();
            }
            else if (this.radioGroup.Properties.Items[this.radioGroup.SelectedIndex].Description.Contains("全部数据"))
            {
                this.RestoreAllData();
            }
        }

        private void simpleButtonRestore2_Click(object sender, EventArgs e)
        {
            if ((this.iListFile2.SelectedIndex != -1) && (this.tListCatalog.FocusedNode != null))
            {
                this.mpanMap.Visible = false;
                this.mapViewTools.Visible = false;
                this.RestoreMapData();
            }
        }

        private void simpleButtonViewList_Click(object sender, EventArgs e)
        {
            if (this.simpleButtonViewList.Text == "查看")
            {
                this.groupControl3.Visible = true;
                this.simpleButtonViewList.Text = "返回";
                this.AddLayer(this.tListLayers);
                this.mapViewTools.Visible = true;
                this.simpleButtonRestore.Enabled = false;
            }
            else if (this.simpleButtonViewList.Text == "返回")
            {
                this.groupControl3.Visible = false;
                this.simpleButtonViewList.Text = "查看";
                this.mpanMap.Visible = false;
                this.mapViewTools.Visible = false;
                this.simpleButtonRestore.Enabled = true;
            }
        }

        private void simpleButtonViewMap_Click(object sender, EventArgs e)
        {
            this.AddLayer(this.tListLayers);
        }

        private void simpleButtonViewMap2_Click(object sender, EventArgs e)
        {
            this.AddLayer(this.tListLayers2);
        }

        private void tListCatalog_AfterExpand(object sender, NodeEventArgs e)
        {
            if (!this.mSelected)
            {
                this.EnumDirectories(e.Node);
            }
        }

        private void tListCatalog_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
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
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlBackRestore", "tListCatalog_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListLayers_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        private void tListLayers_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tListLayers.FocusedNode != null)
            {
                if (this.tListLayers.FocusedNode.Tag is IFeatureClass)
                {
                    this.simpleButtonViewMap.Enabled = true;
                }
                else if (this.tListLayers.FocusedNode.Tag is ITable)
                {
                    this.simpleButtonViewMap.Enabled = true;
                }
                else
                {
                    this.simpleButtonViewMap.Enabled = false;
                }
            }
            else
            {
                this.simpleButtonViewMap.Enabled = false;
            }
        }

        private void tListLayers2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        private void tListLayers2_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tListLayers2.FocusedNode != null)
            {
                if (this.tListLayers2.FocusedNode.Tag is IFeatureClass)
                {
                    this.simpleButtonViewMap2.Enabled = true;
                }
                else if (this.tListLayers2.FocusedNode.Tag is ITable)
                {
                    this.simpleButtonViewMap2.Enabled = true;
                }
                else
                {
                    this.simpleButtonViewMap2.Enabled = false;
                }
            }
            else
            {
                this.simpleButtonViewMap2.Enabled = false;
            }
        }

        private void tListLayers2_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void treeListno_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.treeListno.FocusedNode != null)
            {
                if (this.treeListno.FocusedNode.Tag is IFeatureDataset)
                {
                    this.simpleButtonViewMap3.Enabled = true;
                    this.simpleButtonBackup2.Enabled = true;
                }
                else if (this.treeListno.FocusedNode.Tag is IFeatureClass)
                {
                    this.simpleButtonViewMap3.Enabled = true;
                    this.simpleButtonBackup2.Enabled = true;
                }
                else if (this.treeListno.FocusedNode.Tag is ITable)
                {
                    this.simpleButtonViewMap3.Enabled = true;
                    this.simpleButtonBackup2.Enabled = true;
                }
                else
                {
                    this.simpleButtonViewMap3.Enabled = false;
                    this.simpleButtonBackup2.Enabled = false;
                }
            }
            else
            {
                this.simpleButtonViewMap3.Enabled = false;
                this.simpleButtonBackup2.Enabled = false;
            }
        }
    }
}

