namespace Cartography.Business
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Transparent : FormBase3
    {
        private ILayer _layer;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private ComboBoxEdit comboMaxScale;
        private ComboBoxEdit comboMinScale;
        private IContainer components;
        private GroupBox groupBox1;
        private LabelControl labelControl1;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private Panel panel1;
        private Panel panel2;
        private PanelControl panelControl4;
        private RadioGroup radioGroup1;
        private SpinEdit seTransparent;

        public Transparent(ILayer pLayer)
        {
            this.InitializeComponent();
            this.comboMinScale.Leave += new EventHandler(this.comboMinScale_Leave);
            this.comboMinScale.KeyDown += new KeyEventHandler(this.comboMinScale_KeyDown);
            this.comboMaxScale.Leave += new EventHandler(this.comboMaxScale_Leave);
            this.comboMaxScale.KeyDown += new KeyEventHandler(this.comboMaxScale_KeyDown);
            this._layer = pLayer;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ILayerEffects effects = this._layer as ILayerEffects;
            effects.Transparency = (short) this.seTransparent.Value;
            double num = 0.0;
            double num2 = 0.0;
            if (this.radioGroup1.SelectedIndex == 1)
            {
                if (this.comboMinScale.EditValue.ToString() != "<无>")
                {
                    num = Convert.ToInt32(this.comboMinScale.EditValue.ToString().Substring(2).Replace(",", ""));
                }
                if (this.comboMaxScale.EditValue.ToString() != "<无>")
                {
                    num2 = Convert.ToInt32(this.comboMaxScale.EditValue.ToString().Substring(2).Replace(",", ""));
                }
            }
            this._layer.MinimumScale = num;
            this._layer.MaximumScale = num2;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void CheckScale(ComboBoxEdit pComboBox)
        {
            int num;
            string str = pComboBox.EditValue.ToString().Replace(" ", "");
            switch (str)
            {
                case "":
                case "<无>":
                    pComboBox.SelectedIndex = 0;
                    return;

                default:
                    num = 0;
                    if (str.IndexOf("1:") == 0)
                    {
                        string str2 = str.Substring(2).Replace(",", "");
                        try
                        {
                            num = Convert.ToInt32(str2);
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("请输入比例尺整数！", "提示");
                            return;
                        }
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Replace(",", ""));
                    }
                    catch
                    {
                        MessageBox.Show("请输入比例尺整数！", "提示");
                        return;
                    }
                    break;
            }
            str = "1:" + this.GetNumString((double) num);
            pComboBox.EditValue = str;
        }

        private void comboMaxScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckScale(this.comboMinScale);
            }
        }

        private void comboMaxScale_Leave(object sender, EventArgs e)
        {
            this.CheckScale(this.comboMaxScale);
        }

        private void comboMinScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckScale(this.comboMinScale);
            }
        }

        private void comboMinScale_Leave(object sender, EventArgs e)
        {
            this.CheckScale(this.comboMaxScale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetNumString(double num)
        {
            return num.ToString("#,###");
        }

        private void InitializeComponent()
        {
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.seTransparent = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboMaxScale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboMinScale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.seTransparent.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboMaxScale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboMinScale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Dock = System.Windows.Forms.DockStyle.Left;
            this.btOk.Location = new System.Drawing.Point(80, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(58, 27);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(191, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(56, 27);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "透明度:";
            // 
            // seTransparent
            // 
            this.seTransparent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTransparent.Location = new System.Drawing.Point(80, 10);
            this.seTransparent.Name = "seTransparent";
            this.seTransparent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seTransparent.Properties.IsFloatValue = false;
            this.seTransparent.Properties.Mask.EditMask = "N00";
            this.seTransparent.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seTransparent.Size = new System.Drawing.Size(117, 20);
            this.seTransparent.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelControl4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 136);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "比例尺范围";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Controls.Add(this.labelControl6);
            this.panelControl4.Controls.Add(this.labelControl5);
            this.panelControl4.Controls.Add(this.labelControl4);
            this.panelControl4.Controls.Add(this.comboMaxScale);
            this.panelControl4.Controls.Add(this.comboMinScale);
            this.panelControl4.Controls.Add(this.radioGroup1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(3, 18);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(321, 115);
            this.panelControl4.TabIndex = 87;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(38, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 88;
            this.labelControl7.Text = "小于：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(38, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "大于：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(219, 86);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(84, 14);
            this.labelControl5.TabIndex = 86;
            this.labelControl5.Text = "（最大比例尺）";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(219, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 85;
            this.labelControl4.Text = "（最小比例尺）";
            // 
            // comboMaxScale
            // 
            this.comboMaxScale.Location = new System.Drawing.Point(80, 83);
            this.comboMaxScale.Name = "comboMaxScale";
            this.comboMaxScale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboMaxScale.Size = new System.Drawing.Size(133, 20);
            this.comboMaxScale.TabIndex = 2;
            // 
            // comboMinScale
            // 
            this.comboMinScale.Location = new System.Drawing.Point(80, 56);
            this.comboMinScale.Name = "comboMinScale";
            this.comboMinScale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboMinScale.Size = new System.Drawing.Size(133, 20);
            this.comboMinScale.TabIndex = 1;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "所有比例尺下都显示"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "超出下列比例尺则不显示")});
            this.radioGroup1.Size = new System.Drawing.Size(321, 50);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.seTransparent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 43);
            this.panel1.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btOk);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 195);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(80, 0, 80, 10);
            this.panel2.Size = new System.Drawing.Size(327, 37);
            this.panel2.TabIndex = 93;
            // 
            // Transparent
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(337, 232);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Transparent";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "透明度与显示比例尺";
            this.Load += new System.EventHandler(this.Transparent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seTransparent.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboMaxScale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboMinScale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.comboMaxScale.Enabled = false;
                this.comboMinScale.Enabled = false;
            }
            else
            {
                this.comboMaxScale.Enabled = true;
                this.comboMinScale.Enabled = true;
            }
        }

        private void Transparent_Load(object sender, EventArgs e)
        {
            ILayerEffects effects = this._layer as ILayerEffects;
            this.seTransparent.Value = effects.Transparency;
            string[] strArray = new string[] { "<无>", "1:1,000", "1:10,000", "1:24,000", "1:100,000", "1:250,000", "1:500,000", "1:750,000", "1:1000,000" };
            for (int i = 0; i < strArray.Length; i++)
            {
                this.comboMinScale.Properties.Items.Add(strArray[i]);
            }
            this.comboMinScale.SelectedIndex = 0;
            for (int j = 0; j < strArray.Length; j++)
            {
                this.comboMaxScale.Properties.Items.Add(strArray[j]);
            }
            this.comboMaxScale.SelectedIndex = 0;
            double maximumScale = this._layer.MaximumScale;
            double minimumScale = this._layer.MinimumScale;
            if ((maximumScale == 0.0) && (minimumScale == 0.0))
            {
                this.radioGroup1.SelectedIndex = 0;
                this.comboMaxScale.Enabled = false;
                this.comboMinScale.Enabled = false;
            }
            else
            {
                this.radioGroup1.SelectedIndex = 1;
                this.comboMaxScale.Enabled = true;
                this.comboMinScale.Enabled = true;
                if (minimumScale == 0.0)
                {
                    this.comboMinScale.EditValue = "<无>";
                }
                else
                {
                    this.comboMinScale.EditValue = "1:" + this.GetNumString(minimumScale);
                }
                if (maximumScale == 0.0)
                {
                    this.comboMaxScale.EditValue = "<无>";
                }
                else
                {
                    this.comboMaxScale.EditValue = "1:" + this.GetNumString(maximumScale);
                }
            }
        }
    }
}

