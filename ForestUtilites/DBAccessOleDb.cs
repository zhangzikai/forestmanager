namespace Utilities
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Windows.Forms;

    public class DBAccessOleDb : DBAccessBase
    {
        private const string mClassName = "Utilities.DBAccessOleDb";

        internal DBAccessOleDb()
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
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOleDb(IDbConnection pConn)
        {
            try
            {
                if (pConn is OleDbConnection)
                {
                    this.Initialize(pConn);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        internal DBAccessOleDb(string sDBKey)
        {
            try
            {
                this.Initialize(sDBKey);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Sub New\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                if (!(pDBParam is OleDbParameter))
                {
                    return false;
                }
                OleDbCommand command = null;
                command = pCommand as OleDbCommand;
                command.Parameters.Add(pDBParam);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbCommand command = null;
                command = pCommand as OleDbCommand;
                command.Parameters.Add(pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbCommand command = null;
                command = pCommand as OleDbCommand;
                command.Parameters.AddWithValue(sName, pValue);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function AddDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override IDbCommand GetDBCommand(IDbConnection pConn, string sCmdText)
        {
            try
            {
                if (!(pConn is OleDbConnection))
                {
                    return null;
                }
                if (!this.CheckConnection(pConn))
                {
                    return null;
                }
                return new OleDbCommand(sCmdText, pConn as OleDbConnection);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pCommand is OleDbCommand))
                {
                    return null;
                }
                if (!this.CheckConnection(pCommand.Connection))
                {
                    return null;
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(pCommand as OleDbCommand);
                if (bCmdBuilder)
                {
                    new OleDbCommandBuilder(adapter);
                }
                return adapter;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBDataAdapter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return null;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                return adapter.DeleteCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return null;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                return adapter.InsertCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBDataAdapterInsertCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return null;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                return adapter.SelectCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return null;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                return adapter.UpdateCommand;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBDataAdapterUpdateCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public override IDbDataParameter GetDBParameter()
        {
            try
            {
                return new OleDbParameter();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function GetDBParameter\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                adapter.DeleteCommand = pCommand as OleDbCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function SetDBDataAdapterDeleteCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                adapter.InsertCommand = pCommand as OleDbCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                adapter.SelectCommand = pCommand as OleDbCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!(pDataAdapter is OleDbDataAdapter))
                {
                    return false;
                }
                if (!(pCommand is OleDbCommand))
                {
                    return false;
                }
                OleDbDataAdapter adapter = null;
                adapter = pDataAdapter as OleDbDataAdapter;
                adapter.UpdateCommand = pCommand as OleDbCommand;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBAccessOleDb\n错误出处 : Function SetDBDataAdapterSelectCommand\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}

