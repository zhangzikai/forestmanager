namespace Cartography.Render
{
    using Cartography;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class DevSymbolSelector : FormBase3
    {
        private AxSymbologyControl axSymbologyControl;
        private SimpleButton btCancel;
        private SimpleButton btOK;
        private ColorEdit ceBorderColor;
        private ColorEdit ceFillColor;
        private ColorEdit ceLineColor;
        private ColorEdit cePointColor;
        private IContainer components;
        private GroupBox gbAreaSet;
        private GroupBox gbLineSet;
        private GroupBox gbPointSet;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label lbAngle;
        private Label lbFillColor;
        private Label lbOutLineColor;
        private Label lbOutLineWidth;
        private Label lbPointColor;
        private Label lbPointSize;
        public IStyleGalleryItem m_styleGalleryItem;
        private const string mClassName = "CartographyRender.DevSymbolSelector";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nudLineWidth;
        private SpinEdit nudOutLine;
        private SpinEdit nudPointAngle;
        private SpinEdit nudPointSize;
        private Panel panel1;
        private PictureEdit picturePreView;
        private string visibeState;

        public DevSymbolSelector()
        {
            this.InitializeComponent();
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            this.m_styleGalleryItem = (IStyleGalleryItem) e.styleGalleryItem;
            this.InitialControl();
            this.PreviewImage();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.m_styleGalleryItem = null;
            base.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ceBorderColor_ColorChanged(object sender, EventArgs e)
        {
            IFillSymbol item = (IFillSymbol) this.m_styleGalleryItem.Item;
            ESRI.ArcGIS.esriSystem.IPersist outline = item.Outline as ESRI.ArcGIS.esriSystem.IPersist;
            Guid pClassID = new Guid();
            outline.GetClassID(out pClassID);
            System.Type.GetTypeFromCLSID(pClassID);
            ILineSymbol symbol2 = item.Outline;
            IColor color = ColorService.NetColorToEsriColor(this.ceBorderColor.Color);
            symbol2.Color = color;
            item.Outline = symbol2;
            this.PreviewImage();
        }

        private void ceFillColor_ColorChanged(object sender, EventArgs e)
        {
            IFillSymbol item = (IFillSymbol) this.m_styleGalleryItem.Item;
            IColor color = ColorService.NetColorToEsriColor(this.ceFillColor.Color);
            item.Color = color;
            this.PreviewImage();
        }

        private void ceLineColor_ColorChanged(object sender, EventArgs e)
        {
            ILineSymbol item = (ILineSymbol) this.m_styleGalleryItem.Item;
            IColor color = ColorService.NetColorToEsriColor(this.ceLineColor.Color);
            item.Color = color;
            this.PreviewImage();
        }

        private void cePointColor_ColorChanged(object sender, EventArgs e)
        {
            IMarkerSymbol item = (IMarkerSymbol) this.m_styleGalleryItem.Item;
            IColor color = ColorService.NetColorToEsriColor(this.cePointColor.Color);
            item.Color = color;
            this.PreviewImage();
        }

        private void DevSymbolSelector_Load(object sender, EventArgs e)
        {
            string styleGalleryFile = ElementService.StyleGalleryFile;
            this.axSymbologyControl.LoadStyleFile(styleGalleryFile);
            this.axSymbologyControl.GetStyleClass(this.axSymbologyControl.StyleClass).SelectItem(0);
        }

        protected override void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public IStyleGalleryItem GetItem(ISymbol pSymbol)
        {
            try
            {
                this.m_styleGalleryItem = null;
                if (pSymbol is IMarkerSymbol)
                {
                    this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    this.gbPointSet.Visible = true;
                    this.gbLineSet.Visible = false;
                    this.gbAreaSet.Visible = false;
                    this.visibeState = "1";
                }
                if (pSymbol is ILineSymbol)
                {
                    this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    this.gbLineSet.Visible = true;
                    this.gbPointSet.Visible = false;
                    this.gbAreaSet.Visible = false;
                    this.visibeState = "2";
                }
                if (pSymbol is IFillSymbol)
                {
                    this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    this.gbAreaSet.Visible = true;
                    this.gbPointSet.Visible = false;
                    this.gbLineSet.Visible = false;
                    this.visibeState = "3";
                }
                ISymbologyStyleClass styleClass = this.axSymbologyControl.GetStyleClass(this.axSymbologyControl.StyleClass);
                IStyleGalleryItem item = null;
                this.m_styleGalleryItem = new ServerStyleGalleryItemClass();
                bool flag = false;
                if (pSymbol == null)
                {
                    flag = true;
                }
                if (!flag)
                {
                    this.m_styleGalleryItem.Item = pSymbol;
                    this.InitialControl();
                    item = new ServerStyleGalleryItemClass();
                    item.Item = pSymbol;
                    styleClass.AddItem(item, 0);
                }
                base.ShowDialog();
                return this.m_styleGalleryItem;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "CartographyRender.DevSymbolSelector", "GetItem", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public IStyleGalleryItem GetItem(esriGeometryType pGeometryType, List<ISymbol> pSymbols, int pIndex)
        {
            this.m_styleGalleryItem = null;
            try
            {
                switch (pGeometryType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                        this.gbPointSet.Visible = true;
                        this.gbPointSet.BringToFront();
                        this.gbLineSet.Visible = false;
                        this.gbAreaSet.Visible = false;
                        this.visibeState = "1";
                        break;

                    case esriGeometryType.esriGeometryPolyline:
                        this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                        this.gbLineSet.Visible = true;
                        this.gbLineSet.BringToFront();
                        this.gbPointSet.Visible = false;
                        this.gbAreaSet.Visible = false;
                        this.visibeState = "2";
                        break;

                    case esriGeometryType.esriGeometryPolygon:
                        this.axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                        this.gbAreaSet.Visible = true;
                        this.gbAreaSet.BringToFront();
                        this.gbPointSet.Visible = false;
                        this.gbLineSet.Visible = false;
                        this.visibeState = "3";
                        break;
                }
                ISymbologyStyleClass styleClass = this.axSymbologyControl.GetStyleClass(this.axSymbologyControl.StyleClass);
                IStyleGalleryItem item = null;
                this.m_styleGalleryItem = new ServerStyleGalleryItemClass();
                bool flag = false;
                if ((pSymbols != null) && (pSymbols.Count != 0))
                {
                    using (List<ISymbol>.Enumerator enumerator = pSymbols.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if (enumerator.Current == null)
                            {
                                goto Label_0156;
                            }
                        }
                        goto Label_016A;
                    Label_0156:
                        flag = true;
                        goto Label_016A;
                    }
                }
                flag = true;
            Label_016A:
                if (!flag)
                {
                    ISymbol symbol2 = pSymbols[pIndex];
                    this.m_styleGalleryItem.Item = symbol2;
                    for (int i = 0; i < pSymbols.Count; i++)
                    {
                        item = new ServerStyleGalleryItemClass();
                        item.Item = pSymbols[i];
                        item.Name = i.ToString();
                        styleClass.AddItem(item, i);
                    }
                }
                base.ShowDialog();
                return this.m_styleGalleryItem;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "CartographyRender.DevSymbolSelector", "GetItem", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void InitialControl()
        {
            if (this.visibeState == "3")
            {
                IFillSymbol item = (IFillSymbol) this.m_styleGalleryItem.Item;
                this.ceBorderColor.Color = ColorService.EsriColorToNetColor(item.Outline.Color);
                this.nudOutLine.Value = decimal.Parse(item.Outline.Width.ToString());
                this.ceFillColor.Color = ColorService.EsriColorToNetColor(item.Color);
            }
            else if (this.visibeState == "2")
            {
                ILineSymbol symbol2 = (ILineSymbol) this.m_styleGalleryItem.Item;
                this.nudLineWidth.Value = decimal.Parse(symbol2.Width.ToString());
                this.ceLineColor.Color = ColorService.EsriColorToNetColor(symbol2.Color);
            }
            else
            {
                IMarkerSymbol symbol3 = (IMarkerSymbol) this.m_styleGalleryItem.Item;
                this.nudPointSize.Value = decimal.Parse(symbol3.Size.ToString());
                this.nudPointAngle.Value = decimal.Parse(symbol3.Angle.ToString());
                this.cePointColor.Color = ColorService.EsriColorToNetColor(symbol3.Color);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevSymbolSelector));
            this.axSymbologyControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picturePreView = new DevExpress.XtraEditors.PictureEdit();
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbFillColor = new System.Windows.Forms.Label();
            this.lbOutLineWidth = new System.Windows.Forms.Label();
            this.lbOutLineColor = new System.Windows.Forms.Label();
            this.nudOutLine = new DevExpress.XtraEditors.SpinEdit();
            this.ceFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.ceBorderColor = new DevExpress.XtraEditors.ColorEdit();
            this.gbAreaSet = new System.Windows.Forms.GroupBox();
            this.lbPointColor = new System.Windows.Forms.Label();
            this.lbPointSize = new System.Windows.Forms.Label();
            this.lbAngle = new System.Windows.Forms.Label();
            this.cePointColor = new DevExpress.XtraEditors.ColorEdit();
            this.nudPointSize = new DevExpress.XtraEditors.SpinEdit();
            this.nudPointAngle = new DevExpress.XtraEditors.SpinEdit();
            this.gbPointSet = new System.Windows.Forms.GroupBox();
            this.gbLineSet = new System.Windows.Forms.GroupBox();
            this.nudLineWidth = new DevExpress.XtraEditors.SpinEdit();
            this.ceLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBorderColor.Properties)).BeginInit();
            this.gbAreaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cePointColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointAngle.Properties)).BeginInit();
            this.gbPointSet.SuspendLayout();
            this.gbLineSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axSymbologyControl
            // 
            this.axSymbologyControl.Location = new System.Drawing.Point(9, 12);
            this.axSymbologyControl.Name = "axSymbologyControl";
            this.axSymbologyControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl.OcxState")));
            this.axSymbologyControl.Size = new System.Drawing.Size(297, 412);
            this.axSymbologyControl.TabIndex = 2;
            this.axSymbologyControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picturePreView);
            this.groupBox1.Location = new System.Drawing.Point(371, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(203, 146);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // picturePreView
            // 
            this.picturePreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePreView.Location = new System.Drawing.Point(6, 18);
            this.picturePreView.Name = "picturePreView";
            this.picturePreView.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picturePreView.Properties.Appearance.Options.UseBackColor = true;
            this.picturePreView.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picturePreView.Size = new System.Drawing.Size(191, 122);
            this.picturePreView.TabIndex = 0;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(386, 371);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(70, 27);
            this.btOK.TabIndex = 9;
            this.btOK.Text = "确定";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(481, 371);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(70, 27);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbFillColor
            // 
            this.lbFillColor.AutoSize = true;
            this.lbFillColor.Location = new System.Drawing.Point(22, 31);
            this.lbFillColor.Margin = new System.Windows.Forms.Padding(0);
            this.lbFillColor.Name = "lbFillColor";
            this.lbFillColor.Size = new System.Drawing.Size(47, 14);
            this.lbFillColor.TabIndex = 8;
            this.lbFillColor.Text = "填充色:";
            // 
            // lbOutLineWidth
            // 
            this.lbOutLineWidth.AutoSize = true;
            this.lbOutLineWidth.Location = new System.Drawing.Point(22, 65);
            this.lbOutLineWidth.Name = "lbOutLineWidth";
            this.lbOutLineWidth.Size = new System.Drawing.Size(59, 14);
            this.lbOutLineWidth.TabIndex = 9;
            this.lbOutLineWidth.Text = "边框宽度:";
            // 
            // lbOutLineColor
            // 
            this.lbOutLineColor.AutoSize = true;
            this.lbOutLineColor.Location = new System.Drawing.Point(22, 97);
            this.lbOutLineColor.Name = "lbOutLineColor";
            this.lbOutLineColor.Size = new System.Drawing.Size(59, 14);
            this.lbOutLineColor.TabIndex = 12;
            this.lbOutLineColor.Text = "边框颜色:";
            // 
            // nudOutLine
            // 
            this.nudOutLine.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOutLine.Location = new System.Drawing.Point(90, 61);
            this.nudOutLine.Name = "nudOutLine";
            this.nudOutLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudOutLine.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOutLine.Size = new System.Drawing.Size(87, 20);
            this.nudOutLine.TabIndex = 33;
            this.nudOutLine.ValueChanged += new System.EventHandler(this.nudOutLine_ValueChanged);
            // 
            // ceFillColor
            // 
            this.ceFillColor.EditValue = System.Drawing.Color.Empty;
            this.ceFillColor.Location = new System.Drawing.Point(90, 28);
            this.ceFillColor.Name = "ceFillColor";
            this.ceFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceFillColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceFillColor.Size = new System.Drawing.Size(87, 20);
            this.ceFillColor.TabIndex = 34;
            this.ceFillColor.ColorChanged += new System.EventHandler(this.ceFillColor_ColorChanged);
            // 
            // ceBorderColor
            // 
            this.ceBorderColor.EditValue = System.Drawing.Color.Empty;
            this.ceBorderColor.Location = new System.Drawing.Point(90, 93);
            this.ceBorderColor.Name = "ceBorderColor";
            this.ceBorderColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceBorderColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceBorderColor.Size = new System.Drawing.Size(87, 20);
            this.ceBorderColor.TabIndex = 35;
            this.ceBorderColor.ColorChanged += new System.EventHandler(this.ceBorderColor_ColorChanged);
            // 
            // gbAreaSet
            // 
            this.gbAreaSet.Controls.Add(this.ceBorderColor);
            this.gbAreaSet.Controls.Add(this.ceFillColor);
            this.gbAreaSet.Controls.Add(this.nudOutLine);
            this.gbAreaSet.Controls.Add(this.lbOutLineColor);
            this.gbAreaSet.Controls.Add(this.lbOutLineWidth);
            this.gbAreaSet.Controls.Add(this.lbFillColor);
            this.gbAreaSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAreaSet.Location = new System.Drawing.Point(0, 0);
            this.gbAreaSet.Name = "gbAreaSet";
            this.gbAreaSet.Size = new System.Drawing.Size(203, 136);
            this.gbAreaSet.TabIndex = 8;
            this.gbAreaSet.TabStop = false;
            this.gbAreaSet.Text = "设置";
            this.gbAreaSet.Visible = false;
            // 
            // lbPointColor
            // 
            this.lbPointColor.AutoSize = true;
            this.lbPointColor.Location = new System.Drawing.Point(21, 26);
            this.lbPointColor.Margin = new System.Windows.Forms.Padding(0);
            this.lbPointColor.Name = "lbPointColor";
            this.lbPointColor.Size = new System.Drawing.Size(35, 14);
            this.lbPointColor.TabIndex = 14;
            this.lbPointColor.Text = "颜色:";
            // 
            // lbPointSize
            // 
            this.lbPointSize.AutoSize = true;
            this.lbPointSize.Location = new System.Drawing.Point(21, 59);
            this.lbPointSize.Name = "lbPointSize";
            this.lbPointSize.Size = new System.Drawing.Size(35, 14);
            this.lbPointSize.TabIndex = 15;
            this.lbPointSize.Text = "大小:";
            // 
            // lbAngle
            // 
            this.lbAngle.AutoSize = true;
            this.lbAngle.Location = new System.Drawing.Point(23, 91);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(35, 14);
            this.lbAngle.TabIndex = 18;
            this.lbAngle.Text = "角度:";
            // 
            // cePointColor
            // 
            this.cePointColor.EditValue = System.Drawing.Color.Empty;
            this.cePointColor.Location = new System.Drawing.Point(89, 22);
            this.cePointColor.Name = "cePointColor";
            this.cePointColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cePointColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cePointColor.Size = new System.Drawing.Size(87, 20);
            this.cePointColor.TabIndex = 35;
            this.cePointColor.ColorChanged += new System.EventHandler(this.cePointColor_ColorChanged);
            // 
            // nudPointSize
            // 
            this.nudPointSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPointSize.Location = new System.Drawing.Point(89, 56);
            this.nudPointSize.Name = "nudPointSize";
            this.nudPointSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudPointSize.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPointSize.Size = new System.Drawing.Size(87, 20);
            this.nudPointSize.TabIndex = 36;
            this.nudPointSize.ValueChanged += new System.EventHandler(this.nudPointSize_ValueChanged);
            // 
            // nudPointAngle
            // 
            this.nudPointAngle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPointAngle.Location = new System.Drawing.Point(89, 87);
            this.nudPointAngle.Name = "nudPointAngle";
            this.nudPointAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudPointAngle.Properties.MaxValue = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudPointAngle.Properties.MinValue = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudPointAngle.Size = new System.Drawing.Size(87, 20);
            this.nudPointAngle.TabIndex = 37;
            this.nudPointAngle.ValueChanged += new System.EventHandler(this.nudPointAngle_ValueChanged);
            // 
            // gbPointSet
            // 
            this.gbPointSet.Controls.Add(this.nudPointAngle);
            this.gbPointSet.Controls.Add(this.nudPointSize);
            this.gbPointSet.Controls.Add(this.cePointColor);
            this.gbPointSet.Controls.Add(this.lbAngle);
            this.gbPointSet.Controls.Add(this.lbPointSize);
            this.gbPointSet.Controls.Add(this.lbPointColor);
            this.gbPointSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPointSet.Location = new System.Drawing.Point(0, 0);
            this.gbPointSet.Name = "gbPointSet";
            this.gbPointSet.Size = new System.Drawing.Size(203, 136);
            this.gbPointSet.TabIndex = 11;
            this.gbPointSet.TabStop = false;
            this.gbPointSet.Text = "设置";
            this.gbPointSet.Visible = false;
            // 
            // gbLineSet
            // 
            this.gbLineSet.Controls.Add(this.nudLineWidth);
            this.gbLineSet.Controls.Add(this.ceLineColor);
            this.gbLineSet.Controls.Add(this.label3);
            this.gbLineSet.Controls.Add(this.label2);
            this.gbLineSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLineSet.Location = new System.Drawing.Point(0, 0);
            this.gbLineSet.Name = "gbLineSet";
            this.gbLineSet.Size = new System.Drawing.Size(203, 136);
            this.gbLineSet.TabIndex = 12;
            this.gbLineSet.TabStop = false;
            this.gbLineSet.Text = "设置";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLineWidth.Location = new System.Drawing.Point(87, 70);
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudLineWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudLineWidth.Size = new System.Drawing.Size(87, 20);
            this.nudLineWidth.TabIndex = 41;
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.nudLineWidth_ValueChanged);
            // 
            // ceLineColor
            // 
            this.ceLineColor.EditValue = System.Drawing.Color.Empty;
            this.ceLineColor.Location = new System.Drawing.Point(87, 36);
            this.ceLineColor.Name = "ceLineColor";
            this.ceLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceLineColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceLineColor.Size = new System.Drawing.Size(87, 20);
            this.ceLineColor.TabIndex = 40;
            this.ceLineColor.ColorChanged += new System.EventHandler(this.ceLineColor_ColorChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "宽度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "颜色:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbLineSet);
            this.panel1.Controls.Add(this.gbPointSet);
            this.panel1.Controls.Add(this.gbAreaSet);
            this.panel1.Location = new System.Drawing.Point(371, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 136);
            this.panel1.TabIndex = 12;
            // 
            // DevSymbolSelector
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axSymbologyControl);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevSymbolSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "符号选择器";
            this.Load += new System.EventHandler(this.DevSymbolSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBorderColor.Properties)).EndInit();
            this.gbAreaSet.ResumeLayout(false);
            this.gbAreaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cePointColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointAngle.Properties)).EndInit();
            this.gbPointSet.ResumeLayout(false);
            this.gbPointSet.PerformLayout();
            this.gbLineSet.ResumeLayout(false);
            this.gbLineSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            ILineSymbol item = (ILineSymbol) this.m_styleGalleryItem.Item;
            item.Width = Convert.ToDouble(this.nudLineWidth.Value);
            this.PreviewImage();
        }

        private void nudOutLine_ValueChanged(object sender, EventArgs e)
        {
            IFillSymbol item = (IFillSymbol) this.m_styleGalleryItem.Item;
            ESRI.ArcGIS.esriSystem.IPersist outline = item.Outline as ESRI.ArcGIS.esriSystem.IPersist;
            Guid pClassID = new Guid();
            outline.GetClassID(out pClassID);
            System.Type.GetTypeFromCLSID(pClassID);
            ILineSymbol symbol2 = item.Outline;
            symbol2.Width = double.Parse(this.nudOutLine.Value.ToString());
            symbol2.Color = item.Outline.Color;
            item.Outline = symbol2;
            this.PreviewImage();
        }

        private void nudPointAngle_ValueChanged(object sender, EventArgs e)
        {
            IMarkerSymbol item = (IMarkerSymbol) this.m_styleGalleryItem.Item;
            item.Angle = double.Parse(this.nudPointAngle.Value.ToString());
            this.PreviewImage();
        }

        private void nudPointSize_ValueChanged(object sender, EventArgs e)
        {
            IMarkerSymbol item = (IMarkerSymbol) this.m_styleGalleryItem.Item;
            item.Size = double.Parse(this.nudPointSize.Value.ToString());
            this.PreviewImage();
        }

        private void PreviewImage()
        {
            if (this.m_styleGalleryItem.Item != null)
            {
                Bitmap bitmap = Image.FromHbitmap(new IntPtr(this.axSymbologyControl.GetStyleClass(this.axSymbologyControl.StyleClass).PreviewItem(this.m_styleGalleryItem, this.picturePreView.Width, this.picturePreView.Height).Handle));
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.picturePreView.Image = bitmap;
            }
        }
    }
}

