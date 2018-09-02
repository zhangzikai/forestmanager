namespace QueryCommon
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class PointTool : BaseTool
    {
        private const string mClassName = "PointTool";
        private IHookHelper mHookHelper;
        private UserControlInfo mMyParent;

        public PointTool()
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                base.m_caption = "得到点坐标";
                base.m_name = "PointTool";
                base.m_cursor = new Cursor(base.GetType(), "PointTool.cur");
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetCapture();
        public override void OnClick()
        {
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.mHookHelper.Hook = hook;
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseUp(int button, int shift, int x, int y)
        {
            try
            {
                if ((this.mHookHelper.ActiveView != null) && (button == Keys.LButton.GetHashCode()))
                {
                    IPoint point = null;
                    point = this.mHookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    this.mMyParent.PointLocation = point;
                }
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int ReleaseCapture();
        private void ResetTool()
        {
            try
            {
                if (this.mHookHelper.ActiveView.ScreenDisplay.hWnd == GetCapture())
                {
                    ReleaseCapture();
                }
                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            }
            catch (Exception)
            {
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int SetCapture(int hWnd);

        public override bool Enabled
        {
            get
            {
                try
                {
                    if (this.mHookHelper == null)
                    {
                        return false;
                    }
                    if (this.mHookHelper.FocusMap == null)
                    {
                        return false;
                    }
                    if (this.mHookHelper.FocusMap.LayerCount == 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public UserControl ParentForm
        {
            set
            {
                this.mMyParent = value as UserControlInfo;
            }
        }
    }
}

