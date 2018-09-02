namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class UserControlDataBaseLogin : UserControlBase1
    {
        private IContainer components = null;
        internal System.Windows.Forms.GroupBox GroupBox;
        internal Label label1;
        internal Label lblClose;
        internal Label lblImage;
        internal Label lblInstance;
        internal Label lblPassWord;
        internal Label lblServerName;
        internal Label lblUserName;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        private Panel panelResource0;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        private TextEdit textEditDatabase;
        private TextEdit textEditService;
        private TextEdit textServer;
        private TextEdit txtPassWord;
        private TextEdit txtUserName;

        public UserControlDataBaseLogin()
        {
            this.InitializeComponent();
            this.init();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void init()
        {
            this.txtUserName.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
            this.txtPassWord.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
            this.textServer.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
            this.textEditDatabase.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            this.textEditService.Text = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
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
            this.simpleButtonOK = new SimpleButton();
            this.panel4 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
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
            this.textServer.Size = new Size(0xec, 0x15);
            this.textServer.TabIndex = 0x22;
            this.textEditService.Dock = DockStyle.Fill;
            this.textEditService.EditValue = @"sde:sqlserver:10.2.10.240\sdeworkgroup";
            this.textEditService.Location = new Point(0x41, 6);
            this.textEditService.Name = "textEditService";
            this.textEditService.Size = new Size(0xec, 0x15);
            this.textEditService.TabIndex = 0x23;
            this.textEditDatabase.Dock = DockStyle.Fill;
            this.textEditDatabase.EditValue = "";
            this.textEditDatabase.Location = new Point(0x41, 6);
            this.textEditDatabase.Name = "textEditDatabase";
            this.textEditDatabase.Size = new Size(0xec, 0x15);
            this.textEditDatabase.TabIndex = 0x24;
            this.GroupBox.BackColor = Color.Transparent;
            this.GroupBox.Controls.Add(this.txtPassWord);
            this.GroupBox.Controls.Add(this.txtUserName);
            this.GroupBox.Controls.Add(this.lblUserName);
            this.GroupBox.Controls.Add(this.lblPassWord);
            this.GroupBox.Controls.Add(this.lblImage);
            this.GroupBox.Dock = DockStyle.Fill;
            this.GroupBox.ForeColor = Color.RoyalBlue;
            this.GroupBox.Location = new Point(10, 6);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new Size(0x123, 0x58);
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
            this.panelResource0.Size = new Size(0x137, 0x20);
            this.panelResource0.TabIndex = 0x26;
            this.panel1.BackColor = Color.Transparent;
            this.panel1.Controls.Add(this.textEditService);
            this.panel1.Controls.Add(this.lblInstance);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0x22);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10, 6, 10, 6);
            this.panel1.Size = new Size(0x137, 0x20);
            this.panel1.TabIndex = 0x27;
            this.panel2.BackColor = Color.Transparent;
            this.panel2.Controls.Add(this.textEditDatabase);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0x42);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(10, 6, 10, 6);
            this.panel2.Size = new Size(0x137, 0x20);
            this.panel2.TabIndex = 40;
            this.panel3.BackColor = Color.Transparent;
            this.panel3.Controls.Add(this.GroupBox);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 0x62);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(10, 6, 10, 6);
            this.panel3.Size = new Size(0x137, 100);
            this.panel3.TabIndex = 0x29;
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new Point(0, 0xc6);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(7);
            this.panel6.Size = new Size(0x137, 40);
            this.panel6.TabIndex = 0x2a;
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.ImageIndex = 0x2e;
            this.simpleButtonOK.Location = new Point(0x9a, 7);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x47, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.ToolTip = "保存链接参数";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panel4.Dock = DockStyle.Right;
            this.panel4.Location = new Point(0xe1, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(8, 0x1a);
            this.panel4.TabIndex = 11;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.ImageIndex = 0x34;
            this.simpleButtonCancel.Location = new Point(0xe9, 7);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x47, 0x1a);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.panelResource0);
            base.Controls.Add(this.lblClose);
            base.Name = "UserControlDataBaseLogin";
            base.Padding = new Padding(0, 2, 0, 0);
            base.Size = new Size(0x137, 0xf5);
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
            base.ResumeLayout(false);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.ParentForm.DialogResult = DialogResult.Cancel;
        }
        private MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (((string.IsNullOrEmpty(this.textEditDatabase.Text) || string.IsNullOrEmpty(this.textServer.Text)) || (string.IsNullOrEmpty(this.txtPassWord.Text) || string.IsNullOrEmpty(this.textEditService.Text))) || string.IsNullOrEmpty(this.txtUserName.Text))
            {
                XtraMessageBox.Show("请将信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                UtilFactory.GetConfigOpt().SetConfigValue("DBKey", "SqlServer");
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "UserID", this.txtUserName.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "Password", this.txtPassWord.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "DataSource", this.textServer.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "InitialCatalog", this.textEditDatabase.Text);
                UtilFactory.GetConfigOpt().SetConfigValue2("SqlServer", "Service", this.textEditService.Text);
                string connStr = "Data Source=" + textEditService.Text + ";Initial Catalog=" + this.textEditDatabase.Text;
                connStr += ";User Id=" + this.txtUserName.Text + ";Password=" + this.txtPassWord.Text + ";";
                MDM.ConnectionString = connStr;            
               // DBAccessBase dBAccess = UtilFactory.GetDBAccess("SqlServer") as DBAccessBase;
                if (!MDM.IsOpen)
                {
                    XtraMessageBox.Show("数据库连接遇到问题，请检查配置参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    UtilFactory.GetConfigOpt().SetConfigValue2("DataBase", "Initial", "1");
                    base.ParentForm.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}

