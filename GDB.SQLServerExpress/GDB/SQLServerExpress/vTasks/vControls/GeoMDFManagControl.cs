namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using GDB.SQLServerEpxress.vForms;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.vExpress;
    using GDB.SQLServerExpress.vTasks.vForms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class GeoMDFManagControl : UserControl
    {
        private SimpleButton bnt_attachmdf;
        private SimpleButton bnt_createView;
        private SimpleButton bnt_detachmdf;
        private SimpleButton bnt_newGeoMDF;
        private SimpleButton bnt_setgeotype;
        private SimpleButton bnt_updateKey;
        private IContainer components;
        private TreeListColumn dbName;
        private TreeListColumn geoKey;
        private TreeListColumn geoType;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private PanelControl panelControl1;
        private SqlExprConfigControl sqlExprConfigControl1;
        private TreeList tree_dbNames;
        private TextEdit txt_keys;

        public GeoMDFManagControl()
        {
            this.InitializeComponent();
            this.sqlExprConfigControl1.ServerName = Dns.GetHostName();
        }

        private void bnt_attachmdf_Click(object sender, EventArgs e)
        {
            MdfChooserFrm frm = new MdfChooserFrm();
            if (DialogResult.OK == frm.ShowDialog())
            {
                string mDFPath = frm.MDFPath;
                string lDFPath = frm.LDFPath;
                GeoMDFManager manager = this.GetManager();
                if (manager == null)
                {
                    XtraMessageBox.Show("数据库不能连接，请检查配置参数是否满足需要!");
                }
                else
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(mDFPath);
                    manager.AttachDB(fileNameWithoutExtension, mDFPath, lDFPath);
                    manager.ShutDown();
                    this.RefeshDatabaseTree();
                    this.sqlExprConfigControl1.ShowMessageInfo("操作完成!");
                }
            }
        }

        private void bnt_createView_Click(object sender, EventArgs e)
        {
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                this.sqlExprConfigControl1.ShowMessageInfo("数据库不可用!");
            }
            else
            {
                List<string> userSelectedDBS = this.GetUserSelectedDBS();
                if ((userSelectedDBS == null) || (userSelectedDBS.Count <= 0))
                {
                    XtraMessageBox.Show("尚未选择任何需要更新的数据库!");
                }
                else
                {
                    manager.CreateLdView(userSelectedDBS);
                    manager.ShutDown();
                    XtraMessageBox.Show("选择数据库的林地更新数据联合查询视图建立完成!");
                    this.RefeshDatabaseTree();
                }
            }
        }

        private void bnt_detachmdf_Click(object sender, EventArgs e)
        {
            List<string> userSelectedDBS = this.GetUserSelectedDBS();
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                XtraMessageBox.Show("数据库不能连接，请检查配置参数是否满足需要!");
            }
            else
            {
                manager.DetachGeoDB(userSelectedDBS);
                manager.ShutDown();
                this.RefeshDatabaseTree();
            }
        }

        private void bnt_newGeoMDF_Click(object sender, EventArgs e)
        {
            new NewGeoMDFFrm().ShowDialog(this);
        }

        private void bnt_setgeotype_Click(object sender, EventArgs e)
        {
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                this.sqlExprConfigControl1.ShowMessageInfo("数据库不可用!");
            }
            else
            {
                List<string> userSelectedDBS = this.GetUserSelectedDBS();
                if ((userSelectedDBS == null) || (userSelectedDBS.Count <= 0))
                {
                    XtraMessageBox.Show("尚未选择任何需要更新的数据库!");
                }
                else
                {
                    manager.UpdateGeoDbType(userSelectedDBS);
                    manager.ShutDown();
                    XtraMessageBox.Show("选择数据库的空间数据存储类型已修改完成!");
                    this.RefeshDatabaseTree();
                }
            }
        }

        private void bnt_updateKey_Click(object sender, EventArgs e)
        {
            string key = string.Empty;
            if (string.IsNullOrEmpty(this.txt_keys.Text))
            {
                if (DialogResult.No == XtraMessageBox.Show("是否使用系统默认的许可文件信息？", "提示", MessageBoxButtons.YesNo))
                {
                    return;
                }
                key = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";
            }
            else
            {
                key = this.txt_keys.Text;
            }
            GeoMDFManager manager = this.GetManager();
            if (manager == null)
            {
                XtraMessageBox.Show("数据库不可用!");
            }
            else
            {
                List<string> userSelectedDBS = this.GetUserSelectedDBS();
                manager.UpdateGeoDbKey(userSelectedDBS, key);
                manager.ShutDown();
                this.sqlExprConfigControl1.ShowMessageInfo("操作完成!");
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
            this.sqlExprConfigControl1 = new SqlExprConfigControl();
            this.groupControl1 = new GroupControl();
            this.tree_dbNames = new TreeList();
            this.dbName = new TreeListColumn();
            this.geoType = new TreeListColumn();
            this.geoKey = new TreeListColumn();
            this.panelControl1 = new PanelControl();
            this.bnt_newGeoMDF = new SimpleButton();
            this.bnt_createView = new SimpleButton();
            this.bnt_setgeotype = new SimpleButton();
            this.bnt_detachmdf = new SimpleButton();
            this.bnt_attachmdf = new SimpleButton();
            this.groupControl2 = new GroupControl();
            this.bnt_updateKey = new SimpleButton();
            this.txt_keys = new TextEdit();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.tree_dbNames.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.txt_keys.Properties.BeginInit();
            base.SuspendLayout();
            this.sqlExprConfigControl1.Dock = DockStyle.Top;
            this.sqlExprConfigControl1.InstanceName = "sqlexpress";
            this.sqlExprConfigControl1.Location = new Point(0, 0);
            this.sqlExprConfigControl1.Name = "sqlExprConfigControl1";
            this.sqlExprConfigControl1.ServerName = "";
            this.sqlExprConfigControl1.Size = new Size(0x1d4, 0x7b);
            this.sqlExprConfigControl1.TabIndex = 0;
            this.sqlExprConfigControl1.UserName = "sa";
            this.sqlExprConfigControl1.UserPass = "123456";
            this.sqlExprConfigControl1.OnGdbTestSuccess += new SqlExprConfigControl.GeodbTestHandler(this.sqlExprConfigControl1_OnGdbTestSuccess);
            this.groupControl1.Controls.Add(this.tree_dbNames);
            this.groupControl1.Dock = DockStyle.Left;
            this.groupControl1.Location = new Point(0, 0x7b);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x109, 0x145);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "选择数据库";
            this.tree_dbNames.Columns.AddRange(new TreeListColumn[] { this.dbName, this.geoType, this.geoKey });
            this.tree_dbNames.Dock = DockStyle.Fill;
            this.tree_dbNames.Location = new Point(2, 0x17);
            this.tree_dbNames.Name = "tree_dbNames";
            this.tree_dbNames.OptionsBehavior.Editable = false;
            this.tree_dbNames.OptionsView.ShowCheckBoxes = true;
            this.tree_dbNames.Size = new Size(0x105, 300);
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
            this.panelControl1.Controls.Add(this.bnt_newGeoMDF);
            this.panelControl1.Controls.Add(this.bnt_createView);
            this.panelControl1.Controls.Add(this.bnt_setgeotype);
            this.panelControl1.Controls.Add(this.bnt_detachmdf);
            this.panelControl1.Controls.Add(this.bnt_attachmdf);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0x109, 0x7b);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0xcb, 0x145);
            this.panelControl1.TabIndex = 2;
            this.bnt_newGeoMDF.Location = new Point(30, 0x70);
            this.bnt_newGeoMDF.Name = "bnt_newGeoMDF";
            this.bnt_newGeoMDF.Size = new Size(0x8e, 30);
            this.bnt_newGeoMDF.TabIndex = 4;
            this.bnt_newGeoMDF.Text = "新建GeoMDF库";
            this.bnt_newGeoMDF.Click += new EventHandler(this.bnt_newGeoMDF_Click);
            this.bnt_createView.Location = new Point(30, 0xc4);
            this.bnt_createView.Name = "bnt_createView";
            this.bnt_createView.Size = new Size(0x8e, 30);
            this.bnt_createView.TabIndex = 4;
            this.bnt_createView.Text = "建立林地变更查询视图";
            this.bnt_createView.Click += new EventHandler(this.bnt_createView_Click);
            this.bnt_setgeotype.Location = new Point(30, 0x9a);
            this.bnt_setgeotype.Name = "bnt_setgeotype";
            this.bnt_setgeotype.Size = new Size(0x8e, 30);
            this.bnt_setgeotype.TabIndex = 4;
            this.bnt_setgeotype.Text = "修改库中空间数据类型";
            this.bnt_setgeotype.Click += new EventHandler(this.bnt_setgeotype_Click);
            this.bnt_detachmdf.Location = new Point(30, 0x117);
            this.bnt_detachmdf.Name = "bnt_detachmdf";
            this.bnt_detachmdf.Size = new Size(0x8e, 30);
            this.bnt_detachmdf.TabIndex = 6;
            this.bnt_detachmdf.Text = "移出当前选择数据库";
            this.bnt_detachmdf.Click += new EventHandler(this.bnt_detachmdf_Click);
            this.bnt_attachmdf.Location = new Point(30, 0xee);
            this.bnt_attachmdf.Name = "bnt_attachmdf";
            this.bnt_attachmdf.Size = new Size(0x8e, 30);
            this.bnt_attachmdf.TabIndex = 5;
            this.bnt_attachmdf.Text = "附加现有数据库";
            this.bnt_attachmdf.Click += new EventHandler(this.bnt_attachmdf_Click);
            this.groupControl2.Controls.Add(this.bnt_updateKey);
            this.groupControl2.Controls.Add(this.txt_keys);
            this.groupControl2.Location = new Point(6, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0xc1, 100);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "更新数据库许可信息";
            this.bnt_updateKey.Location = new Point(0x51, 0x47);
            this.bnt_updateKey.Name = "bnt_updateKey";
            this.bnt_updateKey.Size = new Size(0x6b, 0x17);
            this.bnt_updateKey.TabIndex = 1;
            this.bnt_updateKey.Text = "更新许可信息";
            this.bnt_updateKey.Click += new EventHandler(this.bnt_updateKey_Click);
            this.txt_keys.Location = new Point(5, 0x2c);
            this.txt_keys.Name = "txt_keys";
            this.txt_keys.Size = new Size(0xb7, 0x15);
            this.txt_keys.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.sqlExprConfigControl1);
            base.Name = "GeoMDFManagControl";
            base.Size = new Size(0x1d4, 0x1c0);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tree_dbNames.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.txt_keys.Properties.EndInit();
            base.ResumeLayout(false);
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

        private void sqlExprConfigControl1_OnGdbTestSuccess(object sender, string msg)
        {
            this.RefeshDatabaseTree();
        }
    }
}

