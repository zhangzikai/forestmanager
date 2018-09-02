namespace GXFormMainFrame
{
    using ESRI.ArcGIS.Controls;

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using jn.isos.log;

    /// <summary>
    /// FormLogin6:登录附界面：在此界面上主要用于显示加载进度的信息
    /// </summary>
    public class FormLogin6 : Form
    {
        private AxLicenseControl axLicenseControl1;
        private IContainer components = null;
        protected Label LabelLoadInfo;
        protected Label LabelProgressBack;
        protected Label LabelProgressBar;
        public Timer m_Timer = null;
        public Panel panelProgress;
        private IDictionary<string, Image> m_imageDict;
        private Logger m_log = LoggerManager.CreateLogger("UI", typeof(FormLogin6));

        /// <summary>
        /// FormLogin6:登录附界面：在此界面上主要用于显示加载进度的信息（构造器）
        /// </summary>
        public FormLogin6()
        {
            this.InitializeComponent();
            m_imageDict = new Dictionary<string, Image>(10);
            this.m_Timer = new Timer();
            this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
            this.m_Timer.Start();
        }
        /// <summary>
        /// FormLogin6： 登录附界面加载窗体时触发此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin6_Load(object sender, EventArgs e)
        {
            string resource = "000.png";         
            this.BackgroundImage = FindImage(resource);
        }
        /// <summary>
        /// 寻找并加载各种图片的方法
        /// </summary>
        /// <param name="imagName"></param>
        /// <returns></returns>
        private Image FindImage(string imagName)
        {
            if (m_imageDict.ContainsKey(imagName))
            {
                return m_imageDict[imagName];
            }
            else
            {
                Image img = null;
                try
                {
                    img = Image.FromFile(Application.StartupPath + @"\skin\" + imagName);
                }
                catch { }
                if (null != img)
                {
                    m_imageDict.Add(imagName, img);
                }
                return img;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin6));
            this.panelProgress = new System.Windows.Forms.Panel();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new System.Drawing.Point(540, 488);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(264, 32);
            this.panelProgress.TabIndex = 76;
            this.panelProgress.Visible = false;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LabelLoadInfo.Location = new System.Drawing.Point(30, 3);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(258, 19);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Gold;
            this.LabelProgressBar.Location = new System.Drawing.Point(3, 27);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(117, 2);
            this.LabelProgressBar.TabIndex = 13;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(2, 26);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(260, 4);
            this.LabelProgressBack.TabIndex = 11;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(384, 342);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 77;
            // 
            // FormLogin6
            // 
            this.ClientSize = new System.Drawing.Size(945, 617);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.panelProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin6_Load);
            this.panelProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.LabelLoadInfo.Refresh();
            this.LabelProgressBack.Refresh();
            this.LabelProgressBar.Refresh();
        }

        /// <summary>
        /// 设置加载进度和加载信息
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="iValue"></param>
        public void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.LabelLoadInfo.Refresh();
                this.LabelProgressBar.Refresh();
                this.Refresh();
            }
            catch (Exception)
            {
            }
        }

      
    }
}

