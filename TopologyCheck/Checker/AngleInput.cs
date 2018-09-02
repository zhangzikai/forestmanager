namespace TopologyCheck.Checker
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class AngleInput : FormBase3
    {
        private double _angle;
        private bool _close;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private IContainer components;
        private LabelControl lbDegree;
        private TextEdit teAngle;

        public AngleInput()
        {
            this.InitializeComponent();
            this.Init();
        }

        private void AngleInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this._close)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.teAngle.Text))
            {
                XtraMessageBox.Show("角度不能为空！");
            }
            else
            {
                this._close = true;
                this._angle = double.Parse(this.teAngle.Text);
                base.Close();
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

        private void Init()
        {
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AngleValue");
            this.teAngle.Text = configValue;
        }

        private void InitializeComponent()
        {
            this.teAngle = new DevExpress.XtraEditors.TextEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbDegree = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.teAngle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teAngle
            // 
            this.teAngle.EditValue = "";
            this.teAngle.Location = new System.Drawing.Point(14, 21);
            this.teAngle.Name = "teAngle";
            this.teAngle.Size = new System.Drawing.Size(117, 20);
            this.teAngle.TabIndex = 0;
            this.teAngle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teAngle_KeyDown);
            this.teAngle.Leave += new System.EventHandler(this.teAngle_Leave);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(160, 20);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(248, 20);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbDegree
            // 
            this.lbDegree.Location = new System.Drawing.Point(139, 24);
            this.lbDegree.Name = "lbDegree";
            this.lbDegree.Size = new System.Drawing.Size(12, 14);
            this.lbDegree.TabIndex = 3;
            this.lbDegree.Text = "度";
            // 
            // AngleInput
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(337, 65);
            this.Controls.Add(this.lbDegree);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.teAngle);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AngleInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "输入角度";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AngleInput_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.teAngle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void teAngle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            else if ((((((e.KeyCode != Keys.D0) && (e.KeyCode != Keys.NumPad0)) && ((e.KeyCode != Keys.D1) && (e.KeyCode != Keys.NumPad1))) && (((e.KeyCode != Keys.D2) && (e.KeyCode != Keys.NumPad2)) && ((e.KeyCode != Keys.D3) && (e.KeyCode != Keys.NumPad3)))) && ((((e.KeyCode != Keys.D4) && (e.KeyCode != Keys.NumPad4)) && ((e.KeyCode != Keys.D5) && (e.KeyCode != Keys.NumPad5))) && (((e.KeyCode != Keys.D6) && (e.KeyCode != Keys.NumPad6)) && ((e.KeyCode != Keys.D7) && (e.KeyCode != Keys.NumPad7))))) && ((((e.KeyCode != Keys.D8) && (e.KeyCode != Keys.NumPad8)) && ((e.KeyCode != Keys.D9) && (e.KeyCode != Keys.NumPad9))) && (((e.KeyValue != 190) && (e.KeyCode != Keys.Back)) && (e.KeyCode != Keys.Enter))))
            {
                e.SuppressKeyPress = true;
            }
            else if ((this.teAngle.Text.Length == 0) && (e.KeyValue == 190))
            {
                e.SuppressKeyPress = true;
            }
            else if (((this.teAngle.Text == "9") || (this.teAngle.Text == "0")) && (((e.KeyValue != 190) && (e.KeyCode != Keys.Back)) && (e.KeyCode != Keys.Enter)))
            {
                e.SuppressKeyPress = true;
            }
            else if (this.teAngle.Text.Length == 2)
            {
                if (this.teAngle.Text.EndsWith("."))
                {
                    if (e.KeyValue == 190)
                    {
                        e.SuppressKeyPress = true;
                    }
                }
                else if (((e.KeyValue != 190) && (e.KeyCode != Keys.Back)) && (e.KeyCode != Keys.Enter))
                {
                    e.SuppressKeyPress = true;
                }
            }
            else if ((this.teAngle.Text.Length >= 3) && (e.KeyValue == 190))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void teAngle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.teAngle.Text))
            {
                XtraMessageBox.Show("角度不可为空！");
                this.teAngle.Focus();
            }
            if (this.teAngle.Text.EndsWith("."))
            {
                this.teAngle.Text = this.teAngle.Text.TrimEnd(new char[] { '.' });
            }
        }

        public double Angle
        {
            get
            {
                return this._angle;
            }
        }
    }
}

