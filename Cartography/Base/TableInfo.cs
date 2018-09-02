namespace Cartography.Base
{
    using ESRI.ArcGIS.Carto;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TableInfo
    {
        private IFeatureLayer _featureLayer;
        private string _title;
        private string _graphType;
        private bool _useSelection;
        private string _condition;
        private string _fieldName;
        private string _sectionName;
        private bool _custom;
        public IFeatureLayer FeatureLayer
        {
            get
            {
                return this._featureLayer;
            }
            set
            {
                this._featureLayer = value;
            }
        }
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
        public string GraphType
        {
            get
            {
                return this._graphType;
            }
            set
            {
                this._graphType = value;
            }
        }
        public bool UseSelection
        {
            get
            {
                return this._useSelection;
            }
            set
            {
                this._useSelection = value;
            }
        }
        public string Condition
        {
            get
            {
                return this._condition;
            }
            set
            {
                this._condition = value;
            }
        }
        public string FieldName
        {
            get
            {
                return this._fieldName;
            }
            set
            {
                this._fieldName = value;
            }
        }
        public string SectionName
        {
            get
            {
                return this._sectionName;
            }
            set
            {
                this._sectionName = value;
            }
        }
        public bool Custom
        {
            get
            {
                return this._custom;
            }
            set
            {
                this._custom = value;
            }
        }
    }
}

