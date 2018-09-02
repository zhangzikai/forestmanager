namespace AttributesEdit
{
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlAttributesEdit : UserControlBase1
    {
        private SimpleButton btnCancel;
        private SimpleButton btnCut;
        private SimpleButton btnOK;
        private ComboBoxEdit comboBoxCut;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private LabelControl labelControl1;
        private LabelControl labelControl3;
        private LabelControl labelMessage;
        private bool m_bBoldField = true;
        private bool m_bSubmit;
        private const string m_ClassName = "AttributesEdit.UserControlAttributesEdit";
        private IList<IFeature> m_CutFeatures;
        private string[] m_DayFields = AttriEdit.DateFields;
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IHookHelper m_hookHelper;
        private IList<string> m_NNListFields;
        private IObject m_Object;
        private VertXtraGrid m_pVertXtraGrid;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private string[] m_YbdFields = AttriEdit.YBDFields;
        private PanelControl panelControl2;
        private PanelControl panelCut;
        private PanelControl panelSubmit;
        private TextEdit textSubCode;

        public UserControlAttributesEdit()
        {
            this.InitializeComponent();
            this.panelCut.Visible = false;
            this.panelSubmit.Visible = false;
            this.gridControl1.Visible = false;
            this.m_bSubmit = false;
            this.btnOK.Enabled = false;
            this.m_pVertXtraGrid = null;
            this.m_pVertXtraGrid = new VertXtraGrid(this.gridControl1);
            this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomDrawCell += new RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridControl1.KeyPress += new KeyPressEventHandler(this.gridControl1_KeyPress);
        }

        public void AddAttributes(IFeature pFeature, object pHook)
        {
            try
            {
                base.Visible = true;
                this.labelMessage.Text = "";
                this.gridControl1.Visible = false;
                this.panelCut.Visible = false;
                if (pFeature == null)
                {
                    this.m_pVertXtraGrid.Clear();
                }
                else
                {
                    if (this.m_hookHelper == null)
                    {
                        this.m_hookHelper = new HookHelperClass();
                    }
                    this.m_hookHelper.Hook = pHook;
                    this.AddFeature(pFeature);
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "EditAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddFeature(IFeature pFeature)
        {
            this.m_Object = pFeature;
            this.InitGridControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelMessage.Text = "";
                string str = "变化原因";
                GridEditorItem item = null;
                int rowCount = this.gridView1.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    GridEditorItem row = this.gridView1.GetRow(i) as GridEditorItem;
                    if (row.Name == str)
                    {
                        item = row;
                        break;
                    }
                }
                if (item != null)
                {
                    object obj2 = item.Value;
                    string str2 = "";
                    if (obj2 != null)
                    {
                        str2 = item.Value.ToString();
                    }
                    if (str2.Replace(" ", "") == "")
                    {
                        XtraMessageBox.Show(this, "保存失败，请选择变化原因再保存！", "属性编辑");
                        return;
                    }
                }
                bool flag = false;
                if (this.UpdateAllFieldValue())
                {
                    flag = true;
                }
                IFeatureLayer editLayer = EditTask.EditLayer;
                IFeatureClass featureClass = editLayer.FeatureClass;
                if ((featureClass != null) && (featureClass.ShapeType != esriGeometryType.esriGeometryPolyline))
                {
                    string text = CheckAttributes.CheckFeatureAttr(editLayer, (IFeature) this.m_Object);
                    if (text != "")
                    {
                        XtraMessageBox.Show(text, "属性录入提示");
                    }
                }
                if (flag)
                {
                    this.labelMessage.Text = "保存成功！";
                }
                else
                {
                    this.labelMessage.Text = "保存失败！";
                }
                this.m_bSubmit = false;
                this.btnOK.Enabled = false;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "btnOK_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "提交属性");
                this.labelMessage.Text = "保存失败！";
            }
        }

        private void ChangeDist(string sFieldName, object value)
        {
            if (value != null)
            {
                string str = value.ToString();
                string sName = "SHENG";
                string str3 = "SHI";
                string str4 = "XIAN";
                string str5 = "XIANG";
                string str6 = "CUN";
                if (sFieldName == sName)
                {
                    GridEditorItem itemByFieldName = this.GetItemByFieldName(sName);
                    GridEditorItem item = this.GetItemByFieldName(str3);
                    this.ClearDist(item, true);
                    GridEditorItem item3 = this.GetItemByFieldName(str4);
                    this.ClearDist(item3, true);
                    GridEditorItem item4 = this.GetItemByFieldName(str5);
                    this.ClearDist(item4, true);
                    GridEditorItem item5 = this.GetItemByFieldName(str6);
                    this.ClearDist(item5, true);
                    if (str != "<空>")
                    {
                        string selectedCode = this.GetSelectedCode(itemByFieldName);
                        if (selectedCode != "")
                        {
                            this.FilterComboBox(item, selectedCode, "<空>");
                        }
                    }
                }
                else if (sFieldName == str3)
                {
                    GridEditorItem pItem = this.GetItemByFieldName(str3);
                    GridEditorItem item7 = this.GetItemByFieldName(str4);
                    this.ClearDist(item7, true);
                    GridEditorItem item8 = this.GetItemByFieldName(str5);
                    this.ClearDist(item8, true);
                    GridEditorItem item9 = this.GetItemByFieldName(str6);
                    this.ClearDist(item9, true);
                    if (str != "<空>")
                    {
                        string sLastValue = this.GetSelectedCode(pItem);
                        if (sLastValue != "")
                        {
                            this.FilterComboBox(item7, sLastValue, "<空>");
                        }
                    }
                }
                else if (sFieldName == str4)
                {
                    GridEditorItem item10 = this.GetItemByFieldName(str4);
                    GridEditorItem item11 = this.GetItemByFieldName(str5);
                    this.ClearDist(item11, true);
                    GridEditorItem item12 = this.GetItemByFieldName(str6);
                    this.ClearDist(item12, true);
                    if (str != "<空>")
                    {
                        string str9 = this.GetSelectedCode(item10);
                        if (str9 != "")
                        {
                            this.FilterComboBox(item11, str9, "<空>");
                        }
                    }
                }
                else if (sFieldName == str5)
                {
                    GridEditorItem item13 = this.GetItemByFieldName(str5);
                    GridEditorItem item14 = this.GetItemByFieldName(str6);
                    this.ClearDist(item14, true);
                    if (str != "<空>")
                    {
                        string str10 = this.GetSelectedCode(item13);
                        if (str10 != "")
                        {
                            this.FilterComboBox(item14, str10, "<空>");
                        }
                    }
                }
            }
        }

        private void ClearDist(GridEditorItem item, bool bInitValue)
        {
            ((ZLRepositoryItemComboBox) item.RepositoryItem).ClearCombobox();
            item.Value = "<空>";
        }

        public void CombineAttributes(IList<IFeature> pList, IFeature pNewFeature, int index, object pHook)
        {
            if (pNewFeature == null)
            {
                this.gridControl1.Visible = false;
                this.btnOK.Enabled = false;
            }
            else if (index >= 0)
            {
                try
                {
                    this.labelMessage.Text = "";
                    this.gridControl1.Visible = false;
                    this.panelCut.Visible = false;
                    int count = pList.Count;
                    if (index != count)
                    {
                        IFeature pSrcObj = pList[index];
                        this.CopyGeoObject(pSrcObj, pNewFeature);
                    }
                    this.SetCombineFeatureArea(pNewFeature, pList);
                    this.EditFeature(pNewFeature);
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "MergeAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void comboBoxCut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.m_hookHelper != null) && (this.m_hookHelper.Hook != null))
            {
                int selectedIndex = this.comboBoxCut.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0:
                    case 1:
                    {
                        IFeature pFeature = this.m_CutFeatures[selectedIndex];
                        IMap focusMap = this.m_hookHelper.FocusMap;
                        GISFunFactory.FlashFun.FlashFeature(focusMap, pFeature, 0L, false);
                        break;
                    }
                }
            }
        }

        private double ConvertToDouble(object obj)
        {
            if (obj == null)
            {
                return 0.0;
            }
            try
            {
                return Convert.ToDouble(obj.ToString());
            }
            catch
            {
                return 0.0;
            }
        }

        public void CopyGeoObject(IObject pSrcObj, IObject pTargObj)
        {
            if ((pSrcObj != null) && (pTargObj != null))
            {
                string nodeValue = this.GetNodeValue("AreaField");
                string str2 = this.GetNodeValue("ZTAreaField");
                string sFieldName = "";
                IFields fields = pTargObj.Fields;
                try
                {
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if (((field.Type != esriFieldType.esriFieldTypeGeometry) && ((EditTask.KindCode.Substring(0, 2) == "06") || (field.Name != nodeValue))) && ((field.Name != str2) && field.Editable))
                        {
                            sFieldName = field.Name;
                            object fieldValue = DataFuncs.GetFieldValue(pSrcObj, sFieldName);
                            pTargObj.set_Value(i, fieldValue);
                        }
                    }
                    pTargObj.Store();
                }
                catch
                {
                }
            }
        }

        private void Cut()
        {
            if (this.m_CutFeatures != null)
            {
                try
                {
                    int selectedIndex = this.comboBoxCut.SelectedIndex;
                    if (selectedIndex >= 0)
                    {
                        IFeature feature = this.m_CutFeatures[selectedIndex];
                        if (feature != null)
                        {
                            IActiveView activeView = this.m_hookHelper.ActiveView;
                            IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                            editLayer.Clear();
                            if (feature != null)
                            {
                                editLayer.Add(feature);
                            }
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection | esriViewDrawPhase.esriViewGeography, null, null);
                            this.m_Object = feature;
                            this.InitGridControl();
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void CutFeature(IList<IFeature> pList, object pHook)
        {
            try
            {
                this.labelMessage.Text = "";
                this.gridControl1.Visible = false;
                this.panelCut.Visible = true;
                this.panelSubmit.Visible = false;
                this.m_pVertXtraGrid.Clear();
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = pHook;
                this.m_CutFeatures = pList;
                this.InitCutFeature();
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "CutAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public bool DeleteFeatures(IList pList)
        {
            if (this.m_Object != null)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    IFeature feature = pList[i] as IFeature;
                    if (feature.OID == this.m_Object.OID)
                    {
                        this.gridControl1.Visible = false;
                        this.panelCut.Visible = false;
                        this.panelSubmit.Visible = false;
                        break;
                    }
                }
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void EditAttributes(IFeature pFeature, object pHook)
        {
            try
            {
                this.labelMessage.Text = "";
                this.gridControl1.Visible = false;
                this.panelCut.Visible = false;
                if (pFeature == null)
                {
                    this.m_pVertXtraGrid.Clear();
                }
                else
                {
                    if (this.m_hookHelper == null)
                    {
                        this.m_hookHelper = new HookHelperClass();
                    }
                    this.m_hookHelper.Hook = pHook;
                    this.EditFeature(pFeature);
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "EditAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void EditFeature(IFeature pFeature)
        {
            this.m_Object = pFeature;
            this.InitGridControl();
        }

        private void FilterComboBox(GridEditorItem item, string sLastValue)
        {
            ((ZLRepositoryItemComboBox) item.RepositoryItem).Filter(sLastValue);
        }

        private void FilterComboBox(GridEditorItem item, string sLastValue, object pValue)
        {
            item.Value = pValue;
            ZLRepositoryItemComboBox repositoryItem = (ZLRepositoryItemComboBox) item.RepositoryItem;
            repositoryItem.SelectedValue = DBNull.Value;
            repositoryItem.Filter(sLastValue);
        }

        private void FocusControl(int index)
        {
            if (index == this.gridView1.RowCount)
            {
                index = 0;
            }
            GridEditorItem row = this.gridView1.GetRow(index) as GridEditorItem;
            if (row != null)
            {
                if (row.RepositoryItem.ReadOnly)
                {
                    this.FocusControl(index + 1);
                }
                else
                {
                    this.gridView1.FocusedRowHandle = index;
                }
            }
        }

        private GridEditorItem GetItemByAliasName(string sName)
        {
            int rowCount = this.gridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                GridEditorItem row = this.gridView1.GetRow(i) as GridEditorItem;
                if (row.Name == sName)
                {
                    return row;
                }
            }
            return null;
        }

        private GridEditorItem GetItemByFieldName(string sName)
        {
            int rowCount = this.gridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                GridEditorItem row = this.gridView1.GetRow(i) as GridEditorItem;
                if (row.Tag.ToString() == sName)
                {
                    return row;
                }
            }
            return null;
        }

        private string GetNodeValue(string sNode)
        {
            string name = "";
            string str2 = EditTask.KindCode.Substring(0, 2);
            if (str2 == "01")
            {
                name = "Afforest";
            }
            else if (str2 == "02")
            {
                name = "Harvest";
            }
            else if (str2 == "06")
            {
                name = "Disaster";
            }
            else if (str2 != "04")
            {
                if (str2 == "05")
                {
                    name = "Fire";
                }
                else if (str2 == "08")
                {
                    name = "Sub";
                }
                else if (str2 == "07")
                {
                    name = "ForestCase";
                }
                else
                {
                    name = "Other";
                }
            }
            return UtilFactory.GetConfigOpt().GetConfigValue2(name, sNode);
        }

        private IList<string> GetNotNullFields()
        {
            string sql = "";
            string str2 = EditTask.KindCode.Substring(0, 2);
            string str3 = "T_Logic_Check";
            sql = "select * from " + str3 + " where design_kind like '" + str2 + "%' and enabled=true order by CHECK_ID,ID";
       //     IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
            DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
            if ((dataTable == null) || (dataTable.Rows.Count < 1))
            {
                return null;
            }
            IList<string> list = null;
            DataRow[] rowArray = dataTable.Select("CHECK_TYPE='NOTNULL'");
            if (rowArray.Length > 0)
            {
                list = new List<string>();
                for (int i = 0; i < rowArray.Length; i++)
                {
                    string item = rowArray[i]["FIELD_ALIAS"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        private string GetSelectedCode(GridEditorItem pItem)
        {
            ZLRepositoryItemComboBox repositoryItem = (ZLRepositoryItemComboBox) pItem.RepositoryItem;
            object selectedValue = repositoryItem.SelectedValue;
            if (selectedValue == DBNull.Value)
            {
                return "";
            }
            return selectedValue.ToString();
        }

        private string GetShapeString(IField pField)
        {
            string str = "";
            IGeometryDef geometryDef = pField.GeometryDef;
            if (geometryDef != null)
            {
                switch (geometryDef.GeometryType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        str = "点";
                        break;

                    case esriGeometryType.esriGeometryMultipoint:
                        str = "多点";
                        break;

                    case esriGeometryType.esriGeometryPolyline:
                        str = "线";
                        break;

                    case esriGeometryType.esriGeometryPolygon:
                        str = "多边形";
                        break;

                    case esriGeometryType.esriGeometryMultiPatch:
                        str = "多面";
                        break;
                }
                str = str + " ";
                if (geometryDef.HasZ)
                {
                    str = str + "Z";
                }
                if (geometryDef.HasM)
                {
                    str = str + "M";
                }
            }
            return str;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int index = this.gridView1.FocusedRowHandle + 1;
                this.FocusControl(index);
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!this.m_bSubmit)
            {
                this.m_bSubmit = true;
                this.btnOK.Enabled = true;
            }
            GridEditorItem row = this.gridView1.GetRow(e.RowHandle) as GridEditorItem;
            if (row.Name == "森林类别")
            {
                if (this.GetItemByAliasName("前期森林类别").Value.ToString() == row.Value.ToString())
                {
                    this.labelMessage.Text = "";
                }
                else
                {
                    this.labelMessage.Text = "森林类别已改变！";
                }
            }
            this.ChangeDist(row.Tag.ToString(), row.Value);
            this.gridControl1.RefreshDataSource();
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if ((this.m_bBoldField && (e.Column.ColumnHandle == 0)) && (this.m_NNListFields != null))
            {
                string item = e.CellValue.ToString();
                if (this.m_NNListFields.Contains(item))
                {
                    Font prototype = e.Appearance.Font;
                    e.Appearance.Font = new Font(prototype, FontStyle.Bold);
                }
            }
        }

        private void InitCutFeature()
        {
            if (this.m_CutFeatures != null)
            {
                this.comboBoxCut.Properties.Items.Clear();
                string str = "";
                int count = this.m_CutFeatures.Count;
                IFeature pSrcObj = this.m_CutFeatures[count - 1];
                if (pSrcObj != null)
                {
                    str = pSrcObj.OID.ToString();
                }
                for (int i = 0; i < (count - 1); i++)
                {
                    IFeature pFeature = this.m_CutFeatures[i];
                    if (pSrcObj == null)
                    {
                        this.SetAttributesBySub(pFeature);
                    }
                    else
                    {
                        this.CopyGeoObject(pSrcObj, pFeature);
                    }
                    AttriEdit.SetFeatureArea(pFeature, EditTask.KindCode.Substring(0, 2), this.m_hookHelper.FocusMap.SpatialReference);
                    pFeature.Store();
                    if (str != "")
                    {
                        int num4 = i + 1;
                        this.comboBoxCut.Properties.Items.Add(str + "_" + num4.ToString());
                    }
                    else
                    {
                        this.comboBoxCut.Properties.Items.Add(pFeature.OID.ToString());
                    }
                }
                this.comboBoxCut.SelectedIndex = 0;
            }
        }

        private void InitDist()
        {
            string sName = "SHI";
            string str2 = "XIAN";
            string str3 = "XIANG";
            string str4 = "CUN";
            GridEditorItem itemByFieldName = this.GetItemByFieldName(sName);
            itemByFieldName.Value.ToString();
            string selectedCode = this.GetSelectedCode(itemByFieldName);
            if (selectedCode != "")
            {
                this.FilterComboBox(itemByFieldName, selectedCode.Substring(0, 2));
            }
            else
            {
                this.FilterComboBox(itemByFieldName, "");
            }
            GridEditorItem pItem = this.GetItemByFieldName(str2);
            pItem.Value.ToString();
            string str6 = this.GetSelectedCode(pItem);
            if (str6 != "")
            {
                this.FilterComboBox(pItem, str6.Substring(0, 4));
            }
            else
            {
                this.FilterComboBox(pItem, "");
            }
            GridEditorItem item3 = this.GetItemByFieldName(str3);
            item3.Value.ToString();
            string str7 = this.GetSelectedCode(item3);
            if (str7 != "")
            {
                this.FilterComboBox(item3, str7.Substring(0, 6));
            }
            else
            {
                this.FilterComboBox(item3, "");
            }
            GridEditorItem item4 = this.GetItemByFieldName(str4);
            item4.Value.ToString();
            string str8 = this.GetSelectedCode(item4);
            if (str8 != "")
            {
                this.FilterComboBox(item4, str8.Substring(0, 9));
            }
            else
            {
                this.FilterComboBox(item4, "");
            }
        }

        private void InitGridControl()
        {
            if (this.m_Object != null)
            {
                this.panelSubmit.Visible = true;
                this.SetGridControl();
            //    this.InitDist();
                this.gridControl1.RefreshDataSource();
            }
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textSubCode = new DevExpress.XtraEditors.TextEdit();
            this.panelSubmit = new DevExpress.XtraEditors.PanelControl();
            this.labelMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxCut = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCut = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelCut = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSubCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSubmit)).BeginInit();
            this.panelSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCut)).BeginInit();
            this.panelCut.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 87);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(313, 684);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.textSubCode);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(313, 40);
            this.panelControl2.TabIndex = 2;
            this.panelControl2.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "小班编码";
            // 
            // textSubCode
            // 
            this.textSubCode.Location = new System.Drawing.Point(89, 7);
            this.textSubCode.Name = "textSubCode";
            this.textSubCode.Size = new System.Drawing.Size(166, 20);
            this.textSubCode.TabIndex = 0;
            // 
            // panelSubmit
            // 
            this.panelSubmit.Controls.Add(this.labelMessage);
            this.panelSubmit.Controls.Add(this.btnCancel);
            this.panelSubmit.Controls.Add(this.btnOK);
            this.panelSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSubmit.Location = new System.Drawing.Point(0, 771);
            this.panelSubmit.Name = "panelSubmit";
            this.panelSubmit.Padding = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.panelSubmit.Size = new System.Drawing.Size(313, 37);
            this.panelSubmit.TabIndex = 3;
            // 
            // labelMessage
            // 
            this.labelMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Location = new System.Drawing.Point(5, 15);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 14);
            this.labelMessage.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(219, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 27);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // comboBoxCut
            // 
            this.comboBoxCut.Location = new System.Drawing.Point(89, 12);
            this.comboBoxCut.Name = "comboBoxCut";
            this.comboBoxCut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCut.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCut.Size = new System.Drawing.Size(106, 20);
            this.comboBoxCut.TabIndex = 1;
            this.comboBoxCut.SelectedIndexChanged += new System.EventHandler(this.comboBoxCut_SelectedIndexChanged);
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(236, 13);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(65, 27);
            this.btnCut.TabIndex = 2;
            this.btnCut.Text = "确定";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "小班";
            // 
            // panelCut
            // 
            this.panelCut.Controls.Add(this.labelControl3);
            this.panelCut.Controls.Add(this.btnCut);
            this.panelCut.Controls.Add(this.comboBoxCut);
            this.panelCut.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCut.Location = new System.Drawing.Point(0, 0);
            this.panelCut.Name = "panelCut";
            this.panelCut.Size = new System.Drawing.Size(313, 47);
            this.panelCut.TabIndex = 4;
            this.panelCut.VisibleChanged += new System.EventHandler(this.panelCut_VisibleChanged);
            // 
            // UserControlAttributesEdit
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelSubmit);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelCut);
            this.Name = "UserControlAttributesEdit";
            this.Size = new System.Drawing.Size(313, 808);
            this.SizeChanged += new System.EventHandler(this.UserControlAttributesEdit_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSubCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSubmit)).EndInit();
            this.panelSubmit.ResumeLayout(false);
            this.panelSubmit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCut)).EndInit();
            this.panelCut.ResumeLayout(false);
            this.panelCut.PerformLayout();
            this.ResumeLayout(false);

        }

        private void panelCut_VisibleChanged(object sender, EventArgs e)
        {
        }

        public void SetAttributes()
        {
        }

        private void SetAttributesBySub(IFeature pFeature)
        {
            if (pFeature != null)
            {
                IGeometry shapeCopy = pFeature.ShapeCopy;
                try
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    if (configValue != "")
                    {
                        IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.FocusMap as IBasicMap, configValue, true);
                        if (layer != null)
                        {
                            IFeatureClass featureClass = layer.FeatureClass;
                            ISpatialFilter queryFilter = new SpatialFilterClass {
                                Geometry = shapeCopy,
                                GeometryField = featureClass.ShapeFieldName,
                                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
                            };
                            IFeatureCursor o = layer.Search(queryFilter, false);
                            if (o != null)
                            {
                                IFeature pObj = o.NextFeature();
                                if (pObj != null)
                                {
                                    string nodeValue = this.GetNodeValue("AreaField");
                                    string str3 = this.GetNodeValue("ZTAreaField");
                                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                                    {
                                        for (int i = 0; i < pFeature.Fields.FieldCount; i++)
                                        {
                                            IField field = pFeature.Fields.get_Field(i);
                                            if ((field.Editable && (field.Type != esriFieldType.esriFieldTypeGeometry)) && ((field.Name != nodeValue) && (field.Name != str3)))
                                            {
                                                string name = field.Name;
                                                if (name.IndexOf("Q_") == 0)
                                                {
                                                    name = name.Substring(2);
                                                }
                                                object fieldValue = DataFuncs.GetFieldValue(pObj, name);
                                                if (fieldValue != null)
                                                {
                                                    pFeature.set_Value(i, fieldValue);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        double num2 = 0.0;
                                        IFeature feature2 = null;
                                        int num3 = 0;
                                        while (pObj != null)
                                        {
                                            if (num3 == 50)
                                            {
                                                break;
                                            }
                                            IGeometry geometry2 = @operator.Intersect(pObj.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                                            if (geometry2.IsEmpty)
                                            {
                                                pObj = o.NextFeature();
                                            }
                                            else
                                            {
                                                IArea area = geometry2 as IArea;
                                                double num4 = area.Area;
                                                if (num4 > num2)
                                                {
                                                    num2 = num4;
                                                    feature2 = pObj;
                                                }
                                                pObj = o.NextFeature();
                                            }
                                        }
                                        Marshal.ReleaseComObject(o);
                                        for (int j = 0; j < pFeature.Fields.FieldCount; j++)
                                        {
                                            IField field2 = pFeature.Fields.get_Field(j);
                                            if ((field2.Editable && (field2.Type != esriFieldType.esriFieldTypeGeometry)) && ((field2.Name != nodeValue) && (field2.Name != str3)))
                                            {
                                                string sFieldName = field2.Name;
                                                if (sFieldName.IndexOf("Q_") == 0)
                                                {
                                                    sFieldName = sFieldName.Substring(2);
                                                }
                                                object obj3 = DataFuncs.GetFieldValue(feature2, sFieldName);
                                                if (obj3 != null)
                                                {
                                                    pFeature.set_Value(j, obj3);
                                                }
                                            }
                                        }
                                    }
                                    pFeature.Store();
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void SetCombineFeatureArea(IFeature pNewFeature, IList<IFeature> pFeatureList)
        {
            if (pNewFeature != null)
            {
                AttriEdit.SetFeatureArea(pNewFeature, EditTask.KindCode.Substring(0, 2), this.m_hookHelper.FocusMap.SpatialReference);
            }
        }

        private void SetGridControl()
        {
            try
            {
                if (this.m_bBoldField)
                {
                    this.m_NNListFields = this.GetNotNullFields();
                }
                this.m_pVertXtraGrid.Clear();
                string nodeValue = this.GetNodeValue("AreaField");
                string sZTAreaField = this.GetNodeValue("ZTAreaField");
                IFields fields = this.m_Object.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                    {
                        this.ShowFieldValue(i, nodeValue, sZTAreaField);
                    }
                }
                this.gridControl1.Visible = true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "SetGridControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetPageVisible()
        {
            XtraTabPage parent = base.Parent as XtraTabPage;
            if (parent != null)
            {
                parent.PageVisible = true;
                XtraTabControl tabControl = parent.TabControl;
                if (tabControl != null)
                {
                    tabControl.SelectedTabPage = parent;
                    ControlContainer container = tabControl.Parent as ControlContainer;
                    if (container != null)
                    {
                        DockPanel panel = container.Parent as DockPanel;
                        if (panel != null)
                        {
                            panel.Visibility = DockVisibility.Visible;
                        }
                    }
                }
            }
        }

        private void ShowBHYY(IField pField, string sValue, bool bReadOnly)
        {
            string nodeValue = this.GetNodeValue("BHDomain");
            if (nodeValue != "")
            {
                string[] source = nodeValue.Split(new char[] { ',' });
                IDomain domain = pField.Domain;
                if ((domain != null) && (domain is ICodedValueDomain))
                {
                    IList nameList = new ArrayList();
                    IList valueList = new ArrayList();
                    ICodedValueDomain domain2 = domain as ICodedValueDomain;
                    if (pField.IsNullable)
                    {
                        nameList.Add("<空>");
                        if ((sValue.Trim() == "") || (sValue == "<null>"))
                        {
                            sValue = "<空>";
                        }
                        valueList.Add(DBNull.Value);
                    }
                    for (int i = 0; i < domain2.CodeCount; i++)
                    {
                        string str2 = domain2.get_Value(i).ToString();
                        if (source.Contains<string>(str2))
                        {
                            nameList.Add(domain2.get_Name(i));
                            valueList.Add(str2);
                            if (sValue == str2)
                            {
                                sValue = domain2.get_Name(i);
                            }
                        }
                    }
                    this.m_pVertXtraGrid.AddComBoBox(pField.AliasName, sValue, nameList, valueList, bReadOnly, pField.Name, null);
                }
            }
        }

        private void ShowFieldValue(int iFieldIndex, string sAreaField, string sZTAreaField)
        {
            IField pField = this.m_Object.Fields.get_Field(iFieldIndex);
            string aliasName = pField.AliasName;
            object columnValue = this.m_Object.get_Value(iFieldIndex);
            string sValue = columnValue.ToString();
            bool readOnly = !pField.Editable;
            if (this.m_DayFields.Contains<string>(pField.Name))
            {
                string str3 = columnValue.ToString();
                if ((str3 == "") || (str3.Length < 8))
                {
                    this.m_pVertXtraGrid.AddDateEdit(aliasName, null, readOnly, pField.Name);
                }
                else
                {
                    DateTime time = Convert.ToDateTime(str3.Substring(0, 4) + "/" + str3.Substring(4, 2) + "/" + str3.Substring(6, 2));
                    this.m_pVertXtraGrid.AddDateEdit(aliasName, time, readOnly, pField.Name);
                }
            }
            else if (pField.Name == "BHYY")
            {
                this.ShowBHYY(pField, sValue, false);
            }
            else
            {
                IObjectClass class1 = this.m_Object.Class;
                IDomain domain = null;
                ICodedValueDomain domain2 = null;
                IList nameList = new ArrayList();
                IList valueList = new ArrayList();
                if (pField.Type == esriFieldType.esriFieldTypeBlob)
                {
                    sValue = "<二进制数据>";
                    this.m_pVertXtraGrid.AddTextEdit(aliasName, sValue, true, pField.Name, -1);
                }
                else
                {
                    domain = pField.Domain;
                    if (domain != null)
                    {
                        if (domain is ICodedValueDomain)
                        {
                            domain2 = domain as ICodedValueDomain;
                            if (pField.IsNullable)
                            {
                                nameList.Add("<空>");
                                valueList.Add(DBNull.Value);
                                switch (sValue)
                                {
                                    case "":
                                    case "<null>":
                                        sValue = "<空>";
                                        break;
                                }
                            }
                            for (int i = 0; i < domain2.CodeCount; i++)
                            {
                                nameList.Add(domain2.get_Name(i));
                                valueList.Add(domain2.get_Value(i));
                                if (sValue == domain2.get_Value(i).ToString())
                                {
                                    sValue = domain2.get_Name(i);
                                }
                            }
                            string name = pField.Name;
                            string[] readonlyItems = AttriEdit.GetReadonlyItems(pField);
                            this.m_pVertXtraGrid.AddComBoBox(aliasName, sValue, nameList, valueList, readOnly, pField.Name, readonlyItems);
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                        {
                            double minValue = 0.0;
                            double maxValue = 0.0;
                            if (domain is IRangeDomain)
                            {
                                minValue = (double) (domain as IRangeDomain).MinValue;
                                maxValue = (double) (domain as IRangeDomain).MaxValue;
                            }
                            if (!readOnly)
                            {
                                this.m_pVertXtraGrid.AddSpinEdit(aliasName, columnValue, readOnly, minValue, maxValue, true, pField.Scale, pField.Name);
                            }
                            else
                            {
                                this.m_pVertXtraGrid.AddTextEdit(aliasName, columnValue, readOnly, pField.Name, -1);
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                        {
                            double num4 = 0.0;
                            double num5 = 0.0;
                            if (domain is IRangeDomain)
                            {
                                num4 = (double) (domain as IRangeDomain).MinValue;
                                num5 = (double) (domain as IRangeDomain).MaxValue;
                            }
                            if (!readOnly)
                            {
                                this.m_pVertXtraGrid.AddSpinEdit(aliasName, columnValue, readOnly, num4, num5, false, 0, pField.Name);
                            }
                            else
                            {
                                this.m_pVertXtraGrid.AddTextEdit(aliasName, columnValue, readOnly, pField.Name, -1);
                            }
                        }
                        else if (pField.Type == esriFieldType.esriFieldTypeDate)
                        {
                            this.m_pVertXtraGrid.AddDateEdit(aliasName, columnValue, readOnly, pField.Name);
                        }
                        else
                        {
                            this.m_pVertXtraGrid.AddTextEdit(aliasName, sValue, readOnly, pField.Name, -1);
                        }
                    }
                    else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                    {
                        if (!readOnly)
                        {
                            if (this.m_YbdFields.Contains<string>(pField.Name))
                            {
                                this.m_pVertXtraGrid.AddSpinEdit(aliasName, columnValue, readOnly, 0.0, 1.0, true, pField.Scale, pField.Name);
                            }
                            else
                            {
                                this.m_pVertXtraGrid.AddSpinEdit(aliasName, columnValue, readOnly, 0.0, 0.0, true, pField.Scale, pField.Name);
                            }
                        }
                        else
                        {
                            this.m_pVertXtraGrid.AddTextEdit(aliasName, columnValue, readOnly, pField.Name, -1);
                        }
                    }
                    else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                    {
                        if (!readOnly)
                        {
                            this.m_pVertXtraGrid.AddSpinEdit(aliasName, columnValue, readOnly, 0.0, 0.0, false, 0, pField.Name);
                        }
                        else
                        {
                            this.m_pVertXtraGrid.AddTextEdit(aliasName, columnValue, readOnly, pField.Name, -1);
                        }
                    }
                    else if (pField.Type == esriFieldType.esriFieldTypeDate)
                    {
                        this.m_pVertXtraGrid.AddDateEdit(aliasName, columnValue, readOnly, pField.Name);
                    }
                    else
                    {
                        this.m_pVertXtraGrid.AddTextEdit(aliasName, columnValue, readOnly, pField.Name, pField.Length);
                    }
                }
            }
        }

        public void Undo()
        {
            this.gridControl1.Visible = false;
            this.panelCut.Visible = false;
            this.panelSubmit.Visible = false;
        }

        private bool UpdateAllFieldValue()
        {
            try
            {
                Editor.UniqueInstance.StartEditOperation();
                int rowCount = this.gridView1.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    this.UpdateCellValue(i);
                }
                this.m_Object.Store();
                Editor.UniqueInstance.StopEditOperation();
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttributesEdit", "UpdateAllFieldValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void UpdateCellValue(int index)
        {
            try
            {
                int rowHandle = index;
                ISubtypes subtypes = this.m_Object.Class as ISubtypes;
                GridEditorItem row = this.gridView1.GetRow(rowHandle) as GridEditorItem;
                object selectedValue = null;
                if (row.RepositoryItem is RepositoryItemComboBox)
                {
                    ZLRepositoryItemComboBox repositoryItem = (ZLRepositoryItemComboBox) row.RepositoryItem;
                    selectedValue = repositoryItem.SelectedValue;
                }
                else
                {
                    selectedValue = row.Value;
                }
                string str = "";
                if (selectedValue != null)
                {
                    str = selectedValue.ToString();
                }
                int num2 = this.m_Object.Fields.FindFieldByAliasName(row.Name);
                IField pField = this.m_Object.Fields.get_Field(num2);
                if (pField.Editable && (pField.Type != esriFieldType.esriFieldTypeGeometry))
                {
                    object obj2;
                    if ((subtypes != null) && subtypes.HasSubtype)
                    {
                        if (subtypes.SubtypeFieldName == pField.Name)
                        {
                            IEnumSubtype subtype = subtypes.Subtypes;
                            subtype.Reset();
                            int subtypeCode = 0;
                            for (string str2 = subtype.Next(out subtypeCode); str2 != null; str2 = subtype.Next(out subtypeCode))
                            {
                                if (str.ToString() == str2)
                                {
                                    this.UpdateFieldValue(pField, subtypeCode);
                                    return;
                                }
                            }
                        }
                        else if (str.ToString() == "<空>")
                        {
                            obj2 = DBNull.Value;
                            this.UpdateFieldValue(pField, obj2);
                        }
                        else
                        {
                            this.UpdateFieldValue(pField, str);
                        }
                    }
                    else if (str.ToString() == "<空>")
                    {
                        obj2 = DBNull.Value;
                        this.UpdateFieldValue(pField, obj2);
                    }
                    else if (str.ToString() == "")
                    {
                        obj2 = DBNull.Value;
                        this.UpdateFieldValue(pField, obj2);
                    }
                    else
                    {
                        this.UpdateFieldValue(pField, str);
                    }
                }
            }
            catch
            {
            }
        }

        private bool UpdateFieldValue(IField pField, object str)
        {
            bool flag = false;
            try
            {
                object obj2 = DBNull.Value;
                if (this.m_DayFields.Contains<string>(pField.Name))
                {
                    if (str.ToString() != "")
                    {
                        obj2 = Convert.ToDateTime(str.ToString()).ToString("yyyyMMdd");
                    }
                }
                else
                {
                    obj2 = str;
                }
                int index = this.m_Object.Fields.FindField(pField.Name);
                if (index > 0)
                {
                    this.m_Object.set_Value(index, obj2);
                }
                flag = true;
            }
            catch
            {
                XtraMessageBox.Show(this, "输入数据格式错误", "提示");
            }
            return flag;
        }

        private void UserControlAttributesEdit_SizeChanged(object sender, EventArgs e)
        {
            if (this.panelCut.Visible)
            {
                this.gridControl1.Height = (base.Height - this.panelCut.Height) - this.panelSubmit.Height;
            }
            else
            {
                this.gridControl1.Height = base.Height - this.panelSubmit.Height;
            }
        }
    }
}

