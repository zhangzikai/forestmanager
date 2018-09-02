namespace GISControlsClass
{
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlLegendList : UserControlBase1
    {
        private IContainer components;
        private ImageList imageList1;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "GISControlsClass.UserControlLegendList";
        private string mEditKind;
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private HookHelper mHookHelper;
        private ArrayList mLayerList;
        private IMap mMap;
        private ArrayList mNameList;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "图例";
        private TreeList treeList1;
        private TreeListColumn treeListColumn1;

        public UserControlLegendList()
        {
            this.InitializeComponent();
        }

        private Image Convert(ISymbol sym, int width, int height)
        {
            Image image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            IntPtr hdc = graphics.GetHdc();
            IEnvelope env = new EnvelopeClass();
            ITransformation transformation = null;
            env.XMin = 0.0;
            env.XMax = width;
            env.YMin = 0.0;
            env.YMax = height;
            IGeometry geometry = this.CreateGeometryFromSymbol(sym, env);
            if (geometry != null)
            {
                transformation = this.CreateTransformationFromHDC(hdc, width, height);
                sym.SetupDC((int) hdc, transformation);
                sym.Draw(geometry);
                sym.ResetDC();
            }
            graphics.ReleaseHdc(hdc);
            return image;
        }

        private IGeometry CreateGeometryFromSymbol(ISymbol sym, IEnvelope env)
        {
            try
            {
                if (sym is IMarkerSymbol)
                {
                    IArea area = env as IArea;
                    return area.Centroid;
                }
                if ((sym is ILineSymbol) || (sym is ITextSymbol))
                {
                    IPolyline polyline = new PolylineClass();
                    IPoint point = new PointClass();
                    point.PutCoords(env.LowerLeft.X, (env.LowerLeft.Y + env.UpperRight.Y) / 2.0);
                    polyline.FromPoint = point;
                    point = new PointClass();
                    point.PutCoords(env.UpperRight.X, (env.LowerLeft.Y + env.UpperRight.Y) / 2.0);
                    polyline.ToPoint = point;
                    return polyline;
                }
                if (sym is IFillSymbol)
                {
                    IPolygon polygon = new PolygonClass();
                    IPointCollection points = polygon as IPointCollection;
                    IPoint newPoints = new PointClass();
                    newPoints.PutCoords(env.LowerLeft.X, env.LowerLeft.Y + 1.0);
                    points.AddPoints(1, ref newPoints);
                    newPoints.PutCoords(env.UpperLeft.X, env.UpperLeft.Y);
                    points.AddPoints(1, ref newPoints);
                    newPoints.PutCoords(env.UpperRight.X - 1.0, env.UpperRight.Y);
                    points.AddPoints(1, ref newPoints);
                    newPoints.PutCoords(env.LowerRight.X - 1.0, env.LowerRight.Y + 1.0);
                    points.AddPoints(1, ref newPoints);
                    newPoints.PutCoords(env.LowerLeft.X, env.LowerLeft.Y + 1.0);
                    points.AddPoints(1, ref newPoints);
                    return polygon;
                }
                if (sym is MultiLayerLineSymbol)
                {
                    IPoint point3 = new PointClass();
                    IPolyline polyline2 = new PolylineClass();
                    point3.PutCoords(env.LowerLeft.X, (env.LowerLeft.Y + env.UpperRight.Y) / 2.0);
                    polyline2.FromPoint = point3;
                    point3 = new PointClass();
                    point3.PutCoords(env.UpperRight.X, (env.LowerLeft.Y + env.UpperRight.Y) / 2.0);
                    polyline2.ToPoint = point3;
                    return polyline2;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private unsafe ITransformation CreateTransformationFromHDC(IntPtr HDC, int width, int height)
        {
            try
            {
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(0.0, 0.0, (double) width, (double) height);
                tagRECT grect = new tagRECT();
                grect.left = 0;
                grect.top = 0;
                grect.right = width;
                grect.bottom = height;
                double dpiY = Graphics.FromHdc(HDC).DpiY;
                if (((int) dpiY) == 0)
                {
                    MessageBox.Show("获取失败!");
                    return null;
                }
                IDisplayTransformation transformation = new DisplayTransformationClass();
                transformation.Bounds = envelope;
                transformation.VisibleBounds = envelope;
                transformation.set_DeviceFrame(ref grect);
                transformation.Resolution = dpiY;
                return transformation;
            }
            catch (Exception)
            {
                return null;
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

        private ArrayList GetLayers(IGroupLayer pgl, bool visible)
        {
            ArrayList list = new ArrayList();
            try
            {
                ICompositeLayer layer = pgl as ICompositeLayer;
                if (!visible || pgl.Visible)
                {
                    for (int i = 0; i < layer.Count; i++)
                    {
                        ILayer pLayer = layer.get_Layer(i);
                        if (GISFunFactory.LayerFun.CheckLayerValid(this.mMap, pLayer) || !visible)
                        {
                            if (pLayer is IGroupLayer)
                            {
                                ArrayList layers = this.GetLayers(pLayer as IGroupLayer, visible);
                                for (int j = 0; j < layers.Count; j++)
                                {
                                    list.Add(layers[j]);
                                }
                            }
                            list.Add(pLayer);
                        }
                    }
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public void Hook(object hook, string sEditKind, IFeatureLayer pEditFLayer)
        {
            try
            {
                this.mEditKind = sEditKind;
                this.mEditLayer = pEditFLayer;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                        this.mActiveViewEvents.ViewRefreshed+=(new IActiveViewEvents_ViewRefreshedEventHandler(this.mActiveViewEvents_ViewRefreshed));
                        this.mActiveViewEvents.ItemAdded += (new IActiveViewEvents_ItemAddedEventHandler(this.mActiveViewEvents_ItemAdded));
                        this.mActiveViewEvents.ItemDeleted += (new IActiveViewEvents_ItemDeletedEventHandler(this.mActiveViewEvents_ItemDeleted));
                        this.mActiveViewEvents.AfterItemDraw += (new IActiveViewEvents_AfterItemDrawEventHandler(this.mActiveViewEvents_AfterItemDraw));
                        this.mActiveViewEvents.ContentsChanged += (new IActiveViewEvents_ContentsChangedEventHandler(this.mActiveViewEvents_ContentsChanged));
                        this.mActiveViewEvents.AfterDraw += (new IActiveViewEvents_AfterDrawEventHandler(this.mActiveViewEvents_AfterDraw));
                    }
                    this.InitialValue();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlLegendList", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlLegendList));
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.imageList1 = new ImageList(this.components);
            this.treeList1.BeginInit();
            base.SuspendLayout();
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] { "造林" }, -1, 0, 0, 0);
            this.treeList1.AppendNode(new object[] { "造林地图" }, -1, 0, 0, 2);
            this.treeList1.AppendNode(new object[] { "eee" }, 1, 0, 0, 1);
            this.treeList1.AppendNode(new object[] { "ttt" }, 1, 0, 0, 1);
            object[] nodeData = new object[1];
            this.treeList1.AppendNode(nodeData, 1);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList1.OptionsView.ShowButtons = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RowHeight = 0x18;
            this.treeList1.Size = new Size(200, 300);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 0;
            this.treeList1.TreeLevelWidth = 12;
            this.treeList1.TreeLineStyle = LineStyle.None;
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 0x2b;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "picture_edit.png");
            this.imageList1.Images.SetKeyName(1, "table_multiple.png");
            this.imageList1.Images.SetKeyName(2, "world.png");
            this.imageList1.Images.SetKeyName(3, "world_edit.png");
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.treeList1);
            base.Name = "UserControlLegendList";
            base.Size = new Size(200, 300);
            this.treeList1.EndInit();
            base.ResumeLayout(false);
        }

        private void InitialValue()
        {
            try
            {
                ArrayList mLayerList = this.mLayerList;
                this.mLayerList = new ArrayList();
                this.mMap = this.mHookHelper.FocusMap;
                for (int i = 0; i < this.mMap.LayerCount; i++)
                {
                    ILayer layer = this.mMap.get_Layer(i);
                    if (layer.Visible)
                    {
                        if (layer is IGroupLayer)
                        {
                            ArrayList layers = this.GetLayers(layer as IGroupLayer, true);
                            for (int j = 0; j < layers.Count; j++)
                            {
                                this.mLayerList.Add(layers[j]);
                            }
                        }
                        else
                        {
                            this.mLayerList.Add(layer);
                        }
                    }
                }
                bool flag = false;
                if ((mLayerList != null) && (mLayerList.Count == this.mLayerList.Count))
                {
                    flag = true;
                    for (int k = 0; k < mLayerList.Count; k++)
                    {
                        if ((mLayerList[k] as ILayer).Name != (this.mLayerList[k] as ILayer).Name)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    this.treeList1.Nodes.Clear();
                    this.treeList1.OptionsBehavior.Editable = false;
                    this.treeList1.RowHeight = 0x1a;
                    this.treeList1.OptionsView.ShowRoot = false;
                    this.treeList1.OptionsView.ShowButtons = false;
                    this.treeList1.SelectImageList = null;
                    this.treeList1.StateImageList = this.imageList1;
                    this.treeList1.OptionsView.ShowButtons = true;
                    this.treeList1.TreeLevelWidth = 0x24;
                    this.treeList1.TreeLineStyle = LineStyle.None;
                    this.imageList1.Images.Clear();
                    this.imageList1.ImageSize = new Size(20, 20);
                    IGeoFeatureLayer layer3 = null;
                    IFeatureRenderer renderer = null;
                    IRasterRenderer renderer2 = null;
                    for (int m = 0; m < this.mLayerList.Count; m++)
                    {
                        renderer = null;
                        renderer2 = null;
                        ILayer pLayer = this.mLayerList[m] as ILayer;
                        if (pLayer.Visible && GISFunFactory.LayerFun.CheckLayerValid(this.mMap, pLayer))
                        {
                            int width = 0x10;
                            int height = 0x10;
                            if (pLayer is IFeatureLayer)
                            {
                                IFeatureLayer layer2 = pLayer as IFeatureLayer;
                                if (layer2.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                {
                                    width = 20;
                                    height = 20;
                                }
                                else if (layer2.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                {
                                    width = 20;
                                    height = 20;
                                }
                                else if (layer2.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                {
                                    width = 20;
                                    height = 20;
                                }
                                layer3 = layer2 as IGeoFeatureLayer;
                                renderer = layer3.Renderer;
                            }
                            else if (pLayer is IRasterLayer)
                            {
                                IRasterLayer layer5 = pLayer as IRasterLayer;
                                renderer2 = layer5.Renderer;
                                width = 20;
                                height = 20;
                            }
                            if (renderer is ISimpleRenderer)
                            {
                                ISimpleRenderer renderer3 = renderer as ISimpleRenderer;
                                ISymbol sym = renderer3.Symbol;
                                this.imageList1.Images.Add(this.Convert(sym, width, height));
                                parentNode = this.treeList1.AppendNode(pLayer.Name, node3);
                                parentNode.SetValue(0, pLayer.Name);
                                parentNode.StateImageIndex = this.imageList1.Images.Count - 1;
                            }
                            else if (renderer is IUniqueValueRenderer)
                            {
                                IUniqueValueRenderer renderer4 = renderer as IUniqueValueRenderer;
                                parentNode = this.treeList1.AppendNode(pLayer.Name, node3);
                                parentNode.SetValue(0, pLayer.Name);
                                if (renderer4.UseDefaultSymbol)
                                {
                                    ISymbol defaultSymbol = renderer4.DefaultSymbol;
                                    this.imageList1.Images.Add(this.Convert(defaultSymbol, width, height));
                                    if (renderer4.ValueCount == 0)
                                    {
                                        parentNode.StateImageIndex = this.imageList1.Images.Count - 1;
                                    }
                                    else
                                    {
                                        node = this.treeList1.AppendNode(renderer4.DefaultLabel, parentNode);
                                        node.SetValue(0, renderer4.DefaultLabel);
                                        node.StateImageIndex = this.imageList1.Images.Count - 1;
                                    }
                                }
                                for (int n = 0; n < renderer4.ValueCount; n++)
                                {
                                    ISymbol symbol3 = renderer4.get_Symbol(renderer4.get_Value(n));
                                    if (symbol3 != null)
                                    {
                                        this.imageList1.Images.Add(this.Convert(symbol3, width, height));
                                        node = this.treeList1.AppendNode(renderer4.get_Label(renderer4.get_Value(n)), parentNode);
                                        node.SetValue(0, renderer4.get_Label(renderer4.get_Value(n)));
                                        node.StateImageIndex = this.imageList1.Images.Count - 1;
                                    }
                                }
                                parentNode.ExpandAll();
                            }
                            else if (!(renderer2 is IRasterClassifyColorRampRenderer) && !(renderer2 is IRasterUniqueValueRenderer))
                            {
                                if (renderer2 is IRasterStretchColorRampRenderer)
                                {
                                    IRasterStretchColorRampRenderer renderer5 = renderer2 as IRasterStretchColorRampRenderer;
                                    IColorRamp colorRamp = renderer5.ColorRamp;
                                    IColorRampSymbol symbol4 = new ColorRampSymbolClass();
                                    symbol4.ColorRamp = colorRamp;
                                    IFillSymbol symbol5 = symbol4;
                                    ISymbol symbol6 = symbol5 as ISymbol;
                                    this.imageList1.Images.Add(this.Convert(symbol6, 0x20, 0x20));
                                    parentNode = this.treeList1.AppendNode(pLayer.Name, node3);
                                    parentNode.SetValue(0, pLayer.Name);
                                    parentNode.StateImageIndex = this.imageList1.Images.Count - 1;
                                }
                                else if (!(renderer2 is IRasterDiscreteColorRenderer) && (renderer2 is IRasterRenderer2))
                                {
                                    this.treeList1.AppendNode(pLayer.Name, node3).SetValue(0, pLayer.Name);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.UserControlLegendList", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mActiveViewEvents_AfterDraw(IDisplay Display, esriViewDrawPhase phase)
        {
        }

        private void mActiveViewEvents_AfterItemDraw(short Index, IDisplay Display, esriDrawPhase phase)
        {
            if (base.Visible)
            {
                this.InitialValue();
            }
        }

        private void mActiveViewEvents_ContentsChanged()
        {
            if (base.Visible)
            {
                this.InitialValue();
            }
        }

        private void mActiveViewEvents_ItemAdded(object Item)
        {
            if (base.Visible)
            {
                this.InitialValue();
            }
        }

        private void mActiveViewEvents_ItemDeleted(object Item)
        {
            if (base.Visible)
            {
                this.InitialValue();
            }
        }

        private void mActiveViewEvents_ViewRefreshed(IActiveView view, esriViewDrawPhase phase, object Data, IEnvelope envelope)
        {
            if (base.Visible)
            {
                this.InitialValue();
            }
        }
    }
}

