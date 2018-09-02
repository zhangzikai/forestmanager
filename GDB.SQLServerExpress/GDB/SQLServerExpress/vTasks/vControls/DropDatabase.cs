namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using GDB.SQLServerExpress.vTasks.vForms;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DropDatabase : XtraUserControl
    {
        private Server _server;
        private Microsoft.SqlServer.Management.Common.ServerConnection _serverConnection;
        private ButtonEdit bntEdit_dataDir;
        private ComboBoxEdit comboBoxEdit_database;
        private ComboBoxEdit comboBoxEdit_FlDatabase;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private LabelControl labelControl_databases;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private SimpleButton sb_Skip;

        public event Skip SkipEvent;

        public DropDatabase()
        {
            this.InitializeComponent();
        }

        private void bntEdit_dataDir_Properties_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            if (!this._serverConnection.IsOpen)
            {
                this._serverConnection.Connect();
            }
            this._server = new Server(this._serverConnection);
            if (hostName.ToUpper() != this._server.NetName.ToUpper())
            {
                XtraMessageBox.Show("该功能只支持本机Sqlserver实例");
            }
            else
            {
                ServerDirectory directory = new ServerDirectory();
                directory.Init(this._serverConnection, true, true);
                if (directory.ShowDialog() == DialogResult.OK)
                {
                    this.bntEdit_dataDir.Text = directory.Path;
                    this.bntEdit_dataDir.ForeColor = Color.Black;
                }
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
            this.sb_Skip = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bntEdit_dataDir = new DevExpress.XtraEditors.ButtonEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl_databases = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_database = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_FlDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_database.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_FlDatabase.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sb_Skip
            // 
            this.sb_Skip.Location = new System.Drawing.Point(430, 243);
            this.sb_Skip.Name = "sb_Skip";
            this.sb_Skip.Size = new System.Drawing.Size(75, 23);
            this.sb_Skip.TabIndex = 4;
            this.sb_Skip.Text = "跳过";
            this.sb_Skip.Click += new System.EventHandler(this.simpleButton_run_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.bntEdit_dataDir);
            this.groupBox1.Location = new System.Drawing.Point(19, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 63);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "附加数据库";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "数据库存放路径：";
            // 
            // bntEdit_dataDir
            // 
            this.bntEdit_dataDir.EditValue = "";
            this.bntEdit_dataDir.Location = new System.Drawing.Point(117, 24);
            this.bntEdit_dataDir.Name = "bntEdit_dataDir";
            this.bntEdit_dataDir.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bntEdit_dataDir.Properties.Appearance.Options.UseForeColor = true;
            this.bntEdit_dataDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bntEdit_dataDir.Properties.Click += new System.EventHandler(this.bntEdit_dataDir_Properties_Click);
            this.bntEdit_dataDir.Size = new System.Drawing.Size(341, 20);
            this.bntEdit_dataDir.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl_databases);
            this.groupBox2.Controls.Add(this.comboBoxEdit_database);
            this.groupBox2.Location = new System.Drawing.Point(19, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 63);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "删除数据库";
            // 
            // labelControl_databases
            // 
            this.labelControl_databases.Location = new System.Drawing.Point(63, 33);
            this.labelControl_databases.Name = "labelControl_databases";
            this.labelControl_databases.Size = new System.Drawing.Size(48, 14);
            this.labelControl_databases.TabIndex = 43;
            this.labelControl_databases.Text = "数据库：";
            // 
            // comboBoxEdit_database
            // 
            this.comboBoxEdit_database.Location = new System.Drawing.Point(117, 30);
            this.comboBoxEdit_database.Name = "comboBoxEdit_database";
            this.comboBoxEdit_database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_database.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_database.Size = new System.Drawing.Size(197, 20);
            this.comboBoxEdit_database.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelControl2);
            this.groupBox3.Controls.Add(this.comboBoxEdit_FlDatabase);
            this.groupBox3.Location = new System.Drawing.Point(19, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 63);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分离数据库";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(63, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 43;
            this.labelControl2.Text = "数据库：";
            // 
            // comboBoxEdit_FlDatabase
            // 
            this.comboBoxEdit_FlDatabase.Location = new System.Drawing.Point(117, 26);
            this.comboBoxEdit_FlDatabase.Name = "comboBoxEdit_FlDatabase";
            this.comboBoxEdit_FlDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_FlDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_FlDatabase.Size = new System.Drawing.Size(197, 20);
            this.comboBoxEdit_FlDatabase.TabIndex = 2;
            // 
            // DropDatabase
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sb_Skip);
            this.Name = "DropDatabase";
            this.Size = new System.Drawing.Size(533, 274);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_database.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_FlDatabase.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadDatabases()
        {
            this.comboBoxEdit_database.Properties.Items.Clear();
            if (!this._serverConnection.IsOpen)
            {
                this._serverConnection.Connect();
            }
            this._server = new Server(this._serverConnection);
            foreach (Database database in this._server.Databases)
            {
                this.comboBoxEdit_database.Properties.Items.Add(database.Name);
            }
            this.comboBoxEdit_database.Text = "";
        }

        public void LoadDatabasesEx()
        {
            this.comboBoxEdit_FlDatabase.Properties.Items.Clear();
            foreach (string str in this.comboBoxEdit_database.Properties.Items)
            {
                this.comboBoxEdit_FlDatabase.Properties.Items.Add(str);
            }
            this.comboBoxEdit_FlDatabase.Text = "";
        }

        public bool Run()
        {
            try
            {
                if (!this._serverConnection.IsOpen)
                {
                    this._serverConnection.Connect();
                }
                this._server = new Server(this._serverConnection);
                bool flag = false;
                if (!string.IsNullOrEmpty(this.comboBoxEdit_database.Text))
                {
                    Database database = this._server.Databases[this.comboBoxEdit_database.Text];
                    if (database != null)
                    {
                        this._server.KillAllProcesses(this.comboBoxEdit_database.Text);
                        database.Drop();
                        flag = true;
                    }
                }
                if (!string.IsNullOrEmpty(this.comboBoxEdit_FlDatabase.Text) && (this._server.Databases[this.comboBoxEdit_FlDatabase.Text] != null))
                {
                    this._server.KillAllProcesses(this.comboBoxEdit_FlDatabase.Text);
                    this._server.DetachDatabase(this.comboBoxEdit_FlDatabase.Text, true);
                    flag = true;
                }
                if (!string.IsNullOrEmpty(this.bntEdit_dataDir.Text))
                {
                    StringCollection files = new StringCollection();
                    string str = this.bntEdit_dataDir.Text.Remove(this.bntEdit_dataDir.Text.Length - 1);
                    files.Add(str);
                    int length = this.bntEdit_dataDir.Text.LastIndexOf(".mdf");
                    string path = this.bntEdit_dataDir.Text.Substring(0, length) + ".ldf";
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                    files.Add(path);
                    this._server.AttachDatabase(fileNameWithoutExtension, files);
                    flag = true;
                }
                if (flag)
                {
                    XtraMessageBox.Show("执行成功！");
                }
                this.LoadDatabases();
                this.LoadDatabasesEx();
                this._serverConnection.Disconnect();
            }
            catch
            {
                if (this._serverConnection.IsOpen)
                {
                    this._serverConnection.Disconnect();
                }
                XtraMessageBox.Show("执行失败！");
                return false;
            }
            return true;
        }

        private void simpleButton_run_Click(object sender, EventArgs e)
        {
            if (this.SkipEvent != null)
            {
                this.SkipEvent();
            }
        }

        public Microsoft.SqlServer.Management.Common.ServerConnection ServerConnection
        {
            set
            {
                this._serverConnection = value;
            }
        }

        public delegate void Skip();
    }
}

