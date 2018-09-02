namespace TopologyCheck.UI
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
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

    public class MultiLayerCheck : FormBase3
    {
        private Dictionary<string, string> _dt = new Dictionary<string, string>();
        private IFeatureLayer _layer;
        private BarButtonItem barButtonItem1;
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
        private CheckedListBoxControl clbcLayers;
        private IContainer components;
        private Dictionary<string, bool> errs = new Dictionary<string, bool>();
        private GroupBox gbYear;
        private GridControl gcErr;
        private GridView gridView1;
        private LabelControl labelInfo;
        private IHookHelper m_hookHelper;
        private ArrayList m_Layers;
        private const string mClassName = "TopologyCheck.UI.MultiLayerCheck";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PopupMenu popupMenu1;
        private Thread t;

        public MultiLayerCheck()
        {
            this.InitializeComponent();
        }

        private void bbiFlash_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFeature feature = this.GetFeature();
            if (feature != null)
            {
                IArray pArray = new ArrayClass();
                pArray.Add(feature.ShapeCopy);
                ((IHookActions) this.m_hookHelper).DoActionOnMultiple(pArray, esriHookActions.esriHookActionsFlash);
            }
        }

        private void bbiPanTo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFeature pFeature = this.GetFeature();
            if (pFeature != null)
            {
                int[] selectedRows = this.gridView1.GetSelectedRows();
                DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
                int.Parse(row[3].ToString());
                List<IElement> list = null;
                if (ErrManager.ErrElements.ContainsKey(pFeature.OID))
                {
                    list = ErrManager.ErrElements[pFeature.OID];
                    list.Clear();
                }
                else
                {
                    list = new List<IElement>();
                    ErrManager.ErrElements.Add(pFeature.OID, list);
                }
                foreach (IElement element in list)
                {
                    (this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer).DeleteElement(element);
                }
                ErrManager.ZoomToErr(this.m_hookHelper.ActiveView, pFeature);
                ErrManager.AddErrTopoElement(this.m_hookHelper.ActiveView, (IGeometry) row["Geometry"], ref list);
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void bbiSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFeature feature = this.GetFeature();
            if (feature != null)
            {
                this.SelectFeature(feature, this._layer, false);
            }
        }

        private void bbiUnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFeature feature = this.GetFeature();
            if (feature != null)
            {
                this.UnSelectFeature(feature, this._layer);
            }
        }

        private void bbiZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFeature feature = this.GetFeature();
            if (feature != null)
            {
                this.SelectFeature(feature, this._layer, false);
                this.ZoomToFeature(feature, this.m_hookHelper.ActiveView);
            }
        }

        private void bsiModify_GetItemData(object sender, EventArgs e)
        {
            if (this.bsiModify.Tag == null)
            {
                IFeature feature = this.GetFeature();
                if (feature == null)
                {
                    this.bsiModify.ClearLinks();
                }
                else
                {
                    IList<IFeature> pFeatures = new List<IFeature>();
                    pFeatures.Add(feature);
                    ITopoModifyStrategy overlapModifyStrategy = TopoModifyStrategyFactory.GetOverlapModifyStrategy((IMapControl4) this.m_hookHelper.Hook, pFeatures);
                    BarItem item = new BarButtonItem();
                    item.Caption = overlapModifyStrategy.StrategyNames[0];
                    item.ItemClick += new ItemClickEventHandler(this.item_ItemClick);
                    this.bsiModify.AddItem(item);
                    this.bsiModify.Tag = overlapModifyStrategy;
                }
            }
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            this.labelInfo.Text = "";
            if (this.clbcLayers.CheckedItems.Count < 1)
            {
                XtraMessageBox.Show("请选择图层！");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                this.EnableControl(false);
                this.EnableEdit(false);
                this.Check();
                this.labelInfo.Text = "重叠错误个数：" + this.gridView1.RowCount.ToString();
                TopoCheckState.MultiState = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                this.EnableControl(true);
                this.LoadData();
                this.EnableEdit(true);
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private void Check()
        {
            try
            {
                IFeatureClass featureClass = this._layer.FeatureClass;
                int num = -1;
                foreach (CheckedListBoxItem item in this.clbcLayers.Items)
                {
                    num++;
                    if (item.CheckState == CheckState.Checked)
                    {
                        string str = item.Value.ToString();
                        IFeatureLayer layer = (IFeatureLayer) this.m_Layers[num];
                        IFeatureClass class3 = layer.FeatureClass;
                        if (class3 == null)
                        {
                            XtraMessageBox.Show(str + "数据不存在！");
                            return;
                        }
                        IList<IFeatureClass> pList = new List<IFeatureClass>();
                        pList.Add(featureClass);
                        pList.Add(class3);
                        ITopologyChecker checker = new OverLapChecker(pList);
                        checker.Check();
                        Marshal.ReleaseComObject(class3);
                        class3 = null;
                    }
                }
                featureClass = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.UI.MultiLayerCheck", "Check", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                if (!(exception is ThreadAbortException))
                {
                    XtraMessageBox.Show("拓扑检查遇到问题！");
                }
                this.EnableControl(true);
                return;
            }
            this.CallBack();
        }

        private void clbcYears_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            for (int i = 0; i < this.clbcLayers.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    this.clbcLayers.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
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

        protected override void Dispose(bool disposing)
        {
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
                this.gbYear.Enabled = flag;
                this.btCheck.Enabled = flag;
                this.gcErr.Enabled = flag;
            }
            else
            {
                base.Invoke(new ParameterizedThreadStart(this.EnableControl), new object[] { pEnable });
            }
        }

        private void EnableEdit(bool pEdit)
        {
            IDataset featureClass = this._layer.FeatureClass as IDataset;
            IWorkspaceEdit workspace = featureClass.Workspace as IWorkspaceEdit;
            if (!pEdit)
            {
                if (workspace.IsBeingEdited())
                {
                    workspace.StopEditOperation();
                    workspace.StopEditing(true);
                }
            }
            else if (!workspace.IsBeingEdited())
            {
                workspace.StartEditing(true);
                workspace.StartEditOperation();
            }
        }

        private IFeature GetFeature()
        {
            IFeature feature;
            int[] selectedRows = this.gridView1.GetSelectedRows();
            DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
            int iD = int.Parse(row[0].ToString());
            try
            {
                feature = this._layer.FeatureClass.GetFeature(iD);
            }
            catch
            {
                feature = null;
            }
            if ((feature != null) && feature.Shape.IsEmpty)
            {
                XtraMessageBox.Show("要素不存在或图形为空！");
                feature = null;
            }
            return feature;
        }

        private IList<IFeature> GetFeatures()
        {
            this.EnableEdit(false);
            int[] selectedRows = this.gridView1.GetSelectedRows();
            DataRowView row = this.gridView1.GetRow(selectedRows[0]) as DataRowView;
            ErrType type = (ErrType) int.Parse(row[3].ToString());
            IList<IFeature> list = new List<IFeature>();
            IFeature item = null;
            if (type != ErrType.Gap)
            {
                int iD = int.Parse(row[0].ToString());
                try
                {
                    item = this._layer.FeatureClass.GetFeature(iD);
                }
                catch
                {
                    item = null;
                }
                list.Add(item);
                item = null;
                row[2].ToString();
                IFeatureClass class2 = null;
                if (class2 != null)
                {
                    iD = int.Parse(row[1].ToString());
                    try
                    {
                        item = class2.GetFeature(iD);
                    }
                    catch
                    {
                        item = null;
                    }
                }
                list.Add(item);
            }
            this.EnableEdit(true);
            return list;
        }

        private ArrayList GetPolygonFeaturelayers(IGroupLayer pGLayer)
        {
            try
            {
                ILayer layer = null;
                IGroupLayer layer2 = null;
                ArrayList list = new ArrayList();
                ArrayList c = null;
                ICompositeLayer layer3 = pGLayer as ICompositeLayer;
                for (int i = 0; i < layer3.Count; i++)
                {
                    layer = layer3.get_Layer(i);
                    if (layer is IGroupLayer)
                    {
                        layer2 = layer as IGroupLayer;
                        c = this.GetPolygonFeaturelayers(layer2);
                        list.AddRange(c);
                    }
                    else if (layer is IFeatureLayer)
                    {
                        IFeatureLayer layer4 = (IFeatureLayer) layer;
                        if ((layer4.FeatureClass != null) && (layer4.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon))
                        {
                            list.Add(layer);
                        }
                    }
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ArrayList GetPolygonFeaturelayers(IMap pMap)
        {
            try
            {
                IEnumLayer layer;
                if (pMap == null)
                {
                    return null;
                }
                if (pMap.LayerCount == 0)
                {
                    return null;
                }
                ArrayList list = null;
                try
                {
                    layer = pMap.get_Layers(null, false);
                }
                catch (Exception)
                {
                    return null;
                }
                layer.Reset();
                ILayer layer3 = layer.Next();
                if (layer3 == null)
                {
                    return null;
                }
                list = new ArrayList();
                while (layer3 != null)
                {
                    if (layer3 is IGroupLayer)
                    {
                        ArrayList c = null;
                        IGroupLayer pGLayer = layer3 as IGroupLayer;
                        c = this.GetPolygonFeaturelayers(pGLayer);
                        list.AddRange(c);
                    }
                    else if (layer3 is IFeatureLayer)
                    {
                        IFeatureLayer layer4 = (IFeatureLayer) layer3;
                        if (layer4.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                        {
                            list.Add(layer3);
                        }
                    }
                    layer3 = layer.Next();
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.gridView1.GetSelectedRows().Length > 0)
                {
                    this.bsiModify.Enabled = this.bbiPanTo.Enabled = this.bbiFlash.Enabled = this.bsiModify.Enabled = this.bbiUnSelect.Enabled = true;
                    this.popupMenu1.ShowPopup(base.PointToScreen(new System.Drawing.Point(e.X, e.Y)));
                }
                else
                {
                    this.bsiModify.Enabled = this.bbiValidate.Enabled = this.bbiPanTo.Enabled = this.bbiFlash.Enabled = this.bsiModify.Enabled = this.bbiUnSelect.Enabled = false;
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            IFeature feature = this.GetFeature();
            if (feature != null)
            {
                this.ZoomToFeature(feature, this.m_hookHelper.ActiveView);
                this.SelectFeature(feature, this._layer, true);
            }
        }

        public void Init()
        {
            this.labelInfo.Text = "";
            this.ClearElement();
            this._layer = EditTask.EditLayer;
            this.SetLayers();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.btCheck = new SimpleButton();
            this.gcErr = new GridControl();
            this.gridView1 = new GridView();
            this.gbYear = new GroupBox();
            this.clbcLayers = new CheckedListBoxControl();
            this.popupMenu1 = new PopupMenu(this.components);
            this.bbiPanTo = new BarButtonItem();
            this.bsiModify = new BarSubItem();
            this.bbiValidate = new BarButtonItem();
            this.bbiSelect = new BarButtonItem();
            this.bbiUnSelect = new BarButtonItem();
            this.bbiFlash = new BarButtonItem();
            this.bbiZoom = new BarButtonItem();
            this.barManager1 = new BarManager(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.barButtonItem1 = new BarButtonItem();
            this.panelControl1 = new PanelControl();
            this.panelControl2 = new PanelControl();
            this.labelInfo = new LabelControl();
            this.gcErr.BeginInit();
            this.gridView1.BeginInit();
            this.gbYear.SuspendLayout();
            ((ISupportInitialize) this.clbcLayers).BeginInit();
            this.popupMenu1.BeginInit();
            this.barManager1.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.btCheck.Location = new System.Drawing.Point(0x115, 10);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new Size(0x57, 0x1b);
            this.btCheck.TabIndex = 2;
            this.btCheck.Text = "检查";
            this.btCheck.Click += new EventHandler(this.btCheck_Click);
            this.gcErr.Dock = DockStyle.Fill;
            this.gcErr.Location = new System.Drawing.Point(0, 0xae);
            this.gcErr.MainView = this.gridView1;
            this.gcErr.Name = "gcErr";
            this.gcErr.Size = new Size(0x189, 0x10d);
            this.gcErr.TabIndex = 4;
            this.gcErr.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gcErr.MouseDown += new MouseEventHandler(this.gridControl1_MouseDown);
            this.gridView1.GridControl = this.gcErr;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
            this.gbYear.Controls.Add(this.clbcLayers);
            this.gbYear.Dock = DockStyle.Top;
            this.gbYear.Location = new System.Drawing.Point(0, 0);
            this.gbYear.Name = "gbYear";
            this.gbYear.Size = new Size(0x189, 0x7f);
            this.gbYear.TabIndex = 6;
            this.gbYear.TabStop = false;
            this.gbYear.Text = "请选择图层";
            this.clbcLayers.CheckOnClick = true;
            this.clbcLayers.Dock = DockStyle.Fill;
            this.clbcLayers.Location = new System.Drawing.Point(3, 0x12);
            this.clbcLayers.Name = "clbcLayers";
            this.clbcLayers.Size = new Size(0x183, 0x6a);
            this.clbcLayers.TabIndex = 13;
            this.clbcLayers.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.clbcYears_ItemCheck);
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiPanTo), new LinkPersistInfo(this.bsiModify), new LinkPersistInfo(this.bbiValidate), new LinkPersistInfo(this.bbiSelect, true), new LinkPersistInfo(this.bbiUnSelect), new LinkPersistInfo(this.bbiFlash), new LinkPersistInfo(this.bbiZoom) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.bbiPanTo.Caption = "查看错误";
            this.bbiPanTo.Id = 0;
            this.bbiPanTo.Name = "bbiPanTo";
            this.bbiPanTo.ItemClick += new ItemClickEventHandler(this.bbiPanTo_ItemClick);
            this.bsiModify.Caption = "修改建议";
            this.bsiModify.Id = 2;
            this.bsiModify.Name = "bsiModify";
            this.bsiModify.GetItemData += new EventHandler(this.bsiModify_GetItemData);
            this.bbiValidate.Caption = "验证拓扑";
            this.bbiValidate.Id = 1;
            this.bbiValidate.Name = "bbiValidate";
            this.bbiValidate.Visibility = BarItemVisibility.Never;
            this.bbiSelect.Caption = "选择要素";
            this.bbiSelect.Id = 3;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.ItemClick += new ItemClickEventHandler(this.bbiSelect_ItemClick);
            this.bbiUnSelect.Caption = "取消选择";
            this.bbiUnSelect.Id = 4;
            this.bbiUnSelect.Name = "bbiUnSelect";
            this.bbiUnSelect.ItemClick += new ItemClickEventHandler(this.bbiUnSelect_ItemClick);
            this.bbiFlash.Caption = "闪烁要素";
            this.bbiFlash.Id = 5;
            this.bbiFlash.Name = "bbiFlash";
            this.bbiFlash.ItemClick += new ItemClickEventHandler(this.bbiFlash_ItemClick);
            this.bbiZoom.Caption = "缩放到要素";
            this.bbiZoom.Id = 7;
            this.bbiZoom.Name = "bbiZoom";
            this.bbiZoom.ItemClick += new ItemClickEventHandler(this.bbiZoom_ItemClick);
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.bbiPanTo, this.bbiValidate, this.bsiModify, this.bbiSelect, this.bbiUnSelect, this.bbiFlash, this.barButtonItem1, this.bbiZoom });
            this.barManager1.MaxItemId = 8;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new Size(0x189, 0);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 0x1d8);
            this.barDockControlBottom.Size = new Size(0x189, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new Size(0, 0x1d8);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(0x189, 0);
            this.barDockControlRight.Size = new Size(0, 0x1d8);
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            this.panelControl1.Controls.Add(this.btCheck);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x7f);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x189, 0x2f);
            this.panelControl1.TabIndex = 7;
            this.panelControl2.Controls.Add(this.labelInfo);
            this.panelControl2.Dock = DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 0x1bb);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x189, 0x1d);
            this.panelControl2.TabIndex = 8;
            this.labelInfo.Appearance.ForeColor = Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(280, 7);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(0x54, 14);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "拓扑错误个数为";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x189, 0x1d8);
            base.Controls.Add(this.gcErr);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.gbYear);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.Name = "MultiLayerCheck";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "图层间重叠检查";
            base.Load += new EventHandler(this.MultiLayerCheck_Load);
            base.FormClosing += new FormClosingEventHandler(this.MultiLayerCheck_FormClosing);
            this.gcErr.EndInit();
            this.gridView1.EndInit();
            this.gbYear.ResumeLayout(false);
            ((ISupportInitialize) this.clbcLayers).EndInit();
            this.popupMenu1.EndInit();
            this.barManager1.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            object tag = this.bsiModify.Tag;
            IList<IFeature> features = this.GetFeatures();
            if ((features != null) && (features.Count >= 1))
            {
                IFeature feature = features[0];
                IFeature feature2 = features[1];
                ITopologicalOperator2 shapeCopy = feature.ShapeCopy as ITopologicalOperator2;
                shapeCopy.IsKnownSimple_2 = false;
                shapeCopy.Simplify();
                if (!shapeCopy.Intersect(feature2.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension).IsEmpty)
                {
                    Editor.UniqueInstance.CheckOverlap = false;
                    Editor.UniqueInstance.StartEditOperation();
                    Editor.UniqueInstance.StopEditOperation();
                    Editor.UniqueInstance.CheckOverlap = true;
                    this.m_hookHelper.ActiveView.Refresh();
                }
            }
        }

        private void LoadData()
        {
            ErrorTable table = new ErrorTable();
            new List<ErrType>().Add(ErrType.MultiOverlap);
            DataTable table2 = table.GetTable(ErrType.MultiOverlap);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                this.gcErr.DataSource = table2;
                ColumnView focusedView = this.gcErr.FocusedView as ColumnView;
                focusedView.Columns[0].Caption = "要素ID";
                focusedView.Columns[1].Caption = "错误描述";
                focusedView.Columns[2].Visible = focusedView.Columns[3].Visible = focusedView.Columns[4].Visible = false;
            }
            else
            {
                this.gcErr.DataSource = null;
            }
        }

        private void MultiLayerCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.t != null) && this.t.IsAlive)
            {
                this.t.Abort();
                this.t.Join();
                this.t = null;
                this.ClearElement();
                this.m_hookHelper.ActiveView.Refresh();
            }
        }

        private void MultiLayerCheck_Load(object sender, EventArgs e)
        {
            this.Init();
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

        private void SetLayers()
        {
            if (this.m_hookHelper != null)
            {
                IMap focusMap = this.m_hookHelper.FocusMap;
                if (focusMap != null)
                {
                    if (this.m_Layers == null)
                    {
                        this.m_Layers = this.GetPolygonFeaturelayers(focusMap);
                    }
                    if (this.m_Layers != null)
                    {
                        for (int i = 0; i < this.m_Layers.Count; i++)
                        {
                            ILayer layer = this.m_Layers[i] as ILayer;
                            this.clbcLayers.Items.Add(layer.Name);
                        }
                        this.clbcLayers.SelectedIndex = 0;
                    }
                }
            }
        }

        private void UnSelectFeature(IFeature feature, IFeatureLayer pLayer)
        {
            IFeatureSelection selection = (IFeatureSelection) this._layer;
            ISelectionSet selectionSet = selection.SelectionSet;
            int oID = feature.OID;
            selectionSet.RemoveList(1, ref oID);
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, null);
        }

        private void ZoomToFeature(IFeature feature, IActiveView pActiveView)
        {
            IGeometry shapeCopy = feature.ShapeCopy;
            shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_hookHelper.ActiveView.FocusMap.SpatialReference);
            IEnvelope envelope = new EnvelopeClass();
            envelope.SpatialReference = this.m_hookHelper.ActiveView.FocusMap.SpatialReference;
            double num = 100.0;
            envelope.PutCoords(shapeCopy.Envelope.XMin - num, shapeCopy.Envelope.YMin - num, shapeCopy.Envelope.XMax + num, shapeCopy.Envelope.YMax + num);
            this.m_hookHelper.ActiveView.Extent = envelope;
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, envelope);
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

