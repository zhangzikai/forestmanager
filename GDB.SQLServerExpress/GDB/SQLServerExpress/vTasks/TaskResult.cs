namespace GDB.SQLServerExpress.vTasks
{
    using System;
    using System.Runtime.CompilerServices;

    public class TaskResult
    {
        public string Msg { get; set; }

        public object Result { get; set; }

        public bool Success { get; set; }
    }
}

