namespace GDB.SQLServerExpress.vTasks.vControls
{
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DataSetInfo
    {
        private string _path;
        private esriDatasetType _type;
        public string Path
        {
            get
            {
                return this._path;
            }
            set
            {
                this._path = value;
            }
        }
        public esriDatasetType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

