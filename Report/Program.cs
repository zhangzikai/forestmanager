using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    class Program
    {
         [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new ReportCustom());
            
        }
    }
}
