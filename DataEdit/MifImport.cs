namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class MifImport
    {
        internal ILayer LoadMifFile(string fileName)
        {
            MifToShapeFile file = new MifToShapeFile(fileName);
            string saveName = file.saveName;
            string str2 = Path.GetFileName(fileName);
            string name = str2.Substring(0, str2.Length - 4) + ".shp";
            IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
            IFeatureClass class2 = ((IFeatureWorkspace) factory.OpenFromFile(saveName, 0)).OpenFeatureClass(name);
            IFeatureLayer layer = new FeatureLayerClass();
            layer.FeatureClass = class2;
            IGeoFeatureLayer layer2 = (IGeoFeatureLayer) layer;
            ISimpleLineSymbol symbol = new SimpleLineSymbolClass();
            IRgbColor color = new RgbColorClass();
            color.Red = 0xff;
            symbol.Color = color;
            symbol.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol.Width = 1.0;
            ISimpleRenderer renderer = new SimpleRendererClass();
            renderer.Symbol = (ISymbol) symbol;
            layer2.Renderer = (IFeatureRenderer) renderer;
            ILayer layer3 = layer;
            layer3.Name = str2;
            return layer3;
        }

        public ILayer OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MapInfo文件(*.Mif)|*.mif";
            dialog.Title = "打开文件";
            string fileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if (fileName.Length == 0)
            {
                return null;
            }
            return this.LoadMifFile(fileName);
        }
    }
}

