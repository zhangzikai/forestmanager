namespace Print
{
    using System;
    using System.Runtime.CompilerServices;

    internal delegate IntPtr OfnHookProc(IntPtr hWnd, ushort msg, int wParam, int lParam);
}

