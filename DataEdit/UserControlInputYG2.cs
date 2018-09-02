namespace DataEdit
{
    using AttributesEdit;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;
    using td.db.mid.sys;

    public class UserControlInputYG2 : UserControlBase1
    {
        private int column = -1;
        private int column0 = -1;
        private IContainer components = null;
        internal ImageList imageList0;
        private ImageList imageList1;
        internal ImageList imageList2;
        internal ImageList imageList7;
        private Label label1;
        private Label labelCount;
        private Label labelIdentify;
        private Label labelprogress;
        private IFeature m_CountyFeature;
        private IFeatureLayer m_DistLayer;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_YGLayer;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "DataEdit.UserControlInputYG";
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
        private IHookHelper mHookHelper;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private ArrayList mQueryList = null;
        private ArrayList mQueryList2 = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private bool mStopList = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        private PanelControl panelControl1;
        private Panel panelList;
        private Panel panelLog;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonCheck;
        public SimpleButton simpleButtonInfo;
        public SimpleButton simpleButtonlist;
        public SimpleButton simpleButtonOK;
        private TreeList tList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;

        public UserControlInputYG2()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DoInput(IWorkspaceEdit pWorkspaceEdit, IFeatureClass pSFeatureClass, IFeatureClass pTFeatureClass)
        {
            try
            {
                int num5;
                string aliasName = pSFeatureClass.AliasName;
                IFeatureCursor cursor = pSFeatureClass.Search(null, false);
                IFeature feature = cursor.NextFeature();
                pWorkspaceEdit.StartEditing(false);
                pWorkspaceEdit.StartEditOperation();
                Application.DoEvents();
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.simpleButtonOK.Visible = false;
                this.labelprogress.Text = "     清除变更小班数据...";
                this.labelprogress.ImageIndex = 0x44;
                this.labelprogress.Visible = true;
                if (this.richTextBox.Text != "")
                {
                    this.richTextBox.Text = this.richTextBox.Text + "\n清除变更小班数据";
                }
                else
                {
                    this.richTextBox.Text = "清除变更小班数据";
                }
                Application.DoEvents();
                IDataset dataset = pTFeatureClass as IDataset;
                dataset.Workspace.ExecuteSQL("delete from " + dataset.Name);
                IFeatureCursor cursor2 = pTFeatureClass.Search(null, false);
                for (IFeature feature2 = cursor2.NextFeature(); feature2 != null; feature2 = cursor2.NextFeature())
                {
                    feature2.Delete();
                    feature2.Store();
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                    pWorkspaceEdit.StopEditing(true);
                    pWorkspaceEdit.StartEditing(false);
                    pWorkspaceEdit.StartEditOperation();
                    this.richTextBox.Text = this.richTextBox.Text + "- 成功";
                }
                catch (Exception)
                {
                    this.richTextBox.Text = this.richTextBox.Text + "- 失败";
                }
                int num = 0;
                int num2 = 0;
                while (feature != null)
                {
                    this.labelprogress.Text = "     清除变更小班数据 - 成功\n导入遥感检测变化图层数据...";
                    this.labelprogress.ImageIndex = 0x44;
                    this.labelprogress.Visible = true;
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                    }
                    else
                    {
                        this.richTextBox.Text = "导入要素" + feature.OID;
                    }
                    this.richTextBox.Refresh();
                    this.richTextBox.Refresh();
                    num++;
                    num2++;
                    this.labelprogress.Text = "     清除变更小班数据 - 成功\n导入遥感检测变化图层数据" + num + "个班块";
                    this.labelprogress.ImageIndex = 0x44;
                    Application.DoEvents();
                    IFeature feature3 = this.m_EditLayer.FeatureClass.CreateFeature();
                    IClone shape = (IClone) feature.Shape;
                    if (shape == null)
                    {
                        return;
                    }
                    IPolygon polygon = (IPolygon) shape.Clone();
                    try
                    {
                        feature3.Shape = new PolygonClass();
                        feature3.Shape = polygon;
                    }
                    catch (Exception)
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                        goto Label_052E;
                    }
                    string oIDFieldName = pSFeatureClass.OIDFieldName;
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGInputFieldName");
                    int index = feature.Fields.FindField(oIDFieldName);
                    int num4 = feature3.Fields.FindField(configValue);
                    feature3.set_Value(num4, feature.get_Value(index));
                    num5 = 0;
                    while (num5 < feature3.Fields.FieldCount)
                    {
                        if (((feature3.Fields.get_Field(num5).Name != pTFeatureClass.OIDFieldName) && (feature3.Fields.get_Field(num5).Name != pTFeatureClass.LengthField.Name)) && (feature3.Fields.get_Field(num5).Name != pTFeatureClass.AreaField.Name))
                        {
                            string name = feature3.Fields.get_Field(num5).Name;
                            int num6 = feature.Fields.FindField(name);
                            if (num6 > -1)
                            {
                                feature3.set_Value(num5, feature.get_Value(num6));
                            }
                        }
                        num5++;
                    }
                    int num7 = feature3.Fields.FindField("DT_SRC");
                    if (num7 > -1)
                    {
                        feature3.set_Value(num7, "99");
                    }
                    try
                    {
                        Editor.UniqueInstance.AddAttribute = false;
                        feature3.Store();
                        Editor.UniqueInstance.AddAttribute = true;
                        if (num2 >= 50)
                        {
                            try
                            {
                                pWorkspaceEdit.StopEditOperation();
                            }
                            catch (Exception)
                            {
                                pWorkspaceEdit.StopEditOperation();
                            }
                            pWorkspaceEdit.StopEditing(true);
                            pWorkspaceEdit.StartEditing(false);
                            pWorkspaceEdit.StartEditOperation();
                            num2 = 0;
                        }
                    }
                    catch (Exception)
                    {
                        this.labelprogress.Text = "     清除变更小班数据 - 成功\n导入遥感检测变化图层数据[失败]";
                        this.labelprogress.ImageIndex = 0x43;
                        Editor.UniqueInstance.AddAttribute = false;
                        feature3.Store();
                        Editor.UniqueInstance.AddAttribute = true;
                    }
                Label_052E:
                    feature = cursor.NextFeature();
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                catch (Exception)
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                pWorkspaceEdit.StopEditing(true);
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                //DataTable dataTable = null;
                //dataTable = dBAccess.GetDataTable(dBAccess, "select * from T_EditTask");
               IList<T_EDITTASK_Mid> lst= PM.TaskMetaService.FindAll();
               for (num5 = 0; num5 < lst.Count; num5++)
                {
                    T_EDITTASK_Mid mid = lst[0];
                    //string sCmdText = "update T_EditTask set EditState='0' where ID= " + dataTable.Rows[num5]["ID"].ToString();
                    //dBAccess.ExecuteScalar(sCmdText);
                    //sCmdText = "update T_EditTask  set logiccheckstate='0' where ID= " + dataTable.Rows[num5]["ID"].ToString();
                    //dBAccess.ExecuteScalar(sCmdText);
                    //sCmdText = "update T_EditTask  set toplogiccheckstate='0' where ID= " + dataTable.Rows[num5]["ID"].ToString();
                    //dBAccess.ExecuteScalar(sCmdText);
                }
                this.labelprogress.Text = "     清除变更小班数据 - 成功\n导入遥感检测变化图层数据 - 完成,成功导入" + num + "个";
                this.labelprogress.ImageIndex = 0x42;
                this.labelprogress.Visible = true;
                MessageBox.Show("导入遥感检测变化图层数据完成,成功导入" + num + "个", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "DoInput", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
        private ProjectManager PM
        {
            get
            {
                return DBServiceFactory<ProjectManager>.Service;
            }
        }
        private void GetFeatureList()
        {
            try
            {
                this.mQueryList = null;
                IFeatureClass class2 = null;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = "";
                GC.Collect();
                IFeatureCursor cursor = class2.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                this.mQueryList = new ArrayList();
                while (feature != null)
                {
                    this.mQueryList.Add(feature);
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string GetFiledValue(int index, IFeature pf)
        {
            string str2;
            string str = "";
            try
            {
                if (index == -1)
                {
                    return "";
                }
                IField field = pf.Fields.get_Field(index);
                str = pf.get_Value(index).ToString();
                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                {
                    str = "";
                    try
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                        long num = Convert.ToInt64(pf.get_Value(index));
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            if (num == Convert.ToInt64(domain.get_Value(i)))
                            {
                                str = domain.get_Name(i);
                                goto Label_00E9;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        str = pf.get_Value(index).ToString();
                    }
                }
                else
                {
                    str = pf.get_Value(index).ToString();
                }
            Label_00E9:
                str2 = str;
            }
            catch (Exception)
            {
                str2 = str;
            }
            return str2;
        }

        public void Hook(object hook, IFeatureLayer pYGLayer, IFeature pCountyFeature, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_YGLayer = pYGLayer;
                this.m_CountyFeature = pCountyFeature;
                this.mQueryResult = pResult;
                this.mQueryResult2 = pResult2;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlInputYG2));
            this.label1 = new Label();
            this.labelCount = new Label();
            this.tList = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new RepositoryItemImageEdit();
            this.panel6 = new Panel();
            this.simpleButtonCheck = new SimpleButton();
            this.imageList2 = new ImageList(this.components);
            this.panel2 = new Panel();
            this.simpleButtonBack = new SimpleButton();
            this.simpleButtonOK = new SimpleButton();
            this.imageList1 = new ImageList(this.components);
            this.panel1 = new Panel();
            this.simpleButtonInfo = new SimpleButton();
            this.imageList0 = new ImageList(this.components);
            this.imageList7 = new ImageList(this.components);
            this.labelIdentify = new Label();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel4 = new Panel();
            this.labelprogress = new Label();
            this.panelList = new Panel();
            this.panel3 = new Panel();
            this.simpleButtonlist = new SimpleButton();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageComboBox1.BeginInit();
            this.repositoryItemPictureEdit1.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemImageEdit3.BeginInit();
            this.repositoryItemImageEdit33.BeginInit();
            this.panel6.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panel3.SuspendLayout();
            base.SuspendLayout();
            this.label1.Dock = DockStyle.Top;
            this.label1.ForeColor = Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10c, 0x18);
            this.label1.TabIndex = 0;
            this.label1.Text = "清除所有变更小班，导入遥感检测变化数据";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCount.Dock = DockStyle.Bottom;
            this.labelCount.ForeColor = Color.Navy;
            this.labelCount.Location = new System.Drawing.Point(0, 2);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new Size(0xda, 0x16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "遥感检测变化数据  共计n个班块";
            this.labelCount.TextAlign = ContentAlignment.MiddleLeft;
            this.tList.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5 });
            this.tList.Dock = DockStyle.Fill;
            this.tList.Location = new System.Drawing.Point(0, 0x1c);
            this.tList.Name = "tList";
            this.tList.BeginUnboundLoad();
            object[] nodeData = new object[5];
            nodeData[0] = "1";
            nodeData[1] = "XX县";
            this.tList.AppendNode(nodeData, -1, 0, 0, 5);
            this.tList.EndUnboundLoad();
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageComboBox1, this.repositoryItemPictureEdit1, this.repositoryItemButtonEdit1, this.repositoryItemImageEdit3, this.repositoryItemImageEdit33 });
            this.tList.Size = new Size(0x10c, 0x157);
            this.tList.TabIndex = 5;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.MouseUp += new MouseEventHandler(this.tList_MouseUp);
            this.tList.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList_CustomNodeCellEdit);
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.treeListColumn1.Caption = "遥感ID";
            this.treeListColumn1.FieldName = "遥感ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 60;
            this.treeListColumn2.Caption = "县";
            this.treeListColumn2.FieldName = "县";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 70;
            this.treeListColumn3.Caption = "乡";
            this.treeListColumn3.FieldName = "乡";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 70;
            this.treeListColumn4.Caption = "村";
            this.treeListColumn4.FieldName = "村";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 70;
            this.treeListColumn5.Caption = "定位";
            this.treeListColumn5.FieldName = "定位";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 30;
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageComboBox1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.Appearance.Image");
            this.repositoryItemImageComboBox1.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AppearanceFocused.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.AppearanceFocused.Image");
            this.repositoryItemImageComboBox1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.ButtonsStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemPictureEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemPictureEdit1.Appearance.Image");
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Plus) });
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            this.repositoryItemImageEdit3.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit33.AutoHeight = false;
            this.repositoryItemImageEdit33.Name = "repositoryItemImageEdit33";
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonCheck);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonInfo);
            this.panel6.Dock = DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(6, 0x1a9);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 6, 0, 6);
            this.panel6.Size = new Size(0x10c, 0x26);
            this.panel6.TabIndex = 0x17;
            this.simpleButtonCheck.Dock = DockStyle.Right;
            this.simpleButtonCheck.ImageIndex = 6;
            this.simpleButtonCheck.ImageList = this.imageList2;
            this.simpleButtonCheck.Location = new System.Drawing.Point(0, 6);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x48, 0x1a);
            this.simpleButtonCheck.TabIndex = 13;
            this.simpleButtonCheck.Text = "数据校验";
            this.simpleButtonCheck.ToolTip = "校验遥感数据是否有重叠班块,变化原因是否填写";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "blank16.ico");
            this.imageList2.Images.SetKeyName(1, "tick16.ico");
            this.imageList2.Images.SetKeyName(2, "PART16.ICO");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            this.imageList2.Images.SetKeyName(0x10, "(30,24).png");
            this.imageList2.Images.SetKeyName(0x11, "(00,02).png");
            this.imageList2.Images.SetKeyName(0x12, "(00,17).png");
            this.imageList2.Images.SetKeyName(0x13, "(00,46).png");
            this.imageList2.Images.SetKeyName(20, "(01,10).png");
            this.imageList2.Images.SetKeyName(0x15, "(01,25).png");
            this.imageList2.Images.SetKeyName(0x16, "(05,32).png");
            this.imageList2.Images.SetKeyName(0x17, "(06,32).png");
            this.imageList2.Images.SetKeyName(0x18, "(07,32).png");
            this.imageList2.Images.SetKeyName(0x19, "(08,32).png");
            this.imageList2.Images.SetKeyName(0x1a, "(08,36).png");
            this.imageList2.Images.SetKeyName(0x1b, "(09,36).png");
            this.imageList2.Images.SetKeyName(0x1c, "(10,26).png");
            this.imageList2.Images.SetKeyName(0x1d, "(11,26).png");
            this.imageList2.Images.SetKeyName(30, "(11,29).png");
            this.imageList2.Images.SetKeyName(0x1f, "(12,29).png");
            this.imageList2.Images.SetKeyName(0x20, "(11,32).png");
            this.imageList2.Images.SetKeyName(0x21, "(11,36).png");
            this.imageList2.Images.SetKeyName(0x22, "(13,32).png");
            this.imageList2.Images.SetKeyName(0x23, "(19,31).png");
            this.imageList2.Images.SetKeyName(0x24, "(22,18).png");
            this.imageList2.Images.SetKeyName(0x25, "(25,27).png");
            this.imageList2.Images.SetKeyName(0x26, "(29,43).png");
            this.imageList2.Images.SetKeyName(0x27, "(30,14).png");
            this.imageList2.Images.SetKeyName(40, "5.png");
            this.imageList2.Images.SetKeyName(0x29, "10.png");
            this.imageList2.Images.SetKeyName(0x2a, "11.png");
            this.imageList2.Images.SetKeyName(0x2b, "16.png");
            this.imageList2.Images.SetKeyName(0x2c, "17.png");
            this.imageList2.Images.SetKeyName(0x2d, "18.png");
            this.imageList2.Images.SetKeyName(0x2e, "19.png");
            this.imageList2.Images.SetKeyName(0x2f, "20.png");
            this.imageList2.Images.SetKeyName(0x30, "21.png");
            this.imageList2.Images.SetKeyName(0x31, "22.png");
            this.imageList2.Images.SetKeyName(50, "25.png");
            this.imageList2.Images.SetKeyName(0x33, "31.png");
            this.imageList2.Images.SetKeyName(0x34, "41.png");
            this.imageList2.Images.SetKeyName(0x35, "add.png");
            this.imageList2.Images.SetKeyName(0x36, "bullet_minus.png");
            this.imageList2.Images.SetKeyName(0x37, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x38, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x3a, "cross.png");
            this.imageList2.Images.SetKeyName(0x3b, "down.png");
            this.imageList2.Images.SetKeyName(60, "draw_tools.png");
            this.imageList2.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.imageList2.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.imageList2.Images.SetKeyName(0x42, "flag blue.png");
            this.imageList2.Images.SetKeyName(0x43, "flag red.png");
            this.imageList2.Images.SetKeyName(0x44, "flag yellow.png");
            this.imageList2.Images.SetKeyName(0x45, "31.png");
            this.imageList2.Images.SetKeyName(70, "42.png");
            this.imageList2.Images.SetKeyName(0x47, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x49, "cursor.png");
            this.imageList2.Images.SetKeyName(0x4a, "cursor_small.png");
            this.imageList2.Images.SetKeyName(0x4b, "cut.png");
            this.imageList2.Images.SetKeyName(0x4c, "cut_red.png");
            this.imageList2.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.imageList2.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.imageList2.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x52, "key.png");
            this.imageList2.Images.SetKeyName(0x53, "page_add.png");
            this.imageList2.Images.SetKeyName(0x54, "page_delete.png");
            this.imageList2.Images.SetKeyName(0x55, "page_white_world.png");
            this.imageList2.Images.SetKeyName(0x56, "page_world.png");
            this.imageList2.Images.SetKeyName(0x57, "reload.png");
            this.imageList2.Images.SetKeyName(0x58, "world_add.png");
            this.imageList2.Images.SetKeyName(0x59, "world_delete.png");
            this.imageList2.Images.SetKeyName(90, "zoom_in.png");
            this.imageList2.Images.SetKeyName(0x5b, "zoom_out.png");
            this.imageList2.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.imageList2.Images.SetKeyName(0x5e, "Exit.png");
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0x48, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(8, 0x1a);
            this.panel2.TabIndex = 14;
            this.simpleButtonBack.Dock = DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 0x2e;
            this.simpleButtonBack.ImageList = this.imageList2;
            this.simpleButtonBack.Location = new System.Drawing.Point(80, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new Size(60, 0x1a);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new EventHandler(this.simpleButtonBack_Click);
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonOK.ImageIndex = 7;
            this.simpleButtonOK.ImageList = this.imageList1;
            this.simpleButtonOK.Location = new System.Drawing.Point(140, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(60, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "导入";
            this.simpleButtonOK.ToolTip = "导入遥感变化数据";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "20.bmp");
            this.imageList1.Images.SetKeyName(1, "AppDocSave_16.bmp");
            this.imageList1.Images.SetKeyName(2, "BD21298_.GIF");
            this.imageList1.Images.SetKeyName(3, "BPosE.gif");
            this.imageList1.Images.SetKeyName(4, "layer_7_.bmp");
            this.imageList1.Images.SetKeyName(5, "digilin.bmp");
            this.imageList1.Images.SetKeyName(6, "digipnt.bmp");
            this.imageList1.Images.SetKeyName(7, "digipol.bmp");
            this.imageList1.Images.SetKeyName(8, "DisplayXBList.bmp");
            this.imageList1.Images.SetKeyName(9, "EditorsUnboundMode3.bmp");
            this.imageList1.Images.SetKeyName(10, "Fault.bmp");
            this.imageList1.Images.SetKeyName(11, "查看.bmp");
            this.imageList1.Images.SetKeyName(12, "图标10.ico");
            this.imageList1.Images.SetKeyName(13, "PushMsgInfo.ico");
            this.imageList1.Images.SetKeyName(14, "complain.ico");
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(200, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(8, 0x1a);
            this.panel1.TabIndex = 11;
            this.simpleButtonInfo.Dock = DockStyle.Right;
            this.simpleButtonInfo.ImageIndex = 13;
            this.simpleButtonInfo.ImageList = this.imageList1;
            this.simpleButtonInfo.Location = new System.Drawing.Point(0xd0, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(60, 0x1a);
            this.simpleButtonInfo.TabIndex = 9;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.ToolTip = "详细信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.imageList0.ImageStream = (ImageListStreamer) resources.GetObject("imageList0.ImageStream");
            this.imageList0.TransparentColor = Color.Transparent;
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
            this.imageList7.ImageStream = (ImageListStreamer) resources.GetObject("imageList7.ImageStream");
            this.imageList7.TransparentColor = Color.Transparent;
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
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(6, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(0x10c, 30);
            this.labelIdentify.TabIndex = 0x18;
            this.labelIdentify.Text = "      导入遥感数据";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel4);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(6, 0x36);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0x10c, 0x173);
            this.panelLog.TabIndex = 0x1d;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x10c, 0x13d);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x108, 0x139);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new Padding(0, 4, 0, 4);
            this.panel4.Size = new Size(0x10c, 0x30);
            this.panel4.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.ForeColor = Color.Blue;
            this.labelprogress.ImageAlign = ContentAlignment.TopLeft;
            this.labelprogress.ImageIndex = 0x44;
            this.labelprogress.ImageList = this.imageList2;
            this.labelprogress.Location = new System.Drawing.Point(0, 4);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0x10c, 40);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "     生成进度:";
            this.panelList.Controls.Add(this.tList);
            this.panelList.Controls.Add(this.panel3);
            this.panelList.Dock = DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(6, 0x36);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new Padding(0, 2, 0, 0);
            this.panelList.Size = new Size(0x10c, 0x173);
            this.panelList.TabIndex = 30;
            this.panel3.Controls.Add(this.labelCount);
            this.panel3.Controls.Add(this.simpleButtonlist);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 2, 0, 2);
            this.panel3.Size = new Size(0x10c, 0x1a);
            this.panel3.TabIndex = 6;
            this.simpleButtonlist.Dock = DockStyle.Right;
            this.simpleButtonlist.ImageIndex = 7;
            this.simpleButtonlist.ImageList = this.imageList2;
            this.simpleButtonlist.Location = new System.Drawing.Point(0xda, 2);
            this.simpleButtonlist.Name = "simpleButtonlist";
            this.simpleButtonlist.Size = new Size(50, 0x16);
            this.simpleButtonlist.TabIndex = 10;
            this.simpleButtonlist.Text = "列表";
            this.simpleButtonlist.ToolTip = "显示遥感班块列表";
            this.simpleButtonlist.Click += new EventHandler(this.simpleButtonlist_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelLog);
            base.Controls.Add(this.panelList);
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlInputYG";
            base.Padding = new Padding(6, 0, 6, 0);
            base.Size = new Size(280, 0x1cf);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageComboBox1.EndInit();
            this.repositoryItemPictureEdit1.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemImageEdit3.EndInit();
            this.repositoryItemImageEdit33.EndInit();
            this.panel6.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitialTreeList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
                this.mQueryList.Clear();
                IQueryFilter filter = new QueryFilterClass();
                IFeatureCursor cursor = this.m_YGLayer.FeatureClass.Search(filter, false);
                IFeature pf = cursor.NextFeature();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int index = pf.Fields.FindField(configValue);
                if (index == -1)
                {
                    index = 0;
                }
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldDist").Split(new char[] { ',' });
                while (pf != null)
                {
                    node3 = this.tList.AppendNode(pf.get_Value(index).ToString(), parentNode);
                    node3.ImageIndex = 1;
                    node3.StateImageIndex = 3;
                    node3.SelectImageIndex = 1;
                    node3.SetValue(0, pf.get_Value(index).ToString());
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num3 = pf.Fields.FindField(strArray[i]);
                        if (num3 > -1)
                        {
                            node3.SetValue(i + 1, this.GetFiledValue(num3, pf));
                        }
                    }
                    node3.Tag = pf;
                    this.mQueryList.Add(pf);
                    Application.DoEvents();
                    if (this.mStopList)
                    {
                        this.simpleButtonlist.ImageIndex = 7;
                        this.simpleButtonlist.Text = "列表";
                        this.simpleButtonlist.ToolTip = "显示遥感班块列表";
                        break;
                    }
                    pf = cursor.NextFeature();
                }
                this.Cursor = Cursors.Default;
                if (this.mQueryList.Count > 0)
                {
                    this.simpleButtonInfo.Enabled = true;
                }
                else
                {
                    this.simpleButtonInfo.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                this.panelLog.Visible = false;
                this.panelList.BringToFront();
                this.simpleButtonBack.Visible = false;
                this.simpleButtonOK.Visible = true;
                this.simpleButtonOK.Enabled = false;
                this.simpleButtonCheck.Visible = true;
                this.simpleButtonInfo.Enabled = false;
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_CountyFeature == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.m_DistLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IFeatureLayer;
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    if (this.m_DistLayer != null)
                    {
                        GC.Collect();
                        IQueryFilter queryFilter = new QueryFilterClass();
                        string str3 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                        queryFilter.WhereClause = str3 + "='" + EditTask.DistCode.Substring(0, 6) + "'";
                        this.m_CountyFeature = this.m_DistLayer.Search(queryFilter, false).NextFeature();
                    }
                }
                int num = this.m_YGLayer.FeatureClass.FeatureCount(null);
                this.labelCount.Text = "遥感检测变化数据 共计" + num + "个班块";
                this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                this.mCurItemImageEdit0.Images = this.imageList0;
                this.mQueryList = new ArrayList();
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private IFeatureClass Intersect(IList<IFeatureClass> pFCList, string sFile)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                if ((pFCList == null) || (pFCList.Count < 1))
                {
                    return null;
                }
                IGpValueTableObject obj2 = new GpValueTableObjectClass();
                obj2.SetColumns(1);
                object row = null;
                for (int i = 0; i < pFCList.Count; i++)
                {
                    row = pFCList[i];
                    obj2.AddRow(ref row);
                }
                if (!(Directory.Exists(System.IO.Path.GetDirectoryName(sFile)) && (".shp" == System.IO.Path.GetExtension(sFile))))
                {
                    return null;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Intersect process = new ESRI.ArcGIS.AnalysisTools.Intersect(obj2, sFile);
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                return class2;
            }
            catch
            {
                return null;
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.panelList.BringToFront();
            this.simpleButtonBack.Visible = false;
            this.simpleButtonOK.Visible = true;
            this.simpleButtonCheck.Visible = true;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool flag = true;
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.labelprogress.Text = "检查是否有重叠相交小班...";
                this.labelprogress.Visible = true;
                IList<IFeatureClass> pFCList = new List<IFeatureClass>();
                pFCList.Add(this.m_YGLayer.FeatureClass);
                string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                string sFile = str + @"\ygintersect.shp";
                if (File.Exists(str + "ygintersect.shp"))
                {
                    File.Delete(str + "ygintersect.shp");
                }
                if (File.Exists(str + "ygintersect.dbf"))
                {
                    File.Delete(str + "ygintersect.dbf");
                }
                if (File.Exists(str + "ygintersect.sbn"))
                {
                    File.Delete(str + "ygintersect.sbn");
                }
                if (File.Exists(str + "ygintersect.sbx"))
                {
                    File.Delete(str + "ygintersect.sbx");
                }
                if (File.Exists(str + "ygintersect.shx"))
                {
                    File.Delete(str + "ygintersect.shx");
                }
                if (File.Exists(str + "ygintersect.shp.xml"))
                {
                    File.Delete(str + "ygintersect.shp.xml");
                }
                if (File.Exists(str + "ygintersect.prj"))
                {
                    File.Delete(str + "ygintersect.prj");
                }
                this.richTextBox.Text = "计算遥感图层相交班块";
                Application.DoEvents();
                IFeatureClass class2 = this.Intersect(pFCList, sFile);
                this.Cursor = Cursors.Default;
                int num = class2.FeatureCount(null);
                if (num > 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n遥感图层有", num, "个相交班块" });
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层有" + num + "个相交班块";
                    }
                    this.richTextBox.Refresh();
                    this.simpleButtonOK.Enabled = false;
                    flag = false;
                }
                else
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n遥感图层无相交要素";
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层无相交要素";
                    }
                    this.richTextBox.Refresh();
                }
                IFeatureClass featureClass = this.m_YGLayer.FeatureClass;
                if (this.m_CountyFeature != null)
                {
                    this.labelprogress.Text = "检查不在区划范围内的图斑...";
                    if (featureClass == null)
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "--失败";
                    }
                    IEnvelope extent = ((IGeoDataset) featureClass).Extent;
                    IPointCollection points = new PolygonClass();
                    object missing = System.Type.Missing;
                    object after = System.Type.Missing;
                    points.AddPoint(extent.LowerLeft, ref missing, ref after);
                    points.AddPoint(extent.UpperLeft, ref missing, ref after);
                    points.AddPoint(extent.UpperRight, ref missing, ref after);
                    points.AddPoint(extent.LowerRight, ref missing, ref after);
                    points.AddPoint(extent.LowerLeft, ref missing, ref after);
                    IPolygon polygon = points as IPolygon;
                    polygon.Close();
                    IGeometry other = null;
                    other = this.m_CountyFeature.ShapeCopy;
                    polygon.SpatialReference = other.SpatialReference;
                    ITopologicalOperator2 @operator = polygon as ITopologicalOperator2;
                    @operator.Simplify();
                    IGeometry geometry2 = @operator.Difference(other);
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.Geometry = geometry2;
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    filter.SubFields = featureClass.OIDFieldName + "," + featureClass.ShapeFieldName;
                    int num2 = featureClass.FeatureCount(filter);
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n遥感图层有", num2, "个不在区划范围内的班块" });
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层有" + num2 + "个不在区划范围内的班块";
                    }
                    this.richTextBox.Refresh();
                    if (num2 > 0)
                    {
                        this.simpleButtonOK.Enabled = false;
                        flag = false;
                    }
                }
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "BHYY=''";
                int num3 = featureClass.FeatureCount(queryFilter);
                if (this.richTextBox.Text != "")
                {
                    this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n遥感图层有", num3, "个变化原因未填写的班块" });
                }
                else
                {
                    this.richTextBox.Text = "遥感图层有" + num3 + "个变化原因未填写的班块";
                }
                this.richTextBox.Refresh();
                if (num3 > 0)
                {
                    this.simpleButtonOK.Enabled = false;
                    flag = false;
                }
                this.simpleButtonOK.Enabled = flag;
                if (this.simpleButtonOK.Enabled)
                {
                    this.labelprogress.Text = "遥感校验完成--通过校验，可导入小班变更图层。";
                }
                else
                {
                    this.labelprogress.Text = "遥感校验完成--未通过校验，请进入遥感专题修改后再做更新。";
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "simpleButtonCheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            XtraTabControl control;
            if (this.mQueryList != null)
            {
                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_YGLayer, this.mQueryList, null, this.sDesKeyField, null, null);
                this.mDockPanel.Visibility = DockVisibility.Visible;
                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                {
                    control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                    if (control != null)
                    {
                        this.mDockPanel.Text = "遥感判读班块信息";
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
                    else
                    {
                        this.mDockPanel.Text = "遥感判读班块信息";
                    }
                }
            }
            this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_EditLayer, null, null, this.sDesKeyField, null, null);
            if (this.mDockPanel.Controls[0].Controls.Count > 0)
            {
                control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                if (control != null)
                {
                    control.TabPages[1].PageVisible = true;
                }
                else
                {
                    this.mDockPanel.Text = "遥感判读班块信息";
                }
            }
        }

        private void simpleButtonlist_Click(object sender, EventArgs e)
        {
            if (this.simpleButtonlist.ImageIndex == 7)
            {
                this.simpleButtonlist.ImageIndex = 0x17;
                this.simpleButtonlist.Text = "停止";
                this.simpleButtonlist.ToolTip = "停止显示遥感班块列表";
                this.mStopList = false;
                this.mQueryList = new ArrayList();
                this.InitialTreeList();
            }
            else if (this.simpleButtonlist.ImageIndex == 0x17)
            {
                this.simpleButtonInfo.Enabled = true;
                this.mStopList = true;
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace != null)
                {
                    this.simpleButtonCheck.Enabled = false;
                    this.DoInput(editWorkspace, this.m_YGLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                    this.simpleButtonCheck.Enabled = true;
                    this.Cursor = Cursors.Default;
                    this.simpleButtonCheck.Visible = false;
                    this.simpleButtonBack.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "simpleButtonOK_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn5")
            {
                e.RepositoryItem = this.mCurItemImageEdit0;
            }
        }

        private void tList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.column = e.Column.AbsoluteIndex;
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                this.mNode = e.Node;
            }
        }

        private void tList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (((e.X >= this.tList.Columns[0].Width) && (this.column != 1)) && (this.column != 2))
                {
                    if (this.column == 4)
                    {
                        IFeature pFeature = null;
                        pFeature = this.mNode.Tag as IFeature;
                        GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                    }
                    else if (this.column == 5)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void ZTOverlap()
        {
            try
            {
                int num2;
                this.labelprogress.Text = this.labelprogress.Text + "\n计算遥感变化小班与专题数据相交情况...";
                this.labelprogress.Visible = true;
                this.richTextBox.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                IList<IFeatureLayer> pLayerList = new List<IFeatureLayer>();
                for (num2 = 0; num2 < EditTask.UnderLayers.Count; num2++)
                {
                    IFeatureLayer item = EditTask.UnderLayers[num2] as IFeatureLayer;
                    if (!item.Name.Contains("遥感"))
                    {
                        pLayerList.Add(item);
                    }
                }
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                DataTable dataTable = null;
              //  dataTable = dBAccess.GetDataTable(dBAccess, "select * from T_EditTask");
                for (num2 = 0; num2 < dataTable.Rows.Count; num2++)
                {
                    string sCmdText = "update T_EditTask set EditState='0' where ID= " + dataTable.Rows[num2]["ID"].ToString();
                    //dBAccess.ExecuteScalar(sCmdText);
                }
                Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.labelprogress.Text = "计算遥感变化小班与专题数据相交情况...";
                UpdateSub.FindZTOverlap(pLayerList);
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "ZTOverlap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

