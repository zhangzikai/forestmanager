namespace QueryAnalysic
{
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlQueryHisXB : UserControlBase1
    {
        private IContainer components;
        internal ImageList ImageList1;
        private ImageList imageList2;
        private Label labelLocation;
        private Label labelPosition;
        private XBPointTool m_pPointTool;
        private const string mClassName = "QueryAnalysic.UserControlQueryHisXB";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureLayer mHisLayer;
        private ITable mHisTable;
        private HookHelper mHookHelper;
        private IPoint mPoint;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IFeature mXBFeature;
        private IFeatureLayer mXBLayer;
        private ITable mXBTable;
        private ITable mXBTable2;
        private NavBarControl navBarControl1;
        private NavBarGroup navBarGroup1;
        private NavBarGroup navBarGroup2;
        private NavBarGroupControlContainer navBarGroupControlContainer1;
        private NavBarGroupControlContainer navBarGroupControlContainer2;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeList treeListHis;
        private TreeList treeListNow;

        public UserControlQueryHisXB()
        {
            this.InitializeComponent();
        }

        private void AddTableValue()
        {
        }

        private bool CheckFieldVisiable(string sname, string skeyvalue, bool flag)
        {
            try
            {
                if (skeyvalue == "")
                {
                    skeyvalue = "XiaobanFieldString2";
                }
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(skeyvalue).Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == sname)
                    {
                        return flag;
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "CheckFieldVisiable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private string GetDistName(string scode)
        {
            try
            {
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("CurrentDataPath");
                IFeatureWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                ITable table = null;
                if (scode.Length == 6)
                {
                    table = featureWorkspace.OpenTable(configValue);
                }
                else if (scode.Length == 9)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                    table = featureWorkspace.OpenTable(configValue);
                }
                else
                {
                    if (((scode.Length == 8) || (scode.Length == 10)) || (scode.Length == 12))
                    {
                        return scode.Substring(scode.Length - 2, 2);
                    }
                    if (scode.Length == 3)
                    {
                        return scode;
                    }
                }
                if (table != null)
                {
                    int num = table.FindField("code");
                    int index = table.FindField("name");
                    if ((num < 0) || (index < 0))
                    {
                        return "";
                    }
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "code='" + scode + "'";
                    IRow row = table.Search(queryFilter, false).NextRow();
                    if (row != null)
                    {
                        return row.get_Value(index).ToString();
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private ArrayList GetHisFeature(IFeature pf, IFeatureLayer player)
        {
            try
            {
                ArrayList list = new ArrayList();
                IFeatureClass featureClass = player.FeatureClass;
                new QueryFilterClass();
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pf.Shape.Envelope;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                IFeatureCursor cursor = featureClass.Search(filter, false);
                IFeature feature = null;
                if (cursor != null)
                {
                    try
                    {
                        feature = cursor.NextFeature();
                    }
                    catch (Exception)
                    {
                        feature = cursor.NextFeature();
                    }
                }
                while (feature != null)
                {
                    list.Add(feature);
                    feature = cursor.NextFeature();
                }
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                cursor = featureClass.Search(filter, false);
                if (cursor != null)
                {
                    feature = cursor.NextFeature();
                }
                while (feature != null)
                {
                    list.Add(feature);
                    feature = cursor.NextFeature();
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IEnvelope GetSearchEnvelope(ILayer pLayer, IPoint pPoint)
        {
            try
            {
                IActiveView pActiveView = null;
                pActiveView = this.mHookHelper.ActiveView;
                double num = 2.0;
                IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
                IEnvelope visibleBounds = displayTransformation.VisibleBounds;
                tagRECT deviceFrame = displayTransformation.get_DeviceFrame();
                double height = 0.0;
                long num3 = 0L;
                height = visibleBounds.Height;
                num3 = deviceFrame.bottom - deviceFrame.top;
                double num4 = 0.0;
                num4 = height / ((double) num3);
                num *= num4;
                if (pPoint == null)
                {
                    return null;
                }
                visibleBounds = pPoint.Envelope;
                if (pLayer is IFeatureLayer)
                {
                    IFeatureLayer layer = (IFeatureLayer) pLayer;
                    if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        visibleBounds.Width = num;
                        visibleBounds.Height = num;
                    }
                    else if ((layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryLine) | (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline))
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 4.0, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 4.0, false);
                    }
                    else if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 1.0 / num, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 1.0 / num, false);
                    }
                    else
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 2.0, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 2.0, false);
                    }
                }
                else
                {
                    IRasterLayer layer1 = pLayer as IRasterLayer;
                }
                visibleBounds.CenterAt(pPoint);
                return visibleBounds;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "GetSearchEnvelope", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private IRow GetTableRow(ITable pTable, string sKeyField, string sKeyValue)
        {
            string str = sKeyField + "='" + sKeyValue + "'";
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = str;
            ICursor cursor = pTable.Search(queryFilter, false);
            IRow row = cursor.NextRow();
            if (row != null)
            {
                int index = row.Fields.FindField(sKeyField);
                while (row != null)
                {
                    if (row.get_Value(index).ToString() == sKeyValue)
                    {
                        return row;
                    }
                    row = cursor.NextRow();
                }
            }
            return null;
        }

        private ArrayList GetTableRows(ITable pTable, string sKeyField, string sKeyValue)
        {
            string str = sKeyField + "='" + sKeyValue + "'";
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = str;
            ICursor cursor = pTable.Search(queryFilter, false);
            IRow row = cursor.NextRow();
            if (row == null)
            {
                return null;
            }
            int index = row.Fields.FindField(sKeyField);
            ArrayList list = new ArrayList();
            IObject obj2 = null;
            while (row != null)
            {
                if (row.get_Value(index).ToString() == sKeyValue)
                {
                    obj2 = row as IObject;
                    list.Add(obj2);
                }
                row = cursor.NextRow();
            }
            return list;
        }

        private IFeature GetXBFeature()
        {
            try
            {
                if (this.mHookHelper.FocusMap.SelectionCount == 0)
                {
                    return null;
                }
                IFeatureSelection mXBLayer = this.mXBLayer as IFeatureSelection;
                if (mXBLayer.SelectionSet.Count == 0)
                {
                    return null;
                }
                IEnumIDs iDs = mXBLayer.SelectionSet.IDs;
                iDs.Reset();
                int iD = iDs.Next();
                if (iD == -1)
                {
                    return null;
                }
                return this.mXBLayer.FeatureClass.GetFeature(iD);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "InitialXBList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private string GetXBName(IFeature pFeature)
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiFieldName").Split(new char[] { ',' });
                string str = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    int index = pFeature.Fields.FindField(strArray[i]);
                    if (index > -1)
                    {
                        if ((pFeature.Fields.get_Field(index).Domain != null) && (pFeature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                        {
                            string str2 = "";
                            ICodedValueDomain domain = (ICodedValueDomain) pFeature.Fields.get_Field(index).Domain;
                            long num3 = Convert.ToInt64(pFeature.get_Value(index));
                            for (int j = 0; j < domain.CodeCount; j++)
                            {
                                if (num3 == Convert.ToInt64(domain.get_Value(j)))
                                {
                                    str2 = domain.get_Name(j);
                                    break;
                                }
                            }
                            str = str + str2;
                            continue;
                        }
                        if (pFeature.get_Value(index).ToString().Length == 6)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 9)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                        else
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                    }
                }
                return str.Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void InitialHisList(IFeature pFeature, TreeList treelist)
        {
            try
            {
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                treelist.ClearNodes();
                treelist.OptionsView.ShowRoot = true;
                treelist.SelectImageList = null;
                treelist.StateImageList = this.ImageList1;
                treelist.OptionsView.ShowButtons = true;
                treelist.TreeLineStyle = LineStyle.None;
                treelist.RowHeight = 20;
                treelist.OptionsBehavior.AutoPopulateColumns = true;
                if (pFeature == null)
                {
                    node3 = treelist.AppendNode("该小班暂无历史信息", node4);
                    node3.SetValue(0, "该小班暂无历史信息");
                    node3.Tag = pFeature;
                    node3.ImageIndex = -1;
                    node3.StateImageIndex = -1;
                    node3.SelectImageIndex = -1;
                    node3.ExpandAll();
                }
                else
                {
                    string xBName = this.GetXBName(pFeature);
                    node3 = treelist.AppendNode(xBName, node4);
                    node3.SetValue(0, xBName);
                    node3.Tag = pFeature;
                    node3.ImageIndex = -1;
                    node3.StateImageIndex = -1;
                    node3.SelectImageIndex = -1;
                    node3.ExpandAll();
                    IFeature feature = pFeature;
                    string str2 = "";
                    string skeyvalue = "";
                    bool flag = false;
                    skeyvalue = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiFieldName");
                    flag = true;
                    for (int i = 0; i <= (feature.Fields.FieldCount - 1); i++)
                    {
                        if (!this.CheckFieldVisiable(feature.Fields.get_Field(i).Name, skeyvalue, flag) || ((((((feature.Fields.get_Field(i).Name.ToLower() == "objectid") | (feature.Fields.get_Field(i).Name.ToLower() == "shape_length")) | (feature.Fields.get_Field(i).Name.ToLower() == "shape_area")) | (feature.Fields.get_Field(i).Name.ToLower() == "shape.len")) | (feature.Fields.get_Field(i).Name.ToLower() == "shape.area")) | (feature.Fields.get_Field(i).Name.ToLower() == "shape")))
                        {
                            continue;
                        }
                        if ((feature.Fields.get_Field(i).Domain != null) && (feature.Fields.get_Field(i).Domain.Type == esriDomainType.esriDTCodedValue))
                        {
                            str2 = "";
                            try
                            {
                                ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(i).Domain;
                                long num2 = Convert.ToInt64(feature.get_Value(i));
                                for (int j = 0; j < domain.CodeCount; j++)
                                {
                                    if (num2 == Convert.ToInt64(domain.get_Value(j)))
                                    {
                                        str2 = domain.get_Name(j);
                                        goto Label_02C5;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                str2 = feature.get_Value(i).ToString();
                            }
                        }
                        else
                        {
                            str2 = feature.get_Value(i).ToString();
                        }
                    Label_02C5:
                        if ((str2 != "") || (i != -1))
                        {
                            try
                            {
                                treelist.AppendNode(feature.Fields.get_Field(i).AliasName + ": " + str2, node3).SetValue(0, feature.Fields.get_Field(i).AliasName + ": " + str2);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    node3.ExpandAll();
                    string name = "";
                    string str5 = "";
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiRelationField2").Split(new char[] { ',' });
                    name = strArray[0];
                    str5 = strArray[1];
                    strArray = UtilFactory.GetConfigOpt().GetConfigValue("LinGaiRelationField").Split(new char[] { ',' });
                    string text1 = strArray[0];
                    string text2 = strArray[1];
                    int index = feature.Fields.FindField(name);
                    this.mHisTable.Fields.FindField(str5);
                    ArrayList list = this.GetTableRows(this.mHisTable, name, feature.get_Value(index).ToString());
                    if (list != null)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            IRow row = list[k] as IRow;
                            if (list.Count > 1)
                            {
                                parentNode = treelist.AppendNode("林权申请信息" + ((k + 1)).ToString(), node3);
                                parentNode.SetValue(0, "林权申请信息" + ((k + 1)).ToString());
                                parentNode.ExpandAll();
                            }
                            else
                            {
                                parentNode = treelist.AppendNode("林权申请信息", node3);
                                parentNode.SetValue(0, "林权申请信息");
                                parentNode.ExpandAll();
                            }
                            for (int m = 0; m < row.Fields.FieldCount; m++)
                            {
                                str2 = "";
                                if ((row.Fields.get_Field(m).Domain != null) && (row.Fields.get_Field(m).Domain.Type == esriDomainType.esriDTCodedValue))
                                {
                                    try
                                    {
                                        ICodedValueDomain domain2 = (ICodedValueDomain) row.Fields.get_Field(m).Domain;
                                        long num7 = Convert.ToInt64(row.get_Value(m));
                                        for (int n = 0; n < domain2.CodeCount; n++)
                                        {
                                            if (num7 == Convert.ToInt64(domain2.get_Value(n)))
                                            {
                                                str2 = domain2.get_Name(n);
                                                goto Label_0560;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        str2 = row.get_Value(m).ToString();
                                    }
                                }
                                else
                                {
                                    str2 = row.get_Value(m).ToString();
                                }
                            Label_0560:
                                treelist.AppendNode(row.Fields.get_Field(m).AliasName + ": " + str2, parentNode).SetValue(0, row.Fields.get_Field(m).AliasName + ": " + str2);
                            }
                        }
                        node3.ExpandAll();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "InitialHisList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlQueryHisXB));
            this.labelLocation = new Label();
            this.labelPosition = new Label();
            this.treeListNow = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.repositoryItemPopupContainerEdit3 = new RepositoryItemPopupContainerEdit();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.treeListHis = new TreeList();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.repositoryItemPopupContainerEdit1 = new RepositoryItemPopupContainerEdit();
            this.repositoryItemImageEdit2 = new RepositoryItemImageEdit();
            this.navBarControl1 = new NavBarControl();
            this.navBarGroup1 = new NavBarGroup();
            this.navBarGroupControlContainer1 = new NavBarGroupControlContainer();
            this.navBarGroupControlContainer2 = new NavBarGroupControlContainer();
            this.navBarGroup2 = new NavBarGroup();
            this.imageList2 = new ImageList(this.components);
            this.ImageList1 = new ImageList(this.components);
            this.treeListNow.BeginInit();
            this.repositoryItemPopupContainerEdit3.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.treeListHis.BeginInit();
            this.repositoryItemPopupContainerEdit1.BeginInit();
            this.repositoryItemImageEdit2.BeginInit();
            this.navBarControl1.BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            base.SuspendLayout();
            this.labelLocation.BackColor = Color.Transparent;
            this.labelLocation.Cursor = Cursors.Hand;
            this.labelLocation.Dock = DockStyle.Top;
            this.labelLocation.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelLocation.Image = (Image) resources.GetObject("labelLocation.Image");
            this.labelLocation.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(0, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new Padding(0, 3, 0, 3);
            this.labelLocation.Size = new Size(0xf9, 0x1a);
            this.labelLocation.TabIndex = 0x11;
            this.labelLocation.Text = "      历史追溯          ";
            this.labelLocation.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPosition.Cursor = Cursors.Hand;
            this.labelPosition.Dock = DockStyle.Top;
            this.labelPosition.ForeColor = Color.Navy;
            this.labelPosition.Image = (Image) resources.GetObject("labelPosition.Image");
            this.labelPosition.ImageAlign = ContentAlignment.MiddleRight;
            this.labelPosition.Location = new System.Drawing.Point(0, 0x1a);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Padding = new Padding(0, 5, 0, 5);
            this.labelPosition.Size = new Size(0xf9, 0x1a);
            this.labelPosition.TabIndex = 0x13;
            this.labelPosition.Text = "  图上获取     ";
            this.labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPosition.Click += new EventHandler(this.labelPosition_Click);
            this.treeListNow.Appearance.FocusedCell.BackColor = Color.DodgerBlue;
            this.treeListNow.Appearance.FocusedCell.BackColor2 = Color.PaleTurquoise;
            this.treeListNow.Appearance.FocusedCell.BorderColor = Color.Blue;
            this.treeListNow.Appearance.FocusedCell.ForeColor = Color.Yellow;
            this.treeListNow.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListNow.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeListNow.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeListNow.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2 });
            this.treeListNow.Cursor = Cursors.Hand;
            this.treeListNow.Dock = DockStyle.Fill;
            this.treeListNow.Location = new System.Drawing.Point(0, 0);
            this.treeListNow.Name = "treeListNow";
            this.treeListNow.BeginUnboundLoad();
            this.treeListNow.AppendNode(new object[] { "XX县XX乡XX村XXX林班XXX小班", "" }, -1, -1, -1, -1);
            object[] nodeData = new object[2];
            nodeData[0] = "基本信息";
            this.treeListNow.AppendNode(nodeData, 0);
            object[] objArray3 = new object[2];
            objArray3[0] = "申请信息";
            this.treeListNow.AppendNode(objArray3, 0);
            this.treeListNow.AppendNode(new object[] { "XX县XX乡XX村XXX林班XXX小班", "" }, -1);
            this.treeListNow.EndUnboundLoad();
            this.treeListNow.OptionsBehavior.Editable = false;
            this.treeListNow.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListNow.OptionsView.ShowColumns = false;
            this.treeListNow.OptionsView.ShowHorzLines = false;
            this.treeListNow.OptionsView.ShowIndicator = false;
            this.treeListNow.OptionsView.ShowRoot = false;
            this.treeListNow.OptionsView.ShowVertLines = false;
            this.treeListNow.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemPopupContainerEdit3, this.repositoryItemImageEdit1 });
            this.treeListNow.Size = new Size(0xf7, 0xef);
            this.treeListNow.TabIndex = 100;
            this.treeListNow.TreeLevelWidth = 12;
            this.treeListNow.MouseDoubleClick += new MouseEventHandler(this.treeListNow_MouseDoubleClick);
            this.treeListNow.DoubleClick += new EventHandler(this.treeListNow_DoubleClick);
            this.treeListColumn1.Caption = "宗地号";
            this.treeListColumn1.FieldName = "name";
            this.treeListColumn1.MinWidth = 0x25;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0xba;
            this.treeListColumn2.Caption = "定位";
            this.treeListColumn2.FieldName = "value";
            this.treeListColumn2.ImageIndex = 0x11;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 0x24;
            this.repositoryItemPopupContainerEdit3.AutoHeight = false;
            this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit1.ShowIcon = false;
            this.repositoryItemImageEdit1.ShowMenu = false;
            this.repositoryItemImageEdit1.ShowPopupShadow = false;
            this.treeListHis.Appearance.FocusedCell.BackColor = Color.DodgerBlue;
            this.treeListHis.Appearance.FocusedCell.BackColor2 = Color.PaleTurquoise;
            this.treeListHis.Appearance.FocusedCell.BorderColor = Color.Blue;
            this.treeListHis.Appearance.FocusedCell.ForeColor = Color.Yellow;
            this.treeListHis.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListHis.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeListHis.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeListHis.Columns.AddRange(new TreeListColumn[] { this.treeListColumn3, this.treeListColumn4 });
            this.treeListHis.Cursor = Cursors.Hand;
            this.treeListHis.Dock = DockStyle.Fill;
            this.treeListHis.Location = new System.Drawing.Point(0, 0);
            this.treeListHis.Name = "treeListHis";
            this.treeListHis.BeginUnboundLoad();
            this.treeListHis.AppendNode(new object[] { "XX县XX乡XX村XXX林班XXX小班", "" }, -1, -1, -1, -1);
            object[] objArray6 = new object[2];
            objArray6[0] = "基本信息";
            this.treeListHis.AppendNode(objArray6, 0);
            object[] objArray7 = new object[2];
            objArray7[0] = "申请信息";
            this.treeListHis.AppendNode(objArray7, 0);
            this.treeListHis.AppendNode(new object[] { "XX县XX乡XX村XXX林班XXX小班", "" }, -1);
            this.treeListHis.EndUnboundLoad();
            this.treeListHis.OptionsBehavior.Editable = false;
            this.treeListHis.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListHis.OptionsView.ShowColumns = false;
            this.treeListHis.OptionsView.ShowHorzLines = false;
            this.treeListHis.OptionsView.ShowIndicator = false;
            this.treeListHis.OptionsView.ShowRoot = false;
            this.treeListHis.OptionsView.ShowVertLines = false;
            this.treeListHis.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemPopupContainerEdit1, this.repositoryItemImageEdit2 });
            this.treeListHis.Size = new Size(0xf7, 0xef);
            this.treeListHis.TabIndex = 100;
            this.treeListHis.TreeLevelWidth = 12;
            this.treeListHis.MouseDoubleClick += new MouseEventHandler(this.treeListHis_MouseDoubleClick);
            this.treeListHis.DoubleClick += new EventHandler(this.treeListHis_DoubleClick);
            this.treeListColumn3.Caption = "宗地号";
            this.treeListColumn3.FieldName = "name";
            this.treeListColumn3.MinWidth = 0x25;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 0xba;
            this.treeListColumn4.Caption = "定位";
            this.treeListColumn4.FieldName = "value";
            this.treeListColumn4.ImageIndex = 0x11;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Width = 0x24;
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            this.repositoryItemImageEdit2.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit2.Appearance.Image");
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit2.ShowIcon = false;
            this.repositoryItemImageEdit2.ShowMenu = false;
            this.repositoryItemImageEdit2.ShowPopupShadow = false;
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Appearance.Background.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.navBarControl1.Appearance.Background.GradientMode = LinearGradientMode.ForwardDiagonal;
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl1.Appearance.Button.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.navBarControl1.Appearance.Button.Options.UseBackColor = true;
            this.navBarControl1.Appearance.GroupHeader.BackColor = Color.CornflowerBlue;
            this.navBarControl1.Appearance.GroupHeader.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.navBarControl1.Appearance.GroupHeader.Options.UseBackColor = true;
            this.navBarControl1.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Dock = DockStyle.Fill;
            this.navBarControl1.ExplorerBarGroupInterval = 4;
            this.navBarControl1.ExplorerBarGroupOuterIndent = 0;
            this.navBarControl1.Groups.AddRange(new NavBarGroup[] { this.navBarGroup1, this.navBarGroup2 });
            this.navBarControl1.Location = new System.Drawing.Point(0, 0x34);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 0xf9;
            this.navBarControl1.Size = new Size(0xf9, 0x288);
            this.navBarControl1.TabIndex = 0x16;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new AdvExplorerBarViewInfoRegistrator();
            this.navBarControl1.GroupExpanded += new NavBarGroupEventHandler(this.navBarControl1_GroupExpanded);
            this.navBarControl1.GroupCollapsed += new NavBarGroupEventHandler(this.navBarControl1_GroupCollapsed);
            this.navBarGroup1.Caption = "当前小班";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 240;
            this.navBarGroup1.GroupStyle = NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroupControlContainer1.Controls.Add(this.treeListNow);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new Size(0xf7, 0xef);
            this.navBarGroupControlContainer1.TabIndex = 0;
            this.navBarGroupControlContainer2.Controls.Add(this.treeListHis);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new Size(0xf7, 0xef);
            this.navBarGroupControlContainer2.TabIndex = 1;
            this.navBarGroup2.Caption = "历史追溯";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 240;
            this.navBarGroup2.GroupStyle = NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "addcontact_search.ico");
            this.imageList2.Images.SetKeyName(1, "App2.ico");
            this.imageList2.Images.SetKeyName(2, "CommandItemInfoEditor.ico");
            this.imageList2.Images.SetKeyName(3, "ContentsButton.ico");
            this.imageList2.Images.SetKeyName(4, "ContSample.ico");
            this.imageList2.Images.SetKeyName(5, "IMBigToolbarShare.ico");
            this.imageList2.Images.SetKeyName(6, "journal_tutorial.ico");
            this.imageList2.Images.SetKeyName(7, "QZoneDlgInfo.ico");
            this.imageList2.Images.SetKeyName(8, "QZoneDlgInfo2.ico");
            this.imageList2.Images.SetKeyName(9, "Report.ico");
            this.imageList2.Images.SetKeyName(10, "SearchButton.ico");
            this.imageList2.Images.SetKeyName(11, "searchimage.ico");
            this.imageList2.Images.SetKeyName(12, "TIMER01.ICO");
            this.imageList2.Images.SetKeyName(13, "Title.ico");
            this.imageList2.Images.SetKeyName(14, "distributor-logo.png");
            this.imageList2.Images.SetKeyName(15, "area_chart.png");
            this.imageList2.Images.SetKeyName(0x10, "areachart.png");
            this.imageList2.Images.SetKeyName(0x11, "bookmark-edit.png");
            this.imageList2.Images.SetKeyName(0x12, "clock_edit.png");
            this.imageList2.Images.SetKeyName(0x13, "history.png");
            this.imageList2.Images.SetKeyName(20, "monitor_edit.png");
            this.imageList2.Images.SetKeyName(0x15, "bookmarks-edit.png");
            this.imageList2.Images.SetKeyName(0x16, "picture_edit.png");
            this.imageList2.Images.SetKeyName(0x17, "tree_1.png");
            this.imageList2.Images.SetKeyName(0x18, "tree2.png");
            this.imageList2.Images.SetKeyName(0x19, "tree.png");
            this.imageList2.Images.SetKeyName(0x1a, "icontexto-green-01.png");
            this.imageList2.Images.SetKeyName(0x1b, "search5.png");
            this.imageList2.Images.SetKeyName(0x1c, "20071127000634619.png");
            this.imageList2.Images.SetKeyName(0x1d, "20071127000614292.png");
            this.imageList2.Images.SetKeyName(30, "20071127112435759.png");
            this.imageList2.Images.SetKeyName(0x1f, "img-portrait-edit.png");
            this.imageList2.Images.SetKeyName(0x20, "history.png");
            this.imageList2.Images.SetKeyName(0x21, "tree_1.png");
            this.imageList2.Images.SetKeyName(0x22, "tree2.png");
            this.imageList2.Images.SetKeyName(0x23, "globe-green.png");
            this.imageList2.Images.SetKeyName(0x24, "tree.png");
            this.imageList2.Images.SetKeyName(0x25, "icontexto-green-01.png");
            this.imageList2.Images.SetKeyName(0x26, "Arzo_Icons_012.png");
            this.imageList2.Images.SetKeyName(0x27, "20071126112025469.png");
            this.imageList2.Images.SetKeyName(40, "20071126112015852.png");
            this.imageList2.Images.SetKeyName(0x29, "configuration_edit.png");
            this.imageList2.Images.SetKeyName(0x2a, "vacancy.png");
            this.imageList2.Images.SetKeyName(0x2b, "sc0904081_5.png");
            this.imageList2.Images.SetKeyName(0x2c, "sc0904081_6.png");
            this.imageList2.Images.SetKeyName(0x2d, "clock_32.png");
            this.imageList2.Images.SetKeyName(0x2e, "monitor_32.png");
            this.imageList2.Images.SetKeyName(0x2f, "flag_32.png");
            this.imageList2.Images.SetKeyName(0x30, "globe_32.png");
            this.imageList2.Images.SetKeyName(0x31, "search_32.png");
            this.imageList2.Images.SetKeyName(50, "pencil_32.png");
            this.imageList2.Images.SetKeyName(0x33, "client_account_template.png");
            this.imageList2.Images.SetKeyName(0x34, "clock_.png");
            this.imageList2.Images.SetKeyName(0x35, "clock_edit.png");
            this.imageList2.Images.SetKeyName(0x36, "clock_history_frame.png");
            this.imageList2.Images.SetKeyName(0x37, "clock_red.png");
            this.imageList2.Images.SetKeyName(0x38, "color_swatch.png");
            this.imageList2.Images.SetKeyName(0x39, "color_wheel.png");
            this.imageList2.Images.SetKeyName(0x3a, "domain_template.png");
            this.imageList2.Images.SetKeyName(0x3b, "house.png");
            this.imageList2.Images.SetKeyName(60, "images.png");
            this.imageList2.Images.SetKeyName(0x3d, "insert_element.png");
            this.imageList2.Images.SetKeyName(0x3e, "large_tiles.png");
            this.imageList2.Images.SetKeyName(0x3f, "layer_chart.png");
            this.imageList2.Images.SetKeyName(0x40, "layer_rgb.png");
            this.imageList2.Images.SetKeyName(0x41, "layout_content.png");
            this.imageList2.Images.SetKeyName(0x42, "legend.png");
            this.imageList2.Images.SetKeyName(0x43, "linechart.png");
            this.imageList2.Images.SetKeyName(0x44, "magnifier.png");
            this.imageList2.Images.SetKeyName(0x45, "orbit.png");
            this.imageList2.Images.SetKeyName(70, "page_white_world.png");
            this.imageList2.Images.SetKeyName(0x47, "palette.png");
            this.imageList2.Images.SetKeyName(0x48, "pencil.png");
            this.imageList2.Images.SetKeyName(0x49, "plugin_edit.png");
            this.imageList2.Images.SetKeyName(0x4a, "rainbow.png");
            this.imageList2.Images.SetKeyName(0x4b, "report_user.png");
            this.imageList2.Images.SetKeyName(0x4c, "reseller_account_template.png");
            this.imageList2.Images.SetKeyName(0x4d, "reseller_programm.png");
            this.imageList2.Images.SetKeyName(0x4e, "resource_usage.png");
            this.imageList2.Images.SetKeyName(0x4f, "select_by_color.png");
            this.imageList2.Images.SetKeyName(80, "server_components.png");
            this.imageList2.Images.SetKeyName(0x51, "statistics.png");
            this.imageList2.Images.SetKeyName(0x52, "things_digital.png");
            this.imageList2.Images.SetKeyName(0x53, "time.png");
            this.imageList2.Images.SetKeyName(0x54, "timeline.png");
            this.imageList2.Images.SetKeyName(0x55, "tree.png");
            this.imageList2.Images.SetKeyName(0x56, "vcard.png");
            this.imageList2.Images.SetKeyName(0x57, "video_mode.png");
            this.imageList2.Images.SetKeyName(0x58, "widgets.png");
            this.imageList2.Images.SetKeyName(0x59, "zoom.png");
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
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
            this.ImageList1.Images.SetKeyName(0x10, "(30,24).png");
            this.ImageList1.Images.SetKeyName(0x11, "(00,02).png");
            this.ImageList1.Images.SetKeyName(0x12, "(00,17).png");
            this.ImageList1.Images.SetKeyName(0x13, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(0x15, "(01,25).png");
            this.ImageList1.Images.SetKeyName(0x16, "(05,32).png");
            this.ImageList1.Images.SetKeyName(0x17, "(06,32).png");
            this.ImageList1.Images.SetKeyName(0x18, "(07,32).png");
            this.ImageList1.Images.SetKeyName(0x19, "(08,32).png");
            this.ImageList1.Images.SetKeyName(0x1a, "(08,36).png");
            this.ImageList1.Images.SetKeyName(0x1b, "(09,36).png");
            this.ImageList1.Images.SetKeyName(0x1c, "(10,26).png");
            this.ImageList1.Images.SetKeyName(0x1d, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x1f, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x20, "(11,32).png");
            this.ImageList1.Images.SetKeyName(0x21, "(11,36).png");
            this.ImageList1.Images.SetKeyName(0x22, "(13,32).png");
            this.ImageList1.Images.SetKeyName(0x23, "(19,31).png");
            this.ImageList1.Images.SetKeyName(0x24, "(22,18).png");
            this.ImageList1.Images.SetKeyName(0x25, "(25,27).png");
            this.ImageList1.Images.SetKeyName(0x26, "(29,43).png");
            this.ImageList1.Images.SetKeyName(0x27, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(0x29, "10.png");
            this.ImageList1.Images.SetKeyName(0x2a, "11.png");
            this.ImageList1.Images.SetKeyName(0x2b, "16.png");
            this.ImageList1.Images.SetKeyName(0x2c, "17.png");
            this.ImageList1.Images.SetKeyName(0x2d, "18.png");
            this.ImageList1.Images.SetKeyName(0x2e, "19.png");
            this.ImageList1.Images.SetKeyName(0x2f, "20.png");
            this.ImageList1.Images.SetKeyName(0x30, "21.png");
            this.ImageList1.Images.SetKeyName(0x31, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(0x33, "31.png");
            this.ImageList1.Images.SetKeyName(0x34, "41.png");
            this.ImageList1.Images.SetKeyName(0x35, "add.png");
            this.ImageList1.Images.SetKeyName(0x36, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(0x37, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x38, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x3a, "cross.png");
            this.ImageList1.Images.SetKeyName(0x3b, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(0x42, "flag blue.png");
            this.ImageList1.Images.SetKeyName(0x43, "flag red.png");
            this.ImageList1.Images.SetKeyName(0x44, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(0x45, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x47, "(34,00).png");
            this.ImageList1.Images.SetKeyName(0x48, "(03,02).png");
            this.ImageList1.Images.SetKeyName(0x49, "(49,06).png");
            this.ImageList1.Images.SetKeyName(0x4a, "(09,13).png");
            this.ImageList1.Images.SetKeyName(0x4b, "(16,47).png");
            this.ImageList1.Images.SetKeyName(0x4c, "(13,47).png");
            this.ImageList1.Images.SetKeyName(0x4d, "(18,01).png");
            this.ImageList1.Images.SetKeyName(0x4e, "(18,13).png");
            this.ImageList1.Images.SetKeyName(0x4f, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(0x51, "(39,47).png");
            this.ImageList1.Images.SetKeyName(0x52, "(45,12).png");
            this.ImageList1.Images.SetKeyName(0x53, "(45,17).png");
            this.ImageList1.Images.SetKeyName(0x54, "(45,41).png");
            this.ImageList1.Images.SetKeyName(0x55, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(0x56, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x57, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x58, "(12,11).png");
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.navBarControl1);
            base.Controls.Add(this.labelPosition);
            base.Controls.Add(this.labelLocation);
            base.Name = "UserControlQueryHisXB";
            base.Size = new Size(0xf9, 700);
            this.treeListNow.EndInit();
            this.repositoryItemPopupContainerEdit3.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.treeListHis.EndInit();
            this.repositoryItemPopupContainerEdit1.EndInit();
            this.repositoryItemImageEdit2.EndInit();
            this.navBarControl1.EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitialLayer()
        {
            try
            {
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("CurrentDataPath");
                IFeatureWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBDataset");
                IEnumDataset subsets = featureWorkspace.OpenFeatureDataset(configValue).Subsets;
                IDataset dataset3 = subsets.Next();
                string[] strArray = (this.mXBLayer.FeatureClass as IDataset).Name.Split(new char[] { '_' });
                string s = strArray[strArray.Length - 1];
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer") + "_" + ((int.Parse(s) - 1)).ToString();
                while (dataset3 != null)
                {
                    if ((dataset3 is IFeatureClass) && (dataset3.Name == configValue))
                    {
                        this.mHisLayer = new FeatureLayerClass();
                        this.mHisLayer.Name = "历史小班";
                        this.mHisLayer.FeatureClass = dataset3 as IFeatureClass;
                        break;
                    }
                    dataset3 = subsets.Next();
                }
                if (this.mHisLayer == null)
                {
                    configValue = "F_FOREST_V_P_SUBLOT";
                    IFeatureClass class2 = featureWorkspace.OpenFeatureClass(configValue);
                    this.mHisLayer = new FeatureLayerClass();
                    this.mHisLayer.Name = "历史小班";
                    this.mHisLayer.FeatureClass = class2;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "InitialLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue(object hook, IFeatureLayer pXBLayer)
        {
            try
            {
                this.mXBLayer = pXBLayer;
                this.mHookHelper = new HookHelperClass();
                if (hook != null)
                {
                    this.mHookHelper.Hook = hook;
                }
                this.InitialLayer();
                this.mXBFeature = this.GetXBFeature();
                if (this.mXBFeature != null)
                {
                    this.InitialXBList(this.mXBFeature, this.treeListNow);
                    ArrayList hisFeature = this.GetHisFeature(this.mXBFeature, this.mHisLayer);
                    if (hisFeature.Count == 0)
                    {
                        this.InitialHisList(null, this.treeListHis);
                    }
                    else
                    {
                        for (int i = 0; i < hisFeature.Count; i++)
                        {
                            this.InitialHisList(hisFeature[i] as IFeature, this.treeListHis);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialXBList(IFeature pselFeature, TreeList treelist)
        {
            try
            {
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                treelist.ClearNodes();
                treelist.OptionsView.ShowRoot = true;
                treelist.SelectImageList = null;
                treelist.StateImageList = this.ImageList1;
                treelist.OptionsView.ShowButtons = true;
                treelist.TreeLineStyle = LineStyle.None;
                treelist.RowHeight = 20;
                treelist.OptionsBehavior.AutoPopulateColumns = true;
                string xBName = this.GetXBName(pselFeature);
                parentNode = treelist.AppendNode(xBName, node3);
                parentNode.SetValue(0, xBName);
                parentNode.Tag = pselFeature;
                parentNode.ImageIndex = -1;
                parentNode.StateImageIndex = -1;
                parentNode.SelectImageIndex = -1;
                parentNode.ExpandAll();
                IFeature feature = pselFeature;
                string str2 = "";
                string skeyvalue = "";
                bool flag = false;
                skeyvalue = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2");
                flag = true;
                for (int i = 0; i <= (feature.Fields.FieldCount - 1); i++)
                {
                    if ((((!this.CheckFieldVisiable(feature.Fields.get_Field(i).Name, skeyvalue, flag) || (feature.Fields.get_Field(i).Name.ToLower() == "objectid")) || ((feature.Fields.get_Field(i).Name.ToLower() == "shape_length") || (feature.Fields.get_Field(i).Name.ToLower() == "shape_area"))) || ((((feature.Fields.get_Field(i).Name.ToLower() == "shape.len") | (feature.Fields.get_Field(i).Name.ToLower() == "shape.area")) || (feature.Fields.get_Field(i).Name.ToLower() == "shape")) || ((feature.Fields.get_Field(i).Name == this.mXBLayer.FeatureClass.OIDFieldName) || (feature.Fields.get_Field(i).Name == this.mXBLayer.FeatureClass.AreaField.Name)))) || ((feature.Fields.get_Field(i).Name == this.mXBLayer.FeatureClass.LengthField.Name) || (feature.Fields.get_Field(i).Name == this.mXBLayer.FeatureClass.ShapeFieldName)))
                    {
                        continue;
                    }
                    if ((feature.Fields.get_Field(i).Domain != null) && (feature.Fields.get_Field(i).Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        str2 = "";
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(i).Domain;
                            long num2 = Convert.ToInt64(feature.get_Value(i));
                            for (int j = 0; j < domain.CodeCount; j++)
                            {
                                if (num2 == Convert.ToInt64(domain.get_Value(j)))
                                {
                                    str2 = domain.get_Name(j);
                                    goto Label_0346;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            str2 = feature.get_Value(i).ToString();
                        }
                    }
                    else
                    {
                        str2 = feature.get_Value(i).ToString();
                    }
                Label_0346:
                    if ((str2 != "") || (i != -1))
                    {
                        try
                        {
                            treelist.AppendNode(feature.Fields.get_Field(i).AliasName + ": " + str2, parentNode).SetValue(0, feature.Fields.get_Field(i).AliasName + ": " + str2);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                parentNode.ExpandAll();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "InitialXBList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void labelPosition_Click(object sender, EventArgs e)
        {
            this.m_pPointTool = new XBPointTool();
            this.m_pPointTool.ParentForm = this;
            this.m_pPointTool.OnCreate(this.mHookHelper.Hook);
            IMapControl2 hook = null;
            hook = (IMapControl2) this.mHookHelper.Hook;
            hook.CurrentTool = this.m_pPointTool;
        }

        private void navBarControl1_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == this.navBarGroup1)
            {
                if (this.navBarGroup2.Expanded)
                {
                    this.navBarGroup2.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
                else
                {
                    this.navBarGroup2.Expanded = true;
                    this.navBarGroup2.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
            }
            if (e.Group == this.navBarGroup2)
            {
                if (this.navBarGroup1.Expanded)
                {
                    this.navBarGroup1.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
                else
                {
                    this.navBarGroup1.Expanded = true;
                    this.navBarGroup1.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
            }
        }

        private void navBarControl1_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == this.navBarGroup1)
            {
                if (this.navBarGroup2.Expanded)
                {
                    e.Group.GroupClientHeight = (this.navBarControl1.Height - 0x30) / 2;
                    this.navBarGroup2.GroupClientHeight = e.Group.GroupClientHeight;
                }
                else
                {
                    e.Group.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
            }
            if (e.Group == this.navBarGroup2)
            {
                if (this.navBarGroup1.Expanded)
                {
                    e.Group.GroupClientHeight = (this.navBarControl1.Height - 0x30) / 2;
                    this.navBarGroup1.GroupClientHeight = e.Group.GroupClientHeight;
                }
                else
                {
                    e.Group.GroupClientHeight = this.navBarControl1.Height - 0x30;
                }
            }
        }

        private void ReadValue()
        {
            try
            {
                if (this.mPoint != null)
                {
                    this.mHookHelper.FocusMap.ClearSelection();
                    (this.mHookHelper.Hook as IMapControl2).FlashShape(this.mPoint, 1, 300, null);
                    IEnvelope searchEnvelope = this.GetSearchEnvelope(this.mXBLayer, this.mPoint);
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    queryFilter.Geometry = searchEnvelope;
                    queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    IFeatureCursor cursor = this.mXBLayer.Search(queryFilter, false);
                    IFeature feature = null;
                    bool flag = false;
                    if (cursor != null)
                    {
                        feature = cursor.NextFeature();
                        long num = 0L;
                        while (feature != null)
                        {
                            num += 1L;
                            this.mXBFeature = feature;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        this.mHookHelper.FocusMap.SelectFeature(this.mXBLayer, this.mXBFeature);
                        this.InitialXBList(this.mXBFeature, this.treeListNow);
                        ArrayList hisFeature = this.GetHisFeature(this.mXBFeature, this.mHisLayer);
                        if (hisFeature.Count == 0)
                        {
                            this.InitialHisList(null, this.treeListHis);
                        }
                        else
                        {
                            for (int i = 0; i < hisFeature.Count; i++)
                            {
                                this.InitialHisList(hisFeature[i] as IFeature, this.treeListHis);
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHisXB", "ReadValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void treeListHis_DoubleClick(object sender, EventArgs e)
        {
        }

        private void treeListHis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.treeListHis.Selection.Count != 0)
                {
                    TreeListNode node = this.treeListHis.Selection[0];
                    if (node.Tag != null)
                    {
                        IFeature tag = node.Tag as IFeature;
                        string sLayerName = "小班专题";
                        IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                        if (pGroupLayer == null)
                        {
                            GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, sLayerName);
                            pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                        }
                        pGroupLayer.Visible = true;
                        IFeatureLayer layer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.mHisLayer.Name, true) as IFeatureLayer;
                        if (layer2 == null)
                        {
                            pGroupLayer.Add(this.mHisLayer);
                            layer2 = this.mHisLayer;
                            layer2.Visible = true;
                        }
                        else
                        {
                            layer2.FeatureClass = this.mHisLayer.FeatureClass;
                            layer2.Visible = true;
                        }
                        string str2 = "";
                        IFeatureLayerDefinition definition = null;
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName");
                        configValue = "SUB_CODE";
                        int index = tag.Fields.FindField(configValue);
                        str2 = string.Concat(new object[] { configValue, " = '", tag.get_Value(index), "'" });
                        definition = (IFeatureLayerDefinition) layer2;
                        definition.DefinitionExpression = str2;
                        IGeoFeatureLayer mHisLayer = (IGeoFeatureLayer) this.mHisLayer;
                        ISimpleRenderer renderer1 = (ISimpleRenderer) mHisLayer.Renderer;
                        ISymbol symbol = null;
                        ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                        ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                        IRgbColor color = new RgbColorClass();
                        color.NullColor = true;
                        symbol2.Color = color;
                        IRgbColor color2 = new RgbColorClass();
                        color2.Red = 0xff;
                        color2.Blue = 0xff;
                        color2.Green = 0;
                        symbol3.Color = color2;
                        symbol3.Width = 1.2;
                        symbol2.Outline = symbol3;
                        symbol = symbol2 as ISymbol;
                        ISimpleRenderer renderer = new SimpleRendererClass();
                        renderer.Symbol = symbol;
                        mHisLayer.Renderer = renderer as IFeatureRenderer;
                        IAnnotateLayerPropertiesCollection annotationProperties = mHisLayer.AnnotationProperties;
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
                        properties3.Expression = "[" + layer2.DisplayField + "]";
                        ITextSymbol symbol4 = new TextSymbolClass();
                        symbol4.Size = 12.0;
                        IColor color3 = symbol4.Color;
                        stdole.IFontDisp font = symbol4.Font;
                        font.Bold = true;
                        font.Name = "宋体";
                        font.Size = 12M;
                        IRgbColor color4 = new RgbColorClass();
                        color4.Red = 0xff;
                        color4.Blue = 0xff;
                        color4.Green = 0;
                        color3 = color4;
                        symbol4.Color = color3;
                        properties3.Symbol = symbol4;
                        IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                        annotationProperties.Add(item);
                        mHisLayer.DisplayAnnotation = true;
                        IEnvelope envelope = tag.Shape.Envelope;
                        IActiveView activeView = this.mHookHelper.ActiveView;
                        IEnvelope extent = activeView.Extent;
                        if (this.treeListNow.Nodes[0].Tag is IFeature)
                        {
                            extent = (this.treeListNow.Nodes[0].Tag as IFeature).Shape.Envelope;
                        }
                        bool flag = false;
                        if (envelope.XMin < extent.XMin)
                        {
                            extent.XMin = envelope.XMin;
                            flag = true;
                        }
                        if (envelope.YMin < extent.YMin)
                        {
                            extent.YMin = envelope.YMin;
                            flag = true;
                        }
                        if (envelope.XMax > extent.XMax)
                        {
                            extent.XMax = envelope.XMax;
                            flag = true;
                        }
                        if (envelope.YMax > extent.YMax)
                        {
                            extent.YMax = envelope.YMax;
                            flag = true;
                        }
                        if (flag)
                        {
                            extent.Expand(1.5, 1.5, true);
                            activeView.Extent = extent;
                            activeView.Refresh();
                        }
                        else
                        {
                            extent.Expand(1.5, 1.5, true);
                            activeView.Extent = extent;
                            activeView.Refresh();
                        }
                        (this.mHookHelper.Hook as IMapControl2).FlashShape(tag.Shape, 1, 300, null);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeListNow_DoubleClick(object sender, EventArgs e)
        {
        }

        private void treeListNow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.treeListNow.Selection.Count != 0)
            {
                TreeListNode node = this.treeListNow.Selection[0];
                if (node.Tag != null)
                {
                    IFeature tag = node.Tag as IFeature;
                    IEnvelope envelope = tag.Shape.Envelope;
                    IActiveView activeView = this.mHookHelper.ActiveView;
                    IEnvelope extent = activeView.Extent;
                    bool flag = false;
                    if (envelope.XMin < extent.XMin)
                    {
                        extent.XMin = envelope.XMin;
                        flag = true;
                    }
                    if (envelope.YMin < extent.YMin)
                    {
                        extent.YMin = envelope.YMin;
                        flag = true;
                    }
                    if (envelope.XMax > extent.XMin)
                    {
                        extent.XMax = envelope.XMax;
                        flag = true;
                    }
                    if (envelope.YMax > extent.XMin)
                    {
                        extent.YMax = envelope.YMax;
                        flag = true;
                    }
                    if (flag)
                    {
                        extent.Expand(1.2, 1.2, true);
                        activeView.FullExtent = envelope;
                        activeView.Refresh();
                    }
                    (this.mHookHelper.Hook as IMapControl2).FlashShape(tag.Shape, 1, 300, null);
                }
            }
        }

        public IPoint PointLocation
        {
            get
            {
                return this.mPoint;
            }
            set
            {
                if (value != null)
                {
                    this.mPoint = value;
                    if (this.mPoint != null)
                    {
                        this.ReadValue();
                    }
                }
            }
        }
    }
}

