namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class UserControlMapFind : UserControlBase1
    {
        private SimpleButton ButtonFind;
        private CheckEdit checkQuery;
        private ComboBoxEdit comboBoxField;
        private ComboBoxEdit comboBoxFindValue;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private ImageList imageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelInfo;
        private Label labelLocation;
        private Label labelPosition;
        private const string mClassName = "QueryAnalysic.UserControlMapFind";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureList;
        private ArrayList mGroupList;
        private HookHelper mHookHelper;
        private IFeatureLayer mLayer;
        private ArrayList mLayerList;
        private IMap mMap;
        private ArrayList mNameList;
        private DataTable mQTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ArrayList mVisLayerList;
        private Panel panel1;
        private Panel panel2;
        private Panel panel23;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private PopupContainerEdit popEditLayer;
        private PopupContainerControl popupContainerControl1;
        private RadioGroup radioGroupField;
        private SimpleButton simpleButtonMore;
        private SimpleButton simpleButtonReset;
        private TreeListColumn treeListColumn1;
        private TreeList treeListLayer;

        public UserControlMapFind()
        {
            this.InitializeComponent();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelInfo.Text = "    ";
                IFeatureLayer tag = this.popEditLayer.Tag as IFeatureLayer;
                if (tag == null)
                {
                    MessageBox.Show("请选择要查找的图层", "地图查找", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                IFeatureClass featureClass = tag.FeatureClass;
                IQueryFilter filter = new QueryFilterClass();
                this.mQTable.Rows.Clear();
                IDataset dataset = featureClass as IDataset;
                ISQLSyntax workspace = dataset.Workspace as ISQLSyntax;
                esriSQLSpecialCharacters sqlSC = esriSQLSpecialCharacters.esriSQL_WildcardManyMatch;
                string specialCharacter = workspace.GetSpecialCharacter(sqlSC);
                string str2 = " = ";
                string str3 = "";
                string str4 = "";
                ICodedValueDomain domain = null;
                if (this.checkQuery.Checked)
                {
                    str2 = " like ";
                }
                if (this.comboBoxField.Enabled)
                {
                    IField field = tag.FeatureClass.Fields.get_Field(this.comboBoxField.SelectedIndex);
                    if (this.comboBoxFindValue.Tag is ICodedValueDomain)
                    {
                        if (this.comboBoxFindValue.SelectedIndex != -1)
                        {
                            domain = this.comboBoxFindValue.Tag as ICodedValueDomain;
                            str3 = domain.get_Value(this.comboBoxFindValue.SelectedIndex).ToString();
                            str3 = field.Name + "='" + str3 + "'";
                        }
                        else
                        {
                            domain = this.comboBoxFindValue.Tag as ICodedValueDomain;
                            string str5 = "";
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (domain.get_Name(i).Substring(0, this.comboBoxFindValue.Text.Trim().Length) == this.comboBoxFindValue.Text.Trim())
                                {
                                    str5 = domain.get_Value(i).ToString();
                                    if (str3 == "")
                                    {
                                        str3 = field.Name + str2 + "'" + str5 + "'";
                                    }
                                    else
                                    {
                                        str3 = str3 + " or " + field.Name + str2 + "'" + str5 + "'";
                                    }
                                }
                            }
                        }
                    }
                    else if (field.Type == esriFieldType.esriFieldTypeString)
                    {
                        if (this.checkQuery.Checked)
                        {
                            str3 = field.Name + str2 + "'" + specialCharacter + this.comboBoxFindValue.Text.Trim() + specialCharacter + "'";
                        }
                        else
                        {
                            str3 = field.Name + str2 + "'" + this.comboBoxFindValue.Text.Trim() + "'";
                        }
                    }
                    else if (this.checkQuery.Checked)
                    {
                        str3 = field.Name + str2 + specialCharacter + this.comboBoxFindValue.Text.Trim() + specialCharacter;
                    }
                    else
                    {
                        str3 = field.Name + str2 + this.comboBoxFindValue.Text.Trim();
                    }
                }
                else
                {
                    for (int j = 0; j < featureClass.Fields.FieldCount; j++)
                    {
                        IField field2 = featureClass.Fields.get_Field(j);
                        if (field2.Type == esriFieldType.esriFieldTypeString)
                        {
                            if (this.checkQuery.Checked)
                            {
                                str3 = field2.Name + str2 + "'" + specialCharacter + this.comboBoxFindValue.Text.Trim() + specialCharacter + "'";
                            }
                            else
                            {
                                str3 = field2.Name + str2 + "'" + this.comboBoxFindValue.Text.Trim() + "'";
                            }
                        }
                        else if (field2.Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            str3 = "";
                        }
                        else if (field2.Type == esriFieldType.esriFieldTypeInteger)
                        {
                            try
                            {
                                int.Parse(this.comboBoxFindValue.Text.Trim());
                                str3 = field2.Name + " = " + this.comboBoxFindValue.Text.Trim();
                            }
                            catch (Exception)
                            {
                                str3 = "";
                            }
                        }
                        else if (field2.Type == esriFieldType.esriFieldTypeDouble)
                        {
                            try
                            {
                                double.Parse(this.comboBoxFindValue.Text.Trim());
                                str3 = field2.Name + " = " + this.comboBoxFindValue.Text.Trim();
                            }
                            catch (Exception)
                            {
                                str3 = "";
                            }
                        }
                        if (str4 == "")
                        {
                            str4 = str3;
                        }
                        else if (str3 != "")
                        {
                            str4 = str4 + " or " + str3;
                        }
                    }
                    str3 = str4;
                }
                filter.WhereClause = str3;
                IFeatureCursor cursor = featureClass.Search(filter, false);
                if (cursor == null)
                {
                    return;
                }
                IFeature feature = cursor.NextFeature();
                int index = -1;
                if (this.radioGroupField.SelectedIndex == 1)
                {
                    (this.comboBoxField.Tag as IFields).get_Field(this.comboBoxField.SelectedIndex);
                    int selectedIndex = this.comboBoxField.SelectedIndex;
                    while (feature != null)
                    {
                        if (domain != null)
                        {
                            if (this.comboBoxFindValue.SelectedIndex > -1)
                            {
                                if (feature.get_Value(selectedIndex).ToString().Contains(domain.get_Value(this.comboBoxFindValue.SelectedIndex).ToString()))
                                {
                                    index = selectedIndex;
                                }
                            }
                            else
                            {
                                index = selectedIndex;
                            }
                        }
                        else if (feature.get_Value(selectedIndex).ToString().Contains(this.comboBoxFindValue.Text))
                        {
                            index = selectedIndex;
                        }
                        if ((index != -1) && (index < featureClass.Fields.FieldCount))
                        {
                            DataRow row = this.mQTable.NewRow();
                            row[0] = feature.get_Value(index);
                            row[1] = tag.Name;
                            row[2] = featureClass.Fields.get_Field(index).Name;
                            row[3] = feature;
                            this.mQTable.Rows.Add(row);
                            if (this.mQTable.Rows.Count == 0x7d0)
                            {
                                this.labelInfo.Text = "     找到多余2000个地图对象,请缩小查询范围";
                                goto Label_0856;
                            }
                        }
                        feature = cursor.NextFeature();
                    }
                }
                else if (this.radioGroupField.SelectedIndex == 0)
                {
                    while (feature != null)
                    {
                        for (int k = 0; k < featureClass.Fields.FieldCount; k++)
                        {
                            featureClass.Fields.get_Field(k);
                            if (domain != null)
                            {
                                if (!feature.get_Value(k).ToString().Contains(domain.get_Value(this.comboBoxFindValue.SelectedIndex).ToString()))
                                {
                                    continue;
                                }
                                index = k;
                                break;
                            }
                            if (feature.get_Value(k).ToString().Contains(this.comboBoxFindValue.Text))
                            {
                                index = k;
                                break;
                            }
                        }
                        if ((index != -1) && (index < featureClass.Fields.FieldCount))
                        {
                            DataRow row2 = this.mQTable.NewRow();
                            row2[0] = feature.get_Value(index);
                            row2[1] = tag.Name;
                            row2[2] = featureClass.Fields.get_Field(index).Name;
                            row2[3] = feature;
                            this.mQTable.Rows.Add(row2);
                        }
                        feature = cursor.NextFeature();
                    }
                }
                this.labelInfo.Text = "     找到" + this.mQTable.Rows.Count + "个地图对象";
            Label_0856:
                this.gridView1.RefreshData();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "ButtonFind_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBoxField.SelectedIndex != -1)
                {
                    this.comboBoxFindValue.Properties.Items.Clear();
                    this.comboBoxFindValue.Tag = null;
                    this.comboBoxFindValue.Text = "";
                    IField field = (this.comboBoxField.Tag as IFields).get_Field(this.comboBoxField.SelectedIndex);
                    if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                        this.comboBoxFindValue.Tag = domain;
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            this.comboBoxFindValue.Properties.Items.Add(domain.get_Name(i));
                        }
                    }
                }
            }
            catch (Exception)
            {
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

        public bool GetLayerColn()
        {
            try
            {
                if (this.mHookHelper == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap.LayerCount == 0)
                {
                    return false;
                }
                IEnumLayer layer = null;
                try
                {
                    layer = this.mHookHelper.FocusMap.get_Layers(null, false);
                }
                catch (Exception)
                {
                    return false;
                }
                layer.Reset();
                ICompositeLayer layer2 = null;
                IGroupLayer layer3 = null;
                ILayer layer4 = null;
                layer4 = layer.Next();
                if (layer4 == null)
                {
                    return false;
                }
                this.mVisLayerList = new ArrayList();
                this.mLayerList = new ArrayList();
                this.mGroupList = new ArrayList();
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                this.treeListLayer.ClearNodes();
                while (layer4 != null)
                {
                    if (layer4 is IGroupLayer)
                    {
                        layer3 = layer4 as IGroupLayer;
                        layer2 = layer3 as ICompositeLayer;
                        this.mGroupList.Add(layer3);
                        node3 = this.treeListLayer.AppendNode(layer4.Name, node4);
                        node3.SetValue(0, layer4.Name);
                        node3.Tag = layer3;
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = 0;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                        for (int i = 0; i < layer2.Count; i++)
                        {
                            ILayer layer5 = layer2.get_Layer(i);
                            if (layer5 is IGroupLayer)
                            {
                                ICompositeLayer layer6 = null;
                                IGroupLayer layer7 = null;
                                layer7 = layer5 as IGroupLayer;
                                layer6 = layer7 as ICompositeLayer;
                                parentNode = this.treeListLayer.AppendNode(layer7.Name, node3);
                                parentNode.SetValue(0, layer7.Name);
                                parentNode.Tag = layer7;
                                parentNode.ImageIndex = -1;
                                node3.StateImageIndex = 0;
                                node3.SelectImageIndex = -1;
                                parentNode.ExpandAll();
                                for (int j = 0; j < layer6.Count; j++)
                                {
                                    ILayer layer8 = layer6.get_Layer(j);
                                    if ((!(layer8 is IGroupLayer) && (layer8 is IFeatureLayer)) && ((layer8 as IFeatureLayer).FeatureClass != null))
                                    {
                                        node = this.treeListLayer.AppendNode(layer8.Name, parentNode);
                                        node.SetValue(0, layer8.Name);
                                        node.Tag = layer8 as IFeatureLayer;
                                        int num3 = 0;
                                        if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                        {
                                            num3 = 1;
                                        }
                                        else if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                        {
                                            num3 = 2;
                                        }
                                        else if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                        {
                                            num3 = 3;
                                        }
                                        node.ImageIndex = -1;
                                        node.StateImageIndex = num3;
                                        node.SelectImageIndex = -1;
                                        node.ExpandAll();
                                        this.mLayerList.Add(layer4);
                                        if (layer4.Valid && layer4.Visible)
                                        {
                                            this.mVisLayerList.Add(layer4);
                                        }
                                    }
                                }
                                if (parentNode.Nodes.Count == 0)
                                {
                                    this.treeListLayer.DeleteNode(parentNode);
                                }
                            }
                            else if ((layer5 is IFeatureLayer) && ((layer5 as IFeatureLayer).FeatureClass != null))
                            {
                                parentNode = this.treeListLayer.AppendNode(layer5.Name, node3);
                                parentNode.SetValue(0, layer5.Name);
                                parentNode.Tag = layer5 as IFeatureLayer;
                                int num4 = 0;
                                if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                {
                                    num4 = 1;
                                }
                                else if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                {
                                    num4 = 2;
                                }
                                else if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                {
                                    num4 = 3;
                                }
                                parentNode.ImageIndex = -1;
                                parentNode.StateImageIndex = num4;
                                parentNode.SelectImageIndex = -1;
                                parentNode.ExpandAll();
                                this.mLayerList.Add(layer4);
                                if (layer4.Valid && layer4.Visible)
                                {
                                    this.mVisLayerList.Add(layer4);
                                }
                            }
                        }
                        if (node3.Nodes.Count == 0)
                        {
                            this.treeListLayer.DeleteNode(node3);
                        }
                    }
                    else if ((layer4 is IFeatureLayer) && ((layer4 as IFeatureLayer).FeatureClass != null))
                    {
                        node3 = this.treeListLayer.AppendNode(layer4.Name, node4);
                        node3.SetValue(0, layer4.Name);
                        node3.Tag = layer4;
                        int num5 = 0;
                        if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                        {
                            num5 = 1;
                        }
                        else if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                        {
                            num5 = 2;
                        }
                        else if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                        {
                            num5 = 3;
                        }
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = num5;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                        this.mLayerList.Add(layer4);
                        if (layer4.Valid && layer4.Visible)
                        {
                            this.mVisLayerList.Add(layer4);
                        }
                    }
                    layer4 = layer.Next();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "GetLayerColn", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle != -1)
                {
                    IFeature pFeature = this.mQTable.Rows[this.gridView1.FocusedRowHandle]["object"] as IFeature;
                    IFeatureLayer tag = this.popEditLayer.Tag as IFeatureLayer;
                    this.SelectFeature(tag, pFeature);
                    this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitialField(IFeatureLayer pfl)
        {
            try
            {
                this.comboBoxField.Properties.Items.Clear();
                this.comboBoxField.Text = "";
                for (int i = 0; i < pfl.FeatureClass.Fields.FieldCount; i++)
                {
                    IField field = pfl.FeatureClass.Fields.get_Field(i);
                    if (field.Name != field.AliasName)
                    {
                        this.comboBoxField.Properties.Items.Add(field.Name + "[" + field.AliasName + "]");
                    }
                    else
                    {
                        this.comboBoxField.Properties.Items.Add(field.Name);
                    }
                }
                this.comboBoxField.Tag = pfl.FeatureClass.Fields;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "InitialField", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMapFind));
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.popEditLayer = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListLayer = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxFindValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioGroupField = new DevExpress.XtraEditors.RadioGroup();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.panel23 = new System.Windows.Forms.Panel();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.checkQuery = new DevExpress.XtraEditors.CheckEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popEditLayer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayer)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxFindValue.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxField.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupField.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkQuery.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPosition
            // 
            this.labelPosition.BackColor = System.Drawing.Color.Transparent;
            this.labelPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPosition.ForeColor = System.Drawing.Color.Navy;
            this.labelPosition.Image = ((System.Drawing.Image)(resources.GetObject("labelPosition.Image")));
            this.labelPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPosition.Location = new System.Drawing.Point(4, 255);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.labelPosition.Size = new System.Drawing.Size(240, 30);
            this.labelPosition.TabIndex = 21;
            this.labelPosition.Text = "    查找结果";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(4, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(240, 30);
            this.labelLocation.TabIndex = 20;
            this.labelLocation.Text = "      地图查找          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "所在图层";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.popEditLayer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 64);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.panel1.Size = new System.Drawing.Size(240, 34);
            this.panel1.TabIndex = 24;
            // 
            // popEditLayer
            // 
            this.popEditLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.popEditLayer.Location = new System.Drawing.Point(77, 4);
            this.popEditLayer.Name = "popEditLayer";
            this.popEditLayer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popEditLayer.Properties.PopupControl = this.popupContainerControl1;
            this.popEditLayer.Size = new System.Drawing.Size(163, 20);
            this.popEditLayer.TabIndex = 25;
            this.popEditLayer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.popEditLayer_ButtonClick);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListLayer);
            this.popupContainerControl1.Location = new System.Drawing.Point(20, 100);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 200);
            this.popupContainerControl1.TabIndex = 32;
            // 
            // treeListLayer
            // 
            this.treeListLayer.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.treeListLayer.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeListLayer.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListLayer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeListLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLayer.Location = new System.Drawing.Point(0, 0);
            this.treeListLayer.Name = "treeListLayer";
            this.treeListLayer.BeginUnboundLoad();
            this.treeListLayer.AppendNode(new object[] {
            "图层组"}, -1, 0, 0, 0);
            this.treeListLayer.AppendNode(new object[] {
            "图层"}, 0, 0, 0, 1);
            this.treeListLayer.AppendNode(new object[] {
            "图层组"}, -1, 0, 0, 0);
            this.treeListLayer.AppendNode(new object[] {
            "图层"}, 2, 0, 0, 2);
            this.treeListLayer.EndUnboundLoad();
            this.treeListLayer.OptionsBehavior.Editable = false;
            this.treeListLayer.OptionsView.ShowColumns = false;
            this.treeListLayer.OptionsView.ShowHorzLines = false;
            this.treeListLayer.OptionsView.ShowIndicator = false;
            this.treeListLayer.OptionsView.ShowVertLines = false;
            this.treeListLayer.Size = new System.Drawing.Size(200, 200);
            this.treeListLayer.StateImageList = this.imageList1;
            this.treeListLayer.TabIndex = 0;
            this.treeListLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListLayer_MouseClick);
            this.treeListLayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListLayer_MouseDoubleClick);
            this.treeListLayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListLayer_MouseUp);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 69;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "layer2.png");
            this.imageList1.Images.SetKeyName(1, "point.png");
            this.imageList1.Images.SetKeyName(2, "polyine.png");
            this.imageList1.Images.SetKeyName(3, "polygon.png");
            this.imageList1.Images.SetKeyName(4, "layers_0.bmp");
            this.imageList1.Images.SetKeyName(5, "application_Arc.png");
            this.imageList1.Images.SetKeyName(6, "layer7.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxFindValue);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel3.Size = new System.Drawing.Size(240, 34);
            this.panel3.TabIndex = 26;
            // 
            // comboBoxFindValue
            // 
            this.comboBoxFindValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxFindValue.Location = new System.Drawing.Point(78, 4);
            this.comboBoxFindValue.Name = "comboBoxFindValue";
            this.comboBoxFindValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxFindValue.Size = new System.Drawing.Size(162, 20);
            this.comboBoxFindValue.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(9, 6, 0, 6);
            this.label3.Size = new System.Drawing.Size(78, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "查找";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 117);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel4.Size = new System.Drawing.Size(240, 98);
            this.panel4.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxField);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(14, 2, 0, 4);
            this.panel2.Size = new System.Drawing.Size(240, 31);
            this.panel2.TabIndex = 30;
            // 
            // comboBoxField
            // 
            this.comboBoxField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxField.Enabled = false;
            this.comboBoxField.Location = new System.Drawing.Point(77, 7);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxField.Size = new System.Drawing.Size(163, 20);
            this.comboBoxField.TabIndex = 23;
            this.comboBoxField.SelectedIndexChanged += new System.EventHandler(this.comboBoxField_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(14, 2);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 2);
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "字段名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioGroupField);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 34);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.panel6.Size = new System.Drawing.Size(240, 28);
            this.panel6.TabIndex = 29;
            // 
            // radioGroupField
            // 
            this.radioGroupField.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioGroupField.Location = new System.Drawing.Point(14, 0);
            this.radioGroupField.Name = "radioGroupField";
            this.radioGroupField.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupField.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupField.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupField.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "所有字段"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定字段")});
            this.radioGroupField.Size = new System.Drawing.Size(213, 28);
            this.radioGroupField.TabIndex = 28;
            this.radioGroupField.SelectedIndexChanged += new System.EventHandler(this.radioGroupField_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label4.Size = new System.Drawing.Size(240, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "搜索范围";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.simpleButtonReset);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.simpleButtonMore);
            this.panel5.Controls.Add(this.panel23);
            this.panel5.Controls.Add(this.ButtonFind);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 215);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.panel5.Size = new System.Drawing.Size(240, 40);
            this.panel5.TabIndex = 29;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonReset.Image")));
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonReset.Location = new System.Drawing.Point(26, 6);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonReset.TabIndex = 14;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.ToolTip = "重新设置查询条件";
            this.simpleButtonReset.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(92, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(8, 26);
            this.panel7.TabIndex = 17;
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMore.Image")));
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(100, 6);
            this.simpleButtonMore.Name = "simpleButtonMore";
            this.simpleButtonMore.Size = new System.Drawing.Size(66, 26);
            this.simpleButtonMore.TabIndex = 13;
            this.simpleButtonMore.Tag = "基本";
            this.simpleButtonMore.Text = "更多";
            this.simpleButtonMore.ToolTip = "更多查询条件";
            this.simpleButtonMore.Visible = false;
            // 
            // panel23
            // 
            this.panel23.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel23.Location = new System.Drawing.Point(166, 6);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(8, 26);
            this.panel23.TabIndex = 16;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(174, 6);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(66, 26);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查找";
            this.ButtonFind.ToolTip = "查找要素";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(4, 285);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(240, 155);
            this.gridControl1.TabIndex = 30;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.ForeColor = System.Drawing.Color.Navy;
            this.labelInfo.Image = ((System.Drawing.Image)(resources.GetObject("labelInfo.Image")));
            this.labelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.Location = new System.Drawing.Point(4, 440);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.labelInfo.Size = new System.Drawing.Size(240, 30);
            this.labelInfo.TabIndex = 31;
            this.labelInfo.Text = "     ";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkQuery
            // 
            this.checkQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkQuery.Location = new System.Drawing.Point(4, 98);
            this.checkQuery.Name = "checkQuery";
            this.checkQuery.Properties.Caption = "模糊查询";
            this.checkQuery.Size = new System.Drawing.Size(240, 19);
            this.checkQuery.TabIndex = 33;
            // 
            // UserControlMapFind
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.checkQuery);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlMapFind";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Size = new System.Drawing.Size(248, 470);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popEditLayer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayer)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxFindValue.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxField.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupField.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkQuery.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialLayer()
        {
            try
            {
                this.GetLayerColn();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "InitialLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialTreeList(TreeList treelist)
        {
            try
            {
                treelist.ClearNodes();
                treelist.OptionsView.ShowRoot = true;
                treelist.SelectImageList = null;
                treelist.StateImageList = this.imageList1;
                treelist.OptionsView.ShowButtons = true;
                treelist.TreeLineStyle = LineStyle.None;
                treelist.RowHeight = 20;
                treelist.OptionsBehavior.AutoPopulateColumns = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue(object hook)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                if (hook != null)
                {
                    this.mHookHelper.Hook = hook;
                }
                this.InitialTreeList(this.treeListLayer);
                this.InitialLayer();
                this.mQTable = new DataTable();
                DataColumn column = new DataColumn("value", typeof(string));
                column.Caption = "值";
                this.mQTable.Columns.Add(column);
                column = new DataColumn("layer", typeof(string));
                column.Caption = "图层";
                this.mQTable.Columns.Add(column);
                column = new DataColumn("field", typeof(string));
                column.Caption = "字段";
                this.mQTable.Columns.Add(column);
                column = new DataColumn("object", typeof(object));
                this.mQTable.Columns.Add(column);
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mQTable;
                this.gridView1.RefreshData();
                this.gridView1.OptionsBehavior.Editable = false;
                this.gridControl1.Enabled = true;
                this.gridView1.Columns[3].Visible = false;
                this.popEditLayer.Text = "";
                this.comboBoxField.Text = "";
                this.comboBoxFindValue.Text = "";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void popEditLayer_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.treeListLayer.Dock = DockStyle.Fill;
        }

        private void radioGroupField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroupField.SelectedIndex == 0)
            {
                this.comboBoxField.Enabled = false;
            }
            else if (this.radioGroupField.SelectedIndex == 1)
            {
                this.comboBoxField.Enabled = true;
            }
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.mHookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        private void treeListLayer_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void treeListLayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.popEditLayer.Text != "")
            {
                this.popEditLayer.ClosePopup();
            }
        }

        private void treeListLayer_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.treeListLayer.Selection.Count != 0)
            {
                TreeListNode node = this.treeListLayer.Selection[0];
                if (node.Tag is IGroupLayer)
                {
                    this.popEditLayer.Text = "";
                    this.popEditLayer.Tag = null;
                }
                else if (node.Tag is IFeatureLayer)
                {
                    this.popEditLayer.Text = (node.Tag as ILayer).Name;
                    this.popEditLayer.Tag = node.Tag as IFeatureLayer;
                    this.InitialField(node.Tag as IFeatureLayer);
                    this.comboBoxField.Focus();
                }
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
                    if (shape.SpatialReference != pMap.SpatialReference)
                    {
                        shape.Project(pMap.SpatialReference);
                        shape.SpatialReference = pMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shape.Envelope;
                    view = pMap as IActiveView;
                    if (shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        pMap.MapScale = 6000.0;
                        num = view.Extent.Width / 2.0;
                        num2 = view.Extent.Height / 2.0;
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
                        envelope.Expand(1.25, 1.25, true);
                    }
                    if (((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height)) || (((view.Extent.XMin != envelope.XMin) || (view.Extent.YMin != envelope.YMin)) || ((view.Extent.XMax != envelope.XMax) || (view.Extent.YMax != envelope.YMax))))
                    {
                        view.Extent = envelope;
                        view.Refresh();
                    }
                    else
                    {
                        (this.mHookHelper.Hook as IMapControl2).FlashShape(pFeature.Shape, 3, 300, null);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlMapFind", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

