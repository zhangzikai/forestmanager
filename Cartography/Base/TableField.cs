namespace Cartography.Base
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class TableField : FormBase3
    {
        private IFeatureLayer _featureLayer;
        private IMap _map;
        private CheckedListBoxControl clFields;
        private ComboBoxEdit comboBoxEdit_Tables;
        private IContainer components;
        private List<string> fieldsAliaName = new List<string>();
        private List<string> fieldsName = new List<string>();
        private GroupControl gcLayerFields;
        private GroupControl groupControl1;
        private Dictionary<string, IFeatureLayer> layers = new Dictionary<string, IFeatureLayer>();
        private SimpleButton sbCancel;
        private SimpleButton sbOK;
        private List<string> selectedFieldAilaNames = new List<string>();

        public TableField(IFeatureLayer pFeatureLayer, IMap pMap)
        {
            this.InitializeComponent();
            this._featureLayer = pFeatureLayer;
            this._map = pMap;
        }

        private void comboBoxEdit_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._featureLayer = this.layers[this.comboBoxEdit_Tables.Text];
            this.Init(this._featureLayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string[] GetFieldName()
        {
            this.LoadTable();
            this.Init(this._featureLayer);
            if (base.ShowDialog() == DialogResult.OK)
            {
                return this.selectedFieldAilaNames.ToArray();
            }
            return null;
        }

        private void Init(IFeatureLayer pLayer)
        {
            this.fieldsName.Clear();
            this.fieldsAliaName.Clear();
            this.clFields.Items.Clear();
            IDisplayTable table = pLayer as IDisplayTable;
            IFields fields = table.DisplayTable.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if ((field.Name != pLayer.FeatureClass.OIDFieldName) && !field.Name.Contains(pLayer.FeatureClass.ShapeFieldName))
                {
                    this.fieldsName.Add(field.Name);
                    this.fieldsAliaName.Add(field.AliasName);
                    this.clFields.Items.Add(field.AliasName);
                }
            }
        }

        private void InitializeComponent()
        {
            this.gcLayerFields = new DevExpress.XtraEditors.GroupControl();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.clFields = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_Tables = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLayerFields)).BeginInit();
            this.gcLayerFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Tables.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcLayerFields
            // 
            this.gcLayerFields.Controls.Add(this.sbCancel);
            this.gcLayerFields.Controls.Add(this.sbOK);
            this.gcLayerFields.Controls.Add(this.clFields);
            this.gcLayerFields.Location = new System.Drawing.Point(4, 54);
            this.gcLayerFields.Name = "gcLayerFields";
            this.gcLayerFields.Size = new System.Drawing.Size(332, 401);
            this.gcLayerFields.TabIndex = 0;
            this.gcLayerFields.Text = "选择字段";
            // 
            // sbCancel
            // 
            this.sbCancel.Location = new System.Drawing.Point(174, 335);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "取消";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbOK
            // 
            this.sbOK.Location = new System.Drawing.Point(83, 335);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 1;
            this.sbOK.Text = "确定";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // clFields
            // 
            this.clFields.CheckOnClick = true;
            this.clFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.clFields.Location = new System.Drawing.Point(2, 22);
            this.clFields.Name = "clFields";
            this.clFields.Size = new System.Drawing.Size(328, 307);
            this.clFields.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.comboBoxEdit_Tables);
            this.groupControl1.Location = new System.Drawing.Point(4, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(330, 49);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "选择表格";
            // 
            // comboBoxEdit_Tables
            // 
            this.comboBoxEdit_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEdit_Tables.Location = new System.Drawing.Point(2, 22);
            this.comboBoxEdit_Tables.Name = "comboBoxEdit_Tables";
            this.comboBoxEdit_Tables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Tables.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Tables.Size = new System.Drawing.Size(326, 20);
            this.comboBoxEdit_Tables.TabIndex = 0;
            this.comboBoxEdit_Tables.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Tables_SelectedIndexChanged);
            // 
            // TableField
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(344, 417);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcLayerFields);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义字段";
            ((System.ComponentModel.ISupportInitialize)(this.gcLayerFields)).EndInit();
            this.gcLayerFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Tables.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void LoadComTable(ILayer pLayer)
        {
            ICompositeLayer layer = pLayer as ICompositeLayer;
            for (int i = 0; i < layer.Count; i++)
            {
                ILayer layer2 = layer.get_Layer(i);
                if (layer2 is IFeatureLayer)
                {
                    if (!this.layers.ContainsKey(layer2.Name))
                    {
                        this.layers.Add(layer2.Name, layer2 as IFeatureLayer);
                        this.comboBoxEdit_Tables.Properties.Items.Add(layer2.Name);
                    }
                }
                else if (layer2 is ICompositeLayer)
                {
                    this.LoadComTable(pLayer);
                }
            }
        }

        private void LoadTable()
        {
            for (int i = 0; i < this._map.LayerCount; i++)
            {
                ILayer pLayer = this._map.get_Layer(i);
                if (pLayer is IFeatureLayer)
                {
                    if (!this.layers.ContainsKey(pLayer.Name))
                    {
                        this.layers.Add(pLayer.Name, pLayer as IFeatureLayer);
                        this.comboBoxEdit_Tables.Properties.Items.Add(pLayer.Name);
                    }
                }
                else if (pLayer is ICompositeLayer)
                {
                    this.LoadComTable(pLayer);
                }
            }
            this.comboBoxEdit_Tables.Text = this._featureLayer.Name;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this._featureLayer.Name);
            builder.Append(",");
            foreach (int num in (IEnumerable) this.clFields.CheckedIndices)
            {
                string item = this.fieldsName[num];
                this.selectedFieldAilaNames.Add(item);
                builder.Append(item);
                builder.Append(",");
            }
            builder.Remove(builder.Length - 1, 1);
            if (this.selectedFieldAilaNames.Count == 0)
            {
                XtraMessageBox.Show("请选择字段！");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        public IFeatureLayer SelectedFeatureLayer
        {
            get
            {
                return this._featureLayer;
            }
        }
    }
}

