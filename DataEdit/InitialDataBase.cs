namespace DataEdit
{
    using System;
    using System.Windows.Forms;

    public class InitialDataBase
    {
        public static bool Initial()
        {
            FormDataBaseLogin login = new FormDataBaseLogin();
            return (login.ShowDialog() == DialogResult.OK);
        }
    }
}

