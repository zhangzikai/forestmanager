namespace ForestEarth.EarthHelp
{
    using DevExpress.XtraEditors;
    using EarthBusiness;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FrmXbLocate : Form
    {
        private System.Windows.Forms.ComboBox cb_lb;
        private System.Windows.Forms.ComboBox cb_town;
        private System.Windows.Forms.ComboBox cb_village;
        private System.Windows.Forms.ComboBox cb_xb;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private ClsDbHandler m_clsDbHandler;
        private PanelControl panelControl1;

        public event ComboSelected OnComboSelected;

        public FrmXbLocate(string connString, string updateYear)
        {
            this.InitializeComponent();
            this.m_clsDbHandler = new ClsDbHandler();
            this.m_clsDbHandler.SqlConnectionString = connString;
            this.m_clsDbHandler.UpdateYear = updateYear;
        }

        private void cb_lb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cb_xb.DataSource = null;
            DataTable linBanComboSource = this.m_clsDbHandler.GetLinBanComboSource(this.cb_village.SelectedValue.ToString(), this.cb_lb.SelectedValue.ToString());
            if ((linBanComboSource != null) && (linBanComboSource.Rows.Count > 0))
            {
                this.cb_xb.DataSource = linBanComboSource;
                this.cb_xb.DisplayMember = "XIAO_BAN";
                this.cb_xb.ValueMember = "XIAO_BAN";
                this.cb_xb.SelectedIndex = -1;
                XbIdentifyInfo locateGeoStringByCode = this.m_clsDbHandler.GetLocateGeoStringByCode(this.cb_village.SelectedValue.ToString() + this.cb_lb.SelectedValue.ToString());
                if ((locateGeoStringByCode != null) && (this.OnComboSelected != null))
                {
                    this.OnComboSelected(this, locateGeoStringByCode, false);
                }
            }
        }

        private void cb_town_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cb_village.DataSource = null;
            this.cb_lb.DataSource = null;
            this.cb_xb.DataSource = null;
            DataTable adminComboSource = this.m_clsDbHandler.GetAdminComboSource(this.cb_town.SelectedValue.ToString());
            if ((adminComboSource != null) && (adminComboSource.Rows.Count > 0))
            {
                this.cb_village.DataSource = adminComboSource;
                this.cb_village.DisplayMember = "CNAME";
                this.cb_village.ValueMember = "CCODE";
                this.cb_village.SelectedIndex = -1;
                XbIdentifyInfo locateGeoStringByCode = this.m_clsDbHandler.GetLocateGeoStringByCode(this.cb_town.SelectedValue.ToString());
                if ((locateGeoStringByCode != null) && (this.OnComboSelected != null))
                {
                    this.OnComboSelected(this, locateGeoStringByCode, false);
                }
            }
        }

        private void cb_village_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cb_lb.DataSource = null;
            this.cb_xb.DataSource = null;
            DataTable linBanComboSource = this.m_clsDbHandler.GetLinBanComboSource(this.cb_village.SelectedValue.ToString(), string.Empty);
            if ((linBanComboSource != null) && (linBanComboSource.Rows.Count > 0))
            {
                this.cb_lb.DataSource = linBanComboSource;
                this.cb_lb.DisplayMember = "LIN_BAN";
                this.cb_lb.ValueMember = "LIN_BAN";
                this.cb_lb.SelectedIndex = -1;
                XbIdentifyInfo locateGeoStringByCode = this.m_clsDbHandler.GetLocateGeoStringByCode(this.cb_village.SelectedValue.ToString());
                if ((locateGeoStringByCode != null) && (this.OnComboSelected != null))
                {
                    this.OnComboSelected(this, locateGeoStringByCode, false);
                }
            }
        }

        private void cb_xb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string xbid = this.cb_village.SelectedValue.ToString().Trim() + this.cb_lb.SelectedValue.ToString().Trim() + this.cb_xb.SelectedValue.ToString().Trim();
            XbIdentifyInfo result = this.m_clsDbHandler.GetXbInfoByLonLatOrXbid(0.0, 0.0, xbid);
            if ((result != null) && (this.OnComboSelected != null))
            {
                this.OnComboSelected(this, result, true);
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

        private void FrmXbLocate_Load(object sender, EventArgs e)
        {
            DataTable table = null;
            DataTable adminComboSource = this.m_clsDbHandler.GetAdminComboSource(string.Empty);
            if ((adminComboSource != null) && (adminComboSource.Rows.Count > 0))
            {
                table = this.m_clsDbHandler.GetAdminComboSource(adminComboSource.Rows[0][0].ToString());
            }
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.cb_town.DataSource = table;
                this.cb_town.DisplayMember = "CNAME";
                this.cb_town.ValueMember = "CCODE";
                this.cb_town.SelectedIndex = -1;
            }
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new PanelControl();
            this.cb_xb = new System.Windows.Forms.ComboBox();
            this.cb_lb = new System.Windows.Forms.ComboBox();
            this.cb_village = new System.Windows.Forms.ComboBox();
            this.cb_town = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.cb_xb);
            this.panelControl1.Controls.Add(this.cb_lb);
            this.panelControl1.Controls.Add(this.cb_village);
            this.panelControl1.Controls.Add(this.cb_town);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x106, 0xc6);
            this.panelControl1.TabIndex = 0;
            this.cb_xb.BackColor = Color.AliceBlue;
            this.cb_xb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_xb.FormattingEnabled = true;
            this.cb_xb.Location = new Point(0x5d, 0x9a);
            this.cb_xb.Name = "cb_xb";
            this.cb_xb.Size = new Size(0x88, 20);
            this.cb_xb.TabIndex = 7;
            this.cb_xb.SelectionChangeCommitted += new EventHandler(this.cb_xb_SelectionChangeCommitted);
            this.cb_lb.BackColor = Color.AliceBlue;
            this.cb_lb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_lb.FormattingEnabled = true;
            this.cb_lb.Location = new Point(0x5d, 110);
            this.cb_lb.Name = "cb_lb";
            this.cb_lb.Size = new Size(0x88, 20);
            this.cb_lb.TabIndex = 6;
            this.cb_lb.SelectionChangeCommitted += new EventHandler(this.cb_lb_SelectionChangeCommitted);
            this.cb_village.BackColor = Color.AliceBlue;
            this.cb_village.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_village.FormattingEnabled = true;
            this.cb_village.Location = new Point(0x5d, 0x42);
            this.cb_village.Name = "cb_village";
            this.cb_village.Size = new Size(0x88, 20);
            this.cb_village.TabIndex = 5;
            this.cb_village.SelectionChangeCommitted += new EventHandler(this.cb_village_SelectionChangeCommitted);
            this.cb_town.BackColor = Color.AliceBlue;
            this.cb_town.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_town.FormattingEnabled = true;
            this.cb_town.Location = new Point(0x5d, 0x16);
            this.cb_town.Name = "cb_town";
            this.cb_town.Size = new Size(0x88, 20);
            this.cb_town.TabIndex = 4;
            this.cb_town.SelectionChangeCommitted += new EventHandler(this.cb_town_SelectionChangeCommitted);
            this.labelControl4.Location = new Point(0x12, 0x9d);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "选择小班：";
            this.labelControl3.Location = new Point(0x12, 0x71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "选择林班：";
            this.labelControl2.Location = new Point(30, 0x45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x30, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "选择村：";
            this.labelControl1.Location = new Point(30, 0x19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x30, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "选择乡：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x106, 0xc6);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Location = new Point(5, 5);
            base.Name = "FrmXbLocate";
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "小班定位";
            base.Load += new EventHandler(this.FrmXbLocate_Load);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }

        public delegate void ComboSelected(object sender, XbIdentifyInfo result, bool isXb);
    }
}

