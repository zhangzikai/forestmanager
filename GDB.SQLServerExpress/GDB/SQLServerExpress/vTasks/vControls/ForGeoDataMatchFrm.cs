namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using DevExpress.XtraGrid.Views.Base;

    public class ForGeoDataMatchFrm : XtraForm
    {
        private Dictionary<string, esriFieldType> _srcFields;
        private Dictionary<string, esriFieldType> _targetFields;
        private SimpleButton bnt_cancel;
        private SimpleButton bnt_comfirm;
        private ComboBoxEdit combo_targets;
        private IContainer components;
        private GridControl grid_fieldmapping;
        private GridView gridView1;
        private LabelControl label_totable;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private RepositoryItemComboBox repositoryItemComboBox1;

        public ForGeoDataMatchFrm()
        {
            this.InitializeComponent();
        }

        private void combo_targets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.combo_targets.Text;
            if (!string.IsNullOrEmpty(text) && (this.WorkSpace != null))
            {
                IFeatureWorkspace workSpace = this.WorkSpace as IFeatureWorkspace;
                IFeatureClass pFeatureClass = ForestGDBWorkSpaceUtil.OpenFeatureClass(workSpace, text);
                if (pFeatureClass != null)
                {
                    this._srcFields = this.getFields(pFeatureClass);
                    Marshal.ReleaseComObject(pFeatureClass);
                    pFeatureClass = null;
                    this.initFieldMatchTable();
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

        private void ForGeoDataMatchFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
        }

        private Dictionary<string, esriFieldType> getFields(IFeatureClass pFeatureClass)
        {
            if (pFeatureClass == null)
            {
                return null;
            }
            IFields fields = pFeatureClass.Fields;
            if (fields == null)
            {
                return null;
            }
            int fieldCount = fields.FieldCount;
            if (fieldCount <= 0)
            {
                return null;
            }
            Dictionary<string, esriFieldType> dictionary = new Dictionary<string, esriFieldType>();
            for (int i = 0; i < fieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field != null)
                {
                    string name = field.Name;
                    if (!name.Contains(".") && !name.Contains("SHAPE"))
                    {
                        esriFieldType type = field.Type;
                        dictionary.Add(name, type);
                    }
                }
            }
            return dictionary;
        }

        private Dictionary<string, string> getMappedFields()
        {
            DataTable dataSource = this.grid_fieldmapping.DataSource as DataTable;
            DataRowCollection rows = dataSource.Rows;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if ((rows != null) || (rows.Count >= 1))
            {
                foreach (DataRow row in rows)
                {
                    string key = row[0] as string;
                    string str2 = row[1] as string;
                    dictionary.Add(key, str2);
                }
            }
            return dictionary;
        }

        private void initFieldMatchTable()
        {
            this.grid_fieldmapping.DataSource = new DataTable();
            this.grid_fieldmapping.RepositoryItems.Clear();
            if (this._srcFields == null)
            {
                this._srcFields = new Dictionary<string, esriFieldType>();
            }
            if (this._targetFields != null)
            {
                DataTable table = new DataTable();
                DataColumn column = table.Columns.Add("col_target", typeof(string));
                column.Caption = "目标字段名";
                column.ReadOnly = true;
                table.Columns.Add("col_src", typeof(string)).Caption = "源数据字段名";
                foreach (string str in this._targetFields.Keys)
                {
                    esriFieldType type2;
                    DataRow row = table.NewRow();
                    esriFieldType type = this._targetFields[str];
                    row[0] = str;
                    if ((this._srcFields != null) && this._srcFields.TryGetValue(str, out type2))
                    {
                        type2 = this._srcFields[str];
                        row[1] = (type == type2) ? str : string.Empty;
                    }
                    else
                    {
                        row[1] = string.Empty;
                    }
                    table.Rows.Add(row);
                }
                this.grid_fieldmapping.DataSource = table;
                RepositoryItemComboBox item = new RepositoryItemComboBox();
                if (this._srcFields != null)
                {
                    foreach (string str2 in this._srcFields.Keys)
                    {
                        item.Items.Add(str2);
                    }
                }
                this.grid_fieldmapping.RepositoryItems.Add(item);
                this.gridView1.Columns[1].ColumnEdit = item;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ForGeoDataMatchFrm));
            this.panelControl1 = new PanelControl();
            this.bnt_cancel = new SimpleButton();
            this.bnt_comfirm = new SimpleButton();
            this.panelControl2 = new PanelControl();
            this.panelControl4 = new PanelControl();
            this.grid_fieldmapping = new GridControl();
            this.gridView1 = new GridView();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.panelControl3 = new PanelControl();
            this.combo_targets = new ComboBoxEdit();
            this.label_totable = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.panelControl4.BeginInit();
            this.panelControl4.SuspendLayout();
            this.grid_fieldmapping.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemComboBox1.BeginInit();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            this.combo_targets.Properties.BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.bnt_cancel);
            this.panelControl1.Controls.Add(this.bnt_comfirm);
            this.panelControl1.Dock = DockStyle.Bottom;
            this.panelControl1.Location = new Point(0, 0x159);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x20b, 0x27);
            this.panelControl1.TabIndex = 0;
