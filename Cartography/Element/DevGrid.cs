namespace Cartography.Element
{
    using Cartography;
    using Cartography.Base;
    using Cartography.Properties;
    using Cartography.Render;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class DevGrid : FormBase3
    {
        private IMapGrid _mapGrid;
        private IMapGrid _origMapGrid;
        private IActiveView activeView;
        private SimpleButton btCancel;
        private Button btGridBorder;
        private ColorEdit btLabelColor;
        private SimpleButton btLineSymbol;
        private SimpleButton btMajorSymbol;
        private SimpleButton btNumeric;
        private SimpleButton btOk;
        private SimpleButton btSub;
        private SimpleButton btSubSymbol;
        private CheckEdit cbBold;
        private System.Windows.Forms.ComboBox cbBorderType;
        private ComboBoxEdit cbeBorderType;
        private CheckBox cbGridBord;
        private CheckEdit cbIt;
        private CheckEdit cbLabelBottom;
        private CheckEdit cbLabelLeft;
        private CheckEdit cbLabelRight;
        private CheckEdit cbLabelTop;
        private CheckEdit cbMajorBottom;
        private CheckEdit cbMajorLeft;
        private CheckEdit cbMajorRight;
        private CheckEdit cbMajorTop;
        private CheckEdit cbOriBottom;
        private CheckEdit cbOriLeft;
        private CheckEdit cbOriRight;
        private CheckEdit cbOriTop;
        private CheckEdit cbSubBottom;
        private CheckEdit cbSubLeft;
        private CheckEdit cbSubRight;
        private CheckEdit cbSubTop;
        private ComboBoxEdit cbTextFamily;
        private CheckEdit cbUnderLine;
        private CheckEdit ceGridBorder;
        private ComboBoxEdit comboBox1;
        private IContainer components;
        private GroupBox gbBorder;
        private GroupBox gbDisPro;
        private GroupBox gbInterval;
        private GroupBox gbLabelDis;
        private GroupBox gbLabelOri;
        private GroupBox gbMajor;
        private GroupBox gbSub;
        private GroupBox gbTextFormmat;
        private IMapGridBorder gridBorder;
        private bool init;
        private LabelControl labelControl1;
        private LabelControl labelControl4;
        private Label lbBorderType;
        private LabelControl lbColor;
        private LabelControl lbFontFamily;
        private LabelControl lbLineSymbol;
        private LabelControl lbMajorSymbol;
        private LabelControl lbMajorTickPos;
        private LabelControl lbMajorTickSize;
        private LabelControl lbOffset;
        private LabelControl lbOffsetUnit;
        private LabelControl lbSize;
        private LabelControl lbSubSymbol;
        private LabelControl lbSubTickCount;
        private LabelControl lbSubTickPos;
        private LabelControl lbSubTickSize;
        private LabelControl lbVertical;
        private LabelControl lbXAxiesInt;
        private Label lbXUnit;
        private LabelControl lbYAxiesInt;
        private Label lbYUnit;
        private LabelControl lcBorderType;
        private SpinEdit nudMajorTickSize;
        private SpinEdit nudSubSize;
        private SpinEdit nudSubTickCount;
        private PictureBox pictureBox1;
        private RadioGroup radioGroup1;
        private RadioGroup rgMajorPos;
        private RadioGroup rgSubPos;
        private SimpleButton sbGridBorder;
        private TextEdit tbOffset;
        private TextEdit tbXIn;
        private TextEdit tbYIn;
        private ILineSymbol tickLineSymbol = new SimpleLineSymbolClass();
        private IMarkerSymbol tickMarkerSymbol = new SimpleMarkerSymbolClass();
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;

        public DevGrid(IActiveView pActiveView)
        {
            this.InitializeComponent();
            this.activeView = pActiveView;
            this._mapGrid = new MeasuredGridClass();
            IFormattedGridLabel label = new FormattedGridLabelClass();
            label.Format = new NumericFormatClass();
            INumericFormat format = label.Format as INumericFormat;
            format.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfDecimals;
            format.RoundingValue = 0;
            IGridLabel label2 = label as IGridLabel;
            label2.set_LabelAlignment(esriGridAxisEnum.esriGridAxisBottom, true);
            label2.set_LabelAlignment(esriGridAxisEnum.esriGridAxisLeft, false);
            label2.set_LabelAlignment(esriGridAxisEnum.esriGridAxisRight, false);
            label2.set_LabelAlignment(esriGridAxisEnum.esriGridAxisTop, true);
            this._mapGrid.LabelFormat = label2;
            IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
            grid.XIntervalSize = 1000.0;
            grid.YIntervalSize = 1000.0;
            this.CopyTick();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btLabelColor_ColorChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._mapGrid.LabelFormat.Color = ColorService.NetColorToEsriColor(this.btLabelColor.Color);
            }
        }

        private void btLineSymbol_Click(object sender, EventArgs e)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = null;
            if (this.radioGroup1.SelectedIndex == 0)
            {
                item = selector.GetItem(this._mapGrid.LineSymbol as ISymbol);
            }
            else
            {
                item = selector.GetItem(this._mapGrid.TickMarkSymbol as ISymbol);
            }
            selector.Dispose();
            if (item != null)
            {
                ISymbol pSymbol = null;
                Bitmap bitmap = null;
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    this._mapGrid.LineSymbol = item.Item as ILineSymbol;
                    pSymbol = this._mapGrid.LineSymbol as ISymbol;
                    object tickLineSymbol = this.tickLineSymbol;
                    this.CopyObject(this._mapGrid.LineSymbol, ref tickLineSymbol);
                    this.tickLineSymbol = tickLineSymbol as ILineSymbol;
                }
                else
                {
                    this._mapGrid.TickMarkSymbol = item.Item as IMarkerSymbol;
                    pSymbol = this._mapGrid.TickMarkSymbol as ISymbol;
                    object tickMarkerSymbol = this.tickMarkerSymbol;
                    this.CopyObject(this._mapGrid.TickMarkSymbol, ref tickMarkerSymbol);
                    this.tickMarkerSymbol = tickMarkerSymbol as IMarkerSymbol;
                }
                bitmap = BitmapManager.GetSymbolBitMap(pSymbol, this.btLineSymbol.Width - 4, this.btLineSymbol.Height - 2);
                this.btLineSymbol.Image = bitmap;
            }
        }

        private void btMajorSymbol_Click(object sender, EventArgs e)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = null;
            item = selector.GetItem(this._mapGrid.TickLineSymbol as ISymbol);
            selector.Dispose();
            if (item != null)
            {
                this._mapGrid.TickLineSymbol = item.Item as ILineSymbol;
                ISymbol tickLineSymbol = this._mapGrid.TickLineSymbol as ISymbol;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(tickLineSymbol, this.btMajorSymbol.Width - 4, this.btMajorSymbol.Height - 2);
                this.btMajorSymbol.Image = bitmap;
            }
        }

        private void btNumeric_Click(object sender, EventArgs e)
        {
            IFormattedGridLabel labelFormat = this._mapGrid.LabelFormat as IFormattedGridLabel;
            DevDigtal digtal = new DevDigtal(labelFormat.Format);
            digtal.ShowDialog();
            labelFormat.Format = digtal.Formmat;
            digtal.Dispose();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            IPageLayout activeView = this.activeView as IPageLayout;
            IGraphicsContainer container = activeView as IGraphicsContainer;
            IMapFrame frame = container.FindFrame(this.activeView.FocusMap) as IMapFrame;
            IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
            grid.FixedOrigin = true;
            grid.XOrigin = 36000000.0;
            IMapGrids grids = frame as IMapGrids;
            if (grids.MapGridCount != 0)
            {
                grids.ClearMapGrids();
            }
            grids.AddMapGrid(this._mapGrid);
            this.activeView.Refresh();
            base.Close();
        }

        private void btSub_Click(object sender, EventArgs e)
        {
            IPageLayout activeView = this.activeView as IPageLayout;
            IGraphicsContainer container = activeView as IGraphicsContainer;
            IMapFrame frame = container.FindFrame(this.activeView.FocusMap) as IMapFrame;
            IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
            grid.FixedOrigin = true;
            grid.XOrigin = 36000000.0;
            IMapGrids grids = frame as IMapGrids;
            if (grids.MapGridCount != 0)
            {
                grids.ClearMapGrids();
            }
            grids.AddMapGrid(this._mapGrid);
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.activeView.FocusMap as IBasicMap, configValue, true);
            if (layer != null)
            {
                IQueryFilter queryFilter = new QueryFilterClass();
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                queryFilter.WhereClause = str2 + "='" + EditTask.DistCode + "'";
                IFeature feature = layer.Search(queryFilter, false).NextFeature();
                IActiveView focusMap = this.activeView.FocusMap as IActiveView;
                focusMap.Extent = feature.Extent;
            }
            this.activeView.Refresh();
        }

        private void btSubSymbol_Click(object sender, EventArgs e)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = null;
            item = selector.GetItem(this._mapGrid.SubTickLineSymbol as ISymbol);
            selector.Dispose();
            if (item != null)
            {
                this._mapGrid.SubTickLineSymbol = item.Item as ILineSymbol;
                ISymbol subTickLineSymbol = this._mapGrid.SubTickLineSymbol as ISymbol;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(subTickLineSymbol, this.btSubSymbol.Width - 4, this.btSubSymbol.Height - 2);
                this.btSubSymbol.Image = bitmap;
            }
        }

        private void cbBold_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._mapGrid.LabelFormat.Font;
            font.Bold = this.cbBold.Checked;
            this._mapGrid.LabelFormat.Font = font;
        }

        private void cbeBorderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.cbBorderType.SelectedIndex == 0)
                {
                    if ((this.gridBorder == null) || !(this.gridBorder is ISimpleMapGridBorder))
                    {
                        this.gridBorder = new SimpleMapGridBorderClass();
                        this._mapGrid.Border = this.gridBorder;
                    }
                }
                else if ((this.gridBorder == null) || !(this.gridBorder is ICalibratedMapGridBorder))
                {
                    this.gridBorder = new CalibratedMapGridBorderClass();
                    this._mapGrid.Border = this.gridBorder;
                }
            }
        }

        private void cbIt_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._mapGrid.LabelFormat.Font;
            font.Italic = this.cbIt.Checked;
            this._mapGrid.LabelFormat.Font = font;
        }

        private void cbLabelBottom_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryLabelVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetLabelVisibility(leftVis, topVis, rightVis, this.cbLabelBottom.Checked);
        }

        private void cbLabelLeft_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryLabelVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetLabelVisibility(this.cbLabelLeft.Checked, topVis, rightVis, bottomVis);
        }

        private void cbLabelRight_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryLabelVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetLabelVisibility(leftVis, topVis, this.cbLabelRight.Checked, bottomVis);
        }

        private void cbLabelTop_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryLabelVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetLabelVisibility(leftVis, this.cbLabelTop.Checked, rightVis, bottomVis);
        }

        private void cbMajorBottom_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetTickVisibility(leftVis, topVis, rightVis, this.cbMajorBottom.Checked);
        }

        private void cbMajorLeft_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetTickVisibility(this.cbMajorLeft.Checked, topVis, rightVis, bottomVis);
        }

        private void cbMajorRight_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetTickVisibility(leftVis, topVis, this.cbMajorRight.Checked, bottomVis);
        }

        private void cbMajorTop_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetTickVisibility(leftVis, this.cbMajorTop.Checked, rightVis, bottomVis);
        }

        private void cbOriBottom_CheckedChanged(object sender, EventArgs e)
        {
            this._mapGrid.LabelFormat.set_LabelAlignment(esriGridAxisEnum.esriGridAxisBottom, this.cbOriBottom.Checked);
        }

        private void cbOriLeft_CheckedChanged(object sender, EventArgs e)
        {
            this._mapGrid.LabelFormat.set_LabelAlignment(esriGridAxisEnum.esriGridAxisLeft, this.cbOriLeft.Checked);
        }

        private void cbOriRight_CheckedChanged(object sender, EventArgs e)
        {
            this._mapGrid.LabelFormat.set_LabelAlignment(esriGridAxisEnum.esriGridAxisRight, this.cbOriRight.Checked);
        }

        private void cbOriTop_CheckedChanged(object sender, EventArgs e)
        {
            this._mapGrid.LabelFormat.set_LabelAlignment(esriGridAxisEnum.esriGridAxisTop, this.cbOriTop.Checked);
        }

        private void cbSubBottom_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetSubTickVisibility(leftVis, topVis, rightVis, this.cbSubBottom.Checked);
        }

        private void cbSubLeft_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetSubTickVisibility(this.cbSubLeft.Checked, topVis, rightVis, bottomVis);
        }

        private void cbSubRight_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetSubTickVisibility(leftVis, topVis, this.cbSubRight.Checked, bottomVis);
        }

        private void cbSubTop_CheckedChanged(object sender, EventArgs e)
        {
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this._mapGrid.SetSubTickVisibility(leftVis, this.cbSubTop.Checked, rightVis, bottomVis);
        }

        private void cbTextFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                stdole.IFontDisp font = this._mapGrid.LabelFormat.Font;
                font.Name = this.cbTextFamily.Text;
                this._mapGrid.LabelFormat.Font = font;
            }
        }

        private void cbUnderLine_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._mapGrid.LabelFormat.Font;
            font.Underline = this.cbUnderLine.Checked;
            this._mapGrid.LabelFormat.Font = font;
        }

        private void ceGridBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ceGridBorder.Checked)
            {
                this._mapGrid.Border = this.gridBorder;
                this.cbBorderType.Enabled = true;
                this.btGridBorder.Enabled = true;
            }
            else
            {
                this._mapGrid.Border = null;
                this.cbBorderType.Enabled = false;
                this.btGridBorder.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                stdole.IFontDisp font = this._mapGrid.LabelFormat.Font;
                font.Size = decimal.Parse(this.comboBox1.Text);
                this._mapGrid.LabelFormat.Font = font;
            }
        }

        private void CopyObject(object pOrigObj, ref object pTarObj)
        {
            IObjectCopy copy = new ObjectCopyClass();
            if (pOrigObj is ILineSymbol)
            {
                pTarObj = this.GetLineSymbolType(pOrigObj as ILineSymbol, pTarObj as ILineSymbol);
            }
            else
            {
                pTarObj = this.GetMarkerSymbolType(pOrigObj as IMarkerSymbol, pTarObj as IMarkerSymbol);
            }
            object pInObject = copy.Copy(pOrigObj);
            copy.Overwrite(pInObject, ref pTarObj);
        }

        private void CopyTick()
        {
            new ObjectCopyClass();
            if (this._mapGrid.LineSymbol != null)
            {
                this.tickLineSymbol = this.GetLineSymbolType(this._mapGrid.LineSymbol, this.tickLineSymbol);
                if (this.tickLineSymbol != null)
                {
                    CloneService.Clone(this._mapGrid.LineSymbol, this.tickLineSymbol);
                }
            }
            if (this._mapGrid.TickMarkSymbol != null)
            {
                this.tickMarkerSymbol = this.GetMarkerSymbolType(this._mapGrid.TickMarkSymbol, this.tickMarkerSymbol);
                if (this.tickMarkerSymbol != null)
                {
                    CloneService.Clone(this._mapGrid.TickMarkSymbol, this.tickMarkerSymbol);
                }
            }
            else
            {
                this._mapGrid.SetSubTickVisibility(false, false, false, false);
            }
            if (this._mapGrid.Border != null)
            {
                if (this._mapGrid.Border is ISimpleMapGridBorder)
                {
                    this.gridBorder = new SimpleMapGridBorderClass();
                }
                else
                {
                    this.gridBorder = new CalibratedMapGridBorderClass();
                }
                CloneService.Clone(this._mapGrid.Border, this.gridBorder);
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

        private ILineSymbol GetLineSymbolType(ILineSymbol pSymbol, ILineSymbol pTarSymbol)
        {
            if (pSymbol is ICartographicLineSymbol)
            {
                pTarSymbol = new CartographicLineSymbolClass();
            }
            if (pSymbol is IHashLineSymbol)
            {
                pTarSymbol = new HashLineSymbolClass();
            }
            if (pSymbol is IMarkerLineSymbol)
            {
                pTarSymbol = new MarkerLineSymbolClass();
            }
            if (pSymbol is IMultiLayerLineSymbol)
            {
                pTarSymbol = new MultiLayerLineSymbolClass();
            }
            if (pSymbol is IPictureLineSymbol)
            {
                pTarSymbol = new PictureLineSymbolClass();
            }
            if (pSymbol is ISimpleLineSymbol)
            {
                pTarSymbol = new SimpleLineSymbolClass();
            }
            return pTarSymbol;
        }

        private IMarkerSymbol GetMarkerSymbolType(IMarkerSymbol pSymbol, IMarkerSymbol pTarSymbol)
        {
            if (pSymbol is IArrowMarkerSymbol)
            {
                pTarSymbol = new ArrowMarkerSymbolClass();
            }
            if (pSymbol is IBarChartSymbol)
            {
                pTarSymbol = new BarChartSymbolClass();
            }
            if (pSymbol is ICharacterMarkerSymbol)
            {
                pTarSymbol = new CharacterMarkerSymbolClass();
            }
            if (pSymbol is IMultiLayerMarkerSymbol)
            {
                pTarSymbol = new MultiLayerMarkerSymbolClass();
            }
            if (pSymbol is IPictureMarkerSymbol)
            {
                pTarSymbol = new PictureMarkerSymbolClass();
            }
            if (pSymbol is IPieChartSymbol)
            {
                pTarSymbol = new PieChartSymbolClass();
            }
            if (pSymbol is ISimpleMarkerSymbol)
            {
                pTarSymbol = new SimpleMarkerSymbolClass();
            }
            if (pSymbol is IStackedChartSymbol)
            {
                pTarSymbol = new StackedChartSymbolClass();
            }
            return pTarSymbol;
        }

        private void Grid_Load(object sender, EventArgs e)
        {
            for (int i = 5; i < 0x49; i++)
            {
                this.comboBox1.Properties.Items.Add(i);
            }
            this.InitialControl();
        }

        private void InitialControl()
        {
            this.init = true;
            if (this._origMapGrid != null)
            {
                this.btSub.Visible = true;
                this.btOk.Text = "确定";
            }
            bool topVis = false;
            bool bottomVis = false;
            bool leftVis = false;
            bool rightVis = false;
            this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this.cbMajorLeft.Checked = leftVis;
            this.cbMajorRight.Checked = rightVis;
            this.cbMajorTop.Checked = topVis;
            this.cbMajorBottom.Checked = bottomVis;
            ISymbol tickLineSymbol = this._mapGrid.TickLineSymbol as ISymbol;
            Bitmap bitmap = null;
            if (tickLineSymbol != null)
            {
                bitmap = BitmapManager.GetSymbolBitMap(tickLineSymbol, this.btMajorSymbol.Width - 4, this.btMajorSymbol.Height - 2);
                this.btMajorSymbol.Image = bitmap;
                this._mapGrid.QueryTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
                this.cbMajorLeft.Checked = leftVis;
                this.cbMajorRight.Checked = rightVis;
                this.cbMajorTop.Checked = topVis;
                this.cbMajorBottom.Checked = bottomVis;
                if (this._mapGrid.TickLength < 0.0)
                {
                    this.rgMajorPos.SelectedIndex = 0;
                }
                else
                {
                    this.rgMajorPos.SelectedIndex = 1;
                }
                double tickLength = this._mapGrid.TickLength;
                if (tickLength < 0.0)
                {
                    tickLength = -tickLength;
                }
                this.nudMajorTickSize.Value = decimal.Parse(tickLength.ToString());
            }
            tickLineSymbol = this._mapGrid.SubTickLineSymbol as ISymbol;
            if (tickLineSymbol != null)
            {
                this._mapGrid.QuerySubTickVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
                this.cbSubLeft.Checked = leftVis;
                this.cbSubRight.Checked = rightVis;
                this.cbSubTop.Checked = topVis;
                this.cbSubBottom.Checked = bottomVis;
                bitmap = BitmapManager.GetSymbolBitMap(tickLineSymbol, this.btSubSymbol.Width - 4, this.btSubSymbol.Height - 2);
                this.btSubSymbol.Image = bitmap;
                this.nudSubTickCount.Value = decimal.Parse(this._mapGrid.SubTickCount.ToString());
                if (this._mapGrid.SubTickLength < 0.0)
                {
                    this.rgSubPos.SelectedIndex = 0;
                }
                else
                {
                    this.rgSubPos.SelectedIndex = 1;
                }
                double subTickLength = this._mapGrid.SubTickLength;
                if (subTickLength < 0.0)
                {
                    subTickLength = -subTickLength;
                }
                this.nudSubSize.Value = decimal.Parse(subTickLength.ToString());
            }
            else
            {
                this.cbSubBottom.Enabled = false;
                this.cbSubLeft.Enabled = false;
                this.cbSubRight.Enabled = false;
                this.cbSubTop.Enabled = false;
                this.btSubSymbol.Enabled = false;
                this.rgSubPos.Enabled = false;
                this.nudSubSize.Enabled = false;
            }
            if (this._mapGrid.LineSymbol != null)
            {
                this.radioGroup1.SelectedIndex = 0;
                tickLineSymbol = this._mapGrid.LineSymbol as ISymbol;
                bitmap = BitmapManager.GetSymbolBitMap(tickLineSymbol, this.btLineSymbol.Width - 4, this.btLineSymbol.Height - 2);
                this.btLineSymbol.Image = bitmap;
            }
            if (this._mapGrid.TickMarkSymbol != null)
            {
                this.radioGroup1.SelectedIndex = 1;
                tickLineSymbol = this._mapGrid.TickMarkSymbol as ISymbol;
                bitmap = BitmapManager.GetSymbolBitMap(tickLineSymbol, this.btLineSymbol.Width - 4, this.btLineSymbol.Height - 2);
                this.btLineSymbol.Image = bitmap;
            }
            if ((this._mapGrid.LineSymbol == null) & (this._mapGrid.TickMarkSymbol == null))
            {
                this.radioGroup1.SelectedIndex = 2;
                this.btLineSymbol.Enabled = false;
            }
            IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
            this.lbXUnit.Text = UnitService.GetUnitFromESRIUnitChinese(this.activeView.FocusMap.MapUnits);
            this.lbYUnit.Text = this.lbXUnit.Text;
            grid.Units = this.activeView.FocusMap.MapUnits;
            this.tbXIn.Text = grid.XIntervalSize.ToString();
            this.tbYIn.Text = grid.YIntervalSize.ToString();
            this._mapGrid.QueryLabelVisibility(ref leftVis, ref topVis, ref rightVis, ref bottomVis);
            this.cbLabelTop.Checked = topVis;
            this.cbLabelBottom.Checked = bottomVis;
            this.cbLabelLeft.Checked = leftVis;
            this.cbLabelRight.Checked = rightVis;
            bool flag5 = this._mapGrid.LabelFormat.get_LabelAlignment(esriGridAxisEnum.esriGridAxisLeft);
            this.cbOriLeft.Checked = flag5;
            flag5 = this._mapGrid.LabelFormat.get_LabelAlignment(esriGridAxisEnum.esriGridAxisRight);
            this.cbOriRight.Checked = flag5;
            flag5 = this._mapGrid.LabelFormat.get_LabelAlignment(esriGridAxisEnum.esriGridAxisTop);
            this.cbOriTop.Checked = flag5;
            flag5 = this._mapGrid.LabelFormat.get_LabelAlignment(esriGridAxisEnum.esriGridAxisBottom);
            this.cbOriBottom.Checked = flag5;
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                this.cbTextFamily.Properties.Items.Add(family.Name);
            }
            IGridLabel labelFormat = this._mapGrid.LabelFormat;
            this.cbTextFamily.Text = labelFormat.Font.Name;
            this.comboBox1.Text = labelFormat.Font.Size.ToString();
            this.btLabelColor.Color = ColorService.EsriColorToNetColor(this._mapGrid.LabelFormat.Color);
            this.cbBold.Checked = labelFormat.Font.Bold;
            this.cbUnderLine.Checked = labelFormat.Font.Underline;
            this.cbIt.Checked = labelFormat.Font.Italic;
            this.tbOffset.Text = labelFormat.LabelOffset.ToString();
            this.cbeBorderType.Properties.Items.Clear();
            this.cbeBorderType.Properties.Items.Add("简单边界");
            this.cbeBorderType.Properties.Items.Add("校准的边界");
            if (this._mapGrid.Border != null)
            {
                this.ceGridBorder.Checked = true;
                if (this._mapGrid.Border is ISimpleMapGridBorder)
                {
                    this.cbeBorderType.SelectedIndex = 0;
                }
                else
                {
                    this.cbeBorderType.SelectedIndex = 1;
                }
            }
            else
            {
                this.ceGridBorder.Checked = false;
                this.cbeBorderType.SelectedIndex = -1;
                this.cbeBorderType.Enabled = false;
                this.btGridBorder.Enabled = false;
            }
            this.init = false;
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gbSub = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nudSubSize = new DevExpress.XtraEditors.SpinEdit();
            this.lbSubTickSize = new DevExpress.XtraEditors.LabelControl();
            this.rgSubPos = new DevExpress.XtraEditors.RadioGroup();
            this.lbSubTickPos = new DevExpress.XtraEditors.LabelControl();
            this.nudSubTickCount = new DevExpress.XtraEditors.SpinEdit();
            this.lbSubTickCount = new DevExpress.XtraEditors.LabelControl();
            this.btSubSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.lbSubSymbol = new DevExpress.XtraEditors.LabelControl();
            this.cbSubRight = new DevExpress.XtraEditors.CheckEdit();
            this.cbSubBottom = new DevExpress.XtraEditors.CheckEdit();
            this.cbSubLeft = new DevExpress.XtraEditors.CheckEdit();
            this.cbSubTop = new DevExpress.XtraEditors.CheckEdit();
            this.gbMajor = new System.Windows.Forms.GroupBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.nudMajorTickSize = new DevExpress.XtraEditors.SpinEdit();
            this.lbMajorTickSize = new DevExpress.XtraEditors.LabelControl();
            this.rgMajorPos = new DevExpress.XtraEditors.RadioGroup();
            this.lbMajorTickPos = new DevExpress.XtraEditors.LabelControl();
            this.btMajorSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.lbMajorSymbol = new DevExpress.XtraEditors.LabelControl();
            this.cbMajorRight = new DevExpress.XtraEditors.CheckEdit();
            this.cbMajorBottom = new DevExpress.XtraEditors.CheckEdit();
            this.cbMajorLeft = new DevExpress.XtraEditors.CheckEdit();
            this.cbMajorTop = new DevExpress.XtraEditors.CheckEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gbInterval = new System.Windows.Forms.GroupBox();
            this.tbYIn = new DevExpress.XtraEditors.TextEdit();
            this.lbYAxiesInt = new DevExpress.XtraEditors.LabelControl();
            this.tbXIn = new DevExpress.XtraEditors.TextEdit();
            this.lbXAxiesInt = new DevExpress.XtraEditors.LabelControl();
            this.lbYUnit = new System.Windows.Forms.Label();
            this.lbXUnit = new System.Windows.Forms.Label();
            this.gbDisPro = new System.Windows.Forms.GroupBox();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btLineSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.lbLineSymbol = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gbTextFormmat = new System.Windows.Forms.GroupBox();
            this.btLabelColor = new DevExpress.XtraEditors.ColorEdit();
            this.cbTextFamily = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbSize = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbColor = new DevExpress.XtraEditors.LabelControl();
            this.btNumeric = new DevExpress.XtraEditors.SimpleButton();
            this.lbOffsetUnit = new DevExpress.XtraEditors.LabelControl();
            this.tbOffset = new DevExpress.XtraEditors.TextEdit();
            this.lbOffset = new DevExpress.XtraEditors.LabelControl();
            this.cbUnderLine = new DevExpress.XtraEditors.CheckEdit();
            this.cbIt = new DevExpress.XtraEditors.CheckEdit();
            this.cbBold = new DevExpress.XtraEditors.CheckEdit();
            this.lbFontFamily = new DevExpress.XtraEditors.LabelControl();
            this.gbLabelOri = new System.Windows.Forms.GroupBox();
            this.cbOriRight = new DevExpress.XtraEditors.CheckEdit();
            this.cbOriLeft = new DevExpress.XtraEditors.CheckEdit();
            this.cbOriBottom = new DevExpress.XtraEditors.CheckEdit();
            this.cbOriTop = new DevExpress.XtraEditors.CheckEdit();
            this.lbVertical = new DevExpress.XtraEditors.LabelControl();
            this.gbLabelDis = new System.Windows.Forms.GroupBox();
            this.cbLabelRight = new DevExpress.XtraEditors.CheckEdit();
            this.cbLabelLeft = new DevExpress.XtraEditors.CheckEdit();
            this.cbLabelBottom = new DevExpress.XtraEditors.CheckEdit();
            this.cbLabelTop = new DevExpress.XtraEditors.CheckEdit();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.gbBorder = new System.Windows.Forms.GroupBox();
            this.lcBorderType = new DevExpress.XtraEditors.LabelControl();
            this.sbGridBorder = new DevExpress.XtraEditors.SimpleButton();
            this.cbeBorderType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ceGridBorder = new DevExpress.XtraEditors.CheckEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbBorderType = new System.Windows.Forms.Label();
            this.cbGridBord = new System.Windows.Forms.CheckBox();
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.btGridBorder = new System.Windows.Forms.Button();
            this.btSub = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.gbSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSubPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTickCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubBottom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubTop.Properties)).BeginInit();
            this.gbMajor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMajorTickSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgMajorPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorBottom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorTop.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.gbInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbYIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXIn.Properties)).BeginInit();
            this.gbDisPro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.gbTextFormmat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btLabelColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTextFamily.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnderLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBold.Properties)).BeginInit();
            this.gbLabelOri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriBottom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriTop.Properties)).BeginInit();
            this.gbLabelDis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelBottom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelTop.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            this.gbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeBorderType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGridBorder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(518, 350);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gbSub);
            this.xtraTabPage1.Controls.Add(this.gbMajor);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(512, 321);
            this.xtraTabPage1.Text = "坐标轴";
            // 
            // gbSub
            // 
            this.gbSub.Controls.Add(this.labelControl1);
            this.gbSub.Controls.Add(this.nudSubSize);
            this.gbSub.Controls.Add(this.lbSubTickSize);
            this.gbSub.Controls.Add(this.rgSubPos);
            this.gbSub.Controls.Add(this.lbSubTickPos);
            this.gbSub.Controls.Add(this.nudSubTickCount);
            this.gbSub.Controls.Add(this.lbSubTickCount);
            this.gbSub.Controls.Add(this.btSubSymbol);
            this.gbSub.Controls.Add(this.lbSubSymbol);
            this.gbSub.Controls.Add(this.cbSubRight);
            this.gbSub.Controls.Add(this.cbSubBottom);
            this.gbSub.Controls.Add(this.cbSubLeft);
            this.gbSub.Controls.Add(this.cbSubTop);
            this.gbSub.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSub.Location = new System.Drawing.Point(0, 181);
            this.gbSub.Name = "gbSub";
            this.gbSub.Size = new System.Drawing.Size(512, 140);
            this.gbSub.TabIndex = 3;
            this.gbSub.TabStop = false;
            this.gbSub.Text = "子分隔刻度";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(475, 107);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "点";
            // 
            // nudSubSize
            // 
            this.nudSubSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSubSize.Location = new System.Drawing.Point(395, 104);
            this.nudSubSize.Name = "nudSubSize";
            this.nudSubSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudSubSize.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSubSize.Size = new System.Drawing.Size(72, 20);
            this.nudSubSize.TabIndex = 29;
            this.nudSubSize.ValueChanged += new System.EventHandler(this.nudSubSize_ValueChanged);
            // 
            // lbSubTickSize
            // 
            this.lbSubTickSize.Location = new System.Drawing.Point(328, 107);
            this.lbSubTickSize.Name = "lbSubTickSize";
            this.lbSubTickSize.Size = new System.Drawing.Size(52, 14);
            this.lbSubTickSize.TabIndex = 28;
            this.lbSubTickSize.Text = "刻度大小:";
            // 
            // rgSubPos
            // 
            this.rgSubPos.Location = new System.Drawing.Point(99, 101);
            this.rgSubPos.Name = "rgSubPos";
            this.rgSubPos.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSubPos.Properties.Appearance.Options.UseBackColor = true;
            this.rgSubPos.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSubPos.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "数据框内部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "数据框外部")});
            this.rgSubPos.Size = new System.Drawing.Size(205, 30);
            this.rgSubPos.TabIndex = 27;
            this.rgSubPos.SelectedIndexChanged += new System.EventHandler(this.rgSubPos_Changed);
            // 
            // lbSubTickPos
            // 
            this.lbSubTickPos.Location = new System.Drawing.Point(24, 107);
            this.lbSubTickPos.Name = "lbSubTickPos";
            this.lbSubTickPos.Size = new System.Drawing.Size(52, 14);
            this.lbSubTickPos.TabIndex = 26;
            this.lbSubTickPos.Text = "显示刻度:";
            // 
            // nudSubTickCount
            // 
            this.nudSubTickCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSubTickCount.Location = new System.Drawing.Point(309, 68);
            this.nudSubTickCount.Name = "nudSubTickCount";
            this.nudSubTickCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudSubTickCount.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSubTickCount.Size = new System.Drawing.Size(58, 20);
            this.nudSubTickCount.TabIndex = 25;
            this.nudSubTickCount.ValueChanged += new System.EventHandler(this.nudSubTickCount_ValueChanged);
            // 
            // lbSubTickCount
            // 
            this.lbSubTickCount.Location = new System.Drawing.Point(258, 71);
            this.lbSubTickCount.Name = "lbSubTickCount";
            this.lbSubTickCount.Size = new System.Drawing.Size(40, 14);
            this.lbSubTickCount.TabIndex = 24;
            this.lbSubTickCount.Text = "子分隔:";
            // 
            // btSubSymbol
            // 
            this.btSubSymbol.Location = new System.Drawing.Point(79, 66);
            this.btSubSymbol.LookAndFeel.UseWindowsXPTheme = true;
            this.btSubSymbol.Name = "btSubSymbol";
            this.btSubSymbol.Size = new System.Drawing.Size(103, 27);
            this.btSubSymbol.TabIndex = 23;
            this.btSubSymbol.Click += new System.EventHandler(this.btSubSymbol_Click);
            // 
            // lbSubSymbol
            // 
            this.lbSubSymbol.Location = new System.Drawing.Point(24, 71);
            this.lbSubSymbol.Name = "lbSubSymbol";
            this.lbSubSymbol.Size = new System.Drawing.Size(28, 14);
            this.lbSubSymbol.TabIndex = 22;
            this.lbSubSymbol.Text = "符号:";
            // 
            // cbSubRight
            // 
            this.cbSubRight.Location = new System.Drawing.Point(341, 31);
            this.cbSubRight.Name = "cbSubRight";
            this.cbSubRight.Properties.Caption = "右";
            this.cbSubRight.Size = new System.Drawing.Size(87, 19);
            this.cbSubRight.TabIndex = 21;
            this.cbSubRight.CheckedChanged += new System.EventHandler(this.cbSubRight_CheckedChanged);
            // 
            // cbSubBottom
            // 
            this.cbSubBottom.Location = new System.Drawing.Point(236, 31);
            this.cbSubBottom.Name = "cbSubBottom";
            this.cbSubBottom.Properties.Caption = "下";
            this.cbSubBottom.Size = new System.Drawing.Size(87, 19);
            this.cbSubBottom.TabIndex = 20;
            this.cbSubBottom.CheckedChanged += new System.EventHandler(this.cbSubBottom_CheckedChanged);
            // 
            // cbSubLeft
            // 
            this.cbSubLeft.Location = new System.Drawing.Point(131, 31);
            this.cbSubLeft.Name = "cbSubLeft";
            this.cbSubLeft.Properties.Caption = "左";
            this.cbSubLeft.Size = new System.Drawing.Size(87, 19);
            this.cbSubLeft.TabIndex = 19;
            this.cbSubLeft.CheckedChanged += new System.EventHandler(this.cbSubLeft_CheckedChanged);
            // 
            // cbSubTop
            // 
            this.cbSubTop.Location = new System.Drawing.Point(26, 31);
            this.cbSubTop.Name = "cbSubTop";
            this.cbSubTop.Properties.Caption = "上";
            this.cbSubTop.Size = new System.Drawing.Size(87, 19);
            this.cbSubTop.TabIndex = 18;
            this.cbSubTop.CheckedChanged += new System.EventHandler(this.cbSubTop_CheckedChanged);
            // 
            // gbMajor
            // 
            this.gbMajor.Controls.Add(this.labelControl4);
            this.gbMajor.Controls.Add(this.nudMajorTickSize);
            this.gbMajor.Controls.Add(this.lbMajorTickSize);
            this.gbMajor.Controls.Add(this.rgMajorPos);
            this.gbMajor.Controls.Add(this.lbMajorTickPos);
            this.gbMajor.Controls.Add(this.btMajorSymbol);
            this.gbMajor.Controls.Add(this.lbMajorSymbol);
            this.gbMajor.Controls.Add(this.cbMajorRight);
            this.gbMajor.Controls.Add(this.cbMajorBottom);
            this.gbMajor.Controls.Add(this.cbMajorLeft);
            this.gbMajor.Controls.Add(this.cbMajorTop);
            this.gbMajor.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMajor.Location = new System.Drawing.Point(0, 0);
            this.gbMajor.Name = "gbMajor";
            this.gbMajor.Size = new System.Drawing.Size(512, 140);
            this.gbMajor.TabIndex = 2;
            this.gbMajor.TabStop = false;
            this.gbMajor.Text = "主分隔刻度";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(475, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(12, 14);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "点";
            // 
            // nudMajorTickSize
            // 
            this.nudMajorTickSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMajorTickSize.Location = new System.Drawing.Point(395, 104);
            this.nudMajorTickSize.Name = "nudMajorTickSize";
            this.nudMajorTickSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudMajorTickSize.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMajorTickSize.Size = new System.Drawing.Size(72, 20);
            this.nudMajorTickSize.TabIndex = 23;
            this.nudMajorTickSize.ValueChanged += new System.EventHandler(this.nudMajorTickSize_ValueChanged);
            // 
            // lbMajorTickSize
            // 
            this.lbMajorTickSize.Location = new System.Drawing.Point(328, 107);
            this.lbMajorTickSize.Name = "lbMajorTickSize";
            this.lbMajorTickSize.Size = new System.Drawing.Size(52, 14);
            this.lbMajorTickSize.TabIndex = 22;
            this.lbMajorTickSize.Text = "刻度大小:";
            // 
            // rgMajorPos
            // 
            this.rgMajorPos.Location = new System.Drawing.Point(99, 101);
            this.rgMajorPos.Name = "rgMajorPos";
            this.rgMajorPos.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgMajorPos.Properties.Appearance.Options.UseBackColor = true;
            this.rgMajorPos.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgMajorPos.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "数据框内部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "数据框外部")});
            this.rgMajorPos.Size = new System.Drawing.Size(205, 30);
            this.rgMajorPos.TabIndex = 21;
            this.rgMajorPos.SelectedIndexChanged += new System.EventHandler(this.rgMajorPos_Changed);
            // 
            // lbMajorTickPos
            // 
            this.lbMajorTickPos.Location = new System.Drawing.Point(24, 107);
            this.lbMajorTickPos.Name = "lbMajorTickPos";
            this.lbMajorTickPos.Size = new System.Drawing.Size(52, 14);
            this.lbMajorTickPos.TabIndex = 20;
            this.lbMajorTickPos.Text = "显示刻度:";
            // 
            // btMajorSymbol
            // 
            this.btMajorSymbol.Location = new System.Drawing.Point(79, 66);
            this.btMajorSymbol.LookAndFeel.UseWindowsXPTheme = true;
            this.btMajorSymbol.Name = "btMajorSymbol";
            this.btMajorSymbol.Size = new System.Drawing.Size(103, 27);
            this.btMajorSymbol.TabIndex = 19;
            this.btMajorSymbol.Click += new System.EventHandler(this.btMajorSymbol_Click);
            // 
            // lbMajorSymbol
            // 
            this.lbMajorSymbol.Location = new System.Drawing.Point(24, 71);
            this.lbMajorSymbol.Name = "lbMajorSymbol";
            this.lbMajorSymbol.Size = new System.Drawing.Size(28, 14);
            this.lbMajorSymbol.TabIndex = 18;
            this.lbMajorSymbol.Text = "符号:";
            // 
            // cbMajorRight
            // 
            this.cbMajorRight.Location = new System.Drawing.Point(341, 31);
            this.cbMajorRight.Name = "cbMajorRight";
            this.cbMajorRight.Properties.Caption = "右";
            this.cbMajorRight.Size = new System.Drawing.Size(87, 19);
            this.cbMajorRight.TabIndex = 17;
            this.cbMajorRight.CheckedChanged += new System.EventHandler(this.cbMajorRight_CheckedChanged);
            // 
            // cbMajorBottom
            // 
            this.cbMajorBottom.Location = new System.Drawing.Point(236, 31);
            this.cbMajorBottom.Name = "cbMajorBottom";
            this.cbMajorBottom.Properties.Caption = "下";
            this.cbMajorBottom.Size = new System.Drawing.Size(87, 19);
            this.cbMajorBottom.TabIndex = 16;
            this.cbMajorBottom.CheckedChanged += new System.EventHandler(this.cbMajorBottom_CheckedChanged);
            // 
            // cbMajorLeft
            // 
            this.cbMajorLeft.Location = new System.Drawing.Point(131, 31);
            this.cbMajorLeft.Name = "cbMajorLeft";
            this.cbMajorLeft.Properties.Caption = "左";
            this.cbMajorLeft.Size = new System.Drawing.Size(87, 19);
            this.cbMajorLeft.TabIndex = 15;
            this.cbMajorLeft.CheckedChanged += new System.EventHandler(this.cbMajorLeft_CheckedChanged);
            // 
            // cbMajorTop
            // 
            this.cbMajorTop.Location = new System.Drawing.Point(26, 31);
            this.cbMajorTop.Name = "cbMajorTop";
            this.cbMajorTop.Properties.Caption = "上";
            this.cbMajorTop.Size = new System.Drawing.Size(87, 19);
            this.cbMajorTop.TabIndex = 14;
            this.cbMajorTop.CheckedChanged += new System.EventHandler(this.cbMajorTop_CheckedChanged);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gbInterval);
            this.xtraTabPage2.Controls.Add(this.gbDisPro);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(512, 321);
            this.xtraTabPage2.Text = "格网线";
            // 
            // gbInterval
            // 
            this.gbInterval.Controls.Add(this.tbYIn);
            this.gbInterval.Controls.Add(this.lbYAxiesInt);
            this.gbInterval.Controls.Add(this.tbXIn);
            this.gbInterval.Controls.Add(this.lbXAxiesInt);
            this.gbInterval.Controls.Add(this.lbYUnit);
            this.gbInterval.Controls.Add(this.lbXUnit);
            this.gbInterval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbInterval.Location = new System.Drawing.Point(0, 199);
            this.gbInterval.Name = "gbInterval";
            this.gbInterval.Size = new System.Drawing.Size(512, 122);
            this.gbInterval.TabIndex = 8;
            this.gbInterval.TabStop = false;
            this.gbInterval.Text = "间隔";
            // 
            // tbYIn
            // 
            this.tbYIn.Location = new System.Drawing.Point(96, 73);
            this.tbYIn.Name = "tbYIn";
            this.tbYIn.Size = new System.Drawing.Size(117, 20);
            this.tbYIn.TabIndex = 9;
            this.tbYIn.Leave += new System.EventHandler(this.tbYIn_Leave);
            // 
            // lbYAxiesInt
            // 
            this.lbYAxiesInt.Location = new System.Drawing.Point(20, 77);
            this.lbYAxiesInt.Name = "lbYAxiesInt";
            this.lbYAxiesInt.Size = new System.Drawing.Size(60, 14);
            this.lbYAxiesInt.TabIndex = 8;
            this.lbYAxiesInt.Text = "Y坐标间隔:";
            // 
            // tbXIn
            // 
            this.tbXIn.Location = new System.Drawing.Point(96, 33);
            this.tbXIn.Name = "tbXIn";
            this.tbXIn.Size = new System.Drawing.Size(117, 20);
            this.tbXIn.TabIndex = 7;
            this.tbXIn.Leave += new System.EventHandler(this.ttbXIn_Leave);
            // 
            // lbXAxiesInt
            // 
            this.lbXAxiesInt.Location = new System.Drawing.Point(20, 35);
            this.lbXAxiesInt.Name = "lbXAxiesInt";
            this.lbXAxiesInt.Size = new System.Drawing.Size(59, 14);
            this.lbXAxiesInt.TabIndex = 6;
            this.lbXAxiesInt.Text = "X坐标间隔:";
            // 
            // lbYUnit
            // 
            this.lbYUnit.AutoSize = true;
            this.lbYUnit.Location = new System.Drawing.Point(219, 77);
            this.lbYUnit.Name = "lbYUnit";
            this.lbYUnit.Size = new System.Drawing.Size(0, 14);
            this.lbYUnit.TabIndex = 5;
            // 
            // lbXUnit
            // 
            this.lbXUnit.AutoSize = true;
            this.lbXUnit.Location = new System.Drawing.Point(219, 36);
            this.lbXUnit.Name = "lbXUnit";
            this.lbXUnit.Size = new System.Drawing.Size(0, 14);
            this.lbXUnit.TabIndex = 4;
            // 
            // gbDisPro
            // 
            this.gbDisPro.Controls.Add(this.radioGroup1);
            this.gbDisPro.Controls.Add(this.pictureBox1);
            this.gbDisPro.Controls.Add(this.btLineSymbol);
            this.gbDisPro.Controls.Add(this.lbLineSymbol);
            this.gbDisPro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDisPro.Location = new System.Drawing.Point(0, 0);
            this.gbDisPro.Name = "gbDisPro";
            this.gbDisPro.Size = new System.Drawing.Size(512, 188);
            this.gbDisPro.TabIndex = 7;
            this.gbDisPro.TabStop = false;
            this.gbDisPro.Text = "显示";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(20, 24);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "显示为格网线"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "显示成格网刻度"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "不显示线或刻度")});
            this.radioGroup1.Size = new System.Drawing.Size(157, 112);
            this.radioGroup1.TabIndex = 11;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(236, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 105);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btLineSymbol
            // 
            this.btLineSymbol.Location = new System.Drawing.Point(59, 149);
            this.btLineSymbol.Name = "btLineSymbol";
            this.btLineSymbol.Size = new System.Drawing.Size(87, 27);
            this.btLineSymbol.TabIndex = 9;
            this.btLineSymbol.Click += new System.EventHandler(this.btLineSymbol_Click);
            // 
            // lbLineSymbol
            // 
            this.lbLineSymbol.Location = new System.Drawing.Point(20, 154);
            this.lbLineSymbol.Name = "lbLineSymbol";
            this.lbLineSymbol.Size = new System.Drawing.Size(28, 14);
            this.lbLineSymbol.TabIndex = 8;
            this.lbLineSymbol.Text = "符号:";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gbTextFormmat);
            this.xtraTabPage3.Controls.Add(this.gbLabelOri);
            this.xtraTabPage3.Controls.Add(this.gbLabelDis);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(512, 321);
            this.xtraTabPage3.Text = "标注";
            // 
            // gbTextFormmat
            // 
            this.gbTextFormmat.Controls.Add(this.btLabelColor);
            this.gbTextFormmat.Controls.Add(this.cbTextFamily);
            this.gbTextFormmat.Controls.Add(this.lbSize);
            this.gbTextFormmat.Controls.Add(this.comboBox1);
            this.gbTextFormmat.Controls.Add(this.lbColor);
            this.gbTextFormmat.Controls.Add(this.btNumeric);
            this.gbTextFormmat.Controls.Add(this.lbOffsetUnit);
            this.gbTextFormmat.Controls.Add(this.tbOffset);
            this.gbTextFormmat.Controls.Add(this.lbOffset);
            this.gbTextFormmat.Controls.Add(this.cbUnderLine);
            this.gbTextFormmat.Controls.Add(this.cbIt);
            this.gbTextFormmat.Controls.Add(this.cbBold);
            this.gbTextFormmat.Controls.Add(this.lbFontFamily);
            this.gbTextFormmat.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTextFormmat.Location = new System.Drawing.Point(0, 52);
            this.gbTextFormmat.Name = "gbTextFormmat";
            this.gbTextFormmat.Size = new System.Drawing.Size(512, 202);
            this.gbTextFormmat.TabIndex = 9;
            this.gbTextFormmat.TabStop = false;
            this.gbTextFormmat.Text = "格式";
            // 
            // btLabelColor
            // 
            this.btLabelColor.EditValue = System.Drawing.Color.Empty;
            this.btLabelColor.Location = new System.Drawing.Point(65, 118);
            this.btLabelColor.Name = "btLabelColor";
            this.btLabelColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btLabelColor.Size = new System.Drawing.Size(50, 20);
            this.btLabelColor.TabIndex = 27;
            this.btLabelColor.ColorChanged += new System.EventHandler(this.btLabelColor_ColorChanged);
            // 
            // cbTextFamily
            // 
            this.cbTextFamily.Location = new System.Drawing.Point(65, 26);
            this.cbTextFamily.Name = "cbTextFamily";
            this.cbTextFamily.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTextFamily.Size = new System.Drawing.Size(202, 20);
            this.cbTextFamily.TabIndex = 26;
            this.cbTextFamily.SelectedIndexChanged += new System.EventHandler(this.cbTextFamily_SelectedIndexChanged);
            // 
            // lbSize
            // 
            this.lbSize.Location = new System.Drawing.Point(19, 73);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(28, 14);
            this.lbSize.TabIndex = 25;
            this.lbSize.Text = "大小:";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(65, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox1.Size = new System.Drawing.Size(80, 20);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbColor
            // 
            this.lbColor.Location = new System.Drawing.Point(19, 121);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(28, 14);
            this.lbColor.TabIndex = 23;
            this.lbColor.Text = "颜色:";
            // 
            // btNumeric
            // 
            this.btNumeric.Location = new System.Drawing.Point(229, 153);
            this.btNumeric.Name = "btNumeric";
            this.btNumeric.Size = new System.Drawing.Size(87, 27);
            this.btNumeric.TabIndex = 21;
            this.btNumeric.Text = "其他属性";
            this.btNumeric.Click += new System.EventHandler(this.btNumeric_Click);
            // 
            // lbOffsetUnit
            // 
            this.lbOffsetUnit.Location = new System.Drawing.Point(183, 166);
            this.lbOffsetUnit.Name = "lbOffsetUnit";
            this.lbOffsetUnit.Size = new System.Drawing.Size(12, 14);
            this.lbOffsetUnit.TabIndex = 20;
            this.lbOffsetUnit.Text = "点";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(89, 162);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(87, 20);
            this.tbOffset.TabIndex = 19;
            this.tbOffset.Leave += new System.EventHandler(this.tbOffset_Leave);
            // 
            // lbOffset
            // 
            this.lbOffset.Location = new System.Drawing.Point(21, 166);
            this.lbOffset.Name = "lbOffset";
            this.lbOffset.Size = new System.Drawing.Size(52, 14);
            this.lbOffset.TabIndex = 18;
            this.lbOffset.Text = "标注偏移:";
            // 
            // cbUnderLine
            // 
            this.cbUnderLine.Location = new System.Drawing.Point(316, 72);
            this.cbUnderLine.Name = "cbUnderLine";
            this.cbUnderLine.Properties.Caption = "下划线";
            this.cbUnderLine.Size = new System.Drawing.Size(71, 19);
            this.cbUnderLine.TabIndex = 17;
            this.cbUnderLine.Click += new System.EventHandler(this.cbUnderLine_Click);
            // 
            // cbIt
            // 
            this.cbIt.Location = new System.Drawing.Point(255, 72);
            this.cbIt.Name = "cbIt";
            this.cbIt.Properties.Caption = "斜体";
            this.cbIt.Size = new System.Drawing.Size(61, 19);
            this.cbIt.TabIndex = 16;
            this.cbIt.Click += new System.EventHandler(this.cbIt_Click);
            // 
            // cbBold
            // 
            this.cbBold.Location = new System.Drawing.Point(192, 72);
            this.cbBold.Name = "cbBold";
            this.cbBold.Properties.Caption = "加粗";
            this.cbBold.Size = new System.Drawing.Size(56, 19);
            this.cbBold.TabIndex = 15;
            this.cbBold.Click += new System.EventHandler(this.cbBold_Click);
            // 
            // lbFontFamily
            // 
            this.lbFontFamily.Location = new System.Drawing.Point(19, 29);
            this.lbFontFamily.Name = "lbFontFamily";
            this.lbFontFamily.Size = new System.Drawing.Size(28, 14);
            this.lbFontFamily.TabIndex = 14;
            this.lbFontFamily.Text = "字体:";
            // 
            // gbLabelOri
            // 
            this.gbLabelOri.Controls.Add(this.cbOriRight);
            this.gbLabelOri.Controls.Add(this.cbOriLeft);
            this.gbLabelOri.Controls.Add(this.cbOriBottom);
            this.gbLabelOri.Controls.Add(this.cbOriTop);
            this.gbLabelOri.Controls.Add(this.lbVertical);
            this.gbLabelOri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLabelOri.Location = new System.Drawing.Point(0, 269);
            this.gbLabelOri.Name = "gbLabelOri";
            this.gbLabelOri.Size = new System.Drawing.Size(512, 52);
            this.gbLabelOri.TabIndex = 8;
            this.gbLabelOri.TabStop = false;
            this.gbLabelOri.Text = "标注方向";
            // 
            // cbOriRight
            // 
            this.cbOriRight.Location = new System.Drawing.Point(427, 24);
            this.cbOriRight.Name = "cbOriRight";
            this.cbOriRight.Properties.Caption = "右";
            this.cbOriRight.Size = new System.Drawing.Size(43, 19);
            this.cbOriRight.TabIndex = 9;
            this.cbOriRight.CheckedChanged += new System.EventHandler(this.cbOriRight_CheckedChanged);
            // 
            // cbOriLeft
            // 
            this.cbOriLeft.Location = new System.Drawing.Point(217, 24);
            this.cbOriLeft.Name = "cbOriLeft";
            this.cbOriLeft.Properties.Caption = "左";
            this.cbOriLeft.Size = new System.Drawing.Size(43, 19);
            this.cbOriLeft.TabIndex = 8;
            this.cbOriLeft.CheckedChanged += new System.EventHandler(this.cbOriLeft_CheckedChanged);
            // 
            // cbOriBottom
            // 
            this.cbOriBottom.Location = new System.Drawing.Point(322, 24);
            this.cbOriBottom.Name = "cbOriBottom";
            this.cbOriBottom.Properties.Caption = "下";
            this.cbOriBottom.Size = new System.Drawing.Size(43, 19);
            this.cbOriBottom.TabIndex = 7;
            this.cbOriBottom.CheckedChanged += new System.EventHandler(this.cbOriBottom_CheckedChanged);
            // 
            // cbOriTop
            // 
            this.cbOriTop.Location = new System.Drawing.Point(112, 24);
            this.cbOriTop.Name = "cbOriTop";
            this.cbOriTop.Properties.Caption = "上";
            this.cbOriTop.Size = new System.Drawing.Size(43, 19);
            this.cbOriTop.TabIndex = 6;
            this.cbOriTop.CheckedChanged += new System.EventHandler(this.cbOriTop_CheckedChanged);
            // 
            // lbVertical
            // 
            this.lbVertical.Location = new System.Drawing.Point(21, 24);
            this.lbVertical.Name = "lbVertical";
            this.lbVertical.Size = new System.Drawing.Size(52, 14);
            this.lbVertical.TabIndex = 5;
            this.lbVertical.Text = "垂直标注:";
            // 
            // gbLabelDis
            // 
            this.gbLabelDis.Controls.Add(this.cbLabelRight);
            this.gbLabelDis.Controls.Add(this.cbLabelLeft);
            this.gbLabelDis.Controls.Add(this.cbLabelBottom);
            this.gbLabelDis.Controls.Add(this.cbLabelTop);
            this.gbLabelDis.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLabelDis.Location = new System.Drawing.Point(0, 0);
            this.gbLabelDis.Name = "gbLabelDis";
            this.gbLabelDis.Size = new System.Drawing.Size(512, 52);
            this.gbLabelDis.TabIndex = 7;
            this.gbLabelDis.TabStop = false;
            this.gbLabelDis.Text = "标注轴";
            // 
            // cbLabelRight
            // 
            this.cbLabelRight.Location = new System.Drawing.Point(322, 23);
            this.cbLabelRight.Name = "cbLabelRight";
            this.cbLabelRight.Properties.Caption = "右";
            this.cbLabelRight.Size = new System.Drawing.Size(45, 19);
            this.cbLabelRight.TabIndex = 3;
            this.cbLabelRight.CheckedChanged += new System.EventHandler(this.cbLabelRight_CheckedChanged);
            // 
            // cbLabelLeft
            // 
            this.cbLabelLeft.Location = new System.Drawing.Point(112, 23);
            this.cbLabelLeft.Name = "cbLabelLeft";
            this.cbLabelLeft.Properties.Caption = "左";
            this.cbLabelLeft.Size = new System.Drawing.Size(45, 19);
            this.cbLabelLeft.TabIndex = 2;
            this.cbLabelLeft.CheckedChanged += new System.EventHandler(this.cbLabelLeft_CheckedChanged);
            // 
            // cbLabelBottom
            // 
            this.cbLabelBottom.Location = new System.Drawing.Point(217, 24);
            this.cbLabelBottom.Name = "cbLabelBottom";
            this.cbLabelBottom.Properties.Caption = "下";
            this.cbLabelBottom.Size = new System.Drawing.Size(45, 19);
            this.cbLabelBottom.TabIndex = 1;
            this.cbLabelBottom.CheckedChanged += new System.EventHandler(this.cbLabelBottom_CheckedChanged);
            // 
            // cbLabelTop
            // 
            this.cbLabelTop.Location = new System.Drawing.Point(19, 23);
            this.cbLabelTop.Name = "cbLabelTop";
            this.cbLabelTop.Properties.Caption = "上";
            this.cbLabelTop.Size = new System.Drawing.Size(45, 19);
            this.cbLabelTop.TabIndex = 0;
            this.cbLabelTop.CheckedChanged += new System.EventHandler(this.cbLabelTop_CheckedChanged);
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.gbBorder);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(512, 321);
            this.xtraTabPage4.Text = "边框";
            // 
            // gbBorder
            // 
            this.gbBorder.Controls.Add(this.lcBorderType);
            this.gbBorder.Controls.Add(this.sbGridBorder);
            this.gbBorder.Controls.Add(this.cbeBorderType);
            this.gbBorder.Controls.Add(this.ceGridBorder);
            this.gbBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBorder.Location = new System.Drawing.Point(0, 0);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(512, 321);
            this.gbBorder.TabIndex = 5;
            this.gbBorder.TabStop = false;
            this.gbBorder.Text = "边框";
            // 
            // lcBorderType
            // 
            this.lcBorderType.Location = new System.Drawing.Point(16, 73);
            this.lcBorderType.Name = "lcBorderType";
            this.lcBorderType.Size = new System.Drawing.Size(76, 14);
            this.lcBorderType.TabIndex = 9;
            this.lcBorderType.Text = "格网边框类型:";
            // 
            // sbGridBorder
            // 
            this.sbGridBorder.Location = new System.Drawing.Point(322, 68);
            this.sbGridBorder.Name = "sbGridBorder";
            this.sbGridBorder.Size = new System.Drawing.Size(68, 27);
            this.sbGridBorder.TabIndex = 8;
            this.sbGridBorder.Text = "属性";
            this.sbGridBorder.Click += new System.EventHandler(this.sbGridBorder_Click);
            // 
            // cbeBorderType
            // 
            this.cbeBorderType.Location = new System.Drawing.Point(128, 70);
            this.cbeBorderType.Name = "cbeBorderType";
            this.cbeBorderType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeBorderType.Size = new System.Drawing.Size(161, 20);
            this.cbeBorderType.TabIndex = 7;
            this.cbeBorderType.SelectedIndexChanged += new System.EventHandler(this.cbeBorderType_SelectedIndexChanged);
            // 
            // ceGridBorder
            // 
            this.ceGridBorder.Location = new System.Drawing.Point(14, 26);
            this.ceGridBorder.Name = "ceGridBorder";
            this.ceGridBorder.Properties.Caption = "放置格网边框:";
            this.ceGridBorder.Size = new System.Drawing.Size(118, 19);
            this.ceGridBorder.TabIndex = 5;
            this.ceGridBorder.CheckedChanged += new System.EventHandler(this.ceGridBorder_CheckedChanged);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(201, 359);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "创建";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(313, 359);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbBorderType
            // 
            this.lbBorderType.AutoSize = true;
            this.lbBorderType.Location = new System.Drawing.Point(12, 67);
            this.lbBorderType.Name = "lbBorderType";
            this.lbBorderType.Size = new System.Drawing.Size(35, 12);
            this.lbBorderType.TabIndex = 4;
            this.lbBorderType.Text = "类型:";
            // 
            // cbGridBord
            // 
            this.cbGridBord.AutoSize = true;
            this.cbGridBord.Location = new System.Drawing.Point(12, 20);
            this.cbGridBord.Name = "cbGridBord";
            this.cbGridBord.Size = new System.Drawing.Size(96, 16);
            this.cbGridBord.TabIndex = 0;
            this.cbGridBord.Text = "放置格网边框";
            this.cbGridBord.UseVisualStyleBackColor = true;
            // 
            // cbBorderType
            // 
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Items.AddRange(new object[] {
            "简单边界",
            "校准的边界"});
            this.cbBorderType.Location = new System.Drawing.Point(65, 63);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 20);
            this.cbBorderType.TabIndex = 3;
            // 
            // btGridBorder
            // 
            this.btGridBorder.Location = new System.Drawing.Point(12, 110);
            this.btGridBorder.Name = "btGridBorder";
            this.btGridBorder.Size = new System.Drawing.Size(75, 23);
            this.btGridBorder.TabIndex = 2;
            this.btGridBorder.UseVisualStyleBackColor = false;
            // 
            // btSub
            // 
            this.btSub.Location = new System.Drawing.Point(423, 359);
            this.btSub.Name = "btSub";
            this.btSub.Size = new System.Drawing.Size(87, 27);
            this.btSub.TabIndex = 4;
            this.btSub.Text = "应用";
            this.btSub.Visible = false;
            this.btSub.Click += new System.EventHandler(this.btSub_Click);
            // 
            // DevGrid
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(518, 397);
            this.Controls.Add(this.btSub);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.xtraTabControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "公里网";
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.gbSub.ResumeLayout(false);
            this.gbSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSubPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTickCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubBottom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubTop.Properties)).EndInit();
            this.gbMajor.ResumeLayout(false);
            this.gbMajor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMajorTickSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgMajorPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorBottom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMajorTop.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.gbInterval.ResumeLayout(false);
            this.gbInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbYIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXIn.Properties)).EndInit();
            this.gbDisPro.ResumeLayout(false);
            this.gbDisPro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.gbTextFormmat.ResumeLayout(false);
            this.gbTextFormmat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btLabelColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTextFamily.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnderLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBold.Properties)).EndInit();
            this.gbLabelOri.ResumeLayout(false);
            this.gbLabelOri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriBottom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOriTop.Properties)).EndInit();
            this.gbLabelDis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelBottom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLabelTop.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.gbBorder.ResumeLayout(false);
            this.gbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeBorderType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGridBorder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void nudMajorTickSize_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this._mapGrid.TickLength < 0.0)
                {
                    this._mapGrid.TickLength = -double.Parse(this.nudMajorTickSize.Value.ToString());
                }
                else
                {
                    this._mapGrid.TickLength = double.Parse(this.nudMajorTickSize.Value.ToString());
                }
            }
        }

        private void nudSubSize_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this._mapGrid.SubTickLength < 0.0)
                {
                    this._mapGrid.SubTickLength = -double.Parse(this.nudSubSize.Value.ToString());
                }
                else
                {
                    this._mapGrid.SubTickLength = double.Parse(this.nudSubSize.Value.ToString());
                }
            }
        }

        private void nudSubTickCount_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._mapGrid.SubTickCount = short.Parse(this.nudSubTickCount.Value.ToString());
                ISymbol subTickLineSymbol = this._mapGrid.SubTickLineSymbol as ISymbol;
                if (this._mapGrid.SubTickCount > 0)
                {
                    Bitmap bitmap = BitmapManager.GetSymbolBitMap(subTickLineSymbol, this.btSubSymbol.Width - 4, this.btSubSymbol.Height - 2);
                    this.btSubSymbol.Image = bitmap;
                    this.nudSubTickCount.Value = decimal.Parse(this._mapGrid.SubTickCount.ToString());
                    if (this._mapGrid.SubTickLength < 0.0)
                    {
                        this.rgSubPos.SelectedIndex = 0;
                    }
                    else
                    {
                        this.rgSubPos.SelectedIndex = 1;
                    }
                    this.nudSubSize.Value = decimal.Parse(this._mapGrid.SubTickLength.ToString());
                    this.cbSubBottom.Enabled = true;
                    this.cbSubLeft.Enabled = true;
                    this.cbSubRight.Enabled = true;
                    this.cbSubTop.Enabled = true;
                    this.btSubSymbol.Enabled = true;
                    this.rgSubPos.Enabled = true;
                    this.nudSubSize.Enabled = true;
                }
                else
                {
                    this.cbSubBottom.Enabled = false;
                    this.cbSubLeft.Enabled = false;
                    this.cbSubRight.Enabled = false;
                    this.cbSubTop.Enabled = false;
                    this.btSubSymbol.Enabled = false;
                    this.rgSubPos.Enabled = false;
                    this.nudSubSize.Enabled = false;
                }
            }
        }

        private Bitmap PaintButton(IColor pColorA, IColor pColorB, int pWidthA, int pHeightA, int pWidthB, int pHeightB)
        {
            Color color = ColorService.EsriColorToNetColor(pColorA);
            Color color2 = ColorService.EsriColorToNetColor(pColorB);
            Bitmap image = new Bitmap(pWidthA + pWidthB, pHeightA + pHeightB);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawRectangle(new Pen(color), 0, 0, pWidthA, pHeightA);
            graphics.FillRectangle(new SolidBrush(color), 0, 0, pWidthA, pHeightA);
            graphics.DrawRectangle(new Pen(color2), pWidthA, 0, pWidthB, pHeightB);
            graphics.FillRectangle(new SolidBrush(color2), pWidthA, 0, pWidthB, pHeightB);
            return image;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                if (this.tickLineSymbol == null)
                {
                    this.tickLineSymbol = new SimpleLineSymbolClass();
                }
                object lineSymbol = this._mapGrid.LineSymbol;
                this.CopyObject(this.tickLineSymbol, ref lineSymbol);
                this._mapGrid.LineSymbol = lineSymbol as ILineSymbol;
                ISymbol pSymbol = this._mapGrid.LineSymbol as ISymbol;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(pSymbol, this.btLineSymbol.Width - 2, this.btLineSymbol.Height - 2);
                this.btLineSymbol.Image = bitmap;
                if (this._mapGrid.TickMarkSymbol != null)
                {
                    lineSymbol = this.tickMarkerSymbol;
                    this.CopyObject(this._mapGrid.TickMarkSymbol, ref lineSymbol);
                }
                this._mapGrid.TickMarkSymbol = null;
                this.btLineSymbol.Enabled = true;
                this.pictureBox1.Image = Resources.line;
            }
            else if (this.radioGroup1.SelectedIndex == 1)
            {
                if (this.tickMarkerSymbol == null)
                {
                    this.tickMarkerSymbol = new SimpleMarkerSymbolClass();
                }
                object tickMarkSymbol = this._mapGrid.TickMarkSymbol;
                this.CopyObject(this.tickMarkerSymbol, ref tickMarkSymbol);
                this._mapGrid.TickMarkSymbol = tickMarkSymbol as IMarkerSymbol;
                ISymbol symbol2 = this._mapGrid.TickMarkSymbol as ISymbol;
                Bitmap bitmap2 = BitmapManager.GetSymbolBitMap(symbol2, this.btLineSymbol.Width - 2, this.btLineSymbol.Height - 2);
                this.btLineSymbol.Image = bitmap2;
                if (this._mapGrid.LineSymbol != null)
                {
                    tickMarkSymbol = this.tickLineSymbol;
                    this.CopyObject(this._mapGrid.LineSymbol, ref tickMarkSymbol);
                }
                this._mapGrid.LineSymbol = null;
                this.btLineSymbol.Enabled = true;
                this.pictureBox1.Image = Resources.trik;
            }
            else
            {
                object tickLineSymbol = this.tickLineSymbol;
                if (this._mapGrid.LineSymbol != null)
                {
                    this.CopyObject(this._mapGrid.LineSymbol, ref tickLineSymbol);
                }
                this.tickLineSymbol = tickLineSymbol as ILineSymbol;
                tickLineSymbol = this.tickMarkerSymbol;
                if (this._mapGrid.TickMarkSymbol != null)
                {
                    this.CopyObject(this._mapGrid.TickMarkSymbol, ref tickLineSymbol);
                }
                this.tickMarkerSymbol = tickLineSymbol as IMarkerSymbol;
                this._mapGrid.TickMarkSymbol = null;
                this._mapGrid.LineSymbol = null;
                this.btLineSymbol.Image = null;
                this.btLineSymbol.Enabled = false;
                this.pictureBox1.Image = Resources.none;
            }
        }

        private void rgMajorPos_Changed(object sender, EventArgs e)
        {
            if (this.rgMajorPos.SelectedIndex == 0)
            {
                this._mapGrid.TickLength = -this._mapGrid.TickLength;
            }
            else
            {
                this._mapGrid.TickLength = -this._mapGrid.TickLength;
            }
        }

        private void rgSubPos_Changed(object sender, EventArgs e)
        {
            if (this.rgSubPos.SelectedIndex == 0)
            {
                this._mapGrid.SubTickLength = -this._mapGrid.SubTickLength;
            }
            else
            {
                this._mapGrid.SubTickLength = -this._mapGrid.SubTickLength;
            }
        }

        private void sbGridBorder_Click(object sender, EventArgs e)
        {
            if (this.cbeBorderType.SelectedIndex == 0)
            {
                ISimpleMapGridBorder pFramePro = this._mapGrid.Border as ISimpleMapGridBorder;
                FrameSymbolSelector selector = new FrameSymbolSelector();
                IStyleGalleryItem item = selector.GetItem(pFramePro, esriSymbologyStyleClass.esriStyleClassBorders);
                if (selector.DialogResult != DialogResult.OK)
                {
                    return;
                }
                if (item == null)
                {
                    return;
                }
                pFramePro.LineSymbol = item.Item as ILineSymbol;
            }
            else
            {
                CalibratedBorder border2 = new CalibratedBorder(this._mapGrid.Border as ICalibratedMapGridBorder);
                if (border2.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this._mapGrid.Border = border2.GridBorder as IMapGridBorder;
                border2.Dispose();
            }
            IObjectCopy copy = new ObjectCopyClass();
            object pInObject = copy.Copy(this._mapGrid.Border);
            object gridBorder = this.gridBorder;
            copy.Overwrite(pInObject, ref gridBorder);
        }

        private void tbOffset_Leave(object sender, EventArgs e)
        {
            this._mapGrid.LabelFormat.LabelOffset = double.Parse(this.tbOffset.Text);
        }

        private void tbYIn_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.tbYIn.Text.Trim(), @"^\d+(\.\d*)?$"))
            {
                XtraMessageBox.Show("请输入数字");
            }
            else
            {
                IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
                grid.YIntervalSize = double.Parse(this.tbYIn.Text);
            }
        }

        private void ttbXIn_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.tbXIn.Text.Trim(), @"^\d+(\.\d*)?$"))
            {
                XtraMessageBox.Show("请输入数字");
            }
            else
            {
                IMeasuredGrid grid = this._mapGrid as IMeasuredGrid;
                grid.XIntervalSize = double.Parse(this.tbXIn.Text);
            }
        }

        public IMapGrid OrigMapGrid
        {
            set
            {
                this._origMapGrid = value;
                CloneService.Clone(this._origMapGrid, this._mapGrid);
                this.CopyTick();
            }
        }
    }
}

