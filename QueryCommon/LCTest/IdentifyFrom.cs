namespace LCTest
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using Identify;
    using jn.isos.log;
    using QueryCommon;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class IdentifyFrom : FormBase2
    {
        private IActiveViewEvents_Event activeViewEvents;
        private const string AllLayers = "<所有图层>";
        private AxMapControl associateMapControl;
        private Bar bar3;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonItem5;
        private BarButtonItem barButtonItem6;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarEditItem barEditItem1;
        private BarEditItem barEditItem2;
        private BarEditItem barEditItem3;
        private BarEditItem barEditItem4;
        private BarEditItem barEditItem5;
        private BarEditItem barEditItem6;
        private BarManager barManager1;
        private BarStaticItem barStaticItem1;
        private Dictionary<int, int> cc = new Dictionary<int, int>();
        private CheckEdit checkEditShow;
        private Dictionary<int, int> ck = new Dictionary<int, int>();
        private IContainer components;
        private TreeListNode deletenode;
        private bool flag;
        private FlashObjectsClass flashObjects;
        private GridControl gridControl;
        private List<LayerIdentifiedResult> identifiedResultsList;
        private IGeometry identifyEnvelope;
        private List<LayerFilterProperties> layerFilterSet;
        private BarStaticItem lblFeatureCount;
        private LabelControl lblHitPointHeader;
        private LabelControl lblLayers;
        private GridView lstProperties;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PopupMenu popupMenu1;
        private const string SelectableLayers = "<可选图层>";
        private SplitContainerControl splitContainerControl1;
        private const string TopMostLayer = "<最顶图层>";
        private INewEnvelopeFeedback2 trackNewEnvelope;
        private TreeList trvDataList;
        private TextEdit txtCoordinate;
        private UserControlIdentify userControlIdentify1;
        private const string VisibleLayers = "<可见图层>";
        private Logger m_log = LoggerManager.CreateLogger("UI", typeof(IdentifyFrom));
        private IdentifyFrom()
        {
            this.InitializeComponent();
        }

        public void AfterClickQuery()
        {
            if (this.identifyEnvelope != null)
            {
                this.userControlIdentify1.flag = false;
                List<LayerFilterProperties> searchLayers = this.SearchIdentifyLayers();
                this.ExecuteIdentify(searchLayers, this.identifyEnvelope);
                this.DisplayIdentifyResults();
                this.flashObjects.FlashObjects();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode focusedNode = this.trvDataList.FocusedNode;
            if ((focusedNode != null) && (focusedNode.Level != 0))
            {
                int num = this.ck[focusedNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[focusedNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature row = (obj2 as IRowIdentifyObject).Row as IFeature;
                HookHelperClass class2 = new HookHelperClass();
                class2.Hook = this.associateMapControl.Object;
                IHookActions actions = class2;
                class2.ActiveView.ScreenDisplay.UpdateWindow();
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsFlash);
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode focusedNode = this.trvDataList.FocusedNode;
            if ((focusedNode != null) && (focusedNode.Level != 0))
            {
                int num = this.ck[focusedNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[focusedNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature row = (obj2 as IRowIdentifyObject).Row as IFeature;
                HookHelperClass class2 = new HookHelperClass();
                class2.Hook = this.associateMapControl.Object;
                IHookActions actions = class2;
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsZoom);
                Application.DoEvents();
                class2.ActiveView.ScreenDisplay.UpdateWindow();
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsFlash);
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode focusedNode = this.trvDataList.FocusedNode;
            if ((focusedNode != null) && (focusedNode.Level != 0))
            {
                int num = this.ck[focusedNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[focusedNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature row = (obj2 as IRowIdentifyObject).Row as IFeature;
                HookHelperClass class2 = new HookHelperClass();
                class2.Hook = this.associateMapControl.Object;
                IHookActions actions = class2;
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsPan);
                Application.DoEvents();
                class2.ActiveView.ScreenDisplay.UpdateWindow();
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsFlash);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode focusedNode = this.trvDataList.FocusedNode;
            if ((focusedNode != null) && (focusedNode.Level != 0))
            {
                int num = this.ck[focusedNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                ILayer identifyLayer = result.IdentifyLayer;
                int num2 = this.cc[focusedNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature row = (obj2 as IRowIdentifyObject).Row as IFeature;
                this.associateMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                this.associateMapControl.Map.SelectFeature(identifyLayer, row);
                this.associateMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.associateMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            this.associateMapControl.Map.ClearSelection();
            this.associateMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.trvDataList.DeleteNode(this.deletenode);
        }

        private void BindDataToGrid1(TreeListNode pNode)
        {
            if (pNode != null)
            {
                DataTable table = new DataTable();
                DataRow row = null;
                table.Columns.Add("字段");
                table.Columns.Add("值");
                int count = this.identifiedResultsList.Count;
                int num = this.ck[pNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[pNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature feature = (obj2 as IRowIdentifyObject).Row as IFeature;
                IGeometry shape = feature.Shape;
                this.flashObjects.AddGeometry(shape);
                if (feature != null)
                {
                    int fieldCount = feature.Fields.FieldCount;
                    for (int i = 0; i < fieldCount; i++)
                    {
                        IField field = feature.Fields.get_Field(i);
                        string aliasName = field.AliasName;
                        if (aliasName == feature.Class.OIDFieldName)
                        {
                            aliasName = "对象标识";
                        }
                        else if (aliasName == (feature.Class as IFeatureClass).ShapeFieldName)
                        {
                            aliasName = "形状";
                        }
                        else if (aliasName.ToLower().Contains("area"))
                        {
                            aliasName = "面积";
                        }
                        else if (aliasName.ToLower().Contains("length"))
                        {
                            aliasName = "周长";
                        }
                        string str2 = string.Empty;
                        if (field.Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            switch (shape.GeometryType)
                            {
                                case esriGeometryType.esriGeometryPoint:
                                    str2 = "点";
                                    break;

                                case esriGeometryType.esriGeometryPolyline:
                                    str2 = "线";
                                    break;

                                case esriGeometryType.esriGeometryPolygon:
                                    str2 = "面";
                                    break;
                            }
                        }
                        else if ((field.Domain != null) && (field.Domain is ICodedValueDomain))
                        {
                            ICodedValueDomain domain = field.Domain as ICodedValueDomain;
                            for (int j = 0; j < domain.CodeCount; j++)
                            {
                                if (domain.get_Value(j).ToString() == feature.get_Value(i).ToString().Trim())
                                {
                                    str2 = domain.get_Name(j);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            str2 = feature.get_Value(i).ToString();
                        }
                        row = table.NewRow();
                        row["字段"] = aliasName;
                        row["值"] = str2;
                        table.Rows.Add(row);
                    }
                    this.gridControl.DataSource = table;
                }
            }
        }

        private void BindDataToGrid2(TreeListNode pNode)
        {
            if (pNode != null)
            {
                DataTable table = new DataTable();
                DataRow row = null;
                table.Columns.Add("字段");
                table.Columns.Add("值");
                int count = this.identifiedResultsList.Count;
                int num = this.ck[pNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[pNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature feature = (obj2 as IRowIdentifyObject).Row as IFeature;
                IGeometry shape = feature.Shape;
                this.flashObjects.AddGeometry(shape);
                if (feature != null)
                {
                    int fieldCount = feature.Fields.FieldCount;
                    for (int i = 0; i < fieldCount; i++)
                    {
                        IField field = feature.Fields.get_Field(i);
                        string name = field.Name;
                        if (name == feature.Class.OIDFieldName)
                        {
                            name = "对象标识";
                        }
                        else if (name == (feature.Class as IFeatureClass).ShapeFieldName)
                        {
                            name = "形状";
                        }
                        else if (name.ToLower().Contains("area"))
                        {
                            name = "面积";
                        }
                        else if (name.ToLower().Contains("length"))
                        {
                            name = "周长";
                        }
                        else
                        {
                            name = field.AliasName;
                        }
                        string str2 = string.Empty;
                        if (field.Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            switch (shape.GeometryType)
                            {
                                case esriGeometryType.esriGeometryPoint:
                                    str2 = "点";
                                    break;

                                case esriGeometryType.esriGeometryPolyline:
                                    str2 = "线";
                                    break;

                                case esriGeometryType.esriGeometryPolygon:
                                    str2 = "面";
                                    break;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(feature.get_Value(i).ToString().Trim()) || (feature.get_Value(i).ToString().Trim() == "0"))
                            {
                                continue;
                            }
                            if ((field.Domain != null) && (field.Domain is ICodedValueDomain))
                            {
                                ICodedValueDomain domain = field.Domain as ICodedValueDomain;
                                for (int j = 0; j < domain.CodeCount; j++)
                                {
                                    if (domain.get_Value(j).ToString() == feature.get_Value(i).ToString().Trim())
                                    {
                                        str2 = domain.get_Name(j);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                str2 = feature.get_Value(i).ToString();
                            }
                        }
                        row = table.NewRow();
                        row["字段"] = name;
                        row["值"] = str2;
                        table.Rows.Add(row);
                    }
                    this.gridControl.DataSource = table;
                }
            }
        }

        private void checkEditShow_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (this.trvDataList.Nodes.Count != 0)
            {
                TreeListNode pNode = null;
                if (this.trvDataList.FocusedNode == null)
                {
                    pNode = this.trvDataList.Nodes.FirstNode.FirstNode;
                }
                else
                {
                    pNode = (this.trvDataList.FocusedNode.Level == 0) ? this.trvDataList.FocusedNode.FirstNode : this.trvDataList.FocusedNode;
                }
                if (edit.Checked)
                {
                    this.BindDataToGrid2(pNode);
                }
                else
                {
                    this.BindDataToGrid1(pNode);
                }
            }
        }

        public static IdentifyFrom CreateInstance(AxMapControl IdentifyMap)
        {
            IdentifyFrom getInstance = Nested.GetInstance;
            getInstance.ImportReference(IdentifyMap);
            return getInstance;
        }

        private void DisplayCoordinates(double mapX, double mapY)
        {
            if (!base.IsDisposed)
            {
                this.txtCoordinate.Text = string.Format("{0}, {1}", mapX.ToString("########.##"), mapY.ToString("########.##")) + " " + this.MapUnitChinese(this.associateMapControl.MapUnits);
            }
        }

        private void DisplayIdentifyResults()
        {
            this.trvDataList.Nodes.Clear();
            this.ck.Clear();
            this.cc.Clear();
            this.lstProperties.Columns.Clear();
            List<IFeatureIdentifyObj> identifiedFeatureObjList = null;
            IFeatureIdentifyObj obj2 = null;
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add("ID");
            table.Columns.Add("图层信息");
            table.Columns.Add("ParentID");
            int count = this.identifiedResultsList.Count;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                LayerIdentifiedResult result = this.identifiedResultsList[i];
                row = table.NewRow();
                string name = result.IdentifyLayer.Name;
                row["ID"] = name + i;
                row["图层信息"] = name;
                row["ParentID"] = -1;
                table.Rows.Add(row);
                identifiedFeatureObjList = result.IdentifiedFeatureObjList;
                for (int j = 0; j < identifiedFeatureObjList.Count; j++)
                {
                    obj2 = identifiedFeatureObjList[j];
                    IRowIdentifyObject obj3 = obj2 as IRowIdentifyObject;
                    IFeature feature = obj3.Row as IFeature;
                    int index = feature.Fields.FindField(feature.Class.OIDFieldName);
                    if (index == -1)
                    {
                        return;
                    }
                    string text1 = feature.Fields.get_Field(index).Name;
                    string str2 = feature.get_Value(index).ToString();
                    row = table.NewRow();
                    row["ID"] = name + str2 + i;
                    row["图层信息"] = str2;
                    row["ParentID"] = name + i;
                    this.ck.Add((num2 + j) + 1, i);
                    this.cc.Add((num2 + j) + 1, j);
                    table.Rows.Add(row);
                }
                num2 = (this.ck.Count + 1) + i;
            }
            if (table.Rows.Count > 0)
            {
                this.trvDataList.DataSource = table;
                this.trvDataList.ParentFieldName = "ParentID";
                this.trvDataList.ExpandAll();
                TreeListNode pNode = null;
                if (this.trvDataList.FocusedNode == null)
                {
                    pNode = this.trvDataList.Nodes.FirstNode.FirstNode;
                }
                else
                {
                    pNode = (this.trvDataList.FocusedNode.Level == 0) ? this.trvDataList.FocusedNode.FirstNode : this.trvDataList.FocusedNode;
                }
                if (this.checkEditShow.CheckState == CheckState.Checked)
                {
                    this.BindDataToGrid2(pNode);
                }
                else
                {
                    this.BindDataToGrid1(pNode);
                }
            }
        }

        private void DisplayLayersFromMapControl()
        {
            IMap map = this.associateMapControl.Map;
            if (map.LayerCount >= 1)
            {
                IEnumLayer o = map.get_Layers(null, true);
                o.Reset();
                for (ILayer layer2 = o.Next(); layer2 != null; layer2 = o.Next())
                {
                    LayerFilterProperties item = new LayerFilterProperties();
                    item.LayerCategory = string.Empty;
                    item.LayerFilterName = layer2.Name;
                    IFeatureLayer feaLyr = layer2 as IFeatureLayer;
                    if (null == feaLyr) continue;
                    if (null == feaLyr.FeatureClass)
                    {
                        m_log.Warn("no layer exist:" + feaLyr.Name);
                        continue;
                    }
                    item.LayerFeatureType = this.GetLayerFeatureType(layer2);
                    item.TargetLayer = layer2;
                    this.layerFilterSet.Add(item);
                }
                Marshal.ReleaseComObject(o);
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

        private void ExecuteIdentify(List<LayerFilterProperties> searchLayers, IGeometry identifyGeom)
        {
            object missing = System.Type.Missing;
            this.identifiedResultsList.Clear();
            int num = 0;
            int count = searchLayers.Count;
            this.flashObjects.MapControl = this.associateMapControl.Object as IMapControl2;
            this.flashObjects.Init();
            for (int i = 0; i < count; i++)
            {
                LayerFilterProperties properties = searchLayers[i];
                ILayer targetLayer = properties.TargetLayer;
                LayerIdentifiedResult item = new LayerIdentifiedResult();
                item.IdentifyLayer = targetLayer;
                item.GeometryType = properties.LayerFeatureType;
                List<IFeatureIdentifyObj> identifiedFeatureObjList = item.IdentifiedFeatureObjList;
                IArray array = this.Identify(targetLayer, identifyGeom);
                if (array != null)
                {
                    for (int j = 0; j < array.Count; j++)
                    {
                        num++;
                        IFeatureIdentifyObj obj2 = array.get_Element(j) as IFeatureIdentifyObj;
                        identifiedFeatureObjList.Add(obj2);
                    }
                    this.identifiedResultsList.Add(item);
                }
            }
            this.lblFeatureCount.Caption = "查询到 " + num + " 条记录";
        }

        private LayerFeatureType GetLayerFeatureType(ILayer layer)
        {
            LayerFeatureType none = LayerFeatureType.None;
            if (layer is IFeatureLayer)
            {
                switch ((layer as IFeatureLayer).FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        return LayerFeatureType.Point;

                    case esriGeometryType.esriGeometryMultipoint:
                        return none;

                    case esriGeometryType.esriGeometryPolyline:
                        return LayerFeatureType.Polyline;

                    case esriGeometryType.esriGeometryPolygon:
                        return LayerFeatureType.Polygon;
                }
                return none;
            }
            if (layer is IRasterLayer)
            {
                return LayerFeatureType.Raster;
            }
            if (layer is IGroupLayer)
            {
                return LayerFeatureType.GroupLayer;
            }
            return LayerFeatureType.Other;
        }

        private IArray Identify(ILayer identifyLayer, IGeometry identifyGeom)
        {
            if (identifyGeom != null)
            {
                IGeometry pGeom = identifyGeom;
                if (pGeom.GeometryType == esriGeometryType.esriGeometryPoint)
                {
                    pGeom = (identifyGeom as ITopologicalOperator).Buffer(2.0);
                }
                if (identifyLayer is IFeatureLayer)
                {
                    IFeatureLayer layer = identifyLayer as IFeatureLayer;
                    IIdentify2 identify = layer as IIdentify2;
                    return identify.Identify(pGeom, null);
                }
                IRasterLayer layer1 = identifyLayer as IRasterLayer;
            }
            return null;
        }

        private void IdentifyFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.activeViewEvents.ItemAdded-=(new IActiveViewEvents_ItemAddedEventHandler(this.InitializeLayerFilters));
            this.activeViewEvents.ItemDeleted-=(new IActiveViewEvents_ItemDeletedEventHandler(this.InitializeLayerFilters));
            this.associateMapControl.OnMapReplaced -= new IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.OnMapReplaced);
            this.layerFilterSet.Clear();
            this.identifiedResultsList.Clear();
        }

        private void IdentifyFrom_Load(object sender, EventArgs e)
        {
            this.flashObjects = new FlashObjectsClass();
            this.layerFilterSet = new List<LayerFilterProperties>();
            this.identifiedResultsList = new List<LayerIdentifiedResult>();
            this.InitializeLayerFilters(null);
        }

        private void ImportReference(AxMapControl IdentifyMap)
        {
            if (IdentifyMap == null)
            {
                throw new NotImplementedException();
            }
            this.associateMapControl = IdentifyMap;
            this.associateMapControl.OnMapReplaced += new IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.OnMapReplaced);
            this.InitializeActiveViewEvents();
        }

        private void InitializeActiveViewEvents()
        {
            this.activeViewEvents = this.associateMapControl.Map as IActiveViewEvents_Event;
            this.activeViewEvents.ItemAdded+=(new IActiveViewEvents_ItemAddedEventHandler(this.InitializeLayerFilters));
            this.activeViewEvents.ItemDeleted+=(new IActiveViewEvents_ItemDeletedEventHandler(this.InitializeLayerFilters));
        }

        private void InitializeBasicLayerFilters()
        {
            LayerFilterProperties item = new LayerFilterProperties();
            item.LayerCategory = string.Empty;
            item.LayerFeatureType = LayerFeatureType.None;
            item.LayerFilterName = "<最顶图层>";
            item.TargetLayer = null;
            LayerFilterProperties properties2 = new LayerFilterProperties();
            properties2.LayerCategory = string.Empty;
            properties2.LayerFeatureType = LayerFeatureType.None;
            properties2.LayerFilterName = "<可见图层>";
            properties2.TargetLayer = null;
            LayerFilterProperties properties3 = new LayerFilterProperties();
            properties3.LayerCategory = string.Empty;
            properties3.LayerFeatureType = LayerFeatureType.None;
            properties3.LayerFilterName = "<可选图层>";
            properties3.TargetLayer = null;
            LayerFilterProperties properties4 = new LayerFilterProperties();
            properties4.LayerCategory = string.Empty;
            properties4.LayerFeatureType = LayerFeatureType.None;
            properties4.LayerFilterName = "<所有图层>";
            properties4.TargetLayer = null;
            this.layerFilterSet.Add(item);
            this.layerFilterSet.Add(properties2);
            this.layerFilterSet.Add(properties3);
            this.layerFilterSet.Add(properties4);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblLayers = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.userControlIdentify1 = new QueryCommon.UserControlIdentify();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.trvDataList = new DevExpress.XtraTreeList.TreeList();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.checkEditShow = new DevExpress.XtraEditors.CheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblFeatureCount = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.lstProperties = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblHitPointHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtCoordinate = new DevExpress.XtraEditors.TextEdit();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem5 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem4 = new DevExpress.XtraBars.BarEditItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblLayers);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(0, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(515, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // lblLayers
            // 
            this.lblLayers.Location = new System.Drawing.Point(9, 9);
            this.lblLayers.Name = "lblLayers";
            this.lblLayers.Size = new System.Drawing.Size(60, 14);
            this.lblLayers.TabIndex = 1;
            this.lblLayers.Text = "查询图层：";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.userControlIdentify1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(73, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(440, 28);
            this.panelControl2.TabIndex = 0;
            // 
            // userControlIdentify1
            // 
            this.userControlIdentify1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlIdentify1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlIdentify1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlIdentify1.Appearance.Options.UseBackColor = true;
            this.userControlIdentify1.Location = new System.Drawing.Point(5, 3);
            this.userControlIdentify1.Name = "userControlIdentify1";
            this.userControlIdentify1.Size = new System.Drawing.Size(430, 21);
            this.userControlIdentify1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 34);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.trvDataList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(515, 268);
            this.splitContainerControl1.SplitterPosition = 135;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // trvDataList
            // 
            this.trvDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDataList.Location = new System.Drawing.Point(0, 0);
            this.trvDataList.Name = "trvDataList";
            this.trvDataList.OptionsBehavior.Editable = false;
            this.trvDataList.OptionsView.ShowIndicator = false;
            this.trvDataList.Size = new System.Drawing.Size(135, 268);
            this.trvDataList.TabIndex = 0;
            this.trvDataList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trvDataList_FocusedNodeChanged);
            this.trvDataList.DoubleClick += new System.EventHandler(this.trvDataList_DoubleClick);
            this.trvDataList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDataList_MouseDown);
            // 
            // panelControl5
            // 
            this.panelControl5.AutoSize = true;
            this.panelControl5.Controls.Add(this.checkEditShow);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl5.Location = new System.Drawing.Point(277, 31);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(98, 29);
            this.panelControl5.TabIndex = 3;
            // 
            // checkEditShow
            // 
            this.checkEditShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkEditShow.Location = new System.Drawing.Point(2, 2);
            this.checkEditShow.MenuManager = this.barManager1;
            this.checkEditShow.Name = "checkEditShow";
            this.checkEditShow.Properties.Caption = "显示有值属性";
            this.checkEditShow.Size = new System.Drawing.Size(94, 19);
            this.checkEditShow.TabIndex = 4;
            this.checkEditShow.CheckedChanged += new System.EventHandler(this.checkEditShow_CheckedChanged);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblFeatureCount,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6});
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblFeatureCount)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lblFeatureCount
            // 
            this.lblFeatureCount.Caption = "查询到 0 条记录";
            this.lblFeatureCount.Id = 0;
            this.lblFeatureCount.Name = "lblFeatureCount";
            this.lblFeatureCount.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(518, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 304);
            this.barDockControlBottom.Size = new System.Drawing.Size(518, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 304);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(518, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 304);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "闪烁";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "缩放";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "平移";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "选中";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "撤销选中";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "移除节点";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl.Location = new System.Drawing.Point(0, 60);
            this.gridControl.MainView = this.lstProperties;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(375, 208);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.lstProperties});
            // 
            // lstProperties
            // 
            this.lstProperties.GridControl = this.gridControl;
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.OptionsBehavior.Editable = false;
            this.lstProperties.OptionsView.ShowGroupPanel = false;
            this.lstProperties.OptionsView.ShowIndicator = false;
            this.lstProperties.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.lstProperties_CustomDrawEmptyForeground);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.lblHitPointHeader);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(375, 31);
            this.panelControl3.TabIndex = 0;
            // 
            // lblHitPointHeader
            // 
            this.lblHitPointHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHitPointHeader.Location = new System.Drawing.Point(2, 2);
            this.lblHitPointHeader.Name = "lblHitPointHeader";
            this.lblHitPointHeader.Size = new System.Drawing.Size(60, 14);
            this.lblHitPointHeader.TabIndex = 1;
            this.lblHitPointHeader.Text = "点击位置：";
            // 
            // panelControl4
            // 
            this.panelControl4.AutoSize = true;
            this.panelControl4.Controls.Add(this.txtCoordinate);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(69, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(304, 27);
            this.panelControl4.TabIndex = 0;
            // 
            // txtCoordinate
            // 
            this.txtCoordinate.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtCoordinate.Location = new System.Drawing.Point(2, 2);
            this.txtCoordinate.Name = "txtCoordinate";
            this.txtCoordinate.Properties.ReadOnly = true;
            this.txtCoordinate.Size = new System.Drawing.Size(300, 20);
            this.txtCoordinate.TabIndex = 0;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 1;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Tag = "\\";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = null;
            this.barEditItem2.Id = 2;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "barEditItem3";
            this.barEditItem3.Edit = null;
            this.barEditItem3.Id = 3;
            this.barEditItem3.Name = "barEditItem3";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItem5
            // 
            this.barEditItem5.Caption = "barEditItem5";
            this.barEditItem5.Edit = null;
            this.barEditItem5.Id = 7;
            this.barEditItem5.Name = "barEditItem5";
            // 
            // barEditItem6
            // 
            this.barEditItem6.Caption = "barEditItem6";
            this.barEditItem6.Edit = null;
            this.barEditItem6.Id = 8;
            this.barEditItem6.Name = "barEditItem6";
            // 
            // barEditItem4
            // 
            this.barEditItem4.Caption = "  s ";
            this.barEditItem4.Edit = null;
            this.barEditItem4.Id = 9;
            this.barEditItem4.Name = "barEditItem4";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // IdentifyFrom
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(518, 331);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdentifyFrom";
            this.Text = "属性查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IdentifyFrom_FormClosed);
            this.Load += new System.EventHandler(this.IdentifyFrom_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeLayerFilters(object item)
        {
            this.layerFilterSet.Clear();
            this.InitializeBasicLayerFilters();
            this.DisplayLayersFromMapControl();
            this.userControlIdentify1.DisplayLayerFilters1(this.layerFilterSet);
        }

        private void lstProperties_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (this.lstProperties.RowCount == 0)
            {
                string s = "没有选中要查询的要素。";
                Font font = new Font("宋体", 10f, FontStyle.Bold);
                Rectangle layoutRectangle = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(s, font, Brushes.Black, layoutRectangle);
            }
        }

        private string MapUnitChinese(esriUnits mapUnit)
        {
            string str = "未知单位";
            switch (mapUnit)
            {
                case esriUnits.esriMiles:
                    return "英里";

                case esriUnits.esriNauticalMiles:
                    return str;

                case esriUnits.esriMillimeters:
                    return "毫米";

                case esriUnits.esriCentimeters:
                    return "厘米";

                case esriUnits.esriMeters:
                    return "米";

                case esriUnits.esriKilometers:
                    return "千米";

                case esriUnits.esriDecimalDegrees:
                    return "度";

                case esriUnits.esriDecimeters:
                    return "分米";
            }
            return str;
        }

        private void OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            this.InitializeActiveViewEvents();
            this.InitializeLayerFilters(null);
        }

        public void OnMouseDown(int button, double mapX, double mapY)
        {
            if (!base.IsDisposed && (button == 1))
            {
                this.DisplayCoordinates(mapX, mapY);
                IPoint point = new PointClass();
                point.PutCoords(mapX, mapY);
                point.SpatialReference = this.associateMapControl.SpatialReference;
                if ((this.trackNewEnvelope == null) && this.flag)
                {
                    this.trackNewEnvelope = new NewEnvelopeFeedbackClass();
                    this.trackNewEnvelope.Display = this.associateMapControl.ActiveView.ScreenDisplay;
                    this.trackNewEnvelope.Start(point);
                }
                else
                {
                    this.identifyEnvelope = (point as ITopologicalOperator).Buffer(2.0);
                    List<LayerFilterProperties> searchLayers = this.SearchIdentifyLayers();
                    if ((searchLayers == null) || (searchLayers.Count < 1))
                    {
                        return;
                    }
                    this.lblFeatureCount.Caption = "正在查询...";
                    Application.DoEvents();
                    this.ExecuteIdentify(searchLayers, this.identifyEnvelope);
                    this.DisplayIdentifyResults();
                    this.flashObjects.FlashObjects();
                }
                this.flag = true;
            }
        }

        public void OnMouseMove(double mapX, double mapY)
        {
            if (this.trackNewEnvelope != null)
            {
                IPoint point = new PointClass();
                point.PutCoords(mapX, mapY);
                point.SpatialReference = this.associateMapControl.SpatialReference;
                this.DisplayCoordinates(mapX, mapY);
                this.trackNewEnvelope.MoveTo(point);
            }
        }

        public void OnMouseUp(double mapX, double mapY)
        {
            if (this.trackNewEnvelope != null)
            {
                this.DisplayCoordinates(mapX, mapY);
                this.identifyEnvelope = this.trackNewEnvelope.Stop();
                if (this.identifyEnvelope.IsEmpty)
                {
                    IPoint point = new PointClass();
                    point.PutCoords(mapX, mapY);
                    point.SpatialReference = this.associateMapControl.SpatialReference;
                    this.identifyEnvelope = (point as ITopologicalOperator).Buffer(2.0);
                }
                this.identifyEnvelope.SpatialReference = this.associateMapControl.SpatialReference;
                this.trackNewEnvelope = null;
                List<LayerFilterProperties> searchLayers = this.SearchIdentifyLayers();
                if ((searchLayers != null) && (searchLayers.Count >= 1))
                {
                    this.lblFeatureCount.Caption = "正在查询...";
                    Application.DoEvents();
                    this.ExecuteIdentify(searchLayers, this.identifyEnvelope);
                    this.DisplayIdentifyResults();
                    this.flashObjects.FlashObjects();
                }
            }
        }

        private List<LayerFilterProperties> SearchIdentifyLayers()
        {
            List<LayerFilterProperties> list = null;
            LayerFilterProperties properties = this.userControlIdentify1.SearchIdentifyLayers1(this.layerFilterSet);
            switch (properties.LayerFilterName)
            {
                case "<所有图层>":
                    return this.getAllLayers;

                case "<可选图层>":
                    return this.getSelectableLayers;

                case "<可见图层>":
                    return this.getVisibleLayers;

                case "<最顶图层>":
                    if (this.getTopmostLayer != null)
                    {
                        list = new List<LayerFilterProperties>();
                        list.Add(this.getTopmostLayer);
                    }
                    return list;
            }
            if (properties.LayerFeatureType == LayerFeatureType.GroupLayer)
            {
                return this.getGroupLayers;
            }
            list = new List<LayerFilterProperties>();
            list.Add(this.getTargetLayer);
            return list;
        }

        private void trvDataList_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode focusedNode = this.trvDataList.FocusedNode;
            if ((focusedNode != null) && (focusedNode.Level != 0))
            {
                int num = this.ck[focusedNode.Id];
                LayerIdentifiedResult result = this.identifiedResultsList[num];
                int num2 = this.cc[focusedNode.Id];
                IFeatureIdentifyObj obj2 = result.IdentifiedFeatureObjList[num2];
                IFeature row = (obj2 as IRowIdentifyObject).Row as IFeature;
                HookHelperClass class2 = new HookHelperClass();
                class2.Hook = this.associateMapControl.Object;
                IHookActions actions = class2;
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsZoom);
                Application.DoEvents();
                class2.ActiveView.ScreenDisplay.UpdateWindow();
                actions.DoAction(row.Shape, esriHookActions.esriHookActionsFlash);
            }
        }

        private void trvDataList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.deletenode = e.Node;
            if (((e.Node == null) || !e.Node.HasChildren) && ((e.Node != null) && (e.Node.ParentNode != null)))
            {
                if (this.checkEditShow.CheckState == CheckState.Checked)
                {
                    this.BindDataToGrid2(e.Node);
                }
                else
                {
                    this.BindDataToGrid1(e.Node);
                }
            }
        }

        private void trvDataList_MouseDown(object sender, MouseEventArgs e)
        {
            TreeList list = sender as TreeList;
            if (((e.Button == MouseButtons.Right) && (Control.ModifierKeys == Keys.None)) && (this.trvDataList.State == TreeListState.Regular))
            {
                System.Drawing.Point p = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
                TreeListHitInfo info = list.CalcHitInfo(e.Location);
                if (((info.Node != null) && (info.HitInfoType == HitInfoType.Cell)) && (info.Node.RootNode.Id != info.Node.Id))
                {
                    list.SetFocusedNode(info.Node);
                    this.popupMenu1.ShowPopup(p);
                }
            }
        }

        private List<LayerFilterProperties> getAllLayers
        {
            get
            {
                List<LayerFilterProperties> list = new List<LayerFilterProperties>();
                int count = this.layerFilterSet.Count;
                for (int i = 4; i < count; i++)
                {
                    LayerFilterProperties item = this.layerFilterSet[i];
                    if (item.LayerFeatureType != LayerFeatureType.GroupLayer)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        private List<LayerFilterProperties> getGroupLayers
        {
            get
            {
                List<LayerFilterProperties> list = new List<LayerFilterProperties>();
                int selectedIndex = this.userControlIdentify1.selectedIndex;
                LayerFilterProperties item = this.layerFilterSet[0];
                selectedIndex++;
                while (selectedIndex < this.layerFilterSet.Count)
                {
                    if (item.LayerFeatureType == LayerFeatureType.GroupLayer)
                    {
                        return list;
                    }
                    item = this.layerFilterSet[selectedIndex];
                    list.Add(item);
                    selectedIndex++;
                }
                return list;
            }
        }

        private List<LayerFilterProperties> getSelectableLayers
        {
            get
            {
                List<LayerFilterProperties> list = new List<LayerFilterProperties>();
                int count = this.layerFilterSet.Count;
                for (int i = 4; i < count; i++)
                {
                    LayerFilterProperties item = this.layerFilterSet[i];
                    ILayer targetLayer = item.TargetLayer;
                    if (((item.LayerFeatureType != LayerFeatureType.GroupLayer) && (item.LayerFeatureType != LayerFeatureType.Other)) && (targetLayer as IFeatureLayer).Selectable)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        private LayerFilterProperties getTargetLayer
        {
            get
            {
                int selectedIndex = this.userControlIdentify1.selectedIndex;
                return this.layerFilterSet[selectedIndex];
            }
        }

        private LayerFilterProperties getTopmostLayer
        {
            get
            {
                int count = this.layerFilterSet.Count;
                for (int i = 4; i < count; i++)
                {
                    LayerFilterProperties properties2 = this.layerFilterSet[i];
                    ILayer targetLayer = properties2.TargetLayer;
                    if (properties2.LayerFeatureType != LayerFeatureType.GroupLayer)
                    {
                        return properties2;
                    }
                }
                return null;
            }
        }

        private List<LayerFilterProperties> getVisibleLayers
        {
            get
            {
                List<LayerFilterProperties> list = new List<LayerFilterProperties>();
                int count = this.layerFilterSet.Count;
                for (int i = 4; i < count; i++)
                {
                    LayerFilterProperties item = this.layerFilterSet[i];
                    ILayer targetLayer = item.TargetLayer;
                    if ((item.LayerFeatureType != LayerFeatureType.GroupLayer) && targetLayer.Visible)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        internal class Nested
        {
            private static IdentifyFrom instance;

            internal static IdentifyFrom GetInstance
            {
                get
                {
                    if ((instance == null) || instance.IsDisposed)
                    {
                        instance = new IdentifyFrom();
                    }
                    return instance;
                }
            }
        }
    }
}

