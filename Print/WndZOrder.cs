namespace Print
{
    using System;

    internal class WndZOrder
    {
        public const uint HWND_BOTTOM = 1;
        public const uint HWND_NOTOPMOST = 0xfffffffe;
        public const uint HWND_TOP = 0;
        public const uint HWND_TOPMOST = uint.MaxValue;
    }
}

