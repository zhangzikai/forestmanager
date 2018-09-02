namespace Print
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public class ESRIPage : UserControlBase1
    {
        private Print.MapPageSet _mapPageSet;
        private IPageLayoutControl3 _pControl;
        private Print.PrinterSet _printerSet;
        private System.Windows.Forms.ComboBox cbSize;
        private CheckBox cbUsePrinterPaper;
        private IContainer components;
        private GroupBox gbMapPage;
        private bool init;
        private bool IsPrinter;
        private Label label3;
        private Label lbHeight;
        private Label lbHeightUnit;
        private Label lbOri;
        private Label lbOverlap;
        private Label lbOverlapUnit;
        private Label lbSameAsPrinter;
        private Label lbSize;
        private Label lbWidth;
        private Label lbWidthUnit;
        private RadioButton rbLand;
        private RadioButton rbPor;
        private TextBox tbHight;
        private TextBox tbOverlap;
        private TextBox tbWidth;

        public ESRIPage()
        {
            this.InitializeComponent();
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!this.init && !this.IsPrinter) && !this.cbUsePrinterPaper.Checked)
            {
                if (this.cbSize.Text == "自定义")
                {
                    this.tbHight.ReadOnly = false;
                    this.tbWidth.ReadOnly = false;
                    this._mapPageSet.ID = esriPageFormID.esriPageFormCUSTOM;
                }
                else
                {
                    double num;
                    double num2;
                    this.tbHight.ReadOnly = true;
                    this.tbWidth.ReadOnly = true;
                    esriPageFormID formIdByName = FormService.GetFormIdByName(this.cbSize.Text);
                    this._mapPageSet.ID = formIdByName;
                    DeviceService.GetPaperSize(this._printerSet.PrinterName, this._printerSet.PortName, this.cbSize.Text, out num, out num2);
                    if (this.rbPor.Checked)
                    {
                        this._mapPageSet.Width = num;
                        this._mapPageSet.Height = num2;
                        this.tbWidth.Text = Math.Round(num, 1).ToString();
                        this.tbHight.Text = Math.Round(num2, 1).ToString();
                    }
                    else
                    {
                        this._mapPageSet.Width = num2;
                        this._mapPageSet.Height = num;
                        this.tbWidth.Text = Math.Round(num2, 1).ToString();
                        this.tbHight.Text = Math.Round(num, 1).ToString();
                    }
                }
                this.EnableOverLap();
            }
        }

        private void cbUsePrinterPaper_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.cbUsePrinterPaper.Checked)
                {
                    double num;
                    double num2;
                    this.lbSameAsPrinter.Visible = true;
                    this.cbSize.Visible = false;
                    this.tbHight.ReadOnly = true;
                    this.tbWidth.ReadOnly = true;
                    this.rbPor.Enabled = this.rbLand.Enabled = false;
                    esriPageFormID formIdByName = FormService.GetFormIdByName(this._printerSet.FormName);
                    this._mapPageSet.ID = esriPageFormID.esriPageFormSameAsPrinter;
                    if (formIdByName == esriPageFormID.esriPageFormCUSTOM)
                    {
                        this.cbSize.Text = "自定义";
                    }
                    else
                    {
                        this.cbSize.Text = this._printerSet.FormName;
                    }
                    DeviceService.GetPaperSize(this._printerSet.PrinterName, this._printerSet.PortName, this._printerSet.FormName, out num, out num2);
                    IUnitConverter converter = new UnitConverterClass();
                    num = converter.ConvertUnits(num, esriUnits.esriCentimeters, this._pControl.Page.Units);
                    num2 = converter.ConvertUnits(num2, esriUnits.esriCentimeters, this._pControl.Page.Units);
                    if (this._printerSet.OrienTation == 2)
                    {
                        this._mapPageSet.Width = num2;
                        this._mapPageSet.Height = num;
                        this.tbWidth.Text = Math.Round(num2, 1).ToString();
                        this.tbHight.Text = Math.Round(num, 1).ToString();
                    }
                    else
                    {
                        this._mapPageSet.Width = num;
                        this._mapPageSet.Height = num2;
                        this.tbWidth.Text = Math.Round(num, 1).ToString();
                        this.tbHight.Text = Math.Round(num2, 1).ToString();
                    }
                    this._mapPageSet.OrienTation = this._printerSet.OrienTation;
                    if (this._printerSet.OrienTation == 2)
                    {
                        this.rbLand.Checked = true;
                    }
                    else
                    {
                        this.rbPor.Checked = true;
                    }
                }
                else
                {
                    this._mapPageSet.ID = FormService.GetFormIdByName(this.cbSize.Text);
                    if (this.cbSize.Text == "自定义")
                    {
                        this.tbHight.ReadOnly = false;
                        this.tbWidth.ReadOnly = false;
                    }
                    this.lbSameAsPrinter.Visible = false;
                    this.cbSize.Visible = true;
                    this.rbLand.Enabled = this.rbPor.Enabled = true;
                }
                this.EnableOverLap();
            }
        }

        public void ChangeControl(Print.PrinterSet pSet)
        {
            if (this.cbUsePrinterPaper.Checked)
            {
                double num;
                double num2;
                this.IsPrinter = true;
                if (FormService.GetSizeByFormID(FormService.GetFormIdByName(pSet.FormName), this._pControl.Page.Units).Width != -1f)
                {
                    this.cbSize.Text = pSet.FormName;
                }
                else
                {
                    this.cbSize.Text = "自定义";
                }
                DeviceService.GetPaperSize(this._printerSet.PrinterName, this._printerSet.PortName, this._printerSet.FormName, out num, out num2);
                IUnitConverter converter = new UnitConverterClass();
                num = converter.ConvertUnits(num, esriUnits.esriCentimeters, this._pControl.Page.Units);
                num2 = converter.ConvertUnits(num2, esriUnits.esriCentimeters, this._pControl.Page.Units);
                if (this._printerSet.OrienTation == 2)
                {
                    this._mapPageSet.Width = num2;
                    this._mapPageSet.Height = num;
                    this.tbWidth.Text = Math.Round(num2, 1).ToString();
                    this.tbHight.Text = Math.Round(num, 1).ToString();
                }
                else
                {
                    this._mapPageSet.Width = num;
                    this._mapPageSet.Height = num2;
                    this.tbWidth.Text = Math.Round(num, 1).ToString();
                    this.tbHight.Text = Math.Round(num2, 1).ToString();
                }
                this._mapPageSet.OrienTation = this._printerSet.OrienTation;
                if (pSet.OrienTation == 2)
                {
                    this.rbLand.Checked = true;
                }
                else
                {
                    this.rbPor.Checked = true;
                }
                this.tbOverlap.ReadOnly = true;
                this.tbOverlap.Text = "0";
                Print.MapPageSet.OverLap = -1.0;
                this.IsPrinter = false;
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

        private void EnableOverLap()
        {
            double height;
            double width;
            if (this.init)
            {
                PrintDocument document = new PrintDocument();
                if (document.DefaultPageSettings.Landscape)
                {
                    height = document.DefaultPageSettings.PaperSize.Height;
                    width = document.DefaultPageSettings.PaperSize.Width;
                }
                else
                {
                    height = document.DefaultPageSettings.PaperSize.Width;
                    width = document.DefaultPageSettings.PaperSize.Height;
                }
                if ((height != this._mapPageSet.Width) || (width != this._mapPageSet.Height))
                {
                    this.tbOverlap.ReadOnly = false;
                }
                else
                {
                    this.tbOverlap.ReadOnly = true;
                    this.tbOverlap.Text = "0";
                    Print.MapPageSet.OverLap = -1.0;
                }
            }
            else
            {
                DeviceService.GetPaperSize(this._printerSet.PrinterName, this._printerSet.PortName, this._printerSet.FormName, out height, out width);
                if (this._printerSet.OrienTation == 2)
                {
                    width = height;
                    height = width;
                }
                if ((height != this._mapPageSet.Width) || (width != this._mapPageSet.Height))
                {
                    this.tbOverlap.ReadOnly = false;
                }
                else
                {
                    this.tbOverlap.ReadOnly = true;
                    this.tbOverlap.Text = "0";
                    Print.MapPageSet.OverLap = -1.0;
                }
            }
        }

        public void InitControl()
        {
            double num;
            double num2;
            this.init = true;
            this._mapPageSet = new Print.MapPageSet();
            if (string.IsNullOrEmpty(this._printerSet.FormName))
            {
                this._printerSet = new Print.PrinterSet();
                this._printerSet.PrinterName = Print.PrintController.PrintDocument.PrinterSettings.PrinterName;
                this._printerSet.FormName = Print.PrintController.PrintDocument.DefaultPageSettings.PaperSize.PaperName;
                if (Print.PrintController.PrintDocument.DefaultPageSettings.Landscape)
                {
                    this._printerSet.OrienTation = 2;
                }
                else
                {
                    this._printerSet.OrienTation = 1;
                }
                this._printerSet.PortName = Print.PrintController.SH.PrinterInfo5.PortName;
            }
            this._mapPageSet.ID = this._pControl.Page.FormID;
            this._mapPageSet.OrienTation = this._pControl.Page.Orientation;
            IEnumNamedID forms = this._pControl.Printer.Paper.Forms;
            this.lbSameAsPrinter.Visible = false;
            this.tbHight.ReadOnly = true;
            this.tbWidth.ReadOnly = true;
            string nextName = "";
            forms.Next(out nextName);
            while (!string.IsNullOrEmpty(nextName))
            {
                if (nextName.Contains("Custom") || nextName.Contains("自定义"))
                {
                    nextName = "自定义";
                }
                this.cbSize.Items.Add(nextName);
                forms.Next(out nextName);
            }
            if (this.cbSize.Items.IndexOf("自定义") == -1)
            {
                this.cbSize.Items.Add("自定义");
            }
            if (this._pControl.Page.FormID == esriPageFormID.esriPageFormSameAsPrinter)
            {
                esriPageFormID formIdByName = FormService.GetFormIdByName(this._printerSet.FormName);
                this.cbSize.Text = FormService.GetFormStrByEnum(formIdByName);
            }
            else
            {
                this.cbSize.Text = FormService.GetFormStrByEnum(this._pControl.Page.FormID);
            }
            if (this._pControl.Page.FormID == esriPageFormID.esriPageFormSameAsPrinter)
            {
                this.lbSameAsPrinter.Visible = true;
                this.cbSize.Visible = false;
                this.cbUsePrinterPaper.Checked = true;
                this.rbPor.Enabled = false;
                this.rbLand.Enabled = false;
                this.tbOverlap.ReadOnly = false;
            }
            else if (this._pControl.Page.FormID == esriPageFormID.esriPageFormCUSTOM)
            {
                this.lbSameAsPrinter.Visible = false;
                this.tbHight.ReadOnly = false;
                this.tbWidth.ReadOnly = false;
            }
            if (Print.MapPageSet.OverLap == -1.0)
            {
                this.tbOverlap.Text = "0";
            }
            else
            {
                this.tbOverlap.Text = Print.MapPageSet.OverLap.ToString();
            }
            this._pControl.Page.QuerySize(out num, out num2);
            this._mapPageSet.Width = num;
            this._mapPageSet.Height = num2;
            this.tbWidth.Text = Math.Round(num, 1).ToString();
            this.tbHight.Text = Math.Round(num2, 1).ToString();
            this.lbOverlapUnit.Text = this.lbWidthUnit.Text = this.lbHeightUnit.Text = UnitService.GetCN(this._pControl.Page.Units);
            if (this._pControl.Page.Orientation == 2)
            {
                this.rbLand.Checked = true;
            }
            else
            {
                this.rbPor.Checked = true;
            }
            this.EnableOverLap();
            this.init = false;
        }

        private void InitializeComponent()
        {
            this.gbMapPage = new GroupBox();
            this.lbOverlapUnit = new Label();
            this.tbOverlap = new TextBox();
            this.lbOverlap = new Label();
            this.lbSameAsPrinter = new Label();
            this.cbUsePrinterPaper = new CheckBox();
            this.rbPor = new RadioButton();
            this.rbLand = new RadioButton();
            this.lbOri = new Label();
            this.lbHeightUnit = new Label();
            this.tbHight = new TextBox();
            this.tbWidth = new TextBox();
            this.lbWidthUnit = new Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.label3 = new Label();
            this.lbHeight = new Label();
            this.lbWidth = new Label();
            this.lbSize = new Label();
            this.gbMapPage.SuspendLayout();
            base.SuspendLayout();
            this.gbMapPage.Controls.Add(this.lbOverlapUnit);
            this.gbMapPage.Controls.Add(this.tbOverlap);
            this.gbMapPage.Controls.Add(this.lbOverlap);
            this.gbMapPage.Controls.Add(this.lbSameAsPrinter);
            this.gbMapPage.Controls.Add(this.cbUsePrinterPaper);
            this.gbMapPage.Controls.Add(this.rbPor);
            this.gbMapPage.Controls.Add(this.rbLand);
            this.gbMapPage.Controls.Add(this.lbOri);
            this.gbMapPage.Controls.Add(this.lbHeightUnit);
            this.gbMapPage.Controls.Add(this.tbHight);
            this.gbMapPage.Controls.Add(this.tbWidth);
            this.gbMapPage.Controls.Add(this.lbWidthUnit);
            this.gbMapPage.Controls.Add(this.cbSize);
            this.gbMapPage.Controls.Add(this.label3);
            this.gbMapPage.Controls.Add(this.lbHeight);
            this.gbMapPage.Controls.Add(this.lbWidth);
            this.gbMapPage.Controls.Add(this.lbSize);
            this.gbMapPage.Dock = DockStyle.Fill;
//            this.gbMapPage.ImeMode = ImeMode.NoControl;
            this.gbMapPage.Location = new Point(0, 0);
            this.gbMapPage.Name = "gbMapPage";
            this.gbMapPage.Size = new Size(410, 190);
            this.gbMapPage.TabIndex = 0;
            this.gbMapPage.TabStop = false;
            this.gbMapPage.Text = "地图页面大小";
            this.lbOverlapUnit.AutoSize = true;
            this.lbOverlapUnit.Location = new Point(0x167, 0x55);
            this.lbOverlapUnit.Name = "lbOverlapUnit";
            this.lbOverlapUnit.Size = new Size(0x1f, 14);
            this.lbOverlapUnit.TabIndex = 0x10;
            this.lbOverlapUnit.Text = "未知";
            this.tbOverlap.Location = new Point(0x11c, 80);
            this.tbOverlap.Name = "tbOverlap";
            this.tbOverlap.Size = new Size(0x45, 0x16);
            this.tbOverlap.TabIndex = 15;
            this.tbOverlap.TextChanged += new EventHandler(this.tbOverlap_TextChanged);
            this.tbOverlap.KeyDown += new KeyEventHandler(this.ValidateKey);
            this.tbOverlap.Leave += new EventHandler(this.leave);
            this.lbOverlap.AutoSize = true;
            this.lbOverlap.Location = new Point(0x108, 0x37);
            this.lbOverlap.Name = "lbOverlap";
            this.lbOverlap.Size = new Size(0x47, 14);
            this.lbOverlap.TabIndex = 14;
            this.lbOverlap.Text = "页面重叠度:";
            this.lbSameAsPrinter.AutoSize = true;
            this.lbSameAsPrinter.Location = new Point(0x4b, 0x37);
            this.lbSameAsPrinter.Name = "lbSameAsPrinter";
            this.lbSameAsPrinter.Size = new Size(0x67, 14);
            this.lbSameAsPrinter.TabIndex = 13;
            this.lbSameAsPrinter.Text = "和打印机纸张一样";
            this.cbUsePrinterPaper.AutoSize = true;
            this.cbUsePrinterPaper.Location = new Point(10, 0x18);
            this.cbUsePrinterPaper.Name = "cbUsePrinterPaper";
            this.cbUsePrinterPaper.Size = new Size(110, 0x12);
            this.cbUsePrinterPaper.TabIndex = 12;
            this.cbUsePrinterPaper.Text = "使用打印机设置";
            this.cbUsePrinterPaper.UseVisualStyleBackColor = true;
            this.cbUsePrinterPaper.CheckedChanged += new EventHandler(this.cbUsePrinterPaper_CheckedChanged);
            this.rbPor.AutoSize = true;
            this.rbPor.Location = new Point(0x142, 0x6c);
            this.rbPor.Name = "rbPor";
            this.rbPor.Size = new Size(0x44, 0x12);
            this.rbPor.TabIndex = 11;
            this.rbPor.TabStop = true;
            this.rbPor.Text = "纵向(O)";
            this.rbPor.UseVisualStyleBackColor = true;
            this.rbLand.AutoSize = true;
            this.rbLand.Location = new Point(0x143, 0x84);
            this.rbLand.Name = "rbLand";
            this.rbLand.Size = new Size(0x43, 0x12);
            this.rbLand.TabIndex = 10;
            this.rbLand.TabStop = true;
            this.rbLand.Text = "横向(A)";
            this.rbLand.UseVisualStyleBackColor = true;
            this.rbLand.CheckedChanged += new EventHandler(this.rbLand_CheckedChanged);
            this.lbOri.AutoSize = true;
            this.lbOri.Location = new Point(0x108, 110);
            this.lbOri.Name = "lbOri";
            this.lbOri.Size = new Size(0x23, 14);
            this.lbOri.TabIndex = 9;
            this.lbOri.Text = "方向:";
            this.lbHeightUnit.AutoSize = true;
            this.lbHeightUnit.Location = new Point(0xce, 0x84);
            this.lbHeightUnit.Name = "lbHeightUnit";
            this.lbHeightUnit.Size = new Size(0x1f, 14);
            this.lbHeightUnit.TabIndex = 8;
            this.lbHeightUnit.Text = "未知";
            this.tbHight.Location = new Point(0x4d, 0x80);
            this.tbHight.Name = "tbHight";
            this.tbHight.Size = new Size(0x74, 0x16);
            this.tbHight.TabIndex = 7;
            this.tbHight.TextChanged += new EventHandler(this.tbHight_TextChanged);
            this.tbHight.KeyDown += new KeyEventHandler(this.ValidateKey);
            this.tbHight.Leave += new EventHandler(this.leave);
            this.tbWidth.Location = new Point(0x4d, 0x59);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new Size(0x74, 0x16);
            this.tbWidth.TabIndex = 6;
            this.tbWidth.TextChanged += new EventHandler(this.tbWidth_TextChanged);
            this.tbWidth.KeyDown += new KeyEventHandler(this.ValidateKey);
            this.tbWidth.Leave += new EventHandler(this.leave);
            this.lbWidthUnit.AutoSize = true;
            this.lbWidthUnit.Location = new Point(0xce, 0x5e);
            this.lbWidthUnit.Name = "lbWidthUnit";
            this.lbWidthUnit.Size = new Size(0x1f, 14);
            this.lbWidthUnit.TabIndex = 5;
            this.lbWidthUnit.Text = "未知";
            this.cbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new Point(0x4d, 0x33);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new Size(0x74, 0x16);
            this.cbSize.TabIndex = 4;
            this.cbSize.SelectedIndexChanged += new EventHandler(this.cbSize_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x4b, 0x37);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x26, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new Point(9, 0x84);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new Size(0x23, 14);
            this.lbHeight.TabIndex = 2;
            this.lbHeight.Text = "高度:";
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new Point(9, 0x5e);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new Size(0x23, 14);
            this.lbWidth.TabIndex = 1;
            this.lbWidth.Text = "宽度:";
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new Point(9, 0x37);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new Size(0x23, 14);
            this.lbSize.TabIndex = 0;
            this.lbSize.Text = "大小:";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.gbMapPage);
            base.Name = "ESRIPage";
            base.Size = new Size(410, 190);
            this.gbMapPage.ResumeLayout(false);
            this.gbMapPage.PerformLayout();
            base.ResumeLayout(false);
        }

        private void leave(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (string.IsNullOrEmpty(box.Text))
            {
                XtraMessageBox.Show("值不可为空！");
                box.Focus();
            }
            if (box.Text.EndsWith("."))
            {
                box.Text = box.Text.TrimEnd(new char[] { '.' });
            }
        }

        private void rbLand_CheckedChanged(object sender, EventArgs e)
        {
            if ((!this.init && !this.IsPrinter) && !this.cbUsePrinterPaper.Checked)
            {
                if (this.rbLand.Checked)
                {
                    this._mapPageSet.OrienTation = 2;
                }
                else
                {
                    this._mapPageSet.OrienTation = 1;
                }
                double width = this._mapPageSet.Width;
                this._mapPageSet.Width = this._mapPageSet.Height;
                this._mapPageSet.Height = width;
                this.tbWidth.Text = Math.Round(this._mapPageSet.Width, 1).ToString();
                this.tbHight.Text = Math.Round(this._mapPageSet.Height, 1).ToString();
                this.EnableOverLap();
            }
        }

        private void tbHight_TextChanged(object sender, EventArgs e)
        {
            if ((!this.init && !this.IsPrinter) && !this.cbUsePrinterPaper.Checked)
            {
                if (this.cbSize.Text == "自定义")
                {
                    if (string.IsNullOrEmpty(this.tbHight.Text))
                    {
                        return;
                    }
                    string str = this.tbHight.Text.TrimEnd(new char[] { '.' });
                    if (string.IsNullOrEmpty(str))
                    {
                        return;
                    }
                    double num = double.Parse(str);
                    int num2 = str.LastIndexOf('.');
                    if ((num2 != -1) && (str.Substring(num2 + 1).Length > 4))
                    {
                        num = Math.Round(double.Parse(str), 4, MidpointRounding.ToEven);
                        this.tbHight.Text = num.ToString();
                    }
                    this._mapPageSet.Height = num;
                }
                this.EnableOverLap();
            }
        }

        private void tbOverlap_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbOverlap.Text))
            {
                string str = this.tbOverlap.Text.TrimEnd(new char[] { '.' });
                if (!string.IsNullOrEmpty(str))
                {
                    double num2;
                    double num3;
                    double num = double.Parse(str);
                    this._pControl.Page.QuerySize(out num2, out num3);
                    double num4 = Math.Min(num2, num3);
                    if (num <= num4)
                    {
                        if (num == 0.0)
                        {
                            Print.MapPageSet.OverLap = -1.0;
                        }
                        else
                        {
                            Print.MapPageSet.OverLap = num;
                        }
                    }
                    else
                    {
                        MessageBox.Show("重叠部分不可超过页面大小！");
                        this.tbOverlap.Text = "0";
                    }
                }
            }
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            if ((!this.init && !this.IsPrinter) && !this.cbUsePrinterPaper.Checked)
            {
                if (this.cbSize.Text == "自定义")
                {
                    if (string.IsNullOrEmpty(this.tbWidth.Text))
                    {
                        return;
                    }
                    string str = this.tbWidth.Text.TrimEnd(new char[] { '.' });
                    if (string.IsNullOrEmpty(str))
                    {
                        return;
                    }
                    double num = double.Parse(str);
                    int num2 = str.LastIndexOf('.');
                    if ((num2 != -1) && (str.Substring(num2 + 1).Length > 4))
                    {
                        num = Math.Round(double.Parse(str), 4, MidpointRounding.ToEven);
                        this.tbWidth.Text = num.ToString();
                    }
                    this._mapPageSet.Width = num;
                }
                this.EnableOverLap();
            }
        }

        private void ValidateKey(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            else if ((((((e.KeyCode != Keys.D0) && (e.KeyCode != Keys.NumPad0)) && ((e.KeyCode != Keys.D1) && (e.KeyCode != Keys.NumPad1))) && (((e.KeyCode != Keys.D2) && (e.KeyCode != Keys.NumPad2)) && ((e.KeyCode != Keys.D3) && (e.KeyCode != Keys.NumPad3)))) && ((((e.KeyCode != Keys.D4) && (e.KeyCode != Keys.NumPad4)) && ((e.KeyCode != Keys.D5) && (e.KeyCode != Keys.NumPad5))) && (((e.KeyCode != Keys.D6) && (e.KeyCode != Keys.NumPad6)) && ((e.KeyCode != Keys.D7) && (e.KeyCode != Keys.NumPad7))))) && ((((e.KeyCode != Keys.D8) && (e.KeyCode != Keys.NumPad8)) && ((e.KeyCode != Keys.D9) && (e.KeyCode != Keys.NumPad9))) && (((e.KeyValue != 190) && (e.KeyCode != Keys.Back)) && (e.KeyCode != Keys.Enter))))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                TextBox box = sender as TextBox;
                if ((box.Text.Length == 0) && (e.KeyValue == 190))
                {
                    e.SuppressKeyPress = true;
                }
                else if (box.Text.EndsWith(".") && (e.KeyValue == 190))
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        public IPageLayoutControl3 Control
        {
            get
            {
                return this._pControl;
            }
            set
            {
                this._pControl = value;
            }
        }

        public Print.MapPageSet MapPageSet
        {
            get
            {
                return this._mapPageSet;
            }
        }

        public Print.PrinterSet PrinterSet
        {
            set
            {
                this._printerSet = value;
            }
        }
    }
}

