namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks.Forest;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SqlExprConfigControl : UserControl
    {
        private SimpleButton bnt_testDb;
        private IContainer components;
        private GroupControl groupControl1;
        private LabelControl label_info;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private TextEdit txt_instance;
        private TextEdit txt_passwd;
        private TextEdit txt_server;
        private TextEdit txt_user;

        public event GeodbTestHandler OnGdbTestSuccess;

        public SqlExprConfigControl()
        {
            this.InitializeComponent();
            this.txt_server.Text = Dns.GetHostName();
        }

        public void bnt_testDb_Click(object sender, EventArgs e)
        {
            string text = this.txt_server.Text;
            string str2 = this.txt_instance.Text;
            string str3 = this.txt_user.Text;
            string str4 = this.txt_passwd.Text;
            ForestGDBInfo wkGdbInfo = new ForestGDBInfo {
                ServerName = text,
                IntanceName = str2,
                UserName = str3,
                UserPass = str4
            };
            ForestGDBManager manager = new ForestGDBManager(wkGdbInfo);
            if (manager.IsServerOnLine())
            {
                this.label_info.Text = "服务器在线，同时可进行数据库管理操作!";
                if (this.OnGdbTestSuccess != null)
                {
                    this.OnGdbTestSuccess(this, "数据库服务器测试成功!");
                }
            }
            else
            {
                this.label_info.Text = "服务器不能访问，或不能进行数据库管理操作,!";
            }
            manager.Release();
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label_info = new DevExpress.XtraEditors.LabelControl();
            this.bnt_testDb = new DevExpress.XtraEditors.SimpleButton();
            this.txt_passwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_instance = new DevExpress.XtraEditors.TextEdit();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_server = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_passwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_instance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_server.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label_info);
            this.groupControl1.Controls.Add(this.bnt_testDb);
            this.groupControl1.Controls.Add(this.txt_passwd);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txt_instance);
            this.groupControl1.Controls.Add(this.txt_user);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txt_server);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(459, 129);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "空间数据库服务器连接配置";
            // 
            // label_info
            // 
            this.label_info.Location = new System.Drawing.Point(11, 101);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(0, 14);
            this.label_info.TabIndex = 12;
            // 
            // bnt_testDb
            // 
            this.bnt_testDb.Location = new System.Drawing.Point(371, 92);
            this.bnt_testDb.Name = "bnt_testDb";
            this.bnt_testDb.Size = new System.Drawing.Size(75, 23);
            this.bnt_testDb.TabIndex = 5;
            this.bnt_testDb.Text = "测试";
            this.bnt_testDb.Click += new System.EventHandler(this.bnt_testDb_Click);
            // 
            // txt_passwd
            // 
            this.txt_passwd.EditValue = "123456";
            this.txt_passwd.Location = new System.Drawing.Point(297, 63);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(151, 20);
            this.txt_passwd.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(218, 66);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "密   码：";
            // 
            // txt_instance
            // 
            this.txt_instance.EditValue = "sqlexpress";
            this.txt_instance.Location = new System.Drawing.Point(90, 63);
            this.txt_instance.Name = "txt_instance";
            this.txt_instance.Size = new System.Drawing.Size(115, 20);
            this.txt_instance.TabIndex = 2;
            // 
            // txt_user
            // 
            this.txt_user.EditValue = "sa";
            this.txt_user.Location = new System.Drawing.Point(297, 36);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(151, 20);
            this.txt_user.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "服务实例名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(218, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "用户名：";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(90, 36);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(115, 20);
            this.txt_server.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "服务器名称：";
            // 
            // SqlExprConfigControl
            // 
            this.Controls.Add(this.groupControl1);
            this.Name = "SqlExprConfigControl";
            this.Size = new System.Drawing.Size(459, 129);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_passwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_instance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_server.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void ShowMessageInfo(string info)
        {
            this.label_info.Text = info;
            this.label_info.Refresh();
        }

        public void ShowTestButton()
        {
        }

        public string InstanceName
        {
            get
            {
                return this.txt_instance.Text;
            }
            set
            {
                this.txt_instance.Text = value;
            }
        }

        public ForestDBServerInfo ServerInfo
        {
            get
            {
                return new ForestDBServerInfo { 
                    ServerName = this.ServerName,
                    InstanceName = this.InstanceName,
                    UserName = this.UserName,
                    UserPass = this.UserPass
                };
            }
        }

        public string ServerName
        {
            get
            {
                return this.txt_server.Text;
            }
            set
            {
                this.txt_server.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.txt_user.Text;
            }
            set
            {
                this.txt_user.Text = value;
            }
        }

        public string UserPass
        {
            get
            {
                return this.txt_passwd.Text;
            }
            set
            {
                this.txt_passwd.Text = value;
            }
        }

        public delegate void GeodbTestHandler(object sender, string msg);
    }
}

