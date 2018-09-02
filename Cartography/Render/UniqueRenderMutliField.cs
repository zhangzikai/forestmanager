namespace Cartography.Render
{
    using Cartography;
    using Cartography.Base;
    using DevExpress.Data;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Utilities;

    public class UniqueRenderMutliField : FormBase3
    {
        private IFeatureLayer _fLayer;
        private IUniqueValueRenderer _render = new UniqueValueRendererClass();
        private AdvBandedGridView advBandedGridView1;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private BarButtonItem bbiGroup;
        private BarButtonItem bbiNiewTitle;
        private BarButtonItem bbiSplit;
        private BarButtonItem bbiSymbolPro;
        private BarEditItem beiNewTitle;
        private BandedGridColumn bgcDefBitmap;
        private BandedGridColumn bgcDefFieldValue;
        private BandedGridColumn bgcDefLabel;
        private BandedGridColumn bgcDefSymbol;
        private BarSubItem bsiMove;
        private SimpleButton btAddOne;
        private SimpleButton btAllValue;
        private SimpleButton btCancel;
        private SimpleButton btDown;
        private SimpleButton btOK;
        private SimpleButton btRemoveAll;
        private SimpleButton btRemoveOne;
        private SimpleButton btUp;
        private ComboBoxEdit cbeCartoField;
        private IContainer components;
        private List<IField> fls = new List<IField>();
        private GridControl gcValue;
        private GridBand gridBand1;
        private GridBand gridBand11;
        private GridBand gridBand12;
        private GridBand gridBand13;
        private GridBand gridBand14;
        private GridBand gridBand15;
        private GridBand gridBand16;
        private GridBand gridBand17;
        private GridBand gridBand18;
        private GridBand gridBand2;
        private GridBand gridBand3;
        private GridBand gridBand4;
        private ImageComboBoxEdit icbeColorRamp;
        private bool init;
        private Dictionary<IStyleGalleryItem, Bitmap> items;
        private Label lbCartoField;
        private LabelControl lbColorRamp;
        private const string mClassName = "Cartography.Element.UniqueRenderMutliField";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PopupMenu popupMenu1;
        private List<string> refValues = new List<string>();
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private ComboBoxEdit secondField;
        private ComboBoxEdit thirdField;
        private RepositoryItemTextEdit repositoryItemTextEdit2;

        public UniqueRenderMutliField(IFeatureLayer pFeatureLayer)
        {
            if ((pFeatureLayer == null) || (pFeatureLayer.FeatureClass == null))
            {
                throw new NullReferenceException("数据为空！");
            }
            this.InitializeComponent();
            this._fLayer = pFeatureLayer;
            this.Initial();
        }

        private void advBandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name == "bgcDefLabel")
                {
                    if (this.refValues[e.RowHandle] == "-1")
                    {
                        if (e.RowHandle == 0)
                        {
                            bool useDefaultSymbol = this._render.UseDefaultSymbol;
                            this._render.UseDefaultSymbol = true;
                            this._render.DefaultLabel = e.Value.ToString();
                            ILegendInfo info = this._render as ILegendInfo;
                            info.get_LegendGroup(0).get_Class(0).Label = this._render.DefaultLabel;
                            this._render.UseDefaultSymbol = useDefaultSymbol;
                        }
                        else
                        {
                            int rowHandle = e.RowHandle;
                            while (this.refValues[rowHandle++] != "-1")
                            {
                                this._render.set_Heading(this.refValues[rowHandle], e.Value.ToString());
                            }
                        }
                    }
                    else
                    {
                        this._render.set_Label(this.refValues[e.RowHandle], e.Value.ToString());
                    }
                }
                else if (e.Column.Name == "bgcDefSymbol")
                {
                    this._render.UseDefaultSymbol = (bool)e.Value;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "advBandedGridView1_CellValueChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void advBandedGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if ((e.RowHandle == 0) && (e.Column.Name == "bgcDefSymbol"))
            {
                e.RepositoryItem = this.repositoryItemCheckEdit1;
            }
            object rowCellValue = this.advBandedGridView1.GetRowCellValue(e.RowHandle, this.advBandedGridView1.Bands[0].Columns[1]);
            if (((rowCellValue != null) && (rowCellValue.ToString() != "标题")) && (e.Column.Name == "bgcDefBitmap"))
            {
                e.RepositoryItem = this.repositoryItemPictureEdit1;
            }
        }

        private void advBandedGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<int> list2;
                int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                if (selectedRows.Length == 0)
                {
                    this.bbiSplit.Enabled = false;
                    this.btRemoveOne.Enabled = false;
                    this.bbiSymbolPro.Enabled = false;
                    this.bsiMove.Enabled = false;
                    this.btDown.Enabled = false;
                    this.btUp.Enabled = false;
                    return;
                }
                if (selectedRows.Length >= 2)
                {
                    this.btDown.Enabled = false;
                    this.btUp.Enabled = false;
                }
                else
                {
                    int num = selectedRows[0];
                    if (this.refValues[num] != "-1")
                    {
                        if (this.refValues[num - 1] == "-1")
                        {
                            this.btUp.Enabled = false;
                        }
                        else
                        {
                            this.btUp.Enabled = true;
                        }
                        if ((num != (this.refValues.Count - 1)) && (((num + 1) > (this.refValues.Count - 1)) || (this.refValues[num + 1] != "-1")))
                        {
                            this.btDown.Enabled = true;
                        }
                        else
                        {
                            this.btDown.Enabled = false;
                        }
                    }
                    else
                    {
                        ILegendInfo info = this._render as ILegendInfo;
                        ILegendGroup group = null;
                        if (info.LegendGroupCount > 1)
                        {
                            group = info.get_LegendGroup(info.LegendGroupCount - 1);
                        }
                        switch (num)
                        {
                            case 0:
                                this.btDown.Enabled = false;
                                this.btUp.Enabled = false;
                                goto Label_029F;

                            case 1:
                                this.btUp.Enabled = false;
                                if (this._render.UseDefaultSymbol)
                                {
                                    if (info.LegendGroupCount < 3)
                                    {
                                        this.btDown.Enabled = false;
                                    }
                                    else
                                    {
                                        this.btDown.Enabled = true;
                                    }
                                }
                                else if (info.LegendGroupCount < 2)
                                {
                                    this.btDown.Enabled = false;
                                }
                                else
                                {
                                    this.btDown.Enabled = true;
                                }
                                goto Label_029F;
                        }
                        if ((group != null) && group.Heading.Equals(((Cartography.Render.Record)dataSource[num]).Label))
                        {
                            this.btDown.Enabled = false;
                            if (this._render.UseDefaultSymbol)
                            {
                                if (info.LegendGroupCount < 3)
                                {
                                    this.btUp.Enabled = false;
                                }
                                else
                                {
                                    this.btUp.Enabled = true;
                                }
                            }
                            else if (info.LegendGroupCount < 2)
                            {
                                this.btUp.Enabled = false;
                            }
                            else
                            {
                                this.btUp.Enabled = true;
                            }
                        }
                        else
                        {
                            this.btDown.Enabled = true;
                            this.btUp.Enabled = true;
                        }
                    }
                }
            Label_029F:
                list2 = new List<int>();
                bool flag = false;
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int item = selectedRows[i];
                    if (item == 0)
                    {
                        flag = true;
                    }
                    else if (this.refValues[item] != "-1")
                    {
                        list2.Add(item);
                    }
                }
                if (list2.Count < 1)
                {
                    this.bsiMove.Enabled = false;
                    this.bbiSymbolPro.Enabled = flag;
                    this.btRemoveOne.Enabled = false;
                }
                else
                {
                    this.bsiMove.Enabled = true;
                    this.bbiSymbolPro.Enabled = true;
                    this.btRemoveOne.Enabled = true;
                }
                if (list2.Count < 2)
                {
                    this.bbiGroup.Enabled = false;
                }
                else
                {
                    this.bbiGroup.Enabled = true;
                }
                bool flag2 = false;
                using (List<int>.Enumerator enumerator = list2.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        int current = enumerator.Current;
                        Cartography.Render.Record record = dataSource[current] as Cartography.Render.Record;
                        if (record.FieldValue.Contains(";"))
                        {
                            goto Label_03AA;
                        }
                    }
                    goto Label_03BD;
                Label_03AA:
                    flag2 = true;
                }
            Label_03BD:
                this.bbiSplit.Enabled = flag2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "advBandedGridView1_SelectionChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void bbiGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            string str = "";
            StringBuilder builder = new StringBuilder();
            List<int> list2 = new List<int>();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int item = selectedRows[i];
                if ((item != 0) && (this.refValues[item] != "-1"))
                {
                    Cartography.Render.Record record = dataSource[item] as Cartography.Render.Record;
                    string[] strArray = record.FieldValue.Split(new char[] { ';' });
                    list2.Add(item);
                    if (str == "")
                    {
                        str = strArray[0];
                        builder.Append(record.FieldValue);
                    }
                    else
                    {
                        builder.Append(";" + record.FieldValue);
                        this._render.get_Heading(str);
                        foreach (string str2 in strArray)
                        {
                            this._render.RemoveValue(str2);
                            this._render.AddReferenceValue(str2, str);
                        }
                    }
                }
            }
            Cartography.Render.Record record2 = dataSource[list2[0]] as Cartography.Render.Record;
            record2.FieldValue = builder.ToString();
            for (int j = 1; j < list2.Count; j++)
            {
                this.refValues.RemoveAt(list2[j]);
                dataSource.RemoveAt(list2[j]);
            }
            this.gcValue.RefreshDataSource();
        }

        private void bbiNiewTitle_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                NewHeading heading = new NewHeading();
                if (heading.ShowDialog() == DialogResult.OK)
                {
                    int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
                    ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                    for (int i = 0; i < this.refValues.Count; i++)
                    {
                        if ((this.refValues[i] == "-1") && ((Cartography.Render.Record)dataSource[i]).Label.Equals(heading.Heading))
                        {
                            goto Label_01CF;
                        }
                    }
                    dataSource.Add(new Cartography.Render.Record(null, null, "标题", heading.Heading, null));
                    this.refValues.Add("-1");
                    Dictionary<string, ILegendGroup> dictionary = new Dictionary<string, ILegendGroup>();
                    ILegendInfo info = this._render as ILegendInfo;
                    foreach (int num2 in selectedRows)
                    {
                        ILegendGroup group;
                        if (this.refValues[num2] == "-1")
                        {
                            continue;
                        }
                        string str2 = this.refValues[num2];
                        string key = this._render.get_Heading(str2);
                        if (!dictionary.ContainsKey(key))
                        {
                            for (int j = 0; j < info.LegendGroupCount; j++)
                            {
                                group = info.get_LegendGroup(j);
                                if (group.Heading.Equals(key))
                                {
                                    goto Label_014A;
                                }
                            }
                        }
                        goto Label_0155;
                    Label_014A:
                        dictionary.Add(key, group);
                    Label_0155:
                        this._render.set_Heading(str2, heading.Heading);
                        string item = this.refValues[num2];
                        Cartography.Render.Record record = dataSource[num2] as Cartography.Render.Record;
                        this.refValues.RemoveAt(num2);
                        dataSource.RemoveAt(num2);
                        this.refValues.Add(item);
                        dataSource.Add(record);
                    }
                    this.gcValue.RefreshDataSource();
                }
                goto Label_01DC;
            Label_01CF:
                XtraMessageBox.Show("已存在相同的标题！");
                return;
            Label_01DC:
                heading.Dispose();
                heading = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "bbiNiewTitle_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void bbiSplit_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int pSelectedIndex = selectedRows[i];
                if ((pSelectedIndex != 0) && (this.refValues[pSelectedIndex] != "-1"))
                {
                    Cartography.Render.Record pRecord = dataSource[pSelectedIndex] as Cartography.Render.Record;
                    if (pRecord.FieldValue.Contains(";"))
                    {
                        this.Split(pSelectedIndex, pRecord);
                    }
                }
            }
        }

        private void bbiSymbolPro_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int num2;
                ISymbol symbol;
                DevSymbolSelector selector;
                List<ISymbol> pSymbols = new List<ISymbol>();
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    num2 = selectedRows[i];
                    if ((num2 == 0) || (this.refValues[num2] != "-1"))
                    {
                        if (num2 != 0)
                        {
                            goto Label_006A;
                        }
                        pSymbols.Add(this._render.DefaultSymbol);
                    }
                }
                goto Label_008C;
            Label_006A:
                symbol = this._render.get_Symbol(this.refValues[num2]);
                pSymbols.Add(symbol);
            Label_008C:
                selector = new DevSymbolSelector();
                IStyleGalleryItem item = null;
                item = selector.GetItem(this._fLayer.FeatureClass.ShapeType, pSymbols, 0);
                selector.Dispose();
                if (item != null)
                {
                    for (int j = 0; j < selectedRows.Length; j++)
                    {
                        int num4 = selectedRows[j];
                        if ((num4 == 0) || (this.refValues[num4] != "-1"))
                        {
                            ISymbol symbol2 = item.Item as ISymbol;
                            if (num4 == 0)
                            {
                                bool useDefaultSymbol = this._render.UseDefaultSymbol;
                                this._render.UseDefaultSymbol = false;
                                this._render.DefaultSymbol = symbol2;
                                this._render.DefaultLabel = "默认值";
                                this._render.UseDefaultSymbol = useDefaultSymbol;
                            }
                            else
                            {
                                this._render.set_Symbol(this.refValues[num4], symbol2);
                            }
                            Cartography.Render.Record record = dataSource[num4] as Cartography.Render.Record;
                            Bitmap bitmap = BitmapManager.GetSymbolBitMap(symbol2, this.bgcDefBitmap.Width, 30);
                            record.Image = bitmap;
                        }
                    }
                    this.gcValue.RefreshDataSource();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "bbiSymbolPro_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btAddOne_Click(object sender, EventArgs e)
        {
            if (this.icbeColorRamp.SelectedIndex == 0)
            {
                XtraMessageBox.Show("请选择色坡！");
                return;
            }
            IColorRamp colorRamp = this.GetColorRamp();
            if (colorRamp == null)
            {
                XtraMessageBox.Show("没有获取色坡！");
                return;
            }
            else
            {
                try
                {
                    if (this.cbeCartoField.SelectedIndex <= 0 && this.cbeCartoField.SelectedIndex <= 0 && this.cbeCartoField.SelectedIndex <= 0)
                    {
                        XtraMessageBox.Show("请选择字段！");
                    }
                    else
                    {
                        List<IField> fieldList = new List<IField>();
                        int count = 0;
                        string label = "";
                        if (cbeCartoField.SelectedIndex > 0)
                        {
                            fieldList.Add(this.fls[this.cbeCartoField.SelectedIndex - 1]);
                            label += fieldList[0].AliasName;
                            count++;
                        }
                        else
                            fieldList.Add(null);
                        if (secondField.SelectedIndex > 0)
                        {
                            fieldList.Add(this.fls[this.secondField.SelectedIndex - 1]);
                            label += fieldList[1].AliasName;
                            count++;
                        }
                        else
                            fieldList.Add(null);
                        if (thirdField.SelectedIndex > 0)
                        {
                            fieldList.Add(this.fls[this.thirdField.SelectedIndex - 1]);
                            label += fieldList[2].AliasName;
                            count++;
                        }
                        else
                            fieldList.Add(null);
                        String pLabel = "";
                        this._render.FieldCount = count;
                        AddValueMutliField value2 = new AddValueMutliField(fieldList.ToArray(), this._fLayer.FeatureClass as ITable, this._render);
                        if (value2.ShowDialog() == DialogResult.OK)
                        {
                            Dictionary<string, string> codeValues = value2.CodeValues;
                            if (codeValues.Count != 0)
                            {
                                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                               colorRamp = this.GetColorRamp();
                                colorRamp.Size = codeValues.Count<2?2:codeValues.Count;
                                bool ok = false;
                                colorRamp.CreateRamp(out ok);
                                if (ok)
                                {
                                    int index = 0;
                                    string heading = "";
                                    if (dataSource.Count == 1)
                                    {
                                        dataSource.Add(new Cartography.Render.Record(null, null, "标题", label, null));
                                        this.refValues.Add("-1");
                                    }
                                    //if (this.refValues[this.refValues.Count - 1] != "-1")
                                    //{
                                    //    heading = this._render.get_Heading(this.refValues[this.refValues.Count - 1]);
                                    //}
                                    //else
                                    //{
                                    //    heading = ((Cartography.Render.Record)dataSource[dataSource.Count - 1]).FieldValue;
                                    //}

                                        foreach (KeyValuePair<string, string> pair in codeValues)
                                        {
                                            ISymbol pSymbol = UniqueValueCarto.SetSymbolByColorRamp(this._fLayer.FeatureClass.ShapeType, colorRamp.get_Color(index));
                                            Bitmap pImage = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
                                            dataSource.Add(new Cartography.Render.Record(null, pImage, pair.Key, pair.Value, null));
                                            this.refValues.Add(pair.Key);
                                            this._render.AddValue(pair.Key, "标题", pSymbol);
                                            this._render.set_Label(pair.Key, pair.Value);
                                            index++;
                                        }


                                    this.gcValue.RefreshDataSource();
                                }
                                else
                                {
                                    XtraMessageBox.Show("颜色创建遇到问题！");
                                }
                                for (int i = 0; i < this._render.ValueCount; i++)
                                {
                                    this._render.get_Value(i);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "btAddOne_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void btAllValue_Click(object sender, EventArgs e)
        {
            try
            {
                ITable table;
                ArrayList dataSource1 = this.gcValue.DataSource as ArrayList;
                if (dataSource1.Count > 1)
                {
                    this.refValues.RemoveRange(1, this.refValues.Count - 1);
                    dataSource1.RemoveRange(1, dataSource1.Count - 1);
                    this._render.RemoveAllValues();
                }
                if (this.cbeCartoField.SelectedIndex <= 0 && this.secondField.SelectedIndex <= 0 && this.thirdField.SelectedIndex <= 0)
                {
                    XtraMessageBox.Show("请选择字段！");
                    return;
                }
                if (this.icbeColorRamp.SelectedIndex == 0)
                {
                    XtraMessageBox.Show("请选择色坡！");
                    return;
                }
                IColorRamp colorRamp = this.GetColorRamp();
                if (colorRamp == null)
                {
                    XtraMessageBox.Show("没有获取色坡！");
                    return;
                }
                this.refValues.Add("-1");
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                List<IField> fieldList = new List<IField>();
                int count = 0;
                if (cbeCartoField.SelectedIndex > 0)
                {
                    fieldList.Add(this.fls[this.cbeCartoField.SelectedIndex - 1]);
                    count++;
                }
                else
                    fieldList.Add(null);
                if (secondField.SelectedIndex > 0)
                {
                    fieldList.Add(this.fls[this.secondField.SelectedIndex - 1]);
                    count++;
                }
                else
                    fieldList.Add(null);
                if (thirdField.SelectedIndex > 0)
                {
                    fieldList.Add(this.fls[this.thirdField.SelectedIndex - 1]);
                    count++;
                }
                else
                    fieldList.Add(null);
                String pLabel = "";
                this._render.FieldCount = count;
                int rampSize = 1;
                int firstCodeCount = 1;
                int secondCodeCount = 1;
                int thirdCodeCount = 1;
                count = 0;
                int count1 = 0;
                foreach (IField t in fieldList)
                {
                    if (t == null)
                    {
                        count++;
                        continue;
                    }
                    pLabel += t.AliasName;
                    this._render.set_Field(count1, t.Name);
                    rampSize *= (t.Domain as ICodedValueDomain).CodeCount;
                    if (count == 0)
                        firstCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    if (count == 1)
                        secondCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    if (count == 2)
                        thirdCodeCount = (t.Domain as ICodedValueDomain).CodeCount;
                    count++;
                    count1++;
                }
                dataSource.Add(new Cartography.Render.Record(null, null, "标题", pLabel, null));
                //IFieldEdit edit = field as IFieldEdit;
                //IFieldEdit edit1 = field1 as IFieldEdit;
                //IFieldEdit edit2 = field2 as IFieldEdit;
                bool ok = false;
                //if (!(edit.Domain is ICodedValueDomain))
                //{
                //    goto Label_01FD;
                //}
                //ICodedValueDomain domain = edit.Domain as ICodedValueDomain;
                colorRamp.Size = rampSize<2?2:rampSize;
                colorRamp.CreateRamp(out ok);
                if (!ok)
                {
                    goto Label_01ED;
                }
                string pLable3;
                string pvalue3;
                for (int i = 0; i < firstCodeCount; i++)
                {
                    string pLabel1 = "";
                    string pvalue1 = "";
                    if (fieldList[0] != null) {
                        pLabel1 += (fieldList[0].Domain as ICodedValueDomain).get_Name(i) ;
                        pvalue1 += (fieldList[0].Domain as ICodedValueDomain).get_Value(i).ToString();
                        if (fieldList[1] != null || fieldList[2] != null){
                            pLabel1 += ",";
                            pvalue1 += this._render.FieldDelimiter;
                            }
                    }
                    for (int m = 0; m < secondCodeCount; m++)
                    {
                        string pLable2 = "";
                        string pvalue2 = "";
                        if (fieldList[1] != null)
                        {
                            pLable2 = pLabel1 + (fieldList[1].Domain as ICodedValueDomain).get_Name(m) ;
                            pvalue2 = pvalue1 + (fieldList[1].Domain as ICodedValueDomain).get_Value(m).ToString() ;
                            if (fieldList[2] != null) {
                                pLable2 += ",";
                                pvalue2 += this._render.FieldDelimiter;
                            }

                        }
                        else {
                            pLable2 = pLabel1;
                            pvalue2 = pvalue1;
                        }
                        for (int n = 0; n < thirdCodeCount; n++)
                        {
                            pLable3 = "";
                            pvalue3 = "";
                            if (fieldList[2] != null)
                            {
                                pLable3 = pLable2 + (fieldList[2].Domain as ICodedValueDomain).get_Name(n) ;
                                pvalue3 = pvalue2 + (fieldList[2].Domain as ICodedValueDomain).get_Value(n).ToString() ;

                            }
                            else {
                                pLable3 = pLable2;
                                pvalue3 = pvalue2;
                            }
                            ISymbol symbol = UniqueValueCarto.SetSymbolByColorRamp(this._fLayer.FeatureClass.ShapeType, colorRamp.get_Color((i + 1) * (m + 1) * (n + 1)-1));
                            if (symbol == null)
                            {
                                goto Label_01D2;
                            }
                            this._render.AddValue(pvalue3, "标题", symbol);
                            Bitmap pImage = BitmapManager.GetSymbolBitMap(symbol, this.bgcDefBitmap.Width, 30);
                            dataSource.Add(new Cartography.Render.Record(null, pImage, pvalue3, pLable3, null));
                            this._render.set_Label(pvalue3, pLable3);
                            this.refValues.Add(pvalue3);
                        }
                    }

                }
                goto Label_01DD;
            Label_01D2:
                MessageBox.Show("符号创建遇到问题！");
            Label_01DD:
                this.gcValue.RefreshDataSource();
                return;
            Label_01ED:
                XtraMessageBox.Show("颜色创建遇到问题！");
                return;
            Label_01FD:
                table = this._fLayer.FeatureClass as ITable;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.SubFields = "";
                int num2 = table.RowCount(queryFilter);
                colorRamp.Size = num2<2?2:num2;
                colorRamp.CreateRamp(out ok);
                if (!ok)
                {
                    goto Label_0336;
                }
                ICursor cursor = table.Search(queryFilter, true);
                IRow row = null;
                ArrayList list2 = new ArrayList();
                int index = 0;
                while ((row = cursor.NextRow()) != null)
                {
                    string item = row.get_Value(0).ToString();
                    if (!list2.Contains(item))
                    {
                        list2.Add(item);
                        ISymbol symbol2 = UniqueValueCarto.SetSymbolByColorRamp(this._fLayer.FeatureClass.ShapeType, colorRamp.get_Color(index));
                        if (symbol2 == null)
                        {
                            goto Label_031E;
                        }
                        this._render.AddValue(item, "标题", symbol2);
                        this._render.set_Label(item, item);
                        Bitmap bitmap2 = BitmapManager.GetSymbolBitMap(symbol2, this.bgcDefBitmap.Width, 30);
                        dataSource.Add(new Cartography.Render.Record(null, bitmap2, item, item, null));
                        this.refValues.Add(item);
                        index++;
                    }
                }
                goto Label_0329;
            Label_031E:
                MessageBox.Show("符号创建遇到问题！");
            Label_0329:
                this.gcValue.RefreshDataSource();
                return;
            Label_0336:
                XtraMessageBox.Show("颜色创建遇到问题！");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "btAllValue_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = this.advBandedGridView1.FocusedRowHandle;
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            List<Cartography.Render.Record> c = new List<Cartography.Render.Record>();
            if (this.refValues[focusedRowHandle] != "-1")
            {
                int num4 = focusedRowHandle + 1;
                string local1 = this.refValues[focusedRowHandle];
                string str = this.refValues[num4];
                this.refValues[num4] = this.refValues[focusedRowHandle];
                this.refValues[focusedRowHandle] = str;
                Cartography.Render.Record record = dataSource[num4] as Cartography.Render.Record;
                dataSource[num4] = dataSource[focusedRowHandle];
                dataSource[focusedRowHandle] = record;
                UniqueValueCarto.SortOne(this._render, this.refValues[num4], this.refValues[focusedRowHandle]);
            }
            else
            {
                c.Add(dataSource[focusedRowHandle] as Cartography.Render.Record);
                int num2 = focusedRowHandle + 1;
                while (this.refValues[num2] != "-1")
                {
                    if (num2 >= (this.refValues.Count - 1))
                    {
                        break;
                    }
                    c.Add(dataSource[num2] as Cartography.Render.Record);
                    num2++;
                }
                this.refValues.RemoveRange(focusedRowHandle, num2 - focusedRowHandle);
                this.refValues.Add("-1");
                for (int i = 1; i < c.Count; i++)
                {
                    string[] strArray = c[i].FieldValue.Split(new char[] { ';' });
                    this.refValues.Add(strArray[0]);
                }
                dataSource.RemoveRange(focusedRowHandle, num2 - focusedRowHandle);
                dataSource.AddRange(c);
                UniqueValueCarto.SortMany(this._render, ((Cartography.Render.Record)dataSource[num2]).Label, ((Cartography.Render.Record)dataSource[focusedRowHandle]).Label);
            }
            this.gcValue.RefreshDataSource();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbeCartoField.Text))
            {
                XtraMessageBox.Show("因数据存在问题，没有制图字段，不能渲染！");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
                IGeoFeatureLayer layer = this._fLayer as IGeoFeatureLayer;
                layer.Renderer = (IFeatureRenderer)this._render;
                base.Close();
            }
        }

        private void btRemoveAll_Click(object sender, EventArgs e)
        {
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            if (dataSource.Count > 1)
            {
                this.refValues.RemoveRange(1, this.refValues.Count - 1);
                dataSource.RemoveRange(1, dataSource.Count - 1);
                this._render.RemoveAllValues();
            }
            this.gcValue.RefreshDataSource();
        }

        private void btRemoveOne_Click(object sender, EventArgs e)
        {
            int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            foreach (int num in selectedRows)
            {
                if (num != 0)
                {
                    if (this.refValues[num] != "-1")
                    {
                        Cartography.Render.Record record = dataSource[num] as Cartography.Render.Record;
                        foreach (string str in record.FieldValue.Split(new char[] { ';' }))
                        {
                            this._render.RemoveValue(str);
                        }
                    }
                    this.refValues.RemoveAt(num);
                    dataSource.RemoveAt(num);
                }
            }
            this.gcValue.RefreshDataSource();
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = this.advBandedGridView1.FocusedRowHandle;
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            List<Cartography.Render.Record> c = new List<Cartography.Render.Record>();
            if (this.refValues[focusedRowHandle] == "-1")
            {
                int index = focusedRowHandle - 1;
                while (this.refValues[index] != "-1")
                {
                    c.Add(dataSource[index] as Cartography.Render.Record);
                    index--;
                }
                c.Add(dataSource[index] as Cartography.Render.Record);
                c.Reverse();
                this.refValues.RemoveRange(index, focusedRowHandle - index);
                this.refValues.Add("-1");
                for (int i = 1; i < c.Count; i++)
                {
                    string[] strArray = c[i].FieldValue.Split(new char[] { ';' });
                    this.refValues.Add(strArray[0]);
                }
                dataSource.RemoveRange(index, focusedRowHandle - index);
                dataSource.AddRange(c);
                UniqueValueCarto.SortMany(this._render, ((Cartography.Render.Record)dataSource[focusedRowHandle]).Label, ((Cartography.Render.Record)dataSource[index]).Label);
            }
            else
            {
                int num4 = focusedRowHandle - 1;
                string local1 = this.refValues[focusedRowHandle];
                string str = this.refValues[num4];
                this.refValues[num4] = this.refValues[focusedRowHandle];
                this.refValues[focusedRowHandle] = str;
                Cartography.Render.Record record = dataSource[num4] as Cartography.Render.Record;
                dataSource[num4] = dataSource[focusedRowHandle];
                dataSource[focusedRowHandle] = record;
                UniqueValueCarto.SortOne(this._render, this.refValues[num4], this.refValues[focusedRowHandle]);
            }
            this.gcValue.RefreshDataSource();
        }

        private void cbeCartoField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!this.init && (this.cbeCartoField.SelectedIndex != -1)) && (this.cbeCartoField.SelectedIndex != 0))
            {
                IField field = this.fls[this.cbeCartoField.SelectedIndex - 1];
                //this._render.FieldCount = 1;
                //this._render.set_Field(0, field.Name);
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                if ((dataSource != null) && (dataSource.Count > 1))
                {
                    dataSource.RemoveRange(1, dataSource.Count - 1);
                    this.gcValue.RefreshDataSource();
                    this.refValues.RemoveRange(1, this.refValues.Count - 1);
                    while (this._render.ValueCount > 0)
                    {
                        this._render.RemoveValue(this._render.get_Value(0));
                    }
                }
            }
        }

        private void ChangeFillColor(IColorRamp cr, ArrayList list)
        {
            int index = 0;
            for (int i = 0; i < this.refValues.Count; i++)
            {
                if (this.refValues[i] != "-1")
                {
                    ISymbol pSymbol = this._render.get_Symbol(this.refValues[i]);
                    IColor color = cr.get_Color(index);
                    IFillSymbol symbol2 = pSymbol as IFillSymbol;
                    symbol2.Color = color;
                    ((Cartography.Render.Record)list[i]).Image = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
                    index++;
                }
            }
        }

        private void ChangeLineColor(IColorRamp cr, ArrayList list)
        {
            int index = 0;
            for (int i = 0; i < this.refValues.Count; i++)
            {
                if (this.refValues[i] != "-1")
                {
                    ISymbol pSymbol = this._render.get_Symbol(this.refValues[i]);
                    IColor color = cr.get_Color(index);
                    ILineSymbol symbol2 = pSymbol as ILineSymbol;
                    symbol2.Color = color;
                    ((Cartography.Render.Record)list[i]).Image = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
                    index++;
                }
            }
        }

        private void ChangeMarkerColor(IColorRamp cr, ArrayList list)
        {
            int index = 0;
            for (int i = 0; i < this.refValues.Count; i++)
            {
                if (this.refValues[i] != "-1")
                {
                    ISymbol pSymbol = this._render.get_Symbol(this.refValues[i]);
                    IColor color = cr.get_Color(index);
                    IMarkerSymbol symbol2 = pSymbol as IMarkerSymbol;
                    symbol2.Color = color;
                    ((Cartography.Render.Record)list[i]).Image = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
                    index++;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void gcValue_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                {
                    return;
                }
                while (this.bsiMove.ItemLinks.Count > 1)
                {
                    this.bsiMove.ItemLinks.RemoveAt(1);
                }
                int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
                List<int> list = new List<int>();
                bool flag = false;
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int num2 = selectedRows[i];
                    if (num2 == 0)
                    {
                        flag = true;
                    }
                    else if (this.refValues[num2] != "-1")
                    {
                        list.Add(num2);
                    }
                }
                if (list.Count < 1)
                {
                    this.bsiMove.Enabled = false;
                    this.bbiSymbolPro.Enabled = flag;
                }
                if (list.Count < 2)
                {
                    this.bbiGroup.Enabled = false;
                }
                bool flag2 = false;
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                using (List<int>.Enumerator enumerator = list.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        int current = enumerator.Current;
                        Cartography.Render.Record record = dataSource[current] as Cartography.Render.Record;
                        if (record.FieldValue.Contains(";"))
                        {
                            goto Label_0113;
                        }
                    }
                    goto Label_0126;
                Label_0113:
                    flag2 = true;
                }
            Label_0126:
                this.bbiSplit.Enabled = flag2;
                int num4 = 0;
                for (int j = 1; j < this.refValues.Count; j++)
                {
                    if (this.refValues[j] == "-1")
                    {
                        Cartography.Render.Record record2 = dataSource[j] as Cartography.Render.Record;
                        BarItem item = new BarButtonItem();
                        item.Caption = record2.Label;
                        item.ItemClick += new ItemClickEventHandler(this.item_ItemClick);
                        this.bsiMove.AddItem(item);
                        num4++;
                    }
                }
                if (num4 < 2)
                {
                    for (int k = 1; k < this.bsiMove.ItemLinks.Count; k++)
                    {
                        this.bsiMove.ItemLinks[k].Item.Enabled = false;
                    }
                }
                this.popupMenu1.ShowPopup(base.PointToScreen(new System.Drawing.Point(e.X, e.Y)));
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "gcValue_MouseDown", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private IColorRamp GetColorRamp()
        {
            IEnumerator enumerator = this.items.Keys.GetEnumerator();
            int num = 0;
            IStyleGalleryItem current = null;
            while (enumerator.MoveNext())
            {
                if (num == (this.icbeColorRamp.SelectedIndex - 1))
                {
                    current = enumerator.Current as IStyleGalleryItem;
                    break;
                }
                num++;
            }
            return (current.Item as IColorRamp);
        }

        private void icbeColorRamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                try
                {
                    if (this.icbeColorRamp.SelectedIndex != 0)
                    {
                        this._render.ColorScheme = this.icbeColorRamp.Text;
                        ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                        if ((dataSource != null) && (dataSource.Count > 1))
                        {
                            IColorRamp colorRamp = this.GetColorRamp();
                            if (colorRamp == null)
                            {
                                XtraMessageBox.Show("没有获取色坡！");
                                return;
                            }
                            colorRamp.Size = this.refValues.Count;
                            bool ok = false;
                            colorRamp.CreateRamp(out ok);
                            if (ok)
                            {
                                switch (this._fLayer.FeatureClass.ShapeType)
                                {
                                    case esriGeometryType.esriGeometryPoint:
                                        this.ChangeMarkerColor(colorRamp, dataSource);
                                        break;

                                    case esriGeometryType.esriGeometryPolyline:
                                        this.ChangeLineColor(colorRamp, dataSource);
                                        break;

                                    case esriGeometryType.esriGeometryPolygon:
                                        this.ChangeFillColor(colorRamp, dataSource);
                                        break;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("颜色创建遇到问题！");
                            }
                        }
                        this.gcValue.RefreshDataSource();
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "icbeColorRamp_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void Initial()
        {
            try
            {
                string str5;
                List<string> list3;
                List<string> list4;
                ILegendInfo info;
                this.init = true;
                this.repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Stretch;
                this.advBandedGridView1.Bands[0].Columns[1].OptionsColumn.AllowEdit = false;
                IFields fields = this._fLayer.FeatureClass.Fields;
                IGeoFeatureLayer layer = this._fLayer as IGeoFeatureLayer;
                IUniqueValueRenderer pSourceObj = layer.Renderer as IUniqueValueRenderer;
                if (pSourceObj != null)
                {
                    CloneService.Clone(pSourceObj, this._render);
                }
                string cartoFieldAliasName = UniqueValueCarto.GetCartoFieldAliasName(layer.Renderer);
                this.cbeCartoField.Properties.Items.Add("");
                this.secondField.Properties.Items.Add("");
                this.thirdField.Properties.Items.Add("");
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField item = fields.get_Field(i);
                    IFieldEdit edit = item as IFieldEdit;
                    if (((edit.Domain != null) && (edit.Domain.Type != esriDomainType.esriDTRange)) && (edit.Domain.Type != esriDomainType.esriDTString))
                    {
                        this.fls.Add(item);
                        if (item.Name.Equals(cartoFieldAliasName))
                        {
                            this.cbeCartoField.Text = item.AliasName;
                            this.secondField.Text = item.AliasName;
                            this.thirdField.Text = item.AliasName;
                        }
                        this.cbeCartoField.Properties.Items.Add(item.AliasName);
                        this.secondField.Properties.Items.Add(item.AliasName);
                        this.thirdField.Properties.Items.Add(item.AliasName);
                    }
                }
                IRelationshipClassCollection classs = this._fLayer as IRelationshipClassCollection;
                IRelationshipClass class3 = classs.RelationshipClasses.Next();
                while (class3 != null)
                {
                    fields = class3.DestinationClass.Fields;
                    for (int j = 0; j < fields.FieldCount; j++)
                    {
                        IField field2 = fields.get_Field(j);
                        IFieldEdit edit2 = field2 as IFieldEdit;
                        if (((edit2.Domain != null) && (edit2.Domain.Type != esriDomainType.esriDTRange)) && (edit2.Domain.Type != esriDomainType.esriDTString))
                        {
                            this.fls.Add(field2);
                            if (field2.Name.Equals(cartoFieldAliasName))
                            {
                                this.cbeCartoField.Text = field2.AliasName;
                                this.secondField.Text = field2.AliasName;
                                this.thirdField.Text = field2.AliasName;
                            }
                            this.cbeCartoField.Properties.Items.Add(field2.AliasName);
                            this.secondField.Properties.Items.Add(field2.AliasName);
                            this.thirdField.Properties.Items.Add(field2.AliasName);
                        }
                    }
                }
                ImageList list = new ImageList();
                list.ImageSize = new Size(this.icbeColorRamp.Width - 10, this.icbeColorRamp.Height);
                this.icbeColorRamp.Properties.SmallImages = list;
                this.items = BitmapManager.GetBitMapText("Color Ramps", this.icbeColorRamp.Width, this.icbeColorRamp.Height);
                int imageIndex = 0;
                this.icbeColorRamp.Properties.Items.Add(new ImageComboBoxItem("", "", -1));
                foreach (KeyValuePair<IStyleGalleryItem, Bitmap> pair in this.items)
                {
                    list.Images.Add(pair.Value);
                    this.icbeColorRamp.Properties.Items.Add(new ImageComboBoxItem("", pair.Key.Name, imageIndex));
                    imageIndex++;
                }
                this.icbeColorRamp.Properties.SmallImages = list;
                if (pSourceObj != null)
                {
                    if (!string.IsNullOrEmpty(pSourceObj.ColorScheme))
                    {
                        this.icbeColorRamp.Text = pSourceObj.ColorScheme;
                    }
                    else
                    {
                        this.icbeColorRamp.SelectedIndex = 0;
                    }
                }
                else
                {
                    this.icbeColorRamp.SelectedIndex = 0;
                }
                ArrayList list2 = new ArrayList();
                Bitmap image = new Bitmap(this.bgcDefBitmap.Width, 30);
                Graphics.FromImage(image).FillRectangle(new SolidBrush(Color.Green), 0, 0, image.Width, image.Height);
                bool pChecked = true;
                if (pSourceObj == null)
                {
                    ISymbol symbol = UniqueValueCarto.CreateSymbol(this._fLayer.FeatureClass.ShapeType, Color.Green);
                    this._render.DefaultSymbol = symbol;
                    this._render.DefaultLabel = "默认值";
                    this._render.UseDefaultSymbol = true;
                    list2.Add(new Cartography.Render.Record(pChecked, image, "默认值", "默认值", ""));
                    this.refValues.Add("-1");
                    goto Label_06C7;
                }
                Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
                Dictionary<string, StringBuilder> dictionary2 = new Dictionary<string, StringBuilder>();
                if (!pSourceObj.UseDefaultSymbol)
                {
                    pChecked = false;
                }
                image = BitmapManager.GetSymbolBitMap(pSourceObj.DefaultSymbol, this.bgcDefBitmap.Width, 30);
                list2.Add(new Cartography.Render.Record(pChecked, image, "默认值", pSourceObj.DefaultLabel, ""));
                this.refValues.Add("-1");
                string str2 = ";";
                int index = 0;
            Label_04A3:
                if (index >= pSourceObj.ValueCount)
                {
                    goto Label_059E;
                }
                string str3 = pSourceObj.get_Value(index);
                string key = "";
                try
                {
                    key = pSourceObj.get_ReferenceValue(str3);
                    if (!dictionary2.ContainsKey(key))
                    {
                        StringBuilder builder = new StringBuilder();
                        dictionary2.Add(key, builder.Append(key).Append(str2).Append(str3));
                    }
                    else
                    {
                        dictionary2[key].Append(str2).Append(str3);
                    }
                }
                catch
                {
                    key = str3;
                    StringBuilder builder2 = new StringBuilder();
                    dictionary2.Add(key, builder2.Append(key));
                }
                goto Label_0587;
            Label_0539:
                list3 = new List<string>();
                list3.Add(key);
                dictionary.Add(str5, list3);
                goto Label_057C;
            Label_0556:
                list4 = dictionary[str5];
                if (!list4.Contains(key))
                {
                    dictionary[str5].Add(key);
                }
            Label_057C:
                index++;
                goto Label_04A3;
            Label_0587:
                str5 = pSourceObj.get_Heading(key);
                if (dictionary.ContainsKey(str5))
                {
                    goto Label_0556;
                }
                goto Label_0539;
            Label_059E:
                info = this._render as ILegendInfo;
                int num5 = -1;
                if (this._render.UseDefaultSymbol)
                {
                    num5 = 1;
                }
                else
                {
                    num5 = 0;
                }
                while (num5 < info.LegendGroupCount)
                {
                    ILegendGroup group = info.get_LegendGroup(num5);
                    list2.Add(new Cartography.Render.Record(null, null, "标题", group.Heading, ""));
                    this.refValues.Add("-1");
                    if (dictionary.ContainsKey(group.Heading))
                    {
                        List<string> list5 = dictionary[group.Heading];
                        foreach (string str6 in list5)
                        {
                            ISymbol pSymbol = pSourceObj.get_Symbol(str6);
                            string pLabel = pSourceObj.get_Label(str6);
                            image = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
                            list2.Add(new Cartography.Render.Record(null, image, dictionary2[str6].ToString(), pLabel, ""));
                            this.refValues.Add(str6);
                        }
                    }
                    num5++;
                }
            Label_06C7:
                this.gcValue.BeginInit();
                this.gcValue.DataSource = list2;
                this.gcValue.EndInit();
                if (list2.Count == 1)
                {
                    this.btRemoveOne.Enabled = false;
                }
                this.btRemoveOne.Enabled = false;
                this.init = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "Initial", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.lbCartoField = new System.Windows.Forms.Label();
            this.cbeCartoField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbColorRamp = new DevExpress.XtraEditors.LabelControl();
            this.gcValue = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcDefSymbol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgcDefBitmap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcDefFieldValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bgcDefLabel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSplit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSymbolPro = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiMove = new DevExpress.XtraBars.BarSubItem();
            this.bbiNiewTitle = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.beiNewTitle = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btAllValue = new DevExpress.XtraEditors.SimpleButton();
            this.btRemoveAll = new DevExpress.XtraEditors.SimpleButton();
            this.btAddOne = new DevExpress.XtraEditors.SimpleButton();
            this.btRemoveOne = new DevExpress.XtraEditors.SimpleButton();
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.icbeColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.btUp = new DevExpress.XtraEditors.SimpleButton();
            this.btDown = new DevExpress.XtraEditors.SimpleButton();
            this.secondField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.thirdField = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCartoField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeColorRamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdField.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCartoField
            // 
            this.lbCartoField.AutoSize = true;
            this.lbCartoField.Location = new System.Drawing.Point(14, 24);
            this.lbCartoField.Name = "lbCartoField";
            this.lbCartoField.Size = new System.Drawing.Size(59, 14);
            this.lbCartoField.TabIndex = 0;
            this.lbCartoField.Text = "制图字段:";
            // 
            // cbeCartoField
            // 
            this.cbeCartoField.Location = new System.Drawing.Point(90, 21);
            this.cbeCartoField.Name = "cbeCartoField";
            this.cbeCartoField.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbeCartoField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cbeCartoField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeCartoField.Size = new System.Drawing.Size(135, 20);
            this.cbeCartoField.TabIndex = 1;
            this.cbeCartoField.SelectedIndexChanged += new System.EventHandler(this.cbeCartoField_SelectedIndexChanged);
            // 
            // lbColorRamp
            // 
            this.lbColorRamp.Location = new System.Drawing.Point(252, 24);
            this.lbColorRamp.Name = "lbColorRamp";
            this.lbColorRamp.Size = new System.Drawing.Size(28, 14);
            this.lbColorRamp.TabIndex = 2;
            this.lbColorRamp.Text = "色坡:";
            // 
            // gcValue
            // 
            this.gcValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcValue.Location = new System.Drawing.Point(12, 159);
            this.gcValue.MainView = this.advBandedGridView1;
            this.gcValue.Name = "gcValue";
            this.gcValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gcValue.Size = new System.Drawing.Size(423, 329);
            this.gcValue.TabIndex = 4;
            this.gcValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            this.gcValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gcValue_MouseDown);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.advBandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bgcDefSymbol,
            this.bgcDefFieldValue,
            this.bgcDefLabel,
            this.bgcDefBitmap});
            this.advBandedGridView1.GridControl = this.gcValue;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsMenu.EnableColumnMenu = false;
            this.advBandedGridView1.OptionsMenu.EnableFooterMenu = false;
            this.advBandedGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.advBandedGridView1.OptionsPrint.AutoWidth = false;
            this.advBandedGridView1.OptionsSelection.MultiSelect = true;
            this.advBandedGridView1.OptionsView.ColumnAutoWidth = true;
            this.advBandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.advBandedGridView1.OptionsView.ShowDetailButtons = false;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            this.advBandedGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.advBandedGridView1.OptionsView.ShowIndicator = false;
            this.advBandedGridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.advBandedGridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.advBandedGridView1_CustomRowCellEdit);
            this.advBandedGridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.advBandedGridView1_SelectionChanged);
            this.advBandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.advBandedGridView1_CellValueChanged);
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "符号";
            this.gridBand2.Columns.Add(this.bgcDefSymbol);
            this.gridBand2.Columns.Add(this.bgcDefBitmap);
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowMove = false;
            this.gridBand2.OptionsBand.AllowSize = false;
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 88;
            // 
            // bgcDefSymbol
            // 
            this.bgcDefSymbol.Caption = "默认符号";
            this.bgcDefSymbol.FieldName = "Checked";
            this.bgcDefSymbol.Name = "bgcDefSymbol";
            this.bgcDefSymbol.OptionsColumn.AllowMove = false;
            this.bgcDefSymbol.Visible = true;
            this.bgcDefSymbol.Width = 20;
            // 
            // bgcDefBitmap
            // 
            this.bgcDefBitmap.Caption = "默认图片";
            this.bgcDefBitmap.FieldName = "Image";
            this.bgcDefBitmap.Name = "bgcDefBitmap";
            this.bgcDefBitmap.Visible = true;
            this.bgcDefBitmap.Width = 68;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "值";
            this.gridBand3.Columns.Add(this.bgcDefFieldValue);
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 135;
            // 
            // bgcDefFieldValue
            // 
            this.bgcDefFieldValue.Caption = "所有其它值";
            this.bgcDefFieldValue.FieldName = "FieldValue";
            this.bgcDefFieldValue.Name = "bgcDefFieldValue";
            this.bgcDefFieldValue.OptionsColumn.AllowEdit = false;
            this.bgcDefFieldValue.OptionsColumn.AllowMove = false;
            this.bgcDefFieldValue.Visible = true;
            this.bgcDefFieldValue.Width = 135;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "标签";
            this.gridBand4.Columns.Add(this.bgcDefLabel);
            this.gridBand4.MinWidth = 20;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.AllowMove = false;
            this.gridBand4.VisibleIndex = 2;
            this.gridBand4.Width = 135;
            // 
            // bgcDefLabel
            // 
            this.bgcDefLabel.Caption = "默认标签";
            this.bgcDefLabel.FieldName = "Label";
            this.bgcDefLabel.Name = "bgcDefLabel";
            this.bgcDefLabel.OptionsColumn.AllowMove = false;
            this.bgcDefLabel.Visible = true;
            this.bgcDefLabel.Width = 135;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiGroup,
            this.bbiSplit,
            this.bbiSymbolPro,
            this.barButtonItem2,
            this.bsiMove,
            this.barButtonItem3,
            this.beiNewTitle,
            this.bbiNiewTitle});
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(490, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Size = new System.Drawing.Size(490, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(490, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 537);
            // 
            // bbiGroup
            // 
            this.bbiGroup.Caption = "组合";
            this.bbiGroup.Id = 0;
            this.bbiGroup.Name = "bbiGroup";
            this.bbiGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGroup_ItemClick);
            // 
            // bbiSplit
            // 
            this.bbiSplit.Caption = "拆分";
            this.bbiSplit.Id = 1;
            this.bbiSplit.Name = "bbiSplit";
            this.bbiSplit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSplit_ItemClick);
            // 
            // bbiSymbolPro
            // 
            this.bbiSymbolPro.Caption = "符号属性";
            this.bbiSymbolPro.Id = 2;
            this.bbiSymbolPro.Name = "bbiSymbolPro";
            this.bbiSymbolPro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSymbolPro_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "移动到";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bsiMove
            // 
            this.bsiMove.Caption = "移动到标题";
            this.bsiMove.Id = 4;
            this.bsiMove.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNiewTitle)});
            this.bsiMove.Name = "bsiMove";
            // 
            // bbiNiewTitle
            // 
            this.bbiNiewTitle.Caption = "新标题";
            this.bbiNiewTitle.Id = 7;
            this.bbiNiewTitle.Name = "bbiNiewTitle";
            this.bbiNiewTitle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNiewTitle_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "新标题...";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // beiNewTitle
            // 
            this.beiNewTitle.Caption = "新标题";
            this.beiNewTitle.Edit = this.repositoryItemTextEdit2;
            this.beiNewTitle.Id = 6;
            this.beiNewTitle.Name = "beiNewTitle";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // btAllValue
            // 
            this.btAllValue.Location = new System.Drawing.Point(12, 116);
            this.btAllValue.Name = "btAllValue";
            this.btAllValue.Size = new System.Drawing.Size(87, 27);
            this.btAllValue.TabIndex = 5;
            this.btAllValue.Text = "添加所有值";
            this.btAllValue.Click += new System.EventHandler(this.btAllValue_Click);
            // 
            // btRemoveAll
            // 
            this.btRemoveAll.Location = new System.Drawing.Point(348, 116);
            this.btRemoveAll.Name = "btRemoveAll";
            this.btRemoveAll.Size = new System.Drawing.Size(87, 27);
            this.btRemoveAll.TabIndex = 6;
            this.btRemoveAll.Text = "移除所有值";
            this.btRemoveAll.Click += new System.EventHandler(this.btRemoveAll_Click);
            // 
            // btAddOne
            // 
            this.btAddOne.Location = new System.Drawing.Point(125, 116);
            this.btAddOne.Name = "btAddOne";
            this.btAddOne.Size = new System.Drawing.Size(87, 27);
            this.btAddOne.TabIndex = 7;
            this.btAddOne.Text = "添加值";
            this.btAddOne.Click += new System.EventHandler(this.btAddOne_Click);
            // 
            // btRemoveOne
            // 
            this.btRemoveOne.Location = new System.Drawing.Point(230, 116);
            this.btRemoveOne.Name = "btRemoveOne";
            this.btRemoveOne.Size = new System.Drawing.Size(87, 27);
            this.btRemoveOne.TabIndex = 8;
            this.btRemoveOne.Text = "移除值";
            this.btRemoveOne.Click += new System.EventHandler(this.btRemoveOne_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(138, 494);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(87, 27);
            this.btOK.TabIndex = 9;
            this.btOK.Text = "确定";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(269, 494);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 12;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Visible = false;
            this.gridBand1.VisibleIndex = -1;
            this.gridBand1.Width = 300;
            // 
            // gridBand11
            // 
            this.gridBand11.Caption = "gridBand11";
            this.gridBand11.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand12});
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = -1;
            this.gridBand11.Width = 144;
            // 
            // gridBand12
            // 
            this.gridBand12.Caption = "gridBand15";
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Visible = false;
            this.gridBand12.VisibleIndex = -1;
            this.gridBand12.Width = 144;
            // 
            // gridBand13
            // 
            this.gridBand13.Caption = "gridBand12";
            this.gridBand13.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand14});
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.VisibleIndex = -1;
            this.gridBand13.Width = 110;
            // 
            // gridBand14
            // 
            this.gridBand14.Caption = "gridBand16";
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Visible = false;
            this.gridBand14.VisibleIndex = -1;
            this.gridBand14.Width = 110;
            // 
            // gridBand15
            // 
            this.gridBand15.Caption = "gridBand13";
            this.gridBand15.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand16});
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.VisibleIndex = -1;
            this.gridBand15.Width = 110;
            // 
            // gridBand16
            // 
            this.gridBand16.Caption = "gridBand17";
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.Visible = false;
            this.gridBand16.VisibleIndex = -1;
            this.gridBand16.Width = 110;
            // 
            // gridBand17
            // 
            this.gridBand17.Caption = "gridBand14";
            this.gridBand17.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand18});
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.VisibleIndex = -1;
            this.gridBand17.Width = 75;
            // 
            // gridBand18
            // 
            this.gridBand18.Caption = "gridBand18";
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.Visible = false;
            this.gridBand18.VisibleIndex = -1;
            this.gridBand18.Width = 75;
            // 
            // icbeColorRamp
            // 
            this.icbeColorRamp.Location = new System.Drawing.Point(292, 21);
            this.icbeColorRamp.Name = "icbeColorRamp";
            this.icbeColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeColorRamp.Size = new System.Drawing.Size(174, 20);
            this.icbeColorRamp.TabIndex = 13;
            this.icbeColorRamp.SelectedIndexChanged += new System.EventHandler(this.icbeColorRamp_SelectedIndexChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiGroup),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSplit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSymbolPro),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiMove)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btUp
            // 
            this.btUp.Location = new System.Drawing.Point(446, 217);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(35, 27);
            this.btUp.TabIndex = 14;
            this.btUp.Text = "上移";
            this.btUp.Visible = false;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Location = new System.Drawing.Point(446, 275);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(35, 27);
            this.btDown.TabIndex = 16;
            this.btDown.Text = "下移";
            this.btDown.Visible = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // secondField
            // 
            this.secondField.Location = new System.Drawing.Point(90, 48);
            this.secondField.MenuManager = this.barManager1;
            this.secondField.Name = "secondField";
            this.secondField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.secondField.Size = new System.Drawing.Size(136, 20);
            this.secondField.TabIndex = 21;
            // 
            // thirdField
            // 
            this.thirdField.Location = new System.Drawing.Point(90, 74);
            this.thirdField.MenuManager = this.barManager1;
            this.thirdField.Name = "thirdField";
            this.thirdField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.thirdField.Size = new System.Drawing.Size(136, 20);
            this.thirdField.TabIndex = 22;
            // 
            // UniqueRenderMutliField
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(490, 537);
            this.Controls.Add(this.thirdField);
            this.Controls.Add(this.secondField);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.icbeColorRamp);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btRemoveOne);
            this.Controls.Add(this.btAddOne);
            this.Controls.Add(this.btRemoveAll);
            this.Controls.Add(this.btAllValue);
            this.Controls.Add(this.gcValue);
            this.Controls.Add(this.lbColorRamp);
            this.Controls.Add(this.cbeCartoField);
            this.Controls.Add(this.lbCartoField);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UniqueRenderMutliField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "唯一值渲染";
            this.Load += new System.EventHandler(this.UniqueRenderMutliField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbeCartoField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeColorRamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdField.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = this.advBandedGridView1.GetSelectedRows();
                ArrayList dataSource = this.gcValue.DataSource as ArrayList;
                List<Cartography.Render.Record> list2 = new List<Cartography.Render.Record>();
                List<string> list3 = new List<string>();
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int index = selectedRows[i];
                    if (this.refValues[index] != "-1")
                    {
                        string str = this.refValues[index];
                        if (!this._render.get_Heading(str).Equals(e.Item.Caption))
                        {
                            this._render.set_Heading(str, e.Item.Caption);
                            Cartography.Render.Record item = dataSource[index] as Cartography.Render.Record;
                            string str3 = this.refValues[index];
                            this.refValues.RemoveAt(index);
                            dataSource.RemoveAt(index);
                            list2.Add(item);
                            list3.Add(str3);
                        }
                    }
                }
                int count = this.refValues.Count;
                for (int j = 1; j < count; j++)
                {
                    if (this.refValues[j] == "-1")
                    {
                        Cartography.Render.Record record2 = dataSource[j] as Cartography.Render.Record;
                        if (record2.Label.Equals(e.Item.Caption))
                        {
                            int num5 = j + 1;
                            if (num5 < this.refValues.Count)
                            {
                                if (this.refValues[num5] != "-1")
                                {
                                    num5++;
                                }
                                for (int k = 0; k < list3.Count; k++)
                                {
                                    this.refValues.Insert(num5 + k, list3[k]);
                                    dataSource.Insert(num5 + k, list2[k]);
                                }
                            }
                            else
                            {
                                for (int m = 0; m < list3.Count; m++)
                                {
                                    this.refValues.Add(list3[m]);
                                    dataSource.Add(list2[m]);
                                }
                            }
                        }
                    }
                }
                this.gcValue.RefreshDataSource();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.UniqueRenderMutliField", "item_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void Split(int pSelectedIndex, Cartography.Render.Record pRecord)
        {
            string[] strArray = pRecord.FieldValue.Split(new char[] { ';' });
            string heading = this._render.get_Heading(strArray[0]);
            int index = pSelectedIndex;
            for (int i = pSelectedIndex; i < this.refValues.Count; i++)
            {
                if (this.refValues[i] == "-1")
                {
                    break;
                }
                index++;
            }
            string str2 = strArray[0];
            string label = this._render.get_Label(str2);
            ISymbol pSymbol = this._render.get_Symbol(str2);
            ArrayList dataSource = this.gcValue.DataSource as ArrayList;
            Cartography.Render.Record record = dataSource[pSelectedIndex] as Cartography.Render.Record;
            record.FieldValue = str2;
            Bitmap pImage = BitmapManager.GetSymbolBitMap(pSymbol, this.bgcDefBitmap.Width, 30);
            for (int j = 1; j < strArray.Length; j++)
            {
                string str4 = strArray[j];
                this._render.RemoveValue(str4);
                this._render.AddValue(str4, heading, pSymbol);
                this._render.set_Label(str4, label);
                if (index < this.refValues.Count)
                {
                    this.refValues.Insert(index, str4);
                    dataSource.Insert(index, new Cartography.Render.Record(null, pImage, str4, label, null));
                }
                else
                {
                    this.refValues.Add(str4);
                    dataSource.Add(new Cartography.Render.Record(null, pImage, str4, label, null));
                }
                index++;
            }
            this.gcValue.RefreshDataSource();
        }

        private void UniqueRenderMutliField_Load(object sender, EventArgs e)
        {
        }
    }
}