//            this.bnt_cancel.DialogResult = DialogResult.Cancel;
            this.bnt_cancel.Location = new Point(0x1a8, 6);
            this.bnt_cancel.Name = "bnt_cancel";
            this.bnt_cancel.Size = new Size(0x4b, 0x17);
            this.bnt_cancel.TabIndex = 1;
            this.bnt_cancel.Text = "取消";
//            this.bnt_comfirm.DialogResult = DialogResult.OK;
            this.bnt_comfirm.Location = new Point(310, 6);
            this.bnt_comfirm.Name = "bnt_comfirm";
            this.bnt_comfirm.Size = new Size(0x4b, 0x17);
            this.bnt_comfirm.TabIndex = 0;
            this.bnt_comfirm.Text = "设置";
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x20b, 0x159);
            this.panelControl2.TabIndex = 1;
            this.panelControl4.Controls.Add(this.grid_fieldmapping);
            this.panelControl4.Dock = DockStyle.Fill;
            this.panelControl4.Location = new Point(2, 0x4a);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(0x207, 0x10d);
            this.panelControl4.TabIndex = 1;
            this.grid_fieldmapping.Dock = DockStyle.Fill;
            this.grid_fieldmapping.Location = new Point(2, 2);
            this.grid_fieldmapping.MainView = this.gridView1;
            this.grid_fieldmapping.Name = "grid_fieldmapping";
            this.grid_fieldmapping.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox1 });
            this.grid_fieldmapping.Size = new Size(0x203, 0x109);
            this.grid_fieldmapping.TabIndex = 0;
            this.grid_fieldmapping.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.GridControl = this.grid_fieldmapping;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.panelControl3.Controls.Add(this.combo_targets);
            this.panelControl3.Controls.Add(this.label_totable);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = DockStyle.Top;
            this.panelControl3.Location = new Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(0x207, 0x48);
            this.panelControl3.TabIndex = 0;
            this.combo_targets.Location = new Point(0x69, 0x2b);
            this.combo_targets.Name = "combo_targets";
            this.combo_targets.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.combo_targets.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.combo_targets.Size = new Size(0x116, 0x15);
            this.combo_targets.TabIndex = 3;
            this.combo_targets.SelectedIndexChanged += new EventHandler(this.combo_targets_SelectedIndexChanged);
            this.label_totable.Location = new Point(0x73, 11);
            this.label_totable.Name = "label_totable";
            this.label_totable.Size = new Size(0, 14);
            this.label_totable.TabIndex = 2;
            this.labelControl3.Location = new Point(0x185, 0x2d);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x30, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "中的数据";
            this.labelControl2.Location = new Point(0x49, 0x2c);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x18, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "导入";
            this.labelControl1.Location = new Point(0x18, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "向地理图层：";
            base.AcceptButton = this.bnt_comfirm;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.bnt_cancel;
            base.ClientSize = new Size(0x20b, 0x180);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      //      base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ForGeoDataMatchFrm";
            base.ShowIcon = false;
            this.Text = "地理数据导入匹配设置";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.ForGeoDataMatchFrm_FormClosing);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl4.EndInit();
            this.panelControl4.ResumeLayout(false);
            this.grid_fieldmapping.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemComboBox1.EndInit();
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.combo_targets.Properties.EndInit();
            base.ResumeLayout(false);
        }

        public void TryToMatch(string tabName, List<string> srcNames, Dictionary<string, esriFieldType> srcFields, Dictionary<string, esriFieldType> targetFields)
        {
            this.label_totable.Text = tabName;
            this._srcFields = srcFields;
            this._targetFields = targetFields;
            this.combo_targets.Properties.Items.Clear();
            this.combo_targets.SelectedIndex = -1;
            foreach (string str in srcNames)
            {
                this.combo_targets.Properties.Items.Add(str);
            }
            this.combo_targets.Refresh();
            this.initFieldMatchTable();
        }

        public GeoDataMatchResult MatchResult
        {
            get
            {
                string text = this.combo_targets.Text;
                return new GeoDataMatchResult { 
                    TargetName = text,
                    MappedFields = this.getMappedFields()
                };
            }
        }

        public IWorkspace WorkSpace { get; set; }
    }
}

