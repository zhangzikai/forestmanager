namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.vExpress;
    using GDB.SQLServerExpress.vTasks.vForms;
    using GDB.SQLServerExpress.vTasks.vTasks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    public class ForestGeoDataLoadControl : XtraUserControl
    {
        private SimpleButton bnt_LoadGeoData;
        private IContainer components;
        private TreeListColumn dbName;
        private string fileGdbPath = string.Empty;
        private ForestDataLoadTask geoTask;
        private GroupControl groupControl1;
        private ForestProgressMessageBox messageBox;
        private SqlExprConfigControl sqlExprConfigControl1;
        private ToolTipController toolTipController1;
        private TreeList tree_dbNames;
        private Stopwatch watcher;

        public ForestGeoDataLoadControl()
        {
            this.InitializeComponent();
            this.sqlExprConfigControl1.ServerName = Dns.GetHostName();
        }

        private void bnt_LoadGeoData_Click(object sender, EventArgs e)
        {
            FileGeoDataSelectFrm frm = new FileGeoDataSelectFrm();
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                this.fileGdbPath = frm.FileGDBPath;
                if (string.IsNullOrEmpty(this.fileGdbPath))
                {
                    XtraMessageBox.Show("未设置源数据路径!");
                }
                else
                {
                    if (this.messageBox != null)
                    {
                        this.messageBox.Close();
                        this.messageBox = null;
                    }
                    ForestDBServerInfo serverInfo = this.sqlExprConfigControl1.ServerInfo;
                    if (((serverInfo != null) && !string.IsNullOrEmpty(serverInfo.InstanceName)) && !string.IsNullOrEmpty(serverInfo.ServerName))
                    {
                        this.geoTask = new ForestDataLoadTask(string.Empty);
                        this.geoTask.TaskStatusChanged += new TaskEventHandler(this.OnTaskStatusChanged);
                        this.geoTask.TaskThrowError += new TaskEventHandler(this.geoTask_TaskThrowError);
                        this.messageBox = new ForestProgressMessageBox();
                        this.messageBox.initStatus();
                        this.geoTask.TaskProgressChanged += new TaskEventHandler(this.messageBox.OnProgressDataChanged);
                        ThreadStart start = new ThreadStart(this.StartGeoTask);
                        new Thread(start).Start();
                        frm.Close();
                        frm = null;
                    }
                }
            }
            else
            {
                frm.Close();
                frm = null;
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

        private void geoTask_TaskThrowError(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnTaskStatusChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else
            {
                string msg = "数据处理完成!";
                if (this.watcher != null)
                {
                    this.watcher.Stop();
                    msg = msg + "共耗时:" + this.watcher.Elapsed.ToString();
                }
                if (this.messageBox != null)
                {
                    this.messageBox.AddProgressMessage(msg);
                    if (this.geoTask != null)
                    {
                        this.geoTask.TaskProgressChanged -= new TaskEventHandler(this.messageBox.OnProgressDataChanged);
                        this.geoTask.TaskStatusChanged -= new TaskEventHandler(this.OnTaskStatusChanged);
                        this.geoTask.TaskThrowError -= new TaskEventHandler(this.geoTask_TaskThrowError);
                        this.geoTask = null;
                    }
                }
                XtraMessageBox.Show(msg);
                if (this.messageBox != null)
                {
                    this.messageBox.Visible = false;
                    this.messageBox.Close();
                    this.messageBox.Dispose();
                    this.messageBox = null;
                }
            }
        }

        private GeoMDFManager GetManager()
        {
            ForestDBServerInfo serverInfo = this.sqlExprConfigControl1.ServerInfo;
            if (((serverInfo != null) && !string.IsNullOrEmpty(serverInfo.InstanceName)) && !string.IsNullOrEmpty(serverInfo.ServerName))
            {
                return new GeoMDFManager(serverInfo);
            }
            return null;
        }

        private List<string> GetUserSelectedDBS()
        {
            List<string> list = new List<string>();
            foreach (TreeListNode node in this.tree_dbNames.Nodes)
            {
                if ((node != null) && node.Checked)
                {
                    object obj2 = node.GetValue(0);
                    if (obj2 != null)
                    {
                        list.Add(obj2 as string);
                    }
                }
            }
            return list;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.sqlExprConfigControl1 = new SqlExprConfigControl();
            this.groupControl1 = new GroupControl();
            this.tree_dbNames = new TreeList();
            this.dbName = new TreeListColumn();
            this.bnt_LoadGeoData = new SimpleButton();
            this.toolTipController1 = new ToolTipController(this.components);
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.tree_dbNames.BeginInit();
            base.SuspendLayout();
            this.sqlExprConfigControl1.Dock = DockStyle.Top;
            this.sqlExprConfigControl1.InstanceName = "sqlexpress";
            this.sqlExprConfigControl1.Location = new Point(0, 0);
            this.sqlExprConfigControl1.Name = "sqlExprConfigControl1";
            this.sqlExprConfigControl1.ServerName = "trung";
            this.sqlExprConfigControl1.Size = new Size(0x218, 0x92);
            this.sqlExprConfigControl1.TabIndex = 0;
            this.sqlExprConfigControl1.UserName = "sa";
            this.sqlExprConfigControl1.UserPass = "123456";
            this.sqlExprConfigControl1.OnGdbTestSuccess += new SqlExprConfigControl.GeodbTestHandler(this.sqlExprConfigControl1_OnGdbTestSuccess);
            this.groupControl1.Controls.Add(this.tree_dbNames);
            this.groupControl1.Dock = DockStyle.Left;
            this.groupControl1.Location = new Point(0, 0x92);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x176, 0xfc);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "选择数据库";
            this.tree_dbNames.Columns.AddRange(new TreeListColumn[] { this.dbName });
            this.tree_dbNames.Dock = DockStyle.Fill;
            this.tree_dbNames.Location = new Point(2, 0x17);
            this.tree_dbNames.Name = "tree_dbNames";
            this.tree_dbNames.OptionsBehavior.Editable = false;
            this.tree_dbNames.OptionsView.ShowCheckBoxes = true;
            this.tree_dbNames.Size = new Size(370, 0xe3);
            this.tree_dbNames.TabIndex = 0;
            this.dbName.Caption = "数据库名";
            this.dbName.FieldName = "dbName";
            this.dbName.Name = "dbName";
            this.dbName.Visible = true;
            this.dbName.VisibleIndex = 0;
            this.dbName.Width = 0xb5;
            this.bnt_LoadGeoData.Location = new Point(0x181, 0x9a);
            this.bnt_LoadGeoData.Name = "bnt_LoadGeoData";
            this.bnt_LoadGeoData.Size = new Size(0x8e, 0x1f);
            this.bnt_LoadGeoData.TabIndex = 5;
            this.bnt_LoadGeoData.Text = "加载年度更新本底数据";
            this.bnt_LoadGeoData.ToolTip = "从FileGDB数据库中加载年度变更本底数据，转换为GeoMDF格式";
            this.bnt_LoadGeoData.ToolTipController = this.toolTipController1;
            this.bnt_LoadGeoData.ToolTipIconType = ToolTipIconType.Information;
            this.bnt_LoadGeoData.ToolTipTitle = "加载年度更新本底数据";
            this.bnt_LoadGeoData.Click += new EventHandler(this.bnt_LoadGeoData_Click);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.bnt_LoadGeoData);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.sqlExprConfigControl1);
            base.Name = "ForestGeoDataLoadControl";
            base.Size = new Size(0x218, 0x18e);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tree_dbNames.EndInit();
            base.ResumeLayout(false);
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
                string msg = "数据处理完成!";
                if (this.watcher != null)
                {
                    this.watcher.Stop();
                    msg = msg + "共耗时:" + this.watcher.Elapsed.ToString();
                }
                if (this.messageBox != null)
                {
                    this.messageBox.AddProgressMessage(msg);
                    if (this.geoTask != null)
                    {
                        this.geoTask.TaskProgressChanged -= new TaskEventHandler(this.messageBox.OnProgressDataChanged);
                        this.geoTask.TaskStatusChanged -= new TaskEventHandler(this.OnTaskStatusChanged);
                        this.geoTask = null;
                    }
                }
                XtraMessageBox.Show(msg);
                if (this.messageBox != null)
                {
                    this.messageBox.Visible = false;
                    this.messageBox.Close();
                    this.messageBox.Dispose();
                    this.messageBox = null;
                }
            }
        }

        private void RefeshDatabaseTree()
        {
            ForestDBServerInfo serverInfo = this.sqlExprConfigControl1.ServerInfo;
            if (((serverInfo != null) && !string.IsNullOrEmpty(serverInfo.InstanceName)) && !string.IsNullOrEmpty(serverInfo.ServerName))
            {
                GeoMDFManager manager = new GeoMDFManager(serverInfo);
                List<string> allDBNames = manager.GetAllDBNames();
                this.tree_dbNames.Nodes.Clear();
                this.tree_dbNames.DataSource = null;
                this.tree_dbNames.BeginUnboundLoad();
                foreach (string str in allDBNames)
                {
                    this.tree_dbNames.AppendNode(new object[] { str }, (TreeListNode) null);
                }
                this.tree_dbNames.RefreshDataSource();
                this.tree_dbNames.EndUnboundLoad();
                manager.ShutDown();
            }
        }

        private void ShowProgressWindow()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(this.ShowProgressWindow));
            }
            else if (this.messageBox != null)
            {
                this.messageBox.ShowDialog(this);
            }
        }

        private void sqlExprConfigControl1_OnGdbTestSuccess(object sender, string msg)
        {
            this.RefeshDatabaseTree();
        }

        private void StartGeoTask()
        {
            List<string> userSelectedDBS = this.GetUserSelectedDBS();
            if ((userSelectedDBS != null) && (userSelectedDBS.Count > 0))
            {
                if ((this.watcher != null) && this.watcher.IsRunning)
                {
                    this.watcher.Stop();
                }
                this.watcher = new Stopwatch();
                this.watcher.Start();
                string serverName = this.sqlExprConfigControl1.ServerName;
                string instanceName = this.sqlExprConfigControl1.InstanceName;
                if (string.IsNullOrEmpty(instanceName))
                {
                    XtraMessageBox.Show("数据库的实例未设置!");
                }
                else
                {
                    if (string.IsNullOrEmpty(serverName))
                    {
                        serverName = ".";
                    }
                    string str3 = string.Format(@"{0}\{1}", serverName, instanceName);
                    string fileGdbPath = this.fileGdbPath;
                    this.fileGdbPath = string.Empty;
                    this.geoTask.StartTask(new TaskDelegate(this.geoTask.Work), new object[] { fileGdbPath, userSelectedDBS[0], str3 });
                    this.ShowProgressWindow();
                }
            }
        }
    }
}

