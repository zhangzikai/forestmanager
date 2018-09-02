namespace VgsTiledMap.Ags
{
    using System;
    using System.Threading;

    public class TileLoader
    {
        private VgsTilerHelper _arctilerHelper;
        private ManualResetEvent _doneEvent;

        public TileLoader(VgsTilerHelper arctilerHelper, ManualResetEvent doneEvent)
        {
            this._arctilerHelper = arctilerHelper;
            this._doneEvent = doneEvent;
        }

        public void ThreadPoolCallback(object threadContext)
        {
            try
            {
                object[] objArray = (object[]) threadContext;
                int num1 = (int) objArray[0];
                this._doneEvent.Set();
            }
            catch (Exception)
            {
            }
        }
    }
}

