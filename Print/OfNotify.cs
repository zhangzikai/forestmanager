namespace Print
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    internal struct OfNotify
    {
        [FieldOffset(0)]
        public NMHDR hdr;
        [FieldOffset(0x10)]
        public IntPtr ipFile;
        [FieldOffset(12)]
        public IntPtr ipOfn;
    }
}

