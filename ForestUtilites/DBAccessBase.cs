namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public abstract class DBAccessBase : IDBAccess
    {
        private const string mClassName = "Utilities.DBAccessBase";
        protected IDbConnection mConnection;
        protected string mConnectionString = "";
        protected string mDBKey = "";
        protected string mDBMS = "";
        protected DBProviderType mDBProvider;
        protected bool mEnabled;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();

        protected DBAccessBase()
        {
        }

        public abstract bool AddDBParameter(IDbCommand pCommand, IDbDataParameter pDBParam);
        public abstract bool AddDBParameter(IDbCommand pCommand, object pValue);
        public abstract bool AddDBParameter(IDbCommand pCommand, string sName, object pValue);
        public virtual bool CheckConnection(IDbConnection pConn)
        {
            try
            {
                if (pConn == null)
                {
                    pConn = this.mConnection;
                }
                if (pConn == null)
                {
                    return false;
                }
                if (pConn.State == ConnectionState.Closed)
                {
                    if (string.IsNullOrEmpty(this.mConnectionString))
                    {
                        return false;
                    }
                    pConn.ConnectionString = this.mConnectionString;
                    pConn.Open();
                }
                if (pConn.State == ConnectionState.Broken)
                {
                    pConn.Close();
                    pConn.Open();
                }
                return (pConn.State == ConnectionState.Open);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function CheckConnection\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public void Dispose()
        {
            try
            {
                try
                {
                    if ((this.mConnection != null) && ((this.mConnection.State != ConnectionState.Closed) | (this.mConnection.State != ConnectionState.Broken)))
                    {
                        this.mConnection.Close();
                        this.mConnection.Dispose();
                    }
                }
                catch (Exception)
                {
                }
                this.mConnection = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual int ExecuteNonQuery(IDbCommand pCommand)
        {
            try
            {
                if (pCommand == null)
                {
                    return -1;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return -1;
                }
                return pCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteNonQuery\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
        }

        public virtual int ExecuteNonQuery(string sCmdText)
        {
            try
            {
                return this.ExecuteNonQuery(this.mConnection, sCmdText);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteNonQuery\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
        }

        public virtual int ExecuteNonQuery(IDbConnection pConn, string sCmdText)
        {
            try
            {
                IDbCommand pCommand = null;
                pCommand = this.GetDBCommand(pConn, sCmdText);
                if (pCommand == null)
                {
                    return -1;
                }
                return this.ExecuteNonQuery(pCommand);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteNonQuery\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
        }

        public virtual object ExecuteScalar(IDbCommand pCommand)
        {
            try
            {
                if (pCommand == null)
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                return pCommand.ExecuteScalar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteScalar\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual object ExecuteScalar(string sCmdText)
        {
            try
            {
                return this.ExecuteScalar(this.mConnection, sCmdText);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteScalar\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual object ExecuteScalar(IDbConnection pConn, string sCmdText)
        {
            try
            {
                IDbCommand pCommand = null;
                pCommand = this.GetDBCommand(pConn, sCmdText);
                if (pCommand == null)
                {
                    return null;
                }
                return this.ExecuteScalar(pCommand);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function ExecuteScalar\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDataReader GetDataReader(IDbCommand pCommand, CommandBehavior eBehavior)
        {
            try
            {
                if (pCommand == null)
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                return pCommand.ExecuteReader(eBehavior);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDataReader\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDataReader GetDataReader(string sCmdText, CommandBehavior eBehavior)
        {
            try
            {
                return this.GetDataReader(this.mConnection, sCmdText, eBehavior);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDataReader\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDataReader GetDataReader(IDbConnection pConn, string sCmdText, CommandBehavior eBehavior)
        {
            try
            {
                IDbCommand pCommand = null;
                pCommand = this.GetDBCommand(pConn, sCmdText);
                if (pCommand == null)
                {
                    return null;
                }
                return this.GetDataReader(pCommand, eBehavior);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDataReader\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual DataTable GetDataTable(IDBAccess pDBAccess, string sql)
        {
            try
            {
                DbDataAdapter dBDataAdapter = pDBAccess.GetDBDataAdapter(sql, true);
                if (dBDataAdapter == null)
                {
                    return null;
                }
                DataSet dataSet = new DataSet();
                dBDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("", "Utilities.DBAccessBase", "GetDataTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public virtual DataTable GetDataTable(IDBAccess pDBAccess, string TableName, string FieldsName, string OrderByStr, string WhereStr, bool flag)
        {
            try
            {
                string sCmdText = "Select " + FieldsName + " From " + TableName;
                if (WhereStr != "")
                {
                    sCmdText = sCmdText + " Where " + WhereStr;
                }
                if (OrderByStr != "")
                {
                    sCmdText = sCmdText + " ORDER BY " + OrderByStr;
                }
                DbDataAdapter dBDataAdapter = pDBAccess.GetDBDataAdapter(sCmdText, flag);
                DataSet dataSet = new DataSet();
                dBDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDataTable\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDbCommand GetDBCommand(string sCmdText)
        {
            try
            {
                return this.GetDBCommand(this.mConnection, sCmdText);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public abstract IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText);
        public abstract DbDataAdapter GetDBDataAdapter(IDbCommand pCommand, bool bCmdBuilder);
        public virtual DbDataAdapter GetDBDataAdapter(string sCmdText, bool bCmdBuilder)
        {
            try
            {
                return this.GetDBDataAdapter(this.mConnection, sCmdText, bCmdBuilder);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual DbDataAdapter GetDBDataAdapter(IDbConnection pConn, string sCmdText, bool bCmdBuilder)
        {
            try
            {
                IDbCommand pCommand = null;
                pCommand = this.GetDBCommand(pConn, sCmdText);
                if (pCommand == null)
                {
                    return null;
                }
                return this.GetDBDataAdapter(pCommand, bCmdBuilder);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public abstract IDbCommand GetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter);
        public abstract IDbCommand GetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter);
        public abstract IDbCommand GetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter);
        public abstract IDbCommand GetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter);
        private bool GetDBInfoFromINI(string sDBKey)
        {
            try
            {
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBInfoFromINI\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool GetDBInfoFromREG(string sDBKey)
        {
            try
            {
                string str3;
                string str = "";
                str = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "DBMS");
                DBProviderType dBProviderTypeNull = DBProviderType.DBProviderTypeNull;
                string str20 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "DBProvider").ToLower().Trim();
                if (str20 != null)
                {
                    if (str20 != "odbc")
                    {
                        if (str20 == "oledb")
                        {
                            goto Label_008C;
                        }
                        if (str20 == "oracleclient")
                        {
                            goto Label_0090;
                        }
                        if (str20 == "sqlclient")
                        {
                            goto Label_0094;
                        }
                        if (str20 == "sqlServerce")
                        {
                            goto Label_0098;
                        }
                    }
                    else
                    {
                        dBProviderTypeNull = DBProviderType.DBProviderTypeOdbc;
                    }
                }
                goto Label_009A;
            Label_008C:
                dBProviderTypeNull = DBProviderType.DBProviderTypeOleDb;
                goto Label_009A;
            Label_0090:
                dBProviderTypeNull = DBProviderType.DBProviderTypeOracleClient;
                goto Label_009A;
            Label_0094:
                dBProviderTypeNull = DBProviderType.DBProviderTypeSqlClient;
                goto Label_009A;
            Label_0098:
                dBProviderTypeNull = DBProviderType.DBProviderTypeSqlServerCe;
            Label_009A:
                str3 = "";
                string str4 = null;
                str4 = "";
                if (!string.IsNullOrEmpty(str4) & (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc))
                {
                    str3 = str3 + "Driver=" + str4 + ";";
                }
                string str5 = null;
                str5 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "Provider");
                if (!string.IsNullOrEmpty(str5) & (dBProviderTypeNull == DBProviderType.DBProviderTypeOleDb))
                {
                    str3 = str3 + "Provider=" + str5 + ";";
                }
                string str6 = null;
                str6 = "";
                if (!string.IsNullOrEmpty(str6) & (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc))
                {
                    str3 = str3 + "DSN=" + str6 + ";";
                }
                string str7 = null;
                str7 = "";
                if (!string.IsNullOrEmpty(str7) & (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc))
                {
                    str3 = str3 + "DBQ=" + str7 + ";";
                }
                string str8 = null;
                str8 = "";
                if (!string.IsNullOrEmpty(str8) & (dBProviderTypeNull != DBProviderType.DBProviderTypeOleDb))
                {
                    str3 = str3 + "Server=" + str8 + ";";
                }
                string str9 = null;
                str9 = "";
                if (!string.IsNullOrEmpty(str9) & ((dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc) | (dBProviderTypeNull == DBProviderType.DBProviderTypeSqlClient)))
                {
                    str3 = str3 + "Database=" + str9 + ";";
                }
                string str10 = null;
                if (sDBKey == "Access")
                {
                    str10 = UtilFactory.GetConfigOpt().GetConfigValue("AppPath") + @"\" + UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "DataSource");
                }
                else
                {
                    str10 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "DataSource");
                }
                if (!string.IsNullOrEmpty(str10))
                {
                    str3 = str3 + "Data Source=" + str10 + ";";
                }
                string str11 = null;
                str11 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "InitialCatalog");
                if (!string.IsNullOrEmpty(str11) & ((dBProviderTypeNull == DBProviderType.DBProviderTypeOleDb) | (dBProviderTypeNull == DBProviderType.DBProviderTypeSqlClient)))
                {
                    str3 = str3 + "Initial Catalog=" + str11 + ";";
                }
                string str12 = null;
                str12 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "UserID");
                if (!string.IsNullOrEmpty(str12))
                {
                    str12 = str12.ToString();
                    if (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc)
                    {
                        str3 = str3 + "UID=" + str12 + ";";
                    }
                    else
                    {
                        str3 = str3 + "User ID=" + str12 + ";";
                    }
                }
                string str13 = "";
                if (sDBKey != "Access")
                {
                    str13 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "Password");
                }
                if (!string.IsNullOrEmpty(str13))
                {
                    str13 = str13.ToString();
                    if (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc)
                    {
                        str3 = str3 + "PWD=" + str13 + ";";
                    }
                    else
                    {
                        str3 = str3 + "Password=" + str13 + ";";
                    }
                }
                string str14 = null;
                str14 = UtilFactory.GetConfigOpt().GetConfigValue2(sDBKey, "LocalPassword");
                if (!string.IsNullOrEmpty(str14) & (dBProviderTypeNull == DBProviderType.DBProviderTypeOleDb))
                {
                    str14 = str14.ToString();
                    str3 = str3 + "Jet OLEDB:Database Password=" + str14 + ";";
                }
                string str15 = null;
                str15 = "";
                if (!string.IsNullOrEmpty(str15))
                {
                    str3 = str3 + "Extended Properties=" + str15 + ";";
                }
                string str16 = null;
                str16 = "";
                if (!string.IsNullOrEmpty(str16))
                {
                    if (dBProviderTypeNull == DBProviderType.DBProviderTypeOdbc)
                    {
                        str3 = str3 + "Trusted_Connection=" + str16 + ";";
                    }
                    else
                    {
                        str3 = str3 + "Integrated Security=" + str16 + ";";
                    }
                }
                string configValue = null;
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("PersistSecurityInfo");
                if (!string.IsNullOrEmpty(configValue))
                {
                    str3 = str3 + "Persist Security Info=" + configValue + ";";
                }
                string str18 = null;
                str18 = "";
                if (!string.IsNullOrEmpty(str18) & ((dBProviderTypeNull == DBProviderType.DBProviderTypeOleDb) | (dBProviderTypeNull == DBProviderType.DBProviderTypeSqlClient)))
                {
                    str3 = str3 + "Connect Timeout=" + str18 + ";";
                }
                string str19 = null;
                str19 = "";
                if (!string.IsNullOrEmpty(str19))
                {
                    str3 = str3 + str19 + ";";
                }
                this.mDBMS = str;
                this.mDBProvider = dBProviderTypeNull;
                this.mConnectionString = str3;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBInfoFromREG\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool GetDBInfoFromUDL(string sDBKey)
        {
            try
            {
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBInfoFromUDL\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public abstract IDbDataParameter GetDBParameter();
        public virtual IDbTransaction GetDBTransaction()
        {
            try
            {
                if (!this.CheckConnection(this.mConnection))
                {
                    return null;
                }
                return this.mConnection.BeginTransaction();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBTransaction\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDbTransaction GetDBTransaction(IsolationLevel eIL)
        {
            try
            {
                if (!this.CheckConnection(this.mConnection))
                {
                    return null;
                }
                return this.mConnection.BeginTransaction(eIL);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBTransaction\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual IDbTransaction GetDBTransaction(IDbConnection pConn, IsolationLevel eIL)
        {
            try
            {
                if (!this.CheckConnection(pConn))
                {
                    return null;
                }
                return pConn.BeginTransaction(eIL);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function GetDBTransaction\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public virtual bool InitConnection()
        {
            try
            {
                IDbConnection connection = null;
                switch (this.mDBProvider)
                {
                    case DBProviderType.DBProviderTypeOdbc:
                        connection = new OdbcConnection();
                        break;

                    case DBProviderType.DBProviderTypeOleDb:
                        connection = new OleDbConnection();
                        break;

                    case DBProviderType.DBProviderTypeOracleClient:
                        connection = new OracleConnection();
                        break;

                    case DBProviderType.DBProviderTypeSqlClient:
                        connection = new SqlConnection();
                        break;

                    default:
                        return false;
                }
                connection.ConnectionString = this.mConnectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    this.mConnection = connection;
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("", "Utilities.DBAccessBase", "InitConnection", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool InitDBInfo(string sDBKey)
        {
            try
            {
                if (sDBKey == "")
                {
                    sDBKey = UtilFactory.GetConfigOpt().GetConfigValue("DBKey");
                }
                ConnectionStringDepository connStrSaveAtREG = (ConnectionStringDepository) 0;
                connStrSaveAtREG = (ConnectionStringDepository) int.Parse(UtilFactory.GetConfigOpt().GetConfigValue("ConnectionStringDepository"));
                if (connStrSaveAtREG == ((ConnectionStringDepository) 0))
                {
                    UtilFactory.GetConfigOpt().SetConfigValue("ConnectionStringDepository", ConnectionStringDepository.ConnStrSaveAtREG.ToString());
                    connStrSaveAtREG = ConnectionStringDepository.ConnStrSaveAtREG;
                }
                bool dBInfoFromREG = false;
                switch (connStrSaveAtREG)
                {
                    case ConnectionStringDepository.ConnStrSaveAtREG:
                        dBInfoFromREG = this.GetDBInfoFromREG(sDBKey);
                        break;

                    case ConnectionStringDepository.ConnStrSaveAtUDL:
                        dBInfoFromREG = this.GetDBInfoFromUDL(sDBKey);
                        break;

                    case ConnectionStringDepository.ConnStrSaveAtINI:
                        dBInfoFromREG = this.GetDBInfoFromINI(sDBKey);
                        break;
                }
                return dBInfoFromREG;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function InitDBInfo\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public virtual bool Initialize(IDbConnection pConn)
        {
            try
            {
                this.mEnabled = false;
                this.mDBKey = "";
                this.mDBMS = "";
                this.mDBProvider = DBProviderType.DBProviderTypeNull;
                this.mConnectionString = "";
                this.mConnection = null;
                if (this.CheckConnection(pConn))
                {
                    if (pConn is OdbcConnection)
                    {
                        OdbcConnection connection = pConn as OdbcConnection;
                        this.mDBMS = connection.Driver;
                        this.mDBProvider = DBProviderType.DBProviderTypeOdbc;
                        goto Label_00D1;
                    }
                    if (pConn is OleDbConnection)
                    {
                        OleDbConnection connection2 = pConn as OleDbConnection;
                        this.mDBMS = connection2.Provider;
                        this.mDBProvider = DBProviderType.DBProviderTypeOleDb;
                        goto Label_00D1;
                    }
                    if (pConn is OracleConnection)
                    {
                        this.mDBMS = "Oracle";
                        this.mDBProvider = DBProviderType.DBProviderTypeOracleClient;
                        goto Label_00D1;
                    }
                    if (pConn is SqlConnection)
                    {
                        this.mDBMS = "SqlServer";
                        this.mDBProvider = DBProviderType.DBProviderTypeSqlClient;
                        goto Label_00D1;
                    }
                    this.mDBProvider = DBProviderType.DBProviderTypeNull;
                }
                return false;
            Label_00D1:
                this.mConnectionString = pConn.ConnectionString;
                this.mConnection = pConn;
                this.mEnabled = true;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function Initialize\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public virtual bool Initialize(string sDBKey)
        {
            try
            {
                this.mEnabled = false;
                this.mDBKey = sDBKey;
                if (!this.InitDBInfo(sDBKey))
                {
                    return false;
                }
                if (!this.InitConnection())
                {
                    return false;
                }
                this.mEnabled = true;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Function Initialize\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public abstract bool SetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        public abstract bool SetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        public abstract bool SetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        public abstract bool SetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        public virtual bool TestConnection()
        {
            bool flag = false;
            try
            {
                if ((this.mConnection == null) && !this.InitConnection())
                {
                    return false;
                }
                flag = true;
            }
            finally
            {
                this.mConnection.Close();
            }
            return flag;
        }

        public IDbConnection Connection
        {
            get
            {
                try
                {
                    if (this.CheckConnection(this.mConnection))
                    {
                        return this.mConnection;
                    }
                    return null;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Utilities.DBAccessBase\n错误出处 : Property Connection Get\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.mConnectionString;
            }
        }

        public string DBKey
        {
            get
            {
                return this.mDBKey;
            }
        }

        public string DBMS
        {
            get
            {
                return this.mDBMS;
            }
        }

        public DBProviderType DBProvider
        {
            get
            {
                return this.mDBProvider;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.mEnabled;
            }
        }
    }
}

