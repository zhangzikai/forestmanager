namespace GISControlsClass
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlLayerControl : UserControlBase1
    {
        private Bar bar1;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItemClear;
        private BarButtonItem barButtonItemRefresh;
        private BarButtonItem barButtonItemRemove;
        private BarButtonItem barButtonItemSymbol;
        private BarButtonItem barButtonItemZoomTo;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private IContainer components;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private ImageListBoxControl imageListBoxControl1;
        private IActiveViewEvents_Event mActiveViewEvents;
        public IMap Map;
        private const string mClassName = "MainFrame.UserControlLayerControl";
        public string mEditKind;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mLayerList;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PopupMenu popupMenu1;
        public TreeList treeList1;
        private TreeListColumn treeListColumn1;

        public UserControlLayerControl()
        {
            this.InitializeComponent();
        }

        private void barButtonItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < (this.treeList1.Selection[0].Nodes.Count - 1); i++)
            {
                ILayer tag = this.treeList1.Selection[0].Nodes[i].Tag as ILayer;
                this.Map.DeleteLayer(tag);
            }
            (this.Map as IActiveView).Refresh();
        }

        private void barButtonItemRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.treeList1.Selection.Count != 0)
                {
                    TreeListNode node = this.treeList1.Selection[0];
                    IActiveView map = this.Map as IActiveView;
                    if (node.Tag != null)
                    {
                        ArrayList tag = null;
                        if (node.Tag is ArrayList)
                        {
                            tag = node.Tag as ArrayList;
                            for (int i = 0; i < tag.Count; i++)
                            {
                                ILayer data = tag[i] as ILayer;
                                if (data is IGroupLayer)
                                {
                                    IGroupLayer layer2 = data as IGroupLayer;
                                    ICompositeLayer layer3 = layer2 as ICompositeLayer;
                                    for (int j = 0; j < layer3.Count; j++)
                                    {
                                        ILayer layer4 = layer3.get_Layer(j);
                                        map.PartialRefresh(esriViewDrawPhase.esriViewGeography, layer4, layer4.AreaOfInterest);
                                    }
                                }
                                else if (data is IFeatureLayer)
                                {
                                    map.PartialRefresh(esriViewDrawPhase.esriViewGeography, data, data.AreaOfInterest);
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

        private void barButtonItemRemove_ItemClick(object sender, ItemClickEventArgs e)
        {
            ILayer tag = this.treeList1.Selection[0].Tag as ILayer;
            this.Map.DeleteLayer(tag);
            (this.Map as IActiveView).Refresh();
        }

        private void barButtonItemZoomTo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.treeList1.Selection.Count != 0)
                {
                    TreeListNode node = this.treeList1.Selection[0];
                    if (node.Tag != null)
                    {
                        IEnvelope areaOfInterest = new EnvelopeClass();
                        areaOfInterest.PutCoords(0.0, 0.0, 0.0, 0.0);
                        ArrayList tag = null;
                        if (node.Tag is ArrayList)
                        {
                            tag = node.Tag as ArrayList;
                            for (int i = 0; i < tag.Count; i++)
                            {
                                ILayer layer = tag[i] as ILayer;
                                if (layer is IGroupLayer)
                                {
                                    IGroupLayer layer2 = layer as IGroupLayer;
                                    ICompositeLayer layer3 = layer2 as ICompositeLayer;
                                    for (int j = 0; j < layer3.Count; j++)
                                    {
                                        ILayer layer4 = layer3.get_Layer(j);
                                        if ((areaOfInterest.XMin == 0.0) && (areaOfInterest.YMin == 0.0))
                                        {
                                            areaOfInterest = layer4.AreaOfInterest;
                                        }
                                        else
                                        {
                                            if (areaOfInterest.XMin > layer4.AreaOfInterest.XMin)
                                            {
                                                areaOfInterest.XMin = layer4.AreaOfInterest.XMin;
                                            }
                                            if (areaOfInterest.YMin > layer4.AreaOfInterest.YMin)
                                            {
                                                areaOfInterest.YMin = layer4.AreaOfInterest.YMin;
                                            }
                                            if (areaOfInterest.XMax < layer4.AreaOfInterest.XMax)
                                            {
                                                areaOfInterest.XMax = layer4.AreaOfInterest.XMax;
                                            }
                                            if (areaOfInterest.YMax < layer4.AreaOfInterest.YMax)
                                            {
                                                areaOfInterest.YMax = layer4.AreaOfInterest.YMax;
                                            }
                                        }
                                    }
                                }
                                else if (layer is IFeatureLayer)
                                {
                                    if ((areaOfInterest.XMin == 0.0) && (areaOfInterest.YMin == 0.0))
                                    {
                                        areaOfInterest = layer.AreaOfInterest;
                                    }
                                    else if (areaOfInterest.XMin > layer.AreaOfInterest.XMin)
                                    {
                                        areaOfInterest.XMin = layer.AreaOfInterest.XMin;
                                    }
                                    else if (areaOfInterest.YMin > layer.AreaOfInterest.YMin)
                                    {
                                        areaOfInterest.YMin = layer.AreaOfInterest.YMin;
                                    }
                                    else if (areaOfInterest.XMax < layer.AreaOfInterest.XMax)
                                    {
                                        areaOfInterest.XMax = layer.AreaOfInterest.XMax;
                                    }
                                    else if (areaOfInterest.YMax < layer.AreaOfInterest.YMax)
                                    {
                                        areaOfInterest.YMax = layer.AreaOfInterest.YMax;
                                    }
                                }
                            }
                            IActiveView map = this.Map as IActiveView;
                            if ((areaOfInterest.Width != 0.0) && (areaOfInterest.Height != 0.0))
                            {
                                map.Extent = areaOfInterest;
                                map.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool CheckHasLayer(IGroupLayer pGLayer)
        {
            try
            {
                ICompositeLayer layer = pGLayer as ICompositeLayer;
                for (int i = 0; i < layer.Count; i++)
                {
                    if (layer.get_Layer(i) != null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
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

        private void InitializeComponent()
        {
            this.components = new Container();
            SuperToolTip tip = new SuperToolTip();
            ToolTipTitleItem item = new ToolTipTitleItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipTitleItem item2 = new ToolTipTitleItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipTitleItem item3 = new ToolTipTitleItem();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlLayerControl));
            this.barManager1 = new BarManager(this.components);
            this.bar1 = new Bar();
            this.barButtonItem2 = new BarButtonItem();
            this.barButtonItem1 = new BarButtonItem();
            this.barButtonItem3 = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItemRemove = new BarButtonItem();
            this.barButtonItemSymbol = new BarButtonItem();
            this.barButtonItemClear = new BarButtonItem();
            this.barButtonItemRefresh = new BarButtonItem();
            this.barButtonItemZoomTo = new BarButtonItem();
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.popupMenu1 = new PopupMenu(this.components);
            this.imageListBoxControl1 = new ImageListBoxControl();
            this.barManager1.BeginInit();
            this.imageCollection1.BeginInit();
            this.treeList1.BeginInit();
            this.imageCollection2.BeginInit();
            this.popupMenu1.BeginInit();
            ((ISupportInitialize) this.imageListBoxControl1).BeginInit();
            base.SuspendLayout();
            this.barManager1.Bars.AddRange(new Bar[] { this.bar1 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new BarItem[] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItemRemove, this.barButtonItemSymbol, this.barButtonItemClear, this.barButtonItemRefresh, this.barButtonItemZoomTo });
            this.barManager1.LargeImages = this.imageCollection1;
            this.barManager1.MaxItemId = 8;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barButtonItem2), new LinkPersistInfo(this.barButtonItem1, true), new LinkPersistInfo(this.barButtonItem3, true) });
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            this.barButtonItem2.ButtonStyle = BarButtonStyle.Check;
            this.barButtonItem2.Caption = "作业";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageIndex = 0x41;
            this.barButtonItem2.LargeImageIndex = 7;
            this.barButtonItem2.Name = "barButtonItem2";
            item.Text = "作业设计图";
            tip.Items.Add(item);
            this.barButtonItem2.SuperTip = tip;
            this.barButtonItem1.ButtonStyle = BarButtonStyle.Check;
            this.barButtonItem1.Caption = "底图";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageIndex = 0x3f;
            this.barButtonItem1.Name = "barButtonItem1";
            item2.Text = "作业底图";
            tip2.Items.Add(item2);
            this.barButtonItem1.SuperTip = tip2;
            this.barButtonItem3.Caption = "查询";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.ImageIndex = 0x2f;
            this.barButtonItem3.LargeImageIndex = 0x23;
            this.barButtonItem3.Name = "barButtonItem3";
            item3.Text = "查询图层";
            tip3.Items.Add(item3);
            this.barButtonItem3.SuperTip = tip3;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new Size(0xe9, 0x1a);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 700);
            this.barDockControlBottom.Size = new Size(0xe9, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0x1a);
            this.barDockControlLeft.Size = new Size(0, 0x2a2);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(0xe9, 0x1a);
            this.barDockControlRight.Size = new Size(0, 0x2a2);
            this.imageCollection1.ImageSize = new Size(0x18, 0x18);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection1.ImageStream");
            this.barButtonItemRemove.Caption = "删除";
            this.barButtonItemRemove.Id = 3;
            this.barButtonItemRemove.ImageIndex = 13;
            this.barButtonItemRemove.Name = "barButtonItemRemove";
            this.barButtonItemRemove.Visibility = BarItemVisibility.Never;
            this.barButtonItemRemove.ItemClick += new ItemClickEventHandler(this.barButtonItemRemove_ItemClick);
            this.barButtonItemSymbol.ButtonStyle = BarButtonStyle.Check;
            this.barButtonItemSymbol.Caption = "符号";
            this.barButtonItemSymbol.Id = 4;
            this.barButtonItemSymbol.ImageIndex = 10;
            this.barButtonItemSymbol.Name = "barButtonItemSymbol";
            this.barButtonItemSymbol.Visibility = BarItemVisibility.Never;
            this.barButtonItemClear.Caption = "清空";
            this.barButtonItemClear.Id = 5;
            this.barButtonItemClear.ImageIndex = 0x2c;
            this.barButtonItemClear.Name = "barButtonItemClear";
            this.barButtonItemClear.Visibility = BarItemVisibility.Never;
            this.barButtonItemClear.ItemClick += new ItemClickEventHandler(this.barButtonItemClear_ItemClick);
            this.barButtonItemRefresh.Caption = "刷新";
            this.barButtonItemRefresh.Id = 6;
            this.barButtonItemRefresh.ImageIndex = 0x24;
            this.barButtonItemRefresh.Name = "barButtonItemRefresh";
            this.barButtonItemRefresh.ItemClick += new ItemClickEventHandler(this.barButtonItemRefresh_ItemClick);
            this.barButtonItemZoomTo.Caption = "缩放到";
            this.barButtonItemZoomTo.Id = 7;
            this.barButtonItemZoomTo.ImageIndex = 0x4b;
            this.barButtonItemZoomTo.Name = "barButtonItemZoomTo";
            this.barButtonItemZoomTo.ItemClick += new ItemClickEventHandler(this.barButtonItemZoomTo_ItemClick);
            this.treeList1.BorderStyle = BorderStyles.NoBorder;
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1 });
            this.treeList1.Cursor = Cursors.Default;
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0x1a);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] { "作业设计图" }, -1, -1, -1, 6, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "勾绘底图" }, -1, -1, -1, 0x4c);
            this.treeList1.AppendNode(new object[] { "行政区划" }, -1, -1, -1, 30, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "县" }, 2, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "乡" }, 2, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "村" }, 2, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "林班" }, 2, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "林业资源" }, -1, -1, -1, 0x52, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "林班" }, 7, -1, -1, 0x2c, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "小班" }, 7, -1, -1, 0x2c, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "小班_地类" }, 7, -1, -1, 0x2c);
            this.treeList1.AppendNode(new object[] { "小班_林种" }, 7, -1, -1, 0x2c);
            this.treeList1.AppendNode(new object[] { "基础地理" }, -1, -1, -1, 0x51);
            this.treeList1.AppendNode(new object[] { "地名" }, 12, -1, -1, 0x34);
            this.treeList1.AppendNode(new object[] { "道路" }, 12, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "水系" }, 12, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "高程" }, -1, -1, -1, 0x3e);
            this.treeList1.AppendNode(new object[] { "地类山地阴影" }, 0x10, -1, -1, 3);
            this.treeList1.AppendNode(new object[] { "数字高程" }, 0x10, -1, -1, 3);
            this.treeList1.AppendNode(new object[] { "影像" }, -1, -1, -1, 0x19);
            this.treeList1.AppendNode(new object[] { "查询结果" }, -1, -1, -1, 8, CheckState.Checked);
            this.treeList1.AppendNode(new object[] { "作业设计" }, 20, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "类型查询" }, 20, -1, -1, 9);
            this.treeList1.AppendNode(new object[] { "临时图层" }, -1, -1, -1, 0x2b, CheckState.Checked);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RowHeight = 0x1c;
            this.treeList1.SelectImageList = this.imageCollection2;
            this.treeList1.Size = new Size(0xe9, 0x2a2);
            this.treeList1.StateImageList = this.imageCollection2;
            this.treeList1.TabIndex = 5;
            this.treeList1.TreeLevelWidth = 20;
            this.treeList1.TreeLineStyle = LineStyle.None;
            this.treeList1.MouseDown += new MouseEventHandler(this.treeList1_MouseDown);
            this.treeList1.MouseUp += new MouseEventHandler(this.treeList1_MouseUp);
            this.treeList1.MouseMove += new MouseEventHandler(this.treeList1_MouseMove);
            this.treeList1.AfterCheckNode += new NodeEventHandler(this.treeList1_AfterCheckNode);
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 0x6c;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0x58;
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection2.ImageStream");
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
            this.imageCollection2.Images.SetKeyName(0x10, "maps.png");
            this.imageCollection2.Images.SetKeyName(0x11, "maps--arrow.png");
            this.imageCollection2.Images.SetKeyName(0x12, "maps--exclamation.png");
            this.imageCollection2.Images.SetKeyName(0x13, "maps--minus.png");
            this.imageCollection2.Images.SetKeyName(20, "maps--pencil.png");
            this.imageCollection2.Images.SetKeyName(0x15, "maps--pencil2.png");
            this.imageCollection2.Images.SetKeyName(0x16, "maps--pencil3.png");
            this.imageCollection2.Images.SetKeyName(0x17, "maps--plus.png");
            this.imageCollection2.Images.SetKeyName(0x18, "maps-stack.png");
            this.imageCollection2.Images.SetKeyName(0x19, "pathing3.png");
            this.imageCollection2.Images.SetKeyName(0x1a, "picture_pencil.png");
            this.imageCollection2.Images.SetKeyName(0x1b, "table__arrow.png");
            this.imageCollection2.Images.SetKeyName(0x1c, "arrow_large_up.png");
            this.imageCollection2.Images.SetKeyName(0x1d, "web design_16_hot.png");
            this.imageCollection2.Images.SetKeyName(30, "ksirtet16.png");
            this.imageCollection2.Images.SetKeyName(0x1f, "node-select-child.png");
            this.imageCollection2.Images.SetKeyName(0x20, "flag blue.png");
            this.imageCollection2.Images.SetKeyName(0x21, "flag red.png");
            this.imageCollection2.Images.SetKeyName(0x22, "flag yellow.png");
            this.imageCollection2.Images.SetKeyName(0x23, "image.png");
            this.imageCollection2.Images.SetKeyName(0x24, "image_edit.png");
            this.imageCollection2.Images.SetKeyName(0x25, "image_magnify.png");
            this.imageCollection2.Images.SetKeyName(0x26, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(0x27, "page_paintbrush.png");
            this.imageCollection2.Images.SetKeyName(40, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(0x29, "pencil.png");
            this.imageCollection2.Images.SetKeyName(0x2a, "photo.png");
            this.imageCollection2.Images.SetKeyName(0x2b, "photos.png");
            this.imageCollection2.Images.SetKeyName(0x2c, "picture.png");
            this.imageCollection2.Images.SetKeyName(0x2d, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(0x2e, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(0x2f, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(0x30, "search.gif");
            this.imageCollection2.Images.SetKeyName(0x31, "table.png");
            this.imageCollection2.Images.SetKeyName(50, "table_edit.png");
            this.imageCollection2.Images.SetKeyName(0x33, "(01,40).png");
            this.imageCollection2.Images.SetKeyName(0x34, "(01,46).png");
            this.imageCollection2.Images.SetKeyName(0x35, "(09,46).png");
            this.imageCollection2.Images.SetKeyName(0x36, "(12,11).png");
            this.imageCollection2.Images.SetKeyName(0x37, "(14,36).png");
            this.imageCollection2.Images.SetKeyName(0x38, "(14,37).png");
            this.imageCollection2.Images.SetKeyName(0x39, "(15,25).png");
            this.imageCollection2.Images.SetKeyName(0x3a, "(15,40).png");
            this.imageCollection2.Images.SetKeyName(0x3b, "(16,32).png");
            this.imageCollection2.Images.SetKeyName(60, "(17,49).png");
            this.imageCollection2.Images.SetKeyName(0x3d, "(19,01).png");
            this.imageCollection2.Images.SetKeyName(0x3e, "(24,04).png");
            this.imageCollection2.Images.SetKeyName(0x3f, "(24,32).png");
            this.imageCollection2.Images.SetKeyName(0x40, "(28,09).png");
            this.imageCollection2.Images.SetKeyName(0x41, "(29,04).png");
            this.imageCollection2.Images.SetKeyName(0x42, "(30,24).png");
            this.imageCollection2.Images.SetKeyName(0x43, "(32,04).png");
            this.imageCollection2.Images.SetKeyName(0x44, "(32,24).png");
            this.imageCollection2.Images.SetKeyName(0x45, "(33,14).png");
            this.imageCollection2.Images.SetKeyName(70, "(35,29).png");
            this.imageCollection2.Images.SetKeyName(0x47, "(35,31).png");
            this.imageCollection2.Images.SetKeyName(0x48, "(35,45).png");
            this.imageCollection2.Images.SetKeyName(0x49, "(36,04).png");
            this.imageCollection2.Images.SetKeyName(0x4a, "(36,47).png");
            this.imageCollection2.Images.SetKeyName(0x4b, "(39,47).png");
            this.imageCollection2.Images.SetKeyName(0x4c, "(40,05).png");
            this.imageCollection2.Images.SetKeyName(0x4d, "(44,27).png");
            this.imageCollection2.Images.SetKeyName(0x4e, "(45,28).png");
            this.imageCollection2.Images.SetKeyName(0x4f, "(49,06).png");
            this.imageCollection2.Images.SetKeyName(80, "(49,48).png");
            this.imageCollection2.Images.SetKeyName(0x51, "(15,49).png");
            this.imageCollection2.Images.SetKeyName(0x52, "(27,15).png");
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barButtonItemZoomTo), new LinkPersistInfo(this.barButtonItemRefresh), new LinkPersistInfo(this.barButtonItemRemove), new LinkPersistInfo(this.barButtonItemClear), new LinkPersistInfo(this.barButtonItemSymbol) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.imageListBoxControl1.ImageList = this.imageCollection1;
            this.imageListBoxControl1.Items.AddRange(new ImageListBoxItem[] { new ImageListBoxItem("编辑图层", 0), new ImageListBoxItem("编辑底图", 0x41) });
            this.imageListBoxControl1.Location = new System.Drawing.Point(0x2f, 0x164);
            this.imageListBoxControl1.Name = "imageListBoxControl1";
            this.imageListBoxControl1.Size = new Size(140, 0x6f);
            this.imageListBoxControl1.TabIndex = 6;
            this.imageListBoxControl1.Visible = false;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.imageListBoxControl1);
            base.Controls.Add(this.treeList1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            this.Cursor = Cursors.Default;
            base.Name = "UserControlLayerControl";
            base.Size = new Size(0xe9, 700);
            this.barManager1.EndInit();
            this.imageCollection1.EndInit();
            this.treeList1.EndInit();
            this.imageCollection2.EndInit();
            this.popupMenu1.EndInit();
            ((ISupportInitialize) this.imageListBoxControl1).EndInit();
            base.ResumeLayout(false);
        }

        public void InitialValue()
        {
            try
            {
                this.mActiveViewEvents = this.Map as IActiveViewEvents_Event;
                this.mActiveViewEvents.ItemAdded += (new IActiveViewEvents_ItemAddedEventHandler(this.mActiveViewEvents_ItemAdded));
                this.mActiveViewEvents.ItemDeleted += (new IActiveViewEvents_ItemDeletedEventHandler(this.mActiveViewEvents_ItemDeleted));
                this.mActiveViewEvents.ViewRefreshed += (new IActiveViewEvents_ViewRefreshedEventHandler(this.mActiveViewEvents_ViewRefreshed));
                this.mLayerList = new ArrayList();
                if (this.mEditKind == "火灾")
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图," + this.mEditKind + ";森林火灾,遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果," + this.mEditKind + "专题");
                    this.mLayerList.Add("临时图层");
                }
                else if (this.mEditKind == "自然灾害")
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图,灾害;自然灾害,遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果,灾害专题");
                    this.mLayerList.Add("临时图层");
                }
                else if (this.mEditKind.Contains("征占用"))
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图,征占用;林地征占用,遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县界,乡-乡-乡界,村-村-村界");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理信息,基础地理_250K;地名-其它地名-村名-乡镇名-县名-居民地,道路-高速公路-道路1-道路2,水系-河流-有名河流-湖泊");
                    this.mLayerList.Add("影像,影像;卫星影像,山地阴影");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果," + this.mEditKind + "专题");
                    this.mLayerList.Add("临时图层");
                }
                else if (this.mEditKind == "林业工程")
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图,工程;" + this.mEditKind + ",遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果,工程专题");
                    this.mLayerList.Add("临时图层");
                }
                else if (this.mEditKind == "案件")
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图, " + this.mEditKind + ";林业案件,遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果," + this.mEditKind + "专题");
                    this.mLayerList.Add("临时图层");
                }
                else if (this.mEditKind == "小班")
                {
                    this.treeList1.Nodes[0].SetValue(0, "小班变更编辑");
                    this.mLayerList.Add("小班变更编辑,小班变更;变更编辑,编辑底图");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果," + this.mEditKind + "专题");
                    this.mLayerList.Add("临时图层");
                }
                else if ((this.mEditKind == "造林") || (this.mEditKind == "采伐"))
                {
                    this.treeList1.Nodes[0].SetValue(0, this.mEditKind + "编辑图");
                    this.mLayerList.Add(this.mEditKind + "编辑图," + this.mEditKind + ";" + this.mEditKind + "作业,遥感判读");
                    this.mLayerList.Add("勾绘底图,扫描图;扫描图(1:5万)");
                    this.mLayerList.Add("行政区划,界限,区划;县-县-国界-地区界-县_界线-县_界线晕,乡-乡-乡_界线,村-村-村_界线,林班-1万林班界线");
                    this.mLayerList.Add("林业资源,林业资源;林班,小班,小班_地类,小班_林种");
                    this.mLayerList.Add("基础地理,基础地理;地名-村名-乡名-县名,道路-省级公路_线-县级公路_线-乡级公路_线-一般公路_线,水系-水库_面-一般河流_面-湖泊及人工湿地_面");
                    this.mLayerList.Add("影像,影像;卫星影像,遥感影像");
                    this.mLayerList.Add("高程,数字高程;地类山地阴影-山地阴影_小班地类,林种山地阴影-山地阴影_小班林种,数字高程-DEM(30米)-山地阴影(30米)-DEM(1:25万)-25万栅格");
                    this.mLayerList.Add("查询结果," + this.mEditKind + "专题");
                    this.mLayerList.Add("临时图层");
                }
                this.SetLayerList();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrame.UserControlLayerControl", "InitializeEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mActiveViewEvents_ItemAdded(object Item)
        {
            if (base.Visible && !base.Disposing)
            {
                this.SetLayerList();
            }
        }

        private void mActiveViewEvents_ItemDeleted(object Item)
        {
            if (base.Visible && !base.Disposing)
            {
                this.SetLayerList();
            }
        }

        private void mActiveViewEvents_ViewRefreshed(IActiveView view, esriViewDrawPhase phase, object Data, IEnvelope envelope)
        {
            if (base.Visible && !base.Disposing)
            {
                this.SetLayerList();
            }
        }

        private void RefreshLayerList()
        {
        }

        private void SetLayerList()
        {
            try
            {
                TreeListNode parentNode = null;
                TreeListNode node2 = null;
                IGroupLayer pGLayer = null;
                ILayer layer2 = null;
                string str = "";
                string sLayerName = "";
                ArrayList list = null;
                ArrayList list2 = null;
                for (int i = 0; i < this.mLayerList.Count; i++)
                {
                    string[] strArray = this.mLayerList[i].ToString().Split(new char[] { ';' });
                    string[] strArray2 = strArray[0].Split(new char[] { ',' });
                    string[] strArray3 = null;
                    string[] strArray4 = null;
                    if (strArray.Length == 2)
                    {
                        strArray3 = strArray[1].Split(new char[] { ',' });
                    }
                    else
                    {
                        strArray3 = new string[0];
                    }
                    if (strArray2.Length > 0)
                    {
                        str = strArray2[0];
                    }
                    if (str == "")
                    {
                        return;
                    }
                    for (int k = 0; k < this.treeList1.Nodes.Count; k++)
                    {
                        parentNode = this.treeList1.Nodes[k];
                        if (parentNode.GetValue(0) == null)
                        {
                            return;
                        }
                        if ((parentNode.GetValue(0).ToString() == str) && (this.treeList1.Nodes[k].ParentNode == null))
                        {
                            if (strArray2.Length > 1)
                            {
                                list = new ArrayList();
                                bool flag = false;
                                for (int m = 1; m < strArray2.Length; m++)
                                {
                                    sLayerName = strArray2[m];
                                    pGLayer = GISFunFactory.LayerFun.FindLayer(this.Map as IBasicMap, sLayerName, true) as IGroupLayer;
                                    if (!flag)
                                    {
                                        flag = this.CheckHasLayer(pGLayer);
                                    }
                                    list.Add(pGLayer);
                                    parentNode.Checked = pGLayer.Visible;
                                }
                                if (list.Count > 0)
                                {
                                    parentNode.Tag = list;
                                }
                                else
                                {
                                    parentNode.Tag = null;
                                }
                                parentNode.Visible = flag;
                                if ((strArray.Length == 1) || (strArray[1] == ""))
                                {
                                    parentNode.Nodes.Clear();
                                }
                                if (parentNode.Nodes.Count > 0)
                                {
                                    for (int n = 0; n < parentNode.Nodes.Count; n++)
                                    {
                                        node2 = parentNode.Nodes[n];
                                        node2.Tag = null;
                                        list2 = new ArrayList();
                                        for (int num5 = 0; num5 < strArray3.Length; num5++)
                                        {
                                            strArray4 = strArray3[num5].Split(new char[] { '-' });
                                            if (strArray4[0] == node2.GetValue(0).ToString())
                                            {
                                                if (strArray4.Length > 1)
                                                {
                                                    for (int num6 = 1; num6 < strArray4.Length; num6++)
                                                    {
                                                        for (int num7 = 0; num7 < list.Count; num7++)
                                                        {
                                                            IGroupLayer pGroupLayer = list[num7] as IGroupLayer;
                                                            layer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, strArray4[num6], true);
                                                            if (layer2 != null)
                                                            {
                                                                list2.Add(layer2);
                                                                node2.Checked = layer2.Visible;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    for (int num8 = 0; num8 < list.Count; num8++)
                                                    {
                                                        IGroupLayer layer4 = list[num8] as IGroupLayer;
                                                        layer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(layer4, strArray4[0], true);
                                                        if (layer2 != null)
                                                        {
                                                            list2.Add(layer2);
                                                            node2.Checked = layer2.Visible;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (list2.Count > 0)
                                        {
                                            node2.Tag = list2;
                                        }
                                        else
                                        {
                                            node2.Tag = null;
                                        }
                                    }
                                }
                                else
                                {
                                    list2 = new ArrayList();
                                    if ((strArray3.Length > 0) && (strArray3[0] != ""))
                                    {
                                        for (int num9 = 0; num9 < strArray3.Length; num9++)
                                        {
                                            for (int num10 = 0; num10 < list.Count; num10++)
                                            {
                                                IGroupLayer layer5 = list[num10] as IGroupLayer;
                                                layer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(layer5, strArray3[num9], true);
                                                if (layer2 != null)
                                                {
                                                    list2.Add(layer2);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int num11 = 0; num11 < list.Count; num11++)
                                        {
                                            IGroupLayer layer6 = list[num11] as IGroupLayer;
                                            ICompositeLayer layer7 = layer6 as ICompositeLayer;
                                            for (int num12 = 0; num12 < layer7.Count; num12++)
                                            {
                                                layer2 = layer7.get_Layer(num12);
                                                if (layer2 != null)
                                                {
                                                    list2.Add(layer2);
                                                    node2 = this.treeList1.AppendNode(layer2.Name, parentNode);
                                                    node2.SetValue(0, layer2.Name);
                                                    node2.ImageIndex = -1;
                                                    node2.SelectImageIndex = -1;
                                                    node2.StateImageIndex = 9;
                                                    node2.Checked = layer2.Visible;
                                                    node2.Tag = layer2;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                parentNode.Tag = null;
                                parentNode.Nodes.Clear();
                                for (int num13 = 0; num13 < this.Map.LayerCount; num13++)
                                {
                                    ILayer layer8 = this.Map.get_Layer(num13);
                                    if (!(layer8 is IGroupLayer))
                                    {
                                        node2 = this.treeList1.AppendNode(layer8.Name, parentNode);
                                        node2.SetValue(0, layer8.Name);
                                        node2.ImageIndex = -1;
                                        node2.SelectImageIndex = -1;
                                        node2.StateImageIndex = 9;
                                        node2.Checked = layer8.Visible;
                                        node2.Tag = layer8;
                                    }
                                }
                                parentNode.Visible = parentNode.HasChildren;
                            }
                            break;
                        }
                    }
                }
                for (int j = 0; j < this.mLayerList.Count; j++)
                {
                    string[] strArray5 = this.mLayerList[j].ToString().Split(new char[] { ';' });
                    if (strArray5.Length > 1)
                    {
                        string[] strArray6 = strArray5[0].Split(new char[] { ',' });
                        if ((strArray6.Length != 0) && (strArray6.Length != 1))
                        {
                            int length = strArray6.Length;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrame.UserControlLayerControl", "SetLayerList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            try
            {
                bool flag = false;
                if (e.Node.Tag != null)
                {
                    ArrayList tag = null;
                    if (e.Node.Tag is ArrayList)
                    {
                        tag = e.Node.Tag as ArrayList;
                        if (tag.Count == 0)
                        {
                            return;
                        }
                        ILayer layer = tag[0] as ILayer;
                        if (layer is IGroupLayer)
                        {
                            for (int i = 0; i < tag.Count; i++)
                            {
                                IGroupLayer layer2 = tag[i] as IGroupLayer;
                                if (layer2 != null)
                                {
                                    layer2.Visible = e.Node.Checked;
                                    if (!flag)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < tag.Count; j++)
                            {
                                layer = tag[j] as ILayer;
                                layer.Visible = e.Node.Checked;
                                if (!flag)
                                {
                                    flag = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        ILayer layer3 = e.Node.Tag as ILayer;
                        layer3.Visible = e.Node.Checked;
                        if (!flag)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    (this.Map as IActiveView).Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrame.UserControlLayerControl", "treeList1_AfterCheckNode", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            this.barManager1.SetPopupContextMenu(this, this.popupMenu1);
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (this.treeList1.Selection.Count > 0))
            {
                this.barManager1.SetPopupContextMenu(this, this.popupMenu1);
                if (this.treeList1.Selection[0].GetDisplayText(0) == "临时图层")
                {
                    this.barButtonItemClear.Visibility = BarItemVisibility.Always;
                    this.barButtonItemRemove.Visibility = BarItemVisibility.Never;
                }
                if ((this.treeList1.Selection[0].ParentNode != null) && (this.treeList1.Selection[0].ParentNode.GetDisplayText(0) == "临时图层"))
                {
                    this.barButtonItemClear.Visibility = BarItemVisibility.Never;
                    this.barButtonItemRemove.Visibility = BarItemVisibility.Always;
                }
                this.popupMenu1.ShowPopup(e.Location);
            }
            else
            {
                this.barManager1.SetPopupContextMenu(this, null);
            }
        }
    }
}

