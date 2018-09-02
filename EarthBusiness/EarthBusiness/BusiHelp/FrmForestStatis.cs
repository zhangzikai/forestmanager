namespace EarthBusiness.BusiHelp
{
    using DevExpress.XtraCharts;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using EarthBusiness;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmForestStatis : Form
    {
        private SimpleButton btn_statis;
        private ComboBoxEdit cb_chartType;
        private ComboBoxEdit cb_content;
        private ComboBoxEdit cb_town;
        private ComboBoxEdit cb_village;
        private IContainer components;
        private DataGridView dataGridView1;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private ViewType m_chartType;
        private ClsDbHandler m_clsDbHandler;
        private string m_connString = string.Empty;
        private int m_content = 1;
        private ChartControl m_control;
        private string m_contyCode = string.Empty;
        private string m_contyName = string.Empty;
        private string m_pcode = string.Empty;
        private string m_pName = string.Empty;
        private List<CodeName> m_townCodeNames;
        private string m_updateYear = string.Empty;
        private List<CodeName> m_villageCodeNames;
        private string m_xTitle = string.Empty;
        private string m_yTitle = string.Empty;
        private MemoEdit me_smemo;
        private PanelControl panelControl1;
        private SplitterControl splitterControl1;
        private SplitterControl splitterControl2;
        private TextEdit te_conty;
        private XtraTabPage tp_chart;
        private XtraTabControl xtraTabControl1;
        private XtraTabControl xtraTabControl2;
        private XtraTabControl xtraTabControl3;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public FrmForestStatis(ClsDbHandler clsDbHandler, string connstring, string updateyear)
        {
            this.InitializeComponent();
            this.m_clsDbHandler = clsDbHandler;
            this.m_connString = connstring;
            this.m_updateYear = updateyear;
        }

        private void btn_statis_Click(object sender, EventArgs e)
        {
            ForestStatisInfo forStatisData = this.m_clsDbHandler.GetForStatisData(this.m_content, this.m_pcode);
            if (forStatisData != null)
            {
                DataTable bar = forStatisData.Bar;
                this.dataGridView1.DataSource = bar;
                if ((this.m_content == 3) && bar.Rows[bar.Rows.Count - 1][0].ToString().Equals("土地总面积"))
                {
                    bar.Rows.RemoveAt(bar.Rows.Count - 1);
                }
                this.GenerateChartControl(bar);
                this.me_smemo.Text = this.m_pName + forStatisData.Smemo;
            }
        }

        private void cb_chartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_chartType.SelectedIndex == 0)
            {
                this.m_chartType = ViewType.Bar;
            }
            else if (this.cb_chartType.SelectedIndex == 1)
            {
                this.m_chartType = ViewType.Line;
            }
            else
            {
                this.m_chartType = ViewType.Bar;
            }
        }

        private void cb_content_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_content.SelectedIndex)
            {
                case 0:
                    this.m_xTitle = "土地种类";
                    this.m_yTitle = "公顷";
                    break;

                case 1:
                    this.m_xTitle = "树种";
                    this.m_yTitle = "立方米";
                    break;

                case 2:
                    this.m_xTitle = "土地种类";
                    this.m_yTitle = "公顷";
                    break;
            }
            this.m_content = this.cb_content.SelectedIndex + 1;
        }

        private void cb_town_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_town.SelectedIndex >= 0)
            {
                this.cb_village.Text = string.Empty;
                if (this.cb_village.Properties.Items.Count > 0)
                {
                    this.cb_village.Properties.Items.Clear();
                }
                if ((this.m_townCodeNames != null) && (this.m_townCodeNames.Count > 0))
                {
                    this.m_pcode = this.m_townCodeNames[this.cb_town.SelectedIndex].Code;
                    this.m_pName = this.m_townCodeNames[this.cb_town.SelectedIndex].Name;
                    this.m_villageCodeNames = this.m_clsDbHandler.GetAdminLocateTreeData(this.m_pcode);
                    if ((this.m_villageCodeNames != null) && (this.m_villageCodeNames.Count > 0))
                    {
                        foreach (CodeName name in this.m_villageCodeNames)
                        {
                            this.cb_village.Properties.Items.Add(name.Name);
                        }
                    }
                }
            }
        }

        private void cb_village_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cb_village.SelectedIndex >= 0) && ((this.m_villageCodeNames != null) && (this.m_villageCodeNames.Count > 0)))
            {
                this.m_pcode = this.m_villageCodeNames[this.cb_village.SelectedIndex].Code;
                this.m_pName = this.m_villageCodeNames[this.cb_village.SelectedIndex].Name;
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

        private void FrmForestQuery_Load(object sender, EventArgs e)
        {
            DataTable adminComboSource = this.m_clsDbHandler.GetAdminComboSource(this.m_pcode);
            if ((adminComboSource != null) && (adminComboSource.Rows.Count > 0))
            {
                this.te_conty.Text = adminComboSource.Rows[0][1].ToString().Trim();
                this.m_pcode = adminComboSource.Rows[0][0].ToString().Trim();
                this.m_contyCode = this.m_pcode;
                this.m_pName = this.te_conty.Text;
                this.m_contyName = this.te_conty.Text;
            }
            this.m_control = new ChartControl();
            this.tp_chart.Controls.Add(this.m_control);
            this.m_control.Dock = DockStyle.Fill;
        }

        private void FrmForestQuery_Shown(object sender, EventArgs e)
        {
            this.m_townCodeNames = this.m_clsDbHandler.GetAdminLocateTreeData(this.m_pcode);
            if ((this.m_townCodeNames != null) && (this.m_townCodeNames.Count > 0))
            {
                foreach (CodeName name in this.m_townCodeNames)
                {
                    this.cb_town.Properties.Items.Add(name.Name);
                }
            }
            this.cb_content.Properties.Items.AddRange(new string[] { "林地面积", "活立木蓄积量", "森林覆盖率" });
            this.cb_content.SelectedIndex = 0;
            this.cb_chartType.Properties.Items.AddRange(new string[] { "柱状图", "折线图" });
            this.cb_chartType.SelectedIndex = 0;
        }

        private void GenerateChartControl(DataTable dt)
        {
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                if (this.m_control.Series.Count > 0)
                {
                    this.m_control.Series.Clear();
                }
                if (this.m_control.Titles.Count > 0)
                {
                    this.m_control.Titles.Clear();
                }
                ChartService service = new ChartService();
                service.SetChartTitle(this.m_control, true, this.cb_content.Text + "按年度统计情况", true, 2, StringAlignment.Center, ChartTitleDockStyle.Top, true, new Font("宋体", 12f, FontStyle.Bold), Color.Red, 10);
                service.DrawChart(this.m_control, this.m_chartType, dt);
                service.SetAxisX(this.m_control, true, StringAlignment.Center, this.m_xTitle, Color.Red, true, new Font("宋体", 12f, FontStyle.Bold));
                service.SetAxisY(this.m_control, true, StringAlignment.Far, this.m_yTitle, Color.Red, true, new Font("宋体", 12f, FontStyle.Bold));
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmForestStatis));
            this.panelControl1 = new PanelControl();
            this.labelControl5 = new LabelControl();
            this.cb_chartType = new ComboBoxEdit();
            this.btn_statis = new SimpleButton();
            this.cb_content = new ComboBoxEdit();
            this.labelControl4 = new LabelControl();
            this.cb_village = new ComboBoxEdit();
            this.labelControl3 = new LabelControl();
            this.cb_town = new ComboBoxEdit();
            this.labelControl2 = new LabelControl();
            this.te_conty = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.splitterControl1 = new SplitterControl();
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.me_smemo = new MemoEdit();
            this.xtraTabControl2 = new XtraTabControl();
            this.xtraTabPage2 = new XtraTabPage();
            this.dataGridView1 = new DataGridView();
            this.splitterControl2 = new SplitterControl();
            this.xtraTabControl3 = new XtraTabControl();
            this.tp_chart = new XtraTabPage();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.cb_chartType.Properties.BeginInit();
            this.cb_content.Properties.BeginInit();
            this.cb_village.Properties.BeginInit();
            this.cb_town.Properties.BeginInit();
            this.te_conty.Properties.BeginInit();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.me_smemo.Properties.BeginInit();
            this.xtraTabControl2.BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.xtraTabControl3.BeginInit();
            this.xtraTabControl3.SuspendLayout();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.cb_chartType);
            this.panelControl1.Controls.Add(this.btn_statis);
            this.panelControl1.Controls.Add(this.cb_content);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.cb_village);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cb_town);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.te_conty);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(790, 30);
            this.panelControl1.TabIndex = 0;
            this.labelControl5.Location = new Point(0x223, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x4d, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "|统计图类型：";
            this.cb_chartType.Location = new Point(0x26f, 5);
            this.cb_chartType.Name = "cb_chartType";
            this.cb_chartType.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cb_chartType.Size = new Size(0x49, 0x15);
            this.cb_chartType.TabIndex = 9;
            this.cb_chartType.SelectedIndexChanged += new EventHandler(this.cb_chartType_SelectedIndexChanged);
            this.btn_statis.Image = (Image) manager.GetObject("btn_statis.Image");
            this.btn_statis.Location = new Point(0x2c3, 4);
            this.btn_statis.Name = "btn_statis";
            this.btn_statis.Size = new Size(60, 0x17);
            this.btn_statis.TabIndex = 8;
            this.btn_statis.Text = "统计";
            this.btn_statis.Click += new EventHandler(this.btn_statis_Click);
            this.cb_content.Location = new Point(0x1bc, 5);
            this.cb_content.Name = "cb_content";
            this.cb_content.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cb_content.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cb_content.Size = new Size(100, 0x15);
            this.cb_content.TabIndex = 7;
            this.cb_content.SelectedIndexChanged += new EventHandler(this.cb_content_SelectedIndexChanged);
            this.labelControl4.Location = new Point(0x178, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x41, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "|统计内容：";
            this.cb_village.Location = new Point(0x111, 5);
            this.cb_village.Name = "cb_village";
            this.cb_village.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cb_village.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cb_village.Size = new Size(100, 0x15);
            this.cb_village.TabIndex = 5;
            this.cb_village.SelectedIndexChanged += new EventHandler(this.cb_village_SelectedIndexChanged);
            this.labelControl3.Location = new Point(0xf1, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x1d, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "|村：";
            this.cb_town.Location = new Point(0x89, 5);
            this.cb_town.Name = "cb_town";
            this.cb_town.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cb_town.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cb_town.Size = new Size(100, 0x15);
            this.cb_town.TabIndex = 3;
            this.cb_town.SelectedIndexChanged += new EventHandler(this.cb_town_SelectedIndexChanged);
            this.labelControl2.Location = new Point(0x69, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x1d, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "|乡：";
            this.te_conty.Location = new Point(0x27, 5);
            this.te_conty.Name = "te_conty";
            this.te_conty.Properties.ReadOnly = true;
            this.te_conty.Size = new Size(0x3f, 0x15);
            this.te_conty.TabIndex = 1;
            this.te_conty.Click += new EventHandler(this.te_conty_Click);
            this.labelControl1.Location = new Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x18, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "县：";
            this.splitterControl1.Dock = DockStyle.Top;
            this.splitterControl1.Location = new Point(0, 30);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new Size(790, 5);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            this.xtraTabControl1.Dock = DockStyle.Bottom;
            this.xtraTabControl1.Location = new Point(0, 0x1a1);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(790, 0x4f);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1 });
            this.xtraTabPage1.Controls.Add(this.me_smemo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0x310, 0x33);
            this.xtraTabPage1.Text = "统计说明";
            this.me_smemo.Dock = DockStyle.Fill;
            this.me_smemo.Location = new Point(0, 0);
            this.me_smemo.Name = "me_smemo";
            this.me_smemo.Properties.Appearance.Font = new Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.me_smemo.Properties.Appearance.ForeColor = Color.Red;
            this.me_smemo.Properties.Appearance.Options.UseFont = true;
            this.me_smemo.Properties.Appearance.Options.UseForeColor = true;
            this.me_smemo.Size = new Size(0x310, 0x33);
            this.me_smemo.TabIndex = 0;
            this.xtraTabControl2.Dock = DockStyle.Left;
            this.xtraTabControl2.Location = new Point(0, 0x23);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl2.Size = new Size(0x175, 0x17e);
            this.xtraTabControl2.TabIndex = 3;
            this.xtraTabControl2.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage2 });
            this.xtraTabPage2.Controls.Add(this.dataGridView1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0x16f, 0x162);
            this.xtraTabPage2.Text = "统计数值";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x16f, 0x162);
            this.dataGridView1.TabIndex = 0;
            this.splitterControl2.Location = new Point(0x175, 0x23);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new Size(5, 0x17e);
            this.splitterControl2.TabIndex = 4;
            this.splitterControl2.TabStop = false;
            this.xtraTabControl3.Dock = DockStyle.Fill;
            this.xtraTabControl3.Location = new Point(0x17a, 0x23);
            this.xtraTabControl3.Name = "xtraTabControl3";
            this.xtraTabControl3.SelectedTabPage = this.tp_chart;
            this.xtraTabControl3.Size = new Size(0x19c, 0x17e);
            this.xtraTabControl3.TabIndex = 5;
            this.xtraTabControl3.TabPages.AddRange(new XtraTabPage[] { this.tp_chart });
            this.tp_chart.Name = "tp_chart";
            this.tp_chart.Size = new Size(0x196, 0x162);
            this.tp_chart.Text = "统计图";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(790, 0x1f0);
            base.Controls.Add(this.xtraTabControl3);
            base.Controls.Add(this.splitterControl2);
            base.Controls.Add(this.xtraTabControl2);
            base.Controls.Add(this.xtraTabControl1);
            base.Controls.Add(this.splitterControl1);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmForestQuery";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "森林资源统计窗体";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmForestQuery_Load);
            base.Shown += new EventHandler(this.FrmForestQuery_Shown);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.cb_chartType.Properties.EndInit();
            this.cb_content.Properties.EndInit();
            this.cb_village.Properties.EndInit();
            this.cb_town.Properties.EndInit();
            this.te_conty.Properties.EndInit();
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.me_smemo.Properties.EndInit();
            this.xtraTabControl2.EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.xtraTabControl3.EndInit();
            this.xtraTabControl3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void te_conty_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cb_town.Text))
            {
                this.cb_town.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(this.cb_village.Text))
            {
                this.cb_village.Text = string.Empty;
            }
            if (this.cb_village.Properties.Items.Count > 0)
            {
                this.cb_village.Properties.Items.Clear();
            }
            this.m_pcode = this.m_contyCode;
            this.m_pName = this.m_contyName;
        }
    }
}

