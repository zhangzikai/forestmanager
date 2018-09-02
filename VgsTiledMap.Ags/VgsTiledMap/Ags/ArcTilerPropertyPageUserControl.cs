namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ProgId("ArcTilerPropertyPageUserControl"), ClassInterface(ClassInterfaceType.None), Guid("CAB70B8E-A0CD-40F4-9295-E56D85A2A2B2")]
    public class ArcTilerPropertyPageUserControl : UserControl, IComPropertyPage
    {
        private VgsArcTileLayer arcTilerLayer;
        private System.Windows.Forms.Button button1;
        private IContainer components;
        private GroupBox groupBox2 = new GroupBox();
        private bool isPageDirty;
        private IActiveView m_activeView;
        private IComPropertyPageSite m_pageSite;
        private string m_pageTitle;
        private int m_priority;

        public ArcTilerPropertyPageUserControl()
        {
            this.InitializeComponent();
            this.m_pageTitle = "Tiles";
        }

        public int Activate()
        {
            return base.Handle.ToInt32();
        }

        public bool Applies(ISet objects)
        {
            if ((objects != null) && (objects.Count != 0))
            {
                object obj2;
                objects.Reset();
                while ((obj2 = objects.Next()) != null)
                {
                    if (obj2 is VgsArcTileLayer)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Apply()
        {
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            LayerPropertyPages.Register(cLSID);
            SxLayerPropertyPages.Register(cLSID);
            GMxLayerPropertyPages.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            LayerPropertyPages.Unregister(cLSID);
            SxLayerPropertyPages.Unregister(cLSID);
            GMxLayerPropertyPages.Unregister(cLSID);
        }

        private void ArcTilerPropertyPageUserControl_Load(object sender, EventArgs e)
        {
        }

        public void Cancel()
        {
            if (this.isPageDirty)
            {
                this.SetPageDirty(false);
            }
        }

        public void Deactivate()
        {
            this.arcTilerLayer = null;
            this.m_activeView = null;
            this.Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        void IComPropertyPage.Hide()
        {
            base.Hide();
        }

        void IComPropertyPage.Show()
        {
            base.Show();
        }

        public int get_HelpContextID(int controlID)
        {
            return 0;
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new Point(3, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x115, 0x58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "缓存...";
            this.button1.Enabled = false;
            this.button1.Location = new Point(0x16, 30);
            this.button1.Name = "button1";
            this.button1.Size = new Size(220, 0x15);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clear VgsTiledMap.Ags cache";
            this.button1.UseVisualStyleBackColor = true;
            base.Controls.Add(this.groupBox2);
            base.Name = "ArcTilerPropertyPageUserControl";
            base.Size = new Size(0x12d, 0x103);
            base.Load += new EventHandler(this.ArcTilerPropertyPageUserControl_Load);
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void rdbBing_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPageDirty(true);
        }

        private void rdbEsri_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPageDirty(true);
        }

        private void rdbGeodan_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPageDirty(true);
        }

        private void rdbOsm_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPageDirty(true);
        }

        private void rdbTMS_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPageDirty(true);
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        public void SetObjects(ISet objects)
        {
            if ((objects != null) && (objects.Count != 0))
            {
                object obj2;
                this.m_activeView = null;
                this.arcTilerLayer = null;
                objects.Reset();
                while ((obj2 = objects.Next()) != null)
                {
                    if (obj2 is VgsArcTileLayer)
                    {
                        this.arcTilerLayer = obj2 as VgsArcTileLayer;
                    }
                    else if (obj2 is IActiveView)
                    {
                        this.m_activeView = obj2 as IActiveView;
                    }
                }
            }
        }

        private void SetPageDirty(bool dirty)
        {
            if (this.isPageDirty != dirty)
            {
                this.isPageDirty = dirty;
                if (this.m_pageSite != null)
                {
                    this.m_pageSite.PageChanged();
                }
            }
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        [DispId(0x60010005)]
        int IComPropertyPage.Height
        {
            get
            {
                return base.Height;
            }
        }

        [DispId(0x60010004)]
        int IComPropertyPage.Width
        {
            get
            {
                return base.Width;
            }
        }

        public string HelpFile
        {
            get
            {
                return string.Empty;
            }
        }

        public bool IsPageDirty
        {
            get
            {
                return this.isPageDirty;
            }
        }

        public IComPropertyPageSite PageSite
        {
            set
            {
                this.m_pageSite = value;
            }
        }

        public int Priority
        {
            get
            {
                return this.m_priority;
            }
            set
            {
                this.m_priority = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_pageTitle;
            }
            set
            {
                this.m_pageTitle = value;
            }
        }
    }
}

