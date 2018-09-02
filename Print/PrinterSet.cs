namespace Print
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PrinterSet
    {
        private string _formName;
        private short _orienTation;
        private string _printerName;
        private string _portName;
        public string FormName
        {
            get
            {
                return this._formName;
            }
            set
            {
                this._formName = value;
            }
        }
        public short OrienTation
        {
            get
            {
                return this._orienTation;
            }
            set
            {
                this._orienTation = value;
            }
        }
        public string PrinterName
        {
            get
            {
                return this._printerName;
            }
            set
            {
                this._printerName = value;
            }
        }
        public string PortName
        {
            get
            {
                return this._portName;
            }
            set
            {
                this._portName = value;
            }
        }
    }
}

