namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    public class GPSImport
    {
        private IPolyline CreatePolyline(List<IPoint> arrPoint)
        {
            try
            {
                object missing = System.Type.Missing;
                IPolyline polyline = new PolylineClass();
                IPointCollection points = polyline as IPointCollection;
                for (int i = 0; i < arrPoint.Count; i++)
                {
                    points.AddPoint(arrPoint[i], ref missing, ref missing);
                }
                points.AddPoint(arrPoint[0], ref missing, ref missing);
                return polyline;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        internal ILayer LoadTextFile(string fileName)
        {
            IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
            CreateShapeFile file = new CreateShapeFile(factory.OpenFromFile(System.IO.Path.GetTempPath(), 0));
            IPolyline geoType = new PolylineClass();
            file.AddShapeField("shape", geoType);
            string fieldtype = "";
            file.AddField("name", fieldtype);
            IFeatureLayer layer = new FeatureLayerClass();
            layer.FeatureClass = file.CreateFeatureClass("gps");
            List<string> name = new List<string>();
            List<IPolyline> arrPolyline = this.ReadTextToPolyline(fileName, ref name);
            file.AddFeatures(arrPolyline, name);
            layer.Name = "gps";
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
            layer3.Name = "红线图_" + name;
            return layer3;
        }

        public ILayer OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本文件(*.txt)|*.txt";
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
            return this.LoadTextFile(fileName);
        }

        private List<IPolyline> ReadTextToPolyline(string fileName, ref List<string> name)
        {
            IPolyline polyline;
            if (!File.Exists(fileName))
            {
                MessageBox.Show("文件不存在！", "出错");
                return null;
            }
            List<IPolyline> list = new List<IPolyline>();
            List<IPoint> arrPoint = new List<IPoint>();
            StreamReader reader = new StreamReader(fileName);
            string item = string.Empty;
            while ((item = reader.ReadLine()) != null)
            {
                item = item.ToLower();
                if (item.StartsWith("polyline"))
                {
                    name.Add(item);
                    if (arrPoint.Count != 0)
                    {
                        polyline = this.CreatePolyline(arrPoint);
                        list.Add(polyline);
                        arrPoint.Clear();
                    }
                }
                else
                {
                    try
                    {
                        string[] strArray = item.Split(new char[] { ',' });
                        IPoint point = new PointClass();
                        point.X = Convert.ToDouble(strArray[0]);
                        point.Y = Convert.ToDouble(strArray[1]);
                        arrPoint.Add(point);
                    }
                    catch
                    {
                    }
                }
            }
            if (arrPoint.Count != 0)
            {
                polyline = this.CreatePolyline(arrPoint);
                list.Add(polyline);
                arrPoint.Clear();
            }
            return list;
        }
    }
}

