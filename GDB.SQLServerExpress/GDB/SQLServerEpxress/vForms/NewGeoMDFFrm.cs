namespace GDB.SQLServerEpxress.vForms
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks.vControls;
    using GDB.SQLServerExpress.vTasks.vTasks;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class NewGeoMDFFrm : Form
    {
        private ForestProgressMessageBox _forMsgBox;
        private SimpleButton bnt_cancel;
        private SimpleButton bnt_newDb;
        private IContainer components;
        private FolderBrowserDialog folderBrowserDialog1;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private NewForestGDBTemplateTask newGdbTask;
        private PanelControl panelControl1;
        private SqlExprConfigControl sqlExpress_config;
        private TextEdit txt_dbName;
        private ButtonEdit txt_dbPath;
        private Stopwatch watcher;

        public NewGeoMDFFrm()
        {
            this.InitializeComponent();
        }

        private void bnt_cancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void bnt_newDb_Click(object sender, EventArgs e)
        {
            base.Enabled = false;
            if (this._forMsgBox != null)
            {
                this._forMsgBox.Close();
                this._forMsgBox = null;
            }
            this.newGdbTask = new NewForestGDBTemplateTask();
            this.newGdbTask.TaskStatusChanged += new TaskEventHandler(this.OnTaskStatusChanged);
            this._forMsgBox = new ForestProgressMessageBox();
            this._forMsgBox.initStatus();
            this.newGdbTask.TaskProgressChanged += new TaskEventHandler(this._forMsgBox.OnProgressDataChanged);
            ThreadStart start = new ThreadStart(this.startCreate);
            new Thread(start).Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private ForestGDBInfo genGdbInfo()
        {
            return new ForestGDBInfo { 
                DBName = this.txt_dbName.Text,
                GDBDir = this.txt_dbPath.Text,
                ServerName = this.sqlExpress_config.ServerName,
                UserName = this.sqlExpress_config.UserName,
                UserPass = this.sqlExpress_config.UserPass,
                IntanceName = this.sqlExpress_config.InstanceName
            };
        }

        private void InitializeComponent()
        {
            this.sqlExpress_config = new GDB.SQLServerExpress.vTasks.vControls.SqlExprConfigControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bnt_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.bnt_newDb = new DevExpress.XtraEditors.SimpleButton();
            this.txt_dbName = new DevExpress.XtraEditors.TextEdit();
            this.txt_dbPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dbPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlExpress_config
            // 
            this.sqlExpress_config.Dock = System.Windows.Forms.DockStyle.Top;
            this.sqlExpress_config.InstanceName = "sqlexpress";
            this.sqlExpress_config.Location = new System.Drawing.Point(0, 0);
            this.sqlExpress_config.Name = "sqlExpress_config";
            this.sqlExpress_config.ServerName = "trung";
            this.sqlExpress_config.Size = new System.Drawing.Size(471, 125);
            this.sqlExpress_config.TabIndex = 0;
            this.sqlExpress_config.UserName = "sa";
            this.sqlExpress_config.UserPass = "123456";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bnt_cancel);
            this.panelControl1.Controls.Add(this.bnt_newDb);
            this.panelControl1.Controls.Add(this.txt_dbName);
            this.panelControl1.Controls.Add(this.txt_dbPath);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 125);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(471, 115);
            this.panelControl1.TabIndex = 1;
            // 
            // bnt_cancel
            // 
            this.bnt_cancel.Location = new System.Drawing.Point(356, 76);
            this.bnt_cancel.Name = "bnt_cancel";
            this.bnt_cancel.Size = new System.Drawing.Size(86, 27);
            this.bnt_cancel.TabIndex = 3;
            this.bnt_cancel.Text = "取消";
            this.bnt_cancel.Click += new System.EventHandler(this.bnt_cancel_Click);
            // 
            // bnt_newDb
            // 
            this.bnt_newDb.Location = new System.Drawing.Point(232, 76);
            this.bnt_newDb.Name = "bnt_newDb";
            this.bnt_newDb.Size = new System.Drawing.Size(86, 27);
            this.bnt_newDb.TabIndex = 3;
            this.bnt_newDb.Text = "新建...";
            this.bnt_newDb.Click += new System.EventHandler(this.bnt_newDb_Click);
            // 
            // txt_dbName
            // 
            this.txt_dbName.Location = new System.Drawing.Point(126, 12);
            this.txt_dbName.Name = "txt_dbName";
            this.txt_dbName.Size = new System.Drawing.Size(321, 20);
            this.txt_dbName.TabIndex = 2;
            // 
            // txt_dbPath
            // 
            this.txt_dbPath.Location = new System.Drawing.Point(126, 49);
            this.txt_dbPath.Name = "txt_dbPath";
            this.txt_dbPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_dbPath.Size = new System.Drawing.Size(321, 20);
            this.txt_dbPath.TabIndex = 1;
            this.txt_dbPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_dbPath_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "数据库名称：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "选择数据库存放路径:";
            // 
            // NewGeoMDFFrm
            // 
            this.ClientSize = new System.Drawing.Size(471, 240);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.sqlExpress_config);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGeoMDFFrm";
            this.Text = "新建空GeoMDF库";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dbPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void OnTaskStatusChanged(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnTaskStatusChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else if (e.Status == TaskStatus.Stopped)
            {
                base.Enabled = true;
                string msg = "GeoMDF库建立完成!";
                if (this.watcher != null)
                {
                    this.watcher.Stop();
                    msg = msg + "共耗时:" + this.watcher.Elapsed.ToString();
                }
                if (this._forMsgBox != null)
                {
                    this._forMsgBox.AddProgressMessage(msg);
                    if (this.newGdbTask != null)
                    {
                        this.newGdbTask.TaskProgressChanged -= new TaskEventHandler(this._forMsgBox.OnProgressDataChanged);
                    }
                }
                XtraMessageBox.Show(msg);
                if (this._forMsgBox != null)
                {
                    this._forMsgBox.Visible = false;
                    this._forMsgBox.Close();
                    this._forMsgBox.Dispose();
                    this._forMsgBox = null;
                }
            }
        }

        private void ShowProgressWindow()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(this.ShowProgressWindow));
            }
            else if (this._forMsgBox != null)
            {
                this._forMsgBox.TopMost = true;
                this._forMsgBox.Show(this);
            }
        }

        private void startCreate()
        {
            ForestGDBInfo info = this.genGdbInfo();
            if (string.IsNullOrEmpty(info.GDBDir))
            {
                XtraMessageBox.Show("未设置数据存储路径!");
            }
            else
            {
                if ((this.watcher != null) && this.watcher.IsRunning)
                {
                    this.watcher.Stop();
                }
                this.watcher = new Stopwatch();
                this.watcher.Start();
                this.newGdbTask.StartTask(new TaskDelegate(this.newGdbTask.Work), new object[] { info });
                this.ShowProgressWindow();
            }
        }

        private void txt_dbPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                this.txt_dbPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

