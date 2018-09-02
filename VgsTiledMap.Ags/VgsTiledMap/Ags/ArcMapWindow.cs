namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Windows.Forms;

    public class ArcMapWindow : IWin32Window
    {
        private IApplication m_app;

        public ArcMapWindow(IApplication application)
        {
            this.m_app = application;
        }

        public IntPtr Handle
        {
            get
            {
                return new IntPtr(this.m_app.hWnd);
            }
        }
    }
}

