namespace GDB.SQLServerExpress
{
    using System;

    public enum TaskStatus
    {
        Stopped,
        Aborted,
        ThrowErrorStoped,
        Running,
        CancelPending,
        AbortPending
    }
}

