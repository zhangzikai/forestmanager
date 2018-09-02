namespace Cartography.Render
{
    using Cartography;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Display;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class DevLayerRender : FormBase3
    {
        private ColorEdit ceBGColor;
        private ColorEdit ceNodataColor;
        private CheckBox checkBoxBG;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private ImageComboBoxEdit icbeColorRamp;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label labelMessage;
        private Label labelStretchMax;
        private Label labelStretchMin;
        private ListBoxControl listBoxRender;
        private IList<string> m_BandList;
        private IColorRamp m_ColorRamp;
        private Dictionary<IStyleGalleryItem, Bitmap> m_Items;
        private ILayer m_layer;
        private int m_RenderType;
        private const string mClassName = "Cartography.Render.DevLayerRender";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelBG;
        private Panel panelBGShow;
        private Panel panelDetail;
        private Panel panelRaster;
        private Panel panelStretch;
        private PictureBox pictureBox1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemColorEdit repositoryItemColorEdit1;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonOK;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBoxStretchMax;
        private TextBox textBoxStretchMid;
        private TextBox textBoxStretchMin;

        public DevLayerRender()
        {
            this.InitializeComponent();
        }

        private void checkBoxBG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxBG.Checked)
            {
                this.panelBG.Enabled = true;
            }
            else
            {
                this.panelBG.Enabled = false;
            }
        }

        private void DevLayerRender_Load(object sender, EventArgs e)
        {
            this.checkBoxBG.CheckedChanged += new EventHandler(this.checkBoxBG_CheckedChanged);
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox3.KeyPress += new KeyPressEventHandler(this.textBox3_KeyPress);
            this.InitControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int GetBandIndex(string sBand)
        {
            if (this.m_BandList != null)
            {
                for (int i = 0; i < this.m_BandList.Count; i++)
                {
                    if (this.m_BandList[i] == sBand)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void icbeColorRamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.icbeColorRamp.SelectedIndex >= 0)
            {
                string text = this.icbeColorRamp.Text;
                IEnumerator enumerator = this.m_Items.Keys.GetEnumerator();
                int num = 0;
                IStyleGalleryItem current = null;
                while (enumerator.MoveNext())
                {
                    if (num == (this.icbeColorRamp.SelectedIndex - 1))
                    {
                        current = enumerator.Current as IStyleGalleryItem;
                        break;
                    }
                    num++;
                }
                IColorRamp ramp = current.Item as IColorRamp;
                if (ramp != null)
                {
                    this.m_ColorRamp = ramp;
                    if (this.icbeColorRamp.SelectedIndex >= 0)
                    {
                        ImageComboBoxItem selectedItem = this.icbeColorRamp.SelectedItem as ImageComboBoxItem;
                        ImageList smallImages = this.icbeColorRamp.Properties.SmallImages as ImageList;
                        Image image = smallImages.Images[selectedItem.ImageIndex];
                        if (image != null)
                        {
                            this.pictureBox1.Image = this.ResetImage((Bitmap) image, 90);
                        }
                    }
                }
            }
        }

        private void InitControl()
        {
            try
            {
                if (this.m_layer != null)
                {
                    this.listBoxRender.Items.Clear();
                    this.panelDetail.Visible = false;
                    this.panelRaster.Visible = false;
                    if (this.m_layer is IRasterLayer)
                    {
                        this.panelRaster.Visible = true;
                        this.panelDetail.Visible = true;
                        this.panelBGShow.Visible = false;
                        this.panelStretch.Visible = false;
                        this.gridControl1.Visible = false;
                        IRasterLayer layer = (IRasterLayer) this.m_layer;
                        IRasterRenderer renderer = layer.Renderer;
                        if (renderer is RasterStretchColorRampRenderer)
                        {
                            this.listBoxRender.Items.Add("拉伸");
                            this.m_RenderType = 0x15;
                        }
                        else if (renderer is RasterRGBRenderer)
                        {
                            this.listBoxRender.Items.Add("RGB合成");
                            this.m_RenderType = 0x16;
                        }
                        else if (renderer is RasterColormapRenderer)
                        {
                            this.listBoxRender.Items.Add("色彩映射表");
                            this.m_RenderType = 0x17;
                        }
                        else if (renderer is RasterUniqueValueRenderer)
                        {
                            this.listBoxRender.Items.Add("唯一值");
                            this.m_RenderType = 0x18;
                        }
                        else if (renderer is RasterDiscreteColorRenderer)
                        {
                            this.listBoxRender.Items.Add("离散颜色");
                            this.m_RenderType = 0x19;
                        }
                        else
                        {
                            if (!(renderer is RasterClassifyColorRampRenderer))
                            {
                                return;
                            }
                            this.listBoxRender.Items.Add("分类");
                            this.m_RenderType = 0x1a;
                        }
                        IRasterDisplayProps props = (IRasterDisplayProps) renderer;
                        this.ceNodataColor.Color = ColorService.EsriColorToNetColor(props.NoDataColor);
                        if (this.m_RenderType == 0x15)
                        {
                            this.panelBGShow.Visible = true;
                            this.panelStretch.Visible = true;
                            IRasterStretchColorRampRenderer renderer2 = (IRasterStretchColorRampRenderer) renderer;
                            this.m_ColorRamp = renderer2.ColorRamp;
                            ImageList list = new ImageList();
                            list.ImageSize = new Size(this.icbeColorRamp.Width - 10, this.icbeColorRamp.Height);
                            this.icbeColorRamp.Properties.SmallImages = list;
                            this.m_Items = BitmapManager.GetBitMapText("Color Ramps", this.icbeColorRamp.Width, this.icbeColorRamp.Height);
                            int imageIndex = 0;
                            this.icbeColorRamp.Properties.Items.Add(new ImageComboBoxItem("", "", -1));
                            foreach (KeyValuePair<IStyleGalleryItem, Bitmap> pair in this.m_Items)
                            {
                                list.Images.Add(pair.Value);
                                this.icbeColorRamp.Properties.Items.Add(new ImageComboBoxItem("", pair.Key.Name, imageIndex));
                                imageIndex++;
                            }
                            this.icbeColorRamp.Properties.SmallImages = list;
                            if (renderer2.ColorRamp != null)
                            {
                                this.icbeColorRamp.Text = renderer2.ColorRamp.Name;
                            }
                            else
                            {
                                this.icbeColorRamp.SelectedIndex = 0;
                            }
                            IRasterStretchMinMax max = (IRasterStretchMinMax) renderer2;
                            if (max.UseCustomStretchMinMax)
                            {
                                this.labelStretchMax.Text = max.CustomStretchMax.ToString();
                                this.labelStretchMin.Text = max.CustomStretchMin.ToString();
                            }
                            else
                            {
                                this.labelStretchMax.Text = "";
                                this.labelStretchMin.Text = "";
                            }
                            this.textBoxStretchMax.Text = renderer2.LabelHigh;
                            this.textBoxStretchMid.Text = renderer2.LabelMedium;
                            this.textBoxStretchMin.Text = renderer2.LabelLow;
                            this.textBox1.Visible = false;
                            this.textBox2.Visible = false;
                            this.textBox3.Visible = true;
                            this.textBox3.Text = "0";
                            IRasterStretch2 stretch = (IRasterStretch2) renderer;
                            if (stretch.Background)
                            {
                                this.checkBoxBG.Checked = true;
                                this.ceBGColor.Color = ColorService.EsriColorToNetColor(stretch.BackgroundColor);
                                this.textBox3.Text = stretch.BackgroundValue.ToString();
                            }
                            else
                            {
                                this.checkBoxBG.Checked = false;
                                this.panelBG.Enabled = false;
                            }
                        }
                        else if (this.m_RenderType == 0x16)
                        {
                            this.panelBGShow.Visible = true;
                            IList<string> list2 = new List<string>();
                            IRaster2 raster = (IRaster2) layer.Raster;
                            IRasterBandCollection rasterDataset = (IRasterBandCollection) raster.RasterDataset;
                            for (int i = 0; i < rasterDataset.Count; i++)
                            {
                                IRasterBand band = rasterDataset.Item(i);
                                if (!list2.Contains(band.Bandname))
                                {
                                    list2.Add(band.Bandname);
                                }
                            }
                            this.m_BandList = list2;
                            this.repositoryItemComboBox1.Items.Clear();
                            for (int j = 0; j < list2.Count; j++)
                            {
                                this.repositoryItemComboBox1.Items.Add(list2[j]);
                            }
                            IRasterRGBRenderer2 renderer3 = (IRasterRGBRenderer2) renderer;
                            this.gridControl1.Visible = true;
                            this.gridControl1.DataSource = null;
                            DataTable table = new DataTable();
                            DataColumn column = new DataColumn("check", typeof(bool));
                            column.Caption = "";
                            table.Columns.Add(column);
                            column = new DataColumn("channel", typeof(string));
                            column.Caption = "Channel";
                            table.Columns.Add(column);
                            column = new DataColumn("band", typeof(string));
                            column.Caption = "Band";
                            table.Columns.Add(column);
                            DataRow row = table.NewRow();
                            if (renderer3.UseRedBand)
                            {
                                row[0] = true;
                            }
                            else
                            {
                                row[0] = false;
                            }
                            row[1] = "红色";
                            if (renderer3.RedBandIndex < 0)
                            {
                                row[2] = "";
                            }
                            else
                            {
                                row[2] = list2[renderer3.RedBandIndex];
                            }
                            table.Rows.Add(row);
                            row = table.NewRow();
                            if (renderer3.UseGreenBand)
                            {
                                row[0] = true;
                            }
                            else
                            {
                                row[0] = false;
                            }
                            row[1] = "绿色";
                            if (renderer3.GreenBandIndex < 0)
                            {
                                row[2] = "";
                            }
                            else
                            {
                                row[2] = list2[renderer3.GreenBandIndex];
                            }
                            table.Rows.Add(row);
                            row = table.NewRow();
                            if (renderer3.UseBlueBand)
                            {
                                row[0] = true;
                            }
                            else
                            {
                                row[0] = false;
                            }
                            row[1] = "蓝色";
                            if (renderer3.BlueBandIndex < 0)
                            {
                                row[2] = "";
                            }
                            else
                            {
                                row[2] = list2[renderer3.BlueBandIndex];
                            }
                            table.Rows.Add(row);
                            row = table.NewRow();
                            if (renderer3.UseAlphaBand)
                            {
                                row[0] = true;
                            }
                            else
                            {
                                row[0] = false;
                            }
                            row[1] = "透明";
                            if (renderer3.AlphaBandIndex < 0)
                            {
                                row[2] = "";
                            }
                            else
                            {
                                row[2] = list2[renderer3.AlphaBandIndex];
                            }
                            table.Rows.Add(row);
                            this.gridControl1.DataSource = table;
                            this.gridControl1.RefreshDataSource();
                            this.gridView1.Columns[0].ColumnEdit = this.repositoryItemCheckEdit1;
                            this.gridView1.Columns[0].Width = 20;
                            this.gridView1.Columns[1].Width = 80;
                            this.gridView1.Columns[2].Width = 240;
                            this.gridView1.Columns[2].ColumnEdit = this.repositoryItemComboBox1;
                            this.textBox1.Visible = true;
                            this.textBox2.Visible = true;
                            this.textBox3.Visible = true;
                            this.textBox1.Text = "0";
                            this.textBox2.Text = "0";
                            this.textBox3.Text = "0";
                            IRasterStretch2 stretch2 = (IRasterStretch2) renderer;
                            if (stretch2.Background)
                            {
                                this.checkBoxBG.Checked = true;
                                this.ceBGColor.Color = ColorService.EsriColorToNetColor(stretch2.BackgroundColor);
                                double[] backgroundValue = (double[]) stretch2.BackgroundValue;
                                this.textBox1.Text = backgroundValue[0].ToString();
                                this.textBox2.Text = backgroundValue[1].ToString();
                                this.textBox3.Text = backgroundValue[2].ToString();
                            }
                            else
                            {
                                this.checkBoxBG.Checked = false;
                                this.panelBG.Enabled = false;
                            }
                        }
                        else if (this.m_RenderType == 0x17)
                        {
                            this.gridControl1.Visible = true;
                            this.panelBGShow.Visible = false;
                            ILegendInfo info = (ILegendInfo) renderer;
                            this.gridControl1.DataSource = null;
                            DataTable table2 = new DataTable();
                            DataColumn column2 = new DataColumn("Symbol", typeof(Color));
                            column2.Caption = "颜色";
                            table2.Columns.Add(column2);
                            column2 = new DataColumn("label", typeof(string));
                            column2.Caption = "标注";
                            table2.Columns.Add(column2);
                            for (int k = 0; k < info.LegendGroupCount; k++)
                            {
                                ILegendGroup group = info.get_LegendGroup(k);
                                for (int m = 0; m < group.ClassCount; m++)
                                {
                                    ISymbol symbol = group.get_Class(m).Symbol;
                                    string label = group.get_Class(m).Label;
                                    DataRow row2 = table2.NewRow();
                                    row2[0] = ColorService.EsriColorToNetColor(((IFillSymbol) symbol).Color);
                                    row2[1] = label;
                                    table2.Rows.Add(row2);
                                }
                            }
                            this.gridControl1.DataSource = table2;
                            this.gridControl1.RefreshDataSource();
                            this.gridView1.Columns[0].ColumnEdit = this.repositoryItemColorEdit1;
                            this.gridView1.Columns[0].Width = 80;
                            this.gridView1.Columns[1].Width = 240;
                        }
                    }
                    else
                    {
                        this.listBoxRender.Items.Add("单一符号");
                        this.listBoxRender.Items.Add("单字段唯一值");
                    }
                    this.InitMessage();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Render.DevLayerRender", "InitControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelRaster = new System.Windows.Forms.Panel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.panelStretch = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.icbeColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.textBoxStretchMin = new System.Windows.Forms.TextBox();
            this.textBoxStretchMid = new System.Windows.Forms.TextBox();
            this.textBoxStretchMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelStretchMin = new System.Windows.Forms.Label();
            this.labelStretchMax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelBGShow = new System.Windows.Forms.Panel();
            this.panelBG = new System.Windows.Forms.Panel();
            this.ceBGColor = new DevExpress.XtraEditors.ColorEdit();
            this.panel9 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxBG = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ceNodataColor = new DevExpress.XtraEditors.ColorEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxRender = new DevExpress.XtraEditors.ListBoxControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelRaster.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.panelStretch.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbeColorRamp.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.panelBGShow.SuspendLayout();
            this.panelBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceBGColor.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceNodataColor.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRender)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 278);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelRaster);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(133, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel3.Size = new System.Drawing.Size(227, 274);
            this.panel3.TabIndex = 0;
            // 
            // panelRaster
            // 
            this.panelRaster.Controls.Add(this.panelDetail);
            this.panelRaster.Controls.Add(this.panelBGShow);
            this.panelRaster.Controls.Add(this.panel7);
            this.panelRaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRaster.Location = new System.Drawing.Point(4, 28);
            this.panelRaster.Name = "panelRaster";
            this.panelRaster.Size = new System.Drawing.Size(219, 246);
            this.panelRaster.TabIndex = 4;
            // 
            // panelDetail
            // 
            this.panelDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetail.Controls.Add(this.panelStretch);
            this.panelDetail.Controls.Add(this.gridControl1);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(219, 181);
            this.panelDetail.TabIndex = 5;
            // 
            // panelStretch
            // 
            this.panelStretch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelStretch.Controls.Add(this.panel13);
            this.panelStretch.Controls.Add(this.panel12);
            this.panelStretch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStretch.Location = new System.Drawing.Point(0, 0);
            this.panelStretch.Name = "panelStretch";
            this.panelStretch.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.panelStretch.Size = new System.Drawing.Size(217, 179);
            this.panelStretch.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.icbeColorRamp);
            this.panel13.Controls.Add(this.label5);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(10, 145);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(207, 24);
            this.panel13.TabIndex = 17;
            // 
            // icbeColorRamp
            // 
            this.icbeColorRamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.icbeColorRamp.Location = new System.Drawing.Point(43, 0);
            this.icbeColorRamp.Name = "icbeColorRamp";
            this.icbeColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeColorRamp.Size = new System.Drawing.Size(260, 20);
            this.icbeColorRamp.TabIndex = 14;
            this.icbeColorRamp.SelectedIndexChanged += new System.EventHandler(this.icbeColorRamp_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "色阶：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel10);
            this.panel12.Controls.Add(this.panel5);
            this.panel12.Controls.Add(this.panel8);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(10, 10);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(207, 117);
            this.panel12.TabIndex = 16;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.textBoxStretchMin);
            this.panel10.Controls.Add(this.textBoxStretchMid);
            this.panel10.Controls.Add(this.textBoxStretchMax);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(139, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(184, 117);
            this.panel10.TabIndex = 10;
            // 
            // textBoxStretchMin
            // 
            this.textBoxStretchMin.Location = new System.Drawing.Point(0, 94);
            this.textBoxStretchMin.Name = "textBoxStretchMin";
            this.textBoxStretchMin.Size = new System.Drawing.Size(164, 22);
            this.textBoxStretchMin.TabIndex = 8;
            // 
            // textBoxStretchMid
            // 
            this.textBoxStretchMid.Location = new System.Drawing.Point(0, 57);
            this.textBoxStretchMid.Name = "textBoxStretchMid";
            this.textBoxStretchMid.Size = new System.Drawing.Size(164, 22);
            this.textBoxStretchMid.TabIndex = 7;
            // 
            // textBoxStretchMax
            // 
            this.textBoxStretchMax.Location = new System.Drawing.Point(0, 26);
            this.textBoxStretchMax.Name = "textBoxStretchMax";
            this.textBoxStretchMax.Size = new System.Drawing.Size(164, 22);
            this.textBoxStretchMax.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "标注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelStretchMin);
            this.panel5.Controls.Add(this.labelStretchMax);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(32, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.panel5.Size = new System.Drawing.Size(107, 117);
            this.panel5.TabIndex = 8;
            // 
            // labelStretchMin
            // 
            this.labelStretchMin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStretchMin.Location = new System.Drawing.Point(0, 97);
            this.labelStretchMin.Name = "labelStretchMin";
            this.labelStretchMin.Size = new System.Drawing.Size(99, 20);
            this.labelStretchMin.TabIndex = 7;
            this.labelStretchMin.Text = "0";
            this.labelStretchMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelStretchMax
            // 
            this.labelStretchMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStretchMax.Location = new System.Drawing.Point(0, 14);
            this.labelStretchMax.Name = "labelStretchMax";
            this.labelStretchMax.Size = new System.Drawing.Size(99, 30);
            this.labelStretchMax.TabIndex = 6;
            this.labelStretchMax.Text = "1";
            this.labelStretchMax.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "值";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pictureBox1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(32, 117);
            this.panel8.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "颜色";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(217, 179);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // panelBGShow
            // 
            this.panelBGShow.Controls.Add(this.panelBG);
            this.panelBGShow.Controls.Add(this.checkBoxBG);
            this.panelBGShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBGShow.Location = new System.Drawing.Point(0, 181);
            this.panelBGShow.Name = "panelBGShow";
            this.panelBGShow.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.panelBGShow.Size = new System.Drawing.Size(219, 35);
            this.panelBGShow.TabIndex = 2;
            // 
            // panelBG
            // 
            this.panelBG.Controls.Add(this.ceBGColor);
            this.panelBG.Controls.Add(this.panel9);
            this.panelBG.Controls.Add(this.label4);
            this.panelBG.Location = new System.Drawing.Point(102, 4);
            this.panelBG.Name = "panelBG";
            this.panelBG.Padding = new System.Windows.Forms.Padding(0, 5, 2, 2);
            this.panelBG.Size = new System.Drawing.Size(232, 30);
            this.panelBG.TabIndex = 4;
            // 
            // ceBGColor
            // 
            this.ceBGColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.ceBGColor.EditValue = System.Drawing.Color.Empty;
            this.ceBGColor.Location = new System.Drawing.Point(184, 5);
            this.ceBGColor.Name = "ceBGColor";
            this.ceBGColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceBGColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceBGColor.Size = new System.Drawing.Size(46, 20);
            this.ceBGColor.TabIndex = 41;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.textBox3);
            this.panel9.Controls.Add(this.textBox2);
            this.panel9.Controls.Add(this.textBox1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(150, 23);
            this.panel9.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 22);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 22);
            this.textBox1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "为";
            // 
            // checkBoxBG
            // 
            this.checkBoxBG.AutoSize = true;
            this.checkBoxBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxBG.Location = new System.Drawing.Point(10, 5);
            this.checkBoxBG.Name = "checkBoxBG";
            this.checkBoxBG.Size = new System.Drawing.Size(86, 30);
            this.checkBoxBG.TabIndex = 5;
            this.checkBoxBG.Text = "显示背景值";
            this.checkBoxBG.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ceNodataColor);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 216);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(219, 30);
            this.panel7.TabIndex = 4;
            // 
            // ceNodataColor
            // 
            this.ceNodataColor.EditValue = System.Drawing.Color.Empty;
            this.ceNodataColor.Location = new System.Drawing.Point(286, 7);
            this.ceNodataColor.Name = "ceNodataColor";
            this.ceNodataColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceNodataColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceNodataColor.Size = new System.Drawing.Size(46, 20);
            this.ceNodataColor.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "将NoData显示为";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.labelMessage);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(219, 28);
            this.panel4.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(215, 24);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxRender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.panel1.Size = new System.Drawing.Size(133, 274);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // listBoxRender
            // 
            this.listBoxRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRender.Location = new System.Drawing.Point(5, 10);
            this.listBoxRender.Name = "listBoxRender";
            this.listBoxRender.Size = new System.Drawing.Size(123, 254);
            this.listBoxRender.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 278);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 10, 20, 8);
            this.panel6.Size = new System.Drawing.Size(364, 46);
            this.panel6.TabIndex = 3;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonOK.Location = new System.Drawing.Point(152, 10);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 26);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(227, 10);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(40, 26);
            this.panel11.TabIndex = 2;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonCancel.Location = new System.Drawing.Point(267, 10);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 26);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // DevLayerRender
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(364, 324);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.Name = "DevLayerRender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "符号渲染";
            this.Load += new System.EventHandler(this.DevLayerRender_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelRaster.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panelStretch.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icbeColorRamp.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.panelBGShow.ResumeLayout(false);
            this.panelBGShow.PerformLayout();
            this.panelBG.ResumeLayout(false);
            this.panelBG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceBGColor.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceNodataColor.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRender)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitMessage()
        {
            switch (this.m_RenderType)
            {
                case 11:
                    this.labelMessage.Text = "用相同的符号绘制所有要素";
                    return;

                case 12:
                    this.labelMessage.Text = "用一个字段的唯一值显示类别";
                    return;

                case 0x15:
                    this.labelMessage.Text = "沿着颜色梯度拉伸值来绘制栅格";
                    return;

                case 0x16:
                    this.labelMessage.Text = "用RGB合成绘制栅格";
                    return;

                case 0x17:
                    this.labelMessage.Text = "使用内部色彩映射表绘制栅格";
                    return;

                case 0x18:
                    this.labelMessage.Text = "绘制栅格给每个值分配一种颜色";
                    return;

                case 0x19:
                    this.labelMessage.Text = "将值分类绘制栅格";
                    return;

                case 0x1a:
                    this.labelMessage.Text = "使用一组固定的颜色来绘制离散数据";
                    return;
            }
        }

        private Bitmap ResetImage(Bitmap map, int angle)
        {
            try
            {
                angle = angle % 360;
                double d = (angle * 3.1415926535897931) / 180.0;
                double num2 = Math.Cos(d);
                double num3 = Math.Sin(d);
                int width = map.Width;
                int height = map.Height;
                int num6 = (int) Math.Max(Math.Abs((double) ((width * num2) - (height * num3))), Math.Abs((double) ((width * num2) + (height * num3))));
                int num7 = (int) Math.Max(Math.Abs((double) ((width * num3) - (height * num2))), Math.Abs((double) ((width * num3) + (height * num2))));
                Bitmap image = new Bitmap(num6, num7);
                Graphics graphics = Graphics.FromImage(image);
                graphics.InterpolationMode = InterpolationMode.Bilinear;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                Point point = new Point((num6 - width) / 2, (num7 - height) / 2);
                Rectangle rect = new Rectangle(point.X, point.Y, width, height);
                Point point2 = new Point(rect.X + (rect.Width / 2), rect.Y + (rect.Height / 2));
                graphics.TranslateTransform((float) point2.X, (float) point2.Y);
                graphics.RotateTransform((float) (360 - angle));
                graphics.TranslateTransform((float) -point2.X, (float) -point2.Y);
                graphics.DrawImage(map, rect);
                graphics.ResetTransform();
                graphics.Save();
                graphics.Dispose();
                map.Dispose();
                return image;
            }
            catch
            {
                return null;
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.UpdateRender();
            base.DialogResult = DialogResult.OK;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\r')) && ((e.KeyChar != '\b') && (e.KeyChar != '.')))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\r')) && ((e.KeyChar != '\b') && (e.KeyChar != '.')))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\r')) && ((e.KeyChar != '\b') && (e.KeyChar != '.')))
            {
                e.Handled = true;
            }
        }

        private void UpdateRender()
        {
            try
            {
                IRasterLayer layer = (IRasterLayer) this.m_layer;
                IRasterRenderer renderer = layer.Renderer;
                if (this.m_RenderType == 0x15)
                {
                    IRasterStretchColorRampRenderer renderer2 = (IRasterStretchColorRampRenderer) renderer;
                    if (this.m_ColorRamp != null)
                    {
                        renderer2.ColorRamp = this.m_ColorRamp;
                    }
                    renderer2.LabelHigh = this.textBoxStretchMax.Text;
                    renderer2.LabelMedium = this.textBoxStretchMid.Text;
                    renderer2.LabelLow = this.textBoxStretchMin.Text;
                    IRasterStretch2 stretch = (IRasterStretch2) renderer;
                    if (this.checkBoxBG.Checked)
                    {
                        stretch.Background = true;
                        stretch.BackgroundColor = ColorService.NetColorToEsriColor(this.ceBGColor.Color);
                        double num = double.Parse(this.textBox3.Text);
                        stretch.BackgroundValue = num;
                    }
                    else
                    {
                        stretch.Background = false;
                    }
                }
                else if (this.m_RenderType == 0x16)
                {
                    IRasterRGBRenderer2 renderer3 = (IRasterRGBRenderer2) renderer;
                    DataTable dataSource = (DataTable) this.gridControl1.DataSource;
                    DataRow row = dataSource.Rows[0];
                    bool flag = (bool) row[0];
                    renderer3.UseRedBand = flag;
                    renderer3.RedBandIndex = this.GetBandIndex(row[2].ToString());
                    string str = "";
                    if (flag)
                    {
                        str = "Red:    " + row[2].ToString();
                    }
                    else
                    {
                        str = "Red:    NONE";
                    }
                    row = dataSource.Rows[1];
                    flag = (bool) row[0];
                    renderer3.UseGreenBand = flag;
                    renderer3.GreenBandIndex = this.GetBandIndex(row[2].ToString());
                    string str2 = "";
                    if (flag)
                    {
                        str2 = "Green: " + row[2].ToString();
                    }
                    else
                    {
                        str2 = "Green: NONE";
                    }
                    row = dataSource.Rows[2];
                    flag = (bool) row[0];
                    renderer3.UseBlueBand = flag;
                    renderer3.BlueBandIndex = this.GetBandIndex(row[2].ToString());
                    string str3 = "";
                    if (flag)
                    {
                        str3 = "Blue:   " + row[2].ToString();
                    }
                    else
                    {
                        str3 = "Blue:   NONE";
                    }
                    row = dataSource.Rows[3];
                    flag = (bool) row[0];
                    renderer3.UseAlphaBand = flag;
                    renderer3.AlphaBandIndex = this.GetBandIndex(row[2].ToString());
                    try
                    {
                        ILegendGroup group = (renderer3 as ILegendInfo).get_LegendGroup(0);
                        group.get_Class(0).Label = str;
                        group.get_Class(1).Label = str2;
                        group.get_Class(2).Label = str3;
                    }
                    catch
                    {
                    }
                    IRasterStretch2 stretch2 = (IRasterStretch2) renderer;
                    if (this.checkBoxBG.Checked)
                    {
                        stretch2.Background = true;
                        stretch2.BackgroundColor = ColorService.NetColorToEsriColor(this.ceBGColor.Color);
                        double[] numArray = new double[] { double.Parse(this.textBox1.Text), double.Parse(this.textBox2.Text), double.Parse(this.textBox3.Text) };
                        stretch2.BackgroundValue = numArray;
                    }
                    else
                    {
                        stretch2.Background = false;
                    }
                }
                else if (this.m_RenderType == 0x17)
                {
                    DataTable table2 = (DataTable) this.gridControl1.DataSource;
                    ILegendInfo info2 = (ILegendInfo) renderer;
                    for (int i = 0; i < info2.LegendGroupCount; i++)
                    {
                        ILegendGroup group2 = info2.get_LegendGroup(i);
                        for (int j = 0; j < group2.ClassCount; j++)
                        {
                            ((IFillSymbol) group2.get_Class(j).Symbol).Color = ColorService.NetColorToEsriColor((Color) table2.Rows[j][0]);
                            group2.get_Class(j).Label = table2.Rows[j][1].ToString();
                        }
                    }
                }
                IRasterDisplayProps props = (IRasterDisplayProps) renderer;
                props.NoDataColor = ColorService.NetColorToEsriColor(this.ceNodataColor.Color);
                layer.Renderer = renderer;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Render.DevLayerRender", "UpdateRender", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public ILayer RenderLayer
        {
            set
            {
                this.m_layer = value;
            }
        }
    }
}

