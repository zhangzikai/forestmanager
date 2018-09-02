namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Utilities;

    public class AddTxtPointsCommand : BaseCommand
    {
        private ICommand m_command;
        private IFeatureLayer m_EditLayer;
        private IFeature m_Feature;
        private IHookHelper m_HookHelper;
        private IGroupLayer m_TempGroupLayer;
        private ITool m_tool;
        private const string mClassName = "DataEdit.AddTxtPointsCommand";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private IFeatureClass mPointFeatureClass;
        private IFeatureLayer mPointFeatureLayer;
        private DataTable mPointTable;
        private IFeatureLayer mPolyFeatureLayer;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public AddTxtPointsCommand()
        {
            base.m_category = "DataEdit";
            base.m_caption = "添加GPS轨迹点";
            base.m_message = "添加GPS点数据";
            base.m_toolTip = "添加GPS点数据";
            base.m_name = "DataEdit_AddTxtPoints";
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.AddTxtPointsCommand", "AddTxtPointsCommand", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                    pGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (pGroupLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(this.m_HookHelper.FocusMap as IBasicMap, null, "GPS轨迹");
                    pGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                }
                if (pGroupLayer != null)
                {
                    ILayer layer3 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, sName, true);
                    if (layer3 == null)
                    {
                        pGroupLayer.Add(layer);
                    }
                    else
                    {
                        (layer3 as IFeatureLayer).FeatureClass = pfc;
                    }
                }
                else
                {
                    this.m_HookHelper.FocusMap.AddLayer(layer);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.AddTxtPointsCommand", "AddPointLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                ISpatialReference spatialReference = this.m_HookHelper.FocusMap.SpatialReference;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.AddTxtPointsCommand", "CreateShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private bool InputPoints()
        {
            try
            {
                string str = DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_') + ".shp";
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                this.mFeatureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                if (this.mFeatureWorkspace == null)
                {
                    this.mFeatureWorkspace = this.CreateShapefile(Directory.GetParent(sSourceFile).ToString(), UtilFactory.GetConfigOpt().GetConfigValue("TempPath"), esriGeometryType.esriGeometryPolygon, this.m_HookHelper.FocusMap.SpatialReference);
                }
                if (this.mFeatureWorkspace == null)
                {
                    return false;
                }
                if (this.m_TempGroupLayer == null)
                {
                    this.m_TempGroupLayer = (IGroupLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, "GPS轨迹", true);
                    if (this.m_TempGroupLayer == null)
                    {
                        GISFunFactory.LayerFun.AddGroupLayer(this.m_HookHelper.FocusMap as IBasicMap, null, "GPS轨迹");
                    }
                }
                IFeatureClass class3 = null;
                try
                {
                    class3 = this.mFeatureWorkspace.OpenFeatureClass(str.Split(new char[] { '.' })[0]);
                }
                catch (Exception)
                {
                    class3 = this.CreateFeatureClass(this.mFeatureWorkspace, str.Split(new char[] { '.' })[0].ToString());
                }
                IWorkspaceEdit mFeatureWorkspace = this.mFeatureWorkspace as IWorkspaceEdit;
                if (mFeatureWorkspace == null)
                {
                    return false;
                }
                mFeatureWorkspace.StartEditing(false);
                mFeatureWorkspace.StartEditOperation();
                for (int i = 0; i < this.mPointTable.Rows.Count; i++)
                {
                    IFeature feature = class3.CreateFeature();
                    IPoint point = new PointClass();
                    point.PutCoords(double.Parse("17" + this.mPointTable.Rows[i]["X坐标"].ToString()), double.Parse(this.mPointTable.Rows[i]["Y坐标"].ToString()));
                    point.Project(this.m_HookHelper.FocusMap.SpatialReference);
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
                mFeatureWorkspace.StopEditing(true);
                mFeatureWorkspace.StopEditOperation();
                this.mPointFeatureClass = class3;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void OnClick()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "轨迹点文件 (*.txt)|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dialog.FileName;
                    if (this.ReadPoints(fileName) && this.InputPoints())
                    {
                        string[] strArray = fileName.Split(new char[] { '\\' });
                        string[] strArray2 = strArray[strArray.Length - 1].Split(new char[] { '.' });
                        this.AddPointLayer(this.mPointFeatureClass, strArray2[0], this.m_TempGroupLayer);
                    }
                    dialog = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.AddTxtPointsCommand", "OnClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.m_HookHelper = new HookHelperClass();
                this.m_HookHelper.Hook = hook;
                if (this.m_HookHelper.ActiveView == null)
                {
                    this.m_HookHelper = null;
                }
            }
            catch
            {
                this.m_HookHelper = null;
            }
            if (this.m_HookHelper == null)
            {
                base.m_enabled = false;
            }
            else
            {
                base.m_enabled = true;
            }
        }

        private bool ReadPoints(string strpath)
        {
            try
            {
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
                if (this.mPointTable == null)
                {
                    this.mPointTable = new DataTable();
                    this.mPointTable.Clear();
                    DataColumn column = new DataColumn("点号", typeof(string));
                    this.mPointTable.Columns.Add(column);
                    column = new DataColumn("X坐标", typeof(string));
                    this.mPointTable.Columns.Add(column);
                    column = new DataColumn("Y坐标", typeof(string));
                    this.mPointTable.Columns.Add(column);
                    column = new DataColumn("时间", typeof(string));
                    this.mPointTable.Columns.Add(column);
                }
                else
                {
                    this.mPointTable.Rows.Clear();
                }
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

