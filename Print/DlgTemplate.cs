namespace Print
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal class DlgTemplate
    {
        public uint style = 0x44000504;
        public int extendedStyle = 0x10000;
        public short numItems = 1;
        public short x;
        public short y;
        public short cx;
        public short cy;
        public short reservedMenu;
        public short reservedClass;
        public short reservedTitle;
        public uint itemStyle = 0x40000000;
        public int itemExtendedStyle = 4;
        public short itemX;
        public short itemY;
        public short itemCx;
        public short itemCy;
        public short itemId;
        public ushort itemClassHdr = 0xffff;
        public short itemClass = 130;
        public short itemText;
        public short itemData;
    }
}

