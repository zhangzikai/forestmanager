namespace Cartography.Business
{
    using Cartography.Base;
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using Utilities;

    internal class TableDrawer : IDisposable
    {
        private int _border = 1;
        private string _field;
        private int _fontSize;
        private IMap _map;
        private int _padding = 1;
        private string _sectionName;
        private TableInfo _tableInfo;
        private string _title;
        private int _titleOffsetbottom = 3;
        private int _titleOffsetTop = 3;
        private Component component = new Component();
        private bool disposed;
        private const string mClassName = "Cartography.Business.TableDrawer";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public TableDrawer(IMap pMap, TableInfo pTi)
        {
            this._title = pTi.Title;
            this._map = pMap;
            this._tableInfo = pTi;
            this._sectionName = pTi.SectionName;
            this._field = pTi.FieldName;
        }

        private DataTable CreateDataTable(string[] pFields)
        {
            try
            {
                DataTable table = new DataTable();
                table.Clear();
                DataColumn column = null;
                for (int i = 0; i < pFields.Length; i++)
                {
                    string str = pFields[i];
                    string columnName = str.Split(new char[] { ' ' })[0];
                    column = new DataColumn(columnName, typeof(string));
                    table.Columns.Add(column);
                }
                return table;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "DrawtableEx", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (!this.disposed && disposing)
            {
                this.component.Dispose();
            }
            this.disposed = true;
        }

        private void DrawCell(Graphics pGraphics, string pText, float pWidth, float pHeight, Font pFont, float pX, float pY)
        {
            Pen pen = new Pen(Color.Black);
            pGraphics.DrawLine(pen, pX, pY, pX + pWidth, pY);
            pGraphics.DrawLine(pen, pX, pY, pX, pY + pHeight);
            SizeF ef = pGraphics.MeasureString(pText, pFont);
            pGraphics.DrawString(pText, pFont, new SolidBrush(Color.Black), (float) (pX + ((pWidth - ef.Width) / 2f)), (float) (pY + ((pHeight - ef.Height) / 2f)));
        }

        public Metafile Drawtable(IEnvelope pExtent)
        {
            try
            {
                SizeF ef;
                int height = 0;
                float pCellHeight = 0f;
                string[] fields = this.GetFields();
                if (fields == null)
                {
                    return null;
                }
                Font pFont = this.GetFont();
                List<float> pCellWidth = new List<float>();
                List<ICodedValueDomain> pDomain = new List<ICodedValueDomain>();
                IQueryFilter pQf = new QueryFilterClass();
                string currentFilter = this.GetCurrentFilter(pExtent, this._tableInfo);
                if (currentFilter == "")
                {
                    XtraMessageBox.Show("没有数据！");
                    return null;
                }
                pQf.WhereClause = currentFilter;
                IDisplayTable featureLayer = this._tableInfo.FeatureLayer as IDisplayTable;
                this.GetDigtal(pFont, featureLayer, this._title, fields, out ef, pCellWidth, out pCellHeight, pDomain, pQf);
                int width = int.Parse(Math.Ceiling((double) ef.Width).ToString());
                height = int.Parse(Math.Ceiling((double) ef.Height).ToString());
                Bitmap image = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(image);
                Metafile metafile = new Metafile(graphics.GetHdc(), new Rectangle(0, 0, width, height), MetafileFrameUnit.Pixel);
                Graphics pGraphics = Graphics.FromImage(metafile);
                GraphicsUnit pixel = GraphicsUnit.Pixel;
                pGraphics.FillRectangle(new SolidBrush(Color.White), image.GetBounds(ref pixel));
                ef = pGraphics.MeasureString(this._title, pFont);
                float x = (width - ef.Width) / 2f;
                float y = this._titleOffsetTop;
                pGraphics.DrawString(this._title, pFont, new SolidBrush(Color.Black), x, y);
                x = 0f;
                y += this._titleOffsetbottom + ef.Height;
                float pX = x;
                float pY = y;
                ICursor cursor = featureLayer.SearchDisplayTable(pQf, false);
                for (int i = 0; i < fields.Length; i++)
                {
                    int index = cursor.Fields.FindField(fields[i]);
                    IField field = cursor.Fields.get_Field(index);
                    this.DrawCell(pGraphics, field.AliasName, pCellWidth[i], pCellHeight, pFont, pX, pY);
                    pX += pCellWidth[i] - this._border;
                }
                pX = 0f;
                IRow row = null;
                string str2 = "";
                while ((row = cursor.NextRow()) != null)
                {
                    pY += pCellHeight - this._border;
                    for (int j = 0; j < fields.Length; j++)
                    {
                        int num12;
                        int num11 = cursor.Fields.FindField(fields[j]);
                        str2 = row.get_Value(num11).ToString();
                        ICodedValueDomain domain = pDomain[j];
                        if (domain != null)
                        {
                            num12 = 0;
                            while (num12 < domain.CodeCount)
                            {
                                object obj2 = domain.get_Value(num12);
                                if ((obj2 != null) && obj2.ToString().Equals(str2))
                                {
                                    goto Label_029A;
                                }
                                num12++;
                            }
                        }
                        goto Label_02A5;
                    Label_029A:
                        str2 = domain.get_Name(num12);
                    Label_02A5:
                        this.DrawCell(pGraphics, str2, pCellWidth[j], pCellHeight, pFont, pX, pY);
                        pX += pCellWidth[j] - this._border;
                    }
                    pX = 0f;
                }
                pY += pCellHeight;
                pGraphics.DrawLine(new Pen(Color.Black), x, pY, (float) width, pY);
                pGraphics.DrawLine(new Pen(Color.Black), (float) width, y, (float) width, pY);
                pGraphics.Save();
                image.Dispose();
                graphics.Dispose();
                pGraphics.Dispose();
                return metafile;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "Drawtable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public Metafile DrawtableEx(IEnvelope pExtent)
        {
            try
            {
                int height = 0;
                float pCellHeight = 0f;
                string[] pFields = this.GetFields();
                if (pFields != null)
                {
                    SizeF ef;
                    Font pFont = this.GetFont();
                    List<float> pCellWidth = new List<float>();
                    new List<ICodedValueDomain>();
                    IQueryFilter filter = new QueryFilterClass();
                    string currentFilter = this.GetCurrentFilter(pExtent, this._tableInfo);
                    if (currentFilter == "")
                    {
                        return null;
                    }
                    filter.WhereClause = currentFilter;
                    IDisplayTable featureLayer = this._tableInfo.FeatureLayer as IDisplayTable;
                    List<IRow> pRows = null;
                    DataTable ptable = this.CreateDataTable(pFields);
                    if (this._tableInfo.SectionName.ToUpper().Contains("HAR") && (this._tableInfo.GraphType == "Design"))
                    {
                        this.GetDigtal20(pFont, featureLayer, this._title, pFields, ref ptable, out ef, pCellWidth, out pCellHeight, ref pRows, currentFilter);
                    }
                    else
                    {
                        this.GetDigtal10(pFont, featureLayer, this._title, pFields, ref ptable, out ef, pCellWidth, out pCellHeight, ref pRows, currentFilter);
                    }
                    if ((pRows != null) && (pRows.Count != 0))
                    {
                        int width = int.Parse(Math.Ceiling((double) ef.Width).ToString());
                        height = int.Parse(Math.Ceiling((double) ef.Height).ToString());
                        Bitmap image = new Bitmap(width, height);
                        Graphics graphics = Graphics.FromImage(image);
                        Metafile metafile = new Metafile(graphics.GetHdc(), new Rectangle(0, 0, width, height), MetafileFrameUnit.Pixel);
                        Graphics pGraphics = Graphics.FromImage(metafile);
                        GraphicsUnit pixel = GraphicsUnit.Pixel;
                        pGraphics.FillRectangle(new SolidBrush(Color.White), image.GetBounds(ref pixel));
                        ef = pGraphics.MeasureString(this._title, pFont);
                        float x = (width - ef.Width) / 2f;
                        float y = this._titleOffsetTop;
                        pGraphics.DrawString(this._title, pFont, new SolidBrush(Color.Black), x, y);
                        x = 0f;
                        y += this._titleOffsetbottom + ef.Height;
                        float pX = x;
                        float pY = y;
                        IRow row = pRows[0];
                        IFields fields = row.Fields;
                        for (int i = 0; i < pFields.Length; i++)
                        {
                            string name = pFields[i];
                            int index = fields.FindField(name);
                            if (index == -1)
                            {
                                string[] strArray2 = name.Split(new char[] { ' ' });
                                this.DrawCell(pGraphics, strArray2[strArray2.Length - 1], pCellWidth[i], pCellHeight, pFont, pX, pY);
                            }
                            else
                            {
                                this.DrawCell(pGraphics, fields.get_Field(index).AliasName, pCellWidth[i], pCellHeight, pFont, pX, pY);
                            }
                            pX += pCellWidth[i] - this._border;
                        }
                        pX = 0f;
                        string pText = "";
                        foreach (DataRow row2 in ptable.Rows)
                        {
                            pY += pCellHeight - this._border;
                            for (int j = 0; j < pCellWidth.Count; j++)
                            {
                                object obj2 = row2[j];
                                if (obj2 != null)
                                {
                                    pText = obj2.ToString();
                                }
                                else
                                {
                                    pText = "";
                                }
                                this.DrawCell(pGraphics, pText, pCellWidth[j], pCellHeight, pFont, pX, pY);
                                pX += pCellWidth[j] - this._border;
                            }
                            pX = 0f;
                        }
                        pY += pCellHeight;
                        pGraphics.DrawLine(new Pen(Color.Black), x, pY, (float) width, pY);
                        pGraphics.DrawLine(new Pen(Color.Black), (float) width, y, (float) width, pY);
                        pGraphics.Save();
                        image.Dispose();
                        graphics.Dispose();
                        pGraphics.Dispose();
                        return metafile;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "DrawtableEx", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private string GetCurrentFilter(IGeometry pGeo, TableInfo pTi)
        {
            try
            {
                IFeatureLayer featureLayer = pTi.FeatureLayer;
                IFeatureClass featureClass = featureLayer.FeatureClass;
                string str = "";
                if (!pTi.UseSelection)
                {
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    queryFilter.Geometry = pGeo;
                    queryFilter.GeometryField = featureClass.ShapeFieldName;
                    queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    queryFilter.WhereClause = pTi.Condition;
                    UtilFactory.GetConfigOpt();
                    IFeatureCursor cursor = featureLayer.Search(queryFilter, false);
                    for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                    {
                        object obj2 = str;
                        str = string.Concat(new object[] { obj2, " or ", featureClass.OIDFieldName, "=", feature.OID });
                    }
                }
                else
                {
                    IFeatureSelection selection = featureLayer as IFeatureSelection;
                    ISelectionSet selectionSet = selection.SelectionSet;
                    if (selectionSet.Count == 0)
                    {
                        XtraMessageBox.Show("请先用选择工具选中图斑！");
                        return str;
                    }
                    IEnumIDs iDs = selectionSet.IDs;
                    iDs.Reset();
                    for (int i = iDs.Next(); i != -1; i = iDs.Next())
                    {
                        object obj3 = str;
                        str = string.Concat(new object[] { obj3, " or ", featureClass.OIDFieldName, "=", i });
                    }
                }
                if (str != "")
                {
                    str = str.Substring(3);
                }
                else
                {
                    XtraMessageBox.Show("没有数据！");
                }
                return str;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetCurrentFilter", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return "";
            }
        }

        private void GetDigtal(Font pFont, IDisplayTable pTable, string pTitle, string[] pFields, out SizeF pSize, List<float> pCellWidth, out float pCellHeight, List<ICodedValueDomain> pDomain, IQueryFilter pQf)
        {
            float num = 0f;
            Bitmap image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            ICursor o = pTable.SearchDisplayTable(pQf, false);
            IRow item = o.NextRow();
            float num2 = 0f;
            pSize = new SizeF();
            float height = 0f;
            pCellHeight = 0f;
            try
            {
                if (item == null)
                {
                    for (int i = 0; i < pFields.Length; i++)
                    {
                        int index = o.Fields.FindField(pFields[i]);
                        IField field = o.Fields.get_Field(index);
                        SizeF ef = graphics.MeasureString(field.AliasName, pFont);
                        num2 = (ef.Width + (2 * this._padding)) + this._border;
                        pSize.Width += num2;
                        height = ef.Height;
                        pCellWidth.Add(num2 + this._border);
                    }
                    pSize.Width += this._border;
                    pCellHeight = (height + (2 * this._padding)) + (this._border * 2);
                    pSize.Height = ((this._titleOffsetTop + this._titleOffsetbottom) + graphics.MeasureString(pTitle, pFont).Height) + pCellHeight;
                }
                else
                {
                    string str = "";
                    bool flag = false;
                    Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                    List<IRow> list = new List<IRow>();
                    while (item != null)
                    {
                        list.Add(item);
                        item = o.NextRow();
                    }
                    for (int j = 0; j < pFields.Length; j++)
                    {
                        int num7 = o.Fields.FindField(pFields[j]);
                        if (num7 == -1)
                        {
                            throw new Exception("找不到配置文件中设置的字段！");
                        }
                        IField field2 = o.Fields.get_Field(num7);
                        SizeF ef2 = graphics.MeasureString(field2.AliasName, pFont);
                        IFieldEdit edit = field2 as IFieldEdit;
                        ICodedValueDomain domain = edit.Domain as ICodedValueDomain;
                        pDomain.Add(domain);
                        int num8 = 0;
                        string text = string.Empty;
                        foreach (IRow row2 in list)
                        {
                            int num9;
                            int num10;
                            object obj2 = row2.get_Value(num7);
                            if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                            {
                                continue;
                            }
                            str = obj2.ToString();
                            if (domain != null)
                            {
                                num9 = 0;
                                while (num9 < domain.CodeCount)
                                {
                                    obj2 = domain.get_Value(num9);
                                    if ((obj2 != null) && obj2.ToString().Equals(str))
                                    {
                                        goto Label_0269;
                                    }
                                    num9++;
                                }
                            }
                            goto Label_0274;
                        Label_0269:
                            str = domain.get_Name(num9);
                        Label_0274:
                            num10 = str.Length;
                            if (num10 > num8)
                            {
                                num8 = num10;
                                text = str;
                                if (regex.IsMatch(str))
                                {
                                    height = ef2.Height;
                                    flag = true;
                                }
                            }
                        }
                        if (num8 == 0)
                        {
                            num += (ef2.Width + (2 * this._padding)) + this._border;
                            pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                        }
                        else
                        {
                            SizeF ef3 = graphics.MeasureString(text, pFont);
                            if (ef3.Width > ef2.Width)
                            {
                                num += (ef3.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef3.Width + (2 * this._padding)) + (this._border * 2));
                            }
                            else
                            {
                                num += (ef2.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                            }
                        }
                    }
                    num += this._border;
                    SizeF ef4 = graphics.MeasureString(pTitle, pFont);
                    float num11 = ef4.Width + (2 * this._padding);
                    num2 = (num >= num11) ? num : num11;
                    pSize.Width = num2;
                    int num12 = pTable.DisplayTable.RowCount(pQf);
                    if (flag)
                    {
                        num2 = (((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ((num12 + 1) * (height + (this._padding * 2)))) + ((num12 + 1) * this._border);
                        pCellHeight = (height + (this._padding * 2)) + (2 * this._border);
                    }
                    else
                    {
                        num2 = (((((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ef4.Height) + (this._padding * 2)) + (num12 * (graphics.MeasureString("a", pFont).Height + (this._padding * 2)))) + ((num12 + 1) * this._border);
                        pCellHeight = (graphics.MeasureString("a", pFont).Height + (this._padding * 2)) + (2 * this._border);
                    }
                    pSize.Height = num2;
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetDigtal", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void GetDigtal1(Font pFont, IDisplayTable pTable, string pTitle, string[] pFields, out SizeF pSize, List<float> pCellWidth, out float pCellHeight, ref List<IRow> pRows, string pCondition)
        {
            float num = 0f;
            Bitmap image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            float num2 = 0f;
            pSize = new SizeF();
            float height = 0f;
            pCellHeight = 0f;
            try
            {
                string text = null;
                string str2 = null;
                StringBuilder builder = new StringBuilder();
                List<SizeF> list = new List<SizeF>();
                ICodedValueDomain domain = null;
                Dictionary<string, ICodedValueDomain> dictionary = new Dictionary<string, ICodedValueDomain>();
                IFields fields = pTable.DisplayTable.Fields;
                for (int i = 0; i < pFields.Length; i++)
                {
                    str2 = pFields[i];
                    builder.Append(str2);
                    builder.Append(",");
                    string name = str2.Split(new char[] { ' ' })[0];
                    int index = fields.FindField(name);
                    IField field = fields.get_Field(index);
                    text = field.AliasName;
                    IFieldEdit edit = field as IFieldEdit;
                    domain = edit.Domain as ICodedValueDomain;
                    if (domain != null)
                    {
                        dictionary.Add(str2, domain);
                    }
                    SizeF item = graphics.MeasureString(text, pFont);
                    list.Add(item);
                    num2 = (item.Width + (2 * this._padding)) + this._border;
                    pSize.Width += num2;
                    height = item.Height;
                    pCellWidth.Add(num2 + this._border);
                }
                builder = builder.Remove(builder.Length - 1, 1);
                IQueryFilter pQueryFilter = new QueryFilterClass();
                ICursor o = null;
                pQueryFilter.SubFields = builder.ToString();
                pQueryFilter.WhereClause = pCondition;
                pSize.Width += this._border;
                pCellHeight = (height + (2 * this._padding)) + (this._border * 2);
                pSize.Height = ((this._titleOffsetTop + this._titleOffsetbottom) + graphics.MeasureString(pTitle, pFont).Height) + pCellHeight;
                pRows = new List<IRow>();
                o = pTable.SearchDisplayTable(pQueryFilter, false);
                for (IRow row = o.NextRow(); row != null; row = o.NextRow())
                {
                    pRows.Add(row);
                }
                if (pRows.Count != 0)
                {
                    pCellWidth.Clear();
                    string str4 = "";
                    bool flag = false;
                    Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                    for (int j = 0; j < pFields.Length; j++)
                    {
                        domain = null;
                        str2 = pFields[j];
                        int num7 = fields.FindField(str2);
                        if (num7 == -1)
                        {
                            str2 = str2.Split(new char[] { ' ' })[0];
                            num7 = fields.FindField(str2);
                        }
                        if (Enumerable.Contains<string>(dictionary.Keys, str2))
                        {
                            domain = dictionary[str2];
                        }
                        SizeF ef2 = list[j];
                        int num8 = 0;
                        string str5 = string.Empty;
                        foreach (IRow row2 in pRows)
                        {
                            int num9;
                            object obj2 = row2.get_Value(num7);
                            if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                            {
                                continue;
                            }
                            str4 = obj2.ToString();
                            if (domain != null)
                            {
                                num9 = 0;
                                while (num9 < domain.CodeCount)
                                {
                                    obj2 = domain.get_Value(num9);
                                    if ((obj2 != null) && obj2.ToString().Equals(str4))
                                    {
                                        goto Label_0346;
                                    }
                                    num9++;
                                }
                            }
                            goto Label_035C;
                        Label_0346:
                            str4 = domain.get_Name(num9);
                            row2.set_Value(j, str4);
                        Label_035C:
                            if (str4.Contains("."))
                            {
                                row2.set_Value(j, str4.TrimEnd(new char[] { '0' }));
                            }
                            int length = str4.Length;
                            if (length > num8)
                            {
                                num8 = length;
                                str5 = str4;
                                if (regex.IsMatch(str4))
                                {
                                    height = ef2.Height;
                                    flag = true;
                                }
                            }
                        }
                        if (num8 == 0)
                        {
                            num += (ef2.Width + (2 * this._padding)) + this._border;
                            pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                        }
                        else
                        {
                            SizeF ef3 = graphics.MeasureString(str5, pFont);
                            if (ef3.Width > ef2.Width)
                            {
                                num += (ef3.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef3.Width + (2 * this._padding)) + (this._border * 2));
                            }
                            else
                            {
                                num += (ef2.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                            }
                        }
                    }
                    num += this._border;
                    SizeF ef4 = graphics.MeasureString(pTitle, pFont);
                    float num11 = ef4.Width + (2 * this._padding);
                    num2 = (num >= num11) ? num : num11;
                    pSize.Width = num2;
                    int count = pRows.Count;
                    if (flag)
                    {
                        num2 = (((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ((count + 1) * (height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (height + (this._padding * 2)) + (2 * this._border);
                    }
                    else
                    {
                        num2 = (((((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ef4.Height) + (this._padding * 2)) + (count * (graphics.MeasureString("a", pFont).Height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (graphics.MeasureString("a", pFont).Height + (this._padding * 2)) + (2 * this._border);
                    }
                    pSize.Height = num2;
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetDigtal1", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void GetDigtal10(Font pFont, IDisplayTable pTable, string pTitle, string[] pFields, ref DataTable ptable, out SizeF pSize, List<float> pCellWidth, out float pCellHeight, ref List<IRow> pRows, string pCondition)
        {
            float num = 0f;
            Bitmap image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            float num2 = 0f;
            pSize = new SizeF();
            float height = 0f;
            pCellHeight = 0f;
            try
            {
                string text = null;
                string name = null;
                StringBuilder builder = new StringBuilder();
                List<SizeF> list = new List<SizeF>();
                ICodedValueDomain domain = null;
                Dictionary<string, ICodedValueDomain> dictionary = new Dictionary<string, ICodedValueDomain>();
                IFields fields = pTable.DisplayTable.Fields;
                for (int i = 0; i < pFields.Length; i++)
                {
                    name = pFields[i];
                    name = name.Split(new char[] { ' ' })[0];
                    int index = fields.FindField(name);
                    builder.Append(name);
                    builder.Append(",");
                    IField field = fields.get_Field(index);
                    text = field.AliasName;
                    IFieldEdit edit = field as IFieldEdit;
                    domain = edit.Domain as ICodedValueDomain;
                    if (domain != null)
                    {
                        dictionary.Add(name, domain);
                    }
                    SizeF item = graphics.MeasureString(text, pFont);
                    list.Add(item);
                    num2 = (item.Width + (2 * this._padding)) + this._border;
                    pSize.Width += num2;
                    height = item.Height;
                    pCellWidth.Add(num2 + this._border);
                }
                builder = builder.Remove(builder.Length - 1, 1);
                IQueryFilter pQueryFilter = new QueryFilterClass();
                ICursor o = null;
                pQueryFilter.SubFields = builder.ToString();
                pQueryFilter.WhereClause = pCondition;
                pSize.Width += this._border;
                pCellHeight = (height + (2 * this._padding)) + (this._border * 2);
                pSize.Height = ((this._titleOffsetTop + this._titleOffsetbottom) + graphics.MeasureString(pTitle, pFont).Height) + pCellHeight;
                pRows = new List<IRow>();
                o = pTable.SearchDisplayTable(pQueryFilter, false);
                for (IRow row = o.NextRow(); row != null; row = o.NextRow())
                {
                    DataRow row2 = ptable.NewRow();
                    ptable.Rows.Add(row2);
                    pRows.Add(row);
                }
                if (pRows.Count != 0)
                {
                    pCellWidth.Clear();
                    string str3 = "";
                    bool flag = false;
                    Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                    for (int j = 0; j < pFields.Length; j++)
                    {
                        domain = null;
                        name = pFields[j];
                        int num7 = fields.FindField(name);
                        if (num7 == -1)
                        {
                            name = name.Split(new char[] { ' ' })[0];
                            num7 = fields.FindField(name);
                        }
                        if (Enumerable.Contains<string>(dictionary.Keys, name))
                        {
                            domain = dictionary[name];
                        }
                        SizeF ef2 = list[j];
                        int num8 = 0;
                        string str4 = string.Empty;
                        int num9 = 0;
                        foreach (IRow row3 in pRows)
                        {
                            int num10;
                            object obj2 = row3.get_Value(num7);
                            if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                            {
                                continue;
                            }
                            str3 = obj2.ToString();
                            ptable.Rows[num9][j] = str3;
                            if (domain != null)
                            {
                                num10 = 0;
                                while (num10 < domain.CodeCount)
                                {
                                    obj2 = domain.get_Value(num10);
                                    if ((obj2 != null) && obj2.ToString().Equals(str3))
                                    {
                                        goto Label_037A;
                                    }
                                    num10++;
                                }
                            }
                            goto Label_03A8;
                        Label_037A:
                            str3 = domain.get_Name(num10);
                            ptable.Rows[num9][j] = str3;
                            row3.set_Value(num7, str3);
                        Label_03A8:
                            if (str3.Contains("."))
                            {
                                ptable.Rows[num9][j] = str3;
                                row3.set_Value(num7, str3.TrimEnd(new char[] { '0' }));
                            }
                            int length = str3.Length;
                            if (length > num8)
                            {
                                num8 = length;
                                str4 = str3;
                                if (regex.IsMatch(str3))
                                {
                                    height = ef2.Height;
                                    flag = true;
                                }
                            }
                            num9++;
                        }
                        if (num8 == 0)
                        {
                            num += (ef2.Width + (2 * this._padding)) + this._border;
                            pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                        }
                        else
                        {
                            SizeF ef3 = graphics.MeasureString(str4, pFont);
                            if (ef3.Width > ef2.Width)
                            {
                                num += (ef3.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef3.Width + (2 * this._padding)) + (this._border * 2));
                            }
                            else
                            {
                                num += (ef2.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                            }
                        }
                    }
                    num += this._border;
                    SizeF ef4 = graphics.MeasureString(pTitle, pFont);
                    float num12 = ef4.Width + (2 * this._padding);
                    num2 = (num >= num12) ? num : num12;
                    pSize.Width = num2;
                    int count = pRows.Count;
                    if (flag)
                    {
                        num2 = (((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ((count + 1) * (height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (height + (this._padding * 2)) + (2 * this._border);
                    }
                    else
                    {
                        num2 = (((((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ef4.Height) + (this._padding * 2)) + (count * (graphics.MeasureString("a", pFont).Height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (graphics.MeasureString("a", pFont).Height + (this._padding * 2)) + (2 * this._border);
                    }
                    pSize.Height = num2;
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetDigtal10", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void GetDigtal2(Font pFont, IDisplayTable pTable, string pTitle, string[] pFields, out SizeF pSize, List<float> pCellWidth, out float pCellHeight, ref List<IRow> pRows, string pCondition)
        {
            float num = 0f;
            Bitmap image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            float num2 = 0f;
            pSize = new SizeF();
            float height = 0f;
            pCellHeight = 0f;
            try
            {
                string text = null;
                string str2 = null;
                StringBuilder builder = new StringBuilder();
                List<SizeF> list = new List<SizeF>();
                ICodedValueDomain domain = null;
                Dictionary<string, ICodedValueDomain> dictionary = new Dictionary<string, ICodedValueDomain>();
                IFields fields = pTable.DisplayTable.Fields;
                for (int i = 0; i < pFields.Length; i++)
                {
                    str2 = pFields[i];
                    if (i == (pFields.Length - 1))
                    {
                        text = "出材量";
                    }
                    else
                    {
                        builder.Append(str2);
                        builder.Append(",");
                        int index = fields.FindField(str2);
                        if (index == -1)
                        {
                            str2 = str2.Split(new char[] { ' ' })[0];
                            index = fields.FindField(str2);
                        }
                        IField field = fields.get_Field(index);
                        text = field.AliasName;
                        IFieldEdit edit = field as IFieldEdit;
                        domain = edit.Domain as ICodedValueDomain;
                        if (domain != null)
                        {
                            dictionary.Add(str2, domain);
                        }
                    }
                    SizeF item = graphics.MeasureString(text, pFont);
                    list.Add(item);
                    num2 = (item.Width + (2 * this._padding)) + this._border;
                    pSize.Width += num2;
                    height = item.Height;
                    pCellWidth.Add(num2 + this._border);
                }
                builder = builder.Remove(builder.Length - 1, 1);
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.SubFields = builder.ToString();
                pQueryFilter.WhereClause = pCondition;
                ICursor o = pTable.SearchDisplayTable(pQueryFilter, false);
                pSize.Width += this._border;
                pCellHeight = (height + (2 * this._padding)) + (this._border * 2);
                pSize.Height = ((this._titleOffsetTop + this._titleOffsetbottom) + graphics.MeasureString(pTitle, pFont).Height) + pCellHeight;
                pRows = new List<IRow>();
                for (IRow row = o.NextRow(); row != null; row = o.NextRow())
                {
                    pRows.Add(row);
                }
                if (pRows.Count != 0)
                {
                    pCellWidth.Clear();
                    string str3 = "";
                    bool flag = false;
                    Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                    for (int j = 0; j < pFields.Length; j++)
                    {
                        domain = null;
                        str2 = pFields[j];
                        int num7 = fields.FindField(str2);
                        if (num7 == -1)
                        {
                            str2 = str2.Split(new char[] { ' ' })[0];
                            num7 = fields.FindField(str2);
                        }
                        if (Enumerable.Contains<string>(dictionary.Keys, str2))
                        {
                            domain = dictionary[str2];
                        }
                        SizeF ef2 = list[j];
                        int num8 = 0;
                        string str4 = string.Empty;
                        foreach (IRow row2 in pRows)
                        {
                            int num9;
                            object obj2 = row2.get_Value(num7);
                            if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                            {
                                continue;
                            }
                            str3 = obj2.ToString();
                            if (domain != null)
                            {
                                num9 = 0;
                                while (num9 < domain.CodeCount)
                                {
                                    obj2 = domain.get_Value(num9);
                                    if ((obj2 != null) && obj2.ToString().Equals(str3))
                                    {
                                        goto Label_0369;
                                    }
                                    num9++;
                                }
                            }
                            goto Label_037F;
                        Label_0369:
                            str3 = domain.get_Name(num9);
                            row2.set_Value(num7, str3);
                        Label_037F:
                            if (str3.Contains("."))
                            {
                                row2.set_Value(num7, str3.TrimEnd(new char[] { '0' }));
                            }
                            int length = str3.Length;
                            if (length > num8)
                            {
                                num8 = length;
                                str4 = str3;
                                if (regex.IsMatch(str3))
                                {
                                    height = ef2.Height;
                                    flag = true;
                                }
                            }
                        }
                        if (num8 == 0)
                        {
                            num += (ef2.Width + (2 * this._padding)) + this._border;
                            pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                        }
                        else
                        {
                            SizeF ef3 = graphics.MeasureString(str4, pFont);
                            if (ef3.Width > ef2.Width)
                            {
                                num += (ef3.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef3.Width + (2 * this._padding)) + (this._border * 2));
                            }
                            else
                            {
                                num += (ef2.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                            }
                        }
                    }
                    num += this._border;
                    SizeF ef4 = graphics.MeasureString(pTitle, pFont);
                    float num11 = ef4.Width + (2 * this._padding);
                    num2 = (num >= num11) ? num : num11;
                    pSize.Width = num2;
                    int count = pRows.Count;
                    if (flag)
                    {
                        num2 = (((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ((count + 1) * (height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (height + (this._padding * 2)) + (2 * this._border);
                    }
                    else
                    {
                        num2 = (((((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ef4.Height) + (this._padding * 2)) + (count * (graphics.MeasureString("a", pFont).Height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (graphics.MeasureString("a", pFont).Height + (this._padding * 2)) + (2 * this._border);
                    }
                    pSize.Height = num2;
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetDigtal2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void GetDigtal20(Font pFont, IDisplayTable pTable, string pTitle, string[] pFields, ref DataTable ptable, out SizeF pSize, List<float> pCellWidth, out float pCellHeight, ref List<IRow> pRows, string pCondition)
        {
            float num = 0f;
            Bitmap image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            float num2 = 0f;
            pSize = new SizeF();
            float height = 0f;
            pCellHeight = 0f;
            try
            {
                string text = null;
                string str2 = null;
                StringBuilder builder = new StringBuilder();
                List<SizeF> list = new List<SizeF>();
                ICodedValueDomain domain = null;
                Dictionary<string, ICodedValueDomain> dictionary = new Dictionary<string, ICodedValueDomain>();
                IFields fields = pTable.DisplayTable.Fields;
                for (int i = 0; i < pFields.Length; i++)
                {
                    str2 = pFields[i];
                    if (i == (pFields.Length - 1))
                    {
                        text = "出材量";
                    }
                    else
                    {
                        builder.Append(str2);
                        builder.Append(",");
                        int index = fields.FindField(str2);
                        if (index == -1)
                        {
                            str2 = str2.Split(new char[] { ' ' })[0];
                            index = fields.FindField(str2);
                        }
                        IField field = fields.get_Field(index);
                        text = field.AliasName;
                        IFieldEdit edit = field as IFieldEdit;
                        domain = edit.Domain as ICodedValueDomain;
                        if (domain != null)
                        {
                            dictionary.Add(str2, domain);
                        }
                    }
                    SizeF item = graphics.MeasureString(text, pFont);
                    list.Add(item);
                    num2 = (item.Width + (2 * this._padding)) + this._border;
                    pSize.Width += num2;
                    height = item.Height;
                    pCellWidth.Add(num2 + this._border);
                }
                builder = builder.Remove(builder.Length - 1, 1);
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.SubFields = builder.ToString();
                pQueryFilter.WhereClause = pCondition;
                ICursor o = pTable.SearchDisplayTable(pQueryFilter, false);
                pSize.Width += this._border;
                pCellHeight = (height + (2 * this._padding)) + (this._border * 2);
                pSize.Height = ((this._titleOffsetTop + this._titleOffsetbottom) + graphics.MeasureString(pTitle, pFont).Height) + pCellHeight;
                pRows = new List<IRow>();
                for (IRow row = o.NextRow(); row != null; row = o.NextRow())
                {
                    DataRow row2 = ptable.NewRow();
                    ptable.Rows.Add(row2);
                    pRows.Add(row);
                }
                if (pRows.Count != 0)
                {
                    pCellWidth.Clear();
                    string s = "";
                    bool flag = false;
                    Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                    for (int j = 0; j < pFields.Length; j++)
                    {
                        domain = null;
                        str2 = pFields[j];
                        int num7 = fields.FindField(str2);
                        int num8 = -1;
                        if (num7 == -1)
                        {
                            str2 = str2.Split(new char[] { ' ' })[0];
                            num7 = fields.FindField(str2);
                        }
                        if (num7 == -1)
                        {
                            string[] strArray = str2.Split(new char[] { '+' });
                            num7 = fields.FindField(strArray[0]);
                            if (strArray.Length > 1)
                            {
                                num8 = fields.FindField(strArray[1]);
                            }
                        }
                        if (Enumerable.Contains<string>(dictionary.Keys, str2))
                        {
                            domain = dictionary[str2];
                        }
                        SizeF ef2 = list[j];
                        int num9 = 0;
                        string str4 = string.Empty;
                        int num10 = 0;
                        foreach (IRow row3 in pRows)
                        {
                            int num11;
                            object obj2 = row3.get_Value(num7);
                            if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                            {
                                continue;
                            }
                            s = obj2.ToString();
                            if (num8 > -1)
                            {
                                obj2 = row3.get_Value(num8);
                                if ((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().TrimStart(new char[0]).TrimEnd(new char[0])))
                                {
                                    continue;
                                }
                                s = (double.Parse(s) + double.Parse(obj2.ToString())).ToString();
                            }
                            ptable.Rows[num10][j] = s;
                            if (domain != null)
                            {
                                num11 = 0;
                                while (num11 < domain.CodeCount)
                                {
                                    obj2 = domain.get_Value(num11);
                                    if ((obj2 != null) && obj2.ToString().Equals(s))
                                    {
                                        goto Label_043C;
                                    }
                                    num11++;
                                }
                            }
                            goto Label_046A;
                        Label_043C:
                            s = domain.get_Name(num11);
                            ptable.Rows[num10][j] = s;
                            row3.set_Value(num7, s);
                        Label_046A:
                            if (s.Contains("."))
                            {
                                ptable.Rows[num10][j] = s.TrimEnd(new char[] { '0' });
                                row3.set_Value(num7, s.TrimEnd(new char[] { '0' }));
                            }
                            int length = s.Length;
                            if (length > num9)
                            {
                                num9 = length;
                                str4 = s;
                                if (regex.IsMatch(s))
                                {
                                    height = ef2.Height;
                                    flag = true;
                                }
                            }
                            num10++;
                        }
                        if (num9 == 0)
                        {
                            num += (ef2.Width + (2 * this._padding)) + this._border;
                            pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                        }
                        else
                        {
                            SizeF ef3 = graphics.MeasureString(str4, pFont);
                            if (ef3.Width > ef2.Width)
                            {
                                num += (ef3.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef3.Width + (2 * this._padding)) + (this._border * 2));
                            }
                            else
                            {
                                num += (ef2.Width + (2 * this._padding)) + this._border;
                                pCellWidth.Add((ef2.Width + (2 * this._padding)) + (this._border * 2));
                            }
                        }
                    }
                    num += this._border;
                    SizeF ef4 = graphics.MeasureString(pTitle, pFont);
                    float num13 = ef4.Width + (2 * this._padding);
                    num2 = (num >= num13) ? num : num13;
                    pSize.Width = num2;
                    int count = pRows.Count;
                    if (flag)
                    {
                        num2 = (((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ((count + 1) * (height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (height + (this._padding * 2)) + (2 * this._border);
                    }
                    else
                    {
                        num2 = (((((this._titleOffsetTop + ef4.Height) + this._titleOffsetbottom) + ef4.Height) + (this._padding * 2)) + (count * (graphics.MeasureString("a", pFont).Height + (this._padding * 2)))) + ((count + 1) * this._border);
                        pCellHeight = (graphics.MeasureString("a", pFont).Height + (this._padding * 2)) + (2 * this._border);
                    }
                    pSize.Height = num2;
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetDigtal20", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string[] GetFields()
        {
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            string name = "";
            string str2 = "";
            string str3 = this._sectionName.ToUpper();
            if (str3.Contains("AFF"))
            {
                name = "AFF";
            }
            else if (str3.Contains("HAR"))
            {
                name = "HAR";
            }
            else if (str3.Contains("ZZY"))
            {
                name = "ZZY";
            }
            str2 = configOpt.GetConfigValue2(name, this._tableInfo.GraphType);
            if (string.IsNullOrEmpty(str2))
            {
                XtraMessageBox.Show("没有设置表格字段！");
                return null;
            }
            int index = str2.IndexOf(',');
            string sLayerName = str2.Substring(0, index);
            IFeatureLayer pFeatureLayer = GISFunFactory.LayerFun.FindFeatureLayer(this._map as IBasicMap, sLayerName, true);
            if (pFeatureLayer == null)
            {
                XtraMessageBox.Show("没有找到数据图层！");
                return null;
            }
            if (pFeatureLayer.FeatureClass == null)
            {
                XtraMessageBox.Show("图层没有连接数据源！");
                return null;
            }
            this._tableInfo.FeatureLayer = pFeatureLayer;
            string str5 = str2.Substring(index + 1);
            string[] fieldName = null;
            if (!this._tableInfo.Custom)
            {
                return str5.Split(new char[] { ',' });
            }
            TableField field = new TableField(pFeatureLayer, this._map);
            fieldName = field.GetFieldName();
            this._tableInfo.FeatureLayer = field.SelectedFeatureLayer;
            field = null;
            return fieldName;
        }

        private Font GetFont()
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Font");
                if (string.IsNullOrEmpty(configValue))
                {
                    throw new Exception("没有设置字体！");
                }
                string[] strArray = configValue.Split(new char[] { ',' });
                InstalledFontCollection fonts = new InstalledFontCollection();
                FontFamily[] families = fonts.Families;
                bool flag = false;
                foreach (FontFamily family in families)
                {
                    if (family.Name.Equals(strArray[0], StringComparison.Ordinal))
                    {
                        goto Label_007F;
                    }
                }
                goto Label_0082;
            Label_007F:
                flag = true;
            Label_0082:
                if (!flag)
                {
                    throw new Exception("系统没有安装设置的字体类型！");
                }
                int result = 0;
                if (!int.TryParse(strArray[1], out result))
                {
                    throw new Exception("设置的字体大小必须为数字！");
                }
                this._fontSize = result;
                return new Font(new FontFamily(strArray[0]), float.Parse(strArray[1]), FontStyle.Regular, GraphicsUnit.Pixel);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Business.TableDrawer", "GetFont", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }
    }
}

