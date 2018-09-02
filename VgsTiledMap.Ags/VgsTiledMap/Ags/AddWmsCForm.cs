namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class AddWmsCForm : Form
    {
        private Button btnCancel;
        private Button btnOk;
        private Button btnRetrieve;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lbServices;
        public ITileSource SelectedTileSource;
        private TextBox tbWmsCUrl;
        private TextBox textBox1;
        private TextBox textBox2 = new TextBox();
        private IList<ITileSource> tileSources;

        public AddWmsCForm()
        {
            this.InitializeComponent();
        }

        private void AddWmsCForm_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string text = this.tbWmsCUrl.Text;
            try
            {
                this.tileSources = WmscTileSource.TileSourceBuilder(new Uri(text), null);
                List<string> list = new List<string>();
                foreach (ITileSource source in this.tileSources)
                {
                    list.Add(source.Schema.Name);
                }
                this.lbServices.DataSource = list;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
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

        private void InitializeComponent()
        {
            this.textBox2 = new TextBox();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.btnCancel = new Button();
            this.btnOk = new Button();
            this.label1 = new Label();
            this.tbWmsCUrl = new TextBox();
            this.groupBox1 = new GroupBox();
            this.btnRetrieve = new Button();
            this.lbServices = new ListBox();
            this.label3 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.textBox2.Location = new Point(0x55, 0x45);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0x1db, 20);
            this.textBox2.TabIndex = 0x17;
            this.textBox2.Text = "http://www.idee.es/wms-c/IDEE-Base/IDEE-Base?version=1.1.1&request=GetCapabilities&service=wms-c";
            this.textBox1.Location = new Point(0x55, 0x2b);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x1db, 20);
            this.textBox1.TabIndex = 0x16;
            this.textBox1.Text = "http://labs.metacarta.com/wms-c/tilecache.py?version=1.1.1&request=GetCapabilities&service=wms-c";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x12, 0x2e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(50, 13);
            this.label2.TabIndex = 0x12;
            this.label2.Text = "Samples:";
            this.btnCancel.Location = new Point(0x1f2, 0x185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 0x11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOk.Location = new Point(0x1a1, 390);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x4b, 0x17);
            this.btnOk.TabIndex = 0x10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x45, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "WmsC URL: ";
            this.tbWmsCUrl.Location = new Point(0x55, 12);
            this.tbWmsCUrl.Name = "tbWmsCUrl";
            this.tbWmsCUrl.Size = new Size(0x1db, 20);
            this.tbWmsCUrl.TabIndex = 14;
            this.tbWmsCUrl.Text = "http://www.idee.es/wms-c/IDEE-Base/IDEE-Base?version=1.1.1&request=GetCapabilities&service=wms-c";
            this.groupBox1.Controls.Add(this.btnRetrieve);
            this.groupBox1.Controls.Add(this.lbServices);
            this.groupBox1.Location = new Point(0x12, 0x70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x22b, 0x110);
            this.groupBox1.TabIndex = 0x13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Layers";
            this.btnRetrieve.Location = new Point(6, 0x13);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new Size(0xa5, 0x17);
            this.btnRetrieve.TabIndex = 0;
            this.btnRetrieve.Text = "Get Layers";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new EventHandler(this.btnRetrieve_Click);
            this.lbServices.FormattingEnabled = true;
            this.lbServices.Location = new Point(6, 0x34);
            this.lbServices.Name = "lbServices";
            this.lbServices.Size = new Size(0x218, 0xc7);
            this.lbServices.TabIndex = 3;
            this.lbServices.SelectedIndexChanged += new EventHandler(this.lbServices_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x12, 0x48);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 13);
            this.label3.TabIndex = 0x18;
            this.label3.Text = "INSPIRE:";
            base.AcceptButton = this.btnOk;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x24f, 0x1a8);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.tbWmsCUrl);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AddWmsCForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add WMS-C Service";
            base.Load += new EventHandler(this.AddWmsCForm_Load);
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbServices.SelectedItem != null)
            {
                string selectedItem = (string) this.lbServices.SelectedItem;
                foreach (ITileSource source in this.tileSources)
                {
                    if (source.Schema.Name == selectedItem)
                    {
                        this.SelectedTileSource = source;
                    }
                }
                this.btnOk.Enabled = true;
            }
        }
    }
}

