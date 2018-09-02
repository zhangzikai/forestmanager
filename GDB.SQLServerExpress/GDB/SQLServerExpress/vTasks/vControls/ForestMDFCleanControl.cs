namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.Properties;
    using GDB.SQLServerExpress.vTasks.vExpress;
    using GDB.SQLServerExpress.vTasks.vTasks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    public class ForestMDFCleanControl : XtraUserControl
    {
        private SimpleButton bnt_delGbCodes;
        private SimpleButton bnt_delIndx;
        private SimpleButton bnt_delSQL;
        private IContainer components;
        private TreeListColumn dbName;
        private DeleteGeoIndxTask delIndxTask;
        private TreeListColumn geoKey;
        private TreeListColumn geoType;
        private GroupControl groupControl1;
        private ForestProgressMessageBox messageBox;
        private PanelControl panelControl1;
        private SqlExprConfigControl sqlExprConfigControl1;
        private ToolTipController toolTipController1;
        private TreeList tree_dbNames;
        private Stopwatch watcher;

        public ForestMDFCleanControl()
        {
            this.InitializeComponent();
            this.sqlExprConfigControl1.ServerName = Dns.GetHostName();
        }

        private void bnt_delGbCodes_Click(object sender, EventArgs e)
        {
            List<string> userSelectedDBS = this.GetUserSelectedDBS();
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                XtraMessageBox.Show("数据库不能连接，请检查配置参数是否满足需要!");
            }
            else
            {
                manager.DeleteTableGbCode(userSelectedDBS);
                manager.ShutDown();
                this.RefeshDatabaseTree();
            }
        }

        private void bnt_delIndx_Click(object sender, EventArgs e)
        {
            if (this.messageBox != null)
            {
                this.messageBox.Close();
                this.messageBox = null;
            }
            this.delIndxTask = new DeleteGeoIndxTask();
            this.delIndxTask.TaskStatusChanged += new TaskEventHandler(this.OnTaskStatusChanged);
            this.messageBox = new ForestProgressMessageBox();
            this.messageBox.initStatus();
            this.delIndxTask.TaskProgressChanged += new TaskEventHandler(this.messageBox.OnProgressDataChanged);
            ThreadStart start = new ThreadStart(this.StartDeleIndx);
            new Thread(start).Start();
        }

        private void bnt_delSQL_Click(object sender, EventArgs e)
        {
            List<string> userSelectedDBS = this.GetUserSelectedDBS();
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                XtraMessageBox.Show("数据库不能连接，请检查配置参数是否满足需要!");
            }
            else
            {
                manager.DeleteIndxes(userSelectedDBS);
                manager.ShutDown();
                XtraMessageBox.Show("冗余图幅索引框删除完成，请通过ArcGIS检查是否满足要求!");
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
            this.panelControl1 = new PanelControl();
            this.bnt_delGbCodes = new SimpleButton();
            this.toolTipController1 = new ToolTipController(this.components);
            this.bnt_delSQL = new SimpleButton();
            this.bnt_delIndx = new SimpleButton();
            this.groupControl1 = new GroupControl();
            this.tree_dbNames = new TreeList();
            this.dbName = new TreeListColumn();
            this.geoType = new TreeListColumn();
            this.geoKey = new TreeListColumn();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.tree_dbNames.BeginInit();
            base.SuspendLayout();
            this.sqlExprConfigControl1.Dock = DockStyle.Top;
            this.sqlExprConfigControl1.InstanceName = "sqlexpress";
            this.sqlExprConfigControl1.Location = new Point(0, 0);
            this.sqlExprConfigControl1.Name = "sqlExprConfigControl1";
            this.sqlExprConfigControl1.ServerName = "trung";
            this.sqlExprConfigControl1.Size = new Size(0x213, 0x8f);
            this.sqlExprConfigControl1.TabIndex = 0;
            this.sqlExprConfigControl1.UserName = "sa";
            this.sqlExprConfigControl1.UserPass = "123456";
            this.sqlExprConfigControl1.OnGdbTestSuccess += new SqlExprConfigControl.GeodbTestHandler(this.sqlExprConfigControl1_OnGdbTestSuccess);
            this.panelControl1.Controls.Add(this.bnt_delGbCodes);
            this.panelControl1.Controls.Add(this.bnt_delSQL);
            this.panelControl1.Controls.Add(this.bnt_delIndx);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0x176, 0x8f);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x9d, 0x116);
            this.panelControl1.TabIndex = 4;
            this.bnt_delGbCodes.Location = new Point(6, 0x17);
            this.bnt_delGbCodes.Name = "bnt_delGbCodes";
            this.bnt_delGbCodes.Size = new Size(0x8e, 30);
            this.bnt_delGbCodes.TabIndex = 4;
            this.bnt_delGbCodes.Text = "删除冗余代码数据";
            this.bnt_delGbCodes.ToolTip = "将根据数据库名称中第二个标识符(国标代码)来删除表格中存储的冗余代码数据";
            this.bnt_delGbCodes.ToolTipController = this.toolTipController1;
            this.bnt_delGbCodes.ToolTipIconType = ToolTipIconType.Warning;
            this.bnt_delGbCodes.ToolTipTitle = "删除冗余代码数据";
            this.bnt_delGbCodes.Click += new EventHandler(this.bnt_delGbCodes_Click);
            this.toolTipController1.AllowHtmlText = true;
            this.bnt_delSQL.Location = new Point(6, 0x3f);
            this.bnt_delSQL.Name = "bnt_delSQL";
            this.bnt_delSQL.Size = new Size(0x8e, 30);
            this.bnt_delSQL.TabIndex = 5;
            this.bnt_delSQL.Text = "删除冗余图幅索引";
            this.bnt_delSQL.ToolTip = "通过SQL使用县级行政区域界对图幅索引冗余数据进行删除";
            this.bnt_delSQL.ToolTipIconType = ToolTipIconType.Warning;
            this.bnt_delSQL.ToolTipTitle = "删除冗余图幅索引";
            this.bnt_delSQL.Click += new EventHandler(this.bnt_delSQL_Click);
