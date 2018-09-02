namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
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

    /// <summary>
    /// 编辑造林设计调查表窗体：用户自定义窗体
    /// </summary>
    public class UserControlAttrEdit : UserControlBase1
    {
        private SimpleButton btnCut;
        private SimpleButton btnSubmit;
        private ComboBoxEdit comboBoxCut;
        private IContainer components;
        private LabelControl labelSubmit;
        private bool m_bBoldField = true;
        private string m_City = "";
        private string m_Cnty;
        private IList<IFeature> m_CutFeatures;
        private string[] m_DayFields = AttriEdit.DateFields;
        private IFeature m_EditFeature;
        private IHookHelper m_hookHelper;
        private string m_KindCode = "";
        private string[] m_SZCodes = AttriEdit.SZCodes;
        private string m_Town;
        private string m_Vill;
        private string[] m_YbdFields = AttriEdit.YBDFields;
        private const string mClassName = "AttributesEdit.UserControlAttrEdit";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private PanelControl panelAttr;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelCut;
        private PanelControl panelSubmit;
        private UserControlAffAttr userControlAffAttr1;

        private UserControlAttributesEdit userControlCommonEdit1;

        private UserControlFireAttr userControlFireAttr1;
        private UserControlHarAttr1 userControlHarAttr1;
        private UserControlHSAttr userControlHSAttr1;

        private UserControlSubAttr userControlSubAttr1;

        private UserControlZZAttr userControlZZAttr1;

        /// <summary>
        /// 编辑造林设计调查表窗体：用户自定义窗体:构造器
        /// </summary>
        public UserControlAttrEdit()
        {
            this.InitializeComponent();
            this.userControlSubAttr1.OnGetAttributes += new UserControlSubAttr.GetAttributeshandler(this.userControlSubAttr1_OnGetAttributes);
            this.userControlHarAttr1.OnShowJCTable += new UserControlHarAttr1.ShowJCTablehandler(this.userControlHarAttr1_OnShowJCTable);
            this.userControlHarAttr1.OnPrintHarvest += new UserControlHarAttr1.PrintHarvesthandler(this.userControlHarAttr1_OnPrintHarvest);
            this.userControlAffAttr1.OnSetTfh += new UserControlAffAttr.SetTfhhandler(this.userControlAffAttr1_OnSetTfh);
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="pFeature"></param>
        /// <param name="pHook"></param>
        public void AddAttributes(IFeature pFeature, object pHook)
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.SetAttributes(pFeature, pHook, true);
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            if ((this.m_KindCode.Substring(0, 2) == "06") || (this.m_KindCode.Substring(0, 2) == "07"))
            {
                this.userControlCommonEdit1.AddAttributes(pFeature, pHook);
            }
            else
            {
                this.m_EditFeature = pFeature;
                this.ShowAttributes(this.m_EditFeature);
            }
            this.SetPanelVisible(pHook, true);
        }

        /// <summary>
        /// 剪贴属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCut_Click(object sender, EventArgs e)
        {
            if (this.m_CutFeatures != null)
            {
                int selectedIndex = this.comboBoxCut.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    IFeature feature = this.m_CutFeatures[selectedIndex];
                    if (feature != null)
                    {
                        this.m_EditFeature = feature;
                        IActiveView activeView = this.m_hookHelper.ActiveView;
                        IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                        editLayer.Clear();
                        if (feature != null)
                        {
                            editLayer.Add(feature);
                        }
                        activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection | esriViewDrawPhase.esriViewGeography, null, null);
                        this.CutAttributes();
                        this.panelSubmit.Visible = true;
                        this.panelAttr.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// 保存属性数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                this.labelSubmit.Text = "";
                Editor.UniqueInstance.StartEditOperation();
                try
                {
                    if (this.SubmitValue())
                    {
                        flag = true;
                        if (this.m_KindCode.Substring(0, 2) == "04")
                        {
                            this.SubmitSubCode();
                            this.SubmitXMName();
                        }
                        else if ((this.m_KindCode.Substring(0, 2) == "02") && (UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey").ToLower() == "access"))
                        {
                            Control control = this.GetControl("CUN");
                            if (control != null)
                            {
                                DataFuncs.UpdateField(this.m_EditFeature, "CUN_NAME", ((ZLComboBox) control).GetSelectedName());
                            }
                        }
                    }
                }
                catch
                {
                    flag = false;
                }
                Editor.UniqueInstance.StopEditOperation();
                IFeatureLayer editLayer = EditTask.EditLayer;
                IFeatureClass featureClass = editLayer.FeatureClass;
                if ((featureClass != null) && (featureClass.ShapeType != esriGeometryType.esriGeometryPolyline))
                {
                    string text = CheckAttributes.CheckFeatureAttr(editLayer, this.m_EditFeature);
                    if (text != "")
                    {
                        XtraMessageBox.Show(text, "属性录入提示");
                    }
                }
            }
            catch
            {
                flag = false;
            }
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, this.m_EditFeature.Shape.Envelope);
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, this.m_EditFeature.Shape.Envelope);
            if (flag)
            {
                this.labelSubmit.Text = "保存成功！";
            }
            else
            {
                this.labelSubmit.Text = "保存失败！";
            }
        }

        public void CombineFeatures(IList<IFeature> pList, IFeature pNewFeature, int index, object pHook)
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.Hook = pHook;
            this.m_KindCode = EditTask.KindCode;
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            if ((this.m_KindCode.Substring(0, 2) == "06") || (this.m_KindCode.Substring(0, 2) == "07"))
            {
                this.userControlCommonEdit1.CombineAttributes(pList, pNewFeature, index, pHook);
            }
            else
            {
                this.InitCombine(pList, pNewFeature, index);
            }
            this.SetPanelVisible(pHook, true);
        }

        /// <summary>
        /// 转换为double类型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 复制几何对象
        /// </summary>
        /// <param name="pSrcObj"></param>
        /// <param name="pTargObj"></param>
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
                        if (((field.Type != esriFieldType.esriFieldTypeGeometry) && ((this.m_KindCode.Substring(0, 2) == "06") || (field.Name != nodeValue))) && ((field.Name != str2) && field.Editable))
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

        /// <summary>
        /// 剪贴属性
        /// </summary>
        private void CutAttributes()
        {
            try
            {
                this.ShowAttributes(this.m_EditFeature);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "CutAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 剪贴要素
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="pHook"></param>
        public void CutFeature(IList<IFeature> pList, object pHook)
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.Hook = pHook;
            this.m_KindCode = EditTask.KindCode;
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            if ((this.m_KindCode.Substring(0, 2) == "06") || (this.m_KindCode.Substring(0, 2) == "07"))
            {
                this.SetPanelVisible(pHook, true);
                this.userControlCommonEdit1.CutFeature(pList, pHook);
            }
            else
            {
                this.panelCut.Visible = true;
                this.panelAttr.Visible = false;
                this.m_CutFeatures = pList;
                this.InitCutFeature();
                this.SetPanelVisible(pHook, false);
            }
        }

        /// <summary>
        /// 删除要素
        /// </summary>
        /// <param name="pList"></param>
        public void DeleteFeatures(IList pList)
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.m_KindCode = EditTask.KindCode;
            this.panelCut.Visible = false;
            switch (this.m_KindCode.Substring(0, 2))
            {
                case "02":
                    for (int i = 0; i < pList.Count; i++)
                    {
                        IFeature pFeature = pList[i] as IFeature;
                        this.DeleteJC(pFeature);
                    }
                    break;

                case "08":
                case "01":              
                case "05":
                case "04":
                case "09":
                    if (this.m_EditFeature != null)
                    {
                        for (int j = 0; j < pList.Count; j++)
                        {
                            IFeature feature2 = pList[j] as IFeature;
                            if (feature2.OID == this.m_EditFeature.OID)
                            {
                                this.panelSubmit.Visible = false;
                                this.panelAttr.Visible = false;
                                this.panelCut.Visible = false;
                                this.labelSubmit.Text = "";
                                return;
                            }
                        }
                        return;
                    }
                    return;
            }
            this.userControlHarAttr1.Visible = false;
            this.userControlAffAttr1.Visible = false;
            this.userControlSubAttr1.Visible = false;
            this.userControlCommonEdit1.Visible = true;
            this.userControlCommonEdit1.DeleteFeatures(pList);
        }


        public void DeleteJC(IFeature pFeature)
        {
            try
            {
                if (pFeature != null)
                {
                    ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                    string configValue = configOpt.GetConfigValue("CaiFaTableName");
                    IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                    if (editWorkspace != null)
                    {
                        ITable table = null;
                        try
                        {
                            table = editWorkspace.OpenTable(configValue);
                        }
                        catch
                        {
                            return;
                        }
                        if (table != null)
                        {
                            string str2 = configOpt.GetConfigValue("CaiFaConnectFieldName");
                            int index = str2.IndexOf(";");
                            string str3 = str2.Substring(0, index);
                            string str4 = str2.Substring(index + 1);
                            string[] strArray = str3.Split(new char[] { ',' });
                            string[] strArray2 = str4.Split(new char[] { ',' });
                            string str5 = "";
                            string str6 = "";
                            string str7 = "";
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                str6 = DataFuncs.GetFieldValue(pFeature, strArray[i]).ToString();
                                if (str6 == "")
                                {
                                    return;
                                }
                                string str8 = str5;
                                str5 = str8 + " and " + strArray2[i] + "='" + str6 + "'";
                                str7 = str7 + "," + str6;
                            }
                            str5 = str5.Substring(5);
                            str7 = str7.Substring(1);
                            IQueryFilter queryFilter = new QueryFilterClass {
                                WhereClause = str5
                            };
                            ICursor o = null;
                            try
                            {
                                o = table.Search(queryFilter, false);
                            }
                            catch
                            {
                            }
                            if (o != null)
                            {
                                for (IRow row = o.NextRow(); row != null; row = o.NextRow())
                                {
                                    row.Delete();
                                }
                                Marshal.ReleaseComObject(o);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "DeleteJC", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 编辑属性数据
        /// </summary>
        /// <param name="pFeature"></param>
        /// <param name="pHook"></param>
        public void EditAttributes(IFeature pFeature, object pHook)
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.Hook = pHook;
            this.m_KindCode = EditTask.KindCode;
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            if (pFeature == null)
            {
                this.panelAttr.Visible = false;
            }
            else
            {
                ///test
                if ((this.m_KindCode.Substring(0, 2) == "06") || (this.m_KindCode.Substring(0, 2) == "07") || (this.m_KindCode.Substring(0, 2) == "01"))
                {
                    this.userControlCommonEdit1.EditAttributes(pFeature, pHook);
                }
                else
                {
                    this.m_EditFeature = pFeature;
                    this.ShowAttributes(this.m_EditFeature);
                }
                this.SetPanelVisible(pHook, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFeature"></param>
        /// <param name="pHook"></param>
        public void EditHSAttributes(IFeature pFeature, object pHook)
        {
            this.Hook = pHook;
            this.m_KindCode = "09";
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            if (pFeature == null)
            {
                this.panelAttr.Visible = false;
            }
            else
            {
                this.m_EditFeature = pFeature;
                this.ShowAttributes(this.m_EditFeature);
                this.SetPanelVisible(pHook, true);
            }
        }

        /// <summary>
        /// 根据不同操作类别，获取不同的控件布局
        /// </summary>
        /// <param name="sControlName"></param>
        /// <returns></returns>
        private Control GetControl(string sControlName)
        {
            try
            {
                Control control = null;
                switch (this.m_KindCode.Substring(0, 2))
                {
                    case "01":
                        control = this.userControlAffAttr1.GetControl(sControlName);
                        break;

                    case "02":
                        control = this.userControlHarAttr1.GetControl(sControlName);
                        break;

                    case "04":
                        control = this.userControlZZAttr1.GetControl(sControlName);
                        break;

                    case "05":
                        control = this.userControlFireAttr1.GetControl(sControlName);
                        break;

                    case "08":
                        control = this.userControlSubAttr1.GetControl(sControlName);
                        break;

                    case "09":
                        control = this.userControlHSAttr1.GetControl(sControlName);
                        break;

                    case "10":
                        control = this.userControlSubAttr1.GetControl(sControlName);
                        break;
                }
                return control;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取控件里的值
        /// </summary>
        /// <param name="pControl"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private object GetControlValue(Control pControl, int iLength)
        {
            try
            {
                if (pControl is ZLComboBox)
                {
                    string selectedValue = ((ZLComboBox) pControl).GetSelectedValue();
                    if (selectedValue == "")
                    {
                        return null;
                    }
                    if ((iLength > 0) && (selectedValue.Length > iLength))
                    {
                        selectedValue = selectedValue.Substring(0, iLength);
                    }
                    return selectedValue;
                }
                if (pControl is SpinEdit)
                {
                    string text = ((SpinEdit) pControl).Text;
                    if (text == "")
                    {
                        return null;
                    }
                    return Convert.ToDecimal(text);
                }
                if (pControl is DateEdit)
                {
                    DateEdit pDateEdit = pControl as DateEdit;
                    return this.GetDateValue(pDateEdit);
                }
                if (pControl is TextEdit)
                {
                    string str3 = ((TextEdit) pControl).Text;
                    if (str3.Replace(" ", "").Length < 1)
                    {
                        return null;
                    }
                    str3 = str3.Trim();
                    if ((iLength > 0) && (str3.Length > iLength))
                    {
                        str3 = str3.Substring(0, iLength);
                    }
                    return str3;
                }
                if (pControl is CheckedListBoxControl)
                {
                    string str4 = "";
                    CheckedListBoxControl control = (CheckedListBoxControl) pControl;
                    for (int i = 0; i < control.Items.Count; i++)
                    {
                        if (control.Items[i].CheckState == CheckState.Checked)
                        {
                            str4 = str4 + "," + control.Items[i].Value;
                        }
                    }
                    str4 = str4.Substring(1);
                    if ((iLength > 0) && (str4.Length > iLength))
                    {
                        str4 = str4.Substring(0, iLength);
                    }
                    return str4;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取时间值
        /// </summary>
        /// <param name="pDateEdit"></param>
        /// <returns></returns>
        private object GetDateValue(DateEdit pDateEdit)
        {
            if (!this.m_DayFields.Contains<string>(pDateEdit.Name))
            {
                return pDateEdit.DateTime;
            }
            string text = pDateEdit.Text;
            if (text == "")
            {
                return null;
            }
            return Convert.ToDateTime(text).ToString("yyyyMMdd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFLayer"></param>
        /// <param name="sFieldName"></param>
        /// <param name="pGeo"></param>
        /// <returns></returns>
        private string GetDistName(IFeatureLayer pFLayer, string sFieldName, IGeometry pGeo)
        {
            if ((pFLayer == null) || (pGeo == null))
            {
                return "";
            }
            if (sFieldName == "")
            {
                return "";
            }
            IFeatureClass featureClass = pFLayer.FeatureClass;
            if (featureClass == null)
            {
                return "";
            }
            string str = "";
            try
            {
                ISpatialFilter filter = new SpatialFilterClass {
                    Geometry = pGeo,
                    GeometryField = featureClass.ShapeFieldName,
                    SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
                };
                IFeatureCursor cursor = featureClass.Search(filter, false);
                int index = -1;
                if (cursor != null)
                {
                    IFeature feature = cursor.NextFeature();
                    if (feature != null)
                    {
                        index = feature.Fields.FindField(sFieldName);
                        if (index > -1)
                        {
                            return feature.get_Value(index).ToString();
                        }
                    }
                }
                return str;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取节点的值
        /// </summary>
        /// <param name="sNode"></param>
        /// <returns></returns>
        private string GetNodeValue(string sNode)
        {
            string name = "";
            string str2 = this.m_KindCode.Substring(0, 2);
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
            else if (str2 == "07")
            {
                name = "ForestCase";
            }
            else if (str2 == "04")
            {
                name = "Expropriation";
            }
            else if (str2 == "05")
            {
                name = "Fire";
            }
            else if (str2 == "08")
            {
                name = "Sub";
            }
            else
            {
                name = "Other";
            }
            return UtilFactory.GetConfigOpt().GetConfigValue2(name, sNode);
        }

        private void InitCombine(IList<IFeature> pList, IFeature pNewFeature, int index)
        {
            if (index >= 0)
            {
                int count = pList.Count;
                this.m_EditFeature = pNewFeature;
                if (index != count)
                {
                    IFeature pSrcObj = pList[index];
                    this.CopyGeoObject(pSrcObj, pNewFeature);
                }
                this.SetCombineFeatureArea(pNewFeature, pList);
                this.ShowAttributes(this.m_EditFeature);
            }
        }

        /// <summary>
        /// 初始化剪贴要素
        /// </summary>
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
                        this.SetAttributes(pFeature, this.m_hookHelper.Hook, true);
                    }
                    else
                    {
                        this.CopyGeoObject(pSrcObj, pFeature);
                    }
                    AttriEdit.SetFeatureArea(pFeature, this.m_KindCode.Substring(0, 2), this.m_hookHelper.FocusMap.SpatialReference);
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

        private void InitializeComponent()
        {
            this.panelCut = new DevExpress.XtraEditors.PanelControl();
            this.btnCut = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxCut = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelAttr = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlHSAttr1 = new AttributesEdit.UserControlHSAttr();
            this.userControlHarAttr1 = new AttributesEdit.UserControlHarAttr1();
            this.userControlFireAttr1 = new AttributesEdit.UserControlFireAttr();
            this.userControlZZAttr1 = new AttributesEdit.UserControlZZAttr();
            this.userControlAffAttr1 = new AttributesEdit.UserControlAffAttr();
            this.userControlCommonEdit1 = new AttributesEdit.UserControlAttributesEdit();
            this.panelSubmit = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelSubmit = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.userControlSubAttr1 = new AttributesEdit.UserControlSubAttr();
            ((System.ComponentModel.ISupportInitialize)(this.panelCut)).BeginInit();
            this.panelCut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAttr)).BeginInit();
            this.panelAttr.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSubmit)).BeginInit();
            this.panelSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCut
            // 
            this.panelCut.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelCut.Appearance.Options.UseBackColor = true;
            this.panelCut.Controls.Add(this.btnCut);
            this.panelCut.Controls.Add(this.comboBoxCut);
            this.panelCut.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCut.Location = new System.Drawing.Point(0, 0);
            this.panelCut.Name = "panelCut";
            this.panelCut.Size = new System.Drawing.Size(500, 51);
            this.panelCut.TabIndex = 0;
            this.panelCut.Visible = false;
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(190, 12);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(54, 27);
            this.btnCut.TabIndex = 1;
            this.btnCut.Text = "确定";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // comboBoxCut
            // 
            this.comboBoxCut.Location = new System.Drawing.Point(26, 15);
            this.comboBoxCut.Name = "comboBoxCut";
            this.comboBoxCut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCut.Size = new System.Drawing.Size(138, 20);
            this.comboBoxCut.TabIndex = 0;
            // 
            // panelAttr
            // 
            this.panelAttr.Controls.Add(this.panel1);
            this.panelAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr.Location = new System.Drawing.Point(0, 51);
            this.panelAttr.Name = "panelAttr";
            this.panelAttr.Size = new System.Drawing.Size(500, 409);
            this.panelAttr.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.userControlHSAttr1);
            this.panel1.Controls.Add(this.userControlHarAttr1);
            this.panel1.Controls.Add(this.userControlFireAttr1);
            this.panel1.Controls.Add(this.userControlZZAttr1);
            this.panel1.Controls.Add(this.userControlAffAttr1);
            this.panel1.Controls.Add(this.userControlCommonEdit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 405);
            this.panel1.TabIndex = 0;
            // 
            // userControlHSAttr1
            // 
            this.userControlHSAttr1.BackColor = System.Drawing.Color.White;
            this.userControlHSAttr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHSAttr1.Location = new System.Drawing.Point(0, 2430);
            this.userControlHSAttr1.Name = "userControlHSAttr1";
            this.userControlHSAttr1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlHSAttr1.Size = new System.Drawing.Size(479, 810);
            this.userControlHSAttr1.TabIndex = 10;
            // 
            // userControlHarAttr1
            // 
            this.userControlHarAttr1.BackColor = System.Drawing.Color.White;
            this.userControlHarAttr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlHarAttr1.Location = new System.Drawing.Point(0, 1620);
            this.userControlHarAttr1.Name = "userControlHarAttr1";
            this.userControlHarAttr1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlHarAttr1.Size = new System.Drawing.Size(479, 810);
            this.userControlHarAttr1.TabIndex = 8;
            // 
            // userControlFireAttr1
            // 
            this.userControlFireAttr1.BackColor = System.Drawing.Color.White;
            this.userControlFireAttr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFireAttr1.Location = new System.Drawing.Point(0, 1620);
            this.userControlFireAttr1.Name = "userControlFireAttr1";
            this.userControlFireAttr1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlFireAttr1.Size = new System.Drawing.Size(479, 1620);
            this.userControlFireAttr1.TabIndex = 8;
            // 
            // userControlZZAttr1
            // 
            this.userControlZZAttr1.BackColor = System.Drawing.Color.White;
            this.userControlZZAttr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlZZAttr1.Location = new System.Drawing.Point(0, 870);
            this.userControlZZAttr1.Name = "userControlZZAttr1";
            this.userControlZZAttr1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlZZAttr1.Size = new System.Drawing.Size(479, 750);
            this.userControlZZAttr1.TabIndex = 9;
            // 
            // userControlAffAttr1
            // 
            this.userControlAffAttr1.BackColor = System.Drawing.Color.White;
            this.userControlAffAttr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlAffAttr1.Location = new System.Drawing.Point(0, 0);
            this.userControlAffAttr1.Name = "userControlAffAttr1";
            this.userControlAffAttr1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlAffAttr1.Size = new System.Drawing.Size(479, 870);
            this.userControlAffAttr1.TabIndex = 7;
            // 
            // userControlCommonEdit1
            //
            this.userControlCommonEdit1.BackColor = Color.White;
            this.userControlCommonEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCommonEdit1.Location = new System.Drawing.Point(0, 0);
            this.userControlCommonEdit1.Name = "userControlCommonEdit1";
            this.userControlCommonEdit1.Padding = new System.Windows.Forms.Padding(2);
            this.userControlCommonEdit1.Size = new System.Drawing.Size(479, 3240);
            this.userControlCommonEdit1.TabIndex = 0;
            // 
            // panelSubmit
            // 
            this.panelSubmit.Controls.Add(this.panelControl1);
            this.panelSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSubmit.Location = new System.Drawing.Point(0, 460);
            this.panelSubmit.Name = "panelSubmit";
            this.panelSubmit.Size = new System.Drawing.Size(500, 40);
            this.panelSubmit.TabIndex = 2;
            this.panelSubmit.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelSubmit);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.btnSubmit);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panelControl1.Size = new System.Drawing.Size(496, 33);
            this.panelControl1.TabIndex = 1;
            // 
            // labelSubmit
            // 
            this.labelSubmit.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelSubmit.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSubmit.Location = new System.Drawing.Point(20, 0);
            this.labelSubmit.Name = "labelSubmit";
            this.labelSubmit.Size = new System.Drawing.Size(0, 14);
            this.labelSubmit.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(351, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(29, 33);
            this.panelControl3.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSubmit.Location = new System.Drawing.Point(380, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 33);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "保存";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(467, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(29, 33);
            this.panelControl2.TabIndex = 0;
            // 
            // userControlSubAttr1
            // 
            this.userControlSubAttr1.Location = new System.Drawing.Point(0, 0);
            this.userControlSubAttr1.Name = "userControlSubAttr1";
            this.userControlSubAttr1.PointLocation = null;
            this.userControlSubAttr1.Size = new System.Drawing.Size(585, 623);
            this.userControlSubAttr1.TabIndex = 0;
            // 
            // UserControlAttrEdit
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panelAttr);
            this.Controls.Add(this.panelSubmit);
            this.Controls.Add(this.panelCut);
            this.Name = "UserControlAttrEdit";
            this.Size = new System.Drawing.Size(500, 500);
            ((System.ComponentModel.ISupportInitialize)(this.panelCut)).EndInit();
            this.panelCut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAttr)).EndInit();
            this.panelAttr.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSubmit)).EndInit();
            this.panelSubmit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="pFeature"></param>
        /// <param name="pHook"></param>
        /// <param name="bAttriBySub"></param>
        public void SetAttributes(IFeature pFeature, object pHook, bool bAttriBySub)
        {
            this.Hook = pHook;
            this.m_KindCode = EditTask.KindCode;
            if (bAttriBySub)
            {
                this.SetAttributesBySub(pFeature);
            }
            DataFuncs.UpdateField(pFeature, "BHYY", DBNull.Value);
            DataFuncs.UpdateField(pFeature, "GXSJ", DBNull.Value);
            if (this.m_KindCode.Substring(0, 2) == "01")
            {
                this.SetTuf(pFeature);
            }
            else if (this.m_KindCode.Substring(0, 2) == "02")
            {
                this.SetHarFields(pFeature);
            }
            else if (this.m_KindCode.Substring(0, 2) == "05")
            {
                this.SetFireFields(pFeature);
            }
            else if (this.m_KindCode.Substring(0, 2) == "04")
            {
                this.SetZZXM(pFeature);
            }
        }

        /// <summary>
        /// 通过提交的属性获取属性值
        /// </summary>
        /// <param name="pFeature"></param>
        private void SetAttributesBySub(IFeature pFeature)
        {
            if (pFeature != null)
            {
                IGeometry shapeCopy = pFeature.ShapeCopy;
                try
                {
                    ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                    string configValue = configOpt.GetConfigValue("XiaobanLayerName");
                    if (configValue != "")
                    {
                        IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.FocusMap as IBasicMap, configValue, true);
                        if (layer == null)
                        {
                            this.SetDist(pFeature);
                        }
                        else
                        {
                            IFeatureClass featureClass = layer.FeatureClass;
                            if (featureClass == null)
                            {
                                this.SetDist(pFeature);
                            }
                            else
                            {
                                List<string> list = configOpt.GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }).ToList<string>();
                                List<string> list2 = configOpt.GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }).ToList<string>();
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
                                        string str5 = this.GetNodeValue("ZTAreaField");
                                        if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                                        {
                                            for (int i = 0; i < pFeature.Fields.FieldCount; i++)
                                            {
                                                IField field = pFeature.Fields.get_Field(i);
                                                if ((field.Editable && (field.Type != esriFieldType.esriFieldTypeGeometry)) && ((field.Name != nodeValue) && (field.Name != str5)))
                                                {
                                                    string name = field.Name;
                                                    if (list.Contains(name))
                                                    {
                                                        int index = list.IndexOf(name);
                                                        name = list2[index];
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
                                            double num3 = 0.0;
                                            IFeature feature2 = pObj;
                                            int num4 = 0;
                                            while (pObj != null)
                                            {
                                                if (num4 == 10)
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
                                                    double num5 = area.Area;
                                                    if (num5 > num3)
                                                    {
                                                        num3 = num5;
                                                        feature2 = pObj;
                                                    }
                                                    num4++;
                                                    pObj = o.NextFeature();
                                                }
                                            }
                                            Marshal.ReleaseComObject(o);
                                            for (int j = 0; j < pFeature.Fields.FieldCount; j++)
                                            {
                                                IField field2 = pFeature.Fields.get_Field(j);
                                                if ((field2.Editable && (field2.Type != esriFieldType.esriFieldTypeGeometry)) && ((field2.Name != nodeValue) && (field2.Name != str5)))
                                                {
                                                    string item = field2.Name;
                                                    if (list.Contains(item))
                                                    {
                                                        int num7 = list.IndexOf(item);
                                                        item = list2[num7];
                                                    }
                                                    object obj3 = DataFuncs.GetFieldValue(feature2, item);
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
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 设置合并要素的面积
        /// </summary>
        /// <param name="pNewFeature"></param>
        /// <param name="pFeatureList"></param>
        private void SetCombineFeatureArea(IFeature pNewFeature, IList<IFeature> pFeatureList)
        {
            if (pNewFeature != null)
            {
                AttriEdit.SetFeatureArea(pNewFeature, this.m_KindCode.Substring(0, 2), this.m_hookHelper.FocusMap.SpatialReference);
            }
        }

        /// <summary>
        /// 将区划数据依次填充进省市县的下拉框
        /// </summary>
        /// <param name="pFeature"></param>
        private void SetDist(IFeature pFeature)
        {
            try
            {
                string distCode = EditTask.DistCode;
                if (distCode != "")
                {
                    ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                    if (distCode.Length >= 2)
                    {
                        string sFieldName = "SHENG";
                        DataFuncs.UpdateField(pFeature, sFieldName, distCode.Substring(0, 2));
                    }
                    if (distCode.Length >= 4)
                    {
                        string str3 = "SHI";
                        DataFuncs.UpdateField(pFeature, str3, distCode.Substring(0, 4));
                    }
                    if (distCode.Length >= 6)
                    {
                        string str4 = configOpt.GetConfigValue2("Other", "CntyField");
                        DataFuncs.UpdateField(pFeature, str4, distCode.Substring(0, 6));
                    }
                    if (distCode.Length >= 9)
                    {
                        string str5 = configOpt.GetConfigValue2("Other", "TownField");
                        DataFuncs.UpdateField(pFeature, str5, distCode.Substring(0, 9));
                    }
                    if (distCode.Length >= 12)
                    {
                        string str6 = configOpt.GetConfigValue2("Other", "VillField");
                        DataFuncs.UpdateField(pFeature, str6, distCode.Substring(0, 12));
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFeature"></param>
        private void SetFireFields(IFeature pFeature)
        {
            string nodeValue = this.GetNodeValue("BHField");
            string pFieldValue = this.GetNodeValue("BHValue");
            DataFuncs.UpdateField(pFeature, nodeValue, pFieldValue);
            string sFieldName = this.GetNodeValue("DispeField");
            string str4 = this.GetNodeValue("DispeValue");
            DataFuncs.UpdateField(pFeature, sFieldName, str4);
            string str5 = "DI_LEI";
            string str6 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HZDilei");
            DataFuncs.UpdateField(pFeature, str5, str6);
            pFeature.Store();
        }

        private void SetHarFields(IFeature pFeature)
        {
            if (EditTask.TaskID > 0L)
            {
                string nodeValue = this.GetNodeValue("TaskField");
                DataFuncs.UpdateField(pFeature, nodeValue, EditTask.TaskID);
            }
            string sFieldName = "SFCF";
            DataFuncs.UpdateField(pFeature, sFieldName, "是");
            sFieldName = "DI_LEI";
            string pFieldValue = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "CFDilei");
            DataFuncs.UpdateField(pFeature, sFieldName, pFieldValue);
            if (this.m_KindCode.Length > 4)
            {
                sFieldName = "CFLX";
                pFieldValue = this.m_KindCode.Substring(3, 1) + "0";
                DataFuncs.UpdateField(pFeature, sFieldName, pFieldValue);
                sFieldName = "BHYY";
                string str4 = "";
                if (pFieldValue == "10")
                {
                    str4 = "21";
                }
                else if (pFieldValue == "40")
                {
                    str4 = "22";
                }
                else if (pFieldValue == "30")
                {
                    str4 = "23";
                }
                else
                {
                    str4 = "24";
                }
                DataFuncs.UpdateField(pFeature, sFieldName, str4);
            }
            pFeature.Store();
        }

        /// <summary>
        /// 设置不为null的字段
        /// </summary>
        private void SetNotNullFields()
        {
            string sql = "";
            string str2 = this.m_KindCode.Substring(0, 2);
            string str3 = "T_Logic_Check";
            sql = "select * from " + str3 + " where design_kind like '" + str2 + "%' and enabled=true order by CHECK_ID,ID";
          //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
            DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
            if ((dataTable != null) && (dataTable.Rows.Count >= 1))
            {
                DataRow[] rowArray = dataTable.Select("CHECK_TYPE='NOTNULL'");
                if (rowArray.Length > 0)
                {
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        Control control = this.GetControl("la" + rowArray[i]["CHECK_FIELD"].ToString());
                        if (control != null)
                        {
                            Font prototype = control.Font;
                            control.Font = new Font(prototype, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置面板显示的数据
        /// </summary>
        /// <param name="pHook"></param>
        /// <param name="bPanelAttr"></param>
        private void SetPanelVisible(object pHook, bool bPanelAttr)
        {
            XtraTabPage parent = base.Parent as XtraTabPage;
            if (parent != null)
            {
                parent.PageVisible = true;
                XtraTabControl tabControl = parent.TabControl;
                if (tabControl != null)
                {
                    tabControl.SelectedTabPageIndex = 0;
                    tabControl.TabPages[0].PageVisible = true;
                    ControlContainer container = tabControl.Parent as ControlContainer;
                    if (container != null)
                    {
                        DockPanel panel = container.Parent as DockPanel;
                        if (panel != null)
                        {
                            this.userControlHarAttr1.Visible = false;
                            this.userControlAffAttr1.Visible = false;
                            this.userControlSubAttr1.Visible = false;
                            this.userControlFireAttr1.Visible = false;
                            this.userControlZZAttr1.Visible = false;
                            this.userControlHSAttr1.Visible = false;
                            this.userControlCommonEdit1.Visible = false;
                            panel.Visibility = DockVisibility.Visible;
                            if (this.m_KindCode.Substring(0, 2) == "10")
                            {
                                panel.Width = 610;
                                this.userControlSubAttr1.Init(pHook);
                                this.userControlSubAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                                this.userControlSubAttr1.IsVisibleTool = false;
                                this.userControlSubAttr1.IsVisibleAddFields = false;
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "09")
                            {
                                panel.Width = 550;
                                this.userControlHSAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "08")
                            {
                                panel.Width = 610;
                                this.userControlSubAttr1.Init(pHook);
                                this.userControlSubAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                                if (EditTask.EditLayer.Name.Contains("变更"))
                                {
                                    this.userControlSubAttr1.IsVisibleTool = false;
                                    this.userControlSubAttr1.IsVisibleAddFields = false;
                                }
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "01")
                            {
                                panel.Width = 0x217;
                                this.userControlAffAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "02")
                            {
                                panel.Width = 570;
                                this.userControlHarAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "05")
                            {
                                panel.Width = 550;
                                this.userControlFireAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "04")
                            {
                                panel.Width = 540;
                                this.userControlZZAttr1.Init();
                                this.userControlZZAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else if (this.m_KindCode.Substring(0, 2) == "99")
                            {
                                panel.Width = 540;
                                this.userControlHSAttr1.Visible = true;
                                this.labelSubmit.Text = "";
                            }
                            else
                            {
                                this.userControlCommonEdit1.Visible = true;
                            }
                            this.panelAttr.Visible = bPanelAttr;
                            base.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置图幅号
        /// </summary>
        /// <param name="pFeature"></param>
        private void SetTuf(IFeature pFeature)
        {
            try
            {
                if (pFeature != null)
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (!shapeCopy.IsEmpty)
                    {
                        IFeatureLayer tFHLayer = EditTask.TFHLayer;
                        if (tFHLayer != null)
                        {
                            IFeatureClass featureClass = tFHLayer.FeatureClass;
                            if (featureClass != null)
                            {
                                ISpatialFilter filter = new SpatialFilterClass {
                                    Geometry = shapeCopy,
                                    GeometryField = featureClass.ShapeFieldName,
                                    SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
                                };
                                IFeature pObj = featureClass.Search(filter, false).NextFeature();
                                if (pObj != null)
                                {
                                    DataFuncs.UpdateField(pFeature, "TFH", DataFuncs.GetFieldValue(pObj, "旧图幅号").ToString() + "," + DataFuncs.GetFieldValue(pObj, "新图幅号").ToString());
                                    pFeature.Store();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "SetTuf", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFeature"></param>
        private void SetZZXM(IFeature pFeature)
        {
            string sFieldName = "XFSS";
            DataFuncs.UpdateField(pFeature, sFieldName, "否");
            sFieldName = "SFTGD";
            DataFuncs.UpdateField(pFeature, sFieldName, "否");
            sFieldName = "YDFW";
            DataFuncs.UpdateField(pFeature, sFieldName, "2");
            DataFuncs.UpdateField(pFeature, "SEN_LIN_LB", DBNull.Value);
            DataFuncs.UpdateField(pFeature, "LIN_ZHONG", DBNull.Value);
            DataFuncs.UpdateField(pFeature, "DI_LEI", "950");
            DataFuncs.UpdateField(pFeature, "LDBCDJ", 0);
            DataFuncs.UpdateField(pFeature, "LDAZFDJ", 0);
            DataFuncs.UpdateField(pFeature, "LMBCDJ", 0);
            DataFuncs.UpdateField(pFeature, "ZBHFDJ", 0);
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "XMField");
            DataFuncs.UpdateField(pFeature, str2, EditTask.TaskID);
            string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "XMKindField");
            string kindCode = this.m_KindCode;
            if (kindCode.Length >= 6)
            {
                kindCode = kindCode.Substring(3, 1) + kindCode.Substring(5, 1);
                DataFuncs.UpdateField(pFeature, str3, kindCode);
            }
            string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "XMNameField");
            DataFuncs.UpdateField(pFeature, str5, EditTask.TaskName);
            DataFuncs.UpdateField(pFeature, "PZWH", EditTask.PZWH);
            pFeature.Store();
        }

        /// <summary>
        /// 显示属性
        /// </summary>
        /// <param name="pEditObject"></param>
        private void ShowAttributes(IObject pEditObject)
        {
            if (pEditObject == null)
            {
                base.Enabled = false;
            }
            else
            {
                base.Enabled = false;
                this.panelSubmit.Visible = true;
                this.panelAttr.Visible = true;
                try
                {
                    string nodeValue = this.GetNodeValue("AreaField");
                    string sZTAreaField = this.GetNodeValue("ZTAreaField");
                    if ((this.m_KindCode.Substring(0, 2) == "04") && (this.m_EditFeature.Shape.GeometryType == esriGeometryType.esriGeometryPoint))
                    {
                        nodeValue = "";
                    }
                    if (this.m_KindCode.Substring(0, 2) == "07")
                    {
                        sZTAreaField = "";
                    }
                    if (this.m_KindCode.Substring(0, 2) == "02")
                    {
                        sZTAreaField = "";
                    }
                    IFields fields = pEditObject.Fields;
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField pField = fields.get_Field(i);
                        object pValue = pEditObject.get_Value(i);
                        this.ShowFieldValue(pField, pValue, pField.Name, nodeValue, sZTAreaField);
                        Control control = this.GetControl("la" + pField.Name);
                        if (control != null)
                        {
                            control.Font = new Font("宋体", 9f);
                        }
                    }
                    if (this.m_bBoldField)
                    {
                        this.SetNotNullFields();
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "ShowAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                base.Enabled = true;
            }
        }

        /// <summary>
        /// 显示变化原因
        /// </summary>
        /// <param name="pField"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadOnly"></param>
        private void ShowBHYY(IField pField, string sValue, bool bReadOnly)
        {
            string nodeValue = this.GetNodeValue("BHDomain");
            string[] source = nodeValue.Split(new char[] { ',' });
            IDomain domain = pField.Domain;
            if ((domain != null) && (domain is ICodedValueDomain))
            {
                IList pItems = new ArrayList();
                IList pValueList = new ArrayList();
                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                if (pField.IsNullable)
                {
                    pItems.Add("<空>");
                    pValueList.Add("");
                }
                for (int i = 0; i < domain2.CodeCount; i++)
                {
                    string str2 = domain2.get_Value(i).ToString();
                    if (nodeValue != "")
                    {
                        if (source.Contains<string>(str2))
                        {
                            pItems.Add(domain2.get_Name(i));
                            pValueList.Add(str2);
                        }
                    }
                    else
                    {
                        pItems.Add(domain2.get_Name(i));
                        pValueList.Add(str2);
                    }
                }
                this.ShowComboBox(pField.Name, sValue, pItems, pValueList, bReadOnly);
            }
        }

        /// <summary>
        /// 显示下拉框
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="sValue"></param>
        /// <param name="pItems"></param>
        /// <param name="pValueList"></param>
        /// <param name="bReadOnly"></param>
        private void ShowComboBox(string sControlName, string sValue, IList pItems, IList pValueList, bool bReadOnly)
        {
            ZLComboBox control = this.GetControl(sControlName) as ZLComboBox;
            if (control != null)
            {
                int num = -1;
                control.ClearItems();
                if (pItems != null)
                {
                    if (pValueList == null)
                    {
                        pValueList = pItems;
                    }
                    if (sControlName.IndexOf("SZ") == (sControlName.Length - 2))
                    {
                        control.DrawMode = DrawMode.OwnerDrawFixed;
                        for (int i = 0; i < pItems.Count; i++)
                        {
                            string sName = pItems[i].ToString();
                            string str2 = pValueList[i].ToString();
                            if (this.m_SZCodes.Contains<string>(str2))
                            {
                                control.AddItem(sName, str2, true);
                            }
                            else if ((str2.Length > 2) && (str2.Substring(2) == "0"))
                            {
                                control.AddItem(sName, str2, false);
                            }
                            else
                            {
                                control.AddItem(sName, str2, true);
                            }
                            if (pValueList[i].ToString() == sValue)
                            {
                                num = i;
                            }
                        }
                    }
                    else if ((sControlName == "G_CHENG_LB") || (sControlName == "Q_GC_LB"))
                    {
                        string[] unGCLBCodes = AttriEdit.UnGCLBCodes;
                        control.DrawMode = DrawMode.OwnerDrawFixed;
                        for (int j = 0; j < pItems.Count; j++)
                        {
                            string str3 = pItems[j].ToString();
                            string str4 = pValueList[j].ToString();
                            if (unGCLBCodes.Contains<string>(str4))
                            {
                                control.AddItem(str3, str4, false);
                            }
                            else
                            {
                                control.AddItem(str3, str4, true);
                            }
                            if (pValueList[j].ToString() == sValue)
                            {
                                num = j;
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < pItems.Count; k++)
                        {
                            control.AddItem(pItems[k].ToString(), pValueList[k].ToString());
                            if (pValueList[k].ToString() == sValue)
                            {
                                num = k;
                            }
                        }
                    }
                }
                control.SelectedIndex = -1;
                control.Enabled = !bReadOnly;
                if (num == -1)
                {
                    control.SelectedIndex = 0;
                }
                else
                {
                    control.SelectedIndex = num;
                }
                if (sControlName == "SHI")
                {
                    this.m_City = sValue;
                }
                else if (sControlName == this.GetNodeValue("CntyField"))
                {
                    control.Focus();
                    control.ItemFilter(this.m_City);
                    this.m_Cnty = sValue;
                }
                else if (sControlName == this.GetNodeValue("TownField"))
                {
                    control.ItemFilter(this.m_Cnty);
                    this.m_Town = sValue;
                }
                else if (sControlName == this.GetNodeValue("VillField"))
                {
                    control.ItemFilter(this.m_Town);
                    this.m_Vill = sValue;
                }
            }
        }

        /// <summary>
        /// 显示下拉框1
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadonly"></param>
        private void ShowComboBox1(string sControlName, string sValue, bool bReadonly)
        {
            try
            {
                ZLComboBox control = this.GetControl(sControlName) as ZLComboBox;
                if (control != null)
                {
                    int num = -1;
                    control.ClearItems();
                    control.AddItem("<空>", "");
                    num = 0;
                 //   IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                    if ((this.m_Town == null) || (this.m_Town == string.Empty))
                    {
                        string sCmdText = "select CNAME from T_SYS_META_CODE where CDOMAIN='CUN' and CCODE='" + sValue + "'";
                        object obj2 = null;// dBAccess.ExecuteScalar(sCmdText);
                        if (obj2 != null)
                        {
                            control.AddItem(obj2.ToString(), sValue);
                            num = 1;
                        }
                        control.SelectedIndex = num;
                    }
                    else
                    {
                        string sql = "select CCODE,CNAME from T_SYS_META_CODE where CDOMAIN='CUN' and PCODE='" + this.m_Town + "'";
                        DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                        if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                        {
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                string str3 = dataTable.Rows[i]["CCODE"].ToString();
                                control.AddItem(dataTable.Rows[i]["CNAME"].ToString(), str3);
                                if (str3 == sValue)
                                {
                                    num = i + 1;
                                }
                            }
                            control.SelectedIndex = -1;
                            control.Enabled = !bReadonly;
                            if (num == -1)
                            {
                                control.SelectedIndex = 0;
                            }
                            else
                            {
                                control.SelectedIndex = num;
                            }
                            if (sControlName == this.GetNodeValue("VillField"))
                            {
                                this.m_Vill = sValue;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示控件里的值
        /// </summary>
        /// <param name="sField"></param>
        /// <param name="sValue"></param>
        private void ShowControlValue(string sField, string sValue)
        {
            try
            {
                Control control = this.GetControl(sField);
                if (control != null)
                {
                    control.Text = sValue;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示时间编辑
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="pValue"></param>
        /// <param name="bReadOnly"></param>
        /// <param name="bDay"></param>
        private void ShowDateEdit(string sControlName, object pValue, bool bReadOnly, bool bDay)
        {
            DateEdit control = this.GetControl(sControlName) as DateEdit;
            if (control != null)
            {
                control.Enabled = !bReadOnly;
                string str = pValue.ToString();
                if ((str == "") || (str.Length < 8))
                {
                    control.Text = "";
                }
                else if (str.Substring(0, 4) == "1899")
                {
                    control.Text = "";
                }
                else if (bDay)
                {
                    DateTime time = Convert.ToDateTime(str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2));
                    control.DateTime = time;
                }
                else
                {
                    DateTime time2 = Convert.ToDateTime(str);
                    control.DateTime = time2;
                }
            }
        }

        /// <summary>
        /// 显示地类
        /// </summary>
        /// <param name="pField"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadOnly"></param>
        private void ShowDL(IField pField, string sValue, bool bReadOnly)
        {
            IDomain domain = pField.Domain;
            if ((domain != null) && (domain is ICodedValueDomain))
            {
                ZLComboBox control = this.GetControl(pField.Name) as ZLComboBox;
                control.DrawMode = DrawMode.OwnerDrawFixed;
                control.ClearItems();
                IList list = new ArrayList();
                IList list2 = new ArrayList();
                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                if (pField.IsNullable)
                {
                    control.AddItem("<空>", "");
                }
                for (int i = 0; i < domain2.CodeCount; i++)
                {
                    string str = domain2.get_Value(i).ToString();
                    list.Add(domain2.get_Name(i));
                    list2.Add(str);
                }
                string[] strArray = new string[] { "100", "200", "300", "400", "500", "600", "700", "800", "900" };
                string[] strArray2 = new string[] { "林地", "疏林地", "灌木林地", "未成林地", "苗圃地", "无立木林地", "宜林地", "林业辅助生产林地", "非林地" };
                int num2 = 0;
                int num3 = 0;
                for (int j = 0; j < strArray.Length; j++)
                {
                    num2++;
                    string str2 = strArray[j];
                    switch (str2)
                    {
                        case "200":
                        case "500":
                        case "800":
                            control.AddItem(strArray2[j], str2, true);
                            break;

                        default:
                            control.AddItem(strArray2[j], str2, false);
                            break;
                    }
                    if (str2 == sValue)
                    {
                        num3 = num2;
                    }
                    for (int k = 0; k < list2.Count; k++)
                    {
                        string str3 = list2[k].ToString();
                        if ((str2.Substring(0, 1) == str3.Substring(0, 1)) && (str2 != str3))
                        {
                            num2++;
                            control.AddItem(list[k].ToString(), str3, true, 1);
                            if (str3 == sValue)
                            {
                                num3 = num2;
                            }
                        }
                    }
                }
                control.Enabled = !bReadOnly;
                control.SelectedIndex = num3;
            }
        }

        /// <summary>
        /// 显示字段值
        /// </summary>
        /// <param name="pField"></param>
        /// <param name="pValue"></param>
        /// <param name="sControlName"></param>
        /// <param name="sAreaField"></param>
        /// <param name="sZTAreaField"></param>
        private void ShowFieldValue(IField pField, object pValue, string sControlName, string sAreaField, string sZTAreaField)
        {
            try
            {
                string sValue = pValue.ToString();
                bool bReadOnly = !pField.Editable;
                if (this.m_DayFields.Contains<string>(sControlName))
                {
                    this.ShowDateEdit(sControlName, pValue, bReadOnly, true);
                }
                else if (sControlName == "BHYY")
                {
                    this.ShowBHYY(pField, sValue, bReadOnly);
                }
                else if ((sControlName == "DI_LEI") || (sControlName == "Q_DI_LEI"))
                {
                    this.ShowDL(pField, sValue, bReadOnly);
                }
                else
                {
                    string str3 = this.m_KindCode.Substring(0, 2);
                    if (str3 != null)
                    {
                        if (str3 == "01")
                        {
                            if ((sControlName != "ZYTZJF") && (sControlName != "DFTZJF"))
                            {
                                if (sControlName == "ZJLY")
                                {
                                    this.ShowZJLY(sControlName, sValue, bReadOnly);
                                    return;
                                }
                            }
                            else
                            {
                                bReadOnly = true;
                            }
                        }
                        else if (str3 == "02")
                        {
                            if (sControlName == "SFCF")
                            {
                                this.ShowSF(sControlName, sValue, bReadOnly);
                                return;
                            }
                            if ((sControlName == "CUN") && (UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey").ToLower() == "access"))
                            {
                                this.ShowComboBox1(sControlName, sValue, bReadOnly);
                            }
                        }
                        else if (str3 == "04")
                        {
                            if ((sControlName != "SLXJ") && (sControlName != "LDYT"))
                            {
                                if ((sControlName == "XFSS") || (sControlName == "SFTGD"))
                                {
                                    this.ShowSF(sControlName, sValue, bReadOnly);
                                    return;
                                }
                            }
                            else
                            {
                                bReadOnly = true;
                            }
                        }
                        else if (str3 == "05")
                        {
                            if (sControlName == UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "IDField"))
                            {
                                this.ShowFireNo(pField, sValue, bReadOnly);
                                return;
                            }
                        }
                        else if ((str3 == "06") || (str3 == "07"))
                        {
                        }
                    }
                    IDomain domain = null;
                    ICodedValueDomain domain2 = null;
                    IList pItems = new ArrayList();
                    IList pValueList = new ArrayList();
                    if (pField.Type != esriFieldType.esriFieldTypeBlob)
                    {
                        domain = pField.Domain;
                        if (domain != null)
                        {
                            if (domain is ICodedValueDomain)
                            {
                                domain2 = domain as ICodedValueDomain;
                                if (pField.IsNullable)
                                {
                                    pItems.Add("<空>");
                                    pValueList.Add("");
                                }
                                for (int i = 0; i < domain2.CodeCount; i++)
                                {
                                    pItems.Add(domain2.get_Name(i));
                                    pValueList.Add(domain2.get_Value(i));
                                }
                                this.ShowComboBox(sControlName, sValue, pItems, pValueList, bReadOnly);
                            }
                            else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                            {
                                double dMinValue = 0.0;
                                double dMaxValue = 0.0;
                                if (domain is IRangeDomain)
                                {
                                    dMinValue = (double) (domain as IRangeDomain).MinValue;
                                    dMaxValue = (double) (domain as IRangeDomain).MaxValue;
                                }
                                if (!bReadOnly)
                                {
                                    this.ShowSpinEdit(sControlName, pValue, bReadOnly, dMinValue, dMaxValue, true, pField.Scale);
                                }
                                else
                                {
                                    this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                                }
                            }
                            else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                            {
                                double minValue = 0.0;
                                double maxValue = 0.0;
                                if (domain is IRangeDomain)
                                {
                                    minValue = (double) (domain as IRangeDomain).MinValue;
                                    maxValue = (double) (domain as IRangeDomain).MaxValue;
                                }
                                if (!bReadOnly)
                                {
                                    this.ShowSpinEdit(sControlName, pValue, bReadOnly, minValue, maxValue, false, 0);
                                }
                                else
                                {
                                    this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                                }
                            }
                            else if (pField.Type == esriFieldType.esriFieldTypeDate)
                            {
                                this.ShowDateEdit(sControlName, pValue, bReadOnly, false);
                            }
                            else
                            {
                                this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                        {
                            if (!bReadOnly)
                            {
                                if (this.m_YbdFields.Contains<string>(pField.Name))
                                {
                                    this.ShowSpinEdit(sControlName, pValue, bReadOnly, 0.0, 1.0, true, pField.Scale);
                                }
                                else
                                {
                                    this.ShowSpinEdit(sControlName, pValue, bReadOnly, 0.0, 0.0, true, pField.Scale);
                                }
                            }
                            else
                            {
                                this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                        {
                            if (!bReadOnly)
                            {
                                this.ShowSpinEdit(sControlName, pValue, bReadOnly, 0.0, 0.0, false, 0);
                            }
                            else
                            {
                                this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                            }
                        }
                        else if (pField.Type == esriFieldType.esriFieldTypeDate)
                        {
                            this.ShowDateEdit(sControlName, pValue, bReadOnly, false);
                        }
                        else
                        {
                            this.ShowTextEdit(sControlName, pValue, bReadOnly, pField.Length);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示火灾表
        /// </summary>
        /// <param name="pField"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadOnly"></param>
        private void ShowFireNo(IField pField, string sValue, bool bReadOnly)
        {
            try
            {
                string nodeValue = this.GetNodeValue("FireTable");
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                if (editWorkspace != null)
                {
                    ITable table = null;
                    try
                    {
                        table = editWorkspace.OpenTable(nodeValue);
                    }
                    catch
                    {
                        return;
                    }
                    if (table != null)
                    {
                        ICursor o = table.Search(null, false);
                        if (o != null)
                        {
                            string name = this.GetNodeValue("IDField");
                            string str3 = this.GetNodeValue("PlaceField");
                            string str4 = this.GetNodeValue("TimeField");
                            int index = table.FindField(name);
                            if (index >= 0)
                            {
                                int num2 = table.FindField(str3);
                                int num3 = table.FindField(str4);
                                IList pItems = new ArrayList();
                                IList pValueList = new ArrayList();
                                if (pField.IsNullable)
                                {
                                    pItems.Add("<空>");
                                    pValueList.Add("");
                                }
                                IRow row = null;
                                while ((row = o.NextRow()) != null)
                                {
                                    string str5 = row.get_Value(index).ToString();
                                    string str6 = "";
                                    if (num2 >= 0)
                                    {
                                        str6 = row.get_Value(num2).ToString();
                                    }
                                    string str7 = "";
                                    if (num3 >= 0)
                                    {
                                        try
                                        {
                                            str7 = Convert.ToDateTime(row.get_Value(num3).ToString()).ToString("yyyy年MM月dd日HH时mm分ss秒");
                                        }
                                        catch
                                        {
                                            str7 = "";
                                        }
                                    }
                                    pItems.Add(str7 + "(" + str6 + ")");
                                    pValueList.Add(str5);
                                }
                                Marshal.ReleaseComObject(o);
                                this.userControlFireAttr1.IsShowed = false;
                                this.ShowComboBox(pField.Name, sValue, pItems, pValueList, bReadOnly);
                                this.userControlFireAttr1.IsShowed = true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadOnly"></param>
        private void ShowSF(string sControlName, string sValue, bool bReadOnly)
        {
            IList pItems = new ArrayList();
            IList pValueList = new ArrayList();
            pItems.Add("<空>");
            pValueList.Add("");
            pItems.Add("是");
            pValueList.Add("是");
            pItems.Add("否");
            pValueList.Add("否");
            this.ShowComboBox(sControlName, sValue, pItems, pValueList, bReadOnly);
        }

        /// <summary>
        /// 显示分裂的编辑框
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="pValue"></param>
        /// <param name="bReadOnly"></param>
        /// <param name="dMinValue"></param>
        /// <param name="dMaxValue"></param>
        /// <param name="bFloat"></param>
        /// <param name="iScale"></param>
        private void ShowSpinEdit(string sControlName, object pValue, bool bReadOnly, double dMinValue, double dMaxValue, bool bFloat, int iScale)
        {
            ZLSpinEdit control = this.GetControl(sControlName) as ZLSpinEdit;
            if (control == null)
            {
                this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
            }
            else
            {
                control.Properties.AllowNullInput = DefaultBoolean.True;
                control.Properties.NullText = "";
                control.Enabled = !bReadOnly;
                control.Properties.IsFloatValue = bFloat;
                control.EditScale = iScale;
                if ((dMinValue != 0.0) || (dMaxValue != 0.0))
                {
                    control.Properties.MaxValue = (decimal) dMaxValue;
                    control.Properties.MinValue = (decimal) dMinValue;
                }
                if ((pValue == null) || (pValue == DBNull.Value))
                {
                    control.EditValue = null;
                }
                else
                {
                    string str = pValue.ToString();
                    decimal num = 0M;
                    if (str != "")
                    {
                        num = Convert.ToDecimal(str);
                    }
                    control.Value = num;
                }
            }
        }

        /// <summary>
        /// 显示文本编辑框
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="pValue"></param>
        /// <param name="bReadOnly"></param>
        /// <param name="iLength"></param>
        private void ShowTextEdit(string sControlName, object pValue, bool bReadOnly, int iLength)
        {
            TextEdit control = this.GetControl(sControlName) as TextEdit;
            if (control != null)
            {
                control.Enabled = !bReadOnly;
                if (iLength > 0)
                {
                    control.Properties.MaxLength = iLength;
                }
                control.Text = pValue.ToString();
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="sValue"></param>
        /// <param name="bReadOnly"></param>
        private void ShowZJLY(string sControlName, string sValue, bool bReadOnly)
        {
            Control control = this.GetControl(sControlName);
            if (control != null)
            {
                CheckedListBoxControl control2 = control as CheckedListBoxControl;
                string[] source = sValue.Split(new char[] { ',' });
                for (int i = 0; i < control2.Items.Count; i++)
                {
                    string str = control2.Items[i].Value.ToString();
                    if (source.Contains<string>(str))
                    {
                        control2.Items[i].CheckState = CheckState.Checked;
                    }
                    else
                    {
                        control2.Items[i].CheckState = CheckState.Unchecked;
                    }
                }
                this.userControlAffAttr1.InitZJLY();
            }
        }

        private void ShowZZBH(IField pField, string sValue, bool bReadOnly)
        {
            try
            {
                string nodeValue = this.GetNodeValue("ExproTable");
                string str2 = this.GetNodeValue("TaskIDField");
                string str3 = this.GetNodeValue("TaskNameField");
                string str4 = this.GetNodeValue("TaskTimeField");
                string sql = "select " + str2 + "," + str3 + "," + str4 + " from " + nodeValue + " where taskkind like '04%'";
               // IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue("DBKey"));
              //  if (dBAccess != null)
                {
                    DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                    if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                    {
                        IList pItems = new ArrayList();
                        IList pValueList = new ArrayList();
                        if (pField.IsNullable)
                        {
                            pItems.Add("<空>");
                            pValueList.Add("");
                        }
                        DataRow row = null;
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            row = dataTable.Rows[i];
                            string str7 = row[str2].ToString();
                            string str8 = row[str3].ToString();
                            pItems.Add(str8);
                            pValueList.Add(str7);
                        }
                        bReadOnly = true;
                        this.ShowComboBox(pField.Name, sValue, pItems, pValueList, bReadOnly);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 提交该数据的代码值
        /// </summary>
        private void SubmitSubCode()
        {
            try
            {
                IObject editFeature = this.m_EditFeature;
                string nodeValue = this.GetNodeValue("VillField");
                string sFieldName = this.GetNodeValue("LBField");
                string str3 = this.GetNodeValue("XBField");
                string str4 = DataFuncs.GetFieldValue(editFeature, nodeValue).ToString();
                string str5 = DataFuncs.GetFieldValue(editFeature, sFieldName).ToString();
                string str6 = DataFuncs.GetFieldValue(editFeature, str3).ToString();
                string pFieldValue = str4 + str5 + str6;
                string str8 = this.GetNodeValue("IDField");
                DataFuncs.UpdateField(editFeature, str8, pFieldValue);
                editFeature.Store();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 提交值
        /// </summary>
        /// <returns></returns>
        private bool SubmitValue()
        {
            try
            {
                IObject editFeature = this.m_EditFeature;
                IFields fields = editFeature.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (field.Editable)
                    {
                        Control pControl = this.GetControl(field.Name);
                        if (pControl != null)
                        {
                            int iLength = 0;
                            if (field.Type == esriFieldType.esriFieldTypeString)
                            {
                                iLength = field.Length;
                            }
                            object controlValue = this.GetControlValue(pControl, iLength);
                            if (controlValue == null)
                            {
                                editFeature.set_Value(i, DBNull.Value);
                            }
                            else
                            {
                                editFeature.set_Value(i, controlValue);
                            }
                        }
                    }
                }
                editFeature.Store();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "SubmitValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        /// <summary>
        /// 提交项目名称
        /// </summary>
        private void SubmitXMName()
        {
            try
            {
                IObject editFeature = this.m_EditFeature;
                string nodeValue = this.GetNodeValue("XMNameField");
                string sControlName = this.GetNodeValue("XMField");
                Control control = this.GetControl(sControlName);
                if (control != null)
                {
                    string selectedName = ((ZLComboBox) control).GetSelectedName();
                    DataFuncs.UpdateField(editFeature, nodeValue, selectedName);
                    editFeature.Store();
                }
            }
            catch
            {
            }
        }
        
        /// <summary>
        /// 撤销的实现方法
        /// </summary>
        public void Undo()
        {
            EditTask.LogicChkState = LogicCheckState.Failure;
            this.m_KindCode = EditTask.KindCode;
            this.panelSubmit.Visible = false;
            this.panelCut.Visible = false;
            switch (this.m_KindCode.Substring(0, 2))
            {
                case "08":
                case "01":
                case "02":
                case "05":
                case "04":
                case "09":
                    this.panelAttr.Visible = false;
                    this.panelCut.Visible = false;
                    this.labelSubmit.Text = "";
                    return;
            }
            this.userControlHarAttr1.Visible = false;
            this.userControlAffAttr1.Visible = false;
            this.userControlSubAttr1.Visible = false;
            this.userControlCommonEdit1.Visible = true;
            this.userControlCommonEdit1.Undo();
        }

        /// <summary>
        /// 设置图幅号
        /// </summary>
        private void userControlAffAttr1_OnSetTfh()
        {
            try
            {
                IFeature editFeature = this.m_EditFeature;
                if (editFeature != null)
                {
                    IGeometry shapeCopy = editFeature.ShapeCopy;
                    if (!shapeCopy.IsEmpty)
                    {
                        IFeatureLayer tFHLayer = EditTask.TFHLayer;
                        if (tFHLayer != null)
                        {
                            IFeatureClass featureClass = tFHLayer.FeatureClass;
                            if (featureClass != null)
                            {
                                ISpatialFilter filter = new SpatialFilterClass {
                                    Geometry = shapeCopy,
                                    GeometryField = featureClass.ShapeFieldName,
                                    SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
                                };
                                IFeature pObj = featureClass.Search(filter, false).NextFeature();
                                if (pObj != null)
                                {
                                    this.ShowTextEdit("TFH", DataFuncs.GetFieldValue(pObj, "旧图幅号").ToString() + "," + DataFuncs.GetFieldValue(pObj, "新图幅号").ToString(), true, -1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.UserControlAttrEdit", "SetTuf", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void userControlHarAttr1_OnPrintHarvest()
        {
            IFeature editFeature = this.m_EditFeature;
            if (editFeature != null)
            {
                new FormHarTable { ShowFeature = editFeature }.ShowDialog();
            }
        }

        private void userControlHarAttr1_OnShowJCTable(bool bShow)
        {
            if (this.m_EditFeature != null)
            {
                if (bShow)
                {
                    this.userControlHarAttr1.ShowJCTable(this.m_EditFeature);
                }
                else
                {
                    this.panelSubmit.Visible = true;
                }
            }
        }

        /// <summary>
        /// 获取userControlSubAttr1窗体里的属性值
        /// </summary>
        /// <param name="pPoint"></param>
        /// <param name="iType"></param>
        private void userControlSubAttr1_OnGetAttributes(IPoint pPoint, int iType)
        {
            IEnvelope searchEnvelope = DataFuncs.GetSearchEnvelope(this.m_hookHelper.ActiveView, pPoint);
            if (searchEnvelope != null)
            {
                IFeatureLayer pFLayer = null;
                if (iType == 0)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    pFLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.FocusMap as IBasicMap, configValue, true);
                }
                else
                {
                    string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName");
                    pFLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.FocusMap as IBasicMap, sLayerName, true);
                }
                if (pFLayer != null)
                {
                    IFeature pEditObject = null;
                    pEditObject = DataFuncs.SearchFeature(pFLayer, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                    if (pEditObject == null)
                    {
                        XtraMessageBox.Show(this, "未选中任何小班！", "属性编辑");
                    }
                    else
                    {
                        this.ShowAttributes(pEditObject);
                        XtraMessageBox.Show(this, "已获取更改小班属性，点击“保存”按钮，保存属性。", "属性编辑");
                    }
                }
            }
        }

        public object Hook
        {
            set
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = value;
            }
        }
    }
}

