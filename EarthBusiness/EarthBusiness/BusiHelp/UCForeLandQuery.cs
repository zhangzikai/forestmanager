namespace EarthBusiness.BusiHelp
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraTab;
    using EarthBusiness;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UCForeLandQuery : UserControl
    {
        private SimpleButton btn_clear;
        private SimpleButton btn_doQuery;
        private SimpleButton btn_resultClear;
        private SimpleButton btn_resultQuery;
        private System.Windows.Forms.ComboBox cb_firstBhyy;
        private System.Windows.Forms.ComboBox cb_qContent;
        private System.Windows.Forms.ComboBox cb_secBhyy;
        private IContainer components;
        private DataGridView dgv_resultAdd;
        private DataGridView dgv_resultPlus;
        private DataGridView dgv_total;
        private DataGridView dgv_xb;
        private GroupControl groupControl1;
        private LabelControl labelControl1;
        private LabelControl lbl_first;
        private LabelControl lbl_second;
        private string m_bhyy = string.Empty;
        private ClsDbHandler m_clsDbHandler;
        private string m_connString = string.Empty;
        private string m_queryType = string.Empty;
        private string m_updateYear = string.Empty;
        private RichTextBox rtb_total;
        private XtraTabControl xtraTabControl1;
        private XtraTabControl xtraTabControl2;
        private XtraTabControl xtraTabControl3;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPage5;
        private XtraTabPage xtraTabPage6;
        private XtraTabPage xtraTabPage7;

        public event DoLindChangeQuery OnLindChangeQuery;

        public event DoLindChangeQueryClear OnLindChangeQueryClear;

        public event DoLindResultQuery OnLindResultQuery;

        public event DoLindResultQueryClear OnLindResultQueryClear;

        public event FlyToXB OnXbGridViewDoubleClick;

        public UCForeLandQuery()
        {
            this.InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (this.OnLindChangeQueryClear != null)
            {
                this.OnLindChangeQueryClear(this, true);
                if (this.dgv_total.DataSource != null)
                {
                    this.dgv_total.DataSource = null;
                }
                if (this.dgv_xb.DataSource != null)
                {
                    this.dgv_xb.DataSource = null;
                }
                this.cb_qContent.SelectedIndex = -1;
            }
        }

        private void btn_doQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_queryType))
            {
                MessageBox.Show("请选择查询内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                LindQueryResult result = this.DoQuery();
                if (result != null)
                {
                    this.dgv_total.DataSource = result.CountArea;
                    this.dgv_xb.DataSource = result.XB;
                    if (this.OnLindChangeQuery != null)
                    {
                        this.OnLindChangeQuery(this, result);
                    }
                }
            }
        }

        private void btn_resultClear_Click(object sender, EventArgs e)
        {
            this.rtb_total.Text = string.Empty;
            if (this.dgv_resultAdd.DataSource != null)
            {
                this.dgv_resultAdd.DataSource = null;
            }
            if (this.dgv_resultPlus.DataSource != null)
            {
                this.dgv_resultPlus.DataSource = null;
            }
            if (this.OnLindResultQueryClear != null)
            {
                this.OnLindResultQueryClear(this, true);
            }
        }

        private void btn_resultQuery_Click(object sender, EventArgs e)
        {
            LindResultQuery lindUpdateResult = this.m_clsDbHandler.GetLindUpdateResult();
            if (lindUpdateResult != null)
            {
                this.rtb_total.Text = lindUpdateResult.TotalInfor;
                this.dgv_resultAdd.DataSource = lindUpdateResult.XBAdd;
                this.dgv_resultPlus.DataSource = lindUpdateResult.XBPlus;
                if (this.OnLindResultQuery != null)
                {
                    this.OnLindResultQuery(this, lindUpdateResult);
                }
            }
        }

        private void cb_firstBhyy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.m_bhyy = this.cb_firstBhyy.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(this.m_bhyy))
            {
                this.SetSecBhyyControlsVisible(true);
                DataTable secondBHYY = this.m_clsDbHandler.GetSecondBHYY(this.m_bhyy.Substring(0, 1));
                this.cb_secBhyy.DataSource = secondBHYY;
                this.cb_secBhyy.DisplayMember = "CNAME";
                this.cb_secBhyy.ValueMember = "CCODE";
                this.cb_secBhyy.SelectedIndex = -1;
            }
        }

        private void cb_qContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_qContent.SelectedIndex)
            {
                case 0:
                {
                    this.SetBhyyControlsVisible(true);
                    DataTable firstBHYY = this.m_clsDbHandler.GetFirstBHYY();
                    this.cb_firstBhyy.DataSource = firstBHYY;
                    this.cb_firstBhyy.DisplayMember = "CNAME";
                    this.cb_firstBhyy.ValueMember = "CCODE";
                    this.cb_firstBhyy.SelectedIndex = -1;
                    this.m_queryType = "BHYY";
                    return;
                }
                case 1:
                    this.SetBhyyControlsVisible(false);
                    this.m_queryType = "DL";
                    this.m_bhyy = string.Empty;
                    return;

                case 2:
                    this.SetBhyyControlsVisible(false);
                    this.m_bhyy = string.Empty;
                    this.m_queryType = "LZ";
                    return;

                case 3:
                    this.SetBhyyControlsVisible(false);
                    this.m_bhyy = string.Empty;
                    this.m_queryType = "LDQS";
                    return;

                case 4:
                    this.SetBhyyControlsVisible(false);
                    this.m_bhyy = string.Empty;
                    this.m_queryType = "SLLB";
                    return;
            }
            this.SetBhyyControlsVisible(false);
        }

        private void cb_secBhyy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.m_bhyy = this.cb_secBhyy.SelectedValue.ToString();
        }

        private void dgv_xb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int oid = 0;
                    string tableName = string.Empty;
                    if (this.dgv_xb.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                    {
                        oid = Convert.ToInt32(this.dgv_xb.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    if (this.dgv_xb.Rows[e.RowIndex].Cells[4].Value != DBNull.Value)
                    {
                        tableName = this.dgv_xb.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                    if (this.OnXbGridViewDoubleClick != null)
                    {
                        this.OnXbGridViewDoubleClick(this, oid, tableName);
                    }
                }
            }
            catch
            {
            }
        }

        private void dgv_xb_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.dgv_xb.DataSource != null)
            {
                this.dgv_xb.Columns["表名"].Visible = false;
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

        private LindQueryResult DoQuery()
        {
            string where = string.Empty;
            string queryType = this.m_queryType;
            if (queryType != null)
            {
                if (queryType == "BHYY")
                {
                    if (string.IsNullOrEmpty(this.m_bhyy))
                    {
                        where = " where BHYY<>''";
                    }
                    else if (this.m_bhyy.Substring(1).Equals("0"))
                    {
                        where = " where left(BHYY,1)='" + this.m_bhyy.Substring(0, 1) + "'";
                    }
                    else
                    {
                        where = " where BHYY='" + this.m_bhyy + "'";
                    }
                }
                else if (queryType == "DL")
                {
                    where = " where Q_DI_LEI<>DI_LEI";
                }
                else if (queryType == "LZ")
                {
                    where = " where Q_LIN_ZHONG<>LIN_ZHONG";
                }
                else if (queryType == "LDQS")
                {
                    where = " where Q_LD_QS<>LD_QS";
                }
                else if (queryType == "SLLB")
                {
                    where = " where Q_SEN_LIN_LB<>SEN_LIN_LB";
                }
            }
            return this.m_clsDbHandler.QueryLindByBhyy(where);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UCForeLandQuery));
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.xtraTabControl2 = new XtraTabControl();
            this.xtraTabPage3 = new XtraTabPage();
            this.rtb_total = new RichTextBox();
            this.xtraTabPage4 = new XtraTabPage();
            this.dgv_resultAdd = new DataGridView();
            this.xtraTabPage5 = new XtraTabPage();
            this.dgv_resultPlus = new DataGridView();
            this.btn_resultClear = new SimpleButton();
            this.btn_resultQuery = new SimpleButton();
            this.xtraTabPage2 = new XtraTabPage();
            this.xtraTabControl3 = new XtraTabControl();
            this.xtraTabPage6 = new XtraTabPage();
            this.dgv_total = new DataGridView();
            this.xtraTabPage7 = new XtraTabPage();
            this.dgv_xb = new DataGridView();
            this.groupControl1 = new GroupControl();
            this.cb_secBhyy = new System.Windows.Forms.ComboBox();
            this.cb_firstBhyy = new System.Windows.Forms.ComboBox();
            this.cb_qContent = new System.Windows.Forms.ComboBox();
            this.lbl_second = new LabelControl();
            this.lbl_first = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.btn_clear = new SimpleButton();
            this.btn_doQuery = new SimpleButton();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabControl2.BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((ISupportInitialize) this.dgv_resultAdd).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((ISupportInitialize) this.dgv_resultPlus).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabControl3.BeginInit();
            this.xtraTabControl3.SuspendLayout();
            this.xtraTabPage6.SuspendLayout();
            ((ISupportInitialize) this.dgv_total).BeginInit();
            this.xtraTabPage7.SuspendLayout();
            ((ISupportInitialize) this.dgv_xb).BeginInit();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            base.SuspendLayout();
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0xe8, 0x18a);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2 });
            this.xtraTabPage1.Controls.Add(this.xtraTabControl2);
            this.xtraTabPage1.Controls.Add(this.btn_resultClear);
            this.xtraTabPage1.Controls.Add(this.btn_resultQuery);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0xe2, 0x16e);
            this.xtraTabPage1.Text = "林地净变更结果查询";
            this.xtraTabControl2.Dock = DockStyle.Bottom;
            this.xtraTabControl2.Location = new Point(0, 0xbf);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl2.Size = new Size(0xe2, 0xaf);
            this.xtraTabControl2.TabIndex = 2;
            this.xtraTabControl2.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage3, this.xtraTabPage4, this.xtraTabPage5 });
            this.xtraTabPage3.Controls.Add(this.rtb_total);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(220, 0x93);
            this.xtraTabPage3.Text = "概要信息";
            this.rtb_total.Dock = DockStyle.Fill;
            this.rtb_total.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rtb_total.ForeColor = Color.Red;
            this.rtb_total.Location = new Point(0, 0);
            this.rtb_total.Name = "rtb_total";
            this.rtb_total.Size = new Size(220, 0x93);
            this.rtb_total.TabIndex = 0;
            this.rtb_total.Text = "";
            this.xtraTabPage4.Controls.Add(this.dgv_resultAdd);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new Size(220, 0x93);
            this.xtraTabPage4.Text = "新增详情";
            this.dgv_resultAdd.AllowUserToAddRows = false;
            this.dgv_resultAdd.AllowUserToDeleteRows = false;
            this.dgv_resultAdd.BackgroundColor = Color.AliceBlue;
            this.dgv_resultAdd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultAdd.Dock = DockStyle.Fill;
            this.dgv_resultAdd.Location = new Point(0, 0);
            this.dgv_resultAdd.Name = "dgv_resultAdd";
            this.dgv_resultAdd.ReadOnly = true;
            this.dgv_resultAdd.RowTemplate.Height = 0x17;
            this.dgv_resultAdd.Size = new Size(220, 0x93);
            this.dgv_resultAdd.TabIndex = 0;
            this.xtraTabPage5.Controls.Add(this.dgv_resultPlus);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new Size(220, 0x93);
            this.xtraTabPage5.Text = "减少详情";
            this.dgv_resultPlus.BackgroundColor = Color.AliceBlue;
            this.dgv_resultPlus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultPlus.Dock = DockStyle.Fill;
            this.dgv_resultPlus.Location = new Point(0, 0);
            this.dgv_resultPlus.Name = "dgv_resultPlus";
            this.dgv_resultPlus.RowTemplate.Height = 0x17;
            this.dgv_resultPlus.Size = new Size(220, 0x93);
            this.dgv_resultPlus.TabIndex = 0;
            this.btn_resultClear.Image = (Image) manager.GetObject("btn_resultClear.Image");
            this.btn_resultClear.Location = new Point(130, 0x35);
            this.btn_resultClear.Name = "btn_resultClear";
            this.btn_resultClear.Size = new Size(0x4b, 0x17);
            this.btn_resultClear.TabIndex = 1;
            this.btn_resultClear.Text = "一键清除";
            this.btn_resultClear.Click += new EventHandler(this.btn_resultClear_Click);
            this.btn_resultQuery.Image = (Image) manager.GetObject("btn_resultQuery.Image");
            this.btn_resultQuery.Location = new Point(0x15, 0x35);
            this.btn_resultQuery.Name = "btn_resultQuery";
            this.btn_resultQuery.Size = new Size(0x4b, 0x17);
            this.btn_resultQuery.TabIndex = 0;
            this.btn_resultQuery.Text = "一键查询";
            this.btn_resultQuery.Click += new EventHandler(this.btn_resultQuery_Click);
            this.xtraTabPage2.Controls.Add(this.xtraTabControl3);
            this.xtraTabPage2.Controls.Add(this.groupControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0xe2, 0x16e);
            this.xtraTabPage2.Text = "林地转移查询";
            this.xtraTabControl3.Dock = DockStyle.Fill;
            this.xtraTabControl3.Location = new Point(0, 0xc7);
            this.xtraTabControl3.Name = "xtraTabControl3";
            this.xtraTabControl3.SelectedTabPage = this.xtraTabPage6;
            this.xtraTabControl3.Size = new Size(0xe2, 0xa7);
            this.xtraTabControl3.TabIndex = 1;
            this.xtraTabControl3.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage6, this.xtraTabPage7 });
            this.xtraTabPage6.Controls.Add(this.dgv_total);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new Size(220, 0x8b);
            this.xtraTabPage6.Text = "概要信息";
            this.dgv_total.AllowUserToAddRows = false;
            this.dgv_total.AllowUserToDeleteRows = false;
            this.dgv_total.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_total.BackgroundColor = Color.AliceBlue;
            this.dgv_total.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_total.Dock = DockStyle.Fill;
            this.dgv_total.Location = new Point(0, 0);
            this.dgv_total.Name = "dgv_total";
            this.dgv_total.ReadOnly = true;
            this.dgv_total.RowHeadersWidth = 12;
            this.dgv_total.RowTemplate.Height = 0x17;
            this.dgv_total.Size = new Size(220, 0x8b);
            this.dgv_total.TabIndex = 0;
            this.xtraTabPage7.Controls.Add(this.dgv_xb);
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new Size(220, 0x8b);
            this.xtraTabPage7.Text = "详细信息";
            this.dgv_xb.AllowUserToAddRows = false;
            this.dgv_xb.AllowUserToDeleteRows = false;
            this.dgv_xb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_xb.BackgroundColor = Color.AliceBlue;
            this.dgv_xb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_xb.Dock = DockStyle.Fill;
            this.dgv_xb.Location = new Point(0, 0);
            this.dgv_xb.Name = "dgv_xb";
            this.dgv_xb.ReadOnly = true;
            this.dgv_xb.RowHeadersWidth = 12;
            this.dgv_xb.RowTemplate.Height = 0x17;
            this.dgv_xb.Size = new Size(220, 0x8b);
            this.dgv_xb.TabIndex = 0;
            this.dgv_xb.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgv_xb_CellMouseDoubleClick);
            this.dgv_xb.DataSourceChanged += new EventHandler(this.dgv_xb_DataSourceChanged);
            this.groupControl1.Controls.Add(this.cb_secBhyy);
            this.groupControl1.Controls.Add(this.cb_firstBhyy);
            this.groupControl1.Controls.Add(this.cb_qContent);
            this.groupControl1.Controls.Add(this.lbl_second);
            this.groupControl1.Controls.Add(this.lbl_first);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btn_clear);
            this.groupControl1.Controls.Add(this.btn_doQuery);
            this.groupControl1.Dock = DockStyle.Top;
            this.groupControl1.Location = new Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0xe2, 0xc7);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询设置";
            this.cb_secBhyy.BackColor = Color.AliceBlue;
            this.cb_secBhyy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_secBhyy.FormattingEnabled = true;
            this.cb_secBhyy.Location = new Point(0x6c, 0xa2);
            this.cb_secBhyy.Name = "cb_secBhyy";
            this.cb_secBhyy.Size = new Size(0x63, 20);
            this.cb_secBhyy.TabIndex = 7;
            this.cb_secBhyy.Visible = false;
            this.cb_secBhyy.SelectionChangeCommitted += new EventHandler(this.cb_secBhyy_SelectionChangeCommitted);
            this.cb_firstBhyy.BackColor = Color.AliceBlue;
            this.cb_firstBhyy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_firstBhyy.FormattingEnabled = true;
            this.cb_firstBhyy.Location = new Point(0x6c, 0x7b);
            this.cb_firstBhyy.Name = "cb_firstBhyy";
            this.cb_firstBhyy.Size = new Size(0x63, 20);
            this.cb_firstBhyy.TabIndex = 6;
            this.cb_firstBhyy.Visible = false;
            this.cb_firstBhyy.SelectionChangeCommitted += new EventHandler(this.cb_firstBhyy_SelectionChangeCommitted);
            this.cb_qContent.BackColor = Color.AliceBlue;
            this.cb_qContent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_qContent.FormattingEnabled = true;
            this.cb_qContent.Items.AddRange(new object[] { "变化原因", "地类转移", "林种转移", "林地权属转移", "森林类别转移" });
            this.cb_qContent.Location = new Point(0x6c, 0x54);
            this.cb_qContent.Name = "cb_qContent";
            this.cb_qContent.Size = new Size(0x63, 20);
            this.cb_qContent.TabIndex = 5;
            this.cb_qContent.SelectedIndexChanged += new EventHandler(this.cb_qContent_SelectedIndexChanged);
            this.lbl_second.Location = new Point(0x13, 0xa5);
            this.lbl_second.Name = "lbl_second";
            this.lbl_second.Size = new Size(0x54, 14);
            this.lbl_second.TabIndex = 4;
            this.lbl_second.Text = "二级变化原因：";
            this.lbl_second.Visible = false;
            this.lbl_first.Location = new Point(0x13, 0x7e);
            this.lbl_first.Name = "lbl_first";
            this.lbl_first.Size = new Size(0x54, 14);
            this.lbl_first.TabIndex = 3;
            this.lbl_first.Text = "一级变化原因：";
            this.lbl_first.Visible = false;
            this.labelControl1.Location = new Point(0x13, 0x57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x54, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "选择查询内容：";
            this.btn_clear.Image = (Image) manager.GetObject("btn_clear.Image");
            this.btn_clear.Location = new Point(0x84, 0x27);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new Size(0x4b, 0x17);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "清除结果";
            this.btn_clear.Click += new EventHandler(this.btn_clear_Click);
            this.btn_doQuery.Image = (Image) manager.GetObject("btn_doQuery.Image");
            this.btn_doQuery.Location = new Point(0x13, 0x27);
            this.btn_doQuery.Name = "btn_doQuery";
            this.btn_doQuery.Size = new Size(0x4b, 0x17);
            this.btn_doQuery.TabIndex = 0;
            this.btn_doQuery.Text = "执行查询";
            this.btn_doQuery.Click += new EventHandler(this.btn_doQuery_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.xtraTabControl1);
            base.Name = "UCForeLandQuery";
            base.Size = new Size(0xe8, 0x18a);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabControl2.EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_resultAdd).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_resultPlus).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabControl3.EndInit();
            this.xtraTabControl3.ResumeLayout(false);
            this.xtraTabPage6.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_total).EndInit();
            this.xtraTabPage7.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_xb).EndInit();
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void SetBhyyControlsVisible(bool visible)
        {
            if (visible)
            {
                if (!this.lbl_first.Visible)
                {
                    this.lbl_first.Visible = visible;
                }
                if (!this.cb_firstBhyy.Visible)
                {
                    this.cb_firstBhyy.Visible = visible;
                }
            }
            else
            {
                if (this.lbl_first.Visible)
                {
                    this.lbl_first.Visible = visible;
                }
                if (this.cb_firstBhyy.Visible)
                {
                    this.cb_firstBhyy.Visible = visible;
                }
                if (this.lbl_second.Visible)
                {
                    this.lbl_second.Visible = visible;
                }
                if (this.cb_secBhyy.Visible)
                {
                    this.cb_secBhyy.Visible = visible;
                }
            }
        }

        private void SetSecBhyyControlsVisible(bool visible)
        {
            if (visible)
            {
                if (!this.lbl_second.Visible)
                {
                    this.lbl_second.Visible = visible;
                }
                if (!this.cb_secBhyy.Visible)
                {
                    this.cb_secBhyy.Visible = visible;
                }
            }
        }

        public ClsDbHandler ClassDbHandler
        {
            get
            {
                return this.m_clsDbHandler;
            }
            set
            {
                if (value != null)
                {
                    this.m_clsDbHandler = value;
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.m_connString;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_connString = value;
                    if (this.m_clsDbHandler == null)
                    {
                        this.m_clsDbHandler = new ClsDbHandler();
                    }
                    this.m_clsDbHandler.SqlConnectionString = this.m_connString;
                }
            }
        }

        public string UpdateYear
        {
            get
            {
                return this.m_updateYear;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_updateYear = value;
                    if (this.m_clsDbHandler == null)
                    {
                        this.m_clsDbHandler = new ClsDbHandler();
                    }
                    this.m_clsDbHandler.UpdateYear = this.m_updateYear;
                }
            }
        }

        public delegate void DoLindChangeQuery(object sender, LindQueryResult result);

        public delegate void DoLindChangeQueryClear(object sender, bool clear);

        public delegate void DoLindResultQuery(object sender, LindResultQuery result);

        public delegate void DoLindResultQueryClear(object sender, bool clear);

        public delegate void FlyToXB(object sender, int oid, string tableName);
    }
}

