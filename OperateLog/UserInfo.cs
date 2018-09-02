namespace OperateLog
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct UserInfo
    {
        public static string UserID;
        public static string UserName;
        public static string DistCode;
        public static bool IsManager;
        static UserInfo()
        {
            UserID = "";
            UserName = "";
            DistCode = "";
            IsManager = false;
        }
    }
}

