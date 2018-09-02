namespace Print
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    internal struct NMHDR
    {
        [FieldOffset(8)]
        public ushort code;
        [FieldOffset(0)]
        public IntPtr hWndFrom;
        [FieldOffset(4)]
        public ushort idFrom;
    }
}

