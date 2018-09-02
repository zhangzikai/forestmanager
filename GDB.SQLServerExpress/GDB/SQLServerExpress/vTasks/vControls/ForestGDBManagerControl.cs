namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks;
    using GDB.SQLServerExpress.vTasks.vTasks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class ForestGDBManagerControl : XtraUserControl
    {
        private ForestProgressMessageBox _forMsgBox;
        private Dictionary<string, TransForestTemplateTask> _importTasks = new Dictionary<string, TransForestTemplateTask>();
        private SimpleButton bnt_cancel;
        private SimpleButton bnt_new;
        private SimpleButton bnt_testDb;
        private ButtonEdit bnt_txt_datasrc;
        private SimpleButton bnt_updateKeys;
        private ButtonEdit bntEdit_dataDir;
        private ButtonEdit bntxt_fgdb;
        private CheckEdit chk_import;
        private IContainer components;
        private CreateForestGDBTask createGDBTask;
        private DefaultLookAndFeel defaultLookAndFeel1;
        private ComboBoxEdit drd_gbcode;
        private FolderBrowserDialog foldDlg_FileGdb;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private PanelControl panel_fgdb;
        private PanelControl panelControl1;
        private PanelControl panl_import;
        private ProgressBarControl probar_forestgdb;
        private RadioGroup radioGroup1;
        private TextEdit textEdit1;
        private TextEdit txt_instance;
        private TextEdit txt_passwd;
        private TextEdit txt_reNameSets;
        private TextEdit txt_server;
        private TextEdit txt_templ;
        private TextEdit txt_user;
        private TextEdit txt_year;
        private Stopwatch watcher;

        public event TaskEndEvent OnTaskEndHandler;

        public ForestGDBManagerControl()
        {
            this.InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            this.initServerInfo();
        }

        private void bnt_cancel_Click(object sender, EventArgs e)
        {
            if (this.OnTaskEndHandler != null)
            {
                this.OnTaskEndHandler(this, "用户取消任务!");
            }
        }

        private void bnt_new_Click(object sender, EventArgs e)
        {
            base.Enabled = false;
            CreateForestGDBTask createGDBTask = this.createGDBTask;
            if (this._forMsgBox != null)
            {
                this._forMsgBox.Close();
                this._forMsgBox = null;
            }
            this.createGDBTask = new CreateForestGDBTask();
            this.createGDBTask.TaskStatusChanged += new TaskEventHandler(this.OnTaskStatusChanged);
            this.createGDBTask.TaskProgressChanged += new TaskEventHandler(this.OnTaskProgressChanged);
            this.createGDBTask.TaskThrowError += new TaskEventHandler(this.createGDBTask_TaskThrowError);
            this._forMsgBox = new ForestProgressMessageBox();
            this._forMsgBox.initStatus();
            this.createGDBTask.TaskProgressChanged += new TaskEventHandler(this._forMsgBox.OnProgressDataChanged);
            ThreadStart start = new ThreadStart(this.startCreate);
            new Thread(start).Start();
        }

        private void bnt_testDb_Click(object sender, EventArgs e)
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
                XtraMessageBox.Show(this, "服务器在线，同时可进行数据库管理操作!");
            }
            else
            {
                XtraMessageBox.Show(this, "服务器不能访问，或不能进行数据库管理操作!");
            }
            manager.Release();
        }

        private void bnt_txt_datasrc_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.foldDlg_FileGdb.ShowDialog())
            {
                this.bnt_txt_datasrc.Text = this.foldDlg_FileGdb.SelectedPath;
            }
        }

        private void bnt_updateKeys_Click(object sender, EventArgs e)
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
            if (manager.UpdateGDBAuthKey(string.Empty))
            {
                XtraMessageBox.Show(this, "服务器在线，同时可进行数据库管理操作!");
            }
            else
            {
                XtraMessageBox.Show(this, "服务器不能访问，或不能进行数据库管理操作!");
            }
            manager.Release();
        }

        private void bntEdit_dataDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.foldDlg_FileGdb.ShowDialog())
            {
                this.bntEdit_dataDir.Text = this.foldDlg_FileGdb.SelectedPath;
                this.bntEdit_dataDir.ForeColor = Color.Black;
            }
        }

        private void bntEdit_dataDir_Click(object sender, EventArgs e)
        {
            if ("选择数据存放路径...".CompareTo(this.bntEdit_dataDir.Text) == 0)
            {
                this.bntEdit_dataDir.Text = string.Empty;
            }
            this.bntEdit_dataDir.ForeColor = Color.Black;
        }

        private void bntEdit_dataDir_Leave(object sender, EventArgs e)
        {
            string text = this.bntEdit_dataDir.Text;
            bool flag = Directory.Exists(text);
            if (string.IsNullOrEmpty(text) || !flag)
            {
                this.bntEdit_dataDir.Text = "选择数据存放路径...";
                this.bntEdit_dataDir.ForeColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            }
        }

        private void bntxt_fgdb_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.foldDlg_FileGdb.ShowDialog())
            {
                this.bntxt_fgdb.Text = this.foldDlg_FileGdb.SelectedPath;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            this.panl_import.Visible = this.chk_import.Checked;
            if (this.chk_import.Checked && (DialogResult.OK == this.foldDlg_FileGdb.ShowDialog()))
            {
                this.bnt_txt_datasrc.Text = this.foldDlg_FileGdb.SelectedPath;
            }
        }

        private void createComplete()
        {
            if (this.createGDBTask != null)
            {
                this.createGDBTask.TaskStatusChanged -= new TaskEventHandler(this.OnTaskStatusChanged);
                this.createGDBTask.TaskProgressChanged -= new TaskEventHandler(this.OnTaskProgressChanged);
            }
            this.createGDBTask = null;
        }

        private void createGDBTask_TaskThrowError(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnTaskStatusChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else
            {
                base.Enabled = true;
                string msg = "数据库建立时发生错误:" + e.Message;
                if (this.watcher != null)
                {
                    this.watcher.Stop();
                    msg = msg + "共耗时:" + this.watcher.Elapsed.ToString();
                }
                if (this._forMsgBox != null)
                {
                    this._forMsgBox.AddProgressMessage(msg);
                    if (this.createGDBTask != null)
                    {
                        this.createGDBTask.TaskProgressChanged -= new TaskEventHandler(this._forMsgBox.OnProgressDataChanged);
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
            string text = this.txt_server.Text;
            string str2 = this.txt_instance.Text;
            string str3 = this.txt_user.Text;
            string str4 = this.txt_passwd.Text;
            string str5 = this.drd_gbcode.Text;
            string str6 = this.txt_year.Text;
            str6 = !string.IsNullOrEmpty(str6) ? str6 : DateTime.Now.Year.ToString();
            string str7 = this.bntEdit_dataDir.Text;
            if (string.IsNullOrEmpty(str7) || !Directory.Exists(str7))
            {
                XtraMessageBox.Show("请设置生成数据库存放的路径!");
                base.Enabled = true;
                return null;
            }
            string str8 = this.txt_reNameSets.Text;
            int year = DateTime.Now.Year;
            int.TryParse(str6, out year);
            return new ForestGDBInfo { 
                ReNameDatasets = str8,
                DataYear = year,
                GBCode = str5,
                GDBDir = str7,
                ServerName = text,
                GDBSize = 200,
                IntanceName = str2,
                UserName = str3,
                UserPass = str4
            };
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.textEdit1 = new TextEdit();
            this.groupControl1 = new GroupControl();
            this.bnt_updateKeys = new SimpleButton();
            this.bnt_testDb = new SimpleButton();
            this.txt_passwd = new TextEdit();
            this.labelControl4 = new LabelControl();
            this.txt_instance = new TextEdit();
            this.txt_user = new TextEdit();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.txt_server = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.groupControl2 = new GroupControl();
            this.labelControl9 = new LabelControl();
            this.txt_reNameSets = new TextEdit();
            this.bntEdit_dataDir = new ButtonEdit();
            this.probar_forestgdb = new ProgressBarControl();
            this.txt_year = new TextEdit();
            this.drd_gbcode = new ComboBoxEdit();
            this.chk_import = new CheckEdit();
            this.panl_import = new PanelControl();
            this.bnt_txt_datasrc = new ButtonEdit();
            this.labelControl7 = new LabelControl();
            this.panel_fgdb = new PanelControl();
            this.txt_templ = new TextEdit();
            this.bntxt_fgdb = new ButtonEdit();
            this.labelControl6 = new LabelControl();
            this.radioGroup1 = new RadioGroup();
            this.labelControl8 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.bnt_cancel = new SimpleButton();
            this.bnt_new = new SimpleButton();
            this.foldDlg_FileGdb = new FolderBrowserDialog();
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            this.textEdit1.Properties.BeginInit();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.txt_passwd.Properties.BeginInit();
            this.txt_instance.Properties.BeginInit();
            this.txt_user.Properties.BeginInit();
            this.txt_server.Properties.BeginInit();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.txt_reNameSets.Properties.BeginInit();
            this.bntEdit_dataDir.Properties.BeginInit();
            this.probar_forestgdb.Properties.BeginInit();
            this.txt_year.Properties.BeginInit();
            this.drd_gbcode.Properties.BeginInit();
            this.chk_import.Properties.BeginInit();
            this.panl_import.BeginInit();
            this.panl_import.SuspendLayout();
            this.bnt_txt_datasrc.Properties.BeginInit();
            this.panel_fgdb.BeginInit();
            this.panel_fgdb.SuspendLayout();
            this.txt_templ.Properties.BeginInit();
            this.bntxt_fgdb.Properties.BeginInit();
            this.radioGroup1.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.textEdit1.Location = new Point(0, 0);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 0x15);
            this.textEdit1.TabIndex = 0;
            this.groupControl1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.bnt_updateKeys);
            this.groupControl1.Controls.Add(this.bnt_testDb);
            this.groupControl1.Controls.Add(this.txt_passwd);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txt_instance);
            this.groupControl1.Controls.Add(this.txt_user);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txt_server);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = DockStyle.Top;
            this.groupControl1.Location = new Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x1ef, 0x81);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "森林资源更新数据库服务器配置信息";
            this.bnt_updateKeys.Location = new Point(0x165, 0x5f);
            this.bnt_updateKeys.Name = "bnt_updateKeys";
            this.bnt_updateKeys.Size = new Size(0x4b, 0x17);
            this.bnt_updateKeys.TabIndex = 5;
            this.bnt_updateKeys.Text = "更新许可";
            this.bnt_updateKeys.Click += new EventHandler(this.bnt_updateKeys_Click);
            this.bnt_testDb.Location = new Point(0xf9, 0x5e);
            this.bnt_testDb.Name = "bnt_testDb";
            this.bnt_testDb.Size = new Size(0x4b, 0x17);
            this.bnt_testDb.TabIndex = 5;
            this.bnt_testDb.Text = "测试";
            this.bnt_testDb.Click += new EventHandler(this.bnt_testDb_Click);
            this.txt_passwd.EditValue = "123456";
            this.txt_passwd.Location = new Point(320, 0x3d);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new Size(0x97, 0x15);
            this.txt_passwd.TabIndex = 4;
            this.labelControl4.Location = new Point(0xf1, 0x40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x30, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "密   码：";
            this.txt_instance.EditValue = "sqlexpress";
            this.txt_instance.Location = new Point(0x71, 0x3d);
            this.txt_instance.Name = "txt_instance";
            this.txt_instance.Size = new Size(0x73, 0x15);
            this.txt_instance.TabIndex = 2;
            this.txt_user.EditValue = "sa";
            this.txt_user.Location = new Point(320, 0x22);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new Size(0x97, 0x15);
            this.txt_user.TabIndex = 3;
            this.labelControl2.Location = new Point(0x22, 0x40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "服务实例名：";
            this.labelControl3.Location = new Point(0xf1, 0x25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x30, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "用户名：";
            this.txt_server.Location = new Point(0x71, 0x22);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new Size(0x73, 0x15);
            this.txt_server.TabIndex = 1;
            this.labelControl1.Location = new Point(0x22, 0x25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "服务器名称：";
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.txt_reNameSets);
            this.groupControl2.Controls.Add(this.bntEdit_dataDir);
            this.groupControl2.Controls.Add(this.probar_forestgdb);
            this.groupControl2.Controls.Add(this.txt_year);
            this.groupControl2.Controls.Add(this.drd_gbcode);
            this.groupControl2.Controls.Add(this.chk_import);
            this.groupControl2.Controls.Add(this.panl_import);
            this.groupControl2.Controls.Add(this.panel_fgdb);
            this.groupControl2.Controls.Add(this.radioGroup1);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Dock = DockStyle.Fill;
            this.groupControl2.Location = new Point(0, 0x81);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0x1ef, 0x157);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "森林资源更新本底数据库配置";
            this.labelControl9.Location = new Point(0x1f, 0xd7);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(230, 14);
            this.labelControl9.TabIndex = 11;
            this.labelControl9.Text = "需要重命名的数据集名称列表，以\",\"分隔：";
            this.txt_reNameSets.EditValue = "FOREST,ZT";
            this.txt_reNameSets.Location = new Point(0x1f, 0xeb);
            this.txt_reNameSets.Name = "txt_reNameSets";
            this.txt_reNameSets.Size = new Size(0x1c6, 0x15);
            this.txt_reNameSets.TabIndex = 10;
            this.bntEdit_dataDir.EditValue = "选择数据存放路径...";
            this.bntEdit_dataDir.Location = new Point(0xec, 40);
            this.bntEdit_dataDir.Name = "bntEdit_dataDir";
            this.bntEdit_dataDir.Properties.Appearance.ForeColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.bntEdit_dataDir.Properties.Appearance.Options.UseForeColor = true;
            this.bntEdit_dataDir.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.bntEdit_dataDir.Size = new Size(0xf9, 0x15);
            this.bntEdit_dataDir.TabIndex = 1;
            this.bntEdit_dataDir.ButtonClick += new ButtonPressedEventHandler(this.bntEdit_dataDir_ButtonClick);
            this.bntEdit_dataDir.Leave += new EventHandler(this.bntEdit_dataDir_Leave);
            this.bntEdit_dataDir.Click += new EventHandler(this.bntEdit_dataDir_Click);
            this.probar_forestgdb.Location = new Point(0x1f, 0x106);
            this.probar_forestgdb.Name = "probar_forestgdb";
            this.probar_forestgdb.Properties.BorderStyle = BorderStyles.Office2003;
            this.probar_forestgdb.Size = new Size(0x1c6, 0x12);
            this.probar_forestgdb.TabIndex = 8;
            this.txt_year.EditValue = "2013";
            this.txt_year.Location = new Point(0x4b, 0x43);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new Size(150, 0x15);
            this.txt_year.TabIndex = 2;
            this.drd_gbcode.Location = new Point(0x4b, 40);
            this.drd_gbcode.Name = "drd_gbcode";
            this.drd_gbcode.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.drd_gbcode.Size = new Size(150, 0x15);
            this.drd_gbcode.TabIndex = 7;
            this.chk_import.Location = new Point(0xef, 70);
            this.chk_import.Name = "chk_import";
            this.chk_import.Properties.Appearance.BackColor = Color.FromArgb(0xeb, 0xec, 0xef);
            this.chk_import.Properties.Appearance.Options.UseBackColor = true;
            this.chk_import.Properties.Caption = "导入县级数据";
            this.chk_import.Size = new Size(0x62, 0x13);
            this.chk_import.TabIndex = 5;
            this.chk_import.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.panl_import.Controls.Add(this.bnt_txt_datasrc);
            this.panl_import.Controls.Add(this.labelControl7);
            this.panl_import.Location = new Point(0xe7, 0x4f);
            this.panl_import.Name = "panl_import";
            this.panl_import.Size = new Size(0x103, 0x3f);
            this.panl_import.TabIndex = 4;
            this.panl_import.Visible = false;
            this.bnt_txt_datasrc.Location = new Point(5, 0x25);
            this.bnt_txt_datasrc.Name = "bnt_txt_datasrc";
            this.bnt_txt_datasrc.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.bnt_txt_datasrc.Size = new Size(0xf9, 0x15);
            this.bnt_txt_datasrc.TabIndex = 1;
            this.bnt_txt_datasrc.ButtonClick += new ButtonPressedEventHandler(this.bnt_txt_datasrc_ButtonClick);
            this.labelControl7.Location = new Point(10, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(100, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "县级原始数据设置:";
            this.panel_fgdb.Controls.Add(this.txt_templ);
            this.panel_fgdb.Controls.Add(this.bntxt_fgdb);
            this.panel_fgdb.Controls.Add(this.labelControl6);
            this.panel_fgdb.Location = new Point(0x1f, 0x95);
            this.panel_fgdb.Name = "panel_fgdb";
            this.panel_fgdb.Size = new Size(0x1cb, 0x35);
            this.panel_fgdb.TabIndex = 3;
            this.txt_templ.EditValue = "FORDATA_45_MODULE";
            this.txt_templ.Location = new Point(6, 0x1b);
            this.txt_templ.Name = "txt_templ";
            this.txt_templ.Size = new Size(0x1c0, 0x15);
            this.txt_templ.TabIndex = 2;
            this.bntxt_fgdb.Location = new Point(6, 0x1b);
            this.bntxt_fgdb.Name = "bntxt_fgdb";
            this.bntxt_fgdb.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.bntxt_fgdb.Size = new Size(0x1c0, 0x15);
            this.bntxt_fgdb.TabIndex = 1;
            this.bntxt_fgdb.Visible = false;
            this.bntxt_fgdb.ButtonClick += new ButtonPressedEventHandler(this.bntxt_fgdb_ButtonClick);
            this.labelControl6.Location = new Point(6, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x40, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "模板库设置:";
            this.radioGroup1.EditValue = (short) 1;
            this.radioGroup1.Location = new Point(0x1f, 0x5c);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem((short) 1, "使用服务器中的模板库"), new RadioGroupItem((short) 2, "使用文件型模板库") });
            this.radioGroup1.Size = new Size(0xc2, 0x33);
            this.radioGroup1.TabIndex = 2;
            this.radioGroup1.SelectedIndexChanged += new EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.labelControl8.Location = new Point(0x1f, 70);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(0x24, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "年度：";
            this.labelControl5.Location = new Point(0x1f, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x30, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "县代码：";
            this.panelControl1.Controls.Add(this.bnt_cancel);
            this.panelControl1.Controls.Add(this.bnt_new);
            this.panelControl1.Dock = DockStyle.Bottom;
            this.panelControl1.Location = new Point(0, 0x1aa);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x1ef, 0x2e);
            this.panelControl1.TabIndex = 2;
            this.bnt_cancel.Location = new Point(0x173, 9);
            this.bnt_cancel.Name = "bnt_cancel";
            this.bnt_cancel.Size = new Size(0x4a, 0x1b);
            this.bnt_cancel.TabIndex = 0;
            this.bnt_cancel.Text = "取消";
            this.bnt_cancel.Click += new EventHandler(this.bnt_cancel_Click);
            this.bnt_new.Location = new Point(0x117, 9);
            this.bnt_new.Name = "bnt_new";
            this.bnt_new.Size = new Size(0x4a, 0x1b);
            this.bnt_new.TabIndex = 0;
            this.bnt_new.Text = "新建";
            this.bnt_new.Click += new EventHandler(this.bnt_new_Click);
            this.foldDlg_FileGdb.Description = "请选择文件型数据库路径(.gdb)";
            this.foldDlg_FileGdb.RootFolder = Environment.SpecialFolder.MyComputer;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.groupControl2);
            base.Controls.Add(this.groupControl1);
            base.Name = "ForestGDBManagerControl";
            base.Size = new Size(0x1ef, 0x1d8);
            this.textEdit1.Properties.EndInit();
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.txt_passwd.Properties.EndInit();
            this.txt_instance.Properties.EndInit();
            this.txt_user.Properties.EndInit();
            this.txt_server.Properties.EndInit();
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.txt_reNameSets.Properties.EndInit();
            this.bntEdit_dataDir.Properties.EndInit();
            this.probar_forestgdb.Properties.EndInit();
            this.txt_year.Properties.EndInit();
            this.drd_gbcode.Properties.EndInit();
            this.chk_import.Properties.EndInit();
            this.panl_import.EndInit();
            this.panl_import.ResumeLayout(false);
            this.panl_import.PerformLayout();
            this.bnt_txt_datasrc.Properties.EndInit();
            this.panel_fgdb.EndInit();
            this.panel_fgdb.ResumeLayout(false);
            this.panel_fgdb.PerformLayout();
            this.txt_templ.Properties.EndInit();
            this.bntxt_fgdb.Properties.EndInit();
            this.radioGroup1.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void initServerInfo()
        {
            this.txt_server.Text = Dns.GetHostName();
        }

        private void newImportTask(string gdbServer, ForestDataTransConfig config)
        {
            TransForestTemplateTask task = new TransForestTemplateTask(gdbServer);
            this._importTasks.Add(task.Uid, task);
            task.TaskStatusChanged += new TaskEventHandler(this.OnImpTaskStatusChanged);
            task.TaskProgressChanged += new TaskEventHandler(this.OnTaskProgressChanged);
            config.Uid = task.Uid;
            new Thread(new ParameterizedThreadStart(this.startImportTask)).Start(config);
        }

        private void OnImpTaskStatusChanged(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnImpTaskStatusChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else if (e.Status == TaskStatus.Stopped)
            {
                if ((e.Result != null) && (e.Result is string))
                {
                    string result = e.Result as string;
                    TransForestTemplateTask task = this._importTasks[result];
                    if (task != null)
                    {
                        task.TaskStatusChanged -= new TaskEventHandler(this.OnImpTaskStatusChanged);
                        task.TaskProgressChanged -= new TaskEventHandler(this.OnTaskProgressChanged);
                    }
                    this._importTasks.Remove(result);
                }
                if (this._importTasks.Count <= 0)
                {
                    base.Enabled = true;
                }
            }
        }

        private void OnTaskProgressChanged(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnTaskProgressChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else if (((e.Result is TaskResult) && (e.Result is TaskResult)) && (e.Progress > 0))
            {
                this.probar_forestgdb.Position = e.Progress;
            }
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
                string msg = "本底库建立完成!";
                if (this.watcher != null)
                {
                    this.watcher.Stop();
                    msg = msg + "共耗时:" + this.watcher.Elapsed.ToString();
                }
                if (this._forMsgBox != null)
                {
                    this._forMsgBox.AddProgressMessage(msg);
                    if (this.createGDBTask != null)
                    {
                        this.createGDBTask.TaskProgressChanged -= new TaskEventHandler(this._forMsgBox.OnProgressDataChanged);
                    }
                }
                this.createComplete();
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

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.Text == "2")
            {
                this.bntxt_fgdb.Visible = true;
                this.txt_templ.Visible = false;
                if (DialogResult.OK == this.foldDlg_FileGdb.ShowDialog())
                {
                    this.bntxt_fgdb.Text = this.foldDlg_FileGdb.SelectedPath;
                }
            }
            else
            {
                this.bntxt_fgdb.Visible = false;
                this.txt_templ.Visible = true;
            }
        }

        private void ShowProgressWindow()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new InvokeDelegate(this.ShowProgressWindow));
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
            string str = (this.radioGroup1.Text == "1") ? "SQLGDB" : "FGDB";
            string str2 = (this.radioGroup1.Text == "1") ? this.txt_templ.Text : this.bntxt_fgdb.Text;
            str2 = str2.Trim();
            string str3 = this.chk_import.Checked ? this.bnt_txt_datasrc.Text : string.Empty;
            if ((info != null) && (this.createGDBTask != null))
            {
                if ((this.watcher != null) && this.watcher.IsRunning)
                {
                    this.watcher.Stop();
                }
                this.watcher = new Stopwatch();
                this.watcher.Start();
                this.createGDBTask.StartTask(new TaskDelegate(this.createGDBTask.Work), new object[] { info, string.Empty, str, str2, str3, "true" });
                this.ShowProgressWindow();
            }
        }

        private void startImportTask(object taskConfig)
        {
            if ((taskConfig != null) && (taskConfig is ForestDataTransConfig))
            {
                ForestDataTransConfig config = taskConfig as ForestDataTransConfig;
                string uid = config.Uid;
                TransForestTemplateTask task = this._importTasks[uid];
                if (task != null)
                {
                    task.StartTask(new TaskDelegate(task.Work), new object[] { config });
                }
            }
        }

        private void startImportTemp()
        {
            if (this._importTasks != null)
            {
                this._importTasks.Clear();
            }
            ForestGDBInfo info = this.genGdbInfo();
            if (info != null)
            {
                string str = (this.radioGroup1.Text == "1") ? "SQLGDB" : "FGDB";
                string str2 = (this.radioGroup1.Text == "1") ? this.txt_templ.Text : this.bntxt_fgdb.Text;
                str2 = str2.Trim();
                ForestDataTransConfig config = new ForestDataTransConfig {
                    EsriType = esriDatasetType.esriDTFeatureDataset,
                    SrcDBName = str2,
                    SrcType = str,
                    TargetDbName = info.DBName
                };
                this.newImportTask(info.GDBServer, config);
                ForestDataTransConfig config2 = new ForestDataTransConfig {
                    EsriType = esriDatasetType.esriDTTable,
                    SrcDBName = str2,
                    SrcType = str,
                    TargetDbName = info.DBName
                };
                this.newImportTask(info.GDBServer, config2);
            }
        }

        private delegate void InvokeDelegate();

        public delegate void TaskEndEvent(object sender, string msg);
    }
}

