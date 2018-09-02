namespace QueryCommon
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using LCTest;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [Guid("46657a18-a2d1-4aae-b574-c1b56bc7b1f1"), ProgId("QueryCommon.IdentifyTool"), ClassInterface(ClassInterfaceType.None)]
    public sealed class IdentifyTool : BaseTool
    {
        private AxMapControl axMapControl1;
        private bool flag;
        public static IdentifyFrom identifyFrom;
        private IHookHelper m_hookHelper;
        private Form MainForm;

        public IdentifyTool()
        {
            base.m_category = "identify";
            base.m_caption = "identify";
            base.m_message = "identify";
            base.m_toolTip = "identify";
            base.m_name = "identify";
            try
            {
                string resource = base.GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(base.GetType(), resource);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            ////base.m_cursor = new Cursor(base.GetType(), "IdentifyMDown.cur");
            ShowIdentifyDialog();
        }

        public override void OnCreate(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
            IntPtr handle = new IntPtr(this.m_hookHelper.ActiveView.ScreenDisplay.hWnd);
            this.axMapControl1 = Control.FromHandle(handle) as AxMapControl;
            this.MainForm = Control.FromHandle(handle).FindForm();
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if ((Button == 1) && !this.flag)
            {
                this.ShowIdentifyDialog();
                this.flag = true;
                IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                identifyFrom.OnMouseDown(Button, point.X, point.Y);
            }
            else if ((Button == 1) && this.flag)
            {
                if (identifyFrom.IsDisposed)
                {
                    this.ShowIdentifyDialog();
                }
                IPoint point2 = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                identifyFrom.OnMouseDown(Button, point2.X, point2.Y);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (null == identifyFrom) return;
            IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            identifyFrom.OnMouseMove(point.X, point.Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            identifyFrom.OnMouseUp(point.X, point.Y);
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        private void ShowIdentifyDialog()
        {
            identifyFrom = IdentifyFrom.CreateInstance(this.axMapControl1);
            identifyFrom.Owner = this.MainForm;
            identifyFrom.Show();
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