//            this.bnt_delIndx.Image = Resources.Cut;
            this.bnt_delIndx.Location = new Point(6, 0x6a);
            this.bnt_delIndx.Name = "bnt_delIndx";
            this.bnt_delIndx.Size = new Size(0x8e, 30);
            this.bnt_delIndx.TabIndex = 5;
            this.bnt_delIndx.Text = "删除冗余图幅索引";
            this.bnt_delIndx.ToolTip = "通过ArcGIS将根据数据库名称中第二个标识符(国标代码)查询县级行政区域界对图幅索引冗余数据进行删除";
            this.bnt_delIndx.ToolTipController = this.toolTipController1;
            this.bnt_delIndx.ToolTipIconType = ToolTipIconType.Warning;
            this.bnt_delIndx.ToolTipTitle = "删除冗余图幅索引";
            this.bnt_delIndx.Click += new EventHandler(this.bnt_delIndx_Click);
            this.groupControl1.Controls.Add(this.tree_dbNames);
            this.groupControl1.Dock = DockStyle.Left;
            this.groupControl1.Location = new Point(0, 0x8f);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x176, 0x116);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "选择数据库";
            this.tree_dbNames.Columns.AddRange(new TreeListColumn[] { this.dbName, this.geoType, this.geoKey });
            this.tree_dbNames.Dock = DockStyle.Fill;
            this.tree_dbNames.Location = new Point(2, 0x17);
            this.tree_dbNames.Name = "tree_dbNames";
            this.tree_dbNames.OptionsBehavior.Editable = false;
            this.tree_dbNames.OptionsView.ShowCheckBoxes = true;
            this.tree_dbNames.Size = new Size(370, 0xfd);
            this.tree_dbNames.TabIndex = 0;
            this.dbName.Caption = "数据库名";
            this.dbName.FieldName = "dbName";
            this.dbName.Name = "dbName";
            this.dbName.Visible = true;
            this.dbName.VisibleIndex = 0;
            this.dbName.Width = 0xb5;
            this.geoType.Caption = "存储类型";
            this.geoType.FieldName = "geoType";
            this.geoType.Name = "geoType";
            this.geoType.Visible = true;
            this.geoType.VisibleIndex = 1;
            this.geoType.Width = 0x1d;
            this.geoKey.Caption = "授权码";
            this.geoKey.FieldName = "geoKey";
            this.geoKey.Name = "geoKey";
            this.geoKey.Visible = true;
            this.geoKey.VisibleIndex = 2;
            this.geoKey.Width = 30;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.sqlExprConfigControl1);
            base.Name = "ForestMDFCleanControl";
            base.Size = new Size(0x213, 0x1a5);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
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
                    if (this.delIndxTask != null)
                    {
                        this.delIndxTask.TaskProgressChanged -= new TaskEventHandler(this.messageBox.OnProgressDataChanged);
                        this.delIndxTask.TaskStatusChanged -= new TaskEventHandler(this.OnTaskStatusChanged);
                        this.delIndxTask = null;
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
                Dictionary<string, string> geoMDFKeys = manager.GetGeoMDFKeys(null);
                Dictionary<string, string> mDFGeoTypes = manager.GetMDFGeoTypes(null);
                this.tree_dbNames.Nodes.Clear();
                this.tree_dbNames.DataSource = null;
                this.tree_dbNames.BeginUnboundLoad();
                foreach (string str in allDBNames)
                {
                    this.tree_dbNames.AppendNode(new object[] { str, mDFGeoTypes.ContainsKey(str) ? mDFGeoTypes[str] : string.Empty, geoMDFKeys.ContainsKey(str) ? geoMDFKeys[str] : string.Empty }, (TreeListNode) null);
                }
                this.tree_dbNames.RefreshDataSource();
                this.tree_dbNames.EndUnboundLoad();
                manager.ShutDown();
                allDBNames.Clear();
                allDBNames = null;
                geoMDFKeys.Clear();
                geoMDFKeys = null;
                mDFGeoTypes.Clear();
                mDFGeoTypes = null;
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
                this.messageBox.TopMost = true;
                this.messageBox.Show(this);
            }
        }

        private void sqlExprConfigControl1_OnGdbTestSuccess(object sender, string msg)
        {
            this.RefeshDatabaseTree();
        }

        private void StartDeleIndx()
        {
            List<string> userSelectedDBS = this.GetUserSelectedDBS();
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
                this.delIndxTask.StartTask(new TaskDelegate(this.delIndxTask.Work), new object[] { str3, userSelectedDBS });
                this.ShowProgressWindow();
            }
        }
    }
}

