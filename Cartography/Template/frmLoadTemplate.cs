namespace Cartography.Template
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class frmLoadTemplate : FormBase3
    {
        private IContainer components;
        private IHookHelper m_hookHelper;
        private string m_TemplateFile;
        private const string mClassName = "Cartography.Template.frmLoadTemplate";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonDelete;
        private SimpleButton simpleButtonOK;
        private UserControlTemplate userControlTemplate1;

        public frmLoadTemplate()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public ILayer FindFeatureLayer(IMap pMap, IFeatureLayer pFeatureLayer)
        {
            try
            {
                if (pMap != null)
                {
                    if (pMap.LayerCount <= 0)
                    {
                        return null;
                    }
                    ILayer layer = null;
                    for (int i = 0; i <= (pMap.LayerCount - 1); i++)
                    {
                        layer = pMap.get_Layer(i);
                        if (layer is IFeatureLayer)
                        {
                            if (layer.Name.Equals(pFeatureLayer.Name))
                            {
                                IAttributeTable table = layer as IAttributeTable;
                                IAttributeTable table2 = pFeatureLayer as IAttributeTable;
                                IDataset attributeTable = table.AttributeTable as IDataset;
                                IDataset dataset2 = table2.AttributeTable as IDataset;
                                if (attributeTable.Name.Equals(dataset2.Name))
                                {
                                    return layer;
                                }
                            }
                        }
                        else if (layer is IGroupLayer)
                        {
                            layer = this.FindFeatureLayerGroupRecursion(layer as IGroupLayer, pFeatureLayer);
                            if (layer != null)
                            {
                                return layer;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "FindFeatureLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return null;
        }

        private ILayer FindFeatureLayerGroupRecursion(IGroupLayer pGroupLayer, IFeatureLayer pFeatureLayer)
        {
            try
            {
                if (pGroupLayer != null)
                {
                    ICompositeLayer layer = pGroupLayer as ICompositeLayer;
                    if (layer.Count <= 0)
                    {
                        return null;
                    }
                    ILayer layer2 = null;
                    int index = 0;
                    for (index = 0; index <= (layer.Count - 1); index++)
                    {
                        layer2 = layer.get_Layer(index);
                        if (layer2 is IFeatureLayer)
                        {
                            if (layer2.Name.Equals(pFeatureLayer.Name))
                            {
                                IAttributeTable table = layer2 as IAttributeTable;
                                IAttributeTable table2 = pFeatureLayer as IAttributeTable;
                                IDataset attributeTable = table.AttributeTable as IDataset;
                                IDataset dataset2 = table2.AttributeTable as IDataset;
                                if (attributeTable.Name.Equals(dataset2.Name))
                                {
                                    return layer2;
                                }
                            }
                        }
                        else if (layer2 is IGroupLayer)
                        {
                            layer2 = this.FindFeatureLayerGroupRecursion(layer2 as IGroupLayer, pFeatureLayer);
                            if (layer2 != null)
                            {
                                return layer2;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "FindFeatureLayerGroupRecursion", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return null;
        }

        private void frmLoadTemplate_Load(object sender, EventArgs e)
        {
            this.userControlTemplate1.InitControls();
        }

        public void Init(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlTemplate1 = new Cartography.Template.UserControlTemplate();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonDelete);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.simpleButtonOK);
            this.panel2.Controls.Add(this.simpleButtonCancel);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 322);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel2.Size = new System.Drawing.Size(531, 44);
            this.panel2.TabIndex = 2;
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonDelete.Location = new System.Drawing.Point(64, 8);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(70, 28);
            this.simpleButtonDelete.TabIndex = 2;
            this.simpleButtonDelete.Text = "删除";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 28);
            this.panel3.TabIndex = 4;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(274, 8);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 28);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonCancel.Location = new System.Drawing.Point(397, 8);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(70, 28);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(467, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 28);
            this.panel1.TabIndex = 3;
            // 
            // userControlTemplate1
            // 
            this.userControlTemplate1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlTemplate1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlTemplate1.Appearance.Options.UseBackColor = true;
            this.userControlTemplate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTemplate1.Location = new System.Drawing.Point(0, 0);
            this.userControlTemplate1.Name = "userControlTemplate1";
            this.userControlTemplate1.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.userControlTemplate1.Size = new System.Drawing.Size(531, 322);
            this.userControlTemplate1.TabIndex = 3;
            // 
            // frmLoadTemplate
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(531, 366);
            this.Controls.Add(this.userControlTemplate1);
            this.Controls.Add(this.panel2);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadTemplate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义模板";
            this.Load += new System.EventHandler(this.frmLoadTemplate_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void LoadTemplate()
        {
            string templateFile = this.m_TemplateFile;
            if (((templateFile != null) && (templateFile != "")) && (this.m_hookHelper.Hook is IPageLayoutControl3))
            {
                IMap focusMap = this.m_hookHelper.FocusMap;
                try
                {
                    IPageLayoutControl3 hook = this.m_hookHelper.Hook as IPageLayoutControl3;
                    IActiveView activeView = hook.ActiveView;
                    hook.LoadMxFile(templateFile, "");
                    hook.PageLayout = this.m_hookHelper.PageLayout;
                    IGraphicsContainer graphicsContainer = hook.GraphicsContainer;
                    graphicsContainer.Reset();
                    for (IElement element = graphicsContainer.Next(); element != null; element = graphicsContainer.Next())
                    {
                        if (element is IMapFrame)
                        {
                            IMapFrame frame = (IMapFrame) element;
                            frame.Map = focusMap;
                            this.SetMapSurroundFrameMap(hook.PageLayout, focusMap, activeView);
                        }
                    }
                    hook.ActiveView.Activate(hook.hWnd);
                    this.UpdateScaleText(hook, focusMap);
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "LoadTemplate", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        public void SetMapSurroundFrameMap(IPageLayout pPageLayout, IMap pMap, IActiveView pActiveView)
        {
            try
            {
                if (((pPageLayout != null) && (pMap != null)) && (pActiveView != null))
                {
                    IGraphicsContainer graphicsContainer = null;
                    graphicsContainer = pActiveView.GraphicsContainer;
                    if (graphicsContainer != null)
                    {
                        graphicsContainer.Reset();
                        for (IElement element = graphicsContainer.Next(); element != null; element = graphicsContainer.Next())
                        {
                            if (element is IMapSurroundFrame)
                            {
                                IMapSurroundFrame frame = element as IMapSurroundFrame;
                                frame.MapSurround.Map = pMap;
                            }
                            else if (element is IGroupElement)
                            {
                                this.SetMapSurroundFrameMapGroupRecursion(element as IGroupElement, pMap);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "SetMapSurroundFrameMap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetMapSurroundFrameMapGroupRecursion(IGroupElement pGroupElement, IMap pMap)
        {
            try
            {
                if (((pGroupElement != null) && (pGroupElement.ElementCount > 0)) && (pMap != null))
                {
                    IEnumElement elements = pGroupElement.Elements;
                    elements.Reset();
                    for (IElement element2 = elements.Next(); element2 != null; element2 = elements.Next())
                    {
                        if (element2 is IMapSurroundFrame)
                        {
                            IMapSurroundFrame frame = element2 as IMapSurroundFrame;
                            frame.MapSurround.Map = pMap;
                        }
                        else if (element2 is IGroupElement)
                        {
                            this.SetMapSurroundFrameMapGroupRecursion(element2 as IGroupElement, pMap);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "SetMapSurroundFrameMapGroupRecursion", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            this.m_TemplateFile = this.userControlTemplate1.CurrentTemplate;
            if (string.IsNullOrEmpty(this.m_TemplateFile))
            {
                MessageBox.Show("请选择模板。", "错误");
            }
            else if (!File.Exists(this.m_TemplateFile))
            {
                MessageBox.Show("地图模板文件（" + this.m_TemplateFile + "）不存在，请重新选择。", "错误");
            }
            else
            {
                try
                {
                    File.Delete(this.m_TemplateFile);
                }
                catch
                {
                    MessageBox.Show("删除出错！请确认文件未被占用。", "错误");
                    return;
                }
                this.userControlTemplate1.InitControls();
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            Cartography.Template.TemplateInfo.CurrentTemplateInfo = null;
            this.m_TemplateFile = this.userControlTemplate1.CurrentTemplate;
            if (string.IsNullOrEmpty(this.m_TemplateFile))
            {
                MessageBox.Show("请选择模板。", "错误");
            }
            else if (!File.Exists(this.m_TemplateFile))
            {
                MessageBox.Show("地图模板文件（" + this.m_TemplateFile + "）不存在，请重新选择。", "错误");
            }
            else
            {
                IPageLayoutControl3 hook = this.m_hookHelper.Hook as IPageLayoutControl3;
                this.TemplateCarto(hook, this.m_TemplateFile);
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void TemplateCarto(IPageLayoutControl3 pPageLayoutControl, string sTemplateFile)
        {
            try
            {
                IMap focusMap = pPageLayoutControl.ActiveView.FocusMap;
                pPageLayoutControl.LoadMxFile(sTemplateFile, "");
                IMapFrame frame = pPageLayoutControl.GraphicsContainer.FindFrame(pPageLayoutControl.ActiveView.FocusMap) as IMapFrame;
                frame.Map = focusMap;
                pPageLayoutControl.ActiveView.Activate(pPageLayoutControl.hWnd);
                pPageLayoutControl.ActiveView.FocusMap = focusMap;
                IGraphicsContainer pageLayout = pPageLayoutControl.PageLayout as IGraphicsContainer;
                pageLayout.Reset();
                for (IElement element2 = pageLayout.Next(); element2 != null; element2 = pageLayout.Next())
                {
                    if (element2 is IMapSurroundFrame)
                    {
                        IMapSurroundFrame frame2 = (IMapSurroundFrame) element2;
                        IMapSurround mapSurround = frame2.MapSurround;
                        if (mapSurround is ILegend)
                        {
                            ILegend legend = mapSurround as ILegend;
                            ILegendFormat format = legend.Format;
                            List<ILegendItem> list = new List<ILegendItem>();
                            for (int i = 0; i < legend.ItemCount; i++)
                            {
                                list.Add(legend.get_Item(i));
                            }
                            mapSurround.Map = focusMap;
                            legend.ClearItems();
                            foreach (ILegendItem item in list)
                            {
                                ILayer layer = this.FindFeatureLayer(focusMap, item.Layer as IFeatureLayer);
                                if (layer != null)
                                {
                                    item.Layer = layer;
                                    item.CreateGraphics(pPageLayoutControl.ActiveView.ScreenDisplay, legend.Format);
                                    legend.AddItem(item);
                                }
                            }
                            legend.Refresh();
                        }
                        else
                        {
                            mapSurround.Map = focusMap;
                        }
                    }
                }
                pPageLayoutControl.ZoomToWholePage();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "TemplateCart", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool UpdateLegend(IPageLayoutControl3 pPageLayoutControl, IMap pMap)
        {
            try
            {
                if (pPageLayoutControl == null)
                {
                    return false;
                }
                IMapSurroundFrame frame = (IMapSurroundFrame) pPageLayoutControl.FindElementByName("Legend", 1);
                if (frame == null)
                {
                    return false;
                }
                ILegend mapSurround = (ILegend) frame.MapSurround;
                mapSurround.Map = pMap;
                mapSurround.Refresh();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "UpdateLegend", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool UpdateScaleText(IPageLayoutControl3 pPageLayoutControl, IMap pMap)
        {
            try
            {
                if (pPageLayoutControl == null)
                {
                    return false;
                }
                IMapSurroundFrame frame = (IMapSurroundFrame) pPageLayoutControl.FindElementByName("Scale Text", 1);
                if (frame == null)
                {
                    return false;
                }
                IElement element = frame as IElement;
                IScaleText mapSurround = (IScaleText) frame.MapSurround;
                mapSurround.Map = pMap;
                IActiveView map = (IActiveView) frame.MapFrame.Map;
                element.Activate(map.ScreenDisplay);
                IEnvelope envelope = element.Geometry.Envelope;
                pPageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, envelope);
                mapSurround.Refresh();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Template.frmLoadTemplate", "UpdateScaleText", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public string TemplateFile
        {
            get
            {
                return this.m_TemplateFile;
            }
        }
    }
}

