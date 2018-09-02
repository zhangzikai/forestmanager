namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.vExpress;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.Wmi;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class SqlServerDatabases : UserControlBase1
    {
        private bool _connectState;
        private GDB.SQLServerExpress.vTasks.vExpress.GeoMDFManager _geoMDFManager;
        private ComboBoxEdit comboBoxEdit_Instance;
        private ComboBoxEdit comboBoxEdit_Server;
        private IContainer components;
        private LabelControl labelControl_instance;
        private LabelControl labelControl1;
        private LabelControl lb_psw;
        private LabelControl lb_User;
        private SimpleButton simpleButton_Refresh;
        private TextEdit textEdit_psw;
        private TextEdit textEdit_user;

        public SqlServerDatabases()
        {
            this.InitializeComponent();
            comboBoxEdit_Instance.Text = "";
            //comboBoxEdit_Server.Text = "192.168.0.114";
            //textEdit_user.Text = "sa";
            //textEdit_psw.Text = "sa123456";
        }

        public bool CheckConnection()
        {
            ForestDBServerInfo dBServerInfo = this.GetDBServerInfo();
            if (dBServerInfo != null)
            {
                try
                {
                    this._geoMDFManager = new GDB.SQLServerExpress.vTasks.vExpress.GeoMDFManager(dBServerInfo);
                    object obj2 = this._geoMDFManager.SqlServerConnection.ExecuteScalar("select  @@version");
                    if (obj2 == null)
                    {
                        return false;
                    }                               
                    if (!obj2.ToString().StartsWith("Microsoft SQL Server 2008 R2"))
                    {
                        XtraMessageBox.Show("数据库版本必须是：Microsoft SQL Server 2008 R2！");
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("数据库连接失败！");
                }
            }
            return false;
        }

        private void comboBoxEdit_Server_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.comboBoxEdit_Server.Properties.Items.Count == 0)
            {
                this.LoadDatabaseInstanceEx();
            }
        }

        private void comboBoxEdit_Server_TextChanged(object sender, EventArgs e)
        {
            this.comboBoxEdit_Instance.Properties.Items.Clear();
            if (this.comboBoxEdit_Server.Text.ToUpper() == Dns.GetHostName().ToUpper())
            {
                ManagedComputer computer = new ManagedComputer(this.comboBoxEdit_Server.Text);
                ServerInstanceCollection serverInstances = computer.ServerInstances;
                for (int i = 0; i < serverInstances.Count; i++)
                {
                    ServerInstance instance = serverInstances[i];
                    this.comboBoxEdit_Instance.Properties.Items.Add(instance.Name);
                }
                this.comboBoxEdit_Instance.SelectedIndex = 0;
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

        private string GetConnectionString()
        {
            string text = this.comboBoxEdit_Server.Text;
            if (string.IsNullOrEmpty(this.comboBoxEdit_Instance.Text))
            {
                text = text + text + @"\" + this.comboBoxEdit_Instance.Text;
            }
            return ("Server=" + text + ";Data Source=Master;User ID=" + this.textEdit_user.Text + ";Password=" + this.textEdit_psw.Text);
        }

        public ForestDBServerInfo GetDBServerInfo()
        {
            if ((string.IsNullOrEmpty(this.comboBoxEdit_Server.Text) || string.IsNullOrEmpty(this.textEdit_user.Text)) || string.IsNullOrEmpty(this.textEdit_psw.Text))
            {
                XtraMessageBox.Show("请将信息填写完整！");
                return null;
            }
            string text = this.comboBoxEdit_Server.Text;
            string str2 = this.comboBoxEdit_Instance.Text;
            string str3 = this.textEdit_user.Text;
            string str4 = this.textEdit_psw.Text;
            return new ForestDBServerInfo { 
                InstanceName = str2,
                ServerName = text,
                UserName = str3,
                UserPass = str4
            };
        }

        public IWorkspace GetFeatureWorkspace(string pDatabaseName, out string pPath)
        {
            try
            {
                IPropertySet connectionProperties = new PropertySetClass();
                string text = this.comboBoxEdit_Server.Text;
                if (!string.IsNullOrEmpty(this.comboBoxEdit_Instance.Text))
                {
                    text = text + @"\" + this.comboBoxEdit_Instance.Text;
                }
                connectionProperties.SetProperty("SERVER", text);
                connectionProperties.SetProperty("INSTANCE", "sde:sqlserver:" + text);
                connectionProperties.SetProperty("DATABASE", pDatabaseName);
                connectionProperties.SetProperty("USER", this.textEdit_user.Text);
                connectionProperties.SetProperty("PASSWORD", this.textEdit_psw.Text);
                connectionProperties.SetProperty("VERSION", "dbo.DEFAULT");
                IWorkspaceFactory factory = new SdeWorkspaceFactoryClass();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                pPath = baseDirectory + "Source.sde";
                if (System.IO.File.Exists(pPath))
                {
                    System.IO.File.Delete(pPath);
                }
                factory.Create(baseDirectory, "Source.sde", connectionProperties, 0);
                return factory.Open(connectionProperties, 0);
            }
            catch
            {
                pPath = null;
                return null;
            }
        }

        public ForestGDBInfo GetGDBInfo()
        {
            string text = this.comboBoxEdit_Server.Text;
            string str2 = this.comboBoxEdit_Instance.Text;
            string str3 = this.textEdit_user.Text;
            string str4 = this.textEdit_psw.Text;
            return new ForestGDBInfo { 
                IntanceName = str2,
                ServerName = text,
                UserName = str3,
                UserPass = str4
            };
        }

        private void InitializeComponent()
        {
            this.lb_User = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_user = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_psw = new DevExpress.XtraEditors.TextEdit();
            this.lb_psw = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_Server = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl_instance = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit_Instance = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_psw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Server.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Instance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_User
            // 
            this.lb_User.Location = new System.Drawing.Point(77, 89);
            this.lb_User.Name = "lb_User";
            this.lb_User.Size = new System.Drawing.Size(48, 14);
            this.lb_User.TabIndex = 1;
            this.lb_User.Text = "用户名：";
            // 
            // textEdit_user
            // 
            this.textEdit_user.Location = new System.Drawing.Point(132, 86);
            this.textEdit_user.Name = "textEdit_user";
            this.textEdit_user.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEdit_user.Size = new System.Drawing.Size(197, 20);
            this.textEdit_user.TabIndex = 2;
            // 
            // textEdit_psw
            // 
            this.textEdit_psw.Location = new System.Drawing.Point(132, 116);
            this.textEdit_psw.Name = "textEdit_psw";
            this.textEdit_psw.Size = new System.Drawing.Size(197, 20);
            this.textEdit_psw.TabIndex = 4;
            // 
            // lb_psw
            // 
            this.lb_psw.Location = new System.Drawing.Point(77, 119);
            this.lb_psw.Name = "lb_psw";
            this.lb_psw.Size = new System.Drawing.Size(48, 14);
            this.lb_psw.TabIndex = 3;
            this.lb_psw.Text = "密   码：";
            // 
            // comboBoxEdit_Server
            // 
            this.comboBoxEdit_Server.Location = new System.Drawing.Point(132, 26);
            this.comboBoxEdit_Server.Name = "comboBoxEdit_Server";
            this.comboBoxEdit_Server.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Server.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.comboBoxEdit_Server_Properties_ButtonClick);
            this.comboBoxEdit_Server.Size = new System.Drawing.Size(197, 20);
            this.comboBoxEdit_Server.TabIndex = 6;
            this.comboBoxEdit_Server.ToolTip = "远程机器必须和本机在同一工作组，否则，请使用输入的方式";
            this.comboBoxEdit_Server.TextChanged += new System.EventHandler(this.comboBoxEdit_Server_TextChanged);
            // 
            // labelControl_instance
            // 
            this.labelControl_instance.Location = new System.Drawing.Point(18, 29);
            this.labelControl_instance.Name = "labelControl_instance";
            this.labelControl_instance.Size = new System.Drawing.Size(108, 14);
            this.labelControl_instance.TabIndex = 7;
            this.labelControl_instance.Text = "选择或输入服务器：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "选择或输入实例名：";
            // 
            // simpleButton_Refresh
            // 
            this.simpleButton_Refresh.Location = new System.Drawing.Point(347, 25);
            this.simpleButton_Refresh.Name = "simpleButton_Refresh";
            this.simpleButton_Refresh.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Refresh.TabIndex = 10;
            this.simpleButton_Refresh.Text = "刷新";
            this.simpleButton_Refresh.Click += new System.EventHandler(this.simpleButton_Refresh_Click);
            // 
            // comboBoxEdit_Instance
            // 
            this.comboBoxEdit_Instance.Location = new System.Drawing.Point(132, 56);
            this.comboBoxEdit_Instance.Name = "comboBoxEdit_Instance";
            this.comboBoxEdit_Instance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Instance.Size = new System.Drawing.Size(197, 20);
            this.comboBoxEdit_Instance.TabIndex = 11;
            this.comboBoxEdit_Instance.ToolTip = "如果是默认实例,否则设为空";
            // 
            // SqlServerDatabases
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.comboBoxEdit_Instance);
            this.Controls.Add(this.simpleButton_Refresh);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl_instance);
            this.Controls.Add(this.comboBoxEdit_Server);
            this.Controls.Add(this.textEdit_psw);
            this.Controls.Add(this.lb_psw);
            this.Controls.Add(this.textEdit_user);
            this.Controls.Add(this.lb_User);
            this.LookAndFeel.SkinName = "Money Twins";
            this.Name = "SqlServerDatabases";
            this.Size = new System.Drawing.Size(429, 152);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_psw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Server.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Instance.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadDatabaseInstance()
        {
            DataTable dataSources = SqlClientFactory.Instance.CreateDataSourceEnumerator().GetDataSources();
            if ((dataSources == null) || (dataSources.Rows.Count == 0))
            {
                XtraMessageBox.Show("找不到可用SqlServer数据库服务器！");
            }
            else
            {
                DataColumn column = dataSources.Columns["InstanceName"];
                DataColumn column2 = dataSources.Columns["ServerName"];
                DataRowCollection rows = dataSources.Rows;
                string item = string.Empty;
                foreach (DataRow row in dataSources.Rows)
                {
                    string str2 = row[column2] as string;
                    string str3 = row[column] as string;
                    if (((str3 == null) || (str3.Length == 0)) || ("MSSQLSERVER" == str3))
                    {
                        this.comboBoxEdit_Server.Properties.Items.Add(str2);
                    }
                    else
                    {
                        item = str2 + @"\" + str3;
                        this.comboBoxEdit_Server.Properties.Items.Add(item);
                    }
                }
            }
        }

        private void LoadDatabaseInstanceEx()
        {
            DataTable table = SmoApplication.EnumAvailableSqlServers();
            if ((table == null) || (table.Rows.Count == 0))
            {
                XtraMessageBox.Show("找不到可用SqlServer数据库服务器！");
            }
            else
            {
                DataColumn column = table.Columns["Server"];
                DataRowCollection rows = table.Rows;
                string item = string.Empty;
                foreach (DataRow row in table.Rows)
                {
                    item = row[column] as string;
                    this.comboBoxEdit_Server.Properties.Items.Add(item);
                }
                this.comboBoxEdit_Server.SelectedIndex = 0;
            }
        }

        private void LoadDatabaseInstanceExx()
        {
            DataTable dataSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in dataSources.Rows)
            {
                foreach (DataColumn column in dataSources.Columns)
                {
                    object obj1 = row[column];
                }
            }
        }

        private void simpleButton_Refresh_Click(object sender, EventArgs e)
        {
            this.comboBoxEdit_Server.Properties.Items.Clear();
            this.LoadDatabaseInstanceEx();
        }

        public bool ConnectState
        {
            get
            {
                return this._connectState;
            }
        }

        public GDB.SQLServerExpress.vTasks.vExpress.GeoMDFManager GeoMDFManager
        {
            get
            {
                return this._geoMDFManager;
            }
        }
    }
}

