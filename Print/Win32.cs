namespace Print
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Win32
    {
        [DllImport("ComDlg32.dll", CharSet=CharSet.Unicode)]
        internal static extern int CommDlgExtendedError();
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        internal static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int hMenu, int hInstance, int lpParam);
        [DllImport("user32.dll")]
        internal static extern bool DestroyWindow(IntPtr hwnd);
        [DllImport("winspool.drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        internal static extern int DeviceCapabilitiesW(string sDevice, string Port, int fwCapability, IntPtr Output, IntPtr device);
        [DllImport("user32.Dll")]
        internal static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpEnumFunc, int lParam);
        [DllImport("user32.Dll")]
        internal static extern int EnumWindows(CallBack x, int y);
        [DllImport("User32.Dll")]
        internal static extern void GetClassName(int h, StringBuilder s, int nMaxCount);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern int GetClientRect(IntPtr hWnd, ref RECT rc);
        [DllImport("User32.dll", CharSet=CharSet.Unicode)]
        internal static extern IntPtr GetDlgItem(IntPtr hWndDlg, short Id);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern int GetDlgItemText(IntPtr hDlg, int nIDDlgItem, [Out] StringBuilder lpString, int nMaxCount);
        [DllImport("User32.dll", CharSet=CharSet.Unicode)]
        internal static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rc);
        [DllImport("User32.Dll")]
        internal static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern int IsDlgButtonChecked(IntPtr hDlg, int nIDDlgItem);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern int LOWORD(int dwValue);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool repaint);
        [DllImport("User32.Dll")]
        internal static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);
        [DllImport("User32.dll", CharSet=CharSet.Unicode)]
        internal static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, StringBuilder buffer);
        [DllImport("user32.dll")]
        internal static extern uint SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
        [DllImport("User32.dll", CharSet=CharSet.Unicode)]
        internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern bool SetWindowPos(IntPtr hWnd, uint hWndInsertAfter, int X, int Y, int Width, int Height, ushort uFlags);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        internal static extern bool SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}

