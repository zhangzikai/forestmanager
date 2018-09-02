namespace Print
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Runtime.InteropServices;

    internal class DeviceService
    {
        private static Collection<int> GetDeviceCapabilities(string pPinterName, string pPortName, DeviceCapabilities pDc, PtrType pType)
        {
            Collection<int> collection = new Collection<int>();
            int num = Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, IntPtr.Zero, IntPtr.Zero);
            if (num > 0)
            {
                int num2;
                switch (pType)
                {
                    case PtrType.SHORT:
                        num2 = 2;
                        break;

                    case PtrType.LONG:
                        num2 = 8;
                        break;

                    default:
                        num2 = 4;
                        break;
                }
                IntPtr output = Marshal.AllocCoTaskMem(num2 * num);
                Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, output, IntPtr.Zero);
                for (int i = 0; i < num; i++)
                {
                    switch (pType)
                    {
                        case PtrType.SHORT:
                            collection.Add(Marshal.ReadInt16(output, num2 * i));
                            break;

                        case PtrType.INTEGER:
                            collection.Add(Marshal.ReadInt32(output, num2 * i));
                            break;

                        case PtrType.LONG:
                            collection.Add((int) Marshal.ReadInt64(output, num2 * i));
                            break;
                    }
                }
                Marshal.FreeCoTaskMem(output);
            }
            return collection;
        }

        private static StringCollection GetDeviceCapabilities(string pPinterName, string pPortName, DeviceCapabilities pDc, int pLength)
        {
            StringCollection strings = new StringCollection();
            int num = Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, IntPtr.Zero, IntPtr.Zero);
            if (num > 0)
            {
                IntPtr output = Marshal.AllocCoTaskMem(pLength * num);
                Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, output, IntPtr.Zero);
                for (int i = 0; i < num; i++)
                {
                    int num3 = output.ToInt32() + (pLength * i);
                    IntPtr ptr = new IntPtr(num3);
                    strings.Add(Marshal.PtrToStringAuto(ptr));
                }
                Marshal.FreeCoTaskMem(output);
            }
            return strings;
        }

        private static Collection<Point> GetDeviceCapabilitiesPoint(string pPinterName, string pPortName, DeviceCapabilities pDc)
        {
            Collection<Point> collection = new Collection<Point>();
            int num = Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, IntPtr.Zero, IntPtr.Zero);
            if (num > 0)
            {
                IntPtr output = Marshal.AllocCoTaskMem(8 * num);
                Win32.DeviceCapabilitiesW(pPinterName, pPortName, (int) pDc, output, IntPtr.Zero);
                for (int i = 0; i < num; i++)
                {
                    Point item = new Point();
                    item.X = Marshal.ReadInt32(new IntPtr(output.ToInt32() + (i * 8)));
                    item.Y = Marshal.ReadInt32(new IntPtr((output.ToInt32() + (i * 8)) + 4));
                    collection.Add(item);
                }
                Marshal.FreeCoTaskMem(output);
            }
            return collection;
        }

        public static void GetPaperSize(string pPinterName, string pPortName, string pFormName, out double pWidth, out double pHeight)
        {
            if ((string.IsNullOrEmpty(pPinterName) || string.IsNullOrEmpty(pFormName)) || string.IsNullOrEmpty(pPortName))
            {
                pWidth = pHeight = 0.0;
            }
            else
            {
                int index = GetDeviceCapabilities(pPinterName, pPortName, DeviceCapabilities.PAPERNAMES, 0x80).IndexOf(pFormName);
                if (index == -1)
                {
                    throw new Exception("无法获取选定纸张大小,可以手动设置或选择其它格式纸张！");
                }
                Collection<Point> collection = GetDeviceCapabilitiesPoint(pPinterName, pPortName, DeviceCapabilities.PAPERSIZE);
                Point point = collection[index];
                pWidth = Math.Round((double) (((double) point.X) / 100.0), 1);
                Point point2 = collection[index];
                pHeight = Math.Round((double) (((double) point2.Y) / 100.0), 1);
            }
        }
    }
}

