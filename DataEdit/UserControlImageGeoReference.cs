namespace DataEdit
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlImageGeoReference : UserControlBase1
    {
        private SimpleButton ButtonCoordLocation;
        private ButtonEdit buttonEditDataPath;
        private SimpleButton ButtonLocationClear;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel groupBox3;
        private GroupControl groupControl1;
        private GroupControl groupControlXY;
        internal ImageList ImageList1;
        private ImageList imageList2;
        internal ImageList imageList3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelInfo;
        private bool m_bCoor = false;
        private bool m_bUnitD = false;
        private IFeatureLayer m_EditLayer;
        private ITable m_EditTable = null;
        private IFeatureWorkspace m_EditWorkspace;
        private PointTool m_pPointTool = null;
        private PointTool m_pPointTool2 = null;
        private PointTool m_pPointTool3 = null;
        private PointTool m_pPointTool4 = null;
        private IGroupLayer m_TempGroupLayer;
        private const string mClassName = "DataEdit.UserControlImageGeoReference";
        private TextEdit mCurTextX;
        private TextEdit mCurTextY;
      
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private HookHelper mHookHelper = null;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
        private ArrayList mLayerList = null;
        private ArrayList mLayerList2 = null;
        private BarButtonItem mParButton;
        private IPoint mPoint = null;
        private IFeatureLayer mPointFeatureLayer;
        private DataTable mPointTable;
        private DataTable mPointTable2;
        private IFeatureLayer mPolyFeatureLayer;
        private IFeatureWorkspace mPolyFeatureWorkspace;
        private DataTable mPolyTable;
        private ArrayList mRangeList = null;
        private IRasterLayer mRasterlayer = null;
        private ArrayList mRasterlayerList = null;
        private bool mSelected = false;
        private DataTable mSelPointTable;
        private ISpatialReference mSpatialReference = null;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "影像数据配准加载";
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel18;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        public Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelTarget;
        private RadioGroup radioGroup;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
        private RadioGroup radioGroup3;
        public SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonLocation;
        private SimpleButton simpleButtonLocation0;
        private SimpleButton simpleButtonLocation2;
        private SimpleButton simpleButtonLocation3;
        public SimpleButton simpleButtonOK;
        public SimpleButton simpleButtonPointsAdjust;
        private SimpleButton simpleButtonPoject;
        public SimpleButton simpleButtonRemove;
        private SimpleButton simpleButtonTLocation;
        private SimpleButton simpleButtonTLocation0;
        private SimpleButton simpleButtonTLocation2;
        private SimpleButton simpleButtonTLocation3;
        private SpinEdit spinEdit2JX;
        private SpinEdit spinEdit2JX1;
        private SpinEdit spinEdit2JX2;
        private SpinEdit spinEdit2JX3;
        private SpinEdit spinEdit2JY;
        private SpinEdit spinEdit2JY1;
        private SpinEdit spinEdit2JY2;
        private SpinEdit spinEdit2JY3;
        private SpinEdit spinEditJX;
        private SpinEdit spinEditJX1;
        private SpinEdit spinEditJX2;
        private SpinEdit spinEditJX3;
        private SpinEdit spinEditJY;
        private SpinEdit spinEditJY1;
        private SpinEdit spinEditJY2;
        private SpinEdit spinEditJY3;
        private string SubID = "";
        private TextEdit textDX;
        private TextEdit textDX0;
        private TextEdit textDX2;
        private TextEdit textDX3;
        private TextEdit textDY;
        private TextEdit textDY0;
        private TextEdit textDY2;
        private TextEdit textDY3;
        private TextEdit textSDX;
        private TextEdit textSDX0;
        private TextEdit textSDX2;
        private TextEdit textSDX3;
        private TextEdit textSDY;
        private TextEdit textSDY0;
        private TextEdit textSDY2;
        private TextEdit textSDY3;

        public UserControlImageGeoReference()
        {
            this.InitializeComponent();
        }

        private void buttonEditDataPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Exception exception;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.RestoreDirectory = true;
                dialog.Filter = "图片文件(*.BMP,*.GIF;*.TIFF;*.PNG;*.JPG) |*.bmp;*.gif;*.tif;*.png;*.jpg;*jpeg|BMP 文件(*.BMP)|*.BMP|GIF 文件(*.GIF)|*.GIF|TIF 文件(*.TIF)|*.TIF|PNG 文件(*.PNG)|*.PNG|JPG 文件(*.JPEG)|*.JPEG";
                string str = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ILayer layer2;
                    IGeoDataset dataset3;
                    string fileName = dialog.FileName;
                    string str3 = Directory.GetParent(fileName).ToString();
                    this.buttonEditDataPath.Text = fileName;
                    this.buttonEditDataPath.Tag = fileName;
                    dialog = null;
                    string[] strArray = this.buttonEditDataPath.Text.Split(new char[] { '.' });
                    string[] strArray2 = strArray[0].Split(new char[] { '\\' });
                    str = strArray2[strArray2.Length - 1] + "." + strArray[1];
                    IWorkspaceFactory factory = new RasterWorkspaceFactoryClass();
                    IRasterDataset pRasterDataset = null;
                    pRasterDataset = ((IRasterWorkspace) factory.OpenFromFile(str3, 0)).OpenRasterDataset(strArray2[strArray2.Length - 1] + "." + strArray[1]);
                    this.buttonEditDataPath.Tag = pRasterDataset;
                    IGeoDataset dataset2 = pRasterDataset as IGeoDataset;
                    this.textSDX0.EditValue = dataset2.Extent.UpperLeft.X.ToString();
                    this.textSDY0.EditValue = dataset2.Extent.UpperLeft.Y.ToString();
                    this.textSDX.EditValue = dataset2.Extent.LowerLeft.X.ToString();
                    this.textSDY.EditValue = dataset2.Extent.LowerLeft.Y.ToString();
                    this.textSDX2.EditValue = dataset2.Extent.UpperRight.X.ToString();
                    this.textSDY2.EditValue = dataset2.Extent.UpperRight.Y.ToString();
                    this.textSDX3.EditValue = dataset2.Extent.LowerRight.X.ToString();
                    this.textSDY3.EditValue = dataset2.Extent.LowerRight.Y.ToString();
                    this.textDX0.EditValue = dataset2.Extent.UpperLeft.X.ToString();
                    this.textDY0.EditValue = dataset2.Extent.UpperLeft.Y.ToString();
                    this.textDX.EditValue = dataset2.Extent.LowerLeft.X.ToString();
                    this.textDY.EditValue = dataset2.Extent.LowerLeft.Y.ToString();
                    this.textDX2.EditValue = dataset2.Extent.UpperRight.X.ToString();
                    this.textDY2.EditValue = dataset2.Extent.UpperRight.Y.ToString();
                    this.textDX3.EditValue = dataset2.Extent.LowerRight.X.ToString();
                    this.textDY3.EditValue = dataset2.Extent.LowerRight.Y.ToString();
                    this.simpleButtonOK.Enabled = true;
                    this.simpleButtonPointsAdjust.Enabled = true;
                    IRasterLayer mRasterlayer = null;
                    if (this.CheckHas(pRasterDataset))
                    {
                        mRasterlayer = this.mRasterlayer;
                        mRasterlayer.SpatialReference = this.mSpatialReference;
                        try
                        {
                            mRasterlayer.CreateFromDataset(pRasterDataset);
                            this.mRasterlayer = mRasterlayer;
                            if (GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, mRasterlayer.Name, true) == null)
                            {
                                this.mHookHelper.FocusMap.AddLayer(this.mRasterlayer);
                                this.mRasterlayerList.Add(this.mRasterlayer);
                            }
                            layer2 = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, mRasterlayer.Name, true);
                            if (layer2 != null)
                            {
                                this.mHookHelper.FocusMap.MoveLayer(layer2, this.mHookHelper.FocusMap.LayerCount - 1);
                            }
                            dataset3 = pRasterDataset as IGeoDataset;
                            this.mHookHelper.ActiveView.Extent = dataset3.Extent;
                            this.mHookHelper.ActiveView.Refresh();
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                            this.labelInfo.Text = "    文件 " + str + "为无效的栅格影像。";
                            this.labelInfo.Visible = true;
                        }
                    }
                    else
                    {
                        mRasterlayer = new RasterLayerClass();
                        mRasterlayer.SpatialReference = this.mSpatialReference;
                        try
                        {
                            mRasterlayer.CreateFromDataset(pRasterDataset);
                            this.mRasterlayer = mRasterlayer;
                            this.mHookHelper.FocusMap.AddLayer(this.mRasterlayer);
                            this.mRasterlayerList.Add(this.mRasterlayer);
                            layer2 = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, mRasterlayer.Name, true);
                            if (layer2 != null)
                            {
                                this.mHookHelper.FocusMap.MoveLayer(layer2, this.mHookHelper.FocusMap.LayerCount - 1);
                            }
                            dataset3 = pRasterDataset as IGeoDataset;
                            this.mHookHelper.ActiveView.Extent = dataset3.Extent;
                            this.mHookHelper.ActiveView.Refresh();
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                            this.labelInfo.Text = "    文件 " + str + "为无效的栅格影像。";
                            this.labelInfo.Visible = true;
                        }
                    }
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlImageGeoReference", "buttonEditDataPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool CheckHas(IRasterDataset pRasterDataset)
        {
            try
            {
                for (int i = 0; i < this.mRasterlayerList.Count; i++)
                {
                    IDataset dataset = this.mRasterlayerList[i] as IDataset;
                    if (dataset.Name == (pRasterDataset as IDataset).Name)
                    {
                        if (GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, dataset.Name, true) != null)
                        {
                            return true;
                        }
                        this.mRasterlayerList.RemoveAt(i);
                        return false;
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

        private void GetPointTool()
        {
            Exception exception;
            try
            {
                try
                {
                    IMapControl2 hook = null;
                    hook = (IMapControl2) this.mHookHelper.Hook;
                    hook.CurrentTool = this.m_pPointTool;
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    IPageLayoutControl2 control2 = null;
                    control2 = (IPageLayoutControl2) this.mHookHelper.Hook;
                    control2.CurrentTool = this.m_pPointTool;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlImageGeoReference", "GetPointTool", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Hook(object hook, string sEditKind)
        {
            try
            {
                if (hook != null)
                {
                    this.mEditKind = sEditKind;
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    this.InitialValue();
                    this.InitialControl();
                }
                this.mEditKind = sEditKind;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlImageGeoReference", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool ImageGeoReference()
        {
            Exception exception;
            try
            {
                string text = this.buttonEditDataPath.Text;
                IRasterDataset tag = this.buttonEditDataPath.Tag as IRasterDataset;
                if (text == "")
                {
                    this.labelInfo.Text = "    没有选择文件。";
                    this.labelInfo.Visible = true;
                    return false;
                }
                IRasterLayer mRasterlayer = null;
                if (this.mRasterlayer != null)
                {
                    mRasterlayer = this.mRasterlayer;
                }
                else
                {
                    mRasterlayer = new RasterLayerClass();
                    try
                    {
                        mRasterlayer.CreateFromDataset(tag);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        this.labelInfo.Text = "    文件 " + text + "为无效的栅格影像。";
                        this.labelInfo.Visible = true;
                        return false;
                    }
                }
                double jX = 0.0;
                double jY = 0.0;
                double num3 = 0.0;
                double num4 = 0.0;
                if ((this.radioGroup3.SelectedIndex != 0) && (this.radioGroup3.SelectedIndex == 1))
                {
                    if (this.radioGroup.SelectedIndex == 1)
                    {
                        this.m_bCoor = true;
                    }
                    else
                    {
                        this.m_bCoor = false;
                        if (this.radioGroup2.SelectedIndex == 1)
                        {
                            jX = this.JX;
                            jY = this.JY;
                            num3 = this.JX2;
                            num4 = this.JY2;
                        }
                        else
                        {
                            jX = (this.JD_DFM_D + (this.JD_DFM_F / 60.0)) + (this.JD_DFM_M / 3600.0);
                            jY = (this.WD_DFM_D + (this.WD_DFM_F / 60.0)) + (this.WD_DFM_M / 3600.0);
                            num3 = (this.JD_DFM_D2 + (this.JD_DFM_F2 / 60.0)) + (this.JD_DFM_M2 / 3600.0);
                            num3 = (this.WD_DFM_D2 + (this.WD_DFM_F2 / 60.0)) + (this.WD_DFM_M2 / 3600.0);
                        }
                    }
                }
                mRasterlayer.SpatialReference = this.mSpatialReference;
                IGeoDataset dataset2 = mRasterlayer as IGeoDataset;
                IPointCollection targetControlPoints = new MultipointClass();
                IPointCollection sourceControlPoints = new MultipointClass();
                IPoint inPoint = null;
                object before = Missing.Value;
                object after = Missing.Value;
                inPoint = new PointClass();
                inPoint.PutCoords(Convert.ToDouble(this.textSDX0.Text), Convert.ToDouble(this.textSDY0.Text));
                sourceControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(Convert.ToDouble(this.textSDX.Text), Convert.ToDouble(this.textSDY.Text));
                sourceControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(Convert.ToDouble(this.textSDX2.Text), Convert.ToDouble(this.textSDY2.Text));
                sourceControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(Convert.ToDouble(this.textSDX3.Text), Convert.ToDouble(this.textSDY3.Text));
                sourceControlPoints.AddPoint(inPoint, ref before, ref after);
                IGeoReference reference = mRasterlayer as IGeoReference;
                inPoint = new PointClass();
                inPoint.PutCoords(this.DX0, this.DY0);
                targetControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(this.DX, this.DY);
                targetControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(this.DX2, this.DY2);
                targetControlPoints.AddPoint(inPoint, ref before, ref after);
                inPoint = new PointClass();
                inPoint.PutCoords(this.DX3, this.DY3);
                targetControlPoints.AddPoint(inPoint, ref before, ref after);
                IRasterGeometryProc proc = new RasterGeometryProcClass();
                proc.Reset(mRasterlayer.Raster);
                proc.Warp(sourceControlPoints, targetControlPoints, esriGeoTransTypeEnum.esriGeoTransPolyOrder1, mRasterlayer.Raster);
                proc.Register(mRasterlayer.Raster);
                proc = null;
                this.mHookHelper.ActiveView.FullExtent = (mRasterlayer as IGeoDataset).Extent;
                this.mRasterlayer = mRasterlayer;
                ILayer layer2 = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, mRasterlayer.Name, true);
                if (layer2 == null)
                {
                    this.mHookHelper.FocusMap.AddLayer(this.mRasterlayer);
                    this.mRasterlayerList.Add(this.mRasterlayer);
                    layer2 = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, mRasterlayer.Name, true);
                }
                if (layer2 != null)
                {
                    this.mHookHelper.FocusMap.MoveLayer(layer2, this.mHookHelper.FocusMap.LayerCount - (this.mHookHelper.FocusMap.LayerCount - 1));
                }
                return true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlImageGeoReference", "ImageGeoReference", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void InitCoordControl()
        {
            this.panel18.Enabled = true;
            this.groupBox1.Enabled = false;
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = true;
            this.groupBox3.Enabled = true;
            this.groupControlXY.Height = (this.groupBox3.Top + this.groupBox3.Height) + 2;
            this.simpleButtonLocation0.Visible = true;
            this.simpleButtonLocation0.Enabled = true;
            this.simpleButtonLocation.Visible = true;
            this.simpleButtonLocation.Enabled = true;
            this.simpleButtonLocation2.Visible = true;
            this.simpleButtonLocation2.Enabled = true;
            this.simpleButtonLocation3.Visible = true;
            this.simpleButtonLocation3.Enabled = true;
            this.simpleButtonTLocation0.Visible = true;
            this.simpleButtonTLocation0.Enabled = true;
            this.simpleButtonTLocation.Visible = true;
            this.simpleButtonTLocation.Enabled = true;
            this.simpleButtonTLocation2.Visible = true;
            this.simpleButtonTLocation2.Enabled = true;
            this.simpleButtonTLocation3.Visible = true;
            this.simpleButtonTLocation3.Enabled = true;
            this.m_bCoor = false;
            this.m_bUnitD = false;
        }

        private void InitialControl()
        {
            this.panelTarget.Enabled = true;
            this.buttonEditDataPath.Enabled = true;
            this.radioGroup.SelectedIndex = 1;
            this.radioGroup3.SelectedIndex = 1;
            this.InitCoordControl();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlImageGeoReference));
            this.panelTarget = new Panel();
            this.buttonEditDataPath = new ButtonEdit();
            this.label2 = new Label();
            this.groupControlXY = new GroupControl();
            this.panel7 = new Panel();
            this.ButtonCoordLocation = new SimpleButton();
            this.imageList2 = new ImageList(this.components);
            this.panel8 = new Panel();
            this.ButtonLocationClear = new SimpleButton();
            this.groupBox1 = new GroupBox();
            this.spinEdit2JY3 = new SpinEdit();
            this.spinEdit2JX3 = new SpinEdit();
            this.label22 = new Label();
            this.label23 = new Label();
            this.spinEdit2JY2 = new SpinEdit();
            this.label26 = new Label();
            this.spinEdit2JY1 = new SpinEdit();
            this.label27 = new Label();
            this.label28 = new Label();
            this.label29 = new Label();
            this.spinEdit2JX2 = new SpinEdit();
            this.spinEdit2JX1 = new SpinEdit();
            this.label31 = new Label();
            this.label33 = new Label();
            this.spinEditJY3 = new SpinEdit();
            this.spinEditJX3 = new SpinEdit();
            this.label17 = new Label();
            this.label16 = new Label();
            this.spinEditJY2 = new SpinEdit();
            this.label15 = new Label();
            this.spinEditJY1 = new SpinEdit();
            this.label14 = new Label();
            this.label13 = new Label();
            this.label12 = new Label();
            this.spinEditJX2 = new SpinEdit();
            this.spinEditJX1 = new SpinEdit();
            this.label10 = new Label();
            this.label11 = new Label();
            this.groupBox2 = new GroupBox();
            this.label6 = new Label();
            this.label7 = new Label();
            this.spinEdit2JY = new SpinEdit();
            this.spinEdit2JX = new SpinEdit();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label21 = new Label();
            this.label20 = new Label();
            this.spinEditJY = new SpinEdit();
            this.spinEditJX = new SpinEdit();
            this.label19 = new Label();
            this.label18 = new Label();
            this.groupBox3 = new Panel();
            this.panel10 = new Panel();
            this.simpleButtonTLocation3 = new SimpleButton();
            this.imageList3 = new ImageList(this.components);
            this.simpleButtonTLocation2 = new SimpleButton();
            this.textDY3 = new TextEdit();
            this.textDX3 = new TextEdit();
            this.label1 = new Label();
            this.label3 = new Label();
            this.textDY2 = new TextEdit();
            this.textDX2 = new TextEdit();
            this.simpleButtonTLocation = new SimpleButton();
            this.textDY = new TextEdit();
            this.textDX = new TextEdit();
            this.simpleButtonTLocation0 = new SimpleButton();
            this.label4 = new Label();
            this.textDY0 = new TextEdit();
            this.textDX0 = new TextEdit();
            this.label5 = new Label();
            this.label24 = new Label();
            this.label25 = new Label();
            this.label30 = new Label();
            this.label32 = new Label();
            this.label35 = new Label();
            this.label38 = new Label();
            this.label50 = new Label();
            this.label51 = new Label();
            this.label43 = new Label();
            this.panel9 = new Panel();
            this.simpleButtonLocation3 = new SimpleButton();
            this.simpleButtonLocation2 = new SimpleButton();
            this.textSDY3 = new TextEdit();
            this.textSDX3 = new TextEdit();
            this.label48 = new Label();
            this.label49 = new Label();
            this.textSDY2 = new TextEdit();
            this.textSDX2 = new TextEdit();
            this.simpleButtonLocation = new SimpleButton();
            this.textSDY = new TextEdit();
            this.textSDX = new TextEdit();
            this.simpleButtonLocation0 = new SimpleButton();
            this.label45 = new Label();
            this.textSDY0 = new TextEdit();
            this.textSDX0 = new TextEdit();
            this.label44 = new Label();
            this.label46 = new Label();
            this.label47 = new Label();
            this.label41 = new Label();
            this.label34 = new Label();
            this.label40 = new Label();
            this.label39 = new Label();
            this.label36 = new Label();
            this.label37 = new Label();
            this.label42 = new Label();
            this.panel18 = new Panel();
            this.radioGroup2 = new RadioGroup();
            this.panel5 = new Panel();
            this.radioGroup = new RadioGroup();
            this.radioGroup3 = new RadioGroup();
            this.panel6 = new Panel();
            this.simpleButtonOK = new SimpleButton();
            this.ImageList1 = new ImageList(this.components);
            this.panel2 = new Panel();
            this.simpleButtonPointsAdjust = new SimpleButton();
            this.panel1 = new Panel();
            this.simpleButtonRemove = new SimpleButton();
            this.panel3 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.groupControl1 = new GroupControl();
            this.simpleButtonPoject = new SimpleButton();
            this.radioGroup1 = new RadioGroup();
            this.panel4 = new Panel();
            this.labelInfo = new Label();
            this.panel11 = new Panel();
            this.panelTarget.SuspendLayout();
            this.buttonEditDataPath.Properties.BeginInit();
            this.groupControlXY.BeginInit();
            this.groupControlXY.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.spinEdit2JY3.Properties.BeginInit();
            this.spinEdit2JX3.Properties.BeginInit();
            this.spinEdit2JY2.Properties.BeginInit();
            this.spinEdit2JY1.Properties.BeginInit();
            this.spinEdit2JX2.Properties.BeginInit();
            this.spinEdit2JX1.Properties.BeginInit();
            this.spinEditJY3.Properties.BeginInit();
            this.spinEditJX3.Properties.BeginInit();
            this.spinEditJY2.Properties.BeginInit();
            this.spinEditJY1.Properties.BeginInit();
            this.spinEditJX2.Properties.BeginInit();
            this.spinEditJX1.Properties.BeginInit();
            this.groupBox2.SuspendLayout();
            this.spinEdit2JY.Properties.BeginInit();
            this.spinEdit2JX.Properties.BeginInit();
            this.spinEditJY.Properties.BeginInit();
            this.spinEditJX.Properties.BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.textDY3.Properties.BeginInit();
            this.textDX3.Properties.BeginInit();
            this.textDY2.Properties.BeginInit();
            this.textDX2.Properties.BeginInit();
            this.textDY.Properties.BeginInit();
            this.textDX.Properties.BeginInit();
            this.textDY0.Properties.BeginInit();
            this.textDX0.Properties.BeginInit();
            this.panel9.SuspendLayout();
            this.textSDY3.Properties.BeginInit();
            this.textSDX3.Properties.BeginInit();
            this.textSDY2.Properties.BeginInit();
            this.textSDX2.Properties.BeginInit();
            this.textSDY.Properties.BeginInit();
            this.textSDX.Properties.BeginInit();
            this.textSDY0.Properties.BeginInit();
            this.textSDX0.Properties.BeginInit();
            this.panel18.SuspendLayout();
            this.radioGroup2.Properties.BeginInit();
            this.radioGroup.Properties.BeginInit();
            this.radioGroup3.Properties.BeginInit();
            this.panel6.SuspendLayout();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.radioGroup1.Properties.BeginInit();
            this.panel11.SuspendLayout();
            base.SuspendLayout();
            this.panelTarget.BackColor = Color.Transparent;
            this.panelTarget.Controls.Add(this.buttonEditDataPath);
            this.panelTarget.Controls.Add(this.label2);
            this.panelTarget.Dock = DockStyle.Top;
            this.panelTarget.Location = new System.Drawing.Point(4, 4);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Padding = new Padding(0, 0, 0, 6);
            this.panelTarget.Size = new Size(0x110, 0x2e);
            this.panelTarget.TabIndex = 20;
            this.buttonEditDataPath.Dock = DockStyle.Top;
            this.buttonEditDataPath.Enabled = false;
            this.buttonEditDataPath.Location = new System.Drawing.Point(0, 0x12);
            this.buttonEditDataPath.Name = "buttonEditDataPath";
            this.buttonEditDataPath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.buttonEditDataPath.Size = new Size(0x110, 0x15);
            this.buttonEditDataPath.TabIndex = 10;
            this.buttonEditDataPath.ButtonClick += new ButtonPressedEventHandler(this.buttonEditDataPath_ButtonClick);
            this.label2.BackColor = Color.Transparent;
            this.label2.Dock = DockStyle.Top;
            this.label2.ForeColor = Color.Navy;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x110, 0x12);
            this.label2.TabIndex = 8;
            this.label2.Text = "  栅格数据路径:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.groupControlXY.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.groupControlXY.Appearance.Options.UseBackColor = true;
            this.groupControlXY.Controls.Add(this.panel7);
            this.groupControlXY.Controls.Add(this.groupBox1);
            this.groupControlXY.Controls.Add(this.groupBox2);
            this.groupControlXY.Controls.Add(this.groupBox3);
            this.groupControlXY.Controls.Add(this.panel18);
            this.groupControlXY.Dock = DockStyle.Top;
            this.groupControlXY.Location = new System.Drawing.Point(4, 0x52);
            this.groupControlXY.Name = "groupControlXY";
            this.groupControlXY.Padding = new Padding(4);
            this.groupControlXY.Size = new Size(0x110, 0x1a2);
            this.groupControlXY.TabIndex = 0x15;
            this.groupControlXY.Text = "配准坐标";
            this.panel7.Controls.Add(this.ButtonCoordLocation);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.ButtonLocationClear);
            this.panel7.Dock = DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(6, 0x29d);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new Padding(9, 7, 7, 0);
            this.panel7.Size = new Size(260, 0x1f);
            this.panel7.TabIndex = 15;
            this.panel7.Visible = false;
            this.ButtonCoordLocation.Dock = DockStyle.Right;
            this.ButtonCoordLocation.ImageIndex = 10;
            this.ButtonCoordLocation.ImageList = this.imageList2;
            this.ButtonCoordLocation.ImageLocation = ImageLocation.MiddleCenter;
            this.ButtonCoordLocation.Location = new System.Drawing.Point(0xc5, 7);
            this.ButtonCoordLocation.Name = "ButtonCoordLocation";
            this.ButtonCoordLocation.Size = new Size(0x18, 0x18);
            this.ButtonCoordLocation.TabIndex = 11;
            this.ButtonCoordLocation.ToolTip = "定位";
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.White;
            this.imageList2.Images.SetKeyName(0, "PushMsgInfo.ico");
            this.imageList2.Images.SetKeyName(1, "sparkle.bmp");
            this.imageList2.Images.SetKeyName(2, "30.png");
            this.imageList2.Images.SetKeyName(3, "firepoint.bmp");
            this.imageList2.Images.SetKeyName(4, "43.png");
            this.imageList2.Images.SetKeyName(5, "2008113016515014.gif");
            this.imageList2.Images.SetKeyName(6, "2008113016515025.gif");
            this.imageList2.Images.SetKeyName(7, "page_world.png");
            this.imageList2.Images.SetKeyName(8, "pencil.png");
            this.imageList2.Images.SetKeyName(9, "5.png");
            this.imageList2.Images.SetKeyName(10, "9.png");
            this.imageList2.Images.SetKeyName(11, "bookmark.ico");
            this.imageList2.Images.SetKeyName(12, "border_draw.png");
            this.imageList2.Images.SetKeyName(13, "cursor_small.png");
            this.imageList2.Images.SetKeyName(14, "cut.png");
            this.imageList2.Images.SetKeyName(15, "cut_red.png");
            this.imageList2.Images.SetKeyName(0x10, "database_yellow.png");
            this.imageList2.Images.SetKeyName(0x11, "(1645).gif");
            this.imageList2.Images.SetKeyName(0x12, "(1636).gif");
            this.imageList2.Images.SetKeyName(0x13, "(1642).gif");
            this.imageList2.Images.SetKeyName(20, "(19,43).png");
            this.imageList2.Images.SetKeyName(0x15, "(47,17).png");
            this.imageList2.Images.SetKeyName(0x16, "(47,28).png");
            this.imageList2.Images.SetKeyName(0x17, "(15,40).png");
            this.panel8.Dock = DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(0xdd, 7);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(8, 0x18);
            this.panel8.TabIndex = 15;
            this.ButtonLocationClear.Dock = DockStyle.Right;
            this.ButtonLocationClear.ImageIndex = 0x16;
            this.ButtonLocationClear.ImageList = this.imageList2;
            this.ButtonLocationClear.ImageLocation = ImageLocation.MiddleCenter;
            this.ButtonLocationClear.Location = new System.Drawing.Point(0xe5, 7);
            this.ButtonLocationClear.Name = "ButtonLocationClear";
            this.ButtonLocationClear.Size = new Size(0x18, 0x18);
            this.ButtonLocationClear.TabIndex = 14;
            this.ButtonLocationClear.ToolTip = "清除定位点";
            this.groupBox1.Controls.Add(this.spinEdit2JY3);
            this.groupBox1.Controls.Add(this.spinEdit2JX3);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.spinEdit2JY2);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.spinEdit2JY1);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.spinEdit2JX2);
            this.groupBox1.Controls.Add(this.spinEdit2JX1);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.spinEditJY3);
            this.groupBox1.Controls.Add(this.spinEditJX3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.spinEditJY2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.spinEditJY1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.spinEditJX2);
            this.groupBox1.Controls.Add(this.spinEditJX1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 0x21d);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(260, 0x80);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标";
            this.groupBox1.Visible = false;
            int[] bits = new int[4];
            this.spinEdit2JY3.EditValue = new decimal(bits);
            this.spinEdit2JY3.Location = new System.Drawing.Point(0xb9, 0x66);
            this.spinEdit2JY3.Name = "spinEdit2JY3";
            this.spinEdit2JY3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits1 = new int[4];
            bits1[0] = 60;
            this.spinEdit2JY3.Properties.MaxValue = new decimal(bits1);
            this.spinEdit2JY3.Size = new Size(0x20, 0x15);
            this.spinEdit2JY3.TabIndex = 0x26;
            int[] bits2 = new int[4];
            this.spinEdit2JX3.EditValue = new decimal(bits2);
            this.spinEdit2JX3.Location = new System.Drawing.Point(0xb9, 0x4b);
            this.spinEdit2JX3.Name = "spinEdit2JX3";
            this.spinEdit2JX3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits3 = new int[4];
            bits3[0] = 60;
            this.spinEdit2JX3.Properties.MaxValue = new decimal(bits3);
            this.spinEdit2JX3.Size = new Size(0x20, 0x15);
            this.spinEdit2JX3.TabIndex = 30;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(0xda, 0x6a);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x13, 14);
            this.label22.TabIndex = 0x27;
            this.label22.Text = "秒";
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(0xa6, 0x6a);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x13, 14);
            this.label23.TabIndex = 0x25;
            this.label23.Text = "分";
            int[] bits4 = new int[4];
            this.spinEdit2JY2.EditValue = new decimal(bits4);
            this.spinEdit2JY2.Location = new System.Drawing.Point(0x86, 0x66);
            this.spinEdit2JY2.Name = "spinEdit2JY2";
            this.spinEdit2JY2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit2JY2.Properties.IsFloatValue = false;
            this.spinEdit2JY2.Properties.Mask.EditMask = "N00";
            int[] bits5 = new int[4];
            bits5[0] = 60;
            this.spinEdit2JY2.Properties.MaxValue = new decimal(bits5);
            this.spinEdit2JY2.Size = new Size(0x20, 0x15);
            this.spinEdit2JY2.TabIndex = 0x24;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(0x70, 0x6a);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x13, 14);
            this.label26.TabIndex = 0x23;
            this.label26.Text = "度";
            int[] bits6 = new int[4];
            this.spinEdit2JY1.EditValue = new decimal(bits6);
            this.spinEdit2JY1.Location = new System.Drawing.Point(0x44, 0x66);
            this.spinEdit2JY1.Name = "spinEdit2JY1";
            this.spinEdit2JY1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit2JY1.Properties.IsFloatValue = false;
            this.spinEdit2JY1.Properties.Mask.EditMask = "N00";
            int[] bits7 = new int[4];
            bits7[0] = 90;
            this.spinEdit2JY1.Properties.MaxValue = new decimal(bits7);
            this.spinEdit2JY1.Size = new Size(0x2a, 0x15);
            this.spinEdit2JY1.TabIndex = 0x22;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(0xda, 0x4f);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x13, 14);
            this.label27.TabIndex = 0x21;
            this.label27.Text = "秒";
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(0xa6, 0x4f);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x13, 14);
            this.label28.TabIndex = 0x20;
            this.label28.Text = "分";
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(0x70, 0x4f);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x13, 14);
            this.label29.TabIndex = 0x1f;
            this.label29.Text = "度";
            int[] bits8 = new int[4];
            this.spinEdit2JX2.EditValue = new decimal(bits8);
            this.spinEdit2JX2.Location = new System.Drawing.Point(0x86, 0x4b);
            this.spinEdit2JX2.Name = "spinEdit2JX2";
            this.spinEdit2JX2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit2JX2.Properties.IsFloatValue = false;
            this.spinEdit2JX2.Properties.Mask.EditMask = "N00";
            int[] bits9 = new int[4];
            bits9[0] = 60;
            this.spinEdit2JX2.Properties.MaxValue = new decimal(bits9);
            this.spinEdit2JX2.Size = new Size(0x20, 0x15);
            this.spinEdit2JX2.TabIndex = 0x1d;
            this.spinEdit2JX2.EditValueChanged += new EventHandler(this.spinEdit2JX2_EditValueChanged);
            int[] bits10 = new int[4];
            this.spinEdit2JX1.EditValue = new decimal(bits10);
            this.spinEdit2JX1.Location = new System.Drawing.Point(0x44, 0x4b);
            this.spinEdit2JX1.Name = "spinEdit2JX1";
            this.spinEdit2JX1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit2JX1.Properties.IsFloatValue = false;
            this.spinEdit2JX1.Properties.Mask.EditMask = "N00";
            this.spinEdit2JX1.Properties.MaxLength = 3;
            int[] bits11 = new int[4];
            bits11[0] = 180;
            this.spinEdit2JX1.Properties.MaxValue = new decimal(bits11);
            this.spinEdit2JX1.Size = new Size(0x2a, 0x15);
            this.spinEdit2JX1.TabIndex = 0x1c;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(0x15, 0x4e);
            this.label31.Name = "label31";
            this.label31.Size = new Size(50, 14);
            this.label31.TabIndex = 0x1a;
            this.label31.Text = "右上X：";
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(0x15, 0x69);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x33, 14);
            this.label33.TabIndex = 0x1b;
            this.label33.Text = "右上Y：";
            int[] bits12 = new int[4];
            this.spinEditJY3.EditValue = new decimal(bits12);
            this.spinEditJY3.Location = new System.Drawing.Point(0xb9, 0x30);
            this.spinEditJY3.Name = "spinEditJY3";
            this.spinEditJY3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits13 = new int[4];
            bits13[0] = 60;
            this.spinEditJY3.Properties.MaxValue = new decimal(bits13);
            this.spinEditJY3.Size = new Size(0x20, 0x15);
            this.spinEditJY3.TabIndex = 0x18;
            int[] bits14 = new int[4];
            this.spinEditJX3.EditValue = new decimal(bits14);
            this.spinEditJX3.Location = new System.Drawing.Point(0xb9, 0x15);
            this.spinEditJX3.Name = "spinEditJX3";
            this.spinEditJX3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits15 = new int[4];
            bits15[0] = 60;
            this.spinEditJX3.Properties.MaxValue = new decimal(bits15);
            this.spinEditJX3.Size = new Size(0x20, 0x15);
            this.spinEditJX3.TabIndex = 0x10;
            this.spinEditJX3.EditValueChanged += new EventHandler(this.spinEditJX3_EditValueChanged);
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0xda, 0x34);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x13, 14);
            this.label17.TabIndex = 0x19;
            this.label17.Text = "秒";
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0xa6, 0x34);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x13, 14);
            this.label16.TabIndex = 0x17;
            this.label16.Text = "分";
            int[] bits16 = new int[4];
            this.spinEditJY2.EditValue = new decimal(bits16);
            this.spinEditJY2.Location = new System.Drawing.Point(0x86, 0x30);
            this.spinEditJY2.Name = "spinEditJY2";
            this.spinEditJY2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditJY2.Properties.IsFloatValue = false;
            this.spinEditJY2.Properties.Mask.EditMask = "N00";
            int[] bits17 = new int[4];
            bits17[0] = 60;
            this.spinEditJY2.Properties.MaxValue = new decimal(bits17);
            this.spinEditJY2.Size = new Size(0x20, 0x15);
            this.spinEditJY2.TabIndex = 0x16;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(0x70, 0x34);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x13, 14);
            this.label15.TabIndex = 0x15;
            this.label15.Text = "度";
            int[] bits18 = new int[4];
            this.spinEditJY1.EditValue = new decimal(bits18);
            this.spinEditJY1.Location = new System.Drawing.Point(0x44, 0x30);
            this.spinEditJY1.Name = "spinEditJY1";
            this.spinEditJY1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditJY1.Properties.IsFloatValue = false;
            this.spinEditJY1.Properties.Mask.EditMask = "N00";
            int[] bits19 = new int[4];
            bits19[0] = 90;
            this.spinEditJY1.Properties.MaxValue = new decimal(bits19);
            this.spinEditJY1.Size = new Size(0x2a, 0x15);
            this.spinEditJY1.TabIndex = 20;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(0xda, 0x19);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x13, 14);
            this.label14.TabIndex = 0x13;
            this.label14.Text = "秒";
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0xa6, 0x19);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x13, 14);
            this.label13.TabIndex = 0x12;
            this.label13.Text = "分";
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0x70, 0x19);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x13, 14);
            this.label12.TabIndex = 0x11;
            this.label12.Text = "度";
            int[] bits20 = new int[4];
            this.spinEditJX2.EditValue = new decimal(bits20);
            this.spinEditJX2.Location = new System.Drawing.Point(0x86, 0x15);
            this.spinEditJX2.Name = "spinEditJX2";
            this.spinEditJX2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditJX2.Properties.IsFloatValue = false;
            this.spinEditJX2.Properties.Mask.EditMask = "N00";
            int[] bits21 = new int[4];
            bits21[0] = 60;
            this.spinEditJX2.Properties.MaxValue = new decimal(bits21);
            this.spinEditJX2.Size = new Size(0x20, 0x15);
            this.spinEditJX2.TabIndex = 15;
            this.spinEditJX2.EditValueChanged += new EventHandler(this.spinEditJX2_EditValueChanged);
            int[] bits22 = new int[4];
            this.spinEditJX1.EditValue = new decimal(bits22);
            this.spinEditJX1.Location = new System.Drawing.Point(0x44, 0x15);
            this.spinEditJX1.Name = "spinEditJX1";
            this.spinEditJX1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditJX1.Properties.IsFloatValue = false;
            this.spinEditJX1.Properties.Mask.EditMask = "N00";
            this.spinEditJX1.Properties.MaxLength = 3;
            int[] bits23 = new int[4];
            bits23[0] = 180;
            this.spinEditJX1.Properties.MaxValue = new decimal(bits23);
            this.spinEditJX1.Size = new Size(0x2a, 0x15);
            this.spinEditJX1.TabIndex = 14;
            this.spinEditJX1.UseWaitCursor = true;
            this.spinEditJX1.EditValueChanged += new EventHandler(this.spinEditJX1_EditValueChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0x15, 0x18);
            this.label10.Name = "label10";
            this.label10.Size = new Size(50, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "左下X：";
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0x15, 0x33);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x33, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "左下Y：";
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.spinEdit2JY);
            this.groupBox2.Controls.Add(this.spinEdit2JX);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.spinEditJY);
            this.groupBox2.Controls.Add(this.spinEditJX);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Dock = DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(6, 0x19d);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(260, 0x80);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标";
            this.groupBox2.Visible = false;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0xc0, 0x69);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x13, 14);
            this.label6.TabIndex = 0x19;
            this.label6.Text = "度";
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0xc0, 0x4e);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x13, 14);
            this.label7.TabIndex = 0x18;
            this.label7.Text = "度";
            int[] bits57 = new int[4];
            this.spinEdit2JY.EditValue = new decimal(bits57);
            this.spinEdit2JY.Location = new System.Drawing.Point(0x44, 0x66);
            this.spinEdit2JY.Name = "spinEdit2JY";
            this.spinEdit2JY.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits56 = new int[4];
            bits56[0] = 90;
            this.spinEdit2JY.Properties.MaxValue = new decimal(bits56);
            this.spinEdit2JY.Size = new Size(0x79, 0x15);
            this.spinEdit2JY.TabIndex = 0x17;
            int[] bits55 = new int[4];
            this.spinEdit2JX.EditValue = new decimal(bits55);
            this.spinEdit2JX.Location = new System.Drawing.Point(0x44, 0x4b);
            this.spinEdit2JX.Name = "spinEdit2JX";
            this.spinEdit2JX.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit2JX.Properties.MaxLength = 3;
            int[] bits54 = new int[4];
            bits54[0] = 180;
            this.spinEdit2JX.Properties.MaxValue = new decimal(bits54);
            this.spinEdit2JX.Size = new Size(0x79, 0x15);
            this.spinEdit2JX.TabIndex = 0x16;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0x15, 0x67);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x33, 14);
            this.label8.TabIndex = 0x15;
            this.label8.Text = "右上Y：";
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0x15, 0x4e);
            this.label9.Name = "label9";
            this.label9.Size = new Size(50, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "右上X：";
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(0xc0, 0x33);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x13, 14);
            this.label21.TabIndex = 0x13;
            this.label21.Text = "度";
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(0xc0, 0x18);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x13, 14);
            this.label20.TabIndex = 0x12;
            this.label20.Text = "度";
            int[] bits53 = new int[4];
            this.spinEditJY.EditValue = new decimal(bits53);
            this.spinEditJY.Location = new System.Drawing.Point(0x44, 0x30);
            this.spinEditJY.Name = "spinEditJY";
            this.spinEditJY.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] bits52  = new int[4];
            bits52[0] = 90;
            this.spinEditJY.Properties.MaxValue = new decimal(bits52);
            this.spinEditJY.Size = new Size(0x79, 0x15);
            this.spinEditJY.TabIndex = 0x10;
            int[] bits51 = new int[4];
            this.spinEditJX.EditValue = new decimal(bits51);
            this.spinEditJX.Location = new System.Drawing.Point(0x44, 0x15);
            this.spinEditJX.Name = "spinEditJX";
            this.spinEditJX.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditJX.Properties.MaxLength = 3;
            int[] bits50 = new int[4];
            bits50[0] = 180;
            this.spinEditJX.Properties.MaxValue = new decimal(bits50);
            this.spinEditJX.Size = new Size(0x79, 0x15);
            this.spinEditJX.TabIndex = 15;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(0x15, 0x31);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x33, 14);
            this.label19.TabIndex = 14;
            this.label19.Text = "左下Y：";
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0x15, 0x18);
            this.label18.Name = "label18";
            this.label18.Size = new Size(50, 14);
            this.label18.TabIndex = 13;
            this.label18.Text = "左下X：";
            this.groupBox3.Controls.Add(this.panel10);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Controls.Add(this.panel9);
            this.groupBox3.Controls.Add(this.label42);
            this.groupBox3.Dock = DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(6, 0x47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new Padding(0, 1, 0, 0);
            this.groupBox3.Size = new Size(260, 0x156);
            this.groupBox3.TabIndex = 0x27;
            this.panel10.Controls.Add(this.simpleButtonTLocation3);
            this.panel10.Controls.Add(this.simpleButtonTLocation2);
            this.panel10.Controls.Add(this.textDY3);
            this.panel10.Controls.Add(this.textDX3);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.textDY2);
            this.panel10.Controls.Add(this.textDX2);
            this.panel10.Controls.Add(this.simpleButtonTLocation);
            this.panel10.Controls.Add(this.textDY);
            this.panel10.Controls.Add(this.textDX);
            this.panel10.Controls.Add(this.simpleButtonTLocation0);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.textDY0);
            this.panel10.Controls.Add(this.textDX0);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.label24);
            this.panel10.Controls.Add(this.label25);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Controls.Add(this.label32);
            this.panel10.Controls.Add(this.label35);
            this.panel10.Controls.Add(this.label38);
            this.panel10.Controls.Add(this.label50);
            this.panel10.Controls.Add(this.label51);
            this.panel10.Dock = DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0xbd);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(260, 0x98);
            this.panel10.TabIndex = 40;
            this.simpleButtonTLocation3.Cursor = Cursors.Hand;
            this.simpleButtonTLocation3.Enabled = false;
            this.simpleButtonTLocation3.ImageIndex = 0x4a;
            this.simpleButtonTLocation3.ImageList = this.imageList3;
            this.simpleButtonTLocation3.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonTLocation3.Location = new System.Drawing.Point(0xe5, 0x83);
            this.simpleButtonTLocation3.Name = "simpleButtonTLocation3";
            this.simpleButtonTLocation3.Size = new Size(20, 20);
            this.simpleButtonTLocation3.TabIndex = 0x8d;
            this.simpleButtonTLocation3.ToolTip = "设置坐标系统";
            this.simpleButtonTLocation3.Visible = false;
            this.simpleButtonTLocation3.Click += new EventHandler(this.simpleButton1_Click);
            this.imageList3.ImageStream = (ImageListStreamer) resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "blank16.ico");
            this.imageList3.Images.SetKeyName(1, "tick16.ico");
            this.imageList3.Images.SetKeyName(2, "PART16.ICO");
            this.imageList3.Images.SetKeyName(3, "");
            this.imageList3.Images.SetKeyName(4, "");
            this.imageList3.Images.SetKeyName(5, "");
            this.imageList3.Images.SetKeyName(6, "");
            this.imageList3.Images.SetKeyName(7, "");
            this.imageList3.Images.SetKeyName(8, "");
            this.imageList3.Images.SetKeyName(9, "");
            this.imageList3.Images.SetKeyName(10, "");
            this.imageList3.Images.SetKeyName(11, "");
            this.imageList3.Images.SetKeyName(12, "");
            this.imageList3.Images.SetKeyName(13, "");
            this.imageList3.Images.SetKeyName(14, "");
            this.imageList3.Images.SetKeyName(15, "");
            this.imageList3.Images.SetKeyName(0x10, "(30,24).png");
            this.imageList3.Images.SetKeyName(0x11, "(00,02).png");
            this.imageList3.Images.SetKeyName(0x12, "(00,17).png");
            this.imageList3.Images.SetKeyName(0x13, "(00,46).png");
            this.imageList3.Images.SetKeyName(20, "(01,10).png");
            this.imageList3.Images.SetKeyName(0x15, "(01,25).png");
            this.imageList3.Images.SetKeyName(0x16, "(05,32).png");
            this.imageList3.Images.SetKeyName(0x17, "(06,32).png");
            this.imageList3.Images.SetKeyName(0x18, "(07,32).png");
            this.imageList3.Images.SetKeyName(0x19, "(08,32).png");
            this.imageList3.Images.SetKeyName(0x1a, "(08,36).png");
            this.imageList3.Images.SetKeyName(0x1b, "(09,36).png");
            this.imageList3.Images.SetKeyName(0x1c, "(10,26).png");
            this.imageList3.Images.SetKeyName(0x1d, "(11,26).png");
            this.imageList3.Images.SetKeyName(30, "(11,29).png");
            this.imageList3.Images.SetKeyName(0x1f, "(12,29).png");
            this.imageList3.Images.SetKeyName(0x20, "(11,32).png");
            this.imageList3.Images.SetKeyName(0x21, "(11,36).png");
            this.imageList3.Images.SetKeyName(0x22, "(13,32).png");
            this.imageList3.Images.SetKeyName(0x23, "(19,31).png");
            this.imageList3.Images.SetKeyName(0x24, "(22,18).png");
            this.imageList3.Images.SetKeyName(0x25, "(25,27).png");
            this.imageList3.Images.SetKeyName(0x26, "(29,43).png");
            this.imageList3.Images.SetKeyName(0x27, "(30,14).png");
            this.imageList3.Images.SetKeyName(40, "5.png");
            this.imageList3.Images.SetKeyName(0x29, "10.png");
            this.imageList3.Images.SetKeyName(0x2a, "11.png");
            this.imageList3.Images.SetKeyName(0x2b, "16.png");
            this.imageList3.Images.SetKeyName(0x2c, "17.png");
            this.imageList3.Images.SetKeyName(0x2d, "18.png");
            this.imageList3.Images.SetKeyName(0x2e, "19.png");
            this.imageList3.Images.SetKeyName(0x2f, "20.png");
            this.imageList3.Images.SetKeyName(0x30, "21.png");
            this.imageList3.Images.SetKeyName(0x31, "22.png");
            this.imageList3.Images.SetKeyName(50, "25.png");
            this.imageList3.Images.SetKeyName(0x33, "31.png");
            this.imageList3.Images.SetKeyName(0x34, "41.png");
            this.imageList3.Images.SetKeyName(0x35, "add.png");
            this.imageList3.Images.SetKeyName(0x36, "bullet_minus.png");
            this.imageList3.Images.SetKeyName(0x37, "control_add_blue.png");
            this.imageList3.Images.SetKeyName(0x38, "control_power_blue.png");
            this.imageList3.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.imageList3.Images.SetKeyName(0x3a, "cross.png");
            this.imageList3.Images.SetKeyName(0x3b, "down.png");
            this.imageList3.Images.SetKeyName(60, "draw_tools.png");
            this.imageList3.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.imageList3.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.imageList3.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.imageList3.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.imageList3.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.imageList3.Images.SetKeyName(0x42, "flag blue.png");
            this.imageList3.Images.SetKeyName(0x43, "flag red.png");
            this.imageList3.Images.SetKeyName(0x44, "flag yellow.png");
            this.imageList3.Images.SetKeyName(0x45, "31.png");
            this.imageList3.Images.SetKeyName(70, "42.png");
            this.imageList3.Images.SetKeyName(0x47, "control_add_blue.png");
            this.imageList3.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.imageList3.Images.SetKeyName(0x49, "cursor.png");
            this.imageList3.Images.SetKeyName(0x4a, "cursor_small.png");
            this.imageList3.Images.SetKeyName(0x4b, "cut.png");
            this.imageList3.Images.SetKeyName(0x4c, "cut_red.png");
            this.imageList3.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.imageList3.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.imageList3.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.imageList3.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.imageList3.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.imageList3.Images.SetKeyName(0x52, "key.png");
            this.imageList3.Images.SetKeyName(0x53, "page_add.png");
            this.imageList3.Images.SetKeyName(0x54, "page_delete.png");
            this.imageList3.Images.SetKeyName(0x55, "page_white_world.png");
            this.imageList3.Images.SetKeyName(0x56, "page_world.png");
            this.imageList3.Images.SetKeyName(0x57, "reload.png");
            this.imageList3.Images.SetKeyName(0x58, "world_add.png");
            this.imageList3.Images.SetKeyName(0x59, "world_delete.png");
            this.imageList3.Images.SetKeyName(90, "zoom_in.png");
            this.imageList3.Images.SetKeyName(0x5b, "zoom_out.png");
            this.imageList3.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.imageList3.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.imageList3.Images.SetKeyName(0x5e, "Exit.png");
            this.imageList3.Images.SetKeyName(0x5f, "langicon.gif");
            this.imageList3.Images.SetKeyName(0x60, "web.gif");
            this.imageList3.Images.SetKeyName(0x61, "profile.gif");
            this.simpleButtonTLocation2.Cursor = Cursors.Hand;
            this.simpleButtonTLocation2.Enabled = false;
            this.simpleButtonTLocation2.ImageIndex = 0x4a;
            this.simpleButtonTLocation2.ImageList = this.imageList3;
            this.simpleButtonTLocation2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonTLocation2.Location = new System.Drawing.Point(0xe5, 0x5d);
            this.simpleButtonTLocation2.Name = "simpleButtonTLocation2";
            this.simpleButtonTLocation2.Size = new Size(20, 20);
            this.simpleButtonTLocation2.TabIndex = 140;
            this.simpleButtonTLocation2.ToolTip = "设置坐标系统";
            this.simpleButtonTLocation2.Visible = false;
            this.simpleButtonTLocation2.Click += new EventHandler(this.simpleButton1_Click);
            this.textDY3.EditValue = "";
            this.textDY3.Location = new System.Drawing.Point(0x75, 0x83);
            this.textDY3.Name = "textDY3";
            this.textDY3.Properties.Appearance.ForeColor = Color.Black;
            this.textDY3.Properties.Appearance.Options.UseForeColor = true;
            this.textDY3.Size = new Size(0x6d, 0x15);
            this.textDY3.TabIndex = 0x89;
            this.textDX3.EditValue = "";
            this.textDX3.Location = new System.Drawing.Point(4, 0x83);
            this.textDX3.Name = "textDX3";
            this.textDX3.Properties.Appearance.ForeColor = Color.Black;
            this.textDX3.Properties.Appearance.Options.UseForeColor = true;
            this.textDX3.Size = new Size(0x6d, 0x15);
            this.textDX3.TabIndex = 0x88;
            this.label1.Location = new System.Drawing.Point(0x75, 0x74);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x34, 14);
            this.label1.TabIndex = 0x8b;
            this.label1.Text = "右下Y：";
            this.label3.Location = new System.Drawing.Point(3, 0x74);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x34, 14);
            this.label3.TabIndex = 0x8a;
            this.label3.Text = "右下X：";
            this.textDY2.EditValue = "";
            this.textDY2.Location = new System.Drawing.Point(0x75, 0x5d);
            this.textDY2.Name = "textDY2";
            this.textDY2.Properties.Appearance.ForeColor = Color.Black;
            this.textDY2.Properties.Appearance.Options.UseForeColor = true;
            this.textDY2.Size = new Size(0x6d, 0x15);
            this.textDY2.TabIndex = 0x87;
            this.textDX2.EditValue = "";
            this.textDX2.Location = new System.Drawing.Point(4, 0x5d);
            this.textDX2.Name = "textDX2";
            this.textDX2.Properties.Appearance.ForeColor = Color.Black;
            this.textDX2.Properties.Appearance.Options.UseForeColor = true;
            this.textDX2.Size = new Size(0x6d, 0x15);
            this.textDX2.TabIndex = 0x86;
            this.simpleButtonTLocation.Cursor = Cursors.Hand;
            this.simpleButtonTLocation.Enabled = false;
            this.simpleButtonTLocation.ImageIndex = 0x4a;
            this.simpleButtonTLocation.ImageList = this.imageList3;
            this.simpleButtonTLocation.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonTLocation.Location = new System.Drawing.Point(0xe5, 0x37);
            this.simpleButtonTLocation.Name = "simpleButtonTLocation";
            this.simpleButtonTLocation.Size = new Size(20, 20);
            this.simpleButtonTLocation.TabIndex = 130;
            this.simpleButtonTLocation.ToolTip = "设置坐标系统";
            this.simpleButtonTLocation.Visible = false;
            this.simpleButtonTLocation.Click += new EventHandler(this.simpleButton1_Click);
            this.textDY.EditValue = "";
            this.textDY.Location = new System.Drawing.Point(0x75, 0x37);
            this.textDY.Name = "textDY";
            this.textDY.Properties.Appearance.ForeColor = Color.Black;
            this.textDY.Properties.Appearance.Options.UseForeColor = true;
            this.textDY.Size = new Size(0x6d, 0x15);
            this.textDY.TabIndex = 0x85;
            this.textDX.EditValue = "";
            this.textDX.Location = new System.Drawing.Point(4, 0x37);
            this.textDX.Name = "textDX";
            this.textDX.Properties.Appearance.ForeColor = Color.Black;
            this.textDX.Properties.Appearance.Options.UseForeColor = true;
            this.textDX.Size = new Size(0x6d, 0x15);
            this.textDX.TabIndex = 0x84;
            this.simpleButtonTLocation0.Cursor = Cursors.Hand;
            this.simpleButtonTLocation0.Enabled = false;
            this.simpleButtonTLocation0.ImageIndex = 0x4a;
            this.simpleButtonTLocation0.ImageList = this.imageList3;
            this.simpleButtonTLocation0.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonTLocation0.Location = new System.Drawing.Point(0xe5, 0x11);
            this.simpleButtonTLocation0.Name = "simpleButtonTLocation0";
            this.simpleButtonTLocation0.Size = new Size(20, 20);
            this.simpleButtonTLocation0.TabIndex = 0x83;
            this.simpleButtonTLocation0.ToolTip = "设置坐标系统";
            this.simpleButtonTLocation0.Visible = false;
            this.simpleButtonTLocation0.Click += new EventHandler(this.simpleButton1_Click);
            this.label4.Location = new System.Drawing.Point(0x75, 2);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x34, 14);
            this.label4.TabIndex = 0x81;
            this.label4.Text = "左上 Y";
            this.textDY0.EditValue = "";
            this.textDY0.Location = new System.Drawing.Point(0x75, 0x11);
            this.textDY0.Name = "textDY0";
            this.textDY0.Properties.Appearance.ForeColor = Color.Black;
            this.textDY0.Properties.Appearance.Options.UseForeColor = true;
            this.textDY0.Size = new Size(0x6d, 0x15);
            this.textDY0.TabIndex = 0x80;
            this.textDX0.EditValue = "";
            this.textDX0.Location = new System.Drawing.Point(4, 0x11);
            this.textDX0.Name = "textDX0";
            this.textDX0.Properties.Appearance.ForeColor = Color.Black;
            this.textDX0.Properties.Appearance.Options.UseForeColor = true;
            this.textDX0.Size = new Size(0x6d, 0x15);
            this.textDX0.TabIndex = 0x7f;
            this.label5.Location = new System.Drawing.Point(4, 2);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x34, 14);
            this.label5.TabIndex = 0x7c;
            this.label5.Text = "左上 X";
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(0xc9, 2);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x13, 14);
            this.label24.TabIndex = 0x7d;
            this.label24.Text = "米";
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(0xc9, 40);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x13, 14);
            this.label25.TabIndex = 0x7e;
            this.label25.Text = "米";
            this.label30.Location = new System.Drawing.Point(4, 40);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x34, 14);
            this.label30.TabIndex = 0x76;
            this.label30.Text = "左下X：";
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(0xc9, 0x74);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x13, 14);
            this.label32.TabIndex = 0x7b;
            this.label32.Text = "米";
            this.label35.Location = new System.Drawing.Point(0x75, 40);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x34, 14);
            this.label35.TabIndex = 0x77;
            this.label35.Text = "左下Y：";
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(0xc9, 0x4e);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x13, 14);
            this.label38.TabIndex = 120;
            this.label38.Text = "米";
            this.label50.Location = new System.Drawing.Point(0x76, 0x4e);
            this.label50.Name = "label50";
            this.label50.Size = new Size(0x34, 14);
            this.label50.TabIndex = 0x7a;
            this.label50.Text = "右上Y：";
            this.label51.Location = new System.Drawing.Point(4, 0x4e);
            this.label51.Name = "label51";
            this.label51.Size = new Size(0x34, 14);
            this.label51.TabIndex = 0x79;
            this.label51.Text = "右上X：";
            this.label43.Dock = DockStyle.Top;
            this.label43.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.label43.Location = new System.Drawing.Point(0, 0xa9);
            this.label43.Name = "label43";
            this.label43.Size = new Size(260, 20);
            this.label43.TabIndex = 0x27;
            this.label43.Text = " 配准位置";
            this.label43.TextAlign = ContentAlignment.MiddleLeft;
            this.panel9.Controls.Add(this.simpleButtonLocation3);
            this.panel9.Controls.Add(this.simpleButtonLocation2);
            this.panel9.Controls.Add(this.textSDY3);
            this.panel9.Controls.Add(this.textSDX3);
            this.panel9.Controls.Add(this.label48);
            this.panel9.Controls.Add(this.label49);
            this.panel9.Controls.Add(this.textSDY2);
            this.panel9.Controls.Add(this.textSDX2);
            this.panel9.Controls.Add(this.simpleButtonLocation);
            this.panel9.Controls.Add(this.textSDY);
            this.panel9.Controls.Add(this.textSDX);
            this.panel9.Controls.Add(this.simpleButtonLocation0);
            this.panel9.Controls.Add(this.label45);
            this.panel9.Controls.Add(this.textSDY0);
            this.panel9.Controls.Add(this.textSDX0);
            this.panel9.Controls.Add(this.label44);
            this.panel9.Controls.Add(this.label46);
            this.panel9.Controls.Add(this.label47);
            this.panel9.Controls.Add(this.label41);
            this.panel9.Controls.Add(this.label34);
            this.panel9.Controls.Add(this.label40);
            this.panel9.Controls.Add(this.label39);
            this.panel9.Controls.Add(this.label36);
            this.panel9.Controls.Add(this.label37);
            this.panel9.Dock = DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0x11);
            this.panel9.Name = "panel9";
            this.panel9.Size = new Size(260, 0x98);
            this.panel9.TabIndex = 0x26;
            this.simpleButtonLocation3.Cursor = Cursors.Hand;
            this.simpleButtonLocation3.Enabled = false;
            this.simpleButtonLocation3.ImageIndex = 0x4a;
            this.simpleButtonLocation3.ImageList = this.imageList3;
            this.simpleButtonLocation3.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonLocation3.Location = new System.Drawing.Point(0xe4, 0x83);
            this.simpleButtonLocation3.Name = "simpleButtonLocation3";
            this.simpleButtonLocation3.Size = new Size(20, 20);
            this.simpleButtonLocation3.TabIndex = 0x75;
            this.simpleButtonLocation3.ToolTip = "设置坐标系统";
            this.simpleButtonLocation3.Visible = false;
            this.simpleButtonLocation3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButtonLocation2.Cursor = Cursors.Hand;
            this.simpleButtonLocation2.Enabled = false;
            this.simpleButtonLocation2.ImageIndex = 0x4a;
            this.simpleButtonLocation2.ImageList = this.imageList3;
            this.simpleButtonLocation2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonLocation2.Location = new System.Drawing.Point(0xe4, 0x5d);
            this.simpleButtonLocation2.Name = "simpleButtonLocation2";
            this.simpleButtonLocation2.Size = new Size(20, 20);
            this.simpleButtonLocation2.TabIndex = 0x74;
            this.simpleButtonLocation2.ToolTip = "设置坐标系统";
            this.simpleButtonLocation2.Visible = false;
            this.simpleButtonLocation2.Click += new EventHandler(this.simpleButton3_Click);
            this.textSDY3.EditValue = "";
            this.textSDY3.Location = new System.Drawing.Point(0x74, 0x83);
            this.textSDY3.Name = "textSDY3";
            this.textSDY3.Properties.Appearance.ForeColor = Color.Black;
            this.textSDY3.Properties.Appearance.Options.UseForeColor = true;
            this.textSDY3.Size = new Size(0x6d, 0x15);
            this.textSDY3.TabIndex = 0x71;
            this.textSDX3.EditValue = "";
            this.textSDX3.Location = new System.Drawing.Point(3, 0x83);
            this.textSDX3.Name = "textSDX3";
            this.textSDX3.Properties.Appearance.ForeColor = Color.Black;
            this.textSDX3.Properties.Appearance.Options.UseForeColor = true;
            this.textSDX3.Size = new Size(0x6d, 0x15);
            this.textSDX3.TabIndex = 0x70;
            this.label48.Location = new System.Drawing.Point(0x74, 0x74);
            this.label48.Name = "label48";
            this.label48.Size = new Size(0x34, 14);
            this.label48.TabIndex = 0x73;
            this.label48.Text = "右下Y：";
            this.label49.Location = new System.Drawing.Point(2, 0x74);
            this.label49.Name = "label49";
            this.label49.Size = new Size(0x34, 14);
            this.label49.TabIndex = 0x72;
            this.label49.Text = "右下X：";
            this.textSDY2.EditValue = "";
            this.textSDY2.Location = new System.Drawing.Point(0x74, 0x5d);
            this.textSDY2.Name = "textSDY2";
            this.textSDY2.Properties.Appearance.ForeColor = Color.Black;
            this.textSDY2.Properties.Appearance.Options.UseForeColor = true;
            this.textSDY2.Size = new Size(0x6d, 0x15);
            this.textSDY2.TabIndex = 0x6f;
            this.textSDX2.EditValue = "";
            this.textSDX2.Location = new System.Drawing.Point(3, 0x5d);
            this.textSDX2.Name = "textSDX2";
            this.textSDX2.Properties.Appearance.ForeColor = Color.Black;
            this.textSDX2.Properties.Appearance.Options.UseForeColor = true;
            this.textSDX2.Size = new Size(0x6d, 0x15);
            this.textSDX2.TabIndex = 110;
            this.simpleButtonLocation.Cursor = Cursors.Hand;
            this.simpleButtonLocation.Enabled = false;
            this.simpleButtonLocation.ImageIndex = 0x4a;
            this.simpleButtonLocation.ImageList = this.imageList3;
            this.simpleButtonLocation.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonLocation.Location = new System.Drawing.Point(0xe4, 0x37);
            this.simpleButtonLocation.Name = "simpleButtonLocation";
            this.simpleButtonLocation.Size = new Size(20, 20);
            this.simpleButtonLocation.TabIndex = 0x6a;
            this.simpleButtonLocation.ToolTip = "设置坐标系统";
            this.simpleButtonLocation.Visible = false;
            this.simpleButtonLocation.Click += new EventHandler(this.simpleButton3_Click);
            this.textSDY.EditValue = "";
            this.textSDY.Location = new System.Drawing.Point(0x74, 0x37);
            this.textSDY.Name = "textSDY";
            this.textSDY.Properties.Appearance.ForeColor = Color.Black;
            this.textSDY.Properties.Appearance.Options.UseForeColor = true;
            this.textSDY.Size = new Size(0x6d, 0x15);
            this.textSDY.TabIndex = 0x6d;
            this.textSDX.EditValue = "";
            this.textSDX.Location = new System.Drawing.Point(3, 0x37);
            this.textSDX.Name = "textSDX";
            this.textSDX.Properties.Appearance.ForeColor = Color.Black;
            this.textSDX.Properties.Appearance.Options.UseForeColor = true;
            this.textSDX.Size = new Size(0x6d, 0x15);
            this.textSDX.TabIndex = 0x6c;
            this.simpleButtonLocation0.Cursor = Cursors.Hand;
            this.simpleButtonLocation0.Enabled = false;
            this.simpleButtonLocation0.ImageIndex = 0x4a;
            this.simpleButtonLocation0.ImageList = this.imageList3;
            this.simpleButtonLocation0.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonLocation0.Location = new System.Drawing.Point(0xe4, 0x12);
            this.simpleButtonLocation0.Name = "simpleButtonLocation0";
            this.simpleButtonLocation0.Size = new Size(20, 20);
            this.simpleButtonLocation0.TabIndex = 0x6b;
            this.simpleButtonLocation0.ToolTip = "设置坐标系统";
            this.simpleButtonLocation0.Visible = false;
            this.simpleButtonLocation0.Click += new EventHandler(this.simpleButton3_Click);
            this.label45.Location = new System.Drawing.Point(0x74, 3);
            this.label45.Name = "label45";
            this.label45.Size = new Size(0x34, 14);
            this.label45.TabIndex = 0x2d;
            this.label45.Text = "左上 Y";
            this.textSDY0.EditValue = "";
            this.textSDY0.Location = new System.Drawing.Point(0x74, 0x12);
            this.textSDY0.Name = "textSDY0";
            this.textSDY0.Properties.Appearance.ForeColor = Color.Black;
            this.textSDY0.Properties.Appearance.Options.UseForeColor = true;
            this.textSDY0.Size = new Size(0x6d, 0x15);
            this.textSDY0.TabIndex = 0x2c;
            this.textSDX0.EditValue = "";
            this.textSDX0.Location = new System.Drawing.Point(3, 0x12);
            this.textSDX0.Name = "textSDX0";
            this.textSDX0.Properties.Appearance.ForeColor = Color.Black;
            this.textSDX0.Properties.Appearance.Options.UseForeColor = true;
            this.textSDX0.Size = new Size(0x6d, 0x15);
            this.textSDX0.TabIndex = 0x2b;
            this.label44.Location = new System.Drawing.Point(3, 3);
            this.label44.Name = "label44";
            this.label44.Size = new Size(0x34, 14);
            this.label44.TabIndex = 0x25;
            this.label44.Text = "左上 X";
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(200, 3);
            this.label46.Name = "label46";
            this.label46.Size = new Size(0x13, 14);
            this.label46.TabIndex = 0x29;
            this.label46.Text = "米";
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(200, 0x27);
            this.label47.Name = "label47";
            this.label47.Size = new Size(0x13, 14);
            this.label47.TabIndex = 0x2a;
            this.label47.Text = "米";
            this.label41.Location = new System.Drawing.Point(3, 40);
            this.label41.Name = "label41";
            this.label41.Size = new Size(0x34, 14);
            this.label41.TabIndex = 0x19;
            this.label41.Text = "左下X：";
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(200, 0x73);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x13, 14);
            this.label34.TabIndex = 0x24;
            this.label34.Text = "米";
            this.label40.Location = new System.Drawing.Point(0x74, 40);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x34, 14);
            this.label40.TabIndex = 0x1a;
            this.label40.Text = "左下Y：";
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(200, 0x4e);
            this.label39.Name = "label39";
            this.label39.Size = new Size(0x13, 14);
            this.label39.TabIndex = 0x1d;
            this.label39.Text = "米";
            this.label36.Location = new System.Drawing.Point(0x75, 0x4e);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x34, 14);
            this.label36.TabIndex = 0x20;
            this.label36.Text = "右上Y：";
            this.label37.Location = new System.Drawing.Point(3, 0x4e);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x34, 14);
            this.label37.TabIndex = 0x1f;
            this.label37.Text = "右上X：";
            this.label42.Dock = DockStyle.Top;
            this.label42.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.label42.Location = new System.Drawing.Point(0, 1);
            this.label42.Name = "label42";
            this.label42.Size = new Size(260, 0x10);
            this.label42.TabIndex = 0x25;
            this.label42.Text = " 原图位置";
            this.panel18.Controls.Add(this.radioGroup2);
            this.panel18.Controls.Add(this.panel5);
            this.panel18.Controls.Add(this.radioGroup);
            this.panel18.Dock = DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(6, 0x1b);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new Padding(0, 0, 0, 4);
            this.panel18.Size = new Size(260, 0x2c);
            this.panel18.TabIndex = 2;
            this.panel18.Visible = false;
            this.radioGroup2.Dock = DockStyle.Fill;
            this.radioGroup2.Enabled = false;
            this.radioGroup2.Location = new System.Drawing.Point(0x80, 0);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "度分秒"), new RadioGroupItem(null, "度") });
            this.radioGroup2.Size = new Size(0x84, 40);
            this.radioGroup2.TabIndex = 1;
            this.radioGroup2.SelectedIndexChanged += new EventHandler(this.radioGroup2_SelectedIndexChanged);
            this.panel5.Dock = DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0x7a, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(6, 40);
            this.panel5.TabIndex = 15;
            this.radioGroup.Dock = DockStyle.Left;
            this.radioGroup.Location = new System.Drawing.Point(0, 0);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "经纬度"), new RadioGroupItem(null, "大地坐标") });
            this.radioGroup.Size = new Size(0x7a, 40);
            this.radioGroup.TabIndex = 0;
            this.radioGroup.SelectedIndexChanged += new EventHandler(this.radioGroup_SelectedIndexChanged);
            this.radioGroup3.Dock = DockStyle.Fill;
            this.radioGroup3.Location = new System.Drawing.Point(0, 0);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "自动读取坐标点"), new RadioGroupItem(null, "手动设置坐标点") });
            this.radioGroup3.Size = new Size(0x110, 0x1a);
            this.radioGroup3.TabIndex = 0x10;
            this.radioGroup3.SelectedIndexChanged += new EventHandler(this.radioGroup3_SelectedIndexChanged);
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.simpleButtonPointsAdjust);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonRemove);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 0x245);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 6, 0, 6);
            this.panel6.Size = new Size(0x110, 0x26);
            this.panel6.TabIndex = 0x17;
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonOK.ImageIndex = 0x58;
            this.simpleButtonOK.ImageList = this.ImageList1;
            this.simpleButtonOK.Location = new System.Drawing.Point(14, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(60, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "添加";
            this.simpleButtonOK.ToolTip = "加载栅格数据";
            this.simpleButtonOK.Visible = false;
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
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
            this.ImageList1.Images.SetKeyName(0x45, "31.png");
            this.ImageList1.Images.SetKeyName(70, "42.png");
            this.ImageList1.Images.SetKeyName(0x47, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x49, "cursor.png");
            this.ImageList1.Images.SetKeyName(0x4a, "cursor_small.png");
            this.ImageList1.Images.SetKeyName(0x4b, "cut.png");
            this.ImageList1.Images.SetKeyName(0x4c, "cut_red.png");
            this.ImageList1.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.ImageList1.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.ImageList1.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x52, "key.png");
            this.ImageList1.Images.SetKeyName(0x53, "page_add.png");
            this.ImageList1.Images.SetKeyName(0x54, "page_delete.png");
            this.ImageList1.Images.SetKeyName(0x55, "page_white_world.png");
            this.ImageList1.Images.SetKeyName(0x56, "page_world.png");
            this.ImageList1.Images.SetKeyName(0x57, "reload.png");
            this.ImageList1.Images.SetKeyName(0x58, "world_add.png");
            this.ImageList1.Images.SetKeyName(0x59, "world_delete.png");
            this.ImageList1.Images.SetKeyName(90, "zoom_in.png");
            this.ImageList1.Images.SetKeyName(0x5b, "zoom_out.png");
            this.ImageList1.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.ImageList1.Images.SetKeyName(0x5e, "Exit.png");
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0x4a, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(6, 0x1a);
            this.panel2.TabIndex = 11;
            this.simpleButtonPointsAdjust.Dock = DockStyle.Right;
            this.simpleButtonPointsAdjust.Enabled = false;
            this.simpleButtonPointsAdjust.ImageIndex = 0x56;
            this.simpleButtonPointsAdjust.ImageList = this.ImageList1;
            this.simpleButtonPointsAdjust.Location = new System.Drawing.Point(80, 6);
            this.simpleButtonPointsAdjust.Name = "simpleButtonPointsAdjust";
            this.simpleButtonPointsAdjust.Size = new Size(60, 0x1a);
            this.simpleButtonPointsAdjust.TabIndex = 12;
            this.simpleButtonPointsAdjust.Text = "配准";
            this.simpleButtonPointsAdjust.ToolTip = "重新配准";
            this.simpleButtonPointsAdjust.Click += new EventHandler(this.simpleButtonPointsAdjust_Click);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(140, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(6, 0x1a);
            this.panel1.TabIndex = 13;
            this.simpleButtonRemove.Dock = DockStyle.Right;
            this.simpleButtonRemove.Enabled = false;
            this.simpleButtonRemove.ImageIndex = 0x59;
            this.simpleButtonRemove.ImageList = this.ImageList1;
            this.simpleButtonRemove.Location = new System.Drawing.Point(0x92, 6);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new Size(60, 0x1a);
            this.simpleButtonRemove.TabIndex = 15;
            this.simpleButtonRemove.Text = "移除";
            this.simpleButtonRemove.ToolTip = "移除栅格数据";
            this.simpleButtonRemove.Click += new EventHandler(this.simpleButtonRemove_Click);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(0xce, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(6, 0x1a);
            this.panel3.TabIndex = 14;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.Enabled = false;
            this.simpleButtonCancel.ImageIndex = 0x5e;
            this.simpleButtonCancel.ImageList = this.ImageList1;
            this.simpleButtonCancel.Location = new System.Drawing.Point(0xd4, 6);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(60, 0x1a);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "取消";
            this.groupControl1.Controls.Add(this.simpleButtonPoject);
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.Dock = DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(4, 0x1fa);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new Padding(6, 4, 4, 4);
            this.groupControl1.Size = new Size(0x110, 0x4b);
            this.groupControl1.TabIndex = 0x19;
            this.groupControl1.Text = "坐标系统";
            this.groupControl1.Visible = false;
            this.simpleButtonPoject.Cursor = Cursors.Hand;
            this.simpleButtonPoject.Enabled = false;
            this.simpleButtonPoject.ImageIndex = 0x61;
            this.simpleButtonPoject.ImageList = this.imageList3;
            this.simpleButtonPoject.Location = new System.Drawing.Point(0xaf, 0x20);
            this.simpleButtonPoject.Name = "simpleButtonPoject";
            this.simpleButtonPoject.Size = new Size(60, 0x1a);
            this.simpleButtonPoject.TabIndex = 0x67;
            this.simpleButtonPoject.Text = "设置";
            this.simpleButtonPoject.ToolTip = "设置坐标系统";
            this.simpleButtonPoject.Click += new EventHandler(this.simpleButtonPoject_Click);
            this.radioGroup1.Dock = DockStyle.Left;
            this.radioGroup1.Location = new System.Drawing.Point(8, 0x1b);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "当前地图坐标系"), new RadioGroupItem(null, "指定坐标系统") });
            this.radioGroup1.Size = new Size(0x8a, 0x2a);
            this.radioGroup1.TabIndex = 0x66;
            this.radioGroup1.SelectedIndexChanged += new EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 500);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x110, 6);
            this.panel4.TabIndex = 0x1a;
            this.labelInfo.Dock = DockStyle.Top;
            this.labelInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelInfo.ImageIndex = 0x5d;
            this.labelInfo.ImageList = this.imageList3;
            this.labelInfo.Location = new System.Drawing.Point(4, 0x26b);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(0x110, 30);
            this.labelInfo.TabIndex = 0x1b;
            this.labelInfo.Text = "    信息";
            this.labelInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.labelInfo.Visible = false;
            this.panel11.Controls.Add(this.radioGroup3);
            this.panel11.Dock = DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(4, 50);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new Padding(0, 0, 0, 6);
            this.panel11.Size = new Size(0x110, 0x20);
            this.panel11.TabIndex = 0x1c;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
     //       base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            base.Controls.Add(this.labelInfo);
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.groupControlXY);
            base.Controls.Add(this.panel11);
            base.Controls.Add(this.panelTarget);
            base.Name = "UserControlImageGeoReference";
            base.Padding = new Padding(4);
            base.Size = new Size(280, 0x314);
            this.panelTarget.ResumeLayout(false);
            this.buttonEditDataPath.Properties.EndInit();
            this.groupControlXY.EndInit();
            this.groupControlXY.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.spinEdit2JY3.Properties.EndInit();
            this.spinEdit2JX3.Properties.EndInit();
            this.spinEdit2JY2.Properties.EndInit();
            this.spinEdit2JY1.Properties.EndInit();
            this.spinEdit2JX2.Properties.EndInit();
            this.spinEdit2JX1.Properties.EndInit();
            this.spinEditJY3.Properties.EndInit();
            this.spinEditJX3.Properties.EndInit();
            this.spinEditJY2.Properties.EndInit();
            this.spinEditJY1.Properties.EndInit();
            this.spinEditJX2.Properties.EndInit();
            this.spinEditJX1.Properties.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.spinEdit2JY.Properties.EndInit();
            this.spinEdit2JX.Properties.EndInit();
            this.spinEditJY.Properties.EndInit();
            this.spinEditJX.Properties.EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.textDY3.Properties.EndInit();
            this.textDX3.Properties.EndInit();
            this.textDY2.Properties.EndInit();
            this.textDX2.Properties.EndInit();
            this.textDY.Properties.EndInit();
            this.textDX.Properties.EndInit();
            this.textDY0.Properties.EndInit();
            this.textDX0.Properties.EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.textSDY3.Properties.EndInit();
            this.textSDX3.Properties.EndInit();
            this.textSDY2.Properties.EndInit();
            this.textSDX2.Properties.EndInit();
            this.textSDY.Properties.EndInit();
            this.textSDX.Properties.EndInit();
            this.textSDY0.Properties.EndInit();
            this.textSDX0.Properties.EndInit();
            this.panel18.ResumeLayout(false);
            this.radioGroup2.Properties.EndInit();
            this.radioGroup.Properties.EndInit();
            this.radioGroup3.Properties.EndInit();
            this.panel6.ResumeLayout(false);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.radioGroup1.Properties.EndInit();
            this.panel11.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitialValue()
        {
            this.mSpatialReference = this.mHookHelper.FocusMap.SpatialReference;
            this.mRasterlayerList = new ArrayList();
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup.SelectedIndex == 0)
            {
                this.m_bCoor = false;
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
                this.radioGroup2.Enabled = true;
                this.groupControlXY.Height = (this.groupBox1.Top + this.groupBox1.Height) + 10;
            }
            else
            {
                this.m_bCoor = true;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = true;
                this.radioGroup2.Enabled = false;
                this.groupControlXY.Height = (this.groupBox3.Top + this.groupBox3.Height) + 2;
                this.simpleButtonLocation0.Visible = true;
                this.simpleButtonLocation0.Enabled = true;
                this.simpleButtonLocation.Visible = true;
                this.simpleButtonLocation.Enabled = true;
                this.simpleButtonLocation2.Visible = true;
                this.simpleButtonLocation2.Enabled = true;
                this.simpleButtonLocation3.Visible = true;
                this.simpleButtonLocation3.Enabled = true;
                this.simpleButtonTLocation0.Visible = true;
                this.simpleButtonTLocation0.Enabled = true;
                this.simpleButtonTLocation.Visible = true;
                this.simpleButtonTLocation.Enabled = true;
                this.simpleButtonTLocation2.Visible = true;
                this.simpleButtonTLocation2.Enabled = true;
                this.simpleButtonTLocation3.Visible = true;
                this.simpleButtonTLocation3.Enabled = true;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.simpleButtonPoject.Enabled = false;
            }
            else if (this.radioGroup1.SelectedIndex == 1)
            {
                this.simpleButtonPoject.Enabled = true;
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup2.SelectedIndex == 0)
            {
                if (this.m_bUnitD)
                {
                    double dX = this.DX;
                    double dY = this.DY;
                    int num3 = (int) Math.Floor(dX);
                    this.spinEditJX1.Text = string.Format("{0}", num3);
                    dX = (dX - num3) * 60.0;
                    num3 = (int) Math.Floor(dX);
                    this.spinEditJX2.Text = string.Format("{0}", num3);
                    dX = (dX - num3) * 60.0;
                    this.spinEditJX3.Text = string.Format("{0:F}", dX);
                    num3 = (int) Math.Floor(dY);
                    this.spinEditJY1.Text = string.Format("{0}", num3);
                    dY = (dY - num3) * 60.0;
                    num3 = (int) Math.Floor(dY);
                    this.spinEditJY2.Text = string.Format("{0}", num3);
                    dY = (dY - num3) * 60.0;
                    this.spinEditJY3.Text = string.Format("{0:F}", dY);
                }
                this.m_bUnitD = false;
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
            }
            else
            {
                if (!this.m_bUnitD)
                {
                    this.spinEditJX.Text = Convert.ToString((double) ((this.JD_DFM_D + (this.JD_DFM_F / 60.0)) + (this.JD_DFM_M / 3600.0)));
                    this.spinEditJY.Text = Convert.ToString((double) ((this.WD_DFM_D + (this.WD_DFM_F / 60.0)) + (this.WD_DFM_M / 3600.0)));
                }
                this.m_bUnitD = true;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = true;
                this.groupBox3.Visible = false;
            }
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup3.SelectedIndex == 0)
            {
                this.groupControlXY.Visible = false;
                this.groupControlXY.Height = (this.radioGroup3.Top + this.radioGroup3.Height) + 4;
                if (this.groupBox1.Visible)
                {
                    this.groupBox1.Enabled = false;
                }
                if (this.groupBox2.Visible)
                {
                    this.groupBox2.Enabled = false;
                }
                if (this.groupBox3.Visible)
                {
                    this.groupBox3.Enabled = false;
                }
            }
            else if (this.radioGroup3.SelectedIndex == 1)
            {
                this.groupControlXY.Visible = true;
                this.groupControlXY.Enabled = true;
                if (this.groupBox1.Visible)
                {
                    this.groupBox1.Enabled = true;
                    this.groupControlXY.Height = (this.groupBox1.Top + this.groupBox1.Height) + 4;
                }
                if (this.groupBox2.Visible)
                {
                    this.groupBox2.Enabled = true;
                    this.groupControlXY.Height = (this.groupBox2.Top + this.groupBox2.Height) + 4;
                }
                if (this.groupBox3.Visible)
                {
                    this.groupBox3.Enabled = true;
                    this.groupControlXY.Height = (this.groupBox3.Top + this.groupBox3.Height) + 4;
                }
            }
        }

        private void ReadValue()
        {
            try
            {
                if (this.mPoint != null)
                {
                    string s = "";
                    string str2 = "";
                    s = this.mPoint.X.ToString();
                    str2 = this.mPoint.Y.ToString();
                    if (this.radioGroup.SelectedIndex == 1)
                    {
                        if (this.m_pPointTool != null)
                        {
                            this.mCurTextX.Text = s;
                            this.mCurTextY.Text = str2;
                        }
                        else if (this.m_pPointTool2 != null)
                        {
                            this.mCurTextX.Text = s;
                            this.mCurTextY.Text = str2;
                        }
                    }
                    else
                    {
                        this.m_bCoor = false;
                        if (this.radioGroup2.SelectedIndex == 1)
                        {
                            if (this.m_pPointTool != null)
                            {
                                this.spinEditJX.Text = s;
                                this.spinEditJY.Text = str2;
                            }
                            else if (this.m_pPointTool2 != null)
                            {
                                this.spinEdit2JX.Text = s;
                                this.spinEdit2JY.Text = str2;
                            }
                        }
                        else
                        {
                            this.spinEditJX1.Text = int.Parse(s).ToString();
                            this.spinEditJY1.Text = int.Parse(str2).ToString();
                            this.spinEditJX2.Text = int.Parse(s).ToString();
                            this.spinEditJY2.Text = int.Parse(str2).ToString();
                            this.spinEditJX3.Text = int.Parse(s).ToString();
                            this.spinEditJY3.Text = int.Parse(str2).ToString();
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlImageGeoReference", "ReadValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((sender as SimpleButton).Name == "simpleButtonTLocation0")
            {
                this.mCurTextX = this.textDX0;
                this.mCurTextY = this.textDY0;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonTLocation")
            {
                this.mCurTextX = this.textDX;
                this.mCurTextY = this.textDY;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonTLocation2")
            {
                this.mCurTextX = this.textDX2;
                this.mCurTextY = this.textDY2;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonTLocation3")
            {
                this.mCurTextX = this.textDX3;
                this.mCurTextY = this.textDY3;
            }
            this.m_pPointTool2 = null;
            this.m_pPointTool = new PointTool();
            this.m_pPointTool.ParentForm = this;
            this.m_pPointTool.OnCreate(this.mHookHelper.Hook);
            try
            {
                IMapControl2 hook = null;
                hook = (IMapControl2) this.mHookHelper.Hook;
                hook.CurrentTool = this.m_pPointTool;
            }
            catch (Exception)
            {
                IPageLayoutControl2 control2 = null;
                control2 = (IPageLayoutControl2) this.mHookHelper.Hook;
                control2.CurrentTool = this.m_pPointTool;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.m_pPointTool = null;
            this.m_pPointTool3 = null;
            this.m_pPointTool4 = null;
            this.m_pPointTool2 = new PointTool();
            this.m_pPointTool2.ParentForm = this;
            this.m_pPointTool2.OnCreate(this.mHookHelper.Hook);
            try
            {
                IMapControl2 hook = null;
                hook = (IMapControl2) this.mHookHelper.Hook;
                hook.CurrentTool = this.m_pPointTool2;
            }
            catch (Exception)
            {
                IPageLayoutControl2 control2 = null;
                control2 = (IPageLayoutControl2) this.mHookHelper.Hook;
                control2.CurrentTool = this.m_pPointTool2;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if ((sender as SimpleButton).Name == "simpleButtonLocation0")
            {
                this.mCurTextX = this.textSDX0;
                this.mCurTextY = this.textSDY0;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonLocation")
            {
                this.mCurTextX = this.textSDX;
                this.mCurTextY = this.textSDY;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonLocation2")
            {
                this.mCurTextX = this.textSDX2;
                this.mCurTextY = this.textSDY2;
            }
            else if ((sender as SimpleButton).Name == "simpleButtonLocation3")
            {
                this.mCurTextX = this.textSDX3;
                this.mCurTextY = this.textSDY3;
            }
            this.m_pPointTool = null;
            this.m_pPointTool2 = new PointTool();
            this.m_pPointTool2.ParentForm = this;
            this.m_pPointTool2.OnCreate(this.mHookHelper.Hook);
            try
            {
                IMapControl2 hook = null;
                hook = (IMapControl2) this.mHookHelper.Hook;
                hook.CurrentTool = this.m_pPointTool2;
            }
            catch (Exception)
            {
                IPageLayoutControl2 control2 = null;
                control2 = (IPageLayoutControl2) this.mHookHelper.Hook;
                control2.CurrentTool = this.m_pPointTool2;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.m_pPointTool = null;
            this.m_pPointTool2 = null;
            this.m_pPointTool3 = null;
            this.m_pPointTool4 = new PointTool();
            this.m_pPointTool4.ParentForm = this;
            this.m_pPointTool4.OnCreate(this.mHookHelper.Hook);
            try
            {
                IMapControl2 hook = null;
                hook = (IMapControl2) this.mHookHelper.Hook;
                hook.CurrentTool = this.m_pPointTool4;
            }
            catch (Exception)
            {
                IPageLayoutControl2 control2 = null;
                control2 = (IPageLayoutControl2) this.mHookHelper.Hook;
                control2.CurrentTool = this.m_pPointTool4;
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (this.ImageGeoReference())
            {
                this.mHookHelper.ActiveView.Refresh();
                this.simpleButtonOK.Enabled = false;
                this.simpleButtonPointsAdjust.Enabled = true;
                this.simpleButtonRemove.Enabled = true;
            }
        }

        private void simpleButtonPointsAdjust_Click(object sender, EventArgs e)
        {
            this.ImageGeoReference();
            this.mHookHelper.ActiveView.Refresh();
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonPointsAdjust.Enabled = true;
            this.simpleButtonRemove.Enabled = true;
        }

        private void simpleButtonPoject_Click(object sender, EventArgs e)
        {
            FormSetSpatialreference spatialreference = new FormSetSpatialreference();
            this.mSpatialReference = this.mHookHelper.FocusMap.SpatialReference;
            spatialreference.InitialValue(this.mSpatialReference);
            spatialreference.ShowDialog();
            this.mSpatialReference = spatialreference.SpatialReference;
            this.mHookHelper.FocusMap.SpatialReference = this.mSpatialReference;
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            if (this.mRasterlayer != null)
            {
                this.mHookHelper.FocusMap.DeleteLayer(this.mRasterlayer);
                this.mHookHelper.ActiveView.Refresh();
            }
        }

        private void spinEdit2JX2_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void spinEditJX1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void spinEditJX2_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void spinEditJX3_EditValueChanged(object sender, EventArgs e)
        {
        }

        public double DX
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDX.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DX0
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDX0.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DX2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDX2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DX3
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDX3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DY
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDY.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DY0
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDY0.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DY2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDY2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double DY3
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.textDY3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_D
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEditJX1.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_D2
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEdit2JX1.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_F
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEditJX2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_F2
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEdit2JX2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_M
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEditJX3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JD_DFM_M2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEdit2JX3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JX
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEditJX.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JX2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEdit2JX.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JY
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEditJY.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double JY2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEdit2JY.Text);
                }
                catch
                {
                    return 0.0;
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

        public double WD_DFM_D
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEditJY1.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WD_DFM_D2
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEdit2JY1.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WD_DFM_F
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEditJY2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WD_DFM_F2
        {
            get
            {
                try
                {
                    return (double) Convert.ToInt16(this.spinEdit2JY2.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WD_DFM_M
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEditJY3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public double WD_DFM_M2
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEdit2JY3.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }
    }
}

