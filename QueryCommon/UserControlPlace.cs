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
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 查询--地名查找：工具箱界面
    /// </summary>
    public class UserControlPlace : UserControlBase1
    {
        private SimpleButton ButtonQueryMountain;
        private SimpleButton ButtonQueryOther;
        private SimpleButton ButtonQueryPlace;
        private ComboBoxEdit cmbFind;
        private ComboBoxEdit cmbFind2;
        private IContainer components;
        private const string DistLayerNames = "CNAME,TNAME,VNAME";
        private GroupControl groupControlMountain;
        private GroupControl groupControlOther;
        private GroupControl groupControlPlace;
        private ImageListBoxControl icmbFind;
        private ImageListBoxControl icmbFind2;
        private Label label22;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label labelQuery;
        private ListView listMountain;
        private bool m_bCoor;
        private bool m_bUnitD;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private const string mClassName = "QueryAnalysic.UserControlPlace";
        private DataRow mDataRow;
       // private IDBAccess mDBAccess;
        private string mEditKind = "";
        private string mEditKind2 = "";
        private IFeatureLayer mEditLayer;
        private IEnvelope mEnvelope;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mfWorkspace;
        private bool mNodeExpend;
        private ArrayList mOtherLayerList;
        private ArrayList mOtherList;
        private ArrayList mPlaceLayerList;
        private ArrayList mPlaceList;
        private IPoint mPoint;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "地名道路水系查询";
        private Panel panel1;
        private Panel panel15;
        private Panel panel16;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel24;
        private Panel panel26;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panQuery;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroup2;
        private RadioGroup radioGroup3;
        private TextEdit textEditMountain;
        private const string XBCodeName = "SUBLOT_ID";
        private string XBCodeName2 = "";

        /// <summary>
        /// 查询--地名查找：工具箱界面：构造器
        /// </summary>
        public UserControlPlace()
        {
            this.InitializeComponent();
        }

        private void ButtonQueryOther_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.cmbFind2.Text))
                {
                    MessageBox.Show("请输入名称。", "地名查找", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (this.cmbFind2.Properties.Items.Count == 0)
                    {
                        this.cmbFind2.Properties.Items.Add(this.cmbFind2.Text.Trim());
                    }
                    else
                    {
                        int num = 0;
                        bool flag = true;
                        for (num = 0; num <= (this.cmbFind2.Properties.Items.Count - 1); num++)
                        {
                            if (this.cmbFind2.Properties.Items[num].ToString() == this.cmbFind2.Text.Trim())
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            try
                            {
                                this.cmbFind2.Properties.Items.Add(this.cmbFind2.Text.Trim());
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    string sSourceFile = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("CurrentDataPath");
                    IFeatureWorkspace featureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(sSourceFile, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                    if (featureWorkspace != null)
                    {
                        string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("OtherClassName").Split(new char[] { ',' });
                        string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("OtherLayerName").Split(new char[] { ',' });
                        string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue("OtherFiledName").Split(new char[] { ',' });
                        UtilFactory.GetConfigOpt().GetConfigValue("OtherDatasetName");
                        this.icmbFind2.Items.Clear();
                        this.mOtherList = new ArrayList();
                        this.mOtherLayerList = new ArrayList();
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_Map as IBasicMap, strArray2[i], true);
                            IFeatureClass pFeatureClass = null;
                            if (layer != null)
                            {
                                pFeatureClass = layer.FeatureClass;
                            }
                            else
                            {
                                pFeatureClass = featureWorkspace.OpenFeatureClass(strArray[i]);
                                layer = new FeatureLayerClass();
                                layer.Name = strArray2[i];
                                layer.FeatureClass = pFeatureClass;
                            }
                            if ((pFeatureClass != null) && (layer != null))
                            {
                                this.FindOther(pFeatureClass, strArray3[i], strArray2[i]);
                                this.mOtherLayerList.Add(layer);
                            }
                        }
                        if (this.icmbFind2.Items.Count > 0)
                        {
                            this.icmbFind2.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("没有找到符合条件的公路、道路、水系、湖泊，请重新确定查找条件。", "查询", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlPlace", "ButtonQueryOther_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonQueryPlace_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.cmbFind.Text))
                {
                    MessageBox.Show("请输入地名或区划名", "查找", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (this.cmbFind.Properties.Items.Count == 0)
                    {
                        this.cmbFind.Properties.Items.Add(this.cmbFind.Text.Trim());
                    }
                    else
                    {
                        int num = 0;
                        bool flag = true;
                        for (num = 0; num <= (this.cmbFind.Properties.Items.Count - 1); num++)
                        {
                            if (this.cmbFind.Properties.Items[num].ToString() == this.cmbFind.Text.Trim())
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            try
                            {
                                this.cmbFind.Properties.Items.Add(this.cmbFind.Text.Trim());
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                    if (editWorkspace != null)
                    {
                        string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("PlaceClassName").Split(new char[] { ',' });
                        string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("PlaceLayerName").Split(new char[] { ',' });
                        string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue("PlaceFiledName").Split(new char[] { ',' });
                        string[] strArray4 = UtilFactory.GetConfigOpt().GetConfigValue("PlaceTypeString").Split(new char[] { ',' });
                        
                        UtilFactory.GetConfigOpt().GetConfigValue("PlaceDatasetName");
                        this.icmbFind.Items.Clear();
                        this.mPlaceList = new ArrayList();
                        this.mPlaceLayerList = new ArrayList();
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_Map as IBasicMap, strArray2[i], true);
                            IFeatureClass pFeatureClass = null;
                            if (layer != null)
                            {
                                pFeatureClass = layer.FeatureClass;
                            }
                            else
                            {
                                pFeatureClass = editWorkspace.OpenFeatureClass(strArray[i]);
                                layer = new FeatureLayerClass();
                                layer.Name = strArray2[i];
                                layer.FeatureClass = pFeatureClass;
                            }
                            if ((pFeatureClass != null) && (layer != null))
                            {
                                this.FindPlace(pFeatureClass, strArray3[i], strArray2[i], strArray4[i]);
                                this.mPlaceLayerList.Add(layer);
                            }
                        }
                        if (this.icmbFind.Items.Count > 0)
                        {
                            this.icmbFind.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("没有找到符合条件的行政区划、地名，请重新确定查找条件。", "地名定位", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlPlace", "ButtonQueryPlace_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void FindOther(IFeatureClass pFeatureClass, string sName, string sKind)
        {
            try
            {
                IDataset dataset = pFeatureClass as IDataset;
                ISQLSyntax workspace = dataset.Workspace as ISQLSyntax;
                esriSQLSpecialCharacters sqlSC = esriSQLSpecialCharacters.esriSQL_WildcardManyMatch;
                string specialCharacter = workspace.GetSpecialCharacter(sqlSC);
                ISpatialFilter filter = new SpatialFilterClass();
                if (this.radioGroup2.SelectedIndex == 0)
                {
                    filter.Geometry = this.m_HookHelper.ActiveView.Extent;
                }
                else
                {
                    filter.Geometry = (pFeatureClass as IGeoDataset).Extent;
                }
                if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                }
                else
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                }
                filter.WhereClause = sName + " like '" + specialCharacter + this.cmbFind2.Text + specialCharacter + "'";
                IFeatureCursor cursor = pFeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                if (feature != null)
                {
                    int index = feature.Fields.FindField(sName);
                    ImageListBoxItem item = null;
                    while (feature != null)
                    {
                        item = new ImageListBoxItem();
                        if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                        {
                            item.ImageIndex = 0;
                        }
                        else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline)
                        {
                            item.ImageIndex = 1;
                        }
                        else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
                        {
                            item.ImageIndex = 2;
                        }
                        int num2 = 0;
                        int num3 = 0;
                        if (!string.IsNullOrEmpty(sKind))
                        {
                            if (this.icmbFind2.Items.Count > 0)
                            {
                                for (num2 = 0; num2 <= (this.icmbFind2.Items.Count - 1); num2++)
                                {
                                    if (this.icmbFind2.Items[num2].Value.ToString().Substring(1, string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" }).ToString().Length) == string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" }))
                                    {
                                        num3++;
                                    }
                                }
                            }
                            if (num3 > 0)
                            {
                                item.Value = string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]", num3 });
                            }
                            else
                            {
                                item.Value = string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" });
                            }
                        }
                        else
                        {
                            item.Value = feature.get_Value(index);
                        }
                        this.icmbFind2.Items.Add(item);
                        this.mOtherList.Add(feature);
                        if (this.mOtherList.Count > 0x3e8)
                        {
                            MessageBox.Show("符合条件的数据已超过1000, 请缩小范围重新查找。", "地名查找", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        feature = cursor.NextFeature();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlPlace", "FindOther", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void FindPlace(IFeatureClass pFeatureClass, string sName, string sKind, string sType)
        {
            try
            {
                IDataset dataset = pFeatureClass as IDataset;
                ISQLSyntax workspace = dataset.Workspace as ISQLSyntax;
                esriSQLSpecialCharacters sqlSC = esriSQLSpecialCharacters.esriSQL_WildcardManyMatch;
                string specialCharacter = workspace.GetSpecialCharacter(sqlSC);
                ISpatialFilter filter = new SpatialFilterClass();
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    filter.Geometry = this.m_HookHelper.ActiveView.Extent;
                }
                else
                {
                    filter.Geometry = (pFeatureClass as IGeoDataset).Extent;
                }
                if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                }
                else
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                }
                if (sType != "")
                {
                    filter.WhereClause = sName + " like '" + specialCharacter + this.cmbFind.Text + specialCharacter + "' and " + sType;
                }
                else
                {
                    filter.WhereClause = sName + " like '" + specialCharacter + this.cmbFind.Text + specialCharacter + "'";
                }
                IFeatureCursor cursor = pFeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                if (feature != null)
                {
                    int index = feature.Fields.FindField(sName);
                    ImageListBoxItem item = null;
                    while (feature != null)
                    {
                        item = new ImageListBoxItem();
                        if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                        {
                            item.ImageIndex = 0;
                        }
                        else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline)
                        {
                            item.ImageIndex = 1;
                        }
                        else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
                        {
                            item.ImageIndex = 2;
                        }
                        int num2 = 0;
                        int num3 = 0;
                        if (!string.IsNullOrEmpty(sKind))
                        {
                            if (this.icmbFind.Items.Count > 0)
                            {
                                for (num2 = 0; num2 <= (this.icmbFind.Items.Count - 1); num2++)
                                {
                                    if ((string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" }).ToString().Length == this.icmbFind.Items[num2].Value.ToString().Length) && (this.icmbFind.Items[num2].Value.ToString().Substring(0, string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" }).ToString().Length) == string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" })))
                                    {
                                        num3++;
                                    }
                                }
                            }
                            if (num3 > 0)
                            {
                                item.Value = string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]", num3 });
                            }
                            else
                            {
                                item.Value = string.Concat(new object[] { feature.get_Value(index), "[", sKind, "]" });
                            }
                        }
                        else
                        {
                            item.Value = feature.get_Value(index);
                        }
                        this.icmbFind.Items.Add(item);
                        this.mPlaceList.Add(feature);
                        if (this.mPlaceList.Count > 0x3e8)
                        {
                            MessageBox.Show("符合条件的数据已超过1000, 请缩小范围重新查找。", "地名查找", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        feature = cursor.NextFeature();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlPlace", "FindPlace", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void icmbFind_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.icmbFind.SelectedIndex != -1)
                {
                    IFeature feature = this.mPlaceList[this.icmbFind.SelectedIndex] as IFeature;
                    IEnvelope envelope = feature.Shape.Envelope;
                    envelope.Project(this.m_HookHelper.FocusMap.SpatialReference);
                    if (envelope.Width == 0.0)
                    {
                        envelope.PutCoords(envelope.XMin - 500.0, envelope.YMin, envelope.XMax + 500.0, envelope.YMax);
                    }
                    if (envelope.Height == 0.0)
                    {
                        envelope.PutCoords(envelope.XMin, envelope.YMin - 500.0, envelope.XMax, envelope.YMax + 500.0);
                    }
                    envelope.Expand(1.25, 1.25, true);
                    this.m_HookHelper.ActiveView.Extent = envelope;
                    this.m_HookHelper.ActiveView.Refresh();
                    (this.m_HookHelper.Hook as IMapControl2).FlashShape(feature.Shape, 1, 300, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void icmbFind_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.icmbFind.SelectedIndex != -1)
            {
                IFeature feature = this.mPlaceList[this.icmbFind.SelectedIndex] as IFeature;
                string str = this.icmbFind.Items[this.icmbFind.SelectedIndex].Value.ToString();
                IFeatureLayer layer = null;
                for (int i = 0; i < this.mPlaceLayerList.Count; i++)
                {
                    if (str.Contains("[" + (this.mPlaceLayerList[i] as IFeatureLayer).Name + "]"))
                    {
                        layer = this.mPlaceLayerList[i] as IFeatureLayer;
                    }
                }
                if (layer != null)
                {
                    this.m_Map.ClearSelection();
                    this.m_Map.SelectFeature(layer, feature);
                    this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, this.m_HookHelper.ActiveView.Extent);
                }
            }
        }

        private void icmbFind2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.icmbFind2.SelectedIndex != -1)
                {
                    IFeature feature = this.mOtherList[this.icmbFind2.SelectedIndex] as IFeature;
                    IEnvelope envelope = feature.Shape.Envelope;
                    envelope.Project(this.m_HookHelper.FocusMap.SpatialReference);
                    if (envelope.Width == 0.0)
                    {
                        envelope.PutCoords(envelope.XMin - 500.0, envelope.YMin, envelope.XMax + 500.0, envelope.YMax);
                    }
                    if (envelope.Height == 0.0)
                    {
                        envelope.PutCoords(envelope.XMin, envelope.YMin - 500.0, envelope.XMax, envelope.YMax + 500.0);
                    }
                    envelope.Expand(1.25, 1.25, true);
                    this.m_HookHelper.ActiveView.Extent = envelope;
                    this.m_HookHelper.ActiveView.Refresh();
                    (this.m_HookHelper.Hook as IMapControl2).FlashShape(feature.Shape, 1, 300, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void icmbFind2_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.icmbFind2.SelectedIndex != -1)
            {
                IFeature feature = this.mOtherList[this.icmbFind2.SelectedIndex] as IFeature;
                string str = this.icmbFind2.Items[this.icmbFind2.SelectedIndex].Value.ToString();
                IFeatureLayer layer = null;
                for (int i = 0; i < this.mOtherLayerList.Count; i++)
                {
                    if (str.Contains("[" + (this.mOtherLayerList[i] as IFeatureLayer).Name + "]"))
                    {
                        layer = this.mOtherLayerList[i] as IFeatureLayer;
                    }
                }
                if (layer != null)
                {
                    this.m_Map.ClearSelection();
                    this.m_Map.SelectFeature(layer, feature);
                    this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, this.m_HookHelper.ActiveView.Extent);
                }
            }
        }

        private void InitializeComponent()
        {
            this.panQuery = new System.Windows.Forms.Panel();
            this.groupControlPlace = new DevExpress.XtraEditors.GroupControl();
            this.icmbFind = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.label4 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.cmbFind = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ButtonQueryPlace = new DevExpress.XtraEditors.SimpleButton();
            this.panel26 = new System.Windows.Forms.Panel();
            this.groupControlOther = new DevExpress.XtraEditors.GroupControl();
            this.icmbFind2 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.label23 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.cmbFind2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonQueryOther = new DevExpress.XtraEditors.SimpleButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.radioGroup3 = new DevExpress.XtraEditors.RadioGroup();
            this.label22 = new System.Windows.Forms.Label();
            this.groupControlMountain = new DevExpress.XtraEditors.GroupControl();
            this.listMountain = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textEditMountain = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonQueryMountain = new DevExpress.XtraEditors.SimpleButton();
            this.labelQuery = new System.Windows.Forms.Label();
            this.panQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPlace)).BeginInit();
            this.groupControlPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOther)).BeginInit();
            this.groupControlOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind2)).BeginInit();
            this.panel15.SuspendLayout();
            this.panel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFind2.Properties)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMountain)).BeginInit();
            this.groupControlMountain.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMountain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panQuery
            // 
            this.panQuery.BackColor = System.Drawing.Color.Transparent;
            this.panQuery.Controls.Add(this.groupControlPlace);
            this.panQuery.Controls.Add(this.panel26);
            this.panQuery.Controls.Add(this.groupControlOther);
            this.panQuery.Controls.Add(this.groupControlMountain);
            this.panQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panQuery.Location = new System.Drawing.Point(0, 30);
            this.panQuery.Name = "panQuery";
            this.panQuery.Padding = new System.Windows.Forms.Padding(6);
            this.panQuery.Size = new System.Drawing.Size(258, 638);
            this.panQuery.TabIndex = 13;
            // 
            // groupControlPlace
            // 
            this.groupControlPlace.Controls.Add(this.icmbFind);
            this.groupControlPlace.Controls.Add(this.panel3);
            this.groupControlPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlPlace.Location = new System.Drawing.Point(6, 6);
            this.groupControlPlace.Name = "groupControlPlace";
            this.groupControlPlace.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.groupControlPlace.Size = new System.Drawing.Size(246, 209);
            this.groupControlPlace.TabIndex = 70;
            this.groupControlPlace.Text = "地名查询";
            // 
            // icmbFind
            // 
            this.icmbFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icmbFind.Location = new System.Drawing.Point(8, 117);
            this.icmbFind.Name = "icmbFind";
            this.icmbFind.Size = new System.Drawing.Size(230, 84);
            this.icmbFind.TabIndex = 10;
            this.icmbFind.DoubleClick += new System.EventHandler(this.icmbFind_DoubleClick);
            this.icmbFind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.icmbFind_MouseUp);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel20);
            this.panel3.Controls.Add(this.panel19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(8, 22);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 9);
            this.panel3.Size = new System.Drawing.Size(230, 95);
            this.panel3.TabIndex = 9;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.radioGroup1);
            this.panel20.Controls.Add(this.label4);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 41);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(230, 46);
            this.panel20.TabIndex = 19;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(54, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "当前地图范围"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全图范围")});
            this.radioGroup1.Size = new System.Drawing.Size(176, 46);
            this.radioGroup1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "\r\n搜索范围";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.cmbFind);
            this.panel19.Controls.Add(this.label5);
            this.panel19.Controls.Add(this.panel5);
            this.panel19.Controls.Add(this.ButtonQueryPlace);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 5);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel19.Size = new System.Drawing.Size(230, 36);
            this.panel19.TabIndex = 18;
            // 
            // cmbFind
            // 
            this.cmbFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFind.Location = new System.Drawing.Point(38, 6);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFind.Size = new System.Drawing.Size(150, 20);
            this.cmbFind.TabIndex = 16;
            this.cmbFind.Visible = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(188, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 24);
            this.panel5.TabIndex = 15;
            // 
            // ButtonQueryPlace
            // 
            this.ButtonQueryPlace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonQueryPlace.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonQueryPlace.Location = new System.Drawing.Point(196, 6);
            this.ButtonQueryPlace.Name = "ButtonQueryPlace";
            this.ButtonQueryPlace.Size = new System.Drawing.Size(34, 24);
            this.ButtonQueryPlace.TabIndex = 6;
            this.ButtonQueryPlace.Text = "查询";
            this.ButtonQueryPlace.ToolTip = "查询";
            this.ButtonQueryPlace.Click += new System.EventHandler(this.ButtonQueryPlace_Click);
            // 
            // panel26
            // 
            this.panel26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel26.Location = new System.Drawing.Point(6, 215);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(246, 16);
            this.panel26.TabIndex = 73;
            // 
            // groupControlOther
            // 
            this.groupControlOther.Controls.Add(this.icmbFind2);
            this.groupControlOther.Controls.Add(this.panel15);
            this.groupControlOther.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlOther.Location = new System.Drawing.Point(6, 231);
            this.groupControlOther.Name = "groupControlOther";
            this.groupControlOther.Padding = new System.Windows.Forms.Padding(6);
            this.groupControlOther.Size = new System.Drawing.Size(246, 245);
            this.groupControlOther.TabIndex = 74;
            this.groupControlOther.Text = "其它查询";
            this.groupControlOther.Visible = false;
            // 
            // icmbFind2
            // 
            this.icmbFind2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icmbFind2.Location = new System.Drawing.Point(8, 138);
            this.icmbFind2.Name = "icmbFind2";
            this.icmbFind2.Size = new System.Drawing.Size(230, 99);
            this.icmbFind2.TabIndex = 12;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel24);
            this.panel15.Controls.Add(this.panel21);
            this.panel15.Controls.Add(this.panel16);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(8, 28);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel15.Size = new System.Drawing.Size(230, 110);
            this.panel15.TabIndex = 11;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.radioGroup2);
            this.panel24.Controls.Add(this.label23);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 74);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(230, 30);
            this.panel24.TabIndex = 20;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup2.Location = new System.Drawing.Point(75, 0);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "当前地图范围"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全图范围")});
            this.radioGroup2.Size = new System.Drawing.Size(155, 30);
            this.radioGroup2.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 30);
            this.label23.TabIndex = 7;
            this.label23.Text = "搜索范围";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.cmbFind2);
            this.panel21.Controls.Add(this.panel22);
            this.panel21.Controls.Add(this.label3);
            this.panel21.Controls.Add(this.ButtonQueryOther);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 40);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.panel21.Size = new System.Drawing.Size(230, 34);
            this.panel21.TabIndex = 16;
            // 
            // cmbFind2
            // 
            this.cmbFind2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFind2.Location = new System.Drawing.Point(75, 4);
            this.cmbFind2.Name = "cmbFind2";
            this.cmbFind2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFind2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFind2.Size = new System.Drawing.Size(118, 20);
            this.cmbFind2.TabIndex = 18;
            this.cmbFind2.Visible = false;
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel22.Location = new System.Drawing.Point(193, 4);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(8, 24);
            this.panel22.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonQueryOther
            // 
            this.ButtonQueryOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonQueryOther.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonQueryOther.Location = new System.Drawing.Point(201, 4);
            this.ButtonQueryOther.Name = "ButtonQueryOther";
            this.ButtonQueryOther.Size = new System.Drawing.Size(29, 24);
            this.ButtonQueryOther.TabIndex = 13;
            this.ButtonQueryOther.ToolTip = "查询";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.radioGroup3);
            this.panel16.Controls.Add(this.label22);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 8);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel16.Size = new System.Drawing.Size(230, 32);
            this.panel16.TabIndex = 14;
            // 
            // radioGroup3
            // 
            this.radioGroup3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup3.Location = new System.Drawing.Point(75, 0);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "道路"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "水系")});
            this.radioGroup3.Size = new System.Drawing.Size(155, 24);
            this.radioGroup3.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 24);
            this.label22.TabIndex = 17;
            this.label22.Text = "类型";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlMountain
            // 
            this.groupControlMountain.Controls.Add(this.listMountain);
            this.groupControlMountain.Controls.Add(this.panel4);
            this.groupControlMountain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlMountain.Location = new System.Drawing.Point(6, 476);
            this.groupControlMountain.Name = "groupControlMountain";
            this.groupControlMountain.Padding = new System.Windows.Forms.Padding(6);
            this.groupControlMountain.Size = new System.Drawing.Size(246, 156);
            this.groupControlMountain.TabIndex = 71;
            this.groupControlMountain.Text = "山峰查询";
            this.groupControlMountain.Visible = false;
            // 
            // listMountain
            // 
            this.listMountain.BackColor = System.Drawing.Color.White;
            this.listMountain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMountain.FullRowSelect = true;
            this.listMountain.Location = new System.Drawing.Point(8, 68);
            this.listMountain.Name = "listMountain";
            this.listMountain.Size = new System.Drawing.Size(230, 80);
            this.listMountain.TabIndex = 13;
            this.listMountain.UseCompatibleStateImageBehavior = false;
            this.listMountain.View = System.Windows.Forms.View.Details;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textEditMountain);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.ButtonQueryMountain);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(8, 28);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.panel4.Size = new System.Drawing.Size(230, 40);
            this.panel4.TabIndex = 11;
            // 
            // textEditMountain
            // 
            this.textEditMountain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditMountain.Location = new System.Drawing.Point(75, 12);
            this.textEditMountain.Name = "textEditMountain";
            this.textEditMountain.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEditMountain.Properties.Appearance.Options.UseForeColor = true;
            this.textEditMountain.Size = new System.Drawing.Size(121, 20);
            this.textEditMountain.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(75, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 6);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(196, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 26);
            this.panel2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "山峰名";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonQueryMountain
            // 
            this.ButtonQueryMountain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonQueryMountain.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonQueryMountain.Location = new System.Drawing.Point(204, 6);
            this.ButtonQueryMountain.Name = "ButtonQueryMountain";
            this.ButtonQueryMountain.Size = new System.Drawing.Size(26, 26);
            this.ButtonQueryMountain.TabIndex = 10;
            this.ButtonQueryMountain.Text = "查询";
            this.ButtonQueryMountain.ToolTip = "查询";
            // 
            // labelQuery
            // 
            this.labelQuery.BackColor = System.Drawing.Color.Transparent;
            this.labelQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelQuery.Location = new System.Drawing.Point(0, 0);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelQuery.Size = new System.Drawing.Size(258, 30);
            this.labelQuery.TabIndex = 12;
            this.labelQuery.Text = "      专题查询";
            this.labelQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlPlace
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panQuery);
            this.Controls.Add(this.labelQuery);
            this.Name = "UserControlPlace";
            this.Size = new System.Drawing.Size(258, 668);
            this.panQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPlace)).EndInit();
            this.groupControlPlace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOther)).EndInit();
            this.groupControlOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind2)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFind2.Properties)).EndInit();
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMountain)).EndInit();
            this.groupControlMountain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditMountain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialValues()
        {
            try
            {
                this.panel20.Visible = true;
                this.cmbFind.Visible = true;
                this.cmbFind.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            catch (Exception)
            {
            }
        }

        private void lblPlace_Click(object sender, EventArgs e)
        {
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
                        this.InitialValues();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "地名道路水系查询", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}

