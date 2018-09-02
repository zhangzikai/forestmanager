namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OracleClient;
    using System.Windows.Forms;

    public class DBAccessOracleClient : DBAccessBase
    {
        private const string mClassName = "Utilities.DBAccessOracleClient";

        internal DBAccessOracleClient()
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
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOracleClient(IDbConnection pConn)
        {
            try
            {
                if (pConn is OracleConnection)
                {
                    this.Initialize(pConn);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOracleClient(string sDBKey)
        {
            try
            {
                this.Initialize(sDBKey);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                if (!(pDBParam is OracleParameter))
                {
                    return false;
                }
                OracleCommand command = null;
                command = pCommand as OracleCommand;
                command.Parameters.Add(pDBParam);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleCommand command = null;
                command = pCommand as OracleCommand;
                command.Parameters.Add(pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleCommand command = null;
                command = pCommand as OracleCommand;
                command.Parameters.AddWithValue(sName, pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText)
        {
            try
            {
                if (!(pConn is OracleConnection))
                {
                    return null;
                }
                if (!this.CheckConnection(pConn))
                {
                    return null;
                }
                return new OracleCommand(sCmdText, pConn as OracleConnection);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OracleCommand))
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                OracleDataAdapter adapter = new OracleDataAdapter(pCommand as OracleCommand);
                if (bCmdBuilder)
                {
                    new OracleCommandBuilder(adapter);
                }
                return adapter;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return null;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                return adapter.DeleteCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return null;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                return adapter.InsertCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return null;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                return adapter.SelectCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return null;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                return adapter.UpdateCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBDataAdapterUpdateCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbDataParameter GetDBParameter()
        {
            try
            {
                return new OracleParameter();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function GetDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                adapter.DeleteCommand = pCommand as OracleCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function SetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                adapter.InsertCommand = pCommand as OracleCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                adapter.SelectCommand = pCommand as OracleCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OracleDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OracleCommand))
                {
                    return false;
                }
                OracleDataAdapter adapter = null;
                adapter = pDataAdapter as OracleDataAdapter;
                adapter.UpdateCommand = pCommand as OracleCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOracleClient\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}

