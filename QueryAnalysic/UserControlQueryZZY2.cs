namespace QueryAnalysic
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
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
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;
    using td.db.mid.sys;
    using System.Collections.Generic;

    /// <summary>
    /// “征占用查询”的工具箱界面
    /// </summary>
    public class UserControlQueryZZY2 : UserControlBase1
    {
        private SimpleButton ButtonFind;
        private IContainer components;
        private DateEdit dateEdit1;
        private DateEdit dateEdit2;
        private GroupControl groupControl1;
        private GroupControl groupControlDist;
        private GroupControl groupControlResult;
        private ImageList imageList1;
        private Label label1;
        private Label label2;
        private Label label31;
        private Label label4;
        public Label labelLocation;
        private IFeatureWorkspace m_EditWorkspace;
        private IFeatureLayer m_pCLayer;
        private IFeatureLayer m_pTLayer;
        private IFeatureLayer m_pVLayer;
        private RibbonPageGroup mapViewTools;
        private IBasicMap mBasicMap;
        private IFeatureLayer mBorderLayer;
        private const string mClassName = "QueryAnalysic.UserControlQueryZZY2";
 
        private IFeature mDisFeature;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private IGroupLayer mGroupLayer;
        private IHookHelper mHookHelper;
        private string mKindCode = "";
        //private DataTable mKindTable;
        private ArrayList mPathList;
     //   private DataTable mProjectTable;
        private IFeatureLayer mQueryLayer;
        private IFeatureLayer mQueryLayer2;
        private bool mSelected;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel2;
        private Panel panel35;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel9;
        private Panel panelbasic;
        private Panel panelDistLocation;
        internal PopupContainerControl PopupContainer;
        internal PopupContainerEdit PopupContainerEdit1;
        private RadioGroup radioGroup1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonMore;
        internal TreeListColumn tcolBase1;
        private TextEdit textName;
        internal TreeList tListDesignKind;
        private TreeList treeList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;

        public UserControlQueryZZY2()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 查询的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            this.DoQuery();
            if (this.treeList.Nodes.Count > 0)
            {
                this.simpleButtonInfo.Enabled = true;
            }
            else
            {
                this.simpleButtonInfo.Enabled = false;
            }
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
                transformation.set_DeviceFrame( ref grect);
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

        private void DoQuery()
        {
            try
            {
                if (this.mQueryLayer != null)
                {
                    double num32;
                    string str = "";
                    string str2 = "(taskkind like '0" + this.mKindCode + "%') ";
                    if (this.PopupContainerEdit1.Text != "")
                    {
                        string str3 = this.PopupContainerEdit1.Tag.ToString();
                        if (str3.Contains("0000"))
                        {
                            str2 = "taskkind like '0" + this.mKindCode + str3.Replace("0000", "") + "%'";
                        }
                        else
                        {
                            str2 = "taskkind like '0" + this.mKindCode + str3 + "'";
                        }
                    }
                    if (this.textName.Text.Trim() != "")
                    {
                        string str4 = "taskname like '%" + this.textName.Text.Trim() + "%'";
                        if (str2 != "")
                        {
                            str2 = str2 + " and " + str4;
                        }
                        else
                        {
                            str2 = str4;
                        }
                    }
                    if ((this.dateEdit1.Text != "") || (this.dateEdit2.Text != ""))
                    {
                        string str5 = "";
                    
                            string str6 = "";
                            string str7 = "";
                            if (this.dateEdit1.Text.Trim() != "")
                            {
                                str6 = DateTime.Parse(this.dateEdit1.Text).ToString("yyyyMMddHHmmss");
                                str5 = "(createtime)>'" + this.dateEdit1.Text + "'";
                            }
                            if (this.dateEdit2.Text.Trim() != "")
                            {
                                str7 = DateTime.Parse(this.dateEdit2.Text).ToString("yyyyMMddHHmmss");
                                if (str5 != "")
                                {
                                    str5 = str5 + " and (edittime)<'" + this.dateEdit2.Text + "'";
                                }
                                else
                                {
                                    str5 = "(edittime)<'" + this.dateEdit2.Text + "'";
                                }
                            }
                        
                        if (str2 != "")
                        {
                            str2 = str2 + " and " + str5;
                        }
                        else
                        {
                            str2 = str5;
                        }
                    }
                    m_projectLst = PM.TaskService.FindBySql(str2);
                    //this.mProjectTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_EditTask_ZT where (" + str2 + ")");
                    for (int i = 0; i < m_projectLst.Count; i++)
                    {
                        if (str == "")
                        {
                            str = "(XMMC='" + m_projectLst[i].tablename + "' and XMBH='" + m_projectLst[i].ID + "')";
                        }
                        else
                        {
                            str = str + " or (XMMC='" + m_projectLst[i].tablename + "' and XMBH='" + m_projectLst[i].ID + "')";
                        }
                    }
                    this.Cursor = Cursors.WaitCursor;
                    IFeatureLayerDefinition mQueryLayer = (IFeatureLayerDefinition) this.mQueryLayer;
                    mQueryLayer.DefinitionExpression = str;
                    if (this.mQueryLayer.Visible && this.mGroupLayer.Visible)
                    {
                        this.mHookHelper.ActiveView.Refresh();
                    }
                    IGeoFeatureLayer layer = null;
                    IFeatureLayer layer2 = null;
                    IFeatureRenderer renderer = null;
                    int width = 0x10;
                    int height = 0x10;
                    if (this.mQueryLayer2 != null)
                    {
                        layer2 = this.mQueryLayer2;
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
                            width = 0x16;
                            height = 20;
                        }
                        layer = layer2 as IGeoFeatureLayer;
                        renderer = layer.Renderer;
                    }
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    this.treeList.Nodes.Clear();
                    if (this.mEditKind == "造林")
                    {
                        this.treeList.Columns[1].Caption = "公顷株数";
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        this.treeList.Columns[1].Caption = "采伐蓄积";
                    }
                    else if (this.mEditKind == "案件")
                    {
                        this.treeList.Columns[2].Caption = "损失林地面积";
                        this.treeList.Columns[1].Caption = "损失林木蓄积";
                    }
                    else if (this.mEditKind == "灾害")
                    {
                        this.treeList.Columns[2].Caption = "成灾面积";
                        this.treeList.Columns[1].Caption = "损失蓄积";
                    }
                    else if (this.mEditKind == "征占用")
                    {
                        this.treeList.Columns[2].Caption = "补偿费用";
                        this.treeList.Columns[1].Caption = "森林蓄积";
                    }
                    this.imageList1.Images.Clear();
                    this.imageList1.ImageSize = new Size(20, 20);
                    if (renderer is ISimpleRenderer)
                    {
                        ISimpleRenderer renderer2 = renderer as ISimpleRenderer;
                        ISymbol sym = renderer2.Symbol;
                        this.imageList1.Images.Add(this.Convert(sym, width, height));
                        node = this.treeList.AppendNode(layer2.Name, parentNode);
                        node.SetValue(0, layer2.Name);
                        node.Visible = false;
                        IFeatureCursor cursor = this.mQueryLayer2.Search(null, false);
                        IFeature feature = cursor.NextFeature();
                        int num4 = 0;
                        double num5 = 0.0;
                        double num6 = 0.0;
                        while (feature != null)
                        {
                            num4++;
                            if (this.mEditKind == "采伐")
                            {
                                int index = feature.Fields.FindField("MIAN_JI");
                                if (feature.get_Value(index).ToString() != "")
                                {
                                    num5 += double.Parse(feature.get_Value(index).ToString());
                                }
                                int num8 = feature.Fields.FindField("CFXJ");
                                if (feature.get_Value(num8).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num8).ToString());
                                }
                            }
                            else if (this.mEditKind == "造林")
                            {
                                int num9 = feature.Fields.FindField("MIAN_JI");
                                if (feature.get_Value(num9).ToString() != "")
                                {
                                    num5 += double.Parse(feature.get_Value(num9).ToString());
                                }
                                int num10 = feature.Fields.FindField("MEI_GQ_ZS");
                                if (feature.get_Value(num10).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num10).ToString());
                                }
                            }
                            else if (this.mEditKind == "案件")
                            {
                                int num11 = feature.Fields.FindField("SSLDMJ");
                                if (feature.get_Value(num11).ToString() != "")
                                {
                                    num5 += double.Parse(feature.get_Value(num11).ToString());
                                }
                                int num12 = feature.Fields.FindField("SSLMXJ");
                                if (feature.get_Value(num12).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num12).ToString());
                                }
                            }
                            else if (this.mEditKind == "灾害")
                            {
                                int num13 = feature.Fields.FindField("ZHMJ");
                                if (feature.get_Value(num13).ToString() != "")
                                {
                                    num5 += double.Parse(feature.get_Value(num13).ToString());
                                }
                                int num14 = feature.Fields.FindField("SUNSHIXJ");
                                if (feature.get_Value(num14).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num14).ToString());
                                }
                            }
                            else if (this.mEditKind == "征占用")
                            {
                                int num15 = feature.Fields.FindField("ZFYHJ");
                                if (feature.get_Value(num15).ToString() != "")
                                {
                                    num5 += double.Parse(feature.get_Value(num15).ToString());
                                }
                                int num16 = feature.Fields.FindField("SLXJ");
                                if (feature.get_Value(num16).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num16).ToString());
                                }
                            }
                            feature = cursor.NextFeature();
                        }
                        string val = "";
                        string str9 = "";
                        if ((num6 == 0.0) && (node.GetDisplayText(1).ToString().Trim() == ""))
                        {
                            val = "";
                        }
                        else if ((node.GetDisplayText(1).ToString().Trim() == "") && (num6 != 0.0))
                        {
                            val = num6.ToString();
                        }
                        else if ((node.GetDisplayText(1).ToString().Trim() != "") && (num6 == 0.0))
                        {
                            val = node.GetDisplayText(1).ToString().Trim();
                        }
                        else
                        {
                            num32 = double.Parse(node.GetDisplayText(1).ToString().Trim()) + num6;
                            val = num32.ToString();
                        }
                        if ((num5 == 0.0) && (node.GetDisplayText(2).ToString().Trim() == ""))
                        {
                            str9 = "";
                        }
                        else if ((node.GetDisplayText(2).ToString().Trim() == "") && (num5 != 0.0))
                        {
                            str9 = num5.ToString();
                        }
                        else if ((node.GetDisplayText(2).ToString().Trim() != "") && (num5 == 0.0))
                        {
                            str9 = node.GetDisplayText(2).ToString().Trim();
                        }
                        else
                        {
                            num32 = double.Parse(node.GetDisplayText(2).ToString().Trim()) + num5;
                            str9 = num32.ToString();
                        }
                        node.SetValue(1, val);
                        node.SetValue(2, str9);
                        if ((node.GetValue(1).ToString() == "") && (node.GetValue(2).ToString() == ""))
                        {
                            node.Visible = false;
                        }
                        else
                        {
                            node.Visible = true;
                        }
                        node.StateImageIndex = this.imageList1.Images.Count - 1;
                    }
                    else if (renderer is IUniqueValueRenderer)
                    {
                        IUniqueValueRenderer renderer3 = renderer as IUniqueValueRenderer;
                        for (int j = 0; j < renderer3.ValueCount; j++)
                        {
                            ISymbol symbol2 = renderer3.get_Symbol(renderer3.get_Value(j));
                            this.imageList1.Images.Add(this.Convert(symbol2, width, height));
                            if ((node == null) || (renderer3.get_Label(renderer3.get_Value(j)).ToString() != node.GetValue(0).ToString()))
                            {
                                node = this.treeList.AppendNode(renderer3.get_Label(renderer3.get_Value(j)), parentNode);
                                node.SetValue(0, renderer3.get_Label(renderer3.get_Value(j)));
                                node.SetValue(1, 0);
                                node.SetValue(2, 0);
                                node.StateImageIndex = this.imageList1.Images.Count - 1;
                            }
                            IQueryFilter filter = new QueryFilterClass();
                            string[] strArray = renderer3.get_Value(j).Split(new char[] { ';' });
                            string str10 = renderer3.get_Field(0) + "='" + strArray[0] + "'";
                            for (int k = 1; k < strArray.Length; k++)
                            {
                                str10 = str10 + " or " + renderer3.get_Field(0) + "='" + strArray[k] + "'";
                            }
                            if (str != "")
                            {
                                filter.WhereClause = "(" + str10 + ") and (" + str + ")";
                            }
                            else
                            {
                                filter.WhereClause = str10;
                            }
                            IFeatureCursor cursor2 = this.mQueryLayer2.FeatureClass.Search(filter, true);
                            IFeature feature2 = cursor2.NextFeature();
                            int num19 = 0;
                            double num20 = 0.0;
                            double num21 = 0.0;
                            while (feature2 != null)
                            {
                                num19++;
                                if (this.mEditKind == "采伐")
                                {
                                    int num22 = feature2.Fields.FindField("MIAN_JI");
                                    if (feature2.get_Value(num22).ToString() != "")
                                    {
                                        num20 += double.Parse(feature2.get_Value(num22).ToString());
                                    }
                                    int num23 = feature2.Fields.FindField("CFXJ");
                                    if (feature2.get_Value(num23).ToString() != "")
                                    {
                                        num21 += double.Parse(feature2.get_Value(num23).ToString());
                                    }
                                }
                                else if (this.mEditKind == "造林")
                                {
                                    int num24 = feature2.Fields.FindField("MIAN_JI");
                                    if (feature2.get_Value(num24).ToString() != "")
                                    {
                                        num20 += double.Parse(feature2.get_Value(num24).ToString());
                                    }
                                    int num25 = feature2.Fields.FindField("MEI_GQ_ZS");
                                    if (feature2.get_Value(num25).ToString() != "")
                                    {
                                        num21 += double.Parse(feature2.get_Value(num25).ToString());
                                    }
                                }
                                else if (this.mEditKind == "案件")
                                {
                                    int num26 = feature2.Fields.FindField("SSLDMJ");
                                    if (feature2.get_Value(num26).ToString() != "")
                                    {
                                        num20 += double.Parse(feature2.get_Value(num26).ToString());
                                    }
                                    int num27 = feature2.Fields.FindField("SSLMXJ");
                                    if (feature2.get_Value(num27).ToString() != "")
                                    {
                                        num21 += double.Parse(feature2.get_Value(num27).ToString());
                                    }
                                }
                                else if (this.mEditKind == "灾害")
                                {
                                    int num28 = feature2.Fields.FindField("ZHMJ");
                                    if (feature2.get_Value(num28).ToString() != "")
                                    {
                                        num20 += double.Parse(feature2.get_Value(num28).ToString());
                                    }
                                    int num29 = feature2.Fields.FindField("SUNSHIXJ");
                                    if (feature2.get_Value(num29).ToString() != "")
                                    {
                                        num21 += double.Parse(feature2.get_Value(num29).ToString());
                                    }
                                }
                                else if (this.mEditKind == "征占用")
                                {
                                    int num30 = feature2.Fields.FindField("ZFYHJ");
                                    if (feature2.get_Value(num30).ToString() != "")
                                    {
                                        num20 += double.Parse(feature2.get_Value(num30).ToString());
                                    }
                                    int num31 = feature2.Fields.FindField("SLXJ");
                                    if (feature2.get_Value(num31).ToString() != "")
                                    {
                                        num21 += double.Parse(feature2.get_Value(num31).ToString());
                                    }
                                }
                                feature2 = cursor2.NextFeature();
                            }
                            string str11 = "";
                            string str12 = "";
                            if (node.GetDisplayText(1).ToString().Trim() == "0")
                            {
                                node.SetValue(1, "");
                            }
                            if (node.GetDisplayText(2).ToString().Trim() == "0")
                            {
                                node.SetValue(2, "");
                            }
                            if ((num21 == 0.0) && (node.GetDisplayText(1).ToString().Trim() == ""))
                            {
                                str11 = "";
                            }
                            else if ((node.GetDisplayText(1).ToString().Trim() == "") && (num21 != 0.0))
                            {
                                str11 = num21.ToString();
                            }
                            else if ((node.GetDisplayText(1).ToString().Trim() != "") && (num21 == 0.0))
                            {
                                str11 = node.GetDisplayText(1).ToString().Trim();
                            }
                            else
                            {
                                num32 = double.Parse(node.GetDisplayText(1).ToString().Trim()) + num21;
                                str11 = num32.ToString();
                            }
                            if ((num20 == 0.0) && (node.GetDisplayText(2).ToString().Trim() == ""))
                            {
                                str12 = "";
                            }
                            else if ((node.GetDisplayText(2).ToString().Trim() == "") && (num20 != 0.0))
                            {
                                str12 = num20.ToString();
                            }
                            else if ((node.GetDisplayText(2).ToString().Trim() != "") && (num20 == 0.0))
                            {
                                str12 = node.GetDisplayText(2).ToString().Trim();
                            }
                            else
                            {
                                str12 = (double.Parse(node.GetDisplayText(2).ToString().Trim()) + num20).ToString();
                            }
                            node.SetValue(1, str11);
                            node.SetValue(2, str12);
                            if ((node.GetValue(1).ToString() == "") && (node.GetValue(2).ToString() == ""))
                            {
                                node.Visible = false;
                            }
                            else
                            {
                                node.Visible = true;
                            }
                        }
                        if (renderer3.UseDefaultSymbol)
                        {
                            ISymbol defaultSymbol = renderer3.DefaultSymbol;
                            this.imageList1.Images.Add(this.Convert(defaultSymbol, width, height));
                            if (renderer3.ValueCount == 0)
                            {
                                node = this.treeList.AppendNode(layer2.Name, parentNode);
                                node.SetValue(0, layer2.Name);
                                node.StateImageIndex = this.imageList1.Images.Count - 1;
                            }
                            else
                            {
                                string nodeData = "";
                                if (renderer3.DefaultLabel == "")
                                {
                                    nodeData = "其它";
                                }
                                else
                                {
                                    nodeData = renderer3.DefaultLabel;
                                }
                                node = this.treeList.AppendNode(nodeData, parentNode);
                                node.SetValue(0, nodeData);
                                node.StateImageIndex = this.imageList1.Images.Count - 1;
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "DoQuery", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControls()
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TypeLayer").Split(new char[] { ',' });
                string sLayerName = this.mEditKind + "专题";
                this.mGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                if (this.mGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, sLayerName);
                    this.mGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                }
                this.mBorderLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, strArray[0], true) as IFeatureLayer;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                string str4 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                string str5 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, str4, true);
                this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, str5, true);
                this.radioGroup1.Properties.Items.Clear();
                for (int i = 1; i < strArray.Length; i++)
                {
                    string description = strArray[i].Replace(this.mEditKind + "_", "");
                    RadioGroupItem item = new RadioGroupItem(null, description);
                    this.radioGroup1.Properties.Items.Add(item);
                }
                if (this.radioGroup1.Properties.Items.Count > 0)
                {
                    this.radioGroup1.SelectedIndex = 0;
                }
                if (this.radioGroup1.SelectedIndex > -1)
                {
                    this.ButtonFind.Enabled = true;
                }
                string str = strArray[this.radioGroup1.SelectedIndex + 1];
                this.mQueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, str, true) as IFeatureLayer;
                this.mQueryLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, str + "2", true) as IFeatureLayer;
                if (this.mQueryLayer2 == null)
                {
                    this.mQueryLayer2 = this.mQueryLayer;
                }
                if (this.mQueryLayer != null)
                {
                    this.ButtonFind.Enabled = true;
                }
                else
                {
                    this.ButtonFind.Enabled = false;
                }
                this.treeList.Nodes.Clear();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryZZY2));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textName = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PopupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.PopupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this.tListDesignKind = new DevExpress.XtraTreeList.TreeList();
            this.tcolBase1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelbasic.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).BeginInit();
            this.PopupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.treeList);
            this.groupControl1.Controls.Add(this.panel5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(6, 269);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl1.Size = new System.Drawing.Size(246, 325);
            this.groupControl1.TabIndex = 116;
            this.groupControl1.Text = "查询结果";
            // 
            // treeList
            // 
            this.treeList.Appearance.FocusedCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.treeList.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.PaleTurquoise;
            this.treeList.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
            this.treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Yellow;
            this.treeList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(8, 28);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowRoot = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit3,
            this.repositoryItemImageEdit1});
            this.treeList.Size = new System.Drawing.Size(230, 257);
            this.treeList.StateImageList = this.imageList1;
            this.treeList.TabIndex = 99;
            this.treeList.TreeLevelWidth = 12;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "name";
            this.treeListColumn1.MinWidth = 37;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 105;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "小班数";
            this.treeListColumn2.FieldName = "value";
            this.treeListColumn2.ImageIndex = 17;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 2;
            this.treeListColumn2.Width = 66;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "面积";
            this.treeListColumn3.FieldName = "面积";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            this.treeListColumn3.Width = 67;
            // 
            // repositoryItemPopupContainerEdit3
            // 
            this.repositoryItemPopupContainerEdit3.AutoHeight = false;
            this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.Appearance.Image")));
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit1.ShowIcon = false;
            this.repositoryItemImageEdit1.ShowMenu = false;
            this.repositoryItemImageEdit1.ShowPopupShadow = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "color_swatch - 副本.png");
            this.imageList1.Images.SetKeyName(1, "color_wheel.png");
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.simpleButtonInfo);
            this.panel5.Controls.Add(this.simpleButtonBack);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(8, 285);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(230, 32);
            this.panel5.TabIndex = 101;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonInfo.Image")));
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(98, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonInfo.TabIndex = 13;
            this.simpleButtonInfo.Text = "查看";
            this.simpleButtonInfo.ToolTip = "查看详细信息";
            this.simpleButtonInfo.Click += new System.EventHandler(this.simpleButtonInfo_Click);
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.Image")));
            this.simpleButtonBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonBack.Location = new System.Drawing.Point(164, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回设置条件";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.simpleButtonMore);
            this.panel2.Controls.Add(this.ButtonFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 231);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel2.Size = new System.Drawing.Size(246, 38);
            this.panel2.TabIndex = 115;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(48, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(66, 26);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "重置";
            this.simpleButton2.ToolTip = "重新设置查询条件";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMore.Image")));
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(114, 6);
            this.simpleButtonMore.Name = "simpleButtonMore";
            this.simpleButtonMore.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonMore.TabIndex = 13;
            this.simpleButtonMore.Tag = "基本";
            this.simpleButtonMore.Text = "更多";
            this.simpleButtonMore.ToolTip = "更多查询条件";
            this.simpleButtonMore.Visible = false;
            this.simpleButtonMore.Click += new System.EventHandler(this.simpleButtonMore_Click);
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Enabled = false;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(180, 6);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(66, 26);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查询";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.radioGroup1);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlResult.Location = new System.Drawing.Point(6, 151);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(6);
            this.groupControlResult.Size = new System.Drawing.Size(246, 80);
            this.groupControlResult.TabIndex = 112;
            this.groupControlResult.Text = "查询类型";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(8, 28);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "地类"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林种"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "树种"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐类型"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "变更来源")});
            this.radioGroup1.Size = new System.Drawing.Size(230, 44);
            this.radioGroup1.TabIndex = 102;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(6, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 8);
            this.panel1.TabIndex = 114;
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelbasic);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(6, 26);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.groupControlDist.Size = new System.Drawing.Size(246, 117);
            this.groupControlDist.TabIndex = 111;
            this.groupControlDist.Text = "查询范围";
            // 
            // panelbasic
            // 
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbasic.Location = new System.Drawing.Point(8, 22);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(230, 93);
            this.panelbasic.TabIndex = 18;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(68, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(162, 92);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel35);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.textName);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Controls.Add(this.PopupContainerEdit1);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(162, 92);
            this.panel10.TabIndex = 14;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.dateEdit2);
            this.panel35.Controls.Add(this.label31);
            this.panel35.Controls.Add(this.dateEdit1);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 63);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(162, 23);
            this.panel35.TabIndex = 26;
            // 
            // dateEdit2
            // 
            this.dateEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(92, 0);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(70, 20);
            this.dateEdit2.TabIndex = 24;
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.label31.Location = new System.Drawing.Point(80, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(12, 23);
            this.label31.TabIndex = 23;
            this.label31.Text = "-";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateEdit1
            // 
            this.dateEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(0, 0);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(80, 20);
            this.dateEdit1.TabIndex = 22;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 56);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.panel6.Size = new System.Drawing.Size(162, 7);
            this.panel6.TabIndex = 119;
            // 
            // textName
            // 
            this.textName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textName.Location = new System.Drawing.Point(0, 36);
            this.textName.Name = "textName";
            this.textName.Properties.LookAndFeel.SkinName = "Blue";
            this.textName.Size = new System.Drawing.Size(162, 20);
            this.textName.TabIndex = 101;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 29);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.panel4.Size = new System.Drawing.Size(162, 7);
            this.panel4.TabIndex = 120;
            // 
            // PopupContainerEdit1
            // 
            this.PopupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PopupContainerEdit1.EditValue = "";
            this.PopupContainerEdit1.Location = new System.Drawing.Point(0, 7);
            this.PopupContainerEdit1.Name = "PopupContainerEdit1";
            this.PopupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.PopupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.PopupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("PopupContainerEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.PopupContainerEdit1.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.PopupContainerEdit1.Properties.PopupControl = this.PopupContainer;
            this.PopupContainerEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.PopupContainerEdit1.Properties.ShowPopupShadow = false;
            this.PopupContainerEdit1.Size = new System.Drawing.Size(162, 22);
            this.PopupContainerEdit1.TabIndex = 117;
            this.PopupContainerEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.PopupContainerEdit1_ButtonPressed);
            // 
            // PopupContainer
            // 
            this.PopupContainer.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PopupContainer.Appearance.Options.UseBackColor = true;
            this.PopupContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PopupContainer.Controls.Add(this.tListDesignKind);
            this.PopupContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PopupContainer.Location = new System.Drawing.Point(91, 318);
            this.PopupContainer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.PopupContainer.Name = "PopupContainer";
            this.PopupContainer.Padding = new System.Windows.Forms.Padding(1);
            this.PopupContainer.Size = new System.Drawing.Size(170, 166);
            this.PopupContainer.TabIndex = 118;
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
            this.tListDesignKind.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDesignKind.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDesignKind.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.tListDesignKind.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.LightCyan;
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
            this.tListDesignKind.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
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
            this.tcolBase1});
            this.tListDesignKind.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDesignKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDesignKind.Location = new System.Drawing.Point(3, 3);
            this.tListDesignKind.LookAndFeel.SkinName = "Blue";
            this.tListDesignKind.Name = "tListDesignKind";
            this.tListDesignKind.OptionsBehavior.Editable = false;
            this.tListDesignKind.OptionsView.ShowColumns = false;
            this.tListDesignKind.OptionsView.ShowHorzLines = false;
            this.tListDesignKind.OptionsView.ShowIndicator = false;
            this.tListDesignKind.OptionsView.ShowVertLines = false;
            this.tListDesignKind.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.tListDesignKind.Size = new System.Drawing.Size(164, 160);
            this.tListDesignKind.TabIndex = 78;
            this.tListDesignKind.TreeLevelWidth = 12;
            this.tListDesignKind.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDesignKind.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tListDesignKind_FocusedNodeChanged);
            this.tListDesignKind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tListDesignKind_MouseUp);
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
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(162, 7);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel9.Size = new System.Drawing.Size(68, 92);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "创建时间 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 100;
            this.label2.Text = "项目名称:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 26);
            this.label4.TabIndex = 101;
            this.label4.Text = "项目类型:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(6, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(246, 26);
            this.labelLocation.TabIndex = 113;
            this.labelLocation.Text = "      征占用类型查询          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlQueryZZY2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.PopupContainer);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControlResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlQueryZZY2";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.Size = new System.Drawing.Size(258, 600);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelbasic.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupContainer)).EndInit();
            this.PopupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public ProjectManager PM
        {
            get
            {
                return DBServiceFactory<ProjectManager>.Service;
            }
        }
        private void InitialKindList()
        {
            try
            {
                if (this.m_kindCodeLst != null)
                {
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    TreeListNode node4 = null;
                    try
                    {
                        this.tListDesignKind.Nodes.Clear();
                    }
                    catch (Exception)
                    {
                    }
                    this.tListDesignKind.OptionsView.ShowRoot = true;
                    this.tListDesignKind.SelectImageList = null;
                    this.tListDesignKind.OptionsView.ShowButtons = true;
                    this.tListDesignKind.TreeLineStyle = LineStyle.None;
                    this.tListDesignKind.RowHeight = 20;
                    this.tListDesignKind.OptionsBehavior.AutoPopulateColumns = true;
                    
                   // DataTable dataTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '%0000' and kind='" + this.mKindCode + "') ");
                    string str = "";
                    if (this.tListDesignKind.Nodes.Count == 0)
                    {
                        node3 = this.tListDesignKind.AppendNode("", node4);
                    }
                    for (int i = 0; i < m_kindCodeLst.Count; i++)
                    {
                        this.mSelected = true;
                        try
                        {
                            node3 = this.tListDesignKind.AppendNode(m_kindCodeLst[i].name, node4);
                        }
                        catch (Exception)
                        {
                            node3 = this.tListDesignKind.AppendNode(m_kindCodeLst[i].name, node4);
                        }
                        node3.SetValue(0, m_kindCodeLst[i].name);
                        node3.Tag = m_kindCodeLst[i].code;
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = 0;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                    //    str = dataTable.Rows[i]["code"].ToString().Substring(0, 2);
                     //   DataTable table2 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '" + str + "%' and right(code ,4 )<>'0000' and right(code ,2 )='00' and kind='" + this.mKindCode + "')");
                        string str2 = "";
                        IList<T_DESIGNKIND_Mid> secondLst = m_kindCodeLst[i].SubList;
                        for (int j = 0; j < secondLst.Count; j++)
                        {
                            parentNode = this.tListDesignKind.AppendNode(secondLst[j].name, node3);
                            parentNode.ImageIndex = -1;
                            parentNode.StateImageIndex = 0;
                            parentNode.SelectImageIndex = -1;
                            parentNode.SetValue(0, secondLst[j].name);
                            parentNode.Tag = secondLst[j].code;
                            parentNode.Expanded = false;
                           // str2 = table2.Rows[j]["code"].ToString().Substring(0, 4);
                        //    DataTable table3 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where (code like '" + str2 + "%' and right(code ,4 )<>'0000' and right(code ,2 )<>'00' and kind='" + this.mKindCode + "')");
                            IList<T_DESIGNKIND_Mid> thirdLst = secondLst[j].SubList;
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
                        this.tListDesignKind.Selection.Clear();
                        this.tListDesignKind.Refresh();
                        this.tListDesignKind.OptionsSelection.Reset();
                        this.mSelected = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "InitialKindList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
        private IList<T_DESIGNKIND_Mid> m_kindCodeLst;
        private IList<T_EDITTASK_ZT_Mid> m_projectLst;
        public void InitialValue(object hook, string sEditKind, string sEditKind2)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                this.mEditKind = sEditKind;
                this.mEditKind2 = sEditKind2;
      
                this.mKindCode = "4";
                m_kindCodeLst = PM.FindTreeByKindCode(mKindCode);
                m_projectLst = PM.FindByKindCode(mKindCode);
               // this.mKindTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where kind='" + this.mKindCode + "'");
              //  this.mProjectTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_EditTask_ZT where (taskkind like '0" + this.mKindCode + "%') ");
                this.InitialKindList();
                this.InitialControls();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void PopupContainerEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            this.PopupContainerEdit1.Properties.PopupControl = this.PopupContainer;
        }

        /// <summary>
        /// radioGroup选择按钮改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioGroup1.SelectedIndex != -1)
                {
                    string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TypeLayer").Split(new char[] { ',' })[this.radioGroup1.SelectedIndex + 1];
                    this.mQueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, sLayerName, true) as IFeatureLayer;
                    this.mQueryLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, sLayerName + "2", true) as IFeatureLayer;
                    if (this.mQueryLayer2 == null)
                    {
                        this.mQueryLayer2 = this.mQueryLayer;
                    }
                    if (this.mQueryLayer != null)
                    {
                        this.ButtonFind.Enabled = true;
                    }
                    else
                    {
                        this.ButtonFind.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "radioGroup1_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.mGroupLayer.Visible = true;
                ICompositeLayer mGroupLayer = this.mGroupLayer as ICompositeLayer;
                for (int i = 0; i < mGroupLayer.Count; i++)
                {
                    ILayer layer2 = mGroupLayer.get_Layer(i);
                    if ((layer2.Name != this.mBorderLayer.Name) && (layer2.Name != this.mQueryLayer.Name))
                    {
                        layer2.Visible = false;
                    }
                }
                this.mQueryLayer.Visible = true;
                IEnvelope envelope = null;
                if (this.mDisFeature != null)
                {
                    envelope = this.mDisFeature.Shape.Envelope;
                }
                if (envelope == null)
                {
                    envelope = this.mQueryLayer.AreaOfInterest.Envelope;
                }
                envelope.Expand(1.1, 1.1, true);
                this.mHookHelper.ActiveView.Extent = envelope;
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryZZY2", "simpleButtonInfo_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonMore_Click(object sender, EventArgs e)
        {
        }

        private void tListDesignKind_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                this.PopupContainerEdit1.Text = e.Node.GetDisplayText(0);
                this.PopupContainerEdit1.Tag = e.Node.Tag;
                this.PopupContainerEdit1.Refresh();
            }
        }

        private void tListDesignKind_MouseUp(object sender, MouseEventArgs e)
        {
            this.PopupContainerEdit1.ClosePopup();
            this.Refresh();
        }
    }
}

