namespace Print
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Output;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class MapSet : FormBase3
    {
        private IPageLayoutControl3 _pageLayoutControl;
        private IContainer components;
        private ESRIPage esriPage1;
        private SimpleButton sb_Cancel;
        private SimpleButton sb_OK;

        public MapSet(IPageLayoutControl3 pControl)
        {
            this.InitializeComponent();
            this.esriPage1.Control = pControl;
            this.esriPage1.InitControl();
            this._pageLayoutControl = pControl;
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
            this.esriPage1 = new ESRIPage();
            this.sb_OK = new SimpleButton();
            this.sb_Cancel = new SimpleButton();
            base.SuspendLayout();
            this.esriPage1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.esriPage1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.esriPage1.Appearance.Options.UseBackColor = true;
            this.esriPage1.Control = null;
            this.esriPage1.Dock = DockStyle.Top;
            this.esriPage1.Location = new Point(0, 0);
            this.esriPage1.Name = "esriPage1";
            this.esriPage1.Size = new Size(0x1b5, 0xac);
            this.esriPage1.TabIndex = 0;
            this.sb_OK.Location = new Point(140, 0xb1);
            this.sb_OK.Name = "sb_OK";
            this.sb_OK.Size = new Size(0x4b, 0x17);
            this.sb_OK.TabIndex = 1;
            this.sb_OK.Text = "确定";
            this.sb_OK.Click += new EventHandler(this.sb_OK_Click);
            this.sb_Cancel.Location = new Point(0xdd, 0xb1);
            this.sb_Cancel.Name = "sb_Cancel";
            this.sb_Cancel.Size = new Size(0x4b, 0x17);
            this.sb_Cancel.TabIndex = 2;
            this.sb_Cancel.Text = "取消";
            this.sb_Cancel.Click += new EventHandler(this.sb_Cancel_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b5, 0xd4);
            base.Controls.Add(this.sb_Cancel);
            base.Controls.Add(this.sb_OK);
            base.Controls.Add(this.esriPage1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MapSet";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "图幅设置";
            base.ResumeLayout(false);
        }

        private void sb_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void sb_OK_Click(object sender, EventArgs e)
        {
            IPaper paper = new PaperClass();
            paper.Attach(PrintController.PrintDocument.PrinterSettings.GetHdevmode(PrintController.PrintDocument.DefaultPageSettings).ToInt32(), PrintController.PrintDocument.PrinterSettings.GetHdevnames().ToInt32());
            this._pageLayoutControl.Printer.Paper = paper;
            MapPageSet mapPageSet = this.esriPage1.MapPageSet;
            this._pageLayoutControl.Page.FormID = mapPageSet.ID;
            this._pageLayoutControl.Page.Orientation = mapPageSet.OrienTation;
            if ((mapPageSet.ID == esriPageFormID.esriPageFormCUSTOM) || (mapPageSet.ID == esriPageFormID.esriPageFormSameAsPrinter))
            {
                this._pageLayoutControl.Page.PutCustomSize(this._pageLayoutControl.Printer.Paper.PrintableBounds.Width, this._pageLayoutControl.Printer.Paper.PrintableBounds.Height);
            }
            this._pageLayoutControl.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            base.DialogResult = DialogResult.OK;
        }
    }
}

