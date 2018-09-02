namespace Desktop
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    internal static class Program
    {
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Application.ExitThread();
            MessageBox.Show(e.Exception.Message);
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
            Application.Run(new DataBaseInstaller());
        }
    }
}

