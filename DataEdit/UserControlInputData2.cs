namespace DataEdit
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using stdole;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlInputData2 : UserControlBase1
    {
        private ButtonEdit buttonEditDataPath;
        private ButtonEdit buttonEditTargetPath;
        private CheckEdit checkEditClear;
        private CheckEdit checkEditXB;
        private CheckEdit checkEditXiban;
        private CheckEdit checkPorpertyMatch;
        private int chk;
        private int chk2;
        private int ComboxSelectIndex = -1;
        private IContainer components = null;
        private bool DCInputAll = true;
        private bool DCInputAll2 = true;
        private GridColumn gridColumn1;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn14;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private GridColumn gridColumn9;
        private GridControl gridControl1;
        private GridControl gridControl2;
        private GridControl gridControl3;
        private GridControl gridControl4;
        private GridControl gridControl5;
        private GridControl gridControl6;
        private GridControl gridControl7;
        private int GridSelectIndex = -1;
        private GridView gridView1;
        private GridView gridView2;
        private GridView gridView3;
        private GridView gridView4;
        private GridView gridView5;
        private GridView gridView6;
        private GridView gridView7;
        internal ImageList ImageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelPointInfo;
        private Label labelPointInfo2;
        private Label labelPointList;
        private Label labelprogress;
        private Label labelSourceInfo;
        private ListBoxControl listBoxDataList;
        private IGroupLayer m_DCGroupLayer;
        private IFeatureLayer m_EditLayer;
        private ITable m_EditTable = null;
        private IFeatureWorkspace m_EditWorkspace;
        private IGroupLayer m_TempGroupLayer;
        private const string mClassName = "DataEdit.UserControlInputData2";
        private int mDaiHao = 0;
      
        private DataTable mDCDataTable;
        private DataTable mDCDataTable2;
        private IFeatureClass mDCFeatureClass;
        private IFeatureLayer mDCFeatureLayer;
        private ITable mDCTable;
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private HookHelper mHookHelper = null;
        private DataTable mInputTable;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
        private ArrayList mLayerList = null;
        private ArrayList mLayerList2 = null;
        private BarButtonItem mParButton;
        private IFeatureLayer mPointFeatureLayer;
        private DataTable mPointTable;
        private DataTable mPointTable2;
        private IFeatureLayer mPolyFeatureLayer;
        private IFeatureWorkspace mPolyFeatureWorkspace;
        private DataTable mPolyTable;
        private ArrayList mRangeList = null;
        private bool mSelected = false;
        private DataTable mSelPointTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IVersion mVersion = null;
        private IFeatureLayer mXBLayer;
        private const string myClassName = "数据导入";
        private Panel panel1;
        private Panel panel10;
        private Panel panel12;
        private Panel panel13;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelClearAll;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PanelControl panelControl6;
        private Panel panelDiaoCha;
        private Panel panelDo;
        private Panel panelField;
        private Panel panelFieldMatch;
        private Panel panelGPS;
        private Panel panelGridControl;
        private Panel panelLog;
        private Panel panelPointList;
        private Panel panelPoints;
        private Panel panelPolyList;
        private Panel panelResource;
        private Panel panelResource0;
        private Panel panelRseult;
        private Panel panelSet;
        private Panel panelSetID;
        private Panel panelSetSubID;
        private Panel panelSetXB;
        private Panel panelSubID;
        private Panel panelTarget;
        private ProgressBarControl progressBar;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
        private RadioGroup radioGroup3;
        private RadioGroup radioGroupCF;
        private RadioGroup radioGroupDC;
        private bool Redo = false;
        private bool Redo2 = false;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RepositoryItemComboBox repositoryItemComboBox4;
        private RepositoryItemComboBox repositoryItemComboBox5;
        private RepositoryItemComboBox repositoryItemComboBox6;
        private RepositoryItemComboBox repositoryItemComboBox7;
        private RichTextBox richTextBox;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButtonAdd;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonClear;
        private SimpleButton simpleButtonClear2;
        private SimpleButton simpleButtonClose;
        public SimpleButton simpleButtonConvert;
        public SimpleButton simpleButtonDCView;
        private SimpleButton simpleButtonDeletePoly;
        private SimpleButton simpleButtonExpend;
        private SimpleButton simpleButtonExpend2;
        private SimpleButton simpleButtonInput;
        private SimpleButton simpleButtonInputPoint;
        private SimpleButton simpleButtonRemove;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonResult;
        private SimpleButton simpleButtonResultList;
        private SimpleButton simpleButtonSel;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonSelected;
        private SimpleButton simpleButtonSelectTool;
        private SplitterControl splitterControl1;
        private string SubID = "";
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlInputData2()
        {
            this.InitializeComponent();
        }

        private void AddDCLayer(IFeatureClass pfc, string sName)
        {
            try
            {
                IFeatureLayer layer = new FeatureLayerClass();
                layer.Name = sName;
                layer.FeatureClass = pfc;
                IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
                ISimpleRenderer renderer = (ISimpleRenderer) layer2.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = 0xff;
                color2.Blue = 0xff;
                color2.Green = 0;
                symbol3.Color = color2;
                symbol3.Width = 1.0;
                symbol3.Style = esriSimpleLineStyle.esriSLSSolid;
                symbol2.Outline = symbol3;
                symbol2.Style = esriSimpleFillStyle.esriSFSNull;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Description = "调查班块";
                renderer2.Label = "班块";
                renderer2.Symbol = symbol;
                layer2.Renderer = renderer2 as IFeatureRenderer;
                string sLayerName = "调查数据";
                this.m_DCGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true);
                if (this.m_DCGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, sLayerName);
                    this.m_DCGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true);
                }
                if (this.m_DCGroupLayer != null)
                {
                    ILayer layer3 = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.m_DCGroupLayer, sName, true);
                    if (layer3 == null)
                    {
                        this.m_DCGroupLayer.Add(layer);
                        this.mDCFeatureLayer = layer;
                    }
                    else
                    {
                        (layer3 as IFeatureLayer).FeatureClass = pfc;
                        this.mDCFeatureLayer = layer3 as IFeatureLayer;
                    }
                }
                else
                {
                    this.mHookHelper.FocusMap.AddLayer(layer);
                    this.mPolyFeatureLayer = layer;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "AddDCLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddPointLayer(IFeatureClass pfc, string sName, IGroupLayer pGroupLayer)
        {
            try
            {
                IFeatureLayer layer = new FeatureLayerClass();
                layer.Name = sName.Split(new char[] { '.' })[0].ToString();
                layer.FeatureClass = pfc;
                IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
                ISimpleRenderer renderer = (ISimpleRenderer) layer2.Renderer;
                ISymbol symbol = null;
                ISimpleMarkerSymbol symbol2 = new SimpleMarkerSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.Red = 0xff;
                color.Blue = 0;
                color.Green = 0;
                symbol2.Size = 6.0;
                symbol2.Style = esriSimpleMarkerStyle.esriSMSDiamond;
                symbol2.Color = color;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Description = "GPS坐标点";
                renderer2.Label = "GPS轨迹点";
                renderer2.Symbol = symbol;
                layer2.Renderer = renderer2 as IFeatureRenderer;
                layer2.DisplayField = "ID";
                layer2.DisplayAnnotation = true;
                IAnnotateLayerPropertiesCollection annotationProperties = layer2.AnnotationProperties;
                annotationProperties.Clear();
                ILabelEngineLayerProperties properties = new LabelEngineLayerPropertiesClass();
                properties.IsExpressionSimple = true;
                properties.Expression = "[" + layer2.DisplayField.ToString() + "]";
                IAnnotateLayerProperties properties2 = properties as IAnnotateLayerProperties;
                properties2.AnnotationMinimumScale = 35000.0;
                ITextSymbol symbol3 = properties.Symbol;
                symbol3.Size = 12.0;
                IColor color2 = symbol3.Color;
                stdole.IFontDisp font = symbol3.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                IRgbColor color3 = new RgbColorClass();
                color3.Red = color.Red;
                color3.Blue = color.Blue;
                color3.Green = color.Green;
                color2 = color3;
                symbol3.Color = color2;
                layer.ScaleSymbols = true;
                annotationProperties.Add(properties as IAnnotateLayerProperties);
                if (pGroupLayer == null)
                {
                    pGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (pGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, "GPS轨迹");
                    pGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (pGroupLayer != null)
                {
                    ILayer layer3 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, sName, true);
                    if (layer3 == null)
                    {
                        pGroupLayer.Add(layer);
                        this.mPointFeatureLayer = layer;
                    }
                    else
                    {
                        (layer3 as IFeatureLayer).FeatureClass = pfc;
                        this.mPointFeatureLayer = layer3 as IFeatureLayer;
                    }
                }
                else
                {
                    this.mHookHelper.FocusMap.AddLayer(layer);
                    this.mPointFeatureLayer = layer;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "AddPointLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddPolygonLayer(IFeatureClass pfc, string sName)
        {
            try
            {
                IFeatureLayer layer = new FeatureLayerClass();
                layer.Name = sName;
                layer.FeatureClass = pfc;
                IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
                ISimpleRenderer renderer = (ISimpleRenderer) layer2.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = 0xff;
                color2.Blue = 0;
                color2.Green = 0;
                symbol3.Color = color2;
                symbol3.Width = 1.6;
                symbol3.Style = esriSimpleLineStyle.esriSLSSolid;
                symbol2.Outline = symbol3;
                symbol2.Style = esriSimpleFillStyle.esriSFSNull;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Description = "GPS点转面";
                renderer2.Label = "GPS面";
                renderer2.Symbol = symbol;
                layer2.Renderer = renderer2 as IFeatureRenderer;
                if (this.m_TempGroupLayer == null)
                {
                    this.m_TempGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (this.m_TempGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, "GPS轨迹");
                    this.m_TempGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (this.m_TempGroupLayer != null)
                {
                    ILayer layer3 = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.m_TempGroupLayer, sName, true);
                    if (layer3 == null)
                    {
                        this.m_TempGroupLayer.Add(layer);
                        this.mPolyFeatureLayer = layer;
                    }
                    else
                    {
                        (layer3 as IFeatureLayer).FeatureClass = pfc;
                        this.mPolyFeatureLayer = layer3 as IFeatureLayer;
                    }
                }
                else
                {
                    this.mHookHelper.FocusMap.AddLayer(layer);
                    this.mPolyFeatureLayer = layer;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "AddPolygonLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void buttonEditDataPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                IDataset featureClass;
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                    data.ShowDialog(this);
                    ArrayList layerList = data.LayerList;
                    if (layerList != null)
                    {
                        if (this.mLayerList == null)
                        {
                            this.mLayerList = new ArrayList();
                        }
                        this.mLayerList2 = null;
                        this.mLayerList2 = new ArrayList();
                        if (layerList.Count > 0)
                        {
                            for (int i = 0; i < layerList.Count; i++)
                            {
                                IFeatureLayer layer = layerList[i] as IFeatureLayer;
                                featureClass = layer.FeatureClass as IDataset;
                                if (i == 0)
                                {
                                    this.buttonEditDataPath.Text = featureClass.Workspace.PathName + @"\" + featureClass.Name;
                                }
                                else
                                {
                                    this.buttonEditDataPath.Text = this.buttonEditDataPath.Text + "," + featureClass.Workspace.PathName + @"\" + featureClass.Name;
                                }
                                if (this.mLayerList.Count > 0)
                                {
                                    for (int j = 0; j < this.mLayerList.Count; j++)
                                    {
                                        IFeatureLayer layer2 = this.mLayerList[j] as IFeatureLayer;
                                        IDataset dataset2 = layer2.FeatureClass as IDataset;
                                        if ((featureClass.Workspace.PathName != dataset2.Workspace.PathName) || (featureClass.Name != dataset2.Name))
                                        {
                                            this.mLayerList.Add(layer);
                                            this.mLayerList2.Add(layer);
                                        }
                                    }
                                }
                                else
                                {
                                    this.mLayerList.Add(layer);
                                    this.mLayerList2.Add(layer);
                                }
                            }
                            this.buttonEditDataPath.Tag = layerList;
                            this.simpleButtonAdd.Enabled = true;
                            this.labelprogress.Visible = false;
                        }
                        else
                        {
                            this.buttonEditDataPath.Tag = null;
                            this.simpleButtonAdd.Enabled = false;
                            this.labelprogress.Visible = false;
                        }
                    }
                }
                else if (this.radioGroup2.SelectedIndex == 1)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Multiselect = false;
                    dialog.Filter = "轨迹点文件 (*.txt)|*.txt";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = dialog.FileName;
                        this.buttonEditDataPath.Text = fileName;
                        this.buttonEditDataPath.Tag = fileName;
                        dialog = null;
                        this.simpleButtonAdd.Enabled = true;
                        this.labelprogress.Visible = false;
                        if (this.ReadPoints(this.buttonEditDataPath.Text))
                        {
                            this.panelPointList.Dock = DockStyle.Fill;
                            this.panelPointList.Visible = true;
                            this.panelPointList.BringToFront();
                            this.simpleButtonInputPoint.Visible = true;
                            this.simpleButtonBack.Visible = true;
                            this.buttonEditDataPath.Text = "";
                            this.simpleButtonRemove.Enabled = false;
                            this.simpleButtonAdd.Enabled = false;
                        }
                    }
                }
                else if (this.radioGroup2.SelectedIndex == 2)
                {
                    FormAddData3 data2 = new FormAddData3(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                    data2.ShowDialog(this);
                    if (data2.cancelflag)
                    {
                        data2.Close();
                        data2 = null;
                    }
                    else
                    {
                        this.mDCDataTable = null;
                        this.mDCDataTable2 = null;
                        this.simpleButtonSelect.Enabled = false;
                        IFeatureWorkspace fWorkspace = data2.fWorkspace;
                        data2.Close();
                        data2 = null;
                        if (fWorkspace == null)
                        {
                            MessageBox.Show("数据库读取错误", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.InitialGridviewDC(null, 0);
                        }
                        else
                        {
                            IWorkspace workspace2 = fWorkspace as IWorkspace;
                            this.xtraTabControl1.Enabled = false;
                            this.buttonEditDataPath.Text = workspace2.PathName;
                            this.buttonEditDataPath.Tag = fWorkspace;
                            string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                            try
                            {
                                this.mDCFeatureClass = fWorkspace.OpenFeatureClass(configValue);
                                if (this.mDCFeatureClass == null)
                                {
                                    this.InitialGridviewDC(null, 0);
                                    return;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("采伐数据读取错误," + configValue + "图层不存在或打开错误！", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            this.xtraTabControl1.Enabled = true;
                            this.mDCTable = null;
                            if (this.mEditKind2 == "CaiFa")
                            {
                                configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TableName");
                                this.mDCTable = this.m_EditWorkspace.OpenTable(configValue);
                                this.mDCTable = fWorkspace.OpenTable(configValue);
                            }
                            featureClass = this.mDCFeatureClass as IDataset;
                            this.InitialGridviewDC(featureClass, 0);
                            this.simpleButtonInput.Enabled = false;
                            this.simpleButtonSelect.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "buttonEditDataPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void buttonEditDataPath_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void buttonEditDataPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonEditTargetPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleButtonExpend.Visible = this.checkPorpertyMatch.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkEditXiban.Checked)
                {
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "checkEdit2_CheckedChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void checkEdit2_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private bool CheckFieldSame()
        {
            try
            {
                IFeatureClass class2 = this.mRangeList[0] as IFeatureClass;
                IFeatureClass class3 = this.mRangeList[this.mRangeList.Count - 1] as IFeatureClass;
                for (int i = 0; i < class2.Fields.FieldCount; i++)
                {
                    IField field = class2.Fields.get_Field(i);
                    int index = class3.Fields.FindField(field.Name);
                    if (index == -1)
                    {
                        return false;
                    }
                    if (class3.Fields.get_Field(index).Type != field.Type)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int CheckHas(IFeature pSFeature, IFeatureClass sTFeatureClass)
        {
            try
            {
                GC.Collect();
                IFeature pFeature = null;
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pSFeature.Shape;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                pFeature = sTFeatureClass.Search(filter, false).NextFeature();
                GC.Collect();
                if (pFeature != null)
                {
                    if (!this.Redo)
                    {
                        FormInputDataQuestion question = new FormInputDataQuestion(pFeature, this.mHookHelper);
                        question.label4.Text = "      相同位置已存在小班";
                        question.StartPosition = FormStartPosition.CenterParent;
                        if (base.Parent.Parent.Parent.Parent != null)
                        {
                            question.StartPosition = FormStartPosition.Manual;
                            question.Left = base.Parent.Parent.Parent.Parent.Left + 10;
                            question.Top = base.Parent.Parent.Parent.Parent.Top + 100;
                        }
                        else
                        {
                            question.Left = base.Left + this.panelControl1.Left;
                        }
                        question.ShowDialog(this);
                        this.chk = question.Result;
                        this.Redo = question.Redo;
                        question.Close();
                        question = null;
                    }
                    return this.chk;
                }
                this.chk = 0;
                return 0;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "CheckHas", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return 0;
            }
        }

        private int CheckHas2(IRow pSRow, ITable pTTable)
        {
            try
            {
                IRow row = null;
                IQueryFilter queryFilter = new QueryFilterClass();
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TableNameD").Split(new char[] { ',' });
                string str = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str == "")
                    {
                        str = strArray[i] + "='" + pSRow.get_Value(pSRow.Fields.FindField(strArray[i])).ToString() + "'";
                    }
                    else
                    {
                        str = str + " and " + strArray[i] + "='" + pSRow.get_Value(pSRow.Fields.FindField(strArray[i])).ToString() + "'";
                    }
                }
                queryFilter.WhereClause = str;
                ICursor cursor = pTTable.Search(queryFilter, false);
                for (row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    bool flag = true;
                    for (int j = 0; j < row.Fields.FieldCount; j++)
                    {
                        if ((row.Fields.get_Field(j).Name != row.Table.OIDFieldName) && (row.get_Value(j).ToString() != pSRow.get_Value(j).ToString()))
                        {
                            flag = false;
                            continue;
                        }
                    }
                    if (flag)
                    {
                        FormInputDataQuestion question = new FormInputDataQuestion(null, this.mHookHelper);
                        question.label4.Text = "      已存在相同检尺记录";
                        question.StartPosition = FormStartPosition.CenterParent;
                        if (base.Parent.Parent.Parent.Parent != null)
                        {
                            question.StartPosition = FormStartPosition.Manual;
                            question.Left = base.Parent.Parent.Parent.Parent.Left + 20;
                            question.Top = base.Parent.Parent.Parent.Parent.Top + 100;
                        }
                        else
                        {
                            question.Left = base.Left + this.panelControl1.Left;
                        }
                        question.ShowDialog(this);
                        this.chk2 = question.Result;
                        this.Redo2 = question.Redo;
                        question.Close();
                        question = null;
                        return this.chk2;
                    }
                }
                this.chk2 = 0;
                return 0;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "CheckHas", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return 0;
            }
        }

        private IFeatureClass CreateFeatureClass(IFeatureWorkspace pfw, string sName)
        {
            try
            {
                IFields inputField = new FieldsClass();
                IFieldsEdit edit = (IFieldsEdit) inputField;
                IField field = new FieldClass();
                IFieldEdit edit2 = (IFieldEdit) field;
                edit2.Name_2 = "OID";
                edit2.Type_2 = esriFieldType.esriFieldTypeOID;
                edit.AddField(field);
                IGeometryDef def = new GeometryDefClass();
                IGeometryDefEdit edit3 = (IGeometryDefEdit) def;
                edit3.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                ((ISpatialReferenceResolution) spatialReference).ConstructFromHorizon();
                ((ISpatialReferenceTolerance) spatialReference).SetDefaultXYTolerance();
                edit3.SpatialReference_2 = spatialReference;
                IField field2 = new FieldClass();
                IFieldEdit edit4 = (IFieldEdit) field2;
                edit4.Name_2 = "Shape";
                edit4.Type_2 = esriFieldType.esriFieldTypeGeometry;
                edit4.GeometryDef_2 = def;
                edit.AddField(field2);
                IField field3 = new FieldClass();
                IFieldEdit edit5 = (IFieldEdit) field3;
                edit5.Name_2 = "ID";
                edit5.Type_2 = esriFieldType.esriFieldTypeString;
                edit5.Length_2 = 50;
                edit.AddField(field3);
                IField field4 = new FieldClass();
                IFieldEdit edit6 = (IFieldEdit) field4;
                edit6.Name_2 = "X坐标";
                edit6.Type_2 = esriFieldType.esriFieldTypeString;
                edit6.Length_2 = 50;
                edit.AddField(edit6);
                IField field5 = new FieldClass();
                IFieldEdit edit7 = (IFieldEdit) field5;
                edit7.Name_2 = "Y坐标";
                edit7.Type_2 = esriFieldType.esriFieldTypeString;
                edit7.Length_2 = 50;
                edit.AddField(edit7);
                IField field6 = new FieldClass();
                IFieldEdit edit8 = (IFieldEdit) field6;
                edit8.Name_2 = "时间";
                edit8.Type_2 = esriFieldType.esriFieldTypeString;
                edit8.Length_2 = 50;
                edit.AddField(edit8);
                IFieldChecker checker = new FieldCheckerClass();
                IEnumFieldError error = null;
                IFields fixedFields = null;
                checker.ValidateWorkspace = (IWorkspace) pfw;
                checker.Validate(inputField, out error, out fixedFields);
                return pfw.CreateFeatureClass(sName, fixedFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IFeatureClass CreateFeatureClass2(IFeatureWorkspace pfw, string sName)
        {
            try
            {
                IFields inputField = new FieldsClass();
                IFieldsEdit edit = (IFieldsEdit) inputField;
                IField field = new FieldClass();
                IFieldEdit edit2 = (IFieldEdit) field;
                edit2.Name_2 = "OID";
                edit2.Type_2 = esriFieldType.esriFieldTypeOID;
                edit.AddField(field);
                IGeometryDef def = new GeometryDefClass();
                IGeometryDefEdit edit3 = (IGeometryDefEdit) def;
                edit3.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                ((ISpatialReferenceResolution) spatialReference).ConstructFromHorizon();
                ((ISpatialReferenceTolerance) spatialReference).SetDefaultXYTolerance();
                edit3.SpatialReference_2 = spatialReference;
                IField field2 = new FieldClass();
                IFieldEdit edit4 = (IFieldEdit) field2;
                edit4.Name_2 = "Shape";
                edit4.Type_2 = esriFieldType.esriFieldTypeGeometry;
                edit4.GeometryDef_2 = def;
                edit.AddField(field2);
                IField field3 = new FieldClass();
                IFieldEdit edit5 = (IFieldEdit) field3;
                edit5.Name_2 = "ID";
                edit5.Type_2 = esriFieldType.esriFieldTypeString;
                edit5.Length_2 = 50;
                edit.AddField(field3);
                IFieldChecker checker = new FieldCheckerClass();
                IEnumFieldError error = null;
                IFields fixedFields = null;
                checker.ValidateWorkspace = (IWorkspace) pfw;
                checker.Validate(inputField, out error, out fixedFields);
                return pfw.CreateFeatureClass(sName, fixedFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IFeatureWorkspace CreateShapefile(string sPath, string sName, esriGeometryType pType, ISpatialReference pSpReference)
        {
            try
            {
                IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
                IWorkspace workspace = factory.OpenFromFile(sPath, 1);
                IWorkspaceFactory2 factory2 = new ShapefileWorkspaceFactoryClass();
                IName name2 = (IName) factory2.Create(sPath + @"\", sName.Split(new char[] { '.' })[0], null, 0);
                IWorkspace workspace2 = (IWorkspace) name2.Open();
                return (workspace2 as IFeatureWorkspace);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "CreateShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void DoInput(IWorkspaceEdit pWorkspaceEdit)
        {
            IFeatureClass class2 = null;
            Exception exception;
            bool flag = false;
            try
            {
                if (this.checkEditClear.Checked)
                {
                    this.labelprogress.Text = "清空" + this.mEditKind + "图层所有要素";
                    this.labelprogress.Visible = true;
                    this.richTextBox.Text = "删除" + this.mEditKind + "图层所有要素";
                    this.StartEdit();
                    pWorkspaceEdit.StartEditOperation();
                    int num = 0;
                    num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                    IDataset featureClass = this.m_EditLayer.FeatureClass as IDataset;
                    featureClass.Workspace.ExecuteSQL("delete from " + featureClass.Name);
                    try
                    {
                        pWorkspaceEdit.StopEditOperation();
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        this.richTextBox.Text = this.richTextBox.Text + "[错误来源" + exception.Source + "错误描述" + exception.Message + "]";
                        pWorkspaceEdit.StopEditOperation();
                    }
                    this.StopEdit();
                    this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "共计", num, "个要素 [成功]" });
                }
                string sKindCode = "";
                if (EditTask.KindCode.Length <= 4)
                {
                    sKindCode = EditTask.KindCode.Substring(EditTask.KindCode.Length - 2, 2);
                }
                else
                {
                    sKindCode = EditTask.KindCode.Substring(0, 2);
                }
                string node = GetNode(sKindCode);
                IList<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXFields").Split(new char[] { ',' }));
                IList<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXMatchFields").Split(new char[] { ',' }));
                IList<string> list3 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ZTImportFields").Split(new char[] { ',' }));
                IList<string> list4 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "SubImportFields").Split(new char[] { ',' }));
                for (int i = 0; i < this.mRangeList.Count; i++)
                {
                    class2 = this.mRangeList[i] as IFeatureClass;
                    string aliasName = class2.AliasName;
                    int num3 = class2.FeatureCount(null);
                    this.labelprogress.Text = string.Concat(new object[] { "导入", this.mEditKind, "图层[", (class2 as IDataset).Name, "]共", num3, "个多边形要素" });
                    this.labelprogress.Visible = true;
                    IFeatureCursor cursor = class2.Search(null, false);
                    IGeoDataset dataset2 = (class2 as IDataset) as IGeoDataset;
                    IGeometry extent = dataset2.Extent;
                    if (extent.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                    {
                        extent.Project(this.mHookHelper.FocusMap.SpatialReference);
                    }
                    this.mHookHelper.ActiveView.FullExtent = extent.Envelope;
                    this.mHookHelper.ActiveView.Refresh();
                    IFeature feature = cursor.NextFeature();
                    this.Cursor = Cursors.WaitCursor;
                    ArrayList list5 = new ArrayList();
                    while (feature != null)
                    {
                        list5.Add(feature);
                        feature = cursor.NextFeature();
                    }
                    this.Redo = false;
                    this.chk = 0;
                    int num4 = 0;
                    int num5 = 0;
                    this.SubID = "0";
                    int num6 = num3 / 0x3e8;
                    if ((num6 * 0x3e8) < num3)
                    {
                        num6++;
                    }
                    if (num3 > 0)
                    {
                        this.richTextBox.Text = "导入" + class2.AliasName + "图层要素";
                    }
                    List<string> list6 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                    List<string> list7 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                    IWorkspace editWorkspace = EditTask.EditWorkspace as IWorkspace;
                    for (int j = 0; j < num6; j++)
                    {
                        Process process;
                        ProcessStartInfo info;
                        GC.Collect();
                        try
                        {
                            if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                            {
                                process = new Process();
                                info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                process.StartInfo = info;
                                process.StartInfo.UseShellExecute = false;
                                process.Start();
                            }
                        }
                        catch (Exception)
                        {
                        }
                        int num8 = 0;
                        this.StartEdit();
                        flag = true;
                        for (int k = 0; k < 0x3e8; k++)
                        {
                            if ((k + (0x3e8 * j)) == list5.Count)
                            {
                                pWorkspaceEdit.StopEditOperation();
                                pWorkspaceEdit.StopEditing(true);
                                GC.Collect();
                                break;
                            }
                            feature = list5[k + (0x3e8 * j)] as IFeature;
                            Application.DoEvents();
                            num5++;
                            GC.Collect();
                            this.labelprogress.Text = string.Concat(new object[] { "导入", this.mEditKind, "图层[", class2.AliasName, "]共", num3, "个多边形要素\n第", num5, "个多边形要素" });
                            if (!feature.Shape.IsEmpty)
                            {
                                this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n导入要素", feature.Class.OIDFieldName, "-", feature.OID });
                                int num10 = 0;
                                if ((this.chk != 1) || !this.Redo)
                                {
                                    if ((this.chk == 2) && this.Redo)
                                    {
                                        this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                                    }
                                    else if (!this.Redo)
                                    {
                                        num10 = this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                                    }
                                }
                                if (this.chk == 3)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                                    break;
                                }
                                if (this.chk == 2)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                                }
                                else
                                {
                                    pWorkspaceEdit.StartEditOperation();
                                    IFeature pFeature = this.m_EditLayer.FeatureClass.CreateFeature();
                                    IClone shape = (IClone) feature.Shape;
                                    if (shape == null)
                                    {
                                        return;
                                    }
                                    IPolygon polygon = (IPolygon) shape.Clone();
                                    try
                                    {
                                        pFeature.Shape = new PolygonClass();
                                        pFeature.Shape = polygon;
                                    }
                                    catch (Exception)
                                    {
                                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                        continue;
                                    }
                                    IFields fields = pFeature.Fields;
                                    string name = "NO_TB";
                                    int index = pFeature.Fields.FindField(name);
                                    if ((index > -1) && (EditTask.KindCode == "09"))
                                    {
                                        pFeature.set_Value(index, feature.OID);
                                    }
                                    if (this.checkPorpertyMatch.Checked)
                                    {
                                        for (int m = 0; m < this.mFieldTable.Rows.Count; m++)
                                        {
                                            int num13 = pFeature.Fields.FindField(this.mFieldTable.Rows[m]["目标数据字段2"].ToString());
                                            int num14 = feature.Fields.FindField(this.mFieldTable.Rows[m]["源数据字段2"].ToString());
                                            if ((num13 != -1) && (num14 != -1))
                                            {
                                                if (pFeature.Fields.get_Field(num13).Type == feature.Fields.get_Field(num14).Type)
                                                {
                                                    try
                                                    {
                                                        if (feature.get_Value(num14) != null)
                                                        {
                                                            if (feature.Fields.get_Field(num14).Name == "XIAO_BAN")
                                                            {
                                                                pFeature.set_Value(num13, feature.get_Value(num14).ToString().Trim());
                                                            }
                                                            else
                                                            {
                                                                pFeature.set_Value(num13, feature.get_Value(num14));
                                                            }
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        if (feature.get_Value(num14) != null)
                                                        {
                                                            if (pFeature.Fields.get_Field(num13).Type == esriFieldType.esriFieldTypeDouble)
                                                            {
                                                                pFeature.set_Value(num13, double.Parse(feature.get_Value(num14).ToString()));
                                                            }
                                                            else if (pFeature.Fields.get_Field(num13).Type == esriFieldType.esriFieldTypeInteger)
                                                            {
                                                                pFeature.set_Value(num13, int.Parse(feature.get_Value(num14).ToString()));
                                                            }
                                                            else
                                                            {
                                                                pFeature.set_Value(num13, feature.get_Value(num14).ToString());
                                                            }
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                        GC.Collect();
                                    }
                                    if (this.checkEditXB.Checked)
                                    {
                                        IFeature xBFeature = this.GetXBFeature(pFeature);
                                        GC.Collect();
                                        if (xBFeature != null)
                                        {
                                            for (int n = 0; n < pFeature.Fields.FieldCount; n++)
                                            {
                                                IField field = pFeature.Fields.get_Field(n);
                                                string item = field.Name;
                                                if (pFeature.get_Value(n).ToString().Trim() == "")
                                                {
                                                    int num17;
                                                    if (list7.Contains(item))
                                                    {
                                                        int num16 = list7.IndexOf(item);
                                                        item = list6[num16];
                                                        num17 = xBFeature.Fields.FindField(item);
                                                        if (num17 > -1)
                                                        {
                                                            pFeature.set_Value(n, xBFeature.get_Value(num17));
                                                        }
                                                    }
                                                    else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                                    {
                                                        num17 = xBFeature.Fields.FindField(field.Name);
                                                        if (num17 > -1)
                                                        {
                                                            pFeature.set_Value(n, xBFeature.get_Value(num17));
                                                        }
                                                    }
                                                }
                                                else if (pFeature.get_Value(n) == null)
                                                {
                                                }
                                            }
                                            GC.Collect();
                                        }
                                    }
                                    string str13 = "Task_ID";
                                    int num18 = fields.FindField(str13.ToUpper());
                                    index = pFeature.Fields.FindField(str13.ToUpper());
                                    if ((num18 == -1) && (index == -1))
                                    {
                                        str13 = "XMBH";
                                        num18 = fields.FindField(str13.ToUpper());
                                        index = pFeature.Fields.FindField(str13.ToUpper());
                                    }
                                    if (index > -1)
                                    {
                                        pFeature.set_Value(index, EditTask.TaskID);
                                    }
                                    if (this.mEditKind == "征占用")
                                    {
                                        index = pFeature.Fields.FindField("LDYT");
                                        if (index > -1)
                                        {
                                            string str14 = int.Parse(EditTask.KindCode.Substring(2, 4)).ToString();
                                            string str15 = str14.Substring(0, str14.Length - 2) + int.Parse(str14.Substring(str14.Length - 2, 2)).ToString();
                                            pFeature.set_Value(index, str15);
                                        }
                                    }
                                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                                    num18 = fields.FindField(configValue);
                                    index = pFeature.Fields.FindField(configValue);
                                    if (num4 == 0)
                                    {
                                        ITable table = this.m_EditLayer.FeatureClass as ITable;
                                        IQueryFilter queryFilter = new QueryFilterClass();
                                        queryFilter.SubFields = this.m_EditLayer.FeatureClass.OIDFieldName + "," + configValue;
                                        if (((this.mEditKind2 == "CaiFa") || (this.mEditKind2 == "ZZY")) && (EditTask.TaskID != 0L))
                                        {
                                            queryFilter.WhereClause = string.Concat(new object[] { str13, "='", EditTask.TaskID, "'" });
                                        }
                                        IQueryFilterDefinition definition = (IQueryFilterDefinition) queryFilter;
                                        definition.PostfixClause = "ORDER BY " + configValue + " desc";
                                        ICursor cursor2 = table.Search(queryFilter, true);
                                        for (IRow row = cursor2.NextRow(); row != null; row = cursor2.NextRow())
                                        {
                                            int num19 = row.Fields.FindField(configValue);
                                            try
                                            {
                                                if (((row.get_Value(num19) != null) && (row.get_Value(num19).ToString() != "")) && (int.Parse(this.SubID) < int.Parse(row.get_Value(num19).ToString())))
                                                {
                                                    this.SubID = int.Parse(row.get_Value(num19).ToString()).ToString();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                if (this.SubID == "")
                                                {
                                                    this.SubID = "0";
                                                }
                                            }
                                        }
                                    }
                                    if (this.SubID == "")
                                    {
                                        this.SubID = "0";
                                    }
                                    if ((index > -1) && this.checkEditXiban.Checked)
                                    {
                                        int num20 = int.Parse(this.SubID) + 1;
                                        pFeature.set_Value(index, num20.ToString());
                                    }
                                    name = "CFLX";
                                    index = pFeature.Fields.FindField(name);
                                    if (((index > -1) && this.checkEditXiban.Checked) && (EditTask.KindCode.Length > 4))
                                    {
                                        string str17 = EditTask.KindCode.Substring(3, 1) + "0";
                                        pFeature.set_Value(index, str17);
                                    }
                                    this.SetFeatureArea(pFeature, EditTask.KindCode.Substring(0, 2), this.mHookHelper.FocusMap.SpatialReference);
                                    GC.Collect();
                                    try
                                    {
                                        Editor.UniqueInstance.AddAttribute = false;
                                        pFeature.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                        try
                                        {
                                            pWorkspaceEdit.StopEditOperation();
                                        }
                                        catch (Exception exception7)
                                        {
                                            exception = exception7;
                                            this.richTextBox.Text = this.richTextBox.Text + "[错误来源" + exception.Source + "错误描述" + exception.Message + "]";
                                            pWorkspaceEdit.StopEditOperation();
                                        }
                                        num8++;
                                        if (num8 >= 50)
                                        {
                                            this.StopEdit();
                                            try
                                            {
                                                if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 200L)
                                                {
                                                    process = new Process();
                                                    info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                                    process.StartInfo = info;
                                                    process.StartInfo.UseShellExecute = false;
                                                    process.Start();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                            }
                                            num8 = 0;
                                            this.StartEdit();
                                            GC.Collect();
                                        }
                                        IGeometry shapeCopy = pFeature.ShapeCopy;
                                        if (shapeCopy.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                                        {
                                            shapeCopy.Project(this.mHookHelper.FocusMap.SpatialReference);
                                            shapeCopy.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                                        }
                                        GISFunFactory.FlashFun.FlashGeometry(this.mHookHelper.FocusMap, shapeCopy, 300L, true);
                                        this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, shapeCopy.Envelope);
                                        this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, shapeCopy.Envelope);
                                        this.SubID = (int.Parse(this.SubID) + 1).ToString();
                                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, ",生成要素", pFeature.Class.OIDFieldName, "-", pFeature.OID, "[细班-", pFeature.get_Value(pFeature.Fields.FindField(configValue)), "][成功]" });
                                        Application.DoEvents();
                                    }
                                    catch (Exception exception9)
                                    {
                                        exception = exception9;
                                        this.richTextBox.Text = this.richTextBox.Text + "[失败:错误来源" + exception.Source + "错误描述" + exception.Message + "]";
                                        Editor.UniqueInstance.AddAttribute = false;
                                        pFeature.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    num4++;
                                }
                            }
                        }
                        this.StopEdit();
                        GC.Collect();
                    }
                    this.Cursor = Cursors.Default;
                    this.labelprogress.Text = string.Concat(new object[] { "导入", this.mEditKind, "作业图层[", class2.AliasName, "] - 完成\r\n共计", num4, "个", this.mEditKind, "班块" });
                    this.labelprogress.Visible = true;
                    this.mHookHelper.ActiveView.Refresh();
                    MessageBox.Show(this.labelprogress.Text, "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception10)
            {
                exception = exception10;
                this.Cursor = Cursors.Default;
                if (flag)
                {
                    pWorkspaceEdit.StopEditOperation();
                    this.StopEdit();
                }
                this.Cursor = Cursors.Default;
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + class2.AliasName + "] - 中断\r\n异常(" + exception.Message + ")";
                this.labelprogress.Visible = true;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "DoInput", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DoInput2(IWorkspaceEdit pWorkspaceEdit)
        {
            try
            {
                IFeatureClass featureClass = this.mPolyFeatureLayer.FeatureClass;
                string aliasName = featureClass.AliasName;
                IFeatureCursor cursor = featureClass.Search(null, false);
                IFeature pSFeature = cursor.NextFeature();
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + featureClass.AliasName + "]";
                pWorkspaceEdit.StartEditing(false);
                pWorkspaceEdit.StartEditOperation();
                this.Redo = false;
                this.chk = 0;
                while (pSFeature != null)
                {
                    this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + pSFeature.OID;
                    this.richTextBox.Refresh();
                    int num = 0;
                    if ((this.chk != 1) || !this.Redo)
                    {
                        if ((this.chk == 2) && this.Redo)
                        {
                            this.CheckHas(pSFeature, this.m_EditLayer.FeatureClass);
                        }
                        else if (!this.Redo)
                        {
                            num = this.CheckHas(pSFeature, this.m_EditLayer.FeatureClass);
                        }
                    }
                    if (this.chk == 3)
                    {
                        this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                        break;
                    }
                    if (this.chk == 2)
                    {
                        this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                    }
                    else
                    {
                        IFeature pFeature = this.m_EditLayer.FeatureClass.CreateFeature();
                        IClone shape = (IClone) pSFeature.Shape;
                        if (shape == null)
                        {
                            return;
                        }
                        IPolygon polygon = (IPolygon) shape.Clone();
                        IGeometry geometry = polygon;
                        IArea area = geometry as IArea;
                        try
                        {
                            pFeature.Shape = new PolygonClass();
                            pFeature.Shape = polygon;
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            goto Label_03A3;
                        }
                        int index = pFeature.Fields.FindField("Task_ID".ToUpper());
                        if (index > -1)
                        {
                            pFeature.set_Value(index, EditTask.TaskID.ToString());
                        }
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                        index = pFeature.Fields.FindField(configValue);
                        if ((index > -1) && this.checkEditXiban.Checked)
                        {
                            int num3 = int.Parse(this.SubID) + 1;
                            pFeature.set_Value(index, num3.ToString());
                        }
                        this.SetFeatureArea(pFeature);
                        try
                        {
                            Editor.UniqueInstance.AddAttribute = false;
                            pFeature.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                            if (this.SubID == "")
                            {
                                this.SubID = "0";
                            }
                            this.SubID = (int.Parse(this.SubID) + 1).ToString();
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            Editor.UniqueInstance.AddAttribute = false;
                            pFeature.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                    }
                Label_03A3:
                    pSFeature = cursor.NextFeature();
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                catch (Exception)
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                pWorkspaceEdit.StopEditing(true);
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + featureClass.AliasName + "] - 完成";
                this.labelprogress.Visible = true;
                this.mHookHelper.ActiveView.Refresh();
                MessageBox.Show(this.labelprogress.Text, "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "DoInput2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DoInput3(IWorkspaceEdit pWorkspaceEdit, IFeatureWorkspace pSWorkspace)
        {
            try
            {
                int num;
                IFeatureClass mDCFeatureClass;
                IFeature feature;
                int num2;
                IFeature feature2;
                IClone shape;
                IPolygon polygon;
                IGeometry geometry;
                IArea area;
                IGeometry shapeCopy;
                double num3;
                int num4;
                IField field;
                IField field2;
                int num5;
                IRow row;
                int num8;
                IRow row2;
                this.DCInputAll = true;
                bool flag = true;
                this.DCInputAll2 = true;
                bool flag2 = true;
                for (num = 0; num < this.mDCDataTable.Rows.Count; num++)
                {
                    if (!((bool) this.mDCDataTable.Rows[num][0]))
                    {
                        this.DCInputAll = false;
                    }
                    if ((bool) this.mDCDataTable.Rows[num][0])
                    {
                        flag = false;
                    }
                }
                ITable pTTable = null;
                ITable table2 = null;
                string name = "";
                string str2 = "";
                if (this.mEditKind2 == "CaiFa")
                {
                    name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "TableName");
                    pTTable = this.m_EditWorkspace.OpenTable(name);
                    table2 = pSWorkspace.OpenTable(name);
                    str2 = "每木检尺";
                    if (this.mDCDataTable2 == null)
                    {
                        IDataset mDCTable = this.mDCTable as IDataset;
                        this.InitialGridviewDC(mDCTable, 1);
                    }
                    num = 0;
                    while (num < this.mDCDataTable2.Rows.Count)
                    {
                        if (!((bool) this.mDCDataTable2.Rows[num][0]))
                        {
                            this.DCInputAll2 = false;
                        }
                        if ((bool) this.mDCDataTable2.Rows[num][0])
                        {
                            flag2 = false;
                        }
                        num++;
                    }
                }
                if (this.DCInputAll)
                {
                    name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                    mDCFeatureClass = pSWorkspace.OpenFeatureClass(name);
                    if (mDCFeatureClass == null)
                    {
                        return;
                    }
                    string aliasName = mDCFeatureClass.AliasName;
                    IFeatureCursor cursor = mDCFeatureClass.Search(null, false);
                    feature = cursor.NextFeature();
                    this.labelprogress.Text = "导入" + this.mEditKind + "图层[" + mDCFeatureClass.AliasName + "]";
                    pWorkspaceEdit.StartEditing(false);
                    this.Redo = false;
                    this.chk = 0;
                    while (feature != null)
                    {
                        if (this.richTextBox.Text == "")
                        {
                            this.richTextBox.Text = "导入要素" + feature.OID;
                        }
                        else
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                        }
                        this.richTextBox.Refresh();
                        num2 = 0;
                        if ((this.chk != 1) || !this.Redo)
                        {
                            if ((this.chk == 2) && this.Redo)
                            {
                                this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                            }
                            else if (!this.Redo)
                            {
                                num2 = this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                            }
                        }
                        if (this.chk == 3)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                            break;
                        }
                        if (this.chk == 2)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                        }
                        else
                        {
                            pWorkspaceEdit.StartEditOperation();
                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                            shape = (IClone) feature.Shape;
                            if (shape == null)
                            {
                                return;
                            }
                            polygon = (IPolygon) shape.Clone();
                            geometry = polygon;
                            try
                            {
                                feature2.Shape = new PolygonClass();
                                feature2.Shape = polygon;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                goto Label_06AA;
                            }
                            area = geometry as IArea;
                            num = feature2.Fields.FindField("XIAN");
                            if (num != -1)
                            {
                                feature2.set_Value(num, EditTask.DistCode.Substring(0, 6));
                            }
                            num = feature2.Fields.FindField("MIAN_JI");
                            if (num != -1)
                            {
                                shapeCopy = feature2.ShapeCopy;
                                num3 = Math.Round(Math.Abs((double) (((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area / 10000.0)), 2);
                                feature2.set_Value(num, num3);
                            }
                            num4 = 0;
                            while (num4 < feature.Fields.FieldCount)
                            {
                                field = feature.Fields.get_Field(num4);
                                if (num4 < feature2.Fields.FieldCount)
                                {
                                    if (feature2.Fields.get_Field(num4).Name != field.Name)
                                    {
                                        num5 = feature2.Fields.FindField(field.Name);
                                        if (num5 > -1)
                                        {
                                            field2 = feature2.Fields.get_Field(num5);
                                            feature2.set_Value(num5, feature.get_Value(num4));
                                        }
                                    }
                                    else
                                    {
                                        feature2.set_Value(num4, feature.get_Value(num4));
                                    }
                                }
                                num4++;
                            }
                            num = feature2.Fields.FindField("Task_ID");
                            if (num != -1)
                            {
                                feature2.set_Value(num, EditTask.TaskID);
                            }
                            try
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                feature2.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                Editor.UniqueInstance.AddAttribute = false;
                                feature2.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                            try
                            {
                                pWorkspaceEdit.StopEditOperation();
                            }
                            catch (Exception)
                            {
                                pWorkspaceEdit.StopEditOperation();
                            }
                        }
                    Label_06AA:
                        feature = cursor.NextFeature();
                    }
                    pWorkspaceEdit.StopEditing(true);
                    this.labelprogress.Text = "导入" + this.mEditKind + "图层[" + mDCFeatureClass.AliasName + "] - 完成";
                    this.labelprogress.Visible = true;
                }
                else if (!flag)
                {
                    mDCFeatureClass = this.mDCFeatureClass;
                    this.labelprogress.Text = "导入" + this.mEditKind + "图层[" + mDCFeatureClass.AliasName + "]";
                    pWorkspaceEdit.StartEditing(false);
                    this.Redo = false;
                    this.chk = 0;
                    this.Redo2 = false;
                    this.chk2 = 0;
                    for (num = 0; num < this.mDCDataTable.Rows.Count; num++)
                    {
                        if (!((bool) this.mDCDataTable.Rows[num][0]))
                        {
                            continue;
                        }
                        feature = this.mDCDataTable.Rows[num]["object"] as IFeature;
                        if (this.richTextBox.Text == "")
                        {
                            this.richTextBox.Text = "导入要素" + feature.OID;
                        }
                        else
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                        }
                        this.richTextBox.Refresh();
                        int num6 = 0;
                        if ((this.chk != 1) || !this.Redo)
                        {
                            if ((this.chk == 2) && this.Redo)
                            {
                                this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                            }
                            else if (!this.Redo)
                            {
                                num6 = this.CheckHas(feature, this.m_EditLayer.FeatureClass);
                            }
                        }
                        if (this.chk == 3)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                            break;
                        }
                        if (this.chk == 2)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                            continue;
                        }
                        pWorkspaceEdit.StartEditOperation();
                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                        shape = (IClone) feature.Shape;
                        if (shape == null)
                        {
                            return;
                        }
                        polygon = (IPolygon) shape.Clone();
                        geometry = polygon;
                        try
                        {
                            feature2.Shape = new PolygonClass();
                            feature2.Shape = polygon;
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            continue;
                        }
                        area = geometry as IArea;
                        num2 = feature2.Fields.FindField("XIAN");
                        if (num2 != -1)
                        {
                            feature2.set_Value(num2, EditTask.DistCode.Substring(0, 6));
                        }
                        num2 = feature2.Fields.FindField("MIAN_JI");
                        if (num2 != -1)
                        {
                            shapeCopy = feature2.ShapeCopy;
                            num3 = Math.Round(Math.Abs((double) (((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area / 10000.0)), 2);
                            feature2.set_Value(num2, num3);
                        }
                        num4 = 0;
                        while (num4 < feature.Fields.FieldCount)
                        {
                            if (num4 < feature2.Fields.FieldCount)
                            {
                                field = feature.Fields.get_Field(num4);
                                if (feature2.Fields.get_Field(num4).Name != field.Name)
                                {
                                    num5 = feature2.Fields.FindField(field.Name);
                                    if (num5 > -1)
                                    {
                                        field2 = feature2.Fields.get_Field(num5);
                                        feature2.set_Value(num5, feature.get_Value(num4));
                                    }
                                }
                                else if (((field != mDCFeatureClass.AreaField) && (field != mDCFeatureClass.LengthField)) && (field.Name != mDCFeatureClass.OIDFieldName))
                                {
                                    feature2.set_Value(num4, feature.get_Value(num4));
                                }
                            }
                            num4++;
                        }
                        num2 = feature2.Fields.FindField("Task_ID");
                        if (num2 != -1)
                        {
                            feature2.set_Value(num2, EditTask.TaskID);
                        }
                        if ((!this.gridView6.Columns[0].Visible && (this.radioGroupDC.SelectedIndex == 0)) && ((pTTable != null) && (table2 != null)))
                        {
                            IQueryFilter queryFilter = new QueryFilterClass();
                            int index = feature2.Fields.FindField("CUN");
                            string str4 = feature2.get_Value(index).ToString();
                            index = feature2.Fields.FindField("LIN_BAN");
                            string str5 = feature2.get_Value(index).ToString();
                            index = feature2.Fields.FindField("XIAO_BAN");
                            string str6 = feature2.get_Value(index).ToString();
                            index = feature2.Fields.FindField("XI_BAN");
                            string str7 = feature2.get_Value(index).ToString();
                            queryFilter.WhereClause = "CUN='" + str4 + "' and LIN_BAN='" + str5 + "' and DCXB='" + str6 + "' and ZYXB='" + str7 + "'";
                            ICursor cursor2 = table2.Search(queryFilter, false);
                            row = cursor2.NextRow();
                            while (row != null)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "\n导入检尺记录" + row.OID;
                                this.richTextBox.Refresh();
                                num8 = 0;
                                if ((this.chk2 != 1) || !this.Redo2)
                                {
                                    if ((this.chk2 == 2) && this.Redo2)
                                    {
                                        this.CheckHas2(row, pTTable);
                                    }
                                    else if (!this.Redo2)
                                    {
                                        num8 = this.CheckHas2(row, pTTable);
                                    }
                                }
                                if (this.chk2 == 3)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                                    break;
                                }
                                if (this.chk2 == 2)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                                }
                                else
                                {
                                    row2 = pTTable.CreateRow();
                                    num4 = 0;
                                    while (num4 < row.Fields.FieldCount)
                                    {
                                        field = row.Fields.get_Field(num4);
                                        if (row2.Fields.get_Field(num4).Name != field.Name)
                                        {
                                            num5 = row2.Fields.FindField(field.Name);
                                            if (num5 > -1)
                                            {
                                                field2 = row2.Fields.get_Field(num5);
                                                row2.set_Value(num5, row.get_Value(num4));
                                            }
                                        }
                                        else if (field.Name.ToLower() != "objectid")
                                        {
                                            row2.set_Value(num4, row.get_Value(num4));
                                        }
                                        num4++;
                                    }
                                    try
                                    {
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row2.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    catch (Exception)
                                    {
                                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row2.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                }
                                row = cursor2.NextRow();
                            }
                        }
                        try
                        {
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                        try
                        {
                            pWorkspaceEdit.StopEditOperation();
                        }
                        catch (Exception)
                        {
                            pWorkspaceEdit.StopEditOperation();
                        }
                    }
                    pWorkspaceEdit.StopEditing(true);
                    this.labelprogress.Text = "导入" + this.mEditKind + "图层[" + mDCFeatureClass.AliasName + "] - 完成";
                    this.labelprogress.Visible = true;
                }
                if (this.gridView6.Columns[0].Visible && ((pTTable != null) && (table2 != null)))
                {
                    if (this.DCInputAll2)
                    {
                        if ((pTTable == null) || (table2 == null))
                        {
                            return;
                        }
                        pWorkspaceEdit.StartEditing(false);
                        int num9 = table2.RowCount(null);
                        GC.Collect();
                        ICursor cursor3 = table2.Search(null, false);
                        this.labelprogress.Text = "导入" + this.mEditKind + "属性表[" + (table2 as IDataset).Name + "]";
                        for (num = 0; num < num9; num++)
                        {
                            IRow pSRow = cursor3.NextRow();
                            if (pSRow != null)
                            {
                                num8 = 0;
                                if ((this.chk2 != 1) || !this.Redo2)
                                {
                                    if ((this.chk2 == 2) && this.Redo2)
                                    {
                                        this.CheckHas2(pSRow, pTTable);
                                    }
                                    else if (!this.Redo2)
                                    {
                                        num8 = this.CheckHas2(pSRow, pTTable);
                                    }
                                }
                                if (this.chk2 == 3)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                                    break;
                                }
                                if (this.chk2 == 2)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                                }
                                else
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + "\n导入检尺记录" + pSRow.OID;
                                    this.richTextBox.Refresh();
                                    pWorkspaceEdit.StartEditOperation();
                                    IRow row4 = pTTable.CreateRow();
                                    num4 = 0;
                                    while (num4 < table2.Fields.FieldCount)
                                    {
                                        field = table2.Fields.get_Field(num4);
                                        field2 = pTTable.Fields.get_Field(num4);
                                        if (field2.Name != pTTable.OIDFieldName)
                                        {
                                            if (field2.Name != field.Name)
                                            {
                                                num5 = pTTable.Fields.FindField(field.Name);
                                                if (num5 > -1)
                                                {
                                                    field2 = pTTable.Fields.get_Field(num5);
                                                    row4.set_Value(num5, pSRow.get_Value(num4));
                                                }
                                            }
                                            else
                                            {
                                                row4.set_Value(num4, pSRow.get_Value(num4));
                                            }
                                        }
                                        num4++;
                                    }
                                    try
                                    {
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row4.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    catch (Exception)
                                    {
                                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row4.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    try
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    catch (Exception)
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                }
                            }
                        }
                        pWorkspaceEdit.StopEditing(true);
                        this.labelprogress.Text = "导入" + this.mEditKind + "表[" + str2 + "] - 完成";
                        this.labelprogress.Visible = true;
                    }
                    else if (!flag2)
                    {
                        this.labelprogress.Text = "导入" + this.mEditKind + "属性表[" + (table2 as IDataset).Name + "]";
                        pWorkspaceEdit.StartEditing(false);
                        for (num = 0; num < this.mDCDataTable2.Rows.Count; num++)
                        {
                            if ((bool) this.mDCDataTable2.Rows[num][0])
                            {
                                row = this.mDCDataTable2.Rows[num]["object"] as IRow;
                                this.richTextBox.Text = this.richTextBox.Text + "\n导入记录" + row.OID;
                                this.richTextBox.Refresh();
                                int num10 = this.CheckHas2(row, pTTable);
                                if (num10 == 3)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 取消导入";
                                    break;
                                }
                                if (num10 == 2)
                                {
                                    this.richTextBox.Text = this.richTextBox.Text + " - 跳过";
                                }
                                else
                                {
                                    pWorkspaceEdit.StartEditOperation();
                                    row2 = pTTable.CreateRow();
                                    for (num4 = 0; num4 < row.Fields.FieldCount; num4++)
                                    {
                                        field = row.Fields.get_Field(num4);
                                        if (row2.Fields.get_Field(num4).Name != field.Name)
                                        {
                                            num5 = row2.Fields.FindField(field.Name);
                                            if (num5 > -1)
                                            {
                                                field2 = row2.Fields.get_Field(num5);
                                                row2.set_Value(num5, row.get_Value(num4));
                                            }
                                        }
                                        else if (field.Name.ToLower() != "objectid")
                                        {
                                            row2.set_Value(num4, row.get_Value(num4));
                                        }
                                    }
                                    try
                                    {
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row2.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    catch (Exception)
                                    {
                                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                        Editor.UniqueInstance.AddAttribute = false;
                                        row2.Store();
                                        Editor.UniqueInstance.AddAttribute = true;
                                    }
                                    try
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    catch (Exception)
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                }
                            }
                        }
                        pWorkspaceEdit.StopEditing(true);
                        this.labelprogress.Text = "导入" + this.mEditKind + "图层[" + (table2 as IDataset).Name + "] - 完成";
                        this.labelprogress.Visible = true;
                    }
                }
                this.mHookHelper.ActiveView.Refresh();
                MessageBox.Show(this.labelprogress.Text, "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "DoInput3", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private object GetFieldValue(IObject pObj, string sFieldName)
        {
            try
            {
                int index = pObj.Fields.FindField(sFieldName);
                if (index < 0)
                {
                    return null;
                }
                return pObj.get_Value(index);
            }
            catch
            {
                return null;
            }
        }

        private static string GetNode(string sKindCode)
        {
            if (sKindCode == "01")
            {
                return "Afforest";
            }
            if (sKindCode == "02")
            {
                return "Harvest";
            }
            if (sKindCode == "05")
            {
                return "Disaster";
            }
            if (sKindCode == "07")
            {
                return "ForestCase";
            }
            if (sKindCode == "04")
            {
                return "Expropriation";
            }
            if (sKindCode == "03")
            {
                return "Fire";
            }
            if (sKindCode == "08")
            {
                return "Sub";
            }
            return "Other";
        }

        private IGeometry GetPolygon()
        {
            try
            {
                if (this.mSelPointTable.Rows.Count == 0)
                {
                    return null;
                }
                DataRow[] rowArray = this.mSelPointTable.Select("", "点号 ASC ");
                IPointCollection points = new PolygonClass();
                object before = Missing.Value;
                object after = Missing.Value;
                for (int i = 0; i < rowArray.Length; i++)
                {
                    IPoint inPoint = (rowArray[i]["Shape"] as IGeometry) as IPoint;
                    points.AddPoint(inPoint, ref before, ref after);
                }
                points.AddPoint((rowArray[0]["Shape"] as IGeometry) as IPoint, ref before, ref after);
                IArea area = points as IArea;
                (points as ITopologicalOperator).Simplify();
                return (points as IGeometry);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IFeature GetXBFeature(IFeature pFeature)
        {
            Exception exception;
            try
            {
                if (this.mXBLayer == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    this.mXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                }
                if (this.mXBLayer == null)
                {
                    return null;
                }
                if (this.mXBLayer.FeatureClass == null)
                {
                    return null;
                }
                GC.Collect();
                IFeature feature = null;
                IFeature feature2 = null;
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pFeature.Shape;
                filter.GeometryField = this.mXBLayer.FeatureClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                IFeatureCursor cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                feature = cursor.NextFeature();
                double area = 0.0;
                if (feature == null)
                {
                    GC.Collect();
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                    cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                    if (feature == null)
                    {
                        GC.Collect();
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                        feature = cursor.NextFeature();
                        if (feature == null)
                        {
                            GC.Collect();
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                            feature = cursor.NextFeature();
                            if (feature == null)
                            {
                            }
                        }
                    }
                }
                GC.Collect();
                while (feature != null)
                {
                    GC.Collect();
                    IGeometry shapeCopy = feature.ShapeCopy;
                    IGeometry other = pFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                    @operator.IsKnownSimple_2 = false;
                    IGeometry geometry3 = null;
                    try
                    {
                        @operator.Simplify();
                        geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    if ((geometry3 != null) && !geometry3.IsEmpty)
                    {
                        if (area == 0.0)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                        else if (area < ((IArea) geometry3).Area)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                    }
                    feature = cursor.NextFeature();
                }
                GC.Collect();
                return feature2;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if ((e.Column.Caption == "源数据字段") || (e.Column.FieldName == "源数据字段"))
            {
                e.RepositoryItem = this.repositoryItemComboBox1;
                this.GridSelectIndex = e.RowHandle;
            }
            else if ((e.Column.Caption == "目标数据字段") || (e.Column.FieldName == "目标数据字段"))
            {
                this.GridSelectIndex = e.RowHandle;
            }
            else
            {
                this.GridSelectIndex = -1;
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void gridView2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.mHookHelper.FocusMap.ClearSelection();
                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                for (int i = 0; i < this.gridView3.GetSelectedRows().Length; i++)
                {
                    int rowHandle = this.gridView3.GetSelectedRows()[i];
                    DataRowView row = this.gridView3.GetRow(rowHandle) as DataRowView;
                    IFeature feature = this.mPointFeatureLayer.FeatureClass.GetFeature(int.Parse(row.Row["OID"].ToString()));
                    this.mHookHelper.FocusMap.SelectFeature(this.mPointFeatureLayer, feature);
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, feature.Shape.Envelope);
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "gridView2_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void gridView5_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
        }

        private void gridView5_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                this.simpleButtonInput.Enabled = false;
                if (((e.RowHandle > -1) && (e.Column.FieldName == "导入")) && bool.Parse(e.Value.ToString()))
                {
                    this.simpleButtonInput.Enabled = true;
                }
                if (!this.simpleButtonInput.Enabled)
                {
                    for (int i = 0; i < this.gridView5.RowCount; i++)
                    {
                        if (i != e.RowHandle)
                        {
                            DataRowView row = this.gridView5.GetRow(i) as DataRowView;
                            IFeature feature = row["object"] as IFeature;
                            if (!feature.Shape.IsEmpty && bool.Parse(row.Row[0].ToString()))
                            {
                                this.simpleButtonInput.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "gridView5_CellValueChanging", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            if (this.mDCFeatureLayer != null)
            {
                this.mHookHelper.FocusMap.ClearSelection();
                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            for (int i = 0; i < this.gridView5.GetSelectedRows().Length; i++)
            {
                int rowHandle = this.gridView5.GetSelectedRows()[i];
                DataRowView row = this.gridView5.GetRow(rowHandle) as DataRowView;
                IFeature feature = row["object"] as IFeature;
                if (!feature.Shape.IsEmpty)
                {
                    if (this.mDCFeatureLayer != null)
                    {
                        this.mHookHelper.FocusMap.SelectFeature(this.mDCFeatureLayer, feature);
                        GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                    }
                }
                else
                {
                    MessageBox.Show("当前记录图形要素为空", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void gridView5_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "gridView2_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void gridView5_MouseUp(object sender, MouseEventArgs e)
        {
        }

        public void Hook(object hook, string sEditKind, BarButtonItem barButtonItem)
        {
            try
            {
                this.mParButton = barButtonItem;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControl()
        {
            try
            {
                if (this.radioGroup2.Properties.Items.Count == 2)
                {
                    this.radioGroup2.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, this.mEditKind + "外调数据") });
                }
                else if (this.radioGroup2.Properties.Items.Count == 3)
                {
                    this.radioGroup2.Properties.Items[2].Description = this.mEditKind + "外调数据";
                }
                try
                {
                    this.radioGroup2.SelectedIndex = 0;
                    this.xtraTabControl1.SelectedTabPageIndex = 0;
                    this.radioGroupDC.SelectedIndex = 0;
                }
                catch (Exception)
                {
                }
                if ((this.mEditKind2 != "CaiFa") && (this.radioGroup2.Properties.Items.Count > 2))
                {
                    this.radioGroup2.Properties.Items.Remove(this.radioGroup2.Properties.Items[2]);
                }
                if (this.mEditKind2 == "YG")
                {
                    if (this.radioGroup2.Properties.Items.Count > 2)
                    {
                        this.radioGroup2.Properties.Items.Remove(this.radioGroup2.Properties.Items[2]);
                    }
                    if (this.radioGroup2.Properties.Items.Count > 1)
                    {
                        this.radioGroup2.Properties.Items.Remove(this.radioGroup2.Properties.Items[1]);
                    }
                }
                this.SetView(0);
                this.InitialFieldGrid();
                this.mRangeList = new ArrayList();
                this.gridControl5.DataSource = null;
                this.gridView5.Columns.Clear();
                this.gridControl6.DataSource = null;
                this.gridView6.Columns.Clear();
                this.mDCDataTable = null;
                this.mDCDataTable2 = null;
                this.mDCFeatureClass = null;
                this.mDCTable = null;
                this.xtraTabControl1.Enabled = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldGrid()
        {
            try
            {
                IFields fields;
                int num;
                DataRow row;
                string str3;
                this.mFieldTable = new DataTable();
                this.mFieldTable.Clear();
                DataColumn column = new DataColumn("目标数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("目标数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                this.mPointTable = new DataTable();
                this.mPointTable.Clear();
                column = new DataColumn("点号", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("X坐标", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("Y坐标", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("时间", typeof(string));
                this.mPointTable.Columns.Add(column);
                this.mPointTable2 = new DataTable();
                this.mPointTable2.Clear();
                column = new DataColumn("OID", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("点号", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("X坐标", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("Y坐标", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("时间", typeof(string));
                this.mPointTable2.Columns.Add(column);
                this.mPolyTable = new DataTable();
                this.mPolyTable.Clear();
                column = new DataColumn("OID", typeof(string));
                this.mPolyTable.Columns.Add(column);
                column = new DataColumn("小班号", typeof(string));
                this.mPolyTable.Columns.Add(column);
                string name = "";
                if (name != "")
                {
                    try
                    {
                        this.m_EditTable = this.m_EditWorkspace.OpenTable(name);
                    }
                    catch (Exception)
                    {
                    }
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldUID");
                this.mKeyFieldName = configValue;
                if (this.m_EditTable != null)
                {
                    fields = this.m_EditTable.Fields;
                    for (num = 0; num < fields.FieldCount; num++)
                    {
                        row = this.mFieldTable.NewRow();
                        if ((((fields.get_Field(num).Name != configValue) && (fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.LengthField))) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.AreaField))
                        {
                            str3 = fields.get_Field(num).Type.ToString().Replace("esriFieldType", "");
                            row[0] = fields.get_Field(num).AliasName + "[" + str3 + "]";
                            row[1] = fields.get_Field(num).Name;
                            row[2] = "";
                            row[3] = "";
                            this.mFieldTable.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    fields = this.m_EditLayer.FeatureClass.Fields;
                    for (num = 0; num < fields.FieldCount; num++)
                    {
                        row = this.mFieldTable.NewRow();
                        if ((((fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.OIDFieldName) && (fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.ShapeFieldName)) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.LengthField)) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.AreaField))
                        {
                            str3 = fields.get_Field(num).Type.ToString().Replace("esriFieldType", "");
                            row[0] = fields.get_Field(num).AliasName + "[" + str3 + "]";
                            row[1] = fields.get_Field(num).Name;
                            row[2] = "";
                            row[3] = "";
                            this.mFieldTable.Rows.Add(row);
                        }
                    }
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mFieldTable;
                this.gridView1.RefreshData();
                this.gridView1.Columns[1].Visible = false;
                this.gridView1.Columns[3].Visible = false;
                this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
                this.gridControl2.DataSource = null;
                this.gridView2.Columns.Clear();
                this.gridControl2.DataSource = this.mPointTable;
                this.gridView2.RefreshData();
                this.gridControl3.DataSource = null;
                this.gridView3.Columns.Clear();
                this.gridControl3.DataSource = this.mPointTable2;
                this.gridView3.RefreshData();
                this.gridControl4.DataSource = null;
                this.gridView4.Columns.Clear();
                this.gridControl4.DataSource = this.mPolyTable;
                this.gridView4.RefreshData();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "InitialFieldGrid", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldList(IFeatureClass pFeatureClass)
        {
            try
            {
                this.repositoryItemComboBox1.Items.Clear();
                this.repositoryItemComboBox1.Items.Add("");
                for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
                {
                    if (pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.ShapeFieldName)
                    {
                        string str = pFeatureClass.Fields.get_Field(i).Type.ToString().Replace("esriFieldType", "");
                        if (pFeatureClass.Fields.get_Field(i).AliasName != pFeatureClass.Fields.get_Field(i).Name)
                        {
                            this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).AliasName + "[" + pFeatureClass.Fields.get_Field(i).Name + "][" + str + "]");
                        }
                        else
                        {
                            this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).AliasName + "[" + str + "]");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "InitialFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialGridviewDC(IDataset pDataset, int index)
        {
            try
            {
                IFields fields;
                string[] strArray;
                DataColumn column;
                int num;
                int num2;
                IField field;
                int num3;
                DataRow row;
                string str;
                string str2;
                ICodedValueDomain domain;
                int num4;
                if (index == 0)
                {
                    if (pDataset == null)
                    {
                        this.gridControl5.DataSource = null;
                        this.gridView5.Columns.Clear();
                    }
                    else
                    {
                        if (this.mDCDataTable == null)
                        {
                            IFeatureClass class2 = pDataset as IFeatureClass;
                            fields = class2.Fields;
                            IFeatureCursor cursor = class2.Search(null, false);
                            IFeature feature = cursor.NextFeature();
                            strArray = "XIAN,XIANG,CUN,LIN_BAN,XIAO_BAN,XI_BAN".Split(new char[] { ',' });
                            this.mDCDataTable = new DataTable();
                            this.mDCDataTable.Clear();
                            column = new DataColumn("导入", typeof(bool));
                            this.mDCDataTable.Columns.Add(column);
                            column = new DataColumn("序号", typeof(string));
                            this.mDCDataTable.Columns.Add(column);
                            num = 0;
                            while (num < strArray.Length)
                            {
                                num2 = fields.FindField(strArray[num]);
                                if (num2 > -1)
                                {
                                    column = new DataColumn(fields.get_Field(num2).AliasName, typeof(string));
                                    this.mDCDataTable.Columns.Add(column);
                                }
                                num++;
                            }
                            column = new DataColumn("object", typeof(object));
                            this.mDCDataTable.Columns.Add(column);
                            num3 = 0;
                            while (feature != null)
                            {
                                num3++;
                                row = this.mDCDataTable.NewRow();
                                row[0] = false;
                                row[1] = num3;
                                num = 0;
                                while (num < strArray.Length)
                                {
                                    num2 = fields.FindField(strArray[num]);
                                    str = feature.get_Value(num2).ToString();
                                    if (num2 > -1)
                                    {
                                        str2 = "";
                                        field = fields.get_Field(num2);
                                        if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                                        {
                                            str2 = str;
                                            domain = (ICodedValueDomain) field.Domain;
                                            num4 = 0;
                                            while (num4 < domain.CodeCount)
                                            {
                                                if (str == domain.get_Value(num4).ToString())
                                                {
                                                    str2 = domain.get_Name(num4);
                                                    break;
                                                }
                                                num4++;
                                            }
                                            str = str2;
                                        }
                                    }
                                    row[num + 2] = str;
                                    num++;
                                }
                                row["object"] = feature;
                                this.mDCDataTable.Rows.Add(row);
                                feature = cursor.NextFeature();
                            }
                        }
                        this.gridControl5.DataSource = this.mDCDataTable;
                        this.gridView5.OptionsBehavior.Editable = true;
                        this.gridView5.RefreshData();
                        this.gridView5.Columns[this.gridView5.Columns.Count - 1].Visible = false;
                        this.gridView5.Columns[0].OptionsColumn.AllowEdit = true;
                        for (num = 1; num < this.gridView5.Columns.Count; num++)
                        {
                            this.gridView5.Columns[num].OptionsColumn.AllowEdit = false;
                        }
                    }
                }
                else if (index == 1)
                {
                    if (pDataset == null)
                    {
                        this.gridControl6.DataSource = null;
                        this.gridView6.Columns.Clear();
                    }
                    else
                    {
                        if (this.mDCDataTable2 == null)
                        {
                            ITable table = pDataset as ITable;
                            fields = table.Fields;
                            ICursor cursor2 = table.Search(null, false);
                            IRow row2 = cursor2.NextRow();
                            strArray = "CUN,LIN_BAN,DCXB,ZYXB,BZDH".Split(new char[] { ',' });
                            this.mDCDataTable2 = new DataTable();
                            this.mDCDataTable2.Clear();
                            column = new DataColumn("导入", typeof(bool));
                            this.mDCDataTable2.Columns.Add(column);
                            column = new DataColumn("序号", typeof(string));
                            this.mDCDataTable2.Columns.Add(column);
                            num = 0;
                            while (num < strArray.Length)
                            {
                                num2 = fields.FindField(strArray[num]);
                                if (num2 > -1)
                                {
                                    column = new DataColumn(fields.get_Field(num2).AliasName, typeof(string));
                                    this.mDCDataTable2.Columns.Add(column);
                                }
                                num++;
                            }
                            column = new DataColumn("object", typeof(object));
                            this.mDCDataTable2.Columns.Add(column);
                            num3 = 0;
                            while (row2 != null)
                            {
                                num3++;
                                row = this.mDCDataTable2.NewRow();
                                row[0] = false;
                                row[1] = num3;
                                num = 0;
                                while (num < strArray.Length)
                                {
                                    num2 = fields.FindField(strArray[num]);
                                    str = row2.get_Value(num2).ToString();
                                    if (num2 > -1)
                                    {
                                        str2 = "";
                                        field = fields.get_Field(num2);
                                        if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                                        {
                                            str2 = str;
                                            domain = (ICodedValueDomain) field.Domain;
                                            for (num4 = 0; num4 < domain.CodeCount; num4++)
                                            {
                                                if (str == domain.get_Value(num4).ToString())
                                                {
                                                    str2 = domain.get_Name(num4);
                                                    break;
                                                }
                                            }
                                            str = str2;
                                        }
                                    }
                                    row[num + 2] = str;
                                    num++;
                                }
                                row["object"] = row;
                                this.mDCDataTable2.Rows.Add(row);
                                row2 = cursor2.NextRow();
                            }
                        }
                        this.gridControl6.DataSource = null;
                        this.gridView6.RefreshData();
                        this.gridView6.Columns.Clear();
                        this.gridControl6.DataSource = this.mDCDataTable2;
                        this.gridView6.OptionsBehavior.Editable = true;
                        this.gridView6.RefreshData();
                        this.gridView6.Columns[this.gridView6.Columns.Count - 1].Visible = false;
                        for (num = 0; num < this.gridView6.Columns.Count; num++)
                        {
                            this.gridView6.Columns[num].OptionsColumn.AllowEdit = false;
                        }
                        if (this.radioGroupDC.SelectedIndex == 0)
                        {
                            this.gridView6.Columns[0].Visible = false;
                            this.simpleButtonSelect.Enabled = false;
                        }
                        else if (this.radioGroupDC.SelectedIndex == 1)
                        {
                            this.gridView6.Columns[0].Visible = true;
                            this.simpleButtonSelect.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "InitialGridviewDC", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlInputData2));
            this.panelGridControl = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelField = new System.Windows.Forms.Panel();
            this.panelFieldMatch = new System.Windows.Forms.Panel();
            this.simpleButtonExpend = new DevExpress.XtraEditors.SimpleButton();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.checkPorpertyMatch = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonClear = new DevExpress.XtraEditors.SimpleButton();
            this.panelResource = new System.Windows.Forms.Panel();
            this.listBoxDataList = new DevExpress.XtraEditors.ListBoxControl();
            this.panel12 = new System.Windows.Forms.Panel();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButtonClear2 = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditDataPath = new DevExpress.XtraEditors.ButtonEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.panelTarget = new System.Windows.Forms.Panel();
            this.buttonEditTargetPath = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelDo = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonResult = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonConvert = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInputPoint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInput = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelprogress = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelResource0 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSetSubID = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelSourceInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioGroup3 = new DevExpress.XtraEditors.RadioGroup();
            this.checkEditXiban = new DevExpress.XtraEditors.CheckEdit();
            this.panelSubID = new System.Windows.Forms.Panel();
            this.panelClearAll = new System.Windows.Forms.Panel();
            this.checkEditClear = new DevExpress.XtraEditors.CheckEdit();
            this.panelSetXB = new System.Windows.Forms.Panel();
            this.checkEditXB = new DevExpress.XtraEditors.CheckEdit();
            this.panelSetID = new System.Windows.Forms.Panel();
            this.simpleButtonExpend2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelPointList = new System.Windows.Forms.Panel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPointInfo2 = new System.Windows.Forms.Label();
            this.simpleButtonSelected = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelPointList = new System.Windows.Forms.Label();
            this.simpleButtonSelectTool = new DevExpress.XtraEditors.SimpleButton();
            this.panelPolyList = new System.Windows.Forms.Panel();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.simpleButtonDeletePoly = new DevExpress.XtraEditors.SimpleButton();
            this.panelSet = new System.Windows.Forms.Panel();
            this.panelDiaoCha = new System.Windows.Forms.Panel();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl6 = new DevExpress.XtraGrid.GridControl();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.radioGroupDC = new DevExpress.XtraEditors.RadioGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDCView = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.radioGroupCF = new DevExpress.XtraEditors.RadioGroup();
            this.label8 = new System.Windows.Forms.Label();
            this.panelPoints = new System.Windows.Forms.Panel();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPointInfo = new System.Windows.Forms.Label();
            this.simpleButtonSel = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelGPS = new System.Windows.Forms.Panel();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelRseult = new System.Windows.Forms.Panel();
            this.gridControl7 = new DevExpress.XtraGrid.GridControl();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox7 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.simpleButtonResultList = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panelGridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.panelField.SuspendLayout();
            this.panelFieldMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPorpertyMatch.Properties)).BeginInit();
            this.panelResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxDataList)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.panelTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditTargetPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panelDo.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelResource0.SuspendLayout();
            this.panelSetSubID.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXiban.Properties)).BeginInit();
            this.panelSubID.SuspendLayout();
            this.panelClearAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClear.Properties)).BeginInit();
            this.panelSetXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXB.Properties)).BeginInit();
            this.panelSetID.SuspendLayout();
            this.panelPointList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelPolyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            this.panel10.SuspendLayout();
            this.panelSet.SuspendLayout();
            this.panelDiaoCha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDC.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCF.Properties)).BeginInit();
            this.panelPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelGPS.SuspendLayout();
            this.panelRseult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).BeginInit();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGridControl
            // 
            this.panelGridControl.BackColor = System.Drawing.Color.Transparent;
            this.panelGridControl.Controls.Add(this.gridControl1);
            this.panelGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridControl.Location = new System.Drawing.Point(6, 30);
            this.panelGridControl.Name = "panelGridControl";
            this.panelGridControl.Padding = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.panelGridControl.Size = new System.Drawing.Size(357, 120);
            this.panelGridControl.TabIndex = 17;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(357, 110);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "目标属性字段";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "匹配源属性字段";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.SelectedIndexChanged += new System.EventHandler(this.repositoryItemComboBox1_SelectedIndexChanged);
            this.repositoryItemComboBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.repositoryItemComboBox1_MouseUp);
            // 
            // panelField
            // 
            this.panelField.BackColor = System.Drawing.Color.Transparent;
            this.panelField.Controls.Add(this.panelGridControl);
            this.panelField.Controls.Add(this.panelFieldMatch);
            this.panelField.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelField.Location = new System.Drawing.Point(0, 294);
            this.panelField.Name = "panelField";
            this.panelField.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.panelField.Size = new System.Drawing.Size(369, 150);
            this.panelField.TabIndex = 18;
            // 
            // panelFieldMatch
            // 
            this.panelFieldMatch.Controls.Add(this.simpleButtonExpend);
            this.panelFieldMatch.Controls.Add(this.simpleButtonReset);
            this.panelFieldMatch.Controls.Add(this.checkPorpertyMatch);
            this.panelFieldMatch.Controls.Add(this.simpleButtonClear);
            this.panelFieldMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFieldMatch.Location = new System.Drawing.Point(6, 0);
            this.panelFieldMatch.Name = "panelFieldMatch";
            this.panelFieldMatch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelFieldMatch.Size = new System.Drawing.Size(357, 30);
            this.panelFieldMatch.TabIndex = 17;
            // 
            // simpleButtonExpend
            // 
            this.simpleButtonExpend.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend.ImageIndex = 14;
            this.simpleButtonExpend.ImageList = this.ImageList1;
            this.simpleButtonExpend.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend.Location = new System.Drawing.Point(291, 4);
            this.simpleButtonExpend.Name = "simpleButtonExpend";
            this.simpleButtonExpend.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonExpend.TabIndex = 16;
            this.simpleButtonExpend.ToolTip = "展开";
            this.simpleButtonExpend.Visible = false;
            this.simpleButtonExpend.Click += new System.EventHandler(this.simpleButtonExpend_Click);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            this.ImageList1.Images.SetKeyName(16, "(30,24).png");
            this.ImageList1.Images.SetKeyName(17, "(00,02).png");
            this.ImageList1.Images.SetKeyName(18, "(00,17).png");
            this.ImageList1.Images.SetKeyName(19, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(21, "(01,25).png");
            this.ImageList1.Images.SetKeyName(22, "(05,32).png");
            this.ImageList1.Images.SetKeyName(23, "(06,32).png");
            this.ImageList1.Images.SetKeyName(24, "(07,32).png");
            this.ImageList1.Images.SetKeyName(25, "(08,32).png");
            this.ImageList1.Images.SetKeyName(26, "(08,36).png");
            this.ImageList1.Images.SetKeyName(27, "(09,36).png");
            this.ImageList1.Images.SetKeyName(28, "(10,26).png");
            this.ImageList1.Images.SetKeyName(29, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(31, "(12,29).png");
            this.ImageList1.Images.SetKeyName(32, "(11,32).png");
            this.ImageList1.Images.SetKeyName(33, "(11,36).png");
            this.ImageList1.Images.SetKeyName(34, "(13,32).png");
            this.ImageList1.Images.SetKeyName(35, "(19,31).png");
            this.ImageList1.Images.SetKeyName(36, "(22,18).png");
            this.ImageList1.Images.SetKeyName(37, "(25,27).png");
            this.ImageList1.Images.SetKeyName(38, "(29,43).png");
            this.ImageList1.Images.SetKeyName(39, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(41, "10.png");
            this.ImageList1.Images.SetKeyName(42, "11.png");
            this.ImageList1.Images.SetKeyName(43, "16.png");
            this.ImageList1.Images.SetKeyName(44, "17.png");
            this.ImageList1.Images.SetKeyName(45, "18.png");
            this.ImageList1.Images.SetKeyName(46, "19.png");
            this.ImageList1.Images.SetKeyName(47, "20.png");
            this.ImageList1.Images.SetKeyName(48, "21.png");
            this.ImageList1.Images.SetKeyName(49, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(51, "31.png");
            this.ImageList1.Images.SetKeyName(52, "41.png");
            this.ImageList1.Images.SetKeyName(53, "add.png");
            this.ImageList1.Images.SetKeyName(54, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(55, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(56, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(57, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(58, "cross.png");
            this.ImageList1.Images.SetKeyName(59, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(61, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(62, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(63, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(64, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(65, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(66, "flag blue.png");
            this.ImageList1.Images.SetKeyName(67, "flag red.png");
            this.ImageList1.Images.SetKeyName(68, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(69, "31.png");
            this.ImageList1.Images.SetKeyName(70, "42.png");
            this.ImageList1.Images.SetKeyName(71, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(72, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(73, "cursor.png");
            this.ImageList1.Images.SetKeyName(74, "cursor_small.png");
            this.ImageList1.Images.SetKeyName(75, "cut.png");
            this.ImageList1.Images.SetKeyName(76, "cut_red.png");
            this.ImageList1.Images.SetKeyName(77, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(78, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(79, "Feedicons_v2_024.png");
            this.ImageList1.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.ImageList1.Images.SetKeyName(81, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(82, "key.png");
            this.ImageList1.Images.SetKeyName(83, "page_add.png");
            this.ImageList1.Images.SetKeyName(84, "page_delete.png");
            this.ImageList1.Images.SetKeyName(85, "page_white_world.png");
            this.ImageList1.Images.SetKeyName(86, "page_world.png");
            this.ImageList1.Images.SetKeyName(87, "reload.png");
            this.ImageList1.Images.SetKeyName(88, "world_add.png");
            this.ImageList1.Images.SetKeyName(89, "world_delete.png");
            this.ImageList1.Images.SetKeyName(90, "zoom_in.png");
            this.ImageList1.Images.SetKeyName(91, "zoom_out.png");
            this.ImageList1.Images.SetKeyName(92, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(93, "Tipicon.ico");
            this.ImageList1.Images.SetKeyName(94, "Exit.png");
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.ImageIndex = 87;
            this.simpleButtonReset.ImageList = this.ImageList1;
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonReset.Location = new System.Drawing.Point(313, 4);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonReset.TabIndex = 13;
            this.simpleButtonReset.ToolTip = "重新匹配";
            this.simpleButtonReset.Visible = false;
            // 
            // checkPorpertyMatch
            // 
            this.checkPorpertyMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkPorpertyMatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkPorpertyMatch.Location = new System.Drawing.Point(0, 4);
            this.checkPorpertyMatch.Name = "checkPorpertyMatch";
            this.checkPorpertyMatch.Properties.Caption = "属性字段匹配:";
            this.checkPorpertyMatch.Size = new System.Drawing.Size(177, 19);
            this.checkPorpertyMatch.TabIndex = 14;
            this.checkPorpertyMatch.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            this.checkPorpertyMatch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkEdit1_MouseUp);
            // 
            // simpleButtonClear
            // 
            this.simpleButtonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClear.ImageIndex = 92;
            this.simpleButtonClear.ImageList = this.ImageList1;
            this.simpleButtonClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonClear.Location = new System.Drawing.Point(335, 4);
            this.simpleButtonClear.Name = "simpleButtonClear";
            this.simpleButtonClear.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonClear.TabIndex = 11;
            this.simpleButtonClear.ToolTip = "清除";
            this.simpleButtonClear.Visible = false;
            this.simpleButtonClear.Click += new System.EventHandler(this.simpleButtonClear_Click);
            // 
            // panelResource
            // 
            this.panelResource.BackColor = System.Drawing.Color.Transparent;
            this.panelResource.Controls.Add(this.listBoxDataList);
            this.panelResource.Controls.Add(this.panel12);
            this.panelResource.Controls.Add(this.buttonEditDataPath);
            this.panelResource.Controls.Add(this.label6);
            this.panelResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResource.Location = new System.Drawing.Point(0, 154);
            this.panelResource.Name = "panelResource";
            this.panelResource.Padding = new System.Windows.Forms.Padding(6, 2, 6, 6);
            this.panelResource.Size = new System.Drawing.Size(369, 140);
            this.panelResource.TabIndex = 16;
            this.panelResource.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // listBoxDataList
            // 
            this.listBoxDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDataList.Location = new System.Drawing.Point(6, 80);
            this.listBoxDataList.Name = "listBoxDataList";
            this.listBoxDataList.Size = new System.Drawing.Size(357, 54);
            this.listBoxDataList.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.simpleButtonAdd);
            this.panel12.Controls.Add(this.simpleButtonRemove);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Controls.Add(this.simpleButtonClear2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(6, 50);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel12.Size = new System.Drawing.Size(357, 30);
            this.panel12.TabIndex = 13;
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonAdd.ImageIndex = 71;
            this.simpleButtonAdd.ImageList = this.ImageList1;
            this.simpleButtonAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAdd.Location = new System.Drawing.Point(291, 4);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonAdd.TabIndex = 10;
            this.simpleButtonAdd.ToolTip = "添加";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // simpleButtonRemove
            // 
            this.simpleButtonRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRemove.ImageIndex = 72;
            this.simpleButtonRemove.ImageList = this.ImageList1;
            this.simpleButtonRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonRemove.Location = new System.Drawing.Point(313, 4);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonRemove.TabIndex = 9;
            this.simpleButtonRemove.ToolTip = "移除";
            this.simpleButtonRemove.Click += new System.EventHandler(this.simpleButtonRemove_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageList = this.ImageList1;
            this.label9.Location = new System.Drawing.Point(0, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "导入数据列表:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonClear2
            // 
            this.simpleButtonClear2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClear2.ImageIndex = 92;
            this.simpleButtonClear2.ImageList = this.ImageList1;
            this.simpleButtonClear2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonClear2.Location = new System.Drawing.Point(335, 4);
            this.simpleButtonClear2.Name = "simpleButtonClear2";
            this.simpleButtonClear2.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonClear2.TabIndex = 12;
            this.simpleButtonClear2.ToolTip = "清除";
            this.simpleButtonClear2.Click += new System.EventHandler(this.simpleButtonClear2_Click);
            // 
            // buttonEditDataPath
            // 
            this.buttonEditDataPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditDataPath.Location = new System.Drawing.Point(6, 30);
            this.buttonEditDataPath.Name = "buttonEditDataPath";
            this.buttonEditDataPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditDataPath.Size = new System.Drawing.Size(357, 20);
            this.buttonEditDataPath.TabIndex = 10;
            this.buttonEditDataPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditDataPath_ButtonClick);
            this.buttonEditDataPath.EditValueChanged += new System.EventHandler(this.buttonEditDataPath_EditValueChanged);
            this.buttonEditDataPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonEditDataPath_KeyPress);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "导入数据路径:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup2.Location = new System.Drawing.Point(6, 30);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "空间面状数据"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "导航定位文本文件"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐外调数据")});
            this.radioGroup2.Size = new System.Drawing.Size(357, 31);
            this.radioGroup2.TabIndex = 14;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            // 
            // panelTarget
            // 
            this.panelTarget.BackColor = System.Drawing.Color.Transparent;
            this.panelTarget.Controls.Add(this.buttonEditTargetPath);
            this.panelTarget.Controls.Add(this.label2);
            this.panelTarget.Controls.Add(this.radioGroup1);
            this.panelTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTarget.Location = new System.Drawing.Point(0, 1);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Padding = new System.Windows.Forms.Padding(6, 2, 6, 6);
            this.panelTarget.Size = new System.Drawing.Size(369, 85);
            this.panelTarget.TabIndex = 19;
            this.panelTarget.Visible = false;
            // 
            // buttonEditTargetPath
            // 
            this.buttonEditTargetPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditTargetPath.Enabled = false;
            this.buttonEditTargetPath.Location = new System.Drawing.Point(6, 55);
            this.buttonEditTargetPath.Name = "buttonEditTargetPath";
            this.buttonEditTargetPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditTargetPath.Size = new System.Drawing.Size(357, 20);
            this.buttonEditTargetPath.TabIndex = 10;
            this.buttonEditTargetPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditTargetPath_ButtonClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ImageList = this.ImageList1;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "目标数据路径:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(6, 2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "当前编辑图层"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定目标数据")});
            this.radioGroup1.Size = new System.Drawing.Size(357, 30);
            this.radioGroup1.TabIndex = 14;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panelDo
            // 
            this.panelDo.BackColor = System.Drawing.Color.Transparent;
            this.panelDo.Controls.Add(this.panel6);
            this.panelDo.Controls.Add(this.progressBar);
            this.panelDo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDo.Location = new System.Drawing.Point(2, 1761);
            this.panelDo.Name = "panelDo";
            this.panelDo.Padding = new System.Windows.Forms.Padding(6);
            this.panelDo.Size = new System.Drawing.Size(369, 37);
            this.panelDo.TabIndex = 27;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.simpleButtonResult);
            this.panel6.Controls.Add(this.simpleButtonConvert);
            this.panel6.Controls.Add(this.simpleButtonInputPoint);
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonInput);
            this.panel6.Controls.Add(this.simpleButtonClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(357, 24);
            this.panel6.TabIndex = 11;
            // 
            // simpleButtonResult
            // 
            this.simpleButtonResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonResult.ImageIndex = 8;
            this.simpleButtonResult.ImageList = this.ImageList1;
            this.simpleButtonResult.Location = new System.Drawing.Point(-27, 0);
            this.simpleButtonResult.Name = "simpleButtonResult";
            this.simpleButtonResult.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonResult.TabIndex = 14;
            this.simpleButtonResult.Text = "结果";
            this.simpleButtonResult.Visible = false;
            this.simpleButtonResult.Click += new System.EventHandler(this.simpleButtonResult_Click);
            // 
            // simpleButtonConvert
            // 
            this.simpleButtonConvert.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonConvert.ImageIndex = 40;
            this.simpleButtonConvert.ImageList = this.ImageList1;
            this.simpleButtonConvert.Location = new System.Drawing.Point(37, 0);
            this.simpleButtonConvert.Name = "simpleButtonConvert";
            this.simpleButtonConvert.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonConvert.TabIndex = 12;
            this.simpleButtonConvert.Text = "转换";
            this.simpleButtonConvert.ToolTip = "连接点集生成面";
            this.simpleButtonConvert.Visible = false;
            this.simpleButtonConvert.Click += new System.EventHandler(this.simpleButtonConvert_Click);
            // 
            // simpleButtonInputPoint
            // 
            this.simpleButtonInputPoint.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInputPoint.ImageIndex = 41;
            this.simpleButtonInputPoint.ImageList = this.ImageList1;
            this.simpleButtonInputPoint.Location = new System.Drawing.Point(101, 0);
            this.simpleButtonInputPoint.Name = "simpleButtonInputPoint";
            this.simpleButtonInputPoint.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonInputPoint.TabIndex = 11;
            this.simpleButtonInputPoint.Text = "导入点";
            this.simpleButtonInputPoint.ToolTip = "生成临时点图层";
            this.simpleButtonInputPoint.Visible = false;
            this.simpleButtonInputPoint.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 46;
            this.simpleButtonBack.ImageList = this.ImageList1;
            this.simpleButtonBack.Location = new System.Drawing.Point(165, 0);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonBack.TabIndex = 10;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // simpleButtonInput
            // 
            this.simpleButtonInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInput.ImageIndex = 52;
            this.simpleButtonInput.ImageList = this.ImageList1;
            this.simpleButtonInput.Location = new System.Drawing.Point(229, 0);
            this.simpleButtonInput.Name = "simpleButtonInput";
            this.simpleButtonInput.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonInput.TabIndex = 9;
            this.simpleButtonInput.Text = "导入";
            this.simpleButtonInput.Click += new System.EventHandler(this.simpleButtonInput_Click);
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClose.ImageIndex = 94;
            this.simpleButtonClose.ImageList = this.ImageList1;
            this.simpleButtonClose.Location = new System.Drawing.Point(293, 0);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonClose.TabIndex = 13;
            this.simpleButtonClose.Text = "关闭";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(6, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(357, 24);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // labelprogress
            // 
            this.labelprogress.BackColor = System.Drawing.Color.Transparent;
            this.labelprogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(357, 46);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            this.labelprogress.Click += new System.EventHandler(this.labelprogress_Click);
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel4);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLog.Location = new System.Drawing.Point(2, 911);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(6, 0, 6, 4);
            this.panelLog.Size = new System.Drawing.Size(369, 163);
            this.panelLog.TabIndex = 28;
            this.panelLog.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(6, 50);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(357, 109);
            this.panelControl1.TabIndex = 16;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(353, 105);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(6, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel4.Size = new System.Drawing.Size(357, 50);
            this.panel4.TabIndex = 15;
            // 
            // panelResource0
            // 
            this.panelResource0.BackColor = System.Drawing.Color.Transparent;
            this.panelResource0.Controls.Add(this.radioGroup2);
            this.panelResource0.Controls.Add(this.label3);
            this.panelResource0.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResource0.Location = new System.Drawing.Point(0, 86);
            this.panelResource0.Name = "panelResource0";
            this.panelResource0.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.panelResource0.Size = new System.Drawing.Size(369, 68);
            this.panelResource0.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "导入数据类型:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelSetSubID
            // 
            this.panelSetSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSetSubID.Controls.Add(this.panel5);
            this.panelSetSubID.Controls.Add(this.radioGroup3);
            this.panelSetSubID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetSubID.Location = new System.Drawing.Point(6, 30);
            this.panelSetSubID.Name = "panelSetSubID";
            this.panelSetSubID.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.panelSetSubID.Size = new System.Drawing.Size(357, 53);
            this.panelSetSubID.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panelControl2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 7);
            this.panel5.Size = new System.Drawing.Size(357, 75);
            this.panel5.TabIndex = 15;
            this.panel5.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelSourceInfo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(357, 30);
            this.panelControl2.TabIndex = 16;
            // 
            // labelSourceInfo
            // 
            this.labelSourceInfo.BackColor = System.Drawing.Color.White;
            this.labelSourceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSourceInfo.Location = new System.Drawing.Point(2, 2);
            this.labelSourceInfo.Name = "labelSourceInfo";
            this.labelSourceInfo.Size = new System.Drawing.Size(353, 26);
            this.labelSourceInfo.TabIndex = 31;
            this.labelSourceInfo.Text = "共计33个要素";
            this.labelSourceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "源数据信息:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup3
            // 
            this.radioGroup3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup3.Location = new System.Drawing.Point(0, 2);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "自动生成"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定生成")});
            this.radioGroup3.Size = new System.Drawing.Size(357, 28);
            this.radioGroup3.TabIndex = 31;
            this.radioGroup3.SelectedIndexChanged += new System.EventHandler(this.radioGroup3_SelectedIndexChanged);
            // 
            // checkEditXiban
            // 
            this.checkEditXiban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditXiban.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkEditXiban.Location = new System.Drawing.Point(0, 4);
            this.checkEditXiban.Name = "checkEditXiban";
            this.checkEditXiban.Properties.Caption = "生成班块编号";
            this.checkEditXiban.Size = new System.Drawing.Size(133, 19);
            this.checkEditXiban.TabIndex = 33;
            this.checkEditXiban.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            this.checkEditXiban.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkEdit2_MouseUp);
            // 
            // panelSubID
            // 
            this.panelSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSubID.Controls.Add(this.panelClearAll);
            this.panelSubID.Controls.Add(this.panelSetXB);
            this.panelSubID.Controls.Add(this.panelSetSubID);
            this.panelSubID.Controls.Add(this.panelSetID);
            this.panelSubID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubID.Location = new System.Drawing.Point(0, 444);
            this.panelSubID.Name = "panelSubID";
            this.panelSubID.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelSubID.Size = new System.Drawing.Size(369, 89);
            this.panelSubID.TabIndex = 31;
            this.panelSubID.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSubID_Paint);
            // 
            // panelClearAll
            // 
            this.panelClearAll.Controls.Add(this.checkEditClear);
            this.panelClearAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClearAll.Location = new System.Drawing.Point(6, 60);
            this.panelClearAll.Name = "panelClearAll";
            this.panelClearAll.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelClearAll.Size = new System.Drawing.Size(357, 30);
            this.panelClearAll.TabIndex = 32;
            // 
            // checkEditClear
            // 
            this.checkEditClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkEditClear.Location = new System.Drawing.Point(0, 4);
            this.checkEditClear.Name = "checkEditClear";
            this.checkEditClear.Properties.Caption = "清空编辑图层所有班块";
            this.checkEditClear.Size = new System.Drawing.Size(165, 19);
            this.checkEditClear.TabIndex = 33;
            // 
            // panelSetXB
            // 
            this.panelSetXB.Controls.Add(this.checkEditXB);
            this.panelSetXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetXB.Location = new System.Drawing.Point(6, 30);
            this.panelSetXB.Name = "panelSetXB";
            this.panelSetXB.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelSetXB.Size = new System.Drawing.Size(357, 30);
            this.panelSetXB.TabIndex = 31;
            // 
            // checkEditXB
            // 
            this.checkEditXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEditXB.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkEditXB.Location = new System.Drawing.Point(0, 4);
            this.checkEditXB.Name = "checkEditXB";
            this.checkEditXB.Properties.Caption = "自动读取二类小班信息";
            this.checkEditXB.Size = new System.Drawing.Size(165, 19);
            this.checkEditXB.TabIndex = 33;
            // 
            // panelSetID
            // 
            this.panelSetID.Controls.Add(this.simpleButtonExpend2);
            this.panelSetID.Controls.Add(this.checkEditXiban);
            this.panelSetID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetID.Location = new System.Drawing.Point(6, 0);
            this.panelSetID.Name = "panelSetID";
            this.panelSetID.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelSetID.Size = new System.Drawing.Size(357, 30);
            this.panelSetID.TabIndex = 15;
            // 
            // simpleButtonExpend2
            // 
            this.simpleButtonExpend2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend2.ImageIndex = 14;
            this.simpleButtonExpend2.ImageList = this.ImageList1;
            this.simpleButtonExpend2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend2.Location = new System.Drawing.Point(335, 4);
            this.simpleButtonExpend2.Name = "simpleButtonExpend2";
            this.simpleButtonExpend2.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonExpend2.TabIndex = 17;
            this.simpleButtonExpend2.ToolTip = "重新匹配";
            this.simpleButtonExpend2.Visible = false;
            this.simpleButtonExpend2.Click += new System.EventHandler(this.simpleButtonExpend2_Click);
            // 
            // panelPointList
            // 
            this.panelPointList.BackColor = System.Drawing.Color.Transparent;
            this.panelPointList.Controls.Add(this.panelControl3);
            this.panelPointList.Controls.Add(this.panel3);
            this.panelPointList.Controls.Add(this.panel8);
            this.panelPointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPointList.Location = new System.Drawing.Point(0, 0);
            this.panelPointList.Name = "panelPointList";
            this.panelPointList.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelPointList.Size = new System.Drawing.Size(369, 215);
            this.panelPointList.TabIndex = 32;
            this.panelPointList.Visible = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(6, 32);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl3.Size = new System.Drawing.Size(357, 145);
            this.panelControl3.TabIndex = 16;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(2, 4);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.gridControl3.Size = new System.Drawing.Size(353, 139);
            this.gridControl3.TabIndex = 33;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowColumnMoving = false;
            this.gridView3.OptionsCustomization.AllowSort = false;
            this.gridView3.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView3.OptionsFilter.AllowFilterEditor = false;
            this.gridView3.OptionsFilter.AllowMRUFilterList = false;
            this.gridView3.OptionsSelection.MultiSelect = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridView3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseUp);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "点号";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 20;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "X坐标";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Y坐标";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 70;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelPointInfo2);
            this.panel3.Controls.Add(this.simpleButtonSelected);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(6, 177);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel3.Size = new System.Drawing.Size(357, 32);
            this.panel3.TabIndex = 18;
            // 
            // labelPointInfo2
            // 
            this.labelPointInfo2.BackColor = System.Drawing.Color.Transparent;
            this.labelPointInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointInfo2.Location = new System.Drawing.Point(0, 4);
            this.labelPointInfo2.Name = "labelPointInfo2";
            this.labelPointInfo2.Size = new System.Drawing.Size(293, 24);
            this.labelPointInfo2.TabIndex = 17;
            this.labelPointInfo2.Text = "共计:300个点";
            this.labelPointInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonSelected
            // 
            this.simpleButtonSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelected.ImageIndex = 66;
            this.simpleButtonSelected.ImageList = this.ImageList1;
            this.simpleButtonSelected.Location = new System.Drawing.Point(293, 4);
            this.simpleButtonSelected.Name = "simpleButtonSelected";
            this.simpleButtonSelected.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonSelected.TabIndex = 18;
            this.simpleButtonSelected.Text = "选中";
            this.simpleButtonSelected.ToolTip = "查看选中图形对象";
            this.simpleButtonSelected.Visible = false;
            this.simpleButtonSelected.Click += new System.EventHandler(this.simpleButtonSelected_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelPointList);
            this.panel8.Controls.Add(this.simpleButtonSelectTool);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(6, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel8.Size = new System.Drawing.Size(357, 32);
            this.panel8.TabIndex = 15;
            // 
            // labelPointList
            // 
            this.labelPointList.BackColor = System.Drawing.Color.Transparent;
            this.labelPointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointList.Location = new System.Drawing.Point(0, 4);
            this.labelPointList.Name = "labelPointList";
            this.labelPointList.Size = new System.Drawing.Size(293, 24);
            this.labelPointList.TabIndex = 8;
            this.labelPointList.Text = "GPS点集列表:";
            this.labelPointList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonSelectTool
            // 
            this.simpleButtonSelectTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelectTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelectTool.ImageIndex = 73;
            this.simpleButtonSelectTool.ImageList = this.ImageList1;
            this.simpleButtonSelectTool.Location = new System.Drawing.Point(293, 4);
            this.simpleButtonSelectTool.Name = "simpleButtonSelectTool";
            this.simpleButtonSelectTool.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonSelectTool.TabIndex = 12;
            this.simpleButtonSelectTool.Text = "选择";
            this.simpleButtonSelectTool.ToolTip = "选择生成班块的点集";
            this.simpleButtonSelectTool.Visible = false;
            this.simpleButtonSelectTool.Click += new System.EventHandler(this.simpleButtonSelectTool_Click);
            // 
            // panelPolyList
            // 
            this.panelPolyList.BackColor = System.Drawing.Color.Transparent;
            this.panelPolyList.Controls.Add(this.panelControl4);
            this.panelPolyList.Controls.Add(this.panel10);
            this.panelPolyList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPolyList.Location = new System.Drawing.Point(0, 220);
            this.panelPolyList.Name = "panelPolyList";
            this.panelPolyList.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelPolyList.Size = new System.Drawing.Size(369, 177);
            this.panelPolyList.TabIndex = 33;
            this.panelPolyList.Visible = false;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl4);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(6, 32);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl4.Size = new System.Drawing.Size(357, 139);
            this.panelControl4.TabIndex = 16;
            // 
            // gridControl4
            // 
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.Location = new System.Drawing.Point(2, 4);
            this.gridControl4.MainView = this.gridView4;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox3});
            this.gridControl4.Size = new System.Drawing.Size(353, 133);
            this.gridControl4.TabIndex = 33;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView4.GridControl = this.gridControl4;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsCustomization.AllowColumnMoving = false;
            this.gridView4.OptionsCustomization.AllowSort = false;
            this.gridView4.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView4.OptionsFilter.AllowFilterEditor = false;
            this.gridView4.OptionsFilter.AllowMRUFilterList = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "点号";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 20;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "X坐标";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Y坐标";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 70;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.simpleButtonDeletePoly);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(6, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel10.Size = new System.Drawing.Size(357, 32);
            this.panel10.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "GPS面列表:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonDeletePoly
            // 
            this.simpleButtonDeletePoly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonDeletePoly.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonDeletePoly.ImageIndex = 81;
            this.simpleButtonDeletePoly.ImageList = this.ImageList1;
            this.simpleButtonDeletePoly.Location = new System.Drawing.Point(293, 4);
            this.simpleButtonDeletePoly.Name = "simpleButtonDeletePoly";
            this.simpleButtonDeletePoly.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonDeletePoly.TabIndex = 12;
            this.simpleButtonDeletePoly.Text = "删除";
            this.simpleButtonDeletePoly.ToolTip = "删除选中的班块";
            this.simpleButtonDeletePoly.Visible = false;
            this.simpleButtonDeletePoly.Click += new System.EventHandler(this.simpleButtonDeletePoly_Click);
            // 
            // panelSet
            // 
            this.panelSet.Controls.Add(this.panelDiaoCha);
            this.panelSet.Controls.Add(this.panelPoints);
            this.panelSet.Controls.Add(this.panelSubID);
            this.panelSet.Controls.Add(this.panelField);
            this.panelSet.Controls.Add(this.panelResource);
            this.panelSet.Controls.Add(this.panelResource0);
            this.panelSet.Controls.Add(this.panelTarget);
            this.panelSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSet.Location = new System.Drawing.Point(2, 2);
            this.panelSet.Name = "panelSet";
            this.panelSet.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelSet.Size = new System.Drawing.Size(369, 909);
            this.panelSet.TabIndex = 34;
            // 
            // panelDiaoCha
            // 
            this.panelDiaoCha.BackColor = System.Drawing.Color.Transparent;
            this.panelDiaoCha.Controls.Add(this.panelControl6);
            this.panelDiaoCha.Controls.Add(this.panel1);
            this.panelDiaoCha.Controls.Add(this.panel9);
            this.panelDiaoCha.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDiaoCha.Location = new System.Drawing.Point(0, 748);
            this.panelDiaoCha.Name = "panelDiaoCha";
            this.panelDiaoCha.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelDiaoCha.Size = new System.Drawing.Size(369, 181);
            this.panelDiaoCha.TabIndex = 36;
            this.panelDiaoCha.Visible = false;
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.xtraTabControl1);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(6, 30);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl6.Size = new System.Drawing.Size(357, 115);
            this.panelControl6.TabIndex = 16;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(357, 113);
            this.xtraTabControl1.TabIndex = 34;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl5);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.xtraTabPage1.Size = new System.Drawing.Size(351, 84);
            this.xtraTabPage1.Text = "采伐数据";
            // 
            // gridControl5
            // 
            this.gridControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl5.Location = new System.Drawing.Point(2, 2);
            this.gridControl5.MainView = this.gridView5;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox5});
            this.gridControl5.Size = new System.Drawing.Size(347, 80);
            this.gridControl5.TabIndex = 33;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridControl5;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsCustomization.AllowColumnMoving = false;
            this.gridView5.OptionsCustomization.AllowSort = false;
            this.gridView5.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView5.OptionsFilter.AllowFilterEditor = false;
            this.gridView5.OptionsFilter.AllowMRUFilterList = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            this.gridView5.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView5_FocusedRowChanged);
            this.gridView5.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView5_CellValueChanged);
            this.gridView5.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView5_CellValueChanging);
            this.gridView5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView5_MouseUp);
            this.gridView5.DoubleClick += new System.EventHandler(this.gridView5_DoubleClick);
            // 
            // repositoryItemComboBox5
            // 
            this.repositoryItemComboBox5.AutoHeight = false;
            this.repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox5.Name = "repositoryItemComboBox5";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl6);
            this.xtraTabPage2.Controls.Add(this.radioGroupDC);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.xtraTabPage2.Size = new System.Drawing.Size(351, 84);
            this.xtraTabPage2.Text = "每木检尺";
            this.xtraTabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage2_Paint);
            // 
            // gridControl6
            // 
            this.gridControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl6.Location = new System.Drawing.Point(2, 2);
            this.gridControl6.MainView = this.gridView6;
            this.gridControl6.Name = "gridControl6";
            this.gridControl6.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox6});
            this.gridControl6.Size = new System.Drawing.Size(347, 56);
            this.gridControl6.TabIndex = 34;
            this.gridControl6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView6});
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gridControl6;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsCustomization.AllowColumnMoving = false;
            this.gridView6.OptionsCustomization.AllowSort = false;
            this.gridView6.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView6.OptionsFilter.AllowFilterEditor = false;
            this.gridView6.OptionsFilter.AllowMRUFilterList = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.OptionsView.ShowIndicator = false;
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            // 
            // radioGroupDC
            // 
            this.radioGroupDC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radioGroupDC.Location = new System.Drawing.Point(2, 58);
            this.radioGroupDC.Name = "radioGroupDC";
            this.radioGroupDC.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupDC.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupDC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupDC.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "根据图形要素自动读取记录"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "根据选择记录导入")});
            this.radioGroupDC.Size = new System.Drawing.Size(347, 24);
            this.radioGroupDC.TabIndex = 20;
            this.radioGroupDC.SelectedIndexChanged += new System.EventHandler(this.radioGroupDC_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButtonSelect);
            this.panel1.Controls.Add(this.simpleButtonDCView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 145);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel1.Size = new System.Drawing.Size(357, 30);
            this.panel1.TabIndex = 17;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageIndex = 28;
            this.simpleButtonSelect.ImageList = this.ImageList1;
            this.simpleButtonSelect.Location = new System.Drawing.Point(229, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonSelect.TabIndex = 19;
            this.simpleButtonSelect.Text = "全选";
            this.simpleButtonSelect.ToolTip = "选择导入班块";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // simpleButtonDCView
            // 
            this.simpleButtonDCView.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonDCView.ImageIndex = 9;
            this.simpleButtonDCView.ImageList = this.ImageList1;
            this.simpleButtonDCView.Location = new System.Drawing.Point(293, 6);
            this.simpleButtonDCView.Name = "simpleButtonDCView";
            this.simpleButtonDCView.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonDCView.TabIndex = 16;
            this.simpleButtonDCView.Text = "查看";
            this.simpleButtonDCView.ToolTip = "查看外调图形数据";
            this.simpleButtonDCView.Click += new System.EventHandler(this.simpleButtonDCView_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.radioGroupCF);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(6, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel9.Size = new System.Drawing.Size(357, 30);
            this.panel9.TabIndex = 15;
            // 
            // radioGroupCF
            // 
            this.radioGroupCF.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioGroupCF.Location = new System.Drawing.Point(186, 4);
            this.radioGroupCF.Name = "radioGroupCF";
            this.radioGroupCF.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupCF.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupCF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupCF.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐数据"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "每木检尺")});
            this.radioGroupCF.Size = new System.Drawing.Size(171, 22);
            this.radioGroupCF.TabIndex = 15;
            this.radioGroupCF.Visible = false;
            this.radioGroupCF.SelectedIndexChanged += new System.EventHandler(this.radioGroupCF_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "外调数据列表:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPoints
            // 
            this.panelPoints.BackColor = System.Drawing.Color.Transparent;
            this.panelPoints.Controls.Add(this.panelControl5);
            this.panelPoints.Controls.Add(this.panel2);
            this.panelPoints.Controls.Add(this.panel7);
            this.panelPoints.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPoints.Location = new System.Drawing.Point(0, 533);
            this.panelPoints.Name = "panelPoints";
            this.panelPoints.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelPoints.Size = new System.Drawing.Size(369, 215);
            this.panelPoints.TabIndex = 33;
            this.panelPoints.Visible = false;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.gridControl2);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(6, 32);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl5.Size = new System.Drawing.Size(357, 145);
            this.panelControl5.TabIndex = 16;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 4);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox4});
            this.gridControl2.Size = new System.Drawing.Size(353, 139);
            this.gridControl2.TabIndex = 33;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.AllowMRUFilterList = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "点号";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 20;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "X坐标";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 70;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Y坐标";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 70;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelPointInfo);
            this.panel2.Controls.Add(this.simpleButtonSel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(6, 177);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel2.Size = new System.Drawing.Size(357, 32);
            this.panel2.TabIndex = 18;
            // 
            // labelPointInfo
            // 
            this.labelPointInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelPointInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointInfo.Location = new System.Drawing.Point(0, 4);
            this.labelPointInfo.Name = "labelPointInfo";
            this.labelPointInfo.Size = new System.Drawing.Size(293, 24);
            this.labelPointInfo.TabIndex = 17;
            this.labelPointInfo.Text = "共计:300个点";
            this.labelPointInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPointInfo.Click += new System.EventHandler(this.label4_Click);
            // 
            // simpleButtonSel
            // 
            this.simpleButtonSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSel.ImageIndex = 66;
            this.simpleButtonSel.ImageList = this.ImageList1;
            this.simpleButtonSel.Location = new System.Drawing.Point(293, 4);
            this.simpleButtonSel.Name = "simpleButtonSel";
            this.simpleButtonSel.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonSel.TabIndex = 18;
            this.simpleButtonSel.Text = "选中";
            this.simpleButtonSel.ToolTip = "查看选中图形对象";
            this.simpleButtonSel.Visible = false;
            this.simpleButtonSel.Click += new System.EventHandler(this.simpleButtonSel_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.simpleButton2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(6, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel7.Size = new System.Drawing.Size(357, 32);
            this.panel7.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(293, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "GPS点集列表:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.ImageIndex = 73;
            this.simpleButton2.ImageList = this.ImageList1;
            this.simpleButton2.Location = new System.Drawing.Point(293, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(64, 24);
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "选择";
            this.simpleButton2.ToolTip = "选择生成班块的点集";
            this.simpleButton2.Visible = false;
            // 
            // panelGPS
            // 
            this.panelGPS.Controls.Add(this.panelPointList);
            this.panelGPS.Controls.Add(this.splitterControl1);
            this.panelGPS.Controls.Add(this.panelPolyList);
            this.panelGPS.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGPS.Location = new System.Drawing.Point(2, 1074);
            this.panelGPS.Name = "panelGPS";
            this.panelGPS.Size = new System.Drawing.Size(369, 397);
            this.panelGPS.TabIndex = 35;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 215);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(369, 5);
            this.splitterControl1.TabIndex = 34;
            this.splitterControl1.TabStop = false;
            // 
            // panelRseult
            // 
            this.panelRseult.BackColor = System.Drawing.Color.Transparent;
            this.panelRseult.Controls.Add(this.gridControl7);
            this.panelRseult.Controls.Add(this.panel13);
            this.panelRseult.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRseult.Location = new System.Drawing.Point(2, 1471);
            this.panelRseult.Name = "panelRseult";
            this.panelRseult.Padding = new System.Windows.Forms.Padding(6, 0, 6, 4);
            this.panelRseult.Size = new System.Drawing.Size(369, 163);
            this.panelRseult.TabIndex = 36;
            this.panelRseult.Visible = false;
            // 
            // gridControl7
            // 
            this.gridControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl7.Location = new System.Drawing.Point(6, 28);
            this.gridControl7.MainView = this.gridView7;
            this.gridControl7.Name = "gridControl7";
            this.gridControl7.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox7});
            this.gridControl7.Size = new System.Drawing.Size(357, 131);
            this.gridControl7.TabIndex = 34;
            this.gridControl7.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7});
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridView7.GridControl = this.gridControl7;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsCustomization.AllowColumnMoving = false;
            this.gridView7.OptionsCustomization.AllowSort = false;
            this.gridView7.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView7.OptionsFilter.AllowFilterEditor = false;
            this.gridView7.OptionsFilter.AllowMRUFilterList = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            this.gridView7.OptionsView.ShowIndicator = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "序号";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 101;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "ID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 117;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "导入时间";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 135;
            // 
            // repositoryItemComboBox7
            // 
            this.repositoryItemComboBox7.AutoHeight = false;
            this.repositoryItemComboBox7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox7.Name = "repositoryItemComboBox7";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.simpleButtonResultList);
            this.panel13.Controls.Add(this.label4);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(6, 0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel13.Size = new System.Drawing.Size(357, 28);
            this.panel13.TabIndex = 15;
            // 
            // simpleButtonResultList
            // 
            this.simpleButtonResultList.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonResultList.ImageIndex = 87;
            this.simpleButtonResultList.ImageList = this.ImageList1;
            this.simpleButtonResultList.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonResultList.Location = new System.Drawing.Point(335, 2);
            this.simpleButtonResultList.Name = "simpleButtonResultList";
            this.simpleButtonResultList.Size = new System.Drawing.Size(22, 24);
            this.simpleButtonResultList.TabIndex = 14;
            this.simpleButtonResultList.ToolTip = "重新匹配";
            this.simpleButtonResultList.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "导入结果列表:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlInputData2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelRseult);
            this.Controls.Add(this.panelGPS);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelDo);
            this.Controls.Add(this.panelSet);
            this.Name = "UserControlInputData2";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(373, 1800);
            this.panelGridControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.panelField.ResumeLayout(false);
            this.panelFieldMatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkPorpertyMatch.Properties)).EndInit();
            this.panelResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxDataList)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.panelTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditTargetPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panelDo.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelResource0.ResumeLayout(false);
            this.panelSetSubID.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXiban.Properties)).EndInit();
            this.panelSubID.ResumeLayout(false);
            this.panelClearAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClear.Properties)).EndInit();
            this.panelSetXB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditXB.Properties)).EndInit();
            this.panelSetID.ResumeLayout(false);
            this.panelPointList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panelPolyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panelSet.ResumeLayout(false);
            this.panelDiaoCha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDC.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCF.Properties)).EndInit();
            this.panelPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelGPS.ResumeLayout(false);
            this.panelRseult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).EndInit();
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitialValue()
        {
            try
            {
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                string str = "";
                if (this.mEditKind == "小班")
                {
                    this.mEditKind2 = "XB";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName");
                }
                else if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayerName");
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayerName");
                }
                else if (this.mEditKind == "火灾")
                {
                    this.mEditKind2 = "Fire";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("FireLayerName");
                }
                else if (this.mEditKind == "自然灾害")
                {
                    this.mEditKind2 = "ZRZH";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("ZRZHLayerName");
                }
                else if (this.mEditKind == "林业案件")
                {
                    this.mEditKind2 = "AnJian";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("AnJianLayerName");
                }
                else if (this.mEditKind == "征占用")
                {
                    this.mEditKind2 = "ZZY";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayerName");
                }
                else if (this.mEditKind == "遥感")
                {
                    this.mEditKind2 = "YG";
                    str = UtilFactory.GetConfigOpt().GetConfigValue("YGLayerName2");
                }
                this.m_EditWorkspace = EditTask.EditWorkspace;
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_EditLayer == null)
                {
                    this.m_EditLayer = EditTask.EditLayer;
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                this.mXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                int num = (int) double.Parse(focusMap.Extent.YMin.ToString());
                int num2 = (int) double.Parse(focusMap.Extent.XMin.ToString());
                if (num2.ToString().Length > num.ToString().Length)
                {
                    this.mDaiHao = int.Parse(num2.ToString().Substring(0, 2));
                }
                else
                {
                    this.mDaiHao = 0;
                }
                this.mLayerList = null;
                this.mLayerList2 = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool InputPoints(IFeatureWorkspace pfw, IFeatureClass pfc)
        {
            try
            {
                IWorkspaceEdit edit = pfw as IWorkspaceEdit;
                if (edit == null)
                {
                    return false;
                }
                edit.StartEditing(false);
                edit.StartEditOperation();
                for (int i = 0; i < this.mPointTable.Rows.Count; i++)
                {
                    IFeature feature = pfc.CreateFeature();
                    IPoint point = new PointClass();
                    point.PutCoords(double.Parse(this.mDaiHao.ToString() + this.mPointTable.Rows[i]["X坐标"].ToString()), double.Parse(this.mPointTable.Rows[i]["Y坐标"].ToString()));
                    point.Project(this.mHookHelper.FocusMap.SpatialReference);
                    IGeometry geometry = point;
                    feature.Shape = geometry;
                    int index = feature.Fields.FindField("ID");
                    feature.set_Value(index, this.mPointTable.Rows[i]["点号"]);
                    index = feature.Fields.FindField("X坐标");
                    feature.set_Value(index, this.mDaiHao.ToString() + this.mPointTable.Rows[i]["X坐标"]);
                    index = feature.Fields.FindField("Y坐标");
                    feature.set_Value(index, this.mPointTable.Rows[i]["Y坐标"]);
                    index = feature.Fields.FindField("时间");
                    feature.set_Value(index, this.mPointTable.Rows[i]["时间"]);
                    feature.Store();
                }
                edit.StopEditing(true);
                edit.StopEditOperation();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IFeature InputPolygons(IFeatureWorkspace pfw, IFeatureClass pfc, IGeometry pGeo)
        {
            try
            {
                IWorkspaceEdit edit = pfw as IWorkspaceEdit;
                if (edit == null)
                {
                    return null;
                }
                edit.StartEditing(false);
                edit.StartEditOperation();
                IFeature feature = pfc.CreateFeature();
                feature.Shape = pGeo;
                int index = feature.Fields.FindField("ID");
                IFeatureCursor cursor = pfc.Search(null, false);
                IFeature feature2 = cursor.NextFeature();
                string s = "0";
                while (feature2 != null)
                {
                    try
                    {
                        if (int.Parse(feature2.get_Value(index).ToString()) > int.Parse(s))
                        {
                            s = feature2.get_Value(index).ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    feature2 = cursor.NextFeature();
                }
                feature.set_Value(index, int.Parse(s) + 1);
                feature.Store();
                edit.StopEditing(true);
                edit.StopEditOperation();
                return feature;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void labelprogress_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelSubID_Paint(object sender, PaintEventArgs e)
        {
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == this.radioGroup1.SelectedIndex)
            {
                this.buttonEditTargetPath.Enabled = false;
                this.buttonEditTargetPath.Text = "";
                this.InitialFieldGrid();
                if (this.mRangeList.Count == 1)
                {
                    IFeatureClass pSFeatureClass = this.mRangeList[0] as IFeatureClass;
                    this.SetFieldMatch(pSFeatureClass);
                    this.InitialFieldList(pSFeatureClass);
                }
                else if (this.mRangeList.Count > 1)
                {
                    this.CheckFieldSame();
                }
            }
            else if (1 == this.radioGroup1.SelectedIndex)
            {
                this.buttonEditTargetPath.Enabled = true;
                this.mFieldTable.Rows.Clear();
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup2.SelectedIndex == 0)
            {
                this.SetView(0);
                this.mLayerList = null;
            }
            else if (this.radioGroup2.SelectedIndex == 1)
            {
                this.SetView(1);
                this.mLayerList = null;
            }
            else if (this.radioGroup2.SelectedIndex == 2)
            {
                this.SetView(2);
                this.mLayerList = null;
            }
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioGroup3.SelectedIndex == 0)
                {
                    this.SubID = "0";
                    IQueryFilter filter = new QueryFilterClass();
                    filter.WhereClause = string.Concat(new object[] { "Task_ID".ToUpper(), " LIKE '%", EditTask.TaskID, "%'" });
                    IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                    IFeature feature = cursor.NextFeature();
                    int index = feature.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName"));
                    if (index != -1)
                    {
                        while (feature != null)
                        {
                            int num2 = 0;
                            try
                            {
                                num2 = int.Parse(feature.get_Value(index).ToString());
                            }
                            catch (Exception)
                            {
                                num2 = 0;
                            }
                            if (num2 > int.Parse(this.SubID))
                            {
                                this.SubID = feature.get_Value(index).ToString();
                            }
                            feature = cursor.NextFeature();
                        }
                    }
                }
                else if (this.radioGroup3.SelectedIndex == 1)
                {
                    this.SubID = "0";
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "radioGroup3_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroupCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataset mDCFeatureClass;
            if (this.radioGroupCF.SelectedIndex == 0)
            {
                mDCFeatureClass = this.mDCFeatureClass as IDataset;
                this.InitialGridviewDC(mDCFeatureClass, 0);
            }
            else if (this.radioGroupCF.SelectedIndex == 1)
            {
                mDCFeatureClass = this.mDCTable as IDataset;
                this.InitialGridviewDC(mDCFeatureClass, 1);
            }
        }

        private void radioGroupDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroupDC.SelectedIndex == 0)
            {
                this.gridView6.Columns[0].Visible = false;
                this.simpleButtonSelect.Enabled = false;
            }
            else if (this.radioGroupDC.SelectedIndex == 1)
            {
                this.gridView6.Columns[0].Visible = true;
                this.simpleButtonSelect.Enabled = true;
            }
        }

        private bool ReadPoints(string strpath)
        {
            try
            {
                this.labelPointList.Text = "GPS点集列表:";
                this.simpleButtonSelectTool.Visible = false;
                this.simpleButtonSelected.Visible = false;
                if (strpath == "")
                {
                    return false;
                }
                if (!File.Exists(strpath))
                {
                    return false;
                }
                StreamReader reader = new StreamReader(strpath, Encoding.Default);
                string str = "";
                ArrayList list = new ArrayList();
                int num = 0;
                while (str != null)
                {
                    str = reader.ReadLine();
                    num++;
                    if (str != null)
                    {
                        list.Add(str);
                    }
                }
                reader.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    string[] strArray = Regex.Split(list[i].ToString(), "\t", RegexOptions.IgnoreCase);
                    if (((strArray.Length == 0x13) && (strArray[4].ToLower() != "Position".ToLower())) && (strArray[4].Split(new char[] { ' ' }).Length == 2))
                    {
                        DataRow row = this.mPointTable.NewRow();
                        row[0] = strArray[1].ToString();
                        row[1] = strArray[4].Split(new char[] { ' ' })[0].ToString();
                        row[2] = strArray[4].Split(new char[] { ' ' })[1].ToString();
                        row[3] = strArray[2].ToString();
                        this.mPointTable.Rows.Add(row);
                    }
                }
                this.gridView2.RefreshData();
                this.labelPointInfo.Text = "共计" + this.mPointTable.Rows.Count + "个点";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ReadPoints2(IFeatureClass pfc)
        {
            try
            {
                this.labelPointList.Text = "点图层对象列表:";
                this.simpleButtonSelectTool.Visible = true;
                this.simpleButtonSelected.Visible = true;
                if (pfc == null)
                {
                    pfc = this.mPointFeatureLayer.FeatureClass;
                }
                ITable table = pfc as ITable;
                int num = table.RowCount(null);
                ICursor cursor = table.Search(null, true);
                for (IRow row = cursor.NextRow(); row != null; row = cursor.NextRow())
                {
                    DataRow row2 = this.mPointTable2.NewRow();
                    int index = row.Fields.FindField(this.mPointFeatureLayer.FeatureClass.OIDFieldName);
                    row2[0] = row.get_Value(index);
                    index = row.Fields.FindField("ID");
                    row2[1] = row.get_Value(index);
                    index = row.Fields.FindField("X坐标");
                    row2[2] = row.get_Value(index);
                    index = row.Fields.FindField("Y坐标");
                    row2[3] = row.get_Value(index);
                    index = row.Fields.FindField("时间");
                    row2[4] = row.get_Value(index);
                    this.mPointTable2.Rows.Add(row2);
                }
                if (this.mPointTable2.Rows.Count > 0)
                {
                    this.simpleButtonSelectTool.Enabled = true;
                }
                else
                {
                    this.simpleButtonSelectTool.Enabled = false;
                }
                this.gridControl3.DataSource = null;
                this.gridView3.Columns.Clear();
                this.gridControl3.DataSource = this.mPointTable2;
                this.gridView3.RefreshData();
                this.labelPointInfo2.Text = "共计" + this.mPointTable2.Rows.Count + "个点";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ReadPolygon(IFeatureClass pfc, IFeature pf)
        {
            try
            {
                DataRow row;
                int num;
                if (pf == null)
                {
                    this.mPolyTable.Clear();
                    IFeatureCursor cursor = pfc.Search(null, false);
                    pf = cursor.NextFeature();
                    while (pf != null)
                    {
                        row = this.mPolyTable.NewRow();
                        num = pf.Fields.FindField(pfc.OIDFieldName);
                        row["OID"] = pf.get_Value(num);
                        num = pf.Fields.FindField("ID");
                        row["小班号"] = pf.get_Value(num);
                        this.mPolyTable.Rows.Add(row);
                        pf = cursor.NextFeature();
                    }
                }
                else
                {
                    row = this.mPolyTable.NewRow();
                    num = pf.Fields.FindField(pfc.OIDFieldName);
                    row["OID"] = pf.get_Value(num);
                    num = pf.Fields.FindField("ID");
                    row["小班号"] = pf.get_Value(num);
                    this.mPolyTable.Rows.Add(row);
                }
                this.gridView4.RefreshData();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ReadResult()
        {
            try
            {
                if ((this.mRangeList != null) && (this.mRangeList.Count != 0))
                {
                  
                    for (int i = 0; i < this.mRangeList.Count; i++)
                    {
                        IFeatureClass class2 = this.mRangeList[i] as IFeatureClass;
                        DataTable dataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_Input_Feature where SourceName='" + (class2 as IDataset).Name + "'");
                        this.gridControl7.DataSource = null;
                        this.gridView7.Columns.Clear();
                        this.gridControl7.DataSource = dataTable;
                        this.gridView7.RefreshData();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool ReconcileVersionFindConflicts(IFeatureWorkspace pFeatureWorkspace, string strTargetVersion)
        {
            try
            {
                bool flag = false;
                IVersionEdit edit = pFeatureWorkspace as IVersionEdit;
                bool flag2 = edit.CanPost();
                if (edit.Reconcile(strTargetVersion))
                {
                    IFeatureWorkspace startEditingVersion = edit.StartEditingVersion as IFeatureWorkspace;
                    IVersion preReconcileVersion = edit.PreReconcileVersion;
                    IVersion commonAncestorVersion = edit.CommonAncestorVersion;
                    IVersion reconcileVersion = edit.ReconcileVersion;
                    IEnumConflictClass conflictClasses = edit.ConflictClasses;
                    conflictClasses.Reset();
                    for (IConflictClass class3 = conflictClasses.Next(); class3 != null; class3 = conflictClasses.Next())
                    {
                        IDataset dataset = (IDataset) class3;
                        if (class3.HasConflicts)
                        {
                            flag = true;
                            string str = dataset.Name + ":";
                            IEnumIDs iDs = class3.UpdateUpdates.IDs;
                            iDs.Reset();
                            int num = iDs.Next();
                            while (num != -1)
                            {
                                str = str + num.ToString() + ";";
                                num = iDs.Next();
                            }
                            iDs = class3.DeleteUpdates.IDs;
                            iDs.Reset();
                            num = iDs.Next();
                            while (num != -1)
                            {
                                str = str + num.ToString() + ";";
                                num = iDs.Next();
                            }
                            iDs = class3.UpdateDeletes.IDs;
                            iDs.Reset();
                            for (num = iDs.Next(); num != -1; num = iDs.Next())
                            {
                                str = str + num.ToString() + ";";
                            }
                            MessageBox.Show("发现冲突," + str, "版本编辑", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(dataset.Name + " Does Not Have Conflicts", "版本编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "ReconcileVersionFindConflicts", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void repositoryItemComboBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GridSelectIndex != -1)
            {
                this.ComboxSelectIndex = (sender as ComboBoxEdit).SelectedIndex;
                if (this.ComboxSelectIndex != -1)
                {
                    string[] strArray;
                    string str = this.repositoryItemComboBox1.Items[this.ComboxSelectIndex].ToString();
                    this.mFieldTable.Rows[this.GridSelectIndex][2] = str;
                    if (str.Contains("]["))
                    {
                        strArray = str.Replace("][", ",").Replace("[", ",").Replace("]", ",").Split(new char[] { ',' });
                        this.mFieldTable.Rows[this.GridSelectIndex][3] = strArray[1];
                    }
                    else if (str.Contains("[") && str.Contains("]"))
                    {
                        strArray = str.Replace("[", ",").Replace("]", "").Split(new char[] { ',' });
                        this.mFieldTable.Rows[this.GridSelectIndex][3] = strArray[0];
                    }
                    else
                    {
                        this.mFieldTable.Rows[this.GridSelectIndex][3] = str;
                    }
                }
            }
        }

        private void SetFeatureArea(IFeature pFeature)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        double area = ((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area;
                        string str = EditTask.KindCode.Substring(0, 2);
                        string name = "";
                        string str3 = "";
                        string str4 = "";
                        if (str == "01")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Afforest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "02")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Harvest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "06")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Disaster";
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "07")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "ForestCase";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "04")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 4);
                            name = "Expropriation";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "05")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Fire";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        }
                        int index = pFeature.Fields.FindField(str3);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        index = pFeature.Fields.FindField(str4);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        pFeature.Store();
                    }
                }
                catch
                {
                }
            }
        }

        private void SetFeatureArea(IFeature pFeature, string sKindCode, ISpatialReference pSpatialReference)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        double area = ((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area;
                        string name = "";
                        string str2 = "";
                        string str3 = "";
                        if (sKindCode == "01")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Afforest";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (sKindCode == "02")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Harvest";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (sKindCode == "06")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Disaster";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (sKindCode == "07")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "ForestCase";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (sKindCode == "04")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 4);
                            name = "Expropriation";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (sKindCode == "05")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Fire";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Sub";
                            str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        int index = pFeature.Fields.FindField(str2);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        string[] strArray = str3.Split(new char[] { ',' });
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            index = pFeature.Fields.FindField(strArray[i]);
                            if ((index > -1) && (pFeature.get_Value(index).ToString().Trim() == ""))
                            {
                                pFeature.set_Value(index, area);
                            }
                        }
                        pFeature.Store();
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "SetFeatureArea", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void SetFieldMatch(IFeatureClass pSFeatureClass)
        {
            try
            {
                int num;
                IField field;
                int num2;
                IField field2;
                DataRow[] rowArray;
                string str;
                IFeatureClass featureClass = this.m_EditLayer.FeatureClass;
                if (this.m_EditTable != null)
                {
                    for (num = 0; num < this.m_EditTable.Fields.FieldCount; num++)
                    {
                        field = this.m_EditTable.Fields.get_Field(num);
                        num2 = pSFeatureClass.Fields.FindField(field.Name);
                        if ((num2 == -1) && (field.Name.Length > 10))
                        {
                            num2 = pSFeatureClass.Fields.FindField(field.Name.Substring(0, 10));
                        }
                        if (num2 != -1)
                        {
                            field2 = pSFeatureClass.Fields.get_Field(num2);
                            if (field2.Type == field.Type)
                            {
                                rowArray = this.mFieldTable.Select("目标数据字段2='" + field.Name + "'");
                                if (rowArray.Length > 0)
                                {
                                    str = field2.Type.ToString().Replace("esriFieldType", "");
                                    rowArray[0]["源数据字段"] = field2.AliasName + "[" + str + "]";
                                    rowArray[0]["源数据字段2"] = field2.Name;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (num = 0; num < featureClass.Fields.FieldCount; num++)
                    {
                        field = featureClass.Fields.get_Field(num);
                        num2 = pSFeatureClass.Fields.FindField(field.Name);
                        if ((num2 == -1) && (field.Name.Length > 10))
                        {
                            num2 = pSFeatureClass.Fields.FindField(field.Name.Substring(0, 10));
                        }
                        if (num2 != -1)
                        {
                            field2 = pSFeatureClass.Fields.get_Field(num2);
                            if (field2.Type == field.Type)
                            {
                                rowArray = this.mFieldTable.Select("目标数据字段2='" + field.Name + "'");
                                if (rowArray.Length > 0)
                                {
                                    str = field2.Type.ToString().Replace("esriFieldType", "");
                                    rowArray[0]["源数据字段"] = field2.AliasName + "[" + str + "]";
                                    rowArray[0]["源数据字段2"] = field2.Name;
                                }
                            }
                        }
                    }
                }
                this.gridView1.RefreshData();
                this.simpleButtonClear.Enabled = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "SetFieldMatch", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void SetSelectPoints()
        {
            try
            {
                if (this.mSelPointTable == null)
                {
                    this.mSelPointTable = new DataTable();
                    DataColumn column = new DataColumn("点号", typeof(string));
                    this.mSelPointTable.Columns.Add(column);
                    column = new DataColumn("X坐标", typeof(string));
                    this.mSelPointTable.Columns.Add(column);
                    column = new DataColumn("Y坐标", typeof(string));
                    this.mSelPointTable.Columns.Add(column);
                    column = new DataColumn("Shape", typeof(object));
                    this.mSelPointTable.Columns.Add(column);
                }
                else
                {
                    this.mSelPointTable.Clear();
                }
                this.gridView3.ClearSelection();
                IFeatureSelection mPointFeatureLayer = this.mPointFeatureLayer as IFeatureSelection;
                ISelectionSet selectionSet = mPointFeatureLayer.SelectionSet;
                ICursor cursor = null;
                selectionSet.Search(null, false, out cursor);
                IFeatureCursor cursor2 = cursor as IFeatureCursor;
                IFeature feature = cursor2.NextFeature();
                if (feature != null)
                {
                    while (feature != null)
                    {
                        DataRow row = this.mSelPointTable.NewRow();
                        int index = feature.Fields.FindField("ID");
                        row["点号"] = feature.get_Value(index);
                        index = feature.Fields.FindField("X坐标");
                        row["X坐标"] = feature.get_Value(index);
                        index = feature.Fields.FindField("Y坐标");
                        row["Y坐标"] = feature.get_Value(index);
                        row["Shape"] = feature.Shape;
                        this.mSelPointTable.Rows.Add(row);
                        DataRow[] rowArray = this.mPointTable2.Select(string.Concat(new object[] { "点号='", row["点号"], "' and X坐标='", row["X坐标"], "' and Y坐标='", row["Y坐标"], "'" }));
                        this.gridView3.SelectRow(int.Parse(rowArray[0]["OID"].ToString()));
                        feature = cursor2.NextFeature();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "SetSelectPoints", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetView(int kind)
        {
            switch (kind)
            {
                case 0:
                    this.panelSet.Visible = true;
                    this.panelSet.Dock = DockStyle.Fill;
                    this.panelSet.BringToFront();
                    this.panelResource.Height = 140;
                    this.panel12.Visible = true;
                    this.listBoxDataList.Visible = true;
                    this.radioGroup1.SelectedIndex = 0;
                    this.buttonEditDataPath.Text = "";
                    this.buttonEditTargetPath.Text = "";
                    this.listBoxDataList.Items.Clear();
                    this.simpleButtonAdd.Enabled = false;
                    this.simpleButtonClear.Enabled = false;
                    this.simpleButtonRemove.Enabled = false;
                    this.simpleButtonExpend.Visible = false;
                    this.simpleButtonClear.Visible = false;
                    this.simpleButtonReset.Visible = false;
                    this.simpleButtonExpend2.Visible = false;
                    this.panelField.Visible = true;
                    this.panelField.Dock = DockStyle.Top;
                    this.panelField.Height = this.panelFieldMatch.Height;
                    this.checkPorpertyMatch.Enabled = true;
                    this.checkPorpertyMatch.Checked = false;
                    this.panelSubID.Visible = true;
                    this.panelSubID.Dock = DockStyle.Top;
                    this.panelSubID.Height = (this.panelSetID.Height + this.panelSetXB.Height) + this.panelClearAll.Height;
                    this.checkEditXiban.Enabled = true;
                    this.checkEditXB.Enabled = true;
                    this.checkPorpertyMatch.Checked = false;
                    this.panelPoints.Visible = false;
                    this.panelLog.Visible = false;
                    this.panelGPS.Visible = false;
                    this.panelDiaoCha.Visible = false;
                    this.simpleButtonInput.Enabled = false;
                    this.simpleButtonInput.Visible = true;
                    this.simpleButtonBack.Visible = false;
                    this.simpleButtonInputPoint.Visible = false;
                    this.simpleButtonConvert.Visible = false;
                    break;

                case 1:
                    this.panelSet.Visible = true;
                    this.panelSet.Dock = DockStyle.Fill;
                    this.buttonEditDataPath.Text = "";
                    this.buttonEditTargetPath.Text = "";
                    this.listBoxDataList.Items.Clear();
                    this.simpleButtonAdd.Enabled = false;
                    this.simpleButtonClear.Enabled = false;
                    this.simpleButtonRemove.Enabled = false;
                    this.simpleButtonExpend.Visible = false;
                    this.simpleButtonClear.Visible = false;
                    this.simpleButtonReset.Visible = false;
                    this.simpleButtonExpend2.Visible = false;
                    this.panelField.Visible = false;
                    this.panelField.Dock = DockStyle.Top;
                    this.panelField.Height = this.panelFieldMatch.Height;
                    this.panelSubID.Visible = false;
                    this.panelSubID.Dock = DockStyle.Top;
                    this.panelSubID.Height = (this.panelSetID.Height + this.panelSetXB.Height) + this.panelClearAll.Height;
                    this.mPointTable.Clear();
                    this.mPointTable2.Clear();
                    this.labelPointInfo2.Text = "";
                    this.panelPoints.Visible = true;
                    this.panelPoints.Dock = DockStyle.Fill;
                    this.panelPoints.BringToFront();
                    this.labelPointInfo.Text = "";
                    this.panelGPS.Visible = false;
                    this.panelLog.Visible = false;
                    this.panelDiaoCha.Visible = false;
                    this.panelResource.Height = 60;
                    this.panel12.Visible = false;
                    this.listBoxDataList.Visible = false;
                    this.simpleButtonInput.Enabled = false;
                    this.simpleButtonInput.Visible = true;
                    this.simpleButtonBack.Visible = false;
                    this.simpleButtonInputPoint.Visible = false;
                    this.simpleButtonConvert.Visible = false;
                    break;

                case 2:
                    this.panelSet.Visible = true;
                    this.panelSet.Dock = DockStyle.Fill;
                    this.panelSet.BringToFront();
                    this.radioGroup1.SelectedIndex = 0;
                    this.buttonEditDataPath.Text = "";
                    this.buttonEditTargetPath.Text = "";
                    this.listBoxDataList.Items.Clear();
                    this.panelResource.Height = 60;
                    this.panel12.Visible = false;
                    this.listBoxDataList.Visible = false;
                    this.simpleButtonAdd.Enabled = false;
                    this.simpleButtonClear.Enabled = false;
                    this.simpleButtonRemove.Enabled = false;
                    this.simpleButtonExpend.Visible = false;
                    this.simpleButtonClear.Visible = false;
                    this.simpleButtonReset.Visible = false;
                    this.simpleButtonExpend2.Visible = false;
                    this.panelField.Visible = false;
                    this.panelSubID.Visible = false;
                    this.panelPoints.Visible = false;
                    this.panelLog.Visible = false;
                    this.panelGPS.Visible = false;
                    this.panelDiaoCha.Visible = true;
                    this.panelDiaoCha.Dock = DockStyle.Fill;
                    this.panelDiaoCha.BringToFront();
                    this.simpleButtonInput.Enabled = false;
                    this.simpleButtonInput.Visible = true;
                    this.simpleButtonBack.Visible = false;
                    this.simpleButtonInputPoint.Visible = false;
                    this.simpleButtonConvert.Visible = false;
                    break;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_') + ".shp";
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                IFeatureWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                if (featureWorkspace == null)
                {
                    featureWorkspace = this.CreateShapefile(Directory.GetParent(sSourceFile).ToString(), UtilFactory.GetConfigOpt().GetConfigValue("TempPath"), esriGeometryType.esriGeometryPolygon, this.mHookHelper.FocusMap.SpatialReference);
                }
                if (featureWorkspace != null)
                {
                    if (this.m_TempGroupLayer == null)
                    {
                        this.m_TempGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                        if (this.m_TempGroupLayer == null)
                        {
                            GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, "GPS轨迹");
                        }
                    }
                    IFeatureClass pfc = null;
                    try
                    {
                        pfc = featureWorkspace.OpenFeatureClass(str.Split(new char[] { '.' })[0]);
                    }
                    catch (Exception)
                    {
                        pfc = this.CreateFeatureClass(featureWorkspace, str.Split(new char[] { '.' })[0].ToString());
                    }
                    if ((pfc != null) && this.InputPoints(featureWorkspace, pfc))
                    {
                        this.AddPointLayer(pfc, "GPS轨迹点", this.m_TempGroupLayer);
                        this.ReadPoints2(pfc);
                        str = str.Split(new char[] { '.' })[0] + "_p.shp";
                        sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                        this.mPolyFeatureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                        if (this.mPolyFeatureWorkspace == null)
                        {
                            this.mPolyFeatureWorkspace = this.CreateShapefile(Directory.GetParent(sSourceFile).ToString(), UtilFactory.GetConfigOpt().GetConfigValue("TempPath"), esriGeometryType.esriGeometryPolygon, this.mHookHelper.FocusMap.SpatialReference);
                        }
                        if (this.mPolyFeatureWorkspace != null)
                        {
                            pfc = null;
                            try
                            {
                                (this.mPolyFeatureWorkspace.OpenFeatureClass(str.Split(new char[] { '.' })[0]) as IDataset).Delete();
                                pfc = this.CreateFeatureClass2(this.mPolyFeatureWorkspace, str.Split(new char[] { '.' })[0].ToString());
                            }
                            catch (Exception)
                            {
                                pfc = this.CreateFeatureClass2(this.mPolyFeatureWorkspace, str.Split(new char[] { '.' })[0].ToString());
                            }
                            if (pfc != null)
                            {
                                this.AddPolygonLayer(pfc, "GPS轨迹转面");
                                this.mHookHelper.ActiveView.Refresh();
                                this.simpleButtonInputPoint.Visible = false;
                                this.simpleButtonSelectTool.Visible = true;
                                this.simpleButtonConvert.Visible = true;
                                this.simpleButtonConvert.Enabled = false;
                                this.panelSet.Visible = false;
                                this.panelGPS.Visible = true;
                                this.panelGPS.Dock = DockStyle.Fill;
                                this.panelPolyList.Visible = true;
                                this.panelPolyList.Dock = DockStyle.Bottom;
                                this.simpleButtonBack.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "simpleButton3_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.buttonEditDataPath.Text != "")
                {
                    int num;
                    IFeatureLayer layer;
                    IDataset dataset;
                    if ((this.mLayerList2 != null) && (this.mLayerList2.Count > 0))
                    {
                        for (num = 0; num < this.mLayerList2.Count; num++)
                        {
                            layer = this.mLayerList2[num] as IFeatureLayer;
                            dataset = layer as IDataset;
                            this.listBoxDataList.Items.Add(dataset.Workspace.PathName + @"\" + dataset.Name);
                        }
                    }
                    if (this.radioGroup2.SelectedIndex == 0)
                    {
                        IFeatureWorkspace workspace = null;
                        IFeatureClass featureClass = null;
                        for (num = 0; num < this.mLayerList2.Count; num++)
                        {
                            layer = this.mLayerList2[num] as IFeatureLayer;
                            dataset = layer as IDataset;
                            workspace = dataset.Workspace as IFeatureWorkspace;
                            featureClass = layer.FeatureClass;
                            this.mRangeList.Add(featureClass);
                        }
                        if (this.mRangeList.Count == 1)
                        {
                            this.SetFieldMatch(featureClass);
                            this.InitialFieldList(featureClass);
                        }
                        else if (this.mRangeList.Count > 1)
                        {
                            this.CheckFieldSame();
                        }
                        this.buttonEditDataPath.Text = "";
                        this.simpleButtonRemove.Enabled = true;
                        this.simpleButtonAdd.Enabled = false;
                        this.simpleButtonInput.Enabled = true;
                    }
                    else if (this.ReadPoints(this.buttonEditDataPath.Text))
                    {
                        this.panelPointList.Dock = DockStyle.Fill;
                        this.panelPointList.Visible = true;
                        this.panelPointList.BringToFront();
                        this.simpleButtonInputPoint.Visible = true;
                        this.simpleButtonBack.Visible = true;
                        this.buttonEditDataPath.Text = "";
                        this.simpleButtonRemove.Enabled = false;
                        this.simpleButtonAdd.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "simpleButtonAdd_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.mLayerList != null)
                {
                    this.mLayerList.Clear();
                }
                if (this.mLayerList2 != null)
                {
                    this.mLayerList2.Clear();
                }
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    this.InitialFieldGrid();
                    this.mRangeList = new ArrayList();
                    this.SetView(0);
                }
                else if (this.radioGroup2.SelectedIndex == 1)
                {
                    this.InitialFieldGrid();
                    this.mRangeList = new ArrayList();
                    this.SetView(1);
                }
                else if (this.radioGroup2.SelectedIndex == 2)
                {
                    this.SetView(2);
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.mFieldTable.Rows.Count; i++)
            {
                this.mFieldTable.Rows[i][2] = "";
                this.mFieldTable.Rows[i][3] = "";
            }
        }

        private void simpleButtonClear2_Click(object sender, EventArgs e)
        {
            this.mRangeList = null;
            this.mLayerList = null;
            this.mLayerList2 = null;
            this.mRangeList = new ArrayList();
            this.mLayerList = new ArrayList();
            this.listBoxDataList.Items.Clear();
            this.buttonEditDataPath.Text = "";
            this.mPointTable.Clear();
            this.mPointTable2.Clear();
            this.labelPointInfo2.Text = "";
            this.simpleButtonRemove.Enabled = false;
            this.simpleButtonClear2.Enabled = false;
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.mParButton.PerformClick();
        }

        private void simpleButtonContinue_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                IGeometry polygon = this.GetPolygon();
                IFeature pf = this.InputPolygons(this.mPolyFeatureWorkspace, this.mPolyFeatureLayer.FeatureClass, polygon);
                if (pf != null)
                {
                    this.ReadPolygon(this.mPolyFeatureLayer.FeatureClass, pf);
                    ISelection featureClass = this.mPointFeatureLayer.FeatureClass as ISelection;
                    this.mHookHelper.FocusMap.ClearSelection();
                    this.mHookHelper.ActiveView.Refresh();
                    this.simpleButtonInput.Visible = true;
                    this.simpleButtonInput.Enabled = true;
                    this.simpleButtonConvert.Visible = true;
                    this.simpleButtonConvert.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "simpleButtonConvert_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonDCView_Click(object sender, EventArgs e)
        {
            this.AddDCLayer(this.mDCFeatureClass, this.mEditKind);
        }

        private void simpleButtonDeletePoly_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonExpend_Click(object sender, EventArgs e)
        {
            if (this.panelField.Height == this.panelFieldMatch.Height)
            {
                this.panelSubID.Visible = true;
                this.panelSubID.Height = (this.panelSetID.Height + this.panelSetXB.Height) + this.panelClearAll.Height;
                this.panelSubID.Dock = DockStyle.Bottom;
                this.panelField.Dock = DockStyle.Fill;
                this.panelField.BringToFront();
                this.panelGridControl.Visible = true;
                this.simpleButtonReset.Visible = true;
                this.simpleButtonClear.Visible = true;
            }
            else
            {
                this.panelField.Dock = DockStyle.Top;
                this.panelField.Height = this.panelFieldMatch.Height;
                this.panelSubID.Dock = DockStyle.Top;
                this.panelSubID.BringToFront();
                this.simpleButtonReset.Visible = false;
                this.simpleButtonClear.Visible = false;
            }
        }

        private void simpleButtonExpend2_Click(object sender, EventArgs e)
        {
            if (this.panelSubID.Height == ((this.panelSetID.Height + this.panelSetXB.Height) + this.panelClearAll.Height))
            {
                this.panelField.Dock = DockStyle.Top;
                this.panelField.Height = this.panelFieldMatch.Height;
                this.simpleButtonReset.Visible = false;
                this.simpleButtonClear.Visible = false;
                this.panelSubID.Dock = DockStyle.Fill;
                this.panelSubID.BringToFront();
                this.panelSetSubID.Visible = true;
            }
            else
            {
                this.panelSubID.Dock = DockStyle.Top;
                this.panelSubID.Height = (this.panelSetID.Height + this.panelSetXB.Height) + this.panelClearAll.Height;
            }
        }

        private void simpleButtonInput_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                IWorkspaceEdit editWorkspace = this.m_EditWorkspace as IWorkspaceEdit;
                if (editWorkspace != null)
                {
                    this.simpleButtonInput.Enabled = false;
                    this.panelSet.Visible = false;
                    this.panelGPS.Visible = false;
                    this.panelLog.Visible = true;
                    this.panelLog.Dock = DockStyle.Fill;
                    this.panelLog.BringToFront();
                    this.labelprogress.Text = "开始导入操作";
                    this.richTextBox.Text = "";
                    this.panelLog.Visible = true;
                    this.panelLog.BringToFront();
                    this.Cursor = Cursors.WaitCursor;
                    if (this.radioGroup2.SelectedIndex == 0)
                    {
                        this.DoInput(editWorkspace);
                    }
                    else if (this.radioGroup2.SelectedIndex == 1)
                    {
                        this.DoInput2(editWorkspace);
                    }
                    else if (this.radioGroup2.SelectedIndex == 2)
                    {
                        this.DoInput3(editWorkspace, this.buttonEditDataPath.Tag as IFeatureWorkspace);
                    }
                    this.simpleButtonInput.Enabled = false;
                    this.simpleButtonBack.Visible = true;
                    this.Cursor = Cursors.Default;
                    this.panelResource.Enabled = true;
                    this.panelTarget.Enabled = true;
                    this.panelField.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + str + "]失败";
                this.labelprogress.Visible = true;
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "simpleButtonInput_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonJump_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex;
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    selectedIndex = this.listBoxDataList.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        this.mRangeList.RemoveAt(selectedIndex);
                        this.listBoxDataList.Items.Remove(this.listBoxDataList.Items[selectedIndex]);
                        if (this.mRangeList.Count == 0)
                        {
                            for (int i = 0; i < this.mFieldTable.Rows.Count; i++)
                            {
                                this.mFieldTable.Rows[i][2] = "";
                                this.mFieldTable.Rows[i][3] = "";
                            }
                        }
                    }
                    if (this.listBoxDataList.Items.Count == 0)
                    {
                        this.simpleButtonRemove.Enabled = false;
                    }
                }
                else if (this.radioGroup2.SelectedIndex == 1)
                {
                    selectedIndex = this.listBoxDataList.SelectedIndex;
                    this.listBoxDataList.Items.Remove(this.listBoxDataList.Items[selectedIndex]);
                    if (this.listBoxDataList.Items.Count == 0)
                    {
                        this.mPointTable.Rows.Clear();
                        this.simpleButtonRemove.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "simpleButtonRemove_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonResult_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.panelRseult.Visible = true;
            this.panelRseult.Dock = DockStyle.Fill;
            this.panelRseult.BringToFront();
            this.ReadResult();
        }

        private void simpleButtonSel_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            int num;
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (this.mDCDataTable != null)
                {
                    if (this.simpleButtonSelect.Text == "全选")
                    {
                        this.simpleButtonSelect.Text = "反选";
                        this.simpleButtonSelect.ImageIndex = 0x21;
                        this.DCInputAll = true;
                        this.simpleButtonInput.Enabled = true;
                    }
                    else if (this.simpleButtonSelect.Text == "反选")
                    {
                        this.simpleButtonSelect.Text = "全选";
                        this.simpleButtonSelect.ImageIndex = 0x1c;
                        this.DCInputAll = false;
                        this.simpleButtonInput.Enabled = false;
                    }
                    for (num = 0; num < this.mDCDataTable.Rows.Count; num++)
                    {
                        this.mDCDataTable.Rows[num][0] = this.DCInputAll;
                    }
                }
            }
            else if ((this.xtraTabControl1.SelectedTabPageIndex == 1) && (this.mDCDataTable2 != null))
            {
                if (this.simpleButtonSelect.Text == "全选")
                {
                    this.simpleButtonSelect.Text = "反选";
                    this.simpleButtonSelect.ImageIndex = 0x21;
                    this.DCInputAll2 = true;
                    this.simpleButtonInput.Enabled = true;
                }
                else if (this.simpleButtonSelect.Text == "反选")
                {
                    this.simpleButtonSelect.Text = "全选";
                    this.simpleButtonSelect.ImageIndex = 0x1c;
                    this.DCInputAll2 = false;
                    this.simpleButtonInput.Enabled = false;
                }
                for (num = 0; num < this.mDCDataTable2.Rows.Count; num++)
                {
                    this.mDCDataTable2.Rows[num][0] = this.DCInputAll2;
                }
            }
        }

        private void simpleButtonSelected_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonSelectTool_Click(object sender, EventArgs e)
        {
            SelectTool2 tool = new SelectTool2(this.mPointFeatureLayer, this);
            tool.OnCreate(this.mHookHelper.Hook);
            tool.OnClick();
            IMapControl2 hook = null;
            hook = (IMapControl2) this.mHookHelper.Hook;
            hook.CurrentTool = tool;
        }

        private void simpleButtonView_Click(object sender, EventArgs e)
        {
        }

        public void StartEdit()
        {
            try
            {
                IWorkspaceEdit editWorkspace = this.m_EditWorkspace as IWorkspaceEdit;
                IWorkspace workspace = EditTask.EditWorkspace as IWorkspace;
                this.mVersion = workspace as IVersion;
                editWorkspace.StartEditing(false);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "StartEdit", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void StopEdit()
        {
            //try
            //{
            //    IWorkspaceEdit mVersion = (IWorkspaceEdit2) this.mVersion;
            //    IVersionEdit4 edit2 = (IVersionEdit4) mVersion;
            //    bool abortIfConflicts = false;
            //    bool childWins = false;
            //    string versionName = "dbo.Default";
            //    if (this.mVersion.VersionInfo.Parent != null)
            //    {
            //        versionName = this.mVersion.VersionInfo.Parent.VersionName;
            //    }
            //    bool columnLevel = true;
            //    try
            //    {
            //        if (!edit2.Reconcile4(versionName, false, abortIfConflicts, childWins, columnLevel))
            //        {
            //            if (edit2.CanPost())
            //            {
            //                edit2.Post(versionName);
            //                mVersion.StopEditOperation();
            //            }
            //            else
            //            {
            //                mVersion.AbortEditOperation();
            //            }
            //        }
            //        else
            //        {
            //            this.ReconcileVersionFindConflicts(this.m_EditWorkspace, versionName);
            //            try
            //            {
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        try
            //        {
            //            edit2.Reconcile4(versionName, false, abortIfConflicts, childWins, columnLevel);
            //            if (edit2.CanPost())
            //            {
            //                edit2.Post(versionName);
            //                mVersion.StopEditOperation();
            //            }
            //            else
            //            {
            //                mVersion.AbortEditOperation();
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            MessageBox.Show("提交数据到服务器时有冲突，请重点保存再次提交", "数据保存", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        }
            //    }
            //    bool pHasEdits = true;
            //    mVersion.HasEdits(ref pHasEdits);
            //    if (pHasEdits)
            //    {
            //        mVersion.StopEditing(true);
            //    }
            //}
            //catch (Exception exception)
            //{
            //    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "StopEdit", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            //}
            IWorkspaceEdit2 edit2 = (IWorkspaceEdit2)mVersion;
            edit2.StopEditing(true);


        }

        private bool UpdateField(IObject pObject, string sFieldName, object pFieldValue)
        {
            try
            {
                int index = pObject.Fields.FindField(sFieldName);
                if (index > 0)
                {
                    pObject.set_Value(index, pFieldValue);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void WriteInputTable(int featureOID, string inputtype, string sSourceName)
        {
            try
            {
               
                if (this.mInputTable == null)
                {
                    //this.mInputTable = this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_Input_Feature");
                }
                string sCmdText = "INSERT INTO T_Input_Feature (Feature_ID,Input_Type,Input_Time,SourceName)";
                string str2 = DateTime.Now.ToString("yyyyMMddHHmmss");
                object obj2 = sCmdText;
                sCmdText = string.Concat(new object[] { obj2, " VALUES( ", featureOID, " ,'", inputtype, "','", str2, "','", sSourceName, "')" });
             //   this.mDBAccess.ExecuteScalar(sCmdText);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData2", "WriteInputTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            IDataset mDCFeatureClass;
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                mDCFeatureClass = this.mDCFeatureClass as IDataset;
                this.simpleButtonSelect.Enabled = true;
                this.InitialGridviewDC(mDCFeatureClass, 0);
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                mDCFeatureClass = this.mDCTable as IDataset;
                this.InitialGridviewDC(mDCFeatureClass, 1);
            }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

