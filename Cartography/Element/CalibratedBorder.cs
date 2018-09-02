namespace Cartography.Element
{
    using Cartography;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CalibratedBorder : FormBase3
    {
        private ICalibratedMapGridBorder _border;
        private ICalibratedMapGridBorder _origBorder = new CalibratedMapGridBorderClass();
        private bool backColor;
        private SimpleButton btCancel;
        private SimpleButton btFillColor;
        private SimpleButton btOk;
        private SimpleButton btVoidColor;
        private CheckEdit cbDouble;
        private ColorEdit ceFillColor;
        private ColorEdit ceVoidColor;
        private IContainer components;
        private bool foreColor;
        private bool ifSelectColor;
        private LabelControl lbFillColor;
        private LabelControl lbInterval;
        private LabelControl lbVoidColor;
        private LabelControl lbWidth;
        private SpinEdit nudInterval;
        private SpinEdit nudWidth;
        private IColor selectColor;
        private bool symbolColor;

        public CalibratedBorder(ICalibratedMapGridBorder pBorder)
        {
            this.InitializeComponent();
            this._border = pBorder;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btFillColor_Click(object sender, EventArgs e)
        {
            this.symbolColor = true;
            this.backColor = true;
            FrmColorSelector selector = new FrmColorSelector();
            this.ifSelectColor = true;
            this.selectColor = this._border.BackgroundColor;
            selector.SelectColor = this.selectColor;
            selector.OnColorSelect += new FrmColorSelector.ColorSelecthandler(this.colorSelect_OnColorSelect);
            selector.Show(this.btFillColor);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this._border.BackgroundColor = ColorService.NetColorToEsriColor(this.ceFillColor.Color);
            this._border.ForegroundColor = ColorService.NetColorToEsriColor(this.ceVoidColor.Color);
            this._border.BorderWidth = Convert.ToDouble(this.nudWidth.Value);
            this._border.Interval = Convert.ToDouble(this.nudInterval.Value);
            this._border.Alternating = this.cbDouble.Checked;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btVoidColor_Click(object sender, EventArgs e)
        {
            this.symbolColor = true;
            this.foreColor = true;
            FrmColorSelector selector = new FrmColorSelector();
            this.ifSelectColor = true;
            this.selectColor = this._border.ForegroundColor;
            selector.SelectColor = this.selectColor;
            selector.OnColorSelect += new FrmColorSelector.ColorSelecthandler(this.colorSelect_OnColorSelect1);
            selector.Show(this.btVoidColor);
        }

        private void CalibratedBorder_Activated(object sender, EventArgs e)
        {
        }

        private void CalibratedBorder_Load(object sender, EventArgs e)
        {
            this.ceFillColor.Color = ColorService.EsriColorToNetColor(this._border.BackgroundColor);
            this.ceVoidColor.Color = ColorService.EsriColorToNetColor(this._border.ForegroundColor);
            this.nudWidth.Value = decimal.Parse(this._border.BorderWidth.ToString());
            this.nudInterval.Value = decimal.Parse(this._border.Interval.ToString());
            this.cbDouble.Checked = this._border.Alternating;
        }

        private void colorSelect_OnColorSelect(IColor pColor)
        {
            this.btFillColor.Appearance.BackColor = ColorService.EsriColorToNetColor(pColor);
        }

        private void colorSelect_OnColorSelect1(IColor pColor)
        {
            this.btVoidColor.Appearance.BackColor = ColorService.EsriColorToNetColor(pColor);
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
            this.lbFillColor = new DevExpress.XtraEditors.LabelControl();
            this.lbVoidColor = new DevExpress.XtraEditors.LabelControl();
            this.lbWidth = new DevExpress.XtraEditors.LabelControl();
            this.lbInterval = new DevExpress.XtraEditors.LabelControl();
            this.btFillColor = new DevExpress.XtraEditors.SimpleButton();
            this.btVoidColor = new DevExpress.XtraEditors.SimpleButton();
            this.nudWidth = new DevExpress.XtraEditors.SpinEdit();
            this.nudInterval = new DevExpress.XtraEditors.SpinEdit();
            this.cbDouble = new DevExpress.XtraEditors.CheckEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ceFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.ceVoidColor = new DevExpress.XtraEditors.ColorEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDouble.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceVoidColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFillColor
            // 
            this.lbFillColor.Location = new System.Drawing.Point(85, 38);
            this.lbFillColor.Name = "lbFillColor";
            this.lbFillColor.Size = new System.Drawing.Size(40, 14);
            this.lbFillColor.TabIndex = 22;
            this.lbFillColor.Text = "填充色:";
            // 
            // lbVoidColor
            // 
            this.lbVoidColor.Location = new System.Drawing.Point(85, 83);
            this.lbVoidColor.Name = "lbVoidColor";
            this.lbVoidColor.Size = new System.Drawing.Size(40, 14);
            this.lbVoidColor.TabIndex = 23;
            this.lbVoidColor.Text = "间隔色:";
            // 
            // lbWidth
            // 
            this.lbWidth.Location = new System.Drawing.Point(85, 127);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(28, 14);
            this.lbWidth.TabIndex = 24;
            this.lbWidth.Text = "宽度:";
            // 
            // lbInterval
            // 
            this.lbInterval.Location = new System.Drawing.Point(85, 171);
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.Size = new System.Drawing.Size(28, 14);
            this.lbInterval.TabIndex = 25;
            this.lbInterval.Text = "间隔:";
            // 
            // btFillColor
            // 
            this.btFillColor.Location = new System.Drawing.Point(14, 5);
            this.btFillColor.LookAndFeel.SkinName = "Blue";
            this.btFillColor.Name = "btFillColor";
            this.btFillColor.Size = new System.Drawing.Size(87, 27);
            this.btFillColor.TabIndex = 26;
            this.btFillColor.Visible = false;
            this.btFillColor.Click += new System.EventHandler(this.btFillColor_Click);
            // 
            // btVoidColor
            // 
            this.btVoidColor.Location = new System.Drawing.Point(127, 5);
            this.btVoidColor.LookAndFeel.SkinName = "Blue";
            this.btVoidColor.Name = "btVoidColor";
            this.btVoidColor.Size = new System.Drawing.Size(87, 27);
            this.btVoidColor.TabIndex = 27;
            this.btVoidColor.Visible = false;
            this.btVoidColor.Click += new System.EventHandler(this.btVoidColor_Click);
            // 
            // nudWidth
            // 
            this.nudWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudWidth.Location = new System.Drawing.Point(147, 124);
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudWidth.Properties.LookAndFeel.SkinName = "Blue";
            this.nudWidth.Size = new System.Drawing.Size(87, 20);
            this.nudWidth.TabIndex = 28;
            // 
            // nudInterval
            // 
            this.nudInterval.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudInterval.Location = new System.Drawing.Point(147, 168);
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudInterval.Properties.LookAndFeel.SkinName = "Blue";
            this.nudInterval.Size = new System.Drawing.Size(87, 20);
            this.nudInterval.TabIndex = 29;
            // 
            // cbDouble
            // 
            this.cbDouble.Location = new System.Drawing.Point(163, 220);
            this.cbDouble.Name = "cbDouble";
            this.cbDouble.Properties.Caption = "使用双边框";
            this.cbDouble.Properties.LookAndFeel.SkinName = "Blue";
            this.cbDouble.Size = new System.Drawing.Size(103, 19);
            this.cbDouble.TabIndex = 30;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(85, 275);
            this.btOk.LookAndFeel.SkinName = "Blue";
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 31;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(181, 275);
            this.btCancel.LookAndFeel.SkinName = "Blue";
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 32;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ceFillColor
            // 
            this.ceFillColor.EditValue = System.Drawing.Color.Empty;
            this.ceFillColor.Location = new System.Drawing.Point(147, 38);
            this.ceFillColor.Name = "ceFillColor";
            this.ceFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceFillColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceFillColor.Size = new System.Drawing.Size(87, 20);
            this.ceFillColor.TabIndex = 33;
            // 
            // ceVoidColor
            // 
            this.ceVoidColor.EditValue = System.Drawing.Color.Empty;
            this.ceVoidColor.Location = new System.Drawing.Point(147, 79);
            this.ceVoidColor.Name = "ceVoidColor";
            this.ceVoidColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceVoidColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceVoidColor.Size = new System.Drawing.Size(87, 20);
            this.ceVoidColor.TabIndex = 34;
            // 
            // CalibratedBorder
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(353, 342);
            this.Controls.Add(this.ceVoidColor);
            this.Controls.Add(this.ceFillColor);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbDouble);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.btVoidColor);
            this.Controls.Add(this.btFillColor);
            this.Controls.Add(this.lbInterval);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbVoidColor);
            this.Controls.Add(this.lbFillColor);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibratedBorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "校准边框属性";
            this.Activated += new System.EventHandler(this.CalibratedBorder_Activated);
            this.Load += new System.EventHandler(this.CalibratedBorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDouble.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceVoidColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Bitmap PaintButton(IColor pColor, int pWidth, int pHeight)
        {
            Color color = ColorService.EsriColorToNetColor(pColor);
            Bitmap image = new Bitmap(pWidth, pHeight);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawRectangle(new Pen(color), 0, 0, pWidth, pHeight);
            graphics.FillRectangle(new SolidBrush(color), 0, 0, pWidth, pHeight);
            return image;
        }

        public ICalibratedMapGridBorder GridBorder
        {
            get
            {
                return this._border;
            }
        }
    }
}

