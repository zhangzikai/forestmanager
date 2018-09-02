namespace TopologyCheck.Checker
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class AreaInput : FormBase3
    {
        private double _area;
        private bool _close;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private IContainer components;
        private LabelControl lbDegree;
        private TextEdit teArea;

        public AreaInput()
        {
            this.InitializeComponent();
            this.Init();
        }

        private void AreaInput_FormClosed(object sender, FormClosedEventArgs e)
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
            if (string.IsNullOrEmpty(this.teArea.Text))
            {
                XtraMessageBox.Show("面积不能为空！");
            }
            else
            {
                this._close = true;
                this._area = double.Parse(this.teArea.Text.ToString());
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
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AreaValue");
            this.teArea.Text = configValue;
        }

        private void InitializeComponent()
        {
            this.lbDegree = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.teArea = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.teArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDegree
            // 
            this.lbDegree.Location = new System.Drawing.Point(134, 20);
            this.lbDegree.Name = "lbDegree";
            this.lbDegree.Size = new System.Drawing.Size(36, 14);
            this.lbDegree.TabIndex = 7;
            this.lbDegree.Text = "平方米";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(275, 15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(187, 15);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // teArea
            // 
            this.teArea.EditValue = "";
            this.teArea.Location = new System.Drawing.Point(9, 16);
            this.teArea.Name = "teArea";
            this.teArea.Size = new System.Drawing.Size(117, 20);
            this.teArea.TabIndex = 4;
            this.teArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teArea_KeyDown);
            this.teArea.Leave += new System.EventHandler(this.teArea_Leave);
            // 
            // AreaInput
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(364, 54);
            this.Controls.Add(this.lbDegree);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.teArea);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "最小面积";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AreaInput_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.teArea.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void teArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            else if ((((((e.KeyCode != Keys.D0) && (e.KeyCode != Keys.NumPad0)) && ((e.KeyCode != Keys.D1) && (e.KeyCode != Keys.NumPad1))) && (((e.KeyCode != Keys.D2) && (e.KeyCode != Keys.NumPad2)) && ((e.KeyCode != Keys.D3) && (e.KeyCode != Keys.NumPad3)))) && ((((e.KeyCode != Keys.D4) && (e.KeyCode != Keys.NumPad4)) && ((e.KeyCode != Keys.D5) && (e.KeyCode != Keys.NumPad5))) && (((e.KeyCode != Keys.D6) && (e.KeyCode != Keys.NumPad6)) && ((e.KeyCode != Keys.D7) && (e.KeyCode != Keys.NumPad7))))) && ((((e.KeyCode != Keys.D8) && (e.KeyCode != Keys.NumPad8)) && ((e.KeyCode != Keys.D9) && (e.KeyCode != Keys.NumPad9))) && (((e.KeyValue != 190) && (e.KeyCode != Keys.Back)) && (e.KeyCode != Keys.Enter))))
            {
                e.SuppressKeyPress = true;
            }
            else if ((this.teArea.Text.Length == 0) && (e.KeyValue == 190))
            {
                e.SuppressKeyPress = true;
            }
            else if (this.teArea.Text.EndsWith(".") && (e.KeyValue == 0x76c))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void teArea_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.teArea.Text))
            {
                XtraMessageBox.Show("面积不可为空！");
                this.teArea.Focus();
            }
            if (this.teArea.Text.EndsWith("."))
            {
                this.teArea.Text = this.teArea.Text.TrimEnd(new char[] { '.' });
            }
        }

        public double Area
        {
            get
            {
                return this._area;
            }
        }
    }
}

