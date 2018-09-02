namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CreateDatabaseObject : UserControlBase1
    {
        private Server _server;
        private Microsoft.SqlServer.Management.Common.ServerConnection _serverConnection;
        private ComboBoxEdit comboBoxEdit_database;
        private IContainer components;
        private LabelControl labelControl_databases;
        private LabelControl labelControl_sql;
        private MemoEdit memoEdit_sql;
        private SimpleButton simpleButton_run;

        public event Skip SkipEvent;

        public CreateDatabaseObject()
        {
            this.InitializeComponent();
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
            this.memoEdit_sql = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl_sql = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_databases = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_database = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton_run = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_sql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_database.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit_sql
            // 
            this.memoEdit_sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit_sql.Location = new System.Drawing.Point(0, 66);
            this.memoEdit_sql.Name = "memoEdit_sql";
            this.memoEdit_sql.Size = new System.Drawing.Size(552, 166);
            this.memoEdit_sql.TabIndex = 2;
            this.memoEdit_sql.UseOptimizedRendering = true;
            // 
            // labelControl_sql
            // 
            this.labelControl_sql.Location = new System.Drawing.Point(4, 44);
            this.labelControl_sql.Name = "labelControl_sql";
            this.labelControl_sql.Size = new System.Drawing.Size(194, 14);
            this.labelControl_sql.TabIndex = 1;
            this.labelControl_sql.Text = "输入SQL语句（多个语句用;分隔）：";
            // 
            // labelControl_databases
            // 
            this.labelControl_databases.Location = new System.Drawing.Point(4, 14);
            this.labelControl_databases.Name = "labelControl_databases";
            this.labelControl_databases.Size = new System.Drawing.Size(72, 14);
            this.labelControl_databases.TabIndex = 41;
            this.labelControl_databases.Text = "目标数据库：";
            // 
            // comboBoxEdit_database
            // 
            this.comboBoxEdit_database.Location = new System.Drawing.Point(82, 11);
            this.comboBoxEdit_database.Name = "comboBoxEdit_database";
            this.comboBoxEdit_database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_database.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_database.Size = new System.Drawing.Size(197, 20);
            this.comboBoxEdit_database.TabIndex = 1;
            // 
            // simpleButton_run
            // 
            this.simpleButton_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_run.Location = new System.Drawing.Point(467, 247);
            this.simpleButton_run.Name = "simpleButton_run";
            this.simpleButton_run.Size = new System.Drawing.Size(79, 23);
            this.simpleButton_run.TabIndex = 3;
            this.simpleButton_run.Text = "跳过";
            this.simpleButton_run.Click += new System.EventHandler(this.simpleButton_run_Click);
            // 
            // CreateDatabaseObject
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Controls.Add(this.simpleButton_run);
            this.Controls.Add(this.labelControl_databases);
            this.Controls.Add(this.comboBoxEdit_database);
            this.Controls.Add(this.labelControl_sql);
            this.Controls.Add(this.memoEdit_sql);
            this.LookAndFeel.SkinName = "Money Twins";
            this.Name = "CreateDatabaseObject";
            this.Size = new System.Drawing.Size(552, 285);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_sql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_database.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public bool Run()
        {
            if (string.IsNullOrEmpty(this.comboBoxEdit_database.Text))
            {
                XtraMessageBox.Show("请选择数据库");
                return false;
            }
            if (string.IsNullOrEmpty(this.memoEdit_sql.Text))
            {
                XtraMessageBox.Show("请输入SQL语句");
                return false;
            }
            try
            {
                string sqlCommand = this.memoEdit_sql.Text.Replace(";", Environment.NewLine + "go" + Environment.NewLine);
                this._server.Databases[this.comboBoxEdit_database.Text].ExecuteNonQuery(sqlCommand);
                this._serverConnection.Disconnect();
                XtraMessageBox.Show("创建成功！");
            }
            catch
            {
                if (this._serverConnection.IsOpen)
                {
                    this._serverConnection.Disconnect();
                }
                XtraMessageBox.Show("创建失败！");
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

