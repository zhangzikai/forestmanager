namespace VgsTiledMap.Ags
{
    using System;
    using System.Threading;

    public class MultipleThreadResetEvent : IDisposable
    {
        private long current;
        private readonly ManualResetEvent done;
        private readonly int total;

        public MultipleThreadResetEvent(int total)
        {
            this.total = total;
            this.current = total;
            this.done = new ManualResetEvent(false);
        }

        public void Dispose()
        {
            this.done.Dispose();
        }

        public void SetOne()
        {
            if (Interlocked.Decrement(ref this.current) == 0L)
            {
                this.done.Set();
            }
        }

        public void WaitAll()
        {
            this.done.WaitOne();
        }
    }
}

