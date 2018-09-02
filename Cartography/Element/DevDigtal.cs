namespace Cartography.Element
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DevDigtal : FormBase3
    {
        private INumberFormat _fommat;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private CheckEdit cbPad;
        private CheckEdit cbPlug;
        private CheckEdit cbThou;
        private IContainer components;
        private INumericFormat formmat = new NumericFormatClass();
        private GroupBox gbNAlign;
        private GroupBox gbNRounding;
        private IFormattedGridLabel gridLabel;
        private LabelControl lbChar;
        private SpinEdit nudAlign;
        private SpinEdit nudRounding;
        private RadioGroup rgAlignment;
        private RadioGroup rgRound;

        public DevDigtal(INumberFormat pFormat)
        {
            this.InitializeComponent();
            this._fommat = pFormat;
            if (pFormat != null)
            {
                IObjectCopy copy = new ObjectCopyClass();
                object pInObject = copy.Copy(pFormat);
                object formmat = this.formmat;
                copy.Overwrite(pInObject, ref formmat);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this._fommat = (INumberFormat) this.formmat;
            base.Close();
        }

        private void cbPad_CheckedChanged(object sender, EventArgs e)
        {
            this.formmat.ZeroPad = this.cbPad.Checked;
        }

        private void cbPlug_CheckedChanged(object sender, EventArgs e)
        {
            this.formmat.ShowPlusSign = this.cbPlug.Checked;
        }

        private void cbThou_CheckedChanged(object sender, EventArgs e)
        {
            this.formmat.UseSeparator = this.cbThou.Checked;
        }

        private void DevDigtal_Load(object sender, EventArgs e)
        {
            this.InitialControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitialControl()
        {
            if (this.formmat.RoundingOption == esriRoundingOptionEnum.esriRoundNumberOfDecimals)
            {
                this.rgRound.SelectedIndex = 0;
            }
            else
            {
                this.rgRound.SelectedIndex = 1;
            }
            this.nudRounding.Value = decimal.Parse(this.formmat.RoundingValue.ToString());
            if (this.formmat.AlignmentOption == esriNumericAlignmentEnum.esriAlignLeft)
            {
                this.rgAlignment.SelectedIndex = 0;
                this.nudAlign.Enabled = false;
            }
            else
            {
                this.rgAlignment.SelectedIndex = 1;
                this.nudAlign.Value = decimal.Parse(this.formmat.AlignmentWidth.ToString());
            }
            this.cbPad.Checked = this.formmat.ZeroPad;
            this.cbPlug.Checked = this.formmat.ShowPlusSign;
            this.cbThou.Checked = this.formmat.UseSeparator;
        }

        private void InitializeComponent()
        {
            this.gbNAlign = new System.Windows.Forms.GroupBox();
            this.lbChar = new DevExpress.XtraEditors.LabelControl();
            this.nudAlign = new DevExpress.XtraEditors.SpinEdit();
            this.rgAlignment = new DevExpress.XtraEditors.RadioGroup();
            this.gbNRounding = new System.Windows.Forms.GroupBox();
            this.nudRounding = new DevExpress.XtraEditors.SpinEdit();
            this.rgRound = new DevExpress.XtraEditors.RadioGroup();
            this.cbThou = new DevExpress.XtraEditors.CheckEdit();
            this.cbPad = new DevExpress.XtraEditors.CheckEdit();
            this.cbPlug = new DevExpress.XtraEditors.CheckEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gbNAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAlignment.Properties)).BeginInit();
            this.gbNRounding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgRound.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPlug.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbNAlign
            // 
            this.gbNAlign.Controls.Add(this.lbChar);
            this.gbNAlign.Controls.Add(this.nudAlign);
            this.gbNAlign.Controls.Add(this.rgAlignment);
            this.gbNAlign.Location = new System.Drawing.Point(24, 111);
            this.gbNAlign.Name = "gbNAlign";
            this.gbNAlign.Size = new System.Drawing.Size(234, 82);
            this.gbNAlign.TabIndex = 22;
            this.gbNAlign.TabStop = false;
            this.gbNAlign.Text = "对齐";
            // 
            // lbChar
            // 
            this.lbChar.Location = new System.Drawing.Point(183, 37);
            this.lbChar.Name = "lbChar";
            this.lbChar.Size = new System.Drawing.Size(24, 14);
            this.lbChar.TabIndex = 8;
            this.lbChar.Text = "字符";
            // 
            // nudAlign
            // 
            this.nudAlign.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAlign.Location = new System.Drawing.Point(106, 34);
            this.nudAlign.Name = "nudAlign";
            this.nudAlign.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.nudAlign.Properties.Appearance.Options.UseBackColor = true;
            this.nudAlign.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudAlign.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudAlign.Size = new System.Drawing.Size(70, 20);
            this.nudAlign.TabIndex = 7;
            this.nudAlign.ValueChanged += new System.EventHandler(this.nudAlign_ValueChanged);
            // 
            // rgAlignment
            // 
            this.rgAlignment.Location = new System.Drawing.Point(8, 16);
            this.rgAlignment.Name = "rgAlignment";
            this.rgAlignment.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.rgAlignment.Properties.Appearance.Options.UseBackColor = true;
            this.rgAlignment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgAlignment.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "左对齐"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "右对齐")});
            this.rgAlignment.Size = new System.Drawing.Size(91, 58);
            this.rgAlignment.TabIndex = 6;
            this.rgAlignment.SelectedIndexChanged += new System.EventHandler(this.rgAlignment_SelectedIndexChanged);
            // 
            // gbNRounding
            // 
            this.gbNRounding.Controls.Add(this.nudRounding);
            this.gbNRounding.Controls.Add(this.rgRound);
            this.gbNRounding.Location = new System.Drawing.Point(24, 15);
            this.gbNRounding.Name = "gbNRounding";
            this.gbNRounding.Size = new System.Drawing.Size(234, 89);
            this.gbNRounding.TabIndex = 21;
            this.gbNRounding.TabStop = false;
            this.gbNRounding.Text = "舍入";
            this.gbNRounding.UseCompatibleTextRendering = true;
            // 
            // nudRounding
            // 
            this.nudRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRounding.Location = new System.Drawing.Point(106, 40);
            this.nudRounding.Name = "nudRounding";
            this.nudRounding.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.nudRounding.Properties.Appearance.Options.UseBackColor = true;
            this.nudRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudRounding.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudRounding.Size = new System.Drawing.Size(70, 20);
            this.nudRounding.TabIndex = 4;
            this.nudRounding.ValueChanged += new System.EventHandler(this.nudRounding_ValueChanged);
            // 
            // rgRound
            // 
            this.rgRound.Location = new System.Drawing.Point(8, 23);
            this.rgRound.Name = "rgRound";
            this.rgRound.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.rgRound.Properties.Appearance.Options.UseBackColor = true;
            this.rgRound.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgRound.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "小数位数"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "有效位数")});
            this.rgRound.Size = new System.Drawing.Size(91, 58);
            this.rgRound.TabIndex = 3;
            this.rgRound.RightToLeftChanged += new System.EventHandler(this.rgRound_RightToLeftChanged);
            // 
            // cbThou
            // 
            this.cbThou.Location = new System.Drawing.Point(36, 244);
            this.cbThou.Name = "cbThou";
            this.cbThou.Properties.Caption = "显示千分位分隔符";
            this.cbThou.Size = new System.Drawing.Size(135, 19);
            this.cbThou.TabIndex = 28;
            this.cbThou.CheckedChanged += new System.EventHandler(this.cbThou_CheckedChanged);
            // 
            // cbPad
            // 
            this.cbPad.Location = new System.Drawing.Point(36, 199);
            this.cbPad.Name = "cbPad";
            this.cbPad.Properties.Caption = "加零";
            this.cbPad.Size = new System.Drawing.Size(87, 19);
            this.cbPad.TabIndex = 29;
            this.cbPad.CheckedChanged += new System.EventHandler(this.cbPad_CheckedChanged);
            // 
            // cbPlug
            // 
            this.cbPlug.Location = new System.Drawing.Point(128, 199);
            this.cbPlug.Name = "cbPlug";
            this.cbPlug.Properties.Caption = "显示加号";
            this.cbPlug.Size = new System.Drawing.Size(87, 19);
            this.cbPlug.TabIndex = 30;
            this.cbPlug.CheckedChanged += new System.EventHandler(this.cbPlug_CheckedChanged);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(38, 289);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 31;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(148, 289);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 32;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // DevDigtal
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(282, 329);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbPlug);
            this.Controls.Add(this.cbPad);
            this.Controls.Add(this.cbThou);
            this.Controls.Add(this.gbNAlign);
            this.Controls.Add(this.gbNRounding);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevDigtal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数字格式";
            this.Load += new System.EventHandler(this.DevDigtal_Load);
            this.gbNAlign.ResumeLayout(false);
            this.gbNAlign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAlignment.Properties)).EndInit();
            this.gbNRounding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgRound.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPlug.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void nudAlign_ValueChanged(object sender, EventArgs e)
        {
            this.formmat.AlignmentWidth = int.Parse(this.nudAlign.Value.ToString());
            this.nudAlign.Enabled = true;
        }

        private void nudRounding_ValueChanged(object sender, EventArgs e)
        {
            this.formmat.RoundingValue = int.Parse(this.nudRounding.Value.ToString());
        }

        private void rgAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgAlignment.SelectedIndex == 0)
            {
                this.formmat.AlignmentOption = esriNumericAlignmentEnum.esriAlignLeft;
                this.nudAlign.Enabled = false;
            }
            else
            {
                this.formmat.AlignmentOption = esriNumericAlignmentEnum.esriAlignRight;
                this.nudAlign.Enabled = true;
            }
        }

        private void rgRound_RightToLeftChanged(object sender, EventArgs e)
        {
            if (this.rgRound.SelectedIndex == 0)
            {
                this.formmat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfDecimals;
            }
            else
            {
                this.formmat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfSignificantDigits;
            }
        }

        public INumberFormat Formmat
        {
            get
            {
                return this._fommat;
            }
        }
    }
}

