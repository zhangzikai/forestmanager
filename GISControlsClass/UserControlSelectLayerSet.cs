namespace GISControlsClass
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlSelectLayerSet : UserControlBase1
    {
        internal Button ButtonClose;
        private CheckedListBoxControl clstLayers;
        private IContainer components;
        private ImageList imageList1;
        private Label label1;
        internal Label LabelExplain;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "QueryAnalysic.SelectionLayerSet";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IHookHelper mHookHelper;
        private ArrayList mLayerColn;
        private bool mSelecting;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "设置图层可见";
        internal Panel PanelButton;
        internal Panel PanelSample;
        private SimpleButton simpleButtonSelectAll;
        private SimpleButton simpleButtonSelectClear;

        public UserControlSelectLayerSet()
        {
            this.InitializeComponent();
        }

        private void ButtonSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetAllSelectState(true);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "ButtonSelectAll_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ButtonSelectClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetAllSelectState(false);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "ButtonSelectClear_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void clstLayers_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (!this.mSelecting)
                {
                    IFeatureLayer layer = null;
                    layer = this.mLayerColn[e.Index] as IFeatureLayer;
                    layer.Selectable = e.State == CheckState.Checked;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "clstLayers_ItemCheck", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlSelectLayerSet));
            this.PanelButton = new Panel();
            this.simpleButtonSelectClear = new SimpleButton();
            this.simpleButtonSelectAll = new SimpleButton();
            this.ButtonClose = new Button();
            this.PanelSample = new Panel();
            this.label1 = new Label();
            this.imageList1 = new ImageList(this.components);
            this.LabelExplain = new Label();
            this.clstLayers = new CheckedListBoxControl();
            this.PanelButton.SuspendLayout();
            this.PanelSample.SuspendLayout();
            ((ISupportInitialize) this.clstLayers).BeginInit();
            base.SuspendLayout();
            this.PanelButton.Controls.Add(this.simpleButtonSelectClear);
            this.PanelButton.Controls.Add(this.simpleButtonSelectAll);
            this.PanelButton.Controls.Add(this.ButtonClose);
            this.PanelButton.Dock = DockStyle.Bottom;
            this.PanelButton.Location = new Point(5, 0x183);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Padding = new Padding(12, 0, 0, 0);
            this.PanelButton.Size = new Size(0xf3, 40);
            this.PanelButton.TabIndex = 5;
            this.simpleButtonSelectClear.Location = new Point(0xa3, 9);
            this.simpleButtonSelectClear.Name = "simpleButtonSelectClear";
            this.simpleButtonSelectClear.Size = new Size(80, 0x1a);
            this.simpleButtonSelectClear.TabIndex = 5;
            this.simpleButtonSelectClear.Text = "清空(&C)";
            this.simpleButtonSelectClear.Click += new EventHandler(this.ButtonSelectClear_Click);
            this.simpleButtonSelectAll.Location = new Point(0x4d, 9);
            this.simpleButtonSelectAll.Name = "simpleButtonSelectAll";
            this.simpleButtonSelectAll.Size = new Size(80, 0x1a);
            this.simpleButtonSelectAll.TabIndex = 4;
            this.simpleButtonSelectAll.Text = "全选(&S)";
            this.simpleButtonSelectAll.Click += new EventHandler(this.ButtonSelectAll_Click);
            this.ButtonClose.DialogResult = DialogResult.OK;
            this.ButtonClose.Location = new Point(12, 14);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new Size(60, 0x1a);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "关闭";
            this.ButtonClose.Visible = false;
            this.PanelSample.AutoScrollMargin = new Size(100, 100);
            this.PanelSample.Controls.Add(this.label1);
            this.PanelSample.Controls.Add(this.LabelExplain);
            this.PanelSample.Dock = DockStyle.Top;
            this.PanelSample.Location = new Point(5, 5);
            this.PanelSample.Name = "PanelSample";
            this.PanelSample.Size = new Size(0xf3, 0x3d);
            this.PanelSample.TabIndex = 3;
            this.label1.Dock = DockStyle.Top;
            this.label1.ImageAlign = ContentAlignment.MiddleLeft;
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xf3, 0x17);
            this.label1.TabIndex = 4;
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "select000.bmp");
            this.LabelExplain.Dock = DockStyle.Bottom;
            this.LabelExplain.Location = new Point(0, 0x15);
            this.LabelExplain.Name = "LabelExplain";
            this.LabelExplain.Size = new Size(0xf3, 40);
            this.LabelExplain.TabIndex = 0;
            this.LabelExplain.Text = "选择哪个图层可以使用要素选择工具，图形选择和编辑工具等进行交互性选择。";
            this.clstLayers.CheckOnClick = true;
            this.clstLayers.Dock = DockStyle.Fill;
            this.clstLayers.Location = new Point(5, 0x42);
            this.clstLayers.Name = "clstLayers";
            this.clstLayers.Size = new Size(0xf3, 0x141);
            this.clstLayers.TabIndex = 6;
            this.clstLayers.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.clstLayers_ItemCheck);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.clstLayers);
            base.Controls.Add(this.PanelButton);
            base.Controls.Add(this.PanelSample);
            base.Name = "UserControlSelectLayerSet";
            base.Padding = new Padding(5, 5, 5, 5);
            base.Size = new Size(0xfd, 0x1b0);
            this.PanelButton.ResumeLayout(false);
            this.PanelSample.ResumeLayout(false);
            ((ISupportInitialize) this.clstLayers).EndInit();
            base.ResumeLayout(false);
        }

        public void InitialValue()
        {
            try
            {
                this.clstLayers.Items.Clear();
                this.mLayerColn = null;
                this.mLayerColn = new ArrayList();
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IEnumLayer layer = null;
                    try
                    {
                        UID uid = new UIDClass();
                        uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
                        layer = this.mHookHelper.FocusMap.get_Layers(uid, true);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    layer.Reset();
                    this.mSelecting = true;
                    IFeatureLayer layer2 = null;
                    int num = 0;
                    ILayer layer3 = null;
                    for (layer3 = layer.Next(); layer3 != null; layer3 = layer.Next())
                    {
                        if (layer3 is IFeatureLayer)
                        {
                            layer2 = layer3 as IFeatureLayer;
                            this.clstLayers.Items.Add(layer2.Name, layer2.Selectable);
                            this.mLayerColn.Add(layer2);
                            num++;
                        }
                    }
                    this.mSelecting = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mActiveViewEvents_ItemAdded(object Item)
        {
            try
            {
                this.InitialValue();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "mActiveViewEvents_ItemAdded", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void mActiveViewEvents_ItemDeleted(object Item)
        {
            try
            {
                this.InitialValue();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "mActiveViewEvents_ItemDeleted", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetAllSelectState(bool bChecked)
        {
            try
            {
                this.mSelecting = false;
                this.clstLayers.SelectedIndex = -1;
                int index = 0;
                for (index = 0; index <= (this.clstLayers.Items.Count - 1); index++)
                {
                    this.clstLayers.SetItemChecked(index, bChecked);
                }
                foreach (IFeatureLayer layer in this.mLayerColn)
                {
                    layer.Selectable = bChecked;
                }
                this.mSelecting = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "SetAllSelectState", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void UserControlSelectionLayerSet_Closed(object sender, EventArgs e)
        {
            this.mHookHelper = null;
            this.mLayerColn = null;
            this.mActiveViewEvents = null;
        }

        public object Hook
        {
            get
            {
                if (this.mHookHelper != null)
                {
                    return this.mHookHelper.Hook;
                }
                return null;
            }
            set
            {
                try
                {
                    this.mHookHelper = new HookHelperClass();
                    if (value != null)
                    {
                        this.mHookHelper.Hook = value;
                        if (this.mHookHelper.FocusMap != null)
                        {
                            this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.SelectionLayerSet", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }
    }
}

