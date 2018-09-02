namespace VgsTiledMap.Ags.VgsTile.Forms
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using VgsTiledMap.Ags;

    public class VgsFormTileCacheSetting : Form
    {
        private TabPage adv_tab;
        private Button btnClear;
        private Button btnExit;
        private Button btnOpenCachePath;
        private Button cachedir_bnt;
        private CheckBox chkEnableCacheTimeOut;
        private IContainer components;
        private FolderBrowserDialog folderBrowserDialog1;
        private TabPage gen_tab;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupCacheTimeout;
        private bool isUser_CacheTimeout;
        private bool isUser_Threads;
        private bool isVgs_TileChanged;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label9;
        private Label lblClearWarning;
        private TabPage lindi_tab;
        private TextBox lindi_txt;
        private NumericUpDown numCacheTimeOutDays;
        private NumericUpDown numDownloadThreads;
        private NumericUpDown numOfflineThreads;
        private Button set_bnt;
        private TabControl tabControl1;
        private TextBox txtCachePath;
        private string user_cache_dir = string.Empty;

        public VgsFormTileCacheSetting()
        {
            this.InitializeComponent();
        }

        private void AdjustAppConfigFile()
        {
            string vgsConfigFile = ConfigurationHelper.GetVgsConfigFile();
            if (((File.GetAttributes(vgsConfigFile) & FileAttributes.Hidden) == FileAttributes.Hidden) || ((File.GetAttributes(vgsConfigFile) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly))
            {
                File.SetAttributes(vgsConfigFile, FileAttributes.Normal);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("提醒！清空缓存会影响到地图加载！\n请慎重！\n\n确认清空？", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
            {
                string path = ConfigurationHelper.GetConfig().AppSettings.Settings["tileDir"].Value;
                if (path.Contains("%"))
                {
                    path = CacheSettings.ReplaceEnvironmentVar(path);
                }
                try
                {
                    DirectoryInfo info = new DirectoryInfo(path);
                    info.Delete(true);
                    info.Create();
                    MessageBox.Show("清空缓存成功！", "清空操作已完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("清空缓存失败！\n错误信息为" + exception.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            this.lblClearWarning.Visible = true;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            this.lblClearWarning.Visible = false;
        }

        private void btnOpenCachePath_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", this.txtCachePath.Text);
        }

        private void cachedir_bnt_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = true;
            if (this.txtCachePath.Text.Length > 0)
            {
                this.folderBrowserDialog1.SelectedPath = this.txtCachePath.Text;
            }
            if (this.folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.txtCachePath.Text = this.folderBrowserDialog1.SelectedPath;
                this.user_cache_dir = this.folderBrowserDialog1.SelectedPath;
                this.UserChangedConfigs();
            }
        }

        private void ChangeCacheTimeout(string strEnabled, string strTimeoutDays)
        {
            this.AdjustAppConfigFile();
            try
            {
                System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
                config.AppSettings.Settings["tileTimeoutEnabled"].Value = strEnabled;
                config.AppSettings.Settings["tileTimeout"].Value = strTimeoutDays;
                config.Save();
            }
            catch (Exception)
            {
            }
        }

        private void ChangeThreadSettings(string strOfflineThreads, string strDownloadThreads)
        {
            this.AdjustAppConfigFile();
            try
            {
                System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
                config.AppSettings.Settings["OfflineThreads"].Value = strOfflineThreads;
                config.AppSettings.Settings["DownloadThreads"].Value = strDownloadThreads;
                config.Save();
            }
            catch (Exception)
            {
            }
        }

        private void ChangeVgsServerSettings(string url)
        {
            this.AdjustAppConfigFile();
            try
            {
                System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
                config.AppSettings.Settings["VgsUrl"].Value = url;
                config.Save();
            }
            catch (Exception)
            {
            }
        }

        private void chkEnableCacheTimeOut_CheckedChanged(object sender, EventArgs e)
        {
            this.isUser_CacheTimeout = true;
            this.groupCacheTimeout.Enabled = this.chkEnableCacheTimeOut.Checked;
            this.UserChangedConfigs();
        }

        private void ClearCacheFolder(string szTileDir)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(szTileDir);
                info.Delete(true);
                info.Create();
                MessageBox.Show("清空缓存成功！", "清空操作已完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show("清空缓存失败！\n错误信息为" + exception.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        private string GetCacheFolderFromConfigFile()
        {
            string path = ConfigurationHelper.GetConfig().AppSettings.Settings["tileDir"].Value;
            if (path.Contains("%"))
            {
                path = CacheSettings.ReplaceEnvironmentVar(path);
            }
            return path;
        }

        private void InitializeComponent()
        {
            this.set_bnt = new Button();
            this.btnExit = new Button();
            this.tabControl1 = new TabControl();
            this.gen_tab = new TabPage();
            this.cachedir_bnt = new Button();
            this.lblClearWarning = new Label();
            this.btnClear = new Button();
            this.btnOpenCachePath = new Button();
            this.txtCachePath = new TextBox();
            this.label1 = new Label();
            this.adv_tab = new TabPage();
            this.groupBox1 = new GroupBox();
            this.numOfflineThreads = new NumericUpDown();
            this.label10 = new Label();
            this.groupBox2 = new GroupBox();
            this.numDownloadThreads = new NumericUpDown();
            this.label11 = new Label();
            this.chkEnableCacheTimeOut = new CheckBox();
            this.groupCacheTimeout = new GroupBox();
            this.label9 = new Label();
            this.numCacheTimeOutDays = new NumericUpDown();
            this.label8 = new Label();
            this.lindi_tab = new TabPage();
            this.label3 = new Label();
            this.label2 = new Label();
            this.lindi_txt = new TextBox();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.gen_tab.SuspendLayout();
            this.adv_tab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.numOfflineThreads.BeginInit();
            this.groupBox2.SuspendLayout();
            this.numDownloadThreads.BeginInit();
            this.groupCacheTimeout.SuspendLayout();
            this.numCacheTimeOutDays.BeginInit();
            this.lindi_tab.SuspendLayout();
            base.SuspendLayout();
            this.set_bnt.Enabled = false;
            this.set_bnt.Location = new Point(0x10a, 0xec);
            this.set_bnt.Name = "set_bnt";
            this.set_bnt.Size = new Size(0x4b, 0x17);
            this.set_bnt.TabIndex = 5;
            this.set_bnt.Text = "设置";
            this.set_bnt.UseVisualStyleBackColor = true;
            this.set_bnt.Click += new EventHandler(this.set_bnt_Click);
            this.btnExit.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
//            this.btnExit.DialogResult = DialogResult.Cancel;
            this.btnExit.Location = new Point(0x162, 0xec);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "取 消";
            this.btnExit.UseVisualStyleBackColor = true;
            this.tabControl1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.tabControl1.Controls.Add(this.gen_tab);
            this.tabControl1.Controls.Add(this.adv_tab);
            this.tabControl1.Controls.Add(this.lindi_tab);
            this.tabControl1.Location = new Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x1a5, 0xdb);
            this.tabControl1.TabIndex = 3;
            this.gen_tab.Controls.Add(this.cachedir_bnt);
            this.gen_tab.Controls.Add(this.lblClearWarning);
            this.gen_tab.Controls.Add(this.btnClear);
            this.gen_tab.Controls.Add(this.btnOpenCachePath);
            this.gen_tab.Controls.Add(this.txtCachePath);
            this.gen_tab.Controls.Add(this.label1);
            this.gen_tab.Location = new Point(4, 0x16);
            this.gen_tab.Name = "gen_tab";
            this.gen_tab.Padding = new Padding(3);
            this.gen_tab.Size = new Size(0x19d, 0xc1);
            this.gen_tab.TabIndex = 0;
            this.gen_tab.Text = "常规设置";
            this.gen_tab.UseVisualStyleBackColor = true;
            this.cachedir_bnt.Location = new Point(0x13e, 70);
            this.cachedir_bnt.Name = "cachedir_bnt";
            this.cachedir_bnt.Size = new Size(0x54, 0x17);
            this.cachedir_bnt.TabIndex = 5;
            this.cachedir_bnt.Text = "设置...";
            this.cachedir_bnt.UseVisualStyleBackColor = true;
            this.cachedir_bnt.Click += new EventHandler(this.cachedir_bnt_Click);
            this.lblClearWarning.AutoSize = true;
            this.lblClearWarning.ForeColor = Color.Red;
            this.lblClearWarning.Location = new Point(0x7d, 0x6c);
            this.lblClearWarning.Name = "lblClearWarning";
            this.lblClearWarning.Size = new Size(0xe9, 0x18);
            this.lblClearWarning.TabIndex = 4;
            this.lblClearWarning.Text = "注意：清空缓存后，所有在线地图加载时均\r\n需要重新下载，会严重影响浏览速度！";
            this.lblClearWarning.Visible = false;
            this.btnClear.Location = new Point(9, 0x68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x6d, 0x20);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空缓存";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.MouseLeave += new EventHandler(this.btnClear_MouseLeave);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new EventHandler(this.btnClear_MouseEnter);
            this.btnOpenCachePath.Location = new Point(0xd7, 70);
            this.btnOpenCachePath.Name = "btnOpenCachePath";
            this.btnOpenCachePath.Size = new Size(0x51, 0x17);
            this.btnOpenCachePath.TabIndex = 2;
            this.btnOpenCachePath.Text = "浏览";
            this.btnOpenCachePath.UseVisualStyleBackColor = true;
            this.btnOpenCachePath.Click += new EventHandler(this.btnOpenCachePath_Click);
            this.txtCachePath.Location = new Point(0x16, 0x25);
            this.txtCachePath.Name = "txtCachePath";
            this.txtCachePath.ReadOnly = true;
            this.txtCachePath.Size = new Size(380, 0x15);
            this.txtCachePath.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地缓存地址：";
            this.adv_tab.Controls.Add(this.groupBox1);
            this.adv_tab.Controls.Add(this.groupBox2);
            this.adv_tab.Controls.Add(this.chkEnableCacheTimeOut);
            this.adv_tab.Controls.Add(this.groupCacheTimeout);
            this.adv_tab.Location = new Point(4, 0x16);
            this.adv_tab.Name = "adv_tab";
            this.adv_tab.Size = new Size(0x19d, 0xc1);
            this.adv_tab.TabIndex = 3;
            this.adv_tab.Text = "高级设置";
            this.adv_tab.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.numOfflineThreads);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new Point(15, 0x49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x176, 0x2d);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "离线缓存线程设置";
            this.numOfflineThreads.Location = new Point(0x90, 0x11);
            int[] bits = new int[4];
            bits[0] = 1;
            this.numOfflineThreads.Minimum = new decimal(bits);
            this.numOfflineThreads.Name = "numOfflineThreads";
            this.numOfflineThreads.Size = new Size(0x2e, 0x15);
            this.numOfflineThreads.TabIndex = 2;
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numOfflineThreads.Value = new decimal(numArray2);
            this.numOfflineThreads.ValueChanged += new EventHandler(this.numOfflineThreads_ValueChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x36, 0x13);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x2f, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "线程数:";
            this.groupBox2.Controls.Add(this.numDownloadThreads);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new Point(15, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x176, 0x2d);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "下载线程设置";
            this.numDownloadThreads.Location = new Point(0x90, 0x10);
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numDownloadThreads.Minimum = new decimal(numArray3);
            this.numDownloadThreads.Name = "numDownloadThreads";
            this.numDownloadThreads.Size = new Size(0x2e, 0x15);
            this.numDownloadThreads.TabIndex = 2;
            int[] numArray4 = new int[4];
            numArray4[0] = 1;
            this.numDownloadThreads.Value = new decimal(numArray4);
            this.numDownloadThreads.ValueChanged += new EventHandler(this.numDownloadThreads_ValueChanged);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0x36, 0x15);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x2f, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "线程数:";
            this.chkEnableCacheTimeOut.AutoSize = true;
            this.chkEnableCacheTimeOut.BackColor = Color.Transparent;
            this.chkEnableCacheTimeOut.Location = new Point(0x18, 13);
            this.chkEnableCacheTimeOut.Name = "chkEnableCacheTimeOut";
            this.chkEnableCacheTimeOut.Size = new Size(0x60, 0x10);
            this.chkEnableCacheTimeOut.TabIndex = 2;
            this.chkEnableCacheTimeOut.Text = "启动缓存失效";
            this.chkEnableCacheTimeOut.UseVisualStyleBackColor = false;
            this.chkEnableCacheTimeOut.CheckedChanged += new EventHandler(this.chkEnableCacheTimeOut_CheckedChanged);
            this.groupCacheTimeout.Controls.Add(this.label9);
            this.groupCacheTimeout.Controls.Add(this.numCacheTimeOutDays);
            this.groupCacheTimeout.Controls.Add(this.label8);
            this.groupCacheTimeout.Enabled = false;
            this.groupCacheTimeout.Location = new Point(15, 13);
            this.groupCacheTimeout.Name = "groupCacheTimeout";
            this.groupCacheTimeout.Size = new Size(0x176, 0x36);
            this.groupCacheTimeout.TabIndex = 3;
            this.groupCacheTimeout.TabStop = false;
            this.groupCacheTimeout.Text = "groupBox1";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0xc5, 0x19);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x11, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "天";
            this.numCacheTimeOutDays.Location = new Point(0x90, 0x15);
            int[] numArray5 = new int[4];
            numArray5[0] = 1;
            this.numCacheTimeOutDays.Minimum = new decimal(numArray5);
            this.numCacheTimeOutDays.Name = "numCacheTimeOutDays";
            this.numCacheTimeOutDays.Size = new Size(0x2e, 0x15);
            this.numCacheTimeOutDays.TabIndex = 2;
            int[] numArray6 = new int[4];
            numArray6[0] = 1;
            this.numCacheTimeOutDays.Value = new decimal(numArray6);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x15, 0x19);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "缓存失效天数:";
            this.lindi_tab.Controls.Add(this.label3);
            this.lindi_tab.Controls.Add(this.label2);
            this.lindi_tab.Controls.Add(this.lindi_txt);
            this.lindi_tab.Location = new Point(4, 0x16);
            this.lindi_tab.Name = "lindi_tab";
            this.lindi_tab.Padding = new Padding(3);
            this.lindi_tab.Size = new Size(0x19d, 0xc1);
            this.lindi_tab.TabIndex = 4;
            this.lindi_tab.Text = "林地服务设置";
            this.lindi_tab.UseVisualStyleBackColor = true;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Consolas", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.ForestGreen;
            this.label3.Location = new Point(14, 0x76);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x171, 0x13);
            this.label3.TabIndex = 1;
            this.label3.Text = "地址类似  http://10.53.40.2:8080/VgsData";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "林地一张图服务路径设置：";
            this.lindi_txt.Location = new Point(0x19, 0x43);
            this.lindi_txt.Name = "lindi_txt";
            this.lindi_txt.Size = new Size(0x16c, 0x15);
            this.lindi_txt.TabIndex = 0;
            this.lindi_txt.TextChanged += new EventHandler(this.lindi_txt_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1bd, 0x111);
            base.Controls.Add(this.set_bnt);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.tabControl1);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "VgsFormTileCacheSetting";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "地图层块缓存设置";
            base.Load += new EventHandler(this.VgsFormTileCacheSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.gen_tab.ResumeLayout(false);
            this.gen_tab.PerformLayout();
            this.adv_tab.ResumeLayout(false);
            this.adv_tab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.numOfflineThreads.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.numDownloadThreads.EndInit();
            this.groupCacheTimeout.ResumeLayout(false);
            this.groupCacheTimeout.PerformLayout();
            this.numCacheTimeOutDays.EndInit();
            this.lindi_tab.ResumeLayout(false);
            this.lindi_tab.PerformLayout();
            base.ResumeLayout(false);
        }

        private void lindi_txt_TextChanged(object sender, EventArgs e)
        {
            this.isVgs_TileChanged = true;
            this.UserChangedConfigs();
        }

        private void numDownloadThreads_ValueChanged(object sender, EventArgs e)
        {
            this.isUser_Threads = true;
            this.UserChangedConfigs();
        }

        private void numOfflineThreads_ValueChanged(object sender, EventArgs e)
        {
            this.isUser_Threads = true;
            this.UserChangedConfigs();
        }

        private void SaveConfigs()
        {
            this.AdjustAppConfigFile();
            System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
            if (!string.IsNullOrEmpty(this.user_cache_dir))
            {
                string cacheFolderFromConfigFile = this.GetCacheFolderFromConfigFile();
                this.txtCachePath.Text = this.user_cache_dir;
                if (MessageBox.Show("提醒！\n\n您选择更换缓存文件夹，是否保存？\n注意：保存后，请重新启动应用程序。", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    config.AppSettings.Settings["tileDir"].Value = this.user_cache_dir;
                    config.Save();
                }
                catch (Exception)
                {
                }
                if ((cacheFolderFromConfigFile != this.user_cache_dir) && (MessageBox.Show("提醒！\n\n您选择更换缓存文件夹，是否需要清空原来的缓存文件夹？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                {
                    this.ClearCacheFolder(cacheFolderFromConfigFile);
                }
            }
            if (this.isUser_CacheTimeout)
            {
                string strEnabled = this.chkEnableCacheTimeOut.Checked ? "1" : "0";
                string strTimeoutDays = this.numCacheTimeOutDays.Value.ToString("0");
                this.ChangeCacheTimeout(strEnabled, strTimeoutDays);
            }
            if (this.isUser_Threads)
            {
                string strOfflineThreads = this.numOfflineThreads.Value.ToString();
                string strDownloadThreads = this.numDownloadThreads.Value.ToString();
                this.ChangeThreadSettings(strOfflineThreads, strDownloadThreads);
            }
            if (this.isVgs_TileChanged)
            {
                string text = this.lindi_txt.Text;
                if (!string.IsNullOrEmpty(text) || (MessageBox.Show("提醒！\n\n您指定的服务路径为空，是否保存？\n注意：保存后，请重新启动应用程序。", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No))
                {
                    this.ChangeVgsServerSettings(text);
                }
            }
        }

        private void set_bnt_Click(object sender, EventArgs e)
        {
            this.SaveConfigs();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void UserChangedConfigs()
        {
            this.set_bnt.Enabled = true;
        }

        private void VgsFormTileCacheSetting_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
            string path = config.AppSettings.Settings["tileDir"].Value;
            if (path.Contains("%"))
            {
                path = CacheSettings.ReplaceEnvironmentVar(path);
            }
            this.txtCachePath.Text = path;
            this.lindi_txt.Text = config.AppSettings.Settings["VgsUrl"].Value;
        }
    }
}

