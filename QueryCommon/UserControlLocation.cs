namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FormBase;
    using FunFactory;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlLocation : UserControlBase1
    {
        private IPageLayoutControl3 _pageLayoutControl;
        private SimpleButton ButtonCoordLocation;
        private SimpleButton ButtonDistLocation;
        private SimpleButton ButtonLocationClear;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxLinban;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private ComboBoxEdit comboBoxXiaoBan;
        private IContainer components;
        public string DistCode;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupControl groupControlDist;
        private GroupControl groupControlXY;
        private ImageList imageList1;
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
        private Label label24;
        private Label label25;
        private Label label30;
        private Label label32;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelLocation;
        private bool m_bCoor;
        private bool m_bUnitD;
        private ITable m_CountyTable;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private IFeatureLayer m_pCLayer;
        private IRasterLayer m_pDEMLayer;
        private RectangleTool m_pEnvelopeTool;
        private IFeatureLayer m_pLBLayer;
        private PointTool m_pPointTool;
        private IFeatureLayer m_pTLayer;
        private IFeatureLayer m_pVLayer;
        private IFeatureLayer m_pXBLayer;
        private IFeatureLayer m_pXBLayer2;
        private ITable m_Table;
        private ITable m_Table2;
        private ITable m_Table3;
        private ITable m_TownTable;
        private ITable m_VillageTable;
        private Collection m_VisFeatureColn;
        private Collection m_VisLayerColn;
        private ArrayList m_XiaobanColn;
        private ArrayList m_XiaobanColn2;
        private ArrayList m_XiaobanColn22;
        private ArrayList m_XiaobanColn3;
        private ArrayList mCFList;
        private const string mClassName = "QueryAnalysic.UserControlLocation";
        private ArrayList mCList;
        private ArrayList mCList2;
        private DataRow mDataRow;
     //   private IDBAccess mDBAccess;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private IFeatureLayer mEditLayer;
        private IEnvelope mEnvelope;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mfWorkspace;
        private ITool mLastTool;
        private ArrayList mLList;
        private ArrayList mLList2;
        private bool mNodeExpend;
        private ArrayList mOtherLayerList;
        private ArrayList mOtherList;
        private string MountainFieldsName = "";
        private ArrayList mPlaceLayerList;
        private ArrayList mPlaceList;
        private IPoint mPoint;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mVList;
        private ArrayList mVList2;
        private ArrayList mXList;
        private ArrayList mXList2;
        private const string myClassName = "地图定位";
        private ArrayList mZLList;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel17;
        private Panel panel18;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelDistLocation;
        private Panel panLocation;
        private RadioGroup radioGroup;
        private RadioGroup radioGroup2;
        private string sCaiFaFieldString;
        private string sCaiFaFieldString2;
        private string sDistFieldCode;
        private string sDistFieldCode2;
        private string sDistFieldCode3;
        private string sDistFieldName;
        private string sDistFieldName2;
        private string sDistFieldName3;
        private string sDistLayerName;
        private string sDistLayerName2;
        private string sDistLayerName3;
        private string sGYLFieldString;
        private string sGYLFieldString2;
        private string sLinbanFieldName;
        private string sLinbanLayerName;
        private SpinEdit spinEditDX;
        private SpinEdit spinEditDY;
        private SpinEdit spinEditJX;
        private SpinEdit spinEditJX1;
        private SpinEdit spinEditJX2;
        private SpinEdit spinEditJX3;
        private SpinEdit spinEditJY;
        private SpinEdit spinEditJY1;
        private SpinEdit spinEditJY2;
        private SpinEdit spinEditJY3;
        private string sXiaobanFieldName;
        private string sXiaobanFieldString;
        private string sXiaobanLayerName;
        private string sXiaobanLayerName2;
        private string sZaoLinFieldString2;
        private string VillageFieldsName = "";
        private string XBCodeName = "";
        private string XBCodeName2 = "";

        public UserControlLocation()
        {
            this.InitializeComponent();
        }

        private void AddCoordMarker(double pX, double pY)
        {
            try
            {
                IDisplayTransformation transformation;
                ISpatialReference spatialReference = this.m_HookHelper.FocusMap.SpatialReference;
                IActiveView activeView = this.m_HookHelper.ActiveView;
                IPoint p = new PointClass();
                p.PutCoords(pX, pY);
                if (!this.m_bCoor)
                {
                    SpatialReferenceEnvironment environment = new SpatialReferenceEnvironmentClass();
                    ISpatialReference reference2 = environment.CreateGeographicCoordinateSystem(0x1076);
                    IGeometry geometry = p;
                    geometry.SpatialReference = reference2;
                    geometry.Project(spatialReference);
                }
                IEnvelope fullExtent = activeView.FullExtent;
                try
                {
                    if (((p.X >= fullExtent.XMin) && (p.X <= fullExtent.XMax)) && ((p.Y >= fullExtent.YMin) && (p.Y <= fullExtent.YMax)))
                    {
                        goto Label_00D3;
                    }
                    MessageBox.Show("坐标超出范围。请重新输入坐标后再定位。", "提示");
                }
                catch (Exception)
                {
                    MessageBox.Show("坐标超出范围。请重新输入坐标后再定位。", "提示");
                }
                return;
            Label_00D3:
                transformation = activeView.ScreenDisplay.DisplayTransformation;
                IEnvelope visibleBounds = transformation.VisibleBounds;
                IMarkerElement element = new MarkerElementClass();
                ISimpleMarkerSymbol symbol = new SimpleMarkerSymbolClass();
                symbol.Style = esriSimpleMarkerStyle.esriSMSCross;
                symbol.Size = 20.0;
                IRgbColor color = new RgbColorClass();
                color.RGB = 0xff;
                symbol.Color = color;
                element.Symbol = symbol;
                IElement element2 = (IElement) element;
                element2.Geometry = p;
                IGraphicsLayer basicGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer(this.m_HookHelper.FocusMap as IBasicMap, "<Default>");
                if (basicGraphicsLayer == null)
                {
                    IBasicMap focusMap = this.m_HookHelper.FocusMap as IBasicMap;
                    basicGraphicsLayer = focusMap.BasicGraphicsLayer;
                }
                ((IGraphicsContainer) basicGraphicsLayer).AddElement(element2, 0);
                visibleBounds.CenterAt(p);
                transformation.VisibleBounds = visibleBounds;
                activeView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "AddCoordMarker", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddLinbanNames()
        {
            try
            {
                this.comboBoxLinban.Properties.Items.Clear();
                this.comboBoxLinban.ResetText();
                this.comboBoxLinban.Properties.Items.Add("--");
                this.comboBoxXiaoBan.Properties.Items.Clear();
                this.comboBoxXiaoBan.ResetText();
                this.comboBoxXiaoBan.Properties.Items.Add("--");
                if (((this.m_pLBLayer != null) && ((this.comboBoxVillage.SelectedItem != null) && (this.comboBoxTown.SelectedItem != null))) && ((this.comboBoxVillage.SelectedItem != "--") && (this.comboBoxTown.SelectedItem != "--")))
                {
                    this.comboBoxVillage.SelectedItem.ToString();
                    IFeature feature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                    IGeometry shape = feature.Shape;
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.Geometry = shape;
                    filter.GeometryField = this.m_pLBLayer.FeatureClass.ShapeFieldName;
                    IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                    definition.PostfixClause = "ORDER BY LIN_BAN";
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    GC.Collect();
                    IFeatureCursor cursor = null;
                    cursor = this.m_pLBLayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                    this.mLList = new ArrayList();
                    this.mLList2 = new ArrayList();
                    while (feature != null)
                    {
                        int index = feature.Fields.FindField(this.sLinbanFieldName);
                        this.mLList.Add(feature.get_Value(index));
                        this.mLList2.Add(feature);
                        this.comboBoxLinban.Properties.Items.Add(feature.get_Value(index));
                        feature = cursor.NextFeature();
                    }
                    if (this.comboBoxLinban.Properties.Items.Count > 0)
                    {
                        this.comboBoxLinban.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "AddLinbanNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddTownNames()
        {
            try
            {
                this.comboBoxTown.Properties.Items.Clear();
                this.comboBoxTown.ResetText();
                this.comboBoxTown.Properties.Items.Add("--");
                this.comboBoxVillage.Properties.Items.Clear();
                this.comboBoxVillage.ResetText();
                this.comboBoxVillage.Properties.Items.Add("--");
                this.comboBoxLinban.Properties.Items.Clear();
                this.comboBoxLinban.ResetText();
                this.comboBoxLinban.Properties.Items.Add("--");
                this.comboBoxXiaoBan.Properties.Items.Clear();
                this.comboBoxXiaoBan.ResetText();
                this.comboBoxXiaoBan.Properties.Items.Add("--");
                if (((this.m_pTLayer != null) && (this.comboBoxCounty.SelectedItem != null)) && (this.comboBoxCounty.SelectedItem.ToString() != "--"))
                {
                    IFeature feature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                    int index = feature.Fields.FindField(this.sDistFieldName);
                    this.mTList = this.GetDistValues(this.m_pTLayer, this.sDistFieldName2, this.sDistFieldName + "='" + feature.get_Value(index).ToString() + "'", out this.mTList, out this.mTList2);
                    for (int i = 0; i < this.mTList.Count; i++)
                    {
                        this.comboBoxTown.Properties.Items.Add(this.mTList[i].ToString());
                    }
                    this.comboBoxTown.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "AddTownNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddVillageNames()
        {
            try
            {
                this.comboBoxVillage.Properties.Items.Clear();
                this.comboBoxVillage.ResetText();
                this.comboBoxVillage.Properties.Items.Add("--");
                this.comboBoxLinban.Properties.Items.Clear();
                this.comboBoxLinban.ResetText();
                this.comboBoxLinban.Properties.Items.Add("--");
                this.comboBoxXiaoBan.Properties.Items.Clear();
                this.comboBoxXiaoBan.ResetText();
                this.comboBoxXiaoBan.Properties.Items.Add("--");
                if ((this.m_pVLayer != null) && ((this.comboBoxCounty.SelectedItem != null) && (this.comboBoxTown.SelectedItem != null)))
                {
                    this.comboBoxCounty.SelectedItem.ToString();
                    if (this.comboBoxTown.SelectedItem.ToString() != "--")
                    {
                        IFeature feature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        int index = feature.Fields.FindField(this.sDistFieldName2);
                        this.mVList = this.GetDistValues(this.m_pVLayer, this.sDistFieldName3, this.sDistFieldName2 + "='" + feature.get_Value(index).ToString() + "'", out this.mVList, out this.mVList2);
                        for (int i = 0; i < this.mVList.Count; i++)
                        {
                            this.comboBoxVillage.Properties.Items.Add(this.mVList[i].ToString());
                        }
                        this.comboBoxVillage.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "AddVillageNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddXiaobanNames()
        {
            try
            {
                this.comboBoxXiaoBan.Properties.Items.Clear();
                this.comboBoxXiaoBan.ResetText();
                this.comboBoxXiaoBan.Properties.Items.Add("--");
                if (((this.m_pXBLayer != null) && (this.comboBoxLinban.SelectedItem != null)) && (this.comboBoxLinban.SelectedItem != "--"))
                {
                    IFeature feature = this.mLList2[this.comboBoxLinban.SelectedIndex - 1] as IFeature;
                    IGeometry shape = feature.Shape;
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.Geometry = shape;
                    filter.GeometryField = this.m_pXBLayer.FeatureClass.ShapeFieldName;
                    IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                    definition.PostfixClause = "ORDER BY XIAO_BAN";
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    GC.Collect();
                    IFeatureCursor cursor = null;
                    cursor = this.m_pXBLayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                    this.mXList = new ArrayList();
                    this.mXList2 = new ArrayList();
                    while (feature != null)
                    {
                        int index = feature.Fields.FindField(this.XBCodeName);
                        this.mXList.Add(feature.get_Value(index));
                        this.mXList2.Add(feature);
                        this.comboBoxXiaoBan.Properties.Items.Add(feature.get_Value(index));
                        feature = cursor.NextFeature();
                    }
                    if (this.comboBoxXiaoBan.Properties.Items.Count > 0)
                    {
                        this.comboBoxXiaoBan.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "AddXiaobanNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonCoordLocation_Click(object sender, EventArgs e)
        {
            try
            {
                double dX;
                double dY;
                if (this.radioGroup.SelectedIndex == 1)
                {
                    this.m_bCoor = true;
                    dX = this.DX;
                    dY = this.DY;
                }
                else
                {
                    this.m_bCoor = false;
                    if (this.radioGroup2.SelectedIndex == 1)
                    {
                        dX = this.JX;
                        dY = this.JY;
                    }
                    else
                    {
                        dX = (this.JD_DFM_D + (this.JD_DFM_F / 60.0)) + (this.JD_DFM_M / 3600.0);
                        dY = (this.WD_DFM_D + (this.WD_DFM_F / 60.0)) + (this.WD_DFM_M / 3600.0);
                    }
                }
                this.AddCoordMarker(dX, dY);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "ButtonCoordLocation_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonDistLocation_Click(object sender, EventArgs e)
        {
            try
            {
                IFeatureLayer data = null;
                IFeature pFeature = null;
                if (this.comboBoxCounty.SelectedIndex == 0)
                {
                    this.m_HookHelper.ActiveView.Extent = this.m_HookHelper.ActiveView.FullExtent;
                }
                else
                {
                    if (this.comboBoxTown.SelectedIndex == 0)
                    {
                        this.comboBoxCounty.SelectedItem.ToString();
                        pFeature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                        data = this.m_pCLayer;
                    }
                    else if (this.comboBoxVillage.SelectedIndex == 0)
                    {
                        this.comboBoxTown.SelectedItem.ToString();
                        pFeature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        data = this.m_pTLayer;
                    }
                    else if (this.comboBoxLinban.SelectedIndex == 0)
                    {
                        this.comboBoxVillage.SelectedItem.ToString();
                        pFeature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                        data = this.m_pVLayer;
                    }
                    else if (this.comboBoxXiaoBan.SelectedIndex == 0)
                    {
                        pFeature = this.mLList2[this.comboBoxLinban.SelectedIndex - 1] as IFeature;
                        data = this.m_pLBLayer;
                    }
                    else if ((this.comboBoxXiaoBan.SelectedIndex != -1) && (this.comboBoxXiaoBan.SelectedIndex != 0))
                    {
                        this.comboBoxXiaoBan.SelectedItem.ToString();
                        pFeature = this.mXList2[this.comboBoxXiaoBan.SelectedIndex - 1] as IFeature;
                        data = this.m_pXBLayer;
                    }
                    else if ((this.comboBoxLinban.SelectedIndex != -1) && (this.comboBoxLinban.SelectedIndex != 0))
                    {
                        this.comboBoxLinban.SelectedItem.ToString();
                        pFeature = this.mLList2[this.comboBoxLinban.SelectedIndex - 1] as IFeature;
                        data = this.m_pLBLayer;
                    }
                    else if ((this.comboBoxVillage.SelectedIndex != -1) && (this.comboBoxVillage.SelectedIndex != 0))
                    {
                        this.comboBoxVillage.SelectedItem.ToString();
                        pFeature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                        data = this.m_pVLayer;
                    }
                    else if (this.comboBoxTown.SelectedIndex != -1)
                    {
                        this.comboBoxTown.SelectedItem.ToString();
                        pFeature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        data = this.m_pTLayer;
                    }
                    else if (this.comboBoxCounty.SelectedIndex != -1)
                    {
                        this.comboBoxCounty.SelectedItem.ToString();
                        pFeature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                        data = this.m_pCLayer;
                    }
                    else
                    {
                        data = null;
                    }
                    if (pFeature != null)
                    {
                        if (!data.Visible)
                        {
                            data.Visible = true;
                            this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, data, this.m_HookHelper.ActiveView.Extent);
                            for (int i = 0; i < 0x2710; i++)
                            {
                            }
                        }
                        this.SelectFeature(data, pFeature);
                        this.ZoomToFeature(this.m_HookHelper.FocusMap, data, pFeature);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "ButtonDistLocation_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonLocationClear_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView activeView = this.m_HookHelper.ActiveView;
                IGraphicsLayer basicGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer(this.m_HookHelper.FocusMap as IBasicMap, "<Default>");
                if (basicGraphicsLayer == null)
                {
                    IBasicMap focusMap = this.m_HookHelper.FocusMap as IBasicMap;
                    basicGraphicsLayer = focusMap.BasicGraphicsLayer;
                }
                if (basicGraphicsLayer != null)
                {
                    ((IGraphicsContainer) basicGraphicsLayer).DeleteAllElements();
                    activeView.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "ButtonLocationClear_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void comboBoxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = this.comboBoxCounty.SelectedItem.ToString().Trim(new char[] { '-' });
                if (this._pageLayoutControl != null)
                {
                    this._pageLayoutControl.CustomProperty = str;
                }
                this.AddTownNames();
                if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
                {
                    IFeature feature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                    int index = feature.Fields.FindField(this.sDistFieldCode);
                    if (index > -1)
                    {
                        this.DistCode = feature.get_Value(index).ToString();
                    }
                }
                else if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex == 0))
                {
                    this.DistCode = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void comboBoxLinban_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AddXiaobanNames();
        }

        private void comboBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = this.comboBoxTown.SelectedItem.ToString().Trim(new char[] { '-' });
                if ((str != "") && (this._pageLayoutControl != null))
                {
                    this._pageLayoutControl.CustomProperty = str;
                }
                this.AddVillageNames();
                if ((this.mTList2 != null) && (this.comboBoxTown.SelectedIndex > 0))
                {
                    IFeature feature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                    int index = feature.Fields.FindField(this.sDistFieldCode2);
                    if (index > -1)
                    {
                        this.DistCode = feature.get_Value(index).ToString();
                    }
                }
                else if ((this.mTList2 != null) && (this.comboBoxTown.SelectedIndex == 0))
                {
                    this.DistCode = "";
                    if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
                    {
                        IFeature feature2 = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                        int num2 = feature2.Fields.FindField(this.sDistFieldCode);
                        if (num2 > -1)
                        {
                            this.DistCode = feature2.get_Value(num2).ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxVillage.SelectedItem.ToString().Trim(new char[] { '-' });
            if ((str != "") && (this._pageLayoutControl != null))
            {
                this._pageLayoutControl.CustomProperty = str;
            }
            this.AddLinbanNames();
            if ((this.mVList2 != null) && (this.comboBoxVillage.SelectedIndex > 0))
            {
                IFeature feature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                int index = feature.Fields.FindField(this.sDistFieldCode3);
                if (index > -1)
                {
                    this.DistCode = feature.get_Value(index).ToString();
                }
            }
            else if ((this.mVList2 != null) && (this.comboBoxVillage.SelectedIndex == 0))
            {
                this.DistCode = "";
                if ((this.mTList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
                {
                    IFeature feature2 = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                    int num2 = feature2.Fields.FindField(this.sDistFieldCode2);
                    if (num2 > -1)
                    {
                        this.DistCode = feature2.get_Value(num2).ToString();
                    }
                }
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

        private ArrayList GetDistValues(IFeatureLayer pFLayer, string FieldName, string WhereString, out ArrayList list, out ArrayList list2)
        {
            list = new ArrayList();
            list2 = new ArrayList();
            try
            {
                pFLayer.FeatureClass.FeatureCount(null);
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = WhereString;
                IFeatureCursor cursor = pFLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                string name = FieldName;
                int index = feature.Fields.FindField(name);
                string str2 = "";
                while (feature != null)
                {
                    if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        str2 = "";
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                            long num2 = Convert.ToInt64(feature.get_Value(index));
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (num2 == Convert.ToInt64(domain.get_Value(i)))
                                {
                                    str2 = domain.get_Name(i);
                                    goto Label_0113;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            str2 = feature.get_Value(index).ToString();
                        }
                    }
                    else
                    {
                        str2 = feature.get_Value(index).ToString();
                    }
                Label_0113:
                    list.Add(str2);
                    list2.Add(feature);
                    feature = cursor.NextFeature();
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public IArray GetUniqueValues(IFeatureLayer pFLayer, string FieldName)
        {
            try
            {
                IArray array = new ArrayClass();
                if (pFLayer != null)
                {
                    ICursor cursor;
                    IFeatureClass featureClass = pFLayer.FeatureClass;
                    if (featureClass != null)
                    {
                        cursor = (ICursor) featureClass.Search(null, false);
                    }
                    else
                    {
                        cursor = pFLayer.Search(null, false) as ICursor;
                    }
                    IDataStatistics statistics = new DataStatisticsClass();
                    statistics.Field = FieldName;
                    statistics.Cursor = cursor;
                    IEnumerator uniqueValues = statistics.UniqueValues;
                    uniqueValues.Reset();
                    while (uniqueValues.MoveNext())
                    {
                        array.Add(uniqueValues.Current);
                    }
                }
                return array;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "GetUniqueValues", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void groupControlXY_Paint(object sender, PaintEventArgs e)
        {
        }

        private void InitCoordControl()
        {
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
            this.m_bCoor = false;
            this.m_bUnitD = false;
        }

        private void InitDistList()
        {
            try
            {
                if (this.m_pCLayer != null)
                {
                    this.mCList = this.GetDistValues(this.m_pCLayer, this.sDistFieldName, "", out this.mCList, out this.mCList2);
                    this.comboBoxCounty.Properties.Items.Clear();
                    this.comboBoxTown.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxCounty.Properties.Items.Add("--");
                    for (int i = 0; i < this.mCList.Count; i++)
                    {
                        this.comboBoxCounty.Properties.Items.Add(this.mCList[i].ToString());
                    }
                    if (EditTask.DistCode != "")
                    {
                        for (int j = 0; j < this.mCList2.Count; j++)
                        {
                            IFeature feature = this.mCList2[j] as IFeature;
                            int index = feature.Fields.FindField(this.sDistFieldCode);
                            if (feature.get_Value(index).ToString() == EditTask.DistCode.Substring(0, 6))
                            {
                                this.comboBoxCounty.SelectedIndex = j + 1;
                                this.AddTownNames();
                                if (EditTask.DistCode.Length == 9)
                                {
                                    for (int k = 0; k < this.mTList2.Count; k++)
                                    {
                                        IFeature feature2 = this.mTList2[k] as IFeature;
                                        int num5 = feature2.Fields.FindField(this.sDistFieldCode2);
                                        if (feature2.get_Value(num5).ToString() == EditTask.DistCode.Substring(0, 9))
                                        {
                                            this.comboBoxTown.SelectedIndex = k + 1;
                                        }
                                        this.AddVillageNames();
                                    }
                                }
                                return;
                            }
                        }
                    }
                    else
                    {
                        this.comboBoxCounty.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "InitDistList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialControls(string sEditKind, bool bDistLocate)
        {
            this.mEditKind = sEditKind;
            this.groupControlDist.Visible = bDistLocate;
            this.panel17.Visible = bDistLocate;
            this.InitLayers();
            this.InitDistList();
            this.InitCoordControl();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlLocation));
            this.labelLocation = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panLocation = new System.Windows.Forms.Panel();
            this.groupControlXY = new DevExpress.XtraEditors.GroupControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ButtonCoordLocation = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ButtonLocationClear = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spinEditJY3 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditJX3 = new DevExpress.XtraEditors.SpinEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.spinEditJY2 = new DevExpress.XtraEditors.SpinEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.spinEditJY1 = new DevExpress.XtraEditors.SpinEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.spinEditJX2 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditJX1 = new DevExpress.XtraEditors.SpinEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.spinEditJY = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditJX = new DevExpress.XtraEditors.SpinEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.spinEditDY = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditDX = new DevExpress.XtraEditors.SpinEdit();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxXiaoBan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBoxLinban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.ButtonDistLocation = new DevExpress.XtraEditors.SimpleButton();
            this.panLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlXY)).BeginInit();
            this.groupControlXY.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDX.Properties)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
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
            this.labelLocation.Size = new System.Drawing.Size(280, 30);
            this.labelLocation.TabIndex = 15;
            this.labelLocation.Text = "      地图定位          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(6, 188);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(268, 10);
            this.panel17.TabIndex = 16;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.White;
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
            this.imageList2.Images.SetKeyName(16, "database_yellow.png");
            this.imageList2.Images.SetKeyName(17, "(1645).gif");
            this.imageList2.Images.SetKeyName(18, "(1636).gif");
            this.imageList2.Images.SetKeyName(19, "(1642).gif");
            this.imageList2.Images.SetKeyName(20, "(19,43).png");
            this.imageList2.Images.SetKeyName(21, "(47,17).png");
            this.imageList2.Images.SetKeyName(22, "(47,28).png");
            this.imageList2.Images.SetKeyName(23, "(15,40).png");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "Fault.bmp");
            this.imageList3.Images.SetKeyName(1, "4.bmp");
            this.imageList3.Images.SetKeyName(2, "2_.bmp");
            this.imageList3.Images.SetKeyName(3, "2__.bmp");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2008113016515014.gif");
            this.imageList1.Images.SetKeyName(1, "2008113016515025.gif");
            this.imageList1.Images.SetKeyName(2, "ArcView_select_none.bmp");
            this.imageList1.Images.SetKeyName(3, "ArcView_select_all.bmp");
            this.imageList1.Images.SetKeyName(4, "2008113016514232.gif");
            // 
            // panLocation
            // 
            this.panLocation.BackColor = System.Drawing.Color.Transparent;
            this.panLocation.Controls.Add(this.groupControlXY);
            this.panLocation.Controls.Add(this.panel17);
            this.panLocation.Controls.Add(this.groupControlDist);
            this.panLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLocation.Location = new System.Drawing.Point(0, 30);
            this.panLocation.Name = "panLocation";
            this.panLocation.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.panLocation.Size = new System.Drawing.Size(280, 570);
            this.panLocation.TabIndex = 16;
            // 
            // groupControlXY
            // 
            this.groupControlXY.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlXY.Appearance.Options.UseBackColor = true;
            this.groupControlXY.Controls.Add(this.panel7);
            this.groupControlXY.Controls.Add(this.groupBox1);
            this.groupControlXY.Controls.Add(this.groupBox2);
            this.groupControlXY.Controls.Add(this.groupBox3);
            this.groupControlXY.Controls.Add(this.panel18);
            this.groupControlXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlXY.Location = new System.Drawing.Point(6, 198);
            this.groupControlXY.Name = "groupControlXY";
            this.groupControlXY.Size = new System.Drawing.Size(268, 366);
            this.groupControlXY.TabIndex = 15;
            this.groupControlXY.Text = "坐标定位";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ButtonCoordLocation);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.ButtonLocationClear);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(2, 332);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(9, 7, 7, 0);
            this.panel7.Size = new System.Drawing.Size(264, 31);
            this.panel7.TabIndex = 15;
            // 
            // ButtonCoordLocation
            // 
            this.ButtonCoordLocation.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonCoordLocation.ImageIndex = 10;
            this.ButtonCoordLocation.ImageList = this.imageList2;
            this.ButtonCoordLocation.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonCoordLocation.Location = new System.Drawing.Point(201, 7);
            this.ButtonCoordLocation.Name = "ButtonCoordLocation";
            this.ButtonCoordLocation.Size = new System.Drawing.Size(24, 24);
            this.ButtonCoordLocation.TabIndex = 11;
            this.ButtonCoordLocation.ToolTip = "定位";
            this.ButtonCoordLocation.Click += new System.EventHandler(this.ButtonCoordLocation_Click);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(225, 7);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(8, 24);
            this.panel8.TabIndex = 15;
            // 
            // ButtonLocationClear
            // 
            this.ButtonLocationClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonLocationClear.ImageIndex = 22;
            this.ButtonLocationClear.ImageList = this.imageList2;
            this.ButtonLocationClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonLocationClear.Location = new System.Drawing.Point(233, 7);
            this.ButtonLocationClear.Name = "ButtonLocationClear";
            this.ButtonLocationClear.Size = new System.Drawing.Size(24, 24);
            this.ButtonLocationClear.TabIndex = 14;
            this.ButtonLocationClear.ToolTip = "清除定位点";
            this.ButtonLocationClear.Click += new System.EventHandler(this.ButtonLocationClear_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 80);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标";
            // 
            // spinEditJY3
            // 
            this.spinEditJY3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJY3.Location = new System.Drawing.Point(181, 50);
            this.spinEditJY3.Name = "spinEditJY3";
            this.spinEditJY3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJY3.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEditJY3.Size = new System.Drawing.Size(42, 20);
            this.spinEditJY3.TabIndex = 24;
            // 
            // spinEditJX3
            // 
            this.spinEditJX3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJX3.Location = new System.Drawing.Point(181, 20);
            this.spinEditJX3.Name = "spinEditJX3";
            this.spinEditJX3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJX3.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEditJX3.Size = new System.Drawing.Size(42, 20);
            this.spinEditJX3.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(224, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 14);
            this.label17.TabIndex = 25;
            this.label17.Text = "秒";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(160, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 14);
            this.label16.TabIndex = 23;
            this.label16.Text = "分";
            // 
            // spinEditJY2
            // 
            this.spinEditJY2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJY2.Location = new System.Drawing.Point(116, 50);
            this.spinEditJY2.Name = "spinEditJY2";
            this.spinEditJY2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJY2.Properties.IsFloatValue = false;
            this.spinEditJY2.Properties.Mask.EditMask = "N00";
            this.spinEditJY2.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEditJY2.Size = new System.Drawing.Size(42, 20);
            this.spinEditJY2.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(94, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 14);
            this.label15.TabIndex = 21;
            this.label15.Text = "度";
            // 
            // spinEditJY1
            // 
            this.spinEditJY1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJY1.Location = new System.Drawing.Point(37, 50);
            this.spinEditJY1.Name = "spinEditJY1";
            this.spinEditJY1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJY1.Properties.IsFloatValue = false;
            this.spinEditJY1.Properties.Mask.EditMask = "N00";
            this.spinEditJY1.Properties.MaxValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.spinEditJY1.Size = new System.Drawing.Size(56, 20);
            this.spinEditJY1.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 14);
            this.label14.TabIndex = 19;
            this.label14.Text = "秒";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 14);
            this.label13.TabIndex = 18;
            this.label13.Text = "分";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(94, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 14);
            this.label12.TabIndex = 17;
            this.label12.Text = "度";
            // 
            // spinEditJX2
            // 
            this.spinEditJX2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJX2.Location = new System.Drawing.Point(116, 20);
            this.spinEditJX2.Name = "spinEditJX2";
            this.spinEditJX2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJX2.Properties.IsFloatValue = false;
            this.spinEditJX2.Properties.Mask.EditMask = "N00";
            this.spinEditJX2.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEditJX2.Size = new System.Drawing.Size(42, 20);
            this.spinEditJX2.TabIndex = 15;
            // 
            // spinEditJX1
            // 
            this.spinEditJX1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJX1.Location = new System.Drawing.Point(37, 20);
            this.spinEditJX1.Name = "spinEditJX1";
            this.spinEditJX1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJX1.Properties.IsFloatValue = false;
            this.spinEditJX1.Properties.Mask.EditMask = "N00";
            this.spinEditJX1.Properties.MaxLength = 3;
            this.spinEditJX1.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.spinEditJX1.Size = new System.Drawing.Size(56, 20);
            this.spinEditJX1.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "X：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "Y：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.spinEditJY);
            this.groupBox2.Controls.Add(this.spinEditJX);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(2, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 80);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(197, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 14);
            this.label21.TabIndex = 19;
            this.label21.Text = "度";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(197, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 14);
            this.label20.TabIndex = 18;
            this.label20.Text = "度";
            // 
            // spinEditJY
            // 
            this.spinEditJY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJY.Location = new System.Drawing.Point(59, 50);
            this.spinEditJY.Name = "spinEditJY";
            this.spinEditJY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJY.Properties.MaxValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.spinEditJY.Size = new System.Drawing.Size(121, 20);
            this.spinEditJY.TabIndex = 16;
            // 
            // spinEditJX
            // 
            this.spinEditJX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditJX.Location = new System.Drawing.Point(59, 20);
            this.spinEditJX.Name = "spinEditJX";
            this.spinEditJX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditJX.Properties.MaxLength = 3;
            this.spinEditJX.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.spinEditJX.Size = new System.Drawing.Size(121, 20);
            this.spinEditJX.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 14);
            this.label19.TabIndex = 14;
            this.label19.Text = "Y：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 14);
            this.label18.TabIndex = 13;
            this.label18.Text = "X：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.spinEditDY);
            this.groupBox3.Controls.Add(this.spinEditDX);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(2, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox3.Size = new System.Drawing.Size(264, 80);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "坐标";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(197, 54);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(19, 14);
            this.label32.TabIndex = 18;
            this.label32.Text = "米";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(197, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(19, 14);
            this.label30.TabIndex = 17;
            this.label30.Text = "米";
            // 
            // spinEditDY
            // 
            this.spinEditDY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDY.Location = new System.Drawing.Point(59, 50);
            this.spinEditDY.Name = "spinEditDY";
            this.spinEditDY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDY.Size = new System.Drawing.Size(121, 20);
            this.spinEditDY.TabIndex = 16;
            // 
            // spinEditDX
            // 
            this.spinEditDX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDX.Location = new System.Drawing.Point(59, 20);
            this.spinEditDX.Name = "spinEditDX";
            this.spinEditDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDX.Size = new System.Drawing.Size(121, 20);
            this.spinEditDX.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 14);
            this.label24.TabIndex = 14;
            this.label24.Text = "Y：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(23, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 14);
            this.label25.TabIndex = 13;
            this.label25.Text = "X：";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.radioGroup);
            this.panel18.Controls.Add(this.radioGroup2);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(2, 22);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(264, 70);
            this.panel18.TabIndex = 2;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(10, 7);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "经纬度"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "大地坐标")});
            this.radioGroup.Size = new System.Drawing.Size(110, 56);
            this.radioGroup.TabIndex = 0;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // radioGroup2
            // 
            this.radioGroup2.Location = new System.Drawing.Point(126, 7);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "度分秒"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "度")});
            this.radioGroup2.Size = new System.Drawing.Size(110, 56);
            this.radioGroup2.TabIndex = 1;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelDistLocation);
            this.groupControlDist.Controls.Add(this.panel9);
            this.groupControlDist.Controls.Add(this.panel13);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(6, 4);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Size = new System.Drawing.Size(268, 184);
            this.groupControlDist.TabIndex = 14;
            this.groupControlDist.Text = "区划定位";
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(66, 22);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(162, 160);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.comboBoxXiaoBan);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.comboBoxLinban);
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(162, 160);
            this.panel10.TabIndex = 14;
            // 
            // comboBoxXiaoBan
            // 
            this.comboBoxXiaoBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiaoBan.Location = new System.Drawing.Point(0, 128);
            this.comboBoxXiaoBan.Name = "comboBoxXiaoBan";
            this.comboBoxXiaoBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiaoBan.Size = new System.Drawing.Size(162, 20);
            this.comboBoxXiaoBan.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 118);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(162, 10);
            this.panel6.TabIndex = 14;
            // 
            // comboBoxLinban
            // 
            this.comboBoxLinban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLinban.Location = new System.Drawing.Point(0, 98);
            this.comboBoxLinban.Name = "comboBoxLinban";
            this.comboBoxLinban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxLinban.Size = new System.Drawing.Size(162, 20);
            this.comboBoxLinban.TabIndex = 13;
            this.comboBoxLinban.SelectedIndexChanged += new System.EventHandler(this.comboBoxLinban_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 10);
            this.panel1.TabIndex = 12;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 68);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(162, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 58);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(162, 10);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 38);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(162, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.SelectedIndexChanged += new System.EventHandler(this.comboBoxTown_SelectedIndexChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 28);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(162, 10);
            this.panel14.TabIndex = 8;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 8);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCounty.Size = new System.Drawing.Size(162, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.SelectedIndexChanged += new System.EventHandler(this.comboBoxCounty_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(162, 8);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(2, 22);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(64, 160);
            this.panel9.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "小班：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "林班：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 32);
            this.label9.TabIndex = 3;
            this.label9.Text = "村：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.ButtonDistLocation);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(228, 22);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(38, 160);
            this.panel13.TabIndex = 15;
            // 
            // ButtonDistLocation
            // 
            this.ButtonDistLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDistLocation.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDistLocation.Image")));
            this.ButtonDistLocation.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDistLocation.Location = new System.Drawing.Point(6, 6);
            this.ButtonDistLocation.Name = "ButtonDistLocation";
            this.ButtonDistLocation.Size = new System.Drawing.Size(24, 24);
            this.ButtonDistLocation.TabIndex = 12;
            this.ButtonDistLocation.Text = "定位";
            this.ButtonDistLocation.ToolTip = "定位";
            this.ButtonDistLocation.Click += new System.EventHandler(this.ButtonDistLocation_Click);
            // 
            // UserControlLocation
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panLocation);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlLocation";
            this.Size = new System.Drawing.Size(280, 600);
            this.panLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlXY)).EndInit();
            this.groupControlXY.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditJX.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDX.Properties)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitLayers()
        {
            try
            {
                this.sDistLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.sDistLayerName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                this.sDistLayerName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                this.sLinbanLayerName = UtilFactory.GetConfigOpt().GetConfigValue("LinbanLayerName");
                this.sXiaobanLayerName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                this.sDistFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldName");
                this.sDistFieldCode = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                this.sDistFieldName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                this.sDistFieldCode2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                this.sDistFieldName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldName");
                this.sDistFieldCode3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                this.sLinbanFieldName = UtilFactory.GetConfigOpt().GetConfigValue("LinbanFieldName");
                this.sXiaobanFieldName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanFieldName");
                this.XBCodeName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanCodeName");
                this.sXiaobanFieldString = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanFieldString");
                this.sZaoLinFieldString2 = "ZaoLinFieldString2";
                this.sCaiFaFieldString2 = "CaiFaFieldString2";
                if (this.mEditKind.Contains("抚育间伐"))
                {
                    this.sCaiFaFieldString = UtilFactory.GetConfigOpt().GetConfigValue2("Thinning", "ShowFields");
                }
                else
                {
                    this.sCaiFaFieldString = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "ShowFields");
                }
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName, true);
                this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName2, true);
                this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName3, true);
                this.m_pLBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sLinbanLayerName, true);
                this.m_pXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sXiaobanLayerName, true);
                this.mfWorkspace = EditTask.EditWorkspace;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                this.m_CountyTable = this.mfWorkspace.OpenTable(configValue);
                if (this.m_CountyTable != null)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                    this.m_TownTable = this.mfWorkspace.OpenTable(configValue);
                    if (this.m_TownTable != null)
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                        this.m_VillageTable = this.mfWorkspace.OpenTable(configValue);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "InitLayers", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void labelLocation_Click(object sender, EventArgs e)
        {
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
            }
            else
            {
                this.m_bCoor = true;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = true;
                this.radioGroup2.Enabled = false;
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

        private void RB_Unit_D_CheckedChanged(object sender, EventArgs e)
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

        private void RB_Unit_DFM_CheckedChanged(object sender, EventArgs e)
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

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.m_HookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        private void ZoomToFeature(IMap pMap, IFeatureLayer pFeatureLayer, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shape = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shape = pFeature.Shape;
                    if (shape.SpatialReference != pMap.SpatialReference)
                    {
                        shape.Project(pMap.SpatialReference);
                        shape.SpatialReference = pMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shape.Envelope;
                    view = pMap as IActiveView;
                    if (shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shape as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.FullExtent = envelope;
                        pFeatureLayer.Visible = true;
                        if (this.m_HookHelper.FocusMap.MapScale < pFeatureLayer.MaximumScale)
                        {
                            this.m_HookHelper.FocusMap.MapScale = pFeatureLayer.MaximumScale + 1.0;
                        }
                        if (this.m_HookHelper.FocusMap.MapScale > pFeatureLayer.MinimumScale)
                        {
                            this.m_HookHelper.FocusMap.MapScale = pFeatureLayer.MinimumScale - 1.0;
                        }
                        view.Refresh();
                        for (int i = 0; i < 0x2710; i++)
                        {
                        }
                    }
                    else
                    {
                        IMapControl2 hook = (IMapControl2) this.m_HookHelper.Hook;
                        if (hook != null)
                        {
                            hook.FlashShape(pFeature.Shape, 3, 300, null);
                        }
                        view.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, pFeatureLayer, pFeature.Shape.Envelope);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ZoomToGeometry(IMap pMap, IGeometry pGeometry)
        {
            try
            {
                if ((pMap != null) && (pGeometry != null))
                {
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    envelope = new EnvelopeClass();
                    envelope = pGeometry.Envelope;
                    view = pMap as IActiveView;
                    if (pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = pGeometry as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.25, 1.25, true);
                    }
                    view.Extent = envelope;
                    view.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlLocation", "ZoomToGeometry", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public string CountryName
        {
            get
            {
                return this.comboBoxCounty.Text;
            }
        }

        public double DX
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.spinEditDX.Text);
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
                    return Convert.ToDouble(this.spinEditDY.Text);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public object hook
        {
            get
            {
                try
                {
                    if (this.m_HookHelper != null)
                    {
                        return this.m_HookHelper.Hook;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_HookHelper = new HookHelperClass();
                        this.m_HookHelper.Hook = value;
                        this.m_Map = this.m_HookHelper.FocusMap;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "地图定位", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public IPageLayoutControl3 PageLayoutControl
        {
            set
            {
                this._pageLayoutControl = value;
            }
        }

        public string TownName
        {
            get
            {
                return this.comboBoxTown.Text;
            }
        }

        public string VillageName
        {
            get
            {
                return this.comboBoxVillage.Text;
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
    }
}

