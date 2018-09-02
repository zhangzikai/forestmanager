namespace Print
{
    using Cartography.Element;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class DevImageExport : FormBase3
    {
        private IActiveView _activeView;
        private SimpleButton btBrowse;
        private SimpleButton btCancel;
        private SimpleButton btExport;
        private CheckEdit cb_bm;
        private CheckEdit cbGraphics;
        private CheckEdit cbPage;
        private CheckEdit checkEdit_zb;
        private IContainer components;
        private GroupBox gbExport;
        private GroupBox gbFormat;
        internal Label LabelLoadInfo;
        internal Label LabelProgressBack;
        internal Label LabelProgressBar;
        private LabelControl lbDpi;
        private LabelControl lbHeight;
        private LabelControl lbHUnit;
        private LabelControl lbReSample;
        private LabelControl lbWidth;
        private LabelControl lbWUint;
        private NumericUpDown nudResolution;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PanelControl panelBar;
        private SaveFileDialog sfdBitMap;
        private TextEdit tbHeight;
        private TextEdit tbPath;
        private TextEdit tbWidth;

        public DevImageExport()
        {
            this.InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            this.sfdBitMap.Filter = "(*.BMP)|*.BMP|(*.GIF)|*.GIF|(*.TIFF)|*.TIFF|(*.PNG)|*.PNG|(*.JPEG)|*.JPEG|(*.PDF)|*.PDF";
            this.sfdBitMap.Title = "输出图片";
            if (this.sfdBitMap.ShowDialog() == DialogResult.OK)
            {
                this.tbPath.Text = this.sfdBitMap.FileName;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbPath.Text))
            {
                this.SetLoadInfo("正在导出，请稍候……", 50);
                this.panelBar.Visible = true;
                this.ExportZb(this.tbPath.Text);
                if (this.cb_bm.Checked)
                {
                    Jimi jimi = new Jimi();
                    jimi.LayerName = "地形图";
                    jimi.AddText(this._activeView);
                }
                long pOutputResolution = long.Parse(this.nudResolution.Value.ToString());
                string pFormat = this.tbPath.Text.Substring(this.tbPath.Text.LastIndexOf('.') + 1).ToUpper();
                ImageExport export = new ImageExport();
                bool flag = export.ExportActiveViewParameterized(this._activeView, pOutputResolution, 1L, pFormat, this.tbPath.Text, this.cbGraphics.Checked, this.cbPage.Checked);
                export.Dispose();
                base.Close();
                this.SetLoadInfo("导出完成", 100);
                this.panelBar.Visible = false;
                if (flag)
                {
                    XtraMessageBox.Show("图片已经成功输出！");
                }
                else
                {
                    XtraMessageBox.Show("图片输出失败！");
                }
            }
            else
            {
                XtraMessageBox.Show("请设置保存路径！");
            }
        }

        private void cbGraphics_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbGraphics.Checked)
            {
                this.cbPage.Checked = false;
                this.cbPage.Enabled = false;
            }
            else
            {
                this.cbPage.Enabled = true;
            }
        }

        private void cbGraphics_Click(object sender, EventArgs e)
        {
            if (this.cbGraphics.Checked)
            {
                this.ChangeControlText(1);
            }
            else
            {
                this.ChangeControlText(0);
            }
        }

        private void cbPage_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbPage.Checked)
            {
                this.cbGraphics.Checked = false;
                this.ChangeControlText(2);
            }
            else if (this.cbGraphics.Checked)
            {
                this.ChangeControlText(1);
            }
            else
            {
                this.ChangeControlText(0);
            }
        }

        private void ChangeControlText(int iType)
        {
            int pRosolution = int.Parse(this.nudResolution.Value.ToString());
            int num2 = 0;
            int num3 = 0;
            if (iType == 2)
            {
                double num4;
                double num5;
                IPage page = null;
                if (this._activeView is IPageLayout)
                {
                    page = ((IPageLayout) this._activeView).Page;
                }
                else
                {
                    IObjectCopy copy = new ObjectCopyClass();
                    object focusMap = this._activeView.FocusMap;
                    object pInObject = copy.Copy(focusMap);
                    IPageLayoutControl3 control = new PageLayoutControlClass();
                    object pOverwriteObject = control.ActiveView.FocusMap;
                    copy.Overwrite(pInObject, ref pOverwriteObject);
                    control.ActiveView.Extent = this._activeView.Extent;
                    page = control.Page;
                }
                page.QuerySize(out num4, out num5);
                long num6 = 0x60L;
                double num7 = (pRosolution * 37.79524) / ((double) num6);
                double num8 = num4 * num7;
                double num9 = num5 * num7;
                num2 = Convert.ToInt32(num8);
                num3 = Convert.ToInt32(num9);
                this.tbWidth.Text = int.Parse(num2.ToString()).ToString();
                this.tbHeight.Text = int.Parse(num3.ToString()).ToString();
            }
            else
            {
                tagRECT tagRect;
                if (this._activeView is IPageLayout)
                {
                    if (iType == 1)
                    {
                        tagRect = new ImageExport().GetTagRect(this._activeView, (double) pRosolution);
                        num2 = tagRect.right - tagRect.left;
                        num3 = tagRect.bottom - tagRect.top;
                    }
                    else if (iType == 0)
                    {
                        tagRect = this._activeView.ExportFrame;
                        num2 = tagRect.right - tagRect.left;
                        num3 = tagRect.bottom - tagRect.top;
                        double radio = ImageExport.GetRadio(pRosolution);
                        num2 = (int) (num2 * radio);
                        num3 = (int) (num3 * radio);
                    }
                }
                else
                {
                    tagRect = this._activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                    num2 = tagRect.right - tagRect.left;
                    num3 = tagRect.bottom - tagRect.top;
                    double num11 = ImageExport.GetRadio(pRosolution);
                    num2 = (int) (num2 * num11);
                    num3 = (int) (num3 * num11);
                }
                this.tbWidth.Text = int.Parse(num2.ToString()).ToString();
                this.tbHeight.Text = int.Parse(num3.ToString()).ToString();
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

        private void ExportZb(string pPath)
        {
            IGraphicsContainer container = this._activeView as IGraphicsContainer;
            container.Reset();
            IElement element = container.Next();
            StringBuilder builder = new StringBuilder();
            while (element != null)
            {
                if (element is ITextElement)
                {
                    IElementProperties properties = element as IElementProperties;
                    if (properties.Name == "zb")
                    {
                        string str = properties.CustomProperty.ToString();
                        builder.Append(str);
                        builder.Append(Environment.NewLine);
                    }
                }
                element = container.Next();
            }
            if (builder.Length > 0)
            {
                File.WriteAllText(Path.GetDirectoryName(this.tbPath.Text) + @"\" + Path.GetFileName(this.tbPath.Text).Split(new char[] { '.' })[0] + ".txt", builder.ToString());
            }
        }

        private void ImageExport_Load(object sender, EventArgs e)
        {
            if (this._activeView is IPageLayout)
            {
                this.cb_bm.Visible = true;
                this.checkEdit_zb.Visible = true;
            }
            else
            {
                this.cb_bm.Visible = false;
                this.checkEdit_zb.Visible = false;
                this.cb_bm.Checked = false;
                this.checkEdit_zb.Checked = false;
            }
            this.cbGraphics.Visible = false;
            this.cbPage.Visible = false;
            this.cbGraphics.Checked = false;
            this.cbPage.Checked = false;
            this.ChangeControlText(0);
        }

        private void InitializeComponent()
        {
            this.gbExport = new GroupBox();
            this.btBrowse = new SimpleButton();
            this.tbPath = new TextEdit();
            this.gbFormat = new GroupBox();
            this.panel1 = new Panel();
            this.lbWidth = new LabelControl();
            this.tbWidth = new TextEdit();
            this.lbWUint = new LabelControl();
            this.lbHeight = new LabelControl();
            this.lbHUnit = new LabelControl();
            this.tbHeight = new TextEdit();
            this.panel2 = new Panel();
            this.checkEdit_zb = new CheckEdit();
            this.cbGraphics = new CheckEdit();
            this.cbPage = new CheckEdit();
            this.panel3 = new Panel();
            this.lbReSample = new LabelControl();
            this.nudResolution = new NumericUpDown();
            this.lbDpi = new LabelControl();
            this.btExport = new SimpleButton();
            this.btCancel = new SimpleButton();
            this.sfdBitMap = new SaveFileDialog();
            this.panelBar = new PanelControl();
            this.LabelProgressBack = new Label();
            this.LabelProgressBar = new Label();
            this.LabelLoadInfo = new Label();
            this.panel4 = new Panel();
            this.cb_bm = new CheckEdit();
            this.gbExport.SuspendLayout();
            this.tbPath.Properties.BeginInit();
            this.gbFormat.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbWidth.Properties.BeginInit();
            this.tbHeight.Properties.BeginInit();
            this.panel2.SuspendLayout();
            this.checkEdit_zb.Properties.BeginInit();
            this.cbGraphics.Properties.BeginInit();
            this.cbPage.Properties.BeginInit();
            this.panel3.SuspendLayout();
            this.nudResolution.BeginInit();
            this.panelBar.BeginInit();
            this.panelBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.cb_bm.Properties.BeginInit();
            base.SuspendLayout();
            this.gbExport.Controls.Add(this.btBrowse);
            this.gbExport.Controls.Add(this.tbPath);
            this.gbExport.Dock = DockStyle.Top;
            this.gbExport.Location = new Point(20, 10);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new Size(0x189, 60);
            this.gbExport.TabIndex = 5;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "保存路径";
            this.btBrowse.Location = new Point(0x128, 0x15);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new Size(0x4b, 0x1b);
            this.btBrowse.TabIndex = 15;
            this.btBrowse.Text = "浏览...";
            this.btBrowse.Click += new EventHandler(this.btBrowse_Click);
            this.tbPath.Location = new Point(0x11, 0x17);
            this.tbPath.Name = "tbPath";
            this.tbPath.Properties.ReadOnly = true;
            this.tbPath.Size = new Size(0x107, 0x15);
            this.tbPath.TabIndex = 14;
            this.gbFormat.Controls.Add(this.panel1);
            this.gbFormat.Controls.Add(this.panel2);
            this.gbFormat.Controls.Add(this.panel3);
            this.gbFormat.Dock = DockStyle.Top;
            this.gbFormat.Location = new Point(20, 70);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Size = new Size(0x189, 200);
            this.gbFormat.TabIndex = 4;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "属性";
            this.panel1.Controls.Add(this.lbWidth);
            this.panel1.Controls.Add(this.tbWidth);
            this.panel1.Controls.Add(this.lbWUint);
            this.panel1.Controls.Add(this.lbHeight);
            this.panel1.Controls.Add(this.lbHUnit);
            this.panel1.Controls.Add(this.tbHeight);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(3, 0x77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x183, 0x47);
            this.panel1.TabIndex = 0x25;
            this.lbWidth.Location = new Point(0x36, 13);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new Size(0x1c, 14);
            this.lbWidth.TabIndex = 0x1c;
            this.lbWidth.Text = "宽度:";
            this.tbWidth.Location = new Point(0x62, 10);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Properties.ReadOnly = true;
            this.tbWidth.Size = new Size(0x75, 0x15);
            this.tbWidth.TabIndex = 30;
            this.lbWUint.Location = new Point(0xe7, 13);
            this.lbWUint.Name = "lbWUint";
            this.lbWUint.Size = new Size(0x18, 14);
            this.lbWUint.TabIndex = 0x20;
            this.lbWUint.Text = "像素";
            this.lbHeight.Location = new Point(0x36, 0x2b);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new Size(0x1c, 14);
            this.lbHeight.TabIndex = 0x1d;
            this.lbHeight.Text = "高度:";
            this.lbHUnit.Location = new Point(0xe7, 0x2b);
            this.lbHUnit.Name = "lbHUnit";
            this.lbHUnit.Size = new Size(0x18, 14);
            this.lbHUnit.TabIndex = 0x21;
            this.lbHUnit.Text = "像素";
            this.tbHeight.Location = new Point(0x62, 40);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Properties.ReadOnly = true;
            this.tbHeight.Size = new Size(0x75, 0x15);
            this.tbHeight.TabIndex = 0x1f;
            this.panel2.Controls.Add(this.cb_bm);
            this.panel2.Controls.Add(this.checkEdit_zb);
            this.panel2.Controls.Add(this.cbGraphics);
            this.panel2.Controls.Add(this.cbPage);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(3, 0x45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x183, 50);
            this.panel2.TabIndex = 0x26;
            this.checkEdit_zb.Location = new Point(10, 14);
            this.checkEdit_zb.Name = "checkEdit_zb";
            this.checkEdit_zb.Properties.Caption = "输出坐标";
            this.checkEdit_zb.Size = new Size(0x4c, 0x13);
            this.checkEdit_zb.TabIndex = 0x25;
            this.cbGraphics.Location = new Point(0x8b, 14);
            this.cbGraphics.Name = "cbGraphics";
            this.cbGraphics.Properties.Caption = "输出到所有图形范围";
            this.cbGraphics.Size = new Size(80, 0x13);
            this.cbGraphics.TabIndex = 0x23;
            this.cbGraphics.CheckedChanged += new EventHandler(this.cbGraphics_CheckedChanged);
            this.cbGraphics.Click += new EventHandler(this.cbGraphics_Click);
            this.cbPage.Location = new Point(0xe1, 14);
            this.cbPage.Name = "cbPage";
            this.cbPage.Properties.Caption = "按设置的页面大小输出";
            this.cbPage.Size = new Size(0x9b, 0x13);
            this.cbPage.TabIndex = 0x24;
            this.cbPage.CheckedChanged += new EventHandler(this.cbPage_CheckedChanged);
            this.panel3.Controls.Add(this.lbReSample);
            this.panel3.Controls.Add(this.nudResolution);
            this.panel3.Controls.Add(this.lbDpi);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(3, 0x12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x183, 0x33);
            this.panel3.TabIndex = 0x27;
            this.lbReSample.Location = new Point(13, 0x11);
            this.lbReSample.Name = "lbReSample";
            this.lbReSample.Size = new Size(0x34, 14);
            this.lbReSample.TabIndex = 0x1b;
            this.lbReSample.Text = "扫描精度:";
            this.nudResolution.Location = new Point(0x56, 13);
            int[] bits = new int[4];
            bits[0] = 800;
            this.nudResolution.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.nudResolution.Minimum = new decimal(numArray2);
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new Size(0x75, 0x16);
            this.nudResolution.TabIndex = 0x17;
            int[] numArray3 = new int[4];
            numArray3[0] = 300;
            this.nudResolution.Value = new decimal(numArray3);
            this.nudResolution.ValueChanged += new EventHandler(this.nudResolution_ValueChanged);
            this.nudResolution.KeyUp += new KeyEventHandler(this.nudResolution_KeyUp);
            this.lbDpi.Location = new Point(0xdd, 0x11);
            this.lbDpi.Name = "lbDpi";
            this.lbDpi.Size = new Size(0x10, 14);
            this.lbDpi.TabIndex = 0x22;
            this.lbDpi.Text = "dpi";
            this.btExport.Location = new Point(0x54, 2);
            this.btExport.Name = "btExport";
            this.btExport.Size = new Size(0x57, 0x1b);
            this.btExport.TabIndex = 8;
            this.btExport.Text = "输出";
            this.btExport.Click += new EventHandler(this.btExport_Click);
            this.btCancel.Location = new Point(0xca, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new Size(0x57, 0x1b);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new EventHandler(this.btCancel_Click);
            this.panelBar.BorderStyle = BorderStyles.NoBorder;
            this.panelBar.Controls.Add(this.LabelProgressBack);
            this.panelBar.Controls.Add(this.LabelProgressBar);
            this.panelBar.Controls.Add(this.LabelLoadInfo);
            this.panelBar.Dock = DockStyle.Top;
            this.panelBar.Location = new Point(20, 270);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new Size(0x189, 0x2a);
            this.panelBar.TabIndex = 10;
            this.panelBar.Visible = false;
            this.LabelProgressBack.BackColor = Color.White;
            this.LabelProgressBack.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = Color.White;
            this.LabelProgressBack.Location = new Point(40, 0x1c);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new Size(300, 4);
            this.LabelProgressBack.TabIndex = 15;
            this.LabelProgressBar.BackColor = Color.Orange;
            this.LabelProgressBar.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBar.ForeColor = Color.Black;
            this.LabelProgressBar.Location = new Point(40, 0x1c);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new Size(140, 4);
            this.LabelProgressBar.TabIndex = 14;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Location = new Point(0x59, 8);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0xd7, 0x13);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "正在导出，请稍候...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.panel4.Controls.Add(this.btExport);
            this.panel4.Controls.Add(this.btCancel);
            this.panel4.Dock = DockStyle.Bottom;
            this.panel4.Location = new Point(20, 0x142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x189, 0x20);
            this.panel4.TabIndex = 11;
            this.cb_bm.Location = new Point(0x54, 14);
            this.cb_bm.Name = "cb_bm";
            this.cb_bm.Properties.Caption = "保密";
            this.cb_bm.Size = new Size(0x34, 0x13);
            this.cb_bm.TabIndex = 0x26;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b1, 0x16c);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.panelBar);
            base.Controls.Add(this.gbFormat);
            base.Controls.Add(this.gbExport);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DevImageExport";
            base.Padding = new Padding(20, 10, 20, 10);
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "地图位图输出";
            base.Load += new EventHandler(this.ImageExport_Load);
            this.gbExport.ResumeLayout(false);
            this.tbPath.Properties.EndInit();
            this.gbFormat.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbWidth.Properties.EndInit();
            this.tbHeight.Properties.EndInit();
            this.panel2.ResumeLayout(false);
            this.checkEdit_zb.Properties.EndInit();
            this.cbGraphics.Properties.EndInit();
            this.cbPage.Properties.EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.nudResolution.EndInit();
            this.panelBar.EndInit();
            this.panelBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.cb_bm.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void nudResolution_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.cbPage.Checked)
            {
                this.ChangeControlText(0);
            }
        }

        private void nudResolution_ValueChanged(object sender, EventArgs e)
        {
            if (!this.cbPage.Checked)
            {
                this.ChangeControlText(0);
            }
        }

        private void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            catch
            {
            }
        }

        public IActiveView ActiveView
        {
            set
            {
                this._activeView = value;
            }
        }
    }
}

