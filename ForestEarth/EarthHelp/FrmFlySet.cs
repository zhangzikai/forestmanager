namespace ForestEarth.EarthHelp
{
    using DevExpress.XtraEditors;
    using EviaEarthLib;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmFlySet : Form
    {
        private CheckEdit checkEdit1;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private IEviaEarthControl m_control;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;

        public FrmFlySet(IEviaEarthControl pEviaEarthControl)
        {
            this.InitializeComponent();
            this.m_control = pEviaEarthControl;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            this.m_control.FlyerControl.FlyPath.PathVisible = this.checkEdit1.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmFlySet_Load(object sender, EventArgs e)
        {
            this.checkEdit1_CheckedChanged(null, null);
            this.numericUpDown1.Value = 500M;
            this.numericUpDown2.Value = 2500M;
            this.checkEdit1.Checked = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmFlySet));
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.checkEdit1 = new CheckEdit();
            this.numericUpDown1 = new NumericUpDown();
            this.numericUpDown2 = new NumericUpDown();
            this.labelControl3 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.checkEdit1.Properties.BeginInit();
            this.numericUpDown1.BeginInit();
            this.numericUpDown2.BeginInit();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(12, 0x12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "飞行速度：";
            this.labelControl2.Location = new Point(12, 0x38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "飞行高度：";
            this.checkEdit1.Location = new Point(12, 0x5e);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "显示飞行路线";
            this.checkEdit1.Size = new Size(0x67, 0x13);
            this.checkEdit1.TabIndex = 2;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.numericUpDown1.Location = new Point(0x4e, 15);
            int[] bits = new int[4];
            bits[0] = 0x2710;
            this.numericUpDown1.Maximum = new decimal(bits);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new Size(120, 0x15);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown2.Location = new Point(0x4e, 0x35);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x2710;
            this.numericUpDown2.Maximum = new decimal(numArray2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new Size(120, 0x15);
            this.numericUpDown2.TabIndex = 4;
            this.numericUpDown2.ValueChanged += new EventHandler(this.numericUpDown2_ValueChanged);
            this.labelControl3.Location = new Point(0xc9, 0x12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x35, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "公里/小时";
            this.labelControl4.Location = new Point(0xca, 0x38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(12, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "米";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x10b, 0x84);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.numericUpDown2);
            base.Controls.Add(this.numericUpDown1);
            base.Controls.Add(this.checkEdit1);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmFlySet";
            this.Text = "设置飞行参数";
            base.Load += new EventHandler(this.FrmFlySet_Load);
            this.checkEdit1.Properties.EndInit();
            this.numericUpDown1.EndInit();
            this.numericUpDown2.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.m_control.FlyerControl.Speed = Convert.ToSingle((double) ((Convert.ToSingle(this.numericUpDown1.Value) * 1000.0) / 3600.0));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.m_control.FlyerControl.FlyPath.Raise = Convert.ToSingle(this.numericUpDown2.Value);
        }
    }
}

