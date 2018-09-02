namespace OperateLog
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using jn.isos.log;

    public class UserControlDataBaseLogin : UserControlBase1
    {
        private AxLicenseControl axLicenseControl1;
        private CheckBox checkBoxSample;
        private IContainer components;
        internal System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        internal Label label1;
        internal Label label2;
        internal Label lblClose;
        internal Label lblImage;
        internal Label lblInstance;
        internal Label lblPassWord;
        internal Label lblServerName;
        internal Label lblUserName;
        private IWorkspace m_Workspace;
        private Panel panel1;
        private Panel panel10;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelResource0;
        public SimpleButton simpleButton1;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        public SimpleButton simpleButtonTest;
        private TextEdit textEditDatabase;
        private TextEdit textEditService;
        private TextEdit textImgServer;
        private TextEdit textServer;
        private TextEdit txtPassWord;
        private TextEdit txtUserName;
        private Logger m_log = LoggerManager.CreateLogger("DB", typeof(UserControlDataBaseLogin));
        public UserControlDataBaseLogin()
        {
            this.InitializeComponent();
            this.init();
        }

        private void checkBoxSample_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSample.Checked)
            {
                string text = this.textServer.Text;
                this.textImgServer.Text = text;
                this.panel5.Enabled = false;
            }
            else
            {
                this.panel5.Enabled = true;
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

        private string GetIP(string sCacheUrl)
        {
            if (sCacheUrl != "")
            {
                int index = sCacheUrl.IndexOf("//");
                int num2 = sCacheUrl.LastIndexOf(":");
                return sCacheUrl.Substring(index + 2, (num2 - index) - 2);
            }
            return "";
        }

        private IFeatureWorkspace GetWorkspace()
        {
            string text = this.textServer.Text;
            string str2 = this.textEditService.Text;
            string str3 = this.textEditDatabase.Text;
            string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
            string str5 = this.txtUserName.Text;
            string str6 = this.txtPassWord.Text;
            IPropertySet connectionProperties = null;
            IWorkspaceFactory factory = null;
            connectionProperties = new PropertySetClass();
            connectionProperties.SetProperty("SERVER", text);
            connectionProperties.SetProperty("INSTANCE", str2);
            connectionProperties.SetProperty("DATABASE", str3);
            connectionProperties.SetProperty("USER", str5);
            connectionProperties.SetProperty("PASSWORD", str6);
            connectionProperties.SetProperty("VERSION", str4);
            factory = new SdeWorkspaceFactoryClass();
            return (factory.Open(connectionProperties, 0) as IFeatureWorkspace);
        }

        private void init()
        {
            this.m_Workspace = null;
            this.txtUserName.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
            this.txtPassWord.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
            this.textServer.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
            this.textEditDatabase.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            this.textEditService.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
            string path = Application.StartupPath + @"\VgsTiledMap.Ags.dll";
            if (File.Exists(path))
            {
                try
                {
                    string sCacheUrl = ConfigurationManager.OpenExeConfiguration(path).AppSettings.Settings["VgsUrl"].Value.ToString();
                    this.textImgServer.Text = this.GetIP(sCacheUrl);
                }
                catch
                {
                }
            }
            else
            {
                this.groupBox1.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlDataBaseLogin));
            this.lblClose = new Label();
            this.lblInstance = new Label();
            this.lblServerName = new Label();
            this.label1 = new Label();
            this.textServer = new TextEdit();
            this.textEditService = new TextEdit();
            this.textEditDatabase = new TextEdit();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.txtPassWord = new TextEdit();
            this.txtUserName = new TextEdit();
            this.lblUserName = new Label();
            this.lblPassWord = new Label();
            this.lblImage = new Label();
            this.panelResource0 = new Panel();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.panel6 = new Panel();
            this.simpleButton1 = new SimpleButton();
            this.panel10 = new Panel();
            this.simpleButtonTest = new SimpleButton();
            this.panel9 = new Panel();
            this.simpleButtonOK = new SimpleButton();
            this.panel4 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.panel5 = new Panel();
            this.textImgServer = new TextEdit();
            this.label2 = new Label();
            this.checkBoxSample = new CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new Panel();
            this.panel8 = new Panel();
            this.axLicenseControl1 = new AxLicenseControl();
            this.textServer.Properties.BeginInit();
            this.textEditService.Properties.BeginInit();
            this.textEditDatabase.Properties.BeginInit();
            this.GroupBox.SuspendLayout();
            this.txtPassWord.Properties.BeginInit();
            this.txtUserName.Properties.BeginInit();
            this.panelResource0.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.textImgServer.Properties.BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.axLicenseControl1.BeginInit();
            base.SuspendLayout();
            this.lblClose.BackColor = Color.Transparent;
            this.lblClose.Font = new Font("Tahoma", 9f);
            this.lblClose.ForeColor = Color.Black;
            this.lblClose.Image = (Image) resources.GetObject("lblClose.Image");
            this.lblClose.Location = new Point(0x11c, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new Size(15, 13);
            this.lblClose.TabIndex = 30;
            this.lblClose.Visible = false;
            this.lblInstance.BackColor = Color.Transparent;
            this.lblInstance.Dock = DockStyle.Left;
            this.lblInstance.ForeColor = Color.RoyalBlue;
            this.lblInstance.Location = new Point(10, 6);
            this.lblInstance.Name = "lblInstance";
            this.lblInstance.Size = new Size(0x37, 20);
            this.lblInstance.TabIndex = 0x20;
            this.lblInstance.Text = "服务:";
            this.lblInstance.TextAlign = ContentAlignment.MiddleLeft;
            this.lblServerName.BackColor = Color.Transparent;
            this.lblServerName.Dock = DockStyle.Left;
            this.lblServerName.ForeColor = Color.RoyalBlue;
            this.lblServerName.Location = new Point(10, 6);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new Size(0x37, 20);
            this.lblServerName.TabIndex = 0x1f;
            this.lblServerName.Text = "服务器:";
            this.lblServerName.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.BackColor = Color.Transparent;
            this.label1.Dock = DockStyle.Left;
            this.label1.ForeColor = Color.RoyalBlue;
            this.label1.Location = new Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x37, 20);
            this.label1.TabIndex = 0x21;
            this.label1.Text = "数据库:";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.textServer.Dock = DockStyle.Fill;
            this.textServer.EditValue = "";
            this.textServer.Location = new Point(0x41, 6);
            this.textServer.Name = "textServer";
            this.textServer.Properties.AllowNullInput = DefaultBoolean.False;
            this.textServer.Size = new Size(0x115, 0x15);
            this.textServer.TabIndex = 0x22;
            this.textEditService.Dock = DockStyle.Fill;
            this.textEditService.EditValue = @"sde:sqlserver:10.2.10.240\sdeworkgroup";
            this.textEditService.Location = new Point(0x41, 6);
            this.textEditService.Name = "textEditService";
            this.textEditService.Size = new Size(0x115, 0x15);
            this.textEditService.TabIndex = 0x23;
            this.textEditDatabase.Dock = DockStyle.Fill;
            this.textEditDatabase.EditValue = "";
            this.textEditDatabase.Location = new Point(0x41, 6);
            this.textEditDatabase.Name = "textEditDatabase";
            this.textEditDatabase.Size = new Size(0x115, 0x15);
            this.textEditDatabase.TabIndex = 0x24;
            this.GroupBox.BackColor = Color.Transparent;
            this.GroupBox.Controls.Add(this.axLicenseControl1);
            this.GroupBox.Controls.Add(this.txtPassWord);
            this.GroupBox.Controls.Add(this.txtUserName);
            this.GroupBox.Controls.Add(this.lblUserName);
            this.GroupBox.Controls.Add(this.lblPassWord);
            this.GroupBox.Controls.Add(this.lblImage);
            this.GroupBox.Dock = DockStyle.Fill;
            this.GroupBox.ForeColor = Color.RoyalBlue;
            this.GroupBox.Location = new Point(10, 6);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new Size(0x14c, 0x58);
            this.GroupBox.TabIndex = 0x25;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "帐号";
            this.txtPassWord.EditValue = "";
            this.txtPassWord.Location = new Point(0x70, 0x34);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.PasswordChar = '*';
            this.txtPassWord.Size = new Size(0x87, 0x15);
            this.txtPassWord.TabIndex = 1;
            this.txtUserName.EditValue = "";
            this.txtUserName.Location = new Point(0x70, 0x15);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new Size(0x87, 0x15);
            this.txtUserName.TabIndex = 0;
            this.lblUserName.BackColor = Color.Transparent;
            this.lblUserName.ForeColor = Color.RoyalBlue;
            this.lblUserName.Location = new Point(0x36, 0x19);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new Size(50, 0x10);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "用户名:";
            this.lblPassWord.BackColor = Color.Transparent;
            this.lblPassWord.ForeColor = Color.RoyalBlue;
            this.lblPassWord.Location = new Point(0x36, 0x37);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new Size(50, 0x10);
            this.lblPassWord.TabIndex = 15;
            this.lblPassWord.Text = "密   码:";
            this.lblImage.BackColor = Color.Transparent;
            this.lblImage.Image = (Image) resources.GetObject("lblImage.Image");
            this.lblImage.Location = new Point(10, 0x15);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new Size(0x26, 0x30);
            this.lblImage.TabIndex = 0x10;
            this.panelResource0.BackColor = Color.Transparent;
            this.panelResource0.Controls.Add(this.textServer);
            this.panelResource0.Controls.Add(this.lblServerName);
            this.panelResource0.Dock = DockStyle.Top;
            this.panelResource0.Location = new Point(0, 2);
            this.panelResource0.Name = "panelResource0";
            this.panelResource0.Padding = new Padding(10, 6, 10, 6);
            this.panelResource0.Size = new Size(0x160, 0x20);
            this.panelResource0.TabIndex = 0x26;
            this.panel1.BackColor = Color.Transparent;
            this.panel1.Controls.Add(this.textEditService);
            this.panel1.Controls.Add(this.lblInstance);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0x22);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10, 6, 10, 6);
            this.panel1.Size = new Size(0x160, 0x20);
            this.panel1.TabIndex = 0x27;
            this.panel2.BackColor = Color.Transparent;
            this.panel2.Controls.Add(this.textEditDatabase);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0x42);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(10, 6, 10, 6);
            this.panel2.Size = new Size(0x160, 0x20);
            this.panel2.TabIndex = 40;
            this.panel3.BackColor = Color.Transparent;
            this.panel3.Controls.Add(this.GroupBox);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 0x62);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(10, 6, 10, 6);
            this.panel3.Size = new Size(0x160, 100);
            this.panel3.TabIndex = 0x29;
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButton1);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.simpleButtonTest);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new Point(0, 0x123);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(7);
            this.panel6.Size = new Size(0x160, 40);
            this.panel6.TabIndex = 0x2a;
            this.simpleButton1.Dock = DockStyle.Left;
            this.simpleButton1.ImageIndex = 0x2e;
            this.simpleButton1.Location = new Point(0x5e, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x47, 0x1a);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.ToolTip = "测试连接";
            this.simpleButton1.Visible = false;
            this.panel10.Dock = DockStyle.Left;
            this.panel10.Location = new Point(0x56, 7);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(8, 0x1a);
            this.panel10.TabIndex = 14;
            this.simpleButtonTest.Dock = DockStyle.Left;
            this.simpleButtonTest.ImageIndex = 0x2e;
            this.simpleButtonTest.Location = new Point(15, 7);
            this.simpleButtonTest.Name = "simpleButtonTest";
            this.simpleButtonTest.Size = new Size(0x47, 0x1a);
            this.simpleButtonTest.TabIndex = 13;
            this.simpleButtonTest.Text = "测试连接";
            this.simpleButtonTest.ToolTip = "测试连接";
            this.simpleButtonTest.Click += new EventHandler(this.simpleButtonTest_Click);
            this.panel9.Dock = DockStyle.Left;
            this.panel9.Location = new Point(7, 7);
            this.panel9.Name = "panel9";
            this.panel9.Size = new Size(8, 0x1a);
            this.panel9.TabIndex = 12;
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.ImageIndex = 0x2e;
            this.simpleButtonOK.Location = new Point(0xc3, 7);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x47, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "应用";
            this.simpleButtonOK.ToolTip = "保存链接参数";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panel4.Dock = DockStyle.Right;
            this.panel4.Location = new Point(0x10a, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(8, 0x1a);
            this.panel4.TabIndex = 11;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.ImageIndex = 0x34;
            this.simpleButtonCancel.Location = new Point(0x112, 7);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x47, 0x1a);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.panel5.Controls.Add(this.textImgServer);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new Point(3, 0x2a);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new Padding(10, 6, 10, 6);
            this.panel5.Size = new Size(340, 0x20);
            this.panel5.TabIndex = 0x2b;
            this.textImgServer.Dock = DockStyle.Fill;
            this.textImgServer.EditValue = "";
            this.textImgServer.Location = new Point(0x55, 6);
            this.textImgServer.Name = "textImgServer";
            this.textImgServer.Properties.AllowNullInput = DefaultBoolean.False;
            this.textImgServer.Size = new Size(0xf5, 0x15);
            this.textImgServer.TabIndex = 0x23;
            this.label2.BackColor = Color.Transparent;
            this.label2.Dock = DockStyle.Left;
            this.label2.ForeColor = Color.RoyalBlue;
            this.label2.Location = new Point(10, 6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4b, 20);
            this.label2.TabIndex = 0x20;
            this.label2.Text = "图像服务器:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.checkBoxSample.AutoSize = true;
            this.checkBoxSample.Location = new Point(0x10, 3);
            this.checkBoxSample.Name = "checkBoxSample";
            this.checkBoxSample.Size = new Size(0x79, 0x12);
            this.checkBoxSample.TabIndex = 0x24;
            this.checkBoxSample.Text = "IP同上服务器设置";
            this.checkBoxSample.UseVisualStyleBackColor = true;
            this.checkBoxSample.CheckedChanged += new EventHandler(this.checkBoxSample_CheckedChanged);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.ForeColor = Color.RoyalBlue;
            this.groupBox1.Location = new Point(3, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x15a, 0x4e);
            this.groupBox1.TabIndex = 0x2c;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "栅格数据服务";
            this.panel7.Controls.Add(this.checkBoxSample);
            this.panel7.Dock = DockStyle.Top;
            this.panel7.Location = new Point(3, 0x12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(340, 0x18);
            this.panel7.TabIndex = 0;
            this.panel8.Controls.Add(this.groupBox1);
            this.panel8.Dock = DockStyle.Top;
            this.panel8.Location = new Point(0, 0xc6);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new Padding(3, 10, 3, 10);
            this.panel8.Size = new Size(0x160, 0x5d);
            this.panel8.TabIndex = 0x2d;
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new Point(0x115, 0x16);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = (AxHost.State) resources.GetObject("axLicenseControl1.OcxState");
            this.axLicenseControl1.Size = new Size(0x20, 0x20);
            this.axLicenseControl1.TabIndex = 0x11;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.panel8);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.panelResource0);
            base.Controls.Add(this.lblClose);
            base.Name = "UserControlDataBaseLogin";
            base.Padding = new Padding(0, 2, 0, 0);
            base.Size = new Size(0x160, 0x152);
            this.textServer.Properties.EndInit();
            this.textEditService.Properties.EndInit();
            this.textEditDatabase.Properties.EndInit();
            this.GroupBox.ResumeLayout(false);
            this.txtPassWord.Properties.EndInit();
            this.txtUserName.Properties.EndInit();
            this.panelResource0.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.textImgServer.Properties.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.axLicenseControl1.EndInit();
            base.ResumeLayout(false);
        }

        private bool Modify()
        {
            try
            {
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "UserID", this.txtUserName.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "Password", this.txtPassWord.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "DataSource", this.textServer.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "InitialCatalog", this.textEditDatabase.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "Service", this.textEditService.Text);
                if (this.groupBox1.Visible)
                {
                    System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.StartupPath + @"\VgsTiledMap.Ags.dll");
                    string str2 = "http://" + this.textImgServer.Text + ":8080/VgsData";
                    configuration.AppSettings.Settings["VgsUrl"].Value = str2;
                    configuration.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ReConnectDB()
        {
        //    UtilFactory.ReSetDBAccess("SqlServer");
            if (EditTask.EditWorkspace != null)
            {
                try
                {
                    EditTask.EditWorkspace = (IFeatureWorkspace) this.m_Workspace;
                }
                catch
                {
                    XtraMessageBox.Show("系统数据库连接遇到问题，请检查配置参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    EditTask.EditWorkspace = null;
                    return false;
                }
            }
            return true;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if ((this.m_Workspace != null) || this.TestConnection(false))
            {
                if (this.Modify())
                {
                    UtilFactory.GetConfigOpt().SetConfigValue2("DataBase", "Initial", "1");
                    if (this.ReConnectDB())
                    {
                        XtraMessageBox.Show("数据库连接参数修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        base.ParentForm.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    XtraMessageBox.Show("数据库连接参数修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void simpleButtonTest_Click(object sender, EventArgs e)
        {
            this.TestConnection(true);
        }

        private bool TestConnection(bool bMess)
        {
            this.m_Workspace = null;
            if ((string.IsNullOrEmpty(this.textEditDatabase.Text) || string.IsNullOrEmpty(this.textServer.Text)) || ((string.IsNullOrEmpty(this.txtPassWord.Text) || string.IsNullOrEmpty(this.textEditService.Text)) || string.IsNullOrEmpty(this.txtUserName.Text)))
            {
                XtraMessageBox.Show("请将信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            try
            {
                if (!this.TestSqlServer())
                {
                    XtraMessageBox.Show("系统数据库连接遇到问题，请检查配置参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                if (!this.TestSdeConnect())
                {
                    XtraMessageBox.Show("地理数据库连接遇到问题，请检查配置参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                if (bMess)
                {
                    XtraMessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TestSdeConnect()
        {
            string text = this.textServer.Text;
            string str2 = this.textEditService.Text;
            string str3 = this.textEditDatabase.Text;
            string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
            string str5 = this.txtUserName.Text;
            string str6 = this.txtPassWord.Text;
            IPropertySet connectionProperties = null;
            IWorkspaceFactory factory = null;
            IWorkspace workspace = null;
            bool flag = false;
            try
            {
                connectionProperties = new PropertySetClass();
                connectionProperties.SetProperty("SERVER", text);
                connectionProperties.SetProperty("INSTANCE", str2);
                connectionProperties.SetProperty("DATABASE", str3);
                connectionProperties.SetProperty("USER", str5);
                connectionProperties.SetProperty("PASSWORD", str6);
                connectionProperties.SetProperty("VERSION", str4);
                factory = new SdeWorkspaceFactoryClass();
                workspace = factory.Open(connectionProperties, 0);
                if (workspace == null)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                m_log.Warn(ex.Message + ex.Source);
                flag = false;
            }
            this.m_Workspace = workspace;
            return flag;
        }

        private bool TestSqlServer()
        {
            string text = this.textServer.Text;
            string str2 = this.textEditDatabase.Text;
            string str3 = this.txtUserName.Text;
            string str4 = this.txtPassWord.Text;
            bool flag = false;
            IDbConnection connection = new SqlConnection();
            try
            {
                string str5 = "Data Source = " + text + ";Initial Catalog = " + str2 + ";User Id = " + str3 + ";Password = " + str4 + ";";
                connection.ConnectionString = str5;
                connection.Open();
                return (connection.State == ConnectionState.Open);
            }
            catch
            {
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }
    }
}

