namespace Print
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Output;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public sealed class PrintSetupDialogEx : IDisposable
    {
        private const int _CONTENT_PANEL_ID = 0x430;
        private IntPtr _ipTemplate;
        private IPageLayoutControl3 _pageLayoutControl;
        private const int _PANEL_GAP_FACTOR = 3;
        private Control _userControl;
        private const int EXT_DIALOG_PADDING = 160;
        private const int ID_CANCEL = 2;
        private const int ID_PROPERTY = 0x401;
        private const int IDOK = 1;
        private bool IsPro;
        private bool m_bShowNetwork;
        private bool m_bTopMost;
        private bool m_bUseEXDialog;
        private IntPtr m_hParent;
        private IntPtr m_nHandle;
        private int m_normalHeight;
        private int m_normalLeft;
        private int m_normalTop;
        private int m_normalWidth;
        private Rectangle m_oDefaultArea;
        private PrintDocument m_oPrintDoc;
        private ArrayList m_oResourceList;
        private string m_sRegistryPath;
        private PrinterSet set;

        public event WindowStateDelegate LoadStateEvent;

        public event WindowStateDelegate SaveStateEvent;

        public PrintSetupDialogEx()
        {
            this._ipTemplate = IntPtr.Zero;
            this.set = new PrinterSet();
            this.m_oResourceList = new ArrayList();
            this.m_sRegistryPath = @"Software\ZLDX_LC\PrintSetupDialogEx";
        }

        public PrintSetupDialogEx(PrintSetupDialogEx oPrintDlg) : this()
        {
            this.UseEXDialog = oPrintDlg.UseEXDialog;
            this.ShowNetwork = oPrintDlg.ShowNetwork;
            this.TopMost = oPrintDlg.TopMost;
            this.Parent = oPrintDlg.Parent;
        }

        private void ChangeEsriPage(string pId)
        {
            StringBuilder lpString = new StringBuilder(100);
            if (Win32.GetDlgItemText(this.Handle, 0x471, lpString, 100) == 0)
            {
                MessageBox.Show("无法获取打印机纸张大小!");
            }
            else
            {
                this.set.FormName = lpString.ToString();
            }
            lpString.Remove(0, lpString.Length);
            if (Win32.GetDlgItemText(this.Handle, 0x470, lpString, 100) == 0)
            {
                MessageBox.Show("无法获取打印机!");
            }
            else
            {
                this.set.PrinterName = lpString.ToString();
            }
            lpString.Remove(0, lpString.Length);
            if (Win32.GetDlgItemText(this.Handle, 0x44d, lpString, 100) == 0)
            {
                MessageBox.Show("无法获取位置信息!");
            }
            else
            {
                this.set.PortName = lpString.ToString();
            }
            int num = Win32.IsDlgButtonChecked(this.Handle, 0x420);
            if ((pId == "420") || (pId == "421"))
            {
                if (num == 0)
                {
                    this.set.OrienTation = 1;
                }
                else
                {
                    this.set.OrienTation = 2;
                }
            }
            else if (num == 1)
            {
                this.set.OrienTation = 1;
            }
            else
            {
                this.set.OrienTation = 2;
            }
            ESRIPage page = this._userControl as ESRIPage;
            page.PrinterSet = this.set;
            page.ChangeControl(this.set);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            Marshal.FreeCoTaskMem(this._ipTemplate);
            for (int i = 0; i < this.m_oResourceList.Count; i++)
            {
                IntPtr hwnd = (IntPtr) this.m_oResourceList[i];
                Win32.DestroyWindow(hwnd);
            }
            this.m_oResourceList.Clear();
        }

        ~PrintSetupDialogEx()
        {
            this.Dispose(false);
        }

        private bool GetDlgRect(IntPtr hWnd, ref Rectangle lpRect)
        {
            try
            {
                Print.POINT point;
                Print.POINT point2;
                Print.RECT rc = new Print.RECT();
                Win32.GetWindowRect(hWnd, ref rc);
                point.X = rc.left;
                point.Y = rc.top;
                Win32.ScreenToClient(this.Parent, ref point);
                point2.X = rc.right;
                point2.Y = rc.bottom;
                Win32.ScreenToClient(this.Parent, ref point2);
                lpRect.Width = point2.X - point.X;
                lpRect.Height = point2.Y - point.Y;
                lpRect.X = (Screen.PrimaryScreen.WorkingArea.Width - lpRect.Width) / 2;
                lpRect.Y = (Screen.PrimaryScreen.WorkingArea.Height - lpRect.Height) / 2;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Control GetESRIPanel()
        {
            if (this._userControl == null)
            {
                this._userControl = new ESRIPage();
                ESRIPage page = this._userControl as ESRIPage;
                page.Control = this._pageLayoutControl;
                page.PrinterSet = this.set;
                page.InitControl();
            }
            return this._userControl;
        }

        private bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect)
        {
            try
            {
                Print.POINT point;
                Print.POINT point2;
                Print.RECT rc = new Print.RECT();
                Win32.GetWindowRect(hWnd, ref rc);
                IntPtr ptr = (hWnd != this.Handle) ? this.Handle : this.Parent;
                point.X = rc.left;
                point.Y = rc.top;
                Win32.ScreenToClient(ptr, ref point);
                point2.X = rc.right;
                point2.Y = rc.bottom;
                Win32.ScreenToClient(ptr, ref point2);
                lpRect.X = point.X;
                lpRect.Width = point2.X - point.X;
                lpRect.Y = point.Y;
                lpRect.Height = point2.Y - point.Y;
                return true;
            }
            catch
            {
                return false;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern int GlobalFree(IntPtr hMem);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        private static extern bool GlobalUnlock(IntPtr hMem);
        private void InitExtendedControls(IntPtr hPrintDlgWnd)
        {
            Rectangle lpRect = new Rectangle();
            IntPtr dlgItem = Win32.GetDlgItem(hPrintDlgWnd, 1);
            if (this.GetWindowRect(dlgItem, ref lpRect))
            {
                Win32.MoveWindow(dlgItem, lpRect.X, lpRect.Y + 160, lpRect.Width, lpRect.Height, true);
            }
            IntPtr hWnd = Win32.GetDlgItem(hPrintDlgWnd, 2);
            if (this.GetWindowRect(hWnd, ref lpRect))
            {
                Win32.MoveWindow(hWnd, lpRect.X, lpRect.Y + 160, lpRect.Width, lpRect.Height, true);
            }
            Rectangle rectangle2 = new Rectangle();
            IntPtr ptr3 = Win32.GetDlgItem(hPrintDlgWnd, 0x433);
            this.GetWindowRect(ptr3, ref rectangle2);
            IntPtr ptr4 = Win32.GetDlgItem(hPrintDlgWnd, 0x431);
            this.GetWindowRect(ptr4, ref lpRect);
            Win32.MoveWindow(this._userControl.Handle, lpRect.X, lpRect.Bottom + 5, rectangle2.Width, 160, true);
        }

        internal DialogResult InvokePrintDlg(PrinterSettings printerSettings)
        {
            PRINTDLG structure = new PRINTDLG();
            structure.lStructSize = Marshal.SizeOf(structure);
            structure.hwndOwner = this.Parent;
            printerSettings.GetHdevmode();
            IntPtr hdevmode = printerSettings.GetHdevmode(printerSettings.DefaultPageSettings);
            structure.hDevMode = GlobalLock(hdevmode);
            IntPtr hdevnames = printerSettings.GetHdevnames();
            structure.hDevNames = GlobalLock(hdevnames);
            structure.Flags = 0x2008;
            this.setFlag(ref structure.Flags, 0x200000, !this.ShowNetwork);
            this.setFlag(ref structure.Flags, 0x40, true);
            structure.lpfnSetupHook = new SetupHookProc(this.PrintHookProcImpl);
            this.OnLoad(null, null);
            bool flag = PrintDlg(structure);
            printerSettings.SetHdevmode(structure.hDevMode);
            printerSettings.SetHdevnames(structure.hDevNames);
            GlobalUnlock(hdevmode);
            GlobalUnlock(hdevnames);
            GlobalFree(hdevmode);
            GlobalFree(hdevnames);
            this.OnClosing(null, null);
            if (!flag)
            {
                return DialogResult.Cancel;
            }
            return DialogResult.OK;
        }

        private ushort LowWord(uint val)
        {
            return (ushort) val;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(this.m_sRegistryPath);
            key.SetValue("Left", this.m_normalLeft);
            key.SetValue("Top", this.m_normalTop);
            key.SetValue("Width", this.m_normalWidth);
            key.SetValue("Height", this.m_normalHeight);
            if (this.SaveStateEvent != null)
            {
                this.SaveStateEvent(this, key);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(this.m_sRegistryPath);
            if (key != null)
            {
                Rectangle defaultArea = this.DefaultArea;
                if (defaultArea.IsEmpty)
                {
                    this.m_normalLeft = (int) key.GetValue("Left", 0);
                    this.m_normalTop = (int) key.GetValue("Top", 0);
                    this.m_normalWidth = (int) key.GetValue("Width", 0);
                    this.m_normalHeight = (int) key.GetValue("Height", 0);
                }
                else
                {
                    this.m_normalLeft = defaultArea.Left;
                    this.m_normalTop = defaultArea.Top;
                    this.m_normalWidth = defaultArea.Width;
                    this.m_normalHeight = defaultArea.Height;
                }
                if (this.LoadStateEvent != null)
                {
                    this.LoadStateEvent(this, key);
                }
            }
        }

        private void OnMove(object sender, EventArgs e)
        {
            Print.RECT rc = new Print.RECT();
            if (Win32.GetWindowRect(this.Handle, ref rc))
            {
                this.m_normalLeft = rc.left;
                this.m_normalTop = rc.top;
            }
        }

        [DllImport("comdlg32.dll", CharSet=CharSet.Auto)]
        private static extern bool PrintDlg([In, Out] PRINTDLG lppd);
        internal IntPtr PrintHookProcImpl(IntPtr hPrintDlgWnd, ushort msg, int wParam, int lParam)
        {
            uint num2;
            ushort num3;
            string pId = Convert.ToString((int) this.LowWord((uint) wParam), 0x10);
            switch (msg)
            {
                case 2:
                    this.Dispose(true);
                    goto Label_01E2;

                case 3:
                    if (this.DefaultArea.IsEmpty)
                    {
                        this.OnMove(null, null);
                    }
                    return IntPtr.Zero;

                case 0x4e:
                    if ((this._userControl != null) && this.IsPro)
                    {
                        this.ChangeEsriPage(pId);
                    }
                    return IntPtr.Zero;

                case 0x110:
                {
                    this.Handle = hPrintDlgWnd;
                    num2 = this.TopMost ? uint.MaxValue : 0;
                    num3 = WndPos.SWP_SHOWWINDOW;
                    Rectangle defaultArea = this.DefaultArea;
                    if (defaultArea.IsEmpty)
                    {
                        this.GetDlgRect(this.Handle, ref defaultArea);
                        this.m_normalLeft = defaultArea.Left;
                        this.m_normalTop = defaultArea.Top;
                        this.m_normalWidth = defaultArea.Width;
                        this.m_normalHeight = defaultArea.Height;
                        break;
                    }
                    this.m_normalLeft = defaultArea.Left;
                    this.m_normalTop = defaultArea.Top;
                    this.m_normalWidth = defaultArea.Width;
                    this.m_normalHeight = defaultArea.Height;
                    break;
                }
                case 0x111:
                    if (pId != "401")
                    {
                        this.IsPro = false;
                    }
                    else
                    {
                        this.IsPro = true;
                    }
                    if (this._userControl != null)
                    {
                        this.ChangeEsriPage(pId);
                    }
                    return IntPtr.Zero;

                default:
                    goto Label_01E2;
            }
            if (this.m_bUseEXDialog)
            {
                this.m_normalHeight += 160;
            }
            Win32.SetWindowPos(this.Handle, num2, this.m_normalLeft, this.m_normalTop, this.m_normalWidth, this.m_normalHeight, num3);
            if (this.m_bUseEXDialog)
            {
                this._userControl = this.GetESRIPanel();
                if (this._userControl != null)
                {
                    Win32.SetParent(this._userControl.Handle, this.Handle);
                }
                this.InitExtendedControls(hPrintDlgWnd);
            }
        Label_01E2:
            return IntPtr.Zero;
        }

        private bool setFlag(ref int nFlag, int nValue, bool bSet)
        {
            bool flag = true;
            try
            {
                if (bSet)
                {
                    nFlag |= nValue;
                    return flag;
                }
                nFlag &= ~nValue;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public DialogResult ShowDialog()
        {
            DialogResult cancel = DialogResult.Cancel;
            PrinterSettings printerSettings = this.m_oPrintDoc.PrinterSettings;
            PrinterResolution printerResolution = printerSettings.DefaultPageSettings.PrinterResolution;
            cancel = this.InvokePrintDlg(printerSettings);
            if (cancel == DialogResult.OK)
            {
                ESRIPage page = this._userControl as ESRIPage;
                if (page != null)
                {
                    IPaper paper = new PaperClass();
                    paper.Attach(this.m_oPrintDoc.PrinterSettings.GetHdevmode(this.m_oPrintDoc.DefaultPageSettings).ToInt32(), this.m_oPrintDoc.PrinterSettings.GetHdevnames().ToInt32());
                    this._pageLayoutControl.Printer.Paper = paper;
                    MapPageSet mapPageSet = page.MapPageSet;
                    if ((mapPageSet.ID == esriPageFormID.esriPageFormCUSTOM) || (mapPageSet.ID == esriPageFormID.esriPageFormSameAsPrinter))
                    {
                        this._pageLayoutControl.Page.PutCustomSize(mapPageSet.Width, mapPageSet.Height);
                    }
                    this._pageLayoutControl.Page.FormID = mapPageSet.ID;
                    this._pageLayoutControl.Page.Orientation = mapPageSet.OrienTation;
                    this._pageLayoutControl.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
                }
            }
            this._pageLayoutControl.ActiveView.PrinterChanged(this._pageLayoutControl.Printer);
            this._pageLayoutControl.PageLayout.ZoomToWhole();
            return cancel;
        }

        public Rectangle DefaultArea
        {
            get
            {
                return this.m_oDefaultArea;
            }
            set
            {
                this.m_oDefaultArea = value;
            }
        }

        public PrintDocument Document
        {
            get
            {
                return this.m_oPrintDoc;
            }
            set
            {
                this.m_oPrintDoc = value;
            }
        }

        public IntPtr Handle
        {
            get
            {
                return this.m_nHandle;
            }
            set
            {
                this.m_nHandle = value;
            }
        }

        public IPageLayoutControl3 PageLayoutControl
        {
            set
            {
                this._pageLayoutControl = value;
            }
        }

        public IntPtr Parent
        {
            get
            {
                return this.m_hParent;
            }
            set
            {
                this.m_hParent = value;
            }
        }

        public bool ShowNetwork
        {
            get
            {
                return this.m_bShowNetwork;
            }
            set
            {
                this.m_bShowNetwork = value;
            }
        }

        public bool TopMost
        {
            get
            {
                return this.m_bTopMost;
            }
            set
            {
                this.m_bTopMost = value;
            }
        }

        public bool UseEXDialog
        {
            get
            {
                return this.m_bUseEXDialog;
            }
            set
            {
                this.m_bUseEXDialog = value;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto, Pack=1), ComVisible(false)]
        internal class PRINTDLG
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hDevMode;
            public IntPtr hDevNames;
            public IntPtr hDC = IntPtr.Zero;
            public int Flags;
            public short FromPage;
            public short ToPage;
            public short MinPage;
            public short MaxPage;
            public short Copies;
            public IntPtr hInstance = IntPtr.Zero;
            public IntPtr lCustData = IntPtr.Zero;
            public PrintSetupDialogEx.PrintHookProc lpfnPrintHook;
            public PrintSetupDialogEx.SetupHookProc lpfnSetupHook;
            public IntPtr lpPrintTemplateName = IntPtr.Zero;
            public IntPtr lpSetupTemplateName = IntPtr.Zero;
            public IntPtr hPrintTemplate = IntPtr.Zero;
            public IntPtr hSetupTemplate = IntPtr.Zero;
        }

        internal class PrintFlag
        {
            public const int PD_ALLPAGES = 0;
            public const int PD_COLLATE = 0x10;
            public const int PD_DISABLEPRINTTOFILE = 0x80000;
            public const int PD_ENABLEPRINTHOOK = 0x1000;
            public const int PD_ENABLEPRINTTEMPLATE = 0x4000;
            public const int PD_ENABLEPRINTTEMPLATEHANDLE = 0x10000;
            public const int PD_ENABLESETUPHOOK = 0x2000;
            public const int PD_ENABLESETUPTEMPLATE = 0x8000;
            public const int PD_ENABLESETUPTEMPLATEHANDLE = 0x20000;
            public const int PD_HIDEPRINTTOFILE = 0x100000;
            public const int PD_NONETWORKBUTTON = 0x200000;
            public const int PD_NOPAGENUMS = 8;
            public const int PD_NOSELECTION = 4;
            public const int PD_NOWARNING = 0x80;
            public const int PD_PAGENUMS = 2;
            public const int PD_PRINTSETUP = 0x40;
            public const int PD_PRINTTOFILE = 0x20;
            public const int PD_RETURNDC = 0x100;
            public const int PD_RETURNDEFAULT = 0x400;
            public const int PD_RETURNIC = 0x200;
            public const int PD_SELECTION = 1;
            public const int PD_SHOWHELP = 0x800;
            public const int PD_USEDEVMODECOPIES = 0x40000;
            public const int PD_USEDEVMODECOPIESANDCOLLATE = 0x40000;
        }

        internal delegate IntPtr PrintHookProc(IntPtr hWnd, ushort msg, int wParam, int lParam);

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto, Pack=1), ComVisible(false)]
        internal class PRINTPAGERANGE
        {
            public int nFromPage;
            public int nToPage;
        }

        internal delegate IntPtr SetupHookProc(IntPtr hWnd, ushort msg, int wParam, int lParam);

        public delegate void WindowStateDelegate(object sender, RegistryKey key);
    }
}

