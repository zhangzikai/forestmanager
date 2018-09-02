namespace Cartography.Render
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class vForestAnnoControl2 : UserControl
    {
        private Button bnt_addFenmu;
        private Button bnt_addFenzi;
        private ToolStripMenuItem clear_menu;
        private IContainer components;
        private ToolStripMenuItem del_fld_menu;
        private ToolStripMenuItem down_fld_menu;
        private ContextMenuStrip Field_Menu;
        private TextBox field_splash;
        private ListBox fld_fenmu;
        private ListBox fld_fenzi;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private ITextSymbol m_TextSymbol;
        private ListBox src_flds_listbox;
        private ILayer tLayer;
        private ToolStripMenuItem up_fld_menu;

        public vForestAnnoControl2()
        {
            this.InitializeComponent();
            this.fld_fenmu.DisplayMember = "DisplayName";
            this.fld_fenzi.DisplayMember = "DisplayName";
        }

        public void ApplyToLayer()
        {
            if ((this.tLayer != null) && (this.tLayer is IFeatureLayer))
            {
                IGeoFeatureLayer tLayer = this.tLayer as IGeoFeatureLayer;
                tLayer.AnnotationProperties.Clear();
                IBasicOverposterLayerProperties properties = this.CreateBasicOverPropers(((IFeatureLayer) this.tLayer).FeatureClass);
                ILabelEngineLayerProperties properties2 = new LabelEngineLayerPropertiesClass();
                if (this.m_TextSymbol != null)
                {
                    properties2.Symbol = this.m_TextSymbol;
                }
                properties2.BasicOverposterLayerProperties = properties;
                properties2.IsExpressionSimple = true;
                properties2.Expression = this.LabelExpression;
                IAnnotateLayerProperties item = properties2 as IAnnotateLayerProperties;
                item.DisplayAnnotation = true;
                item.FeatureLayer = this.tLayer as IFeatureLayer;
                item.LabelWhichFeatures = esriLabelWhichFeatures.esriVisibleFeatures;
                item.WhereClause = "";
                tLayer.DisplayAnnotation = true;
                tLayer.AnnotationProperties.Add(item);
            }
            else
            {
                MessageBox.Show("目标图层为空，或不是矢量图层，不能进行处理!");
            }
        }

        private void bnt_addFenmu_Click(object sender, EventArgs e)
        {
            object selectedItem = this.src_flds_listbox.SelectedItem;
            if ((selectedItem != null) && (selectedItem is vFieldItem))
            {
                vFieldItem item = selectedItem as vFieldItem;
                this.fld_fenmu.Items.Add(item);
            }
        }

        private void bnt_addFenzi_Click(object sender, EventArgs e)
        {
            object selectedItem = this.src_flds_listbox.SelectedItem;
            if ((selectedItem != null) && (selectedItem is vFieldItem))
            {
                vFieldItem item = selectedItem as vFieldItem;
                this.fld_fenzi.Items.Add(item);
            }
        }

        private void clear_menu_Click(object sender, EventArgs e)
        {
            ListBox tag = this.Field_Menu.Tag as ListBox;
            if (tag != null)
            {
                tag.Items.Clear();
            }
        }

        private IBasicOverposterLayerProperties CreateBasicOverPropers(IFeatureClass featureClass)
        {
            IBasicOverposterLayerProperties properties = new BasicOverposterLayerPropertiesClass();
            switch (featureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    properties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                    properties.PointPlacementOnTop = true;
                    break;

                case esriGeometryType.esriGeometryPolyline:
                    properties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                    break;

                case esriGeometryType.esriGeometryPolygon:
                    properties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
                    break;

                default:
                    properties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
                    break;
            }
            properties.NumLabelsOption = esriBasicNumLabelsOption.esriOneLabelPerShape;
            return properties;
        }

        private void del_fld_menu_Click(object sender, EventArgs e)
        {
            ListBox tag = this.Field_Menu.Tag as ListBox;
            if (tag != null)
            {
                tag.Items.RemoveAt(tag.SelectedIndex);
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

        private void down_fld_menu_Click(object sender, EventArgs e)
        {
            ListBox tag = this.Field_Menu.Tag as ListBox;
            if (tag != null)
            {
                int selectedIndex = tag.SelectedIndex;
                if (selectedIndex < tag.Items.Count)
                {
                    object item = tag.Items[selectedIndex];
                    tag.Items.RemoveAt(selectedIndex);
                    tag.Items.Insert(selectedIndex + 1, item);
                }
            }
        }

        private void fld_fenmu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ShowListBoxMenu(sender, e);
            }
        }

        private void fld_fenzi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ShowListBoxMenu(sender, e);
            }
        }

        private string genExpression()
        {
            string expressInfo = this.GetExpressInfo(this.fld_fenzi);
            string str2 = this.GetExpressInfo(this.fld_fenmu);
            if (string.IsNullOrEmpty(expressInfo))
            {
                return str2;
            }
            if (string.IsNullOrEmpty(str2))
            {
                return expressInfo;
            }
            return (("\"<UND> \" & " + expressInfo + " & \" </UND>\" & vbnewline & ") + str2);
        }

        private string GetExpressInfo(ListBox fldInf0s)
        {
            int count = fldInf0s.Items.Count;
            if (count <= 0)
            {
                return string.Empty;
            }
            string str = string.IsNullOrEmpty(this.field_splash.Text) ? "-" : this.field_splash.Text;
            string str2 = string.Empty;
            for (int i = 0; i < count; i++)
            {
                vFieldItem item = fldInf0s.Items[i] as vFieldItem;
                if ((item != null) && !string.IsNullOrEmpty(item.FieldName))
                {
                    if (string.IsNullOrEmpty(str2))
                    {
                        str2 = str2 + "[" + item.FieldName + "]";
                    }
                    else
                    {
                        string str3 = str2;
                        str2 = str3 + " & \"" + str + "\" & [" + item.FieldName + "] ";
                    }
                }
            }
            return str2;
        }

        private void initFields(ILayer pLayer)
        {
            this.src_flds_listbox.Items.Clear();
            if ((pLayer != null) && (pLayer is IFeatureLayer))
            {
                ITable table = pLayer as ITable;
                IField field = null;
                for (int i = 0; i < table.Fields.FieldCount; i++)
                {
                    field = table.Fields.get_Field(i);
                    if (field != null)
                    {
                        vFieldItem item = new vFieldItem();
                        item.AliasName = field.AliasName;
                        item.FieldName = field.Name;
                        item.DisplayName = string.IsNullOrEmpty(field.AliasName) ? ("[" + field.Name + "]-[" + field.Name + "]") : ("[" + field.Name + "]-[" + field.AliasName + "]");
                        this.src_flds_listbox.Items.Add(item);
                    }
                }
                this.src_flds_listbox.DisplayMember = "DisplayName";
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.groupBox1 = new GroupBox();
            this.src_flds_listbox = new ListBox();
            this.groupBox2 = new GroupBox();
            this.fld_fenzi = new ListBox();
            this.Field_Menu = new ContextMenuStrip(this.components);
            this.del_fld_menu = new ToolStripMenuItem();
            this.clear_menu = new ToolStripMenuItem();
            this.up_fld_menu = new ToolStripMenuItem();
            this.down_fld_menu = new ToolStripMenuItem();
            this.groupBox3 = new GroupBox();
            this.fld_fenmu = new ListBox();
            this.field_splash = new TextBox();
            this.label1 = new Label();
            this.bnt_addFenzi = new Button();
            this.bnt_addFenmu = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Field_Menu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.src_flds_listbox);
            this.groupBox1.Location = new System.Drawing.Point(4, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xb2, 0xee);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "源字段";
            this.src_flds_listbox.Dock = DockStyle.Fill;
            this.src_flds_listbox.FormattingEnabled = true;
            this.src_flds_listbox.ItemHeight = 12;
            this.src_flds_listbox.Location = new System.Drawing.Point(3, 0x11);
            this.src_flds_listbox.Name = "src_flds_listbox";
            this.src_flds_listbox.Size = new Size(0xac, 0xd0);
            this.src_flds_listbox.TabIndex = 0;
            this.groupBox2.Controls.Add(this.fld_fenzi);
            this.groupBox2.Location = new System.Drawing.Point(0xee, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(180, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分子字段";
            this.fld_fenzi.Dock = DockStyle.Fill;
            this.fld_fenzi.FormattingEnabled = true;
            this.fld_fenzi.ItemHeight = 12;
            this.fld_fenzi.Location = new System.Drawing.Point(3, 0x11);
            this.fld_fenzi.Name = "fld_fenzi";
            this.fld_fenzi.Size = new Size(0xae, 0x4c);
            this.fld_fenzi.TabIndex = 0;
            this.fld_fenzi.MouseDown += new MouseEventHandler(this.fld_fenzi_MouseDown);
            this.Field_Menu.Items.AddRange(new ToolStripItem[] { this.del_fld_menu, this.clear_menu, this.up_fld_menu, this.down_fld_menu });
            this.Field_Menu.Name = "Field_Menu";
            this.Field_Menu.Size = new Size(0x65, 0x5c);
            this.del_fld_menu.Name = "del_fld_menu";
            this.del_fld_menu.Size = new Size(100, 0x16);
            this.del_fld_menu.Text = "删除";
            this.del_fld_menu.Click += new EventHandler(this.del_fld_menu_Click);
            this.clear_menu.Name = "clear_menu";
            this.clear_menu.Size = new Size(100, 0x16);
            this.clear_menu.Text = "清空";
            this.clear_menu.Click += new EventHandler(this.clear_menu_Click);
            this.up_fld_menu.Name = "up_fld_menu";
            this.up_fld_menu.Size = new Size(100, 0x16);
            this.up_fld_menu.Text = "上移";
            this.up_fld_menu.Click += new EventHandler(this.up_fld_menu_Click);
            this.down_fld_menu.Name = "down_fld_menu";
            this.down_fld_menu.Size = new Size(100, 0x16);
            this.down_fld_menu.Text = "下移";
            this.down_fld_menu.Click += new EventHandler(this.down_fld_menu_Click);
            this.groupBox3.Controls.Add(this.fld_fenmu);
            this.groupBox3.Location = new System.Drawing.Point(0xee, 0x77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(180, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分母字段";
            this.fld_fenmu.Dock = DockStyle.Fill;
            this.fld_fenmu.FormattingEnabled = true;
            this.fld_fenmu.ItemHeight = 12;
            this.fld_fenmu.Location = new System.Drawing.Point(3, 0x11);
            this.fld_fenmu.Name = "fld_fenmu";
            this.fld_fenmu.Size = new Size(0xae, 0x4c);
            this.fld_fenmu.TabIndex = 0;
            this.fld_fenmu.MouseDown += new MouseEventHandler(this.fld_fenmu_MouseDown);
            this.field_splash.Location = new System.Drawing.Point(0x131, 230);
            this.field_splash.Name = "field_splash";
            this.field_splash.Size = new Size(110, 0x15);
            this.field_splash.TabIndex = 2;
            this.field_splash.Text = "-";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0xd8, 0xe9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "字段间连接符:";
            this.bnt_addFenzi.Location = new System.Drawing.Point(0xbc, 0x21);
            this.bnt_addFenzi.Name = "bnt_addFenzi";
            this.bnt_addFenzi.Size = new Size(0x2f, 0x17);
            this.bnt_addFenzi.TabIndex = 1;
            this.bnt_addFenzi.Text = "分子>>";
            this.bnt_addFenzi.UseVisualStyleBackColor = true;
            this.bnt_addFenzi.Click += new EventHandler(this.bnt_addFenzi_Click);
            this.bnt_addFenmu.Location = new System.Drawing.Point(0xbc, 0x88);
            this.bnt_addFenmu.Name = "bnt_addFenmu";
            this.bnt_addFenmu.Size = new Size(0x2f, 0x17);
            this.bnt_addFenmu.TabIndex = 1;
            this.bnt_addFenmu.Text = "分母>>";
            this.bnt_addFenmu.UseVisualStyleBackColor = true;
            this.bnt_addFenmu.Click += new EventHandler(this.bnt_addFenmu_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.bnt_addFenmu);
            base.Controls.Add(this.bnt_addFenzi);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.field_splash);
            base.Controls.Add(this.groupBox1);
            base.Name = "vForestAnnoControl2";
            base.Size = new Size(0x1aa, 0x109);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.Field_Menu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ShowListBoxMenu(object sender, MouseEventArgs e)
        {
            ListBox control = sender as ListBox;
            if (control != null)
            {
                int num = control.IndexFromPoint(e.Location);
                if (num >= 0)
                {
                    control.SelectedIndex = num;
                    this.Field_Menu.Tag = control;
                    this.Field_Menu.Show(control, e.Location);
                }
            }
        }

        private void up_fld_menu_Click(object sender, EventArgs e)
        {
            ListBox tag = this.Field_Menu.Tag as ListBox;
            if (tag != null)
            {
                int selectedIndex = tag.SelectedIndex;
                if (selectedIndex != 0)
                {
                    object item = tag.Items[selectedIndex];
                    tag.Items.RemoveAt(selectedIndex);
                    tag.Items.Insert(selectedIndex - 1, item);
                }
            }
        }

        public string LabelExpression
        {
            get
            {
                return this.genExpression();
            }
        }

        public ILayer TargetLayer
        {
            get
            {
                return this.tLayer;
            }
            set
            {
                this.tLayer = value;
                this.initFields(value);
            }
        }

        public ITextSymbol TextSymbol
        {
            set
            {
                this.m_TextSymbol = value;
            }
        }

        private class vFieldItem
        {
           

            public string AliasName
            {
               get;set;
            }

            public string DisplayName
            {
                get;
                set;
            }

            public string FieldName
            {
                get;
                set;
            }
        }
    }
}

