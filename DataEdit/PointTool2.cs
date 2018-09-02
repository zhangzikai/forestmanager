namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class PointTool2 : BaseTool
    {
        private const string mClassName = "PointTool";
        private IHookHelper mHookHelper;
        private UserControlImageGeoReference2 mMyParent;
        private double mX = 0.0;
        private double mY = 0.0;

        public PointTool2()
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
            try
            {
            }
            catch (Exception)
            {
            }
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
                    FormXY mxy = new FormXY();
                    mxy.Left = (this.mMyParent.Width + 8) + x;
                    mxy.Top = ((this.mMyParent.Parent.Top + this.mMyParent.Parent.Parent.Parent.Top) + 50) + y;
                    if ((this.mX > 0.0) && (this.mY > 0.0))
                    {
                        mxy.SetXY(this.mX, this.mY);
                    }
                    mxy.ShowDialog();
                    this.mMyParent.PointLocation = point;
                    this.mMyParent.PointLocation2(mxy.X, mxy.Y);
                    mxy.Close();
                    mxy = null;
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
                this.mMyParent = value as UserControlImageGeoReference2;
            }
        }

        public double X
        {
            set
            {
                this.mX = value;
            }
        }

        public double Y
        {
            set
            {
                this.mY = value;
            }
        }
    }
}

