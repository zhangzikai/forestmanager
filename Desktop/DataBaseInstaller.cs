namespace Desktop
{
    using Desktop.Properties;
    using DevExpress.XtraEditors;
    using DevExpress.XtraWizard;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.vControls;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class DataBaseInstaller : FormBase3
    {
        private bool _skip;
        private CompletionWizardPage completionWizardPage1;
        private IContainer components;
        private WizardPage ConnectionConfig;
        private WizardPage CreateDatabase;
        private WizardPage CreateDatabaseObject;
        private GDB.SQLServerExpress.vTasks.vControls.CreateDatabaseObject createDatabaseObject1;
        private CreateNewGDB createNewGDB1;
        private WizardPage DropDatabase;
        private GDB.SQLServerExpress.vTasks.vControls.DropDatabase dropDatabase1;
        private bool finish = true;
        private GroupBox groupBox_database;
        private LabelControl labelControl1;
        private SqlServerDatabases sqlServerDatabases1;
        private WizardPage updateDatabaseObject;
        private UpdateDatabaseObject updateDatabaseObject1;
        private WizardControl WizardControl1;

        public DataBaseInstaller()
        {
            this.InitializeComponent();
            this.createNewGDB1.SkipEvent += new CreateNewGDB.Skip(this.createNewGDB1_SkipEvent);
            this.dropDatabase1.SkipEvent += new GDB.SQLServerExpress.vTasks.vControls.DropDatabase.Skip(this.dropDatabase1_SkipEvent);
            this.createDatabaseObject1.SkipEvent += new GDB.SQLServerExpress.vTasks.vControls.CreateDatabaseObject.Skip(this.createDatabaseObject1_SkipEvent);
            this.updateDatabaseObject1.SkipEvent += new UpdateDatabaseObject.Skip(this.updateDatabaseObject1_SkipEvent);
        }

        private void createDatabaseObject1_SkipEvent()
        {
            this._skip = true;
            this.WizardControl1.SelectedPage = this.DropDatabase;
            this._skip = false;
        }

        private void createNewGDB1_SkipEvent()
        {
            this._skip = true;
            this.WizardControl1.SelectedPage = this.updateDatabaseObject;
            this._skip = false;
        }

        private void DataBaseInstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.finish)
            {
                XtraMessageBox.Show("请等待操作完成！");
                e.Cancel = true;
            }
            else if ((this.sqlServerDatabases1.GeoMDFManager != null) && this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection.IsOpen)
            {
                this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection.Disconnect();
            }
        }

        private void DataBaseInstaller_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new Process { StartInfo = { 
                FileName = AppDomain.CurrentDomain.BaseDirectory + "系统帮助.chm",
                Verb = "Open",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal
            } }.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dropDatabase1_SkipEvent()
        {
            this._skip = true;
            this.WizardControl1.SelectedPage = this.completionWizardPage1;
            this._skip = false;
        }

        private void InitializeComponent()
        {
            new ComponentResourceManager(typeof(DataBaseInstaller));
            this.WizardControl1 = new WizardControl();
            this.CreateDatabaseObject = new WizardPage();
            this.createDatabaseObject1 = new GDB.SQLServerExpress.vTasks.vControls.CreateDatabaseObject();
            this.ConnectionConfig = new WizardPage();
            this.groupBox_database = new GroupBox();
            this.sqlServerDatabases1 = new SqlServerDatabases();
            this.CreateDatabase = new WizardPage();
            this.createNewGDB1 = new CreateNewGDB();
            this.updateDatabaseObject = new WizardPage();
            this.updateDatabaseObject1 = new UpdateDatabaseObject();
            this.DropDatabase = new WizardPage();
            this.dropDatabase1 = new GDB.SQLServerExpress.vTasks.vControls.DropDatabase();
            this.completionWizardPage1 = new CompletionWizardPage();
            this.labelControl1 = new LabelControl();
            this.WizardControl1.BeginInit();
            this.WizardControl1.SuspendLayout();
            this.CreateDatabaseObject.SuspendLayout();
            this.ConnectionConfig.SuspendLayout();
            this.groupBox_database.SuspendLayout();
            this.CreateDatabase.SuspendLayout();
            this.updateDatabaseObject.SuspendLayout();
            this.DropDatabase.SuspendLayout();
            base.SuspendLayout();
            this.WizardControl1.Appearance.Page.BackColor = Color.White;
            this.WizardControl1.Appearance.Page.ForeColor = Color.White;
            this.WizardControl1.Appearance.Page.Options.UseBackColor = true;
            this.WizardControl1.Appearance.Page.Options.UseForeColor = true;
            this.WizardControl1.Appearance.PageTitle.Font = new Font("华文宋体", 15f, FontStyle.Bold);
            this.WizardControl1.Appearance.PageTitle.Options.UseFont = true;
            this.WizardControl1.CancelText = "取消";
            this.WizardControl1.Controls.Add(this.CreateDatabaseObject);
            this.WizardControl1.Controls.Add(this.ConnectionConfig);
            this.WizardControl1.Controls.Add(this.CreateDatabase);
            this.WizardControl1.Controls.Add(this.updateDatabaseObject);
            this.WizardControl1.Controls.Add(this.DropDatabase);
            this.WizardControl1.Controls.Add(this.completionWizardPage1);
            this.WizardControl1.Dock = DockStyle.Fill;
            this.WizardControl1.FinishText = "&完成";
            this.WizardControl1.HelpText = "&帮助";
          //  this.WizardControl1.Image = Resources.wizard_image;
            this.WizardControl1.ImageLayout = ImageLayout.Zoom;
            this.WizardControl1.Location = new Point(0, 0);
            this.WizardControl1.Name = "WizardControl1";
            this.WizardControl1.NextText = "&下一步 >";
            this.WizardControl1.Pages.AddRange(new BaseWizardPage[] { this.ConnectionConfig, this.CreateDatabase, this.updateDatabaseObject, this.CreateDatabaseObject, this.DropDatabase, this.completionWizardPage1 });
            this.WizardControl1.PreviousText = "< &后退";
            this.WizardControl1.Size = new Size(0x237, 0x1aa);
            this.WizardControl1.Text = "后退";
            this.WizardControl1.SelectedPageChanging += new WizardPageChangingEventHandler(this.wizardControl1_SelectedPageChanging);
            this.WizardControl1.FinishClick += new CancelEventHandler(this.WizardControl1_FinishClick);
            this.WizardControl1.CancelClick += new CancelEventHandler(this.WizardControl1_CancelClick);
            this.CreateDatabaseObject.Controls.Add(this.createDatabaseObject1);
            this.CreateDatabaseObject.Name = "CreateDatabaseObject";
            this.CreateDatabaseObject.Size = new Size(0x217, 0x119);
            this.CreateDatabaseObject.Text = "创建数据库对象（可选）";
            this.createDatabaseObject1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.createDatabaseObject1.Appearance.BackColor2 = Color.White;
            this.createDatabaseObject1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.createDatabaseObject1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.createDatabaseObject1.Appearance.Options.UseBackColor = true;
            this.createDatabaseObject1.Appearance.Options.UseBorderColor = true;
            this.createDatabaseObject1.Dock = DockStyle.Fill;
            this.createDatabaseObject1.Location = new Point(0, 0);
            this.createDatabaseObject1.LookAndFeel.SkinName = "Money Twins";
            this.createDatabaseObject1.Name = "createDatabaseObject1";
            this.createDatabaseObject1.Size = new Size(0x217, 0x119);
            this.createDatabaseObject1.TabIndex = 0;
            this.ConnectionConfig.Controls.Add(this.groupBox_database);
            this.ConnectionConfig.Name = "ConnectionConfig";
            this.ConnectionConfig.Size = new Size(0x217, 0x119);
            this.ConnectionConfig.Text = "连接数据库实例";
            this.groupBox_database.Controls.Add(this.sqlServerDatabases1);
            this.groupBox_database.Dock = DockStyle.Fill;
            this.groupBox_database.Location = new Point(0, 0);
            this.groupBox_database.Name = "groupBox_database";
            this.groupBox_database.Size = new Size(0x217, 0x119);
            this.groupBox_database.TabIndex = 0;
            this.groupBox_database.TabStop = false;
            this.groupBox_database.Text = "选择或输入目标数据库信息";
            this.sqlServerDatabases1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.sqlServerDatabases1.Appearance.BackColor2 = Color.White;
            this.sqlServerDatabases1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.sqlServerDatabases1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.sqlServerDatabases1.Appearance.Options.UseBackColor = true;
            this.sqlServerDatabases1.Appearance.Options.UseBorderColor = true;
            this.sqlServerDatabases1.Dock = DockStyle.Fill;
            this.sqlServerDatabases1.Location = new Point(3, 0x12);
            this.sqlServerDatabases1.LookAndFeel.SkinName = "Money Twins";
            this.sqlServerDatabases1.Name = "sqlServerDatabases1";
            this.sqlServerDatabases1.Size = new Size(0x211, 260);
            this.sqlServerDatabases1.TabIndex = 0;
            this.CreateDatabase.Controls.Add(this.createNewGDB1);
            this.CreateDatabase.Name = "CreateDatabase";
            this.CreateDatabase.Size = new Size(0x217, 0x119);
            this.CreateDatabase.Text = "创建数据库";
            this.createNewGDB1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.createNewGDB1.Appearance.BackColor2 = Color.White;
            this.createNewGDB1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.createNewGDB1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.createNewGDB1.Appearance.Options.UseBackColor = true;
            this.createNewGDB1.Appearance.Options.UseBorderColor = true;
            this.createNewGDB1.Dock = DockStyle.Fill;
            this.createNewGDB1.Location = new Point(0, 0);
            this.createNewGDB1.Name = "createNewGDB1";
           // this.createNewGDB1.ServerConnection = null;
            this.createNewGDB1.Size = new Size(0x217, 0x119);
            this.createNewGDB1.TabIndex = 0;
            this.updateDatabaseObject.Controls.Add(this.updateDatabaseObject1);
            this.updateDatabaseObject.Name = "updateDatabaseObject";
            this.updateDatabaseObject.Size = new Size(0x217, 0x119);
            this.updateDatabaseObject.Text = "更新数据库对象（可选）";
            this.updateDatabaseObject1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.updateDatabaseObject1.Appearance.BackColor2 = Color.White;
            this.updateDatabaseObject1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.updateDatabaseObject1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.updateDatabaseObject1.Appearance.Options.UseBackColor = true;
            this.updateDatabaseObject1.Appearance.Options.UseBorderColor = true;
            this.updateDatabaseObject1.Dock = DockStyle.Fill;
            this.updateDatabaseObject1.Location = new Point(0, 0);
            this.updateDatabaseObject1.LookAndFeel.SkinName = "Money Twins";
            this.updateDatabaseObject1.Name = "updateDatabaseObject1";
            this.updateDatabaseObject1.Size = new Size(0x217, 0x119);
            this.updateDatabaseObject1.TabIndex = 0;
            this.DropDatabase.Controls.Add(this.dropDatabase1);
            this.DropDatabase.Name = "DropDatabase";
            this.DropDatabase.Size = new Size(0x217, 0x119);
            this.DropDatabase.Text = "删除、分离、附加数据库（可选）";
            this.dropDatabase1.Dock = DockStyle.Fill;
            this.dropDatabase1.Location = new Point(0, 0);
            this.dropDatabase1.Name = "dropDatabase1";
            this.dropDatabase1.Size = new Size(0x217, 0x119);
            this.dropDatabase1.TabIndex = 0;
            this.completionWizardPage1.FinishText = "已完成所有操作!";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "点击完成退出向导。";
            this.completionWizardPage1.Size = new Size(350, 0x125);
            this.completionWizardPage1.Text = "完成";
            this.labelControl1.AutoSizeMode = LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new Point(3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x158, 0x2a);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "本向导用于广西森林资源管理系统及伐区采集系统SqlServer数据库的生成及配置，使用前请先安装SqlServer 2008 R2 数据库实例！";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
          //  base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x237, 0x1aa);
            base.Controls.Add(this.WizardControl1);
          //  base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.HelpButton = true;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DataBaseInstaller";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "数据库创建向导";
            base.HelpButtonClicked += new CancelEventHandler(this.DataBaseInstaller_HelpButtonClicked);
            base.FormClosing += new FormClosingEventHandler(this.DataBaseInstaller_FormClosing);
            this.WizardControl1.EndInit();
            this.WizardControl1.ResumeLayout(false);
            this.CreateDatabaseObject.ResumeLayout(false);
            this.ConnectionConfig.ResumeLayout(false);
            this.groupBox_database.ResumeLayout(false);
            this.CreateDatabase.ResumeLayout(false);
            this.updateDatabaseObject.ResumeLayout(false);
            this.DropDatabase.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void insertData1_SkipEvent()
        {
            this._skip = true;
            this.WizardControl1.SelectedPage = this.updateDatabaseObject;
            this._skip = false;
        }

        private void updateDatabaseObject1_SkipEvent()
        {
            this._skip = true;
            this.WizardControl1.SelectedPage = this.CreateDatabaseObject;
            this._skip = false;
        }

        private void WizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            base.Close();
        }

        private void WizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            base.Close();
        }

        private void wizardControl1_SelectedPageChanging(object sender, WizardPageChangingEventArgs e)
        {
            if ((e.PrevPage == this.ConnectionConfig) && (e.Direction == Direction.Forward))
            {
                this.finish = false;
                if (!this.sqlServerDatabases1.CheckConnection())
                {
                    e.Cancel = true;
                    this.finish = true;
                }
                else
                {
                    this.finish = true;
                    this.createNewGDB1.ServerConnection = this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection;
                }
            }
            else if (e.PrevPage == this.CreateDatabase)
            {
                if (e.Direction == Direction.Forward)
                {
                    if (!this._skip)
                    {
                        this.finish = false;
                        this.createNewGDB1.ParentForm = this;
                        if (!this.createNewGDB1.Run())
                        {
                            this.finish = true;
                            e.Cancel = true;
                            return;
                        }
                        this.finish = true;
                    }
                    this.updateDatabaseObject1.ServerConnection = this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection;
                    this.updateDatabaseObject1.LoadDatabases();
                }
            }
            else if (e.PrevPage == this.updateDatabaseObject)
            {
                if (e.Direction == Direction.Forward)
                {
                    if (!this._skip)
                    {
                        this.finish = false;
                        if (!this.updateDatabaseObject1.Run())
                        {
                            this.finish = true;
                            e.Cancel = true;
                            return;
                        }
                        this.finish = true;
                    }
                    this.createDatabaseObject1.ServerConnection = this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection;
                    this.createDatabaseObject1.LoadDatabases();
                }
            }
            else if (e.PrevPage == this.CreateDatabaseObject)
            {
                if (e.Direction == Direction.Forward)
                {
                    if (!this._skip)
                    {
                        this.finish = false;
                        if (!this.createDatabaseObject1.Run())
                        {
                            this.finish = true;
                            e.Cancel = true;
                            return;
                        }
                        this.finish = true;
                    }
                    this.dropDatabase1.ServerConnection = this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection;
                    this.dropDatabase1.LoadDatabases();
                    this.dropDatabase1.LoadDatabasesEx();
                }
                else
                {
                    this.updateDatabaseObject1.LoadDatabases();
                }
            }
            else if (e.PrevPage == this.DropDatabase)
            {
                if (e.Direction != Direction.Forward)
                {
                    this.createDatabaseObject1.LoadDatabases();
                }
                else if (!this._skip)
                {
                    this.finish = false;
                    if (!this.dropDatabase1.Run())
                    {
                        this.finish = true;
                        e.Cancel = true;
                    }
                    else
                    {
                        this.finish = true;
                    }
                }
            }
            else if (e.PrevPage == this.completionWizardPage1)
            {
                this.dropDatabase1.LoadDatabases();
                this.dropDatabase1.LoadDatabasesEx();
            }
            else if (e.Direction == Direction.Backward)
            {
                this.WizardControl1.NextText = "&下一步 >";
            }
        }
    }
}

