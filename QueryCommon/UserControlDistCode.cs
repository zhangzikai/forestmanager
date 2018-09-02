namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlDistCode : UserControlBase1
    {
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
        private const string myClassName = "区划逐级代码";
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
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

        public UserControlDistCode()
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

        private void comboBoxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception)
            {
            }
        }

        private void comboBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelDistLocation);
            this.groupControlDist.Controls.Add(this.panel9);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDist.Location = new System.Drawing.Point(0, 0);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 2, 8, 8);
            this.groupControlDist.Size = new System.Drawing.Size(268, 138);
            this.groupControlDist.TabIndex = 16;
            this.groupControlDist.Text = "区划范围选择";
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(66, 24);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(192, 104);
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
            this.panel10.Size = new System.Drawing.Size(192, 104);
            this.panel10.TabIndex = 14;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 70);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Size = new System.Drawing.Size(192, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 60);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(192, 10);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 40);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Size = new System.Drawing.Size(192, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.SelectedIndexChanged += new System.EventHandler(this.comboBoxTown_SelectedIndexChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 30);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(192, 10);
            this.panel14.TabIndex = 8;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 10);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Size = new System.Drawing.Size(192, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.SelectedIndexChanged += new System.EventHandler(this.comboBoxCounty_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(192, 10);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(8, 24);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(58, 104);
            this.panel9.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "村：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 37);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlDistCode
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControlDist);
            this.MaximumSize = new System.Drawing.Size(350, 152);
            this.Name = "UserControlDistCode";
            this.Size = new System.Drawing.Size(268, 138);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitLayers()
        {
            try
            {
                this.sDistLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.sDistLayerName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                this.sDistLayerName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                this.sDistFieldName = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldName");
                this.sDistFieldCode = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                this.sDistFieldName2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                this.sDistFieldCode2 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                this.sDistFieldName3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldName");
                this.sDistFieldCode3 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName, true);
                this.m_pTLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName2, true);
                this.m_pVLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, this.sDistLayerName3, true);
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
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryLocate", "InitLayers", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

