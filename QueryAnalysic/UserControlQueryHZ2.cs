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

    public class UserControlQueryHZ2 : UserControlBase1
    {
        private SimpleButton ButtonFind;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private IContainer components;
        private DateEdit dateEdit1;
        private DateEdit dateEdit2;
        private GroupControl groupControl1;
        private GroupControl groupControlDist;
        private GroupControl groupControlResult;
        private ImageList imageList1;
        private Label label1;
        private Label label31;
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
        private IFeatureLayer mBorderLayer;
        private const string mClassName = "QueryAnalysic.UserControlQueryHZ2";
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
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel14;
        private Panel panel2;
        private Panel panel3;
        private Panel panel35;
        private Panel panel5;
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

        public UserControlQueryHZ2()
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "comboBoxBase_TextChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    double num21;
                    string str = "";
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldDist").Split(new char[] { ',' });
                    ArrayList tag = null;
                    DataRow[] rowArray = null;
                    IQueryFilter queryFilter = new QueryFilterClass();
                    IFeatureCursor cursor = null;
                    this.mDisFeature = null;
                    if (this.comboBoxVillage.SelectedIndex >= 1)
                    {
                        tag = this.comboBoxVillage.Tag as ArrayList;
                        rowArray = tag[1] as DataRow[];
                        str = string.Concat(new object[] { strArray[2], "='", rowArray[this.comboBoxVillage.SelectedIndex - 1][0], "'" });
                        string str3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                        queryFilter.WhereClause = string.Concat(new object[] { str3, "='", rowArray[this.comboBoxVillage.SelectedIndex - 1][0], "'" });
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
                        str = string.Concat(new object[] { strArray[1], "='", rowArray[this.comboBoxTown.SelectedIndex - 1][0], "'" });
                        string str4 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                        queryFilter.WhereClause = string.Concat(new object[] { str4, "='", rowArray[this.comboBoxTown.SelectedIndex - 1][0], "'" });
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
                        str = string.Concat(new object[] { strArray[0], "='", rowArray[this.comboBoxCounty.SelectedIndex - 1][0], "'" });
                        string str5 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                        queryFilter.WhereClause = string.Concat(new object[] { str5, "='", rowArray[this.comboBoxCounty.SelectedIndex - 1][0], "'" });
                        this.mDisFeature = this.m_pCLayer.Search(queryFilter, false).NextFeature();
                    }
                    string str6 = "";
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldTime");
                    if ((configValue != "") && ((this.dateEdit1.Text != "") || (this.dateEdit2.Text != "")))
                    {
                        string str8 = "";
                        if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "Local")
                        {
                            str8 = " date ";
                        }
                        else if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "SqlServer")
                        {
                            str8 = "";
                        }
                        string str9 = "";
                        if (this.dateEdit1.Text != "")
                        {
                            str9 = DateTime.Parse(this.dateEdit1.Text).ToString("yyyy-MM-dd HH:mm:ss");
                            str6 = configValue + ">= " + str8 + "'" + str9 + "'";
                        }
                        if (this.dateEdit2.Text != "")
                        {
                            str9 = DateTime.Parse(this.dateEdit2.Text).ToString("yyyy-MM-dd 23:59:59");
                            if (str6 == "")
                            {
                                str6 = configValue + "<= " + str8 + "'" + str9 + "'";
                            }
                            else
                            {
                                str6 = str6 + " and " + configValue + "<= " + str8 + "'" + str9 + "'";
                            }
                        }
                        string str10 = "";
                        if (str6 != "")
                        {
                            ITable table = EditTask.EditWorkspace.OpenTable(EditTask.TableName);
                            IQueryFilter filter2 = new QueryFilterClass();
                            filter2.WhereClause = str6;
                            ICursor cursor2 = table.Search(filter2, false);
                            IRow row = cursor2.NextRow();
                            string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TableFieldName");
                            while (row != null)
                            {
                                int index = row.Fields.FindField(name);
                                if (row.get_Value(index).ToString() != "")
                                {
                                    if (str10 != "")
                                    {
                                        str10 = string.Concat(new object[] { str10, " or ", name, " = ", row.get_Value(index) });
                                    }
                                    else
                                    {
                                        str10 = string.Concat(new object[] { name, " = '", row.get_Value(index), "'" });
                                    }
                                }
                                row = cursor2.NextRow();
                            }
                        }
                        if (str10 != "")
                        {
                            if (str != "")
                            {
                                str = str + " and " + str10;
                            }
                            else
                            {
                                str = str10;
                            }
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
                    else if (this.mEditKind == "火灾")
                    {
                        this.treeList.Columns[2].Caption = "灾害面积";
                        this.treeList.Columns[1].Caption = "损失蓄积";
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
                        IFeatureCursor cursor3 = this.mQueryLayer2.Search(null, false);
                        IFeature feature = cursor3.NextFeature();
                        int num4 = 0;
                        double num5 = 0.0;
                        double num6 = 0.0;
                        while (feature != null)
                        {
                            num4++;
                            int num7 = feature.Fields.FindField("MIAN_JI");
                            if (feature.get_Value(num7).ToString() != "")
                            {
                                num5 += double.Parse(feature.get_Value(num7).ToString());
                            }
                            if (this.mEditKind == "采伐")
                            {
                                int num8 = feature.Fields.FindField("CFXJ");
                                if (feature.get_Value(num8).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num8).ToString());
                                }
                            }
                            else if (this.mEditKind == "造林")
                            {
                                int num9 = feature.Fields.FindField("MEI_GQ_ZS");
                                if (feature.get_Value(num9).ToString() != "")
                                {
                                    num6 += double.Parse(feature.get_Value(num9).ToString());
                                }
                            }
                            feature = cursor3.NextFeature();
                        }
                        string val = "";
                        string str13 = "";
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
                            num21 = double.Parse(node.GetDisplayText(1).ToString().Trim()) + num6;
                            val = num21.ToString();
                        }
                        if ((num5 == 0.0) && (node.GetDisplayText(2).ToString().Trim() == ""))
                        {
                            str13 = "";
                        }
                        else if ((node.GetDisplayText(2).ToString().Trim() == "") && (num5 != 0.0))
                        {
                            str13 = num5.ToString();
                        }
                        else if ((node.GetDisplayText(2).ToString().Trim() != "") && (num5 == 0.0))
                        {
                            str13 = node.GetDisplayText(2).ToString().Trim();
                        }
                        else
                        {
                            num21 = double.Parse(node.GetDisplayText(2).ToString().Trim()) + num5;
                            str13 = num21.ToString();
                        }
                        node.SetValue(1, val);
                        node.SetValue(2, str13);
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
                        for (int i = 0; i < renderer3.ValueCount; i++)
                        {
                            ISymbol symbol2 = renderer3.get_Symbol(renderer3.get_Value(i));
                            this.imageList1.Images.Add(this.Convert(symbol2, width, height));
                            if ((node == null) || (renderer3.get_Label(renderer3.get_Value(i)).ToString() != node.GetValue(0).ToString()))
                            {
                                node = this.treeList.AppendNode(renderer3.get_Label(renderer3.get_Value(i)), parentNode);
                                node.SetValue(0, renderer3.get_Label(renderer3.get_Value(i)));
                                node.SetValue(1, 0);
                                node.SetValue(2, 0);
                                node.Visible = false;
                                node.StateImageIndex = this.imageList1.Images.Count - 1;
                            }
                            IQueryFilter filter = new QueryFilterClass();
                            string[] strArray2 = renderer3.get_Value(i).Split(new char[] { ';' });
                            string str14 = renderer3.get_Field(0) + "='" + strArray2[0] + "'";
                            for (int j = 1; j < strArray2.Length; j++)
                            {
                                str14 = str14 + " or " + renderer3.get_Field(0) + "='" + strArray2[j] + "'";
                            }
                            if (str != "")
                            {
                                filter.WhereClause = "(" + str14 + ") and " + str;
                            }
                            else
                            {
                                filter.WhereClause = str14;
                            }
                            IFeatureCursor cursor4 = this.mQueryLayer2.FeatureClass.Search(filter, true);
                            IFeature feature2 = cursor4.NextFeature();
                            int num12 = 0;
                            double num13 = 0.0;
                            double num14 = 0.0;
                            while (feature2 != null)
                            {
                                num12++;
                                if (this.mEditKind == "采伐")
                                {
                                    int num15 = feature2.Fields.FindField("MIAN_JI");
                                    if (feature2.get_Value(num15).ToString() != "")
                                    {
                                        num13 += double.Parse(feature2.get_Value(num15).ToString());
                                    }
                                    int num16 = feature2.Fields.FindField("CFXJ");
                                    if (feature2.get_Value(num16).ToString() != "")
                                    {
                                        num14 += double.Parse(feature2.get_Value(num16).ToString());
                                    }
                                }
                                else if (this.mEditKind == "造林")
                                {
                                    int num17 = feature2.Fields.FindField("MIAN_JI");
                                    if (feature2.get_Value(num17).ToString() != "")
                                    {
                                        num13 += double.Parse(feature2.get_Value(num17).ToString());
                                    }
                                    int num18 = feature2.Fields.FindField("MEI_GQ_ZS");
                                    if (feature2.get_Value(num18).ToString() != "")
                                    {
                                        num14 += double.Parse(feature2.get_Value(num18).ToString());
                                    }
                                }
                                else if (this.mEditKind == "火灾")
                                {
                                    int num19 = feature2.Fields.FindField("ZHMJ");
                                    if (feature2.get_Value(num19).ToString() != "")
                                    {
                                        num13 += double.Parse(feature2.get_Value(num19).ToString());
                                    }
                                    int num20 = feature2.Fields.FindField("SUNSHIXJ");
                                    if (feature2.get_Value(num20).ToString() != "")
                                    {
                                        num14 += double.Parse(feature2.get_Value(num20).ToString());
                                    }
                                }
                                feature2 = cursor4.NextFeature();
                            }
                            string str15 = "";
                            string str16 = "";
                            if (node.GetDisplayText(1).ToString().Trim() == "0")
                            {
                                node.SetValue(1, "");
                            }
                            if (node.GetDisplayText(2).ToString().Trim() == "0")
                            {
                                node.SetValue(2, "");
                            }
                            if ((num14 == 0.0) && (node.GetDisplayText(1).ToString().Trim() == ""))
                            {
                                str15 = "";
                            }
                            else if ((node.GetDisplayText(1).ToString().Trim() == "") && (num14 != 0.0))
                            {
                                str15 = num14.ToString();
                            }
                            else if ((node.GetDisplayText(1).ToString().Trim() != "") && (num14 == 0.0))
                            {
                                str15 = node.GetDisplayText(1).ToString().Trim();
                            }
                            else
                            {
                                num21 = double.Parse(node.GetDisplayText(1).ToString().Trim()) + num14;
                                str15 = num21.ToString();
                            }
                            if ((num13 == 0.0) && (node.GetDisplayText(2).ToString().Trim() == ""))
                            {
                                str16 = "";
                            }
                            else if ((node.GetDisplayText(2).ToString().Trim() == "") && (num13 != 0.0))
                            {
                                str16 = num13.ToString();
                            }
                            else if ((node.GetDisplayText(2).ToString().Trim() != "") && (num13 == 0.0))
                            {
                                str16 = node.GetDisplayText(2).ToString().Trim();
                            }
                            else
                            {
                                str16 = (double.Parse(node.GetDisplayText(2).ToString().Trim()) + num13).ToString();
                            }
                            node.SetValue(1, str15);
                            node.SetValue(2, str16);
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
                                node.Visible = false;
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
                                node.Visible = false;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "DoQuery", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.InitialDist();
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
                if (this.radioGroup1.Properties.Items.Count > 0)
                {
                    this.radioGroup1.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDist()
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                UtilFactory.GetConfigOpt().GetConfigValue("CaiFaFieldDist").Split(new char[] { ',' });
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "InitialDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryHZ2));
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel5 = new System.Windows.Forms.Panel();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.panel35.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panelbasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 6);
            this.panel3.TabIndex = 27;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(8, 28);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "火灾等级"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "火灾原因")});
            this.radioGroup1.Size = new System.Drawing.Size(257, 44);
            this.radioGroup1.TabIndex = 102;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
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
            this.dateEdit2.Size = new System.Drawing.Size(97, 20);
            this.dateEdit2.TabIndex = 24;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 58);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(189, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
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
            // panel35
            // 
            this.panel35.Controls.Add(this.dateEdit2);
            this.panel35.Controls.Add(this.label31);
            this.panel35.Controls.Add(this.dateEdit1);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 84);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(189, 23);
            this.panel35.TabIndex = 26;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel35);
            this.panel10.Controls.Add(this.panel3);
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(189, 115);
            this.panel10.TabIndex = 14;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 52);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(189, 6);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 32);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(189, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 26);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(189, 6);
            this.panel14.TabIndex = 8;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 6);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCounty.Size = new System.Drawing.Size(189, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 6);
            this.panel11.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "发生时间 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel9.Size = new System.Drawing.Size(68, 115);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 26);
            this.label9.TabIndex = 3;
            this.label9.Text = "村 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 26);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(68, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(189, 115);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panelbasic
            // 
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbasic.Location = new System.Drawing.Point(8, 22);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(257, 116);
            this.panelbasic.TabIndex = 18;
            // 
            // repositoryItemPopupContainerEdit3
            // 
            this.repositoryItemPopupContainerEdit3.AutoHeight = false;
            this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelbasic);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(0, 26);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.groupControlDist.Size = new System.Drawing.Size(273, 140);
            this.groupControlDist.TabIndex = 117;
            this.groupControlDist.Text = "查询范围";
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
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "火场数";
            this.treeListColumn2.FieldName = "value";
            this.treeListColumn2.ImageIndex = 17;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 2;
            this.treeListColumn2.Width = 66;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.treeList);
            this.groupControl1.Controls.Add(this.panel5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 292);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl1.Size = new System.Drawing.Size(273, 360);
            this.groupControl1.TabIndex = 122;
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
            this.treeList.Size = new System.Drawing.Size(257, 292);
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
            this.panel5.Location = new System.Drawing.Point(8, 320);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(257, 32);
            this.panel5.TabIndex = 101;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonInfo.Image")));
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(125, 6);
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
            this.simpleButtonBack.Location = new System.Drawing.Point(191, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回设置条件";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.radioGroup1);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlResult.Location = new System.Drawing.Point(0, 166);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(6);
            this.groupControlResult.Size = new System.Drawing.Size(273, 80);
            this.groupControlResult.TabIndex = 118;
            this.groupControlResult.Text = "查询类型";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(75, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(66, 26);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "重置";
            this.simpleButton2.ToolTip = "重新设置查询条件";
            this.simpleButton2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 8);
            this.panel1.TabIndex = 120;
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMore.Image")));
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(141, 6);
            this.simpleButtonMore.Name = "simpleButtonMore";
            this.simpleButtonMore.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonMore.TabIndex = 13;
            this.simpleButtonMore.Tag = "基本";
            this.simpleButtonMore.Text = "更多";
            this.simpleButtonMore.ToolTip = "更多查询条件";
            this.simpleButtonMore.Visible = false;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Enabled = false;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(207, 6);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(66, 26);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查询";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.simpleButtonMore);
            this.panel2.Controls.Add(this.ButtonFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 246);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel2.Size = new System.Drawing.Size(273, 38);
            this.panel2.TabIndex = 121;
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(0, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(273, 26);
            this.labelLocation.TabIndex = 119;
            this.labelLocation.Text = "      火灾类型查询          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlQueryHZ2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControlResult);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlQueryHZ2";
            this.Size = new System.Drawing.Size(273, 652);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.panel35.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panelbasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(object hook, string sEditKind, string sEditKind2)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                this.mEditKind = sEditKind;
                this.mEditKind2 = sEditKind2;
                this.InitialControls();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "radioGroup1_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ2", "simpleButtonInfo_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonMore_Click(object sender, EventArgs e)
        {
        }
    }
}

