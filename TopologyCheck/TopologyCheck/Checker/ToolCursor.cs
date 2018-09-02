namespace TopologyCheck.Checker
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using TopologyCheck.Properties;

    internal class ToolCursor
    {
        private static Cursor _validate = new Cursor(new MemoryStream(Resources.Validate));

        public static int Validate
        {
            get
            {
                return _validate.Handle.ToInt32();
            }
        }
    }
}

