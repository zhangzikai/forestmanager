namespace Print
{
    using System;
    using System.Drawing.Printing;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode), SecurityPermission(SecurityAction.Demand, Unrestricted=true)]
    internal struct PrinterDefaults
    {
        [MarshalAs(UnmanagedType.SysInt)]
        private IntPtr dDataType;
        [MarshalAs(UnmanagedType.SysInt)]
        private IntPtr dDeviceMode;
        [MarshalAs(UnmanagedType.U4)]
        public int DesiredAccess;
        internal PrinterDefaults(bool pAllAccess)
        {
            this.dDataType = IntPtr.Zero;
            this.dDeviceMode = IntPtr.Zero;
            if (pAllAccess)
            {
                new PrintingPermission(PermissionState.Unrestricted).Demand();
                this.DesiredAccess = 0xf000c;
            }
            else
            {
                this.DesiredAccess = 8;
            }
        }
    }
}

