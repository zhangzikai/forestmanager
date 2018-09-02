namespace VgsTiledMap.Ags
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    internal class VgsTiledMapAboutBox : Form
    {
        private IContainer components = new Container();
        private Label label1 = new Label();
        private Label labelProductName = new Label();
        private Label labelVersion = new Label();
        private PictureBox logoPictureBox = new PictureBox();
        private Button okButton = new Button();
        private TableLayoutPanel tableLayoutPanel;
        private LinkLabel webLink = new LinkLabel();

        public VgsTiledMapAboutBox()
        {
            this.InitializeComponent();
            this.Text = "林地一张图数据管理";
            this.labelProductName.Text = "林地一张图数据管理";
            this.labelVersion.Text = string.Format("版本:{0}", this.AssemblyVersion);
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
            this.tableLayoutPanel = new TableLayoutPanel();
            this.labelProductName = new Label();
            this.labelVersion = new Label();
            this.logoPictureBox = new PictureBox();
            this.label1 = new Label();
            this.okButton = new Button();
            this.webLink = new LinkLabel();
            this.tableLayoutPanel.SuspendLayout();
            ((ISupportInitialize) this.logoPictureBox).BeginInit();
            base.SuspendLayout();
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.1247f));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.8753f));
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.webLink, 1, 4);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(9, 8);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 43.5f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5f));
            this.tableLayoutPanel.Size = new Size(0x1a1, 200);
            this.tableLayoutPanel.TabIndex = 0;
            this.labelProductName.Dock = DockStyle.Fill;
            this.labelProductName.Location = new Point(0xbd, 0);
            this.labelProductName.Margin = new Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new Size(0, 0x10);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new Size(0xe1, 0x10);
            this.labelProductName.TabIndex = 0x13;
            this.labelProductName.Text = "名称";
            this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            this.labelVersion.Dock = DockStyle.Fill;
            this.labelVersion.Location = new Point(0xbd, 20);
            this.labelVersion.Margin = new Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new Size(0, 0x10);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(0xe1, 0x10);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "版本";
            this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            this.logoPictureBox.Location = new Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 5);
            this.logoPictureBox.Size = new Size(0xb1, 0xa1);
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0x1b;
            this.logoPictureBox.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xba, 40);
            this.label1.Name = "label1";
            this.tableLayoutPanel.SetRowSpan(this.label1, 2);
            this.label1.Size = new Size(0, 12);
            this.label1.TabIndex = 0x1a;
            this.okButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Location = new Point(0x153, 0xaf);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(0x4b, 0x16);
            this.okButton.TabIndex = 0x18;
            this.okButton.Text = "确定";
            this.webLink.AutoSize = true;
            this.webLink.Location = new Point(0xba, 80);
            this.webLink.Name = "webLink";
            this.webLink.Size = new Size(0x53, 12);
            this.webLink.TabIndex = 0x1c;
            this.webLink.TabStop = true;
            this.webLink.Text = "www.caf.ac.cn";
            this.webLink.Visible = false;
            this.webLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.weiboLink_LinkClicked);
            base.AcceptButton = this.okButton;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x1b3, 0xd8);
            base.Controls.Add(this.tableLayoutPanel);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "VgsTiledMapAboutBox";
            base.Padding = new Padding(9, 8, 9, 8);
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "关于";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((ISupportInitialize) this.logoPictureBox).EndInit();
            base.ResumeLayout(false);
        }

        private void weiboLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.caf.ac.cn");
        }

        public string AssemblyCompany
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute) customAttributes[0]).Company;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "Produced By IFRIT@2012";
                }
                return ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute) customAttributes[0]).Product;
            }
        }

        public string AssemblyTitle
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length > 0)
                {
                    AssemblyTitleAttribute attribute = (AssemblyTitleAttribute) customAttributes[0];
                    if (attribute.Title != "")
                    {
                        return attribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}

