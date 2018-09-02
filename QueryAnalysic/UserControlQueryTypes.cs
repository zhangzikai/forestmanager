namespace QueryAnalysic
{
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.db.mid.sys;
    using System.Collections.Generic;
    using td.logic.sys;
    using td.db.orm;

    public class UserControlQueryTypes : UserControlBase1
    {
        private SimpleButton ButtonLocationClear;
        private SimpleButton ButtonQuery;
        private SimpleButton ButtonResult;
        private CheckedListBoxControl cListBoxF;
        private CheckedListBoxControl cListBoxL;
        private CheckedListBoxControl cListBoxR;
        private CheckedListBoxControl cListBoxR2;
        private CheckedListBoxControl cListBoxR3;
        private CheckedListBoxControl cListBoxR4;
        private CheckedListBoxControl cListBoxT;
        private IContainer components;
        internal ImageList ImageList1;
        private ImageList imageList2;
        public ImageListBoxControl imageListBoxControl3;
        public ImageListBoxControl imageListBoxControlY;
        public ImageListBoxControl imageListBoxR;
        private LabelControl labelInfo;
        private Label labelRight;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureClass m_EditFeatureClass;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private ITable m_QueryTable;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "QueryAnalysic.UserControlQueryTypes";
   
        private DockPanel mDockPanel;
        private string mEditKind = "造林";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private ArrayList mForList;
        private IHookHelper mHookHelper;
        private bool mIsBatch = true;
        private string mKindCode = "";
        private ArrayList mKindList;
        private DataTable mKindTable;
        private ArrayList mLandList;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private ArrayList mQueryList;
        private UserControlQueryResult mQueryResult;
        private DataTable mQueryTable;
        private ArrayList mRangeList;
        private ArrayList mRightList;
        private ArrayList mRightList2;
        private ArrayList mRightList3;
        private ArrayList mRightList4;
        private bool mSelected;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ITable mTableF;
        private ITable mTableL;
        private ITable mTableR;
        private ITable mTableR2;
        private ITable mTableR3;
        private ITable mTableR4;
        private ITable mTableT;
        private ArrayList mTreeList;
        private const string myClassName = "组合类型查找设计班块";
        private NavBarControl navBarControl1;
        private NavBarGroup navBarGroup1;
        private NavBarGroup navBarGroup3;
        private NavBarGroup navBarGroup4;
        private NavBarGroup navBarGroup5;
        private NavBarGroup navBarGroup7;
        private NavBarGroupControlContainer navBarGroupControlContainer1;
        private NavBarGroupControlContainer navBarGroupControlContainer2;
        private NavBarGroupControlContainer navBarGroupControlContainer3;
        private NavBarGroupControlContainer navBarGroupControlContainer4;
        private NavBarGroupControlContainer navBarGroupControlContainer5;
        private NavBarGroupControlContainer navBarGroupControlContainer6;
        private NavBarGroupControlContainer navBarGroupControlContainer7;
        private NavBarGroupControlContainer navBarGroupControlContainer8;
        private NavBarGroup navBarGroupDesignKind;
        private NavBarGroup navBarGroupRange;
        private NavBarGroup navBarGroupYear;
        private Panel panel1;
        private Panel panel7;
        private Panel panel8;
        private Panel panelRight;
        private RadioGroup radioGroupYear;
        internal TreeListColumn tcolBase1;
        internal TreeListColumn tcolBase2;
        internal TreeList tListDesignKind;
        internal TreeList tListDist;
        internal TreeListColumn treeListColumn1;
        internal TreeListColumn treeListColumn2;

        public UserControlQueryTypes()
        {
            this.InitializeComponent();
        }

        private ILayer AddLayer2(string sname, IFeatureClass pFClass, IGroupLayer pGLayer)
        {
            try
            {
                ICompositeLayer layer = pGLayer as ICompositeLayer;
                for (int i = 0; i < layer.Count; i++)
                {
                    ILayer layer2 = layer.get_Layer(i);
                    if (layer2.Name == sname)
                    {
                        pGLayer.Delete(layer2);
                    }
                }
                IFeatureLayer layer3 = new FeatureLayerClass();
                layer3.FeatureClass = pFClass;
                layer3.Name = sname;
                layer3.DisplayField = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "FieldName");
                ILayer layer4 = layer3;
                pGLayer.Add(layer4);
                IFeatureLayer layer5 = layer4 as IFeatureLayer;
                IGeoFeatureLayer layer6 = (IGeoFeatureLayer) layer5;
                ISimpleRenderer renderer1 = (ISimpleRenderer) layer6.Renderer;
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
                layer6.Renderer = renderer as IFeatureRenderer;
                IAnnotateLayerPropertiesCollection annotationProperties = layer6.AnnotationProperties;
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
                properties3.Expression = "[" + layer3.DisplayField + "]";
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
                layer6.DisplayAnnotation = true;
                return layer4;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.mEditKind == "造林")
                {
                    str = "ZaoLin";
                }
                else if (this.mEditKind == "采伐")
                {
                    str = "CaiFa";
                }
                else
                {
                    str = "";
                }
                string str2 = "";
                if (this.radioGroupYear.SelectedIndex != -1)
                {
                    str2 = this.radioGroupYear.Properties.Items[this.radioGroupYear.SelectedIndex].Description.Replace("年", "");
                }
                if (str2 == "")
                {
                    return;
                }
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue(str + "Table") + "_" + str2;
                this.InitialQueryLayer();
                string queryStr = "";
                this.m_QueryTable = null;
                IFeatureClass featureClass = this.m_QueryLayer.FeatureClass;
                IObjectClass class3 = featureClass;
                if (class3 == null)
                {
                    return;
                }
                IEnumRelationshipClass class4 = class3.get_RelationshipClasses(esriRelRole.esriRelRoleOrigin);
                class4.Reset();
                IRelationshipClass class5 = class4.Next();
                IDataset queryTable = null;
                IRelationshipClass relClass = null;
                if (class5 != null)
                {
                    IObjectClass class7 = class5.DestinationClass;
                    this.m_QueryTable = class7 as ITable;
                    queryTable = this.m_QueryTable as IDataset;
                    if (queryTable.Name != str3)
                    {
                        class5 = class4.Next();
                        class7 = class5.DestinationClass;
                        this.m_QueryTable = class7 as ITable;
                        if ((this.m_QueryTable as IDataset).Name != str3)
                        {
                            class5 = null;
                            return;
                        }
                    }
                    string originForeignKey = class5.OriginForeignKey;
                    IFields fields = this.m_QueryTable.Fields;
                    queryStr = this.GetQueryStr();
                }
                else
                {
                    IFields fields2 = featureClass.Fields;
                    queryTable = featureClass as IDataset;
                    queryStr = this.GetQueryStr();
                    goto Label_031A;
                }
                IDisplayTable queryLayer = (IDisplayTable) this.m_QueryLayer;
                IFeatureClass displayTable = (IFeatureClass) queryLayer.DisplayTable;
                ITable table2 = (ITable) displayTable;
                GC.Collect();
                IMemoryRelationshipClassFactory factory = new MemoryRelationshipClassFactoryClass();
                string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Relation") + "_" + str2;
                try
                {
                    relClass = ((this.m_QueryLayer.FeatureClass as IDataset).Workspace as IFeatureWorkspace).OpenRelationshipClass(name);
                }
                catch (Exception)
                {
                    name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Relation").Replace("Relation", "") + str2 + "_Relation";
                    relClass = ((this.m_QueryLayer.FeatureClass as IDataset).Workspace as IFeatureWorkspace).OpenRelationshipClass(name);
                }
                if (relClass == null)
                {
                    relClass = factory.Open("TabletoLayer", (IObjectClass) table2, "UUID", (IObjectClass) this.m_QueryTable, "UUID", "forward", "backward", esriRelCardinality.esriRelCardinalityOneToMany);
                }
                (this.m_QueryLayer as IDisplayRelationshipClass).DisplayRelationshipClass(relClass, esriJoinType.esriLeftOuterJoin);
                IObjectClass originClass = relClass.OriginClass;
                IObjectClass destinationClass = relClass.DestinationClass;
                IFeatureLayerDefinition definition = (IFeatureLayerDefinition) this.m_QueryLayer;
                definition.DefinitionExpression = queryStr;
                this.mHookHelper.ActiveView.Refresh();
            Label_031A:
                this.m_QueryLayer.Visible = true;
                try
                {
                    this.m_QueryLayer.DisplayField = UtilFactory.GetConfigOpt().GetConfigValue(str + "FieldName");
                }
                catch (Exception)
                {
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(str + "GroupName2");
                IGroupLayer layer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                layer.Visible = true;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = queryStr;
                GC.Collect();
                ICursor cursor = this.m_QueryTable.Search(queryFilter, false);
                string text2 = (this.m_QueryTable as IDataset).Name;
                IFeature feature = null;
                IRow row = cursor.NextRow();
                int num = 0;
                this.mQueryList = new ArrayList();
                while (row != null)
                {
                    num++;
                    IQueryFilter filter = new QueryFilterClass();
                    int index = row.Fields.FindField("UUID");
                    filter.WhereClause = "UUID='" + row.get_Value(index).ToString() + "'";
                    feature = this.m_QueryLayer.FeatureClass.Search(filter, false).NextFeature();
                    this.mQueryList.Add(feature);
                    row = cursor.NextRow();
                }
                this.labelInfo.Text = "查询结果：找到" + num + "个班块";
                this.labelInfo.Visible = true;
                this.navBarControl1.BringToFront();
                IEnvelope areaOfInterest = null;
                if (this.mQueryList == null)
                {
                    IDataset dataset2 = this.m_QueryLayer as IDataset;
                    IGeoDataset dataset3 = dataset2 as IGeoDataset;
                    dataset3.Extent.Expand(1.25, 1.25, true);
                    areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                    areaOfInterest.Expand(1.25, 1.25, true);
                }
                if (this.mQueryList != null)
                {
                    if (this.mQueryList.Count > 0)
                    {
                        for (int i = 0; i < this.mQueryList.Count; i++)
                        {
                            if (this.mQueryList[i] != null)
                            {
                                IFeature feature2 = this.mQueryList[i] as IFeature;
                                IEnvelope envelope = feature2.Shape.Envelope;
                                if (areaOfInterest == null)
                                {
                                    areaOfInterest = envelope;
                                }
                                else if (!envelope.IsEmpty)
                                {
                                    if (areaOfInterest.XMin > envelope.XMin)
                                    {
                                        areaOfInterest.XMin = envelope.XMin;
                                    }
                                    if (areaOfInterest.YMin > envelope.YMin)
                                    {
                                        areaOfInterest.YMin = envelope.YMin;
                                    }
                                    if (areaOfInterest.XMax < envelope.XMin)
                                    {
                                        areaOfInterest.XMax = envelope.XMax;
                                    }
                                    if (areaOfInterest.YMax < envelope.YMax)
                                    {
                                        areaOfInterest.YMax = envelope.YMax;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                        areaOfInterest.Expand(1.25, 1.25, true);
                    }
                }
                else
                {
                    areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                    areaOfInterest.Expand(1.25, 1.25, true);
                }
                this.mHookHelper.ActiveView.Extent = areaOfInterest;
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "ButtonQuery_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            try
            {
                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, "UUID");
                this.mDockPanel.Visibility = DockVisibility.Visible;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "ButtonResult_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private CheckState CheckParentNodeSelected(TreeListNode node)
        {
            if (node.ParentNode == null)
            {
                return node.CheckState;
            }
            bool flag = false;
            bool flag2 = true;
            for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
            {
                if (node.ParentNode.Nodes[i].Checked && !flag)
                {
                    flag = true;
                }
                if (!node.ParentNode.Nodes[i].Checked && flag2)
                {
                    flag2 = false;
                }
            }
            if (flag2)
            {
                return CheckState.Checked;
            }
            if (flag)
            {
                return CheckState.Indeterminate;
            }
            return CheckState.Unchecked;
        }

        private void cListBoxR_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
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

        private string GetQueryStr()
        {
            try
            {
                string str = "";
                for (int i = 0; i < this.mKindList.Count; i++)
                {
                    if (str == "")
                    {
                        str = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".DESI_KIND='0", this.mKindCode, this.mKindList[i], "'" });
                    }
                    else
                    {
                        str = string.Concat(new object[] { str, " or ", (this.m_QueryTable as IDataset).Name, ".DESI_KIND='0", this.mKindCode, this.mKindList[i], "'" });
                    }
                }
                if (str != "")
                {
                    str = "(" + str + ")";
                }
                string str2 = "";
                for (int j = 0; j < this.mRangeList.Count; j++)
                {
                    string str3 = "";
                    if (this.mRangeList[j].ToString().Length == 6)
                    {
                        str3 = (this.m_QueryTable as IDataset).Name + ".CNTY";
                    }
                    else if (this.mRangeList[j].ToString().Length == 9)
                    {
                        str3 = (this.m_QueryTable as IDataset).Name + ".TOWN";
                    }
                    else if (this.mRangeList[j].ToString().Length == 12)
                    {
                        str3 = (this.m_QueryTable as IDataset).Name + ".VILL";
                    }
                    if (str2 == "")
                    {
                        str2 = string.Concat(new object[] { str3, "='", this.mRangeList[j], "'" });
                    }
                    else
                    {
                        str2 = string.Concat(new object[] { str2, " or ", str3, "='", this.mRangeList[j], "'" });
                    }
                }
                if (str2 != "")
                {
                    str2 = "(" + str2 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str2;
                    }
                    else
                    {
                        str = str2;
                    }
                }
                if (this.mEditKind == "造林")
                {
                    str2 = "";
                    for (int num3 = 0; num3 < this.mRightList.Count; num3++)
                    {
                        if (this.cListBoxR.Items[num3].CheckState == CheckState.Checked)
                        {
                            if (str2 == "")
                            {
                                str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".OWNER='", this.mRightList[num3], "'" });
                            }
                            else
                            {
                                str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".OWNER='", this.mRightList[num3], "'" });
                            }
                        }
                    }
                    if (str2 != "")
                    {
                        str2 = "(" + str2 + ")";
                        if (str != "")
                        {
                            str = str + " and " + str2;
                        }
                        else
                        {
                            str = str2;
                        }
                    }
                }
                else if (this.mEditKind == "采伐")
                {
                    str2 = "";
                    for (int num4 = 0; num4 < this.mRightList.Count; num4++)
                    {
                        if (this.cListBoxR.Items[num4].CheckState == CheckState.Checked)
                        {
                            if (str2 == "")
                            {
                                str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".LAND_OWNE='", this.mRightList[num4], "'" });
                            }
                            else
                            {
                                str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".LAND_OWNE='", this.mRightList[num4], "'" });
                            }
                        }
                    }
                    if (str2 != "")
                    {
                        str2 = "(" + str2 + ")";
                        if (str != "")
                        {
                            str = str + " and " + str2;
                        }
                        else
                        {
                            str = str2;
                        }
                    }
                    str2 = "";
                    for (int num5 = 0; num5 < this.mRightList2.Count; num5++)
                    {
                        if (this.cListBoxR2.Items[num5].CheckState == CheckState.Checked)
                        {
                            if (str2 == "")
                            {
                                str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".LAND_USER='", this.mRightList2[num5], "'" });
                            }
                            else
                            {
                                str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".LAND_USER='", this.mRightList2[num5], "'" });
                            }
                        }
                    }
                    if (str2 != "")
                    {
                        str2 = "(" + str2 + ")";
                        if (str != "")
                        {
                            str = str + " and " + str2;
                        }
                        else
                        {
                            str = str2;
                        }
                    }
                    str2 = "";
                    for (int num6 = 0; num6 < this.mRightList3.Count; num6++)
                    {
                        if (this.cListBoxR3.Items[num6].CheckState == CheckState.Checked)
                        {
                            if (str2 == "")
                            {
                                str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".FORS_OWNER='", this.mRightList3[num6], "'" });
                            }
                            else
                            {
                                str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".FORS_OWNER='", this.mRightList3[num6], "'" });
                            }
                        }
                    }
                    if (str2 != "")
                    {
                        str2 = "(" + str2 + ")";
                        if (str != "")
                        {
                            str = str + " and " + str2;
                        }
                        else
                        {
                            str = str2;
                        }
                    }
                    str2 = "";
                    for (int num7 = 0; num7 < this.mRightList4.Count; num7++)
                    {
                        if (this.cListBoxR4.Items[num7].CheckState == CheckState.Checked)
                        {
                            if (str2 == "")
                            {
                                str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".FORS_USER='", this.mRightList4[num7], "'" });
                            }
                            else
                            {
                                str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".FORS_USER='", this.mRightList4[num7], "'" });
                            }
                        }
                    }
                    if (str2 != "")
                    {
                        str2 = "(" + str2 + ")";
                        if (str != "")
                        {
                            str = str + " and " + str2;
                        }
                        else
                        {
                            str = str2;
                        }
                    }
                }
                str2 = "";
                for (int k = 0; k < this.mLandList.Count; k++)
                {
                    if (this.cListBoxL.Items[k].CheckState == CheckState.Checked)
                    {
                        if (str2 == "")
                        {
                            str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".LAND_TYPE='", this.mLandList[k], "'" });
                        }
                        else
                        {
                            str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".LAND_TYPE='", this.mLandList[k], "'" });
                        }
                    }
                }
                if (str2 != "")
                {
                    str2 = "(" + str2 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str2;
                    }
                    else
                    {
                        str = str2;
                    }
                }
                str2 = "";
                for (int m = 0; m < this.mTreeList.Count; m++)
                {
                    if (this.cListBoxT.Items[m].CheckState == CheckState.Checked)
                    {
                        if (str2 == "")
                        {
                            str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".DOMSPECIE='", this.mTreeList[m], "'" });
                        }
                        else
                        {
                            str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".DOMSPECIE='", this.mTreeList[m], "'" });
                        }
                    }
                }
                if (str2 != "")
                {
                    str2 = "(" + str2 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str2;
                    }
                    else
                    {
                        str = str2;
                    }
                }
                str2 = "";
                for (int n = 0; n < this.mForList.Count; n++)
                {
                    if (this.cListBoxF.Items[n].CheckState == CheckState.Checked)
                    {
                        if (str2 == "")
                        {
                            str2 = string.Concat(new object[] { (this.m_QueryTable as IDataset).Name, ".FORS_TYPE='", this.mForList[n], "'" });
                        }
                        else
                        {
                            str2 = string.Concat(new object[] { str2, " or ", (this.m_QueryTable as IDataset).Name, ".FORS_TYPE='", this.mForList[n], "'" });
                        }
                    }
                }
                if (str2 != "")
                {
                    str2 = "(" + str2 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str2;
                    }
                    else
                    {
                        str = str2;
                    }
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Hook(object hook, string sEditKind, IFeatureLayer pEditFLayer, UserControlQueryResult pResult, DockPanel pDockPanel)
        {
            try
            {
                this.mEditKind = sEditKind;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void imageListBoxControlY_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!this.mSelected)
                {
                    for (int i = 0; i < this.imageListBoxControlY.Items.Count; i++)
                    {
                        if (i == this.imageListBoxControlY.SelectedIndex)
                        {
                            this.imageListBoxControlY.Items[this.imageListBoxControlY.SelectedIndex].ImageIndex = 1;
                        }
                        else
                        {
                            this.imageListBoxControlY.Items[this.imageListBoxControlY.SelectedIndex].ImageIndex = 0;
                        }
                    }
                    this.imageListBoxControlY.SelectedIndex = -1;
                    this.imageListBoxControlY.MultiColumn = true;
                    this.imageListBoxControlY.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        private void imageListBoxControlY_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void imageListBoxControlY_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryTypes));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupDesignKind = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.tListDesignKind = new DevExpress.XtraTreeList.TreeList();
            this.tcolBase1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tcolBase2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.radioGroupYear = new DevExpress.XtraEditors.RadioGroup();
            this.imageListBoxControlY = new DevExpress.XtraEditors.ImageListBoxControl();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelRight = new System.Windows.Forms.Panel();
            this.cListBoxR = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cListBoxR2 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cListBoxR3 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cListBoxR4 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelRight = new System.Windows.Forms.Label();
            this.imageListBoxR = new DevExpress.XtraEditors.ImageListBoxControl();
            this.navBarGroupControlContainer4 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.cListBoxT = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.navBarGroupControlContainer5 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.cListBoxF = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.navBarGroupControlContainer6 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.tListDist = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer7 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.imageListBoxControl3 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.navBarGroupControlContainer8 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.cListBoxL = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.navBarGroupYear = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupRange = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup7 = new DevExpress.XtraNavBar.NavBarGroup();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ButtonLocationClear = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonResult = new DevExpress.XtraEditors.SimpleButton();
            this.labelInfo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).BeginInit();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControlY)).BeginInit();
            this.navBarGroupControlContainer3.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxR)).BeginInit();
            this.navBarGroupControlContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxT)).BeginInit();
            this.navBarGroupControlContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxF)).BeginInit();
            this.navBarGroupControlContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).BeginInit();
            this.navBarGroupControlContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl3)).BeginInit();
            this.navBarGroupControlContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxL)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroupDesignKind;
            this.navBarControl1.BackColor = System.Drawing.Color.White;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer4);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer5);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer6);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer7);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer8);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupYear,
            this.navBarGroupDesignKind,
            this.navBarGroupRange,
            this.navBarGroup3,
            this.navBarGroup1,
            this.navBarGroup4,
            this.navBarGroup5,
            this.navBarGroup7});
            this.navBarControl1.LargeImages = this.imageList2;
            this.navBarControl1.Location = new System.Drawing.Point(5, 5);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 278;
            this.navBarControl1.Size = new System.Drawing.Size(324, 895);
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroupDesignKind
            // 
            this.navBarGroupDesignKind.Caption = "作业设计类型";
            this.navBarGroupDesignKind.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroupDesignKind.Expanded = true;
            this.navBarGroupDesignKind.GroupClientHeight = 140;
            this.navBarGroupDesignKind.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupDesignKind.LargeImageIndex = 21;
            this.navBarGroupDesignKind.Name = "navBarGroupDesignKind";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.tListDesignKind);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(316, 136);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // tListDesignKind
            // 
            this.tListDesignKind.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Empty.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.EvenRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.EvenRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.tListDesignKind.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.tListDesignKind.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDesignKind.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.OddRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.OddRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.tListDesignKind.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.tListDesignKind.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Preview.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.Preview.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Row.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.Row.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.tListDesignKind.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tListDesignKind.Appearance.TreeLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDesignKind.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.VertLine.Options.UseBackColor = true;
            this.tListDesignKind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tListDesignKind.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tcolBase1,
            this.tcolBase2});
            this.tListDesignKind.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDesignKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDesignKind.Location = new System.Drawing.Point(0, 0);
            this.tListDesignKind.LookAndFeel.SkinName = "Blue";
            this.tListDesignKind.Name = "tListDesignKind";
            this.tListDesignKind.BeginUnboundLoad();
            this.tListDesignKind.AppendNode(new object[] {
            "退耕还林",
            null}, -1, 2, 2, 1);
            this.tListDesignKind.AppendNode(new object[] {
            "荒山造林",
            null}, 0, -1, -1, 1);
            this.tListDesignKind.AppendNode(new object[] {
            "封山育林",
            null}, 0, 0, 0, 1);
            this.tListDesignKind.AppendNode(new object[] {
            "工程造林",
            null}, -1, 0, 0, 0);
            this.tListDesignKind.AppendNode(new object[] {
            "防护林",
            null}, 3, 0, 0, 0);
            this.tListDesignKind.AppendNode(new object[] {
            "木本油料项目",
            null}, 3);
            this.tListDesignKind.EndUnboundLoad();
            this.tListDesignKind.OptionsBehavior.Editable = false;
            this.tListDesignKind.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tListDesignKind.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tListDesignKind.OptionsSelection.InvertSelection = true;
            this.tListDesignKind.OptionsView.ShowColumns = false;
            this.tListDesignKind.OptionsView.ShowHorzLines = false;
            this.tListDesignKind.OptionsView.ShowIndicator = false;
            this.tListDesignKind.OptionsView.ShowVertLines = false;
            this.tListDesignKind.Size = new System.Drawing.Size(316, 136);
            this.tListDesignKind.StateImageList = this.ImageList1;
            this.tListDesignKind.TabIndex = 77;
            this.tListDesignKind.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDesignKind.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.tListDesignKind_StateImageClick);
            this.tListDesignKind.SelectImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.tListDesignKind_SelectImageClick);
            // 
            // tcolBase1
            // 
            this.tcolBase1.Caption = "名称";
            this.tcolBase1.FieldName = "设备号";
            this.tcolBase1.MinWidth = 100;
            this.tcolBase1.Name = "tcolBase1";
            this.tcolBase1.Visible = true;
            this.tcolBase1.VisibleIndex = 0;
            this.tcolBase1.Width = 100;
            // 
            // tcolBase2
            // 
            this.tcolBase2.Caption = "定位";
            this.tcolBase2.FieldName = "定位";
            this.tcolBase2.Name = "tcolBase2";
            this.tcolBase2.Visible = true;
            this.tcolBase2.VisibleIndex = 1;
            this.tcolBase2.Width = 20;
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
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.radioGroupYear);
            this.navBarGroupControlContainer1.Controls.Add(this.imageListBoxControlY);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(316, 47);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // radioGroupYear
            // 
            this.radioGroupYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupYear.Location = new System.Drawing.Point(0, 0);
            this.radioGroupYear.Name = "radioGroupYear";
            this.radioGroupYear.Properties.Columns = 3;
            this.radioGroupYear.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2001"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2002"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2003")});
            this.radioGroupYear.Size = new System.Drawing.Size(316, 47);
            this.radioGroupYear.TabIndex = 3;
            // 
            // imageListBoxControlY
            // 
            this.imageListBoxControlY.Appearance.BackColor = System.Drawing.Color.White;
            this.imageListBoxControlY.Appearance.Options.UseBackColor = true;
            this.imageListBoxControlY.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageListBoxControlY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxControlY.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.imageListBoxControlY.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.imageListBoxControlY.ImageList = this.ImageList1;
            this.imageListBoxControlY.ItemHeight = 22;
            this.imageListBoxControlY.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("2011年", 86),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("2009年", 87),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("2008年", 87)});
            this.imageListBoxControlY.Location = new System.Drawing.Point(0, 0);
            this.imageListBoxControlY.MultiColumn = true;
            this.imageListBoxControlY.Name = "imageListBoxControlY";
            this.imageListBoxControlY.Size = new System.Drawing.Size(316, 47);
            this.imageListBoxControlY.TabIndex = 2;
            this.imageListBoxControlY.SelectedIndexChanged += new System.EventHandler(this.imageListBoxControlY_SelectedIndexChanged);
            this.imageListBoxControlY.SelectedValueChanged += new System.EventHandler(this.imageListBoxControlY_SelectedValueChanged);
            this.imageListBoxControlY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageListBoxControlY_MouseClick);
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Controls.Add(this.panelRight);
            this.navBarGroupControlContainer3.Controls.Add(this.imageListBoxR);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(322, 139);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.cListBoxR);
            this.panelRight.Controls.Add(this.cListBoxR2);
            this.panelRight.Controls.Add(this.cListBoxR3);
            this.panelRight.Controls.Add(this.cListBoxR4);
            this.panelRight.Controls.Add(this.labelRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panelRight.Size = new System.Drawing.Size(322, 139);
            this.panelRight.TabIndex = 5;
            // 
            // cListBoxR
            // 
            this.cListBoxR.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxR.CheckOnClick = true;
            this.cListBoxR.ColumnWidth = 50;
            this.cListBoxR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListBoxR.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.cListBoxR.ItemHeight = 24;
            this.cListBoxR.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他")});
            this.cListBoxR.Location = new System.Drawing.Point(55, 5);
            this.cListBoxR.MultiColumn = true;
            this.cListBoxR.Name = "cListBoxR";
            this.cListBoxR.Size = new System.Drawing.Size(262, 35);
            this.cListBoxR.TabIndex = 3;
            this.cListBoxR.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.cListBoxR_ItemCheck);
            // 
            // cListBoxR2
            // 
            this.cListBoxR2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxR2.CheckOnClick = true;
            this.cListBoxR2.ColumnWidth = 50;
            this.cListBoxR2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cListBoxR2.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.cListBoxR2.ItemHeight = 24;
            this.cListBoxR2.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他")});
            this.cListBoxR2.Location = new System.Drawing.Point(55, 40);
            this.cListBoxR2.MultiColumn = true;
            this.cListBoxR2.Name = "cListBoxR2";
            this.cListBoxR2.Size = new System.Drawing.Size(262, 33);
            this.cListBoxR2.TabIndex = 4;
            // 
            // cListBoxR3
            // 
            this.cListBoxR3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxR3.CheckOnClick = true;
            this.cListBoxR3.ColumnWidth = 50;
            this.cListBoxR3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cListBoxR3.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.cListBoxR3.ItemHeight = 24;
            this.cListBoxR3.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他")});
            this.cListBoxR3.Location = new System.Drawing.Point(55, 73);
            this.cListBoxR3.MultiColumn = true;
            this.cListBoxR3.Name = "cListBoxR3";
            this.cListBoxR3.Size = new System.Drawing.Size(262, 33);
            this.cListBoxR3.TabIndex = 6;
            // 
            // cListBoxR4
            // 
            this.cListBoxR4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxR4.CheckOnClick = true;
            this.cListBoxR4.ColumnWidth = 50;
            this.cListBoxR4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cListBoxR4.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.cListBoxR4.ItemHeight = 24;
            this.cListBoxR4.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他")});
            this.cListBoxR4.Location = new System.Drawing.Point(55, 106);
            this.cListBoxR4.MultiColumn = true;
            this.cListBoxR4.Name = "cListBoxR4";
            this.cListBoxR4.Size = new System.Drawing.Size(262, 33);
            this.cListBoxR4.TabIndex = 7;
            // 
            // labelRight
            // 
            this.labelRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelRight.Location = new System.Drawing.Point(5, 5);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(50, 134);
            this.labelRight.TabIndex = 5;
            this.labelRight.Text = "林地所有权\r\n林地使用权\r\n林木所有权\r\n林木使用权";
            this.labelRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageListBoxR
            // 
            this.imageListBoxR.Appearance.BackColor = System.Drawing.Color.White;
            this.imageListBoxR.Appearance.Options.UseBackColor = true;
            this.imageListBoxR.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageListBoxR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxR.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.imageListBoxR.ImageList = this.ImageList1;
            this.imageListBoxR.ItemHeight = 22;
            this.imageListBoxR.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("国有", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("集体", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("个人", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("其他", 0)});
            this.imageListBoxR.Location = new System.Drawing.Point(0, 0);
            this.imageListBoxR.MultiColumn = true;
            this.imageListBoxR.Name = "imageListBoxR";
            this.imageListBoxR.Size = new System.Drawing.Size(322, 139);
            this.imageListBoxR.TabIndex = 2;
            // 
            // navBarGroupControlContainer4
            // 
            this.navBarGroupControlContainer4.Controls.Add(this.cListBoxT);
            this.navBarGroupControlContainer4.Name = "navBarGroupControlContainer4";
            this.navBarGroupControlContainer4.Size = new System.Drawing.Size(322, 139);
            this.navBarGroupControlContainer4.TabIndex = 3;
            // 
            // cListBoxT
            // 
            this.cListBoxT.CheckOnClick = true;
            this.cListBoxT.ColumnWidth = 120;
            this.cListBoxT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListBoxT.ItemHeight = 18;
            this.cListBoxT.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5")});
            this.cListBoxT.Location = new System.Drawing.Point(0, 0);
            this.cListBoxT.MultiColumn = true;
            this.cListBoxT.Name = "cListBoxT";
            this.cListBoxT.Size = new System.Drawing.Size(322, 139);
            this.cListBoxT.TabIndex = 4;
            // 
            // navBarGroupControlContainer5
            // 
            this.navBarGroupControlContainer5.Controls.Add(this.cListBoxF);
            this.navBarGroupControlContainer5.Name = "navBarGroupControlContainer5";
            this.navBarGroupControlContainer5.Size = new System.Drawing.Size(322, 115);
            this.navBarGroupControlContainer5.TabIndex = 4;
            // 
            // cListBoxF
            // 
            this.cListBoxF.CheckOnClick = true;
            this.cListBoxF.ColumnWidth = 134;
            this.cListBoxF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListBoxF.ItemHeight = 18;
            this.cListBoxF.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5")});
            this.cListBoxF.Location = new System.Drawing.Point(0, 0);
            this.cListBoxF.MultiColumn = true;
            this.cListBoxF.Name = "cListBoxF";
            this.cListBoxF.Size = new System.Drawing.Size(322, 115);
            this.cListBoxF.TabIndex = 4;
            // 
            // navBarGroupControlContainer6
            // 
            this.navBarGroupControlContainer6.Controls.Add(this.tListDist);
            this.navBarGroupControlContainer6.Name = "navBarGroupControlContainer6";
            this.navBarGroupControlContainer6.Size = new System.Drawing.Size(316, 112);
            this.navBarGroupControlContainer6.TabIndex = 5;
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
            this.tListDist.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
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
            this.tListDist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tListDist.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tListDist.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDist.Location = new System.Drawing.Point(0, 0);
            this.tListDist.LookAndFeel.SkinName = "Blue";
            this.tListDist.Name = "tListDist";
            this.tListDist.BeginUnboundLoad();
            this.tListDist.AppendNode(new object[] {
            "乡1",
            null}, -1, 2, 2, 1);
            this.tListDist.AppendNode(new object[] {
            "村1",
            null}, 0, -1, -1, 1);
            this.tListDist.AppendNode(new object[] {
            "村2",
            null}, 0, 0, 0, 1);
            this.tListDist.AppendNode(new object[] {
            "乡2",
            null}, -1, 0, 0, 0);
            this.tListDist.AppendNode(new object[] {
            "村1",
            null}, 3, 0, 0, 0);
            this.tListDist.AppendNode(new object[] {
            "乡3",
            null}, -1);
            this.tListDist.AppendNode(new object[] {
            "村1",
            null}, 5);
            this.tListDist.EndUnboundLoad();
            this.tListDist.OptionsBehavior.Editable = false;
            this.tListDist.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tListDist.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tListDist.OptionsSelection.InvertSelection = true;
            this.tListDist.OptionsView.ShowColumns = false;
            this.tListDist.OptionsView.ShowHorzLines = false;
            this.tListDist.OptionsView.ShowIndicator = false;
            this.tListDist.OptionsView.ShowVertLines = false;
            this.tListDist.Size = new System.Drawing.Size(316, 112);
            this.tListDist.StateImageList = this.ImageList1;
            this.tListDist.TabIndex = 77;
            this.tListDist.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDist.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.tListDist_StateImageClick);
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
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 20;
            // 
            // navBarGroupControlContainer7
            // 
            this.navBarGroupControlContainer7.Controls.Add(this.imageListBoxControl3);
            this.navBarGroupControlContainer7.Name = "navBarGroupControlContainer7";
            this.navBarGroupControlContainer7.Size = new System.Drawing.Size(322, 92);
            this.navBarGroupControlContainer7.TabIndex = 6;
            // 
            // imageListBoxControl3
            // 
            this.imageListBoxControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.imageListBoxControl3.Appearance.Options.UseBackColor = true;
            this.imageListBoxControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageListBoxControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxControl3.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.imageListBoxControl3.ImageList = this.ImageList1;
            this.imageListBoxControl3.ItemHeight = 22;
            this.imageListBoxControl3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("国有", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("集体", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("个人", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("其他", 0)});
            this.imageListBoxControl3.Location = new System.Drawing.Point(0, 0);
            this.imageListBoxControl3.MultiColumn = true;
            this.imageListBoxControl3.Name = "imageListBoxControl3";
            this.imageListBoxControl3.Size = new System.Drawing.Size(322, 92);
            this.imageListBoxControl3.TabIndex = 3;
            // 
            // navBarGroupControlContainer8
            // 
            this.navBarGroupControlContainer8.Controls.Add(this.cListBoxL);
            this.navBarGroupControlContainer8.Name = "navBarGroupControlContainer8";
            this.navBarGroupControlContainer8.Size = new System.Drawing.Size(322, 92);
            this.navBarGroupControlContainer8.TabIndex = 7;
            // 
            // cListBoxL
            // 
            this.cListBoxL.CheckOnClick = true;
            this.cListBoxL.ColumnWidth = 134;
            this.cListBoxL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListBoxL.ItemHeight = 18;
            this.cListBoxL.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("国有"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("集体"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("个人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("其他"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5")});
            this.cListBoxL.Location = new System.Drawing.Point(0, 0);
            this.cListBoxL.MultiColumn = true;
            this.cListBoxL.Name = "cListBoxL";
            this.cListBoxL.Size = new System.Drawing.Size(322, 92);
            this.cListBoxL.TabIndex = 5;
            // 
            // navBarGroupYear
            // 
            this.navBarGroupYear.Caption = "设计时间";
            this.navBarGroupYear.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroupYear.Expanded = true;
            this.navBarGroupYear.GroupClientHeight = 51;
            this.navBarGroupYear.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupYear.LargeImageIndex = 45;
            this.navBarGroupYear.Name = "navBarGroupYear";
            // 
            // navBarGroupRange
            // 
            this.navBarGroupRange.Caption = "区划范围";
            this.navBarGroupRange.ControlContainer = this.navBarGroupControlContainer6;
            this.navBarGroupRange.Expanded = true;
            this.navBarGroupRange.GroupClientHeight = 116;
            this.navBarGroupRange.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupRange.LargeImageIndex = 82;
            this.navBarGroupRange.Name = "navBarGroupRange";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "权属";
            this.navBarGroup3.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroup3.GroupClientHeight = 140;
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup3.LargeImageIndex = 75;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "地类";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer8;
            this.navBarGroup1.GroupClientHeight = 93;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.LargeImageIndex = 69;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "树种";
            this.navBarGroup4.ControlContainer = this.navBarGroupControlContainer4;
            this.navBarGroup4.GroupClientHeight = 140;
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup4.LargeImageIndex = 85;
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "林种";
            this.navBarGroup5.ControlContainer = this.navBarGroupControlContainer5;
            this.navBarGroup5.GroupClientHeight = 116;
            this.navBarGroup5.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup5.LargeImageIndex = 80;
            this.navBarGroup5.Name = "navBarGroup5";
            // 
            // navBarGroup7
            // 
            this.navBarGroup7.Caption = "造林方式";
            this.navBarGroup7.ControlContainer = this.navBarGroupControlContainer7;
            this.navBarGroup7.Expanded = true;
            this.navBarGroup7.GroupClientHeight = 93;
            this.navBarGroup7.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup7.LargeImageIndex = 58;
            this.navBarGroup7.Name = "navBarGroup7";
            this.navBarGroup7.Visible = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
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
            this.imageList2.Images.SetKeyName(16, "areachart.png");
            this.imageList2.Images.SetKeyName(17, "bookmark-edit.png");
            this.imageList2.Images.SetKeyName(18, "clock_edit.png");
            this.imageList2.Images.SetKeyName(19, "history.png");
            this.imageList2.Images.SetKeyName(20, "monitor_edit.png");
            this.imageList2.Images.SetKeyName(21, "bookmarks-edit.png");
            this.imageList2.Images.SetKeyName(22, "picture_edit.png");
            this.imageList2.Images.SetKeyName(23, "tree_1.png");
            this.imageList2.Images.SetKeyName(24, "tree2.png");
            this.imageList2.Images.SetKeyName(25, "tree.png");
            this.imageList2.Images.SetKeyName(26, "icontexto-green-01.png");
            this.imageList2.Images.SetKeyName(27, "search5.png");
            this.imageList2.Images.SetKeyName(28, "20071127000634619.png");
            this.imageList2.Images.SetKeyName(29, "20071127000614292.png");
            this.imageList2.Images.SetKeyName(30, "20071127112435759.png");
            this.imageList2.Images.SetKeyName(31, "img-portrait-edit.png");
            this.imageList2.Images.SetKeyName(32, "history.png");
            this.imageList2.Images.SetKeyName(33, "tree_1.png");
            this.imageList2.Images.SetKeyName(34, "tree2.png");
            this.imageList2.Images.SetKeyName(35, "globe-green.png");
            this.imageList2.Images.SetKeyName(36, "tree.png");
            this.imageList2.Images.SetKeyName(37, "icontexto-green-01.png");
            this.imageList2.Images.SetKeyName(38, "Arzo_Icons_012.png");
            this.imageList2.Images.SetKeyName(39, "20071126112025469.png");
            this.imageList2.Images.SetKeyName(40, "20071126112015852.png");
            this.imageList2.Images.SetKeyName(41, "configuration_edit.png");
            this.imageList2.Images.SetKeyName(42, "vacancy.png");
            this.imageList2.Images.SetKeyName(43, "sc0904081_5.png");
            this.imageList2.Images.SetKeyName(44, "sc0904081_6.png");
            this.imageList2.Images.SetKeyName(45, "clock_32.png");
            this.imageList2.Images.SetKeyName(46, "monitor_32.png");
            this.imageList2.Images.SetKeyName(47, "flag_32.png");
            this.imageList2.Images.SetKeyName(48, "globe_32.png");
            this.imageList2.Images.SetKeyName(49, "search_32.png");
            this.imageList2.Images.SetKeyName(50, "pencil_32.png");
            this.imageList2.Images.SetKeyName(51, "client_account_template.png");
            this.imageList2.Images.SetKeyName(52, "clock_.png");
            this.imageList2.Images.SetKeyName(53, "clock_edit.png");
            this.imageList2.Images.SetKeyName(54, "clock_history_frame.png");
            this.imageList2.Images.SetKeyName(55, "clock_red.png");
            this.imageList2.Images.SetKeyName(56, "color_swatch.png");
            this.imageList2.Images.SetKeyName(57, "color_wheel.png");
            this.imageList2.Images.SetKeyName(58, "domain_template.png");
            this.imageList2.Images.SetKeyName(59, "house.png");
            this.imageList2.Images.SetKeyName(60, "images.png");
            this.imageList2.Images.SetKeyName(61, "insert_element.png");
            this.imageList2.Images.SetKeyName(62, "large_tiles.png");
            this.imageList2.Images.SetKeyName(63, "layer_chart.png");
            this.imageList2.Images.SetKeyName(64, "layer_rgb.png");
            this.imageList2.Images.SetKeyName(65, "layout_content.png");
            this.imageList2.Images.SetKeyName(66, "legend.png");
            this.imageList2.Images.SetKeyName(67, "linechart.png");
            this.imageList2.Images.SetKeyName(68, "magnifier.png");
            this.imageList2.Images.SetKeyName(69, "orbit.png");
            this.imageList2.Images.SetKeyName(70, "page_white_world.png");
            this.imageList2.Images.SetKeyName(71, "palette.png");
            this.imageList2.Images.SetKeyName(72, "pencil.png");
            this.imageList2.Images.SetKeyName(73, "plugin_edit.png");
            this.imageList2.Images.SetKeyName(74, "rainbow.png");
            this.imageList2.Images.SetKeyName(75, "report_user.png");
            this.imageList2.Images.SetKeyName(76, "reseller_account_template.png");
            this.imageList2.Images.SetKeyName(77, "reseller_programm.png");
            this.imageList2.Images.SetKeyName(78, "resource_usage.png");
            this.imageList2.Images.SetKeyName(79, "select_by_color.png");
            this.imageList2.Images.SetKeyName(80, "server_components.png");
            this.imageList2.Images.SetKeyName(81, "statistics.png");
            this.imageList2.Images.SetKeyName(82, "things_digital.png");
            this.imageList2.Images.SetKeyName(83, "time.png");
            this.imageList2.Images.SetKeyName(84, "timeline.png");
            this.imageList2.Images.SetKeyName(85, "tree.png");
            this.imageList2.Images.SetKeyName(86, "vcard.png");
            this.imageList2.Images.SetKeyName(87, "video_mode.png");
            this.imageList2.Images.SetKeyName(88, "widgets.png");
            this.imageList2.Images.SetKeyName(89, "zoom.png");
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ButtonQuery);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.ButtonLocationClear);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Controls.Add(this.ButtonResult);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(5, 900);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(7, 0, 5, 0);
            this.panel7.Size = new System.Drawing.Size(324, 28);
            this.panel7.TabIndex = 17;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonQuery.ImageIndex = 9;
            this.ButtonQuery.ImageList = this.ImageList1;
            this.ButtonQuery.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonQuery.Location = new System.Drawing.Point(110, 0);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(65, 28);
            this.ButtonQuery.TabIndex = 11;
            this.ButtonQuery.Text = "查找";
            this.ButtonQuery.ToolTip = "查找";
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(175, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(7, 28);
            this.panel8.TabIndex = 15;
            // 
            // ButtonLocationClear
            // 
            this.ButtonLocationClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonLocationClear.ImageIndex = 56;
            this.ButtonLocationClear.ImageList = this.ImageList1;
            this.ButtonLocationClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonLocationClear.Location = new System.Drawing.Point(182, 0);
            this.ButtonLocationClear.Name = "ButtonLocationClear";
            this.ButtonLocationClear.Size = new System.Drawing.Size(65, 28);
            this.ButtonLocationClear.TabIndex = 14;
            this.ButtonLocationClear.Text = "重置";
            this.ButtonLocationClear.ToolTip = "重置图层";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(247, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(7, 28);
            this.panel1.TabIndex = 16;
            // 
            // ButtonResult
            // 
            this.ButtonResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonResult.ImageIndex = 7;
            this.ButtonResult.ImageList = this.ImageList1;
            this.ButtonResult.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonResult.Location = new System.Drawing.Point(254, 0);
            this.ButtonResult.Name = "ButtonResult";
            this.ButtonResult.Size = new System.Drawing.Size(65, 28);
            this.ButtonResult.TabIndex = 17;
            this.ButtonResult.Text = "结果";
            this.ButtonResult.ToolTip = "显示结果列表";
            this.ButtonResult.Click += new System.EventHandler(this.ButtonResult_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.Location = new System.Drawing.Point(5, 886);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(116, 14);
            this.labelInfo.TabIndex = 18;
            this.labelInfo.Text = "查询结果:找到 个班块";
            this.labelInfo.Visible = false;
            // 
            // UserControlQueryTypes
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.panel7);
            this.Name = "UserControlQueryTypes";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(334, 933);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).EndInit();
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControlY)).EndInit();
            this.navBarGroupControlContainer3.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxR4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxR)).EndInit();
            this.navBarGroupControlContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxT)).EndInit();
            this.navBarGroupControlContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxF)).EndInit();
            this.navBarGroupControlContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).EndInit();
            this.navBarGroupControlContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl3)).EndInit();
            this.navBarGroupControlContainer8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxL)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public ProjectManager PM
        {
            get
            {
                return DBServiceFactory<ProjectManager>.Service;
            }
        }
        private IList<T_DESIGNKIND_Mid> m_kindCodeLst;
        private IList<T_EDITTASK_ZT_Mid> m_projectLst;
        private void InitialKindList()
        {
            try
            {
                if (this.mKindTable != null)
                {
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    TreeListNode node4 = null;
                    this.tListDesignKind.Nodes.Clear();
                    this.tListDesignKind.OptionsView.ShowRoot = true;
                    this.tListDesignKind.SelectImageList = null;
                    this.tListDesignKind.StateImageList = this.ImageList1;
                    this.tListDesignKind.OptionsView.ShowButtons = true;
                    this.tListDesignKind.TreeLineStyle = LineStyle.None;
                    this.tListDesignKind.RowHeight = 20;
                    this.tListDesignKind.OptionsBehavior.AutoPopulateColumns = true;
                    m_kindCodeLst = PM.FindTreeByKindCode(mKindCode);
                   // DataTable dataTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '%0000' and kind='" + this.mKindCode + "') ");
                    string str = "";
                    for (int i = 0; i < m_kindCodeLst.Count; i++)
                    {
                        this.mSelected = true;
                        node3 = this.tListDesignKind.AppendNode(m_kindCodeLst[i].name, node4);
                        node3.SetValue(0, m_kindCodeLst[i].name);
                        node3.Tag = m_kindCodeLst[i].code;
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = 0;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                        IList<T_DESIGNKIND_Mid> secondLst = m_kindCodeLst[i].SubList;
                       // DataTable table2 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '" + str + "%' and right(code ,4 )<>'0000' and right(code ,2 )='00' and kind='" + this.mKindCode + "')");
                        string str2 = "";
                        for (int j = 0; j < secondLst.Count; j++)
                        {
                            parentNode = this.tListDesignKind.AppendNode(secondLst[i].name, node3);
                            parentNode.ImageIndex = -1;
                            parentNode.StateImageIndex = 0;
                            parentNode.SelectImageIndex = -1;
                            parentNode.SetValue(0, secondLst[i].name);
                            parentNode.Tag = secondLst[i].code;
                            parentNode.Expanded = false;
                            //str2 = table2.Rows[j]["code"].ToString().Substring(0, 4);
                         //   DataTable table3 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where (code like '" + str2 + "%' and right(code ,4 )<>'0000' and right(code ,2 )<>'00' and kind='" + this.mKindCode + "')");
                            IList<T_DESIGNKIND_Mid> thirdLst = secondLst[i].SubList;
                            for (int k = 0; k < thirdLst.Count; k++)
                            {
                                node = this.tListDesignKind.AppendNode(thirdLst[k].name, parentNode);
                                node.ImageIndex = -1;
                                node.StateImageIndex = 0;
                                node.SelectImageIndex = -1;
                                node.SetValue(0, thirdLst[k].name);
                                node.Tag = thirdLst[k].code;
                                node.Expanded = false;
                            }
                        }
                        node3.ExpandAll();
                        this.mSelected = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "InitialKindList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialList()
        {
            try
            {
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                this.tListDist.ClearNodes();
                this.tListDist.OptionsView.ShowRoot = true;
                this.tListDist.SelectImageList = null;
                this.tListDist.StateImageList = this.ImageList1;
                this.tListDist.OptionsView.ShowButtons = true;
                this.tListDist.TreeLineStyle = LineStyle.None;
                this.tListDist.RowHeight = 20;
                this.tListDist.OptionsBehavior.AutoPopulateColumns = true;
                this.m_CountyLayer.FeatureClass.FeatureCount(null);
                IFeatureCursor cursor = this.m_CountyLayer.FeatureClass.Search(null, false);
                IFeature feature = cursor.NextFeature();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                int index = feature.Fields.FindField(configValue);
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode");
                while (feature != null)
                {
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = str2 + "='" + feature.get_Value(index).ToString() + "'";
                    ICursor cursor2 = this.m_CountyTable.Search(queryFilter, false);
                    IRow row = cursor2.NextRow();
                    int num2 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode"));
                    int num3 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName"));
                    while (row != null)
                    {
                        if (row.get_Value(num2).ToString() == feature.get_Value(index).ToString())
                        {
                            node3 = this.tListDist.AppendNode(row.get_Value(num3).ToString(), node4);
                            node3.ImageIndex = -1;
                            node3.StateImageIndex = 0;
                            node3.SelectImageIndex = -1;
                            node3.SetValue(0, row.get_Value(num3).ToString());
                            node3.Tag = row.get_Value(num2).ToString();
                            IQueryFilter filter2 = new QueryFilterClass();
                            filter2.WhereClause = str2 + " like '" + row.get_Value(num2).ToString() + "%'";
                            ICursor cursor3 = this.m_TownTable.Search(filter2, true);
                            for (IRow row2 = cursor3.NextRow(); row2 != null; row2 = cursor3.NextRow())
                            {
                                parentNode = this.tListDist.AppendNode(row2.get_Value(num3).ToString(), node3);
                                parentNode.ImageIndex = -1;
                                parentNode.StateImageIndex = 0;
                                parentNode.SelectImageIndex = -1;
                                parentNode.SetValue(0, row2.get_Value(num3).ToString());
                                parentNode.Tag = row2.get_Value(num2).ToString();
                                parentNode.Expanded = false;
                                IQueryFilter filter3 = new QueryFilterClass();
                                filter3.WhereClause = str2 + " like '" + row2.get_Value(num2).ToString() + "%'";
                                ICursor cursor4 = this.m_VillageTable.Search(filter3, false);
                                for (IRow row3 = cursor4.NextRow(); row3 != null; row3 = cursor4.NextRow())
                                {
                                    node = this.tListDist.AppendNode(row3.get_Value(num3).ToString(), parentNode);
                                    node.ImageIndex = -1;
                                    node.StateImageIndex = 0;
                                    node.SelectImageIndex = -1;
                                    node.SetValue(0, row3.get_Value(num3).ToString());
                                    node.Tag = row3.get_Value(num2).ToString();
                                    node.Expanded = false;
                                }
                            }
                        }
                        row = cursor2.NextRow();
                    }
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialQueryLayer()
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "GroupName2");
                IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                if (pGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, configValue);
                    pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                }
                this.m_QueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, "类型查询", true) as IFeatureLayer;
                IFeatureClass pFClass = this.mLayerList[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                if (this.m_QueryLayer == null)
                {
                    this.m_QueryLayer = this.AddLayer2("类型查询", pFClass, pGroupLayer) as IFeatureLayer;
                }
                else
                {
                    try
                    {
                        this.m_QueryLayer.FeatureClass = pFClass;
                    }
                    catch (Exception)
                    {
                        this.mHookHelper.FocusMap.DeleteLayer(this.m_QueryLayer);
                        this.m_QueryLayer = null;
                        this.m_QueryLayer = this.AddLayer2("类型查询", pFClass, pGroupLayer) as IFeatureLayer;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitialValue()
        {
            try
            {
                IDataset editDataset;
                string str7;
                IRow row;
       
                if (this.mEditKind == "造林")
                {
                    this.mKindCode = "1";
                    this.mIsBatch = true;
                    this.labelRight.Visible = false;
                    this.cListBoxR2.Visible = false;
                    this.cListBoxR3.Visible = false;
                    this.cListBoxR4.Visible = false;
                    this.navBarGroup3.GroupClientHeight = 30;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mKindCode = "2";
                    this.mIsBatch = false;
                    this.labelRight.Visible = true;
                    this.cListBoxR2.Visible = true;
                    this.cListBoxR3.Visible = true;
                    this.cListBoxR4.Visible = true;
                    this.navBarGroup3.GroupClientHeight = 120;
                }
                else
                {
                    this.mKindCode = "";
                }
              //  this.mKindTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where kind='" + this.mKindCode + "'");
                m_kindCodeLst = PM.FindTreeByKindCode(mKindCode);
                this.InitialKindList();
                if (((this.mHookHelper == null) || (this.mHookHelper.FocusMap == null)) || (this.mHookHelper.FocusMap.LayerCount == 0))
                {
                    return;
                }
                IMap focusMap = this.mHookHelper.FocusMap;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.m_CountyLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                if (this.m_CountyLayer == null)
                {
                    return;
                }
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                this.m_TownLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                if (this.m_TownLayer == null)
                {
                    return;
                }
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                this.m_VillageLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                if (this.m_VillageLayer == null)
                {
                    return;
                }
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                IFeatureWorkspace pfw = null;
                if (sSourceFile.Contains(".gdb") || sSourceFile.Contains(".GDB"))
                {
                    pfw = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                }
                else if (sSourceFile.Contains(".mdb") || sSourceFile.Contains(".MDB"))
                {
                    pfw = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSAccessWorkspaceFactory);
                }
                if (pfw == null)
                {
                    return;
                }
                string name = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                this.m_CountyTable = pfw.OpenTable(name);
                if (this.m_CountyTable == null)
                {
                    return;
                }
                name = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                this.m_TownTable = pfw.OpenTable(name);
                if (this.m_TownTable == null)
                {
                    return;
                }
                name = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                this.m_VillageTable = pfw.OpenTable(name);
                if (this.m_VillageTable == null)
                {
                    return;
                }
                this.InitialList();
                if (this.mEditKind == "造林")
                {
                    this.mEditKindCode = "ZaoLin";
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKindCode = "CaiFa";
                }
                else
                {
                    this.mEditKindCode = "";
                }
                string str4 = "";
                if (this.m_EditLayer == null)
                {
                    editDataset = QueryFun.GetEditDataset(this.mEditKindCode, pfw);
                    if (editDataset == null)
                    {
                        goto Label_0574;
                    }
                    string[] strArray = editDataset.Name.Split(new char[] { '_' });
                    string str5 = strArray[strArray.Length - 1];
                    str4 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer") + "_" + str5;
                }
                else
                {
                    editDataset = this.m_EditLayer.FeatureClass as IDataset;
                    str4 = editDataset.Name;
                    editDataset = this.m_EditLayer.FeatureClass.FeatureDataset;
                }
                IEnumDataset subsets = editDataset.Subsets;
                editDataset = subsets.Next();
                while (editDataset != null)
                {
                    if (str4 == editDataset.Name)
                    {
                        this.m_EditFeatureClass = editDataset as IFeatureClass;
                        break;
                    }
                    editDataset = subsets.Next();
                }
                this.imageListBoxControlY.Items.Clear();
                this.radioGroupYear.Properties.Items.Clear();
                this.mLayerList = new ArrayList();
                string str6 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer");
                if (this.m_EditFeatureClass != null)
                {
                    this.imageListBoxControlY.Items.Add(editDataset.Name.Substring(str6.Length + 1, (str4.Length - str6.Length) - 1) + "年", 1);
                    RadioGroupItem item = new RadioGroupItem(null, editDataset.Name.Substring(str6.Length + 1, (str4.Length - str6.Length) - 1) + "年");
                    this.radioGroupYear.Properties.Items.Add(item);
                    this.radioGroupYear.SelectedIndex = 0;
                    this.mLayerList.Add(this.m_EditFeatureClass);
                }
            Label_0574:
                str7 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "DatasetName2");
                str6 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer2");
                IFeatureDataset dataset3 = pfw.OpenFeatureDataset(str7) as IFeatureDataset;
                IEnumDataset dataset4 = dataset3.Subsets;
                IDataset dataset5 = dataset4.Next();
                IFeatureClass class2 = null;
                while (dataset5 != null)
                {
                    if (dataset5.Type == esriDatasetType.esriDTFeatureClass)
                    {
                        class2 = dataset5 as IFeatureClass;
                        if (dataset5.Name.Contains(str6) && (dataset5.Name.Length > str6.Length))
                        {
                            this.imageListBoxControlY.Items.Add(dataset5.Name.Substring(str6.Length + 1, (dataset5.Name.Length - str6.Length) - 1) + "年", 0);
                            RadioGroupItem item2 = new RadioGroupItem(null, dataset5.Name.Substring(str6.Length + 1, (dataset5.Name.Length - str6.Length) - 1) + "年");
                            this.radioGroupYear.Properties.Items.Add(item2);
                            this.mLayerList.Add(class2);
                        }
                    }
                    dataset5 = dataset4.Next();
                }
                this.mRangeList = new ArrayList();
                this.mKindList = new ArrayList();
                this.InitialQueryLayer();
                string str8 = "";
                string str9 = "";
                string str10 = "";
                string str11 = "";
                if (this.mEditKind == "造林")
                {
                    str8 = "T_CODE_FOR_OWNER";
                }
                else if (this.mEditKind == "采伐")
                {
                    str8 = "T_CODE_LAND_OWNE";
                    str9 = "T_CODE_LAND_USER";
                    str10 = "T_CODE_FOR_OWNER";
                    str11 = "T_CODE_FORS_USER";
                }
                this.mTableR = pfw.OpenTable(str8);
                this.cListBoxR.Items.Clear();
                this.mRightList = new ArrayList();
                int index = this.mTableR.Fields.FindField("name");
                int num2 = this.mTableR.Fields.FindField("code");
                ICursor cursor = this.mTableR.Search(null, false);
                for (row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    this.cListBoxR.Items.Add(row.get_Value(index), false);
                    this.mRightList.Add(row.get_Value(num2));
                }
                if (str9 != "")
                {
                    this.mTableR2 = pfw.OpenTable(str9);
                    this.cListBoxR2.Items.Clear();
                    this.mRightList2 = new ArrayList();
                    int num3 = this.mTableR2.Fields.FindField("name");
                    int num4 = this.mTableR2.Fields.FindField("code");
                    ICursor cursor2 = this.mTableR2.Search(null, false);
                    for (IRow row2 = cursor2.NextRow(); row2 != null; row2 = cursor2.NextRow())
                    {
                        this.cListBoxR2.Items.Add(row2.get_Value(num3), false);
                        this.mRightList2.Add(row2.get_Value(num4));
                    }
                }
                if (str10 != "")
                {
                    this.mTableR3 = pfw.OpenTable(str10);
                    this.cListBoxR3.Items.Clear();
                    this.mRightList3 = new ArrayList();
                    int num5 = this.mTableR3.Fields.FindField("name");
                    int num6 = this.mTableR3.Fields.FindField("code");
                    ICursor cursor3 = this.mTableR3.Search(null, false);
                    for (IRow row3 = cursor3.NextRow(); row3 != null; row3 = cursor3.NextRow())
                    {
                        this.cListBoxR3.Items.Add(row3.get_Value(num5), false);
                        this.mRightList3.Add(row3.get_Value(num6));
                    }
                }
                if (str11 != "")
                {
                    this.mTableR4 = pfw.OpenTable(str11);
                    this.cListBoxR4.Items.Clear();
                    this.mRightList4 = new ArrayList();
                    int num7 = this.mTableR4.Fields.FindField("name");
                    int num8 = this.mTableR4.Fields.FindField("code");
                    ICursor cursor4 = this.mTableR4.Search(null, false);
                    for (IRow row4 = cursor4.NextRow(); row4 != null; row4 = cursor4.NextRow())
                    {
                        this.cListBoxR4.Items.Add(row4.get_Value(num7), false);
                        this.mRightList4.Add(row4.get_Value(num8));
                    }
                }
                this.mTableL = pfw.OpenTable("T_CODE_LAND_TYPE");
                this.cListBoxL.Items.Clear();
                this.mLandList = new ArrayList();
                index = this.mTableL.Fields.FindField("name");
                num2 = this.mTableL.Fields.FindField("code");
                cursor = this.mTableL.Search(null, false);
                for (row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    this.cListBoxL.Items.Add(row.get_Value(index), false);
                    this.mLandList.Add(row.get_Value(num2));
                }
                this.mTableT = pfw.OpenTable("T_CODE_DOMSPECIE");
                this.cListBoxT.Items.Clear();
                this.mTreeList = new ArrayList();
                index = this.mTableT.Fields.FindField("name");
                num2 = this.mTableT.Fields.FindField("code");
                cursor = this.mTableT.Search(null, false);
                for (row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    this.cListBoxT.Items.Add(row.get_Value(index), false);
                    this.mTreeList.Add(row.get_Value(num2));
                }
                this.mTableF = pfw.OpenTable("T_CODE_FORS_SORT");
                this.cListBoxF.Items.Clear();
                this.mForList = new ArrayList();
                index = this.mTableF.Fields.FindField("name");
                num2 = this.mTableF.Fields.FindField("code");
                cursor = this.mTableF.Search(null, false);
                for (row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    this.cListBoxF.Items.Add(row.get_Value(index), false);
                    this.mForList.Add(row.get_Value(num2));
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListDesignKind_SelectImageClick(object sender, NodeClickEventArgs e)
        {
        }

        private void tListDesignKind_StateImageClick(object sender, NodeClickEventArgs e)
        {
            try
            {
                if (e.Node.StateImageIndex == 0)
                {
                    e.Node.StateImageIndex = 1;
                }
                else
                {
                    e.Node.StateImageIndex = 0;
                }
                if (e.Node.Nodes.Count > 0)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        e.Node.Nodes[i].StateImageIndex = e.Node.StateImageIndex;
                        if (e.Node.Nodes[i].Nodes.Count > 0)
                        {
                            for (int j = 0; j < e.Node.Nodes[i].Nodes.Count; j++)
                            {
                                e.Node.Nodes[i].Nodes[j].StateImageIndex = e.Node.Nodes[i].StateImageIndex;
                                if (e.Node.Nodes[i].Nodes[j].StateImageIndex == 1)
                                {
                                    try
                                    {
                                        this.mKindList.Add(e.Node.Nodes[i].Nodes[j].Tag);
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                                else
                                {
                                    this.mKindList.Remove(e.Node.Nodes[i].Nodes[j].Tag);
                                }
                            }
                        }
                        else if (e.Node.Nodes[i].StateImageIndex == 1)
                        {
                            try
                            {
                                this.mKindList.Add(e.Node.Nodes[i].Tag);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            this.mKindList.Remove(e.Node.Nodes[i].Tag);
                        }
                    }
                }
                else if (e.Node.StateImageIndex == 1)
                {
                    this.mKindList.Add(e.Node.Tag);
                }
                else
                {
                    this.mKindList.Remove(e.Node.Tag);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "tListDesignKind_StateImageClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListDist_StateImageClick(object sender, NodeClickEventArgs e)
        {
            try
            {
                if (e.Node.StateImageIndex == 0)
                {
                    e.Node.StateImageIndex = 1;
                }
                else
                {
                    e.Node.StateImageIndex = 0;
                }
                if (e.Node.Nodes.Count > 0)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        e.Node.Nodes[i].StateImageIndex = e.Node.StateImageIndex;
                        for (int j = 0; j < e.Node.Nodes[i].Nodes.Count; j++)
                        {
                            e.Node.Nodes[i].Nodes[j].StateImageIndex = e.Node.StateImageIndex;
                        }
                    }
                    if (e.Node.StateImageIndex == 1)
                    {
                        string str = e.Node.Tag.ToString();
                        for (int k = 0; k < this.mRangeList.Count; k++)
                        {
                            if ((this.mRangeList[k].ToString().Length > str.Length) && (this.mRangeList[k].ToString().Substring(0, str.Length) == str))
                            {
                                this.mRangeList.Remove(this.mRangeList[k]);
                            }
                        }
                        this.mRangeList.Add(e.Node.Tag);
                        bool flag = true;
                        for (int m = 0; m < e.Node.ParentNode.Nodes.Count; m++)
                        {
                            if (e.Node.ParentNode.Nodes[m].StateImageIndex == 0)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            for (int n = 0; n < e.Node.ParentNode.Nodes.Count; n++)
                            {
                                if (e.Node.ParentNode.Nodes[n].StateImageIndex == 1)
                                {
                                    this.mRangeList.Remove(e.Node.ParentNode.Nodes[n].Tag);
                                }
                            }
                            this.mRangeList.Add(e.Node.ParentNode.Tag);
                            e.Node.ParentNode.StateImageIndex = 1;
                        }
                    }
                    else
                    {
                        string str2 = e.Node.Tag.ToString();
                        for (int num6 = 0; num6 < this.mRangeList.Count; num6++)
                        {
                            if ((this.mRangeList[num6].ToString().Length > str2.Length) && (this.mRangeList[num6].ToString().Substring(0, str2.Length) == str2))
                            {
                                this.mRangeList.Remove(this.mRangeList[num6]);
                            }
                        }
                        int count = this.mRangeList.Count;
                        this.mRangeList.Remove(e.Node.Tag);
                        if (count == this.mRangeList.Count)
                        {
                            this.mRangeList.Remove(e.Node.ParentNode.Tag);
                            e.Node.ParentNode.StateImageIndex = 0;
                            for (int num8 = 0; num8 < e.Node.ParentNode.Nodes.Count; num8++)
                            {
                                if (e.Node.ParentNode.Nodes[num8].StateImageIndex == 1)
                                {
                                    this.mRangeList.Add(e.Node.ParentNode.Nodes[num8].Tag);
                                }
                            }
                        }
                    }
                }
                else if (e.Node.StateImageIndex == 1)
                {
                    this.mRangeList.Add(e.Node.Tag);
                    bool flag2 = true;
                    for (int num9 = 0; num9 < e.Node.ParentNode.Nodes.Count; num9++)
                    {
                        if (e.Node.ParentNode.Nodes[num9].StateImageIndex == 0)
                        {
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        for (int num10 = 0; num10 < e.Node.ParentNode.Nodes.Count; num10++)
                        {
                            if (e.Node.ParentNode.Nodes[num10].StateImageIndex == 1)
                            {
                                this.mRangeList.Remove(e.Node.ParentNode.Nodes[num10].Tag);
                            }
                        }
                        this.mRangeList.Add(e.Node.ParentNode.Tag);
                        e.Node.ParentNode.StateImageIndex = 1;
                        for (int num11 = 0; num11 < e.Node.ParentNode.ParentNode.Nodes.Count; num11++)
                        {
                            if (e.Node.ParentNode.ParentNode.Nodes[num11].StateImageIndex == 1)
                            {
                                this.mRangeList.Remove(e.Node.ParentNode.ParentNode.Nodes[num11].Tag);
                            }
                        }
                        this.mRangeList.Add(e.Node.ParentNode.ParentNode.Tag);
                        e.Node.ParentNode.ParentNode.StateImageIndex = 1;
                    }
                }
                else
                {
                    int num12 = this.mRangeList.Count;
                    this.mRangeList.Remove(e.Node.Tag);
                    if (num12 == this.mRangeList.Count)
                    {
                        this.mRangeList.Remove(e.Node.ParentNode.Tag);
                        if (num12 == this.mRangeList.Count)
                        {
                            this.mRangeList.Remove(e.Node.ParentNode.ParentNode.Tag);
                            e.Node.ParentNode.ParentNode.StateImageIndex = e.Node.StateImageIndex;
                            e.Node.ParentNode.StateImageIndex = e.Node.StateImageIndex;
                            for (int num13 = 0; num13 < e.Node.ParentNode.Nodes.Count; num13++)
                            {
                                if (e.Node.ParentNode.Nodes[num13].StateImageIndex == 1)
                                {
                                    this.mRangeList.Add(e.Node.ParentNode.Nodes[num13].Tag);
                                }
                            }
                            for (int num14 = 0; num14 < e.Node.ParentNode.ParentNode.Nodes.Count; num14++)
                            {
                                if (e.Node.ParentNode.ParentNode.Nodes[num14].StateImageIndex == 1)
                                {
                                    this.mRangeList.Add(e.Node.ParentNode.ParentNode.Nodes[num14].Tag);
                                }
                            }
                        }
                        else
                        {
                            e.Node.ParentNode.StateImageIndex = e.Node.StateImageIndex;
                            for (int num15 = 0; num15 < e.Node.ParentNode.Nodes.Count; num15++)
                            {
                                if (e.Node.ParentNode.Nodes[num15].StateImageIndex == 1)
                                {
                                    this.mRangeList.Add(e.Node.ParentNode.Nodes[num15].Tag);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTypes", "tListDesignKind_StateImageClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public ArrayList QueryList
        {
            get
            {
                return this.mQueryList;
            }
            set
            {
                this.mQueryList = value;
            }
        }
    }
}

