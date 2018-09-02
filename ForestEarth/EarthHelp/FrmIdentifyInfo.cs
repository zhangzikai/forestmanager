namespace ForestEarth.EarthHelp
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmIdentifyInfo : Form
    {
        private CheckEdit checkEdit1;
        private IContainer components;
        private DataGridView dataGridView1;
        private DataTable m_validDataTable;
        private DataTable m_wholeDataTable;
        private PanelControl panelControl1;
        private SplitterControl splitterControl1;

        public FrmIdentifyInfo()
        {
            this.InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit1.Checked)
            {
                this.dataGridView1.DataSource = this.m_wholeDataTable;
            }
            else
            {
                this.dataGridView1.DataSource = this.m_validDataTable;
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
            this.panelControl1 = new PanelControl();
            this.checkEdit1 = new CheckEdit();
            this.splitterControl1 = new SplitterControl();
            this.dataGridView1 = new DataGridView();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.checkEdit1.Properties.BeginInit();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0xfd, 0x22);
            this.panelControl1.TabIndex = 0;
            this.checkEdit1.Location = new Point(11, 8);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "查看完整的小班调查因子信息";
            this.checkEdit1.Size = new Size(0xc4, 0x13);
            this.checkEdit1.TabIndex = 0;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.splitterControl1.Dock = DockStyle.Top;
            this.splitterControl1.Location = new Point(0, 0x22);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new Size(0xfd, 5);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0x27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 12;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0xfd, 0xf9);
            this.dataGridView1.TabIndex = 2;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xfd, 0x120);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.splitterControl1);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Location = new Point(2, 2);
            base.Name = "FrmIdentifyInfo";
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "小班调查因子信息";
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.checkEdit1.Properties.EndInit();
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void SetDataSource()
        {
            try
            {
                if (this.m_wholeDataTable != null)
                {
                    if ((this.m_validDataTable != null) && (this.m_validDataTable.Rows.Count > 0))
                    {
                        this.m_validDataTable.Rows.Clear();
                    }
                    DataRow row = null;
                    for (int i = 0; i < this.m_wholeDataTable.Rows.Count; i++)
                    {
                        object obj2 = this.m_wholeDataTable.Rows[i][1];
                        try
                        {
                            if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString().Trim()))
                            {
                                row = this.m_validDataTable.NewRow();
                                row["调查因子"] = this.m_wholeDataTable.Rows[i][0];
                                row["调查值"] = this.m_wholeDataTable.Rows[i][1];
                                this.m_validDataTable.Rows.Add(row);
                            }
                        }
                        catch
                        {
                        }
                    }
                    this.dataGridView1.DataSource = this.m_validDataTable;
                }
            }
            catch
            {
            }
        }

        public DataTable IdentifyResult
        {
            set
            {
                this.m_wholeDataTable = value;
                this.m_validDataTable = this.m_wholeDataTable.Copy();
                this.SetDataSource();
            }
        }
    }
}

