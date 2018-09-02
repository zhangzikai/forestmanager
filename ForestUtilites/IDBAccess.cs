namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;

    public interface IDBAccess
    {
        bool AddDBParameter(IDbCommand pCommand, IDbDataParameter pDBParam);
        bool AddDBParameter(IDbCommand pCommand, object pValue);
        bool AddDBParameter(IDbCommand pCommand, string sName, object pValue);
        bool CheckConnection(IDbConnection pConn);
        int ExecuteNonQuery(IDbCommand pCommand);
        int ExecuteNonQuery(string sCmdText);
        int ExecuteNonQuery(IDbConnection pConn, string sCmdText);
        object ExecuteScalar(IDbCommand pCommand);
        object ExecuteScalar(string sCmdText);
        object ExecuteScalar(IDbConnection pConn, string sCmdText);
        IDataReader GetDataReader(IDbCommand pCommand, CommandBehavior eBehavior);
        IDataReader GetDataReader(string sCmdText, CommandBehavior eBehavior);
        IDataReader GetDataReader(IDbConnection pConn, string sCmdText, CommandBehavior eBehavior);
        DataTable GetDataTable(IDBAccess pDBAccess, string sql);
        DataTable GetDataTable(IDBAccess pDBAccess, string TableName, string FieldsName, string OrderByStr, string WhereStr, bool flag);
        IDbCommand GetDBCommand(string sCmdText);
        IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText);
        DbDataAdapter GetDBDataAdapter(IDbCommand pCommand, bool bCmdBuilder);
        DbDataAdapter GetDBDataAdapter(string sCmdText, bool bCmdBuilder);
        DbDataAdapter GetDBDataAdapter(IDbConnection pConn, string sCmdText, bool bCmdBuilder);
        IDbCommand GetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter);
        IDbCommand GetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter);
        IDbCommand GetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter);
        IDbCommand GetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter);
        IDbDataParameter GetDBParameter();
        IDbTransaction GetDBTransaction();
        IDbTransaction GetDBTransaction(IsolationLevel eIL);
        IDbTransaction GetDBTransaction(IDbConnection pConn, IsolationLevel eIL);
        bool InitConnection();
        bool Initialize(IDbConnection pConn);
        bool Initialize(string sDBKey);
        bool SetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        bool SetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        bool SetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);
        bool SetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand);

        IDbConnection Connection { get; }

        string ConnectionString { get; }

        string DBKey { get; }

        string DBMS { get; }

        DBProviderType DBProvider { get; }

        bool Enabled { get; }
    }
}

