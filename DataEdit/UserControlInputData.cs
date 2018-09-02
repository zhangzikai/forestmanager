namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Catalog;
    using ESRI.ArcGIS.CatalogUI;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlInputData : UserControlBase1
    {
        private ButtonEdit buttonEditDataPath;
        private ButtonEdit buttonEditTargetPath;
        private CheckEdit checkEdit2;
        private CheckEdit checkPorpertyMatch;
        private int ComboxSelectIndex = -1;
        private IContainer components = null;
        private GridColumn gridColumn1;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
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
        private GridView gridView1;
        private GridView gridView2;
        private GridView gridView3;
        private GridView gridView4;
        internal ImageList ImageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label labelPointInfo;
        private Label labelPointInfo2;
        private Label labelPointList;
        private Label labelprogress;
        private Label labelSourceInfo;
        private ListBoxControl listBoxDataList;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private ITable m_EditTable = null;
        private IFeatureWorkspace m_EditWorkspace;
        private IGroupLayer m_TempGroupLayer;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private const string mClassName = "DataEdit.UserControlInputData";
     
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private HookHelper mHookHelper = null;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
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
        private const string myClassName = "数据导入";
        private Panel panel10;
        private Panel panel12;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
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
        private Panel panelSet;
        private Panel panelSetID;
        private Panel panelSetSubID;
        private Panel panelSubID;
        private Panel panelTarget;
        private ProgressBarControl progressBar;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
        private RadioGroup radioGroup3;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RepositoryItemComboBox repositoryItemComboBox4;
        private RichTextBox richTextBox;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButtonAdd;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonClear;
        private SimpleButton simpleButtonClear2;
        public SimpleButton simpleButtonConvert;
        private SimpleButton simpleButtonDeletePoly;
        private SimpleButton simpleButtonExpend;
        private SimpleButton simpleButtonExpend2;
        private SimpleButton simpleButtonInput;
        private SimpleButton simpleButtonInputPoint;
        private SimpleButton simpleButtonRemove;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonSelected;
        private SimpleButton simpleButtonSelectTool;
        private SplitterControl splitterControl1;
        private string SubID = "";

        public UserControlInputData()
        {
            this.InitializeComponent();
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
            catch (Exception)
            {
            }
        }

        private void AddPolygonLayer(IFeatureClass pfc, string sName)
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

        private void buttonEditDataPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                IGxObjectFilter filter = new GxFilterDatasetsAndLayersClass();
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    GxFilterShapefiles shapefiles = new GxFilterShapefilesClass();
                    filter = shapefiles;
                }
                else if (this.radioGroup2.SelectedIndex == 1)
                {
                    GxFilterTextFiles files = new GxFilterTextFilesClass();
                    filter = files;
                }
                IGxDialog dialog = new GxDialogClass();
                dialog.AllowMultiSelect = false;
                dialog.Title = "选择" + this.mEditKind + "数据";
                dialog.ObjectFilter = filter;
                IEnumGxObject selection = null;
                IGxObject obj3 = null;
                if (dialog.DoModalOpen((int) base.Handle, out selection))
                {
                    obj3 = selection.Next();
                    this.buttonEditDataPath.Text = obj3.FullName;
                    this.buttonEditDataPath.Tag = obj3.BaseName;
                    this.simpleButtonAdd.Enabled = true;
                    this.labelprogress.Visible = false;
                }
            }
            catch (Exception)
            {
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
                if (this.checkEdit2.Checked)
                {
                    this.SubID = "0";
                    IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(null, false);
                    IFeature feature = cursor.NextFeature();
                    int index = feature.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName"));
                    if (index != -1)
                    {
                        while (feature != null)
                        {
                            int num2 = 0;
                            if (feature.get_Value(index).ToString() == "")
                            {
                                num2 = 0;
                            }
                            else
                            {
                                try
                                {
                                    num2 = int.Parse(feature.get_Value(index).ToString());
                                }
                                catch (Exception)
                                {
                                    num2 = 0;
                                }
                            }
                            if (num2 > int.Parse(this.SubID))
                            {
                                this.SubID = feature.get_Value(index).ToString();
                            }
                            feature = cursor.NextFeature();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void checkEdit2_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleButtonExpend2.Visible = this.checkEdit2.Checked;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "CreateShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
            try
            {
                for (int i = 0; i < this.mRangeList.Count; i++)
                {
                    IFeatureClass class2 = this.mRangeList[i] as IFeatureClass;
                    string aliasName = class2.AliasName;
                    IFeatureCursor cursor = class2.Search(null, false);
                    IFeature feature = cursor.NextFeature();
                    pWorkspaceEdit.StartEditing(false);
                    pWorkspaceEdit.StartEditOperation();
                    while (feature != null)
                    {
                        int num5;
                        int num6;
                        int num7;
                        this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                        this.richTextBox.Refresh();
                        IFeature feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                        IClone shape = (IClone) feature.Shape;
                        if (shape == null)
                        {
                            return;
                        }
                        IPolygon polygon = (IPolygon) shape.Clone();
                        try
                        {
                            feature2.Shape = new PolygonClass();
                            feature2.Shape = polygon;
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            goto Label_082E;
                        }
                        if ((this.mKeyFieldName != "") && (this.m_EditTable != null))
                        {
                            int num8;
                            string str2 = Guid.NewGuid().ToString();
                            int index = feature2.Fields.FindField(this.mKeyFieldName);
                            feature2.set_Value(index, str2);
                            IFields fields = feature2.Fields;
                            IRow row = this.m_EditTable.CreateRow();
                            int num3 = fields.FindField("Task_State".ToUpper());
                            int num4 = row.Fields.FindField("Task_State".ToUpper());
                            if (num3 > -1)
                            {
                                feature2.set_Value(num3, EditTask.TaskState.GetHashCode().ToString());
                            }
                            if (num4 > -1)
                            {
                                row.set_Value(num4, EditTask.TaskState.GetHashCode().ToString());
                            }
                            num3 = fields.FindField("Edit_State".ToUpper());
                            num4 = row.Fields.FindField("Edit_State".ToUpper());
                            if (num3 > -1)
                            {
                                feature2.set_Value(num3, "1");
                            }
                            if (num4 > -1)
                            {
                                row.set_Value(num4, "1");
                            }
                            num3 = fields.FindField("Task_ID".ToUpper());
                            num4 = row.Fields.FindField("Task_ID".ToUpper());
                            if (num3 > -1)
                            {
                                feature2.set_Value(num3, EditTask.TaskID.ToString());
                            }
                            if (num4 > -1)
                            {
                                row.set_Value(num4, EditTask.TaskID.ToString());
                            }
                            num3 = fields.FindField("YEAR");
                            num4 = row.Fields.FindField("YEAR");
                            if (num3 > -1)
                            {
                                feature2.set_Value(num3, EditTask.TaskYear);
                            }
                            if (num4 > -1)
                            {
                                row.set_Value(num4, EditTask.TaskYear);
                            }
                            num3 = fields.FindField("CNTY");
                            num4 = row.Fields.FindField("CNTY");
                            if (num3 > -1)
                            {
                                feature2.set_Value(num3, EditTask.DistCode.Substring(0, 6));
                            }
                            num3 = fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName"));
                            num4 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName"));
                            if ((num3 > -1) && this.checkEdit2.Checked)
                            {
                                num8 = int.Parse(this.SubID) + 1;
                                feature2.set_Value(num3, num8.ToString());
                            }
                            if ((num4 > -1) && this.checkEdit2.Checked)
                            {
                                num8 = int.Parse(this.SubID) + 1;
                                row.set_Value(num4, num8.ToString());
                            }
                            num5 = 0;
                            while (num5 < this.mFieldTable.Rows.Count)
                            {
                                if ((this.mFieldTable.Rows[num5][2] != "") && (this.mFieldTable.Rows[num5][3] != ""))
                                {
                                    num6 = row.Fields.FindField(this.mFieldTable.Rows[num5]["目标数据字段2"].ToString());
                                    num7 = feature.Fields.FindField(this.mFieldTable.Rows[num5]["源数据字段2"].ToString());
                                    if ((num6 != -1) && (num7 != -1))
                                    {
                                        if (row.get_Value(num6).ToString() == "")
                                        {
                                            if (feature.Fields.get_Field(num7).Type == row.Fields.get_Field(num6).Type)
                                            {
                                                row.set_Value(num6, feature.get_Value(num7));
                                            }
                                            else if (row.Fields.get_Field(num6).Type == esriFieldType.esriFieldTypeDouble)
                                            {
                                                row.set_Value(num6, double.Parse(feature.get_Value(num7).ToString()));
                                            }
                                            else if (row.Fields.get_Field(num6).Type == esriFieldType.esriFieldTypeInteger)
                                            {
                                                row.set_Value(num6, int.Parse(feature.get_Value(num7).ToString()));
                                            }
                                            else if (row.Fields.get_Field(num6).Type == esriFieldType.esriFieldTypeString)
                                            {
                                                row.set_Value(num6, feature.get_Value(num7).ToString());
                                            }
                                        }
                                    }
                                    else if (row.Fields.get_Field(num6).Type.ToString().Contains("String"))
                                    {
                                        row.set_Value(num6, "");
                                    }
                                    else
                                    {
                                        row.set_Value(num6, null);
                                    }
                                }
                                num5++;
                            }
                            index = row.Fields.FindField(this.mKeyFieldName);
                            row.set_Value(index, str2);
                            row.Store();
                        }
                        else
                        {
                            for (num5 = 0; num5 < this.mFieldTable.Rows.Count; num5++)
                            {
                                num6 = feature2.Fields.FindField(this.mFieldTable.Rows[num5]["目标数据字段2"].ToString());
                                num7 = feature.Fields.FindField(this.mFieldTable.Rows[num5]["源数据字段2"].ToString());
                                if ((num6 != -1) && (num7 != -1))
                                {
                                    feature2.set_Value(num6, feature.get_Value(num7));
                                }
                            }
                        }
                        try
                        {
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                            this.SubID = (int.Parse(this.SubID) + 1).ToString();
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                    Label_082E:
                        feature = cursor.NextFeature();
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
                    this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + class2.AliasName + "]成功";
                    this.labelprogress.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void DoInput2(IWorkspaceEdit pWorkspaceEdit)
        {
            try
            {
                IFeatureClass featureClass = this.mPolyFeatureLayer.FeatureClass;
                string aliasName = featureClass.AliasName;
                IFeatureCursor cursor = featureClass.Search(null, false);
                IFeature feature = cursor.NextFeature();
                this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                pWorkspaceEdit.StartEditing(false);
                pWorkspaceEdit.StartEditOperation();
                while (feature != null)
                {
                    this.richTextBox.Text = this.richTextBox.Text + "\n导入要素" + feature.OID;
                    this.richTextBox.Refresh();
                    IFeature feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                    IClone shape = (IClone) feature.Shape;
                    if (shape == null)
                    {
                        return;
                    }
                    IPolygon polygon = (IPolygon) shape.Clone();
                    try
                    {
                        feature2.Shape = new PolygonClass();
                        feature2.Shape = polygon;
                    }
                    catch (Exception)
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                        goto Label_0700;
                    }
                    if ((this.mKeyFieldName != "") && (this.m_EditTable != null))
                    {
                        string str2 = Guid.NewGuid().ToString();
                        int index = feature2.Fields.FindField(this.mKeyFieldName);
                        feature2.set_Value(index, str2);
                        IRow row = this.m_EditTable.CreateRow();
                        IFields fields = feature2.Fields;
                        for (int i = 0; i < fields.FieldCount; i++)
                        {
                            int num3;
                            if (fields.get_Field(i).Name.ToUpper() == "Task_State".ToUpper())
                            {
                                feature2.set_Value(i, EditTask.TaskState.GetHashCode().ToString());
                                num3 = row.Fields.FindField("Task_State".ToUpper());
                                if (num3 > -1)
                                {
                                    row.set_Value(num3, EditTask.TaskState.GetHashCode().ToString());
                                }
                            }
                            if (fields.get_Field(i).Name.ToUpper() == "Edit_State".ToUpper())
                            {
                                feature2.set_Value(i, "1");
                                num3 = row.Fields.FindField("Edit_State".ToUpper());
                                if (num3 > -1)
                                {
                                    row.set_Value(num3, "1");
                                }
                            }
                            if (fields.get_Field(i).Name.ToUpper() == "Task_ID".ToUpper())
                            {
                                feature2.set_Value(i, EditTask.TaskID);
                                num3 = row.Fields.FindField("Task_ID".ToUpper());
                                if (num3 > -1)
                                {
                                    row.set_Value(num3, EditTask.TaskID);
                                }
                            }
                            if (fields.get_Field(i).Name.ToUpper() == "YEAR".ToUpper())
                            {
                                feature2.set_Value(i, EditTask.TaskYear);
                                num3 = row.Fields.FindField("YEAR".ToUpper());
                                if (num3 > -1)
                                {
                                    row.set_Value(num3, EditTask.TaskYear);
                                }
                            }
                            if (fields.get_Field(i).Name.ToUpper() == "CNTY".ToUpper())
                            {
                                feature2.set_Value(i, EditTask.DistCode.Substring(0, 6));
                                num3 = row.Fields.FindField("CNTY".ToUpper());
                                if (num3 > -1)
                                {
                                    row.set_Value(num3, EditTask.DistCode.Substring(0, 6));
                                }
                            }
                            if ((fields.get_Field(i).Name == UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName")) && (this.checkEdit2.Checked || (this.radioGroup2.SelectedIndex == 1)))
                            {
                                this.SubID = "0";
                                IQueryFilter filter = new QueryFilterClass();
                                filter.WhereClause = string.Concat(new object[] { "Task_ID".ToUpper(), " LIKE '%", EditTask.TaskID, "%'" });
                                IFeatureCursor cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                                IFeature feature3 = cursor2.NextFeature();
                                int num4 = feature3.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName"));
                                if (num4 == -1)
                                {
                                    return;
                                }
                                while (feature3 != null)
                                {
                                    int num5 = 0;
                                    try
                                    {
                                        num5 = int.Parse(feature3.get_Value(num4).ToString());
                                    }
                                    catch (Exception)
                                    {
                                        num5 = 0;
                                    }
                                    if (num5 > int.Parse(this.SubID))
                                    {
                                        this.SubID = feature3.get_Value(num4).ToString();
                                    }
                                    feature3 = cursor2.NextFeature();
                                }
                                if (this.SubID == "")
                                {
                                    this.SubID = "0";
                                }
                                int num6 = int.Parse(this.SubID) + 1;
                                feature2.set_Value(i, num6.ToString());
                                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldUID");
                                num3 = row.Fields.FindField(configValue);
                                if (num3 > -1)
                                {
                                    num6 = int.Parse(this.SubID) + 1;
                                    row.set_Value(num3, num6.ToString());
                                }
                            }
                        }
                        index = row.Fields.FindField(this.mKeyFieldName);
                        row.set_Value(index, str2);
                        row.Store();
                        try
                        {
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                            this.SubID = (int.Parse(this.SubID) + 1).ToString();
                        }
                        catch (Exception)
                        {
                            this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                            Editor.UniqueInstance.AddAttribute = false;
                            feature2.Store();
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                    }
                Label_0700:
                    feature = cursor.NextFeature();
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
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + featureClass.AliasName + "]成功";
                this.labelprogress.Visible = true;
            }
            catch (Exception)
            {
            }
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

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.Caption == "源数据字段")
            {
                e.RepositoryItem = this.repositoryItemComboBox1;
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
                (this.mPointFeatureLayer as IFeatureSelection).Clear();
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
            catch (Exception)
            {
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
            catch (Exception)
            {
            }
        }

        private void InitialControl()
        {
            try
            {
                this.SetView(0);
                this.InitialFieldGrid();
                this.mRangeList = new ArrayList();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                string tableName = EditTask.TableName;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldUID");
                this.mKeyFieldName = configValue;
                try
                {
                    this.m_EditTable = this.m_EditWorkspace.OpenTable(tableName);
                }
                catch (Exception)
                {
                }
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "InitialFieldGrid", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    if ((pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.OIDFieldName) && (pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.ShapeFieldName))
                    {
                        string str = pFeatureClass.Fields.get_Field(i).Type.ToString().Replace("esriFieldType", "");
                        this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).Name + "[" + str + "]");
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "InitialFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlInputData));
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
            this.simpleButtonConvert = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInputPoint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInput = new DevExpress.XtraEditors.SimpleButton();
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
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.panelSubID = new System.Windows.Forms.Panel();
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelGPS = new System.Windows.Forms.Panel();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            this.panelSubID.SuspendLayout();
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
            this.panelPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelGPS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGridControl
            // 
            this.panelGridControl.BackColor = System.Drawing.Color.Transparent;
            this.panelGridControl.Controls.Add(this.gridControl1);
            this.panelGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridControl.Location = new System.Drawing.Point(5, 28);
            this.panelGridControl.Name = "panelGridControl";
            this.panelGridControl.Padding = new System.Windows.Forms.Padding(0, 5, 0, 9);
            this.panelGridControl.Size = new System.Drawing.Size(278, 160);
            this.panelGridControl.TabIndex = 17;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 5);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(278, 146);
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
            this.panelField.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panelField.Size = new System.Drawing.Size(288, 188);
            this.panelField.TabIndex = 18;
            // 
            // panelFieldMatch
            // 
            this.panelFieldMatch.Controls.Add(this.simpleButtonExpend);
            this.panelFieldMatch.Controls.Add(this.simpleButtonReset);
            this.panelFieldMatch.Controls.Add(this.checkPorpertyMatch);
            this.panelFieldMatch.Controls.Add(this.simpleButtonClear);
            this.panelFieldMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFieldMatch.Location = new System.Drawing.Point(5, 0);
            this.panelFieldMatch.Name = "panelFieldMatch";
            this.panelFieldMatch.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelFieldMatch.Size = new System.Drawing.Size(278, 28);
            this.panelFieldMatch.TabIndex = 17;
            // 
            // simpleButtonExpend
            // 
            this.simpleButtonExpend.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend.ImageIndex = 14;
            this.simpleButtonExpend.ImageList = this.ImageList1;
            this.simpleButtonExpend.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend.Location = new System.Drawing.Point(200, 2);
            this.simpleButtonExpend.Name = "simpleButtonExpend";
            this.simpleButtonExpend.Size = new System.Drawing.Size(26, 26);
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
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.ImageIndex = 87;
            this.simpleButtonReset.ImageList = this.ImageList1;
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonReset.Location = new System.Drawing.Point(226, 2);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(26, 26);
            this.simpleButtonReset.TabIndex = 13;
            this.simpleButtonReset.ToolTip = "重新匹配";
            this.simpleButtonReset.Visible = false;
            // 
            // checkPorpertyMatch
            // 
            this.checkPorpertyMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkPorpertyMatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkPorpertyMatch.Location = new System.Drawing.Point(0, 2);
            this.checkPorpertyMatch.Name = "checkPorpertyMatch";
            this.checkPorpertyMatch.Properties.Caption = "属性字段匹配:";
            this.checkPorpertyMatch.Size = new System.Drawing.Size(133, 19);
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
            this.simpleButtonClear.Location = new System.Drawing.Point(252, 2);
            this.simpleButtonClear.Name = "simpleButtonClear";
            this.simpleButtonClear.Size = new System.Drawing.Size(26, 26);
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
            this.panelResource.Padding = new System.Windows.Forms.Padding(5, 2, 5, 7);
            this.panelResource.Size = new System.Drawing.Size(288, 140);
            this.panelResource.TabIndex = 16;
            this.panelResource.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // listBoxDataList
            // 
            this.listBoxDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDataList.Location = new System.Drawing.Point(5, 80);
            this.listBoxDataList.Name = "listBoxDataList";
            this.listBoxDataList.Size = new System.Drawing.Size(278, 53);
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
            this.panel12.Location = new System.Drawing.Point(5, 50);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel12.Size = new System.Drawing.Size(278, 30);
            this.panel12.TabIndex = 13;
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonAdd.ImageIndex = 71;
            this.simpleButtonAdd.ImageList = this.ImageList1;
            this.simpleButtonAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAdd.Location = new System.Drawing.Point(200, 2);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(26, 26);
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
            this.simpleButtonRemove.Location = new System.Drawing.Point(226, 2);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(26, 26);
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
            this.label9.Location = new System.Drawing.Point(0, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 26);
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
            this.simpleButtonClear2.Location = new System.Drawing.Point(252, 2);
            this.simpleButtonClear2.Name = "simpleButtonClear2";
            this.simpleButtonClear2.Size = new System.Drawing.Size(26, 26);
            this.simpleButtonClear2.TabIndex = 12;
            this.simpleButtonClear2.ToolTip = "清除";
            this.simpleButtonClear2.Click += new System.EventHandler(this.simpleButtonClear2_Click);
            // 
            // buttonEditDataPath
            // 
            this.buttonEditDataPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditDataPath.Location = new System.Drawing.Point(5, 30);
            this.buttonEditDataPath.Name = "buttonEditDataPath";
            this.buttonEditDataPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditDataPath.Size = new System.Drawing.Size(278, 20);
            this.buttonEditDataPath.TabIndex = 10;
            this.buttonEditDataPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditDataPath_ButtonClick);
            this.buttonEditDataPath.EditValueChanged += new System.EventHandler(this.buttonEditDataPath_EditValueChanged);
            this.buttonEditDataPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonEditDataPath_KeyPress);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "导入数据路径:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup2.Location = new System.Drawing.Point(5, 30);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "空间要素类"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "GPS文本文件")});
            this.radioGroup2.Size = new System.Drawing.Size(278, 31);
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
            this.panelTarget.Padding = new System.Windows.Forms.Padding(7, 2, 7, 7);
            this.panelTarget.Size = new System.Drawing.Size(288, 85);
            this.panelTarget.TabIndex = 19;
            this.panelTarget.Visible = false;
            // 
            // buttonEditTargetPath
            // 
            this.buttonEditTargetPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditTargetPath.Enabled = false;
            this.buttonEditTargetPath.Location = new System.Drawing.Point(7, 55);
            this.buttonEditTargetPath.Name = "buttonEditTargetPath";
            this.buttonEditTargetPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditTargetPath.Size = new System.Drawing.Size(274, 20);
            this.buttonEditTargetPath.TabIndex = 10;
            this.buttonEditTargetPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditTargetPath_ButtonClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ImageList = this.ImageList1;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "目标数据路径:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(7, 2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "当前编辑图层"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定目标数据")});
            this.radioGroup1.Size = new System.Drawing.Size(274, 30);
            this.radioGroup1.TabIndex = 14;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panelDo
            // 
            this.panelDo.BackColor = System.Drawing.Color.Transparent;
            this.panelDo.Controls.Add(this.panel6);
            this.panelDo.Controls.Add(this.progressBar);
            this.panelDo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDo.Location = new System.Drawing.Point(2, 1244);
            this.panelDo.Name = "panelDo";
            this.panelDo.Padding = new System.Windows.Forms.Padding(7, 7, 7, 9);
            this.panelDo.Size = new System.Drawing.Size(288, 37);
            this.panelDo.TabIndex = 27;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.simpleButtonConvert);
            this.panel6.Controls.Add(this.simpleButtonInputPoint);
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonInput);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(7, 7);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(274, 28);
            this.panel6.TabIndex = 11;
            // 
            // simpleButtonConvert
            // 
            this.simpleButtonConvert.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonConvert.ImageIndex = 40;
            this.simpleButtonConvert.ImageList = this.ImageList1;
            this.simpleButtonConvert.Location = new System.Drawing.Point(-15, 0);
            this.simpleButtonConvert.Name = "simpleButtonConvert";
            this.simpleButtonConvert.Size = new System.Drawing.Size(71, 28);
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
            this.simpleButtonInputPoint.Location = new System.Drawing.Point(56, 0);
            this.simpleButtonInputPoint.Name = "simpleButtonInputPoint";
            this.simpleButtonInputPoint.Size = new System.Drawing.Size(76, 28);
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
            this.simpleButtonBack.Location = new System.Drawing.Point(132, 0);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(71, 28);
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
            this.simpleButtonInput.Location = new System.Drawing.Point(203, 0);
            this.simpleButtonInput.Name = "simpleButtonInput";
            this.simpleButtonInput.Size = new System.Drawing.Size(71, 28);
            this.simpleButtonInput.TabIndex = 9;
            this.simpleButtonInput.Text = "导入";
            this.simpleButtonInput.Click += new System.EventHandler(this.simpleButtonInput_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(7, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(274, 21);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // labelprogress
            // 
            this.labelprogress.BackColor = System.Drawing.Color.Transparent;
            this.labelprogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(274, 54);
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
            this.panelLog.Location = new System.Drawing.Point(2, 768);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(7, 0, 7, 5);
            this.panelLog.Size = new System.Drawing.Size(288, 82);
            this.panelLog.TabIndex = 28;
            this.panelLog.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(7, 58);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(274, 19);
            this.panelControl1.TabIndex = 16;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(270, 15);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(7, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel4.Size = new System.Drawing.Size(274, 58);
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
            this.panelResource0.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panelResource0.Size = new System.Drawing.Size(288, 68);
            this.panelResource0.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "导入数据类型:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSetSubID
            // 
            this.panelSetSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSetSubID.Controls.Add(this.panel5);
            this.panelSetSubID.Controls.Add(this.radioGroup3);
            this.panelSetSubID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetSubID.Location = new System.Drawing.Point(5, 28);
            this.panelSetSubID.Name = "panelSetSubID";
            this.panelSetSubID.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.panelSetSubID.Size = new System.Drawing.Size(278, 31);
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
            this.panel5.Size = new System.Drawing.Size(278, 75);
            this.panel5.TabIndex = 15;
            this.panel5.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelSourceInfo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(278, 30);
            this.panelControl2.TabIndex = 16;
            // 
            // labelSourceInfo
            // 
            this.labelSourceInfo.BackColor = System.Drawing.Color.White;
            this.labelSourceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSourceInfo.Location = new System.Drawing.Point(2, 2);
            this.labelSourceInfo.Name = "labelSourceInfo";
            this.labelSourceInfo.Size = new System.Drawing.Size(274, 26);
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
            this.label1.Size = new System.Drawing.Size(278, 21);
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
            this.radioGroup3.Size = new System.Drawing.Size(278, 28);
            this.radioGroup3.TabIndex = 31;
            this.radioGroup3.SelectedIndexChanged += new System.EventHandler(this.radioGroup3_SelectedIndexChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEdit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkEdit2.Location = new System.Drawing.Point(0, 2);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "生成小班编号:";
            this.checkEdit2.Size = new System.Drawing.Size(133, 19);
            this.checkEdit2.TabIndex = 33;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            this.checkEdit2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkEdit2_MouseUp);
            // 
            // panelSubID
            // 
            this.panelSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSubID.Controls.Add(this.panelSetSubID);
            this.panelSubID.Controls.Add(this.panelSetID);
            this.panelSubID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubID.Location = new System.Drawing.Point(0, 482);
            this.panelSubID.Name = "panelSubID";
            this.panelSubID.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelSubID.Size = new System.Drawing.Size(288, 64);
            this.panelSubID.TabIndex = 31;
            this.panelSubID.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSubID_Paint);
            // 
            // panelSetID
            // 
            this.panelSetID.Controls.Add(this.simpleButtonExpend2);
            this.panelSetID.Controls.Add(this.checkEdit2);
            this.panelSetID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetID.Location = new System.Drawing.Point(5, 0);
            this.panelSetID.Name = "panelSetID";
            this.panelSetID.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelSetID.Size = new System.Drawing.Size(278, 28);
            this.panelSetID.TabIndex = 15;
            // 
            // simpleButtonExpend2
            // 
            this.simpleButtonExpend2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend2.ImageIndex = 14;
            this.simpleButtonExpend2.ImageList = this.ImageList1;
            this.simpleButtonExpend2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend2.Location = new System.Drawing.Point(252, 2);
            this.simpleButtonExpend2.Name = "simpleButtonExpend2";
            this.simpleButtonExpend2.Size = new System.Drawing.Size(26, 26);
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
            this.panelPointList.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelPointList.Size = new System.Drawing.Size(288, 215);
            this.panelPointList.TabIndex = 32;
            this.panelPointList.Visible = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(5, 30);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl3.Size = new System.Drawing.Size(278, 152);
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
            this.gridControl3.Size = new System.Drawing.Size(274, 146);
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
            this.panel3.Location = new System.Drawing.Point(5, 182);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel3.Size = new System.Drawing.Size(278, 28);
            this.panel3.TabIndex = 18;
            // 
            // labelPointInfo2
            // 
            this.labelPointInfo2.BackColor = System.Drawing.Color.Transparent;
            this.labelPointInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointInfo2.Location = new System.Drawing.Point(0, 2);
            this.labelPointInfo2.Name = "labelPointInfo2";
            this.labelPointInfo2.Size = new System.Drawing.Size(212, 26);
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
            this.simpleButtonSelected.Location = new System.Drawing.Point(212, 2);
            this.simpleButtonSelected.Name = "simpleButtonSelected";
            this.simpleButtonSelected.Size = new System.Drawing.Size(66, 26);
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
            this.panel8.Location = new System.Drawing.Point(5, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel8.Size = new System.Drawing.Size(278, 30);
            this.panel8.TabIndex = 15;
            // 
            // labelPointList
            // 
            this.labelPointList.BackColor = System.Drawing.Color.Transparent;
            this.labelPointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointList.Location = new System.Drawing.Point(0, 2);
            this.labelPointList.Name = "labelPointList";
            this.labelPointList.Size = new System.Drawing.Size(212, 26);
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
            this.simpleButtonSelectTool.Location = new System.Drawing.Point(212, 2);
            this.simpleButtonSelectTool.Name = "simpleButtonSelectTool";
            this.simpleButtonSelectTool.Size = new System.Drawing.Size(66, 26);
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
            this.panelPolyList.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelPolyList.Size = new System.Drawing.Size(288, 177);
            this.panelPolyList.TabIndex = 33;
            this.panelPolyList.Visible = false;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl4);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(5, 30);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl4.Size = new System.Drawing.Size(278, 142);
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
            this.gridControl4.Size = new System.Drawing.Size(274, 136);
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
            this.panel10.Location = new System.Drawing.Point(5, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel10.Size = new System.Drawing.Size(278, 30);
            this.panel10.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 26);
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
            this.simpleButtonDeletePoly.Location = new System.Drawing.Point(212, 2);
            this.simpleButtonDeletePoly.Name = "simpleButtonDeletePoly";
            this.simpleButtonDeletePoly.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonDeletePoly.TabIndex = 12;
            this.simpleButtonDeletePoly.Text = "删除";
            this.simpleButtonDeletePoly.ToolTip = "删除选中的班块";
            this.simpleButtonDeletePoly.Visible = false;
            this.simpleButtonDeletePoly.Click += new System.EventHandler(this.simpleButtonDeletePoly_Click);
            // 
            // panelSet
            // 
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
            this.panelSet.Size = new System.Drawing.Size(288, 766);
            this.panelSet.TabIndex = 34;
            // 
            // panelPoints
            // 
            this.panelPoints.BackColor = System.Drawing.Color.Transparent;
            this.panelPoints.Controls.Add(this.panelControl5);
            this.panelPoints.Controls.Add(this.panel2);
            this.panelPoints.Controls.Add(this.panel7);
            this.panelPoints.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPoints.Location = new System.Drawing.Point(0, 546);
            this.panelPoints.Name = "panelPoints";
            this.panelPoints.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelPoints.Size = new System.Drawing.Size(288, 215);
            this.panelPoints.TabIndex = 33;
            this.panelPoints.Visible = false;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.gridControl2);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(5, 30);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelControl5.Size = new System.Drawing.Size(278, 152);
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
            this.gridControl2.Size = new System.Drawing.Size(274, 146);
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
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 182);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(278, 28);
            this.panel2.TabIndex = 18;
            // 
            // labelPointInfo
            // 
            this.labelPointInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelPointInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointInfo.Location = new System.Drawing.Point(0, 2);
            this.labelPointInfo.Name = "labelPointInfo";
            this.labelPointInfo.Size = new System.Drawing.Size(212, 26);
            this.labelPointInfo.TabIndex = 17;
            this.labelPointInfo.Text = "共计:300个点";
            this.labelPointInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPointInfo.Click += new System.EventHandler(this.label4_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.ImageIndex = 66;
            this.simpleButton1.ImageList = this.ImageList1;
            this.simpleButton1.Location = new System.Drawing.Point(212, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(66, 26);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "选中";
            this.simpleButton1.ToolTip = "查看选中图形对象";
            this.simpleButton1.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.simpleButton2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(5, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel7.Size = new System.Drawing.Size(278, 30);
            this.panel7.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 26);
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
            this.simpleButton2.Location = new System.Drawing.Point(212, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(66, 26);
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
            this.panelGPS.Location = new System.Drawing.Point(2, 850);
            this.panelGPS.Name = "panelGPS";
            this.panelGPS.Size = new System.Drawing.Size(288, 397);
            this.panelGPS.TabIndex = 35;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 215);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(288, 5);
            this.splitterControl1.TabIndex = 34;
            this.splitterControl1.TabStop = false;
            // 
            // UserControlInputData
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelGPS);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelDo);
            this.Controls.Add(this.panelSet);
            this.Name = "UserControlInputData";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(292, 1283);
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
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            this.panelSubID.ResumeLayout(false);
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
            this.panelPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelGPS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitialValue()
        {
            try
            {
                IMap focusMap = this.mHookHelper.FocusMap;
                string sLayerName = "";
                if (this.mEditKind == "小班")
                {
                    this.mEditKind2 = "xiaoban";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditLayer");
                }
                else if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditZLLayer");
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditCFLayer");
                }
                else if (this.mEditKind == "林改")
                {
                    this.mEditKind2 = "LinGai";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditLGLayer");
                }
                else if (this.mEditKind == "公益林")
                {
                    this.mEditKind2 = "GYL";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditGYLLayer");
                }
                else if (this.mEditKind == "通用")
                {
                    this.mEditKind2 = "TY";
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditTYLayer");
                }
                this.m_EditLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, sLayerName, true);
                if (this.m_EditLayer == null)
                {
                    this.m_EditLayer = EditTask.EditLayer;
                }
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                if (sSourceFile.Contains(".gdb") || sSourceFile.Contains(".GDB"))
                {
                    this.m_EditWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                }
                else if (sSourceFile.Contains(".mdb") || sSourceFile.Contains(".MDB"))
                {
                    this.m_EditWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSAccessWorkspaceFactory);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    point.PutCoords(double.Parse("17" + this.mPointTable.Rows[i]["X坐标"].ToString()), double.Parse(this.mPointTable.Rows[i]["Y坐标"].ToString()));
                    point.Project(this.mHookHelper.FocusMap.SpatialReference);
                    IGeometry geometry = point;
                    feature.Shape = geometry;
                    int index = feature.Fields.FindField("ID");
                    feature.set_Value(index, this.mPointTable.Rows[i]["点号"]);
                    index = feature.Fields.FindField("X坐标");
                    feature.set_Value(index, "17" + this.mPointTable.Rows[i]["X坐标"]);
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
            }
            else if (this.radioGroup2.SelectedIndex == 1)
            {
                this.SetView(1);
            }
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
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

        private void repositoryItemComboBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "SetFieldMatch", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputData", "SetSelectPoints", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    this.panelSubID.Height = this.panelSetID.Height;
                    this.checkEdit2.Enabled = true;
                    this.checkPorpertyMatch.Checked = false;
                    this.panelPoints.Visible = false;
                    this.panelLog.Visible = false;
                    this.panelGPS.Visible = false;
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
                    this.panelSubID.Height = this.panelSetID.Height;
                    this.mPointTable.Clear();
                    this.mPointTable2.Clear();
                    this.labelPointInfo2.Text = "";
                    this.panelPoints.Visible = true;
                    this.panelPoints.Dock = DockStyle.Fill;
                    this.panelPoints.BringToFront();
                    this.labelPointInfo.Text = "";
                    this.panelGPS.Visible = false;
                    this.panelLog.Visible = false;
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
            catch (Exception)
            {
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.buttonEditDataPath.Text != "")
                {
                    for (int i = 0; i < this.listBoxDataList.Items.Count; i++)
                    {
                        if (this.buttonEditDataPath.Text == this.listBoxDataList.Items[i].ToString())
                        {
                            return;
                        }
                    }
                    this.listBoxDataList.Items.Add(this.buttonEditDataPath.Text);
                    if (this.radioGroup2.SelectedIndex == 0)
                    {
                        IFeatureClass class2 = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(Directory.GetParent(this.buttonEditDataPath.Text).ToString(), WorkspaceSource.esriWSShapefileWorkspaceFactory).OpenFeatureClass(this.buttonEditDataPath.Tag.ToString());
                        this.mRangeList.Add(class2);
                        if (this.mRangeList.Count == 1)
                        {
                            this.SetFieldMatch(class2);
                            this.InitialFieldList(class2);
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
                        this.simpleButtonRemove.Enabled = true;
                        this.simpleButtonAdd.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
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
            this.mRangeList = new ArrayList();
            this.listBoxDataList.Items.Clear();
            this.mPointTable.Clear();
            this.mPointTable2.Clear();
            this.labelPointInfo2.Text = "";
            this.simpleButtonRemove.Enabled = false;
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
            catch (Exception)
            {
            }
        }

        private void simpleButtonDeletePoly_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonExpend_Click(object sender, EventArgs e)
        {
            if (this.panelField.Height == this.panelFieldMatch.Height)
            {
                this.panelSubID.Visible = true;
                this.panelSubID.Height = this.panelSetID.Height;
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
            if (this.panelSubID.Height == this.panelSetID.Height)
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
                this.panelSubID.Height = this.panelSetID.Height;
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
                    this.simpleButtonInput.Enabled = false;
                    this.simpleButtonBack.Visible = true;
                    this.Cursor = Cursors.Default;
                    this.panelResource.Enabled = true;
                    this.panelTarget.Enabled = true;
                    this.panelField.Enabled = true;
                }
            }
            catch (Exception)
            {
                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                this.labelprogress.Text = "导入" + this.mEditKind + "作业图层[" + str + "]失败";
                this.labelprogress.Visible = true;
                this.Cursor = Cursors.Default;
            }
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
            catch (Exception)
            {
            }
        }

        private void simpleButtonSelected_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonSelectTool_Click(object sender, EventArgs e)
        {
            SelectTool tool = new SelectTool(this.mPointFeatureLayer, this);
            tool.OnCreate(this.mHookHelper.Hook);
            tool.OnClick();
            IMapControl2 hook = null;
            hook = (IMapControl2) this.mHookHelper.Hook;
            hook.CurrentTool = tool;
        }
    }
}

