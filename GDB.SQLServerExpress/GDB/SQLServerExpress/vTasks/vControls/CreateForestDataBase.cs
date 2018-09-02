namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.Properties;
    using GDB.SQLServerExpress.vTasks.vForms;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Types;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class CreateForestDataBase : UserControlBase1
    {
        private ForestDBServerInfo _dbServerInfo;
        private ServerConnection _serverConnection;
        private ButtonEdit bntEdit_dataDir;
        private IContainer components;
        public bool CreateSuccess;
        private LabelControl labelControl1;
        private LabelControl labelControl8;
        private SimpleButton sb_Create;
        private string sCode;
        private string sYear;
        private TextEdit txt_year;

        public CreateForestDataBase()
        {
            this.InitializeComponent();
        }

        private void bntEdit_dataDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ServerDirectory directory = new ServerDirectory();
            directory.Init(this._serverConnection, false, false);
            if (directory.ShowDialog() == DialogResult.OK)
            {
                this.bntEdit_dataDir.Text = directory.Path;
                this.bntEdit_dataDir.ForeColor = Color.Black;
            }
        }

        private void CompressDatabase(Server pServer, string pDbName, string pPath)
        {
            this._serverConnection.Connect();
            string path = this.bntEdit_dataDir.Text + pDbName + ".ldf";
            string str2 = this.bntEdit_dataDir.Text + pDbName + ".mdf";
            pServer.KillAllProcesses(pDbName);
            pServer.DetachDatabase(pDbName, false);
            System.IO.File.Delete(path);
            StringCollection files = new StringCollection {
                str2
            };
            pServer.AttachDatabase(pDbName, files);
            this._serverConnection.Disconnect();
        }

        private bool CreateDatabase(string code, string year)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                baseDirectory = baseDirectory.Remove(baseDirectory.LastIndexOf("bin"));
                string pDataBaseName = null;
                string sqlCommand = null;
                string newValue = null;
                Server pServer = new Server(this._serverConnection);
                int num = int.Parse(year) - 1;
                newValue = code + "_" + year;
                pDataBaseName = "FORDATA_" + newValue;
                baseDirectory = baseDirectory + @"Template\FORDATA\";
                using (StreamReader reader = new StreamReader(baseDirectory + "Database.db", Encoding.Default))
                {
                    sqlCommand = reader.ReadToEnd();
                }
                sqlCommand = sqlCommand.Replace("{1}", newValue).Replace("{0}", this.bntEdit_dataDir.Text).Replace("{2}", year).Replace("{3}", num.ToString());
                WaitDialog dialog = null;
                try
                {
                    string str5 = "select count(*) from dbo.sysdatabases where name='" + pDataBaseName + "'";
                    if (!this._serverConnection.IsOpen)
                    {
                        this._serverConnection.Connect();
                    }
                    object obj2 = pServer.ConnectionContext.ExecuteScalar(str5);
                    dialog = new WaitDialog {
                        Owner = base.ParentForm
                    };
                    dialog.Show();
                    Application.DoEvents();
                    if (obj2.ToString() == "0")
                    {
                        dialog.SetProgress("正在创建数据库...");
                        pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
                    }
                    else
                    {
                        XtraMessageBox.Show("数据库已存在！");
                        dialog.Close();
                        return true;
                    }
                    bool flag = Dns.GetHostName().ToUpper() != pServer.NetName.ToUpper();
                    pServer.ConnectionContext.BeginTransaction();
                    dialog.SetProgress("正在加载元数据...");
                    if (!flag)
                    {
                        this.LoadFORDATAMetaData(pServer, baseDirectory + "Local", newValue, pDataBaseName);
                    }
                    else
                    {
                        this.LoadFORDATAMetaData(baseDirectory + "Server", newValue, pDataBaseName);
                    }
                    dialog.SetProgress("正在删除域...");
                    this.DeleteDomain(pServer, pDataBaseName, code);
                    dialog.SetProgress("正在删除冗余数据...");
                    this.DeleteOverData(pServer, code, new string[] { "T_SYS_LD_ADMIN_CODES", "T_SYS_META_CODE" });
                    pServer.ConnectionContext.CommitTransaction();
                    this._serverConnection.Disconnect();
                    if (!flag)
                    {
                        dialog.SetProgress("压缩数据库");
                        this.CompressDatabase(pServer, pDataBaseName, baseDirectory);
                    }
                    dialog.SetProgress("完成");
                    dialog.Close();
                    XtraMessageBox.Show("数据库创建成功！");
                }
                catch (Exception exception)
                {
                    if (dialog != null)
                    {
                        dialog.SetProgress("正在回退数据...");
                    }
                    pServer.ConnectionContext.RollBackTransaction();
                    if (this._serverConnection.IsOpen)
                    {
                        this._serverConnection.Disconnect();
                    }
                    if (dialog != null)
                    {
                        dialog.Close();
                        dialog.Dispose();
                    }
                    XtraMessageBox.Show("数据库创建失败：" + exception.Message);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CreateForestDataBase_Load(object sender, EventArgs e)
        {
            this.txt_year.Focus();
        }

        private void CreateView(Server pServer, string pYear)
        {
            string sqlCommand = string.Format(Resources.CREATE_VIEW, pYear);
            pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
        }

        private void DeleteDomain(Server pServer, string pDbName, string pCode)
        {
            Database database = pServer.Databases[pDbName];
            string str = pCode.Substring(0, 4);
            string str2 = pCode + "001";
            string str3 = str2 + "001";
            string str4 = ((int.Parse(pCode) + 1)).ToString() + "001";
            string str5 = str4 + "001";
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code!=" + str + "])') where Name='SHI'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code!=" + pCode + "])') where Name='XIAN'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code<" + str2 + " or Code>=" + str4 + "])') where Name='XIANG'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code<" + str3 + " or Code>=" + str5 + "])') where Name='CUN'");
        }

        private void DeleteOverData(Server pServer, string pCode, string[] pTables)
        {
            string str = pCode.Substring(0, 4);
            foreach (string str2 in pTables)
            {
                string sqlCommand = "delete from " + str2 + " where (ccode!='" + str + "' and len(ccode)=4 and ctype='市') or (ccode not like '%" + pCode + "%' and len(ccode)>=6 and CTYPE IN('县','乡','村'))";
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sb_Create = new DevExpress.XtraEditors.SimpleButton();
            this.txt_year = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bntEdit_dataDir = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sb_Create
            // 
            this.sb_Create.Location = new System.Drawing.Point(343, 181);
            this.sb_Create.Name = "sb_Create";
            this.sb_Create.Size = new System.Drawing.Size(75, 23);
            this.sb_Create.TabIndex = 40;
            this.sb_Create.Text = "创建";
            this.sb_Create.Click += new System.EventHandler(this.sb_Create_Click);
            // 
            // txt_year
            // 
            this.txt_year.EditValue = "2016";
            this.txt_year.Location = new System.Drawing.Point(19, 32);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(150, 20);
            this.txt_year.TabIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(19, 11);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(72, 14);
            this.labelControl8.TabIndex = 38;
            this.labelControl8.Text = "数据库年度：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "数据库存放路径：";
            // 
            // bntEdit_dataDir
            // 
            this.bntEdit_dataDir.EditValue = "";
            this.bntEdit_dataDir.Location = new System.Drawing.Point(19, 104);
            this.bntEdit_dataDir.Name = "bntEdit_dataDir";
            this.bntEdit_dataDir.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bntEdit_dataDir.Properties.Appearance.Options.UseForeColor = true;
            this.bntEdit_dataDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bntEdit_dataDir.Size = new System.Drawing.Size(399, 20);
            this.bntEdit_dataDir.TabIndex = 36;
            this.bntEdit_dataDir.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bntEdit_dataDir_ButtonClick);
            // 
            // CreateForestDataBase
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.sb_Create);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.bntEdit_dataDir);
            this.Name = "CreateForestDataBase";
            this.Size = new System.Drawing.Size(437, 224);
            this.Load += new System.EventHandler(this.CreateForestDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void InitialValue(ForestDBServerInfo dbServerInfo, string code)
        {
            try
            {
                this._dbServerInfo = dbServerInfo;
                this.sCode = code;
                string serverName = this._dbServerInfo.ServerName;
                this._serverConnection = new ServerConnection(serverName, this._dbServerInfo.UserName, this._dbServerInfo.UserPass);
                this._serverConnection.Connect();
                this.txt_year.Text = "";
                this.txt_year.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void LoadFORDATAMetaData(string pPath, string pExtendInfo, string pDataBaseName)
        {
            string s = pExtendInfo.Substring(pExtendInfo.Length - 4, 4);
            string newValue = (int.Parse(s) - 1).ToString();
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str3 = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,SDE_raster_columns,T_SYS_META_TABLE,SDE_process_information";
            SqlConnection pConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[] { this._serverConnection.ServerInstance, pDataBaseName, this._serverConnection.TrueLogin, this._serverConnection.Password }));
            SqlTransaction pTransaction = null;
            try
            {
                pConnection.Open();
                pTransaction = pConnection.BeginTransaction();
                foreach (FileInfo info2 in files)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(info2.Name);
                    if (str3.Contains(fileNameWithoutExtension))
                    {
                        string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pExtendInfo + ".txt";
                        using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                        {
                            string contents = reader.ReadToEnd().Replace("{1}", pExtendInfo).Replace("{2}", s).Replace("{3}", newValue);
                            System.IO.File.WriteAllText(path, contents, Encoding.Default);
                        }
                        this.WriteToServer(Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", path, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                    else
                    {
                        this.WriteToServer(Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", info2.FullName, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                }
                pTransaction.Commit();
                pConnection.Close();
            }
            catch
            {
                if (pConnection.State != ConnectionState.Closed)
                {
                    pConnection.Close();
                }
                throw;
            }
        }

        private void LoadFORDATAMetaData(Server pServer, string pPath, string pExtendInfo, string pDataBaseName)
        {
            string s = pExtendInfo.Substring(pExtendInfo.Length - 4, 4);
            string newValue = (int.Parse(s) - 1).ToString();
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str3 = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,SDE_raster_columns,T_SYS_META_TABLE,SDE_process_information";
            string sqlCommand = null;
            foreach (FileInfo info2 in files)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(info2.Name);
                if (str3.Contains(fileNameWithoutExtension))
                {
                    string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pExtendInfo + ".txt";
                    using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                    {
                        string contents = reader.ReadToEnd().Replace("{1}", pExtendInfo).Replace("{2}", s).Replace("{3}", newValue);
                        System.IO.File.WriteAllText(path, contents, Encoding.Default);
                    }
                    sqlCommand = string.Format("Bulk insert {0}.[dbo].[" + fileNameWithoutExtension + "] from '" + path + "' with(formatfile = '" + Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml') ", pDataBaseName);
                }
                else
                {
                    sqlCommand = string.Format("Bulk insert {0}.[dbo].[" + fileNameWithoutExtension + "] from '" + info2.FullName + "' with(formatfile = '" + Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')", pDataBaseName);
                }
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        private void sb_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_year.Text))
            {
                XtraMessageBox.Show("请填写数据库年份！", "数据库创建", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.sYear = this.txt_year.Text.Trim();
                if (string.IsNullOrEmpty(this.bntEdit_dataDir.Text))
                {
                    XtraMessageBox.Show("请选择数据库存放路径！", "数据库创建", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DirectoryInfo info = new DirectoryInfo(this.bntEdit_dataDir.Text.Trim());
                    if (!info.Exists)
                    {
                        XtraMessageBox.Show("请选择存在数据库存放路径！", "数据库创建", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (this.CreateDatabase(this.sCode, this.sYear))
                    {
                        this.CreateSuccess = true;
                        (base.Tag as Form).Hide();
                    }
                    else
                    {
                        this.CreateSuccess = false;
                    }
                }
            }
        }

        private void UpdateUser(Server pServer, string pCreateUser)
        {
            pServer.ConnectionContext.ExecuteNonQuery("UPDATE T_SYS_DB_INFO SET V_VALUE='" + pCreateUser + "' WHERE V_ITEM='PRODUCER'");
            pServer.ConnectionContext.ExecuteNonQuery("UPDATE T_SYS_DB_INFO SET V_VALUE='" + DateTime.Now.ToString("yyyyMMdd") + "' WHERE V_ITEM='PRDATE'");
        }

        private void WriteToServer(string pFormatFile, string pDataFile, string pTablename, SqlConnection pConnection, SqlTransaction pTransaction)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pFormatFile);
            string str = document.GetElementsByTagName("FIELD").Item(0).Attributes["TERMINATOR"].Value;
            DataTable table = new DataTable();
            IEnumerator enumerator = document.GetElementsByTagName("COLUMN").GetEnumerator();
            enumerator.Reset();
            int num = -1;
            int num2 = -1;
            while (enumerator.MoveNext())
            {
                XmlNode current = enumerator.Current as XmlNode;
                string columnName = current.Attributes["NAME"].Value;
                string str3 = current.Attributes["xsi:type"].Value;
                DataColumn column = new DataColumn(columnName);
                num++;
                switch (str3)
                {
                    case "SQLINT":
                        column.DataType = typeof(int);
                        break;

                    case "SQLSMALLINT":
                        column.DataType = typeof(short);
                        break;

                    case "SQLUNIQUEID":
                        column.DataType = typeof(Guid);
                        break;

                    case "SQLUDT":
                        column.DataType = typeof(SqlGeometry);
                        num2 = num;
                        break;

                    default:
                        column.DataType = typeof(string);
                        break;
                }
                table.Columns.Add(column);
            }
            using (StreamReader reader = new StreamReader(pDataFile, Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    string str4 = reader.ReadLine();
                    if (!string.IsNullOrEmpty(str4))
                    {
                        string[] strArray = str4.Split(str.ToCharArray());
                        DataRow row = table.NewRow();
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i] == "")
                            {
                                if ((table.Columns[i].DataType == typeof(short)) || (table.Columns[i].DataType == typeof(int)))
                                {
                                    row[i] = DBNull.Value;
                                }
                                else
                                {
                                    row[i] = null;
                                }
                            }
                            else if (i == num2)
                            {
                                SqlChars geometryTaggedText = new SqlChars(strArray[i].ToString());
                                row[i] = SqlGeometry.STGeomFromText(geometryTaggedText, 0x1202);
                            }
                            else
                            {
                                row[i] = strArray[i];
                            }
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            using (SqlBulkCopy copy = new SqlBulkCopy(pConnection, SqlBulkCopyOptions.KeepIdentity, pTransaction))
            {
                copy.BatchSize = table.Rows.Count;
                copy.BulkCopyTimeout = 60;
                copy.DestinationTableName = pTablename;
                copy.WriteToServer(table);
            }
        }
    }
}

