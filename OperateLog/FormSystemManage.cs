namespace OperateLog
{
    using DevExpress.XtraTab;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSystemManage : FormBase2
    {
        private IContainer components;
        private bool m_bInitConnect;
        private bool m_bInitUpdate;
        private bool m_bInitUser;
        private Panel panelConnect;
        private Panel panelUpdate;
        private Panel panelUser;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;

        public FormSystemManage()
        {
            this.InitializeComponent();
            base.MinimizeBox = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormSystemManage_Load(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            try
            {
                if (!this.m_bInitConnect)
                {
                    FormDataBaseLogin login = new FormDataBaseLogin();
                    login.SetCloseVisible(false);
                    login.TopLevel = false;
                    login.FormBorderStyle = FormBorderStyle.None;
                    login.Dock = DockStyle.Fill;
                    login.Parent = this.panelConnect;
                    login.Show();
                    this.m_bInitConnect = true;
                }
            }
            catch
            {
            }
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.panelConnect = new Panel();
            this.xtraTabPage2 = new XtraTabPage();
            this.panelUser = new Panel();
            this.xtraTabPage3 = new XtraTabPage();
            this.panelUpdate = new Panel();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            base.SuspendLayout();
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0x162, 0x16a);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3 });
            this.xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabPage1.Controls.Add(this.panelConnect);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0x15d, 0x14f);
            this.xtraTabPage1.Text = "数据库连接参数设置";
            this.panelConnect.Dock = DockStyle.Fill;
            this.panelConnect.Location = new Point(0, 0);
            this.panelConnect.Name = "panelConnect";
            this.panelConnect.Size = new Size(0x15d, 0x14f);
            this.panelConnect.TabIndex = 0;
            this.xtraTabPage2.Controls.Add(this.panelUser);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0x15d, 0x14f);
            this.xtraTabPage2.Text = "用户管理";
            this.panelUser.Dock = DockStyle.Fill;
            this.panelUser.Location = new Point(0, 0);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new Size(0x15d, 0x14f);
            this.panelUser.TabIndex = 1;
            this.xtraTabPage3.Controls.Add(this.panelUpdate);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0x15d, 0x14f);
            this.xtraTabPage3.Text = "数据库升级";
            this.panelUpdate.Dock = DockStyle.Fill;
            this.panelUpdate.Location = new Point(0, 0);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new Size(0x15d, 0x14f);
            this.panelUpdate.TabIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x162, 0x16a);
            base.Controls.Add(this.xtraTabControl1);
            base.LookAndFeel.SkinName = "Blue";
            base.Name = "FormSystemManage";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "系统管理";
            base.Load += new EventHandler(this.FormSystemManage_Load);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (!this.m_bInitConnect)
                {
                    FormDataBaseLogin login = new FormDataBaseLogin();
                    login.SetCloseVisible(false);
                    login.TopLevel = false;
                    login.FormBorderStyle = FormBorderStyle.None;
                    login.Dock = DockStyle.Fill;
                    login.Parent = this.panelConnect;
                    login.Show();
                    this.m_bInitConnect = true;
                }
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (!this.m_bInitUser)
                {
                    FormUserManage manage = new FormUserManage();
                    manage.SetCloseVisible(false);
                    manage.TopLevel = false;
                    manage.FormBorderStyle = FormBorderStyle.None;
                    manage.Dock = DockStyle.Fill;
                    manage.Parent = this.panelUser;
                    manage.Show();
                    this.m_bInitUser = true;
                }
            }
            else if ((this.xtraTabControl1.SelectedTabPageIndex == 2) && !this.m_bInitUpdate)
            {
                FormUpdateGDB egdb = new FormUpdateGDB();
                egdb.SetCloseVisible(false);
                egdb.TopLevel = false;
                egdb.FormBorderStyle = FormBorderStyle.None;
                egdb.Dock = DockStyle.Fill;
                egdb.Parent = this.panelUpdate;
                egdb.Show();
                this.m_bInitUpdate = true;
            }
        }
    }
}

