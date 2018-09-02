namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class DBAccessSqlClient : DBAccessBase
    {
        private const string mClassName = "Utilities.DBAccessSqlClient";

        internal DBAccessSqlClient()
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
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessSqlClient(IDbConnection pConn)
        {
            try
            {
                if (pConn is SqlConnection)
                {
                    this.Initialize(pConn);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessSqlClient(string sDBKey)
        {
            try
            {
                this.Initialize(sDBKey);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                if (!(pDBParam is SqlParameter))
                {
                    return false;
                }
                SqlCommand command = null;
                command = pCommand as SqlCommand;
                command.Parameters.Add(pDBParam);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlCommand command = null;
                command = pCommand as SqlCommand;
                command.Parameters.Add(pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlCommand command = null;
                command = pCommand as SqlCommand;
                command.Parameters.AddWithValue(sName, pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText)
        {
            try
            {
                if (!(pConn is SqlConnection))
                {
                    return null;
                }
                if (!this.CheckConnection(pConn))
                {
                    return null;
                }
                return new SqlCommand(sCmdText, pConn as SqlConnection);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is SqlCommand))
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(pCommand as SqlCommand);
                if (bCmdBuilder)
                {
                    new SqlCommandBuilder(adapter);
                }
                return adapter;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return null;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                return adapter.DeleteCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return null;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                return adapter.InsertCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBDataAdapterInsertCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return null;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                return adapter.SelectCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return null;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                return adapter.UpdateCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBDataAdapterUpdateCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbDataParameter GetDBParameter()
        {
            try
            {
                return new SqlParameter();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function GetDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                adapter.DeleteCommand = pCommand as SqlCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function SetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                adapter.InsertCommand = pCommand as SqlCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                adapter.SelectCommand = pCommand as SqlCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is SqlDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is SqlCommand))
                {
                    return false;
                }
                SqlDataAdapter adapter = null;
                adapter = pDataAdapter as SqlDataAdapter;
                adapter.UpdateCommand = pCommand as SqlCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessSqlClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}

