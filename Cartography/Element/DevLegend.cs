namespace Cartography.Element
{
    using Cartography;
    using Cartography.Base;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    /// <summary>
    /// 图例的制作窗体
    /// </summary>
    public class DevLegend : FormBase3
    {
        private IPageLayoutControl _control;
        /// <summary>
        /// ILegend接口提供对控制图例的成员的访问。图例用于显示图例的地图环绕。
        /// </summary>
        private ILegend _legend;
        /// <summary>
        /// IMapSurroundFrame界面提供对控制地图环绕元素界面的成员的访问。IMapSurroundFrame是MapSurroundFrame对象的默认界面。使用此界面获取或更新存储在框架内的环绕对象（北箭头，比例尺或图例），或者要获取或更新与环绕相关联的MapFrame时。
        /// </summary>
        private IMapSurroundFrame _mapSurroundFrame;
        /// <summary>
        /// IMapSurroundFrame界面提供对控制地图环绕元素界面的成员的访问。IMapSurroundFrame是MapSurroundFrame对象的默认界面。使用此界面获取或更新存储在框架内的环绕对象（北箭头，比例尺或图例），或者要获取或更新与环绕相关联的MapFrame时。
        /// </summary>
        private IMapSurroundFrame _preMapSurroundFrame;
        private ISymbolBackground background;
        /// <summary>
        /// ISymbolBorder接口提供对控制SymbolBorder对象的成员的访问。SymbolBorder使用符号绘制的边框。提供ISymbolBorder接口来设置框架装饰使用的符号来绘制框架元素周围的边框。
        /// </summary>
        private ISymbolBorder border;
        private SimpleButton btAddAll;
        private SimpleButton btAddOne;
        private SimpleButton btBack;
        private SimpleButton btBorder;
        private SimpleButton btBottom;
        private SimpleButton btCancel;
        private SimpleButton btDown;
        private SimpleButton btItemStyle;
        private SimpleButton btItemTxtSymbol;
        private SimpleButton btMinusAll;
        private SimpleButton btMinusOne;
        private SimpleButton btOk;
        private SimpleButton btShadow;
        private SimpleButton btSymbol;
        private SimpleButton btTop;
        private SimpleButton btUp;
        private CheckEdit cbAdd;
        private CheckEdit cbChoice;
        private CheckEdit cbItemOrder;
        private ComboBoxEdit cbItemText;
        private ImageComboBoxEdit cbPatchArea;
        private ImageComboBoxEdit cbPatchLine;
        private ComboBoxEdit cbPos;
        private CheckEdit cbShow;
        private CheckEdit ceNewColumn;
        private IContainer components;
        private GroupBox gbBack;
        private GroupBox gbBorder;
        private GroupBox gbDropShadow;
        private GroupBox gbItems;
        private GroupBox gbLayer;
        private GroupBox gbMapCon;
        private GroupBox gbPatch;
        private GroupBox gbSpace;
        private GroupBox gbText;
        private GroupBox gbTitle;
        private bool init;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl6;
        private LabelControl lbArea;
        private LabelControl lbBackGap;
        private LabelControl lbBackRounding;
        private LabelControl lbBackSymbol;
        private LabelControl lbBackX;
        private Label lbBackXPts;
        private LabelControl lbBackY;
        private LabelControl lbBackYPts;
        private LabelControl lbBorderGap;
        private LabelControl lbBorderRounding;
        private LabelControl lbBorderSymbol;
        private LabelControl lbBorderX;
        private Label lbBorderXPts;
        private LabelControl lbBorderY;
        private LabelControl lbBorderYPts;
        private LabelControl lbColumn;
        private LabelControl lbColumns;
        private LabelControl lbContent;
        private LabelControl lbGroup;
        private LabelControl lbHeading;
        private LabelControl lbItemHeight;
        private LabelControl lbItemWidth;
        private LabelControl lbLabelDes;
        private LabelControl lbLine;
        private LabelControl lbPatchLabel;
        private LabelControl lbPatchVer;
        private LabelControl lbPosition;
        private LabelControl lbShadowGap;
        private LabelControl lbShadowRounding;
        private LabelControl lbShadowSymbol;
        private LabelControl lbShadowX;
        private LabelControl lbShadowXPts;
        private LabelControl lbShadowY;
        private LabelControl lbShadowYPts;
        private LabelControl lbTitleItems;
        private List<ILegendItem> legendItems = new List<ILegendItem>();
        private ListBoxControl lvItems;
        private const string mClassName = "Cartography.Element.DevLegend";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nudBackRounding;
        private SpinEdit nudBackX;
        private SpinEdit nudBackY;
        private SpinEdit nudBorderRounding;
        private SpinEdit nudBorderX;
        private SpinEdit nudBorderY;
        private SpinEdit nudColumns;
        private SpinEdit nudShadowRounding;
        private SpinEdit nudShadowX;
        private SpinEdit nudShadowY;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureEdit pbBack;
        private PictureEdit pbBorder;
        private PictureEdit pbShadow;
        private List<int> pos = new List<int>();
        private RadioGroup rgLegendItem;
        private SimpleButton sBtnApply;
        private ISymbolShadow shadow;
        private SpinEdit spColumns;
        private SpinEdit spGroup;
        private SpinEdit spHeading;
        private SpinEdit spLabelDes;
        private SpinEdit spPatchLabel;
        private SpinEdit spPatchVer;
        private SpinEdit spTitleItems;
        private TextBox teTitle;
        private TreeList tlLayer;
        private TreeListColumn tlsLayer;
        private TextEdit txtItemHeigt;
        private TextEdit txtItemWidth;
        private XtraTabPage xtpBox;
        private XtraTabPage xtpLegend;
        private XtraTabPage xtpLegendItem;
        private XtraTabControl xtraTabControl1;

        /// <summary>
        /// 图例的制作窗体:构造器。
        /// </summary>
        public DevLegend()
        {
            this.InitializeComponent();
            base.LookAndFeel.SkinName = "Blue";
        }

        private void AddLayer(TreeListNode pNode, LayerFun pLayHander)
        {
            string displayText = pNode.GetDisplayText(0);
            this.lvItems.Items.Add(displayText);
            ILayer pLy = pLayHander.FindLayer(this._control.ActiveView.FocusMap as IBasicMap, displayText, true);
            IStyleGalleryItem pItem = null;
            if (!(pLy is IFeatureLayer))
            {
            }
            ILegendItem item = LegendService.CreateLegendItem(pLy, 30.0, 15.0, pItem, this._control.ActiveView.ScreenDisplay);
            if (this._preMapSurroundFrame == null)
            {
                this.legendItems.Add(item);
            }
            else
            {
                this._legend.AddItem(item);
            }
        }

        private void btAddAll_Click(object sender, EventArgs e)
        {
            this.lvItems.Items.Clear();
            this._legend.ClearItems();
            this.legendItems.Clear();
            this.FillLayerName();
            LayerFun layerFun = GISFunFactory.LayerFun;
            foreach (string str in this.lvItems.Items)
            {
                try
                {
                    ILayer pLy = layerFun.FindLayer(this._control.ActiveView.FocusMap as IBasicMap, str, true);
                    IStyleGalleryItem pItem = null;
                    ILegendItem item = LegendService.CreateLegendItem(pLy, 30.0, 15.0, pItem, this._control.ActiveView.ScreenDisplay);
                    if (this._preMapSurroundFrame == null)
                    {
                        this.legendItems.Add(item);
                    }
                    else
                    {
                        this._legend.AddItem(item);
                    }
                }
                catch
                {
                }
            }
        }

        private void btAddOne_Click(object sender, EventArgs e)
        {
            TreeListMultiSelection selection = this.tlLayer.Selection;
            if (selection.Count == 0)
            {
                XtraMessageBox.Show("请选择图层");
            }
            else
            {
                LayerFun layerFun = GISFunFactory.LayerFun;
                for (int i = 0; i < selection.Count; i++)
                {
                    TreeListNode pNode = this.tlLayer.Selection[i];
                    if (pNode.HasChildren)
                    {
                        for (int j = 0; j < pNode.Nodes.Count; j++)
                        {
                            this.AddLayer(pNode.Nodes[j], layerFun);
                        }
                    }
                    else
                    {
                        this.AddLayer(pNode, layerFun);
                    }
                }
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.background == null)
                {
                    this.background = new SymbolBackgroundClass();
                    IFillSymbol fillSymbol = this.background.FillSymbol;
                    ILineSymbol symbol2 = new CartographicLineSymbolClass();
                    symbol2.Width = 0.0;
                    fillSymbol.Outline = symbol2;
                    IColor color = fillSymbol.Color;
                    color.NullColor = true;
                    fillSymbol.Color = color;
                    this.background.FillSymbol = fillSymbol;
                }
                FrameSymbolSelector selector = new FrameSymbolSelector();
                IStyleGalleryItem item = selector.GetItem(this.background, esriSymbologyStyleClass.esriStyleClassBackgrounds);
                if (selector.DialogResult == DialogResult.OK)
                {
                    selector.Dispose();
                    if (item != null)
                    {
                        if (item.Name != "无")
                        {
                            this.background.FillSymbol = ((ISymbolBackground) item.Item).FillSymbol;
                            Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                            bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                            this.pbBack.Image = bitmap;
                        }
                        else
                        {
                            this.pbBack.Image = null;
                            this.background = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "btBack_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btBorder_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.border == null)
                {
                    this.border = new SymbolBorderClass();
                    ILineSymbol lineSymbol = this.border.LineSymbol;
                    lineSymbol.Width = 0.0;
                    this.border.LineSymbol = lineSymbol;
                }
                FrameSymbolSelector selector = new FrameSymbolSelector();
                IStyleGalleryItem item = selector.GetItem(this.border, esriSymbologyStyleClass.esriStyleClassBorders);
                if ((selector.DialogResult == DialogResult.OK) && (item != null))
                {
                    if (item.Name != "无")
                    {
                        this.border.LineSymbol = ((ISymbolBorder) item.Item).LineSymbol;
                        Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                        this.pbBorder.Image = bitmap;
                    }
                    else
                    {
                        this.pbBorder.Image = null;
                        this.border = null;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "btBorder_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btBottom_Click(object sender, EventArgs e)
        {
            this.pos.Clear();
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < this.lvItems.SelectedIndices.Count; i++)
            {
                list.Add(this.lvItems.GetItemText(this.lvItems.SelectedIndices[i]));
                list2.Add(this.lvItems.SelectedIndices[i]);
                this.pos.Add(this.lvItems.SelectedIndices[i]);
            }
            for (int j = 0; j < list2.Count; j++)
            {
                this.lvItems.Items.RemoveAt(list2[j] - j);
            }
            this.lvItems.UnSelectAll();
            for (int k = 0; k < list.Count; k++)
            {
                this.lvItems.Items.Insert(this.lvItems.ItemCount, list[k]);
                this.lvItems.SetSelected(this.lvItems.ItemCount, true);
            }
            this.ChangeOrderBottom();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            this.pos.Clear();
            int itemCount = this.lvItems.ItemCount;
            for (int i = this.lvItems.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int item = this.lvItems.SelectedIndices[i];
                if ((item + 1) == itemCount)
                {
                    itemCount = item;
                }
                else
                {
                    itemCount = item + 1;
                    this.pos.Add(item);
                    string itemText = this.lvItems.GetItemText(itemCount);
                    this.lvItems.Items[itemCount] = this.lvItems.GetItemText(item);
                    this.lvItems.Items[item] = itemText;
                }
            }
            this.lvItems.UnSelectAll();
            foreach (int num4 in this.pos)
            {
                this.lvItems.SetSelected(num4 + 1, true);
                this.lvItems.SetSelected(num4, false);
            }
            this.ChangeOrderDown();
        }

        private void btItemStyle_Click(object sender, EventArgs e)
        {
            try
            {
                List<ILegendItem> list = new List<ILegendItem>();
                List<int> list2 = new List<int>();
                ILegendItem itemByIndex = null;
                if (this._preMapSurroundFrame != null)
                {
                    foreach (int num in (IEnumerable<int>) this.lvItems.SelectedIndices)
                    {
                        itemByIndex = LegendService.GetItemByIndex(num, this._legend);
                        list.Add(itemByIndex);
                        list2.Add(num);
                    }
                }
                else
                {
                    foreach (int num2 in (IEnumerable<int>) this.lvItems.SelectedIndices)
                    {
                        itemByIndex = LegendService.GetLegendItemByIndex(num2, this.legendItems);
                        list.Add(itemByIndex);
                        list2.Add(num2);
                    }
                }
                if (list.Count >= 1)
                {
                    DevLegendItemStyle style = new DevLegendItemStyle();
                    style.LegendItems = list;
                    style.LegendFormat = this._legend.Format;
                    style.ScreenDisplay = this._control.ActiveView.ScreenDisplay;
                    if (style.ShowDialog() != DialogResult.Cancel)
                    {
                        List<ILegendItem> legendItems = style.LegendItems;
                        style.Dispose();
                        int pIndex = -1;
                        if (this._preMapSurroundFrame != null)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                pIndex = list2[i];
                                LegendService.ReMoveItemByIndex(pIndex, this._legend);
                                this._legend.InsertItem(pIndex, legendItems[i]);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                pIndex = list2[j];
                                LegendService.RemoveLegendItemByIndex(pIndex, this.legendItems);
                                this.legendItems.Insert(pIndex, legendItems[j]);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "btItemStyle_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btItemTxtSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                ISymbol defaultTextSymbol = (ISymbol) this.GetDefaultTextSymbol();
                frmTextSymbol symbol3 = new frmTextSymbol();
                symbol3.SymbolSource = defaultTextSymbol;
                if (symbol3.ShowDialog() == DialogResult.OK)
                {
                    ISymbol symbolSelected = (ISymbol) symbol3.SymbolSelected;
                    ITextSymbol symbol5 = (ITextSymbol) symbolSelected;
                    symbol3 = null;
                    if (this.rgLegendItem.SelectedIndex == 0)
                    {
                        int count = 0;
                        if (this._preMapSurroundFrame != null)
                        {
                            count = this.lvItems.Items.Count;
                        }
                        else
                        {
                            count = this.legendItems.Count;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            ILegendItem itemByIndex = null;
                            if (this._preMapSurroundFrame != null)
                            {
                                itemByIndex = LegendService.GetItemByIndex(i, this._legend);
                            }
                            else
                            {
                                itemByIndex = LegendService.GetLegendItemByIndex(i, this.legendItems);
                            }
                            if (this.cbItemText.SelectedIndex == 0)
                            {
                                itemByIndex.HeadingSymbol = symbol5;
                                itemByIndex.LayerNameSymbol = symbol5;
                                itemByIndex.LegendClassFormat.LabelSymbol = symbol5;
                                itemByIndex.LegendClassFormat.DescriptionSymbol = symbol5;
                                

                            }
                            else if (this.cbItemText.SelectedIndex == 1)
                            {
                                itemByIndex.LayerNameSymbol = symbol5;
                            }
                            else if (this.cbItemText.SelectedIndex == 2)
                            {
                                itemByIndex.HeadingSymbol = symbol5;
                            }
                            else if (this.cbItemText.SelectedIndex == 3)
                            {
                                itemByIndex.LegendClassFormat.LabelSymbol = symbol5;
                            }
                            else
                            {
                                itemByIndex.LegendClassFormat.DescriptionSymbol = symbol5;
                            }
                        }
                    }
                    else
                    {
                        foreach (int num3 in (IEnumerable<int>) this.lvItems.SelectedIndices)
                        {
                            this.lvItems.Items[num3].ToString();
                            ILegendItem legendItemByIndex = null;
                            if (this._preMapSurroundFrame != null)
                            {
                                legendItemByIndex = LegendService.GetItemByIndex(num3, this._legend);
                            }
                            else
                            {
                                legendItemByIndex = LegendService.GetLegendItemByIndex(num3, this.legendItems);
                            }
                            if (this.cbItemText.SelectedIndex == 0)
                            {
                                legendItemByIndex.HeadingSymbol = symbol5;
                                legendItemByIndex.LayerNameSymbol = symbol5;
                                legendItemByIndex.LegendClassFormat.LabelSymbol = symbol5;
                                legendItemByIndex.LegendClassFormat.DescriptionSymbol = symbol5;
                            }
                            else if (this.cbItemText.SelectedIndex == 1)
                            {
                                legendItemByIndex.LayerNameSymbol = symbol5;
                            }
                            else if (this.cbPatchArea.SelectedIndex == 2)
                            {
                                legendItemByIndex.HeadingSymbol = symbol5;
                            }
                            else
                            {
                                legendItemByIndex.LegendClassFormat.DescriptionSymbol = symbol5;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "btItemTxtSymbol_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btMinusAll_Click(object sender, EventArgs e)
        {
            this.lvItems.Items.Clear();
            if (this._preMapSurroundFrame != null)
            {
                this._legend.ClearItems();
            }
            else
            {
                this.legendItems.Clear();
            }
        }

        private void btMinusOne_Click(object sender, EventArgs e)
        {
            if (this.lvItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请选择项");
            }
            int[] array = new int[this.lvItems.SelectedIndices.Count];
            this.lvItems.SelectedIndices.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                int pIndex = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int num4 = array[j];
                    array[j] = num4--;
                }
                if (this._preMapSurroundFrame == null)
                {
                    LegendService.RemoveLegendItemByIndex(pIndex, this.legendItems);
                }
                else
                {
                    LegendService.ReMoveItemByIndex(pIndex, this._legend);
                }
                this.lvItems.Items.RemoveAt(pIndex);
            }
        }

        /// <summary>
        /// 图例创建的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Preview();
            base.Close();
        }

        private void btShadow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.shadow == null)
                {
                    this.shadow = new SymbolShadowClass();
                    IFillSymbol fillSymbol = this.shadow.FillSymbol;
                    ILineSymbol symbol2 = new CartographicLineSymbolClass();
                    symbol2.Width = 0.0;
                    fillSymbol.Outline = symbol2;
                    IColor color = fillSymbol.Color;
                    color.NullColor = true;
                    fillSymbol.Color = color;
                    this.shadow.FillSymbol = fillSymbol;
                }
                FrameSymbolSelector selector = new FrameSymbolSelector();
                IStyleGalleryItem item = selector.GetItem(this.shadow, esriSymbologyStyleClass.esriStyleClassShadows);
                if (selector.DialogResult == DialogResult.OK)
                {
                    selector.Dispose();
                    if (item != null)
                    {
                        if (item.Name != "无")
                        {
                            this.shadow.FillSymbol = ((ISymbolShadow) item.Item).FillSymbol;
                            Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                            bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                            this.pbShadow.Image = bitmap;
                        }
                        else
                        {
                            this.pbShadow.Image = null;
                            this.shadow = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "btShadow_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btSymbol_Click(object sender, EventArgs e)
        {
            ITextSymbol titleSymbol = this._legend.Format.TitleSymbol;
            titleSymbol.Text = this._legend.Title;
            ISymbol symbol2 = (ISymbol) titleSymbol;
            frmTextSymbol symbol3 = new frmTextSymbol();
            symbol3.SymbolSource = symbol2;
            if (symbol3.ShowDialog() == DialogResult.OK)
            {
                ISymbol symbolSelected = (ISymbol) symbol3.SymbolSelected;
                this._legend.Format.TitleSymbol = (ITextSymbol) symbolSelected;
                symbol3 = null;
            }
        }

        private void btTop_Click(object sender, EventArgs e)
        {
            this.pos.Clear();
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < this.lvItems.SelectedIndices.Count; i++)
            {
                list.Add(this.lvItems.GetItemText(this.lvItems.SelectedIndices[i]));
                list2.Add(this.lvItems.SelectedIndices[i]);
                this.pos.Add(this.lvItems.SelectedIndices[i]);
            }
            for (int j = 0; j < list2.Count; j++)
            {
                this.lvItems.Items.RemoveAt(list2[j] - j);
            }
            this.lvItems.UnSelectAll();
            for (int k = 0; k < list.Count; k++)
            {
                this.lvItems.Items.Insert(k, list[k]);
                this.lvItems.SetSelected(k, true);
            }
            this.ChangeOrderTop();
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            this.pos.Clear();
            int index = -1;
            for (int i = 0; i < this.lvItems.SelectedIndices.Count; i++)
            {
                int item = this.lvItems.SelectedIndices[i];
                if ((item - 1) == index)
                {
                    index = item;
                }
                else
                {
                    index = item - 1;
                    this.pos.Add(item);
                    string itemText = this.lvItems.GetItemText(index);
                    this.lvItems.Items[index] = this.lvItems.GetItemText(item);
                    this.lvItems.Items[item] = itemText;
                }
            }
            foreach (int num4 in this.pos)
            {
                this.lvItems.SetSelected(num4 - 1, true);
                this.lvItems.SetSelected(num4, false);
            }
            this.ChangeOrderUp();
        }

        private void cbAdd_CheckedChanged(object sender, EventArgs e)
        {
            this._legend.AutoAdd = this.cbAdd.Checked;
        }

        private void cbChoice_CheckedChanged(object sender, EventArgs e)
        {
            this._legend.AutoVisibility = this.cbChoice.Checked;
        }

        private void cbItemOrder_CheckedChanged(object sender, EventArgs e)
        {
            this._legend.AutoReorder = this.cbItemOrder.Checked;
        }

        private void cbPatchArea_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbPatchLine_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                ILegendFormat format = this._legend.Format;
                switch (this.cbPos.SelectedIndex)
                {
                    case 0:
                        format.TitlePosition = esriRectanglePosition.esriTopSide;
                        break;

                    case 1:
                        format.TitlePosition = esriRectanglePosition.esriBottomSide;
                        break;

                    case 2:
                        format.TitlePosition = esriRectanglePosition.esriLeftSide;
                        break;

                    case 3:
                        format.TitlePosition = esriRectanglePosition.esriRightSide;
                        break;
                }
                this._legend.Format = format;
            }
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            this._legend.Format.ShowTitle = this.cbShow.Checked;
        }

        private void ceNewColumn_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChangeOrderBottom()
        {
            if ((this._preMapSurroundFrame == null) && ((this._preMapSurroundFrame != null) || (this._mapSurroundFrame == null)))
            {
                LegendService.ChangeLegendItemOrderBottom(this.legendItems, this.pos);
            }
            else
            {
                LegendService.ChangeLegendItemOrderBottom(this._legend, this.pos);
            }
        }

        private void ChangeOrderDown()
        {
            if ((this._preMapSurroundFrame == null) && ((this._preMapSurroundFrame != null) || (this._mapSurroundFrame == null)))
            {
                LegendService.ChangeLegendItemOrderDown(this.legendItems, this.pos);
            }
            else
            {
                LegendService.ChangeLegendItemOrderDown(this._legend, this.pos);
            }
        }

        private void ChangeOrderTop()
        {
            if ((this._preMapSurroundFrame == null) && ((this._preMapSurroundFrame != null) || (this._mapSurroundFrame == null)))
            {
                LegendService.ChangeLegendItemOrderTop(this.legendItems, this.pos);
            }
            else
            {
                LegendService.ChangeLegendItemOrderTop(this._legend, this.pos);
            }
        }

        private void ChangeOrderUp()
        {
            if ((this._preMapSurroundFrame == null) && ((this._preMapSurroundFrame != null) || (this._mapSurroundFrame == null)))
            {
                LegendService.ChangeLegendItemOrderUp(this.legendItems, this.pos);
            }
            else
            {
                LegendService.ChangeLegendItemOrderUp(this._legend, this.pos);
            }
        }

        private bool CheckIsAdd(string pTxt)
        {
            foreach (string str in this.lvItems.Items)
            {
                if (str == pTxt)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillAllLayer()
        {
            if (this._preMapSurroundFrame == null)
            {
                double mapScale = this._control.ActiveView.FocusMap.MapScale;
                for (int i = 0; i < this._control.ActiveView.FocusMap.LayerCount; i++)
                {
                    ILayer pLy = this._control.ActiveView.FocusMap.get_Layer(i);
                    if ((pLy is IGroupLayer) && pLy.Visible)
                    {
                        if (((pLy.MaximumScale == 0.0) || (pLy.MaximumScale <= mapScale)) && ((pLy.MinimumScale == 0.0) || (pLy.MinimumScale >= mapScale)))
                        {
                            this.FillAllSubLayer((IGroupLayer) pLy);
                        }
                    }
                    else
                    {
                        if ((pLy.Visible && ((pLy.MaximumScale == 0.0) || (pLy.MaximumScale <= mapScale))) && ((pLy.MinimumScale == 0.0) || (pLy.MinimumScale >= mapScale)))
                        {
                            this.lvItems.Items.Add(pLy.Name);
                            IStyleGalleryItem pItem = null;
                            if (pLy is IFeatureLayer)
                            {
                                IFeatureLayer layer2 = pLy as IFeatureLayer;
                                if ((layer2 == null) || (layer2.FeatureClass == null))
                                {
                                    goto Label_016A;
                                }
                            }
                            if (pLy is IRasterLayer)
                            {
                                IRasterLayer layer3 = pLy as IRasterLayer;
                                if ((layer3 == null) || (layer3.Raster == null))
                                {
                                    goto Label_016A;
                                }
                            }
                            ILegendItem item = LegendService.CreateLegendItem(pLy, 30.0, 15.0, pItem, this._control.ActiveView.ScreenDisplay);
                            this.legendItems.Add(item);
                        }
                    Label_016A:;
                    }
                }
            }
            else
            {
                for (int j = 0; j < this._legend.ItemCount; j++)
                {
                    ILegendItem item3 = this._legend.get_Item(j);
                    this.lvItems.Items.Add(item3.Layer.Name);
                }
            }
        }

        private void FillAllSubLayer(IGroupLayer pGply)
        {
            double mapScale = this._control.ActiveView.FocusMap.MapScale;
            ICompositeLayer layer = (ICompositeLayer) pGply;
            for (int i = 0; i < layer.Count; i++)
            {
                ILayer pLy = layer.get_Layer(i);
                if ((pLy is IGroupLayer) && pLy.Visible)
                {
                    if (((pLy.MaximumScale == 0.0) || (pLy.MaximumScale <= mapScale)) && ((pLy.MinimumScale == 0.0) || (pLy.MinimumScale >= mapScale)))
                    {
                        this.FillAllSubLayer((IGroupLayer) pLy);
                    }
                }
                else if ((pLy.Visible && ((pLy.MaximumScale == 0.0) || (pLy.MaximumScale <= mapScale))) && ((pLy.MinimumScale == 0.0) || (pLy.MinimumScale >= mapScale)))
                {
                    this.lvItems.Items.Add(pLy.Name);
                    IStyleGalleryItem pItem = null;
                    IFeatureLayer layer3 = pLy as IFeatureLayer;
                    if ((layer3 == null) || (layer3.FeatureClass != null))
                    {
                        ILegendItem item = LegendService.CreateLegendItem(pLy, 30.0, 15.0, pItem, this._control.ActiveView.ScreenDisplay);
                        this.legendItems.Add(item);
                    }
                }
            }
        }

        private void FillItem()
        {
            for (int i = 0; i < this._legend.ItemCount; i++)
            {
                ILegendItem3 item = (ILegendItem3) this._legend.get_Item(i);
                this.lvItems.Items.Add(item.Layer.Name);
            }
            this.lvItems.SelectedIndex = 0;
        }

        private void FillLayer()
        {
            for (int i = 0; i < this._control.ActiveView.FocusMap.LayerCount; i++)
            {
                ILayer layer = this._control.ActiveView.FocusMap.get_Layer(i);
                if (layer is IGroupLayer)
                {
                    TreeListNode pNode = this.tlLayer.AppendNode(new object[] { layer.Name }, (TreeListNode) null);
                    if (!this.FillSubLayer((IGroupLayer) layer, pNode, this.tlLayer))
                    {
                        this.tlLayer.Nodes.Remove(pNode);
                    }
                }
                else
                {
                    if ((layer is IFeatureLayer) && (((IFeatureLayer) layer).FeatureClass != null))
                    {
                        this.tlLayer.AppendNode(new object[] { layer.Name }, (TreeListNode) null);
                    }
                    if ((layer is IRasterLayer) && (((IRasterLayer) layer).Raster != null))
                    {
                        this.tlLayer.AppendNode(new object[] { layer.Name }, (TreeListNode) null);
                    }
                }
            }
        }

        private void FillLayerName()
        {
            foreach (TreeListNode node in this.tlLayer.Nodes)
            {
                this.FillSubLayerName(node);
            }
        }

        private bool FillSubLayer(IGroupLayer pGply, TreeListNode pNode, TreeList plist)
        {
            ICompositeLayer layer = (ICompositeLayer) pGply;
            for (int i = 0; i < layer.Count; i++)
            {
                ILayer layer2 = layer.get_Layer(i);
                if (layer2 is IGroupLayer)
                {
                    TreeListNode node = plist.AppendNode(new object[] { layer2.Name }, pNode);
                    if (!this.FillSubLayer((IGroupLayer) layer2, node, this.tlLayer))
                    {
                        plist.Nodes.Remove(node);
                    }
                }
                else
                {
                    if ((layer2 is IFeatureLayer) && (((IFeatureLayer) layer2).FeatureClass != null))
                    {
                        plist.AppendNode(new object[] { layer2.Name }, pNode);
                    }
                    if ((layer2 is IRasterLayer) && (((IRasterLayer) layer2).Raster != null))
                    {
                        plist.AppendNode(new object[] { layer2.Name }, pNode);
                    }
                }
            }
            if (pNode.Nodes.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void FillSubLayerName(TreeListNode pNode)
        {
            for (int i = 0; i < pNode.Nodes.Count; i++)
            {
                if (pNode.Nodes[i].Nodes.Count != 0)
                {
                    this.FillSubLayerName(pNode.Nodes[i]);
                }
                else
                {
                    this.lvItems.Items.Add(pNode.Nodes[i].GetDisplayText(0));
                }
            }
        }

        private void FillSymbol(string pStyleClassName, ImageComboBoxEdit pCombobox)
        {
            IStyleGallery o = new ServerStyleGalleryClass();
            IStyleGalleryStorage storage = (IStyleGalleryStorage) o;
            string path = "";
            try
            {
                path = ElementService.StyleGalleryFile;
            }
            catch (FileNotFoundException exception)
            {
                XtraMessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK);
                return;
            }
            storage.AddFile(path);
            IStyleGalleryClass class2 = null;
            for (int i = 0; i < o.ClassCount; i++)
            {
                IStyleGalleryClass class3 = o.get_Class(i);
                if (class3.Name == pStyleClassName)
                {
                    class2 = class3;
                    break;
                }
            }
            IEnumStyleGalleryItem item = o.get_Items(pStyleClassName, path, "Default");
            item.Reset();
            IStyleGalleryItem item2 = null;
            ImageList list = new ImageList();
            int imageIndex = 0;
            while ((item2 = item.Next()) != null)
            {
                Bitmap image = new Bitmap(40, 40);
                Graphics graphics = Graphics.FromImage(image);
                tagRECT rectangle = new tagRECT();
                rectangle.right = image.Width;
                rectangle.bottom = image.Height;
                IntPtr hdc = graphics.GetHdc();
                class2.Preview(item2.Item, hdc.ToInt32(), ref rectangle);
                graphics.ReleaseHdc(hdc);
                list.Images.Add(image);
                pCombobox.Properties.Items.Add(new ImageComboBoxItem(item2.Name, item2, imageIndex));
                imageIndex++;
                graphics.Dispose();
            }
            pCombobox.Properties.SmallImages = list;
            Marshal.ReleaseComObject(item);
            int num3 = 0;
            while (true)
            {
                if (o != null)
                {
                    num3 = Marshal.ReleaseComObject(o);
                }
                if (num3 <= 0)
                {
                    return;
                }
            }
        }

        private ITextSymbol GetDefaultTextSymbol()
        {
            ITextSymbol symbol = new TextSymbolClass();
            IRgbColor color = new RgbColorClass();
            color.Red = 0;
            color.Blue = 0;
            color.Green = 0;
            symbol.Color = color;
            stdole.IFontDisp disp = new StdFontClass() as stdole.IFontDisp;
            disp.Size = 14M;
            disp.Name = "宋体";
            disp.Bold = true;
            disp.Italic = false;
            disp.Underline = false;
            disp.Strikethrough = false;
            symbol.Font = disp;
            return symbol;
        }

        private void InitialControl()
        {
            this.init = true;
            this.teTitle.Text = this._legend.Title;
            this.cbShow.Checked = this._legend.Format.ShowTitle;
            if (this._legend.Format.ShowTitle)
            {
                this.btSymbol.Enabled = true;
            }
            this.spTitleItems.Value = Convert.ToDecimal(this._legend.Format.TitleGap);
            this.spGroup.Value = Convert.ToDecimal(this._legend.Format.VerticalItemGap);
            this.spColumns.Value = Convert.ToDecimal(this._legend.Format.HorizontalItemGap);
            this.spHeading.Value = Convert.ToDecimal(this._legend.Format.HeadingGap);
            this.spLabelDes.Value = Convert.ToDecimal(this._legend.Format.TextGap);
            this.spPatchLabel.Value = Convert.ToDecimal(this._legend.Format.HorizontalPatchGap);
            this.spPatchVer.Value = Convert.ToDecimal(this._legend.Format.VerticalPatchGap);
            this.FillLayer();
            this.FillItem();
            this.cbChoice.Checked = this._legend.AutoVisibility;
            this.cbAdd.Checked = this._legend.AutoAdd;
            this.cbItemOrder.Checked = this._legend.AutoReorder;
            this.cbItemText.Text = this.cbItemText.Properties.Items[0].ToString();
            this.nudColumns.Properties.MaxValue = this._control.ActiveView.FocusMap.LayerCount;
            IFrameProperties properties = (IFrameProperties) this._preMapSurroundFrame;
            IFrameDecoration decoration = null;
            Bitmap bitmap = null;
            if (properties != null)
            {
                if (properties.Border != null)
                {
                    this.border = new SymbolBorderClass();
                    CloneService.Clone(properties.Border, this.border);
                    ISymbolBorder pItem = (ISymbolBorder) properties.Border;
                    decoration = (IFrameDecoration) pItem;
                    this.nudBorderRounding.Value = decimal.Parse(pItem.CornerRounding.ToString());
                    this.nudBorderX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudBorderY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                    bitmap = BitmapManager.GetSymbolBitMap(pItem, this.pbBorder.Width, this.pbBorder.Height);
                    bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                    this.pbBorder.Image = bitmap;
                }
                if (properties.Background != null)
                {
                    this.background = new SymbolBackgroundClass();
                    CloneService.Clone(properties.Background, this.background);
                    ISymbolBackground background = (ISymbolBackground) properties.Background;
                    decoration = (IFrameDecoration) background;
                    this.nudBackRounding.Value = decimal.Parse(background.CornerRounding.ToString());
                    this.nudBackX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudBackY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                    bitmap = BitmapManager.GetSymbolBitMap(background, this.pbBack.Width, this.pbBack.Height);
                    bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                    this.pbBack.Image = bitmap;
                }
                if (properties.Shadow != null)
                {
                    this.shadow = new SymbolShadowClass();
                    CloneService.Clone(properties.Shadow, this.shadow);
                    ISymbolShadow shadow = (ISymbolShadow) properties.Shadow;
                    decoration = (IFrameDecoration) shadow;
                    this.nudShadowRounding.Value = decimal.Parse(shadow.CornerRounding.ToString());
                    this.nudShadowX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudShadowY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                    bitmap = BitmapManager.GetSymbolBitMap(shadow, this.pbShadow.Width, this.pbShadow.Height);
                    bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                    this.pbShadow.Image = bitmap;
                }
            }
            this.init = false;
        }

        private void InitialDefault()
        {
            this.init = true;
            this.teTitle.Text = "请输入图例标题";
            this._legend.Title = this.teTitle.Text;
            ITextSymbol titleSymbol = this._legend.Format.TitleSymbol;
            titleSymbol.Text = this.teTitle.Text;
            this._legend.Format.TitleSymbol = titleSymbol;
            this.cbShow.Checked = true;
            this.cbPos.SelectedIndex = 0;
            this.spTitleItems.Value = Convert.ToDecimal(this._legend.Format.TitleGap);
            this.spGroup.Value = Convert.ToDecimal(this._legend.Format.VerticalItemGap);
            this.spColumns.Value = Convert.ToDecimal(this._legend.Format.HorizontalItemGap);
            this.spHeading.Value = Convert.ToDecimal(this._legend.Format.HeadingGap);
            this.spLabelDes.Value = Convert.ToDecimal(this._legend.Format.TextGap);
            this.spPatchLabel.Value = Convert.ToDecimal(this._legend.Format.HorizontalPatchGap);
            this.spPatchVer.Value = Convert.ToDecimal(this._legend.Format.VerticalPatchGap);
            this.tlLayer.BeginUnboundLoad();
            this.FillLayer();
            this.tlLayer.EndUnboundLoad();
            this.FillAllLayer();
            this.cbItemText.Text = this.cbItemText.Properties.Items[0].ToString();
            this.nudColumns.Properties.MaxValue = this._control.ActiveView.FocusMap.LayerCount;
            this.init = false;
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpLegend = new DevExpress.XtraTab.XtraTabPage();
            this.gbSpace = new System.Windows.Forms.GroupBox();
            this.spPatchLabel = new DevExpress.XtraEditors.SpinEdit();
            this.spPatchVer = new DevExpress.XtraEditors.SpinEdit();
            this.spLabelDes = new DevExpress.XtraEditors.SpinEdit();
            this.spHeading = new DevExpress.XtraEditors.SpinEdit();
            this.spColumns = new DevExpress.XtraEditors.SpinEdit();
            this.spGroup = new DevExpress.XtraEditors.SpinEdit();
            this.spTitleItems = new DevExpress.XtraEditors.SpinEdit();
            this.lbPatchLabel = new DevExpress.XtraEditors.LabelControl();
            this.lbPatchVer = new DevExpress.XtraEditors.LabelControl();
            this.lbLabelDes = new DevExpress.XtraEditors.LabelControl();
            this.lbHeading = new DevExpress.XtraEditors.LabelControl();
            this.lbColumns = new DevExpress.XtraEditors.LabelControl();
            this.lbGroup = new DevExpress.XtraEditors.LabelControl();
            this.lbTitleItems = new DevExpress.XtraEditors.LabelControl();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.teTitle = new System.Windows.Forms.TextBox();
            this.btSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.cbPos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbPosition = new DevExpress.XtraEditors.LabelControl();
            this.cbShow = new DevExpress.XtraEditors.CheckEdit();
            this.xtpLegendItem = new DevExpress.XtraTab.XtraTabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudColumns = new DevExpress.XtraEditors.SpinEdit();
            this.btUp = new DevExpress.XtraEditors.SimpleButton();
            this.lbColumn = new DevExpress.XtraEditors.LabelControl();
            this.btTop = new DevExpress.XtraEditors.SimpleButton();
            this.ceNewColumn = new DevExpress.XtraEditors.CheckEdit();
            this.btDown = new DevExpress.XtraEditors.SimpleButton();
            this.btItemStyle = new DevExpress.XtraEditors.SimpleButton();
            this.btBottom = new DevExpress.XtraEditors.SimpleButton();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.lvItems = new DevExpress.XtraEditors.ListBoxControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAddOne = new DevExpress.XtraEditors.SimpleButton();
            this.btAddAll = new DevExpress.XtraEditors.SimpleButton();
            this.btMinusOne = new DevExpress.XtraEditors.SimpleButton();
            this.btMinusAll = new DevExpress.XtraEditors.SimpleButton();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.tlLayer = new DevExpress.XtraTreeList.TreeList();
            this.tlsLayer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gbText = new System.Windows.Forms.GroupBox();
            this.btItemTxtSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.cbItemText = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbContent = new DevExpress.XtraEditors.LabelControl();
            this.gbPatch = new System.Windows.Forms.GroupBox();
            this.cbPatchArea = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbPatchLine = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtItemHeigt = new DevExpress.XtraEditors.TextEdit();
            this.txtItemWidth = new DevExpress.XtraEditors.TextEdit();
            this.lbArea = new DevExpress.XtraEditors.LabelControl();
            this.lbLine = new DevExpress.XtraEditors.LabelControl();
            this.lbItemHeight = new DevExpress.XtraEditors.LabelControl();
            this.lbItemWidth = new DevExpress.XtraEditors.LabelControl();
            this.rgLegendItem = new DevExpress.XtraEditors.RadioGroup();
            this.gbMapCon = new System.Windows.Forms.GroupBox();
            this.cbItemOrder = new DevExpress.XtraEditors.CheckEdit();
            this.cbAdd = new DevExpress.XtraEditors.CheckEdit();
            this.cbChoice = new DevExpress.XtraEditors.CheckEdit();
            this.xtpBox = new DevExpress.XtraTab.XtraTabPage();
            this.pbShadow = new DevExpress.XtraEditors.PictureEdit();
            this.pbBack = new DevExpress.XtraEditors.PictureEdit();
            this.pbBorder = new DevExpress.XtraEditors.PictureEdit();
            this.gbDropShadow = new System.Windows.Forms.GroupBox();
            this.lbShadowYPts = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowY = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowY = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowXPts = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowX = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowX = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowRounding = new DevExpress.XtraEditors.LabelControl();
            this.btShadow = new DevExpress.XtraEditors.SimpleButton();
            this.lbShadowSymbol = new DevExpress.XtraEditors.LabelControl();
            this.gbBack = new System.Windows.Forms.GroupBox();
            this.nudBackY = new DevExpress.XtraEditors.SpinEdit();
            this.nudBackX = new DevExpress.XtraEditors.SpinEdit();
            this.lbBackYPts = new DevExpress.XtraEditors.LabelControl();
            this.lbBackY = new DevExpress.XtraEditors.LabelControl();
            this.lbBackX = new DevExpress.XtraEditors.LabelControl();
            this.lbBackGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.nudBackRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbBackRounding = new DevExpress.XtraEditors.LabelControl();
            this.btBack = new DevExpress.XtraEditors.SimpleButton();
            this.lbBackSymbol = new DevExpress.XtraEditors.LabelControl();
            this.lbBackXPts = new System.Windows.Forms.Label();
            this.gbBorder = new System.Windows.Forms.GroupBox();
            this.nudBorderY = new DevExpress.XtraEditors.SpinEdit();
            this.nudBorderX = new DevExpress.XtraEditors.SpinEdit();
            this.lbBorderYPts = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderY = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderX = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nudBorderRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbBorderRounding = new DevExpress.XtraEditors.LabelControl();
            this.btBorder = new DevExpress.XtraEditors.SimpleButton();
            this.lbBorderSymbol = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderXPts = new System.Windows.Forms.Label();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnApply = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpLegend.SuspendLayout();
            this.gbSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPatchLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPatchVer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLabelDes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spColumns.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTitleItems.Properties)).BeginInit();
            this.gbTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShow.Properties)).BeginInit();
            this.xtpLegendItem.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewColumn.Properties)).BeginInit();
            this.gbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlLayer)).BeginInit();
            this.gbText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbItemText.Properties)).BeginInit();
            this.gbPatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatchArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatchLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemHeigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgLegendItem.Properties)).BeginInit();
            this.gbMapCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbItemOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice.Properties)).BeginInit();
            this.xtpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).BeginInit();
            this.gbDropShadow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowRounding.Properties)).BeginInit();
            this.gbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackRounding.Properties)).BeginInit();
            this.gbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderRounding.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpLegend;
            this.xtraTabControl1.Size = new System.Drawing.Size(567, 471);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpLegend,
            this.xtpLegendItem,
            this.xtpBox});
            // 
            // xtpLegend
            // 
            this.xtpLegend.Controls.Add(this.gbSpace);
            this.xtpLegend.Controls.Add(this.gbTitle);
            this.xtpLegend.Name = "xtpLegend";
            this.xtpLegend.Size = new System.Drawing.Size(561, 442);
            this.xtpLegend.Text = "图例";
            // 
            // gbSpace
            // 
            this.gbSpace.Controls.Add(this.spPatchLabel);
            this.gbSpace.Controls.Add(this.spPatchVer);
            this.gbSpace.Controls.Add(this.spLabelDes);
            this.gbSpace.Controls.Add(this.spHeading);
            this.gbSpace.Controls.Add(this.spColumns);
            this.gbSpace.Controls.Add(this.spGroup);
            this.gbSpace.Controls.Add(this.spTitleItems);
            this.gbSpace.Controls.Add(this.lbPatchLabel);
            this.gbSpace.Controls.Add(this.lbPatchVer);
            this.gbSpace.Controls.Add(this.lbLabelDes);
            this.gbSpace.Controls.Add(this.lbHeading);
            this.gbSpace.Controls.Add(this.lbColumns);
            this.gbSpace.Controls.Add(this.lbGroup);
            this.gbSpace.Controls.Add(this.lbTitleItems);
            this.gbSpace.Location = new System.Drawing.Point(59, 195);
            this.gbSpace.Name = "gbSpace";
            this.gbSpace.Size = new System.Drawing.Size(436, 234);
            this.gbSpace.TabIndex = 5;
            this.gbSpace.TabStop = false;
            this.gbSpace.Text = "间距(单位:像素)";
            // 
            // spPatchLabel
            // 
            this.spPatchLabel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spPatchLabel.Location = new System.Drawing.Point(244, 201);
            this.spPatchLabel.Name = "spPatchLabel";
            this.spPatchLabel.Properties.Appearance.Options.UseTextOptions = true;
            this.spPatchLabel.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spPatchLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPatchLabel.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spPatchLabel.Size = new System.Drawing.Size(164, 20);
            this.spPatchLabel.TabIndex = 34;
            this.spPatchLabel.Leave += new System.EventHandler(this.spPatchLabel_Leave);
            // 
            // spPatchVer
            // 
            this.spPatchVer.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spPatchVer.Location = new System.Drawing.Point(244, 170);
            this.spPatchVer.Name = "spPatchVer";
            this.spPatchVer.Properties.Appearance.Options.UseTextOptions = true;
            this.spPatchVer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spPatchVer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPatchVer.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spPatchVer.Size = new System.Drawing.Size(164, 20);
            this.spPatchVer.TabIndex = 33;
            this.spPatchVer.Leave += new System.EventHandler(this.spPatchVer_Leave);
            // 
            // spLabelDes
            // 
            this.spLabelDes.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spLabelDes.Location = new System.Drawing.Point(244, 140);
            this.spLabelDes.Name = "spLabelDes";
            this.spLabelDes.Properties.Appearance.Options.UseTextOptions = true;
            this.spLabelDes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spLabelDes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spLabelDes.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spLabelDes.Size = new System.Drawing.Size(164, 20);
            this.spLabelDes.TabIndex = 32;
            this.spLabelDes.Leave += new System.EventHandler(this.spLabelDes_Leave);
            // 
            // spHeading
            // 
            this.spHeading.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spHeading.Location = new System.Drawing.Point(244, 110);
            this.spHeading.Name = "spHeading";
            this.spHeading.Properties.Appearance.Options.UseTextOptions = true;
            this.spHeading.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spHeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spHeading.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spHeading.Size = new System.Drawing.Size(164, 20);
            this.spHeading.TabIndex = 31;
            this.spHeading.Leave += new System.EventHandler(this.spHeading_Leave);
            // 
            // spColumns
            // 
            this.spColumns.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spColumns.Location = new System.Drawing.Point(244, 79);
            this.spColumns.Name = "spColumns";
            this.spColumns.Properties.Appearance.Options.UseTextOptions = true;
            this.spColumns.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spColumns.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spColumns.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spColumns.Size = new System.Drawing.Size(164, 20);
            this.spColumns.TabIndex = 30;
            this.spColumns.Leave += new System.EventHandler(this.spColumns_Leave);
            // 
            // spGroup
            // 
            this.spGroup.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spGroup.Location = new System.Drawing.Point(244, 48);
            this.spGroup.Name = "spGroup";
            this.spGroup.Properties.Appearance.Options.UseTextOptions = true;
            this.spGroup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spGroup.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spGroup.Size = new System.Drawing.Size(164, 20);
            this.spGroup.TabIndex = 29;
            this.spGroup.Leave += new System.EventHandler(this.spGroup_Leave);
            // 
            // spTitleItems
            // 
            this.spTitleItems.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spTitleItems.Location = new System.Drawing.Point(244, 17);
            this.spTitleItems.Name = "spTitleItems";
            this.spTitleItems.Properties.Appearance.Options.UseTextOptions = true;
            this.spTitleItems.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spTitleItems.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTitleItems.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spTitleItems.Size = new System.Drawing.Size(164, 20);
            this.spTitleItems.TabIndex = 28;
            this.spTitleItems.Leave += new System.EventHandler(this.spTitleItems_Leave);
            // 
            // lbPatchLabel
            // 
            this.lbPatchLabel.Location = new System.Drawing.Point(24, 204);
            this.lbPatchLabel.Name = "lbPatchLabel";
            this.lbPatchLabel.Size = new System.Drawing.Size(112, 14);
            this.lbPatchLabel.TabIndex = 20;
            this.lbPatchLabel.Text = "图例符号与标注间距:";
            // 
            // lbPatchVer
            // 
            this.lbPatchVer.Location = new System.Drawing.Point(24, 174);
            this.lbPatchVer.Name = "lbPatchVer";
            this.lbPatchVer.Size = new System.Drawing.Size(100, 14);
            this.lbPatchVer.TabIndex = 19;
            this.lbPatchVer.Text = "图例符号垂直间距:";
            // 
            // lbLabelDes
            // 
            this.lbLabelDes.Location = new System.Drawing.Point(24, 143);
            this.lbLabelDes.Name = "lbLabelDes";
            this.lbLabelDes.Size = new System.Drawing.Size(112, 14);
            this.lbLabelDes.TabIndex = 18;
            this.lbLabelDes.Text = "图例标注与说明间距:";
            // 
            // lbHeading
            // 
            this.lbHeading.Location = new System.Drawing.Point(24, 113);
            this.lbHeading.Name = "lbHeading";
            this.lbHeading.Size = new System.Drawing.Size(160, 14);
            this.lbHeading.TabIndex = 17;
            this.lbHeading.Text = "分组图例标题与图例符号间距:";
            // 
            // lbColumns
            // 
            this.lbColumns.Location = new System.Drawing.Point(24, 83);
            this.lbColumns.Name = "lbColumns";
            this.lbColumns.Size = new System.Drawing.Size(88, 14);
            this.lbColumns.TabIndex = 16;
            this.lbColumns.Text = "图例项水平间距:";
            // 
            // lbGroup
            // 
            this.lbGroup.Location = new System.Drawing.Point(24, 52);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Size = new System.Drawing.Size(88, 14);
            this.lbGroup.TabIndex = 15;
            this.lbGroup.Text = "图例项垂直间距:";
            // 
            // lbTitleItems
            // 
            this.lbTitleItems.Location = new System.Drawing.Point(24, 22);
            this.lbTitleItems.Name = "lbTitleItems";
            this.lbTitleItems.Size = new System.Drawing.Size(136, 14);
            this.lbTitleItems.TabIndex = 14;
            this.lbTitleItems.Text = "图例标题与图例符号间距:";
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.teTitle);
            this.gbTitle.Controls.Add(this.btSymbol);
            this.gbTitle.Controls.Add(this.cbPos);
            this.gbTitle.Controls.Add(this.lbPosition);
            this.gbTitle.Controls.Add(this.cbShow);
            this.gbTitle.Location = new System.Drawing.Point(59, 5);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(436, 169);
            this.gbTitle.TabIndex = 4;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "标题";
            // 
            // teTitle
            // 
            this.teTitle.Location = new System.Drawing.Point(24, 26);
            this.teTitle.Multiline = true;
            this.teTitle.Name = "teTitle";
            this.teTitle.Size = new System.Drawing.Size(383, 96);
            this.teTitle.TabIndex = 10;
            this.teTitle.Leave += new System.EventHandler(this.teTitle_Leave);
            // 
            // btSymbol
            // 
            this.btSymbol.Location = new System.Drawing.Point(343, 135);
            this.btSymbol.Name = "btSymbol";
            this.btSymbol.Size = new System.Drawing.Size(65, 27);
            this.btSymbol.TabIndex = 9;
            this.btSymbol.Text = "符号";
            this.btSymbol.Click += new System.EventHandler(this.btSymbol_Click);
            // 
            // cbPos
            // 
            this.cbPos.Location = new System.Drawing.Point(156, 136);
            this.cbPos.Name = "cbPos";
            this.cbPos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPos.Properties.Items.AddRange(new object[] {
            "在符号矩形框上面",
            "在符号矩形框下面",
            "在符号矩形框右边",
            "在符号矩形框左边"});
            this.cbPos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPos.Size = new System.Drawing.Size(168, 20);
            this.cbPos.TabIndex = 8;
            this.cbPos.Visible = false;
            this.cbPos.SelectedIndexChanged += new System.EventHandler(this.cbPos_SelectedIndexChanged);
            // 
            // lbPosition
            // 
            this.lbPosition.Location = new System.Drawing.Point(117, 140);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(28, 14);
            this.lbPosition.TabIndex = 7;
            this.lbPosition.Text = "位置:";
            this.lbPosition.Visible = false;
            // 
            // cbShow
            // 
            this.cbShow.Location = new System.Drawing.Point(22, 138);
            this.cbShow.Name = "cbShow";
            this.cbShow.Properties.Caption = "是否显示";
            this.cbShow.Size = new System.Drawing.Size(87, 19);
            this.cbShow.TabIndex = 6;
            this.cbShow.CheckedChanged += new System.EventHandler(this.cbShow_CheckedChanged);
            // 
            // xtpLegendItem
            // 
            this.xtpLegendItem.Controls.Add(this.panel3);
            this.xtpLegendItem.Controls.Add(this.gbText);
            this.xtpLegendItem.Controls.Add(this.gbMapCon);
            this.xtpLegendItem.Name = "xtpLegendItem";
            this.xtpLegendItem.Size = new System.Drawing.Size(561, 442);
            this.xtpLegendItem.Text = "图例子项";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.gbItems);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.gbLayer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9, 2, 6, 2);
            this.panel3.Size = new System.Drawing.Size(561, 219);
            this.panel3.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudColumns);
            this.panel2.Controls.Add(this.btUp);
            this.panel2.Controls.Add(this.lbColumn);
            this.panel2.Controls.Add(this.btTop);
            this.panel2.Controls.Add(this.ceNewColumn);
            this.panel2.Controls.Add(this.btDown);
            this.panel2.Controls.Add(this.btItemStyle);
            this.panel2.Controls.Add(this.btBottom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(393, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(9);
            this.panel2.Size = new System.Drawing.Size(162, 215);
            this.panel2.TabIndex = 48;
            // 
            // nudColumns
            // 
            this.nudColumns.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Location = new System.Drawing.Point(93, 182);
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudColumns.Properties.IsFloatValue = false;
            this.nudColumns.Properties.Mask.EditMask = "n0";
            this.nudColumns.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Size = new System.Drawing.Size(56, 20);
            this.nudColumns.TabIndex = 56;
            this.nudColumns.ValueChanged += new System.EventHandler(this.nudColumns_ValueChanged);
            // 
            // btUp
            // 
            this.btUp.Location = new System.Drawing.Point(15, 15);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(40, 31);
            this.btUp.TabIndex = 49;
            this.btUp.Text = "↑";
            this.btUp.ToolTip = "上移";
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // lbColumn
            // 
            this.lbColumn.Location = new System.Drawing.Point(15, 185);
            this.lbColumn.Name = "lbColumn";
            this.lbColumn.Size = new System.Drawing.Size(64, 14);
            this.lbColumn.TabIndex = 55;
            this.lbColumn.Text = "显示在哪列:";
            // 
            // btTop
            // 
            this.btTop.Location = new System.Drawing.Point(64, 15);
            this.btTop.Name = "btTop";
            this.btTop.Size = new System.Drawing.Size(38, 31);
            this.btTop.TabIndex = 50;
            this.btTop.Text = "↑↑";
            this.btTop.ToolTip = "移到最顶端";
            this.btTop.Click += new System.EventHandler(this.btTop_Click);
            // 
            // ceNewColumn
            // 
            this.ceNewColumn.Location = new System.Drawing.Point(16, 149);
            this.ceNewColumn.Name = "ceNewColumn";
            this.ceNewColumn.Properties.Caption = "放置在新的一列";
            this.ceNewColumn.Size = new System.Drawing.Size(128, 19);
            this.ceNewColumn.TabIndex = 54;
            this.ceNewColumn.CheckedChanged += new System.EventHandler(this.ceNewColumn_CheckedChanged);
            // 
            // btDown
            // 
            this.btDown.Location = new System.Drawing.Point(16, 54);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(38, 31);
            this.btDown.TabIndex = 51;
            this.btDown.Text = "↓";
            this.btDown.ToolTip = "下移";
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btItemStyle
            // 
            this.btItemStyle.Location = new System.Drawing.Point(16, 111);
            this.btItemStyle.Name = "btItemStyle";
            this.btItemStyle.Size = new System.Drawing.Size(71, 27);
            this.btItemStyle.TabIndex = 53;
            this.btItemStyle.Text = "风格";
            this.btItemStyle.Click += new System.EventHandler(this.btItemStyle_Click);
            // 
            // btBottom
            // 
            this.btBottom.Location = new System.Drawing.Point(65, 54);
            this.btBottom.Name = "btBottom";
            this.btBottom.Size = new System.Drawing.Size(38, 31);
            this.btBottom.TabIndex = 52;
            this.btBottom.Text = "↓↓";
            this.btBottom.ToolTip = "移到最底部";
            this.btBottom.Click += new System.EventHandler(this.btBottom_Click);
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.lvItems);
            this.gbItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbItems.Location = new System.Drawing.Point(224, 2);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(169, 215);
            this.gbItems.TabIndex = 27;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "图例子项";
            // 
            // lvItems
            // 
            this.lvItems.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItems.HorizontalScrollbar = true;
            this.lvItems.Location = new System.Drawing.Point(3, 18);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(163, 194);
            this.lvItems.TabIndex = 0;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAddOne);
            this.panel1.Controls.Add(this.btAddAll);
            this.panel1.Controls.Add(this.btMinusOne);
            this.panel1.Controls.Add(this.btMinusAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(161, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12, 23, 12, 12);
            this.panel1.Size = new System.Drawing.Size(63, 215);
            this.panel1.TabIndex = 31;
            // 
            // btAddOne
            // 
            this.btAddOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btAddOne.Location = new System.Drawing.Point(12, 23);
            this.btAddOne.Name = "btAddOne";
            this.btAddOne.Size = new System.Drawing.Size(39, 27);
            this.btAddOne.TabIndex = 44;
            this.btAddOne.Text = ">";
            this.btAddOne.ToolTip = "添加选择";
            this.btAddOne.Click += new System.EventHandler(this.btAddOne_Click);
            // 
            // btAddAll
            // 
            this.btAddAll.Location = new System.Drawing.Point(12, 57);
            this.btAddAll.Name = "btAddAll";
            this.btAddAll.Size = new System.Drawing.Size(40, 27);
            this.btAddAll.TabIndex = 45;
            this.btAddAll.Text = ">>";
            this.btAddAll.ToolTip = "添加所有";
            this.btAddAll.Click += new System.EventHandler(this.btAddAll_Click);
            // 
            // btMinusOne
            // 
            this.btMinusOne.Location = new System.Drawing.Point(12, 142);
            this.btMinusOne.Name = "btMinusOne";
            this.btMinusOne.Size = new System.Drawing.Size(40, 27);
            this.btMinusOne.TabIndex = 46;
            this.btMinusOne.Text = "<";
            this.btMinusOne.ToolTip = "移除选择";
            this.btMinusOne.Click += new System.EventHandler(this.btMinusOne_Click);
            // 
            // btMinusAll
            // 
            this.btMinusAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btMinusAll.Location = new System.Drawing.Point(12, 176);
            this.btMinusAll.Name = "btMinusAll";
            this.btMinusAll.Size = new System.Drawing.Size(39, 27);
            this.btMinusAll.TabIndex = 47;
            this.btMinusAll.Text = "<<";
            this.btMinusAll.ToolTip = "移除所有";
            this.btMinusAll.Click += new System.EventHandler(this.btMinusAll_Click);
            // 
            // gbLayer
            // 
            this.gbLayer.Controls.Add(this.tlLayer);
            this.gbLayer.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLayer.Location = new System.Drawing.Point(9, 2);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(152, 215);
            this.gbLayer.TabIndex = 48;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "图层";
            // 
            // tlLayer
            // 
            this.tlLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlLayer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlLayer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlsLayer});
            this.tlLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLayer.Location = new System.Drawing.Point(3, 18);
            this.tlLayer.Name = "tlLayer";
            this.tlLayer.OptionsBehavior.Editable = false;
            this.tlLayer.OptionsSelection.MultiSelect = true;
            this.tlLayer.OptionsView.ShowColumns = false;
            this.tlLayer.OptionsView.ShowHorzLines = false;
            this.tlLayer.OptionsView.ShowIndicator = false;
            this.tlLayer.OptionsView.ShowVertLines = false;
            this.tlLayer.Size = new System.Drawing.Size(146, 194);
            this.tlLayer.TabIndex = 43;
            // 
            // tlsLayer
            // 
            this.tlsLayer.Caption = "图层";
            this.tlsLayer.FieldName = "图层";
            this.tlsLayer.Name = "tlsLayer";
            this.tlsLayer.Visible = true;
            this.tlsLayer.VisibleIndex = 0;
            // 
            // gbText
            // 
            this.gbText.Controls.Add(this.btItemTxtSymbol);
            this.gbText.Controls.Add(this.cbItemText);
            this.gbText.Controls.Add(this.lbContent);
            this.gbText.Controls.Add(this.gbPatch);
            this.gbText.Controls.Add(this.rgLegendItem);
            this.gbText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbText.Location = new System.Drawing.Point(0, 238);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(561, 86);
            this.gbText.TabIndex = 42;
            this.gbText.TabStop = false;
            this.gbText.Text = "改变文本";
            // 
            // btItemTxtSymbol
            // 
            this.btItemTxtSymbol.Location = new System.Drawing.Point(330, 49);
            this.btItemTxtSymbol.Name = "btItemTxtSymbol";
            this.btItemTxtSymbol.Size = new System.Drawing.Size(70, 27);
            this.btItemTxtSymbol.TabIndex = 30;
            this.btItemTxtSymbol.Text = "符号";
            this.btItemTxtSymbol.Click += new System.EventHandler(this.btItemTxtSymbol_Click);
            // 
            // cbItemText
            // 
            this.cbItemText.Location = new System.Drawing.Point(78, 51);
            this.cbItemText.Name = "cbItemText";
            this.cbItemText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbItemText.Properties.Items.AddRange(new object[] {
            "下面所有项",
            "图层名",
            "组名",
            "标注",
            "说明"});
            this.cbItemText.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbItemText.Size = new System.Drawing.Size(233, 20);
            this.cbItemText.TabIndex = 29;
            // 
            // lbContent
            // 
            this.lbContent.Location = new System.Drawing.Point(10, 55);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(52, 14);
            this.lbContent.TabIndex = 28;
            this.lbContent.Text = "应用对象:";
            // 
            // gbPatch
            // 
            this.gbPatch.Controls.Add(this.cbPatchArea);
            this.gbPatch.Controls.Add(this.cbPatchLine);
            this.gbPatch.Controls.Add(this.txtItemHeigt);
            this.gbPatch.Controls.Add(this.txtItemWidth);
            this.gbPatch.Controls.Add(this.lbArea);
            this.gbPatch.Controls.Add(this.lbLine);
            this.gbPatch.Controls.Add(this.lbItemHeight);
            this.gbPatch.Controls.Add(this.lbItemWidth);
            this.gbPatch.Location = new System.Drawing.Point(413, 33);
            this.gbPatch.Name = "gbPatch";
            this.gbPatch.Size = new System.Drawing.Size(106, 47);
            this.gbPatch.TabIndex = 28;
            this.gbPatch.TabStop = false;
            this.gbPatch.Text = "符号(单位:像素)";
            this.gbPatch.Visible = false;
            // 
            // cbPatchArea
            // 
            this.cbPatchArea.Location = new System.Drawing.Point(55, 134);
            this.cbPatchArea.Name = "cbPatchArea";
            this.cbPatchArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPatchArea.Size = new System.Drawing.Size(79, 20);
            this.cbPatchArea.TabIndex = 17;
            this.cbPatchArea.SelectedIndexChanged += new System.EventHandler(this.cbPatchArea_SelectedIndexChanged);
            // 
            // cbPatchLine
            // 
            this.cbPatchLine.Location = new System.Drawing.Point(55, 100);
            this.cbPatchLine.Name = "cbPatchLine";
            this.cbPatchLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPatchLine.Size = new System.Drawing.Size(79, 20);
            this.cbPatchLine.TabIndex = 16;
            this.cbPatchLine.SelectedIndexChanged += new System.EventHandler(this.cbPatchLine_SelectedIndexChanged);
            // 
            // txtItemHeigt
            // 
            this.txtItemHeigt.EditValue = "";
            this.txtItemHeigt.Location = new System.Drawing.Point(55, 66);
            this.txtItemHeigt.Name = "txtItemHeigt";
            this.txtItemHeigt.Size = new System.Drawing.Size(79, 20);
            this.txtItemHeigt.TabIndex = 15;
            this.txtItemHeigt.Leave += new System.EventHandler(this.txtItemHeigt_Leave);
            // 
            // txtItemWidth
            // 
            this.txtItemWidth.EditValue = "";
            this.txtItemWidth.Location = new System.Drawing.Point(55, 33);
            this.txtItemWidth.Name = "txtItemWidth";
            this.txtItemWidth.Size = new System.Drawing.Size(79, 20);
            this.txtItemWidth.TabIndex = 14;
            this.txtItemWidth.Leave += new System.EventHandler(this.txtItemWidth_Leave);
            // 
            // lbArea
            // 
            this.lbArea.Location = new System.Drawing.Point(12, 138);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(24, 14);
            this.lbArea.TabIndex = 13;
            this.lbArea.Text = "  面:";
            // 
            // lbLine
            // 
            this.lbLine.Location = new System.Drawing.Point(12, 104);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(24, 14);
            this.lbLine.TabIndex = 12;
            this.lbLine.Text = "  线:";
            // 
            // lbItemHeight
            // 
            this.lbItemHeight.Location = new System.Drawing.Point(12, 69);
            this.lbItemHeight.Name = "lbItemHeight";
            this.lbItemHeight.Size = new System.Drawing.Size(28, 14);
            this.lbItemHeight.TabIndex = 11;
            this.lbItemHeight.Text = "高度:";
            // 
            // lbItemWidth
            // 
            this.lbItemWidth.Location = new System.Drawing.Point(12, 36);
            this.lbItemWidth.Name = "lbItemWidth";
            this.lbItemWidth.Size = new System.Drawing.Size(28, 14);
            this.lbItemWidth.TabIndex = 10;
            this.lbItemWidth.Text = "宽度:";
            // 
            // rgLegendItem
            // 
            this.rgLegendItem.Location = new System.Drawing.Point(10, 21);
            this.rgLegendItem.Name = "rgLegendItem";
            this.rgLegendItem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgLegendItem.Properties.Appearance.Options.UseBackColor = true;
            this.rgLegendItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgLegendItem.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "所有图例项"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "选定的图例项")});
            this.rgLegendItem.Size = new System.Drawing.Size(225, 27);
            this.rgLegendItem.TabIndex = 27;
            // 
            // gbMapCon
            // 
            this.gbMapCon.Controls.Add(this.cbItemOrder);
            this.gbMapCon.Controls.Add(this.cbAdd);
            this.gbMapCon.Controls.Add(this.cbChoice);
            this.gbMapCon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMapCon.Location = new System.Drawing.Point(0, 324);
            this.gbMapCon.Name = "gbMapCon";
            this.gbMapCon.Size = new System.Drawing.Size(561, 118);
            this.gbMapCon.TabIndex = 41;
            this.gbMapCon.TabStop = false;
            this.gbMapCon.Text = "地图关联";
            // 
            // cbItemOrder
            // 
            this.cbItemOrder.Location = new System.Drawing.Point(14, 91);
            this.cbItemOrder.Name = "cbItemOrder";
            this.cbItemOrder.Properties.Caption = "当地图上图层顺序改变时图例也跟着改变";
            this.cbItemOrder.Size = new System.Drawing.Size(276, 19);
            this.cbItemOrder.TabIndex = 5;
            this.cbItemOrder.CheckedChanged += new System.EventHandler(this.cbItemOrder_CheckedChanged);
            // 
            // cbAdd
            // 
            this.cbAdd.Location = new System.Drawing.Point(14, 58);
            this.cbAdd.Name = "cbAdd";
            this.cbAdd.Properties.Caption = "当地图上添加了新的图层时向图例添加一个子项";
            this.cbAdd.Size = new System.Drawing.Size(323, 19);
            this.cbAdd.TabIndex = 4;
            this.cbAdd.CheckedChanged += new System.EventHandler(this.cbAdd_CheckedChanged);
            // 
            // cbChoice
            // 
            this.cbChoice.Location = new System.Drawing.Point(14, 26);
            this.cbChoice.Name = "cbChoice";
            this.cbChoice.Properties.Caption = "只显示选择图层中可见的图层";
            this.cbChoice.Size = new System.Drawing.Size(211, 19);
            this.cbChoice.TabIndex = 3;
            this.cbChoice.CheckedChanged += new System.EventHandler(this.cbChoice_CheckedChanged);
            // 
            // xtpBox
            // 
            this.xtpBox.Controls.Add(this.pbShadow);
            this.xtpBox.Controls.Add(this.pbBack);
            this.xtpBox.Controls.Add(this.pbBorder);
            this.xtpBox.Controls.Add(this.gbDropShadow);
            this.xtpBox.Controls.Add(this.gbBack);
            this.xtpBox.Controls.Add(this.gbBorder);
            this.xtpBox.Name = "xtpBox";
            this.xtpBox.Size = new System.Drawing.Size(561, 442);
            this.xtpBox.Text = "图框";
            // 
            // pbShadow
            // 
            this.pbShadow.Location = new System.Drawing.Point(369, 306);
            this.pbShadow.Name = "pbShadow";
            this.pbShadow.Size = new System.Drawing.Size(176, 119);
            this.pbShadow.TabIndex = 55;
            // 
            // pbBack
            // 
            this.pbBack.Location = new System.Drawing.Point(369, 163);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(176, 119);
            this.pbBack.TabIndex = 54;
            // 
            // pbBorder
            // 
            this.pbBorder.Location = new System.Drawing.Point(369, 20);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(176, 119);
            this.pbBorder.TabIndex = 53;
            // 
            // gbDropShadow
            // 
            this.gbDropShadow.Controls.Add(this.lbShadowYPts);
            this.gbDropShadow.Controls.Add(this.nudShadowY);
            this.gbDropShadow.Controls.Add(this.lbShadowY);
            this.gbDropShadow.Controls.Add(this.lbShadowXPts);
            this.gbDropShadow.Controls.Add(this.nudShadowX);
            this.gbDropShadow.Controls.Add(this.lbShadowX);
            this.gbDropShadow.Controls.Add(this.lbShadowGap);
            this.gbDropShadow.Controls.Add(this.labelControl2);
            this.gbDropShadow.Controls.Add(this.nudShadowRounding);
            this.gbDropShadow.Controls.Add(this.lbShadowRounding);
            this.gbDropShadow.Controls.Add(this.btShadow);
            this.gbDropShadow.Controls.Add(this.lbShadowSymbol);
            this.gbDropShadow.Location = new System.Drawing.Point(12, 295);
            this.gbDropShadow.Name = "gbDropShadow";
            this.gbDropShadow.Size = new System.Drawing.Size(343, 129);
            this.gbDropShadow.TabIndex = 52;
            this.gbDropShadow.TabStop = false;
            this.gbDropShadow.Text = "阴影";
            // 
            // lbShadowYPts
            // 
            this.lbShadowYPts.Location = new System.Drawing.Point(296, 69);
            this.lbShadowYPts.Name = "lbShadowYPts";
            this.lbShadowYPts.Size = new System.Drawing.Size(24, 14);
            this.lbShadowYPts.TabIndex = 51;
            this.lbShadowYPts.Text = "像素";
            // 
            // nudShadowY
            // 
            this.nudShadowY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowY.Location = new System.Drawing.Point(241, 65);
            this.nudShadowY.Name = "nudShadowY";
            this.nudShadowY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowY.Size = new System.Drawing.Size(51, 20);
            this.nudShadowY.TabIndex = 50;
            this.nudShadowY.ValueChanged += new System.EventHandler(this.nudShadowY_ValueChanged);
            // 
            // lbShadowY
            // 
            this.lbShadowY.Location = new System.Drawing.Point(209, 69);
            this.lbShadowY.Name = "lbShadowY";
            this.lbShadowY.Size = new System.Drawing.Size(12, 14);
            this.lbShadowY.TabIndex = 49;
            this.lbShadowY.Text = "Y:";
            // 
            // lbShadowXPts
            // 
            this.lbShadowXPts.Location = new System.Drawing.Point(154, 69);
            this.lbShadowXPts.Name = "lbShadowXPts";
            this.lbShadowXPts.Size = new System.Drawing.Size(24, 14);
            this.lbShadowXPts.TabIndex = 48;
            this.lbShadowXPts.Text = "像素";
            // 
            // nudShadowX
            // 
            this.nudShadowX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowX.Location = new System.Drawing.Point(99, 65);
            this.nudShadowX.Name = "nudShadowX";
            this.nudShadowX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowX.Size = new System.Drawing.Size(51, 20);
            this.nudShadowX.TabIndex = 47;
            this.nudShadowX.ValueChanged += new System.EventHandler(this.nudShadowX_ValueChanged);
            // 
            // lbShadowX
            // 
            this.lbShadowX.Location = new System.Drawing.Point(68, 69);
            this.lbShadowX.Name = "lbShadowX";
            this.lbShadowX.Size = new System.Drawing.Size(11, 14);
            this.lbShadowX.TabIndex = 46;
            this.lbShadowX.Text = "X:";
            // 
            // lbShadowGap
            // 
            this.lbShadowGap.Location = new System.Drawing.Point(13, 69);
            this.lbShadowGap.Name = "lbShadowGap";
            this.lbShadowGap.Size = new System.Drawing.Size(28, 14);
            this.lbShadowGap.TabIndex = 45;
            this.lbShadowGap.Text = "边距:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(303, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "%";
            // 
            // nudShadowRounding
            // 
            this.nudShadowRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowRounding.Location = new System.Drawing.Point(241, 23);
            this.nudShadowRounding.Name = "nudShadowRounding";
            this.nudShadowRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowRounding.Size = new System.Drawing.Size(51, 20);
            this.nudShadowRounding.TabIndex = 43;
            this.nudShadowRounding.ValueChanged += new System.EventHandler(this.nudShadowRounding_ValueChanged);
            // 
            // lbShadowRounding
            // 
            this.lbShadowRounding.Location = new System.Drawing.Point(190, 27);
            this.lbShadowRounding.Name = "lbShadowRounding";
            this.lbShadowRounding.Size = new System.Drawing.Size(28, 14);
            this.lbShadowRounding.TabIndex = 42;
            this.lbShadowRounding.Text = "圆角:";
            // 
            // btShadow
            // 
            this.btShadow.Location = new System.Drawing.Point(79, 22);
            this.btShadow.Name = "btShadow";
            this.btShadow.Size = new System.Drawing.Size(87, 27);
            this.btShadow.TabIndex = 41;
            this.btShadow.Text = "设置";
            this.btShadow.Click += new System.EventHandler(this.btShadow_Click);
            // 
            // lbShadowSymbol
            // 
            this.lbShadowSymbol.Location = new System.Drawing.Point(13, 27);
            this.lbShadowSymbol.Name = "lbShadowSymbol";
            this.lbShadowSymbol.Size = new System.Drawing.Size(28, 14);
            this.lbShadowSymbol.TabIndex = 40;
            this.lbShadowSymbol.Text = "符号 ";
            // 
            // gbBack
            // 
            this.gbBack.Controls.Add(this.nudBackY);
            this.gbBack.Controls.Add(this.nudBackX);
            this.gbBack.Controls.Add(this.lbBackYPts);
            this.gbBack.Controls.Add(this.lbBackY);
            this.gbBack.Controls.Add(this.lbBackX);
            this.gbBack.Controls.Add(this.lbBackGap);
            this.gbBack.Controls.Add(this.labelControl6);
            this.gbBack.Controls.Add(this.nudBackRounding);
            this.gbBack.Controls.Add(this.lbBackRounding);
            this.gbBack.Controls.Add(this.btBack);
            this.gbBack.Controls.Add(this.lbBackSymbol);
            this.gbBack.Controls.Add(this.lbBackXPts);
            this.gbBack.Location = new System.Drawing.Point(12, 153);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(343, 129);
            this.gbBack.TabIndex = 51;
            this.gbBack.TabStop = false;
            this.gbBack.Text = "背景";
            // 
            // nudBackY
            // 
            this.nudBackY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackY.Location = new System.Drawing.Point(241, 76);
            this.nudBackY.Name = "nudBackY";
            this.nudBackY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackY.Size = new System.Drawing.Size(51, 20);
            this.nudBackY.TabIndex = 39;
            this.nudBackY.ValueChanged += new System.EventHandler(this.nudBackY_ValueChanged);
            // 
            // nudBackX
            // 
            this.nudBackX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackX.Location = new System.Drawing.Point(99, 76);
            this.nudBackX.Name = "nudBackX";
            this.nudBackX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackX.Size = new System.Drawing.Size(51, 20);
            this.nudBackX.TabIndex = 38;
            this.nudBackX.ValueChanged += new System.EventHandler(this.nudBackX_ValueChanged);
            // 
            // lbBackYPts
            // 
            this.lbBackYPts.Location = new System.Drawing.Point(296, 79);
            this.lbBackYPts.Name = "lbBackYPts";
            this.lbBackYPts.Size = new System.Drawing.Size(24, 14);
            this.lbBackYPts.TabIndex = 37;
            this.lbBackYPts.Text = "像素";
            // 
            // lbBackY
            // 
            this.lbBackY.Location = new System.Drawing.Point(209, 79);
            this.lbBackY.Name = "lbBackY";
            this.lbBackY.Size = new System.Drawing.Size(12, 14);
            this.lbBackY.TabIndex = 36;
            this.lbBackY.Text = "Y:";
            // 
            // lbBackX
            // 
            this.lbBackX.Location = new System.Drawing.Point(68, 79);
            this.lbBackX.Name = "lbBackX";
            this.lbBackX.Size = new System.Drawing.Size(11, 14);
            this.lbBackX.TabIndex = 35;
            this.lbBackX.Text = "X:";
            // 
            // lbBackGap
            // 
            this.lbBackGap.Location = new System.Drawing.Point(13, 79);
            this.lbBackGap.Name = "lbBackGap";
            this.lbBackGap.Size = new System.Drawing.Size(28, 14);
            this.lbBackGap.TabIndex = 34;
            this.lbBackGap.Text = "边距:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(303, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(12, 14);
            this.labelControl6.TabIndex = 33;
            this.labelControl6.Text = "%";
            // 
            // nudBackRounding
            // 
            this.nudBackRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackRounding.Location = new System.Drawing.Point(243, 26);
            this.nudBackRounding.Name = "nudBackRounding";
            this.nudBackRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackRounding.Size = new System.Drawing.Size(50, 20);
            this.nudBackRounding.TabIndex = 32;
            this.nudBackRounding.ValueChanged += new System.EventHandler(this.nudBackRounding_ValueChanged);
            // 
            // lbBackRounding
            // 
            this.lbBackRounding.Location = new System.Drawing.Point(190, 29);
            this.lbBackRounding.Name = "lbBackRounding";
            this.lbBackRounding.Size = new System.Drawing.Size(28, 14);
            this.lbBackRounding.TabIndex = 31;
            this.lbBackRounding.Text = "圆角:";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(79, 24);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(87, 27);
            this.btBack.TabIndex = 30;
            this.btBack.Text = "设置";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // lbBackSymbol
            // 
            this.lbBackSymbol.Location = new System.Drawing.Point(13, 29);
            this.lbBackSymbol.Name = "lbBackSymbol";
            this.lbBackSymbol.Size = new System.Drawing.Size(24, 14);
            this.lbBackSymbol.TabIndex = 29;
            this.lbBackSymbol.Text = "符号";
            // 
            // lbBackXPts
            // 
            this.lbBackXPts.AutoSize = true;
            this.lbBackXPts.Location = new System.Drawing.Point(150, 79);
            this.lbBackXPts.Name = "lbBackXPts";
            this.lbBackXPts.Size = new System.Drawing.Size(31, 14);
            this.lbBackXPts.TabIndex = 28;
            this.lbBackXPts.Text = "像素";
            // 
            // gbBorder
            // 
            this.gbBorder.Controls.Add(this.nudBorderY);
            this.gbBorder.Controls.Add(this.nudBorderX);
            this.gbBorder.Controls.Add(this.lbBorderYPts);
            this.gbBorder.Controls.Add(this.lbBorderY);
            this.gbBorder.Controls.Add(this.lbBorderX);
            this.gbBorder.Controls.Add(this.lbBorderGap);
            this.gbBorder.Controls.Add(this.labelControl1);
            this.gbBorder.Controls.Add(this.nudBorderRounding);
            this.gbBorder.Controls.Add(this.lbBorderRounding);
            this.gbBorder.Controls.Add(this.btBorder);
            this.gbBorder.Controls.Add(this.lbBorderSymbol);
            this.gbBorder.Controls.Add(this.lbBorderXPts);
            this.gbBorder.Location = new System.Drawing.Point(12, 10);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(343, 129);
            this.gbBorder.TabIndex = 50;
            this.gbBorder.TabStop = false;
            this.gbBorder.Text = "边框";
            // 
            // nudBorderY
            // 
            this.nudBorderY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderY.Location = new System.Drawing.Point(241, 69);
            this.nudBorderY.Name = "nudBorderY";
            this.nudBorderY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderY.Size = new System.Drawing.Size(51, 20);
            this.nudBorderY.TabIndex = 26;
            this.nudBorderY.ValueChanged += new System.EventHandler(this.nudBorderY_ValueChanged);
            // 
            // nudBorderX
            // 
            this.nudBorderX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderX.Location = new System.Drawing.Point(99, 69);
            this.nudBorderX.Name = "nudBorderX";
            this.nudBorderX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderX.Size = new System.Drawing.Size(51, 20);
            this.nudBorderX.TabIndex = 25;
            this.nudBorderX.ValueChanged += new System.EventHandler(this.nudBorderX_ValueChanged);
            // 
            // lbBorderYPts
            // 
            this.lbBorderYPts.Location = new System.Drawing.Point(296, 72);
            this.lbBorderYPts.Name = "lbBorderYPts";
            this.lbBorderYPts.Size = new System.Drawing.Size(24, 14);
            this.lbBorderYPts.TabIndex = 24;
            this.lbBorderYPts.Text = "像素";
            // 
            // lbBorderY
            // 
            this.lbBorderY.Location = new System.Drawing.Point(209, 72);
            this.lbBorderY.Name = "lbBorderY";
            this.lbBorderY.Size = new System.Drawing.Size(12, 14);
            this.lbBorderY.TabIndex = 23;
            this.lbBorderY.Text = "Y:";
            // 
            // lbBorderX
            // 
            this.lbBorderX.Location = new System.Drawing.Point(68, 72);
            this.lbBorderX.Name = "lbBorderX";
            this.lbBorderX.Size = new System.Drawing.Size(11, 14);
            this.lbBorderX.TabIndex = 22;
            this.lbBorderX.Text = "X:";
            // 
            // lbBorderGap
            // 
            this.lbBorderGap.Location = new System.Drawing.Point(13, 72);
            this.lbBorderGap.Name = "lbBorderGap";
            this.lbBorderGap.Size = new System.Drawing.Size(28, 14);
            this.lbBorderGap.TabIndex = 21;
            this.lbBorderGap.Text = "边距:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(303, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "%";
            // 
            // nudBorderRounding
            // 
            this.nudBorderRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderRounding.Location = new System.Drawing.Point(243, 19);
            this.nudBorderRounding.Name = "nudBorderRounding";
            this.nudBorderRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderRounding.Size = new System.Drawing.Size(50, 20);
            this.nudBorderRounding.TabIndex = 19;
            this.nudBorderRounding.ValueChanged += new System.EventHandler(this.nudBorderRounding_ValueChanged);
            // 
            // lbBorderRounding
            // 
            this.lbBorderRounding.Location = new System.Drawing.Point(190, 22);
            this.lbBorderRounding.Name = "lbBorderRounding";
            this.lbBorderRounding.Size = new System.Drawing.Size(28, 14);
            this.lbBorderRounding.TabIndex = 18;
            this.lbBorderRounding.Text = "圆角:";
            // 
            // btBorder
            // 
            this.btBorder.Location = new System.Drawing.Point(79, 17);
            this.btBorder.Name = "btBorder";
            this.btBorder.Size = new System.Drawing.Size(87, 27);
            this.btBorder.TabIndex = 17;
            this.btBorder.Text = "设置";
            this.btBorder.Click += new System.EventHandler(this.btBorder_Click);
            // 
            // lbBorderSymbol
            // 
            this.lbBorderSymbol.Location = new System.Drawing.Point(13, 22);
            this.lbBorderSymbol.Name = "lbBorderSymbol";
            this.lbBorderSymbol.Size = new System.Drawing.Size(24, 14);
            this.lbBorderSymbol.TabIndex = 16;
            this.lbBorderSymbol.Text = "符号";
            // 
            // lbBorderXPts
            // 
            this.lbBorderXPts.AutoSize = true;
            this.lbBorderXPts.Location = new System.Drawing.Point(150, 72);
            this.lbBorderXPts.Name = "lbBorderXPts";
            this.lbBorderXPts.Size = new System.Drawing.Size(31, 14);
            this.lbBorderXPts.TabIndex = 7;
            this.lbBorderXPts.Text = "像素";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(295, 483);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(184, 483);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "创建 ";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // sBtnApply
            // 
            this.sBtnApply.Location = new System.Drawing.Point(412, 484);
            this.sBtnApply.Name = "sBtnApply";
            this.sBtnApply.Size = new System.Drawing.Size(87, 27);
            this.sBtnApply.TabIndex = 4;
            this.sBtnApply.Text = "应用";
            this.sBtnApply.Click += new System.EventHandler(this.sBtnApply_Click);
            // 
            // DevLegend
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(567, 524);
            this.Controls.Add(this.sBtnApply);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.xtraTabControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevLegend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图例";
            this.Load += new System.EventHandler(this.Legend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpLegend.ResumeLayout(false);
            this.gbSpace.ResumeLayout(false);
            this.gbSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPatchLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPatchVer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLabelDes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spColumns.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTitleItems.Properties)).EndInit();
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShow.Properties)).EndInit();
            this.xtpLegendItem.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewColumn.Properties)).EndInit();
            this.gbItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbLayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlLayer)).EndInit();
            this.gbText.ResumeLayout(false);
            this.gbText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbItemText.Properties)).EndInit();
            this.gbPatch.ResumeLayout(false);
            this.gbPatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatchArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPatchLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemHeigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgLegendItem.Properties)).EndInit();
            this.gbMapCon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbItemOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice.Properties)).EndInit();
            this.xtpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).EndInit();
            this.gbDropShadow.ResumeLayout(false);
            this.gbDropShadow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowRounding.Properties)).EndInit();
            this.gbBack.ResumeLayout(false);
            this.gbBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackRounding.Properties)).EndInit();
            this.gbBorder.ResumeLayout(false);
            this.gbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderRounding.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void Legend_Load(object sender, EventArgs e)
        {
            this._legend = new LegendClass_2();
            if (this._preMapSurroundFrame != null)
            {
                this.btOk.Text = "确定";
                this.sBtnApply.Visible = true;
                ILegend mapSurround = this._preMapSurroundFrame.MapSurround as ILegend;
                this._legend.AutoAdd = mapSurround.AutoAdd;
                this._legend.AutoReorder = mapSurround.AutoReorder;
                this._legend.AutoVisibility = mapSurround.AutoVisibility;
                this._legend.FlowRight = mapSurround.FlowRight;
                ILegendFormat pTargetObj = new LegendFormatClass();
                CloneService.Clone(mapSurround.Format, pTargetObj);
                this._legend.Format = pTargetObj;
                this._legend.Name = mapSurround.Name;
                this._legend.Title = mapSurround.Title;
                this._legend.Map = this._control.ActiveView.FocusMap;
                this._legend.ClearItems();
                for (int i = 0; i < mapSurround.ItemCount; i++)
                {
                    ILegendItem item = mapSurround.get_Item(i);
                    this._legend.AddItem(item);
                }
                this.InitialControl();
            }
            else
            {
                this.sBtnApply.Visible = false;
                this.InitialDefault();
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this._legend.ItemCount != 0) || (this.legendItems.Count != 0))
            {
                try
                {
                    bool flag = false;
                    bool flag2 = false;
                    List<ILegendItem> list = new List<ILegendItem>();
                    foreach (int num in (IEnumerable<int>) this.lvItems.SelectedIndices)
                    {
                        if (num == 0)
                        {
                            flag = true;
                        }
                        ILegendItem itemByIndex = null;
                        if (this._preMapSurroundFrame != null)
                        {
                            if (num == (this._legend.ItemCount - 1))
                            {
                                flag2 = true;
                            }
                            itemByIndex = LegendService.GetItemByIndex(num, this._legend);
                        }
                        else
                        {
                            if (num == (this.legendItems.Count - 1))
                            {
                                flag2 = true;
                            }
                            itemByIndex = LegendService.GetLegendItemByIndex(num, this.legendItems);
                        }
                        list.Add(itemByIndex);
                    }
                    if (flag && flag2)
                    {
                        this.btUp.Enabled = false;
                        this.btTop.Enabled = false;
                        this.btDown.Enabled = false;
                        this.btBottom.Enabled = false;
                    }
                    else if (flag)
                    {
                        this.btUp.Enabled = false;
                        this.btTop.Enabled = false;
                        this.btDown.Enabled = true;
                        this.btBottom.Enabled = true;
                    }
                    else if (flag2)
                    {
                        this.btUp.Enabled = true;
                        this.btTop.Enabled = true;
                        this.btDown.Enabled = false;
                        this.btBottom.Enabled = false;
                    }
                    else
                    {
                        this.btUp.Enabled = true;
                        this.btTop.Enabled = true;
                        this.btDown.Enabled = true;
                        this.btBottom.Enabled = true;
                    }
                    int num2 = -1;
                    if (list.Count != 0)
                    {
                        bool flag3 = true;
                        for (int i = 0; i < list.Count; i++)
                        {
                            ILegendItem item2 = list[i];
                            flag3 = flag3 && item2.NewColumn;
                            num2 = i;
                            if ((item2.Layer is IFeatureLayer) && (((IFeatureLayer) item2.Layer).FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint))
                            {
                                break;
                            }
                        }
                        this.ceNewColumn.Checked = flag3;
                        this.nudColumns.Value = decimal.Parse(list[num2].Columns.ToString());
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevLegend", "lvItems_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void nudBackRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.CornerRounding = short.Parse(this.nudBackRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBackX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.HorizontalSpacing = double.Parse(this.nudBackX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBackY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.VerticalSpacing = double.Parse(this.nudBackY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBorderRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.HorizontalSpacing = double.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.VerticalSpacing = double.Parse(this.nudBorderY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudColumns_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nudShadowRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.CornerRounding = short.Parse(this.nudShadowRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void nudShadowX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.HorizontalSpacing = short.Parse(this.nudShadowX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void nudShadowY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.VerticalSpacing = short.Parse(this.nudShadowY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        /// <summary>
        /// 图例创建的执行方法
        /// </summary>
        private void Preview()
        {
            this._legend.Refresh();
            ElementService service = new ElementService();
            ///IFrameProperties界面提供对控制框架的常规属性的成员的访问。IFrameProperties界面用于修改框架元素的背景，边框和阴影。
            IFrameProperties properties = null;
            object data = null;
            if (this._preMapSurroundFrame != null)
            {
                ///IMapSurroundFrame.MapSurround属性由此框架元素显示的地图环绕。MapSurround属性允许您检索或设置存储在框架内的环绕对象（北箭头，图例或比例尺）。
                this._preMapSurroundFrame.MapSurround = null;
                this._preMapSurroundFrame.MapSurround = this._legend;
                //IElement接口提供对控制元素的成员的访问。该界面提供对元素几何的访问，并包含用于绘制和执行命中测试的方法。
                IElement element = this._preMapSurroundFrame as IElement;
                IEnvelope envelope = element.Geometry.Envelope;
                IEnvelope oldBounds = new EnvelopeClass();
                ///IEnvelope.PutCoords方法根据下，左和右，右角的坐标值构建一个包络线。给定XMin，YMin，XMax和YMax的包络线。如果XMin> XMax或YMin> YMax，创建的包络线使用输入值，但正确重新分配最小值和最大值。
                oldBounds.PutCoords(envelope.XMin, envelope.YMin, envelope.XMax, envelope.YMax);
                ///IMapSurround.QueryBounds方法返回地图环绕边界。
                this._legend.QueryBounds(this._control.ActiveView.ScreenDisplay, oldBounds, oldBounds);
                Marshal.ReleaseComObject(element.Geometry);
                element.Geometry = oldBounds;
                properties = (IFrameProperties) this._preMapSurroundFrame;
                data = this._preMapSurroundFrame;
            }
            else
            {
                ///如果已经存在图例应该首先删除，再创建
                ///经典啊
                IElement pDeletElement = this._control.FindElementByName("Legend");
                if (pDeletElement!=null)
                {
                    IGraphicsContainer pGraphicsContainer = this._control.GraphicsContainer;
                    pGraphicsContainer.DeleteElement(pDeletElement);
                }

                this._mapSurroundFrame = service.CreateLegend(this._control, this._legend, this.legendItems);
                properties = (IFrameProperties) this._mapSurroundFrame;
                data = this._mapSurroundFrame;
            }
            properties.Background = this.background;
            properties.Border = this.border;
            properties.Shadow = this.shadow;
            this._control.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, data, this._control.ActiveView.Extent);
        }

        /// <summary>
        /// 图例--应用：的实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sBtnApply_Click(object sender, EventArgs e)
        {
            this.Preview();
        }

        private void spColumns_Leave(object sender, EventArgs e)
        {
            this._legend.Format.HorizontalItemGap = Convert.ToDouble(this.spColumns.Value);
        }

        private void spGroup_Leave(object sender, EventArgs e)
        {
            this._legend.Format.VerticalItemGap = Convert.ToDouble(this.spGroup.Value);
        }

        private void spHeading_Leave(object sender, EventArgs e)
        {
            this._legend.Format.HeadingGap = Convert.ToDouble(this.spHeading.Value);
        }

        private void spLabelDes_Leave(object sender, EventArgs e)
        {
            this._legend.Format.TextGap = Convert.ToDouble(this.spLabelDes.Value);
        }

        private void spPatchLabel_Leave(object sender, EventArgs e)
        {
            this._legend.Format.HorizontalPatchGap = Convert.ToDouble(this.spPatchLabel.Value);
        }

        private void spPatchVer_Leave(object sender, EventArgs e)
        {
            this._legend.Format.VerticalPatchGap = Convert.ToDouble(this.spPatchVer.Value);
        }

        private void spTitleItems_Leave(object sender, EventArgs e)
        {
            this._legend.Format.TitleGap = Convert.ToDouble(this.spTitleItems.Value);
        }

        private void teTitle_Leave(object sender, EventArgs e)
        {
            this._legend.Title = this.teTitle.Text;
        }

        private void txtItemHeigt_Leave(object sender, EventArgs e)
        {
        }

        private void txtItemWidth_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 设置IPageLayoutControl的值。
        /// IPageLayoutControl接口提供对控制PageLayoutControl的成员的访问。IPageLayoutControl接口是与PageLayoutControl相关的任何任务的起点，例如设置一般外观，设置页面和显示属性，添加和查找元素，加载地图文档和打印。
        /// </summary>
        public IPageLayoutControl PageLayoutControl
        {
            set
            {
                this._control = value;
            }
        }

        public IMapSurroundFrame PreMapSurroundFrame
        {
            set
            {
                this._preMapSurroundFrame = value;
            }
        }
    }
}

