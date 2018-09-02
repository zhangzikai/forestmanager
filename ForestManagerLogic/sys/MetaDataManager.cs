using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.mid.sys;
using td.db.orm;
using td.db.orm.mssql;
using td.db.service.sys;

namespace td.logic.sys
{
    /// <summary>
    /// 元数据管理类
    /// </summary>
    public class MetaDataManager
    {
        public MetaDataManager()
        {

        }
        public T_SYS_META_TABLE_Service TableService { get { return DBServiceFactory<T_SYS_META_TABLE_Service>.Service; } }
        public T_SYS_META_FIELDS_Service ColumnService { get { return DBServiceFactory<T_SYS_META_FIELDS_Service>.Service; } }
        public T_SYS_DB_INFO_Service DBInfoService { get { return DBServiceFactory<T_SYS_DB_INFO_Service>.Service; } }

        public T_STAT_REPORT_Service ReportService { get { return DBServiceFactory<T_STAT_REPORT_Service>.Service; } }
        #region 数据库元数据表
        public IList<T_SYS_META_FIELDS_Mid> FindColumnsByTable(string tableName)
        {
            T_SYS_META_TABLE_Mid mid=TableService.FindByTableName(tableName);
            if (null == mid) return new List<T_SYS_META_FIELDS_Mid>();
           
            return ColumnService.FindBySql("TAB_ID='"+mid.TAB_ID+"'");
        }
        #endregion
        public IList<T_STAT_REPORT_Mid> FindReport(string theme)
        {
            return ReportService.FindBySql("theme='" + theme + "' and IsShow=1 order by reportid");
        }
        public T_STAT_REPORT_Mid FindReport(string theme,string reportID)
        {
            return ReportService.FindOneBySql("theme='" + theme + "' and  reportid='" + reportID+"'");
        }
        public T_SYS_META_CODE_Service MetaCodeService
        {
            get { return DBServiceFactory<T_SYS_META_CODE_Service>.Service; }
        }
     
        # region 基础
        public IList<T_SYS_META_CODE_Mid> FindDomain(string cDomainName)
        {
            return MetaCodeService.FindBySql("CDOMAIN='" + cDomainName + "'");
        }
        public IList<T_SYS_META_CODE_Mid> FindDomainByIndex(string cindex)
        {
            return MetaCodeService.FindBySql("CINDEX='" + cindex + "'");
        }
        public string FindNameByIndex(string cindex, string ccode)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='" + cindex + "' and ccode='" + ccode + "'");
            if (null != mid) return mid.CNAME;
            return cindex + ":" + ccode;
        }
        public string FindName(string cDomainName, string ccode)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CDOMAIN='" + cDomainName + "' and ccode='" + ccode + "'");
            if (null != mid) return mid.CNAME;
            return cDomainName + ":" + ccode;
        }
        #endregion
        # region 行政区
        public IList<T_SYS_META_CODE_Mid> XianList
        {
            get { return MetaCodeService.FindBySql("CINDEX='103'"); }
        }
       
        public IList<T_SYS_META_CODE_Mid> FindXiang(string xian)
        {
              return MetaCodeService.FindBySql("CINDEX='104' and pcode='"+xian+"'"); 
        }
        public IList<T_SYS_META_CODE_Mid> FindCun(string xiang)
        {
            return MetaCodeService.FindBySql("CINDEX='105' and pcode='" + xiang + "'");
        }
        public string FindShengName(string sheng)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='101' and ccode='" + sheng + "'");
            if (null != mid) return mid.CNAME;
            return sheng;
        }
        public string FindShiName(string shi)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='102' and ccode='" + shi + "'");
            if (null != mid) return mid.CNAME;
            return shi;
        }
        public string FindXianName(string xian)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='103' and ccode='" + xian + "'");
            if (null != mid) return mid.CNAME;
            return xian;
        }
        public string FindXiangName(string xiang)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='104' and ccode='" + xiang + "'");
            if (null != mid) return mid.CNAME;
            return xiang;
        }
        public string FindCunName(string cun)
        {
            T_SYS_META_CODE_Mid mid = MetaCodeService.FindOneBySql("CINDEX='105' and ccode='" + cun + "'");
            if (null != mid) return mid.CNAME;
            return cun;
        }
        public string FindXQName(string code)
        {
            if(code.Length==9)
            {
                return FindXiangName(code);
            }
            else if(code.Length==6)
            {
                return FindXianName(code);
            }
            if(code.Length==4)
            {
                return FindShiName(code);
            }
            if(code.Length==2)
            {
                return FindShengName(code);
            }
            if(code.Length==12)
            {
                return FindCunName(code);
            }
            return code;
        }
        # endregion
        public T_DESIGNKIND_Service DKService
        {
            get { return DBServiceFactory<T_DESIGNKIND_Service>.Service; }
        }
 
        public string DBVersion
        {
            get
            {
              return  DBServiceFactory<T_SYS_DB_INFO_Service>.Service.FindDBValueByItem("VERSION");
            }
        }
        public bool UpdateDB(string sql)
        {
            return DBServiceFactory<T_SYS_DB_INFO_Service>.Service.ExecuteSql(sql)>-1;
        }
        public bool UpdateDBInfo(string key,string value)
        {
            T_SYS_DB_INFO_Mid mid = DBInfoService.FindOneBySql("V_ITEM='" + key + "'");
           if (null == mid) return false;
           mid.V_VALUE = value;
           return DBInfoService.Edit(mid);
        }
        public string ConnectionString
        {
            get{
                return TDMSSqlDBConnection.Single.MSSqlCon.ConnectionString;
            }
            set
            {
                TDMSSqlDBConnection.Single.Init(value);
            }
        }
        public bool IsOpen
        {
            get { return TDMSSqlDBConnection.Single.IsOpen(); }
        }
         
      
    }
}
