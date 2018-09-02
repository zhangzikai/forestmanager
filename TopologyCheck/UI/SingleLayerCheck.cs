namespace TopologyCheck.UI
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using TopologyCheck;
    using TopologyCheck.Checker;
    using TopologyCheck.Error;
    using TopologyCheck.TopologyModify;
    using Utilities;

    /// <summary>
    /// 校验--图层检查窗体
    /// </summary>
    public class SingleLayerCheck : FormBase3
    {
        private int _checkType;
        private string _disCode;
        private IList<IFeature> _Features;
        private IGeometry _geo;
        private IFeatureLayer _layer;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private BarButtonItem bbiFlash;
        private BarButtonItem bbiPanTo;
        private BarButtonItem bbiSelect;
        private BarButtonItem bbiUnSelect;
        private BarButtonItem bbiValidate;
        private BarButtonItem bbiZoom;
        private BarSubItem bsiModify;
        private SimpleButton btCheck;
        private CheckEdit ceBoundaryBeyond;
        private CheckEdit cePlolygonArea;
        private CheckEdit cePolygonAcuteangle;
        private CheckEdit cePolygonGap;
        private CheckEdit cePolygonOverlap;
        private CheckEdit cePolygonSelf;
        /// <summary>
        /// 重复点
        /// </summary>
        private CheckEdit ceRepeatPoint;
        private IContainer components;
        private GridControl gcErr;
        private GroupBox gpRuler;
        private GridView gridView1;
        private LabelControl labelInfo;
        internal Label LabelLoadInfo;
        internal Label LabelProgressBack;
        internal Label LabelProgressBar;
        private LabelControl lbSquare;
        private LabelControl lcDegree;
        private const string m_ClassName = "TopologyCheck.UI.SingleLayerCheck";
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IFeatureClass m_FClass;
        private IHookHelper m_hookHelper;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PopupMenu popupMenu1;
        private TextEdit teAngle;
        private TextEdit teArea;

        public SingleLayerCheck()
        {
            this.InitializeComponent();
        }

        private void bbiFlash_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._Features == null)
            {
                this._Features = this.GetFeatures();
            }
            IList<IFeature> list = this._Features;
            if ((list != null) && (list.Count >= 1))
            {
                IArray pArray = new ArrayClass();
                IFeature feature = null;
                for (int i = 0; i < list.Count; i++)
                {
                    feature = list[i];
                    if (feature != null)
                    {
                        pArray.Add(feature.ShapeCopy);
                    }
                }
                ((IHookActions) this.m_hookHelper).DoActionOnMultiple(pArray, esriHookActions.esriHookActionsFlash);
            }
        }

        private void bbiPanTo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowError();
        }

        private void bbiSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._Features == null)
            {
                this._Features = this.GetFeatures();
            }
            IList<IFeature> list = this._Features;
            if ((list != null) && (list.Count >= 1))
            {
                IFeature feature = null;
                for (int i = 0; i < list.Count; i++)
                {
                    feature = list[i];
                    if (feature != null)
                    {
                        this.SelectFeature(feature, this._layer, false);
                    }
                }
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void bbiUnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._Features == null)
            {
                this._Features = this.GetFeatures();
            }
            IList<IFeature> list = this._Features;
            if ((list != null) && (list.Count >= 1))
            {
                IFeature feature = null;
                for (int i = 0; i < list.Count; i++)
                {
                    feature = list[i];
                    if (feature != null)
                    {
                        this.UnSelectFeature(feature, this._layer);
                    }
                }
            }
        }

        private void bbiZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = this.gridView1.GetSelectedRows();
            DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
            this.ZoomToSelectedRow(row, false, true);
        }

        private void bsiModify_GetItemData(object sender, EventArgs e)
        {
            IMapControl4 hook = (IMapControl4) this.m_hookHelper.Hook;
            this.bsiModify.ClearLinks();
            int[] selectedRows = this.gridView1.GetSelectedRows();
            DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
            ErrType type = (ErrType) int.Parse(row[3].ToString());
            ITopoModifyStrategy pointModifyStrategy = null;
            if (this._Features == null)
            {
                this._Features = this.GetFeatures();
            }
            IList<IFeature> pFeatures = this._Features;
            IFeature pFeature = null;
            switch (type)
            {
                case ErrType.ReportPoint:
                    pointModifyStrategy = TopoModifyStrategyFactory.GetPointModifyStrategy(hook);
                    break;

                case ErrType.SelfIntersect:
                    pointModifyStrategy = TopoModifyStrategyFactory.GetSelfIntersectModifyStrategy(hook);
                    break;

                case ErrType.OverLap:
                    pointModifyStrategy = TopoModifyStrategyFactory.GetOverlapModifyStrategy(hook, pFeatures);
                    break;

                case ErrType.Gap:
                    pointModifyStrategy = TopoModifyStrategyFactory.GetGapModifyStrategy(hook);
                    break;

                case ErrType.Area:
                    pFeature = pFeatures[0];
                    pointModifyStrategy = TopoModifyStrategyFactory.GetAreaModifyStrategy(hook, pFeature);
                    break;

                case ErrType.Angle:
                    pointModifyStrategy = TopoModifyStrategyFactory.GetAngleModifyStrategy(hook);
                    break;

                case ErrType.BeyondBoundary:
                    pFeature = pFeatures[0];
                    pointModifyStrategy = TopoModifyStrategyFactory.GetBoundaryModifyStartegy(hook, pFeature);
                    break;
            }
            this.bsiModify.Tag = pointModifyStrategy;
            for (int i = 0; i < pointModifyStrategy.StrategyNames.Length; i++)
            {
                BarItem item = new BarButtonItem();
                item.Caption = pointModifyStrategy.StrategyNames[i];
                item.Tag = i;
                this.bsiModify.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(this.item_ItemClick);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.ClearElement();
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCheck_Click(object sender, EventArgs e)
        {
            this.labelInfo.Text = "";
            this.gcErr.DataSource = null;
            if (!Editor.UniqueInstance.IsBeingEdited)
            {
                XtraMessageBox.Show("未打开编辑状态，无法进行拓扑校验！");
            }
            else if (this._layer == null)
            {
                XtraMessageBox.Show("请选择进行拓扑校验的图层！");
            }
            else
            {
                List<ErrType> errType = this.GetErrType();
                if (errType.Count == 0)
                {
                    XtraMessageBox.Show("请至少选择一个检查规则！");
                }
                else
                {
                    this._Features = null;
                    this.Cursor = Cursors.WaitCursor;
                    TopoCheckState.StateKind = 1;
                    if (this._checkType == 0)
                    {
                        TopoCheckState.SingleState = false;
                    }
                    else
                    {
                        TopoCheckState.EditedState = false;
                    }
                    this.EnableControl(false);
                    this.SetLoadInfo("拓扑检查开始……", 10);
                    this.EnableEdit(false);
                    this.m_FClass = null;
                    if (EditTask.KindCode.Substring(0, 2) == "08")
                    {
                        this.m_FClass = this._layer.FeatureClass;
                        IFeatureWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(WorkspaceSource.esriWSSdeWorkspaceFactory);
                        string name = ((IDataset) this._layer.FeatureClass).Name;
                        this._layer.FeatureClass = featureWorkspace.OpenFeatureClass(name);
                    }
                    this.Check(errType);
                    this.labelInfo.Text = "拓扑错误个数：" + this.gridView1.RowCount.ToString();
                    if (this.gridView1.RowCount == 0)
                    {
                        if (this._checkType == 0)
                        {
                            TopoCheckState.SingleState = true;
                        }
                        else
                        {
                            TopoCheckState.EditedState = true;
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                if (this.m_FClass != null)
                {
                    this._layer.FeatureClass = this.m_FClass;
                }
                this.EnableControl(true);
                this.LoadData();
                this.EnableEdit(true);
                this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private bool CanEdit(IFeature pFeature)
        {
            try
            {
                IFeatureLayer targetLayer = Editor.UniqueInstance.TargetLayer;
                int oID = pFeature.OID;
                string oIDFieldName = targetLayer.FeatureClass.OIDFieldName;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.SubFields = oIDFieldName;
                queryFilter.WhereClause = oIDFieldName + "=" + oID;
                IFeatureCursor o = targetLayer.Search(queryFilter, false);
                IFeature feature = o.NextFeature();
                Marshal.ReleaseComObject(o);
                if (feature == null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Check(List<ErrType> pTyps)
        {
            try
            {
                this.ClearElement();
                List<ErrType> list = pTyps;
                IFeatureLayer pLayer = this._layer;
                int count = pTyps.Count;
                ITopologyChecker checker = null;
                int num2 = 1;
                foreach (ErrType type in list)
                {
                    int iValue = (num2 * 90) / count;
                    switch (type)
                    {
                        case ErrType.ReportPoint:
                            this.SetLoadInfo("正在检查重复点……", iValue);
                            checker = new PointRepeatChecker(pLayer, this._checkType);
                            break;

                        case ErrType.SelfIntersect:
                            this.SetLoadInfo("正在检查面自相交……", iValue);
                            checker = new SelfIntersectChecker(pLayer, this._checkType);
                            break;

                        case ErrType.OverLap:
                            this.SetLoadInfo("正在检查面之间重叠……", iValue);
                            checker = new OverLapChecker(pLayer, this._checkType);
                            break;

                        case ErrType.Gap:
                            this.SetLoadInfo("正在检查面之间有缝隙……", iValue);
                            if (this._geo == null)
                            {
                                this._geo = this.GetSubBoundary(this._disCode);
                            }
                            checker = new GapsChecker(pLayer, this._geo, this._checkType);
                            break;

                        case ErrType.Area:
                            this.SetLoadInfo("正在检查最小面积……", iValue);
                            checker = new AreaChecker(this.m_hookHelper.ActiveView, pLayer, double.Parse(this.teArea.EditValue.ToString()), this._checkType);
                            break;

                        case ErrType.Angle:
                            this.SetLoadInfo("正在检查最小角度……", iValue);
                            checker = new AngleChecker(double.Parse(this.teAngle.EditValue.ToString()), pLayer, this._checkType);
                            break;

                        case ErrType.BeyondBoundary:
                            this.SetLoadInfo("正在检查超越行政边界……", iValue);
                            if (this._geo == null)
                            {
                                this._geo = this.GetSubBoundary(this._disCode);
                            }
                            checker = new BoundaryBeyondChecker(pLayer, this._geo, this._checkType);
                            break;
                    }
                    checker.Check();
                    num2++;
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "TopologyCheck.UI.SingleLayerCheck", "Check", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                if (!(exception is ThreadAbortException))
                {
                    XtraMessageBox.Show(exception.Message);
                }
                this.EnableControl(true);
                this.EnableEdit(true);
                return;
            }
            this.CallBack();
        }

        private void ClearElement()
        {
            IGraphicsContainer focusMap = this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer;
            foreach (KeyValuePair<int, List<IElement>> pair in ErrManager.ErrElements)
            {
                List<IElement> list = pair.Value;
                foreach (IElement element in list)
                {
                    focusMap.DeleteElement(element);
                }
                list.Clear();
            }
            ErrManager.ErrElements.Clear();
        }

        private void DeleteRPoint(IList<IFeature> pFeatures, DataRowView pRow)
        {
            if ((pFeatures != null) && (pFeatures.Count >= 1))
            {
                IFeature pFeature = pFeatures[0];
                pFeature = Editor.UniqueInstance.TargetLayer.FeatureClass.GetFeature(pFeature.OID);
                if (!this.CanEdit(pFeature))
                {
                    XtraMessageBox.Show("班块不能编辑！");
                }
                else
                {
                    string str = pRow[2].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] strArray = str.Split(new char[] { ',' });
                        double num = double.Parse(strArray[0]);
                        double num2 = double.Parse(strArray[1]);
                        string str2 = string.Format("{0:F6},{1:F6}", num, num2);
                        Editor.UniqueInstance.StartEditOperation();
                        bool flag = false;
                        IGeometryCollection shapeCopy = pFeature.ShapeCopy as IGeometryCollection;
                        int geometryCount = shapeCopy.GeometryCount;
                        for (int i = 0; i < geometryCount; i++)
                        {
                            flag = false;
                            IGeometry geometry = shapeCopy.get_Geometry(i);
                            int num5 = 0;
                            if ((geometry.GeometryType == esriGeometryType.esriGeometryPolygon) || (geometry.GeometryType == esriGeometryType.esriGeometryRing))
                            {
                                IRing ring = geometry as IRing;
                                if (ring.IsClosed)
                                {
                                    num5 = 1;
                                }
                            }
                            IPointCollection points = geometry as IPointCollection;
                            int pointCount = points.PointCount;
                            int num7 = -1;
                            for (int j = num5; j < pointCount; j++)
                            {
                                if ((pointCount - num5) < 2)
                                {
                                    MessageBox.Show("无法删除重复点，已小于几何图形的最小点数。请检查是否班块过小。", "提示");
                                    Editor.UniqueInstance.AbortEditOperation();
                                    return;
                                }
                                IPoint point = points.get_Point(j);
                                if (string.Format("{0:F6},{1:F6}", point.X, point.Y) == str2)
                                {
                                    if (num7 == -1)
                                    {
                                        num7 = j;
                                    }
                                    else
                                    {
                                        points.RemovePoints(j, 1);
                                        j--;
                                        pointCount--;
                                        flag = true;
                                    }
                                }
                            }
                            if (flag)
                            {
                                object missing = System.Type.Missing;
                                object before = new object();
                                before = i;
                                shapeCopy.RemoveGeometries(i, 1);
                                shapeCopy.AddGeometry(points as IGeometry, ref before, ref missing);
                            }
                        }
                        pFeature.Shape = shapeCopy as IGeometry;
                        pFeature.Store();
                        Editor.UniqueInstance.StopEditOperation("delete repeat point");
                        this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, this.m_hookHelper.ActiveView.Extent);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EnableControl(object pEnable)
        {
            if (!base.InvokeRequired)
            {
                bool flag = (bool) pEnable;
                this.gcErr.Enabled = this.cePlolygonArea.Enabled = this.cePolygonAcuteangle.Enabled = this.teAngle.Enabled = this.teArea.Enabled = this.cePolygonGap.Enabled = this.cePolygonOverlap.Enabled = this.cePolygonSelf.Enabled = this.ceRepeatPoint.Enabled = this.ceBoundaryBeyond.Enabled = this.btCheck.Enabled = this.btCheck.Visible = flag;
                this.LabelLoadInfo.Visible = !flag;
                this.LabelProgressBar.Visible = !flag;
                this.LabelProgressBack.Visible = !flag;
            }
            else
            {
                base.Invoke(new ParameterizedThreadStart(this.EnableControl), new object[] { pEnable });
            }
        }

        private void EnableEdit(bool pEdit)
        {
            if (!pEdit)
            {
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
            }
            else if (!Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
            }
        }

        /// <summary>
        /// 展示检查结果的表格：当鼠标指针位于控件上并按下鼠标键时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcErr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int[] selectedRows = this.gridView1.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    this.bsiModify.Enabled = this.bbiPanTo.Enabled = this.bbiFlash.Enabled = this.bbiSelect.Enabled = this.bbiUnSelect.Enabled = true;
                    DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
                    int.Parse(row[3].ToString());
                    this.popupMenu1.ItemLinks[3].Item.Enabled = true;
                    this.popupMenu1.ItemLinks[4].Item.Enabled = true;
                    this.popupMenu1.ItemLinks[5].Item.Enabled = true;
                    this.popupMenu1.ItemLinks[6].Item.Enabled = true;
                    this.popupMenu1.ShowPopup(base.PointToScreen(new System.Drawing.Point(e.X, e.Y)));
                }
                else
                {
                    this.bsiModify.Enabled = this.bbiValidate.Enabled = this.bbiPanTo.Enabled = this.bbiFlash.Enabled = this.bbiSelect.Enabled = this.bbiUnSelect.Enabled = false;
                }
            }
        }

        private List<ErrType> GetErrType()
        {
            List<ErrType> list = new List<ErrType>();
            if (this.ceRepeatPoint.Checked)
            {
                list.Add(ErrType.ReportPoint);
            }
            if (this.cePolygonSelf.Checked)
            {
                list.Add(ErrType.SelfIntersect);
            }
            if (this.cePolygonOverlap.Checked)
            {
                list.Add(ErrType.OverLap);
            }
            if (this.cePolygonGap.Checked)
            {
                list.Add(ErrType.Gap);
            }
            if (this.cePlolygonArea.Checked)
            {
                list.Add(ErrType.Area);
            }
            if (this.cePolygonAcuteangle.Checked)
            {
                list.Add(ErrType.Angle);
            }
            if (this.ceBoundaryBeyond.Visible && this.ceBoundaryBeyond.Checked)
            {
                list.Add(ErrType.BeyondBoundary);
            }
            return list;
        }

        private IList<IFeature> GetFeatures()
        {
            IList<IFeature> list = new List<IFeature>();
            try
            {
                int[] selectedRows = this.gridView1.GetSelectedRows();
                DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
                if ((int.Parse(row[3].ToString()) == 4) && (this._geo != null))
                {
                    return null;
                }
                IFeature item = null;
                string[] strArray = row[0].ToString().Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    int iD = int.Parse(strArray[i]);
                    try
                    {
                        item = this._layer.FeatureClass.GetFeature(iD);
                    }
                    catch
                    {
                        item = null;
                    }
                    list.Add(item);
                }
            }
            catch
            {
                list = new List<IFeature>();
            }
            return list;
        }

        private IGeometry GetSubBoundary(string sCodes)
        {
            try
            {
                string[] strArray = sCodes.Split(new char[] { ',' });
                string str = "";
                string str2 = "";
                string str3 = "";
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string str4 = configOpt.GetConfigValue2("Sub", "CntyField");
                string str5 = configOpt.GetConfigValue2("Sub", "TownField");
                string str6 = configOpt.GetConfigValue2("Sub", "VillField");
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str7 = strArray[i];
                    if (str7.Length == 6)
                    {
                        string str11 = str;
                        str = str11 + " or " + str4 + "='" + str7 + "'";
                    }
                    else if (str7.Length == 9)
                    {
                        string str12 = str2;
                        str2 = str12 + " or " + str5 + "='" + str7 + "'";
                    }
                    else if (str7.Length == 12)
                    {
                        string str13 = str3;
                        str3 = str13 + " or " + str6 + "='" + str7 + "'";
                    }
                    else
                    {
                        return null;
                    }
                }
                IGeometry shapeCopy = null;
                if (str != "")
                {
                    str = str.Substring(4);
                    string configValue = configOpt.GetConfigValue("CountyLayerName");
                    IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_hookHelper.FocusMap, configValue, true);
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = str;
                    shapeCopy = layer.Search(queryFilter, false).NextFeature().ShapeCopy;
                }
                else
                {
                    if (str2 != "")
                    {
                        string sLayerName = configOpt.GetConfigValue("TownLayerName");
                        IFeatureLayer layer2 = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_hookHelper.FocusMap, sLayerName, true);
                        IQueryFilter filter2 = new QueryFilterClass();
                        filter2.WhereClause = str2.Substring(4);
                        IGeometry other = layer2.Search(filter2, false).NextFeature().ShapeCopy;
                        if (shapeCopy == null)
                        {
                            shapeCopy = other;
                        }
                        else
                        {
                            ((ITopologicalOperator2) shapeCopy).Union(other);
                        }
                    }
                    if (str3 != "")
                    {
                        string str10 = configOpt.GetConfigValue("VillageLayerName");
                        IFeatureLayer layer3 = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_hookHelper.FocusMap, str10, true);
                        IQueryFilter filter3 = new QueryFilterClass();
                        filter3.WhereClause = str3.Substring(4);
                        IGeometry geometry3 = layer3.Search(filter3, false).NextFeature().ShapeCopy;
                        if (shapeCopy == null)
                        {
                            shapeCopy = geometry3;
                        }
                        else
                        {
                            ((ITopologicalOperator2) shapeCopy).Union(geometry3);
                        }
                    }
                }
                return shapeCopy;
            }
            catch
            {
                return null;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowError();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this._Features = this.GetFeatures();
        }

        /// <summary>
        /// 窗体数据初始化
        /// </summary>
        private void Init()
        {
            this.labelInfo.Text = "";
            this.LabelLoadInfo.Visible = false;
            this.LabelProgressBar.Visible = false;
            this.LabelProgressBack.Visible = false;
            this._layer = EditTask.EditLayer;
            this._disCode = EditTask.DistCode;
            this._Features = null;
            this.ClearElement();
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            string configValue = configOpt.GetConfigValue("AreaValue");
            if (string.IsNullOrEmpty(configValue))
            {
                this.teArea.Text = "667";
            }
            else
            {
                this.teArea.Text = configValue;
            }
            configValue = configOpt.GetConfigValue("AngleValue");
            if (string.IsNullOrEmpty(configValue))
            {
                this.teAngle.Text = "15";
            }
            else
            {
                this.teAngle.Text = configValue;
            }
            configValue = configOpt.GetConfigValue("Angle");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonAcuteangle.Checked = false;
            }
            configValue = configOpt.GetConfigValue("Area");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePlolygonArea.Checked = false;
            }
            configValue = configOpt.GetConfigValue("RepeatPoint");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.ceRepeatPoint.Checked = false;
            }
            configValue = configOpt.GetConfigValue("SelfIntersect");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonSelf.Checked = false;
            }
            configValue = configOpt.GetConfigValue("Overlap");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonOverlap.Checked = false;
            }
            configValue = configOpt.GetConfigValue("BeyondBoundary");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.ceBoundaryBeyond.Checked = false;
            }
            configValue = configOpt.GetConfigValue("Gaps");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonGap.Checked = false;
            }
            if ((this._layer != null) && (this._layer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon))
            {
                if (this._layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    this.cePolygonSelf.Checked = false;
                    this.cePlolygonArea.Checked = false;
                    this.cePolygonGap.Checked = false;
                    this.cePolygonOverlap.Checked = false;
                }
                else
                {
                    this.ceRepeatPoint.Checked = true;
                    this.cePolygonSelf.Checked = false;
                    this.cePlolygonArea.Checked = false;
                    this.cePolygonAcuteangle.Checked = false;
                    this.cePolygonGap.Checked = false;
                    this.cePolygonOverlap.Checked = false;
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.btCheck = new SimpleButton();
            this.gcErr = new GridControl();
            this.gridView1 = new GridView();
            this.barManager1 = new BarManager(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.bbiPanTo = new BarButtonItem();
            this.bbiSelect = new BarButtonItem();
            this.bbiUnSelect = new BarButtonItem();
            this.bbiFlash = new BarButtonItem();
            this.bbiValidate = new BarButtonItem();
            this.bsiModify = new BarSubItem();
            this.bbiZoom = new BarButtonItem();
            this.popupMenu1 = new PopupMenu(this.components);
            this.ceRepeatPoint = new CheckEdit();
            this.cePolygonSelf = new CheckEdit();
            this.cePolygonOverlap = new CheckEdit();
            this.cePolygonAcuteangle = new CheckEdit();
            this.teAngle = new TextEdit();
            this.cePlolygonArea = new CheckEdit();
            this.teArea = new TextEdit();
            this.cePolygonGap = new CheckEdit();
            this.lbSquare = new LabelControl();
            this.lcDegree = new LabelControl();
            this.ceBoundaryBeyond = new CheckEdit();
            this.gpRuler = new GroupBox();
            this.panelControl1 = new PanelControl();
            this.LabelProgressBack = new Label();
            this.LabelProgressBar = new Label();
            this.LabelLoadInfo = new Label();
            this.labelInfo = new LabelControl();
            this.panelControl2 = new PanelControl();
            this.gcErr.BeginInit();
            this.gridView1.BeginInit();
            this.barManager1.BeginInit();
            this.popupMenu1.BeginInit();
            this.ceRepeatPoint.Properties.BeginInit();
            this.cePolygonSelf.Properties.BeginInit();
            this.cePolygonOverlap.Properties.BeginInit();
            this.cePolygonAcuteangle.Properties.BeginInit();
            this.teAngle.Properties.BeginInit();
            this.cePlolygonArea.Properties.BeginInit();
            this.teArea.Properties.BeginInit();
            this.cePolygonGap.Properties.BeginInit();
            this.ceBoundaryBeyond.Properties.BeginInit();
            this.gpRuler.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.btCheck.Location = new System.Drawing.Point(330, 9);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new Size(0x57, 0x1b);
            this.btCheck.TabIndex = 1;
            this.btCheck.Text = "检查";
            this.btCheck.Click += new EventHandler(this.btCheck_Click);
            this.gcErr.Dock = DockStyle.Fill;
            this.gcErr.Location = new System.Drawing.Point(0, 170);
            this.gcErr.MainView = this.gridView1;
            this.gcErr.Name = "gcErr";
            this.gcErr.Size = new Size(0x1b0, 0x10c);
            this.gcErr.TabIndex = 3;
            this.gcErr.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gcErr.MouseDown += new MouseEventHandler(this.gcErr_MouseDown);
            this.gridView1.GridControl = this.gcErr;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewLines = false;
            this.gridView1.FocusedRowChanged += new FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.bbiPanTo, this.bbiSelect, this.bbiUnSelect, this.bbiFlash, this.bbiValidate, this.bsiModify, this.bbiZoom });
            this.barManager1.MaxItemId = 11;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new Size(0x1b0, 0);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 0x1d3);
            this.barDockControlBottom.Size = new Size(0x1b0, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new Size(0, 0x1d3);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(0x1b0, 0);
            this.barDockControlRight.Size = new Size(0, 0x1d3);
            this.bbiPanTo.Caption = "查看错误";
            this.bbiPanTo.Id = 0;
            this.bbiPanTo.Name = "bbiPanTo";
            this.bbiPanTo.ItemClick += new ItemClickEventHandler(this.bbiPanTo_ItemClick);
            this.bbiSelect.Caption = "选择要素";
            this.bbiSelect.Id = 2;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.ItemClick += new ItemClickEventHandler(this.bbiSelect_ItemClick);
            this.bbiUnSelect.Caption = "取消选择";
            this.bbiUnSelect.Id = 3;
            this.bbiUnSelect.Name = "bbiUnSelect";
            this.bbiUnSelect.ItemClick += new ItemClickEventHandler(this.bbiUnSelect_ItemClick);
            this.bbiFlash.Caption = "闪烁要素";
            this.bbiFlash.Id = 4;
            this.bbiFlash.Name = "bbiFlash";
            this.bbiFlash.ItemClick += new ItemClickEventHandler(this.bbiFlash_ItemClick);
            this.bbiValidate.Caption = "验证拓扑";
            this.bbiValidate.Id = 7;
            this.bbiValidate.Name = "bbiValidate";
            this.bbiValidate.Visibility = BarItemVisibility.Never;
            this.bsiModify.Caption = "修改建议";
            this.bsiModify.Id = 9;
            this.bsiModify.Name = "bsiModify";
            this.bsiModify.GetItemData += new EventHandler(this.bsiModify_GetItemData);
            this.bbiZoom.Caption = "缩放到要素";
            this.bbiZoom.Id = 10;
            this.bbiZoom.Name = "bbiZoom";
            this.bbiZoom.ItemClick += new ItemClickEventHandler(this.bbiZoom_ItemClick);
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiPanTo), new LinkPersistInfo(this.bsiModify), new LinkPersistInfo(this.bbiValidate), new LinkPersistInfo(this.bbiSelect, true), new LinkPersistInfo(this.bbiUnSelect), new LinkPersistInfo(this.bbiFlash), new LinkPersistInfo(this.bbiZoom) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.ceRepeatPoint.EditValue = true;
            this.ceRepeatPoint.Location = new System.Drawing.Point(8, 0x1a);
            this.ceRepeatPoint.Name = "ceRepeatPoint";
            this.ceRepeatPoint.Properties.Caption = "重复点";
            this.ceRepeatPoint.Properties.CheckStyle = CheckStyles.Style5;
            this.ceRepeatPoint.Properties.ReadOnly = true;
            this.ceRepeatPoint.Size = new Size(120, 0x16);
            this.ceRepeatPoint.TabIndex = 0;
            this.cePolygonSelf.EditValue = true;
            this.cePolygonSelf.Location = new System.Drawing.Point(0x87, 0x1a);
            this.cePolygonSelf.Name = "cePolygonSelf";
            this.cePolygonSelf.Properties.Caption = "面自相交";
            this.cePolygonSelf.Properties.CheckStyle = CheckStyles.Style5;
            this.cePolygonSelf.Properties.ReadOnly = true;
            this.cePolygonSelf.Size = new Size(0x57, 0x16);
            this.cePolygonSelf.TabIndex = 1;
            this.cePolygonOverlap.EditValue = true;
            this.cePolygonOverlap.Location = new System.Drawing.Point(0x87, 0x5d);
            this.cePolygonOverlap.Name = "cePolygonOverlap";
            this.cePolygonOverlap.Properties.Caption = "面之间重叠";
            this.cePolygonOverlap.Properties.CheckStyle = CheckStyles.Style5;
            this.cePolygonOverlap.Properties.ReadOnly = true;
            this.cePolygonOverlap.Size = new Size(0x69, 0x16);
            this.cePolygonOverlap.TabIndex = 2;
            this.cePolygonAcuteangle.EditValue = true;
            this.cePolygonAcuteangle.Location = new System.Drawing.Point(220, 0x3a);
            this.cePolygonAcuteangle.Name = "cePolygonAcuteangle";
            this.cePolygonAcuteangle.Properties.Caption = "角度小于";
            this.cePolygonAcuteangle.Properties.CheckStyle = CheckStyles.Style5;
            this.cePolygonAcuteangle.Properties.ReadOnly = true;
            this.cePolygonAcuteangle.Size = new Size(0x5e, 0x16);
            this.cePolygonAcuteangle.TabIndex = 3;
            this.teAngle.EditValue = "";
            this.teAngle.Location = new System.Drawing.Point(0x134, 0x3b);
            this.teAngle.Name = "teAngle";
            this.teAngle.Properties.AllowNullInput = DefaultBoolean.False;
            this.teAngle.Properties.ReadOnly = true;
            this.teAngle.Size = new Size(0x37, 0x15);
            this.teAngle.TabIndex = 4;
            this.cePlolygonArea.EditValue = true;
            this.cePlolygonArea.Location = new System.Drawing.Point(7, 0x3a);
            this.cePlolygonArea.Name = "cePlolygonArea";
            this.cePlolygonArea.Properties.Caption = "面积小于";
            this.cePlolygonArea.Properties.CheckStyle = CheckStyles.Style5;
            this.cePlolygonArea.Properties.ReadOnly = true;
            this.cePlolygonArea.Size = new Size(0x57, 0x16);
            this.cePlolygonArea.TabIndex = 5;
            this.teArea.EditValue = "";
            this.teArea.Location = new System.Drawing.Point(0x5c, 0x3b);
            this.teArea.Name = "teArea";
            this.teArea.Properties.AllowNullInput = DefaultBoolean.False;
            this.teArea.Properties.ReadOnly = true;
            this.teArea.Size = new Size(50, 0x15);
            this.teArea.TabIndex = 6;
            this.cePolygonGap.EditValue = true;
            this.cePolygonGap.Location = new System.Drawing.Point(8, 0x5d);
            this.cePolygonGap.Name = "cePolygonGap";
            this.cePolygonGap.Properties.Caption = "面之间有缝隙";
            this.cePolygonGap.Properties.CheckStyle = CheckStyles.Style5;
            this.cePolygonGap.Properties.ReadOnly = true;
            this.cePolygonGap.Size = new Size(0x73, 0x16);
            this.cePolygonGap.TabIndex = 7;
            this.lbSquare.Location = new System.Drawing.Point(0x94, 0x3f);
            this.lbSquare.Name = "lbSquare";
            this.lbSquare.Size = new Size(0x18, 14);
            this.lbSquare.TabIndex = 8;
            this.lbSquare.Text = "平米";
            this.lcDegree.Location = new System.Drawing.Point(0x173, 0x3f);
            this.lcDegree.Name = "lcDegree";
            this.lcDegree.Size = new Size(12, 14);
            this.lcDegree.TabIndex = 9;
            this.lcDegree.Text = "度";
            this.ceBoundaryBeyond.EditValue = true;
            this.ceBoundaryBeyond.Location = new System.Drawing.Point(0x10b, 0x5d);
            this.ceBoundaryBeyond.Name = "ceBoundaryBeyond";
            this.ceBoundaryBeyond.Properties.Caption = "超越行政边界";
            this.ceBoundaryBeyond.Properties.CheckStyle = CheckStyles.Style5;
            this.ceBoundaryBeyond.Properties.ReadOnly = true;
            this.ceBoundaryBeyond.Size = new Size(120, 0x16);
            this.ceBoundaryBeyond.TabIndex = 10;
            this.gpRuler.Controls.Add(this.ceBoundaryBeyond);
            this.gpRuler.Controls.Add(this.lcDegree);
            this.gpRuler.Controls.Add(this.lbSquare);
            this.gpRuler.Controls.Add(this.cePolygonGap);
            this.gpRuler.Controls.Add(this.teArea);
            this.gpRuler.Controls.Add(this.cePlolygonArea);
            this.gpRuler.Controls.Add(this.teAngle);
            this.gpRuler.Controls.Add(this.cePolygonAcuteangle);
            this.gpRuler.Controls.Add(this.cePolygonOverlap);
            this.gpRuler.Controls.Add(this.cePolygonSelf);
            this.gpRuler.Controls.Add(this.ceRepeatPoint);
            this.gpRuler.Dock = DockStyle.Top;
            this.gpRuler.Location = new System.Drawing.Point(0, 0);
            this.gpRuler.Name = "gpRuler";
            this.gpRuler.Size = new Size(0x1b0, 0x80);
            this.gpRuler.TabIndex = 0;
            this.gpRuler.TabStop = false;
            this.gpRuler.Text = "拓扑规则";
            this.panelControl1.Controls.Add(this.LabelProgressBack);
            this.panelControl1.Controls.Add(this.LabelProgressBar);
            this.panelControl1.Controls.Add(this.btCheck);
            this.panelControl1.Controls.Add(this.LabelLoadInfo);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x80);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x1b0, 0x2a);
            this.panelControl1.TabIndex = 4;
            this.LabelProgressBack.BackColor = Color.White;
            this.LabelProgressBack.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(50, 0x1c);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new Size(330, 4);
            this.LabelProgressBack.TabIndex = 15;
            this.LabelProgressBar.BackColor = Color.Orange;
            this.LabelProgressBar.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBar.ForeColor = Color.Black;
            this.LabelProgressBar.Location = new System.Drawing.Point(50, 0x1c);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new Size(140, 4);
            this.LabelProgressBar.TabIndex = 14;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Location = new System.Drawing.Point(0x59, 8);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0x102, 0x13);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "请稍后...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.labelInfo.Appearance.ForeColor = Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(0x114, 7);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(0x54, 14);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "拓扑错误个数为";
            this.panelControl2.Controls.Add(this.labelInfo);
            this.panelControl2.Dock = DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 0x1b6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x1b0, 0x1d);
            this.panelControl2.TabIndex = 5;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b0, 0x1d3);
            base.Controls.Add(this.gcErr);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.gpRuler);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.Name = "SingleLayerCheck";
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "班块拓扑检查";
            base.Load += new EventHandler(this.SingleLayerCheck_Load);
            base.FormClosing += new FormClosingEventHandler(this.SingleLayerCheck_FormClosing);
            this.gcErr.EndInit();
            this.gridView1.EndInit();
            this.barManager1.EndInit();
            this.popupMenu1.EndInit();
            this.ceRepeatPoint.Properties.EndInit();
            this.cePolygonSelf.Properties.EndInit();
            this.cePolygonOverlap.Properties.EndInit();
            this.cePolygonAcuteangle.Properties.EndInit();
            this.teAngle.Properties.EndInit();
            this.cePlolygonArea.Properties.EndInit();
            this.teArea.Properties.EndInit();
            this.cePolygonGap.Properties.EndInit();
            this.ceBoundaryBeyond.Properties.EndInit();
            this.gpRuler.ResumeLayout(false);
            this.gpRuler.PerformLayout();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = this.gridView1.GetSelectedRows();
                DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
                ErrType type = (ErrType) int.Parse(row[3].ToString());
                switch (type)
                {
                    case ErrType.OverLap:
                        if (this._Features == null)
                        {
                            this._Features = this.GetFeatures();
                        }
                        Editor.UniqueInstance.CheckOverlap = false;
                        this.ModifyOverlap(this._Features, e.Item.Tag);
                        Editor.UniqueInstance.CheckOverlap = true;
                        MessageBox.Show("修改完成！", "提示");
                        return;

                    case ErrType.Area:
                        Editor.UniqueInstance.StartEditOperation();
                        if (this._Features == null)
                        {
                            this._Features = this.GetFeatures();
                        }
                        for (int i = 0; i < this._Features.Count; i++)
                        {
                            if (this._Features[i] == null)
                            {
                                MessageBox.Show("此要素已被删除！", "提示");
                                return;
                            }
                            this._Features[i].Delete();
                        }
                        Editor.UniqueInstance.StopEditOperation();
                        MessageBox.Show("删除完成！", "提示");
                        return;
                }
                if ((type == ErrType.ReportPoint) && (e.Item.Caption == "删除重复点"))
                {
                    if (this._Features == null)
                    {
                        this._Features = this.GetFeatures();
                    }
                    Editor.UniqueInstance.SetArea = false;
                    Editor.UniqueInstance.CheckOverlap = false;
                    this.DeleteRPoint(this._Features, row);
                    MessageBox.Show("删除重复点完成！", "提示");
                    Editor.UniqueInstance.CheckOverlap = true;
                    Editor.UniqueInstance.SetArea = true;
                }
                else
                {
                    int tag = (int) e.Item.Tag;
                    ITopoModifyStrategy strategy = (ITopoModifyStrategy) this.bsiModify.Tag;
                    strategy.StrategyIndex = tag;
                }
            }
            catch
            {
            }
        }

        private void LoadData()
        {
            ErrorTable table = new ErrorTable();
            List<ErrType> errType = this.GetErrType();
            DataTable table2 = table.GetTable(errType);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                this.gcErr.DataSource = table2;
                ColumnView focusedView = this.gcErr.FocusedView as ColumnView;
                focusedView.Columns[0].Caption = "要素ID";
                focusedView.Columns[1].Caption = "错误描述";
                focusedView.Columns[2].Visible = focusedView.Columns[3].Visible = focusedView.Columns[4].Visible = false;
                focusedView.Columns[0].Width = 100;
            }
            else
            {
                this.gcErr.DataSource = null;
            }
        }

        private void ModifyOverlap(IList<IFeature> pFeatures, object pTag)
        {
            if ((pFeatures != null) && (pFeatures.Count >= 1))
            {
                int num = int.Parse(pTag.ToString());
                if (num >= 0)
                {
                    try
                    {
                        int count = pFeatures.Count;
                        IFeature pFeature = null;
                        IFeature feature = null;
                        if (num < count)
                        {
                            pFeature = pFeatures[num];
                            feature = pFeatures[1 - num];
                        }
                        else
                        {
                            pFeature = pFeatures[0];
                            feature = pFeatures[1];
                        }
                        pFeature = Editor.UniqueInstance.TargetLayer.FeatureClass.GetFeature(pFeature.OID);
                        feature = Editor.UniqueInstance.TargetLayer.FeatureClass.GetFeature(feature.OID);
                        if (!this.CanEdit(pFeature) || !this.CanEdit(feature))
                        {
                            XtraMessageBox.Show("重叠班块不能编辑！");
                            return;
                        }
                        ITopologicalOperator2 shapeCopy = pFeature.ShapeCopy as ITopologicalOperator2;
                        shapeCopy.IsKnownSimple_2 = false;
                        shapeCopy.Simplify();
                        IGeometry other = shapeCopy.Intersect(feature.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                        if (other.IsEmpty)
                        {
                            return;
                        }
                        ITopologicalOperator2 operator2 = other as ITopologicalOperator2;
                        operator2.IsKnownSimple_2 = false;
                        operator2.Simplify();
                        if (num == (count + 1))
                        {
                            Editor.UniqueInstance.StartEditOperation();
                            IGeometry geometry2 = shapeCopy.Difference(other);
                            if (geometry2.IsEmpty)
                            {
                                pFeature.Delete();
                            }
                            else
                            {
                                pFeature.Shape = geometry2;
                                pFeature.Store();
                            }
                            ITopologicalOperator2 operator3 = feature.ShapeCopy as ITopologicalOperator2;
                            operator3.IsKnownSimple_2 = false;
                            operator3.Simplify();
                            IGeometry geometry3 = operator3.Difference(other);
                            if (geometry3.IsEmpty)
                            {
                                feature.Delete();
                            }
                            else
                            {
                                feature.Shape = geometry3;
                                feature.Store();
                            }
                            Editor.UniqueInstance.AddAttribute = true;
                            IFeature feature3 = Editor.UniqueInstance.TargetLayer.FeatureClass.CreateFeature();
                            feature3.Shape = other;
                            feature3.Store();
                            Editor.UniqueInstance.StopEditOperation();
                            Editor.UniqueInstance.AddAttribute = false;
                        }
                        else if (num == count)
                        {
                            Editor.UniqueInstance.StartEditOperation();
                            IGeometry geometry4 = shapeCopy.Difference(other);
                            if (geometry4.IsEmpty)
                            {
                                pFeature.Delete();
                            }
                            else
                            {
                                pFeature.Shape = geometry4;
                                pFeature.Store();
                            }
                            ITopologicalOperator2 operator4 = feature.ShapeCopy as ITopologicalOperator2;
                            operator4.IsKnownSimple_2 = false;
                            operator4.Simplify();
                            IGeometry geometry5 = operator4.Difference(other);
                            if (geometry5.IsEmpty)
                            {
                                feature.Delete();
                            }
                            else
                            {
                                feature.Shape = geometry5;
                                feature.Store();
                            }
                            Editor.UniqueInstance.StopEditOperation();
                        }
                        else
                        {
                            Editor.UniqueInstance.StartEditOperation();
                            ITopologicalOperator2 operator5 = feature.ShapeCopy as ITopologicalOperator2;
                            operator5.IsKnownSimple_2 = false;
                            operator5.Simplify();
                            IGeometry geometry6 = operator5.Difference(other);
                            if (geometry6.IsEmpty)
                            {
                                feature.Delete();
                            }
                            else
                            {
                                feature.Shape = geometry6;
                                feature.Store();
                            }
                            Editor.UniqueInstance.StopEditOperation();
                        }
                    }
                    catch (Exception exception)
                    {
                        this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "TopologyCheck.UI.SingleLayerCheck", "ModifyOverlap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    this.m_hookHelper.ActiveView.Refresh();
                }
            }
        }

        private void SelectFeature(IFeature feature, IFeatureLayer pLayer, bool bClear)
        {
            IFeatureSelection selection = (IFeatureSelection) pLayer;
            if (bClear)
            {
                selection.Clear();
            }
            selection.Add(feature);
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        private void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            catch
            {
            }
        }

        private void ShowError()
        {
            try
            {
                IActiveView activeView = this.m_hookHelper.ActiveView;
                int[] selectedRows = this.gridView1.GetSelectedRows();
                DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
                ErrType type = (ErrType) int.Parse(row[3].ToString());
                if (this._Features == null)
                {
                    this._Features = this.GetFeatures();
                }
                IList<IFeature> list = this._Features;
                IFeature pFeature = null;
                if ((list != null) && (list.Count > 0))
                {
                    pFeature = list[0];
                }
                if ((pFeature != null) || (type == ErrType.Gap))
                {
                    List<IElement> list2 = null;
                    int key = -1;
                    key = this.gridView1.FocusedRowHandle + 1;
                    if (ErrManager.ErrElements.ContainsKey(key))
                    {
                        list2 = ErrManager.ErrElements[key];
                        foreach (IElement element in list2)
                        {
                            (activeView.FocusMap as IGraphicsContainer).DeleteElement(element);
                        }
                        list2.Clear();
                    }
                    else
                    {
                        list2 = new List<IElement>();
                        ErrManager.ErrElements.Add(key, list2);
                    }
                    switch (type)
                    {
                        case ErrType.OverLap:
                            ErrManager.ZoomToErr(activeView, pFeature);
                            ErrManager.AddErrTopoElement(activeView, (IGeometry) row["Geometry"], ref list2);
                            break;

                        case ErrType.Gap:
                            if (row["Geometry"] is IGeometry)
                            {
                                ErrManager.ZoomToErr(activeView, (IGeometry) row["Geometry"]);
                                ErrManager.AddErrTopoElement(activeView, (IGeometry) row["Geometry"], ref list2);
                            }
                            else
                            {
                                ErrManager.ZoomToErr(activeView, pFeature);
                                ErrManager.AddErrTopoElement(activeView, row["Geometry"], pFeature);
                            }
                            break;

                        default:
                            if (type == ErrType.Area)
                            {
                                ErrManager.ZoomToErr(activeView, pFeature);
                                ErrManager.AddErrAreaElement(activeView, pFeature, ref list2);
                            }
                            else
                            {
                                ErrManager.ZoomToErr(activeView, pFeature);
                                ErrManager.AddErrPointElement(activeView, row[2].ToString(), (this._layer.FeatureClass as IGeoDataset).SpatialReference, ref list2);
                            }
                            break;
                    }
                    activeView.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "TopologyCheck.UI.SingleLayerCheck", "ShowError", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SingleLayerCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ClearElement();
            this.m_hookHelper.ActiveView.Refresh();
        }

        private void SingleLayerCheck_Load(object sender, EventArgs e)
        {
            if (this._checkType == 0)
            {
                this.Text = "拓扑校验（专题数据校验）";
            }
            else
            {
                this.Text = "拓扑校验（" + EditTask.TaskName + "）";
            }
            this.Init();
        }

        private void UnSelectFeature(IFeature feature, IFeatureLayer pLayer)
        {
            IFeatureSelection selection = (IFeatureSelection) this._layer;
            ISelectionSet selectionSet = selection.SelectionSet;
            int oID = feature.OID;
            selectionSet.RemoveList(1, ref oID);
            this.m_hookHelper.ActiveView.Refresh();
        }

        private void ZoomToSelectedRow(DataRowView row, bool bSelect, bool bMessage)
        {
            try
            {
                ErrType type = (ErrType) int.Parse(row[3].ToString());
                IGeometry pGeometry = null;
                if (type == ErrType.Gap)
                {
                    pGeometry = (IGeometry) row["Geometry"];
                }
                else
                {
                    if (this._Features == null)
                    {
                        this._Features = this.GetFeatures();
                    }
                    IList<IFeature> list = this._Features;
                    if ((list == null) || (list.Count < 1))
                    {
                        return;
                    }
                    IFeature feature = null;
                    for (int i = 0; i < list.Count; i++)
                    {
                        feature = list[i];
                        if (feature != null)
                        {
                            if (bSelect)
                            {
                                this.SelectFeature(feature, this._layer, false);
                            }
                            if (pGeometry == null)
                            {
                                pGeometry = feature.ShapeCopy;
                            }
                            else
                            {
                                (pGeometry as ITopologicalOperator).Union(feature.ShapeCopy);
                            }
                        }
                    }
                    if (pGeometry == null)
                    {
                        MessageBox.Show("此要素已被删除！", "提示");
                        return;
                    }
                }
                if (pGeometry.IsEmpty)
                {
                    if (bMessage)
                    {
                        MessageBox.Show("此斑块图形为空，无法定位。请应用右键菜单中的修改建议删除此斑块。", "提示");
                    }
                }
                else
                {
                    pGeometry = GISFunFactory.UnitFun.ConvertPoject(pGeometry, this.m_hookHelper.ActiveView.FocusMap.SpatialReference);
                    IEnvelope envelope = new EnvelopeClass();
                    envelope.SpatialReference = this.m_hookHelper.ActiveView.FocusMap.SpatialReference;
                    double num2 = 100.0;
                    envelope.PutCoords(pGeometry.Envelope.XMin - num2, pGeometry.Envelope.YMin - num2, pGeometry.Envelope.XMax + num2, pGeometry.Envelope.YMax + num2);
                    this.m_hookHelper.ActiveView.Extent = envelope;
                    this.m_hookHelper.ActiveView.Refresh();
                }
            }
            catch
            {
            }
        }

        public int CheckType
        {
            get
            {
                return this._checkType;
            }
            set
            {
                this._checkType = value;
            }
        }

        public object Hook
        {
            set
            {
                if (value != null)
                {
                    try
                    {
                        this.m_hookHelper = new HookHelperClass();
                        this.m_hookHelper.Hook = value;
                        if (this.m_hookHelper.ActiveView == null)
                        {
                            this.m_hookHelper = null;
                        }
                    }
                    catch
                    {
                        this.m_hookHelper = null;
                    }
                }
            }
        }
    }
}

