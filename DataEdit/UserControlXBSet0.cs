namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlXBSet0 : UserControlBase1
    {
        private int column = -1;
        private int column0 = -1;
        private IContainer components = null;
        private bool EditFlag = false;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        internal ImageList imageList0;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        internal ImageList imageList3;
        private ImageList imageList4;
        private ImageList imageList5;
        internal ImageList imageList6;
        internal ImageList imageList7;
        private IFeatureLayer m_BackLayer;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private ITable m_QueryTable;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private IActiveViewEvents_Event mActiveViewEvents;
        private RepositoryItemButtonEdit mButton;
        private const string mClassName = "DataEdit.UserControlXBSet";
        private RepositoryItemImageEdit mCurItemImageEdit;
        private RepositoryItemImageEdit mCurItemImageEdit0;
        private RepositoryItemImageEdit mCurItemImageEdit2;
        private RepositoryItemImageEdit mCurItemImageEdit22;
        private RepositoryItemImageEdit mCurItemImageEdit4;
        private RepositoryItemImageEdit mCurItemImageEdit5;
      
        private DockPanel mDockPanel;
        private string mEditKindCode;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private IHookHelper mHookHelper;
        private DataTable mKindTable;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private ArrayList mQueryList = null;
        private UserControlQueryResult mQueryResult;
        private bool mSelected;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        public NavBarControl navBarControl1;
        public NavBarGroup navBarGroup1;
        public NavBarGroup navBarGroup2;
        private NavBarGroupControlContainer navBarGroupControlContainer1;
        private NavBarGroupControlContainer navBarGroupControlContainer2;
        private NavBarItem navBarItem1;
        private NavBarItem navBarItem2;
        private NavBarItem navBarItem3;
        private NavBarItem navBarItem4;
        private NavBarItem navBarItem5;
        private NavBarItem navBarItem6;
        private Panel panel1;
        private Panel panel6;
        private RadioGroup radioGroup1;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemImageEdit repositoryItemImageEdit4;
        private RepositoryItemImageEdit repositoryItemImageEdit5;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private string sDesKeyField;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        private TreeList tListDist;
        private TreeList tListKind;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeListColumn treeListColumn6;
        private TreeListColumn treeListColumn7;
        private TreeListColumn treeListColumn8;

        public UserControlXBSet0()
        {
            this.InitializeComponent();
        }

        private void DeleteDistCode(TreeListNode node)
        {
            try
            {
                int num;
                string[] strArray = EditTask.DistCode.Split(new char[] { ',' });
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num] == node.Tag.ToString())
                    {
                        strArray[num] = "";
                    }
                }
                EditTask.DistCode = "";
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num] != "")
                    {
                        if (EditTask.DistCode != "")
                        {
                            EditTask.DistCode = EditTask.DistCode + "," + strArray[num];
                        }
                        else
                        {
                            EditTask.DistCode = strArray[num];
                        }
                    }
                }
            }
            catch (Exception)
            {
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

        private void GetFeatureList()
        {
            try
            {
                this.m_QueryTable = null;
                this.mQueryList = null;
                this.m_QueryLayer = null;
                ArrayList tag = null;
                ITable table = null;
                string str = "";
                if (this.mNode2.Tag is ArrayList)
                {
                    tag = this.mNode2.Tag as ArrayList;
                    if ((tag.Count > 0) && (tag[0] is string))
                    {
                        str = tag[0].ToString();
                    }
                    if (tag[tag.Count - 1] is ITable)
                    {
                        table = tag[tag.Count - 1] as ITable;
                        this.m_QueryTable = table;
                    }
                }
                else if (this.mNode3.Tag != null)
                {
                    tag = this.mNode3.Tag as ArrayList;
                    if ((tag.Count > 0) && (tag[0] is string))
                    {
                        str = tag[0].ToString();
                    }
                }
                tag = this.mNode3.Tag as ArrayList;
                if (tag != null)
                {
                    IFeatureClass featureClass = null;
                    IFeatureLayer layer = null;
                    for (int i = 0; i < tag.Count; i++)
                    {
                        if (tag[i] is IFeatureLayer)
                        {
                            layer = tag[i] as IFeatureLayer;
                            featureClass = (tag[i] as IFeatureLayer).FeatureClass;
                            this.m_QueryLayer = layer;
                        }
                        else if (tag[i] is IFeatureClass)
                        {
                            featureClass = tag[i] as IFeatureClass;
                            layer = new FeatureLayerClass();
                            layer.FeatureClass = featureClass;
                            layer.Name = "";
                            this.m_QueryLayer = layer;
                        }
                        else if (!(tag[i] is string) && (tag[i] is ITable))
                        {
                            table = tag[i] as ITable;
                            this.m_QueryTable = table;
                        }
                    }
                    IQueryFilter filter = new QueryFilterClass();
                    filter.WhereClause = "";
                    GC.Collect();
                    IFeatureCursor cursor = featureClass.Search(filter, false);
                    IFeature feature = cursor.NextFeature();
                    this.mQueryList = new ArrayList();
                    while (feature != null)
                    {
                        this.mQueryList.Add(feature);
                        feature = cursor.NextFeature();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private TreeListNode GetParentNode(string code)
        {
            try
            {
                for (int i = 0; i < this.tListKind.Nodes.Count; i++)
                {
                    if (this.tListKind.Nodes[i].Tag == code)
                    {
                        return this.tListKind.Nodes[i];
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "GetParentNode", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public void Hook(object hook, IFeatureLayer pEditFLayer, UserControlQueryResult pResult, DockPanel pDockPanel)
        {
            try
            {
                this.m_EditLayer = pEditFLayer;
                this.mQueryResult = pResult;
                this.mDockPanel = pDockPanel;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                    }
                    this.InitialValue();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDistList()
        {
            try
            {
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                if (this.tListDist.Nodes.Count > 0)
                {
                    this.tListDist.ClearNodes();
                }
                this.tListDist.Columns[0].Width = ((this.tListDist.Width - 0x18) - 0x18) - 10;
                this.tListDist.Columns[1].Width = 0x18;
                this.tListDist.OptionsView.ShowRoot = true;
                this.tListDist.SelectImageList = this.ImageList1;
                this.tListDist.StateImageList = this.ImageList1;
                this.tListDist.OptionsView.ShowButtons = true;
                this.tListDist.TreeLineStyle = LineStyle.None;
                this.tListDist.RowHeight = 20;
                this.tListDist.OptionsBehavior.AutoPopulateColumns = true;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                int num = this.m_CountyLayer.FeatureClass.FeatureCount(null);
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = configValue + "='" + EditTask.DistCode.Substring(0, 6) + "'";
                IFeatureCursor cursor = this.m_CountyLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                int index = feature.Fields.FindField(configValue);
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode");
                while (feature != null)
                {
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = str2 + "='" + feature.get_Value(index).ToString() + "' and CINDEX='103'";
                    ICursor cursor2 = this.m_CountyTable.Search(queryFilter, false);
                    IRow row = cursor2.NextRow();
                    int num3 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode"));
                    int num4 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName"));
                    while (row != null)
                    {
                        if (row.get_Value(num3).ToString() == feature.get_Value(index).ToString())
                        {
                            node3 = this.tListDist.AppendNode(row.get_Value(num4).ToString(), node4);
                            node3.ImageIndex = 1;
                            node3.StateImageIndex = 3;
                            node3.SelectImageIndex = 1;
                            node3.SetValue(0, row.get_Value(num4).ToString());
                            node3.Tag = row.get_Value(num3).ToString();
                            IQueryFilter filter3 = new QueryFilterClass();
                            filter3.WhereClause = str2 + " like '" + row.get_Value(num3).ToString() + "%' and CINDEX='104'";
                            ICursor cursor3 = this.m_TownTable.Search(filter3, true);
                            for (IRow row2 = cursor3.NextRow(); row2 != null; row2 = cursor3.NextRow())
                            {
                                parentNode = this.tListDist.AppendNode(row2.get_Value(num4).ToString(), node3);
                                parentNode.ImageIndex = -1;
                                parentNode.StateImageIndex = 0x5b;
                                parentNode.SelectImageIndex = -1;
                                parentNode.SetValue(0, row2.get_Value(num4).ToString());
                                parentNode.Tag = row2.get_Value(num3).ToString();
                                parentNode.Expanded = false;
                                IQueryFilter filter4 = new QueryFilterClass();
                                filter4.WhereClause = str2 + " like '" + row2.get_Value(num3).ToString() + "%' and CINDEX='105'";
                                ICursor cursor4 = this.m_VillageTable.Search(filter4, false);
                                for (IRow row3 = cursor4.NextRow(); row3 != null; row3 = cursor4.NextRow())
                                {
                                    node = this.tListDist.AppendNode(row3.get_Value(num4).ToString(), parentNode);
                                    node.ImageIndex = -1;
                                    node.StateImageIndex = 4;
                                    node.SelectImageIndex = -1;
                                    node.SetValue(0, row3.get_Value(num4).ToString());
                                    node.Tag = row3.get_Value(num3).ToString();
                                    node.Expanded = false;
                                }
                            }
                            node3.Expanded = true;
                        }
                        row = cursor2.NextRow();
                    }
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "InitialDistList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlXBSet0));
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.tListDist = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tListKind = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageList5 = new System.Windows.Forms.ImageList();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.imageList4 = new System.Windows.Forms.ImageList();
            this.imageList6 = new System.Windows.Forms.ImageList();
            this.imageList0 = new System.Windows.Forms.ImageList();
            this.repositoryItemImageEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageList7 = new System.Windows.Forms.ImageList();
            this.repositoryItemImageEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit5)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "当前编辑图层"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定目标数据")});
            this.radioGroup1.Size = new System.Drawing.Size(292, 30);
            this.radioGroup1.TabIndex = 18;
            this.radioGroup1.Visible = false;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6});
            this.navBarControl1.LargeImages = this.imageCollection1;
            this.navBarControl1.Location = new System.Drawing.Point(0, 30);
            this.navBarControl1.LookAndFeel.SkinName = "Money Twins";
            this.navBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(292, 551);
            this.navBarControl1.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.navBarControl1.SmallImages = this.imageCollection2;
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 19;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "区划范围";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup1.GroupClientHeight = 530;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.LargeImageIndex = 38;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImageIndex = 52;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.tListDist);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(267, 526);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // tListDist
            // 
            this.tListDist.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListDist.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListDist.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDist.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDist.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tListDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDist.Location = new System.Drawing.Point(0, 0);
            this.tListDist.Name = "tListDist";
            this.tListDist.BeginUnboundLoad();
            this.tListDist.AppendNode(new object[] {
            "县",
            null}, -1, 0, 0, 3);
            this.tListDist.AppendNode(new object[] {
            "乡",
            null}, 0, 0, 0, 4);
            this.tListDist.AppendNode(new object[] {
            "村",
            null}, 1, 0, 0, 91);
            this.tListDist.EndUnboundLoad();
            this.tListDist.OptionsBehavior.Editable = false;
            this.tListDist.OptionsView.AutoWidth = false;
            this.tListDist.OptionsView.ShowColumns = false;
            this.tListDist.OptionsView.ShowHorzLines = false;
            this.tListDist.OptionsView.ShowIndicator = false;
            this.tListDist.OptionsView.ShowVertLines = false;
            this.tListDist.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.tListDist.RowHeight = 22;
            this.tListDist.SelectImageList = this.ImageList1;
            this.tListDist.Size = new System.Drawing.Size(267, 526);
            this.tListDist.StateImageList = this.ImageList1;
            this.tListDist.TabIndex = 0;
            this.tListDist.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.tListDist_CustomNodeCellEdit);
            this.tListDist.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.tListDist_BeforeExpand);
            this.tListDist.BeforeCollapse += new DevExpress.XtraTreeList.BeforeCollapseEventHandler(this.tListDist_BeforeCollapse);
            this.tListDist.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.tListDist_AfterExpand);
            this.tListDist.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.tListDist_AfterCollapse);
            this.tListDist.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListDist_FocusedNodeChanged);
            this.tListDist.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tListDist_FocusedColumnChanged);
            this.tListDist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tListDist_MouseUp);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 103;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 180;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.MinWidth = 16;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 16;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.Appearance.Image")));
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.AppearanceFocused.Image")));
            this.repositoryItemImageEdit1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.HideSelection = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit1.Click += new System.EventHandler(this.repositoryItemImageEdit1_Click);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "(14,37).png");
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
            this.ImageList1.Images.SetKeyName(69, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(71, "(34,00).png");
            this.ImageList1.Images.SetKeyName(72, "(03,02).png");
            this.ImageList1.Images.SetKeyName(73, "(49,06).png");
            this.ImageList1.Images.SetKeyName(74, "(09,13).png");
            this.ImageList1.Images.SetKeyName(75, "(16,47).png");
            this.ImageList1.Images.SetKeyName(76, "(13,47).png");
            this.ImageList1.Images.SetKeyName(77, "(18,01).png");
            this.ImageList1.Images.SetKeyName(78, "(18,13).png");
            this.ImageList1.Images.SetKeyName(79, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(81, "(39,47).png");
            this.ImageList1.Images.SetKeyName(82, "(45,12).png");
            this.ImageList1.Images.SetKeyName(83, "(45,17).png");
            this.ImageList1.Images.SetKeyName(84, "(45,41).png");
            this.ImageList1.Images.SetKeyName(85, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(86, "(11,29).png");
            this.ImageList1.Images.SetKeyName(87, "(12,29).png");
            this.ImageList1.Images.SetKeyName(88, "(12,11).png");
            this.ImageList1.Images.SetKeyName(89, "(24,28).png");
            this.ImageList1.Images.SetKeyName(90, "");
            this.ImageList1.Images.SetKeyName(91, "home_16.png");
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.panel1);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(290, 491);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tListKind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7);
            this.panel1.Size = new System.Drawing.Size(290, 491);
            this.panel1.TabIndex = 0;
            // 
            // tListKind
            // 
            this.tListKind.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.tListKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListKind.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.tListKind.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListKind.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tListKind.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tListKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListKind.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8});
            this.tListKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListKind.Location = new System.Drawing.Point(7, 7);
            this.tListKind.Name = "tListKind";
            this.tListKind.BeginUnboundLoad();
            this.tListKind.AppendNode(new object[] {
            "专题",
            "",
            null,
            null,
            null,
            null}, -1, 0, 0, 5);
            this.tListKind.AppendNode(new object[] {
            "采伐",
            "可见",
            null,
            null,
            null,
            null}, 0, -1, -1, 53);
            this.tListKind.AppendNode(new object[] {
            "采伐",
            "可见",
            null,
            null,
            null,
            null}, 0, -1, -1, 41);
            this.tListKind.AppendNode(new object[] {
            "森林火灾",
            null,
            null,
            null,
            null,
            null}, 0, -1, -1, 54);
            this.tListKind.AppendNode(new object[] {
            "林地征占用",
            null,
            null,
            null,
            null,
            null}, 0, -1, -1, 52);
            this.tListKind.AppendNode(new object[] {
            "自然灾害",
            null,
            null,
            null,
            null,
            null}, 0, -1, -1, 64);
            this.tListKind.AppendNode(new object[] {
            "林业案件",
            null,
            null,
            null,
            null,
            null}, 0, -1, -1, 2);
            this.tListKind.AppendNode(new object[] {
            "其它变更",
            "",
            null,
            null,
            null,
            null}, -1, 7, -1, 7);
            this.tListKind.AppendNode(new object[] {
            "自然因素",
            null,
            null,
            null,
            null,
            null}, 7, -1, -1, 35);
            this.tListKind.AppendNode(new object[] {
            "调查因素",
            null,
            null,
            null,
            null,
            null}, 7, -1, -1, 44);
            this.tListKind.EndUnboundLoad();
            this.tListKind.OptionsBehavior.Editable = false;
            this.tListKind.OptionsView.AutoWidth = false;
            this.tListKind.OptionsView.ShowColumns = false;
            this.tListKind.OptionsView.ShowHorzLines = false;
            this.tListKind.OptionsView.ShowIndicator = false;
            this.tListKind.OptionsView.ShowVertLines = false;
            this.tListKind.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit2,
            this.repositoryItemImageComboBox1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageEdit3,
            this.repositoryItemImageEdit33});
            this.tListKind.SelectImageList = this.imageList5;
            this.tListKind.Size = new System.Drawing.Size(276, 477);
            this.tListKind.StateImageList = this.imageCollection1;
            this.tListKind.TabIndex = 4;
            this.tListKind.TreeLevelWidth = 12;
            this.tListKind.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListKind.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.tListKind_CustomNodeCellEdit);
            this.tListKind.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListKind_FocusedNodeChanged);
            this.tListKind.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tListKind_FocusedColumnChanged);
            this.tListKind.DoubleClick += new System.EventHandler(this.tListKind_DoubleClick);
            this.tListKind.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tListKind_MouseDoubleClick);
            this.tListKind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tListKind_MouseUp);
            this.tListKind.Resize += new System.EventHandler(this.tListKind_Resize);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn1";
            this.treeListColumn3.FieldName = "treeListColumn1";
            this.treeListColumn3.MinWidth = 94;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 160;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn2";
            this.treeListColumn4.FieldName = "treeListColumn2";
            this.treeListColumn4.MinWidth = 16;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 1;
            this.treeListColumn4.Width = 50;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "treeListColumn3";
            this.treeListColumn5.FieldName = "treeListColumn3";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 2;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "treeListColumn4";
            this.treeListColumn6.FieldName = "treeListColumn4";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "treeListColumn5";
            this.treeListColumn7.FieldName = "treeListColumn5";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 3;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "treeListColumn6";
            this.treeListColumn8.FieldName = "treeListColumn6";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 4;
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit2.Appearance.Image")));
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit2.Click += new System.EventHandler(this.repositoryItemImageEdit2_Click);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageComboBox1.Appearance.Image")));
            this.repositoryItemImageComboBox1.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageComboBox1.AppearanceFocused.Image")));
            this.repositoryItemImageComboBox1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemPictureEdit1.Appearance.Image")));
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            this.repositoryItemImageEdit3.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemImageEdit33
            // 
            this.repositoryItemImageEdit33.AutoHeight = false;
            this.repositoryItemImageEdit33.Name = "repositoryItemImageEdit33";
            // 
            // imageList5
            // 
            this.imageList5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList5.ImageStream")));
            this.imageList5.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "170503292.gif");
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "document-open.png");
            this.imageCollection1.Images.SetKeyName(1, "lincity-ng.png");
            this.imageCollection1.Images.SetKeyName(2, "kde-folder-txt.png");
            this.imageCollection1.Images.SetKeyName(3, "old-go-home.png");
            this.imageCollection1.Images.SetKeyName(4, "go-home.png");
            this.imageCollection1.Images.SetKeyName(5, "stock_task-recurring.png");
            this.imageCollection1.Images.SetKeyName(6, "old-openofficeorg-math.png");
            this.imageCollection1.Images.SetKeyName(7, "okteta.png");
            this.imageCollection1.Images.SetKeyName(8, "gconfeditor.png");
            this.imageCollection1.Images.SetKeyName(9, "gddccontrol.png");
            this.imageCollection1.Images.SetKeyName(10, "gnome-klotski.png");
            this.imageCollection1.Images.SetKeyName(11, "layer.png");
            this.imageCollection1.Images.SetKeyName(12, "chart_bullseye.png");
            this.imageCollection1.Images.SetKeyName(13, "draw_polyline.png");
            this.imageCollection1.Images.SetKeyName(14, "large_tiles.png");
            this.imageCollection1.Images.SetKeyName(15, "layers2.png");
            this.imageCollection1.Images.SetKeyName(16, "small_tiles.png");
            this.imageCollection1.Images.SetKeyName(17, "layers.png");
            this.imageCollection1.Images.SetKeyName(18, "application_view_tile.png");
            this.imageCollection1.Images.SetKeyName(19, "chart_stock.png");
            this.imageCollection1.Images.SetKeyName(20, "preferences-desktop-theme.png");
            this.imageCollection1.Images.SetKeyName(21, "grass.png");
            this.imageCollection1.Images.SetKeyName(22, "house_one.png");
            this.imageCollection1.Images.SetKeyName(23, "plotchart.png");
            this.imageCollection1.Images.SetKeyName(24, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(25, "illustration.png");
            this.imageCollection1.Images.SetKeyName(26, "google_map.png");
            this.imageCollection1.Images.SetKeyName(27, "color_swatches.png");
            this.imageCollection1.Images.SetKeyName(28, "openofficeorg-draw.png");
            this.imageCollection1.Images.SetKeyName(29, "green_wormhole.png");
            this.imageCollection1.Images.SetKeyName(30, "applix.png");
            this.imageCollection1.Images.SetKeyName(31, "abiword.png");
            this.imageCollection1.Images.SetKeyName(32, "Text-Document.png");
            this.imageCollection1.Images.SetKeyName(33, "Xcode.png");
            this.imageCollection1.Images.SetKeyName(34, "Application.png");
            this.imageCollection1.Images.SetKeyName(35, "leaves.png");
            this.imageCollection1.Images.SetKeyName(36, "folder_edit.png");
            this.imageCollection1.Images.SetKeyName(37, "color_swatch.png");
            this.imageCollection1.Images.SetKeyName(38, "house.png");
            this.imageCollection1.Images.SetKeyName(39, "images.png");
            this.imageCollection1.Images.SetKeyName(40, "tree2.png");
            this.imageCollection1.Images.SetKeyName(41, "tree_1.png");
            this.imageCollection1.Images.SetKeyName(42, "img-portrait-edit.png");
            this.imageCollection1.Images.SetKeyName(43, "tree.png");
            this.imageCollection1.Images.SetKeyName(44, "20071126112025469.png");
            this.imageCollection1.Images.SetKeyName(45, "mb5u3_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(46, "mb5u6_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(47, "20071127000637768.png");
            this.imageCollection1.Images.SetKeyName(48, "sc0905281_3.png");
            this.imageCollection1.Images.SetKeyName(49, "sc0905281_4.png");
            this.imageCollection1.Images.SetKeyName(50, "20071127000640731.png");
            this.imageCollection1.Images.SetKeyName(51, "20071127112435759.png");
            this.imageCollection1.Images.SetKeyName(52, "20071206144123734.png");
            this.imageCollection1.Images.SetKeyName(53, "icontexto-green-01.png");
            this.imageCollection1.Images.SetKeyName(54, "fire.png");
            this.imageCollection1.Images.SetKeyName(55, "house.png");
            this.imageCollection1.Images.SetKeyName(56, "images.png");
            this.imageCollection1.Images.SetKeyName(57, "layers.png");
            this.imageCollection1.Images.SetKeyName(58, "layers_map.png");
            this.imageCollection1.Images.SetKeyName(59, "Plant.png");
            this.imageCollection1.Images.SetKeyName(60, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(61, "sun_rain.png");
            this.imageCollection1.Images.SetKeyName(62, "tree.png");
            this.imageCollection1.Images.SetKeyName(63, "weather_rain.png");
            this.imageCollection1.Images.SetKeyName(64, "weather_snow.png");
            this.imageCollection1.Images.SetKeyName(65, "widgets.png");
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.AppearancePressed.BorderColor = System.Drawing.Color.Red;
            this.navBarGroup2.AppearancePressed.Options.UseBorderColor = true;
            this.navBarGroup2.Caption = "变更类型";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup2.GroupClientHeight = 530;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.LargeImageIndex = 10;
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImageIndex = 30;
            // 
            // navBarItem1
            // 
            this.navBarItem1.Appearance.BorderColor = System.Drawing.Color.Red;
            this.navBarItem1.Appearance.Options.UseBorderColor = true;
            this.navBarItem1.AppearanceDisabled.ForeColor = System.Drawing.Color.Gray;
            this.navBarItem1.AppearanceDisabled.Options.UseForeColor = true;
            this.navBarItem1.AppearanceHotTracked.BorderColor = System.Drawing.Color.Red;
            this.navBarItem1.AppearanceHotTracked.Options.UseBorderColor = true;
            this.navBarItem1.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.navBarItem1.AppearancePressed.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarItem1.AppearancePressed.BorderColor = System.Drawing.Color.Red;
            this.navBarItem1.AppearancePressed.ForeColor = System.Drawing.Color.Blue;
            this.navBarItem1.AppearancePressed.Options.UseBackColor = true;
            this.navBarItem1.AppearancePressed.Options.UseBorderColor = true;
            this.navBarItem1.AppearancePressed.Options.UseForeColor = true;
            this.navBarItem1.Caption = "造林作业";
            this.navBarItem1.LargeImageIndex = 54;
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "采伐作业";
            this.navBarItem2.LargeImageIndex = 55;
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "森林火灾";
            this.navBarItem3.LargeImageIndex = 16;
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "林地征占用";
            this.navBarItem4.LargeImageIndex = 59;
            this.navBarItem4.Name = "navBarItem4";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "自然灾害";
            this.navBarItem5.LargeImageIndex = 67;
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "自检自查";
            this.navBarItem6.LargeImageIndex = 78;
            this.navBarItem6.Name = "navBarItem6";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "1259760497_color_swatch_2.png");
            this.imageCollection2.Images.SetKeyName(1, "arrow_circle_double.png");
            this.imageCollection2.Images.SetKeyName(2, "edit_16x16.gif");
            this.imageCollection2.Images.SetKeyName(3, "map.png");
            this.imageCollection2.Images.SetKeyName(4, "map_add2.png");
            this.imageCollection2.Images.SetKeyName(5, "map_delete.png");
            this.imageCollection2.Images.SetKeyName(6, "map_edit2.png");
            this.imageCollection2.Images.SetKeyName(7, "map_go.png");
            this.imageCollection2.Images.SetKeyName(8, "map_magnify2.png");
            this.imageCollection2.Images.SetKeyName(9, "map2.png");
            this.imageCollection2.Images.SetKeyName(10, "map4.png");
            this.imageCollection2.Images.SetKeyName(11, "map--arrow.png");
            this.imageCollection2.Images.SetKeyName(12, "map--minus.png");
            this.imageCollection2.Images.SetKeyName(13, "map--pencil.png");
            this.imageCollection2.Images.SetKeyName(14, "map-pin.png");
            this.imageCollection2.Images.SetKeyName(15, "map--plus.png");
            this.imageCollection2.Images.SetKeyName(16, "maps.png");
            this.imageCollection2.Images.SetKeyName(17, "maps--arrow.png");
            this.imageCollection2.Images.SetKeyName(18, "maps--exclamation.png");
            this.imageCollection2.Images.SetKeyName(19, "maps--minus.png");
            this.imageCollection2.Images.SetKeyName(20, "maps--pencil.png");
            this.imageCollection2.Images.SetKeyName(21, "maps--pencil2.png");
            this.imageCollection2.Images.SetKeyName(22, "maps--pencil3.png");
            this.imageCollection2.Images.SetKeyName(23, "maps--plus.png");
            this.imageCollection2.Images.SetKeyName(24, "maps-stack.png");
            this.imageCollection2.Images.SetKeyName(25, "pathing3.png");
            this.imageCollection2.Images.SetKeyName(26, "picture_pencil.png");
            this.imageCollection2.Images.SetKeyName(27, "table__arrow.png");
            this.imageCollection2.Images.SetKeyName(28, "arrow_large_up.png");
            this.imageCollection2.Images.SetKeyName(29, "web design_16_hot.png");
            this.imageCollection2.Images.SetKeyName(30, "ksirtet16.png");
            this.imageCollection2.Images.SetKeyName(31, "node-select-child.png");
            this.imageCollection2.Images.SetKeyName(32, "flag blue.png");
            this.imageCollection2.Images.SetKeyName(33, "flag red.png");
            this.imageCollection2.Images.SetKeyName(34, "flag yellow.png");
            this.imageCollection2.Images.SetKeyName(35, "image.png");
            this.imageCollection2.Images.SetKeyName(36, "image_edit.png");
            this.imageCollection2.Images.SetKeyName(37, "image_magnify.png");
            this.imageCollection2.Images.SetKeyName(38, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(39, "page_paintbrush.png");
            this.imageCollection2.Images.SetKeyName(40, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(41, "pencil.png");
            this.imageCollection2.Images.SetKeyName(42, "photo.png");
            this.imageCollection2.Images.SetKeyName(43, "photos.png");
            this.imageCollection2.Images.SetKeyName(44, "picture.png");
            this.imageCollection2.Images.SetKeyName(45, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(46, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(47, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(48, "search.gif");
            this.imageCollection2.Images.SetKeyName(49, "table.png");
            this.imageCollection2.Images.SetKeyName(50, "table_edit.png");
            this.imageCollection2.Images.SetKeyName(51, "(01,40).png");
            this.imageCollection2.Images.SetKeyName(52, "(01,46).png");
            this.imageCollection2.Images.SetKeyName(53, "(09,46).png");
            this.imageCollection2.Images.SetKeyName(54, "(12,11).png");
            this.imageCollection2.Images.SetKeyName(55, "(14,36).png");
            this.imageCollection2.Images.SetKeyName(56, "(14,37).png");
            this.imageCollection2.Images.SetKeyName(57, "(15,25).png");
            this.imageCollection2.Images.SetKeyName(58, "(15,40).png");
            this.imageCollection2.Images.SetKeyName(59, "(16,32).png");
            this.imageCollection2.Images.SetKeyName(60, "(17,49).png");
            this.imageCollection2.Images.SetKeyName(61, "(19,01).png");
            this.imageCollection2.Images.SetKeyName(62, "(24,04).png");
            this.imageCollection2.Images.SetKeyName(63, "(24,32).png");
            this.imageCollection2.Images.SetKeyName(64, "(28,09).png");
            this.imageCollection2.Images.SetKeyName(65, "(29,04).png");
            this.imageCollection2.Images.SetKeyName(66, "(30,24).png");
            this.imageCollection2.Images.SetKeyName(67, "(32,04).png");
            this.imageCollection2.Images.SetKeyName(68, "(32,24).png");
            this.imageCollection2.Images.SetKeyName(69, "(33,14).png");
            this.imageCollection2.Images.SetKeyName(70, "(35,29).png");
            this.imageCollection2.Images.SetKeyName(71, "(35,31).png");
            this.imageCollection2.Images.SetKeyName(72, "(35,45).png");
            this.imageCollection2.Images.SetKeyName(73, "(36,04).png");
            this.imageCollection2.Images.SetKeyName(74, "(36,47).png");
            this.imageCollection2.Images.SetKeyName(75, "(39,47).png");
            this.imageCollection2.Images.SetKeyName(76, "(40,05).png");
            this.imageCollection2.Images.SetKeyName(77, "(44,27).png");
            this.imageCollection2.Images.SetKeyName(78, "(45,28).png");
            this.imageCollection2.Images.SetKeyName(79, "(49,06).png");
            this.imageCollection2.Images.SetKeyName(80, "(49,48).png");
            this.imageCollection2.Images.SetKeyName(81, "(15,49).png");
            this.imageCollection2.Images.SetKeyName(82, "(27,15).png");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 581);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(7);
            this.panel6.Size = new System.Drawing.Size(292, 40);
            this.panel6.TabIndex = 22;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonOK.ImageIndex = 46;
            this.simpleButtonOK.Location = new System.Drawing.Point(143, 7);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(71, 26);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "编辑";
            this.simpleButtonOK.ToolTip = "开始编辑";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonCancel.ImageIndex = 52;
            this.simpleButtonCancel.Location = new System.Drawing.Point(214, 7);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(71, 26);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "停止";
            this.simpleButtonCancel.ToolTip = "停止编辑";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "layers_map.png");
            this.imageList2.Images.SetKeyName(1, "(28,08).png");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "(01,49).png");
            this.imageList2.Images.SetKeyName(4, "(18,13).png");
            this.imageList2.Images.SetKeyName(5, "(01,46).png");
            this.imageList2.Images.SetKeyName(6, "(05,49).png");
            this.imageList2.Images.SetKeyName(7, "(06,30).png");
            this.imageList2.Images.SetKeyName(8, "(07,30).png");
            this.imageList2.Images.SetKeyName(9, "(09,13).png");
            this.imageList2.Images.SetKeyName(10, "(09,24).png");
            this.imageList2.Images.SetKeyName(11, "(11,49).png");
            this.imageList2.Images.SetKeyName(12, "(18,29).png");
            this.imageList2.Images.SetKeyName(13, "(34,00).png");
            this.imageList2.Images.SetKeyName(14, "(47,25).png");
            this.imageList2.Images.SetKeyName(15, "(48,48).png");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "(04,42).png");
            this.imageList3.Images.SetKeyName(1, "(03,42).png");
            this.imageList3.Images.SetKeyName(2, "(01,46).png");
            this.imageList3.Images.SetKeyName(3, "(01,49).png");
            this.imageList3.Images.SetKeyName(4, "(02,27).png");
            this.imageList3.Images.SetKeyName(5, "(03,42).png");
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "001_45.gif");
            this.imageList4.Images.SetKeyName(1, "001_38.gif");
            this.imageList4.Images.SetKeyName(2, "blue_view_24x24.gif");
            this.imageList4.Images.SetKeyName(3, "gtk-edit.png");
            this.imageList4.Images.SetKeyName(4, "ico6.gif");
            // 
            // imageList6
            // 
            this.imageList6.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList6.ImageStream")));
            this.imageList6.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "(03,42).png");
            this.imageList6.Images.SetKeyName(1, "(04,42).png");
            this.imageList6.Images.SetKeyName(2, "(01,46).png");
            this.imageList6.Images.SetKeyName(3, "(01,49).png");
            this.imageList6.Images.SetKeyName(4, "(02,27).png");
            this.imageList6.Images.SetKeyName(5, "(03,42).png");
            // 
            // imageList0
            // 
            this.imageList0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList0.ImageStream")));
            this.imageList0.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList0.Images.SetKeyName(0, "(01,49).png");
            this.imageList0.Images.SetKeyName(1, "");
            this.imageList0.Images.SetKeyName(2, "(18,13).png");
            this.imageList0.Images.SetKeyName(3, "(01,46).png");
            this.imageList0.Images.SetKeyName(4, "(05,49).png");
            this.imageList0.Images.SetKeyName(5, "(06,30).png");
            this.imageList0.Images.SetKeyName(6, "(07,30).png");
            this.imageList0.Images.SetKeyName(7, "(09,13).png");
            this.imageList0.Images.SetKeyName(8, "(09,24).png");
            this.imageList0.Images.SetKeyName(9, "(11,49).png");
            this.imageList0.Images.SetKeyName(10, "(18,29).png");
            this.imageList0.Images.SetKeyName(11, "(34,00).png");
            this.imageList0.Images.SetKeyName(12, "(47,25).png");
            this.imageList0.Images.SetKeyName(13, "(48,48).png");
            // 
            // repositoryItemImageEdit4
            // 
            this.repositoryItemImageEdit4.AutoHeight = false;
            this.repositoryItemImageEdit4.Name = "repositoryItemImageEdit4";
            // 
            // imageList7
            // 
            this.imageList7.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList7.ImageStream")));
            this.imageList7.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList7.Images.SetKeyName(0, "(01,49).png");
            this.imageList7.Images.SetKeyName(1, "(18,13).png");
            this.imageList7.Images.SetKeyName(2, "");
            this.imageList7.Images.SetKeyName(3, "(01,46).png");
            this.imageList7.Images.SetKeyName(4, "(05,49).png");
            this.imageList7.Images.SetKeyName(5, "(06,30).png");
            this.imageList7.Images.SetKeyName(6, "(07,30).png");
            this.imageList7.Images.SetKeyName(7, "(09,13).png");
            this.imageList7.Images.SetKeyName(8, "(09,24).png");
            this.imageList7.Images.SetKeyName(9, "(11,49).png");
            this.imageList7.Images.SetKeyName(10, "(18,29).png");
            this.imageList7.Images.SetKeyName(11, "(34,00).png");
            this.imageList7.Images.SetKeyName(12, "(47,25).png");
            this.imageList7.Images.SetKeyName(13, "(48,48).png");
            // 
            // repositoryItemImageEdit5
            // 
            this.repositoryItemImageEdit5.AutoHeight = false;
            this.repositoryItemImageEdit5.Name = "repositoryItemImageEdit5";
            // 
            // UserControlXBSet0
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.radioGroup1);
            this.Name = "UserControlXBSet0";
            this.Size = new System.Drawing.Size(292, 621);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit5)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialKindList(bool flag)
        {
            try
            {
                int num;
                int num2;
                ArrayList list;
                int num3;
                TreeListNode node2 = null;
                TreeListNode node3 = null;
                this.tListKind.Columns[0].Width = this.tListKind.Width - 110;
                this.tListKind.Columns[1].Width = 0x18;
                this.tListKind.Columns[2].Width = 0x16;
                this.tListKind.Columns[4].Width = 0x16;
                this.tListKind.Columns[5].Width = 0x16;
                this.tListKind.OptionsView.ShowRoot = true;
                this.tListKind.SelectImageList = this.imageList5;
                this.tListKind.StateImageList = this.imageCollection1;
                this.tListKind.OptionsView.ShowButtons = true;
                this.tListKind.TreeLineStyle = LineStyle.None;
                this.tListKind.RowHeight = 0x20;
                this.tListKind.OptionsBehavior.AutoPopulateColumns = true;
                for (num = 0; num < this.tListKind.Nodes.Count; num++)
                {
                    if ((this.tListKind.Nodes[num].ParentNode == null) && (this.tListKind.Nodes[num].Nodes.Count > 0))
                    {
                        num2 = 0;
                        while (num2 < this.tListKind.Nodes[num].Nodes.Count)
                        {
                            this.tListKind.Nodes[num].Nodes[num2].SetValue(1, "");
                            this.tListKind.Nodes[num].Nodes[num2].SelectImageIndex = -1;
                            this.tListKind.Nodes[num].Nodes[num2].ImageIndex = -1;
                            if ((this.tListKind.Nodes[num].Nodes[num2].Nodes.Count > 0) && (this.tListKind.Nodes[num].ParentNode == null))
                            {
                                this.tListKind.Nodes[num].Nodes[num2].Nodes.Clear();
                            }
                            list = new ArrayList();
                            num3 = num2 + 1;
                            list.Add("0" + num3.ToString());
                            this.tListKind.Nodes[num].Nodes[num2].Tag = list;
                            num2++;
                        }
                    }
                    else
                    {
                        this.tListKind.Nodes[num].SetValue(1, "");
                        this.tListKind.Nodes[num].SelectImageIndex = -1;
                        this.tListKind.Nodes[num].ImageIndex = -1;
                        if ((this.tListKind.Nodes[num].Nodes.Count > 0) && (this.tListKind.Nodes[num].ParentNode == null))
                        {
                            this.tListKind.Nodes[num].Nodes.Clear();
                        }
                        list = new ArrayList();
                        num3 = num + 1;
                        list.Add("0" + num3.ToString());
                        this.tListKind.Nodes[num].Tag = list;
                    }
                }
                if (flag)
                {
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName2").Split(new char[] { ',' });
                    string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName3").Split(new char[] { ',' });
                    string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName4").Split(new char[] { ',' });
                    ArrayList underLayers = EditTask.UnderLayers;
                    list = null;
                    for (num = 0; num < this.tListKind.Nodes.Count; num++)
                    {
                        string str;
                        string str2;
                        string str3;
                        IFeatureLayer layer;
                        node3 = this.tListKind.Nodes[num];
                        node3.ExpandAll();
                        if (node3.Nodes.Count == 0)
                        {
                            if (num <= (strArray.Length - 1))
                            {
                                str = strArray[num];
                                str2 = strArray2[num];
                                str3 = strArray3[num];
                                layer = underLayers[num] as IFeatureLayer;
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                list.Add(layer);
                                list.Add(str3);
                                node3.Tag = list;
                                node3.Nodes.Clear();
                                if (layer.Visible)
                                {
                                    node3.SetValue(3, "可见");
                                }
                                else
                                {
                                    node3.SetValue(3, "不可见");
                                }
                            }
                            else
                            {
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                node3.Tag = list;
                            }
                        }
                        else
                        {
                            switch (num)
                            {
                                case 0:
                                    num2 = 0;
                                    while (num2 < node3.Nodes.Count)
                                    {
                                        node2 = node3.Nodes[num2];
                                        if (num2 <= (strArray.Length - 1))
                                        {
                                            str = strArray[num2];
                                            str2 = strArray2[num2];
                                            str3 = strArray3[num2];
                                            layer = underLayers[num2] as IFeatureLayer;
                                            list = new ArrayList();
                                            num3 = num2 + 1;
                                            list.Add("0" + num3.ToString());
                                            list.Add(layer);
                                            list.Add(str3);
                                            node2.Tag = list;
                                            node2.Nodes.Clear();
                                            if (layer.Visible)
                                            {
                                                node2.SetValue(3, "可见");
                                            }
                                            else
                                            {
                                                node2.SetValue(3, "不可见");
                                            }
                                        }
                                        else
                                        {
                                            list = new ArrayList();
                                            num3 = num + 1;
                                            list.Add("0" + num3.ToString());
                                            node2.Tag = list;
                                        }
                                        num2++;
                                    }
                                    break;

                                case 1:
                                    for (num2 = 0; num2 < node3.Nodes.Count; num2++)
                                    {
                                        node2 = node3.Nodes[num2];
                                        list = new ArrayList();
                                        list.Add("0" + (((node2.Id - 2) + 1)).ToString());
                                        node2.Tag = list;
                                        node2.SetValue(3, "");
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IMap focusMap = this.mHookHelper.FocusMap;
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.m_CountyLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                    if (this.m_CountyLayer != null)
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                        this.m_TownLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                        if (this.m_TownLayer != null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                            this.m_VillageLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                            if (this.m_VillageLayer != null)
                            {
                                this.mFeatureWorkspace = EditTask.EditWorkspace;
                                if (this.mFeatureWorkspace != null)
                                {
                                    string name = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                                    this.m_CountyTable = this.mFeatureWorkspace.OpenTable(name);
                                    if (this.m_CountyTable != null)
                                    {
                                        name = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                                        this.m_TownTable = this.mFeatureWorkspace.OpenTable(name);
                                        if (this.m_TownTable != null)
                                        {
                                            name = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                                            this.m_VillageTable = this.mFeatureWorkspace.OpenTable(name);
                                            if (this.m_VillageTable != null)
                                            {
                                                this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                                                this.mCurItemImageEdit0.Images = this.imageList0;
                                                this.mCurItemImageEdit = this.repositoryItemImageEdit2;
                                                this.mCurItemImageEdit.Images = this.imageList2;
                                                this.mCurItemImageEdit.Click += new EventHandler(this.mCurItemImageEdit_Click);
                                                this.mCurItemImageEdit.ButtonClick += new ButtonPressedEventHandler(this.mCurItemImageEdit_ButtonClick);
                                                this.mCurItemImageEdit2 = this.repositoryItemImageEdit3;
                                                this.mCurItemImageEdit2.Images = this.imageList6;
                                                this.mCurItemImageEdit22 = this.repositoryItemImageEdit33;
                                                this.mCurItemImageEdit22.Images = this.imageList3;
                                                this.mCurItemImageEdit4 = this.repositoryItemImageEdit4;
                                                this.mCurItemImageEdit4.Images = this.imageList0;
                                                this.mCurItemImageEdit5 = this.repositoryItemImageEdit5;
                                                this.mCurItemImageEdit5.Images = this.imageList7;
                                                this.InitialDistList();
                                                this.InitialKindList(true);
                                                this.tListKind_MouseDoubleClick(null, null);
                                                this.mSelected = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mCurItemImageEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void mCurItemImageEdit_Click(object sender, EventArgs e)
        {
        }

        private void repositoryItemImageEdit1_Click(object sender, EventArgs e)
        {
            if (this.mNode.Tag != null)
            {
                IFeature tag = this.mNode.Tag as IFeature;
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                IEnvelope envelope = tag.Shape.Envelope;
                envelope.Expand(1.2, 1.2, true);
                focusMap.FullExtent = envelope;
                focusMap.Refresh();
            }
        }

        private void repositoryItemImageEdit2_Click(object sender, EventArgs e)
        {
            if (this.mNode2.Tag != null)
            {
                IFeature tag = this.mNode.Tag as IFeature;
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                IEnvelope envelope = tag.Shape.Envelope;
                envelope.Expand(1.2, 1.2, true);
                focusMap.FullExtent = envelope;
                focusMap.Refresh();
            }
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.mHookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
        }

        private void tListDist_AfterCollapse(object sender, NodeEventArgs e)
        {
        }

        private void tListDist_AfterExpand(object sender, NodeEventArgs e)
        {
        }

        private void tListDist_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            this.mSelected = true;
        }

        private void tListDist_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            this.mSelected = true;
        }

        private void tListDist_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn2")
            {
                e.RepositoryItem = this.mCurItemImageEdit0;
            }
        }

        private void tListDist_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.Column != null)
            {
                this.column0 = e.Column.AbsoluteIndex;
            }
        }

        private void tListDist_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                this.mNode = e.Node;
            }
        }

        private void tListDist_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.mSelected)
                {
                    this.mSelected = false;
                }
                else
                {
                    string tag;
                    if ((this.column0 == 0) || (e.X < ((this.tListDist.Width - 0x18) - 0x18)))
                    {
                        if (this.mNode != null)
                        {
                            int num;
                            int num2;
                            tag = this.mNode.Tag as string;
                            if (this.mNode.ParentNode == null)
                            {
                                if ((e.X >= 20) && (e.X <= 0x24))
                                {
                                    if (this.mNode.ImageIndex == 0)
                                    {
                                        this.mNode.ImageIndex = 1;
                                        this.mNode.SelectImageIndex = 1;
                                        EditTask.DistCode = this.mNode.Tag.ToString();
                                        for (num = 0; num < this.mNode.Nodes.Count; num++)
                                        {
                                            this.mNode.Nodes[num].ImageIndex = -1;
                                            this.mNode.Nodes[num].SelectImageIndex = -1;
                                            if (this.mNode.Nodes[num].ImageIndex == 1)
                                            {
                                                this.DeleteDistCode(this.mNode.Nodes[num]);
                                            }
                                            num2 = 0;
                                            while (num2 < this.mNode.Nodes[num].Nodes.Count)
                                            {
                                                if (this.mNode.Nodes[num].Nodes[num2].ImageIndex == 1)
                                                {
                                                    this.DeleteDistCode(this.mNode.Nodes[num].Nodes[num2]);
                                                }
                                                this.mNode.Nodes[num].Nodes[num2].ImageIndex = -1;
                                                this.mNode.Nodes[num].Nodes[num2].SelectImageIndex = -1;
                                                num2++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this.mNode.ImageIndex == 1)
                                        {
                                            this.DeleteDistCode(this.mNode);
                                        }
                                        this.mNode.ImageIndex = 0;
                                        this.mNode.SelectImageIndex = 0;
                                        for (num = 0; num < this.mNode.Nodes.Count; num++)
                                        {
                                            if (this.mNode.Nodes[num].ImageIndex == 1)
                                            {
                                                this.DeleteDistCode(this.mNode);
                                            }
                                            this.mNode.Nodes[num].ImageIndex = 0;
                                            this.mNode.Nodes[num].SelectImageIndex = 0;
                                            num2 = 0;
                                            while (num2 < this.mNode.Nodes[num].Nodes.Count)
                                            {
                                                if (this.mNode.Nodes[num].Nodes[num2].ImageIndex == 1)
                                                {
                                                    this.DeleteDistCode(this.mNode.Nodes[num].Nodes[num2]);
                                                }
                                                this.mNode.Nodes[num].Nodes[num2].ImageIndex = 0;
                                                this.mNode.Nodes[num].Nodes[num2].SelectImageIndex = 0;
                                                num2++;
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((this.mNode.ParentNode.ParentNode == null) && this.mNode.HasChildren)
                            {
                                if ((e.X >= 0x24) && (e.X <= 0x34))
                                {
                                    TreeListNode parentNode;
                                    if (this.mNode.ImageIndex == 0)
                                    {
                                        this.mNode.ImageIndex = 1;
                                        this.mNode.SelectImageIndex = 1;
                                        EditTask.DistCode = this.mNode.Tag.ToString();
                                        for (num = 0; num < this.mNode.Nodes.Count; num++)
                                        {
                                            if (this.mNode.Nodes[num].ImageIndex == 1)
                                            {
                                                this.DeleteDistCode(this.mNode.Nodes[num]);
                                            }
                                            this.mNode.Nodes[num].ImageIndex = -1;
                                            this.mNode.Nodes[num].SelectImageIndex = -1;
                                        }
                                        parentNode = this.mNode.ParentNode;
                                        for (num = 0; num < parentNode.Nodes.Count; num++)
                                        {
                                            num2 = 0;
                                            while (num2 < parentNode.Nodes[num].Nodes.Count)
                                            {
                                                if (parentNode.Nodes[num].Nodes[num2].ImageIndex == 1)
                                                {
                                                    this.DeleteDistCode(parentNode.Nodes[num].Nodes[num2]);
                                                }
                                                parentNode.Nodes[num].Nodes[num2].ImageIndex = -1;
                                                parentNode.Nodes[num].Nodes[num2].SelectImageIndex = -1;
                                                num2++;
                                            }
                                        }
                                    }
                                    else if (this.mNode.ImageIndex == 1)
                                    {
                                        this.DeleteDistCode(this.mNode);
                                        this.mNode.ImageIndex = 0;
                                        this.mNode.SelectImageIndex = 0;
                                        parentNode = this.mNode.ParentNode;
                                        bool flag = false;
                                        for (num = 0; num < parentNode.Nodes.Count; num++)
                                        {
                                            if (parentNode.Nodes[num].ImageIndex == 1)
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                        {
                                            for (num = 0; num < this.mNode.Nodes.Count; num++)
                                            {
                                                this.mNode.Nodes[num].ImageIndex = 0;
                                                this.mNode.Nodes[num].SelectImageIndex = 0;
                                                this.DeleteDistCode(this.mNode.Nodes[num]);
                                            }
                                        }
                                        else
                                        {
                                            for (num = 0; num < parentNode.Nodes.Count; num++)
                                            {
                                                for (num2 = 0; num2 < parentNode.Nodes[num].Nodes.Count; num2++)
                                                {
                                                    if (parentNode.Nodes[num].Nodes[num2].ImageIndex == 1)
                                                    {
                                                        this.DeleteDistCode(parentNode.Nodes[num].Nodes[num2]);
                                                    }
                                                    parentNode.Nodes[num].Nodes[num2].ImageIndex = 0;
                                                    parentNode.Nodes[num].Nodes[num2].SelectImageIndex = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((!this.mNode.HasChildren && (this.mNode.ParentNode != null)) && ((e.X >= 0x34) && (e.X <= 0x44)))
                            {
                                if (this.mNode.ImageIndex == 0)
                                {
                                    this.mNode.ImageIndex = 1;
                                    this.mNode.SelectImageIndex = 1;
                                    EditTask.DistCode = this.mNode.Tag.ToString();
                                }
                                else if (this.mNode.ImageIndex == 1)
                                {
                                    this.mNode.ImageIndex = 0;
                                    this.mNode.SelectImageIndex = 0;
                                    this.DeleteDistCode(this.mNode);
                                }
                            }
                        }
                    }
                    else if ((this.column0 == 1) && (this.mNode != null))
                    {
                        tag = this.mNode.Tag as string;
                        string configValue = "";
                        IFeatureLayer pFLayer = null;
                        if (this.mNode.ParentNode == null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                            pFLayer = this.m_CountyLayer;
                        }
                        else if ((this.mNode.ParentNode.ParentNode == null) && this.mNode.HasChildren)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                            pFLayer = this.m_TownLayer;
                        }
                        else if (!(this.mNode.HasChildren || (this.mNode.ParentNode == null)))
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                            pFLayer = this.m_VillageLayer;
                        }
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = configValue + "='" + tag + "'";
                        IFeature pFeature = pFLayer.Search(queryFilter, false).NextFeature();
                        if (pFeature != null)
                        {
                            this.SelectFeature(pFLayer, pFeature);
                            this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "tListDist_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListKind_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListColumn4")
                {
                    if (e.Node.ParentNode == this.mNode2)
                    {
                        if ((e.Node.Tag as ArrayList).Count < 3)
                        {
                            e.RepositoryItem = this.mCurItemImageEdit;
                        }
                        else
                        {
                            e.RepositoryItem = null;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn5")
                {
                    if (e.Node != this.mNode2)
                    {
                        if (e.Node.ParentNode == this.mNode2)
                        {
                            if (e.Node.GetDisplayText(3) == "可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit22;
                            }
                            else if (e.Node.GetDisplayText(3) == "不可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit2;
                            }
                            else
                            {
                                e.RepositoryItem = null;
                            }
                        }
                        else
                        {
                            e.RepositoryItem = null;
                        }
                        this.mSelected = false;
                        return;
                    }
                    if ((e.Node.Tag != null) && (e.Node.Tag is ArrayList))
                    {
                        if (e.Node.GetDisplayText(3) == "可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit22;
                        }
                        else if (e.Node.GetDisplayText(3) == "不可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit2;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn7")
                {
                    if (((e.Node.Tag != null) && (e.Node.ParentNode == this.mNode2)) && (e.Node.GetDisplayText(3) == "可见"))
                    {
                        e.RepositoryItem = this.mCurItemImageEdit4;
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn8")
                {
                    if ((((e.Node.Tag != null) && (e.Node.Nodes.Count == 0)) && (e.Node.ParentNode == this.mNode2)) && (e.Node.GetDisplayText(3) == "可见"))
                    {
                        e.RepositoryItem = this.mCurItemImageEdit5;
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tListKind_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tListKind_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.column = e.Column.AbsoluteIndex;
        }

        private void tListKind_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNode3 = e.Node;
        }

        private void tListKind_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num;
                if (this.tListKind.Selection.Count != 0)
                {
                    if (this.tListKind.Selection[0].ParentNode == null)
                    {
                        this.tListKind.Selection[0].SelectImageIndex = 0;
                        this.tListKind.Selection[0].ImageIndex = 0;
                        this.EditFlag = true;
                        goto Label_00B3;
                    }
                    this.tListKind.Selection[0].SelectImageIndex = -1;
                    this.tListKind.Selection[0].ImageIndex = -1;
                }
                return;
            Label_00B3:
                this.mNode2 = this.tListKind.Selection[0];
                this.mNode2.ExpandAll();
                this.mNode3 = this.mNode2.Nodes[0];
                if (this.mNode2.Tag != null)
                {
                    if (this.mNode2.Tag is IFeatureLayer)
                    {
                        EditTask.UnderLayer = this.mNode2.Tag as IFeatureLayer;
                    }
                    else if (this.mNode2.Tag is ArrayList)
                    {
                        ArrayList tag = this.mNode2.Tag as ArrayList;
                        for (num = 0; num < tag.Count; num++)
                        {
                            if (tag[num] is IFeatureLayer)
                            {
                                EditTask.UnderLayer = tag[num] as IFeatureLayer;
                            }
                        }
                    }
                }
                this.mEditKindCode = "";
                EditTask.KindCode = "08";
                if (this.mNode3.GetDisplayText(0).Contains("造林"))
                {
                    this.mEditKindCode = "ZaoLin";
                }
                if (this.mNode3.GetDisplayText(0).Contains("采伐"))
                {
                    this.mEditKindCode = "CaiFa";
                }
                if (this.mNode3.GetDisplayText(0).Contains("火灾"))
                {
                    this.mEditKindCode = "Fire";
                }
                if (this.mNode3.GetDisplayText(0).Contains("征占用"))
                {
                    this.mEditKindCode = "ZZY";
                }
                if (this.mNode3.GetDisplayText(0).Contains("自然灾害"))
                {
                    this.mEditKindCode = "ZRZH";
                }
                if (this.mNode3.GetDisplayText(0).Contains("林业工程"))
                {
                    this.mEditKindCode = "LYGC";
                }
                if (this.mNode3.GetDisplayText(0).Contains("林业案件"))
                {
                    this.mEditKindCode = "LYAJ";
                }
                if (this.mNode3.GetDisplayText(0).Contains("自然因素"))
                {
                    this.mEditKindCode = "ZRYS";
                }
                if (this.mNode3.GetDisplayText(0).Contains("调查因素"))
                {
                    this.mEditKindCode = "DCYS";
                }
                EditTask.TaskName = this.mNode2.GetDisplayText(0);
                for (num = 0; num < this.tListKind.Nodes.Count; num++)
                {
                    if (!this.tListKind.Nodes[num].Equals(this.mNode2))
                    {
                        this.tListKind.Nodes[num].SelectImageIndex = -1;
                        this.tListKind.Nodes[num].ImageIndex = -1;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void tListKind_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditFlag && (e.X >= this.tListKind.Columns[0].Width))
                {
                    ArrayList tag;
                    if (this.column == 1)
                    {
                        if ((((this.mNode2 != null) && (this.mNode2 == this.mNode3.ParentNode)) && (this.mNode3.Nodes.Count == 0)) && ((this.mNode3.Tag as ArrayList).Count < 3))
                        {
                            FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                            data.ShowDialog(this);
                            if (data.LayerList != null)
                            {
                                tag = this.mNode3.Tag as ArrayList;
                                if (data.LayerList.Count > 0)
                                {
                                    if (tag.Count == 1)
                                    {
                                        tag.Add(data.LayerList[0]);
                                    }
                                    else
                                    {
                                        tag[1] = data.LayerList[0];
                                    }
                                    this.mNode3.SetValue(3, "不可见");
                                }
                            }
                            if (this.mNode2.Tag == null)
                            {
                            }
                        }
                    }
                    else
                    {
                        int num;
                        IFeatureLayer layer2;
                        if (this.column == 2)
                        {
                            if (this.mNode2 != null)
                            {
                                tag = this.mNode2.Tag as ArrayList;
                                string str = "";
                                if (this.mNode2.Tag != null)
                                {
                                    if (tag != null)
                                    {
                                        str = tag[0].ToString();
                                    }
                                    else
                                    {
                                        str = this.mNode2.Tag.ToString();
                                    }
                                }
                                if (this.mNode3 != null)
                                {
                                    tag = this.mNode3.Tag as ArrayList;
                                }
                                if (tag != null)
                                {
                                    IFeatureClass featureClass;
                                    ILayer layer3;
                                    string str2 = "XB";
                                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "GroupName");
                                    IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                                    if (this.mNode3.GetDisplayText(3) == "不可见")
                                    {
                                        for (num = 0; num < tag.Count; num++)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer2 = tag[num] as IFeatureLayer;
                                                layer3 = tag[num] as ILayer;
                                                if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, layer3.Name, true) == null)
                                                {
                                                    pGroupLayer.Add(layer3);
                                                }
                                                layer3.Visible = true;
                                                break;
                                            }
                                            if (tag[num] is IFeatureClass)
                                            {
                                            }
                                        }
                                        pGroupLayer.Visible = true;
                                        this.mHookHelper.ActiveView.Refresh();
                                        this.mNode3.SetValue(3, "可见");
                                    }
                                    else
                                    {
                                        num = 0;
                                        while (num < tag.Count)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer3 = tag[num] as ILayer;
                                                layer3.Visible = false;
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            else if (tag[num] is IFeatureClass)
                                            {
                                                featureClass = tag[num] as IFeatureClass;
                                                layer3 = null;
                                                ICompositeLayer layer5 = pGroupLayer as ICompositeLayer;
                                                for (int i = 0; i < layer5.Count; i++)
                                                {
                                                    layer3 = layer5.get_Layer(i);
                                                    layer2 = layer3 as IFeatureLayer;
                                                    if (layer2.FeatureClass.Equals(featureClass))
                                                    {
                                                        layer3.Visible = false;
                                                    }
                                                }
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            num++;
                                        }
                                        this.mNode3.SetValue(3, "不可见");
                                    }
                                }
                            }
                        }
                        else if (this.column == 4)
                        {
                            tag = this.mNode3.Tag as ArrayList;
                            for (num = 0; num < tag.Count; num++)
                            {
                                IEnvelope areaOfInterest;
                                IFeatureClass class3 = null;
                                layer2 = null;
                                if (tag[num] is IFeatureLayer)
                                {
                                    layer2 = tag[num] as IFeatureLayer;
                                    areaOfInterest = layer2.AreaOfInterest;
                                    areaOfInterest.Expand(1.25, 1.25, true);
                                    this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                    this.mHookHelper.ActiveView.Refresh();
                                    return;
                                }
                                if (tag[num] is IFeatureClass)
                                {
                                    class3 = tag[num] as IFeatureClass;
                                    areaOfInterest = (class3 as IGeoDataset).Extent;
                                    if (!areaOfInterest.IsEmpty)
                                    {
                                        areaOfInterest.Expand(1.25, 1.25, true);
                                        this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                        this.mHookHelper.ActiveView.Refresh();
                                    }
                                    return;
                                }
                            }
                        }
                        else if ((this.column == 5) && (this.mNode3.ParentNode == this.mNode2))
                        {
                            this.GetFeatureList();
                            if (this.mQueryList != null)
                            {
                                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, null, null);
                                this.mDockPanel.Visibility = DockVisibility.Visible;
                                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                                {
                                    XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                                    if (control != null)
                                    {
                                        this.mDockPanel.Text = "编辑底图信息";
                                        if (control.TabPages[0].Tooltip == "作业设计信息")
                                        {
                                            control.TabPages[0].PageVisible = false;
                                        }
                                        if (control.TabPages[1].Tooltip == "查询结果列表")
                                        {
                                            control.TabPages[1].PageVisible = true;
                                            control.SelectedTabPage = control.TabPages[1];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void tListKind_Resize(object sender, EventArgs e)
        {
            try
            {
                this.tListKind.Columns[0].Width = this.tListKind.Width - 0x76;
                this.tListKind.Columns[1].Width = 0x18;
                this.tListKind.Columns[2].Width = 0x16;
                this.tListKind.Columns[4].Width = 0x16;
                this.tListKind.Columns[5].Width = 0x16;
            }
            catch (Exception)
            {
            }
        }

        private void ZoomToFeature(IMap pMap, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shapeCopy = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                    {
                        shapeCopy.Project(this.mHookHelper.FocusMap.SpatialReference);
                        shapeCopy.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shapeCopy.Envelope;
                    view = pMap as IActiveView;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shapeCopy as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.FullExtent = envelope;
                        view.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

