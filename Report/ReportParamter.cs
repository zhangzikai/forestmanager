namespace Report
{
    using ESRI.ArcGIS.Carto;
    using System;
    using System.Collections.Generic;
    using td.db.mid.forest;
    using td.logic.forest;

    /// <summary>
    /// 报表参数类
    /// </summary>
    public class ReportParamter
    {
        private string _bk;
        private string _dataTable;
        private string _distCode;
        private string _exportPath;
        private IFeatureLayer _featureLayer;
        private List<string> _ids;
        private List<string> _names;
        private StaticMsg _statisticsMsg;
        private SystemType _sysType;
        private string _taskID;
        private string _taskName;
        private StatisticsTheme _theme;
        private string _year;
        private string _yueFen;

        public FindMidFromLayer<T_ZT_HZ_INFO_Mid> FindFromTable { get; set; }
        public FindMidFromLayer<ZT_LYAJ_Mid> FindFromLayer_AJ { get; set; }

        public FindMidFromLayer<ZT_CF_Mid> FindFromLayer_CF { get; set; }
        public FindMidFromLayer<ZT_ZH_Mid> FindFromLayer_ZH { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FindMidFromLayer<FOR_XIAOBAN_Mid> FindFromLayer_XB { get; set; }
        public string BK
        {
            get
            {
                return this._bk;
            }
            set
            {
                this._bk = value;
            }
        }

        public string DataTable
        {
            get
            {
                return this._dataTable;
            }
            set
            {
                this._dataTable = value;
            }
        }

        public string DistCode
        {
            get
            {
                return this._distCode;
            }
            set
            {
                this._distCode = value;
            }
        }

        public string ExportPath
        {
            get
            {
                return this._exportPath;
            }
            set
            {
                this._exportPath = value;
            }
        }

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

        public List<string> IDs
        {
            get
            {
                return this._ids;
            }
            set
            {
                this._ids = value;
            }
        }

        public List<string> Names
        {
            get
            {
                return this._names;
            }
            set
            {
                this._names = value;
            }
        }

        /// <summary>
        /// 获取和设置静态的信息
        /// </summary>
        public StaticMsg StatisticsMsg
        {
            get
            {
                return this._statisticsMsg;
            }
            set
            {
                this._statisticsMsg = value;
            }
        }

        /// <summary>
        /// 报表参数：获取和设置系统类型
        /// </summary>
        public SystemType SysType
        {
            get
            {
                return this._sysType;
            }
            set
            {
                this._sysType = value;
            }
        }

        /// <summary>
        /// 报表参数：获取和设置任务ID
        /// </summary>
        public string TaskID
        {
            get
            {
                return this._taskID;
            }
            set
            {
                this._taskID = value;
            }
        }

        /// <summary>
        /// 报表参数：获取和设置任务名称
        /// </summary>
        public string TaskName
        {
            get
            {
                return this._taskName;
            }
            set
            {
                this._taskName = value;
            }
        }

        public StatisticsTheme Theme
        {
            get
            {
                return this._theme;
            }
            set
            {
                this._theme = value;
            }
        }

        /// <summary>
        /// 报表参数：获取和设置任务年度
        /// </summary>
        public string Year
        {
            get
            {
                return this._year;
            }
            set
            {
                this._year = value;
            }
        }

        public string YueFen
        {
            get
            {
                return this._yueFen;
            }
            set
            {
                this._yueFen = value;
            }
        }
    }
}

