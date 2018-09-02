namespace DataEdit
{
    using AttributesEdit;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlInputYG : UserControlBase1
    {
        private bool bContinue = false;
        private int column = -1;
        private int column0 = -1;
        private IContainer components = null;
        internal ImageList imageList0;
        private ImageList imageList1;
        internal ImageList imageList2;
        internal ImageList imageList7;
        private Label label1;
        private Label label2;
        private Label labelCount;
        private Label labelIdentify;
        private Label labelprogress;
        private Label labelXBInfo;
        private IFeature m_CountyFeature;
        private IFeatureLayer m_DistLayer;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_YGLayer;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "DataEdit.UserControlInputYG";
        private RepositoryItemImageEdit mCurItemImageEdit;
        private RepositoryItemImageEdit mCurItemImageEdit0;
        private RepositoryItemImageEdit mCurItemImageEdit2;
        private RepositoryItemImageEdit mCurItemImageEdit22;
        private RepositoryItemImageEdit mCurItemImageEdit4;
        private RepositoryItemImageEdit mCurItemImageEdit5;
     
        private DockPanel mDockPanel;
        private string mEditKindCode;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private IHookHelper mHookHelper;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private ArrayList mQueryList = null;
        private ArrayList mQueryList2 = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private DataTable mStateTable;
        private bool mStopList = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        private PanelControl panelControl1;
        private PanelControl panelControlSel;
        private Panel panelInfo;
        private Panel panelList;
        private Panel panelLog;
        private RadioGroup radioGroupSel;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        private SimpleButton simpleButtonBack;
        public SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonCheck;
        public SimpleButton simpleButtonInfo;
        public SimpleButton simpleButtonlist;
        public SimpleButton simpleButtonOK;
        public SimpleButton simpleButtonSel;
        private TreeList tList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;

        public UserControlInputYG()
        {
            this.InitializeComponent();
        }

        private bool ClipXBCreateFeature(IFeature pSFeature, out IGeometry geoclip)
        {
            Exception exception;
            geoclip = pSFeature.ShapeCopy;
            try
            {
                geoclip = pSFeature.ShapeCopy;
                List<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                List<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                bool flag = false;
                for (int i = 0; i < this.mQueryList2.Count; i++)
                {
                    ITopologicalOperator2 @operator;
                    IGeometry geometry3;
                    IGeometry geometry4;
                    ITopologicalOperator2 operator2;
                    GC.Collect();
                    IFeature pObject = this.mQueryList2[i] as IFeature;
                    Application.DoEvents();
                    int index = pObject.Fields.FindField("BHYY");
                    double pFieldValue = 0.0;
                    IGeometry shapeCopy = pObject.ShapeCopy;
                    IGeometry other = geoclip;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    if (((pObject.get_Value(index).ToString() == "40") || (pObject.get_Value(index).ToString() == "41")) || (pObject.get_Value(index).ToString() == "42"))
                    {
                        @operator = other as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        try
                        {
                            geometry3 = null;
                            geometry4 = @operator.Intersect(shapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                            if (geometry4.IsEmpty)
                            {
                                geometry3 = other;
                            }
                            else
                            {
                                operator2 = geometry4 as ITopologicalOperator2;
                                operator2.IsKnownSimple_2 = false;
                                operator2.Simplify();
                                ITopologicalOperator2 operator3 = other as ITopologicalOperator2;
                                geometry3 = operator3.Difference(geometry4);
                            }
                            if (geometry3.IsEmpty)
                            {
                                geoclip = geometry3;
                            }
                            else
                            {
                                geoclip = geometry3;
                            }
                        }
                        catch (Exception)
                        {
                            if (this.richTextBox.Text != "")
                            {
                                this.richTextBox.AppendText("——失败");
                            }
                            this.richTextBox.Refresh();
                        }
                    }
                    else
                    {
                        try
                        {
                            ITopologicalOperator2 operator4 = shapeCopy as ITopologicalOperator2;
                            operator4.IsKnownSimple_2 = false;
                            operator4.Simplify();
                            @operator = other as ITopologicalOperator2;
                            @operator.IsKnownSimple_2 = false;
                            @operator.Simplify();
                            try
                            {
                                geometry4 = operator4.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                                if (!geometry4.IsEmpty)
                                {
                                    operator2 = geometry4 as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    geometry3 = (shapeCopy as ITopologicalOperator2).Difference(geometry4);
                                    if (geometry3.IsEmpty)
                                    {
                                        pObject.Delete();
                                        pObject.Store();
                                    }
                                    else
                                    {
                                        pObject.Shape = geometry3;
                                        pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, geometry3);
                                        this.UpdateField(pObject, "MIAN_JI", pFieldValue);
                                        pObject.Store();
                                    }
                                    flag = true;
                                }
                            }
                            catch (Exception)
                            {
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("——失败");
                                }
                                this.richTextBox.Refresh();
                            }
                            GC.Collect();
                        }
                        catch (Exception exception3)
                        {
                            exception = exception3;
                            this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                        }
                    }
                }
                return flag;
            }
            catch (Exception exception4)
            {
                exception = exception4;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
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

        private void DoInput(IWorkspaceEdit pWorkspaceEdit, IFeatureClass pSFeatureClass, IFeatureClass pTFeatureClass)
        {
            try
            {
                Process process;
                ProcessStartInfo info;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                int index = this.m_YGLayer.FeatureClass.Fields.FindField(configValue);
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("YGLayer");
                str2 = str2 + "_" + EditTask.TaskYear + "_" + EditTask.DistCode;
                string aliasName = pSFeatureClass.AliasName;
                int num3 = this.m_YGLayer.FeatureClass.FeatureCount(null);
                IFeatureCursor cursor = pSFeatureClass.Search(null, false);
                IFeature pSFeature = cursor.NextFeature();
                pWorkspaceEdit.StartEditing(false);
                Editor.UniqueInstance.AddAttribute = false;
                Editor.UniqueInstance.CheckOverlap = false;
                pWorkspaceEdit.StartEditOperation();
                Application.DoEvents();
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.richTextBox.Text = "";
                this.simpleButtonOK.Visible = false;
                bool flag = true;
                if (this.m_EditLayer.FeatureClass.FeatureCount(null) == 0)
                {
                    flag = false;
                }
                DataTable dataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_Input_YGFeature ORDER BY ID ASC");
                int num4 = 0;
                int num5 = 0;
                while (pSFeature != null)
                {
                    this.labelprogress.Text = "     导入遥感检测变化图层数据...";
                    this.labelprogress.ImageIndex = 0x44;
                    this.labelprogress.Visible = true;
                    this.richTextBox.AppendText("\n导入要素" + pSFeature.OID);
                    this.richTextBox.Refresh();
                    num4++;
                    num5++;
                    this.labelprogress.Text = string.Concat(new object[] { "     导入遥感检测变化图层数据第", num4, "个班块，共计", num3, "个班块" });
                    this.labelprogress.ImageIndex = 0x44;
                    if (this.bContinue && (dataTable.Select(string.Concat(new object[] { "SFeature_ID=", pSFeature.OID, " and NO_TB='", pSFeature.get_Value(index).ToString().Trim(), "'" })).Length > 0))
                    {
                        this.richTextBox.AppendText("[已导入,忽略]");
                    }
                    else if (pSFeature.ShapeCopy.IsEmpty)
                    {
                        this.richTextBox.AppendText("[图形空忽略]");
                    }
                    else
                    {
                        int num6;
                        string str4;
                        string str5;
                        Application.DoEvents();
                        bool flag2 = false;
                        IGeometry geoclip = null;
                        if (flag)
                        {
                            this.mQueryList2 = new ArrayList();
                            IGeometry shapeCopy = pSFeature.ShapeCopy;
                            ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                            @operator.IsKnownSimple_2 = false;
                            @operator.Simplify();
                            IGeometry geometry3 = shapeCopy;
                            ISpatialFilter filter = new SpatialFilterClass();
                            filter.Geometry = geometry3;
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                            IFeatureCursor cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                            IFeature feature2 = cursor2.NextFeature();
                            while (feature2 != null)
                            {
                                if (this.mQueryList2.Count > 0)
                                {
                                    num6 = 0;
                                    while (num6 < this.mQueryList2.Count)
                                    {
                                        if ((this.mQueryList2[num6] as IFeature).OID == feature2.OID)
                                        {
                                            goto Label_03F1;
                                        }
                                        num6++;
                                    }
                                    this.mQueryList2.Add(feature2);
                                }
                                else
                                {
                                    this.mQueryList2.Add(feature2);
                                }
                            Label_03F1:
                                feature2 = cursor2.NextFeature();
                            }
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                            GC.Collect();
                            cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                            feature2 = cursor2.NextFeature();
                            while (feature2 != null)
                            {
                                if (this.mQueryList2.Count > 0)
                                {
                                    num6 = 0;
                                    while (num6 < this.mQueryList2.Count)
                                    {
                                        if ((this.mQueryList2[num6] as IFeature).OID == feature2.OID)
                                        {
                                            goto Label_04C3;
                                        }
                                        num6++;
                                    }
                                    this.mQueryList2.Add(feature2);
                                }
                                else
                                {
                                    this.mQueryList2.Add(feature2);
                                }
                            Label_04C3:
                                feature2 = cursor2.NextFeature();
                            }
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            GC.Collect();
                            cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                            for (feature2 = cursor2.NextFeature(); feature2 != null; feature2 = cursor2.NextFeature())
                            {
                                if (this.mQueryList2.Count > 0)
                                {
                                    num6 = 0;
                                    while (num6 < this.mQueryList2.Count)
                                    {
                                        if ((this.mQueryList2[num6] as IFeature).OID == feature2.OID)
                                        {
                                            continue;
                                        }
                                        num6++;
                                    }
                                    this.mQueryList2.Add(feature2);
                                }
                                else
                                {
                                    this.mQueryList2.Add(feature2);
                                }
                            }
                            if (this.mQueryList2.Count > 0)
                            {
                                flag2 = this.ClipXBCreateFeature(pSFeature, out geoclip);
                            }
                            else
                            {
                                geoclip = pSFeature.ShapeCopy;
                            }
                        }
                        else
                        {
                            geoclip = pSFeature.ShapeCopy;
                        }
                        if ((geoclip != null) && geoclip.IsEmpty)
                        {
                            this.richTextBox.AppendText("[与变更小班变化原因为征占用的班块冲突，忽略]");
                            str4 = "T_Input_YGFeature";
                            str5 = string.Concat(new object[] { "insert into ", str4, " (SFeature_ID,NO_TB,Input_Type,SourceName) values (", pSFeature.OID, ",'", pSFeature.get_Value(index).ToString().Trim(), "','2','", str2, "')" });
                          //  this.mDBAccess.ExecuteScalar(str5);
                        }
                        else
                        {
                            IFeature feature3 = this.m_EditLayer.FeatureClass.CreateFeature();
                            IClone clone = (IClone) geoclip;
                            if (clone == null)
                            {
                                return;
                            }
                            IPolygon polygon = (IPolygon) clone.Clone();
                            try
                            {
                                feature3.Shape = polygon;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                goto Label_0B14;
                            }
                            string name = UtilFactory.GetConfigOpt().GetConfigValue("YGInputFieldName");
                            int num7 = pSFeature.Fields.FindField(configValue);
                            int num8 = feature3.Fields.FindField(name);
                            feature3.set_Value(num8, pSFeature.get_Value(num7));
                            num7 = pSFeature.Fields.FindField("LDGLLX");
                            num8 = feature3.Fields.FindField("GLLX");
                            if ((num7 > -1) && (num8 > -1))
                            {
                                feature3.set_Value(num8, pSFeature.get_Value(num7));
                            }
                            for (num6 = 0; num6 < feature3.Fields.FieldCount; num6++)
                            {
                                if (((feature3.Fields.get_Field(num6).Name != pTFeatureClass.OIDFieldName) && (feature3.Fields.get_Field(num6).Name != pTFeatureClass.LengthField.Name)) && (feature3.Fields.get_Field(num6).Name != pTFeatureClass.AreaField.Name))
                                {
                                    string str7 = feature3.Fields.get_Field(num6).Name;
                                    int num9 = pSFeature.Fields.FindField(str7);
                                    if (num9 > -1)
                                    {
                                        feature3.set_Value(num6, pSFeature.get_Value(num9));
                                    }
                                }
                            }
                            int num10 = feature3.Fields.FindField("DT_SRC");
                            if (num10 > -1)
                            {
                                feature3.set_Value(num10, "99");
                            }
                            num10 = feature3.Fields.FindField("GXSJ");
                            if (num10 > -1)
                            {
                                feature3.set_Value(num10, EditTask.TaskYear + "1231");
                            }
                            try
                            {
                                feature3.Shape = polygon;
                                feature3.Store();
                                this.richTextBox.AppendText("[成功]");
                                str4 = "T_Input_YGFeature";
                                str5 = string.Concat(new object[] { "insert into ", str4, " (SFeature_ID,NO_TB,Feature_ID,Input_Type,SourceName) values (", pSFeature.OID, ",'", pSFeature.get_Value(index).ToString().Trim(), "',", feature3.OID, ",'1','", str2, "')" });
                             //   this.mDBAccess.ExecuteScalar(str5);
                                if (num5 >= 50)
                                {
                                    try
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    catch (Exception)
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    Editor.UniqueInstance.AddAttribute = true;
                                    Editor.UniqueInstance.CheckOverlap = true;
                                    pWorkspaceEdit.StopEditing(true);
                                    pWorkspaceEdit.StartEditing(false);
                                    Editor.UniqueInstance.AddAttribute = false;
                                    Editor.UniqueInstance.CheckOverlap = false;
                                    pWorkspaceEdit.StartEditOperation();
                                    try
                                    {
                                        if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                                        {
                                            process = new Process();
                                            info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                            process.StartInfo = info;
                                            process.StartInfo.UseShellExecute = false;
                                            process.Start();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    this.richTextBox.Text = "";
                                    num5 = 0;
                                }
                            }
                            catch (Exception)
                            {
                                this.richTextBox.AppendText("[保存失败]");
                                this.labelprogress.Text = "     导入遥感检测变化图层数据[失败]";
                                this.labelprogress.ImageIndex = 0x43;
                                Editor.UniqueInstance.AddAttribute = false;
                                feature3.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                        }
                    }
                Label_0B14:
                    pSFeature = cursor.NextFeature();
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                catch (Exception)
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                Editor.UniqueInstance.AddAttribute = true;
                Editor.UniqueInstance.CheckOverlap = true;
                pWorkspaceEdit.StopEditing(true);
                this.mHookHelper.ActiveView.Refresh();
                this.labelprogress.Text = "     导入遥感检测变化图层数据 - 完成,成功导入" + num4 + "个";
                this.labelprogress.ImageIndex = 0x42;
                this.labelprogress.Visible = true;
                string[] strArray = (this.m_YGLayer.FeatureClass as IDataset).Name.Split(new char[] { '.' });
                string str9 = strArray[strArray.Length - 1];
                str9 = str9.Replace("_" + EditTask.TaskYear, "");
                string sCmdText = "update T_EditTask  set editstate='2' where layername = '" + str9 + "'";
              //  this.mDBAccess.ExecuteScalar(sCmdText);
                MessageBox.Show("导入遥感检测变化图层数据完成,成功导入" + num4 + "个", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GC.Collect();
                try
                {
                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                    {
                        process = new Process();
                        info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                        process.StartInfo = info;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                    }
                }
                catch (Exception)
                {
                }
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "DoInput", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private double GetArea(ISpatialReference pSrf, IGeometry pGeo)
        {
            if (pGeo == null)
            {
                return 0.0;
            }
            IClone clone = (IClone) pGeo;
            IPolygon polygon = (IPolygon) clone.Clone();
            IGeometry pGeometry = polygon;
            try
            {
                pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeometry, pSrf);
                return Math.Round(Math.Abs((double) (((IArea) pGeometry).Area / 10000.0)), 2);
            }
            catch
            {
                return 0.0;
            }
        }

        private void GetFeatureList()
        {
            try
            {
                this.mQueryList = null;
                IFeatureClass class2 = null;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = "";
                GC.Collect();
                IFeatureCursor cursor = class2.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                this.mQueryList = new ArrayList();
                while (feature != null)
                {
                    this.mQueryList.Add(feature);
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string GetFiledValue(int index, IFeature pf)
        {
            string str2;
            string str = "";
            try
            {
                if (index == -1)
                {
                    return "";
                }
                IField field = pf.Fields.get_Field(index);
                str = pf.get_Value(index).ToString();
                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                {
                    str = "";
                    try
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                        long num = Convert.ToInt64(pf.get_Value(index));
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            if (num == Convert.ToInt64(domain.get_Value(i)))
                            {
                                str = domain.get_Name(i);
                                goto Label_00E9;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        str = pf.get_Value(index).ToString();
                    }
                }
                else
                {
                    str = pf.get_Value(index).ToString();
                }
            Label_00E9:
                str2 = str;
            }
            catch (Exception)
            {
                str2 = str;
            }
            return str2;
        }

        private void GetXBInfo()
        {
            try
            {
                this.panelInfo.Height = 0x74;
                string name = "BHYY";
                string str2 = "DT_SRC";
                int num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.labelXBInfo.Text = "已有变更小班 共计" + num + "个";
                IQueryFilter queryFilter = new QueryFilterClass();
                int num2 = 0;
                string configValue = "";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num3 = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                queryFilter.WhereClause = configValue + " <> ''and " + str2 + " = '99'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n导入遥感判读班块", num2, "个" });
                int num4 = this.m_EditLayer.FeatureClass.Fields.FindField(name);
                if (num2 > 0)
                {
                    queryFilter.WhereClause = name + " like '1%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中变化原因为植树造林的", num2, "个" });
                    queryFilter.WhereClause = name + " like '2%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，森林采伐的", num2, "个" });
                    queryFilter.WhereClause = name + " like '3%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，规划调整的", num2, "个" });
                    queryFilter.WhereClause = name + " like '4%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，占用征收的", num2, "个" });
                    queryFilter.WhereClause = name + " like '5%' and " + configValue + "<>'0'and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，毁林开荒的", num2, "个" });
                    queryFilter.WhereClause = name + " = '71' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，火灾的", num2, "个" });
                    queryFilter.WhereClause = "(" + name + " = '70' or " + name + " = '72' or " + name + " = '73') and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，灾害因素的", num2, "个" });
                    queryFilter.WhereClause = name + " like '7%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，自然因素的", num2, "个" });
                    queryFilter.WhereClause = name + " like '9%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，调查因素的", num2, "个" });
                    this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
                    this.panelInfo.Height = 0xa6;
                }
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                queryFilter.WhereClause = name + " is not null and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') and " + str2 + " < '08'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n六专题导入班块", num2, "个" });
                queryFilter.WhereClause = str2 + " = '01' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中数据来源为造林专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '02' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",采伐专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '03' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",火灾专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '04' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",征占用专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '05' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",灾害专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '07' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",案件专题的", num2, "个" });
                this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
                queryFilter.WhereClause = str2 + " = '88'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n公益林导入班块", num2, "个" });
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "GetXBInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Hook(object hook, IFeatureLayer pYGLayer, IFeature pCountyFeature, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_YGLayer = pYGLayer;
                this.m_CountyFeature = pCountyFeature;
                this.mQueryResult = pResult;
                this.mQueryResult2 = pResult2;
                this.mDockPanel = pDockPanel;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlInputYG));
            this.label1 = new Label();
            this.labelCount = new Label();
            this.tList = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new RepositoryItemImageEdit();
            this.panel6 = new Panel();
            this.simpleButtonCheck = new SimpleButton();
            this.imageList2 = new ImageList(this.components);
            this.panel2 = new Panel();
            this.simpleButtonBack = new SimpleButton();
            this.simpleButtonOK = new SimpleButton();
            this.imageList1 = new ImageList(this.components);
            this.panel1 = new Panel();
            this.simpleButtonInfo = new SimpleButton();
            this.imageList0 = new ImageList(this.components);
            this.imageList7 = new ImageList(this.components);
            this.labelIdentify = new Label();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel4 = new Panel();
            this.labelprogress = new Label();
            this.panelList = new Panel();
            this.panel3 = new Panel();
            this.simpleButtonlist = new SimpleButton();
            this.panelInfo = new Panel();
            this.labelXBInfo = new Label();
            this.panelControlSel = new PanelControl();
            this.radioGroupSel = new RadioGroup();
            this.label2 = new Label();
            this.simpleButtonSel = new SimpleButton();
            this.simpleButtonCancel = new SimpleButton();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageComboBox1.BeginInit();
            this.repositoryItemPictureEdit1.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemImageEdit3.BeginInit();
            this.repositoryItemImageEdit33.BeginInit();
            this.panel6.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelControlSel.BeginInit();
            this.panelControlSel.SuspendLayout();
            this.radioGroupSel.Properties.BeginInit();
            base.SuspendLayout();
            this.label1.Dock = DockStyle.Top;
            this.label1.ForeColor = Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 0x7c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10c, 0x18);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入遥感检测变化数据";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCount.Dock = DockStyle.Bottom;
            this.labelCount.ForeColor = Color.Navy;
            this.labelCount.Location = new System.Drawing.Point(0, 2);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new Size(0xda, 0x16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "遥感检测变化数据  共计n个班块";
            this.labelCount.TextAlign = ContentAlignment.MiddleLeft;
            this.tList.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5 });
            this.tList.Dock = DockStyle.Fill;
            this.tList.Location = new System.Drawing.Point(0, 0x1c);
            this.tList.Name = "tList";
            this.tList.BeginUnboundLoad();
            object[] nodeData = new object[5];
            nodeData[0] = "1";
            nodeData[1] = "XX县";
            this.tList.AppendNode(nodeData, -1, 0, 0, 5);
            this.tList.EndUnboundLoad();
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageComboBox1, this.repositoryItemPictureEdit1, this.repositoryItemButtonEdit1, this.repositoryItemImageEdit3, this.repositoryItemImageEdit33 });
            this.tList.Size = new Size(0x10c, 0xf9);
            this.tList.TabIndex = 5;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.MouseUp += new MouseEventHandler(this.tList_MouseUp);
            this.tList.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList_CustomNodeCellEdit);
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.treeListColumn1.Caption = "遥感ID";
            this.treeListColumn1.FieldName = "遥感ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 60;
            this.treeListColumn2.Caption = "县";
            this.treeListColumn2.FieldName = "县";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 70;
            this.treeListColumn3.Caption = "乡";
            this.treeListColumn3.FieldName = "乡";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 70;
            this.treeListColumn4.Caption = "村";
            this.treeListColumn4.FieldName = "村";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 70;
            this.treeListColumn5.Caption = "定位";
            this.treeListColumn5.FieldName = "定位";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 30;
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageComboBox1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.Appearance.Image");
            this.repositoryItemImageComboBox1.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AppearanceFocused.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.AppearanceFocused.Image");
            this.repositoryItemImageComboBox1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.ButtonsStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemPictureEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemPictureEdit1.Appearance.Image");
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Plus) });
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            this.repositoryItemImageEdit3.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit33.AutoHeight = false;
            this.repositoryItemImageEdit33.Name = "repositoryItemImageEdit33";
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonCheck);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonInfo);
            this.panel6.Dock = DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(6, 0x1a9);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 6, 0, 6);
            this.panel6.Size = new Size(0x10c, 0x26);
            this.panel6.TabIndex = 0x17;
            this.simpleButtonCheck.Dock = DockStyle.Right;
            this.simpleButtonCheck.ImageIndex = 6;
            this.simpleButtonCheck.ImageList = this.imageList2;
            this.simpleButtonCheck.Location = new System.Drawing.Point(0, 6);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x48, 0x1a);
            this.simpleButtonCheck.TabIndex = 13;
            this.simpleButtonCheck.Text = "数据校验";
            this.simpleButtonCheck.ToolTip = "校验遥感数据是否有重叠班块,变化原因是否填写";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "blank16.ico");
            this.imageList2.Images.SetKeyName(1, "tick16.ico");
            this.imageList2.Images.SetKeyName(2, "PART16.ICO");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            this.imageList2.Images.SetKeyName(0x10, "(30,24).png");
            this.imageList2.Images.SetKeyName(0x11, "(00,02).png");
            this.imageList2.Images.SetKeyName(0x12, "(00,17).png");
            this.imageList2.Images.SetKeyName(0x13, "(00,46).png");
            this.imageList2.Images.SetKeyName(20, "(01,10).png");
            this.imageList2.Images.SetKeyName(0x15, "(01,25).png");
            this.imageList2.Images.SetKeyName(0x16, "(05,32).png");
            this.imageList2.Images.SetKeyName(0x17, "(06,32).png");
            this.imageList2.Images.SetKeyName(0x18, "(07,32).png");
            this.imageList2.Images.SetKeyName(0x19, "(08,32).png");
            this.imageList2.Images.SetKeyName(0x1a, "(08,36).png");
            this.imageList2.Images.SetKeyName(0x1b, "(09,36).png");
            this.imageList2.Images.SetKeyName(0x1c, "(10,26).png");
            this.imageList2.Images.SetKeyName(0x1d, "(11,26).png");
            this.imageList2.Images.SetKeyName(30, "(11,29).png");
            this.imageList2.Images.SetKeyName(0x1f, "(12,29).png");
            this.imageList2.Images.SetKeyName(0x20, "(11,32).png");
            this.imageList2.Images.SetKeyName(0x21, "(11,36).png");
            this.imageList2.Images.SetKeyName(0x22, "(13,32).png");
            this.imageList2.Images.SetKeyName(0x23, "(19,31).png");
            this.imageList2.Images.SetKeyName(0x24, "(22,18).png");
            this.imageList2.Images.SetKeyName(0x25, "(25,27).png");
            this.imageList2.Images.SetKeyName(0x26, "(29,43).png");
            this.imageList2.Images.SetKeyName(0x27, "(30,14).png");
            this.imageList2.Images.SetKeyName(40, "5.png");
            this.imageList2.Images.SetKeyName(0x29, "10.png");
            this.imageList2.Images.SetKeyName(0x2a, "11.png");
            this.imageList2.Images.SetKeyName(0x2b, "16.png");
            this.imageList2.Images.SetKeyName(0x2c, "17.png");
            this.imageList2.Images.SetKeyName(0x2d, "18.png");
            this.imageList2.Images.SetKeyName(0x2e, "19.png");
            this.imageList2.Images.SetKeyName(0x2f, "20.png");
            this.imageList2.Images.SetKeyName(0x30, "21.png");
            this.imageList2.Images.SetKeyName(0x31, "22.png");
            this.imageList2.Images.SetKeyName(50, "25.png");
            this.imageList2.Images.SetKeyName(0x33, "31.png");
            this.imageList2.Images.SetKeyName(0x34, "41.png");
            this.imageList2.Images.SetKeyName(0x35, "add.png");
            this.imageList2.Images.SetKeyName(0x36, "bullet_minus.png");
            this.imageList2.Images.SetKeyName(0x37, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x38, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x3a, "cross.png");
            this.imageList2.Images.SetKeyName(0x3b, "down.png");
            this.imageList2.Images.SetKeyName(60, "draw_tools.png");
            this.imageList2.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.imageList2.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.imageList2.Images.SetKeyName(0x42, "flag blue.png");
            this.imageList2.Images.SetKeyName(0x43, "flag red.png");
            this.imageList2.Images.SetKeyName(0x44, "flag yellow.png");
            this.imageList2.Images.SetKeyName(0x45, "31.png");
            this.imageList2.Images.SetKeyName(70, "42.png");
            this.imageList2.Images.SetKeyName(0x47, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x49, "cursor.png");
            this.imageList2.Images.SetKeyName(0x4a, "cursor_small.png");
            this.imageList2.Images.SetKeyName(0x4b, "cut.png");
            this.imageList2.Images.SetKeyName(0x4c, "cut_red.png");
            this.imageList2.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.imageList2.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.imageList2.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x52, "key.png");
            this.imageList2.Images.SetKeyName(0x53, "page_add.png");
            this.imageList2.Images.SetKeyName(0x54, "page_delete.png");
            this.imageList2.Images.SetKeyName(0x55, "page_white_world.png");
            this.imageList2.Images.SetKeyName(0x56, "page_world.png");
            this.imageList2.Images.SetKeyName(0x57, "reload.png");
            this.imageList2.Images.SetKeyName(0x58, "world_add.png");
            this.imageList2.Images.SetKeyName(0x59, "world_delete.png");
            this.imageList2.Images.SetKeyName(90, "zoom_in.png");
            this.imageList2.Images.SetKeyName(0x5b, "zoom_out.png");
            this.imageList2.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.imageList2.Images.SetKeyName(0x5e, "Exit.png");
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0x48, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(8, 0x1a);
            this.panel2.TabIndex = 14;
            this.simpleButtonBack.Dock = DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 0x2e;
            this.simpleButtonBack.ImageList = this.imageList2;
            this.simpleButtonBack.Location = new System.Drawing.Point(80, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new Size(60, 0x1a);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new EventHandler(this.simpleButtonBack_Click);
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonOK.ImageIndex = 7;
            this.simpleButtonOK.ImageList = this.imageList1;
            this.simpleButtonOK.Location = new System.Drawing.Point(140, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(60, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "导入";
            this.simpleButtonOK.ToolTip = "导入遥感变化数据";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "20.bmp");
            this.imageList1.Images.SetKeyName(1, "AppDocSave_16.bmp");
            this.imageList1.Images.SetKeyName(2, "BD21298_.GIF");
            this.imageList1.Images.SetKeyName(3, "BPosE.gif");
            this.imageList1.Images.SetKeyName(4, "layer_7_.bmp");
            this.imageList1.Images.SetKeyName(5, "digilin.bmp");
            this.imageList1.Images.SetKeyName(6, "digipnt.bmp");
            this.imageList1.Images.SetKeyName(7, "digipol.bmp");
            this.imageList1.Images.SetKeyName(8, "DisplayXBList.bmp");
            this.imageList1.Images.SetKeyName(9, "EditorsUnboundMode3.bmp");
            this.imageList1.Images.SetKeyName(10, "Fault.bmp");
            this.imageList1.Images.SetKeyName(11, "查看.bmp");
            this.imageList1.Images.SetKeyName(12, "图标10.ico");
            this.imageList1.Images.SetKeyName(13, "PushMsgInfo.ico");
            this.imageList1.Images.SetKeyName(14, "complain.ico");
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(200, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(8, 0x1a);
            this.panel1.TabIndex = 11;
            this.simpleButtonInfo.Dock = DockStyle.Right;
            this.simpleButtonInfo.ImageIndex = 13;
            this.simpleButtonInfo.ImageList = this.imageList1;
            this.simpleButtonInfo.Location = new System.Drawing.Point(0xd0, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(60, 0x1a);
            this.simpleButtonInfo.TabIndex = 9;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.ToolTip = "详细信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.imageList0.ImageStream = (ImageListStreamer) resources.GetObject("imageList0.ImageStream");
            this.imageList0.TransparentColor = Color.Transparent;
            this.imageList0.Images.SetKeyName(0, "(01,49).png");
            this.imageList0.Images.SetKeyName(1, "");
            this.imageList0.Images.SetKeyName(2, "(18,13).png");
            this.imageList0.Images.SetKeyName(3, "(01,46).png");
            this.imageList0.Images.SetKeyName(4, "(05,49).png");
            this.imageList0.Images.SetKeyName(5, "(06,30).png");
            this.imageList0.Images.SetKeyName(6, "(07,30).png");
            this.imageList0.Images.SetKeyName(7, "(09,13).png");
            this.imageList0.Images.SetKeyName(8, "(09,24).png");
            this.imageList0.Images.SetKeyName(9, "(11,49).png");
            this.imageList0.Images.SetKeyName(10, "(18,29).png");
            this.imageList0.Images.SetKeyName(11, "(34,00).png");
            this.imageList0.Images.SetKeyName(12, "(47,25).png");
            this.imageList0.Images.SetKeyName(13, "(48,48).png");
            this.imageList7.ImageStream = (ImageListStreamer) resources.GetObject("imageList7.ImageStream");
            this.imageList7.TransparentColor = Color.Transparent;
            this.imageList7.Images.SetKeyName(0, "(01,49).png");
            this.imageList7.Images.SetKeyName(1, "(18,13).png");
            this.imageList7.Images.SetKeyName(2, "");
            this.imageList7.Images.SetKeyName(3, "(01,46).png");
            this.imageList7.Images.SetKeyName(4, "(05,49).png");
            this.imageList7.Images.SetKeyName(5, "(06,30).png");
            this.imageList7.Images.SetKeyName(6, "(07,30).png");
            this.imageList7.Images.SetKeyName(7, "(09,13).png");
            this.imageList7.Images.SetKeyName(8, "(09,24).png");
            this.imageList7.Images.SetKeyName(9, "(11,49).png");
            this.imageList7.Images.SetKeyName(10, "(18,29).png");
            this.imageList7.Images.SetKeyName(11, "(34,00).png");
            this.imageList7.Images.SetKeyName(12, "(47,25).png");
            this.imageList7.Images.SetKeyName(13, "(48,48).png");
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(6, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(0x10c, 30);
            this.labelIdentify.TabIndex = 0x18;
            this.labelIdentify.Text = "      导入遥感数据";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel4);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(6, 0x94);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0x10c, 0x115);
            this.panelLog.TabIndex = 0x1d;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x10c, 0xdf);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x108, 0xdb);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new Padding(0, 4, 0, 4);
            this.panel4.Size = new Size(0x10c, 0x30);
            this.panel4.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.ForeColor = Color.Blue;
            this.labelprogress.ImageAlign = ContentAlignment.TopLeft;
            this.labelprogress.ImageIndex = 0x44;
            this.labelprogress.ImageList = this.imageList2;
            this.labelprogress.Location = new System.Drawing.Point(0, 4);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0x10c, 40);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "     生成进度:";
            this.panelList.Controls.Add(this.tList);
            this.panelList.Controls.Add(this.panel3);
            this.panelList.Dock = DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(6, 0x94);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new Padding(0, 2, 0, 0);
            this.panelList.Size = new Size(0x10c, 0x115);
            this.panelList.TabIndex = 30;
            this.panel3.Controls.Add(this.labelCount);
            this.panel3.Controls.Add(this.simpleButtonlist);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 2, 0, 2);
            this.panel3.Size = new Size(0x10c, 0x1a);
            this.panel3.TabIndex = 6;
            this.simpleButtonlist.Dock = DockStyle.Right;
            this.simpleButtonlist.ImageIndex = 7;
            this.simpleButtonlist.ImageList = this.imageList2;
            this.simpleButtonlist.Location = new System.Drawing.Point(0xda, 2);
            this.simpleButtonlist.Name = "simpleButtonlist";
            this.simpleButtonlist.Size = new Size(50, 0x16);
            this.simpleButtonlist.TabIndex = 10;
            this.simpleButtonlist.Text = "列表";
            this.simpleButtonlist.ToolTip = "显示遥感班块列表";
            this.simpleButtonlist.Click += new EventHandler(this.simpleButtonlist_Click);
            this.panelInfo.Controls.Add(this.labelXBInfo);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(6, 30);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(0, 4, 0, 4);
            this.panelInfo.Size = new Size(0x10c, 0x5e);
            this.panelInfo.TabIndex = 40;
            this.panelInfo.Visible = false;
            this.labelXBInfo.Dock = DockStyle.Fill;
            this.labelXBInfo.Location = new System.Drawing.Point(0, 4);
            this.labelXBInfo.Name = "labelXBInfo";
            this.labelXBInfo.Size = new Size(0x10c, 0x56);
            this.labelXBInfo.TabIndex = 0;
            this.labelXBInfo.Text = "已有变更小班 共计0个  \r\n导入遥感判读班块0个,已确定变化原因班块0个(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n非遥感判读导入班块0个,(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n\r\n\r\n";
            this.panelControlSel.Appearance.BackColor = Color.Transparent;
            this.panelControlSel.Appearance.Options.UseBackColor = true;
            this.panelControlSel.Controls.Add(this.simpleButtonCancel);
            this.panelControlSel.Controls.Add(this.radioGroupSel);
            this.panelControlSel.Controls.Add(this.label2);
            this.panelControlSel.Controls.Add(this.simpleButtonSel);
            this.panelControlSel.Location = new System.Drawing.Point(30, 200);
            this.panelControlSel.Name = "panelControlSel";
            this.panelControlSel.Padding = new Padding(4);
            this.panelControlSel.Size = new Size(220, 0x9f);
            this.panelControlSel.TabIndex = 0x29;
            this.panelControlSel.Visible = false;
            this.radioGroupSel.Location = new System.Drawing.Point(9, 0x2c);
            this.radioGroupSel.Name = "radioGroupSel";
            this.radioGroupSel.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "清空导入[清空已导入,重新导入]"), new RadioGroupItem(null, "覆盖导入[覆盖已导入,重头导入]"), new RadioGroupItem(null, "继续导入[保留已导入,继续导入]") });
            this.radioGroupSel.Size = new Size(0xca, 0x4e);
            this.radioGroupSel.TabIndex = 15;
            this.label2.Dock = DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xd0, 0x2d);
            this.label2.TabIndex = 14;
            this.label2.Text = "当前变更图层已存在遥感班块\r\n请选择导入方式";
            this.simpleButtonSel.ImageIndex = 0x13;
            this.simpleButtonSel.ImageList = this.imageList2;
            this.simpleButtonSel.Location = new System.Drawing.Point(0x55, 0x80);
            this.simpleButtonSel.Name = "simpleButtonSel";
            this.simpleButtonSel.Size = new Size(60, 0x16);
            this.simpleButtonSel.TabIndex = 11;
            this.simpleButtonSel.Text = "确定";
            this.simpleButtonSel.Click += new EventHandler(this.simpleButtonSel_Click);
            this.simpleButtonCancel.ImageIndex = 70;
            this.simpleButtonCancel.ImageList = this.imageList2;
            this.simpleButtonCancel.Location = new System.Drawing.Point(0x97, 0x80);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(60, 0x16);
            this.simpleButtonCancel.TabIndex = 0x10;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControlSel);
            base.Controls.Add(this.panelList);
            base.Controls.Add(this.panelLog);
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.panelInfo);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlInputYG";
            base.Padding = new Padding(6, 0, 6, 0);
            base.Size = new Size(280, 0x1cf);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageComboBox1.EndInit();
            this.repositoryItemPictureEdit1.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemImageEdit3.EndInit();
            this.repositoryItemImageEdit33.EndInit();
            this.panel6.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelControlSel.EndInit();
            this.panelControlSel.ResumeLayout(false);
            this.radioGroupSel.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void InitialTreeList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
                this.mQueryList.Clear();
                IQueryFilter filter = new QueryFilterClass();
                IFeatureCursor cursor = this.m_YGLayer.FeatureClass.Search(filter, false);
                IFeature pf = cursor.NextFeature();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int index = pf.Fields.FindField(configValue);
                if (index == -1)
                {
                    index = 0;
                }
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldDist").Split(new char[] { ',' });
                while (pf != null)
                {
                    node3 = this.tList.AppendNode(pf.get_Value(index).ToString(), parentNode);
                    node3.ImageIndex = 1;
                    node3.StateImageIndex = 3;
                    node3.SelectImageIndex = 1;
                    node3.SetValue(0, pf.get_Value(index).ToString());
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num3 = pf.Fields.FindField(strArray[i]);
                        if (num3 > -1)
                        {
                            node3.SetValue(i + 1, this.GetFiledValue(num3, pf));
                        }
                    }
                    node3.Tag = pf;
                    this.mQueryList.Add(pf);
                    Application.DoEvents();
                    if (this.mStopList)
                    {
                        this.simpleButtonlist.ImageIndex = 7;
                        this.simpleButtonlist.Text = "列表";
                        this.simpleButtonlist.ToolTip = "显示遥感班块列表";
                        break;
                    }
                    pf = cursor.NextFeature();
                }
                this.Cursor = Cursors.Default;
                if (this.mQueryList.Count > 0)
                {
                    this.simpleButtonInfo.Enabled = true;
                }
                else
                {
                    this.simpleButtonInfo.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                this.panelLog.Visible = false;
                this.panelList.BringToFront();
                this.simpleButtonBack.Visible = false;
                this.simpleButtonOK.Visible = true;
                this.simpleButtonOK.Enabled = false;
                this.simpleButtonCheck.Visible = true;
                this.simpleButtonInfo.Enabled = false;
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_CountyFeature == null)
                {
                    string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.m_DistLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, sLayerName, true) as IFeatureLayer;
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    if (this.m_DistLayer != null)
                    {
                        GC.Collect();
                        IQueryFilter filter = new QueryFilterClass();
                        string str3 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                        filter.WhereClause = str3 + "='" + EditTask.DistCode.Substring(0, 6) + "'";
                        this.m_CountyFeature = this.m_DistLayer.Search(filter, false).NextFeature();
                    }
                }
                int num = this.m_YGLayer.FeatureClass.FeatureCount(null);
                this.labelCount.Text = "遥感检测变化数据 共计" + num + "个班块";
                IQueryFilter queryFilter = new QueryFilterClass();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num2 = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                queryFilter.WhereClause = configValue + " <> ''";
                int num3 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelCount.Text = string.Concat(new object[] { this.labelCount.Text, "\r\n已导入遥感判读班块", num3, "个" });
                this.labelCount.Height = 30;
                this.labelCount.BringToFront();
                this.panel3.Height = 30;
                this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                this.mCurItemImageEdit0.Images = this.imageList0;
                this.mQueryList = new ArrayList();
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
                this.simpleButtonCheck.Enabled = true;
                this.label1.Text = "导入遥感检测变化数据";
               // this.mDBAccess = UtilFactory.GetDBAccess("Access");
                this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
                for (int i = 0; i < 6; i++)
                {
                    if (this.mStateTable.Rows[i]["EditState"].ToString().Trim() != "2")
                    {
                        this.label1.Text = "请先完成六类专题的合并，再导入遥感变化检测数据。";
                        this.simpleButtonCheck.Enabled = false;
                        return;
                    }
                }
                this.label1.Text = "已做完专题合并，可导入遥感变化检测数据。";
                if (this.panelInfo.Visible)
                {
                    this.GetXBInfo();
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private IFeatureClass Intersect(IList<IFeatureClass> pFCList, string sFile)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                if ((pFCList == null) || (pFCList.Count < 1))
                {
                    return null;
                }
                IGpValueTableObject obj2 = new GpValueTableObjectClass();
                obj2.SetColumns(1);
                object row = null;
                for (int i = 0; i < pFCList.Count; i++)
                {
                    row = pFCList[i];
                    obj2.AddRow(ref row);
                }
                if (!(Directory.Exists(System.IO.Path.GetDirectoryName(sFile)) && (".shp" == System.IO.Path.GetExtension(sFile))))
                {
                    return null;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Intersect process = new ESRI.ArcGIS.AnalysisTools.Intersect(obj2, sFile);
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                return class2;
            }
            catch
            {
                return null;
            }
        }

        private void labelIdentify_Click(object sender, EventArgs e)
        {
            this.panelInfo.Visible = !this.panelInfo.Visible;
            if (this.panelInfo.Visible)
            {
                this.GetXBInfo();
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.panelList.BringToFront();
            this.simpleButtonBack.Visible = false;
            this.simpleButtonOK.Visible = true;
            this.simpleButtonCheck.Visible = true;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.panelControlSel.Visible = false;
            this.simpleButtonOK.Enabled = true;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string str4;
                this.Cursor = Cursors.WaitCursor;
                bool flag = true;
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.labelprogress.Text = "    检查是否有重叠相交小班...";
                this.labelprogress.Visible = true;
                IList<IFeatureClass> pFCList = new List<IFeatureClass>();
                pFCList.Add(this.m_YGLayer.FeatureClass);
                string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                string sFile = str + @"\ygintersect.shp";
                if (File.Exists(str + "ygintersect.shp"))
                {
                    File.Delete(str + "ygintersect.shp");
                }
                if (File.Exists(str + "ygintersect.dbf"))
                {
                    File.Delete(str + "ygintersect.dbf");
                }
                if (File.Exists(str + "ygintersect.sbn"))
                {
                    File.Delete(str + "ygintersect.sbn");
                }
                if (File.Exists(str + "ygintersect.sbx"))
                {
                    File.Delete(str + "ygintersect.sbx");
                }
                if (File.Exists(str + "ygintersect.shx"))
                {
                    File.Delete(str + "ygintersect.shx");
                }
                if (File.Exists(str + "ygintersect.shp.xml"))
                {
                    File.Delete(str + "ygintersect.shp.xml");
                }
                if (File.Exists(str + "ygintersect.prj"))
                {
                    File.Delete(str + "ygintersect.prj");
                }
                this.richTextBox.Text = "计算遥感图层相交班块";
                Application.DoEvents();
                IFeatureClass class2 = this.Intersect(pFCList, sFile);
                this.Cursor = Cursors.Default;
                int num = class2.FeatureCount(null);
                if (num > 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n遥感图层有", num, "个相交班块" });
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层有" + num + "个相交班块";
                    }
                    this.richTextBox.Refresh();
                    this.simpleButtonOK.Enabled = false;
                    flag = false;
                }
                else
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n遥感图层无相交要素";
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层无相交要素";
                    }
                    this.richTextBox.Refresh();
                }
                IFeatureClass featureClass = this.m_YGLayer.FeatureClass;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "ltrim(rtrim(bhyy))='' or bhyy is null";
                int num2 = featureClass.FeatureCount(queryFilter);
                if (num2 == 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n遥感图层无变化原因未填写的班块";
                    }
                    else
                    {
                        this.richTextBox.Text = "遥感图层无变化原因未填写的班块";
                    }
                }
                else if (this.richTextBox.Text != "")
                {
                    this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n遥感图层有", num2, "个变化原因未填写的班块" });
                }
                else
                {
                    this.richTextBox.Text = "遥感图层有" + num2 + "个变化原因未填写的班块";
                }
                this.richTextBox.Refresh();
                if (num2 > 0)
                {
                    this.simpleButtonOK.Enabled = false;
                    flag = false;
                }
                this.simpleButtonOK.Enabled = flag;
                string[] strArray = (this.m_YGLayer.FeatureClass as IDataset).Name.Split(new char[] { '.' });
                string str3 = strArray[strArray.Length - 1];
                str3 = str3.Replace("_" + EditTask.TaskYear, "");
                if (this.simpleButtonOK.Enabled)
                {
                    this.labelprogress.Text = "    遥感校验完成--通过校验，可导入小班变更图层。";
                    str4 = "update T_EditTask  set logiccheckstate='1' where layername = '" + str3 + "'";
                  //  this.mDBAccess.ExecuteScalar(str4);
                    str4 = "update T_EditTask  set toplogiccheckstate='1' where layername = '" + str3 + "'";
                   // this.mDBAccess.ExecuteScalar(str4);
                }
                else
                {
                    this.labelprogress.Text = "    遥感校验完成--未通过校验，请进入遥感专题修改后再做更新。";
                    str4 = "update T_EditTask  set logiccheckstate='0' where layername = '" + str3 + "'";
                 //   this.mDBAccess.ExecuteScalar(str4);
                    str4 = "update T_EditTask  set toplogiccheckstate='0' where layername = '" + str3 + "'";
                  //  this.mDBAccess.ExecuteScalar(str4);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "simpleButtonCheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            XtraTabControl control;
            if (this.mQueryList != null)
            {
                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_YGLayer, this.mQueryList, null, this.sDesKeyField, null, null);
                this.mDockPanel.Visibility = DockVisibility.Visible;
                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                {
                    control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                    if (control != null)
                    {
                        this.mDockPanel.Text = "遥感判读班块信息";
                        if (control.TabPages[0].Tooltip == "作业设计信息")
                        {
                            control.TabPages[0].PageVisible = false;
                        }
                        if (control.TabPages[1].Tooltip == "查询结果列表")
                        {
                            control.TabPages[1].PageVisible = true;
                            control.SelectedTabPage = control.TabPages[1];
                        }
                    }
                    else
                    {
                        this.mDockPanel.Text = "遥感判读班块信息";
                    }
                }
            }
            this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_EditLayer, null, null, this.sDesKeyField, null, null);
            if (this.mDockPanel.Controls[0].Controls.Count > 0)
            {
                control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                if (control != null)
                {
                    control.TabPages[1].PageVisible = true;
                }
                else
                {
                    this.mDockPanel.Text = "遥感判读班块信息";
                }
            }
        }

        private void simpleButtonlist_Click(object sender, EventArgs e)
        {
            if (this.simpleButtonlist.ImageIndex == 7)
            {
                this.simpleButtonlist.ImageIndex = 0x17;
                this.simpleButtonlist.Text = "停止";
                this.simpleButtonlist.ToolTip = "停止显示遥感班块列表";
                this.mStopList = false;
                this.mQueryList = new ArrayList();
                this.InitialTreeList();
            }
            else if (this.simpleButtonlist.ImageIndex == 0x17)
            {
                this.simpleButtonInfo.Enabled = true;
                this.mStopList = true;
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                string str2 = "DT_SRC";
                int num = 0;
                string name = "";
                name = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num2 = this.m_EditLayer.FeatureClass.Fields.FindField(name);
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = name + " <> ''and " + str2 + " = '99'";
                num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.bContinue = false;
                if (num > 0)
                {
                    this.simpleButtonOK.Enabled = false;
                    this.panelControlSel.Visible = true;
                    this.panelControlSel.BringToFront();
                    this.radioGroupSel.SelectedIndex = 1;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (editWorkspace == null)
                    {
                        return;
                    }
                    this.simpleButtonCheck.Enabled = false;
                    this.DoInput(editWorkspace, this.m_YGLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                    this.simpleButtonCheck.Enabled = true;
                    this.Cursor = Cursors.Default;
                    this.simpleButtonCheck.Visible = false;
                    this.simpleButtonBack.Visible = true;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "simpleButtonOK_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonSel_Click(object sender, EventArgs e)
        {
            string str6;
            IWorkspaceEdit editWorkspace;
            string str2 = "DT_SRC";
            string configValue = "";
            configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
            if (this.radioGroupSel.SelectedIndex == 0)
            {
                string str4 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer") + "_" + EditTask.TaskYear;
                string sqlStmt = "DELETE FROM " + str4 + " where ( " + configValue + " <> '' and " + str2 + " = '99' )";
                (this.m_EditLayer.FeatureClass as IDataset).Workspace.ExecuteSQL(sqlStmt);
                str6 = "DELETE * FROM T_Input_YGFeature";
              //  this.mDBAccess.ExecuteScalar(str6);
                this.Cursor = Cursors.WaitCursor;
                editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace == null)
                {
                    return;
                }
                this.simpleButtonCheck.Enabled = false;
                this.DoInput(editWorkspace, this.m_YGLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                this.simpleButtonCheck.Enabled = true;
                this.Cursor = Cursors.Default;
                this.simpleButtonCheck.Visible = false;
                this.simpleButtonBack.Visible = true;
            }
            else if (this.radioGroupSel.SelectedIndex == 1)
            {
                str6 = "DELETE * FROM T_Input_YGFeature";
              //  this.mDBAccess.ExecuteScalar(str6);
                this.Cursor = Cursors.WaitCursor;
                editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace == null)
                {
                    return;
                }
                this.simpleButtonCheck.Enabled = false;
                this.DoInput(editWorkspace, this.m_YGLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                this.simpleButtonCheck.Enabled = true;
                this.Cursor = Cursors.Default;
                this.simpleButtonCheck.Visible = false;
                this.simpleButtonBack.Visible = true;
            }
            else if (this.radioGroupSel.SelectedIndex == 2)
            {
                this.bContinue = true;
                this.Cursor = Cursors.WaitCursor;
                editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace == null)
                {
                    return;
                }
                this.simpleButtonCheck.Enabled = false;
                this.DoInput(editWorkspace, this.m_YGLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                this.simpleButtonCheck.Enabled = true;
                this.Cursor = Cursors.Default;
                this.simpleButtonCheck.Visible = false;
                this.simpleButtonBack.Visible = true;
            }
            this.simpleButtonOK.Enabled = true;
        }

        private void tList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn5")
            {
                e.RepositoryItem = this.mCurItemImageEdit0;
            }
        }

        private void tList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.column = e.Column.AbsoluteIndex;
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                this.mNode = e.Node;
            }
        }

        private void tList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (((e.X >= this.tList.Columns[0].Width) && (this.column != 1)) && (this.column != 2))
                {
                    if (this.column == 4)
                    {
                        IFeature pFeature = null;
                        pFeature = this.mNode.Tag as IFeature;
                        GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                    }
                    else if (this.column == 5)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool UpdateField(IObject pObject, string sFieldName, object pFieldValue)
        {
            try
            {
                int index = pObject.Fields.FindField(sFieldName);
                if (index > 0)
                {
                    pObject.set_Value(index, pFieldValue);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void ZTOverlap()
        {
            try
            {
                int num2;
                this.labelprogress.Text = this.labelprogress.Text + "\n计算遥感变化小班与专题数据相交情况...";
                this.labelprogress.Visible = true;
                this.richTextBox.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                IList<IFeatureLayer> pLayerList = new List<IFeatureLayer>();
                for (num2 = 0; num2 < EditTask.UnderLayers.Count; num2++)
                {
                    IFeatureLayer item = EditTask.UnderLayers[num2] as IFeatureLayer;
                    if (!item.Name.Contains("遥感"))
                    {
                        pLayerList.Add(item);
                    }
                }
            //    IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                DataTable dataTable = null;
              //  dataTable = dBAccess.GetDataTable(dBAccess, "select * from T_EditTask");
                for (num2 = 0; num2 < dataTable.Rows.Count; num2++)
                {
                    string sCmdText = "update T_EditTask set EditState='0' where ID= " + dataTable.Rows[num2]["ID"].ToString();
                  //  dBAccess.ExecuteScalar(sCmdText);
                }
                Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.labelprogress.Text = "计算遥感变化小班与专题数据相交情况...";
                UpdateSub.FindZTOverlap(pLayerList);
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputYG", "ZTOverlap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

