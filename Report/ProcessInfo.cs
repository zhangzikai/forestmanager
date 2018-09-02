namespace Report
{
    using System;
    using System.Diagnostics;
    using System.Management;

    internal class ProcessInfo
    {
        public static bool CheckParentProcess(int pID)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ProcessID=" + pID);
            ManagementObjectCollection objects = searcher.Get();
            new ManagementOperationObserver();
            bool flag = false;
            foreach (ManagementObject obj2 in objects)
            {
                object obj3 = obj2["ParentProcessID"];
                if ((obj3 != null) && (Process.GetProcessById(int.Parse(obj3.ToString())).ProcessName == "svchost"))
                {
                    flag = true;
                    break;
                }
            }
            searcher.Dispose();
            searcher = null;
            objects.Dispose();
            objects = null;
            return flag;
        }
    }
}

