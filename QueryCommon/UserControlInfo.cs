namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FormBase;
    using FunFactory;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlInfo : UserControlBase1
    {
        private ComboBoxEdit comboBoxCF;
        private ComboBoxEdit comboBoxZL;
        private IContainer components;
        private ImageList imageList1;
        private ImageList imageList2;
        internal ImageList imageList3;
        private Label labelIdentify;
        private Label labelPosition;
        private bool m_bCoor;
        private bool m_bUnitD;
        private ITable m_CountyTable;
        private IRasterLayer m_DEMLayer;
        private IGdbRasterCatalogLayer m_DEMLayer2;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_EditLayer2;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private IFeatureLayer m_pCLayer;
        private RectangleTool m_pEnvelopeTool;
        private IFeatureLayer m_pLBLayer;
        private PointTool m_pPointTool;
        private IFeatureLayer m_pTLayer;
        private IFeatureLayer m_pVLayer;
        private IFeatureLayer m_pXBLayer;
        private ITable m_Table;
        private ITable m_Table2;
        private ITable m_Table3;
        private ITable m_TownTable;
        private ITable m_VillageTable;
        private Collection m_VisFeatureColn;
        private Collection m_VisLayerColn;
        private ArrayList m_XiaobanColn;
        private ArrayList m_XiaobanColn2;
        private ArrayList m_XiaobanColn22;
        private ArrayList m_XiaobanColn3;
        private ArrayList mCFList;
        private const string mClassName = "QueryAnalysic.UserControlInfo";
        private ArrayList mCList;
        private ArrayList mCList2;
      //  private IDBAccess mDBAccess;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private IFeatureLayer mEditLayer;
        private IEnvelope mEnvelope;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mfWorkspace;
        private ITool mLastTool;
        private ArrayList mLList;
        private ArrayList mLList2;
        private bool mNodeExpend;
        private ArrayList mOtherLayerList;
        private ArrayList mOtherList;
        private string MountainFieldsName = "";
        private ArrayList mPlaceLayerList;
        private ArrayList mPlaceList;
        private IPoint mPoint;
        private IRasterRenderer mRenderer;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mVList;
        private ArrayList mVList2;
        private ArrayList mXList;
        private ArrayList mXList2;
        private const string myClassName = "信息查询";
        private ArrayList mZLList;
        private Panel panel25;
        private Panel panel27;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private Panel panIdentify;
        private RadioGroup radioGroupInfo;
        private string sCaiFaFieldString;
        private string sCaiFaFieldString2;
        private string sConnectTableString;
        private string sDistFieldCode;
        private string sDistFieldCode2;
        private string sDistFieldCode3;
        private string sDistFieldName;
        private string sDistFieldName2;
        private string sDistFieldName3;
        private string sDistLayerName;
        private string sDistLayerName2;
        private string sDistLayerName3;
        private string sEditCodeName;
        private string sEditFieldString;
        private string sEditFieldString2;
        private string sEditLayerName;
        private string sEditLayerName2;
        private string sGYLFieldString;
        private string sGYLFieldString2;
        private string sLinbanFieldName;
        private string sLinbanLayerName;
        private string sTableFieldName;
        private string sXiaobanFieldName;
        private string sXiaobanFieldString;
        private string sXiaobanLayerName;
        private string sZaoLinFieldString2;
        private TreeView tListVisFeature;
        private TreeView tListXiaoban;
        private RichTextBox txtLocation;
        private string VillageFieldsName = "";
        private string XBCodeName = "";
        private string XBCodeName2 = "";

        public UserControlInfo()
        {
            this.InitializeComponent();
        }

        private bool AddFeatureValue(TreeNode nodeF)
        {
            try
            {
                if (nodeF.GetNodeCount(false) == 0)
                {
                    string str = nodeF.Tag.ToString();
                    if (string.IsNullOrEmpty(str))
                    {
                        return false;
                    }
                    IFeature feature = this.m_VisFeatureColn[str] as IFeature;
                    int index = 0;
                    for (index = 0; index <= (feature.Fields.FieldCount - 1); index++)
                    {
                        Application.DoEvents();
                        if (!((((feature.Fields.get_Field(index).Name == feature.Class.OIDFieldName) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).ShapeFieldName)) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).LengthField.Name)) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).AreaField.Name)))
                        {
                            string str2;
                            if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                            {
                                str2 = "";
                                ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                                string str3 = feature.get_Value(index).ToString();
                                for (int i = 0; i < domain.CodeCount; i++)
                                {
                                    if (str3 == domain.get_Value(i).ToString())
                                    {
                                        str2 = domain.get_Name(i);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                str2 = feature.get_Value(index).ToString();
                            }
                            if (str2 != "")
                            {
                                try
                                {
                                    nodeF.Nodes.Add(feature.Fields.get_Field(index).AliasName + ": " + str2);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    nodeF.Expand();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "AddFeatureValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void AddXiaobanValue(IPoint pPoint)
        {
            try
            {
                this.tListXiaoban.Nodes.Clear();
                if (this.GetXiaoban(pPoint))
                {
                    Application.DoEvents();
                    if ((this.m_XiaobanColn != null) && (this.m_XiaobanColn.Count != 0))
                    {
                        TreeNode node = null;
                        IFeature feature = null;
                        int num = 0;
                        int index = 0;
                        for (num = 0; num < this.m_XiaobanColn.Count; num++)
                        {
                            feature = (IFeature) this.m_XiaobanColn[num];
                            int num3 = feature.Fields.FindField(this.XBCodeName);
                            if (num3 < 0)
                            {
                                return;
                            }
                            string text = (string) feature.get_Value(num3);
                            node = this.tListXiaoban.Nodes.Add(text);
                            node.Tag = num;
                            node.ForeColor = Color.Blue;
                            node.Expand();
                            string str2 = string.Empty;
                            for (index = 0; index <= (feature.Fields.FieldCount - 1); index++)
                            {
                                if (((!this.CheckFieldVisiable(feature.Fields.get_Field(index).Name, "", false) || (feature.Fields.get_Field(index).Name == feature.Class.OIDFieldName)) || ((feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).ShapeFieldName) || (feature.Fields.get_Field(index) == (feature.Class as IFeatureClass).LengthField))) || (feature.Fields.get_Field(index) == (feature.Class as IFeatureClass).AreaField))
                                {
                                    continue;
                                }
                                if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                                {
                                    str2 = "";
                                    try
                                    {
                                        if (feature.get_Value(index) is DBNull)
                                        {
                                            str2 = "";
                                        }
                                        else if (feature.get_Value(index).ToString().Trim() == "")
                                        {
                                            str2 = "";
                                        }
                                        else
                                        {
                                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                                            long num4 = Convert.ToInt64(feature.get_Value(index));
                                            for (int i = 0; i < domain.CodeCount; i++)
                                            {
                                                if (num4 == Convert.ToInt64(domain.get_Value(i)))
                                                {
                                                    str2 = domain.get_Name(i);
                                                    goto Label_0273;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        str2 = feature.get_Value(index).ToString();
                                    }
                                }
                                else
                                {
                                    str2 = feature.get_Value(index).ToString();
                                }
                            Label_0273:
                                try
                                {
                                    node.Nodes.Add(feature.Fields.get_Field(index).AliasName + ": " + str2);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            if (num == 0)
                            {
                                node.Expand();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "AddXiaobanValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddXiaobanValue2(IPoint pPoint)
        {
            try
            {
                this.tListXiaoban.Nodes.Clear();
                if (this.GetXiaoban2(pPoint))
                {
                    Application.DoEvents();
                    if (((this.m_XiaobanColn2 != null) || (this.m_XiaobanColn22 != null)) && ((this.m_XiaobanColn2.Count != 0) || (this.m_XiaobanColn22.Count != 0)))
                    {
                        TreeNode node = null;
                        TreeNode node2 = null;
                        TreeNode node3 = null;
                        int num = 0;
                        int index = 0;
                        string str = string.Empty;
                        string skeyvalue = "";
                        bool flag = false;
                        if (this.mEditKind.Contains("采伐"))
                        {
                            skeyvalue = this.sCaiFaFieldString2;
                            flag = false;
                        }
                        skeyvalue = this.sEditFieldString2;
                        if (this.m_XiaobanColn2 != null)
                        {
                            for (num = 0; num < this.m_XiaobanColn2.Count; num++)
                            {
                                IFeature feature = this.m_XiaobanColn2[num] as IFeature;
                                int num3 = feature.Fields.FindField(this.sEditCodeName);
                                if (num3 < 0)
                                {
                                    break;
                                }
                                string text = feature.get_Value(num3).ToString();
                                node = this.tListXiaoban.Nodes.Add(text);
                                node.Tag = feature;
                                node.ForeColor = Color.Blue;
                                node.ExpandAll();
                                index = 1;
                                while (index < feature.Fields.FieldCount)
                                {
                                    if (!this.CheckFieldVisiable(feature.Fields.get_Field(index).Name, skeyvalue, flag) || ((((feature.Fields.get_Field(index).Name == feature.Class.OIDFieldName) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).ShapeFieldName)) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).LengthField.Name)) | (feature.Fields.get_Field(index).Name == (feature.Class as IFeatureClass).AreaField.Name)))
                                    {
                                        goto Label_033A;
                                    }
                                    if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                                    {
                                        str = "";
                                        try
                                        {
                                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                                            long num4 = Convert.ToInt64(feature.get_Value(index));
                                            for (int i = 0; i < domain.CodeCount; i++)
                                            {
                                                if (num4 == Convert.ToInt64(domain.get_Value(i)))
                                                {
                                                    str = domain.get_Name(i);
                                                    goto Label_02F7;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            str = feature.get_Value(index).ToString();
                                        }
                                    }
                                    else if (feature.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeDate)
                                    {
                                        if (feature.get_Value(index).ToString() == "1899/12/30 0:00:00")
                                        {
                                            str = "";
                                        }
                                        else
                                        {
                                            str = feature.get_Value(index).ToString();
                                        }
                                    }
                                    else
                                    {
                                        str = feature.get_Value(index).ToString();
                                    }
                                Label_02F7:
                                    if ((str != "") || (index != -1))
                                    {
                                        try
                                        {
                                            node2 = node.Nodes.Add(feature.Fields.get_Field(index).AliasName + ": " + str);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                Label_033A:
                                    index++;
                                }
                                if ((this.m_Table != null) && (this.sConnectTableString != ""))
                                {
                                    string str4 = this.sConnectTableString.Split(new char[] { ';' })[0];
                                    string str5 = this.sConnectTableString.Split(new char[] { ';' })[1];
                                    string[] strArray = str4.Split(new char[] { ',' });
                                    string[] strArray2 = str5.Split(new char[] { ',' });
                                    string str6 = "";
                                    for (int j = 0; j < strArray.Length; j++)
                                    {
                                        int num7 = feature.Fields.FindField(strArray[j]);
                                        if (str6 == "")
                                        {
                                            str6 = string.Concat(new object[] { strArray2[j], "='", feature.get_Value(num7), "'" });
                                        }
                                        else
                                        {
                                            str6 = string.Concat(new object[] { str6, " and ", strArray2[j], "='", feature.get_Value(num7), "'" });
                                        }
                                    }
                                    IQueryFilter queryFilter = new QueryFilterClass();
                                    queryFilter.WhereClause = str6;
                                    ICursor cursor = this.m_Table.Search(queryFilter, false);
                                    IRow row = cursor.NextRow();
                                    if (row != null)
                                    {
                                        string aliasName = (this.m_Table as IObjectClass).AliasName;
                                        node2 = node.Nodes.Add(aliasName);
                                    }
                                    int num8 = 0;
                                    while (row != null)
                                    {
                                        num8++;
                                        if (this.mEditKind == "火灾")
                                        {
                                            for (int k = 0; k < row.Fields.FieldCount; k++)
                                            {
                                                IField field = row.Fields.get_Field(k);
                                                for (int m = 0; m < strArray2.Length; m++)
                                                {
                                                    if (strArray2[m] == field.Name)
                                                    {
                                                        goto Label_0652;
                                                    }
                                                }
                                                if (field.Name == row.Table.OIDFieldName)
                                                {
                                                    goto Label_0652;
                                                }
                                                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                                                {
                                                    str = "";
                                                    try
                                                    {
                                                        ICodedValueDomain domain2 = (ICodedValueDomain) row.Fields.get_Field(k).Domain;
                                                        long num11 = Convert.ToInt64(row.get_Value(k));
                                                        for (int n = 0; n < domain2.CodeCount; n++)
                                                        {
                                                            if (num11 == Convert.ToInt64(domain2.get_Value(n)))
                                                            {
                                                                str = domain2.get_Name(n);
                                                                goto Label_061B;
                                                            }
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        str = row.get_Value(k).ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    str = row.get_Value(k).ToString();
                                                }
                                            Label_061B:
                                                if ((str != "") || (k != -1))
                                                {
                                                    try
                                                    {
                                                        node3 = node2.Nodes.Add(field.AliasName + ":" + str);
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                }
                                            Label_0652:
                                                node2.Collapse();
                                            }
                                        }
                                        else
                                        {
                                            int num13 = row.Fields.FindField(this.sTableFieldName);
                                            if (num13 > -1)
                                            {
                                                node3 = node2.Nodes.Add(row.Fields.get_Field(num13).AliasName + ":" + row.get_Value(num13));
                                            }
                                            else
                                            {
                                                node3 = node2.Nodes.Add("编号:" + num8.ToString());
                                            }
                                            node2.Expand();
                                            for (int num14 = 0; num14 < row.Fields.FieldCount; num14++)
                                            {
                                                IField field2 = row.Fields.get_Field(num14);
                                                for (int num15 = 0; num15 < strArray2.Length; num15++)
                                                {
                                                    if (strArray2[num15] == field2.Name)
                                                    {
                                                        goto Label_0821;
                                                    }
                                                }
                                                if (field2.Name == row.Table.OIDFieldName)
                                                {
                                                    goto Label_0821;
                                                }
                                                if ((field2.Domain != null) && (field2.Domain.Type == esriDomainType.esriDTCodedValue))
                                                {
                                                    str = "";
                                                    try
                                                    {
                                                        ICodedValueDomain domain3 = (ICodedValueDomain) row.Fields.get_Field(num14).Domain;
                                                        long num16 = Convert.ToInt64(row.get_Value(num14));
                                                        for (int num17 = 0; num17 < domain3.CodeCount; num17++)
                                                        {
                                                            if (num16 == Convert.ToInt64(domain3.get_Value(num17)))
                                                            {
                                                                str = domain3.get_Name(num17);
                                                                goto Label_07EA;
                                                            }
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        str = row.get_Value(num14).ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    str = row.get_Value(num14).ToString();
                                                }
                                            Label_07EA:
                                                if ((str != "") || (num14 != -1))
                                                {
                                                    try
                                                    {
                                                        node3.Nodes.Add(field2.AliasName + ":" + str);
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                }
                                            Label_0821:
                                                node3.Collapse();
                                            }
                                        }
                                        row = cursor.NextRow();
                                    }
                                }
                                if (num == 0)
                                {
                                    node.Expand();
                                }
                            }
                        }
                        if (this.m_XiaobanColn22 != null)
                        {
                            for (num = 0; num < this.m_XiaobanColn22.Count; num++)
                            {
                                IFeature feature2 = this.m_XiaobanColn22[num] as IFeature;
                                int num18 = feature2.Fields.FindField(this.sEditCodeName);
                                if (num18 < 0)
                                {
                                    return;
                                }
                                string str8 = feature2.get_Value(num18).ToString();
                                node = this.tListXiaoban.Nodes.Add(str8);
                                node.Tag = feature2;
                                node.ForeColor = Color.Blue;
                                node.ExpandAll();
                                for (index = 1; index < feature2.Fields.FieldCount; index++)
                                {
                                    if (!this.CheckFieldVisiable(feature2.Fields.get_Field(index).Name, skeyvalue, flag) || ((((((feature2.Fields.get_Field(index).Name.ToLower() == "objectid") | (feature2.Fields.get_Field(index).Name.ToLower() == "shape_length")) | (feature2.Fields.get_Field(index).Name.ToLower() == "shape_area")) | (feature2.Fields.get_Field(index).Name.ToLower() == "shape.len")) | (feature2.Fields.get_Field(index).Name.ToLower() == "shape.area")) | (feature2.Fields.get_Field(index).Name.ToLower() == "shape")))
                                    {
                                        continue;
                                    }
                                    if ((feature2.Fields.get_Field(index).Domain != null) && (feature2.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                                    {
                                        str = "";
                                        try
                                        {
                                            ICodedValueDomain domain4 = (ICodedValueDomain) feature2.Fields.get_Field(index).Domain;
                                            long num19 = Convert.ToInt64(feature2.get_Value(index));
                                            for (int num20 = 0; num20 < domain4.CodeCount; num20++)
                                            {
                                                if (num19 == Convert.ToInt64(domain4.get_Value(num20)))
                                                {
                                                    str = domain4.get_Name(num20);
                                                    goto Label_0AA9;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            str = feature2.get_Value(index).ToString();
                                        }
                                    }
                                    else
                                    {
                                        str = feature2.get_Value(index).ToString();
                                    }
                                Label_0AA9:
                                    if ((str != "") || (index != -1))
                                    {
                                        try
                                        {
                                            node2 = node.Nodes.Add(feature2.Fields.get_Field(index).AliasName + ": " + str);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                                if (num == 0)
                                {
                                    node.Expand();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "AddXiaobanValue2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool CheckFeatureLayerScale(IGeoFeatureLayer pGeoLayer)
        {
            try
            {
                double mapScale = 0.0;
                mapScale = this.m_HookHelper.FocusMap.MapScale;
                if (pGeoLayer.FeatureClass == null)
                {
                    return false;
                }
                if ((pGeoLayer.MinimumScale > 0.0) && (pGeoLayer.MinimumScale < mapScale))
                {
                    return false;
                }
                if ((pGeoLayer.MaximumScale > 0.0) && (pGeoLayer.MaximumScale > mapScale))
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "CheckFeatureLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool CheckFeatureLayerVisible(IGeoFeatureLayer pGeoLayer)
        {
            try
            {
                if (!pGeoLayer.Visible)
                {
                    return false;
                }
                double mapScale = 0.0;
                mapScale = this.m_HookHelper.FocusMap.MapScale;
                IEnumLayer layer = null;
                UID uid = new UIDClass();
                uid.Value = "{EDAD6644-1810-11D1-86AE-0000F8751720}";
                layer = this.m_HookHelper.FocusMap.get_Layers(uid, true);
                layer.Reset();
                IGroupLayer layer2 = layer.Next() as IGroupLayer;
                ICompositeLayer layer3 = null;
                int index = 0;
                while (layer2 != null)
                {
                    layer3 = layer2 as ICompositeLayer;
                    for (index = 0; index <= (layer3.Count - 1); index++)
                    {
                        if (object.ReferenceEquals(layer3.get_Layer(index), pGeoLayer))
                        {
                            if (!layer2.Visible)
                            {
                                return false;
                            }
                            if ((layer2.MinimumScale > 0.0) | (layer2.MaximumScale > 0.0))
                            {
                                if (layer2.MinimumScale < mapScale)
                                {
                                    return false;
                                }
                                if (layer2.MaximumScale > mapScale)
                                {
                                    return false;
                                }
                                return true;
                            }
                            if (pGeoLayer.FeatureClass == null)
                            {
                                return false;
                            }
                            if ((pGeoLayer.MinimumScale > 0.0) && (pGeoLayer.MinimumScale < mapScale))
                            {
                                return false;
                            }
                            if ((pGeoLayer.MaximumScale > 0.0) && (pGeoLayer.MaximumScale > mapScale))
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                    layer2 = layer.Next() as IGroupLayer;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "CheckFeatureLayerVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return true;
            }
        }

        private bool CheckFieldVisiable(string sname, string skeyvalue, bool flag)
        {
            try
            {
                string configValue = "";
                if (skeyvalue == "")
                {
                    skeyvalue = this.mEditKind2 + "FieldString2";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue(skeyvalue);
                }
                else
                {
                    configValue = skeyvalue;
                }
                string[] strArray = configValue.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToLower() == sname.ToLower())
                    {
                        return flag;
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "CheckFieldVisiable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool CheckRasterLayer(IRasterLayer pRasLayer)
        {
            bool flag;
            try
            {
                if (pRasLayer.Raster == null)
                {
                    return false;
                }
                if (!pRasLayer.Visible)
                {
                    flag = false;
                }
                else
                {
                    double mapScale = 0.0;
                    mapScale = this.m_HookHelper.FocusMap.MapScale;
                    try
                    {
                        IEnumLayer layer = null;
                        UID uid = new UIDClass();
                        uid.Value = "{EDAD6644-1810-11D1-86AE-0000F8751720}";
                        layer = this.m_HookHelper.FocusMap.get_Layers(uid, true);
                        layer.Reset();
                        IGroupLayer layer2 = layer.Next() as IGroupLayer;
                        ICompositeLayer layer3 = null;
                        int index = 0;
                        while (layer2 != null)
                        {
                            layer3 = layer2 as ICompositeLayer;
                            for (index = 0; index <= (layer3.Count - 1); index++)
                            {
                                if (object.ReferenceEquals(layer3.get_Layer(index), pRasLayer))
                                {
                                    if (!layer2.Visible)
                                    {
                                        return false;
                                    }
                                    if ((layer2.MinimumScale > 0.0) | (layer2.MaximumScale > 0.0))
                                    {
                                        if (layer2.MinimumScale < mapScale)
                                        {
                                            return false;
                                        }
                                        if (layer2.MaximumScale > mapScale)
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        if ((pRasLayer.MinimumScale > 0.0) && (pRasLayer.MinimumScale < mapScale))
                                        {
                                            return false;
                                        }
                                        if ((pRasLayer.MaximumScale > 0.0) && (pRasLayer.MaximumScale > mapScale))
                                        {
                                            return false;
                                        }
                                    }
                                    return true;
                                }
                            }
                            layer2 = layer.Next() as IGroupLayer;
                        }
                        flag = true;
                    }
                    catch (Exception)
                    {
                        if ((pRasLayer.MinimumScale > 0.0) && (pRasLayer.MinimumScale < mapScale))
                        {
                            return false;
                        }
                        if ((pRasLayer.MaximumScale > 0.0) && (pRasLayer.MaximumScale > mapScale))
                        {
                            return false;
                        }
                        flag = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "CheckRasterLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                flag = false;
            }
            return flag;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FindFeatureLayers(string sGroupName, out ArrayList pList)
        {
            int index = 0;
            pList = new ArrayList();
            try
            {
                ILayer layer2 = GISFunFactory.LayerFun.FindLayer(this.m_Map as IBasicMap, sGroupName, true);
                if (layer2 is IGroupLayer)
                {
                    IGroupLayer layer = layer2 as IGroupLayer;
                    ICompositeLayer layer4 = layer as ICompositeLayer;
                    if (layer4.Count > 0)
                    {
                        for (index = 0; index <= (layer4.Count - 1); index++)
                        {
                            if (layer4.get_Layer(index) is IFeatureLayer)
                            {
                                IFeatureLayer layer3 = layer4.get_Layer(index) as IFeatureLayer;
                                pList.Add(layer3);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private string GetAltitude(IPoint pPoint)
        {
            try
            {
                if ((this.m_DEMLayer != null) || (this.m_DEMLayer2 != null))
                {
                    IRasterLayer dEMLayer = null;
                    if (this.m_DEMLayer != null)
                    {
                        dEMLayer = this.m_DEMLayer;
                    }
                    IGdbRasterCatalogLayer layer2 = null;
                    if (this.m_DEMLayer2 != null)
                    {
                        layer2 = this.m_DEMLayer2;
                    }
                    IIdentify identify = null;
                    if (dEMLayer != null)
                    {
                        identify = (IIdentify) dEMLayer;
                    }
                    else
                    {
                        identify = (IIdentify) layer2;
                    }
                    IIdentify2 identify1 = (IIdentify2) layer2;
                    IArray array = new ArrayClass();
                    array = identify.Identify(pPoint);
                    if (array != null)
                    {
                        if (dEMLayer != null)
                        {
                            IRasterIdentifyObj obj2 = (IRasterIdentifyObj) array.get_Element(0);
                            try
                            {
                                Convert.ToDouble(obj2.Name);
                                return obj2.Name;
                            }
                            catch (Exception)
                            {
                                return obj2.Name;
                            }
                        }
                        if (layer2 != null)
                        {
                            IIdentifyObj obj3 = (IIdentifyObj) array.get_Element(0);
                            try
                            {
                                Convert.ToDouble(obj3.Name);
                                return obj3.Name;
                            }
                            catch (Exception)
                            {
                                return "0";
                            }
                        }
                        return "0";
                    }
                }
                return "0";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetAltitude", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return "";
            }
        }

        private string GetDist(IFeatureLayer[] layers, string FieldName, IPoint pPoint)
        {
            try
            {
                string[] strArray = FieldName.Split(new char[] { ',' });
                int index = 0;
                int num2 = 0;
                IFeatureLayer pLayer = null;
                string str = "";
                for (index = 0; index <= (layers.Length - 1); index++)
                {
                    pLayer = layers[index];
                    if (pLayer == null)
                    {
                        return "";
                    }
                    IEnvelope searchEnvelope = this.GetSearchEnvelope(pLayer, pPoint);
                    if (searchEnvelope == null)
                    {
                        return "";
                    }
                    IFeature feature = null;
                    IFeatureCursor cursor = null;
                    cursor = this.SearchFeatureCursorFromFeatureClass(pLayer.FeatureClass, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                    if (cursor == null)
                    {
                        continue;
                    }
                    feature = cursor.NextFeature();
                    if (feature == null)
                    {
                        continue;
                    }
                    num2 = feature.Fields.FindField(strArray[index]);
                    if (num2 <= -1)
                    {
                        continue;
                    }
                    string str2 = "";
                    if ((feature.Fields.get_Field(num2).Domain != null) && (feature.Fields.get_Field(num2).Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(num2).Domain;
                            long num3 = Convert.ToInt64(feature.get_Value(num2));
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (num3 == Convert.ToInt64(domain.get_Value(i)))
                                {
                                    str2 = domain.get_Name(i);
                                    goto Label_0155;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            str2 = feature.get_Value(num2).ToString();
                        }
                    }
                    else
                    {
                        str2 = feature.get_Value(num2).ToString();
                    }
                Label_0155:
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str + "," + str2;
                    }
                    else
                    {
                        str = str2;
                    }
                }
                return str;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return "";
            }
        }

        private string GetFeatureFieldValue(IFeature pFeature, string FieldName)
        {
            try
            {
                int index = pFeature.Fields.FindField(FieldName);
                int num2 = 0;
                if (index == -1)
                {
                    for (num2 = 0; num2 <= (pFeature.Fields.FieldCount - 1); num2++)
                    {
                        if (pFeature.Fields.get_Field(num2).AliasName.ToLower() == FieldName.ToLower())
                        {
                            index = num2;
                        }
                    }
                }
                if (!object.ReferenceEquals(pFeature.get_Value(index), DBNull.Value))
                {
                    if ((pFeature.Fields.get_Field(index).Domain == null) || (pFeature.Fields.get_Field(index).Domain.Type != esriDomainType.esriDTCodedValue))
                    {
                        return pFeature.get_Value(index).ToString();
                    }
                    string str = "";
                    try
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) pFeature.Fields.get_Field(index).Domain;
                        long num3 = Convert.ToInt64(pFeature.get_Value(index));
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            if (num3 == Convert.ToInt64(domain.get_Value(i)))
                            {
                                return domain.get_Name(i);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        str = pFeature.get_Value(index).ToString();
                    }
                    return str;
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public ILayer GetLayer(IMap pMap, string sLayerName)
        {
            IEnumLayer layer = null;
            try
            {
                layer = pMap.get_Layers(null, true);
            }
            catch (Exception)
            {
                return null;
            }
            layer.Reset();
            ILayer layer2 = layer.Next();
            ILayer layer3 = null;
            while (layer2 != null)
            {
                if (layer2.Name == sLayerName)
                {
                    return layer2;
                }
                layer2 = layer.Next();
            }
            if ((layer3 == null) && sLayerName.Contains(this.mEditKind))
            {
                layer.Reset();
                for (layer2 = layer.Next(); layer2 != null; layer2 = layer.Next())
                {
                    if (layer2.Name.Contains(this.mEditKind) && (layer2 is IFeatureLayer))
                    {
                        return layer2;
                    }
                }
            }
            return null;
        }

        public ILayer GetLayer2(IMap pMap, string sLayerName)
        {
            IEnumLayer layer = null;
            try
            {
                layer = pMap.get_Layers(null, true);
            }
            catch (Exception)
            {
                return null;
            }
            layer.Reset();
            ILayer layer2 = layer.Next();
            while (layer2 != null)
            {
                if (layer2.Name.Contains(sLayerName))
                {
                    return layer2;
                }
                layer2 = layer.Next();
            }
            return null;
        }

        public bool GetLayerColn()
        {
            try
            {
                if (this.m_HookHelper == null)
                {
                    return false;
                }
                if (this.m_HookHelper.FocusMap == null)
                {
                    return false;
                }
                if (this.m_HookHelper.FocusMap.LayerCount == 0)
                {
                    return false;
                }
                IEnumLayer layer = null;
                try
                {
                    layer = this.m_HookHelper.FocusMap.get_Layers(null, false);
                }
                catch (Exception)
                {
                    return false;
                }
                layer.Reset();
                ICompositeLayer layer2 = null;
                IGroupLayer layer3 = null;
                int iFLayerCount = 1;
                int iFvisCount = 1;
                ILayer pLayer = null;
                pLayer = layer.Next();
                if (pLayer == null)
                {
                    return false;
                }
                this.m_VisLayerColn = new Collection();
                while (pLayer != null)
                {
                    if (pLayer is IGroupLayer)
                    {
                        layer3 = pLayer as IGroupLayer;
                        layer2 = layer3 as ICompositeLayer;
                        for (int i = 0; i < layer2.Count; i++)
                        {
                            ILayer layer5 = layer2.get_Layer(i);
                            if (layer5 is IGroupLayer)
                            {
                                ICompositeLayer layer6 = null;
                                IGroupLayer layer7 = null;
                                layer7 = layer5 as IGroupLayer;
                                layer6 = layer7 as ICompositeLayer;
                                for (int j = 0; j < layer6.Count; j++)
                                {
                                    ILayer layer8 = layer6.get_Layer(j);
                                    if (!(layer8 is IGroupLayer))
                                    {
                                        this.SetLayerConnection(layer8, iFLayerCount, iFvisCount, out iFLayerCount, out iFvisCount);
                                    }
                                }
                            }
                            else
                            {
                                this.SetLayerConnection(layer5, iFLayerCount, iFvisCount, out iFLayerCount, out iFvisCount);
                            }
                        }
                    }
                    else
                    {
                        this.SetLayerConnection(pLayer, iFLayerCount, iFvisCount, out iFLayerCount, out iFvisCount);
                    }
                    pLayer = layer.Next();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetLayerColn", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void GetPointTool()
        {
            try
            {
                try
                {
                    IMapControl2 hook = null;
                    hook = (IMapControl2) this.m_HookHelper.Hook;
                    hook.CurrentTool = this.m_pPointTool;
                }
                catch (Exception)
                {
                    IPageLayoutControl2 control2 = null;
                    control2 = (IPageLayoutControl2) this.m_HookHelper.Hook;
                    control2.CurrentTool = this.m_pPointTool;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetPointTool", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private ArrayList GetRelateObjs(ITable pTable, string sKeyField, string sKeyValue)
        {
            ArrayList list = new ArrayList();
            string str = sKeyField + "='" + sKeyValue + "'";
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = str;
            ICursor cursor = pTable.Search(queryFilter, false);
            IRow row = cursor.NextRow();
            if (row != null)
            {
                int index = row.Fields.FindField(sKeyField);
                IObject obj2 = null;
                while (row != null)
                {
                    if (row.get_Value(index).ToString() == sKeyValue)
                    {
                        obj2 = row as IObject;
                        list.Add(obj2);
                    }
                    row = cursor.NextRow();
                }
            }
            return list;
        }

        private IEnvelope GetSearchEnvelope(ILayer pLayer, IPoint pPoint)
        {
            try
            {
                IActiveView pActiveView = null;
                pActiveView = this.m_HookHelper.ActiveView;
                double num = pActiveView.Extent.Width / 100.0;
                IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
                IEnvelope visibleBounds = displayTransformation.VisibleBounds;
                tagRECT deviceFrame = displayTransformation.get_DeviceFrame();
                double height = 0.0;
                long num3 = 0L;
                height = visibleBounds.Height;
                num3 = deviceFrame.bottom - deviceFrame.top;
                double num4 = 0.0;
                num4 = height / ((double) num3);
                num *= num4;
                if (pPoint == null)
                {
                    return null;
                }
                visibleBounds = pPoint.Envelope;
                if (pLayer is IFeatureLayer)
                {
                    IFeatureLayer layer = (IFeatureLayer) pLayer;
                    if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        visibleBounds.Width = num;
                        visibleBounds.Height = num;
                    }
                    else if ((layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryLine) | (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline))
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 4.0, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 4.0, false);
                    }
                    else if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 1.0 / num, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 1.0 / num, false);
                    }
                    else
                    {
                        visibleBounds.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 2.0, true);
                        visibleBounds.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 2.0, false);
                    }
                }
                else
                {
                    IRasterLayer layer1 = pLayer as IRasterLayer;
                }
                visibleBounds.CenterAt(pPoint);
                return visibleBounds;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetSearchEnvelope", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private IRow GetTableRow(ITable pTable, string sKeyField, string sKeyValue)
        {
            string str = sKeyField + "='" + sKeyValue + "'";
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = str;
            ICursor cursor = pTable.Search(queryFilter, false);
            IRow row = cursor.NextRow();
            if (row != null)
            {
                int index = row.Fields.FindField(sKeyField);
                while (row != null)
                {
                    if (row.get_Value(index).ToString() == sKeyValue)
                    {
                        return row;
                    }
                    row = cursor.NextRow();
                }
            }
            return null;
        }

        private ArrayList GetTableRows(ITable pTable, string sKeyField, string sKeyValue)
        {
            string str = sKeyField + "='" + sKeyValue + "'";
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = str;
            ICursor cursor = pTable.Search(queryFilter, false);
            IRow row = cursor.NextRow();
            if (row == null)
            {
                return null;
            }
            int index = row.Fields.FindField(sKeyField);
            ArrayList list = new ArrayList();
            IObject obj2 = null;
            while (row != null)
            {
                if (row.get_Value(index).ToString() == sKeyValue)
                {
                    obj2 = row as IObject;
                    list.Add(obj2);
                }
                row = cursor.NextRow();
            }
            return list;
        }

        private bool GetVisFeatureColn(Collection pLayerColn)
        {
            try
            {
                int num = 0;
                IFeatureCursor cursor = null;
                IFeatureLayer pLayer = null;
                IFeature item = null;
                IRasterLayer layer2 = null;
                ILayer layer3 = null;
                this.m_VisFeatureColn = null;
                this.m_VisFeatureColn = new Collection();
                IEnvelope searchEnvelope = null;
                (this.m_HookHelper.Hook as IMapControl2).FlashShape(this.mPoint, 1, 300, null);
                this.mNodeExpend = false;
                for (num = 1; num <= pLayerColn.Count; num++)
                {
                    layer3 = pLayerColn[num] as ILayer;
                    if (layer3 is IFeatureLayer)
                    {
                        pLayer = layer3 as IFeatureLayer;
                        if (pLayer.Name != this.sXiaobanLayerName)
                        {
                            searchEnvelope = this.GetSearchEnvelope(pLayer, this.mPoint);
                            if (searchEnvelope == null)
                            {
                                break;
                            }
                            ISpatialFilter queryFilter = new SpatialFilterClass();
                            queryFilter.Geometry = searchEnvelope;
                            queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                            cursor = pLayer.Search(queryFilter, false);
                            if (cursor != null)
                            {
                                item = cursor.NextFeature();
                                long num2 = 0L;
                                while (item != null)
                                {
                                    this.m_VisFeatureColn.Add(item, num + "_" + (num2 + 1L), null, null);
                                    item = cursor.NextFeature();
                                }
                            }
                        }
                    }
                    else if (layer3 is IRasterLayer)
                    {
                        layer2 = (IRasterLayer) layer3;
                        IIdentify identify = null;
                        identify = (IIdentify) layer2;
                        IGeoDataset raster = (IGeoDataset) layer2.Raster;
                        ESRI.ArcGIS.esriSystem.Array array = new ArrayClass();
                        array = (ESRI.ArcGIS.esriSystem.Array) identify.Identify(this.mPoint);
                        if (array != null)
                        {
                            IRasterIdentifyObj obj2 = (IRasterIdentifyObj) array.get_Element(0);
                            IIdentifyObj obj1 = (IIdentifyObj) obj2;
                            this.m_VisFeatureColn.Add(array, num + "_1", null, null);
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetVisFeatureColn", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool GetXiaoban(IPoint pPoint)
        {
            try
            {
                if (pPoint == null)
                {
                    return false;
                }
                this.m_XiaobanColn = new ArrayList();
                IFeatureLayer pLayer = (IFeatureLayer) this.GetLayer(this.m_Map, this.sXiaobanLayerName);
                if (pLayer == null)
                {
                    return false;
                }
                IEnvelope searchEnvelope = this.GetSearchEnvelope(pLayer, pPoint);
                if (searchEnvelope == null)
                {
                    return false;
                }
                IFeature feature = null;
                IFeatureCursor cursor = null;
                cursor = this.SearchFeatureCursorFromFeatureClass(pLayer.FeatureClass, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                if (cursor != null)
                {
                    for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                    {
                        this.m_XiaobanColn.Add(feature);
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetXiaoban", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool GetXiaoban2(IPoint pPoint)
        {
            try
            {
                IFeature feature;
                if (pPoint == null)
                {
                    return false;
                }
                this.m_XiaobanColn2 = new ArrayList();
                this.m_XiaobanColn22 = new ArrayList();
                this.m_XiaobanColn3 = new ArrayList();
                IFeatureLayer pLayer = (IFeatureLayer) this.GetLayer(this.m_Map, this.sEditLayerName);
                if (pLayer == null)
                {
                    pLayer = this.m_EditLayer;
                }
                if (pLayer == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                    pLayer = (IFeatureLayer) this.GetLayer2(this.m_Map, configValue);
                }
                if (pLayer == null)
                {
                    return false;
                }
                IEnvelope searchEnvelope = this.GetSearchEnvelope(pLayer, pPoint);
                if (searchEnvelope == null)
                {
                    return false;
                }
                IFeatureClass featureClass = pLayer.FeatureClass;
                if (featureClass == null)
                {
                    return false;
                }
                IFeatureCursor cursor = this.SearchFeatureCursorFromFeatureClass(featureClass, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                if (cursor == null)
                {
                    return false;
                }
                for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                {
                    this.m_XiaobanColn2.Add(feature);
                }
                if (this.mEditKind == "征占用")
                {
                    pLayer = this.m_EditLayer2;
                    if (pLayer == null)
                    {
                        return false;
                    }
                    searchEnvelope = this.GetSearchEnvelope(pLayer, pPoint);
                    if (searchEnvelope == null)
                    {
                        return false;
                    }
                    featureClass = pLayer.FeatureClass;
                    if (featureClass == null)
                    {
                        return false;
                    }
                    cursor = this.SearchFeatureCursorFromFeatureClass(featureClass, searchEnvelope, esriSpatialRelEnum.esriSpatialRelContains);
                    if (cursor == null)
                    {
                        return false;
                    }
                    for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                    {
                        this.m_XiaobanColn22.Add(feature);
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "GetXiaoban2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void InitialCombox(ComboBoxEdit comboBox, ArrayList pList)
        {
            try
            {
                comboBox.Properties.Items.Clear();
                for (int i = 0; i < pList.Count; i++)
                {
                    IFeatureLayer layer = pList[i] as IFeatureLayer;
                    comboBox.Properties.Items.Add(layer.Name);
                }
            }
            catch (Exception)
            {
            }
        }

        public void InitialControls(string sEditKind)
        {
            try
            {
                if (sEditKind != "")
                {
                    this.mEditKind = sEditKind;
                    string description = "";
                    string str2 = "";
                    if (this.mEditKind == "造林")
                    {
                        this.mEditKind2 = "ZaoLin";
                        description = "造林班块查看结果";
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        this.mEditKind2 = "CaiFa";
                        description = "采伐班块查看结果";
                    }
                    else if (this.mEditKind == "林业工程")
                    {
                        this.mEditKind2 = "LYGC";
                        description = "工程班块查看结果";
                    }
                    else if (this.mEditKind.Contains("征占用"))
                    {
                        this.mEditKind2 = "ZZY";
                        description = "征占用班块查看结果";
                    }
                    else if (this.mEditKind.Contains("火灾"))
                    {
                        this.mEditKind2 = "Fire";
                        description = "火灾班块查看结果";
                    }
                    else if (this.mEditKind.Contains("自然灾害"))
                    {
                        this.mEditKind2 = "ZRZH";
                        description = "自然灾害班块查看结果";
                    }
                    else if (this.mEditKind.Contains("案件"))
                    {
                        this.mEditKind2 = "AnJian";
                        description = "案件班块查看结果";
                    }
                    else if (this.mEditKind == "小班变更")
                    {
                        this.mEditKind2 = "XB";
                        description = "变更小班查看结果";
                    }
                    else if (this.mEditKind == "年度小班")
                    {
                        this.mEditKind2 = "XB";
                        str2 = "年度小班查看结果";
                    }
                    else if (this.mEditKind.Contains("遥感"))
                    {
                        this.mEditKind2 = "YG";
                        description = "遥感班块查看结果";
                    }
                    if (this.m_Map != null)
                    {
                        this.InitLayers();
                        this.comboBoxCF.Visible = false;
                        this.comboBoxZL.Visible = false;
                        this.radioGroupInfo.Properties.Items.Clear();
                        this.radioGroupInfo.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "可见图层查看列表") });
                        if (!this.mEditKind.Contains("2"))
                        {
                            this.radioGroupInfo.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "小班图层查看列表") });
                        }
                        else
                        {
                            this.mEditKind = this.mEditKind.Replace("2", "");
                        }
                        if (description != "")
                        {
                            this.radioGroupInfo.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, description) });
                        }
                        if (str2 != "")
                        {
                            this.radioGroupInfo.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, str2) });
                        }
                        //if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "Local")
                        //{
                        //    this.mDBAccess = UtilFactory.GetDBAccess("Access");
                        //}
                        //else if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "SqlServer")
                        //{
                        //    this.mDBAccess = UtilFactory.GetDBAccess("SqlServer");
                        //}
                        this.m_VisFeatureColn = new Collection();
                        this.tListXiaoban.Visible = false;
                        this.m_pPointTool = new PointTool();
                        this.m_pPointTool.ParentForm = this;
                        this.m_pPointTool.OnCreate(this.m_HookHelper.Hook);
                        this.GetPointTool();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlInfo));
            this.imageList1 = new ImageList(this.components);
            this.panIdentify = new Panel();
            this.comboBoxCF = new ComboBoxEdit();
            this.comboBoxZL = new ComboBoxEdit();
            this.panelControl2 = new PanelControl();
            this.panel27 = new Panel();
            this.tListXiaoban = new TreeView();
            this.tListVisFeature = new TreeView();
            this.radioGroupInfo = new RadioGroup();
            this.panelControl1 = new PanelControl();
            this.panel25 = new Panel();
            this.txtLocation = new RichTextBox();
            this.labelPosition = new Label();
            this.imageList2 = new ImageList(this.components);
            this.imageList3 = new ImageList(this.components);
            this.labelIdentify = new Label();
            this.panIdentify.SuspendLayout();
            this.comboBoxCF.Properties.BeginInit();
            this.comboBoxZL.Properties.BeginInit();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.panel27.SuspendLayout();
            this.radioGroupInfo.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel25.SuspendLayout();
            base.SuspendLayout();
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2008113016515014.gif");
            this.imageList1.Images.SetKeyName(1, "2008113016515025.gif");
            this.imageList1.Images.SetKeyName(2, "ArcView_select_none.bmp");
            this.imageList1.Images.SetKeyName(3, "ArcView_select_all.bmp");
            this.imageList1.Images.SetKeyName(4, "2008113016514232.gif");
            this.panIdentify.BackColor = Color.Transparent;
            this.panIdentify.Controls.Add(this.comboBoxCF);
            this.panIdentify.Controls.Add(this.comboBoxZL);
            this.panIdentify.Controls.Add(this.panelControl2);
            this.panIdentify.Controls.Add(this.radioGroupInfo);
            this.panIdentify.Controls.Add(this.panelControl1);
            this.panIdentify.Controls.Add(this.labelPosition);
            this.panIdentify.Dock = DockStyle.Fill;
            this.panIdentify.Location = new System.Drawing.Point(0, 30);
            this.panIdentify.Name = "panIdentify";
            this.panIdentify.Padding = new Padding(9, 5, 7, 7);
            this.panIdentify.Size = new Size(300, 0x29a);
            this.panIdentify.TabIndex = 0;
            this.comboBoxCF.Location = new System.Drawing.Point(150, 0x83);
            this.comboBoxCF.Name = "comboBoxCF";
            this.comboBoxCF.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxCF.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxCF.Size = new Size(140, 0x15);
            this.comboBoxCF.TabIndex = 13;
            this.comboBoxCF.Visible = false;
            this.comboBoxZL.Location = new System.Drawing.Point(150, 0x9e);
            this.comboBoxZL.Name = "comboBoxZL";
            this.comboBoxZL.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxZL.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxZL.Size = new Size(140, 0x15);
            this.comboBoxZL.TabIndex = 12;
            this.comboBoxZL.Visible = false;
            this.panelControl2.Controls.Add(this.panel27);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(9, 0xb9);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x11c, 0x1da);
            this.panelControl2.TabIndex = 6;
            this.panel27.BackColor = Color.White;
            this.panel27.Controls.Add(this.tListXiaoban);
            this.panel27.Controls.Add(this.tListVisFeature);
            this.panel27.Dock = DockStyle.Fill;
            this.panel27.Location = new System.Drawing.Point(2, 2);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new Padding(4);
            this.panel27.Size = new Size(280, 470);
            this.panel27.TabIndex = 10;
//            this.tListXiaoban.BorderStyle = BorderStyle.None;
            this.tListXiaoban.Dock = DockStyle.Fill;
            this.tListXiaoban.Location = new System.Drawing.Point(4, 4);
            this.tListXiaoban.Name = "tListXiaoban";
            this.tListXiaoban.Size = new Size(0x110, 0x1ce);
            this.tListXiaoban.TabIndex = 9;
            this.tListXiaoban.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.tListXiaoban_NodeMouseDoubleClick);
            this.tListXiaoban.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tListXiaoban_NodeMouseClick);
//            this.tListVisFeature.BorderStyle = BorderStyle.None;
            this.tListVisFeature.Dock = DockStyle.Fill;
            this.tListVisFeature.Location = new System.Drawing.Point(4, 4);
            this.tListVisFeature.Name = "tListVisFeature";
            this.tListVisFeature.Size = new Size(0x110, 0x1ce);
            this.tListVisFeature.TabIndex = 5;
            this.tListVisFeature.MouseUp += new MouseEventHandler(this.tListVisFeature_MouseUp);
            this.tListVisFeature.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tListVisFeature_NodeMouseClick);
            this.radioGroupInfo.Dock = DockStyle.Top;
            this.radioGroupInfo.Location = new System.Drawing.Point(9, 0x7d);
            this.radioGroupInfo.Name = "radioGroupInfo";
            this.radioGroupInfo.Properties.Appearance.BackColor = Color.Transparent;
            this.radioGroupInfo.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupInfo.Properties.BorderStyle = BorderStyles.NoBorder;
            this.radioGroupInfo.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "可见图层查看结果"), new RadioGroupItem(null, "二类小班查看结果"), new RadioGroupItem(null, "造林地块查看结果"), new RadioGroupItem(null, "采伐地块查看结果") });
            this.radioGroupInfo.Size = new Size(0x11c, 60);
            this.radioGroupInfo.TabIndex = 11;
            this.radioGroupInfo.SelectedIndexChanged += new EventHandler(this.radioGroupInfo_SelectedIndexChanged);
            this.panelControl1.Controls.Add(this.panel25);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(9, 0x1f);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x11c, 0x5e);
            this.panelControl1.TabIndex = 3;
            this.panel25.BackColor = Color.White;
            this.panel25.Controls.Add(this.txtLocation);
            this.panel25.Dock = DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(2, 2);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new Padding(4);
            this.panel25.Size = new Size(280, 90);
            this.panel25.TabIndex = 3;
            this.txtLocation.BackColor = Color.White;
//            this.txtLocation.BorderStyle = BorderStyle.None;
            this.txtLocation.Dock = DockStyle.Fill;
            this.txtLocation.ForeColor = Color.Blue;
            this.txtLocation.Location = new System.Drawing.Point(4, 4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new Size(0x110, 0x52);
            this.txtLocation.TabIndex = 2;
            this.txtLocation.Text = "经度：  X\n纬度：  Y\n高程：  H\n所在地：";
            this.labelPosition.Cursor = Cursors.Hand;
            this.labelPosition.Dock = DockStyle.Top;
            this.labelPosition.ForeColor = Color.Navy;
            this.labelPosition.Image = (Image) resources.GetObject("labelPosition.Image");
            this.labelPosition.ImageAlign = ContentAlignment.MiddleRight;
            this.labelPosition.Location = new System.Drawing.Point(9, 5);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Padding = new Padding(0, 6, 0, 6);
            this.labelPosition.Size = new Size(0x11c, 0x1a);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "位置       ";
            this.labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPosition.Click += new EventHandler(this.labelPosition_Click);
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.White;
            this.imageList2.Images.SetKeyName(0, "PushMsgInfo.ico");
            this.imageList2.Images.SetKeyName(1, "sparkle.bmp");
            this.imageList2.Images.SetKeyName(2, "30.png");
            this.imageList2.Images.SetKeyName(3, "firepoint.bmp");
            this.imageList2.Images.SetKeyName(4, "43.png");
            this.imageList2.Images.SetKeyName(5, "2008113016515014.gif");
            this.imageList2.Images.SetKeyName(6, "2008113016515025.gif");
            this.imageList2.Images.SetKeyName(7, "page_world.png");
            this.imageList2.Images.SetKeyName(8, "pencil.png");
            this.imageList2.Images.SetKeyName(9, "5.png");
            this.imageList2.Images.SetKeyName(10, "9.png");
            this.imageList2.Images.SetKeyName(11, "bookmark.ico");
            this.imageList2.Images.SetKeyName(12, "border_draw.png");
            this.imageList2.Images.SetKeyName(13, "cursor_small.png");
            this.imageList2.Images.SetKeyName(14, "cut.png");
            this.imageList2.Images.SetKeyName(15, "cut_red.png");
            this.imageList2.Images.SetKeyName(0x10, "database_yellow.png");
            this.imageList2.Images.SetKeyName(0x11, "(1645).gif");
            this.imageList2.Images.SetKeyName(0x12, "(1636).gif");
            this.imageList2.Images.SetKeyName(0x13, "(1642).gif");
            this.imageList2.Images.SetKeyName(20, "(19,43).png");
            this.imageList2.Images.SetKeyName(0x15, "(47,17).png");
            this.imageList2.Images.SetKeyName(0x16, "(47,28).png");
            this.imageList2.Images.SetKeyName(0x17, "(15,40).png");
            this.imageList3.ImageStream = (ImageListStreamer) resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "Fault.bmp");
            this.imageList3.Images.SetKeyName(1, "4.bmp");
            this.imageList3.Images.SetKeyName(2, "2_.bmp");
            this.imageList3.Images.SetKeyName(3, "2__.bmp");
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(0, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(300, 30);
            this.labelIdentify.TabIndex = 13;
            this.labelIdentify.Text = "      信息查看";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panIdentify);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlInfo";
            base.Size = new Size(300, 0x2b8);
            this.panIdentify.ResumeLayout(false);
            this.comboBoxCF.Properties.EndInit();
            this.comboBoxZL.Properties.EndInit();
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.radioGroupInfo.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private bool InitialTreeVisFeature()
        {
            try
            {
                this.tListVisFeature.Nodes.Clear();
                Application.DoEvents();
                if (this.m_VisFeatureColn == null)
                {
                    return false;
                }
                if (this.m_VisFeatureColn.Count != 0)
                {
                    TreeNode nodeF = null;
                    TreeNode node2 = null;
                    ILayer layer = null;
                    IFeatureLayer layer2 = null;
                    IFeature pFeature = null;
                    int num = 0;
                    int num2 = 1;
                    for (num = 1; num <= this.m_VisLayerColn.Count; num++)
                    {
                        Application.DoEvents();
                        layer = this.m_VisLayerColn[num] as ILayer;
                        if ((layer.Name != this.sXiaobanLayerName) && (layer.Name != this.sEditLayerName))
                        {
                            for (num2 = 1; num2 <= this.m_VisFeatureColn.Count; num2++)
                            {
                                try
                                {
                                    if (this.m_VisFeatureColn[num + "_" + num2] == null)
                                    {
                                        break;
                                    }
                                    if (num2 == 1)
                                    {
                                        node2 = this.tListVisFeature.Nodes.Add(layer.Name);
                                        node2.Tag = "L" + num;
                                        node2.ForeColor = Color.Blue;
                                    }
                                    if (this.m_VisFeatureColn[num + "_" + num2] is IFeature)
                                    {
                                        pFeature = this.m_VisFeatureColn[num + "_" + num2] as IFeature;
                                        layer2 = layer as IFeatureLayer;
                                        string featureFieldValue = this.GetFeatureFieldValue(pFeature, layer2.DisplayField.ToString());
                                        if (string.IsNullOrEmpty(featureFieldValue))
                                        {
                                            featureFieldValue = pFeature.get_Value(0).ToString();
                                        }
                                        nodeF = node2.Nodes.Add(featureFieldValue);
                                        nodeF.Tag = num + "_" + num2;
                                        this.AddFeatureValue(nodeF);
                                        if (num2 == 1)
                                        {
                                            nodeF.Expand();
                                        }
                                    }
                                    else if (this.m_VisFeatureColn[num + "_" + num2] is IArray)
                                    {
                                        IArray array = this.m_VisFeatureColn[num + "_" + num2] as IArray;
                                        if (array.Count < 1)
                                        {
                                            return false;
                                        }
                                        IRasterLayer layer3 = layer as IRasterLayer;
                                        this.mRenderer = layer3.Renderer;
                                        IRasterIdentifyObj obj2 = array.get_Element(0) as IRasterIdentifyObj;
                                        if (this.mRenderer is IRasterStretchColorRampRenderer)
                                        {
                                            nodeF = node2.Nodes.Add(obj2.Name);
                                            nodeF.Tag = obj2;
                                            nodeF.Nodes.Add("像素值: " + obj2.MapTip.ToString());
                                        }
                                        else
                                        {
                                            if (this.mRenderer is IRasterRGBRenderer)
                                            {
                                                nodeF = node2.Nodes.Add("RGB");
                                            }
                                            else if (this.mRenderer is IRasterUniqueValueRenderer)
                                            {
                                                nodeF = node2.Nodes.Add(obj2.Name);
                                            }
                                            else if (this.mRenderer is IRasterClassifyColorRampRenderer)
                                            {
                                                nodeF = node2.Nodes.Add(obj2.Name);
                                            }
                                            else
                                            {
                                                nodeF = node2.Nodes.Add(obj2.Name);
                                            }
                                            nodeF.Tag = num + "_" + num2;
                                            this.AddFeatureValue(nodeF);
                                        }
                                        if (num2 == 1)
                                        {
                                            nodeF.Expand();
                                        }
                                    }
                                    if (node2 != null)
                                    {
                                        node2.Expand();
                                    }
                                }
                                catch (Exception)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (this.tListVisFeature.GetNodeCount(true) > 0)
                    {
                        this.tListVisFeature.SelectedNode = this.tListVisFeature.Nodes[0];
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "InitialTreeVisFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void InitLayers()
        {
            try
            {
                this.sDistLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.sDistLayerName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                this.sDistLayerName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                this.sLinbanLayerName = UtilFactory.GetConfigOpt().GetConfigValue("LinbanLayerName");
                this.sXiaobanLayerName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                this.sDistFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldName");
                this.sDistFieldCode = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                this.sDistFieldName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                this.sDistFieldCode2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                this.sDistFieldName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldName");
                this.sDistFieldCode3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                this.sLinbanFieldName = UtilFactory.GetConfigOpt().GetConfigValue("LinbanFieldName");
                this.sXiaobanFieldName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanFieldName");
                this.XBCodeName = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanCodeName");
                this.sXiaobanFieldString = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanFieldString");
                this.sZaoLinFieldString2 = "ZaoLinFieldString2";
                this.sCaiFaFieldString2 = "CaiFaFieldString2";
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName, true);
                this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName2, true);
                this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName3, true);
                this.m_pLBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sLinbanLayerName, true);
                this.m_pXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sXiaobanLayerName, true);
                this.mfWorkspace = EditTask.EditWorkspace;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                this.m_CountyTable = this.mfWorkspace.OpenTable(configValue);
                if (this.m_CountyTable != null)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                    this.m_TownTable = this.mfWorkspace.OpenTable(configValue);
                    if (this.m_TownTable != null)
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                        this.m_VillageTable = this.mfWorkspace.OpenTable(configValue);
                        string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("DEMLayerName");
                        if (sLayerName == "")
                        {
                            sLayerName = "DEM(30米)";
                        }
                        ILayer layer = GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, sLayerName, true);
                        if (layer != null)
                        {
                            if (layer.GetType() is IRasterDataset)
                            {
                                this.m_DEMLayer = (IRasterLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, sLayerName, true);
                                if (this.m_DEMLayer == null)
                                {
                                    sLayerName = "DEM";
                                    this.m_DEMLayer = (IRasterLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, sLayerName, true);
                                }
                            }
                            else if ((layer is IGdbRasterCatalogLayer) && (this.m_DEMLayer == null))
                            {
                                sLayerName = "DEM";
                                this.m_DEMLayer2 = (IGdbRasterCatalogLayer) GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, sLayerName, true);
                            }
                        }
                        string str3 = "";
                        if (this.mEditKind.Contains("年度小班"))
                        {
                            this.sEditLayerName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "LayerName1");
                            this.sEditCodeName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "GroupName2");
                        }
                        else if (this.mEditKind.Contains("遥感"))
                        {
                            this.sEditLayerName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "LayerName2");
                            this.sEditCodeName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "GroupName2");
                        }
                        else
                        {
                            this.sEditLayerName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "LayerName");
                            this.sEditCodeName = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "GroupName");
                        }
                        IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.m_HookHelper.FocusMap as IBasicMap, str3, true) as IGroupLayer;
                        this.m_EditLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.sEditLayerName, true) as IFeatureLayer;
                        if (this.m_EditLayer == null)
                        {
                            this.m_EditLayer = EditTask.EditLayer;
                        }
                        if (this.mEditKind.Contains("征占用"))
                        {
                            this.m_EditLayer = EditTask.UnderLayers[2] as IFeatureLayer;
                            this.m_EditLayer2 = EditTask.UnderLayers[0] as IFeatureLayer;
                        }
                        this.sEditFieldString = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldString");
                        this.sEditFieldString2 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldString2");
                        if (this.mEditKind.Contains("采伐"))
                        {
                            string name = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaTableName");
                            this.m_Table = this.mfWorkspace.OpenTable(name);
                            this.sConnectTableString = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaConnectFieldName");
                            this.sTableFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaTableFieldName");
                        }
                        if (this.mEditKind.Contains("火灾"))
                        {
                            string str5 = UtilFactory.GetConfigOpt().GetConfigValue("FireTableName");
                            this.m_Table = this.mfWorkspace.OpenTable(str5);
                            this.sConnectTableString = UtilFactory.GetConfigOpt().GetConfigValue("FireConnectFieldName");
                            this.sTableFieldName = UtilFactory.GetConfigOpt().GetConfigValue("FireTableFieldName");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "InitLayers", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitResult(IFeatureLayer pFLayer, string strFieldNames, ListView listResult)
        {
            if (pFLayer != null)
            {
                ColumnHeader[] array = null;
                IFeatureClass featureClass = pFLayer.FeatureClass;
                if (featureClass != null)
                {
                    string[] strArray = (featureClass.OIDFieldName + "," + strFieldNames).Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string aliasName = "";
                        short num2 = 0;
                        if (strArray[i] == "Dist")
                        {
                            aliasName = "区划";
                            num2 = 100;
                        }
                        else
                        {
                            IField field = featureClass.Fields.get_Field(featureClass.FindField(strArray[i]));
                            if (field.Name.ToUpper() == "OBJECTID")
                            {
                                aliasName = "";
                                num2 = 0;
                            }
                            else
                            {
                                aliasName = field.AliasName;
                                num2 = 60;
                            }
                        }
                        System.Array.Resize<ColumnHeader>(ref array, i + 1);
                        array[i] = new ColumnHeader();
                        array[i].Width = num2;
                        array[i].Text = aliasName;
                    }
                    listResult.Columns.AddRange(array);
                }
            }
        }

        private void labelIdentify_Click(object sender, EventArgs e)
        {
        }

        private void labelPosition_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_pPointTool = new PointTool();
                this.m_pPointTool.ParentForm = this;
                this.m_pPointTool.OnCreate(this.m_HookHelper.Hook);
                this.GetPointTool();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "labelPosition_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroupInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag1 = this.mEditKind == "";
        }

        private void ReadValue()
        {
            try
            {
                if (this.mPoint != null)
                {
                    this.txtLocation.Text = "经度 :  \n纬度 :  ";
                    this.txtLocation.Text = this.txtLocation.Text + "\n所在地: ";
                    this.txtLocation.Refresh();
                    this.tListVisFeature.Nodes.Clear();
                    this.tListVisFeature.Refresh();
                    string outx = "";
                    string outy = "";
                    GISFunFactory.UnitFun.bj54tojingweiduAo2(this.m_HookHelper.ActiveView, this.mPoint.X, this.mPoint.Y, ref outx, ref outy);
                    this.txtLocation.Text = "经度 :  " + outx + "\n纬度 :  " + outy + "\n高程 :  " + this.GetAltitude(this.mPoint) + "米";
                    this.txtLocation.Text = "经度 :  " + outx + "\n纬度 :  " + outy;
                    this.txtLocation.Text = this.txtLocation.Text + "\n所在地: ";
                    IFeatureLayer[] layers = new IFeatureLayer[] { this.m_pCLayer, this.m_pTLayer, this.m_pVLayer };
                    string str3 = this.GetDist(layers, this.sDistFieldCode + "," + this.sDistFieldCode2 + "," + this.sDistFieldCode3, this.mPoint);
                    this.txtLocation.Text = this.txtLocation.Text + str3;
                    this.Cursor = Cursors.WaitCursor;
                    if (this.radioGroupInfo.SelectedIndex == 0)
                    {
                        if (this.tListVisFeature.Enabled)
                        {
                            if (this.GetLayerColn())
                            {
                                this.GetVisFeatureColn(this.m_VisLayerColn);
                            }
                            this.InitialTreeVisFeature();
                        }
                        this.tListVisFeature.Visible = true;
                        this.tListXiaoban.Visible = false;
                    }
                    if (this.radioGroupInfo.Properties.Items[this.radioGroupInfo.SelectedIndex].Description.Contains("小班图层查看"))
                    {
                        this.AddXiaobanValue(this.mPoint);
                        this.tListXiaoban.Visible = true;
                        this.tListVisFeature.Visible = false;
                    }
                    if ((this.radioGroupInfo.Properties.Items[this.radioGroupInfo.SelectedIndex].Description.Contains(this.mEditKind.Replace("2", "")) || this.radioGroupInfo.Properties.Items[this.radioGroupInfo.SelectedIndex].Description.Contains("变更小班")) || this.radioGroupInfo.Properties.Items[this.radioGroupInfo.SelectedIndex].Description.Contains("案件"))
                    {
                        this.AddXiaobanValue2(this.mPoint);
                        this.tListXiaoban.Visible = true;
                        this.tListVisFeature.Visible = false;
                    }
                    if (this.radioGroupInfo.SelectedIndex == 3)
                    {
                        this.AddXiaobanValue2(this.mPoint);
                        this.tListXiaoban.Visible = true;
                        this.tListVisFeature.Visible = false;
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "ReadValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void ReadValue2()
        {
            try
            {
                if (this.mEnvelope != null)
                {
                    string outx = "";
                    string outy = "";
                    GISFunFactory.UnitFun.bj54tojingweidu2(this.mEnvelope.XMin, this.mEnvelope.YMin, ref outx, ref outy);
                    GISFunFactory.UnitFun.bj54tojingweidu3(this.mEnvelope.XMin, this.mEnvelope.YMin, ref outx, ref outy);
                    GISFunFactory.UnitFun.bj54tojingweidu2(this.mEnvelope.XMax, this.mEnvelope.YMax, ref outx, ref outy);
                    GISFunFactory.UnitFun.bj54tojingweidu3(this.mEnvelope.XMax, this.mEnvelope.YMax, ref outx, ref outy);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "ReadValue2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public IFeatureCursor SearchFeatureCursorFromFeatureClass(IFeatureClass pFClass, IGeometry pFilterGeometry, esriSpatialRelEnum enumSpatialRel)
        {
            try
            {
                if (pFClass == null)
                {
                    return null;
                }
                ISpatialFilter filter = null;
                if (pFilterGeometry == null)
                {
                    filter = null;
                }
                else
                {
                    filter = new SpatialFilterClass();
                    filter.Geometry = pFilterGeometry;
                    filter.GeometryField = pFClass.ShapeFieldName;
                    filter.SpatialRel = enumSpatialRel;
                }
                GC.Collect();
                return pFClass.Search(filter, false);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "SearchFeatureCursorFromFeatureClass", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void SetLayerConnection(ILayer pLayer, int iFLayerCount, int iFvisCount, out int iFLayerCount2, out int iFvisCount2)
        {
            IFeatureLayer item = null;
            IRasterLayer pRasLayer = null;
            try
            {
                iFLayerCount2 = iFLayerCount;
                iFvisCount2 = iFvisCount;
                if (pLayer is IFeatureLayer)
                {
                    item = pLayer as IFeatureLayer;
                    try
                    {
                        iFLayerCount2 = iFLayerCount + 1;
                        if (this.CheckFeatureLayerVisible(item as IGeoFeatureLayer) && this.CheckFeatureLayerScale(item as IGeoFeatureLayer))
                        {
                            this.m_VisLayerColn.Add(item, iFvisCount.ToString(), null, null);
                            iFvisCount2 = iFvisCount + 1;
                        }
                    }
                    catch (Exception exception)
                    {
                        iFLayerCount2 = iFLayerCount;
                        iFvisCount2 = iFvisCount;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "SetLayerConnection", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                }
                else if (pLayer is IRasterLayer)
                {
                    pRasLayer = pLayer as IRasterLayer;
                    iFLayerCount++;
                    if (pRasLayer.Visible && this.CheckRasterLayer(pRasLayer))
                    {
                        try
                        {
                            this.m_VisLayerColn.Add(pRasLayer, iFvisCount.ToString(), null, null);
                            iFvisCount2 = iFvisCount + 1;
                        }
                        catch (Exception)
                        {
                            if (this.m_VisLayerColn.Count == iFvisCount)
                            {
                                iFvisCount2 = iFvisCount + 1;
                            }
                            this.m_VisLayerColn.Add(pRasLayer, iFvisCount.ToString(), null, null);
                            iFvisCount2 = iFvisCount + 1;
                        }
                    }
                }
                else
                {
                    ITinLayer layer1 = pLayer as ITinLayer;
                }
            }
            catch (Exception exception2)
            {
                iFLayerCount2 = iFLayerCount;
                iFvisCount2 = iFvisCount;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "SetLayerConnection", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
            }
        }

        private void tListVisFeature_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tListVisFeature_MouseUp(object sender, MouseEventArgs e)
        {
            if ((this.tListVisFeature.SelectedNode != null) && (this.tListVisFeature.SelectedNode.Tag != null))
            {
                this.tListVisFeature.SelectedNode.Tag.ToString();
            }
        }

        private void tListVisFeature_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (this.mNodeExpend)
                {
                    this.mNodeExpend = false;
                }
                else
                {
                    TreeNode nodeAt = this.tListVisFeature.GetNodeAt(e.Location);
                    if ((nodeAt != null) && (nodeAt.Tag != null))
                    {
                        if (nodeAt.Tag is IIdentifyObj)
                        {
                            ((IIdentifyObj) nodeAt.Tag).Flash(this.m_HookHelper.ActiveView.ScreenDisplay);
                        }
                        else
                        {
                            string str = nodeAt.Tag.ToString();
                            if (!string.IsNullOrEmpty(str))
                            {
                                try
                                {
                                    IFeature pFeature = this.m_VisFeatureColn[str] as IFeature;
                                    if (pFeature != null)
                                    {
                                        (this.m_HookHelper.Hook as IMapControl2).FlashShape(pFeature.Shape, 1, 300, null);
                                        this.mNodeExpend = false;
                                        GISFunFactory.FeatureFun.ZoomToFeature(this.m_HookHelper.FocusMap, pFeature);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "tListVisFeature_NodeMouseClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.mNodeExpend = false;
            }
        }

        private void tListXiaoban_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode nodeAt = this.tListXiaoban.GetNodeAt(e.Location);
                if ((nodeAt != null) && (nodeAt.Tag != null))
                {
                    if (nodeAt.Tag is IIdentifyObj)
                    {
                        ((IIdentifyObj) nodeAt.Tag).Flash(this.m_HookHelper.ActiveView.ScreenDisplay);
                    }
                    else if (nodeAt.Tag is IFeature)
                    {
                        IFeature tag = nodeAt.Tag as IFeature;
                        (this.m_HookHelper.Hook as IMapControl2).FlashShape(tag.Shape, 1, 300, null);
                    }
                    else
                    {
                        string str = nodeAt.Tag.ToString();
                        if (!string.IsNullOrEmpty(str))
                        {
                            try
                            {
                                IFeature feature2 = null;
                                if (this.radioGroupInfo.SelectedIndex == 1)
                                {
                                    feature2 = this.m_XiaobanColn[Convert.ToInt16(str)] as IFeature;
                                }
                                else if (this.radioGroupInfo.SelectedIndex == 2)
                                {
                                    feature2 = this.m_XiaobanColn2[Convert.ToInt16(str)] as IFeature;
                                }
                                if (feature2 != null)
                                {
                                    (this.m_HookHelper.Hook as IMapControl2).FlashShape(feature2.Shape, 1, 300, null);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "tListXiaoban_NodeMouseClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListXiaoban_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode nodeAt = this.tListXiaoban.GetNodeAt(e.Location);
                if (nodeAt != null)
                {
                    if ((nodeAt.Tag == null) && (nodeAt.Parent != null))
                    {
                        nodeAt = nodeAt.Parent;
                    }
                    if (nodeAt.Tag != null)
                    {
                        if (nodeAt.Tag is IIdentifyObj)
                        {
                            ((IIdentifyObj) nodeAt.Tag).Flash(this.m_HookHelper.ActiveView.ScreenDisplay);
                        }
                        else if (nodeAt.Tag is IFeature)
                        {
                            IFeature tag = nodeAt.Tag as IFeature;
                            if (this.m_EditLayer.FeatureClass == tag.Class)
                            {
                                (this.m_EditLayer as IFeatureSelection).Clear();
                                this.m_HookHelper.FocusMap.SelectFeature(this.m_EditLayer, tag);
                            }
                            else if (this.m_EditLayer2.FeatureClass == tag.Class)
                            {
                                (this.m_EditLayer2 as IFeatureSelection).Clear();
                                this.m_HookHelper.FocusMap.SelectFeature(this.m_EditLayer2, tag);
                            }
                            GISFunFactory.FeatureFun.ZoomToFeature(this.m_HookHelper.FocusMap, tag);
                        }
                        else
                        {
                            string str = nodeAt.Tag.ToString();
                            if (!string.IsNullOrEmpty(str))
                            {
                                try
                                {
                                    IFeature feature = null;
                                    if (this.radioGroupInfo.SelectedIndex == 1)
                                    {
                                        feature = this.m_XiaobanColn[Convert.ToInt16(str)] as IFeature;
                                        (this.m_pXBLayer as IFeatureSelection).Clear();
                                        this.m_HookHelper.FocusMap.SelectFeature(this.m_pXBLayer, feature);
                                        GISFunFactory.FeatureFun.ZoomToFeature(this.m_HookHelper.FocusMap, feature);
                                    }
                                    else if (this.radioGroupInfo.SelectedIndex == 2)
                                    {
                                        feature = this.m_XiaobanColn2[Convert.ToInt16(str)] as IFeature;
                                        (this.mEditLayer as IFeatureSelection).Clear();
                                        this.m_HookHelper.FocusMap.SelectFeature(this.mEditLayer, feature);
                                        GISFunFactory.FeatureFun.ZoomToFeature(this.m_HookHelper.FocusMap, feature);
                                    }
                                    if (feature != null)
                                    {
                                        nodeAt.ExpandAll();
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlInfo", "tListXiaoban_NodeMouseClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tlstFireInfo_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        public IFeatureLayer EditLayer
        {
            get
            {
                return this.m_EditLayer;
            }
            set
            {
                this.m_EditLayer = value;
            }
        }

        public object hook
        {
            get
            {
                try
                {
                    if (this.m_HookHelper != null)
                    {
                        return this.m_HookHelper.Hook;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_HookHelper = new HookHelperClass();
                        this.m_HookHelper.Hook = value;
                        this.m_Map = this.m_HookHelper.FocusMap;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "信息查询", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public IPoint PointLocation
        {
            get
            {
                return this.mPoint;
            }
            set
            {
                if (value != null)
                {
                    this.mPoint = value;
                    if (this.mPoint != null)
                    {
                        this.ReadValue();
                    }
                }
            }
        }

        public IEnvelope PointLocation2
        {
            get
            {
                return this.mEnvelope;
            }
            set
            {
                if (value != null)
                {
                    this.mEnvelope = value;
                    if (this.mEnvelope != null)
                    {
                        this.ReadValue2();
                    }
                }
            }
        }
    }
}

