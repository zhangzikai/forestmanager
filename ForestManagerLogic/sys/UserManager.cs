using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using td.db.mid.sys;
using td.db.orm;
using td.db.service.sys;

namespace td.logic.sys
{
    public class UserManager
    {
        private static UserManager s_service;
        private static object s_lock = new object();
        public static UserManager Single
        {
            get
            {
                if (null != s_service)
                {
                    return s_service;
                }
                lock (s_lock)
                {
                    if (null == s_service)
                    {
                        s_service = new UserManager();
                    }
                }
                return s_service;
            }
        }        
        protected T_SYS_FLOW_USER_Mid UserInfo { get; set; }
        public T_SYS_FLOW_DEPT_Service DeptService
        {
            get { return DBServiceFactory<T_SYS_FLOW_DEPT_Service>.Service; }
        }
        public T_SYS_FLOW_USER_Service UserService
        {
            get { return DBServiceFactory<T_SYS_FLOW_USER_Service>.Service; }
        }
        public T_SYS_USER_AUTHOR_Service UserAuthService
        {
            get { return DBServiceFactory<T_SYS_USER_AUTHOR_Service>.Service; }
        }
        public T_SYS_FLOW_AUTHOR_Service AuthService
        {
            get { return DBServiceFactory<T_SYS_FLOW_AUTHOR_Service>.Service; }
        }
        public IList<T_SYS_FLOW_DEPT_Mid> AllDepts
        {
            get
            {
                return DeptService.FindAll();
            }
        }
        public IList<T_SYS_FLOW_USER_Mid> FindUserByDept(int deptID)
        {
            return UserService.FindBySql("USER_DEPT=" + deptID);
        }
        private IList<T_SYS_FLOW_AUTHOR_Mid> m_authList;
        public UserManager()
        {
            m_authList = new List<T_SYS_FLOW_AUTHOR_Mid>();
        }
        public void Log(string sOperate, string sRemark, string sSystem)
        {
            try
            {
                DateTime now = DateTime.Now;
                T_LOG_Mid mid = new T_LOG_Mid();
                mid.USER_NAME = UserInfo.USER_NAME;
                mid.OPERATE = sOperate;
                mid.LOG_TIME = DateTime.Now;
                mid.REMARK = sRemark;
                mid.SYSTEM = sSystem;
                DBServiceFactory<T_LOG_Service>.Service.Add(mid);
            }
            catch
            {

            }
        }
        public bool ClearLog()
        {
            DBServiceFactory<T_LOG_Service>.Service.Clear();
            return true;
        }
        public int ExecuteNonQuery(string sql)
        {
            return DBServiceFactory<T_LOG_Service>.Service.ExectNoneQuerySql(sql);
        }
        public bool DeleteSingleLog(string sLogID)
        {
            DBServiceFactory<T_LOG_Service>.Service.Delete(Convert.ToInt32(sLogID));         
            return true;
        }
        public bool DeleteLog(DateTime pStartTime, DateTime pEndTime, string sType, string sSystemType)
        {
            string str = "";
          
            string str3 = str;
            str = str3 + "log_time>='" + pStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and log_time<'" + pEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (sSystemType != "")
            {
                str = str + " and system='" + sSystemType + "'";
            }
            if (sType != "")
            {
                str = str + " and operate='" + sType + "'";            }
        
            DBServiceFactory<T_LOG_Service>.Service.DeleteBySql(str);
            return true;
        }
        public IList<T_LOG_Mid> GetLogs(DateTime pStartTime, DateTime pEndTime, string sType, string sSystem)
        {
            string str = "";
         
           
            string str3 = str;
            str = str3 + "log_time>='" + pStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and log_time<'" + pEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
           
            if (sSystem != "")
            {
                str = str + " and system='" + sSystem + "'";
            }
            if (sType != "")
            {
                str = str + " and operate='" + sType + "'";
            }
            string sSql = "";
            sSql =  str + " order by log_time desc";
            return DBServiceFactory<T_LOG_Service>.Service.FindBySql(sSql);
        }

        public int DeleteUser(int userID)
        {
            DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.Delete(userID);
            return DBServiceFactory<T_SYS_USER_AUTHOR_Service>.Service.DeleteBySql("USER_ID=" + userID);

        }
        public bool IsUserNameExist(string uName)
        {
            return DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.IsUserExist(uName);
        }
        public Tuple<bool, string> Login2(string sUserName, string sPasswrd)
        {
            if (sUserName == "")
            {
                return new Tuple<bool, string>(false, "请输入用户名!");
            }
            try
            {
                if (!DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.IsUserExist(sUserName))
                {
                    return new Tuple<bool, string>(false, "此用户名不存在!");
                }
                UserInfo = DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.FindByUserAndPws(sUserName, sPasswrd);
                if (null == UserInfo)
                {
                    return new Tuple<bool, string>(false, "密码错误!");
                }

                m_authList = DBServiceFactory<T_SYS_USER_AUTHOR_Service>.Service.FindAuthByUID(UserInfo.ID);
                if ((m_authList == null) || (m_authList.Count < 1))
                {
                    return new Tuple<bool, string>(false, "用户没有进入所选系统的权限!");
                }
               
                bool flag2 = false;
                string str8 = "";
                foreach (T_SYS_FLOW_AUTHOR_Mid aMid in m_authList)
                {
                    if (str8 == "")
                    {
                        str8 = aMid.SYSTEM_ZT;
                    }
                    else
                    {
                        str8 = str8 + "," + aMid.SYSTEM_ZT;
                    }
                }
                if (!flag2)
                {
                    return new Tuple<bool, string>(false, "用户没有进入所选系统的权限!");
                }
                UserInfo.IsManager = flag2;
                Log("登录系统", "系统管理", "系统管理");
                return new Tuple<bool, string>(true, str8);
            }
            catch
            {

                return new Tuple<bool, string>(false, "登录系统出错!");
            }
        }
        public Tuple<bool, string> Login(string sUserName, string sPasswrd, string sKind)
        {          
            if (sUserName == "")
            {
                return new Tuple<bool,string>(false,"请输入用户名!");               
            }
            try
            {
                if (!DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.IsUserExist(sUserName))
                {
                    return new Tuple<bool, string>(false, "此用户名不存在!");
                }
                UserInfo = DBServiceFactory<T_SYS_FLOW_USER_Service>.Service.FindByUserAndPws(sUserName, sPasswrd);
                if (null == UserInfo)
                {
                    return new Tuple<bool, string>(false, "密码错误!");
                }

                m_authList = DBServiceFactory<T_SYS_USER_AUTHOR_Service>.Service.FindAuthByUID(UserInfo.ID);
                if ((m_authList == null) || (m_authList.Count < 1))
                {
                    return new Tuple<bool, string>(false, "用户没有进入所选系统的权限!");
                }
                    bool flag = false;
                    bool flag2 = false;
                    foreach (T_SYS_FLOW_AUTHOR_Mid aMid in m_authList)
                    {
                        if (aMid.SYSTEM_ZT == sKind)
                        {
                            flag = true;
                            
                        }
                        else if (aMid.SYSTEM_ZT == "系统管理")
                        {
                            flag2 = true;
                        }
                    }
                    if (!flag)
                    {
                        return new Tuple<bool, string>(false, "用户没有进入所选系统的权限!");
                    }
                    UserInfo.IsManager = flag2;
                    Log("登录系统", sKind, sKind);
                    return new Tuple<bool, string>(true, "正常登录系统!");
                }               
            catch
            {

                return new Tuple<bool, string>(false, "登录系统出错!");
            }
        }
    }
}