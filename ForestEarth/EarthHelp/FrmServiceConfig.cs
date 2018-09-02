namespace ForestEarth.EarthHelp
{
    using DevExpress.XtraEditors;
    using ForestEarth;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class FrmServiceConfig : Form
    {

        private SimpleButton btn_cancel;
        private SimpleButton btn_ok;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private PanelControl panelControl1;
        private TextEdit te_ip;
        private TextEdit te_name;
        private TextEdit te_port;

        public FrmServiceConfig()
        {
            this.InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.te_ip.Text = string.Empty;
            this.te_port.Text = string.Empty;
            this.te_name.Text = string.Empty;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoCheck();
                string path = AppDomain.CurrentDomain.BaseDirectory + "EarthData";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = path + @"\esconfig.xml";
                FileInfo info = new FileInfo(fileName);
                if (info.Exists)
                {
                    info.Delete();
                }
                XmlDocument document = new XmlDocument();
                document.LoadXml("<?xml version=\"1.0\" encoding=\"GBK\"?><ESPATH></ESPATH>");
                XmlNode node = document.SelectSingleNode("ESPATH");
                XmlNode newChild = document.CreateElement("ESIP");
                newChild.InnerText = this.te_ip.Text.Trim();
                node.AppendChild(newChild);
                XmlNode node3 = document.CreateElement("ESPORT");
                node3.InnerText = this.te_port.Text.Trim();
                node.AppendChild(node3);
                XmlNode node4 = document.CreateElement("ESNAME");
                node4.InnerText = this.te_name.Text.Trim();
                node.AppendChild(node4);
                document.Save(fileName);
                StringBuilder builder = new StringBuilder();
                builder.Append("http://").Append(this.te_ip.Text.Trim()).Append(":");
                builder.Append(this.te_port.Text.Trim()).Append("/earth/scene=");
                builder.Append(this.te_name.Text.Trim());
                ClsConfigManage.PathEarthService = builder.ToString();
                this.CreateESConfigXml = true;
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("保存三维服务地址配置文件出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.CreateESConfigXml = false;
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

        private void DoCheck()
        {
            if (string.IsNullOrEmpty(this.te_ip.Text.Trim()))
            {
                MessageBox.Show("三维服务IP地址为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(this.te_port.Text.Trim()))
            {
                MessageBox.Show("三维服务端口号为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(this.te_name.Text.Trim()))
            {
                MessageBox.Show("三维服务名为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmServiceConfig_Load(object sender, EventArgs e)
        {
            this.LoadESConfigXml();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmServiceConfig));
            this.panelControl1 = new PanelControl();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.btn_ok = new SimpleButton();
            this.btn_cancel = new SimpleButton();
            this.te_ip = new TextEdit();
            this.te_port = new TextEdit();
            this.te_name = new TextEdit();
            this.labelControl4 = new LabelControl();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.te_ip.Properties.BeginInit();
            this.te_port.Properties.BeginInit();
            this.te_name.Properties.BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.te_name);
            this.panelControl1.Controls.Add(this.te_port);
            this.panelControl1.Controls.Add(this.te_ip);
            this.panelControl1.Controls.Add(this.btn_cancel);
            this.panelControl1.Controls.Add(this.btn_ok);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x130, 0xc0);
            this.panelControl1.TabIndex = 0;
            this.labelControl1.Location = new Point(20, 0x1c);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x47, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "服务IP地址：";
            this.labelControl2.Location = new Point(0x2b, 0x45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x30, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "端口号：";
            this.labelControl3.Location = new Point(0x1f, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "服务名称：";
            this.btn_ok.Image = (Image) manager.GetObject("btn_ok.Image");
            this.btn_ok.Location = new Point(0x39, 0x93);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new Size(0x4b, 0x17);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确 定";
            this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
            this.btn_cancel.Image = (Image) manager.GetObject("btn_cancel.Image");
            this.btn_cancel.Location = new Point(0xad, 0x93);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new Size(0x4b, 0x17);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "重 置";
            this.btn_cancel.Click += new EventHandler(this.btn_cancel_Click);
            this.te_ip.Location = new Point(0x61, 0x19);
            this.te_ip.Name = "te_ip";
            this.te_ip.Size = new Size(0xc0, 0x15);
            this.te_ip.TabIndex = 5;
            this.te_port.Location = new Point(0x61, 0x42);
            this.te_port.Name = "te_port";
            this.te_port.Size = new Size(0x56, 0x15);
            this.te_port.TabIndex = 6;
            this.te_name.Location = new Point(0x61, 0x6b);
            this.te_name.Name = "te_name";
            this.te_name.Size = new Size(0xc0, 0x15);
            this.te_name.TabIndex = 7;
            this.labelControl4.Location = new Point(0xb9, 0x45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x68, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "（如8080或9090）";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x130, 0xc0);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmServiceConfig";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "系统服务设窗体置";
            base.Load += new EventHandler(this.FrmServiceConfig_Load);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.te_ip.Properties.EndInit();
            this.te_port.Properties.EndInit();
            this.te_name.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void LoadESConfigXml()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\esconfig.xml";
            if (File.Exists(path))
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(path);
                    XmlNode node = document.SelectSingleNode("ESPATH");
                    if (node != null)
                    {
                        XmlNode node2 = node.SelectSingleNode("ESIP");
                        XmlNode node3 = node.SelectSingleNode("ESPORT");
                        XmlNode node4 = node.SelectSingleNode("ESNAME");
                        this.te_ip.Text = node2.InnerText;
                        this.te_port.Text = node3.InnerText;
                        this.te_name.Text = node4.InnerText;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("方法LoadESConfigXml读取三维服务地址配置文件出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        public bool CreateESConfigXml
        {
            get;
            set;
        }
    }
}

