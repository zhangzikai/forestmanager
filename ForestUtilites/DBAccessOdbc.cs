namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.Odbc;
    using System.Windows.Forms;

    public class DBAccessOdbc : DBAccessBase
    {
        private const string mClassName = "Utilities.DBAccessOdbc";

        internal DBAccessOdbc()
        {
            try
            {
                base.mEnabled = false;
                base.mDBKey = "";
                base.mDBMS = "";
                base.mDBProvider = DBProviderType.DBProviderTypeNull;
                base.mConnectionString = "";
                base.mConnection = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOdbc(IDbConnection pConn)
        {
            try
            {
                if (pConn is OdbcConnection)
                {
                    this.Initialize(pConn);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOdbc(string sDBKey)
        {
            try
            {
                this.Initialize(sDBKey);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool AddDBParameter(IDbCommand pCommand, IDbDataParameter pDBParam)
        {
            try
            {
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                if (!(pDBParam is OdbcParameter))
                {
                    return false;
                }
                OdbcCommand command = null;
                command = pCommand as OdbcCommand;
                command.Parameters.Add(pDBParam);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool AddDBParameter(IDbCommand pCommand, object pValue)
        {
            try
            {
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcCommand command = null;
                command = pCommand as OdbcCommand;
                command.Parameters.Add(pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool AddDBParameter(IDbCommand pCommand, string sName, object pValue)
        {
            try
            {
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcCommand command = null;
                command = pCommand as OdbcCommand;
                command.Parameters.AddWithValue(sName, pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override DataTable GetDataTable(IDBAccess pDBAccess, string sql)
        {
            try
            {
                DbDataAdapter dBDataAdapter = pDBAccess.GetDBDataAdapter(sql, true);
                DataSet dataSet = new DataSet();
                dBDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDataTable\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override DataTable GetDataTable(IDBAccess pDBAccess, string TableName, string FieldsName, string OrderByStr, string WhereStr, bool flag)
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
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDataTable\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText)
        {
            try
            {
                if (!(pConn is OdbcConnection))
                {
                    return null;
                }
                if (!this.CheckConnection(pConn))
                {
                    return null;
                }
                return new OdbcCommand(sCmdText, pConn as OdbcConnection);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override DbDataAdapter GetDBDataAdapter(IDbCommand pCommand, bool bCmdBuilder)
        {
            try
            {
                if (pCommand == null)
                {
                    return null;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                OdbcDataAdapter adapter = new OdbcDataAdapter(pCommand as OdbcCommand);
                if (bCmdBuilder)
                {
                    new OdbcCommandBuilder(adapter);
                }
                return adapter;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbCommand GetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return null;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return null;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                return adapter.DeleteCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbCommand GetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return null;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return null;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                return adapter.InsertCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBDataAdapterInsertCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbCommand GetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return null;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return null;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                return adapter.SelectCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbCommand GetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return null;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return null;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                return adapter.UpdateCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBDataAdapterUpdateCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbDataParameter GetDBParameter()
        {
            try
            {
                return new OdbcParameter();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function GetDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override bool SetDBDataAdapterDeleteCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return false;
                }
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                adapter.DeleteCommand = pCommand as OdbcCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function SetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool SetDBDataAdapterInsertCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return false;
                }
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                adapter.InsertCommand = pCommand as OdbcCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool SetDBDataAdapterSelectCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return false;
                }
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                adapter.SelectCommand = pCommand as OdbcCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool SetDBDataAdapterUpdateCommand(DbDataAdapter pDataAdapter, IDbCommand pCommand)
        {
            try
            {
                if (pDataAdapter == null)
                {
                    return false;
                }
                if (pCommand == null)
                {
                    return false;
                }
                if (!(pDataAdapter is OdbcDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OdbcCommand))
                {
                    return false;
                }
                OdbcDataAdapter adapter = null;
                adapter = pDataAdapter as OdbcDataAdapter;
                adapter.UpdateCommand = pCommand as OdbcCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOdbc\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}

