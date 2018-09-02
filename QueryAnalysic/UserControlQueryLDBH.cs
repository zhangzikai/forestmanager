namespace QueryAnalysic
{
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
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// “林地查询”的工具箱界面
    /// </summary>
    public class UserControlQueryLDBH : UserControlBase1
    {
        private SimpleButton ButtonFind;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private IContainer components;
        private GroupControl groupControl1;
        private GroupControl groupControlDist;
        private GroupControl groupControlResult;
        private ImageList imageList1;
        private Label label7;
        private Label label8;
        private Label label9;
        public Label labelLocation;
        private IFeatureWorkspace m_EditWorkspace;
        private IFeatureLayer m_pCLayer;
        private IFeatureLayer m_pTLayer;
        private IFeatureLayer m_pVLayer;
        private RibbonPageGroup mapViewTools;
        private IBasicMap mBasicMap;
        private const string mClassName = "QueryAnalysic.UserControlQueryLDBH";
        private IFeature mDisFeature;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IGroupLayer mGroupLayer;
        private IHookHelper mHookHelper;
        private ArrayList mPathList;
        private IFeatureLayer mQueryLayer;
        private IFeatureLayer mQueryLayer2;
        private bool mSelected;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IFeatureLayer mXBLayer;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel14;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel8;
        private Panel panel9;
        private Panel panelbasic;
        private Panel panelDistLocation;
        private RadioGroup radioGroup1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonMore;
        private TreeList treeList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;

        public UserControlQueryLDBH()
        {
            this.InitializeComponent();
        }

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

        /// <summary>
        /// “县、乡、村”文本改变响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxBase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEdit edit = sender as ComboBoxEdit;
                DataTable table = (edit.Tag as ArrayList)[0] as DataTable;
                DataRow[] rowArray = null;
                if ((edit.Tag as ArrayList).Count > 1)
                {
                    rowArray = (edit.Tag as ArrayList)[1] as DataRow[];
                }
                if (edit.Name.Contains("County"))
                {
                    this.comboBoxTown.Properties.Items.Clear();
                    this.comboBoxTown.Properties.Items.Add("--");
                    this.comboBoxTown.Text = "--";
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Add("--");
                    this.comboBoxVillage.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        ArrayList tag = this.comboBoxTown.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxTown);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxTown);
                        }
                    }
                }
                else if (edit.Name.Contains("Town"))
                {
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Add("--");
                    this.comboBoxVillage.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        ArrayList list2 = this.comboBoxVillage.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), list2[0] as DataTable, this.comboBoxVillage);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), list2[0] as DataTable, this.comboBoxVillage);
                        }
                    }
                }
                else
                {
                    edit.Name.Contains("Village");
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "comboBoxBase_TextChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                sym.SetupDC((int)hdc, transformation);
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
                envelope.PutCoords(0.0, 0.0, (double)width, (double)height);
                tagRECT grect = new tagRECT();
                grect.left = 0;
                grect.top = 0;
                grect.right = width;
                grect.bottom = height;
                double dpiY = Graphics.FromHdc(HDC).DpiY;
                if (((int)dpiY) == 0)
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

        private void DoQuery()
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBTypeLayer2").Split(new char[] { ',' });
                if (this.mGroupLayer != null)
                {
                    bool flag = false;
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        if (strArray[i].Contains(this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Description))
                        {
                            this.mQueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, strArray[i], true) as IFeatureLayer;
                            this.mQueryLayer.FeatureClass = this.mXBLayer.FeatureClass;
                            this.mQueryLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGroupLayer, strArray[i] + "2", true) as IFeatureLayer;
                            if (this.mQueryLayer2 == null)
                            {
                                this.mQueryLayer2 = this.mQueryLayer;
                            }
                            flag = true;
                            break;
                        }
                    }
                    if (flag && (this.mQueryLayer != null))
                    {
                        string str2 = "";
                        string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                        ArrayList tag = null;
                        DataRow[] rowArray = null;
                        IQueryFilter queryFilter = new QueryFilterClass();
                        IFeatureCursor cursor = null;
                        this.mDisFeature = null;
                        if (this.comboBoxVillage.SelectedIndex >= 1)
                        {
                            tag = this.comboBoxVillage.Tag as ArrayList;
                            rowArray = tag[1] as DataRow[];
                            str2 = string.Concat(new object[] { strArray2[2], "='", rowArray[this.comboBoxVillage.SelectedIndex - 1][0], "'" });
                            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                            queryFilter.WhereClause = string.Concat(new object[] { configValue, "='", rowArray[this.comboBoxVillage.SelectedIndex - 1][0], "'" });
                            cursor = this.m_pVLayer.Search(queryFilter, false);
                            this.mDisFeature = cursor.NextFeature();
                        }
                        else if (this.comboBoxTown.SelectedIndex >= 1)
                        {
                            tag = this.comboBoxTown.Tag as ArrayList;
                            if (tag.Count == 1)
                            {
                                rowArray = (tag[0] as DataTable).Select("");
                            }
                            else
                            {
                                rowArray = tag[1] as DataRow[];
                            }
                            str2 = string.Concat(new object[] { strArray2[1], "='", rowArray[this.comboBoxTown.SelectedIndex - 1][0], "'" });
                            string str5 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                            queryFilter.WhereClause = string.Concat(new object[] { str5, "='", rowArray[this.comboBoxTown.SelectedIndex - 1][0], "'" });
                            cursor = this.m_pTLayer.Search(queryFilter, false);
                            this.mDisFeature = cursor.NextFeature();
                        }
                        else if (this.comboBoxCounty.SelectedIndex >= 1)
                        {
                            tag = this.comboBoxCounty.Tag as ArrayList;
                            if (tag.Count == 1)
                            {
                                rowArray = (tag[0] as DataTable).Select("");
                            }
                            else
                            {
                                rowArray = tag[1] as DataRow[];
                            }
                            str2 = string.Concat(new object[] { strArray2[0], "='", rowArray[this.comboBoxCounty.SelectedIndex - 1][0], "'" });
                            string str6 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                            queryFilter.WhereClause = string.Concat(new object[] { str6, "='", rowArray[this.comboBoxCounty.SelectedIndex - 1][0], "'" });
                            this.mDisFeature = this.m_pCLayer.Search(queryFilter, false).NextFeature();
                        }
                        this.Cursor = Cursors.WaitCursor;
                        ///IFeatureLayerDefinition接口提供对从底层要素类定义特征子集的成员的访问。使用此接口在图层上设置定义查询，只显示符合指定条件的特征。使用DefinitionExpression访问定义查询。
                        //此外，您可以使用CreateSelectionLayer根据现有FeatureLayer的所选功能创建新的FeatureLayer。在ArcMap用户文档和界面中，这个新层被称为选择层。
                        //您可以使用RelationshipClass访问关系类（如果存在），该关系类定义了层和连接到它的表之间的关系。可以通过IDisplayRelationshipClass :: RelationshipClass访问同一个对象。 IDisplayRelationshipClass可以更方便，因为它具有多个加法方法和属性来处理图层连接。
                        IFeatureLayerDefinition mQueryLayer = (IFeatureLayerDefinition)this.mQueryLayer;
                        if (this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Description == "林地分布")
                        {
                            if (str2 != "")
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" < '900' and " + str2;
                            }
                            else
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" < '900'";
                            }
                        }
                        else if (this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Description == "林地变更")
                        {
                            if (str2 != "")
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>'' and " + str2;
                            }
                            else
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>''";
                            }
                        }
                        else if (this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Description == "新增林地")
                        {
                            if (str2 != "")
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>'' and \"DI_LEI\" < '900' and \"Q_DI_LEI\" >='900' and " + str2;
                            }
                            else
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>'' and \"DI_LEI\" < '900' and \"Q_DI_LEI\" >='900'";
                            }
                        }
                        else if (this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Description == "流失林地")
                        {
                            if (str2 != "")
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>'' and \"Q_DI_LEI\" < '900' and \"DI_LEI\" >='900' and " + str2;
                            }
                            else
                            {
                                mQueryLayer.DefinitionExpression = "\"DI_LEI\" <> \"Q_DI_LEI\" and \"Q_DI_LEI\"<>'' and \"Q_DI_LEI\" < '900' and \"DI_LEI\" >='900'";
                            }
                        }
                        else
                        {
                            mQueryLayer.DefinitionExpression = str2;
                        }
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
                        this.imageList1.Images.Clear();
                        this.imageList1.ImageSize = new Size(20, 20);
                        Application.DoEvents();
                        if (renderer is ISimpleRenderer)
                        {
                            ISimpleRenderer renderer2 = renderer as ISimpleRenderer;
                            ISymbol sym = renderer2.Symbol;
                            this.imageList1.Images.Add(this.Convert(sym, width, height));
                            node = this.treeList.AppendNode(layer2.Name, parentNode);
                            node.SetValue(0, layer2.Name);
                            IFeatureCursor cursor2 = this.mQueryLayer2.Search(null, false);
                            IFeature feature = cursor2.NextFeature();
                            int num4 = 0;
                            double val = 0.0;
                            double num6 = 0.0;
                            while (feature != null)
                            {
                                num4++;
                                int index = feature.Fields.FindField("MIAN_JI");
                                if (feature.get_Value(index).ToString() != "")
                                {
                                    val += double.Parse(feature.get_Value(index).ToString());
                                }
                                index = feature.Fields.FindField("ZXJ");
                                if (feature.get_Value(index).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(index).ToString());
                                }
                                Application.DoEvents();
                                feature = cursor2.NextFeature();
                            }
                            node.SetValue(1, num6);
                            node.SetValue(2, val);
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
                                string[] strArray3 = renderer3.get_Value(j).Split(new char[] { ';' });
                                string str7 = renderer3.get_Field(0) + "='" + strArray3[0] + "'";
                                for (int k = 1; k < strArray3.Length; k++)
                                {
                                    str7 = str7 + " or " + renderer3.get_Field(0) + "='" + strArray3[k] + "'";
                                }
                                if (str2 != "")
                                {
                                    filter.WhereClause = "(" + str7 + ") and " + str2;
                                }
                                else
                                {
                                    filter.WhereClause = str7;
                                }
                                IFeatureCursor cursor3 = this.mQueryLayer2.FeatureClass.Search(filter, true);
                                IFeature feature2 = cursor3.NextFeature();
                                int num10 = 0;
                                double num11 = 0.0;
                                double num12 = 0.0;
                                while (feature2 != null)
                                {
                                    num10++;
                                    int num13 = feature2.Fields.FindField("MIAN_JI");
                                    if (feature2.get_Value(num13).ToString() != "")
                                    {
                                        num11 += double.Parse(feature2.get_Value(num13).ToString());
                                    }
                                    num13 = feature2.Fields.FindField("ZXJ");
                                    if (feature2.get_Value(num13).ToString() != "")
                                    {
                                        num12 += double.Parse(feature2.get_Value(num13).ToString());
                                    }
                                    Application.DoEvents();
                                    feature2 = cursor3.NextFeature();
                                }
                                if (node.GetValue(1).ToString() == "")
                                {
                                    node.SetValue(1, num12);
                                }
                                else
                                {
                                    node.SetValue(1, double.Parse(node.GetValue(1).ToString()) + num12);
                                }
                                if (node.GetValue(2).ToString() == "")
                                {
                                    node.SetValue(2, num11);
                                }
                                else
                                {
                                    node.SetValue(2, double.Parse(node.GetValue(2).ToString()) + num11);
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
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "DoQuery", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControls()
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBTypeLayer2").Split(new char[] { ',' });
                string sLayerName = "林地保护";
                this.mGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IGroupLayer;
                if (this.mGroupLayer != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    string str4 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                    string str5 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                    this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                    this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, str4, true);
                    this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, str5, true);
                    this.InitialDist();
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
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDist()
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameD").Split(new char[] { ',' });
                string[] strArray = "County,Town,Village".Split(new char[] { ',' });
                ArrayList list = new ArrayList();
                list.Add(this.comboBoxCounty);
                list.Add(this.comboBoxTown);
                list.Add(this.comboBoxVillage);
                for (int i = 0; i < strArray.Length; i++)
                {
                    ComboBoxEdit edit = list[i] as ComboBoxEdit;
                    edit.Properties.Items.Clear();
                    edit.Properties.Items.Add("--");
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableName");
                    ITable table2 = editWorkspace.OpenTable(configValue);
                    string name = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableFieldName");
                    string str3 = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableFieldCode");
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableWhereStr");
                    ICursor cursor = table2.Search(queryFilter, false);
                    IRow row = cursor.NextRow();
                    DataTable table = new DataTable();
                    DataColumn column = new DataColumn("code", typeof(string));
                    table.Columns.Add(column);
                    column = new DataColumn("name", typeof(string));
                    table.Columns.Add(column);
                    while (row != null)
                    {
                        int index = row.Fields.FindField(name);
                        int num3 = row.Fields.FindField(str3);
                        DataRow row2 = table.NewRow();
                        row2["code"] = row.get_Value(num3);
                        row2["name"] = row.get_Value(index);
                        table.Rows.Add(row2);
                        if (i == 0)
                        {
                            edit.Properties.Items.Add(row2["name"].ToString());
                        }
                        row = cursor.NextRow();
                    }
                    if (table.Rows.Count > 0)
                    {
                        ArrayList list2 = new ArrayList();
                        list2.Add(table);
                        edit.Tag = list2;
                        edit.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "InitialDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryLDBH));
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelLocation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelbasic.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelbasic);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(4, 26);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupControlDist.Size = new System.Drawing.Size(292, 104);
            this.groupControlDist.TabIndex = 104;
            this.groupControlDist.Text = "查询范围";
            // 
            // panelbasic
            // 
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbasic.Location = new System.Drawing.Point(6, 22);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(280, 80);
            this.panelbasic.TabIndex = 18;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(60, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(220, 79);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(220, 79);
            this.panel10.TabIndex = 14;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 52);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(220, 20);
            this.comboBoxVillage.TabIndex = 11;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 48);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(220, 4);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 28);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(220, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 24);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(220, 4);
            this.panel14.TabIndex = 8;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 4);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCounty.Size = new System.Drawing.Size(220, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(220, 4);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 79);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 26);
            this.label9.TabIndex = 3;
            this.label9.Text = "村 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 26);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.radioGroup1);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlResult.Location = new System.Drawing.Point(4, 134);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(4);
            this.groupControlResult.Size = new System.Drawing.Size(292, 164);
            this.groupControlResult.TabIndex = 106;
            this.groupControlResult.Text = "查询类型";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(6, 26);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地分布"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林种分布"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地质量等级"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地保护等级"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地起源"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地权属"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林木权属"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "事权等级"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "用益林保护等级"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "公益林商品林"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地变化原因"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "林地变更"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "新增林地"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "流失林地")});
            this.radioGroup1.Size = new System.Drawing.Size(280, 132);
            this.radioGroup1.TabIndex = 102;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(4, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(292, 26);
            this.labelLocation.TabIndex = 107;
            this.labelLocation.Text = "      林地保护类型查询          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 4);
            this.panel1.TabIndex = 108;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.simpleButtonMore);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.ButtonFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 298);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel2.Size = new System.Drawing.Size(292, 34);
            this.panel2.TabIndex = 109;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(98, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(60, 26);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "重置";
            this.simpleButton2.ToolTip = "重新设置查询条件";
            this.simpleButton2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(158, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 26);
            this.panel3.TabIndex = 17;
            this.panel3.Visible = false;
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMore.Image")));
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(165, 4);
            this.simpleButtonMore.Name = "simpleButtonMore";
            this.simpleButtonMore.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonMore.TabIndex = 13;
            this.simpleButtonMore.Tag = "基本";
            this.simpleButtonMore.Text = "更多";
            this.simpleButtonMore.ToolTip = "更多查询条件";
            this.simpleButtonMore.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(225, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(7, 26);
            this.panel8.TabIndex = 16;
            this.panel8.Visible = false;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Enabled = false;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(232, 4);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(60, 26);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查询";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.treeList);
            this.groupControl1.Controls.Add(this.panel5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 332);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl1.Size = new System.Drawing.Size(292, 282);
            this.groupControl1.TabIndex = 110;
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
            this.treeList.Location = new System.Drawing.Point(6, 26);
            this.treeList.Name = "treeList";
            this.treeList.BeginUnboundLoad();
            this.treeList.AppendNode(new object[] {
            "经济林",
            "2",
            "100"}, -1, -1, -1, 0);
            this.treeList.AppendNode(new object[] {
            "薪炭林",
            "3",
            "200"}, -1, 0, 0, 1);
            this.treeList.EndUnboundLoad();
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowRoot = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit3,
            this.repositoryItemImageEdit1});
            this.treeList.Size = new System.Drawing.Size(280, 220);
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
            this.treeListColumn1.Width = 140;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "蓄积";
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
            this.treeListColumn3.Width = 66;
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
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.simpleButtonBack);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(6, 246);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel5.Size = new System.Drawing.Size(280, 30);
            this.panel5.TabIndex = 101;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonInfo.Image")));
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(154, 4);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonInfo.TabIndex = 13;
            this.simpleButtonInfo.Text = "查看";
            this.simpleButtonInfo.ToolTip = "查看详细信息";
            this.simpleButtonInfo.Click += new System.EventHandler(this.simpleButtonInfo_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(214, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 26);
            this.panel4.TabIndex = 16;
            this.panel4.Visible = false;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.Image")));
            this.simpleButtonBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonBack.Location = new System.Drawing.Point(220, 4);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回设置条件";
            this.simpleButtonBack.Visible = false;
            // 
            // UserControlQueryLDBH
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScroll = true;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControlResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlQueryLDBH";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.Size = new System.Drawing.Size(300, 618);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelbasic.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(object hook, IFeatureLayer pLayer)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                this.mXBLayer = pLayer;
                this.InitialControls();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioGroup1.SelectedIndex != -1)
                {
                    string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("XBTypeLayer2").Split(new char[] { ',' })[this.radioGroup1.SelectedIndex + 1];
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "radioGroup1_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetDist(string code, DataTable ptable, ComboBoxEdit combox)
        {
            try
            {
                DataRow[] rowArray = ptable.Select("code like '" + code + "%'");
                for (int i = 0; i < rowArray.Length; i++)
                {
                    combox.Properties.Items.Add(rowArray[i]["name"]);
                }
                if (combox.Properties.Items.Count > 0)
                {
                    combox.SelectedIndex = 0;
                }
                ArrayList list = new ArrayList();
                list.Add(ptable);
                list.Add(rowArray);
                combox.Tag = list;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
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
                    if (layer2.Name != this.mQueryLayer.Name)
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLDBH", "simpleButtonInfo_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

