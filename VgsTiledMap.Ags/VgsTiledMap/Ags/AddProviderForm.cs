namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml;

    public class AddProviderForm : Form
    {
      
        private Button btnCancel;
        private Button btnOk;
        private IContainer components = new Container();
        private EnumArcVgsTileLayer enumArcTilerLayer = EnumArcVgsTileLayer.TMS;
        private ErrorProvider errorProvider1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label3;
        private Label label4;
        private ListBox lbProviders;
        private string providedServiceURL = string.Empty;
        private TextBox tbName;
        private TextBox tbTmsUrl;

        public AddProviderForm()
        {
            this.InitializeComponent();
            this.InitForm();
        }

        private void AddProviderForm_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.checkUrl(this.tbTmsUrl.Text))
            {
                this.ProviderName = this.tbName.Text;
                this.ProvidedServiceURL = this.tbTmsUrl.Text;
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private bool checkUrl(string url)
        {
            bool flag = false;
            if (this.UrlIsValid(url))
            {
                try
                {
                    TmsTileMapServiceParser.GetTileMaps(url);
                    flag = true;
                }
                catch (WebException)
                {
                    this.errorProvider1.SetError(this.tbTmsUrl, "Could not download document. Please specify valid url");
                }
                catch (XmlException)
                {
                    this.errorProvider1.SetError(this.tbTmsUrl, "Could not download XML document. Please specify valid url");
                }
            }
            return flag;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<TileMapService> GetList(string Url)
        {
            List<TileMapService> list = new List<TileMapService>();
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            for (bool flag = true; !reader.EndOfStream; flag = false)
            {
                string str = reader.ReadLine();
                if (!flag)
                {
                    TileMapService service2 = new TileMapService();
                    service2.Title = str.Split(new char[] { ',' })[0];
                    service2.Href = str.Split(new char[] { ',' })[1];
                    service2.Version = str.Split(new char[] { ',' })[2];
                    TileMapService item = service2;
                    list.Add(item);
                }
            }
            return list;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void InitForm()
        {
            string url = "http://www.google.com/fusiontables/api/query?sql=SELECT Title,Url, Version from 368892 order by Title";
            List<TileMapService> list = this.GetList(url);
            this.lbProviders.DataSource = list;
            this.lbProviders.DisplayMember = "Title";
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.tbTmsUrl = new TextBox();
            this.label1 = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.lbProviders = new ListBox();
            this.label4 = new Label();
            this.tbName = new TextBox();
            this.label3 = new Label();
            this.errorProvider1 = new ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.errorProvider1).BeginInit();
            base.SuspendLayout();
            this.tbTmsUrl.CausesValidation = false;
            this.tbTmsUrl.Location = new Point(0x47, 0x30);
            this.tbTmsUrl.Name = "tbTmsUrl";
            this.tbTmsUrl.Size = new Size(0x125, 0x15);
            this.tbTmsUrl.TabIndex = 1;
            this.tbTmsUrl.Validating += new CancelEventHandler(this.tbTmsUrl_Validating);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(15, 0x30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url: ";
            this.btnOk.Location = new Point(0xd6, 0x13c);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x6d, 0x17);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Add provider";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x149, 0x13c);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.groupBox2.Controls.Add(this.lbProviders);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbTmsUrl);
            this.groupBox2.Location = new Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x187, 310);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provider Description:";
            this.groupBox2.Enter += new EventHandler(this.groupBox2_Enter);
            this.lbProviders.FormattingEnabled = true;
            this.lbProviders.ItemHeight = 12;
            this.lbProviders.Location = new Point(0x47, 80);
            this.lbProviders.Name = "lbProviders";
            this.lbProviders.Size = new Size(0x125, 0xb8);
            this.lbProviders.TabIndex = 0x10;
            this.lbProviders.SelectedIndexChanged += new EventHandler(this.lbProviders_SelectedIndexChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "Samples:";
            this.tbName.CausesValidation = false;
            this.tbName.Location = new Point(0x47, 0x16);
            this.tbName.Name = "tbName";
            this.tbName.Size = new Size(0x125, 0x15);
            this.tbName.TabIndex = 14;
            this.tbName.Validating += new CancelEventHandler(this.tbName_Validating);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(15, 0x16);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name:";
            this.errorProvider1.ContainerControl = this;
            base.AcceptButton = this.btnOk;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x1b0, 0x15f);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.groupBox2);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AddProviderForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add TMS Provider";
            base.Load += new EventHandler(this.AddProviderForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize) this.errorProvider1).EndInit();
            base.ResumeLayout(false);
        }

        private void lbProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            TileMapService selectedItem = (TileMapService) this.lbProviders.SelectedItem;
            this.tbName.Text = selectedItem.Title;
            this.tbTmsUrl.Text = selectedItem.Href;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo info2 = new ProcessStartInfo();
            info2.UseShellExecute = true;
            info2.FileName = "http://VgsTiledMap.Ags.codeplex.com";
            ProcessStartInfo startInfo = info2;
            Process.Start(startInfo);
        }

        private void rdbTMS_CheckedChanged(object sender, EventArgs e)
        {
            this.enumArcTilerLayer = EnumArcVgsTileLayer.TMS;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (this.tbName.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.tbName, "Please give name");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(this.tbName, "");
            }
        }

        private void tbTmsUrl_Validating(object sender, CancelEventArgs e)
        {
            if (this.tbTmsUrl.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.tbTmsUrl, "Please give url");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(this.tbTmsUrl, "");
            }
        }

        private bool UrlIsValid(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri);
        }

        public EnumArcVgsTileLayer EnumArcTilerLayer
        {
            get
            {
                return this.enumArcTilerLayer;
            }
            set
            {
                this.enumArcTilerLayer = value;
            }
        }

        public string ProvidedServiceURL
        {
            get
            {
                return this.providedServiceURL;
            }
            set
            {
                this.providedServiceURL = value;
            }
        }

        public string ProviderName
        {
            get;
            set;
        }
    }
}

