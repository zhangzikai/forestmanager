namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Windows.Forms;

    public class DwgImport
    {
        internal ILayer LoadCADFile(string fileName)
        {
            if (fileName.Length == 0)
            {
                return null;
            }
            int length = fileName.LastIndexOf('\\');
            string str = fileName.Substring(0, length);
            string str2 = fileName.Substring(length + 1);
            IWorkspaceFactory factory = new CadWorkspaceFactoryClass();
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) factory.OpenFromFile(str, 0);
            IFeatureClass class2 = workspace2.OpenFeatureClass(str2 + ":Polygon");
            if (class2 == null)
            {
                class2 = workspace2.OpenFeatureClass(str2 + ":Polyline");
            }
            IFeatureLayer layer = new CadFeatureLayerClass();
            layer.FeatureClass = class2;
            IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
            if (class2.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.Red = 0xff;
                symbol.Color = color;
                symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                symbol.Width = 1.0;
                ISimpleRenderer renderer = new SimpleRendererClass();
                renderer.Symbol = (ISymbol) symbol;
                layer2.Renderer = (IFeatureRenderer) renderer;
            }
            else if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                IFeatureRenderer renderer2 = layer2.Renderer;
                ISimpleRenderer renderer3 = new SimpleRendererClass();
                layer2.Renderer = renderer3 as IFeatureRenderer;
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
                ISimpleRenderer renderer4 = new SimpleRendererClass();
                renderer4.Symbol = symbol2;
                layer2.Renderer = renderer4 as IFeatureRenderer;
                IFeatureRenderer renderer5 = layer2.Renderer;
                layer2.DisplayAnnotation = true;
            }
            layer.Name = str2;
            return layer;
        }

        public ILayer OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CAD文件(*.dwg)|*.dwg";
            dialog.Title = "打开CAD文件";
            string fileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if (fileName.Length == 0)
            {
                return null;
            }
            return this.LoadCADFile(fileName);
        }
    }
}

