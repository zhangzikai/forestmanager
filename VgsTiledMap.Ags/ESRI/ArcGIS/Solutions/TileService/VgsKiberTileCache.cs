namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class VgsKiberTileCache : Dictionary<RawTile, MemoryStream>
    {
        public int MemoryCacheCapacity = 0x16;
        private long memoryCacheSize;
        private readonly Queue<RawTile> Queue = new Queue<RawTile>();

        public void Add(RawTile key, MemoryStream value)
        {
            this.Queue.Enqueue(key);
            base.Add(key, value);
            this.memoryCacheSize += value.Length;
            if (this.MemoryCacheSize > (this.MemoryCacheCapacity * 2))
            {
                this.RemoveMemoryOverload();
            }
        }

        private void Remove(RawTile key)
        {
        }

        internal void RemoveMemoryOverload()
        {
            while (this.MemoryCacheSize > this.MemoryCacheCapacity)
            {
                if (base.Keys.Count <= 0)
                {
                    break;
                }
                if (this.Queue.Count <= 0)
                {
                    return;
                }
                RawTile key = this.Queue.Dequeue();
                try
                {
                    using (MemoryStream stream = base[key])
                    {
                        base.Remove(key);
                        this.memoryCacheSize -= stream.Length;
                    }
                    continue;
                }
                catch
                {
                    continue;
                }
            }
        }

        public double MemoryCacheSize
        {
            get
            {
                return (((double) this.memoryCacheSize) / 1048576.0);
            }
        }
    }
}

