namespace DataEdit
{
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    internal class MifToShapeFile
    {
        private bool bPoint;
        private bool bPolygon;
        private bool bPolyline;
        private bool bText;
        private string fileName;
        private int mid;
        private StreamReader midSr;
        private IFields pFields;
        private IGeometry pGeometry;
        private string pointName;
        private int pointRowID;
        private string polygonName;
        private int polygonRowID;
        private string polylineName;
        private int polylineRowID;
        private esriGeometryType pShapeType;
        public string saveName;
        private StreamReader sr;
        private double textAngle;
        private string textName;
        private int textRowID;
        private double textSize;
        private string textTitle;

        public MifToShapeFile(string sFileName)
        {
            this.fileName = string.Empty;
            this.saveName = string.Empty;
            this.bPoint = false;
            this.bPolyline = false;
            this.bPolygon = false;
            this.bText = false;
            this.pointName = "point";
            this.polylineName = "polyline";
            this.polygonName = "polygon";
            this.textName = "Anno";
            this.textAngle = 0.0;
            this.textSize = 0.0;
            this.textTitle = string.Empty;
            this.pointRowID = 0;
            this.polylineRowID = 0;
            this.polygonRowID = 0;
            this.textRowID = 0;
            this.mid = 0;
            this.fileName = sFileName;
            this.saveName = System.IO.Path.GetTempPath();
            this.MifConvertToShapeFile();
        }

        public MifToShapeFile(string sFileName, string sSaveName)
        {
            this.fileName = string.Empty;
            this.saveName = string.Empty;
            this.bPoint = false;
            this.bPolyline = false;
            this.bPolygon = false;
            this.bText = false;
            this.pointName = "point";
            this.polylineName = "polyline";
            this.polygonName = "polygon";
            this.textName = "Anno";
            this.textAngle = 0.0;
            this.textSize = 0.0;
            this.textTitle = string.Empty;
            this.pointRowID = 0;
            this.polylineRowID = 0;
            this.polygonRowID = 0;
            this.textRowID = 0;
            this.mid = 0;
            this.fileName = sFileName;
            this.saveName = sSaveName;
            this.MifConvertToShapeFile();
        }

        public IFeature AddFeature(IGeometry shape, IFeatureClass featureClass)
        {
            IFeature feature = featureClass.CreateFeature();
            if (feature != null)
            {
                feature.Shape = shape;
                feature.Store();
            }
            return feature;
        }

        public void AddNewField(IFeatureClass featureClass, string fieldName, esriFieldType fieldType, long fieldLength, bool isNull, ref IField field)
        {
            IFields fields = featureClass.Fields;
            fieldName = fieldName.ToUpper();
            if (fieldName == "ID")
            {
                fieldName = "ID2";
            }
            if ((this.fileName == "FID") || (fieldName == "SHAPE"))
            {
                MessageBox.Show("不能添加FID和SHAPE等系统关键字段");
            }
            else
            {
                IField field2;
                if (fields.FindField(fieldName) < 0)
                {
                    field2 = new FieldClass();
                }
                else
                {
                    return;
                }
                IFieldEdit edit = (IFieldEdit) field2;
                edit.IsNullable_2 = isNull;
                edit.Length_2 = (int)fieldLength;
                edit.Name_2 = fieldName;
                edit.Type_2 = fieldType;
                field = field2;
                try
                {
                    featureClass.AddField(field2);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private IPolygon CreatePolygonByPoints(ISet pointSet)
        {
            IPolygon polygon = new PolygonClass();
            IPointCollection points = (IPointCollection) polygon;
            object missing = System.Type.Missing;
            pointSet.Reset();
            for (int i = 0; i < pointSet.Count; i++)
            {
                IPoint inPoint = (IPoint) pointSet.Next();
                if (inPoint != null)
                {
                    points.AddPoint(inPoint, ref missing, ref missing);
                }
            }
            return polygon;
        }

        public IFeatureClass CreateShapeFile(string FullName, esriGeometryType shapeType)
        {
            int length = FullName.LastIndexOf(@"\");
            string fileName = FullName.Substring(0, length);
            string name = FullName.Substring(length + 1, (FullName.Length - length) - 1);
            FileInfo info = new FileInfo(fileName + @"\" + name);
            if (info.Exists)
            {
                info.Delete();
            }
            info = new FileInfo(fileName + @"\" + name.Substring(0, name.Length - 3) + "shx");
            if (info.Exists)
            {
                info.Delete();
            }
            info = new FileInfo(fileName + @"\" + name.Substring(0, name.Length - 3) + "dbf");
            if (info.Exists)
            {
                info.Delete();
            }
            IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace workspace2 = factory.OpenFromFile(fileName, 0) as IFeatureWorkspace;
            IFields fields = new FieldsClass();
            IField field = new FieldClass();
            IFieldsEdit edit = fields as IFieldsEdit;
            IFieldEdit edit2 = field as IFieldEdit;
            IGeometryDef def = new GeometryDefClass();
            IGeometryDefEdit edit3 = def as IGeometryDefEdit;
            ISpatialReferenceFactory2 factory2 = new SpatialReferenceEnvironmentClass();
            IGeographicCoordinateSystem system = factory2.CreateGeographicCoordinateSystem(0x1202);
            edit3.SpatialReference_2 = system;
            edit3.GeometryType_2 = shapeType;
            edit2.Name_2 = "shape";
            edit2.Type_2 = esriFieldType.esriFieldTypeGeometry;
            edit2.GeometryDef_2 = def;
            edit.AddField(field);
            return workspace2.CreateFeatureClass(name, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
        }

        public void DeleteField(IFeatureClass featureClass, string fieldName)
        {
            IFields fields = featureClass.Fields;
            int index = fields.FindField(fieldName);
            if (index != -1)
            {
                IField field = fields.get_Field(index);
                ((IFieldsEdit) fields).DeleteField(field);
            }
            else
            {
                MessageBox.Show("不存要删除的字段");
            }
        }

        private void GetShapeFromMIF(ref IGeometry shape)
        {
            string str3;
            string str4;
            int index;
            double num2;
            double num3;
            string str = this.sr.ReadLine();
            while ((str == null) || (str.Length == 0))
            {
                if (!this.sr.EndOfStream)
                {
                    str = this.sr.ReadLine();
                }
                else
                {
                    shape = null;
                    return;
                }
            }
            while (str.Substring(0, 1) == " ")
            {
                str = str.Substring(0, str.Length - 1);
            }
            str = str.ToLower();
            if (str.Length < 4)
            {
                str = this.sr.ReadLine();
            }
            string str2 = str.Substring(0, 4);
            if ((str2 == "poin") && !this.sr.EndOfStream)
            {
                str3 = string.Empty;
                str4 = string.Empty;
                string str5 = string.Empty;
                index = str.IndexOf(" ");
                str5 = str.Substring(index + 1, (str.Length - index) - 1);
                index = str5.IndexOf(" ");
                str3 = str5.Substring(0, index);
                str4 = str5.Substring(index + 1, (str5.Length - index) - 1);
                num2 = Convert.ToDouble(str3);
                num3 = Convert.ToDouble(str4);
                IPoint point = new PointClass();
                point.PutCoords(num2, num3);
                shape = point;
            }
            else
            {
                IPointCollection points;
                object missing;
                string str6;
                int num4;
                double num5;
                double num6;
                double num7;
                double num8;
                if (str2 == "line")
                {
                    points = new PolylineClass();
                    IPoint inPoint = new PointClass();
                    IPoint point3 = new PointClass();
                    missing = System.Type.Missing;
                    str6 = string.Empty;
                    string str7 = string.Empty;
                    string str8 = string.Empty;
                    string str9 = string.Empty;
                    string str10 = string.Empty;
                    str6 = str;
                    num4 = str.IndexOf(" ");
                    str6 = str.Substring(num4 + 1, (str.Length - num4) - 1);
                    num4 = str6.IndexOf(" ");
                    str7 = str6.Substring(0, num4);
                    str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                    num4 = str6.IndexOf(" ");
                    str8 = str6.Substring(0, num4);
                    str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                    num4 = str6.IndexOf(" ");
                    str9 = str6.Substring(0, num4);
                    str10 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                    num5 = Convert.ToDouble(str7);
                    num6 = Convert.ToDouble(str8);
                    num7 = Convert.ToDouble(str9);
                    num8 = Convert.ToDouble(str10);
                    inPoint.PutCoords(num5, num6);
                    point3.PutCoords(num7, num8);
                    points.AddPoint(inPoint, ref missing, ref missing);
                    points.AddPoint(point3, ref missing, ref missing);
                    shape = (IGeometry) points;
                }
                else
                {
                    int num10;
                    int num12;
                    IPoint point4;
                    string str12;
                    IGeometryCollection geometrys;
                    IPointCollection points2;
                    IPoint point5;
                    IPoint point6;
                    IPoint point7;
                    IPoint point8;
                    string str14;
                    string str15;
                    string str16;
                    string str17;
                    double num20;
                    ICurve curve;
                    double num21;
                    IPointCollection points3;
                    IEllipticArc arc3;
                    IConstructEllipticArc arc4;
                    IPoint point15;
                    if (str2 == "plin")
                    {
                        short num11;
                        str6 = str;
                        int num9 = str6.IndexOf(" ");
                        num10 = str6.LastIndexOf(" ");
                        if (num9 == num10)
                        {
                            num11 = Convert.ToInt16(str.Substring(num9 + 1, (str.Length - num9) - 1));
                            points = new PolylineClass();
                            missing = System.Type.Missing;
                            for (num12 = 0; num12 < num11; num12++)
                            {
                                point4 = new PointClass();
                                str3 = string.Empty;
                                str4 = string.Empty;
                                str12 = this.sr.ReadLine();
                                index = str12.IndexOf(" ");
                                str3 = str12.Substring(0, index);
                                str4 = str12.Substring(index, str12.Length - index);
                                num2 = Convert.ToDouble(str3);
                                num3 = Convert.ToDouble(str4);
                                point4.PutCoords(num2, num3);
                                points.AddPoint(point4, ref missing, ref missing);
                            }
                            shape = points as IGeometry;
                            return;
                        }
                        num11 = Convert.ToInt16(str.Substring(num10 + 1, (str.Length - num10) - 1));
                        geometrys = new PolylineClass();
                        missing = System.Type.Missing;
                        for (num12 = 0; num12 < num11; num12++)
                        {
                            points2 = new PolylineClass();
                            str = this.sr.ReadLine();
                            while (str.Substring(0, 1) == " ")
                            {
                                str = str.Substring(1, str.Length - 1);
                            }
                            num4 = Convert.ToInt32(str);
                            for (int i = 0; i < num4; i++)
                            {
                                point4 = new PointClass();
                                str3 = string.Empty;
                                str4 = string.Empty;
                                str12 = this.sr.ReadLine();
                                index = str12.IndexOf(" ");
                                str3 = str12.Substring(0, index);
                                str4 = str12.Substring(index, str12.Length - index);
                                num2 = Convert.ToDouble(str3);
                                num3 = Convert.ToDouble(str4);
                                point4.PutCoords(num2, num3);
                                points2.AddPoint(point4, ref missing, ref missing);
                            }
                            geometrys.AddGeometryCollection((IGeometryCollection) points2);
                            if (num12 == (num11 - 1))
                            {
                                shape = (IGeometry) geometrys;
                                return;
                            }
                        }
                    }
                    switch (str2)
                    {
                        case "arc ":
                        {
                            IPolyline polyline = new PolylineClass();
                            IGeometryCollection geometrys2 = (IGeometryCollection) polyline;
                            ISegmentCollection segments = new PolylineClass();
                            points2 = new PolylineClass();
                            IConstructEllipticArc arc = new EllipticArcClass();
                            IEllipticArc arc2 = new EllipticArcClass();
                            point5 = new PointClass();
                            point6 = new PointClass();
                            point7 = new PointClass();
                            point8 = new PointClass();
                            missing = System.Type.Missing;
                            str6 = str;
                            num4 = str6.IndexOf(" ");
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str14 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str15 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str16 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str17 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            string str18 = str6.Substring(0, num4);
                            string str19 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num5 = Convert.ToDouble(str14);
                            num6 = Convert.ToDouble(str15);
                            num7 = Convert.ToDouble(str16);
                            num8 = Convert.ToDouble(str17);
                            double num14 = Convert.ToDouble(str18);
                            double num15 = Convert.ToDouble(str19);
                            double num16 = Math.Max(num5, num7);
                            double num17 = Math.Min(num5, num7);
                            double num18 = Math.Max(num6, num8);
                            double num19 = Math.Max(num6, num8);
                            IPoint fromPoint = new PointClass();
                            IPoint toPoint = new PointClass();
                            switch (num14.ToString())
                            {
                                case "90.0":
                                    fromPoint.PutCoords((num5 + num7) / 2.0, num8);
                                    toPoint.PutCoords(num5, (num6 + num8) / 2.0);
                                    break;

                                case "0.0":
                                    fromPoint.PutCoords(num7, (num6 + num8) / 2.0);
                                    toPoint.PutCoords((num5 + num7) / 2.0, num8);
                                    break;

                                case "180.0":
                                    fromPoint.PutCoords(num7, (num6 + num8) / 2.0);
                                    toPoint.PutCoords((num5 + num7) / 2.0, num8);
                                    break;

                                case "270.0":
                                    fromPoint.PutCoords((num5 + num7) / 2.0, num6);
                                    toPoint.PutCoords(num7, (num6 + num8) / 2.0);
                                    break;
                            }
                            if ((fromPoint == null) || (toPoint == null))
                            {
                                MessageBox.Show("空点");
                            }
                            arc.ConstructQuarterEllipse(fromPoint, toPoint, true);
                            arc2 = (IEllipticArc) arc;
                            num10 = 30;
                            num20 = arc2.Length / 30.0;
                            curve = arc2;
                            num21 = 0.0;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point8);
                                points2.AddPoint(point8, ref missing, ref missing);
                            }
                            polyline = (IPolyline) points2;
                            shape = polyline;
                            return;
                        }
                        case "regi":
                        {
                            num4 = str.LastIndexOf(" ");
                            int num22 = Convert.ToInt32(str.Substring(num4 + 1, (str.Length - num4) - 1));
                            PolygonClass class2 = new PolygonClass();
                            geometrys = class2;
                            missing = System.Type.Missing;
                            for (num12 = 0; num12 < num22; num12++)
                            {
                                points3 = new RingClass();
                                str = this.sr.ReadLine();
                                while ((str.Length == 0) || (str == null))
                                {
                                    str = this.sr.ReadLine();
                                }
                                if (str.Length > 0)
                                {
                                    while (str.Substring(0, 1) == " ")
                                    {
                                        str = str.Substring(1, str.Length - 1);
                                    }
                                }
                                num10 = Convert.ToInt32(str);
                                for (int j = 0; j < num10; j++)
                                {
                                    point4 = new PointClass();
                                    str3 = string.Empty;
                                    str4 = string.Empty;
                                    str12 = this.sr.ReadLine();
                                    index = str12.IndexOf(" ");
                                    str3 = str12.Substring(0, index);
                                    str4 = str12.Substring(index, str12.Length - index);
                                    num2 = Convert.ToDouble(str3);
                                    num3 = Convert.ToDouble(str4);
                                    point4.PutCoords(num2, num3);
                                    points3.AddPoint(point4, ref missing, ref missing);
                                }
                                geometrys.AddGeometry((IGeometry) points3, ref missing, ref missing);
                            }
                            shape = class2;
                            return;
                        }
                        case "rect":
                        {
                            IPolygon polygon = new PolygonClass();
                            geometrys = (IGeometryCollection) polygon;
                            missing = System.Type.Missing;
                            points3 = new RingClass();
                            point5 = new PointClass();
                            point6 = new PointClass();
                            point7 = new PointClass();
                            point8 = new PointClass();
                            str6 = str;
                            num4 = str6.IndexOf(" ");
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str14 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str15 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str16 = str6.Substring(0, num4);
                            str17 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num5 = Convert.ToDouble(str14);
                            num6 = Convert.ToDouble(str15);
                            num7 = Convert.ToDouble(str16);
                            num8 = Convert.ToDouble(str17);
                            point5.PutCoords(num5, num6);
                            point6.PutCoords(num5, num8);
                            point7.PutCoords(num7, num8);
                            point8.PutCoords(num7, num6);
                            points3.AddPoint(point5, ref missing, ref missing);
                            points3.AddPoint(point6, ref missing, ref missing);
                            points3.AddPoint(point7, ref missing, ref missing);
                            points3.AddPoint(point8, ref missing, ref missing);
                            geometrys.AddGeometry((IGeometry) points3, ref missing, ref missing);
                            shape = polygon;
                            return;
                        }
                        case "roun":
                        {
                            points2 = new PolygonClass();
                            arc3 = new EllipticArcClass();
                            arc4 = (IConstructEllipticArc) arc3;
                            str6 = str;
                            num4 = str6.IndexOf(" ");
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str14 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str15 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str16 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str17 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            string str21 = str6.Substring(0, num4);
                            num5 = Convert.ToDouble(str14);
                            num6 = Convert.ToDouble(str15);
                            num7 = Convert.ToDouble(str16);
                            num8 = Convert.ToDouble(str17);
                            double num24 = Convert.ToDouble(str21);
                            num24 = 0.47652937538651 * num24;
                            point5 = new PointClass();
                            point6 = new PointClass();
                            point7 = new PointClass();
                            point8 = new PointClass();
                            IPoint point11 = new PointClass();
                            IPoint point12 = new PointClass();
                            IPoint point13 = new PointClass();
                            IPoint point14 = new PointClass();
                            point15 = new PointClass();
                            point5.PutCoords(num5 + num24, num8);
                            point6.PutCoords(num5, num8 - num24);
                            point7.PutCoords(num5, num6 + num24);
                            point8.PutCoords(num5 + num24, num6);
                            point11.PutCoords(num7 - num24, num6);
                            point12.PutCoords(num7, num6 + num24);
                            point13.PutCoords(num7, num8 - num24);
                            point14.PutCoords(num7 - num24, num8);
                            IPoint point16 = new PointClass();
                            IPoint point17 = new PointClass();
                            IPoint point18 = new PointClass();
                            IPoint point19 = new PointClass();
                            if (Math.Abs((double) (num5 - num7)) <= (2.0 * num24))
                            {
                                point5.PutCoords((num5 + num7) / 2.0, num8);
                                point14.PutCoords((num5 + num7) / 2.0, num8);
                                point8.PutCoords((num5 + num7) / 2.0, num6);
                                point11.PutCoords((num5 + num7) / 2.0, num6);
                            }
                            if (Math.Abs((double) (num6 - num8)) <= (2.0 * num24))
                            {
                                point6.PutCoords(num5, (num6 + num8) / 2.0);
                                point7.PutCoords(num5, (num6 + num8) / 2.0);
                                point12.PutCoords(num7, (num6 + num8) / 2.0);
                                point13.PutCoords(num7, (num6 + num8) / 2.0);
                            }
                            missing = System.Type.Missing;
                            arc4.ConstructQuarterEllipse(point5, point6, true);
                            curve = arc3;
                            num10 = 30;
                            num20 = arc3.Length / 30.0;
                            num21 = 0.0;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            points2.AddPoint(point6, ref missing, ref missing);
                            points2.AddPoint(point7, ref missing, ref missing);
                            arc4.ConstructQuarterEllipse(point7, point8, true);
                            num21 = 0.0;
                            curve = (ICurve) arc4;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            points2.AddPoint(point8, ref missing, ref missing);
                            points2.AddPoint(point11, ref missing, ref missing);
                            arc4.ConstructQuarterEllipse(point11, point12, true);
                            num21 = 0.0;
                            curve = (ICurve) arc4;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            points2.AddPoint(point12, ref missing, ref missing);
                            points2.AddPoint(point13, ref missing, ref missing);
                            arc4.ConstructQuarterEllipse(point13, point14, true);
                            num21 = 0.0;
                            curve = (ICurve) arc4;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            points2.AddPoint(point14, ref missing, ref missing);
                            points2.AddPoint(point5, ref missing, ref missing);
                            shape = (IPolygon) points2;
                            return;
                        }
                        case "elli":
                            str6 = str;
                            num4 = str6.IndexOf(" ");
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str14 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str15 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str16 = str6.Substring(0, num4);
                            str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            num4 = str6.IndexOf(" ");
                            str17 = str6;
                            num5 = Convert.ToDouble(str14);
                            num6 = Convert.ToDouble(str15);
                            num7 = Convert.ToDouble(str16);
                            num8 = Convert.ToDouble(str17);
                            point5 = new PointClass();
                            point6 = new PointClass();
                            point7 = new PointClass();
                            point8 = new PointClass();
                            point15 = new PointClass();
                            missing = System.Type.Missing;
                            point5.PutCoords(num5 + num7, num8);
                            point6.PutCoords(num5, (num6 + num8) / 2.0);
                            point7.PutCoords((num5 + num7) / 2.0, num6);
                            point8.PutCoords(num7, (num6 + num8) / 2.0);
                            arc4 = new EllipticArcClass();
                            points2 = new PolygonClass();
                            arc4.ConstructQuarterEllipse(point5, point6, true);
                            arc3 = (IEllipticArc) arc4;
                            num20 = arc3.Length / 30.0;
                            num10 = 30;
                            num21 = 0.0;
                            curve = arc3;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            arc4.ConstructQuarterEllipse(point6, point7, true);
                            num21 = 0.0;
                            curve = arc3;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            arc4.ConstructQuarterEllipse(point7, point8, true);
                            num21 = 0.0;
                            curve = arc3;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            arc4.ConstructQuarterEllipse(point8, point5, true);
                            num21 = 0.0;
                            curve = arc3;
                            for (num12 = 0; num12 < num10; num12++)
                            {
                                num21 += num20;
                                curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num21, false, point15);
                                points2.AddPoint(point15, ref missing, ref missing);
                            }
                            shape = (IPolygon) points2;
                            return;

                        case "text":
                        {
                            this.bText = true;
                            str6 = str;
                            str6 = this.sr.ReadLine();
                            while (str6.Substring(0, 1) == " ")
                            {
                                str6 = str6.Substring(1, str6.Length - 1);
                            }
                            string str22 = str6;
                            str6 = this.sr.ReadLine();
                            while (str6.Substring(0, 1) == " ")
                            {
                                str6 = str6.Substring(1, str6.Length - 1);
                            }
                            string[] strArray = new string[4];
                            for (num12 = 0; num12 < 3; num12++)
                            {
                                num4 = str6.IndexOf(" ");
                                strArray[num12] = str6.Substring(0, num4);
                                str6 = str6.Substring(num4 + 1, (str6.Length - num4) - 1);
                            }
                            strArray[3] = str6;
                            double[] numArray = new double[4];
                            for (num12 = 0; num12 < 4; num12++)
                            {
                                numArray[num12] = Convert.ToDouble(strArray[num12]);
                            }
                            point4 = new PointClass();
                            point4.PutCoords((numArray[0] + numArray[2]) / 2.0, (numArray[1] + numArray[3]) / 2.0);
                            shape = point4;
                            str6 = this.sr.ReadLine();
                            double num25 = Math.Abs((double) (numArray[0] - numArray[2])) * Math.Abs((double) (numArray[1] - numArray[3]));
                            double num26 = 0.0;
                            while (str6.Length != 0)
                            {
                                while (str6.Substring(0, 1) == " ")
                                {
                                    str6 = str6.Substring(1, str6.Length - 1);
                                }
                                if (str6.Length > 4)
                                {
                                    string str23 = str6.Substring(0, 4).ToUpper();
                                    if (str23 == "ANGE")
                                    {
                                        num4 = str23.IndexOf(" ");
                                        num26 = Convert.ToDouble(str23.Substring(num4 + 1, (str23.Length - num4) - 1));
                                    }
                                }
                                str6 = this.sr.ReadLine();
                            }
                            this.textTitle = str22;
                            this.textAngle = num26;
                            this.textSize = num25;
                            return;
                        }
                    }
                    this.GetShapeFromMIF(ref shape);
                }
            }
        }

        private void MifConvertToShapeFile()
        {
            IFeatureClass featureClass = null;
            IFeatureClass class3 = null;
            IFeatureClass class4 = null;
            IFeatureClass class5 = null;
            IFeatureClass class6 = null;
            this.sr = new StreamReader(this.fileName, Encoding.GetEncoding("gb2312"));
            this.ReadMifHeadFile(ref this.pShapeType, ref this.pFields);
            if ((this.fileName.Length != 0) && (this.fileName != null))
            {
                int num2;
                int num3;
                IField field2;
                string fileName = this.fileName;
                if (this.saveName.Length != 0)
                {
                    fileName = this.saveName + @"\";
                }
                else
                {
                    int length = fileName.LastIndexOf(@"\");
                    fileName = fileName.Substring(0, length);
                }
                if (this.bPoint)
                {
                    num2 = this.pointName.LastIndexOf(@"\");
                    this.pointName = this.pointName.Substring(num2 + 1, (this.pointName.Length - num2) - 1);
                    this.pointName = fileName + this.pointName + ".shp";
                    class3 = this.CreateShapeFile(this.pointName, esriGeometryType.esriGeometryPoint);
                }
                if (this.bPolyline)
                {
                    num2 = this.polylineName.LastIndexOf(@"\");
                    this.polylineName = this.polylineName.Substring(num2 + 1, (this.polylineName.Length - num2) - 1);
                    this.polylineName = fileName + this.polylineName + ".shp";
                    class4 = this.CreateShapeFile(this.polylineName, esriGeometryType.esriGeometryPolyline);
                }
                if (this.bPolygon)
                {
                    num2 = this.polygonName.LastIndexOf(@"\");
                    this.polygonName = this.polygonName.Substring(num2 + 1, (this.polygonName.Length - num2) - 1);
                    this.polygonName = fileName + this.polygonName + ".shp";
                    class5 = this.CreateShapeFile(this.polygonName, esriGeometryType.esriGeometryPolygon);
                }
                if (this.bText)
                {
                    num2 = this.textName.LastIndexOf(@"\");
                    this.textName = this.textName.Substring(num2 + 1, (this.textName.Length - num2) - 1);
                    this.textName = fileName + this.textName + ".shp";
                    class6 = this.CreateShapeFile(this.textName, esriGeometryType.esriGeometryPoint);
                }
                this.sr.Dispose();
                IField field = null;
                if (this.bText)
                {
                    this.bText = false;
                    featureClass = class6;
                    for (num3 = 0; num3 < this.pFields.FieldCount; num3++)
                    {
                        field2 = this.pFields.get_Field(num3);
                        this.AddNewField(featureClass, field2.Name, field2.Type, (long) field2.Length, field2.IsNullable, ref field);
                    }
                    this.AddNewField(featureClass, "Text_String", esriFieldType.esriFieldTypeString, 8L, false, ref field);
                    this.AddNewField(featureClass, "Text_Angel", esriFieldType.esriFieldTypeDouble, 0x10L, false, ref field);
                    this.AddNewField(featureClass, "Text_String", esriFieldType.esriFieldTypeDouble, 0x10L, false, ref field);
                }
                if (this.bPoint)
                {
                    featureClass = class3;
                    for (num3 = 0; num3 < this.pFields.FieldCount; num3++)
                    {
                        field2 = this.pFields.get_Field(num3);
                        this.AddNewField(featureClass, field2.Name, field2.Type, (long) field2.Length, field2.IsNullable, ref field);
                    }
                }
                if (this.bPolyline)
                {
                    featureClass = class4;
                    for (num3 = 0; num3 < this.pFields.FieldCount; num3++)
                    {
                        field2 = this.pFields.get_Field(num3);
                        this.AddNewField(featureClass, field2.Name, field2.Type, (long) field2.Length, field2.IsNullable, ref field);
                    }
                }
                if (this.bPolygon)
                {
                    featureClass = class5;
                    for (num3 = 0; num3 < this.pFields.FieldCount; num3++)
                    {
                        field2 = this.pFields.get_Field(num3);
                        this.AddNewField(featureClass, field2.Name, field2.Type, (long) field2.Length, field2.IsNullable, ref field);
                    }
                }
                IFeature feature = null;
                this.sr = new StreamReader(this.fileName, Encoding.GetEncoding("gb2312"));
                string str2 = string.Empty;
                bool flag = false;
                while (!this.sr.EndOfStream && !flag)
                {
                    str2 = this.sr.ReadLine().ToLower();
                    if (str2 == "data")
                    {
                        flag = true;
                    }
                }
                if (str2 == "Data")
                {
                    str2 = this.sr.ReadLine();
                }
                if (!this.sr.EndOfStream)
                {
                    IDataset dataset = (IDataset) featureClass;
                    IWorkspaceEdit workspace = (IWorkspaceEdit) dataset.Workspace;
                    workspace.StartEditOperation();
                    workspace.StopEditing(true);
                    workspace.StartEditing(true);
                    workspace.StartEditOperation();
                    IRow row = null;
                    string str3 = this.fileName;
                    str3 = str3.Substring(0, str3.Length - 4) + ".mid";
                    FileInfo info = new FileInfo(str3);
                    if (!info.Exists)
                    {
                        MessageBox.Show("文件夹中找不到.mid文件，转换失败！");
                        return;
                    }
                    this.midSr = new StreamReader(str3, Encoding.GetEncoding("gb2312"));
                    this.pointRowID = 0;
                    this.polylineRowID = 0;
                    this.polygonRowID = 0;
                    this.textRowID = 0;
                    while (!this.sr.EndOfStream && !this.midSr.EndOfStream)
                    {
                        this.GetShapeFromMIF(ref this.pGeometry);
                        if (this.pGeometry != null)
                        {
                            int rowID = 0;
                            if (this.pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                            {
                            }
                            if (!this.bText)
                            {
                                featureClass = class3;
                                this.pointRowID++;
                                rowID = this.pointRowID;
                            }
                            else
                            {
                                featureClass = class6;
                                this.textRowID++;
                                rowID = this.textRowID;
                            }
                            if (this.pGeometry.GeometryType == esriGeometryType.esriGeometryPolyline)
                            {
                                featureClass = class4;
                                this.polylineRowID++;
                                rowID = this.polylineRowID;
                            }
                            if (this.pGeometry.GeometryType == esriGeometryType.esriGeometryPolygon)
                            {
                                featureClass = class5;
                                this.polygonRowID++;
                                rowID = this.polygonRowID;
                            }
                            feature = this.AddFeature(this.pGeometry, featureClass);
                            this.ReadRowFromMif(row, featureClass, rowID);
                        }
                    }
                    workspace.StopEditOperation();
                    workspace.StopEditing(true);
                }
                this.sr.Dispose();
                this.bText = false;
                this.bPoint = false;
                this.bPolyline = false;
                this.bPolygon = false;
            }
        }

        private void ReadMifHeadFile(ref esriGeometryType shapeType, ref IFields fields)
        {
            short num = 0;
            string str2 = string.Empty;
            string str3 = string.Empty;
            int startIndex = 0;
            if (this.fileName != string.Empty)
            {
                while (!this.sr.EndOfStream)
                {
                    str3 = string.Empty;
                    str2 = this.sr.ReadLine();
                    while (str2.Substring(0, 1) == " ")
                    {
                        str2 = str2.Substring(1, str2.Length - 1);
                    }
                    if (str2.Length >= 4)
                    {
                        str3 = str2.Substring(0, 4);
                    }
                    str3 = str3.ToLower();
                    switch (str3)
                    {
                        case "vers":
                            startIndex = str2.IndexOf(" ");
                            num = Convert.ToInt16(str2.Substring(startIndex, str2.Length - startIndex));
                            break;

                        case "coor":
                        {
                            startIndex = str2.IndexOf(" ");
                            string str = str2.Substring(startIndex, str2.Length - startIndex);
                            break;
                        }
                        case "colu":
                        {
                            IFields fields2 = new FieldsClass();
                            IFieldsEdit edit = fields2 as IFieldsEdit;
                            startIndex = str2.IndexOf(" ");
                            short num3 = Convert.ToInt16(str2.Substring(startIndex, str2.Length - startIndex));
                            for (int i = 0; i < num3; i++)
                            {
                                IField field = new FieldClass();
                                IFieldEdit edit2 = field as IFieldEdit;
                                str2 = this.sr.ReadLine();
                                while (str2.Substring(0, 1) == " ")
                                {
                                    str2 = str2.Substring(1, str2.Length - 1);
                                }
                                int length = 0;
                                length = str2.IndexOf(" ");
                                string str5 = str2.Substring(0, length);
                                string str6 = str2.Substring(length, str2.Length - length);
                                while (str6.Substring(0, 1) == " ")
                                {
                                    str6 = str6.Substring(1, str6.Length - 1);
                                }
                                switch (str6.Substring(0, 4).ToLower())
                                {
                                    case "char":
                                    {
                                        int index = str6.IndexOf("(");
                                        short num7 = Convert.ToInt16(str6.Substring(index + 1, (str6.Length - index) - 2));
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeString;
                                        edit2.Length_2 = num7 + 2;
                                        edit.AddField(field);
                                        break;
                                    }
                                    case "inte":
                                    edit2.Name_2 = str5;
                                    edit2.Type_2 = esriFieldType.esriFieldTypeInteger;
                                    edit2.Length_2 = 4;
                                        edit.AddField(field);
                                        break;

                                    case "smal":
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeSmallInteger;
                                        edit2.Length_2 = 2;
                                        edit.AddField(field);
                                        break;

                                    case "deci":
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeDouble;
                                        edit2.Length_2 = 0x10;
                                        edit.AddField(field);
                                        break;

                                    case "floa":
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeDouble;
                                        edit2.Length_2 = 6;
                                        edit.AddField(field);
                                        break;

                                    case "date":
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeDate;
                                        edit.AddField(field);
                                        break;

                                    case "logi":
                                        edit2.Name_2 = str5;
                                        edit2.Type_2 = esriFieldType.esriFieldTypeGeometry;
                                        edit.AddField(field);
                                        break;
                                }
                            }
                            fields = fields2;
                            break;
                        }
                    }
                    if (str3 == "data")
                    {
                        while (!this.sr.EndOfStream)
                        {
                            str2 = this.sr.ReadLine();
                            goto Label_0462;
                        Label_0454:
                            str2 = this.sr.ReadLine();
                        Label_0462:;
                            if (((str2.Length == 0) || (str2 == null)) && !this.sr.EndOfStream)
                            {
                                goto Label_0454;
                            }
                            while ((str2.Length > 0) && (str2.Substring(0, 1) == ""))
                            {
                                str2 = str2.Substring(1, str2.Length - 1);
                            }
                            str2 = str2.ToLower();
                            if (str2.Length >= 4)
                            {
                                switch (str2.Substring(0, 4))
                                {
                                    case "poin":
                                        this.bPoint = true;
                                        break;

                                    case "plin":
                                    case "line":
                                    case "arc ":
                                        this.bPolyline = true;
                                        break;

                                    case "regi":
                                    case "rect":
                                    case "roun":
                                    case "elli":
                                        this.bPolygon = true;
                                        break;

                                    case "text":
                                        this.bText = true;
                                        break;
                                }
                            }
                        }
                        string str9 = this.fileName.Substring(0, this.fileName.Length - 4);
                        this.pointName = this.pointName + str9;
                        this.polylineName = this.polylineName + str9;
                        this.polygonName = this.polygonName + str9;
                        this.textName = this.textName + str9;
                    }
                }
            }
        }

        private void ReadRowFromMif(IRow row, IFeatureClass featureClass, int rowID)
        {
            ITable table = (ITable) featureClass;
            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor cursor = table.Search(queryFilter, false);
            for (int i = 0; i < rowID; i++)
            {
                row = cursor.NextRow();
            }
            if (!this.midSr.EndOfStream)
            {
                string str = this.midSr.ReadLine();
                if (str.Length > 0)
                {
                    while (str.Substring(0, 1) == " ")
                    {
                        str = str.Substring(1, str.Length - 1);
                        if (!((str.Length != 0) || this.midSr.EndOfStream))
                        {
                            str = this.midSr.ReadLine();
                        }
                        if (this.midSr.EndOfStream)
                        {
                            return;
                        }
                    }
                }
                int index = 3;
                while (str.Length > 0)
                {
                    int length = str.IndexOf(",");
                    string str2 = "";
                    if (length >= 0)
                    {
                        str2 = str.Substring(0, length);
                        str = str.Substring(length + 1, (str.Length - length) - 1);
                    }
                    if (length < 0)
                    {
                        str2 = str;
                        str = string.Empty;
                    }
                    if (index != this.mid)
                    {
                        row.set_Value(index, str2);
                        index++;
                    }
                    else
                    {
                        int num4 = 0;
                        try
                        {
                            num4 = Convert.ToInt32(str2);
                        }
                        catch
                        {
                            row.set_Value(2, 0);
                            continue;
                        }
                        row.set_Value(2, num4);
                    }
                }
                if (this.bText)
                {
                    row.set_Value(index, this.textTitle);
                    index++;
                    row.set_Value(index, this.textAngle);
                    index++;
                    row.set_Value(index, this.textSize);
                    this.bText = false;
                }
                row.Store();
            }
        }
    }
}

