namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Windows.Forms;
    using Utilities;

    public class RedLineImport
    {
        private const string mClassName = "DataEdit.RedLineImport";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ISpatialReference mSpatialReference;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public RedLineImport(ISpatialReference pSpatialReference)
        {
            this.mSpatialReference = pSpatialReference;
        }

        private bool CreateLayer(IFeatureWorkspace pFWorkspace, string dname, IFeatureLayer pfLayer)
        {
            try
            {
                if (pFWorkspace == null)
                {
                    return false;
                }
                IWorkspace workspace = pFWorkspace as IWorkspace;
                IFeatureDataset dataset = null;
                try
                {
                    pFWorkspace.OpenFeatureDataset(dname).Delete();
                }
                catch (Exception)
                {
                }
                dataset = pFWorkspace.CreateFeatureDataset(dname, this.mSpatialReference);
                if (dataset == null)
                {
                    return false;
                }
                IFeatureClassDescription description = new FeatureClassDescriptionClass();
                IObjectClassDescription description2 = (IObjectClassDescription) description;
                IFeatureClass class2 = dataset.CreateFeatureClass("polygon", pfLayer.FeatureClass.Fields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                IFeatureClass featureClass = pfLayer.FeatureClass;
                if (featureClass != null)
                {
                    double num;
                    double num2;
                    double num3;
                    double num4;
                    IGeoDataset dataset2 = featureClass as IGeoDataset;
                    ISpatialReference spatialReference = dataset2.SpatialReference;
                    IProjectedCoordinateSystem mSpatialReference = spatialReference as IProjectedCoordinateSystem;
                    IGeographicCoordinateSystem system2 = spatialReference as IGeographicCoordinateSystem;
                    IGeoDatasetSchemaEdit edit = (IGeoDatasetSchemaEdit) dataset2;
                    double falseEasting = 0.0;
                    double dy = 0.0;
                    mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                    system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                    falseEasting = mSpatialReference.FalseEasting;
                    dy = mSpatialReference.FalseNorthing;
                    spatialReference.GetDomain(out num, out num2, out num3, out num4);
                    if ((Math.Round(num, 0).ToString().Length + 2) == falseEasting.ToString().Length)
                    {
                        num = double.Parse(falseEasting.ToString().Substring(0, 2) + num.ToString());
                    }
                    if ((Math.Round(num2, 0).ToString().Length + 2) == falseEasting.ToString().Length)
                    {
                        num2 = double.Parse(falseEasting.ToString().Substring(0, 2) + num2.ToString());
                    }
                    (dataset as IGeoDataset).SpatialReference.SetDomain(num - 1000000.0, num2 + 1000000.0, num3 - 1000000.0, num4 + 1000000.0);
                    (class2 as IGeoDataset).SpatialReference.SetDomain(num - 1000000.0, num2 + 1000000.0, num3 - 1000000.0, num4 + 1000000.0);
                    edit = (IGeoDatasetSchemaEdit) (class2 as IGeoDataset);
                    try
                    {
                        if (edit.CanAlterSpatialReference)
                        {
                            edit.AlterSpatialReference(spatialReference);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    IWorkspaceEdit edit2 = pFWorkspace as IWorkspaceEdit;
                    if (edit2 == null)
                    {
                        return false;
                    }
                    edit2.StartEditing(false);
                    edit2.StartEditOperation();
                    IFeatureCursor cursor = featureClass.Search(null, false);
                    for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                    {
                        Application.DoEvents();
                        IFeature feature2 = class2.CreateFeature();
                        feature2 = feature;
                        ITransform2D shape = feature2.Shape as ITransform2D;
                        shape.Move(double.Parse(falseEasting.ToString().Substring(0, 2) + "000000"), dy);
                        IGeometry geometry = shape as IGeometry;
                        geometry.Project(this.mSpatialReference);
                        feature2.Shape = geometry;
                        feature2.Store();
                    }
                    try
                    {
                        edit2.StopEditOperation();
                    }
                    catch (Exception)
                    {
                        edit2.StopEditOperation();
                    }
                    edit2.StopEditing(true);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.RedLineImport", "CreateLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private IFeatureWorkspace CreateWorkspace(string sPath, string sName)
        {
            try
            {
                IWorkspaceFactory2 factory = null;
                IWorkspaceName name = null;
                if (sName.Contains(".gdb"))
                {
                    factory = new FileGDBWorkspaceFactoryClass();
                    name = factory.Create(sPath + @"\", sName, null, 0);
                }
                else if (sName.Contains(".mdb"))
                {
                    factory = new AccessWorkspaceFactoryClass();
                    name = factory.Create(sPath + @"\", sName, null, 0);
                }
                else
                {
                    factory = new FileGDBWorkspaceFactoryClass();
                    IWorkspace workspace2 = factory.OpenFromFile(sPath + @"\" + sName + ".gdb", 0);
                    if (!workspace2.Exists())
                    {
                        name = factory.Create(sPath + @"\", sName + ".gdb", null, 0);
                    }
                    else
                    {
                        return (workspace2 as IFeatureWorkspace);
                    }
                }
                IName name2 = (IName) name;
                IWorkspace workspace3 = (IWorkspace) name2.Open();
                return (workspace3 as IFeatureWorkspace);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.RedLineImport", "CreateWorkspace", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public ILayer OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CAD文件(*.dwg)|*.dwg|MapInfo文件(*.Mif)|*.mif|ShapeFile文件(*.shp)|*.shp|文本文件(*.txt)|*.txt";
            dialog.Title = "打开线状数据文件或GPS文件";
            string fileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if (fileName.Length == 0)
            {
                return null;
            }
            string str2 = fileName.Substring(fileName.LastIndexOf("."));
            ILayer layer = null;
            string str3 = str2.ToLower();
            if (str3 != null)
            {
                if (str3 != ".dwg")
                {
                    if (str3 == ".mif")
                    {
                        MifImport import2 = new MifImport();
                        return import2.LoadMifFile(fileName);
                    }
                    if (str3 == ".txt")
                    {
                        GPSImport import3 = new GPSImport();
                        return import3.LoadTextFile(fileName);
                    }
                    if (str3 == ".shp")
                    {
                        ShapeImport import4 = new ShapeImport();
                        return import4.LoadShapeFile(fileName);
                    }
                }
                else
                {
                    layer = new DwgImport().LoadCADFile(fileName);
                }
            }
            return layer;
        }
    }
}

