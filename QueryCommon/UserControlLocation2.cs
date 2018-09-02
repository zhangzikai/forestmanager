namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlLocation2 : UserControlBase1
    {
        private SimpleButton ButtonDistLocation;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private IContainer components;
        public string DistCode = "";
        private const string DistLayerNames = "CNAME,TNAME,VNAME";
        private GroupControl groupControlDist;
        private Label label7;
        private Label label8;
        private Label label9;
        private bool m_bCoor;
        private bool m_bUnitD;
        private ITable m_CountyTable;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private IFeatureLayer m_pCLayer;
        private IFeatureLayer m_pTLayer;
        private IFeatureLayer m_pVLayer;
        private ITable m_Table;
        private ITable m_Table2;
        private ITable m_TownTable;
        private ITable m_VillageTable;
        private const string mClassName = "QueryAnalysic.UserControlQueryLocate";
        private ArrayList mCList;
        private ArrayList mCList2;
        private DataRow mDataRow;
       // private IDBAccess mDBAccess;
        private string mEditKind = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mfWorkspace;
        private bool mNodeExpend;
        private string MountainFieldsName = "";
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mTList;
        private ArrayList mTList2;
        private ArrayList mVList;
        private ArrayList mVList2;
        private const string myClassName = "区划逐级定位";
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel9;
        private Panel panelDistLocation;
        private string sDistFieldCode;
        private string sDistFieldCode2;
        private string sDistFieldCode3;
        private string sDistFieldName;
        private string sDistFieldName2;
        private string sDistFieldName3;
        private string sDistLayerName;
        private string sDistLayerName2;
        private string sDistLayerName3;
        private string VillageFieldsName = "";
        private const string XBCodeName = "SUBLOT_ID";
        private string XBCodeName2 = "";

        public UserControlLocation2()
        {
            this.InitializeComponent();
        }

        private void AddTownNames()
        {
            try
            {
                this.comboBoxTown.Properties.Items.Clear();
                this.comboBoxTown.ResetText();
                this.comboBoxTown.Properties.Items.Add("--");
                this.comboBoxVillage.Properties.Items.Clear();
                this.comboBoxVillage.ResetText();
                this.comboBoxVillage.Properties.Items.Add("--");
                if (((this.m_pTLayer != null) && (this.comboBoxCounty.SelectedItem != null)) && (this.comboBoxCounty.SelectedItem.ToString() != "--"))
                {
                    IFeature feature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                    int index = feature.Fields.FindField(this.sDistFieldName);
                    this.mTList = this.GetDistValues(this.m_pTLayer, this.sDistFieldName2, this.sDistFieldName + "='" + feature.get_Value(index).ToString() + "'", out this.mTList, out this.mTList2);
                    for (int i = 0; i < this.mTList.Count; i++)
                    {
                        this.comboBoxTown.Properties.Items.Add(this.mTList[i].ToString());
                    }
                    this.comboBoxTown.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "AddTownNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddVillageNames()
        {
            try
            {
                this.comboBoxVillage.Properties.Items.Clear();
                this.comboBoxVillage.ResetText();
                this.comboBoxVillage.Properties.Items.Add("--");
                if ((this.m_pVLayer != null) && ((this.comboBoxCounty.SelectedItem != null) && (this.comboBoxTown.SelectedItem != null)))
                {
                    this.comboBoxCounty.SelectedItem.ToString();
                    if (this.comboBoxTown.SelectedItem.ToString() != "--")
                    {
                        IFeature feature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        int index = feature.Fields.FindField(this.sDistFieldName2);
                        this.mVList = this.GetDistValues(this.m_pVLayer, this.sDistFieldName3, this.sDistFieldName2 + "='" + feature.get_Value(index).ToString() + "'", out this.mVList, out this.mVList2);
                        for (int i = 0; i < this.mVList.Count; i++)
                        {
                            this.comboBoxVillage.Properties.Items.Add(this.mVList[i].ToString());
                        }
                        this.comboBoxVillage.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "AddVillageNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonDistLocation_Click(object sender, EventArgs e)
        {
            try
            {
                IFeatureLayer pFLayer = null;
                IFeature pFeature = null;
                if (this.comboBoxCounty.SelectedIndex == 0)
                {
                    this.m_HookHelper.ActiveView.Extent = this.m_HookHelper.ActiveView.FullExtent;
                }
                else
                {
                    if (this.comboBoxTown.SelectedIndex == 0)
                    {
                        this.comboBoxCounty.SelectedItem.ToString();
                        pFeature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                        pFLayer = this.m_pCLayer;
                    }
                    else if (this.comboBoxVillage.SelectedIndex == 0)
                    {
                        this.comboBoxTown.SelectedItem.ToString();
                        pFeature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        pFLayer = this.m_pTLayer;
                    }
                    else if ((this.comboBoxVillage.SelectedIndex != -1) && (this.comboBoxVillage.SelectedIndex != 0))
                    {
                        this.comboBoxVillage.SelectedItem.ToString();
                        pFeature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                        int index = pFeature.Fields.FindField(this.sDistFieldCode3);
                        this.DistCode = pFeature.get_Value(index).ToString();
                        pFLayer = this.m_pVLayer;
                    }
                    else if (this.comboBoxTown.SelectedIndex != -1)
                    {
                        this.comboBoxTown.SelectedItem.ToString();
                        pFeature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                        int num2 = pFeature.Fields.FindField(this.sDistFieldCode2);
                        this.DistCode = pFeature.get_Value(num2).ToString();
                        pFLayer = this.m_pTLayer;
                    }
                    else if (this.comboBoxCounty.SelectedIndex != -1)
                    {
                        this.comboBoxCounty.SelectedItem.ToString();
                        pFeature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                        int num3 = pFeature.Fields.FindField(this.sDistFieldCode);
                        this.DistCode = pFeature.get_Value(num3).ToString();
                        pFLayer = this.m_pCLayer;
                    }
                    else
                    {
                        pFLayer = null;
                    }
                    if (pFeature != null)
                    {
                        this.SelectFeature(pFLayer, pFeature);
                        GISFunFactory.FeatureFun.ZoomToFeature(this.m_HookHelper.FocusMap, pFeature);
                        IMapControl2 hook = (IMapControl2) this.m_HookHelper.Hook;
                        if (hook != null)
                        {
                            hook.FlashShape(pFeature.Shape, 3, 300, null);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "ButtonDistLocation_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void comboBoxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pText = this.comboBoxCounty.SelectedText.Trim(new char[] { '-' });
            this.SetControlProperty(pText);
            this.AddTownNames();
            if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
            {
                IFeature feature = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                int index = feature.Fields.FindField(this.sDistFieldCode);
                if (index > -1)
                {
                    this.DistCode = feature.get_Value(index).ToString();
                }
            }
            else if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex == 0))
            {
                this.DistCode = "";
            }
        }

        private void comboBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pText = this.comboBoxTown.SelectedText.Trim(new char[] { '-' });
            this.SetControlProperty(pText);
            this.AddVillageNames();
            if ((this.mTList2 != null) && (this.comboBoxTown.SelectedIndex > 0))
            {
                IFeature feature = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                int index = feature.Fields.FindField(this.sDistFieldCode2);
                if (index > -1)
                {
                    this.DistCode = feature.get_Value(index).ToString();
                }
            }
            else if ((this.mTList2 != null) && (this.comboBoxTown.SelectedIndex == 0))
            {
                this.DistCode = "";
                if ((this.mCList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
                {
                    IFeature feature2 = this.mCList2[this.comboBoxCounty.SelectedIndex - 1] as IFeature;
                    int num2 = feature2.Fields.FindField(this.sDistFieldCode);
                    if (num2 > -1)
                    {
                        this.DistCode = feature2.get_Value(num2).ToString();
                    }
                }
            }
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pText = this.comboBoxVillage.SelectedText.Trim(new char[] { '-' });
            this.SetControlProperty(pText);
            if ((this.mVList2 != null) && (this.comboBoxVillage.SelectedIndex > 0))
            {
                IFeature feature = this.mVList2[this.comboBoxVillage.SelectedIndex - 1] as IFeature;
                int index = feature.Fields.FindField(this.sDistFieldCode3);
                if (index > -1)
                {
                    this.DistCode = feature.get_Value(index).ToString();
                }
            }
            else if ((this.mVList2 != null) && (this.comboBoxVillage.SelectedIndex == 0))
            {
                this.DistCode = "";
                if ((this.mTList2 != null) && (this.comboBoxCounty.SelectedIndex > 0))
                {
                    IFeature feature2 = this.mTList2[this.comboBoxTown.SelectedIndex - 1] as IFeature;
                    int num2 = feature2.Fields.FindField(this.sDistFieldCode2);
                    if (num2 > -1)
                    {
                        this.DistCode = feature2.get_Value(num2).ToString();
                    }
                }
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

        private ArrayList GetDistValues(IFeatureLayer pFLayer, string FieldName, string WhereString, out ArrayList list, out ArrayList list2)
        {
            list = new ArrayList();
            list2 = new ArrayList();
            try
            {
                pFLayer.FeatureClass.FeatureCount(null);
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = WhereString;
                IFeatureCursor cursor = pFLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                string name = FieldName;
                int index = feature.Fields.FindField(name);
                string str2 = "";
                while (feature != null)
                {
                    if ((feature.Fields.get_Field(index).Domain != null) && (feature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        str2 = "";
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(index).Domain;
                            long num2 = Convert.ToInt64(feature.get_Value(index));
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (num2 == Convert.ToInt64(domain.get_Value(i)))
                                {
                                    str2 = domain.get_Name(i);
                                    goto Label_0113;
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
                Label_0113:
                    list.Add(str2);
                    list2.Add(feature);
                    feature = cursor.NextFeature();
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        private void InitDistList()
        {
            try
            {
                if (this.m_pCLayer != null)
                {
                    this.mCList = this.GetDistValues(this.m_pCLayer, this.sDistFieldName, "", out this.mCList, out this.mCList2);
                    this.comboBoxCounty.Properties.Items.Clear();
                    this.comboBoxTown.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxCounty.Properties.Items.Add("--");
                    for (int i = 0; i < this.mCList.Count; i++)
                    {
                        this.comboBoxCounty.Properties.Items.Add(this.mCList[i].ToString());
                    }
                    this.comboBoxCounty.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "InitDistList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        public void InitialControls(object hook)
        {
            try
            {
                this.m_HookHelper = new HookHelperClass();
                this.m_HookHelper.Hook = hook;
                this.m_Map = this.m_HookHelper.FocusMap;
                if (this.m_Map != null)
                {
                    this.InitLayers();
                    this.InitDistList();
                    //if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "Local")
                    //{
                    //    this.mDBAccess = UtilFactory.GetDBAccess("Access");
                    //}
                    //else if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "SqlServer")
                    //{
                    //    this.mDBAccess = UtilFactory.GetDBAccess("SqlServer");
                    //}
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.ButtonDistLocation = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelDistLocation);
            this.groupControlDist.Controls.Add(this.panel9);
            this.groupControlDist.Controls.Add(this.panel13);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDist.Location = new System.Drawing.Point(0, 7);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(5, 0, 7, 7);
            this.groupControlDist.Size = new System.Drawing.Size(248, 152);
            this.groupControlDist.TabIndex = 15;
            this.groupControlDist.Text = "出版区划定位";
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(62, 22);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(177, 95);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(177, 95);
            this.panel10.TabIndex = 14;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 66);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Size = new System.Drawing.Size(177, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 57);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(177, 9);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 37);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Size = new System.Drawing.Size(177, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.SelectedIndexChanged += new System.EventHandler(this.comboBoxTown_SelectedIndexChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 28);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(177, 9);
            this.panel14.TabIndex = 8;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 8);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Size = new System.Drawing.Size(177, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.SelectedIndexChanged += new System.EventHandler(this.comboBoxCounty_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(177, 8);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(7, 22);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(55, 95);
            this.panel9.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "村：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 36);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.ButtonDistLocation);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(7, 117);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(232, 26);
            this.panel13.TabIndex = 15;
            // 
            // ButtonDistLocation
            // 
            this.ButtonDistLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDistLocation.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonDistLocation.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonDistLocation.Location = new System.Drawing.Point(166, 0);
            this.ButtonDistLocation.Name = "ButtonDistLocation";
            this.ButtonDistLocation.Size = new System.Drawing.Size(66, 26);
            this.ButtonDistLocation.TabIndex = 12;
            this.ButtonDistLocation.Text = "定位";
            this.ButtonDistLocation.ToolTip = "定位";
            this.ButtonDistLocation.Click += new System.EventHandler(this.ButtonDistLocation_Click);
            // 
            // UserControlLocation2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControlDist);
            this.Name = "UserControlLocation2";
            this.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.Size = new System.Drawing.Size(248, 159);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitLayers()
        {
            try
            {
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName, true);
                this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName2, true);
                this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName3, true);
                string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("CurrentDataPath");
                this.mfWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
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
                        this.sDistLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                        this.sDistLayerName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                        this.sDistLayerName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                        this.sDistFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldName");
                        this.sDistFieldCode = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                        this.sDistFieldName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                        this.sDistFieldCode2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                        this.sDistFieldName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldName");
                        this.sDistFieldCode3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "InitLayers", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                        Array.Resize<ColumnHeader>(ref array, i + 1);
                        array[i] = new ColumnHeader();
                        array[i].Width = num2;
                        array[i].Text = aliasName;
                    }
                    listResult.Columns.AddRange(array);
                }
            }
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.m_HookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        private void SetControlProperty(string pText)
        {
            if (this.m_HookHelper.Hook is IMapControl4)
            {
                IMapControl4 hook = this.m_HookHelper.Hook as IMapControl4;
                hook.CustomProperty = pText;
            }
            else if (this.m_HookHelper.Hook is IPageLayout3)
            {
                IPageLayoutControl3 control2 = this.m_HookHelper.Hook as IPageLayoutControl3;
                control2.CustomProperty = pText;
            }
            else if (this.m_HookHelper.Hook is IToolbarControl2)
            {
                IToolbarControl2 control3 = this.m_HookHelper.Hook as IToolbarControl2;
                control3.CustomProperty = pText;
            }
        }

        private void ZoomToFeature(IMap pMap, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shape = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shape = pFeature.Shape;
                    envelope = new EnvelopeClass();
                    envelope = shape.Envelope;
                    view = pMap as IActiveView;
                    if (shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shape as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.5, 1.5, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.FullExtent = envelope;
                        view.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ZoomToGeometry(IMap pMap, IGeometry pGeometry)
        {
            try
            {
                if ((pMap != null) && (pGeometry != null))
                {
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    envelope = new EnvelopeClass();
                    envelope = pGeometry.Envelope;
                    view = pMap as IActiveView;
                    if (pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = pGeometry as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.25, 1.25, true);
                    }
                    view.Extent = envelope;
                    view.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "ZoomToGeometry", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public string CountryName
        {
            get
            {
                return this.comboBoxCounty.Text;
            }
        }

        public string TownName
        {
            get
            {
                return this.comboBoxTown.Text;
            }
        }

        public string VillageName
        {
            get
            {
                return this.comboBoxVillage.Text;
            }
        }
    }
}

