namespace OperateLog
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct LogType
    {
        public static string SystemType;
        static LogType()
        {
            SystemType = "";
        }
    }
}

