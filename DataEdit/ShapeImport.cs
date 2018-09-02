namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    internal class ShapeImport
    {
        private const string mClassName = "DataEdit.ShapeImport";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        internal ILayer LoadShapeFile(string fileName)
        {
            try
            {
                string str = Directory.GetParent(fileName).ToString();
                string[] strArray = fileName.Split(new char[] { '\\' });
                string name = strArray[strArray.Length - 1];
                name = name.Split(new char[] { '.' })[0];
                IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
                IWorkspace workspace = factory.OpenFromFile(str, 0);
                IFeatureLayer layer = null;
                IFeatureWorkspace workspace2 = workspace as IFeatureWorkspace;
                IDataset dataset = workspace as IDataset;
                dataset = workspace2.OpenFeatureClass(name) as IDataset;
                IFeatureClass class2 = dataset as IFeatureClass;
                if ((class2.ShapeType != esriGeometryType.esriGeometryPolyline) && (class2.ShapeType != esriGeometryType.esriGeometryPolygon))
                {
                    MessageBox.Show("选择Shapefile文件非线状或面状数据，请重新选择导入文件", "红线图导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return null;
                }
                layer = new FeatureLayerClass();
                layer.Name = name;
                layer.FeatureClass = class2;
                IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
                ISimpleRenderer renderer = new SimpleRendererClass();
                if (class2.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
                    IRgbColor color = new RgbColorClass();
                    color.Red = 0xff;
                    symbol.Color = color;
                    symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    symbol.Width = 1.0;
                    renderer.Symbol = (ISymbol) symbol;
                }
                else if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    ISymbol symbol2 = null;
                    ISimpleFillSymbol symbol3 = new SimpleFillSymbolClass();
                    ISimpleLineSymbol symbol4 = new SimpleLineSymbolClass();
                    IRgbColor color2 = new RgbColorClass();
                    color2.NullColor = true;
                    symbol3.Color = color2;
                    IRgbColor color3 = new RgbColorClass();
                    color3.Red = 0xff;
                    color3.Blue = 0;
                    color3.Green = 0;
                    symbol4.Color = color3;
                    symbol4.Width = 1.0;
                    symbol3.Outline = symbol4;
                    symbol2 = symbol3 as ISymbol;
                    renderer.Symbol = symbol2;
                }
                layer2.Renderer = (IFeatureRenderer) renderer;
                ILayer layer3 = layer;
                layer3.Name = name;
                return layer3;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.ShapeImport", "LoadShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public ILayer OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Shapefile文件(*.shp)|*.shp";
            dialog.Title = "打开Shapefile文件";
            string fileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if (fileName.Length == 0)
            {
                return null;
            }
            return this.LoadShapeFile(fileName);
        }
    }
}

