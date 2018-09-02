namespace DataEdit
{
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessor;
    using FunFactory;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class OutputShapeFile
    {
        private const string mClassName = "DataEdit.OutputShapeFile";
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IHookHelper mHookHelper;
        private IMap mMap;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.OutputShapeFile", "CreateShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public void OutputData(string spath, IFeatureClass pfclass, string swhere)
        {
            try
            {
                IFeatureWorkspace featureWorkspace;
                IDataset dataset;
                string[] strArray = spath.Split(new char[] { '\\' });
                string str = strArray[strArray.Length - 1];
                string sSourceFile = spath.Replace(@"\" + strArray[strArray.Length - 1], "");
                try
                {
                    FileInfo info = new FileInfo(spath);
                    if (info.Exists)
                    {
                        featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                        if (featureWorkspace != null)
                        {
                            dataset = featureWorkspace.OpenFeatureClass(str.Replace(".shp", "")) as IDataset;
                            dataset.Delete();
                        }
                    }
                }
                catch (Exception)
                {
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                Select process = new Select();
                process.in_features = pfclass;
                string str3 = spath;
                process.out_feature_class = str3;
                process.where_clause = swhere;
                object obj2 = geoprocessor.Execute(process, null);
                string messages = "";
                object severity = null;
                messages = geoprocessor.GetMessages(ref severity);
                try
                {
                    featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSShapefileWorkspaceFactory);
                    if (featureWorkspace != null)
                    {
                        dataset = featureWorkspace.OpenFeatureClass(str.Replace(".shp", "")) as IDataset;
                        MessageBox.Show("导出成功！", "数据导出", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("导出失败！", "数据导出", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("导出失败！", "数据导出", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出失败！", "数据导出", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.OutputShapeFile", "OutputData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

