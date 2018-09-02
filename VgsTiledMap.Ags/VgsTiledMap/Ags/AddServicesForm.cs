namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml.Linq;

    public class AddServicesForm : Form
    {
    
        private Button btnAddProvider;
        private Button btnCancel;
        private Button btnOk;
        private Button btnRemoveProvider;
        private IContainer components;
        private DataGridView dgvServices;
        private string file;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private bool init = true;
        private ListBox lbProvider;
        private string servicesDir;

        public AddServicesForm()
        {
            this.InitializeComponent();
        }

        private void AddPredefinedServicesForm_Load(object sender, EventArgs e)
        {
            this.InitForm();
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            AddProviderForm form = new AddProviderForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string providerName = form.ProviderName;
                string providedServiceURL = form.ProvidedServiceURL;
                EnumArcVgsTileLayer enumArcTilerLayer = form.EnumArcTilerLayer;
                this.WriteProviderXML(providerName, providedServiceURL, enumArcTilerLayer);
                this.InitForm();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btnRemoveProvider_Click(object sender, EventArgs e)
        {
            string selectedItem = (string) this.lbProvider.SelectedItem;
            string path = string.Concat(new object[] { this.servicesDir, Path.DirectorySeparatorChar, selectedItem, ".xml" });
            if (File.Exists(path))
            {
                File.Delete(path);
                this.InitForm();
            }
            else
            {
                MessageBox.Show("File " + selectedItem + " does not exist. Cannot remove provider.", "Error");
            }
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this.btnOk.Enabled = true;
                this.SelectedService = (TileMap) this.dgvServices.CurrentRow.DataBoundItem;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void InitForm()
        {
            this.servicesDir = CacheSettings.GetServicesConfigDir();
            List<string> list = new List<string>();
            DirectoryInfo info = new DirectoryInfo(this.servicesDir);
            foreach (FileInfo info2 in info.GetFiles("*.xml"))
            {
                list.Add(Path.GetFileNameWithoutExtension(info2.FullName));
            }
            this.lbProvider.DataSource = list;
            if (list.Count == 0)
            {
                this.dgvServices.DataSource = null;
            }
        }

        private void InitializeComponent()
        {
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.lbProvider = new ListBox();
            this.dgvServices = new DataGridView();
            this.btnAddProvider = new Button();
            this.btnRemoveProvider = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            ((ISupportInitialize) this.dgvServices).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.btnOk.Location = new Point(0x11e, 0x1a1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x86, 0x17);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Add Selected Service";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.Location = new Point(0x1aa, 0x1a1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.lbProvider.FormattingEnabled = true;
            this.lbProvider.Location = new Point(13, 0x13);
            this.lbProvider.Name = "lbProvider";
            this.lbProvider.Size = new Size(0x1d8, 0x79);
            this.lbProvider.TabIndex = 2;
            this.lbProvider.SelectedIndexChanged += new EventHandler(this.lbProvider_SelectedIndexChanged);
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new Point(0x1d, 230);
            this.dgvServices.MultiSelect = false;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersVisible = false;
            this.dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.ShowCellErrors = false;
            this.dgvServices.ShowCellToolTips = false;
            this.dgvServices.ShowEditingIcon = false;
            this.dgvServices.ShowRowErrors = false;
            this.dgvServices.Size = new Size(0x1d8, 0xaf);
            this.dgvServices.TabIndex = 5;
            this.dgvServices.SelectionChanged += new EventHandler(this.dgvServices_SelectionChanged);
            this.btnAddProvider.Location = new Point(0x12, 0x92);
            this.btnAddProvider.Name = "btnAddProvider";
            this.btnAddProvider.Size = new Size(0x75, 0x17);
            this.btnAddProvider.TabIndex = 6;
            this.btnAddProvider.Text = "Add provider...";
            this.btnAddProvider.UseVisualStyleBackColor = true;
            this.btnAddProvider.Click += new EventHandler(this.btnAddProvider_Click);
            this.btnRemoveProvider.Enabled = false;
            this.btnRemoveProvider.Location = new Point(150, 0x92);
            this.btnRemoveProvider.Name = "btnRemoveProvider";
            this.btnRemoveProvider.Size = new Size(0x98, 0x17);
            this.btnRemoveProvider.TabIndex = 7;
            this.btnRemoveProvider.Text = "Remove selected provider";
            this.btnRemoveProvider.UseVisualStyleBackColor = true;
            this.btnRemoveProvider.Click += new EventHandler(this.btnRemoveProvider_Click);
            this.groupBox1.Controls.Add(this.btnAddProvider);
            this.groupBox1.Controls.Add(this.btnRemoveProvider);
            this.groupBox1.Controls.Add(this.lbProvider);
            this.groupBox1.Location = new Point(0x10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1ec, 0xb6);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Providers";
            this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
            this.groupBox2.Location = new Point(0x10, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1ec, 0xd3);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Services";
            base.AcceptButton = this.btnOk;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(520, 0x1c4);
            base.Controls.Add(this.dgvServices);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            base.MaximizeBox = false;
            base.Name = "AddServicesForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add TMS service";
            base.TopMost = true;
            base.Load += new EventHandler(this.AddPredefinedServicesForm_Load);
            ((ISupportInitialize) this.dgvServices).EndInit();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void lbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.init = true;
            this.file = (string) this.lbProvider.SelectedItem;
            XElement element = XDocument.Load(string.Concat(new object[] { this.servicesDir, Path.DirectorySeparatorChar, this.file, ".xml" })).Element("Services").Element("TileMapService");
            TileMapService service2 = new TileMapService();
            service2.Title = element.Attribute("title").Value;
            service2.Version = element.Attribute("version").Value;
            service2.Href = element.Attribute("href").Value;
            TileMapService service = service2;
            this.SelectedTileMapService = service;
            this.btnRemoveProvider.Enabled = true;
            List<TileMap> tileMaps = TmsTileMapServiceParser.GetTileMaps(this.SelectedTileMapService.Href);
            tileMaps.Sort(new Comparison<TileMap>(TileMap.Compare));
            this.dgvServices.DataSource = tileMaps;
            this.dgvServices.Columns.Remove("Href");
            this.dgvServices.Columns.Remove("Profile");
            this.dgvServices.Columns.Remove("Srs");
            this.dgvServices.Columns.Remove("Type");
            this.dgvServices.Columns.Remove("OverwriteUrls");
            this.dgvServices.Columns[0].Width = 120;
            this.dgvServices.ClearSelection();
            this.init = false;
            if (tileMaps.Count > 0)
            {
                this.btnOk.Enabled = false;
            }
        }

        private void WriteProviderXML(string Name, string Url, EnumArcVgsTileLayer EnumArcTilerLayer)
        {
            string str = "<?xml version='1.0' encoding='utf-8' ?><Services>";
            str = str + string.Format("<TileMapService title='{0}' version='1.0.0' href='{1}' type='{2}'/>", Name, Url, EnumArcTilerLayer) + "</Services>";
            string path = string.Concat(new object[] { this.servicesDir, Path.DirectorySeparatorChar, Name, ".xml" });
            if (!File.Exists(path))
            {
                TextWriter writer = new StreamWriter(path);
                writer.WriteLine(str);
                writer.Close();
            }
            else
            {
                MessageBox.Show("Provider " + Name + " does already exist.");
            }
        }

        public TileMap SelectedService
        {
            get;
            set;
        }

        public TileMapService SelectedTileMapService
        {
            get;
            set;
        }
    }
}

