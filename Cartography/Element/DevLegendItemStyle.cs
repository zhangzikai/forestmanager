namespace Cartography.Element
{
    using Cartography;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class DevLegendItemStyle : FormBase3
    {
        private ILegendFormat _legendFormat;
        private List<ILegendItem> _legendItems;
        private IScreenDisplay _screenDisplay;
        private AxSymbologyControl axsc;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private ImageComboBoxEdit cbPatchArea;
        private ImageComboBoxEdit cbPatchLine;
        private IContainer components;
        private GroupBox gbPatch;
        private GroupBox gbPreView;
        private LabelControl lbArea;
        private LabelControl lbItemHeight;
        private LabelControl lbItemWidth;
        private LabelControl lbLine;
        private IStyleGalleryItem m_styleGalleryItem = new ServerStyleGalleryItemClass();
        private PictureEdit pbPreview;
        private TextEdit txtItemHeigt;
        private TextEdit txtItemWidth;

        public DevLegendItemStyle()
        {
            this.InitializeComponent();
            base.DialogResult = DialogResult.Cancel;
        }

        private void axsc_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            IStyleGalleryItem styleGalleryItem = (IStyleGalleryItem) e.styleGalleryItem;
            if (this.m_styleGalleryItem != styleGalleryItem)
            {
                this.m_styleGalleryItem = styleGalleryItem;
                this._legendItems = LegendService.CreateLegendItemFromExist(this._legendItems, (ILegendItem) this.m_styleGalleryItem.Item, this._screenDisplay, this._legendFormat);
                this.m_styleGalleryItem.Item = this._legendItems[0];
                this.PreviewImage();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(DevLegendItemStyle));
            this.gbPreView = new GroupBox();
            this.pbPreview = new PictureEdit();
            this.axsc = new AxSymbologyControl();
            this.btOk = new SimpleButton();
            this.btCancel = new SimpleButton();
            this.gbPatch = new GroupBox();
            this.cbPatchArea = new ImageComboBoxEdit();
            this.cbPatchLine = new ImageComboBoxEdit();
            this.txtItemHeigt = new TextEdit();
            this.txtItemWidth = new TextEdit();
            this.lbArea = new LabelControl();
            this.lbLine = new LabelControl();
            this.lbItemHeight = new LabelControl();
            this.lbItemWidth = new LabelControl();
            this.gbPreView.SuspendLayout();
            this.pbPreview.Properties.BeginInit();
            this.axsc.BeginInit();
            this.gbPatch.SuspendLayout();
            this.cbPatchArea.Properties.BeginInit();
            this.cbPatchLine.Properties.BeginInit();
            this.txtItemHeigt.Properties.BeginInit();
            this.txtItemWidth.Properties.BeginInit();
            base.SuspendLayout();
            this.gbPreView.Controls.Add(this.pbPreview);
            this.gbPreView.Location = new Point(0x160, 11);
            this.gbPreView.Name = "gbPreView";
            this.gbPreView.Size = new Size(0xb0, 0x9f);
            this.gbPreView.TabIndex = 4;
            this.gbPreView.TabStop = false;
            this.gbPreView.Text = "预览";
            this.pbPreview.Location = new Point(3, 0x10);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Properties.Appearance.BackColor = Color.Transparent;
            this.pbPreview.Properties.Appearance.Options.UseBackColor = true;
            this.pbPreview.Properties.BorderStyle = BorderStyles.NoBorder;
            this.pbPreview.Size = new Size(170, 140);
            this.pbPreview.TabIndex = 0;
            this.axsc.Location = new Point(11, 11);
            this.axsc.Name = "axsc";
//            this.axsc.OcxState = (AxHost.State) manager.GetObject("axsc.OcxState");
            this.axsc.Size = new Size(0x141, 0x1e8);
            this.axsc.TabIndex = 3;
            this.axsc.OnItemSelected += new ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axsc_OnItemSelected);
            this.btOk.Location = new Point(0x160, 0x171);
            this.btOk.Name = "btOk";
            this.btOk.Size = new Size(0x4b, 0x17);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "确定";
            this.btOk.Click += new EventHandler(this.btOk_Click);
            this.btCancel.Location = new Point(450, 0x171);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new Size(0x4b, 0x17);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new EventHandler(this.btCancel_Click);
            this.gbPatch.Controls.Add(this.cbPatchArea);
            this.gbPatch.Controls.Add(this.cbPatchLine);
            this.gbPatch.Controls.Add(this.txtItemHeigt);
            this.gbPatch.Controls.Add(this.txtItemWidth);
            this.gbPatch.Controls.Add(this.lbArea);
            this.gbPatch.Controls.Add(this.lbLine);
            this.gbPatch.Controls.Add(this.lbItemHeight);
            this.gbPatch.Controls.Add(this.lbItemWidth);
            this.gbPatch.Location = new Point(0x163, 0xb0);
            this.gbPatch.Name = "gbPatch";
            this.gbPatch.Size = new Size(170, 140);
            this.gbPatch.TabIndex = 0x1d;
            this.gbPatch.TabStop = false;
            this.gbPatch.Text = "符号(单位:像素)";
            this.gbPatch.Visible = false;
            this.cbPatchArea.Location = new Point(0x2f, 0x73);
            this.cbPatchArea.Name = "cbPatchArea";
            this.cbPatchArea.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cbPatchArea.Size = new Size(0x44, 0x15);
            this.cbPatchArea.TabIndex = 0x11;
            this.cbPatchLine.Location = new Point(0x2f, 0x56);
            this.cbPatchLine.Name = "cbPatchLine";
            this.cbPatchLine.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cbPatchLine.Size = new Size(0x44, 0x15);
            this.cbPatchLine.TabIndex = 0x10;
            this.txtItemHeigt.EditValue = "";
            this.txtItemHeigt.Location = new Point(0x2f, 0x39);
            this.txtItemHeigt.Name = "txtItemHeigt";
            this.txtItemHeigt.Size = new Size(0x44, 0x15);
            this.txtItemHeigt.TabIndex = 15;
            this.txtItemWidth.EditValue = "";
            this.txtItemWidth.Location = new Point(0x2f, 0x1c);
            this.txtItemWidth.Name = "txtItemWidth";
            this.txtItemWidth.Size = new Size(0x44, 0x15);
            this.txtItemWidth.TabIndex = 14;
            this.lbArea.Location = new Point(10, 0x76);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new Size(0x18, 14);
            this.lbArea.TabIndex = 13;
            this.lbArea.Text = "  面:";
            this.lbLine.Location = new Point(10, 0x59);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new Size(0x18, 14);
            this.lbLine.TabIndex = 12;
            this.lbLine.Text = "  线:";
            this.lbItemHeight.Location = new Point(10, 0x3b);
            this.lbItemHeight.Name = "lbItemHeight";
            this.lbItemHeight.Size = new Size(0x1c, 14);
            this.lbItemHeight.TabIndex = 11;
            this.lbItemHeight.Text = "高度:";
            this.lbItemWidth.Location = new Point(10, 0x1f);
            this.lbItemWidth.Name = "lbItemWidth";
            this.lbItemWidth.Size = new Size(0x1c, 14);
            this.lbItemWidth.TabIndex = 10;
            this.lbItemWidth.Text = "宽度:";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x21b, 510);
            base.Controls.Add(this.gbPatch);
            base.Controls.Add(this.btCancel);
            base.Controls.Add(this.btOk);
            base.Controls.Add(this.gbPreView);
            base.Controls.Add(this.axsc);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DevLegendItemStyle";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "图例符号";
            base.Load += new EventHandler(this.LegendItemStyle_Load);
            base.FormClosed += new FormClosedEventHandler(this.LegendItemStyle_FormClosed);
            this.gbPreView.ResumeLayout(false);
            this.pbPreview.Properties.EndInit();
            this.axsc.EndInit();
            this.gbPatch.ResumeLayout(false);
            this.gbPatch.PerformLayout();
            this.cbPatchArea.Properties.EndInit();
            this.cbPatchLine.Properties.EndInit();
            this.txtItemHeigt.Properties.EndInit();
            this.txtItemWidth.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void LegendItemStyle_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void LegendItemStyle_Load(object sender, EventArgs e)
        {
            this.axsc.StyleClass = esriSymbologyStyleClass.esriStyleClassLegendItems;
            string fileName = "";
            try
            {
                fileName = ElementService.StyleGalleryFile;
            }
            catch (FileNotFoundException exception)
            {
                XtraMessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK);
                return;
            }
            this.axsc.LoadStyleFile(fileName);
            this.PreviewImage();
        }

        private void PreviewImage()
        {
            Image image = Image.FromHbitmap(new IntPtr(this.axsc.GetStyleClass(this.axsc.StyleClass).PreviewItem(this.m_styleGalleryItem, this.pbPreview.Width, this.pbPreview.Height).Handle));
            this.pbPreview.Image = image;
        }

        public ILegendFormat LegendFormat
        {
            set
            {
                this._legendFormat = value;
            }
        }

        public List<ILegendItem> LegendItems
        {
            get
            {
                return this._legendItems;
            }
            set
            {
                this._legendItems = value;
                this.m_styleGalleryItem.Item = this._legendItems[0];
            }
        }

        public IScreenDisplay ScreenDisplay
        {
            set
            {
                this._screenDisplay = value;
            }
        }
    }
}

